Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
'TODO: valutare implementazioni Fattura elettronica ( da ordine non ho modo, serve elaborazione successiva)
'Todo: Dichiarazione intento lettera W ( magari impostare un campo in anagrafica cliente/ordine) e aggiungerlo agli step di pre-invio( tipo quello dei dati canoni ) ma ne verrano fuori altri

Partial Module Ordini

    ''' <summary>
    ''' Genero righe su Ordine Consuntivo tramite LINQ e OrdContext
    ''' </summary>
    ''' <returns></returns>
    Public Function GeneraRigheOrdineConsuntivo() As Boolean
#Region "Variabili Selezione"
        'Variabili legate alla maschera di selezione 
        Dim bFiltroDateOrdini As Boolean
        Dim fromOrdDate As Date
        Dim sFromOrdDate As String = fromOrdDate.ToShortDateString
        Dim toOrdDate As Date
        Dim sToOrdDate As String = toOrdDate.ToShortDateString
        Dim bSingoloOrdine As Boolean
        Dim nrOrd As String = String.Empty
        Dim bSingoloCliente As Boolean
        Dim cliente As String = String.Empty
        Dim bSingolaFiliale As Boolean
        Dim filiale As String = String.Empty
        Dim dataFattDa As Date
        Dim sDataFattDa As String = dataFattDa.ToShortDateString
        Dim dataFattA As Date
        Dim sDataFattA As String = dataFattA.ToShortDateString
        Dim p_Tutti As Boolean
        Dim p_Annuali As Boolean
        Dim p_Semestrali As Boolean
        Dim p_Quadrimestrali As Boolean
        Dim p_Trimestrali As Boolean
        Dim p_Bimestrali As Boolean
        Dim p_Mensili As Boolean
        Dim p_Periodi(6) As Boolean
        Dim filtri As New StringBuilder()

#Region "Regole di richiesta "
        'Lancio la form con le regole di richiesta
        Using ff = New FAskFiltriOrdini
            Dim result As DialogResult = ff.ShowDialog
            If result = DialogResult.OK Then
                bFiltroDateOrdini = ff.RadDalAl.Checked
                fromOrdDate = OnlyDate(ff.DtaOrdineDA.Value)
                toOrdDate = OnlyDate(ff.DtaOrdineA.Value)
                bSingoloOrdine = ff.ChkNrOrdine.Checked
                nrOrd = ff.TxtNrOrdine.Text '.PadLeft(6, "0")
                bSingoloCliente = ff.ChkCliente.Checked
                cliente = ff.TxtOrdCliente.Text
                bSingolaFiliale = ff.ChkFiliale.Checked
                filiale = ff.TxtOrdFiliale.Text
                dataFattDa = OnlyDate(ff.DtaFattDa.Value) 'Data giorno di fatturazione
                dataFattA = OnlyDate(ff.DtaFattA.Value) 'Data giorno di fatturazione
                p_Tutti = ff.ChkP_Tutti.Checked
                p_Annuali = ff.ChkP_Annuali.Checked
                p_Semestrali = ff.ChkP_Semestrali.Checked
                p_Quadrimestrali = ff.ChkP_Quadrimestrali.Checked
                p_Trimestrali = ff.ChkP_Trimestrali.Checked
                p_Bimestrali = ff.ChkP_Bimestrali.Checked
                p_Mensili = ff.ChkP_Mensili.Checked
                p_Periodi(0) = p_Tutti
                p_Periodi(1) = p_Mensili
                p_Periodi(2) = p_Bimestrali
                p_Periodi(3) = p_Trimestrali
                p_Periodi(4) = p_Quadrimestrali
                p_Periodi(5) = p_Semestrali
                p_Periodi(6) = p_Annuali
                filtri.AppendLine(" --- Filtri ---")
                filtri.AppendLine(If(bFiltroDateOrdini, "Dal " & fromOrdDate.ToShortDateString & " al " & toOrdDate.ToShortDateString, "Fino al " & toOrdDate.ToShortDateString))
                filtri.AppendLine("Ordine : " & If(bSingoloOrdine, nrOrd, "TUTTI"))
                filtri.AppendLine("Cliente : " & If(bSingoloCliente, cliente, "TUTTI"))
                filtri.AppendLine("Filiale : " & If(bSingolaFiliale, filiale, "TUTTI"))
                filtri.AppendLine("Dalla data Fatt. :" & dataFattDa.ToShortDateString)
                filtri.AppendLine("Alla data Fatt. :" & dataFattA.ToShortDateString)
                If p_Tutti Then
                    filtri.AppendLine("Periodo : Tutti")
                Else
                    If p_Annuali Then filtri.AppendLine("Periodo : Annuali")
                    If p_Semestrali Then filtri.AppendLine("Periodo : Semestrali")
                    If p_Quadrimestrali Then filtri.AppendLine("Periodo : Quadrimestrali")
                    If p_Trimestrali Then filtri.AppendLine("Periodo : Trimestrali")
                    If p_Bimestrali Then filtri.AppendLine("Periodo : Bimestrali")
                    If p_Mensili Then filtri.AppendLine("Periodo : Mensili")
                End If
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & filtri.ToString)

            ElseIf result = DialogResult.Cancel Then
                Return False
                Exit Function
            End If
        End Using
#End Region
        'TODO: ordine tabella totali = Summary ??
        Dim someTrouble As Boolean = False
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()
        Dim avvisi As New StringBuilder()
        Dim debugging As New StringBuilder()
        Dim msgLog As String

        Dim totOrdini As Integer
        Dim totOrdiniConNuoveRighe As Integer       ' Totale ordini con righe contratto che fatturate
        Dim totOrdiniConRigheAggiornate As Integer  ' Totale ordini con righe contratto che vengono aggiorate
        Dim bIsSomething As Boolean
        Dim totInterventi As Integer

#End Region

        Try
