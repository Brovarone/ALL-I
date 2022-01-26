Imports System
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Reflection.MethodBase
Imports System.Collections.Generic

Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
'todo: aggiornamento righe fatture con dati All canoni etc. ( vedere se fare da mago o da programma)
'TODO: valutare implementazioni Fattura elettronica 
'Todo: Dichiarazione intento lettera W ( magari impostare un campo in anagrafica cliente/ordine) e aggiungerlo agli step di pre-invio( tipo quello dei dati canoni ) ma ne verrano fuori altri

Module Ordini
    Const decPerc As Integer = 2
    Const decValUnit As Integer = 5
    Const decTax As Integer = 2

    Public Function GeneraRigheOrdine() As Boolean

#Region "Variabili Selezione"
        'Variabili legate alla maschera di selezione 
        Dim bFiltroDateOrdini As Boolean
        Dim fromOrdDate As Date
        Dim toOrdDate As Date
        Dim bSingoloOrdine As Boolean
        Dim nrOrd As String = ""
        Dim bSingoloCliente As Boolean
        Dim cliente As String = ""
        Dim bSingolaFiliale As Boolean
        Dim filiale As String = ""
        Dim dataFattDa As Date
        Dim dataFattA As Date
        Dim p_Tutti As Boolean
        Dim p_Annuali As Boolean
        Dim p_Semestrali As Boolean
        Dim p_Quadrimestrali As Boolean
        Dim p_Trimestrali As Boolean
        Dim p_Bimestrali As Boolean
        Dim p_Mensili As Boolean

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
                filtri.AppendLine(" --- Filtri ---")
                filtri.AppendLine(If(bFiltroDateOrdini, "Dal " & fromOrdDate.ToShortDateString & " al " & toOrdDate.ToShortDateString, "Fino al " & toOrdDate.ToShortDateString))
                filtri.AppendLine("Ordine : " & If(bSingoloOrdine, nrOrd, "TUTTI"))
                filtri.AppendLine("Cliente : " & If(bSingoloCliente, cliente, "TUTTI"))
                filtri.AppendLine("Filiale : " & If(bSingolaFiliale, filiale, "TUTTI"))
                filtri.AppendLine("Dalla data Fatt. :" & dataFattDa.ToShortDateString)
                filtri.AppendLine("Alla data Fatt. :" & dataFattA.ToShortDateString)
                filtri.AppendLine("Periodo (Tutti) : " & p_Tutti.ToString)
                filtri.AppendLine("Periodo (Annuali) : " & p_Annuali.ToString)
                filtri.AppendLine("Periodo (Sem.) : " & p_Semestrali.ToString)
                filtri.AppendLine("Periodo (Quadr.) : " & p_Quadrimestrali.ToString)
                filtri.AppendLine("Periodo (Trim.) : " & p_Trimestrali.ToString)
                filtri.AppendLine("Periodo (Bim.) : " & p_Bimestrali.ToString)
                filtri.AppendLine("Periodo (Mensi) : " & p_Mensili.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & filtri.ToString)

            ElseIf result = DialogResult.Cancel Then
                Return False
                Exit Function
            End If
        End Using
#End Region
        'TODO: ordine tabella totali = Summary ??
        'TODO: forse fatto !! gestire rifatturazione non a periodo ma infraperiodo ( Controllare su righe chiuse o cose cosi')
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
        Dim sLoginId As String = My.Settings.mLOGINID

#End Region

        Try
#Region "Estrazioni dati con Query LINQ"
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
            'AGGIUNGO  FILTRI
            'Vengono esclusi a priori gli ordini con data cessazione > di Data Competenza
            q = q.Where(Function(facc) facc.ALLOrdCliAcc.DataCessazione = sDataNulla OrElse facc.ALLOrdCliAcc.DataCessazione > dataFattA)
            If bFiltroDateOrdini Then
                q = q.Where(Function(oDate) oDate.OrderDate >= fromOrdDate And oDate.OrderDate <= toOrdDate)
            Else
                q = q.Where(Function(oDate) oDate.OrderDate <= toOrdDate)
            End If
            If bSingoloCliente Then q = q.Where(Function(oCli) oCli.Customer.Equals(cliente))
            If bSingoloOrdine Then q = q.Where(Function(oNrOrd) oNrOrd.InternalOrdNo.Equals(nrOrd))
            If bSingolaFiliale Then q = q.Where(Function(oFiliale) oFiliale.CostCenter.Equals(filiale))

            'ESEGUO LA QUERY
            Dim allOrders = q.ToList

            'Creo le entities che usero' poi con BulkInsert
            Dim efMaSaleOrd As New List(Of MaSaleOrd)
            Dim efMaSaleOrdDetails As New List(Of MaSaleOrdDetails)
            Dim efMaSaleOrdSummary As New List(Of MaSaleOrdSummary)
            Dim efAllordCliAcc As New List(Of AllordCliAcc)
            Dim efAllordCliAttivita As New List(Of AllordCliAttivita)
            Dim efAllordCliContratto As New List(Of AllordCliContratto)
#End Region

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
                    FLogin.prgCopy.PerformStep()
                    FLogin.prgCopy.Update()
                    Application.DoEvents()
                    Debug.Print("Ordine: " & o.InternalOrdNo)
                    debugging.AppendLine("Ordine: " & o.InternalOrdNo)
#Region "Inizializzazione"
                    'Resetto alcune cose 
                    Dim iNewRowsCount As Integer = 0
                    Dim isNewRows As Boolean = False    ' Indica se ci sono righe contratto che vengono fatturate e quindi inserite nelle righe
                    Dim isUpdateRows As Boolean = False ' Indica se ci sono righe contratto che vengono aggiorate
                    'Inizializzo alcuni valori
                    Dim curSaleOrdId As Integer = o.SaleOrdId
                    Dim curLastLine As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Line), 0)
                    Dim curLastPosition As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Position), 0)
                    Dim curCliente As String = o.Customer
                    Dim curOrdDate As Date = o.OrderDate
                    Dim curOrdNo As String = o.InternalOrdNo
                    Dim curScadenzaFissa As Date = o.ALLOrdCliAcc.DataScadenzaFissa
                    Dim curDataCessazione As Date = o.ALLOrdCliAcc.DataCessazione
                    Dim curCommessa As String = o.Job
                    Dim curCdC As String = o.CostCenter
                    Dim curCIG As String = o.ContractCode
                    Dim curCUP As String = o.ProjectCode
                    Dim bScrittoDescrizioni As Boolean = False
                    Dim iNrRigheNota As Integer = 0
                    Dim iNrRigheAValore As Integer = 0
                    Dim isScadenzaFissa As Boolean = False
                    Dim isCessazione As Boolean = False
                    Dim isDaEscludere As Boolean = False
