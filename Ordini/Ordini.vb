Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
'TODO: valutare implementazioni Fattura elettronica ( da ordine non ho modo, serve elaborazione successiva)
'Todo: Dichiarazione intento lettera W ( magari impostare un campo in anagrafica cliente/ordine) e aggiungerlo agli step di pre-invio( tipo quello dei dati canoni ) ma ne verrano fuori altri

Module Ordini
    Friend Const decPerc As Integer = 2
    Friend Const decValUnit As Integer = 5
    Friend Const decTax As Integer = 2

    Friend Enum TipologiaServizio As Integer '19472
        Canone = 1276116992
        Consuntivo = 1276116993
        UnaTantum = 1276116994
        AConsumo = 1276116995
        Continuativo = 1276116996
    End Enum

    Friend Enum Cadenza As Integer '30661
        Anticipato = 2009399296
        Posticipato = 2009399297
    End Enum
    Friend Enum Periodo As Integer '16697
        Annuale = 1094254592
        Mensile = 1094254593
        Bimestrale = 1094254594
        Trimestrale = 1094254595
        Quadrimestrale = 1094254596
        Semestrale = 1094254598
        Variabile = 1094254692
    End Enum

    ReadOnly sLoginId As String = My.Settings.mLOGINID

    ''' <summary>
    ''' Genero righe su Ordine tramite LINQ e OrdContext
    ''' </summary>
    ''' <returns></returns>
    Public Function GeneraRigheOrdine() As Boolean
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
        Dim bPriorita As Boolean
        Dim priorita As String = String.Empty
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
                bPriorita = ff.ChkPriorita.Checked
                'Integer.TryParse(ff.TxtordPriorita.Text, priorita)
                priorita = ff.TxtordPriorita.Text
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
                filtri.AppendLine("Priorità : " & If(bSingolaFiliale, filiale, "TUTTI"))
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

#End Region

        Try
#Region "Estrazioni dati con Query LINQ"
            OrdContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(120))
            'https://entityframework.net/why-first-query-slow
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
                                        .ThenInclude(Of Allattivita)(Function(at) at.Allattivita) _
                            .Include(Function(att) att.AllordCliAttivita) _
                                .ThenInclude(Of Allattivita)(Function(at) at.Allattivita)) ' _
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
            If bPriorita Then q = q.Where(Function(oPriorita) oPriorita.Priority.ToString.Equals(priorita))

            Dim iAllOrders As IQueryable(Of MaSaleOrd) = q
            'ESEGUO LA QUERY (ALDO 30/06 ritorna 1 invece che 2)
            'Operazione molto lunga che non faccio in quanto non serve
            'Dim orderList = q.ToList

            'Creo le entities che usero' poi con BulkInsert
            Dim efMaSaleOrd As New List(Of MaSaleOrd)
            Dim efMaSaleOrdDetails As New List(Of MaSaleOrdDetails)
            Dim efMaSaleOrdSummary As New List(Of MaSaleOrdSummary)
            Dim efAllordCliAcc As New List(Of AllordCliAcc)
            Dim efAllordCliAttivita As New List(Of AllordCliAttivita)
            Dim efAllordCliContratto As New List(Of AllordCliContratto)
#End Region

            If iAllOrders.Any Then
                totOrdini = iAllOrders.Count
                bIsSomething = True
                Debug.Print("Ordini Estratti : " & totOrdini.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Ordini Estratti : " & totOrdini.ToString)
                FLogin.lstStatoConnessione.Items.Add("Ordini Estratti : " & totOrdini.ToString)
                EditTestoBarra("Ordini Estratti : " & totOrdini.ToString)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totOrdini
                FLogin.prgCopy.Step = 1
#Region "Variabili Default"
                debugging.AppendLine("Estrazione dati di default")
                Dim defVendite = (From dv In OrdContext.MaUserDefaultSales.ToList Select dv).FirstOrDefault
                debugging.AppendLine(" - Vendite")
                ' Dim defContabili = (From dc In OrdContext.MaAccountingDefaults.ToList Select dc).FirstOrDefault
                debugging.AppendLine(" - Contabili")
                Dim defIva = (From dc In OrdContext.MaTaxCodesDefaults.ToList Select dc).FirstOrDefault
                debugging.AppendLine(" - Iva")
                Dim codiciIva = (From c In OrdContext.MaTaxCodes.ToList Select c)
                debugging.AppendLine(" - Codici Iva")

                Dim sDefContropartita As String = defVendite.ServicesSalesAccount
                Dim sDefCodIva As String = defIva.TaxCode
                Dim dDefPercIva As Double = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = sDefCodIva).Perc.Value, decPerc)