#Region "Estrazioni dati con Query LINQ"
            'https://entityframework.net/why-first-query-slow
            'Tipizzare con (Of ) solo le Tabelle singole 1-1 che NON hanno 1-n / Collection
            Dim q = (From o In OrdContext.MaSaleOrd _
                            .Include(Function(r) r.MaSaleOrdDetails) _
                            .Include(Function(acc) acc.ALLOrdCliAcc) _
                            .Include(Function(des) des.ALLordCliDescrizioni) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Of MaItems)(Function(it) it.MaItems) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Of AlltipoRigaServizio)(Function(trs) trs.AlltipoRigaServizio) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                 .ThenInclude(Function(att) att.AllordCliAttivita) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                 .ThenInclude(Function(att) att.AllordCliAttivita) _
                                        .ThenInclude(Of Allattivita)(Function(at) at.Allattivita) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(dis) dis.AllordCliContrattoDistinta) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Of MaItems)(Function(it) it.MaItems) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Of AlltipoRigaServizio)(Function(trs) trs.AlltipoRigaServizio) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(servAgg) servAgg.AllordCliContrattoDistintaServAgg) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(servAgg) servAgg.AllordCliContrattoDistintaServAgg) _
                                        .ThenInclude(Of MaItems)(Function(it) it.MaItems) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(servAgg) servAgg.AllordCliContrattoDistintaServAgg) _
                                        .ThenInclude(Of AlltipoRigaServizio)(Function(trs) trs.AlltipoRigaServizio) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(des) des.AllordCliContrattoDescFatt)
                         )
 _
            'q = q.Where(Function(i) i.MaSaleOrdDetails..)
            'AGGIUNGO  FILTRI
            'Vengono esclusi a priori gli ordini con data cessazione > di Data Competenza
            'Il filtro where che prende quelli senza data cessazione o con data successiva ( preimpostata da loro)
            ' q = q.Where(Function(facc) facc.ALLOrdCliAcc.DataCessazione = sDataNulla OrElse facc.ALLOrdCliAcc.DataCessazione.Value.Date >= dataFattA)
            If bFiltroDateOrdini Then
                q = q.Where(Function(oDate) oDate.OrderDate.Value.Date >= fromOrdDate And oDate.OrderDate.Value.Date <= toOrdDate)
            Else
                'Sostituisco la logica di "uguale" aggiungendo un giorno, in questo modo prendo anche le cose create nello stesso giorno
                q = q.Where(Function(oDate) oDate.OrderDate <= toOrdDate)
            End If
            If bSingoloCliente Then q = q.Where(Function(oCli) oCli.Customer.Equals(cliente))
            If bSingoloOrdine Then q = q.Where(Function(oNrOrd) oNrOrd.InternalOrdNo.Equals(nrOrd))
            If bSingolaFiliale Then q = q.Where(Function(oFiliale) oFiliale.CostCenter.Equals(filiale))


            Dim l = (From o In OrdContext.IntegraInterventi)
            'If bAskFilter Then
            'l = l.Where(Function(oDate) oDate.DataInsert.Value.Date >= fromLogDate And oDate.DataInsert.Value.Date <= toLogDate)
            'If bSingolaFiliale Then l = l.Where(Function(oFiliale) oFiliale.Filiale.Equals(filiale))
            'End If

            Dim dist = (From o In OrdContext.AllordCliContrattoDistinta.Include(Function(sa) sa.AllordCliContrattoDistintaServAgg))

            Dim allServAgg = dist.ToList
            Dim allInterventi = l.ToList
#End Region
            'Creo le entities che usero' poi con BulkInsert
            Dim efMaSaleOrd As New List(Of MaSaleOrd)
            Dim efMaSaleOrdDetails As New List(Of MaSaleOrdDetails)
            Dim efMaSaleOrdSummary As New List(Of MaSaleOrdSummary)
            Dim efAllordCliAcc As New List(Of AllordCliAcc)
            Dim efAllordCliAttivita As New List(Of AllordCliAttivita)
            Dim efAllordCliContratto As New List(Of AllordCliContratto)
            Dim efAllordCliContrattoDistinta As New List(Of AllordCliContrattoDistinta)
            Dim efAllordCliContrattoDistintaServAgg As New List(Of AllordCliContrattoDistintaServAgg)

            If allInterventi.Any Then
                totInterventi = allInterventi.Count
                Debug.Print("Interventi Estratti : " & totInterventi.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi Estratti : " & totInterventi.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi Estratti : " & totInterventi.ToString)
                EditTestoBarra("Interventi Estratti : " & totInterventi.ToString)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totInterventi
                FLogin.prgCopy.Step = 1

                'Ciclo su tutti gli Interventi
                For Each i In allInterventi
                    AvanzaBarra()
                    Debug.Print("Intervento: " & i.ID)

                Next
            End If

            'ESEGUO LA QUERY (ALDO 30/06 ritorna 1 invece che 2)
            Dim allOrders = q.ToList
            If allOrders.Any Then
                totOrdini = allOrders.Count
                bIsSomething = True
                Debug.Print("Ordini Estratti : " & totOrdini.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Ordini Estratti : " & totOrdini.ToString)
                FLogin.lstStatoConnessione.Items.Add("Ordini Estratti : " & totOrdini.ToString)
                EditTestoBarra("Ordini Estratti : " & totOrdini.ToString)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totOrdini
                FLogin.prgCopy.Step = 1
#Region "Variabili Default"

                Dim defVendite = (From dv In OrdContext.MaUserDefaultSales.ToList Select dv).FirstOrDefault
                ' Dim defContabili = (From dc In OrdContext.MaAccountingDefaults.ToList Select dc).FirstOrDefault
                Dim defIva = (From dc In OrdContext.MaTaxCodesDefaults.ToList Select dc).FirstOrDefault
                Dim codiciIva = (From c In OrdContext.MaTaxCodes.ToList Select c)

                Dim sDefContropartita As String = defVendite.ServicesSalesAccount
                Dim sDefCodIva As String = defIva.TaxCode
                Dim dDefPercIva As Double = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = sDefCodIva).Perc.Value, decPerc)
#End Region
                'Ciclo su tutti gli ordini
                For Each o In allOrders
                    AvanzaBarra()
                    Debug.Print("Ordine: " & o.InternalOrdNo)
                    debugging.AppendLine("Ordine: " & o.InternalOrdNo)
#Region "Inizializzazione"
                    'Resetto alcune cose 
                    Dim iNewRowsCount As Integer = 0
                    Dim isNewRows As Boolean = False    ' Indica se ci sono righe contratto che vengono fatturate e quindi inserite nelle righe
                    Dim isUpdateRows As Boolean = False ' Indica se ci sono righe contratto che vengono aggiorate
                    'Inizializzo alcuni valori
                    Dim cOrd As New CurOrd(o)
                    Dim curLastLine As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Line), 0)
                    Dim curLastPosition As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Position), 0)
                    Dim bScrittoDescrizioni As Boolean = False
                    Dim iNrRigheNota As Integer = 0
                    Dim iNrRigheAValore As Integer = 0
#End Region
                    'STEP 1 : Ciclo le righe contratto
                    For Each c In o.ALLordCliContratto
                        Dim isDaEscludere As Boolean = False