#End Region
                    'STEP 1 : Ciclo le righe contratto
                    For Each c In o.ALLordCliContratto
#Region "Controllo Esclusioni righe Contratto"
                        Dim sEx As String = c.Line & ") " & c.TipoRigaServizio & " " & c.Servizio
                        If c.AlltipoRigaServizio.Consuntivo Then
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
                        If c.DataDecorrenza > dataFattA Then
                            Debug.Print("# [ESCLUSA] (Decorrenza non raggiunta) R.:(" & sEx)
                            debugging.AppendLine("# [ESCLUSA] (Decorrenza non raggiunta) R.:(" & sEx)
                            Continue For
                        End If
                        If c.DataProssimaFatt > dataFattA Then
                            Debug.Print("# [ESCLUSA] (Prossima fattura non raggiunta) R.:(" & sEx)
                            debugging.AppendLine("# [ESCLUSA] (Prossima fattura non raggiunta) R.:(" & sEx)
                            '26/01/2022 Vanno comunque esaminate per cercare eventuali righe sospsese da rifatturare
                            'Continue For
                            isDaEscludere = True
                        End If
                        Debug.Print("# R. :(" & sEx)
                        debugging.AppendLine("# R. :(" & sEx)
#End Region
#Region "Variabili Correnti"
                        Dim isOk As Boolean = True ' Usata anche per aggiornare data prossima fatturazione
                        Dim curItem As String = c.Servizio
                        Dim curOffset As String = If(String.IsNullOrWhiteSpace(c.MaItems.SaleOffset), sDefContropartita, c.MaItems.SaleOffset)
                        Dim curCodIva As String = If(String.IsNullOrWhiteSpace(c.CodiceIva), sDefCodIva, c.CodiceIva)
                        Dim curPercIva As Double = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = curCodIva).Perc.Value, decPerc)
                        Dim curDescri As String = c.Descrizione
                        Dim curUom As String = c.Um
                        Dim curValUnit As Double = Math.Round(c.ValUnitIstat.Value, decValUnit)
                        Dim curQta As Double = Math.Round(c.Qta.Value, decPerc)
                        'STEP 2: Determino date ( Consegna, nr canoni etc.)
                        Dim cOrdRow As CurOrdRow = EvalCurOrdRow(c.DataProssimaFatt, c.AlltipoRigaServizio)
                        'TODO IMPORTANTE ( CREARE CLASSE AD HOC PER CurOrdine , con TUTTO quello che serve le date, le qta iniziali, correnti, sospese, annullate etc, i flag sospeso annullato etc,
                        'TODO Aggiugere curitem , offset iva etc pulendo un po
                        Dim curDate As MyBloccoDate = ValorizzaDate(c.DataProssimaFatt, c.AlltipoRigaServizio)
                        Dim isSospeso As Boolean = False
                        Dim isAnnullato As Boolean = False
                        Dim isDaRifatturare As Boolean = False
                        Dim attDaRifatturare As New List(Of AllordCliAttivita)
                        Dim isISTAT As Boolean = False
                        Dim attIstat As New List(Of AllordCliAttivita)