#End Region
                'Ciclo su tutti gli ordini
                debugging.AppendLine("Inizio Ciclo Ordini")
                For Each o In iAllOrders
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
                    'Dim cOrd As CurOrd = Eval_CurrentOrder(o)
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
            End If
#End Region

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

    Private Function RigaDescrittiva(iNewRowsCount As Integer, cOrdRow As CurOrdRow, d As String) As MaSaleOrdDetails
        Dim rd As New MaSaleOrdDetails With {
                                                .Line = cOrdRow.Parent.LastLine + iNewRowsCount,
                                                .Position = 0,
                                                .SubId = cOrdRow.Parent.LastSubId + iNewRowsCount,
                                                .SaleOrdId = cOrdRow.Parent.SaleOrdId,
                                                .LineType = LineType.Nota,
                                                .Description = d,
                                                .InEi = "1",
                                                .ExpectedDeliveryDate = cOrdRow.DataPrevistaConsegna,
                                                .ConfirmedDeliveryDate = cOrdRow.DataConfermaConsegna, ' sDataNulla
                                                .InternalOrdNo = cOrdRow.Parent.OrdNo,
                                                .Customer = cOrdRow.Parent.Cliente,
                                                .OrderDate = cOrdRow.Parent.OrdDate,
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
        Return rd
    End Function

    Private Function CheckRigaBianca(d As MaSaleOrdDetails) As Boolean
        Dim result As Boolean
        'Controllo sull'inserimento automatico da Mago ( Articolo=vuoto + merce + line e pos = 1)
        If String.IsNullOrWhiteSpace(d.Item) AndAlso d.LineType = LineType.Merce AndAlso d.Line = 1 AndAlso d.Position = 1 Then
            result = True
        End If
        'Controllo sull'inserimento a Mano Valunit=0 + line e pos= 1
        If (d.LineType = LineType.Merce OrElse d.LineType = LineType.Servizio) AndAlso d.UnitValue = 0 AndAlso d.Line = 1 AndAlso d.Position = 1 Then
            result = True
        End If
        Return result
    End Function

    Public Function AdeguaIstatOrdine() As Boolean

#Region "Variabili Selezione"
        'Variabili legate alla maschera di selezione 
        Dim bFiltroDateOrdini As Boolean
        Dim fromOrdDate As Date
        Dim toOrdDate As Date
        Dim bSingoloOrdine As Boolean
        Dim nrOrd As String = String.Empty
        Dim bSingoloCliente As Boolean
        Dim cliente As String = String.Empty
        Dim bSingolaFiliale As Boolean
        Dim filiale As String = String.Empty
        Dim dataDecorrenza As Date
        Dim percIstat As Double = 0
        Dim cauAttivita As String = String.Empty
        Dim annoAdeguamento As Integer = 0
        Dim testoFattura As String = String.Empty

        Dim filtri As New StringBuilder()

#Region "Regole di richiesta "
        'Lancio la form con le regole di richiesta
        Using ff = New FAskFiltriOrdini
            ff.IsIstat = True
            Dim result As DialogResult = ff.ShowDialog
            If result = DialogResult.OK Then
                If Not Double.TryParse(ff.TxtPercIstat.Text, percIstat) Then
                    MessageBox.Show("Elaborazione Interrotta" & Environment.NewLine & "Percentuale Adeguamento ISTAT nulla.")
                    Return False
                    Exit Function
                End If
                If percIstat = 0 Then
                    MessageBox.Show("Elaborazione Interrotta" & Environment.NewLine & "Percentuale Adeguamento ISTAT pari a Zero.")
                    Return False
                    Exit Function
                End If
                bFiltroDateOrdini = ff.RadDalAl.Checked
                fromOrdDate = OnlyDate(ff.DtaOrdineDA.Value)
                toOrdDate = OnlyDate(ff.DtaOrdineA.Value)
                bSingoloOrdine = ff.ChkNrOrdine.Checked
                nrOrd = ff.TxtNrOrdine.Text '.PadLeft(6, "0")
                bSingoloCliente = ff.ChkCliente.Checked
                cliente = ff.TxtOrdCliente.Text
                bSingolaFiliale = ff.ChkFiliale.Checked
                filiale = ff.TxtOrdFiliale.Text
                dataDecorrenza = OnlyDate(ff.DtaDecorrenza.Value) 'Data giorno di fatturazione
                cauAttivita = ff.TxtIstatAttivita.Text
                annoAdeguamento = CInt(ff.TxtAnnoAdeguamento.Text)
                testoFattura = ff.TxtIstatTesto.Text
                filtri.AppendLine(" --- Filtri ---")
                filtri.AppendLine(If(bFiltroDateOrdini, "Dal: " & fromOrdDate.ToShortDateString & " al: " & toOrdDate.ToShortDateString, "Fino al: " & toOrdDate.ToShortDateString))
                filtri.AppendLine("Ordine: " & If(bSingoloOrdine, nrOrd, "TUTTI"))
                filtri.AppendLine("Cliente: " & If(bSingoloCliente, cliente, "TUTTI"))
                filtri.AppendLine("Filiale: " & If(bSingolaFiliale, filiale, "TUTTI"))
                filtri.AppendLine("Data Decorrenza: " & dataDecorrenza.ToShortDateString)
                filtri.AppendLine("Percentuale ISTAT: " & percIstat.ToString)
                filtri.AppendLine("Attività: " & cauAttivita)
                'filtri.AppendLine("Data rifatturazione : " & dataRifatturazione.ToShortDateString)
                filtri.AppendLine("Anno adeguamento: " & annoAdeguamento)
                filtri.AppendLine("Testo: " & testoFattura)
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & filtri.ToString)

            ElseIf result = DialogResult.Cancel Then
                Return False
                Exit Function
            End If
        End Using