#Region "Controllo Esclusioni righe Contratto"
                        Dim sEx As String = "R:" & c.Line.ToString & " (" & c.TipoRigaServizio & "-" & c.Servizio & ")"
                        Debug.Print(sEx)
                        debugging.AppendLine(sEx)
                        'Blocco Esclusioni Canoni dovute ai filtri di periodo
                        If c.AlltipoRigaServizio.TipologiaServizio = TipologiaServizio.Canone AndAlso Not p_Tutti AndAlso Not IsBewteenPeriodo(c, p_Periodi) Then
                            Debug.Print(" - [ESCLUSA] Fuori filtro periodo")
                            debugging.AppendLine(" - [ESCLUSA] Fuori filtro periodo")
                            Continue For
                        End If
                        If c.AlltipoRigaServizio.TipologiaServizio = TipologiaServizio.Consuntivo Then
                            Debug.Print(" - [ESCLUSA] Consuntivo")
                            debugging.AppendLine(" - [ESCLUSA] Consuntivo")
                            Continue For
                        End If
                        If CBool(c.Fatturato) Then
                            Debug.Print(" - [ESCLUSA] Fatturata")
                            debugging.AppendLine(" - [ESCLUSA] Fatturata")
                            Continue For
                        End If
                        If c.DataDecorrenza = sDataNulla Then
                            Debug.Print(" - [ESCLUSA] Decorrenza non Impostata")
                            debugging.AppendLine(" - [ESCLUSA] Decorrenza non Impostata")
                            Continue For
                        End If
                        If c.DataDecorrenza > dataFattA Then
                            Debug.Print(" - [ESCLUSA] Decorrenza non raggiunta")
                            debugging.AppendLine(" - [ESCLUSA] Decorrenza non raggiunta")
                            Continue For
                        End If

                        'Da qua sotto non fa "Continue For"
                        If c.DataProssimaFatt >= dataFattDa And c.DataProssimaFatt <= dataFattA Then
                            Debug.Print(" + [OK]")
                        Else
                            Debug.Print(" - [ESCLUSA] Fuori filtro data")
                            debugging.AppendLine(" - [ESCLUSA] Fuori filtro data")
                            isDaEscludere = True
                            '26/01/2022 Vanno comunque esaminate per cercare eventuali righe sospese da rifatturare
                            'DEPRECATO il Continue For
                        End If
                        If c.DataProssimaFatt > dataFattA Then
                            Debug.Print(" - [ESCLUSA] Prossima fattura non raggiunta")
                            debugging.AppendLine(" - [ESCLUSA] Prossima fattura non raggiunta")
                            isDaEscludere = True
                            '26/01/2022 Vanno comunque esaminate per cercare eventuali righe sospese da rifatturare
                            'DEPRECATO il Continue For
                        End If
#End Region
#Region "Variabili Correnti"
                        Dim cOrdRow As New CurOrdRow(c) With {
                            .CanoneFuoriRangeDate = isDaEscludere,
                            .Contropartita = If(String.IsNullOrWhiteSpace(c.MaItems.SaleOffset), sDefContropartita, c.MaItems.SaleOffset),
                            .CodIva = If(String.IsNullOrWhiteSpace(c.CodiceIva), sDefCodIva, c.CodiceIva),
                            .PercIva = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = .CodIva).Perc.Value, decPerc),
                            .Parent = cOrd
                        }
                        Dim attDaRifatturare As New List(Of AllordCliAttivita)
                        Dim isISTAT As Boolean = False
                        Dim attIstat As New List(Of AllordCliAttivita)
#End Region
#Region "STEP 3 Attività"
                        For Each att In c.AllordCliAttivita
                            'Determina tipologia
                            Dim tipoAttivita As String = att.GetTipoAttivita
                            msgLog = " # Attiv:(" & att.Line.ToString & "-" & tipoAttivita & ") " & att.Attivita & " " & att.DataInizio.Value.ToShortDateString & " " & att.Nota
                            Debug.Print(msgLog)
                            debugging.AppendLine(msgLog)
#Region "STEP 3a Attività di Sospensione"
                            'STEP 3a: Attività di Sospensione 
                            '---  Esclusioni di Sospensione ---
                            If CBool(att.Allattivita.Sospensione) Then
                                'Fatturata
                                If CBool(att.Fatturata) Then
                                    Debug.Print("  - [Fatturata]")
                                    debugging.AppendLine("  - [Fatturata]")
                                    Continue For
                                End If
                                'Mesi sospesi ( solo se nel periodo)
                                Dim dCanoniSospesi As Double
                                If IsBetweenSospensione(att.DataInizio, att.DataFine, cOrdRow, dCanoniSospesi) Then
                                    msgLog = "  - [Sospensione]: Mesi " & dCanoniSospesi.ToString & " dal " & att.DataInizio.Value.ToShortDateString & " al " & att.DataFine.Value.ToShortDateString
                                    Debug.Print(msgLog)
                                    debugging.AppendLine(msgLog)
                                End If
                                'Mesi da rifatturare
                                Dim dCanoniRipresi As Double
                                If CBool(att.DaFatturare) AndAlso IsBetweenRipresi(att, dataFattDa, dataFattA, dCanoniRipresi) Then
                                    cOrdRow.DaRifatturare = True
                                    If dCanoniRipresi > 0 Then
                                        'Setto il valore nella proprietà  Shadow
                                        att.CanoniRipresi = dCanoniRipresi
                                        cOrdRow.QtaDaRifatturare += dCanoniRipresi
                                        attDaRifatturare.Add(att)
                                        cOrdRow.IsOk = True
                                        msgLog = "  - [Ripresa]: " & att.CanoniRipresi.ToString & " mesi il " & att.DataRifatturazione.Value.ToShortDateString
                                        Debug.Print(msgLog)
                                        debugging.AppendLine(msgLog)
                                        'Segno la riga come Fatturata
                                        att.Fatturata = "1"
                                        att.Tbmodified = Now
                                        att.TbmodifiedId = sLoginId
                                        efAllordCliAttivita.Add(att)
                                    End If
                                End If
                            End If
#End Region
                            'STEP 3b: Attività di Annullamento 
                            '---  Esclusioni di Annullamento ---
                            If Not cOrdRow.CanoneFuoriRangeDate AndAlso CBool(att.Allattivita.Annullamento) Then
                                If cOrdRow.HaAnnullatoDaAttivita Then
                                    'Non dorvebbe succedere perche' su Mago ho introdotto un controllo
                                    errori.AppendLine("Ordine " & cOrd.OrdNo & " Servizio " & cOrdRow.Item & ": Annullato da piu' attività. Verrà considerata la prima.")
                                Else
                                    cOrdRow.AnnullaDaAttività(att.DataInizio)
                                End If
                            End If

                            'STEP 3c: Attività di Istat 
                            If CBool(att.Allattivita.Istat) Then
                                '--- Controllo Esclusioni di ISTAT---

                                'Fatturata
                                If CBool(att.Fatturata) Then
                                    Debug.Print("  - [Fatturata]")
                                    debugging.AppendLine("  - [Fatturata]")
                                    Continue For
                                End If
                                'E' nel range
                                If CBool(att.DaFatturare) AndAlso IsBetweenIstat(att, dataFattDa, dataFattA) Then
                                    isISTAT = True
                                    cOrdRow.IsOk = True
                                    msgLog = "  - [ISTAT]: il " & att.DataRifatturazione.ToString
                                    Debug.Print(msgLog)
                                    debugging.AppendLine(msgLog)
                                    'Segno la riga come Fatturata
                                    att.Fatturata = "1"
                                    att.Tbmodified = Now
                                    att.TbmodifiedId = sLoginId
                                    attIstat.Add(att) ' Non posso ancora metterla nell' efAllordCliAttivita perche' potrebbe essere tutto sospeso)
                                End If
                            End If

                        Next