#End Region
                        For Each att In c.AllordCliAttivita
                            msgLog = "## Attività:(" & att.Line & ") " & att.Attivita & " " & att.DataInizio.Value.ToShortDateString & " " & att.RifServizio & " " & att.RifLinea & " " & att.Nota
                            Debug.Print(msgLog)
                            debugging.AppendLine(msgLog)
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
                                Dim dCanoniSospesi As Double
                                If IsBetweenSospensione(att.DataInizio, att.DataFine, curDate, dCanoniSospesi) Then
                                    isSospeso = True
                                    If dCanoniSospesi = c.Qta.Value Then isOk = False
                                    If dCanoniSospesi > 0 Then curQta -= dCanoniSospesi
                                    msgLog = "## [Sospensione] ## : Mesi " & dCanoniSospesi.ToString & " dal " & att.DataInizio.Value.ToShortDateString & " al " & att.DataFine.Value.ToShortDateString
                                    Debug.Print(msgLog)
                                    debugging.AppendLine(msgLog)
                                End If
                                'Mesi da rifatturare
                                Dim dCanoniRipresi As Double
                                If CBool(att.DaFatturare) AndAlso IsBetweenRipresi(att, dataFattDa, dataFattA, dCanoniRipresi) Then
                                    isDaRifatturare = True
                                    If dCanoniRipresi > 0 Then
                                        'Setto il valore nella proprietà  Shadow
                                        att.CanoniRipresi = dCanoniRipresi
                                        'att.CanoniRipresi = dCanoniRipresi
                                        attDaRifatturare.Add(att)
                                        isOk = True
                                        msgLog = "## [Ripresa] ## : il " & att.DataRifatturazione.ToString
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
                            'STEP 3b: Ciclo sulle Attività per Annullamento 
                            If CBool(att.Allattivita.Annullamento) Then
                                '--- Controllo Esclusioni di Annullamento---
                                curDate.DataCessazione = att.DataInizio

                                'Controllo la data di Inizio
                                Dim dCanoniResidui As Double
                                If IsBetweenAnnullamento(att.DataInizio, curDate, dCanoniResidui) Then
                                    'In dCanoniresidui ho il delta dei mesi
                                    If dCanoniResidui > 0 Then
                                        isAnnullato = True
                                        curQta = (dCanoniResidui - c.Qta.Value + curQta)
                                        debugging.AppendLine("## Annullamento Parziale ##")
                                    Else
                                        isAnnullato = True
                                        curQta = 0
                                        isOk = False
                                        debugging.AppendLine("## Annullamento Parziale -> Totale ##")
                                    End If
                                ElseIf att.DataInizio <> sDataNulla AndAlso att.DataInizio < curDate.CanoniDataIn Then
                                    'Completamente annullata
                                    isAnnullato = True
                                    isOk = False
                                    Debug.Print("## Annullamento Totale ##")
                                    debugging.AppendLine("## Annullamento Totale ##")
                                    Exit For
                                End If
                            End If
                            'STEP 3c: Ciclo sulle Attività per Istat 
                            If CBool(att.Allattivita.Istat) Then
                                '--- Controllo Esclusioni di ISTAT---

                                'Fatturata
                                If CBool(att.Fatturata) Then
                                    Debug.Print("## [Fatturata] ##")
                                    debugging.AppendLine("## [Fatturata] ##")
                                    Continue For
                                End If
                                'E' nel range
                                If CBool(att.DaFatturare) AndAlso IsBetweenIstat(att, dataFattDa, dataFattA) Then
                                    isISTAT = True
                                    isOk = True
                                    msgLog = "## [ISTAT] ## : il " & att.DataRifatturazione.ToString
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
                        'STEP 4 : Controllo Scadenza Fissa
                        If curScadenzaFissa <> sDataNulla AndAlso curDate.CanoniDataFin >= curScadenzaFissa Then
                            isScadenzaFissa = True
                            msgLog = "Ordine: " & curOrdNo & " Cliente: " & curCliente & " con scadenza fissa. Controllare canoni!"
                            avvisi.AppendLine(msgLog)
                            debugging.AppendLine(msgLog)
                            'Simile a Mesi annullati
                            Dim dCanoniFinoA As Double
                            If IsBetweenAnnullamento(curScadenzaFissa, curDate, dCanoniFinoA) Then
                                'In dCanoniFinoA ho i mesi da fatturare
                                If dCanoniFinoA > 0 Then
                                    curQta = (dCanoniFinoA - c.Qta.Value + curQta)
                                    debugging.AppendLine("## Scadenza Fissa ##")
                                Else
                                    curQta = 0
                                    isOk = False
                                    debugging.AppendLine("## Scadenza Fissa -> Totale ##")
                                End If
                            End If

                            If o.ALLOrdCliAcc.DataCessazione = sDataNulla Then
                                o.ALLOrdCliAcc.DataCessazione = curScadenzaFissa
                                o.ALLOrdCliAcc.MotivoCessazione = "[AUTO] Scadenza Fissa"
                                o.ALLOrdCliAcc.Tbmodified = Now
                                o.ALLOrdCliAcc.TbmodifiedId = sLoginId
                                debugging.AppendLine("Ordine: " & curOrdNo & " Impostata cessazione: " & curScadenzaFissa.ToShortDateString)
                                efAllordCliAcc.Add(o.ALLOrdCliAcc)
                            Else
                                errori.AppendLine("Ordine: " & curOrdNo & " Cliente: " & curCliente & " con data cessazione già valorizzata. Controllare scadenza fissa!")
                            End If
                        End If
                        'STEP 5 : Controllo Data Cessazione
                        If curDataCessazione <> sDataNulla AndAlso curDate.CanoniDataFin >= curDataCessazione Then
                            If isAnnullato Then
                                'Controllo che le date coincidano o che quella generale sia successiva.
                                If curDataCessazione < curDate.DataCessazione Then
                                    isCessazione = True
                                    msgLog = "Ordine: " & curOrdNo & " Cliente: " & curCliente & " cessato il " & curDataCessazione.ToShortDateString & ". Controllare esattezza canoni!"
                                    errori.AppendLine("DISCREPANZA Ordine: " & curOrdNo & " Cliente: " & curCliente & " cessato il " & curDataCessazione.ToShortDateString & ". Controllare esattezza canoni!")
                                    'TODO CALCOLARE I MESI  
                                End If
                            Else
                                'Se la riga non era annullata allora valorizzo isCessazione
                                isCessazione = True
                            End If
                            msgLog = "Ordine: " & curOrdNo & " Cliente: " & curCliente & " cessato il " & curDataCessazione.ToShortDateString & ". Controllare esattezza canoni!"
                            avvisi.AppendLine(msgLog)
                            debugging.AppendLine(msgLog)
                            'Simile a Mesi annullati
                            'TODO ( vedere com interagisce con sospesi , annullati o altro)
                            Dim dCanoniFinoA As Double
                            If IsBetweenAnnullamento(curDataCessazione, curDate, dCanoniFinoA) Then
                                'In dCanoniFinoA ho i mesi da fatturare
                                If dCanoniFinoA > 0 Then
                                    curQta = (dCanoniFinoA - c.Qta.Value + curQta)
                                    debugging.AppendLine("## Cessato ##")
                                Else
                                    curQta = 0
                                    isOk = False
                                    debugging.AppendLine("## Cessato -> Totale ##")
                                End If
                            End If

                            'If o.ALLOrdCliAcc.DataCessazione = sDataNulla Then
                            '    o.ALLOrdCliAcc.DataCessazione = curScadenzaFissa
                            '    o.ALLOrdCliAcc.MotivoCessazione = "[AUTO] Scadenza Fissa"
                            '    o.ALLOrdCliAcc.Tbmodified = Now
                            '    o.ALLOrdCliAcc.TbmodifiedId = sLoginId
                            '    debugging.AppendLine("Ordine: " & curOrdNo & " Impostata cessazione: " & curScadenzaFissa.ToShortDateString)
                            '    efAllordCliAcc.Add(o.ALLOrdCliAcc)
                            'Else
                            '    errori.AppendLine("Ordine: " & curOrdNo & " Cliente: " & curCliente & " con data cessazione già valorizzata. Controllare cessazione!")
                            'End If
                        End If
                        'Se ok allora Creo nuova riga di dettaglio
                        If (isOk OrElse isDaRifatturare) AndAlso curQta > 0 Then
#Region "Controllo su prima riga bianca"
                            If o.MaSaleOrdDetails.Any AndAlso o.MaSaleOrdDetails.Count = 1 Then

                                'Controllo sull'inserimento automatico da Mago ( Articolo=vuoto + merce + line e pos = 1)
                                If String.IsNullOrWhiteSpace(o.MaSaleOrdDetails.First.Item) AndAlso o.MaSaleOrdDetails.First.LineType = LineType.Merce AndAlso o.MaSaleOrdDetails.First.Line = 1 AndAlso o.MaSaleOrdDetails.First.Position = 1 Then
                                    ' Faccio in modo di sovrascivere
                                    curLastLine = 0
                                    curLastPosition = 0
                                End If
                                'Controllo sull'inserimento a Mano Valunit=0 + line e pos= 1
                                If (o.MaSaleOrdDetails.First.LineType = LineType.Merce OrElse o.MaSaleOrdDetails.First.LineType = LineType.Servizio) AndAlso o.MaSaleOrdDetails.First.UnitValue = 0 AndAlso o.MaSaleOrdDetails.First.Line = 1 AndAlso o.MaSaleOrdDetails.First.Position = 1 Then
                                    ' Faccio in modo di sovrascivere
                                    curLastLine = 0
                                    curLastPosition = 0
                                End If
                            End If
#End Region
                            'Controllo e imposto data prevista consegna con la piu' vecchia ( serve nel caso di rifatturazione)
                            If attDaRifatturare.Any Then
                                For Each aDaRif In attDaRifatturare
                                    If aDaRif.DataRifatturazione < curDate.DataPrevistaConsegna Then
                                        If Not isDaEscludere Then avvisi.AppendLine("Ordine " & curOrdNo & " Servizio " & curItem & " con date prevista fatturazione non congruenti !")
                                        curDate.DataPrevistaConsegna = aDaRif.DataRifatturazione
                                        curDate.DataConfermaConsegna = aDaRif.DataRifatturazione
                                    End If
                                Next
                            End If