#End Region

        Dim someTrouble As Boolean = False
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()
        Dim avvisi As New StringBuilder()
        Dim debugging As New StringBuilder()
        Dim msgLog As String

        Dim totOrdini As Integer
        Dim totOrdiniok As Integer
        Dim bIsSomething As Boolean
        Dim sLoginId As String = My.Settings.mLOGINID

#End Region

        Try
#Region "Estrazioni dati con Query LINQ"
            'https://entityframework.net/why-first-query-slow
            Dim q = (From o In OrdContext.MaSaleOrd _
                            .Include(Function(acc) acc.ALLOrdCliAcc) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Of MaItems)(Function(it) it.MaItems) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Of AlltipoRigaServizio)(Function(trs) trs.AlltipoRigaServizio) _
                            .Include(Function(con) con.ALLordCliContratto) _
                                 .ThenInclude(Function(att) att.AllordCliAttivita) _
                                        .ThenInclude(Of Allattivita)(Function(at) at.Allattivita) _
                            .Include(Function(att) att.AllordCliAttivita) _
                                .ThenInclude(Of Allattivita)(Function(at) at.Allattivita)) ' _
            'AGGIUNGO  FILTRI
            q = q.Where(Function(facc) CBool(facc.ALLOrdCliAcc.ApplicoIstat) AndAlso (facc.ALLOrdCliAcc.DataCessazione = sDataNulla OrElse facc.ALLOrdCliAcc.DataCessazione > dataDecorrenza))
            If bFiltroDateOrdini Then
                q = q.Where(Function(oDate) oDate.OrderDate >= fromOrdDate And oDate.OrderDate <= toOrdDate)
            Else
                q = q.Where(Function(oDate) oDate.OrderDate <= toOrdDate)
            End If
            If bSingoloCliente Then q = q.Where(Function(oCli) oCli.Customer.Equals(cliente))
            If bSingoloOrdine Then q = q.Where(Function(oNrOrd) oNrOrd.InternalOrdNo.Equals(nrOrd))
            If bSingolaFiliale Then q = q.Where(Function(oFiliale) oFiliale.CostCenter.Equals(filiale))

            Dim iAllOrders As IQueryable(Of MaSaleOrd) = q
            'ESEGUO LA QUERY
            'Dim orderList = q.ToList

            'Creo le entities che usero' poi con BulkInsert
            Dim efAllordCliAttivita As New List(Of AllordCliAttivita)
            Dim efAllordCliContratto As New List(Of AllordCliContratto)