#End Region
                        'STEP 4a : Controllo Scadenza Fissa ( se CanoniDataFin >= data Scadenza Fissa su Ordine)
                        If cOrd.HaScadenzaFissa AndAlso Not cOrdRow.CanoneFuoriRangeDate AndAlso cOrdRow.CanoniDataFin >= cOrd.DataScadenzaFissa Then
                            cOrdRow.HaScadenzaFissa = True
                            cOrdRow.DataScadenzaFissa = cOrd.DataScadenzaFissa
                        End If

                        'STEP 4b : Controllo Data Cessazione ( se CanoniDataFin >= data Cessazione su Ordine)
                        If cOrd.HaDataCessazione AndAlso cOrdRow.CanoniDataFin >= cOrd.DataCessazione Then
                            cOrdRow.HaDataCessazione = True
                            cOrdRow.DataCessazione = cOrd.DataCessazione
                        End If

                        'STEP 5:
                        If Not cOrdRow.CanoneFuoriRangeDate AndAlso (cOrdRow.HaScadenzaFissa OrElse cOrdRow.HaDataCessazione OrElse cOrdRow.HaAnnullatoDaAttivita) Then
                            Dim msg As String = ""
                            Dim bEsci As Boolean = False
                            '19/01/2023: Con Laura definiamo che la priorità e' Attività -> Scadenza Fissa -> Data Cessazione

                            'Priorità 1: Attività
                            If Not bEsci AndAlso cOrdRow.HaAnnullatoDaAttivita Then
                                bEsci = True
                                If IsBetweenAnnullamento_Attivita(cOrdRow, msg) Then
                                    Debug.Print(msg)
                                    debugging.AppendLine(msg)
                                    cOrdRow.PeriodoDataFin = cOrdRow.DataCessazioneDaAttivita

                                End If
                            End If

                            'Priorità 2: Scadenza Fissa
                            If Not bEsci AndAlso cOrdRow.HaScadenzaFissa Then
                                bEsci = True
                                If IsBetweenAnnullamento_ScadenzaFissa(cOrdRow, msg) Then
                                    debugging.AppendLine(msg)
                                    cOrdRow.PeriodoDataFin = cOrdRow.DataScadenzaFissa
                                End If
                                'Scrivo Data e Motivo Cessazione
                                If o.ALLOrdCliAcc.DataCessazione = sDataNulla Then
                                    o.ALLOrdCliAcc.DataCessazione = cOrdRow.DataScadenzaFissa
                                    o.ALLOrdCliAcc.MotivoCessazione = "[AUTO] Scadenza Fissa"
                                    o.ALLOrdCliAcc.Tbmodified = Now
                                    o.ALLOrdCliAcc.TbmodifiedId = sLoginId
                                    debugging.AppendLine("Ordine: " & cOrdRow.Parent.OrdNo & " Impostata cessazione: " & cOrdRow.DataScadenzaFissa.ToShortDateString)
                                    efAllordCliAcc.Add(o.ALLOrdCliAcc)
                                End If
                            End If

                            'Priorità 3: Cessazione
                            If Not bEsci AndAlso cOrdRow.HaDataCessazione Then
                                bEsci = True
                                If IsBetweenAnnullamento_Cessazione(cOrdRow, msg) Then
                                    debugging.AppendLine(msg)
                                    cOrdRow.PeriodoDataFin = cOrdRow.DataCessazione
                                    'Scrivo Motivo Cessazione
                                    If String.IsNullOrWhiteSpace(o.ALLOrdCliAcc.MotivoCessazione) Then
                                        'o.ALLOrdCliAcc.DataCessazione = cOrdRow.DataCessazione
                                        o.ALLOrdCliAcc.MotivoCessazione = "[AUTO] Data Cessazione"
                                        o.ALLOrdCliAcc.Tbmodified = Now
                                        o.ALLOrdCliAcc.TbmodifiedId = sLoginId
                                        debugging.AppendLine("Ordine: " & cOrdRow.Parent.OrdNo & " Impostata cessazione: " & cOrdRow.DataCessazione.ToShortDateString)
                                        efAllordCliAcc.Add(o.ALLOrdCliAcc)
                                    End If
                                End If
                            End If
                        End If

                        'Se ok allora creo dettaglio
                        If Not cOrdRow.PrecendementeCessato AndAlso ((cOrdRow.IsOk AndAlso Not cOrdRow.CanoneFuoriRangeDate) OrElse cOrdRow.DaRifatturare) AndAlso (cOrdRow.QtaCorrente > 0 OrElse cOrdRow.QtaDaRifatturare > 0) Then
                            If o.MaSaleOrdDetails.Any AndAlso o.MaSaleOrdDetails.Count = 1 Then
                                If CheckRigaBianca(o.MaSaleOrdDetails.First) Then
                                    cOrd.LastLine = 0
                                    curLastPosition = 0
                                End If
                            End If

                            'Controllo e imposto data prevista consegna con la piu' vecchia ( serve nel caso di rifatturazione)
                            If attDaRifatturare.Any Then
                                For Each aDaRif In attDaRifatturare
                                    If aDaRif.DataRifatturazione < cOrdRow.DataPrevistaConsegna Then
                                        If Not cOrdRow.CanoneFuoriRangeDate Then avvisi.AppendLine("Ordine " & cOrd.OrdNo & " Servizio " & cOrdRow.Item & " con date prevista fatturazione non congruenti !")
                                        cOrdRow.DataPrevistaConsegna = aDaRif.DataRifatturazione
                                        cOrdRow.DataConfermaConsegna = aDaRif.DataRifatturazione
                                    End If
                                Next
                            End If

                            'Scrivo Testo descrittivo su MaSaleOrdDetails
                            isNewRows = True
                            If Not bScrittoDescrizioni Then
                                For Each d In o.ALLordCliDescrizioni
                                    iNewRowsCount += 1
                                    iNrRigheNota += 1
                                    bScrittoDescrizioni = True
                                    Dim rd As MaSaleOrdDetails = RigaDescrittiva(iNewRowsCount, cOrdRow, d.Descrizione)
                                    'Aggiungo la riga alla collection
                                    efMaSaleOrdDetails.Add(rd)
                                    Debug.Print("### Riga descrittiva:(" & rd.Position.ToString & ") " & rd.Description)
                                    debugging.AppendLine(" *D:" & rd.Position.ToString)
                                Next
                            End If

                            cOrdRow.PercIva = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = cOrdRow.CodIva).Perc.Value, decPerc)
                            If cOrdRow.PercIva = 0 Then cOrdRow.PercIva = dDefPercIva