#Region "Scrivo Testo descrittivo su MaSaleOrdDetails"
                            isNewRows = True
                            'STEP 6 : Ciclo le righe Descrizioni
                            If Not bScrittoDescrizioni Then
                                For Each d In o.ALLordCliDescrizioni
                                    msgLog = "### Riga descrittiva:(" & d.Line & ") " & d.Descrizione
                                    Debug.Print(msgLog)
                                    debugging.AppendLine(msgLog)
                                    iNewRowsCount += 1
                                    iNrRigheNota += 1
                                    bScrittoDescrizioni = True
                                    Dim rd As New MaSaleOrdDetails With {
                                        .Line = curLastLine + iNewRowsCount,
                                        .Position = 0,
                                        .SubId = curLastLine + iNewRowsCount,
                                        .SaleOrdId = curSaleOrdId,
                                        .LineType = LineType.Nota,
                                        .Description = d.Descrizione,
                                        .InEi = "1",
                                        .ExpectedDeliveryDate = curDate.DataPrevistaConsegna,
                                        .ConfirmedDeliveryDate = curDate.DataConfermaConsegna, ' sDataNulla
                                        .InternalOrdNo = curOrdNo,
                                        .Customer = curCliente,
                                        .OrderDate = curOrdDate,
                                        .NoOfPacks = 0,
                                        .ProductionPlanLine = 0,
                                        .ExternalLineReference = 0,
                                        .Tbcreated = Now,
                                        .Tbmodified = Now,
                                        .TbcreatedId = sLoginId,
                                        .TbmodifiedId = sLoginId,
                                        .Item = "",
                                        .UoM = "",
                                        .Qty = 0,
                                        .UnitValue = 0,
                                        .TaxableAmount = 0,
                                        .TotalAmount = 0,
                                        .PacksUoM = "",
                                        .TaxCode = "",
                                        .Job = "",
                                        .CostCenter = "",
                                        .Offset = "",
                                        .Notes = "",
                                        .NetPrice = 0,
                                        .ContractCode = "",
                                        .ProjectCode = "",
                                        .AllNrCanoni = 0,
                                        .AllCanoniDataI = sDataNulla,
                                        .AllCanoniDataF = sDataNulla
                                    }
                                    'Aggiungo la riga alla collection
                                    efMaSaleOrdDetails.Add(rd)
                                Next
                            End If

#End Region
                            curPercIva = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = curCodIva).Perc.Value, decPerc)
                            If curPercIva = 0 Then curPercIva = dDefPercIva
#Region "Righe da rifatturare"
                            For Each aDaRif In attDaRifatturare
                                Debug.Print("### Riga da rifatt:(" & aDaRif.Line & ") " & aDaRif.Attivita)
                                debugging.AppendLine("### Riga da rifatt:(" & aDaRif.Line & ") " & aDaRif.Attivita)

                                iNewRowsCount += 1
                                iNrRigheAValore += 1
                                Dim rRif As New MaSaleOrdDetails
                                rRif.Line = curLastLine + iNewRowsCount
                                rRif.Position = curLastPosition + iNrRigheAValore
                                rRif.SubId = curLastLine + iNewRowsCount
                                rRif.SaleOrdId = curSaleOrdId
                                rRif.LineType = LineType.Servizio
                                rRif.Item = curItem
                                Dim periodoRif As String = "Periodo dal " & aDaRif.DataInizio.Value.ToString("dd/MM/yyyy") & " al " & aDaRif.DataFine.Value.ToString("dd/MM/yyyy")
                                rRif.Description = If(String.IsNullOrWhiteSpace(curDescri), periodoRif, curDescri & " " & periodoRif)
                                rRif.UoM = curUom
                                rRif.PacksUoM = curUom
                                rRif.Qty = aDaRif.CanoniRipresi.Value
                                If aDaRif.ValUnit = 0 Then errori.AppendLine("Ordine: " & curOrdNo & " Pos.: " & rRif.Position & " Servizio: " & curItem & " con valore unitario di ripresa uguale a 0.00")
                                rRif.UnitValue = Math.Round(aDaRif.ValUnit.Value, decValUnit) ' Pesco il valore unitario dall'attività
                                rRif.NetPrice = curValUnit
                                rRif.TaxableAmount = Math.Round(aDaRif.CanoniRipresi.Value * curValUnit, decValUnit)
                                rRif.TaxCode = curCodIva
                                rRif.TotalAmount = Math.Round((aDaRif.CanoniRipresi.Value * curValUnit) * ((100 + curPercIva) / 100), decTax)
                                rRif.ExpectedDeliveryDate = curDate.DataPrevistaConsegna
                                rRif.ConfirmedDeliveryDate = curDate.DataConfermaConsegna
                                rRif.AllNrCanoni = aDaRif.CanoniRipresi.Value
                                rRif.AllCanoniDataI = aDaRif.DataInizio.Value
                                rRif.AllCanoniDataF = aDaRif.DataFine.Value
                                rRif.Notes = Trim(Left(aDaRif.Nota.ToString, 32))
                                rRif.Job = curCommessa
                                rRif.CostCenter = curCdC
                                rRif.ContractCode = curCIG
                                rRif.ProjectCode = curCUP
                                rRif.Offset = curOffset
                                rRif.InternalOrdNo = curOrdNo
                                rRif.Customer = curCliente
                                rRif.OrderDate = curOrdDate
                                rRif.NoOfPacks = 0
                                rRif.ProductionPlanLine = 0
                                rRif.ExternalLineReference = 0
                                rRif.InEi = 0
                                rRif.Tbcreated = Now
                                rRif.Tbmodified = Now
                                rRif.TbcreatedId = sLoginId
                                rRif.TbmodifiedId = sLoginId

                                'Aggiungo la riga alla collection
                                'OrdContext.MaSaleOrdDetails.Add(rRif)
                                efMaSaleOrdDetails.Add(rRif)
                            Next