#End Region

            If iAllOrders.Any Then
                totOrdini = iAllOrders.Count
                bIsSomething = True
                Debug.Print("Ordini Estratti : " & totOrdini.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Ordini Estratti : " & totOrdini.ToString)
                FLogin.lstStatoConnessione.Items.Add("Ordini Estratti : " & totOrdini.ToString)
                EditTestoBarra("Ordini Estratti : " & totOrdini.ToString)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totOrdini
                FLogin.prgCopy.Step = 1

                'Ciclo su tutti gli ordini
                For Each o In iAllOrders
                    AvanzaBarra()
                    Debug.Print("Ordine: " & o.InternalOrdNo)
                    debugging.AppendLine("Ordine: " & o.InternalOrdNo)
#Region "Inizializzazione"
                    'Resetto alcune cose 
                    Dim isNewRowsAtt As Boolean = False
                    Dim iNewRowsAttCount As Integer = 0
                    Dim curLastLineAtt As Integer = If(o.AllordCliAttivita.Any, o.AllordCliAttivita.Max(Function(m) m.Line), 0)
                    'Inizializzo alcuni valori
                    Dim cOrd As New CurOrd With {
                        .SaleOrdId = o.SaleOrdId,
                        .Cliente = o.Customer,
                        .OrdNo = o.InternalOrdNo,
                        .DataScadenzaFissa = o.ALLOrdCliAcc.DataScadenzaFissa
                        }
#End Region
                    'STEP 1 : Ciclo le righe contratto
                    For Each c In o.ALLordCliContratto
#Region "Esclusioni Righe Contratto"
                        Dim sEx As String = c.Line.ToString & ") " & c.TipoRigaServizio & " " & c.Servizio
                        'Controllo Esclusioni 
                        If c.AlltipoRigaServizio.TipologiaServizio = TipologiaServizio.Consuntivo Then
                            Debug.Print("# [ESCLUSA] (Consuntivo) R.:(" & sEx)
                            debugging.AppendLine("# [ESCLUSA] (Consuntivo) R.:(" & sEx)
                            Continue For
                        End If
                        If CBool(c.Fatturato) Then
                            Debug.Print("# [ESCLUSA] (Fatturata) R.:(" & sEx)
                            debugging.AppendLine("# [ESCLUSA] (Fatturata) R.:(" & sEx)
                            Continue For
                        End If
                        If c.DataDecorrenza = sDataNulla Then
                            Debug.Print("# [ESCLUSA] (Decorrenza non Impostata) R.:(" & sEx)
                            debugging.AppendLine("# [ESCLUSA] (Decorrenza non Impostata) R.:(" & sEx)
                            Continue For
                        End If
                        'Questo e' il principale motivo di esclusione legato alla data!
                        If c.DataDecorrenza > dataDecorrenza Then
                            Debug.Print("# [ESCLUSA] (Decorrenza non raggiunta) R.:(" & sEx)
                            debugging.AppendLine("# [ESCLUSA] (Decorrenza non raggiunta) R.:(" & sEx)
                            Continue For
                        End If
                        'If c.DataProssimaFatt > dataDecorrenza Then
                        'Debug.Print("# [ESCLUSA] (Prossima fattura non raggiunta) R.:(" & sEx)
                        'debugging.AppendLine("# [ESCLUSA] (Prossima fattura non raggiunta) R.:(" & sEx)
                        'Continue For
                        'End If
                        Debug.Print("# R. :(" & sEx)
                        debugging.AppendLine("# R. :(" & sEx)
#End Region
#Region "Variabili Correnti"
                        Dim cOrdRow As New CurOrdRow(c)

                        'STEP 2: Determino date ( Consegna, nr canoni etc.)
                        cOrdRow.ValUnit = Math.Round(c.ValUnitIstat.Value, decTax)
                        If cOrdRow.ValUnit <= 0 Then errori.AppendLine("Ordine: " & cOrd.OrdNo & " Valore Unitario Att <= 0 // Riga: (" & sEx)
                        Dim isDaRifatturare As Boolean = False
                        Dim attDaAdeguare As New List(Of AllordCliAttivita)
                        Dim isIstat As Boolean = False
#End Region
                        For Each att In c.AllordCliAttivita
                            Debug.Print("## Attività:(" & att.Line.ToString & ") " & att.Attivita & " " & att.DataInizio.Value.ToShortDateString & " " & att.RifServizio & " " & att.RifLinea & " " & att.Nota)
                            debugging.AppendLine("## Attività:(" & att.Line.ToString & ") " & att.Attivita & " " & att.DataInizio.Value.ToShortDateString & " " & att.RifServizio & " " & att.RifLinea & " " & att.Nota)
                            'STEP 3a: Ciclo sulle Attività per Sospensione 
                            If CBool(att.Allattivita.Sospensione) Then
                                '--- Controllo Esclusioni di Sospensione---

                                'Fatturata
                                If CBool(att.Fatturata) Then
                                    Debug.Print("## [Fatturata] ##")
                                    debugging.AppendLine("## [Fatturata] ##")
                                    Continue For
                                End If
                                'Mesi sospesi
                                If att.DataInizio.Value.Year = annoAdeguamento OrElse att.DataFine.Value.Year = annoAdeguamento Then
                                    cOrdRow.SospesoDaAttivita = True
                                    msgLog = "## [Sospensione] ## : dal " & att.DataInizio.Value.ToShortDateString & " al " & att.DataFine.Value.ToShortDateString
                                    Debug.Print(msgLog)
                                    debugging.AppendLine(msgLog)
                                    attDaAdeguare.Add(att)
                                    cOrdRow.IsOk = True
                                End If

                            End If

                            'STEP 3b: Ciclo sulle Attività per Annullamento 
                            If CBool(att.Allattivita.Annullamento) Then
                                '--- Controllo Esclusioni di Annullamento---

                                cOrdRow.HaAnnullatoDaAttivita = True
                                'Controllo la data di Inizio
                                Dim dCanoniResidui As Double
                                If IsBetweenAnnullamento(att.DataInizio, cOrdRow, dCanoniResidui) Then
                                    'In dCanoniresidui ho il delta dei mesi
                                    If dCanoniResidui > 0 Then
                                        debugging.AppendLine("## Annullamento Parziale ##")
                                    Else
                                        cOrdRow.IsOk = False
                                        debugging.AppendLine("## Annullamento Parziale -> Totale ##")
                                    End If
                                ElseIf att.DataInizio <> sDataNulla AndAlso att.DataInizio < cOrdRow.CanoniDataIn Then
                                    'Completamente annullata
                                    cOrdRow.IsOk = False
                                    Debug.Print("## Annullamento Totale ##")
                                    debugging.AppendLine("## Annullamento Totale ##")
                                    Exit For
                                End If
                            End If

                            'STEP 3c: Ciclo sulle Attività per Istat 
                            'Devo assicurarmi di non adeguare nuovamente all'istat quelli antecenti a xxxx
                            If CBool(att.Allattivita.Istat) Then
                                '--- Controllo Esclusioni di ISTAT---

                                'E' nel range
                                If CBool(att.DaFatturare) AndAlso att.DataRifatturazione.Value.Year = annoAdeguamento Then
                                    isIstat = True
                                    'TODO: Valutare se usare avvisi o debugging
                                    avvisi.AppendLine("Ordine: " & cOrd.OrdNo & " con riga di adeguamento Istat già presente per l'anno: " & annoAdeguamento.ToString)
                                    cOrdRow.IsOk = False
                                End If
                            End If
                        Next
                        'STEP 4 : Controllo Scadenza Fissa
                        If cOrd.DataScadenzaFissa <> sDataNulla AndAlso cOrdRow.CanoniDataFin > cOrd.DataScadenzaFissa Then
                            avvisi.AppendLine("Ordine: " & cOrd.OrdNo & " Cliente: " & cOrd.Cliente & " con scadenza fissa. Controllare canoni!")
                            debugging.AppendLine("Ordine: " & cOrd.OrdNo & " Cliente: " & cOrd.Cliente & " con scadenza fissa. Controllare canoni!")
                            'Simile a Mesi annullati
                            Dim dCanoniFinoA As Double
                            If IsBetweenAnnullamento(cOrd.DataScadenzaFissa, cOrdRow, dCanoniFinoA) Then
                                'In dcanoniFinoA ho i mesi da fatturare
                                If dCanoniFinoA > 0 Then
                                    debugging.AppendLine("## Scadenza Fissa ##")
                                Else
                                    cOrdRow.IsOk = False
                                    debugging.AppendLine("## Scadenza Fissa -> Totale ##")
                                End If
                            End If
                        End If
                        'Se ok allora 
                        If cOrdRow.IsOk AndAlso Not isIstat Then
#Region "Adeguo AllordCliContratto"
                            'Adeguo riga di Canone
                            isNewRowsAtt = True
                            Debug.Print("### Riga contratto:(" & c.Line.ToString & ") " & c.Servizio)
                            debugging.AppendLine("### Riga contratto:(" & c.Line.ToString & ") " & c.Servizio)
                            Dim newValUnit As Double = Math.Round(cOrdRow.ValUnit * (1 + (percIstat / 100)), decTax)
                            c.ValUnitIstat = newValUnit
                            c.DataUltRivIstat = Now
                            c.DataFineElaborazione = Now
                            efAllordCliContratto.Add(c)
#End Region
                            'Creo la riga di Attività
                            '27/12/2021: Aggiunta possibilità di rifatturazione per creare riga di nota con scritta
                            iNewRowsAttCount += 1
                            Dim rAtt As New AllordCliAttivita With {
                                .IdOrdCli = cOrd.SaleOrdId,
                                .Line = curLastLineAtt + iNewRowsAttCount,
                                .Attivita = "ISTAT",
                                .DataInizio = dataDecorrenza,
                                .DataFine = sDataNulla,
                                .DaFatturare = "1",
                                .DataRifatturazione = cOrdRow.DataPrevistaConsegna,
                                .Fatturata = "0",
                                .Nota = "Adeguamento ISTAT (" & percIstat.ToString & "%). Precedente: " & cOrdRow.ValUnit.ToString,
                                .TestoFattura = testoFattura,
                                .RifServizio = cOrdRow.Item,
                                .RifLinea = cOrdRow.Line,
                                .ValUnit = newValUnit,
                                .Tbcreated = DateAndTime.Now,
                                .Tbmodified = DateAndTime.Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId
                                }
                            efAllordCliAttivita.Add(rAtt)
                            'Adeguo le righe di attività sospese
                            For Each adeg In attDaAdeguare
                                adeg.ValUnit = newValUnit
                                adeg.TestoFattura = "Adeguato a ISTAT"
                                adeg.Tbmodified = DateAndTime.Now
                                adeg.TbmodifiedId = sLoginId
                                efAllordCliAttivita.Add(adeg)
                            Next

                        End If
                    Next
                    If isNewRowsAtt Then
                        totOrdiniok += 1
                        Debug.Print("#### Ordine: " & o.InternalOrdNo & " Nuove righe Attività:" & iNewRowsAttCount.ToString)
                        debugging.Append("#### Ordine: " & o.InternalOrdNo & " Nuove righe Attività" & iNewRowsAttCount.ToString)
                    End If

                Next

#Region "Bulk Insert"
                My.Application.Log.DefaultFileLogWriter.WriteLine("Ordini con righe Contratto valide : " & totOrdiniok.ToString)
                FLogin.lstStatoConnessione.Items.Add("Ordini con righe Contratto valide : " & totOrdiniok.ToString)

                If totOrdiniok > 0 Then
                    'Parametri
                    'https://github.com/borisdj/EFCore.BulkExtensions
                    Debug.Print("[RIASSUNTO] Ordini Estratti : " & totOrdini.ToString & " Ordini con Righe: " & totOrdiniok.ToString)

                    Using bulkTrans = OrdContext.Database.BeginTransaction
                        Dim iStep As Integer
                        Try
                            OrdContext.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                            iStep += 1
                            EditTestoBarra("Salvataggio: Inserimento righe attività ")
                            If efAllordCliAttivita.Any Then
                                Dim t = efAllordCliAttivita.Count
                                Dim cfgOrdAtt As New BulkConfig With {
                                        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                        .BulkCopyTimeout = 0,
                                        .CalculateStats = True,
                                        .BatchSize = If(t < 5000, 0, t / 10),
                                        .NotifyAfter = t / 10
                                        }
                                OrdContext.BulkInsertOrUpdate(efAllordCliAttivita, cfgOrdAtt, Function(d) d)
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

                            If someTrouble Then
                                bulkTrans.Rollback()
                                bulkMessage.AppendLine("[Salvataggio] Sono stati riscontrati degli errori. Eseguita rollback")
                            Else
                                bulkTrans.Commit()
                                bulkMessage.AppendLine("Processati: " & totOrdiniok.ToString & " ordini")
                                FLogin.lstStatoConnessione.Items.Add("Processati: " & totOrdiniok.ToString & " ordini")
                                'Adeguo Query di aggiornamento Subid su tabella Ma_Saleord
                                'todo: sarà da adeguare alla nuova tabella
                                Dim sb As StringBuilder
                                sb.AppendLine("WITH MaxLine AS (SELECT IdOrdCli, MAX(line) AS MaxLine FROM ALLOrdCliAttivita GROUP BY IdOrdCli) ")
                                sb.AppendLine("UPDATE MA_SaleOrd SET SubIdAttivita = MaxLine.MaxLine FROM MaxLine WHERE MA_SaleOrd.SaleOrdid = MaxLine.IdOrdCli;")
                                OrdContext.Database.ExecuteSqlRaw(sb.ToString)
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
            End If
#End Region

        Catch ex As Exception
            Debug.Print(ex.Message)
            errori.AppendLine("[Procedura] Messaggio:" & ex.Message)
            errori.AppendLine("[Procedura] Stack:" & ex.StackTrace)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
            someTrouble = True
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

    Private Function IsBewteenPeriodo(ByVal c As AllordCliContratto, periodi() As Boolean) As Boolean
        Dim result As Boolean = False
        If c.AlltipoRigaServizio.TipologiaServizio = TipologiaServizio.Canone Then
            Select Case c.AlltipoRigaServizio.Periodicita
                Case Periodo.Annuale
                    If periodi(6) Then result = True
                Case Periodo.Semestrale
                    If periodi(5) Then result = True
                Case Periodo.Quadrimestrale
                    If periodi(4) Then result = True
                Case Periodo.Trimestrale
                    If periodi(3) Then result = True
                Case Periodo.Bimestrale
                    If periodi(2) Then result = True
                Case Periodo.Mensile
                    If periodi(1) Then result = True
            End Select
        End If
        Return result
    End Function
    Private Function IsBetweenAnnullamento(ByVal data As Date, ByVal range As CurOrdRow, ByRef canoniResidui As Double) As Boolean
        Dim result As Boolean = False
        canoniResidui = 0
        If data >= range.CanoniDataIn AndAlso data <= range.CanoniDataFin Then
            result = True
            canoniResidui = CalcolaMesi(range.CanoniDataIn, data, False)
        End If
        Return result
    End Function
    Private Function IsBetweenAnnullamento_Attivita(ByVal range As CurOrdRow, ByRef message As String) As Boolean
        Dim result As Boolean = False
        Dim canoniResidui As Double
        If range.DataCessazioneDaAttivita >= range.CanoniDataIn AndAlso range.DataCessazioneDaAttivita <= range.CanoniDataFin Then
            result = True
            canoniResidui = CalcolaMesi(range.CanoniDataIn, range.DataCessazioneDaAttivita, False)

            If canoniResidui > 0 Then
                range.QtaCorrente = (canoniResidui - range.QtaOrdine + range.QtaCorrente)
                range.QtaAnnullata = range.QtaOrdine - canoniResidui
                message = "  - Annullamento Parziale"
            Else
                range.QtaCorrente = 0
                range.QtaAnnullata = range.QtaOrdine
                range.IsOk = False
                message = "  - Annullamento Parziale -> Totale"
            End If
        ElseIf range.DataCessazioneDaAttivita <> sDataNulla AndAlso range.DataCessazioneDaAttivita < range.CanoniDataIn Then
            'Completamente annullata
            result = True
            range.PrecendementeCessato = True
            range.QtaAnnullata = range.QtaOrdine
            range.IsOk = False
            message = " - [ESCLUSA] Precentemente Cessato"
        End If
        Return result
    End Function
    Private Function IsBetweenAnnullamento_Cessazione(ByVal range As CurOrdRow, ByRef message As String) As Boolean
        Dim result As Boolean = False
        Dim canoniResidui As Double = 0
        If range.DataCessazione >= range.CanoniDataIn AndAlso range.DataCessazione <= range.CanoniDataFin Then
            result = True
            canoniResidui = CalcolaMesi(range.CanoniDataIn, range.DataCessazione, False)
        End If
        If canoniResidui > 0 Then
            range.QtaCorrente = (canoniResidui - range.QtaOrdine + range.QtaCorrente)
            message = "  - Cessato"
        Else
            range.QtaCorrente = 0
            range.IsOk = False
            message = "  - Cessato -> Totale"
        End If

        Return result
    End Function
    Private Function IsBetweenAnnullamento_ScadenzaFissa(ByVal range As CurOrdRow, ByRef message As String) As Boolean
        Dim result As Boolean = False
        Dim canoniResidui As Double = 0
        If range.DataScadenzaFissa >= range.CanoniDataIn AndAlso range.DataScadenzaFissa <= range.CanoniDataFin Then
            result = True
            canoniResidui = CalcolaMesi(range.CanoniDataIn, range.DataScadenzaFissa, False)
        End If
        If canoniResidui > 0 Then
            range.QtaCorrente = (canoniResidui - range.QtaOrdine + range.QtaCorrente)
            message = "  - Scadenza Fissa"
        Else
            range.QtaCorrente = 0
            range.IsOk = False
            message = "  - Scadenza Fissa -> Totale"
        End If
        Return result
    End Function
    Private Function IsBetweenSospensione(ByVal dataInizioSosp As Date, ByVal dataFineSosp As Date, ByVal range As CurOrdRow, ByRef canoniSospesi As Double) As Boolean
        Dim result As Boolean = False
        If dataInizioSosp >= range.CanoniDataFin Then Return False
        If dataFineSosp <= range.CanoniDataIn Then Return False

        canoniSospesi = 0
        If (dataInizioSosp >= range.CanoniDataIn AndAlso dataInizioSosp <= range.CanoniDataFin) AndAlso (dataFineSosp >= range.CanoniDataIn AndAlso dataFineSosp <= range.CanoniDataFin) Then
            'Caso di sospensione infraperiodo ( es: 1 mese sui trimestrali)
            result = True
            canoniSospesi = CalcolaMesi(dataInizioSosp, dataFineSosp, False)

        Else
            'Spesso invece vengono indicata date a cavallo del periodo di fatturazione
            '( esempio sospeso a tempo indeterminato 31/12/xxxx)

            'Data Inizio antecedente al periodo con ( Data Fine compresa)
            If dataInizioSosp < range.CanoniDataIn AndAlso (dataFineSosp >= range.CanoniDataIn AndAlso dataFineSosp <= range.CanoniDataFin) Then
                result = True
                canoniSospesi = CalcolaMesi(range.CanoniDataIn, dataFineSosp, False)
            End If

            '(Data Inizio compresa) con Data Fine Successiva al periodo [Sospensione Indeterminata] 
            If (dataInizioSosp >= range.CanoniDataIn AndAlso dataInizioSosp <= range.CanoniDataFin) AndAlso dataFineSosp > range.CanoniDataFin Then
                result = True
                canoniSospesi = CalcolaMesi(dataInizioSosp, range.CanoniDataFin, True)
            End If

            'Entrambe le date oltre le date periodo 
            If (dataInizioSosp < range.CanoniDataIn) AndAlso (dataFineSosp > range.CanoniDataFin) Then
                result = True
                canoniSospesi = range.NrCanoniIniziale
            End If
        End If
        range.QtaSospesa = canoniSospesi

        If result Then
            range.SospesoDaAttivita = True
            If canoniSospesi = range.QtaOrdine Then range.IsOk = False
            If canoniSospesi > 0 Then range.QtaCorrente -= canoniSospesi
        End If

        Return result
    End Function
    Private Function IsBetweenIstat_Canoni(ByVal a As AllordCliAttivita, ByVal range As CurOrdRow) As Boolean
        Dim result As Boolean = False
        If a.DataRifatturazione >= range.CanoniDataIn AndAlso a.DataRifatturazione <= range.CanoniDataFin Then
            result = True
        End If
        Return result
    End Function
    Private Function IsBetweenIstat(ByVal a As AllordCliAttivita, ByVal da As Date, ByVal al As Date) As Boolean
        Dim result As Boolean = False
        If a.DataRifatturazione >= da AndAlso a.DataRifatturazione <= al Then
            result = True
        End If
        Return result
    End Function
    Private Function IsBetweenRipresi_Canoni(ByVal a As AllordCliAttivita, ByVal range As CurOrdRow, ByRef canoniRipresi As Double) As Boolean
        'DPRECATO 26/01/2022 : Cambiato comportamento, cerco sempre se ci sono canoni da rifatturare a non solo all'avverarsi della condizione di fatturazione canone
        'Veniva passato cOrdRow
        Dim result As Boolean = False
        canoniRipresi = 0
        If a.DataRifatturazione >= range.CanoniDataIn AndAlso a.DataRifatturazione <= range.CanoniDataFin Then
            result = True
            canoniRipresi = CalcolaMesi(a.DataInizio, a.DataFine, False)
        End If
        Return result
    End Function
    Private Function IsBetweenRipresi(ByVal a As AllordCliAttivita, ByVal da As Date, ByVal al As Date, ByRef canoniRipresi As Double) As Boolean
        Dim result As Boolean = False
        canoniRipresi = 0
        If a.DataRifatturazione >= da AndAlso a.DataRifatturazione <= al Then
            result = True
            canoniRipresi = CalcolaMesi(a.DataInizio, a.DataFine, False)
        End If

        Return result
    End Function

    Private Function CalcolaMesi(ByVal d1 As Date, ByVal d2 As Date, ByVal checkGiorniSuPrimadata As Boolean) As Double
        'Logica con date 1-8=0 // 9-23= 0,5 // 23-28(31) =1
        Dim monthNr As Double
        'Determino il fine mese del primo valore
        Dim firstEndDate As Date = New DateTime(d1.Year, d1.Month, 1).AddMonths(1).AddDays(-1)
        Dim secondEndDate As Date = New DateTime(d2.Year, d2.Month, 1).AddMonths(1).AddDays(-1)
        If firstEndDate.Equals(d1) Then
            Dim d1Actual As Date = firstEndDate.AddDays(1)
            monthNr = DateAndTime.DateDiff(DateInterval.Month, d1Actual, d2)
        Else
            monthNr = DateAndTime.DateDiff(DateInterval.Month, d1, d2)
        End If
        'Dim d As Double = (d2 - d1).TotalDays
        'Dim monthCalcNr As Double = Math.Round(DateAndTime.DateDiff(DateInterval.Day, d1, d2) / (365.2425 / 12), 0)

        'Controllo su giorno come da specifiche
        If checkGiorniSuPrimadata Then
            'Se considero la prima data il valore e' invertito
            Select Case d1.Day
                Case 1 To 8
                    monthNr += 1
                Case 9 To 23
                    monthNr += 0.5
                Case 24 To 31
                    monthNr += 0
            End Select
        Else
            Select Case d2.Day
                Case 1 To 8
                    monthNr += 0
                Case 9 To 23
                    monthNr += 0.5
                Case 24 To 31
                    monthNr += 1
            End Select
        End If

        Return monthNr
    End Function

End Module