#Region "Righe da rifatturare"
                            For Each aDaRif In attDaRifatturare
                                iNewRowsCount += 1
                                iNrRigheAValore += 1
                                Dim periodoRif As String = "Periodo dal " & aDaRif.DataInizio.Value.ToString("dd/MM/yyyy") & " al " & aDaRif.DataFine.Value.ToString("dd/MM/yyyy")
                                If aDaRif.ValUnit = 0 Then errori.AppendLine("Ordine: " & cOrd.OrdNo & " Pos.: " & (curLastPosition + iNrRigheAValore) & " Servizio: " & cOrdRow.Item & " con valore unitario di ripresa uguale a 0.00")
                                Dim rRif As New MaSaleOrdDetails With {
                                    .Line = cOrd.LastLine + iNewRowsCount,
                                    .Position = curLastPosition + iNrRigheAValore,
                                    .SubId = cOrd.LastSubId + iNewRowsCount,
                                    .SaleOrdId = cOrd.SaleOrdId,
                                    .LineType = LineType.Servizio,
                                    .Item = cOrdRow.Item,
                                    .Description = If(String.IsNullOrWhiteSpace(cOrdRow.Description), periodoRif, cOrdRow.Description & " " & periodoRif),
                                    .UoM = cOrdRow.UoM,
                                    .PacksUoM = cOrdRow.UoM,
                                    .Qty = aDaRif.CanoniRipresi,
                                    .UnitValue = Math.Round(aDaRif.ValUnit.Value, decTax), ' Pesco il valore unitario dall'attività
                                    .NetPrice = Math.Round(aDaRif.ValUnit.Value, decTax),
                                    .TaxableAmount = Math.Round(aDaRif.CanoniRipresi * aDaRif.ValUnit.Value, decTax),
                                    .TaxCode = cOrdRow.CodIva,
                                    .TotalAmount = Math.Round((aDaRif.CanoniRipresi * aDaRif.ValUnit.Value) * ((100 + cOrdRow.PercIva) / 100), decTax),
                                    .ExpectedDeliveryDate = cOrdRow.DataPrevistaConsegna,
                                    .ConfirmedDeliveryDate = cOrdRow.DataConfermaConsegna,
                                    .AllNrCanoni = aDaRif.CanoniRipresi,
                                    .AllCanoniDataI = aDaRif.DataInizio.Value,
                                    .AllCanoniDataF = aDaRif.DataFine.Value,
                                    .Invoiced = "0",
                                    .Notes = Trim(Left(aDaRif.Nota.ToString, 32)),
                                    .Job = cOrd.Commessa,
                                    .CostCenter = cOrd.CdC,
                                    .ContractCode = cOrd.CIG,
                                    .ProjectCode = cOrd.CUP,
                                    .Offset = cOrdRow.Contropartita,
                                    .InternalOrdNo = cOrd.OrdNo,
                                    .Customer = cOrd.Cliente,
                                    .OrderDate = cOrd.OrdDate,
                                    .NoOfPacks = 0,
                                    .ProductionPlanLine = 0,
                                    .ExternalLineReference = 0,
                                    .InEi = 0,
                                    .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId
                                }
                                'Aggiungo la riga alla collection
                                efMaSaleOrdDetails.Add(rRif)
                                Debug.Print("### Riga da rifatt:(" & rRif.Position.ToString & ") " & aDaRif.Attivita)
                                debugging.AppendLine(" *Rifatt:" & rRif.Position.ToString & " " & aDaRif.Attivita)

                            Next
#End Region
#Region "Scrivo MaSaleOrdDetails"
                            If Not cOrdRow.CanoneFuoriRangeDate AndAlso cOrdRow.QtaCorrente > 0 Then
                                'Scrivo il corpo solo nel caso dei canoni ( in caso di rifatturazione potrei non averne)
                                iNewRowsCount += 1
                                iNrRigheAValore += 1
                                Dim r As New MaSaleOrdDetails With {
                                    .Line = cOrd.LastLine + iNewRowsCount,
                                    .Position = curLastPosition + iNrRigheAValore,
                                    .SubId = cOrd.LastSubId + iNewRowsCount,
                                    .SaleOrdId = cOrd.SaleOrdId,
                                    .LineType = LineType.Servizio,
                                    .Item = cOrdRow.Item
                                    }
                                Debug.Print("### R Ord:" & r.Position.ToString)
                                debugging.AppendLine(" *R:" & r.Position.ToString)
                                Dim periodoDataFine As String = cOrdRow.PeriodoDataFin.ToShortDateString
                                Dim periodo As String = "Periodo dal " & cOrdRow.PeriodoDataIn.ToShortDateString & " al " & periodoDataFine
                                If cOrdRow.IsUnaTantum Then
                                    r.Description = cOrdRow.Description
                                    'Segno come Fatturata
                                    c.Fatturato = "1"
                                ElseIf cOrdRow.IsContinuativo Then
                                    r.Description = cOrdRow.Description
                                Else
                                    r.Description = If(String.IsNullOrWhiteSpace(cOrdRow.Description), periodo, cOrdRow.Description & " " & periodo)
                                End If
                                r.UoM = cOrdRow.UoM
                                r.PacksUoM = cOrdRow.UoM
#Region "Blocco Quantità"
                                'TODO: controllare con qta riga per gestire Spese incasso con qta singola !
                                If cOrdRow.IsAConsumo Then
                                    If cOrdRow.QtaCorrente + cOrdRow.QtaFranchigia = cOrdRow.QtaOrdine Then
                                        c.Fatturato = "1"
                                        r.Qty = cOrdRow.QtaCorrente
                                    ElseIf cOrdRow.QtaCorrente + cOrdRow.QtaFranchigia > cOrdRow.QtaOrdine Then
                                        c.Fatturato = "1"
                                        r.Qty = cOrdRow.QtaOrdine - cOrdRow.QtaFranchigia
                                    Else
                                        r.Qty = cOrdRow.QtaCorrente
                                    End If
                                    cOrdRow.QtaFranchigia += r.Qty
                                    c.Franchigia = cOrdRow.QtaFranchigia
                                ElseIf cOrdRow.IsContinuativo Then
                                    r.Qty = cOrdRow.QtaOrdine
                                Else
                                    'Tutti gli altri casi
                                    r.Qty = cOrdRow.QtaCorrente
                                End If
                                cOrdRow.QtaCorrente = r.Qty