#End Region
#Region "Scrivo MaSaleOrdDetails"
                            If Not isDaEscludere Then
                                'Scrivo il corpo solo nel caso dei canoni ( in caso di rifatturazione potrei non averne)
                                Debug.Print("### Riga corpo:(" & c.Line & ") " & c.Servizio)
                                debugging.AppendLine("### Riga corpo:(" & c.Line & ") " & c.Servizio)
                                iNewRowsCount += 1
                                iNrRigheAValore += 1
                                Dim r As New MaSaleOrdDetails
                                r.Line = curLastLine + iNewRowsCount
                                r.Position = curLastPosition + iNrRigheAValore
                                r.SubId = curLastLine + iNewRowsCount
                                r.SaleOrdId = curSaleOrdId
                                r.LineType = LineType.Servizio
                                r.Item = curItem
                                Dim perDataFine As String = If(isScadenzaFissa, curScadenzaFissa.ToShortDateString, curDate.CanoniDataFin.ToShortDateString)
                                perDataFine = If(isAnnullato, curDate.DataCessazione.ToShortDateString, perDataFine)
                                perDataFine = If(isCessazione, curDataCessazione.ToShortDateString, perDataFine)
                                Dim periodo As String = "Periodo dal " & curDate.CanoniDataIn.ToShortDateString & " al " & perDataFine
                                If curDate.UnaTantum Then
                                    r.Description = curDescri
                                    'Segno come Fatturata
                                    c.Fatturato = "1"
                                Else
                                    r.Description = If(String.IsNullOrWhiteSpace(curDescri), periodo, curDescri & " " & periodo)
                                End If
                                r.UoM = curUom
                                r.PacksUoM = curUom
                                r.Qty = curQta
                                r.UnitValue = curValUnit
                                r.NetPrice = curValUnit
                                r.TaxableAmount = Math.Round(curQta * curValUnit, decValUnit)
                                r.TaxCode = curCodIva
                                r.TotalAmount = Math.Round((curQta * curValUnit) * ((100 + curPercIva) / 100), decTax)
                                r.ExpectedDeliveryDate = curDate.DataPrevistaConsegna
                                r.ConfirmedDeliveryDate = curDate.DataConfermaConsegna
                                'TODO: chiedere se data fine competenza in caso di Scadenza fissa e' fine periodo o la data scadenza fissa
                                'TODO: Idem per quantità
                                r.AllNrCanoni = curQta 'curDate.NrCanoni '-> visto che potrebbe variare uso curQta
                                r.AllCanoniDataI = curDate.CanoniDataIn
                                r.AllCanoniDataF = curDate.CanoniDataFin
                                r.Notes = Trim(Left(c.Nota.ToString, 32))
                                r.Job = curCommessa
                                r.CostCenter = curCdC
                                r.ContractCode = curCIG
                                r.ProjectCode = curCUP
                                r.Offset = curOffset
                                r.InternalOrdNo = curOrdNo
                                r.Customer = curCliente
                                r.OrderDate = curOrdDate
                                r.NoOfPacks = 0
                                r.ProductionPlanLine = 0
                                r.ExternalLineReference = 0
                                r.InEi = 0
                                r.Tbcreated = Now
                                r.Tbmodified = Now
                                r.TbcreatedId = sLoginId
                                r.TbmodifiedId = sLoginId

                                'Aggiungo la riga alla collection
                                'OrdContext.MaSaleOrdDetails.Add(r)
                                efMaSaleOrdDetails.Add(r)
                            End If
#End Region
#Region "Righe ISTAT"
                            For Each aIst In attIstat
                                'todo (genera ordini): testare riga istat
                                msgLog = "### Riga Istat:(" & aIst.Line & ") " & aIst.Attivita
                                Debug.Print(msgLog)
                                debugging.AppendLine(msgLog)

                                iNewRowsCount += 1
                                iNrRigheNota += 1
                                'bScrittoDescrizioni = True
                                Dim rd As New MaSaleOrdDetails With {
                                .Line = curLastLine + iNewRowsCount,
                                .Position = 0,
                                .SubId = curLastLine + iNewRowsCount,
                                .SaleOrdId = curSaleOrdId,
                                .LineType = LineType.Nota,
                                .Description = aIst.TestoFattura,
                                .InEi = "1",
                                .ExpectedDeliveryDate = curDate.DataPrevistaConsegna,
                                .ConfirmedDeliveryDate = curDate.DataConfermaConsegna, ' sDataNulla
                                .InternalOrdNo = curOrdNo,
                                .Customer = curCliente,
                                .OrderDate = curOrdDate,
                                .NoOfPacks = 0,
                                .ProductionPlanLine = 0,
                                .ExternalLineReference = 0,
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId,
                                .Item = "",
                                .UoM = "",
                                .Qty = 0,
                                .UnitValue = 0,
                                .TaxableAmount = 0,
                                .TotalAmount = 0,
                                .PacksUoM = "",
                                .TaxCode = "",
                                .Job = "",
                                .CostCenter = "",
                                .Offset = "",
                                .Notes = "",
                                .NetPrice = 0,
                                .ContractCode = "",
                                .ProjectCode = "",
                                .AllNrCanoni = 0,
                                .AllCanoniDataI = sDataNulla,
                                .AllCanoniDataF = sDataNulla
                            }
                                'Aggiungo la riga alla collection
                                efMaSaleOrdDetails.Add(rd)
                                'Aggiungo l'attività alla collection ( per aggionare il flag Fatturata)
                                efAllordCliAttivita.Add(aIst)
                            Next
#End Region
                        End If
#Region "Aggiorno date prossima Fatturazione"
                        If Not isDaEscludere AndAlso (isOk OrElse isDaRifatturare OrElse isSospeso) Then
                            If curDate.DataProssimaFattura < dataFattA Then avvisi.AppendLine("Ordine " & curOrdNo & " Servizio " & curItem & " con data prossima fatturazione antecedente alla data competenza !")
                            c.DataProssimaFatt = curDate.DataProssimaFattura
                            c.DataFineElaborazione = Now
                            c.Tbmodified = Now
                            c.TbmodifiedId = sLoginId
                            efAllordCliContratto.Add(c)
                            isUpdateRows = True
                        End If
#End Region

                    Next
                    'Se ho scritto qualche riga svuoto il flag Consegnato, Fatturato etc. della testa
                    'Aggiorno il cotatore ordini Ok
                    If isNewRows Then
                        o.Invoiced = "0"
                        o.Delivered = "0"
                        o.Picked = "0"
                        o.LastSubId = curLastLine + iNewRowsCount
                        o.Tbmodified = Now
                        o.TbmodifiedId = sLoginId
                        totOrdiniConNuoveRighe += 1
                        msgLog = "#### Ordine: " & o.InternalOrdNo & " Nuove righe N:" & iNrRigheNota.ToString & " S:" & iNrRigheAValore.ToString
                        Debug.Print(msgLog)
                        debugging.Append(msgLog)
                        efMaSaleOrd.Add(o)
                    End If
                    If isUpdateRows Then totOrdiniConRigheAggiornate += 1
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
        If bIsDebugging AndAlso debugging.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Debugging ---" & Environment.NewLine & debugging.ToString)

        Return Not someTrouble

    End Function
    Public Function AdeguaIstatOrdine() As Boolean