#End Region
                                r.UnitValue = Math.Round(cOrdRow.ValUnit, decTax)
                                r.NetPrice = Math.Round(cOrdRow.ValUnit, decTax)
                                r.TaxableAmount = Math.Round(cOrdRow.QtaCorrente * cOrdRow.ValUnit, decTax)
                                r.TaxCode = cOrdRow.CodIva
                                r.TotalAmount = Math.Round((cOrdRow.QtaCorrente * cOrdRow.ValUnit) * ((100 + cOrdRow.PercIva) / 100), decTax)
                                r.ExpectedDeliveryDate = cOrdRow.DataPrevistaConsegna
                                r.ConfirmedDeliveryDate = cOrdRow.DataConfermaConsegna
                                'TODO: chiedere se data fine competenza in caso di Scadenza fissa e' fine periodo o la data scadenza fissa
                                r.AllNrCanoni = cOrdRow.QtaCorrente 'cOrdRow.NrCanoni '-> visto che potrebbe variare uso cOrdRow.QtaCorrente
                                r.AllCanoniDataI = cOrdRow.PeriodoDataIn
                                r.AllCanoniDataF = cOrdRow.PeriodoDataFin
                                r.Invoiced = "0"
                                r.Notes = Trim(Left(c.Nota.ToString, 32))
                                r.Job = cOrd.Commessa
                                r.CostCenter = cOrd.CdC
                                r.ContractCode = cOrd.CIG
                                r.ProjectCode = cOrd.CUP
                                r.Offset = cOrdRow.Contropartita
                                r.InternalOrdNo = cOrd.OrdNo
                                r.Customer = cOrd.Cliente
                                r.OrderDate = cOrd.OrdDate
                                r.NoOfPacks = 0
                                r.ProductionPlanLine = 0
                                r.ExternalLineReference = 0
                                r.InEi = 0
                                r.Tbcreated = Now
                                r.Tbmodified = Now
                                r.TbcreatedId = sLoginId
                                r.TbmodifiedId = sLoginId

                                'Aggiungo la riga alla collection
                                efMaSaleOrdDetails.Add(r)
                            End If
#End Region
#Region "Righe ISTAT"
                            For Each aIst In attIstat
                                iNewRowsCount += 1
                                iNrRigheNota += 1
                                'bScrittoDescrizioni = True
                                Dim rd As New MaSaleOrdDetails With {
                                .Line = cOrd.LastLine + iNewRowsCount,
                                .Position = 0,
                                .SubId = cOrd.LastSubId + iNewRowsCount,
                                .SaleOrdId = cOrd.SaleOrdId,
                                .LineType = LineType.Nota,
                                .Description = aIst.TestoFattura,
                                .InEi = "1",
                                .ExpectedDeliveryDate = cOrdRow.DataPrevistaConsegna,
                                .ConfirmedDeliveryDate = cOrdRow.DataConfermaConsegna, ' sDataNulla
                                .InternalOrdNo = cOrd.OrdNo,
                                .Customer = cOrd.Cliente,
                                .OrderDate = cOrd.OrdDate,
                                .NoOfPacks = 0,
                                .ProductionPlanLine = 0,
                                .ExternalLineReference = 0,
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId,
                                .Item = String.Empty,
                                .UoM = String.Empty,
                                .Qty = 0,
                                .UnitValue = 0,
                                .TaxableAmount = 0,
                                .TotalAmount = 0,
                                .PacksUoM = String.Empty,
                                .TaxCode = String.Empty,
                                .Job = String.Empty,
                                .CostCenter = String.Empty,
                                .Offset = String.Empty,
                                .Notes = String.Empty,
                                .NetPrice = 0,
                                .ContractCode = String.Empty,
                                .ProjectCode = String.Empty,
                                .AllNrCanoni = 0,
                                .AllCanoniDataI = sDataNulla,
                                .AllCanoniDataF = sDataNulla,
                                .Invoiced = "0"
                            }
                                'Aggiungo la riga alla collection
                                efMaSaleOrdDetails.Add(rd)
                                'Aggiungo l'attività alla collection ( per aggionare il flag Fatturata)
                                efAllordCliAttivita.Add(aIst)

                                msgLog = "### Riga Istat:(" & rd.Position.ToString & ") " & aIst.Attivita
                                Debug.Print(msgLog)
                                debugging.AppendLine(" *I:" & rd.Position.ToString & " " & aIst.Attivita)

                            Next
#End Region
                        End If
#Region "Aggiorno date prossima Fatturazione"
                        If Not cOrdRow.CanoneFuoriRangeDate AndAlso (cOrdRow.IsOk OrElse cOrdRow.DaRifatturare OrElse cOrdRow.SospesoDaAttivita) AndAlso Not cOrdRow.PrecendementeCessato Then
                            If cOrdRow.DataProssimaFattura < dataFattA Then avvisi.AppendLine("Ordine " & cOrd.OrdNo & " Servizio " & cOrdRow.Item & " con data prossima fatturazione antecedente alla data di fine estrazione !")
                            c.DataProssimaFatt = cOrdRow.DataProssimaFattura
                            c.DataFineElaborazione = Now
                            c.Tbmodified = Now
                            c.TbmodifiedId = sLoginId
                            efAllordCliContratto.Add(c)
                            isUpdateRows = True
                        End If
#End Region

                    Next
                    'Se ho scritto qualche riga svuoto il flag Consegnato, Fatturato etc. della testa
                    'Aggiorno il contatore "Ordini Ok"
                    If isNewRows Then
                        o.Invoiced = "0"
                        o.Delivered = "0"
                        o.Picked = "0"
                        o.LastSubId = cOrd.LastSubId + iNewRowsCount
                        o.Tbmodified = Now
                        o.TbmodifiedId = sLoginId
                        efMaSaleOrd.Add(o)
                        totOrdiniConNuoveRighe += 1
                        msgLog = "Nuove righe n:" & iNrRigheNota.ToString & " S:" & iNrRigheAValore.ToString
                        Debug.Print(msgLog)
                        debugging.AppendLine(msgLog)
                    End If
                    If isUpdateRows Then totOrdiniConRigheAggiornate += 1
                    debugging.AppendLine()
                Next

#Region "Bulk Insert"
                msgLog = "Ordini con righe Contratto valide : " & totOrdiniConNuoveRighe.ToString
                My.Application.Log.DefaultFileLogWriter.WriteLine(msgLog)
                FLogin.lstStatoConnessione.Items.Add(msgLog)
                msgLog = "Ordini con righe Contratto con data prossima fatturazione da adeguare : " & totOrdiniConRigheAggiornate.ToString
                My.Application.Log.DefaultFileLogWriter.WriteLine(msgLog)
                FLogin.lstStatoConnessione.Items.Add(msgLog)

                If totOrdiniConNuoveRighe > 0 OrElse totOrdiniConRigheAggiornate > 0 Then
                    'Parametri
                    'https://github.com/borisdj/EFCore.BulkExtensions

                    Using bulkTrans = OrdContext.Database.BeginTransaction
                        Dim iStep As Integer
                        Try
                            OrdContext.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                            iStep += 1
                            EditTestoBarra("Salvataggio: Aggiornamento teste ordini")
                            If efMaSaleOrd.Any Then
                                Dim t = efMaSaleOrd.Count
                                Dim cfgOrd As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkUpdate(efMaSaleOrd, cfgOrd, Function(d) d)
                                Debug.Print("MaSaleOrd Ins:" & cfgOrd.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrd.StatsInfo.StatsNumberUpdated.ToString)
                                bulkMessage.AppendLine("MaSaleOrd Ins:" & cfgOrd.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrd.StatsInfo.StatsNumberUpdated.ToString)
                            End If
                            iStep += 1
                            EditTestoBarra("Salvataggio: Inserimento/Aggiornamento righe ordini")
                            If efMaSaleOrdDetails.Any Then
                                Dim t = efMaSaleOrdDetails.Count
                                Dim cfgOrdDet As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkInsertOrUpdate(efMaSaleOrdDetails, cfgOrdDet, Function(d) d)
                                Debug.Print("MaSaleOrdDetails Ins:" & cfgOrdDet.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdDet.StatsInfo.StatsNumberUpdated.ToString) '& " Canc:" & cfgOrdDet.StatsInfo.StatsNumberDeleted.ToString)
                                bulkMessage.AppendLine("MaSaleOrdDetails Ins:" & cfgOrdDet.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdDet.StatsInfo.StatsNumberUpdated.ToString) ' & " Canc:" & cfgOrdDet.StatsInfo.StatsNumberDeleted.ToString)
                            End If
                            iStep += 1
                            EditTestoBarra("Salvataggio: Inserimento/Aggiornamento totali ordini")
                            If efMaSaleOrdSummary.Any Then
                                Dim t = efMaSaleOrdSummary.Count
                                Dim cfgOrdTot As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkInsertOrUpdate(efMaSaleOrdSummary, cfgOrdTot, Function(d) d)
                                Debug.Print("MaSaleOrdSummary Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                                bulkMessage.AppendLine("MaSaleOrdSummary Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                            End If
                            iStep += 1
                            EditTestoBarra("Salvataggio: Inserimento/Aggiornamento dati accessori ordini")
                            If efAllordCliAcc.Any Then
                                Dim t = efAllordCliAcc.Count
                                Dim cfgOrdAcc As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkInsertOrUpdate(efAllordCliAcc, cfgOrdAcc, Function(d) d)
                                Debug.Print("ALLOrdCliAcc Ins:" & cfgOrdAcc.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAcc.StatsInfo.StatsNumberUpdated.ToString)
                                bulkMessage.AppendLine("ALLOrdCliAcc Ins:" & cfgOrdAcc.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAcc.StatsInfo.StatsNumberUpdated.ToString)
                            End If
                            iStep += 1
                            EditTestoBarra("Salvataggio: Aggiornamento righe attività ")
                            If efAllordCliAttivita.Any Then
                                Dim t = efAllordCliAttivita.Count
                                Dim cfgOrdAtt As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkUpdate(efAllordCliAttivita, cfgOrdAtt, Function(d) d)
                                Debug.Print("AllordCliAttivita Ins:" & cfgOrdAtt.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAtt.StatsInfo.StatsNumberUpdated.ToString)
                                bulkMessage.AppendLine("AllordCliAttivita Ins:" & cfgOrdAtt.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAtt.StatsInfo.StatsNumberUpdated.ToString)
                            End If
                            iStep += 1
                            EditTestoBarra("Salvataggio: Aggiornamento righe contratto ")
                            If efAllordCliContratto.Any Then
                                Dim t = efAllordCliContratto.Count
                                Dim cfgOrdCon As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkUpdate(efAllordCliContratto, cfgOrdCon, Function(d) d)
                                Debug.Print("AllordCliContratto Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                                bulkMessage.AppendLine("AllordCliContratto Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                            End If
                            iStep += 1
                            EditTestoBarra("Salvataggio: Aggiornamento righe distinta ")
                            If efAllordCliContrattoDistinta.Any Then
                                Dim t = efAllordCliContrattoDistinta.Count
                                Dim cfgOrdConDis As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkUpdate(efAllordCliContrattoDistinta, cfgOrdConDis, Function(d) d)
                                Debug.Print("AllordCliContrattoDistinta Ins:" & cfgOrdConDis.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDis.StatsInfo.StatsNumberUpdated.ToString)
                                bulkMessage.AppendLine("AllordCliContrattoDistinta Ins:" & cfgOrdConDis.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDis.StatsInfo.StatsNumberUpdated.ToString)
                            End If
                            iStep += 1
                            EditTestoBarra("Salvataggio: Aggiornamento righe Servizi Aggiuntivi ")
                            If efAllordCliContrattoDistintaServAgg.Any Then
                                Dim t = efAllordCliContrattoDistintaServAgg.Count
                                Dim cfgOrdConDisServAgg As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkUpdate(efAllordCliContrattoDistintaServAgg, cfgOrdConDisServAgg, Function(d) d)
                                Debug.Print("AllordCliContrattoDistintaServAgg Ins:" & cfgOrdConDisServAgg.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDisServAgg.StatsInfo.StatsNumberUpdated.ToString)
                                bulkMessage.AppendLine("AllordCliContrattoDistintaServAgg Ins:" & cfgOrdConDisServAgg.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDisServAgg.StatsInfo.StatsNumberUpdated.ToString)
                            End If

                            If someTrouble Then
                                bulkTrans.Rollback()
                                bulkMessage.AppendLine("[Salvataggio] Sono stati riscontrati degli errori. Eseguita rollback")
                            Else
                                bulkTrans.Commit()
                                FLogin.lstStatoConnessione.Items.Add(" --- Inserimento Dati ---")
                                msgLog = "Ordini Estratti : " & totOrdini.ToString & " ..con Righe: " & totOrdiniConNuoveRighe.ToString & " ..con Adeguamenti: " & totOrdiniConRigheAggiornate.ToString
                                Debug.Print(msgLog)
                                bulkMessage.AppendLine("[RIASSUNTO] " & msgLog)
                                FLogin.lstStatoConnessione.Items.Add(msgLog)
                            End If
                            OrdContext.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

                        Catch ex As Exception
                            someTrouble = True
                            Debug.Print(ex.Message)
                            FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori allo step " & iStep)
                            bulkMessage.AppendLine("[Salvataggio] - STEP: " & iStep & " - Sono stati riscontrati degli errori. (Vedere sezione Errori)")
                            errori.AppendLine("[Salvataggio] Messaggio:" & ex.Message)
                            errori.AppendLine("[Salvataggio] Stack:" & ex.StackTrace)

                            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                            mb.ShowDialog()
                        End Try
                    End Using
                End If
#End Region
            End If

        Catch ex As Exception
            Debug.Print(ex.Message)
            errori.AppendLine("[Procedura] Messaggio:" & ex.Message)
            errori.AppendLine("[Procedura] Stack:" & ex.StackTrace)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        OrdContext.Dispose()

        'Scrivo i LOG
        If bulkMessage.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Inserimento Dati ---" & Environment.NewLine & bulkMessage.ToString)
        If errori.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Errori ---" & Environment.NewLine & errori.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
        End If
        If avvisi.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Avvisi ---" & Environment.NewLine & avvisi.ToString)
            FLogin.lstStatoConnessione.Items.Add("Presenti avvisi : Controllare file di Log")
        End If
        If IsDebugging AndAlso debugging.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Debugging ---" & Environment.NewLine & debugging.ToString)

        Return Not someTrouble

    End Function

    ''' <summary>
    ''' Controllo Flusso Integra
    ''' </summary>
    ''' <returns></returns>
    Public Function ControllaFlussoIntegra() As Boolean
#Region "Variabili Selezione"
        'Variabili legate alla maschera di selezione 
        Dim nrMonth As Integer
        Dim dataFatt As Date
        Dim bSingolaFiliale As Boolean
        Dim filiale As String = String.Empty
        Dim fromLogDate As Date
        Dim toLogDate As Date
        Dim bAskFilter As Boolean

#Region "Regole di richiesta "
        'Lancio la form con le regole di richiesta
        Using ff = New FAskFiltriOrdiniConsuntivo
            Dim result As DialogResult = ff.ShowDialog
            If result = DialogResult.OK Then
                nrMonth = ff.CmbMonth.SelectedIndex + 1
                dataFatt = OnlyDate(ff.DtaFatt.Value) 'Data giorno di fatturazione
                bSingolaFiliale = ff.ChkFiliale.Checked
                filiale = ff.TxtOrdFiliale.Text
                fromLogDate = OnlyDate(ff.firstLogDate.Value)
                toLogDate = OnlyDate(ff.lastLogDate.Value)
                bAskFilter = ff.ChkNoFilter.Checked
                'My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & filtri.ToString)
            ElseIf result = DialogResult.Cancel Then
                Return False
                Exit Function
            End If
        End Using

#End Region
        Dim someTrouble As Boolean = False
        Dim errori As New StringBuilder()
        Dim errorList As New List(Of String)
        Dim errorCount As Integer
        Dim totInterventi As Integer
#End Region

        Try
#Region "Estrazioni dati con Query LINQ"
            'https://entityframework.net/why-first-query-slow
            'Tipizzare con (Of ) solo le Tabelle singole 1-1 che NON hanno 1-n / Collection
            Dim l = (From o In OrdContext.IntegraInterventi)
            If bAskFilter Then
                l = l.Where(Function(oDate) oDate.DataInsert.Value.Date >= fromLogDate And oDate.DataInsert.Value.Date <= toLogDate)
                If bSingolaFiliale Then l = l.Where(Function(oFiliale) oFiliale.Filiale.Equals(filiale))
            End If

            Dim d = (From o In OrdContext.AllordCliContrattoDistinta.Include(Function(sa) sa.AllordCliContrattoDistintaServAgg))

            Dim ttt = (From dis In OrdContext.AllordCliContrattoDistinta _
                    .Include(Function(sa) sa.AllordCliContrattoDistintaServAgg)
                       Join i In OrdContext.IntegraInterventi On dis.CodIntegra Equals i.Contratto
                       Select dis, i)

            Dim allttt = ttt.ToList
            Dim allServAgg = d.ToList
            Dim allInterventi = l.ToList
#End Region

            If allInterventi.Any Then
                totInterventi = allInterventi.Count
                Debug.Print("Interventi Estratti : " & totInterventi.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi Estratti : " & totInterventi.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi Estratti : " & totInterventi.ToString)
                EditTestoBarra("Interventi Estratti : " & totInterventi.ToString)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totInterventi
                FLogin.prgCopy.Step = 1

                'Ciclo su tutti gli Interventi
                For Each i In allInterventi
                    AvanzaBarra()
                    Debug.Print("Intervento: " & i.ID)

                    Dim check = d.Where(Function(x) x.CodIntegra.Equals(i.Contratto))
                    If Not check.Any Then
                        errorCount += 1
                        If Not errorList.Exists(Function(x) x.Equals(i.Contratto)) Then
                            errorList.Add(i.Contratto)
                        End If
                    End If
                Next

            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            errori.AppendLine("[Procedura] Messaggio:" & ex.Message)
            errori.AppendLine("[Procedura] Stack:" & ex.StackTrace)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        OrdContext.Dispose()

        'Scrivo i LOG
        If errorList.Count > 0 Then
            errorList.Sort()
            For Each e In errorList
                errori.AppendLine("Contratto assente: " & e)
            Next
            My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi con Errore : " & errorCount.ToString)
            FLogin.lstStatoConnessione.Items.Add("Interventi con Errore : " & errorCount.ToString)
            My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Errori ---" & Environment.NewLine & errori.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
            someTrouble = True
        End If

        Return Not someTrouble

    End Function

    Private Function TrascodificaServizioAggiuntivo(value As String) As String
        Dim ret As String = ""
        If value = "ISP" Then ret = ServiziAggiuntivi.Ispezioni  '"ISPEZIONI"
        If value = "" Then ret = ServiziAggiuntivi.Ispezioni_Descri  '"Ispezioni"
        If value = "INT" Then ret = ServiziAggiuntivi.Interventi  '"INTERVENTI"
        If value = "" Then ret = ServiziAggiuntivi.Interventi_Descri  '"Interventi"
        If value = "" Then ret = ServiziAggiuntivi.AperturaChiusura  '"APECHIU"
        If value = "" Then ret = ServiziAggiuntivi.AperturaChiusura_Descri  '"Apertura Chiusura"
        If value = "" Then ret = ServiziAggiuntivi.Assistenza  '"ASSISTENZA"
        If value = "" Then ret = ServiziAggiuntivi.Assistenza_Descri  '"Assistenza"
        If value = "" Then ret = ServiziAggiuntivi.Piantoni  '"PIANTONI"
        If value = "" Then ret = ServiziAggiuntivi.Piantoni_Descri  '"Piantoni"
        If value = "" Then ret = ServiziAggiuntivi.VideoIsp  '"VIDEOISPEZIONI"
        If value = "" Then ret = ServiziAggiuntivi.VideoIsp_Descri  '"Video Ispezioni"
        If value = "" Then ret = ServiziAggiuntivi.Frequenza  '"SUPPLEMENTAR"
        Return ret
    End Function
End Module