#Region "Variabili Selezione"
        'Variabili legate alla maschera di selezione 
        Dim bFiltroDateOrdini As Boolean
        Dim fromOrdDate As Date
        Dim toOrdDate As Date
        Dim bSingoloOrdine As Boolean
        Dim nrOrd As String = ""
        Dim bSingoloCliente As Boolean
        Dim cliente As String = ""
        Dim bSingolaFiliale As Boolean
        Dim filiale As String = ""
        Dim dataDecorrenza As Date
        Dim percIstat As Double = 0
        Dim cauAttivita As String = ""
        Dim annoAdeguamento As Integer = 0
        Dim testoFattura As String = ""

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
                'dataRifatturazione = ff.DtaIstatRifatt.Value 'Data giorno di fatturazione
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

            'ESEGUO LA QUERY
            Dim allOrders = q.ToList

            'Creo le entities che usero' poi con BulkInsert
            Dim efAllordCliAttivita As New List(Of AllordCliAttivita)
            Dim efAllordCliContratto As New List(Of AllordCliContratto)
#End Region

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

                'Ciclo su tutti gli ordini
                For Each o In allOrders
                    FLogin.prgCopy.PerformStep()
                    FLogin.prgCopy.Update()
                    Application.DoEvents()
                    Debug.Print("Ordine: " & o.InternalOrdNo)
                    debugging.AppendLine("Ordine: " & o.InternalOrdNo)
#Region "Inizializzazione"
                    'Resetto alcune cose 
                    Dim isNewRowsAtt As Boolean = False
                    Dim iNewRowsAttCount As Integer = 0
                    Dim curLastLineAtt As Integer = If(o.AllordCliAttivita.Any, o.AllordCliAttivita.Max(Function(m) m.Line), 0)
                    'Inizializzo alcuni valori
                    Dim curSaleOrdId As Integer = o.SaleOrdId
                    Dim curCliente As String = o.Customer
                    Dim curOrdNo As String = o.InternalOrdNo
                    Dim curScadenzaFissa As Date = o.ALLOrdCliAcc.DataScadenzaFissa

#End Region
                    'STEP 1 : Ciclo le righe contratto
                    For Each c In o.ALLordCliContratto
#Region "Esclusioni Righe Contratto"
                        Dim sEx As String = c.Line & ") " & c.TipoRigaServizio & " " & c.Servizio
                        'Controllo Esclusioni 
                        If c.AlltipoRigaServizio.Consuntivo Then
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
                        Dim isOk As Boolean = True
                        'STEP 2: Determino date ( Consegna, nr canoni etc.)
                        Dim curDate As MyBloccoDate = ValorizzaDate(c.DataProssimaFatt, c.AlltipoRigaServizio)
                        Dim curItem As String = c.Servizio
                        Dim curRifLinea As Integer = c.Line
                        Dim curValUnit As Double = Math.Round(c.ValUnitIstat.Value, decValUnit)
                        If curValUnit <= 0 Then errori.AppendLine("Ordine: " & curOrdNo & " Valore Unitario Att <= 0 // Riga: (" & sEx)
                        Dim isSospeso As Boolean = False
                        Dim isAnnullato As Boolean = False
                        Dim isDaRifatturare As Boolean = False
                        Dim attDaAdeguare As New List(Of AllordCliAttivita)
                        Dim isIstat As Boolean = False
#End Region
                        For Each att In c.AllordCliAttivita
                            Debug.Print("## Attività:(" & att.Line & ") " & att.Attivita & " " & att.DataInizio.Value.ToShortDateString & " " & att.RifServizio & " " & att.RifLinea & " " & att.Nota)
                            debugging.AppendLine("## Attività:(" & att.Line & ") " & att.Attivita & " " & att.DataInizio.Value.ToShortDateString & " " & att.RifServizio & " " & att.RifLinea & " " & att.Nota)
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
                                    isSospeso = True
                                    msgLog = "## [Sospensione] ## : dal " & att.DataInizio.Value.ToShortDateString & " al " & att.DataFine.Value.ToShortDateString
                                    Debug.Print(msgLog)
                                    debugging.AppendLine(msgLog)
                                    attDaAdeguare.Add(att)
                                    isOk = True
                                End If

                            End If

                            'STEP 3b: Ciclo sulle Attività per Annullamento 
                            If CBool(att.Allattivita.Annullamento) Then
                                '--- Controllo Esclusioni di Annullamento---

                                isAnnullato = True
                                'Controllo la data di Inizio
                                Dim dCanoniResidui As Double
                                If IsBetweenAnnullamento(att.DataInizio, curDate, dCanoniResidui) Then
                                    'In dCanoniresidui ho il delta dei mesi
                                    If dCanoniResidui > 0 Then
                                        debugging.AppendLine("## Annullamento Parziale ##")
                                    Else
                                        isOk = False
                                        debugging.AppendLine("## Annullamento Parziale -> Totale ##")
                                    End If
                                ElseIf att.DataInizio <> sDataNulla AndAlso att.DataInizio < curDate.CanoniDataIn Then
                                    'Completamente annullata
                                    isOk = False
                                    Debug.Print("## Annullamento Totale ##")
                                    debugging.AppendLine("## Annullamento Totale ##")
                                    Exit For
                                End If
                            End If

                            'STEP 3c: Ciclo sulle Attività per Istat 
                            'Devo assicurarmi di non adeguare nuovamente all'istat quelli antecenti a xxxxx
                            If CBool(att.Allattivita.Istat) Then
                                '--- Controllo Esclusioni di ISTAT---

                                'E' nel range
                                If CBool(att.DaFatturare) AndAlso att.DataRifatturazione.Value.Year = annoAdeguamento Then
                                    isIstat = True
                                    'TODO: Valutare se usare avvisi o debugging
                                    avvisi.AppendLine("Ordine: " & curOrdNo & " con riga di adeguamento Istat già presente per l'anno: " & annoAdeguamento.ToString)
                                    isOk = False
                                End If
                            End If
                        Next
                        'STEP 4 : Controllo Scadenza Fissa
                        If curScadenzaFissa <> sDataNulla AndAlso curDate.CanoniDataFin > curScadenzaFissa Then
                            avvisi.AppendLine("Ordine: " & curOrdNo & " Cliente: " & curCliente & " con scadenza fissa. Controllare canoni!")
                            debugging.AppendLine("Ordine: " & curOrdNo & " Cliente: " & curCliente & " con scadenza fissa. Controllare canoni!")
                            'Simile a Mesi annullati
                            Dim dCanoniFinoA As Double
                            If IsBetweenAnnullamento(curScadenzaFissa, curDate, dCanoniFinoA) Then
                                'In dcanoniFinoA ho i mesi da fatturare
                                If dCanoniFinoA > 0 Then
                                    debugging.AppendLine("## Scadenza Fissa ##")
                                Else
                                    isOk = False
                                    debugging.AppendLine("## Scadenza Fissa -> Totale ##")
                                End If
                            End If
                        End If
                        'Se ok allora 
                        If isOk AndAlso Not isIstat Then
#Region "Adeguo AllordCliContratto"
                            'Adeguo riga di Canone
                            isNewRowsAtt = True
                            Debug.Print("### Riga contratto:(" & c.Line & ") " & c.Servizio)
                            debugging.AppendLine("### Riga contratto:(" & c.Line & ") " & c.Servizio)
                            Dim newValUnit As Double = Math.Round(curValUnit * (1 + (percIstat / 100)), decValUnit)
                            c.ValUnitIstat = newValUnit
                            c.DataUltRivIstat = Now
                            c.DataFineElaborazione = Now
                            efAllordCliContratto.Add(c)
#End Region
                            'Creo la riga di Attività
                            '27/12/2021: Aggiunta possibilità di rifatturazione per creare riga di nota con scritta
                            iNewRowsAttCount += 1
                            Dim rAtt As New AllordCliAttivita With {
                                .IdOrdCli = curSaleOrdId,
                                .Line = curLastLineAtt + iNewRowsAttCount,
                                .Attivita = "ISTAT",
                                .DataInizio = dataDecorrenza,
                                .DataFine = sDataNulla,
                                .DaFatturare = "1",
                                .DataRifatturazione = curDate.DataPrevistaConsegna,
                                .Fatturata = "0",
                                .Nota = "Adeguamento ISTAT (" & percIstat.ToString & "%). Precedente: " & curValUnit.ToString,
                                .TestoFattura = testoFattura,
                                .RifServizio = curItem,
                                .RifLinea = curRifLinea,
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
        If bIsDebugging AndAlso debugging.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Debugging ---" & Environment.NewLine & debugging.ToString)

        Return Not someTrouble

    End Function
    Private Class CurOrd
        Public Property SaleOrdId As Integer
        Public Property LastLine As Integer
        Public Property LastPosition As Integer
        Public Property Cliente As String
        Public Property OrdDate As Date
        Public Property OrdNo As String
        Public Property ScadenzaFissa As Date
        Public Property DataCessazione As Date
        Public Property Commessa As String
        Public Property CdC As String
        Public Property CIG As String
        Public Property CUP As String
    End Class

    Private Class CurOrdRow
        Public Property DataDecorrenza As Date
        Public Property DataProssimaFattura As Date
        Public Property DataPrevistaConsegna As Date
        Public Property DataConfermaConsegna As Date
        Public Property QtaIniziale As Short
        Public Property QtaCorrente As Short
        Public Property QtaDaRifatturare As Short
        Public Property DataProssimaRifatturazione As Date
        Public Property QtaSospesa As Short
        Public Property Sospeso As Boolean
        Public Property QtaAnnullata As Short
        Public Property Annullato As Boolean
        Public Property CanoniDataIn As Date
        Public Property CanoniDataFin As Date
        Public Property UnaTantum As Boolean
        Public Property DataCessazione As Date
        Public Sub New()
            Dim d As Date = OnlyDate(Now)
            DataDecorrenza = d
            DataProssimaFattura = d
            DataPrevistaConsegna = d
            DataConfermaConsegna = d
            QtaIniziale = 0
            QtaCorrente = 0
            QtaDaRifatturare = 0
            DataProssimaRifatturazione = d
            QtaSospesa = 0
            Sospeso = False
            QtaAnnullata = 0
            Annullato = False
            CanoniDataIn = d
            CanoniDataFin = d
            UnaTantum = True
            DataCessazione = New DateTime(1799, 12, 31)
        End Sub
    End Class
    Private Class MyBloccoDate
        Public Property DataPrevistaConsegna As Date
        Public Property DataConfermaConsegna As Date
        Public Property DataProssimaFattura As Date
        Public Property NrCanoni As Short
        Public Property CanoniDataIn As Date
        Public Property CanoniDataFin As Date
        Public Property UnaTantum As Boolean
        Public Property DataCessazione As Date

        Public Sub New()
            Dim d As Date = OnlyDate(Now)
            DataPrevistaConsegna = d
            DataConfermaConsegna = d
            DataProssimaFattura = d
            NrCanoni = 0
            CanoniDataIn = d
            CanoniDataFin = d
            UnaTantum = True
            DataCessazione = New DateTime(1799, 12, 31)
        End Sub
    End Class

    Private Function EvalCurOrdRow(ByVal nextDate As Date, t As AlltipoRigaServizio) As CurOrdRow
        Dim r As New CurOrdRow With {
        .DataPrevistaConsegna = nextDate,
        .DataConfermaConsegna = nextDate,
        .UnaTantum = CBool(t.UnaTantum)
            }
        Dim bIsAnt = t.Cadenza.Value = Cadenza.Anticipato
        Dim iNrCanoni As Integer
        If CBool(t.Canone) Then
            Select Case t.Periodicita
                Case Periodo.Annuale
                    iNrCanoni = 12
                Case Periodo.Semestrale
                    iNrCanoni = 6
                Case Periodo.Quadrimestrale
                    iNrCanoni = 4
                Case Periodo.Trimestrale
                    iNrCanoni = 3
                Case Periodo.Bimestrale
                    iNrCanoni = 2
                Case Periodo.Mensile
                    iNrCanoni = 1
            End Select
            r.CanoniDataIn = If(bIsAnt, nextDate, nextDate.AddMonths(-(iNrCanoni)).AddDays(1))
            r.CanoniDataFin = If(bIsAnt, nextDate.AddMonths(iNrCanoni).AddDays(-1), nextDate)
            r.DataProssimaFattura = nextDate.AddMonths(iNrCanoni)
        ElseIf CBool(t.UnaTantum) Then
            iNrCanoni = 1
            r.CanoniDataIn = nextDate
            r.CanoniDataFin = nextDate
        End If
        r.QtaIniziale = iNrCanoni
        Return r
    End Function

    Private Function ValorizzaDate(ByVal nextDate As Date, t As AlltipoRigaServizio) As MyBloccoDate
        Dim d As New MyBloccoDate With {
        .DataPrevistaConsegna = nextDate,
        .DataConfermaConsegna = nextDate,
        .UnaTantum = CBool(t.UnaTantum)
            }
        Dim bIsAnt = t.Cadenza.Value = Cadenza.Anticipato
        Dim iNrCanoni As Integer
        If CBool(t.Canone) Then
            Select Case t.Periodicita
                Case Periodo.Annuale
                    iNrCanoni = 12
                Case Periodo.Semestrale
                    iNrCanoni = 6
                Case Periodo.Quadrimestrale
                    iNrCanoni = 4
                Case Periodo.Trimestrale
                    iNrCanoni = 3
                Case Periodo.Bimestrale
                    iNrCanoni = 2
                Case Periodo.Mensile
                    iNrCanoni = 1
            End Select
            d.CanoniDataIn = If(bIsAnt, nextDate, nextDate.AddMonths(-(iNrCanoni)).AddDays(1))
            d.CanoniDataFin = If(bIsAnt, nextDate.AddMonths(iNrCanoni).AddDays(-1), nextDate)
            d.DataProssimaFattura = nextDate.AddMonths(iNrCanoni)
        ElseIf CBool(t.UnaTantum) Then
            iNrCanoni = 1
            d.CanoniDataIn = nextDate
            d.CanoniDataFin = nextDate
        End If
        d.NrCanoni = iNrCanoni
        Return d
    End Function

    Friend Enum Cadenza As Integer
        Anticipato = 2009399296
        Posticipato = 2009399297
    End Enum
    Friend Enum Periodo As Integer
        Annuale = 1094254592
        Mensile = 1094254593
        Bimestrale = 1094254594
        Trimestrale = 1094254595
        Quadrimestrale = 1094254596
        Semestrale = 1094254598
        Variabile = 1094254692
    End Enum
    Private Function IsBetweenAnnullamento(ByVal data As Date, ByVal range As MyBloccoDate, ByRef canoniResidui As Double) As Boolean
        Dim result As Boolean = False
        canoniResidui = 0
        If data >= range.CanoniDataIn AndAlso data <= range.CanoniDataFin Then
            result = True
            canoniResidui = CalcolaMesi(range.CanoniDataIn, data)
        End If
        Return result
    End Function
    Private Function IsBetweenSospensione(ByVal dataInizio As Date, ByVal dataFine As Date, ByVal range As MyBloccoDate, ByRef canoniSospesi As Double) As Boolean
        Dim result As Boolean = False
        If dataInizio >= range.CanoniDataFin Then Return False
        If dataFine <= range.CanoniDataIn Then Return False

        canoniSospesi = 0
        If (dataInizio >= range.CanoniDataIn AndAlso dataInizio <= range.CanoniDataFin) AndAlso (dataFine >= range.CanoniDataIn AndAlso dataFine <= range.CanoniDataFin) Then
            result = True
            canoniSospesi = CalcolaMesi(dataInizio, dataFine)
            'La sospensione inizia con la data di inizio periodo
            ' If dataInizio = range.CanoniDataIn Then
            'canoniSospesi = CalcolaMesi(dataInizio, dataFine)
            'ElseIf dataFine = range.CanoniDataFin Then
            'canoniSospesi = CalcolaMesi(dataInizio, dataFine)
            'Else
            'canoniSospesi = CalcolaMesi(range.CanoniDataIn, dataInizio)
            'End If
        Else
            'Ci potrebbero essere date a cavallo del periodo di fatturazione
            'Data Inizio antecedente al periodo con ( Data Fine compresa)
            If dataInizio < range.CanoniDataIn AndAlso (dataFine >= range.CanoniDataIn AndAlso dataFine <= range.CanoniDataFin) Then
                result = True
                canoniSospesi = CalcolaMesi(range.CanoniDataIn, dataFine)
            End If

            '(Data Inizio compresa) con Data Fine Successiva al periodo 
            If (dataInizio >= range.CanoniDataIn AndAlso dataInizio <= range.CanoniDataFin) AndAlso dataFine > range.CanoniDataFin Then
                result = True
                canoniSospesi = CalcolaMesi(dataInizio, range.CanoniDataFin)
            End If

            'Entrambe le date oltre le date periodo 
            If (dataInizio < range.CanoniDataIn) AndAlso (dataFine > range.CanoniDataFin) Then
                result = True
                canoniSospesi = range.NrCanoni
            End If
        End If
        Return result
    End Function
    Private Function IsBetweenIstat_Canoni(ByVal a As AllordCliAttivita, ByVal range As MyBloccoDate) As Boolean
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
    Private Function IsBetweenRipresi_Canoni(ByVal a As AllordCliAttivita, ByVal range As MyBloccoDate, ByRef canoniRipresi As Double) As Boolean
        '26/01/2022 : Cambiato comportamento, cerco sempre se ci sono canoni da rifatturare a non solo all'avverarsi della condizione di fatturazione canone
        'Veniva passato curDate
        Dim result As Boolean = False
        canoniRipresi = 0
        If a.DataRifatturazione >= range.CanoniDataIn AndAlso a.DataRifatturazione <= range.CanoniDataFin Then
            result = True
            canoniRipresi = CalcolaMesi(a.DataInizio, a.DataFine)
        End If
        Return result
    End Function
    Private Function IsBetweenRipresi(ByVal a As AllordCliAttivita, ByVal da As Date, ByVal al As Date, ByRef canoniRipresi As Double) As Boolean
        Dim result As Boolean = False
        canoniRipresi = 0
        If a.DataRifatturazione >= da AndAlso a.DataRifatturazione <= al Then
            result = True
            canoniRipresi = CalcolaMesi(a.DataInizio, a.DataFine)
        End If
        Return result
    End Function
    Private Function CalcolaMesi_Old(d1 As Date, d2 As Date) As Double
        'Una volta usavo questo
        'Non lavora bene con month perche' non prende 1/1-31/1
        'canoniSospesi = DateAndTime.DateDiff(DateInterval.Month, dataInizio, range.CanoniDataFin)
        Return Math.Round(DateAndTime.DateDiff(DateInterval.Day, d1, d2) / (365.2425 / 12), 0)
    End Function
    Private Function CalcolaMesi(d1 As Date, d2 As Date) As Double
        'Logica con date 1-8=0 // 9-23= 0,5 // 23-28(31) =1
        Dim monthNr As Double = DateAndTime.DateDiff(DateInterval.Month, d1, d2)

        'Controllo su giorno come da specifiche
        Select Case d2.Day
            Case 1 To 8
                monthNr += 0
            Case 9 To 23
                monthNr += 0.5
            Case 24 To 31
                monthNr += 1
        End Select
        'canoniSospesi = DateAndTime.DateDiff(DateInterval.Month, dataInizio, range.CanoniDataFin)
        Return monthNr
    End Function
End Module
