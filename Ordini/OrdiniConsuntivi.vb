﻿Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Imports EFMago.Linq
Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
Imports ALLSystemTools
'TODO: valutare implementazioni Fattura elettronica ( da ordine non ho modo, serve elaborazione successiva)
'Todo: Dichiarazione intento lettera W ( magari impostare un campo in anagrafica cliente/ordine) e aggiungerlo agli step di pre-invio( tipo quello dei dati canoni ) ma ne verrano fuori altri

Partial Module Ordini

    Private nrMonth As Integer
    Private dataFatt As Date
    Private bSingolaFiliale As Boolean
    Private filiale As String = String.Empty
    Private fromLogDate As Date
    Private toLogDate As Date
    Private bAskFilter As Boolean
    Private bRiassegna As Boolean


    ''' <summary>
    ''' Genero righe su Ordine Consuntivo tramite LINQ e OrdContext
    ''' </summary>
    ''' <returns></returns>
    Public Function GeneraRigheOrdineConsuntivo() As Boolean

#Region "Variabili Selezione"
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
        FLogin.lstStatoConnessione.Items.Add("Estrazione ordini Corrispondenti... ")
        FLogin.prgCopy.Value = 1
        FLogin.Refresh()
        Application.DoEvents()

        'test_LINQ.LinqStringQuery()

        Try
            OrdContext.Database.SetCommandTimeout(120)
#Region "Estrazioni dati con Query LINQ"
            'https://entityframework.net/why-first-query-slow
            'Tipizzare con (Of ) solo le Tabelle singole 1-1 che NON hanno 1-n / Collection
            'Interventi+Distinta con filtro ( partendo dagli interventi)
            Dim intFiltrati = (From interv In OrdContext.IntegraInterventi _
                            .Include(Function(ord) ord.SaleOrd) _
                            .Include(Function(dis) dis.AllordCliContrattoDistinta) _
                            .Where(Function(wdis) Not wdis.AllordCliContrattoDistinta.Servizio.Equals(TECNO_ALL1)))
            'Se mi fermassi qui' otterrei solo quelle con una distinta valida, se proseguo mi estrae correttamente tutto.
            'DEVO quindi controllare sempre l'esistenza del dati padre\figlio
            'Distinta (Articolo)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Of MaItems)(Function(dIt) dIt.MaItems)
            'Distinta (TipoRigaServizio)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                .ThenInclude(Of AlltipoRigaServizio)(Function(dTrs) dTrs.AlltipoRigaServizio)

            'Servizi aggiuntivi (viene caricata automaticamente)
            'intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
            '.ThenInclude(Function(dServ) dServ.AllordCliContrattoDistintaServAgg)
            'Servizi aggiuntivi (TipoRigaServizio)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(dServ) dServ.AllordCliContrattoDistintaServAgg) _
                                        .ThenInclude(Of AlltipoRigaServizio)(Function(dServTrs) dServTrs.AlltipoRigaServizio)
            'Servizi aggiuntivi (Articolo)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(dServ) dServ.AllordCliContrattoDistintaServAgg) _
                                        .ThenInclude(Of MaItems)(Function(dServIt) dServIt.MaItems)

            'Contratto (viene caricata automaticamente)
            'intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
            '.ThenInclude(Function(con) con.AllordCliContratto)
            'Contratto (Descrizioni fattura Contratto) 
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Function(conDesFt) conDesFt.AllordCliContrattoDescFatt)
            'Contratto (Articolo)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Of MaItems)(Function(conIt) conIt.MaItems)
            'Contratto (Tipo riga Servizio)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Of AlltipoRigaServizio)(Function(conTrs) conTrs.AlltipoRigaServizio)
            'Contratto (Ordine)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Function(ord) ord.SaleOrd)
            'Contratto (Ordine) (Dettaglio righe)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Function(ord) ord.SaleOrd) _
                                            .ThenInclude(Function(det) det.MaSaleOrdDetails)
            'Contratto (Ordine) (Descrizioni testa)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Function(ord) ord.SaleOrd) _
                                            .ThenInclude(Function(desT) desT.ALLordCliDescrizioni)
            'Contratto (Ordine) (Dati Accessori ordine)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Function(ord) ord.SaleOrd) _
                                            .ThenInclude(Function(acc) acc.ALLOrdCliAcc)
            'Attività (viene caricata automaticamente)
            'intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
            '.ThenInclude(Function(con) con.AllordCliContratto) _
            '.ThenInclude(Function(att) att.AllordCliAttivita) _
            'Attività (Codice attività)
            intFiltrati = intFiltrati.Include(Function(dis) dis.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(con) con.AllordCliContratto) _
                                        .ThenInclude(Function(att) att.AllordCliAttivita) _
                                            .ThenInclude(Of Allattivita)(Function(at) at.Allattivita)

            If bAskFilter Then
                'todo: rivedere filtri
                'intFiltrati = intFiltrati.Where(Function(oDate) oDate.InizioAllarme.Value.Date >= fromLogDate And oDate.InizioAllarme.Value.Date <= toLogDate)
                If bSingolaFiliale Then intFiltrati = intFiltrati.Where(Function(oFiliale) oFiliale.Filiale.Equals(filiale))
            Else
            End If
            Dim interventi = intFiltrati.ToList

            'Rigiro l'estrazione per avere le Distinte/Contratti
            'Dim distinte = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta).ToList
            'Rigiro per avere gli ordini
            'nuoo
            Dim ooo = intFiltrati.Select(Of MaSaleOrd)(Function(u) u.SaleOrd)
            Dim oooList = ooo.ToList
            'cvecchio che va
            Dim dummyOrdini = intFiltrati.Select(Of MaSaleOrd)(Function(u) u.AllordCliContrattoDistinta.AllordCliContratto.SaleOrd)
            Dim dummyOrdiniList = dummyOrdini.ToList
            'Applico il mio comparatore per avere una collection dei soli ordini DISTINCT
            'https://www.codeproject.com/Articles/94272/A-Generic-IEqualityComparer-for-Linq-Distinct
            Dim customComparer As IEqualityComparer(Of MaSaleOrd) = New PropertyComparer(Of MaSaleOrd)("SaleOrdId")
            Dim ordini As IEnumerable(Of MaSaleOrd) = dummyOrdiniList.Distinct(customComparer).ToList

            For Each o In ordini
                Debug.Print(o.InternalOrdNo)
            Next
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
            Dim efIntegraInterventi As New List(Of IntegraInterventi)

            If ordini.Any Then
                bIsSomething = True
                totInterventi = interventi.Count
                Debug.Print("Interventi Estratti : " & totInterventi.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi Estratti : " & totInterventi.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi Estratti : " & totInterventi.ToString)

                totOrdini = ordini.Count
                Debug.Print("Ordini Corrispondenti : " & totOrdini.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Ordini Corrispondenti : " & totOrdini.ToString)
                FLogin.lstStatoConnessione.Items.Add("Ordini Corrispondenti : " & totOrdini.ToString)
                EditTestoBarra("Ordini Corrispondenti : " & totOrdini.ToString)
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
                'Ciclo su tutti gli ordini corrispondenti
                For Each o In ordini
                    'C'e' la possibilità di estrarre interventi senza ordine
                    If o Is Nothing Then
                        errori.AppendLine("FATAlL ERROR: esistono interventi sanza corrispondenza")
                        Continue For
                    End If
                    AvanzaBarra()
                    Debug.Print("Ordine: " & o.InternalOrdNo)
                    debugging.AppendLine("Ordine: " & o.InternalOrdNo)
#Region "Inizializzazione"
                    'Resetto alcune cose 
                    Dim iNewRowsCount As Integer = 0
                    Dim isNewRows As Boolean = False    ' Indica se ci sono righe che vengono fatturate e quindi inserite nelle righe
                    Dim isUpdateRows As Boolean = False ' Indica se ci sono righe contratto che vengono aggiorate
                    'Inizializzo alcuni valori
                    Dim cOrd As New CurOrd(o)
                    Dim bWritedHeadDescription As Boolean = False
                    Dim bWritedRowDescription As Boolean = False
                    Dim iNrRigheNota As Integer = 0
                    Dim iNrRigheAValore As Integer = 0
#End Region
                    'STEP 1 : Ciclo le righe contratto
                    For Each c As AllordCliContratto In o.ALLordCliContratto
                        For Each d As AllordCliContrattoDistinta In c.AllordCliContrattoDistinta
                            For Each s As AllordCliContrattoDistintaServAgg In d.AllordCliContrattoDistintaServAgg
#Region "Calcolo Interventi"
                                Dim evento As String = TranscodificaEventoIntegra(s.Servizio)
                                Dim periodFranchigia As Periodo = s.Periodicita
                                Dim n = d.IntegraInterventi.Where(Function(w) w.TipoEvento.Equals(evento))
                                If n.Any Then
                                    s.AnnoIntervento = Year(toLogDate)
                                    Dim toDataMese As New Date(Year(toLogDate), Month(toLogDate), Date.DaysInMonth(Year(toLogDate), Month(toLogDate)))
                                    Dim fromDataMese As New Date(toDataMese.Year, toDataMese.Month, 1)
                                    s.NrInterventiMese = n.Where(Function(wp) wp.InizioAllarme >= fromDataMese And wp.InizioAllarme <= toDataMese).Sum(Function(q) q.Qta)
                                    s.NrInterventiPeriodo = n.Where(Function(wp) wp.InizioAllarme >= fromLogDate And wp.InizioAllarme <= toLogDate).Sum(Function(q) q.Qta)
                                    If periodFranchigia = Periodo.Nessuno Then
                                        s.NrInterventiFranchigia = 0
                                        s.NrInterventiOltreFranchigia = s.NrInterventiMese
                                    Else
                                        s.NrInterventiOltreFranchigia = s.NrInterventiPeriodo - s.Franchigia
                                        s.NrInterventiFranchigia = If(s.NrInterventiOltreFranchigia <= 0, s.NrInterventiMese, s.Franchigia)
                                    End If
                                    debugging.AppendLine(evento & " Int mese=" & s.NrInterventiMese.ToString & " Periodo(" & Periodo.GetName(GetType(Periodo), periodFranchigia) & " Int=" & s.NrInterventiPeriodo.ToString & " in Franc=" & s.Franchigia)
                                    'Aggiorno Flag Analizzato sull'intervento
                                    For Each intervento In n
                                        'intervento.Fatturare = "1"
                                    Next
                                End If
#End Region
                                If s.NrInterventiOltreFranchigia Is Nothing Then
                                    debugging.AppendLine(evento & " Escluso (senza record)")
                                ElseIf s.NrInterventiOltreFranchigia.GetValueOrDefault <= 0 Then
                                    'isDaEscludere  = true
                                    debugging.AppendLine(evento & " Escluso (In franchigia)")
                                Else
                                    'Si puo' Fatturare
                                    'isDaEscludere  = false
                                    debugging.AppendLine(evento & " in fattura=" & s.NrInterventiOltreFranchigia.ToString)
#Region "Variabili Correnti"
                                    Dim cOrdRow As New CurOrdRow(s) With {
                                            .Contropartita = If(String.IsNullOrWhiteSpace(s.MaItems.SaleOffset), sDefContropartita, s.MaItems.SaleOffset),
                                            .CodIva = If(String.IsNullOrWhiteSpace(c.CodiceIva), sDefCodIva, c.CodiceIva),
                                            .PercIva = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = .CodIva).Perc.Value, decPerc),
                                            .Parent = cOrd,
                                            .CanoniDataIn = fromLogDate,
                                            .CanoniDataFin = toLogDate,
                                            .PeriodoDataIn = fromLogDate,
                                            .PeriodoDataFin = toLogDate
                                        }
                                    If cOrdRow.PercIva = 0 Then cOrdRow.PercIva = dDefPercIva
                                    'TODO: non ricordo cosa sono  righe istat
                                    'Dim attDaRifatturare As New List(Of AllordCliAttivita)
                                    'Dim isISTAT As Boolean = False
                                    'Dim attIstat As New List(Of AllordCliAttivita)
#End Region
                                    'Se ok allora creo dettaglio
                                    'SU FOX FANNO
                                    'STEP 1 : PRIMA RIGA DI NOTA CON "INTERVENTI SUPPLEMENTARI"
                                    'STEP 2 : DESCRIZIONI FATTURA TESTA
                                    'STEP 3 : DESCRIZIONI FATTURA RIGA CONTRATTO/FATTURATIVA
                                    'STEP 4 : DETTAGLIA INTERVENTI UNO PER RIGA IN BASE A FLAG EC SI/NO
                                    'TODO: MIGLIORARE QUESTA COSA DELL' ESTRATTO CONTO INTERVENTI

                                    'todo ritarare i filtri 
                                    'If Not cOrdRow.PrecendementeCessato AndAlso ((cOrdRow.IsOk AndAlso Not cOrdRow.CanoneFuoriRangeDate) OrElse cOrdRow.DaRifatturare) AndAlso (r.Qty > 0 OrElse cOrdRow.QtaDaRifatturare > 0) Then
                                    If Not cOrdRow.PrecendementeCessato Then
                                        If o.MaSaleOrdDetails.Any AndAlso o.MaSaleOrdDetails.Count = 1 Then
                                            If CheckRigaBianca(o.MaSaleOrdDetails.First) Then
                                                cOrd.LastLine = 0
                                                cOrd.CurrentLastPosition = 0
                                            End If
                                        End If

                                        isNewRows = True
                                        If Not bWritedHeadDescription Then
#Region "STEP 1 : INTERVENTI SUPPLEMENTARI"
                                            bWritedHeadDescription = True
                                            iNewRowsCount += 1
                                            iNrRigheNota += 1
                                            Dim rdi As MaSaleOrdDetails = RigaDescrittiva(iNewRowsCount, cOrdRow, "INTERVENTI SUPPLEMENTARI")
                                            'Aggiungo la riga alla collection
                                            efMaSaleOrdDetails.Add(rdi)
                                            Debug.Print("### Interventi supplementari:(" & rdi.Position.ToString & ") ")
                                            debugging.AppendLine(" *DTi:" & rdi.Position.ToString)
#End Region
#Region "STEP 2 : DESCRIZIONI FATTURA TESTA"
                                            For Each dTesta In o.ALLordCliDescrizioni
                                                iNewRowsCount += 1
                                                iNrRigheNota += 1
                                                Dim rdt As MaSaleOrdDetails = RigaDescrittiva(iNewRowsCount, cOrdRow, dTesta.Descrizione)
                                                'Aggiungo la riga alla collection
                                                efMaSaleOrdDetails.Add(rdt)
                                                Debug.Print("### Riga descrittiva testa:(" & rdt.Position.ToString & ") " & rdt.Description)
                                                debugging.AppendLine(" *DTt:" & rdt.Position.ToString)
                                            Next
#End Region
                                        End If
#Region "STEP 3 : DESCRIZIONI RIGA CONTRATTO/FATTURATIVA "
                                        For Each dRiga In c.AllordCliContrattoDescFatt
                                            iNewRowsCount += 1
                                            iNrRigheNota += 1
                                            Dim rdr As MaSaleOrdDetails = RigaDescrittiva(iNewRowsCount, cOrdRow, dRiga.Descrizione)
                                            'Aggiungo la riga alla collection
                                            efMaSaleOrdDetails.Add(rdr)
                                            Debug.Print("### Riga descrittiva contratto:(" & rdr.Position.ToString & ") " & rdr.Description)
                                            debugging.AppendLine(" *DD:" & rdr.Position.ToString)
                                        Next
#End Region
#Region "STEP 4 : DETTAGLIO SERVIZIO"
                                        iNewRowsCount += 1
                                        iNrRigheAValore += 1
                                        Dim r As New MaSaleOrdDetails With {
                                            .Line = cOrd.LastLine + iNewRowsCount,
                                            .Position = cOrd.CurrentLastPosition + iNrRigheAValore,
                                            .SubId = cOrd.LastSubId + iNewRowsCount,
                                            .SaleOrdId = cOrd.SaleOrdId,
                                            .LineType = LineType.Servizio,
                                            .Item = cOrdRow.Item
                                            }
                                        Debug.Print("### R Ord:" & r.Position.ToString)
                                        debugging.AppendLine(" *R:" & r.Position.ToString)
                                        Dim periodoDataFine As String = cOrdRow.PeriodoDataFin.ToShortDateString
                                        Dim periodo As String = "Periodo dal " & cOrdRow.PeriodoDataIn.ToShortDateString & " al " & periodoDataFine
                                        'todo : vedere cosa scrivere qui
                                        r.Description = If(String.IsNullOrWhiteSpace(cOrdRow.Description), periodo, cOrdRow.Description & " " & periodo)
                                        r.UoM = cOrdRow.UoM
                                        r.PacksUoM = cOrdRow.UoM
                                        r.Qty = cOrdRow.NrInterventiOltreFranchigia
                                        r.UnitValue = Math.Round(cOrdRow.ValUnit, decTax)
                                        r.NetPrice = Math.Round(cOrdRow.ValUnit, decTax)
                                        r.TaxableAmount = Math.Round(r.Qty.GetValueOrDefault * cOrdRow.ValUnit, decTax)
                                        r.TaxCode = cOrdRow.CodIva
                                        r.TotalAmount = Math.Round((r.Qty.GetValueOrDefault * cOrdRow.ValUnit) * ((100 + cOrdRow.PercIva) / 100), decTax)
                                        r.ExpectedDeliveryDate = cOrdRow.DataPrevistaConsegna
                                        r.ConfirmedDeliveryDate = cOrdRow.DataConfermaConsegna
                                        'TODO: chiedere se data fine competenza in caso di Scadenza fissa e' fine periodo o la data scadenza fissa
                                        r.AllNrCanoni = r.Qty 'cOrdRow.NrCanoni '-> visto che potrebbe variare uso r.Qty
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

#End Region
                                    End If
                                End If
                            Next
                        Next
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
                Dim isDaEscludere As Boolean = False
#Region "??Controllo Esclusioni righe Contratto"
                'Dim sEx As String = "R:" & c.Line.ToString & " (" & c.TipoRigaServizio & "-" & c.Servizio & ")"
                'Debug.Print(sEx)
                'debugging.AppendLine(sEx)
                ''Blocco Esclusioni Canoni dovute ai filtri di periodo
                ''If c.AlltipoRigaServizio.TipologiaServizio = TipologiaServizio.Canone AndAlso Not p_Tutti AndAlso Not IsBewteenPeriodo(c, p_Periodi) Then
                ''    Debug.Print(" - [ESCLUSA] Fuori filtro periodo")
                ''    debugging.AppendLine(" - [ESCLUSA] Fuori filtro periodo")
                ''    Continue For
                ''End If
                'If c.AlltipoRigaServizio.TipologiaServizio = TipologiaServizio.Consuntivo Then
                '    Debug.Print(" - [ESCLUSA] Consuntivo")
                '    debugging.AppendLine(" - [ESCLUSA] Consuntivo")
                '    Continue For
                'End If
                'If CBool(c.Fatturato) Then
                '    Debug.Print(" - [ESCLUSA] Fatturata")
                '    debugging.AppendLine(" - [ESCLUSA] Fatturata")
                '    Continue For
                'End If
                'If c.DataDecorrenza = sDataNulla Then
                '    Debug.Print(" - [ESCLUSA] Decorrenza non Impostata")
                '    debugging.AppendLine(" - [ESCLUSA] Decorrenza non Impostata")
                '    Continue For
                'End If
                'If c.DataDecorrenza > dataFattA Then
                '    Debug.Print(" - [ESCLUSA] Decorrenza non raggiunta")
                '    debugging.AppendLine(" - [ESCLUSA] Decorrenza non raggiunta")
                '    Continue For
                'End If

                ''Da qua sotto non fa "Continue For"
                'If c.DataProssimaFatt >= dataFattDa And c.DataProssimaFatt <= dataFattA Then
                '    Debug.Print(" + [OK]")
                'Else
                '    Debug.Print(" - [ESCLUSA] Fuori filtro data")
                '    debugging.AppendLine(" - [ESCLUSA] Fuori filtro data")
                '    isDaEscludere = True
                '    '26/01/2022 Vanno comunque esaminate per cercare eventuali righe sospese da rifatturare
                '    'DEPRECATO il Continue For
                'End If
                'If c.DataProssimaFatt > dataFattA Then
                '    Debug.Print(" - [ESCLUSA] Prossima fattura non raggiunta")
                '    debugging.AppendLine(" - [ESCLUSA] Prossima fattura non raggiunta")
                '    isDaEscludere = True
                '    '26/01/2022 Vanno comunque esaminate per cercare eventuali righe sospese da rifatturare
                '    'DEPRECATO il Continue For
                'End If
#End Region

#Region "STEP 3 Attività"
                '                        For Each att In c.AllordCliAttivita
                '                            'Determina tipologia
                '                            Dim tipoAttivita As String = att.GetTipoAttivita
                '                            msgLog = " # Attiv:(" & att.Line.ToString & "-" & tipoAttivita & ") " & att.Attivita & " " & att.DataInizio.Value.ToShortDateString & " " & att.Nota
                '                            Debug.Print(msgLog)
                '                            debugging.AppendLine(msgLog)
                '#Region "STEP 3a Attività di Sospensione"
                '                            'STEP 3a: Attività di Sospensione 
                '                            '---  Esclusioni di Sospensione ---
                '                            If CBool(att.Allattivita.Sospensione) Then
                '                                'Fatturata
                '                                If CBool(att.Fatturata) Then
                '                                    Debug.Print("  - [Fatturata]")
                '                                    debugging.AppendLine("  - [Fatturata]")
                '                                    Continue For
                '                                End If
                '                                'Mesi sospesi ( solo se nel periodo)
                '                                Dim dCanoniSospesi As Double
                '                                If IsBetweenSospensione(att.DataInizio, att.DataFine, cOrdRow, dCanoniSospesi) Then
                '                                    msgLog = "  - [Sospensione]: Mesi " & dCanoniSospesi.ToString & " dal " & att.DataInizio.Value.ToShortDateString & " al " & att.DataFine.Value.ToShortDateString
                '                                    Debug.Print(msgLog)
                '                                    debugging.AppendLine(msgLog)
                '                                End If
                '                                'Mesi da rifatturare
                '                                Dim dCanoniRipresi As Double
                '                                'If CBool(att.DaFatturare) AndAlso IsBetweenRipresi(att, dataFattDa, dataFattA, dCanoniRipresi) Then
                '                                '    cOrdRow.DaRifatturare = True
                '                                '    If dCanoniRipresi > 0 Then
                '                                '        'Setto il valore nella proprietà  Shadow
                '                                '        att.CanoniRipresi = dCanoniRipresi
                '                                '        cOrdRow.QtaDaRifatturare += dCanoniRipresi
                '                                '        attDaRifatturare.Add(att)
                '                                '        cOrdRow.IsOk = True
                '                                '        msgLog = "  - [Ripresa]: " & att.CanoniRipresi.ToString & " mesi il " & att.DataRifatturazione.Value.ToShortDateString
                '                                '        Debug.Print(msgLog)
                '                                '        debugging.AppendLine(msgLog)
                '                                '        'Segno la riga come Fatturata
                '                                '        att.Fatturata = "1"
                '                                '        att.Tbmodified = Now
                '                                '        att.TbmodifiedId = sLoginId
                '                                '        efAllordCliAttivita.Add(att)
                '                                '    End If
                '                                'End If
                '                            End If
                '#End Region
                '                            'STEP 3b: Attività di Annullamento 
                '                            '---  Esclusioni di Annullamento ---
                '                            If Not cOrdRow.CanoneFuoriRangeDate AndAlso CBool(att.Allattivita.Annullamento) Then
                '                                If cOrdRow.HaAnnullatoDaAttivita Then
                '                                    'Non dorvebbe succedere perche' su Mago ho introdotto un controllo
                '                                    errori.AppendLine("Ordine " & cOrd.OrdNo & " Servizio " & cOrdRow.Item & ": Annullato da piu' attività. Verrà considerata la prima.")
                '                                Else
                '                                    cOrdRow.AnnullaDaAttività(att.DataInizio)
                '                                End If
                '                            End If

                '                            'STEP 3c: Attività di Istat 
                '                            If CBool(att.Allattivita.Istat) Then
                '                                '--- Controllo Esclusioni di ISTAT---

                '                                'Fatturata
                '                                If CBool(att.Fatturata) Then
                '                                    Debug.Print("  - [Fatturata]")
                '                                    debugging.AppendLine("  - [Fatturata]")
                '                                    Continue For
                '                                End If
                '                                'E' nel range
                '                                'If CBool(att.DaFatturare) AndAlso IsBetweenIstat(att, dataFattDa, dataFattA) Then
                '                                '    isISTAT = True
                '                                '    cOrdRow.IsOk = True
                '                                '    msgLog = "  - [ISTAT]: il " & att.DataRifatturazione.ToString
                '                                '    Debug.Print(msgLog)
                '                                '    debugging.AppendLine(msgLog)
                '                                '    'Segno la riga come Fatturata
                '                                '    att.Fatturata = "1"
                '                                '    att.Tbmodified = Now
                '                                '    att.TbmodifiedId = sLoginId
                '                                '    attIstat.Add(att) ' Non posso ancora metterla nell' efAllordCliAttivita perche' potrebbe essere tutto sospeso)
                '                                'End If
                '                            End If

                '                        Next
#End Region
                'STEP 4a : Controllo Scadenza Fissa ( se CanoniDataFin >= data Scadenza Fissa su Ordine)
                'If cOrd.HaScadenzaFissa AndAlso Not cOrdRow.CanoneFuoriRangeDate AndAlso cOrdRow.CanoniDataFin >= cOrd.DataScadenzaFissa Then
                '    cOrdRow.HaScadenzaFissa = True
                '    cOrdRow.DataScadenzaFissa = cOrd.DataScadenzaFissa
                'End If

                ''STEP 4b : Controllo Data Cessazione ( se CanoniDataFin >= data Cessazione su Ordine)
                'If cOrd.HaDataCessazione AndAlso cOrdRow.CanoniDataFin >= cOrd.DataCessazione Then
                '    cOrdRow.HaDataCessazione = True
                '    cOrdRow.DataCessazione = cOrd.DataCessazione
                'End If

                'STEP 5:
                'If Not cOrdRow.CanoneFuoriRangeDate AndAlso (cOrdRow.HaScadenzaFissa OrElse cOrdRow.HaDataCessazione OrElse cOrdRow.HaAnnullatoDaAttivita) Then
                '    Dim msg As String = ""
                '    Dim bEsci As Boolean = False
                '    '19/01/2023: Con Laura definiamo che la priorità e' Attività -> Scadenza Fissa -> Data Cessazione

                '    'Priorità 1: Attività
                '    If Not bEsci AndAlso cOrdRow.HaAnnullatoDaAttivita Then
                '        bEsci = True
                '        If IsBetweenAnnullamento_Attivita(cOrdRow, msg) Then
                '            Debug.Print(msg)
                '            debugging.AppendLine(msg)
                '            cOrdRow.PeriodoDataFin = cOrdRow.DataCessazioneDaAttivita

                '        End If
                '    End If

                '    'Priorità 2: Scadenza Fissa
                '    If Not bEsci AndAlso cOrdRow.HaScadenzaFissa Then
                '        bEsci = True
                '        If IsBetweenAnnullamento_ScadenzaFissa(cOrdRow, msg) Then
                '            debugging.AppendLine(msg)
                '            cOrdRow.PeriodoDataFin = cOrdRow.DataScadenzaFissa
                '        End If
                '        'Scrivo Data e Motivo Cessazione
                '        If o.ALLOrdCliAcc.DataCessazione = sDataNulla Then
                '            o.ALLOrdCliAcc.DataCessazione = cOrdRow.DataScadenzaFissa
                '            o.ALLOrdCliAcc.MotivoCessazione = "[AUTO] Scadenza Fissa"
                '            o.ALLOrdCliAcc.Tbmodified = Now
                '            o.ALLOrdCliAcc.TbmodifiedId = sLoginId
                '            debugging.AppendLine("Ordine: " & cOrdRow.Parent.OrdNo & " Impostata cessazione: " & cOrdRow.DataScadenzaFisdis.ToShortDateString)
                '            efAllordCliAcc.Add(o.ALLOrdCliAcc)
                '        End If
                '    End If

                '    'Priorità 3: Cessazione
                '    If Not bEsci AndAlso cOrdRow.HaDataCessazione Then
                '        bEsci = True
                '        If IsBetweenAnnullamento_Cessazione(cOrdRow, msg) Then
                '            debugging.AppendLine(msg)
                '            cOrdRow.PeriodoDataFin = cOrdRow.DataCessazione
                '            'Scrivo Motivo Cessazione
                '            If String.IsNullOrWhiteSpace(o.ALLOrdCliAcc.MotivoCessazione) Then
                '                'o.ALLOrdCliAcc.DataCessazione = cOrdRow.DataCessazione
                '                o.ALLOrdCliAcc.MotivoCessazione = "[AUTO] Data Cessazione"
                '                o.ALLOrdCliAcc.Tbmodified = Now
                '                o.ALLOrdCliAcc.TbmodifiedId = sLoginId
                '                debugging.AppendLine("Ordine: " & cOrdRow.Parent.OrdNo & " Impostata cessazione: " & cOrdRow.DataCessazione.ToShortDateString)
                '                efAllordCliAcc.Add(o.ALLOrdCliAcc)
                '            End If
                '        End If
                '    End If
                'End If


#Region "Righe ISTAT"
                'For Each aIst In attIstat
                '    iNewRowsCount += 1
                '    iNrRigheNota += 1
                '    'bScrittoDescrizioni = True
                '    Dim rd As New MaSaleOrdDetails With {
                '        .Line = cOrd.LastLine + iNewRowsCount,
                '        .Position = 0,
                '        .SubId = cOrd.LastSubId + iNewRowsCount,
                '        .SaleOrdId = cOrd.SaleOrdId,
                '        .LineType = LineType.Nota,
                '        .Description = aIst.TestoFattura,
                '        .InEi = "1",
                '        .ExpectedDeliveryDate = cOrdRow.DataPrevistaConsegna,
                '        .ConfirmedDeliveryDate = cOrdRow.DataConfermaConsegna, ' sDataNulla
                '        .InternalOrdNo = cOrd.OrdNo,
                '        .Customer = cOrd.Cliente,
                '        .OrderDate = cOrd.OrdDate,
                '        .NoOfPacks = 0,
                '        .ProductionPlanLine = 0,
                '        .ExternalLineReference = 0,
                '        .Tbcreated = Now,
                '        .Tbmodified = Now,
                '        .TbcreatedId = sLoginId,
                '        .TbmodifiedId = sLoginId,
                '        .Item = String.Empty,
                '        .UoM = String.Empty,
                '        .Qty = 0,
                '        .UnitValue = 0,
                '        .TaxableAmount = 0,
                '        .TotalAmount = 0,
                '        .PacksUoM = String.Empty,
                '        .TaxCode = String.Empty,
                '        .Job = String.Empty,
                '        .CostCenter = String.Empty,
                '        .Offset = String.Empty,
                '        .Notes = String.Empty,
                '        .NetPrice = 0,
                '        .ContractCode = String.Empty,
                '        .ProjectCode = String.Empty,
                '        .AllNrCanoni = 0,
                '        .AllCanoniDataI = sDataNulla,
                '        .AllCanoniDataF = sDataNulla,
                '        .Invoiced = "0"
                '    }
                '    'Aggiungo la riga alla collection
                '    efMaSaleOrdDetails.Add(rd)
                '    'Aggiungo l'attività alla collection ( per aggionare il flag Fatturata)
                '    efAllordCliAttivita.Add(aIst)

                '    msgLog = "### Riga Istat:(" & rd.Position.ToString & ") " & aIst.Attivita
                '    Debug.Print(msgLog)
                '    debugging.AppendLine(" *I:" & rd.Position.ToString & " " & aIst.Attivita)

                'Next
#End Region
            End If
#Region "Aggiorno date prossima Fatturazione"
            'If Not cOrdRow.CanoneFuoriRangeDate AndAlso (cOrdRow.IsOk OrElse cOrdRow.DaRifatturare OrElse cOrdRow.SospesoDaAttivita) AndAlso Not cOrdRow.PrecendementeCessato Then
            '    'If cOrdRow.DataProssimaFattura < dataFattA Then avvisi.AppendLine("Ordine " & cOrd.OrdNo & " Servizio " & cOrdRow.Item & " con data prossima fatturazione antecedente alla data di fine estrazione !")
            '    c.DataProssimaFatt = cOrdRow.DataProssimaFattura
            '    c.DataFineElaborazione = Now
            '    c.Tbmodified = Now
            '    c.TbmodifiedId = sLoginId
            '    efAllordCliContratto.Add(c)
            '    isUpdateRows = True
            'End If
#End Region
            Dim alt As Boolean = False
#Region "Controllo se tutti gli interventi sono stati analizzati"
            Dim intNotOk = (From interv In OrdContext.IntegraInterventi _
                            .Where(Function(wok) wok.Fatturare <> "1")).ToList
            If intNotOk.Count <> 0 Then
                someTrouble = True
                msgLog = "Interventi non analizzati correttamente : " & intNotOk.Count.ToString
                errori.AppendLine(msgLog)
                msgLog += Environment.NewLine & "Si desidera continuare?"
                My.Application.Log.DefaultFileLogWriter.WriteLine(msgLog)
                FLogin.lstStatoConnessione.Items.Add(msgLog)

                If DialogResult.No = MessageBox.Show(msgLog, GetCurrentMethod.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) Then
                    alt = True
                End If
            End If
#End Region

#Region "Bulk Insert"
            'todo : forse ci sono da togliere dei bulk insert
            msgLog = "Ordini con righe Contratto valide : " & totOrdiniConNuoveRighe.ToString
            My.Application.Log.DefaultFileLogWriter.WriteLine(msgLog)
            FLogin.lstStatoConnessione.Items.Add(msgLog)
            msgLog = "Ordini con righe Contratto con data prossima fatturazione da adeguare : " & totOrdiniConRigheAggiornate.ToString
            My.Application.Log.DefaultFileLogWriter.WriteLine(msgLog)
            FLogin.lstStatoConnessione.Items.Add(msgLog)

            If Not alt AndAlso (totOrdiniConNuoveRighe > 0 OrElse totOrdiniConRigheAggiornate > 0) Then
                'Parametri
                'https://github.com/borisdj/EFCore.BulkExtensions

                Using bulkTrans = OrdContext.Database.BeginTransaction
                    Dim iStep As Integer
                    Try
                        OrdContext.Database.ExecuteSqlRaw("DBCC TRACEON(610)")
                        Dim tablesToUpdate As New Dictionary(Of String, IEnumerable(Of Object)) From {
                            {"MaSaleOrd|U|teste ordini", efMaSaleOrd},
                            {"MaSaleOrdDetails|IU|righe ordini", efMaSaleOrdDetails},
                            {"MaSaleOrdSummary|IU|totali ordini", efMaSaleOrdSummary},
                            {"AllordCliAcc|IU|dati accessori ordini", efAllordCliAcc},
                            {"AllordCliAttivita|U|righe attività", efAllordCliAttivita},
                            {"AllordCliContratto|U|righe contratto", efAllordCliContratto},
                            {"AllordCliContrattoDistinta|U|righe distinta", efAllordCliContrattoDistinta},
                            {"AllordCliContrattoDistintaServAgg|U|righe servizi aggiuntivi", efAllordCliContrattoDistintaServAgg},
                            {"IntegraInterventi|U|interventi", efIntegraInterventi}
                        }

                        For Each kvp As KeyValuePair(Of String, IEnumerable(Of Object)) In tablesToUpdate
                            Dim keys As String = kvp.Key
                            Dim entityList As List(Of Object) = kvp.Value.ToList

                            iStep += 1
                            EseguiBulkUpdate(OrdContext, entityList, keys, bulkMessage)
                        Next

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


        Catch ex As Exception
            Debug.Print(ex.Message)
            errori.AppendLine("[Procedura] Messaggio:" & ex.Message)
            errori.AppendLine("[Procedura] Stack:" & ex.StackTrace)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

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
        My.Application.Log.DefaultFileLogWriter.WriteLine("Controllo Flusso")

#Region "Variabili Selezione"
        'todo : gestire il filtr su Associato = 0

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
                If ff.RadOnlyCheck.Checked OrElse ff.RadCheckAndFatt.Checked Then
                    bRiassegna = ff.ChkRiassegna.Checked
                End If
                Dim filtri As New StringBuilder()
                filtri.AppendLine(" --- Filtri ---")
                filtri.AppendLine("Dal " & fromLogDate.ToShortDateString & " al " & toLogDate.ToShortDateString)
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & filtri.ToString)
            ElseIf result = DialogResult.Cancel Then
                Return False
                Exit Function
            End If
        End Using

        Dim someTrouble As Boolean = False
        Dim errori As New StringBuilder()
        Dim contrattoErrorList As New List(Of String)
        Dim eventoErrorList As New List(Of String)
        Dim fatalContrattoErrorList As New List(Of String)
        Dim fatalEventoErrorList As New List(Of String)
        Dim totInterventi As Integer
        Dim contrattoErrorCnt As Integer
        Dim eventoErrorCnt As Integer
        Dim fatalContrattoErrorCnt As Integer
        Dim fatalEventoErrorCnt As Integer

#End Region

        Try
#Region "Estrazioni dati con Query LINQ"
            'https://entityframework.net/why-first-query-slow
            'Tipizzare con (Of ) solo le Tabelle singole 1-1 che NON hanno 1-n / Collection
            'OrdContext.Database.SetCommandTimeout(120)
            Dim allDistinte = (From o In OrdContext.AllordCliContrattoDistinta _
                         .Include(Function(sa) sa.AllordCliContrattoDistintaServAgg) _
                         .Where(Function(wsa) Not wsa.Servizio.Equals(TECNO_ALL1)) _
                         .Include(Function(o) o.AllordCliContratto) _
                            .ThenInclude(Function(ord) ord.SaleOrd) _
                                .ThenInclude(Function(info) info.ALLOrdCliAcc)) _
                                .Select(Function(x) New MiniDistinta With {.CodIntegra = x.CodIntegra,
                                                                   .DataCessazione = x.AllordCliContratto.SaleOrd.ALLOrdCliAcc.DataCessazione,
                                                                   .DataScadenzaFissa = x.AllordCliContratto.SaleOrd.ALLOrdCliAcc.DataScadenzaFissa,
                                                                   .AllordCliContrattoDistintaServAgg = x.AllordCliContrattoDistintaServAgg})


            Dim allInterventi As List(Of IntegraInterventi) = (From o In OrdContext.IntegraInterventi).ToList
            If bAskFilter Then
                If Not bRiassegna Then allInterventi = allInterventi.Where(Function(oAss) oAss.MAssociato.Equals("0"))
                allInterventi = allInterventi.Where(Function(oDate) oDate.InizioAllarme.Value.Date >= fromLogDate AndAlso oDate.InizioAllarme.Value.Date <= toLogDate)
                If bSingolaFiliale Then allInterventi = allInterventi.Where(Function(oFiliale) oFiliale.Filiale.Equals(filiale))
            Else
            End If
#End Region
            If allInterventi.Any Then
                Dim updIntList As New List(Of IntegraInterventi)
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
                    Debug.Print("ID Intervento: " & i.ID)
                    Dim allDistinteFiltered = allDistinte.Where(Function(x) x.CodIntegra.Equals(i.Contratto))
                    Dim allDistintexxx = allDistinte.Where(Function(d) d.DataCessazione.Equals(Nothing) _
                        OrElse d.DataCessazione.Equals(dataNulla) _
                        OrElse d.DataCessazione >= toLogDate)
                    Dim allDistinteyyy = allDistinte.Where(Function(d) d.DataScadenzaFissa.Equals(Nothing) _
                        OrElse d.DataScadenzaFissa.Equals(dataNulla) _
                        OrElse d.DataScadenzaFissa >= toLogDate)
                    If allDistinteFiltered.Any Then
                        If allDistinteFiltered.Count = 1 Then
                            Dim distinta = allDistinteFiltered.Single
                            Dim eventoMago As String = TrascodificaServizioAggiuntivo(i.TipoEvento)
                            Dim allEventi = distinta.AllordCliContrattoDistintaServAgg.Where(Function(y) y.Servizio.Equals(eventoMago))
                            'Blocco Eventi
                            If allEventi.Any Then
                                If allEventi.Count = 1 Then
                                    Dim row As AllordCliContrattoDistintaServAgg = allEventi.Single()
                                    'Aggiorno Flag
                                    i.MAssociato = "1"
                                    i.MIdOrdCli = row.IdOrdCli
                                    i.MLineaContratto = row.RifRifLinea
                                    i.MLineaDistinta = row.RifLinea

                                    Exit For

                                    Continue For
                                Else
                                    fatalEventoErrorCnt += 1
                                    Dim errorString As String = $"Contratto: {i.Contratto} Evento: {i.TipoEvento}"
                                    If Not fatalEventoErrorList.Contains(errorString) Then
                                        fatalEventoErrorList.Add(errorString)
                                    End If
                                    Continue For
                                End If
                            Else
                                eventoErrorCnt += 1
                                Dim errorString As String = $"Contratto: {i.Contratto} Evento: {i.TipoEvento}"
                                If Not eventoErrorList.Contains(errorString) Then
                                    eventoErrorList.Add(errorString)
                                End If
                                Continue For
                            End If

                        Else
                            fatalContrattoErrorCnt += 1
                            Dim errorString As String = i.Contratto
                            If Not fatalContrattoErrorList.Contains(errorString) Then
                                fatalContrattoErrorList.Add(errorString)
                            End If
                            Continue For
                        End If
                    Else
                        eventoErrorCnt += 1
                        Dim errorString As String = i.Contratto
                        If Not contrattoErrorList.Contains(errorString) Then
                            contrattoErrorList.Add(errorString)
                        End If
                        Continue For
                    End If
                Next
                'Scrivo le modifiche sulla tabella IntegraInterventi
#Region "Salvataggio"
                Using bulkTrans = OrdContext.Database.BeginTransaction
                    Dim someBulkTrouble As Boolean = False
                    Dim bulkMessage As New StringBuilder()
                    Dim msgLog As String
                    Try
                        OrdContext.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                        EditTestoBarra("Salvataggio: Aggiornamento interventi")
                        Dim t = allInterventi.Count
                        Dim iIntUpd As Integer = OrdContext.SaveChanges()
                        Debug.Print("IntegraInterventi Agg:" & iIntUpd.ToString)
                        bulkMessage.AppendLine("IntegraInterventi Agg:" & iIntUpd.ToString)

                        If someBulkTrouble Then
                            bulkTrans.Rollback()
                            bulkMessage.AppendLine("[Aggiornamento IntegraInterventi] Sono stati riscontrati degli errori. Eseguita rollback")
                        Else
                            bulkTrans.Commit()
                            FLogin.lstStatoConnessione.Items.Add(" --- Inserimento Dati ---")
                            msgLog = "Interventi Aggiornati : " & iIntUpd.ToString
                            Debug.Print(msgLog)
                            bulkMessage.AppendLine("[RIASSUNTO] " & msgLog)
                            FLogin.lstStatoConnessione.Items.Add(msgLog)
                        End If
                        OrdContext.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

                    Catch ex As Exception
                        someBulkTrouble = True
                        Dim entries = OrdContext.ChangeTracker.Entries.Where(Function(x) x.State <> EntityState.Unchanged)
                        For Each entry In entries
                            For Each prop In entry.CurrentValues.Properties
                                Dim val = prop.PropertyInfo.GetValue(entry.Entity)
                                Console.WriteLine($" {prop.PropertyInfo } {prop.ToString()} ~ ({val?.ToString().Length})({val})")
                            Next
                        Next
                        Debug.Print(ex.Message)
                        FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori")
                        bulkMessage.AppendLine("[Aggiornamento IntegraInterventi] - Sono stati riscontrati degli errori. (Vedere sezione Errori)")
                        errori.AppendLine("[Aggiornamento IntegraInterventi] Messaggio:" & ex.Message)
                        errori.AppendLine("[Aggiornamento IntegraInterventi] Stack:" & ex.StackTrace)

                        Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                        mb.ShowDialog()
                    End Try
                End Using
#End Region

            End If

        Catch ex As Exception
            Debug.Print(ex.Message)
            errori.AppendLine("[Procedura] Messaggio:" & ex.Message)
            errori.AppendLine("[Procedura] Stack:" & ex.StackTrace)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        My.Application.Log.DefaultFileLogWriter.WriteLine("Controllo terminato" & Environment.NewLine)
        FLogin.lstStatoConnessione.Items.Add("Controllo terminato")

        'Scrivo i LOG
#Region "Logs"
        If contrattoErrorCnt > 0 OrElse eventoErrorCnt > 0 OrElse fatalContrattoErrorCnt > 0 OrElse fatalEventoErrorCnt > 0 Then
            If fatalContrattoErrorCnt > 0 Then
                fatalContrattoErrorList.Sort()
                errori.AppendLine(" --- ERRORI GRAVI ---")
                errori.AppendLine("Codice Contratto duplicato, controllare su Mago l'unicità del CodIntegra")
                For Each e In fatalContrattoErrorList
                    errori.AppendLine(e)
                Next
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi con Contratto duplicato : " & fatalContrattoErrorCnt.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi con Contratto duplicato : " & fatalContrattoErrorCnt.ToString)
            End If
            If fatalEventoErrorCnt > 0 Then
                fatalEventoErrorList.Sort()
                errori.AppendLine(" --- ERRORI GRAVI ---")
                errori.AppendLine("Codice Evento duplicato, controllare su Mago l'unicità dell' Evento")
                For Each e In fatalEventoErrorList
                    errori.AppendLine(e)
                Next
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi con Evento duplicato : " & fatalContrattoErrorCnt.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi con Evento duplicato : " & fatalContrattoErrorCnt.ToString)
            End If
            If contrattoErrorCnt > 0 Then
                contrattoErrorList.Sort()
                errori.AppendLine(" --- ERRORI MEDI ---")
                errori.AppendLine("Codice Contratto assente, inserirlo in Mago")
                For Each e In contrattoErrorList
                    errori.AppendLine("Contratto assente: " & e)
                Next
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi con Contratto assente : " & fatalContrattoErrorCnt.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi con Contratto assente : " & fatalContrattoErrorCnt.ToString)
            End If
            If eventoErrorCnt > 0 Then
                eventoErrorList.Sort()
                errori.AppendLine(" --- ERRORI MEDI ---")
                errori.AppendLine("Codice Evento assente, inserirlo in Mago")
                For Each e In contrattoErrorList
                    errori.AppendLine(e)
                Next
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi con Evento assente : " & fatalContrattoErrorCnt.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi con Evento assente : " & fatalContrattoErrorCnt.ToString)
            End If
            My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Errori ---" & Environment.NewLine & errori.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
            someTrouble = True
        End If
#End Region
        Application.DoEvents()
        Return Not someTrouble

    End Function

    Private Function TrascodificaServizioAggiuntivo(value As String) As String
        'todo trasformare in dictionary
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
    Private Sub EseguiBulkUpdate(Of T As Class)(ByVal context As OrdiniContext, ByVal entityList As List(Of T), ByVal keys As String, log As StringBuilder)

        Dim operation As String() = keys.Split("|")
        Dim tablename As String = operation(0)
        Dim whatTodo As String = operation(1)
        Dim stepDescription As String = operation(2)
        Select Case whatTodo
            Case "I"
                stepDescription = "Inserimento " & stepDescription
            Case "U"
                stepDescription = "Aggiornamento " & stepDescription
            Case "IU"
                stepDescription = "Inserimento/Aggiornamento " & stepDescription
        End Select
        EditTestoBarra($"Salvataggio: {stepDescription}  {tablename}")
        If entityList.Any() Then
            Dim c As Integer = entityList.Count
            Dim bulkConfig As New BulkConfig With {
        .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
        .BulkCopyTimeout = 0,
        .CalculateStats = True,
        .BatchSize = If(c < 5000, 0, c / 10),
        .NotifyAfter = c / 10
            }
            Select Case whatTodo
                Case "I"
                    context.BulkInsert(entityList, bulkConfig, Function(d) d)
                Case "U"
                    context.BulkUpdate(entityList, bulkConfig, Function(d) d)
                Case "IU"
                    context.BulkInsertOrUpdate(entityList, bulkConfig, Function(d) d)
            End Select
            Debug.Print($"{tablename} Ins:{bulkConfig.StatsInfo.StatsNumberInserted} Agg:{bulkConfig.StatsInfo.StatsNumberUpdated}")
            log.AppendLine($"{tablename} Ins:{bulkConfig.StatsInfo.StatsNumberInserted} Agg:{bulkConfig.StatsInfo.StatsNumberUpdated}")
        End If
        Application.DoEvents()
    End Sub
    Private Class MiniDistinta
        Property CodIntegra As String
        Property DataCessazione As Date
        Property DataScadenzaFissa As Date
        Property AllordCliContrattoDistintaServAgg As ICollection(Of AllordCliContrattoDistintaServAgg)
        Property SaleDocId As Integer
        Property LineaDistinta As Short
        Property LineaContratto As Short
    End Class
End Module

Module test_LINQ
    Public Sub LinqStringQuery()
        'https://entityframework.net/why-first-query-slow
        'Tipizzare con (Of ) solo le Tabelle singole 1-1 che NON hanno 1-n / Collection
        Dim l = (From o In OrdContext.IntegraInterventi)
        If 1 = 2 Then
            l = l.Where(Function(oDate) oDate.DataInsert.Value.Date >= "20230101" AndAlso oDate.DataInsert.Value.Date <= "20231231")
            If 2 = 2 Then l = l.Where(Function(oFiliale) oFiliale.Filiale.Equals("filialE"))
        End If
        Dim allInterventi = l.ToList

        Dim dist_con_join = (From dis In OrdContext.AllordCliContrattoDistinta _
                                         .Where(Function(w) Not w.Servizio.Equals(TECNO_ALL1)) _
                                        .Include(Function(sa) sa.AllordCliContrattoDistintaServAgg)
                             Join i In OrdContext.IntegraInterventi On dis.CodIntegra Equals i.Contratto
                             Select dis, i)

        'Solo gli Interventi con le loro distinte
        Dim soloInterventi = (From o In OrdContext.IntegraInterventi _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(i) i.AllordCliContrattoDistintaServAgg) _
                                .Where(Function(wsa) Not wsa.AllordCliContrattoDistinta.Servizio.Equals(TECNO_ALL1)))
        Dim allInt = soloInterventi.ToList
        Dim allDistConjoin = dist_con_join.ToList



        'ESCLUDO DISTINTE Tecnologia Allsystem1
        'Solo le Distinte con Interventi
        Dim distWithInt = (From o In OrdContext.AllordCliContrattoDistinta _
                                .Include(Function(sa) sa.AllordCliContrattoDistintaServAgg) _
                                .Where(Function(wsa) Not wsa.Servizio.Equals(TECNO_ALL1)) _
                                .Where(Function(n) n.IntegraInterventi.Count > 0)
                                )
        Dim allDist = distWithInt.ToList  '-> QUESTA LAVORA BENE

        'Interventi+Distinta con filtro ( partendo dagli iterventi)
        Dim intFiltrati = (From o In OrdContext.IntegraInterventi _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(i) i.AllordCliContrattoDistintaServAgg) _
                                .Where(Function(wsa) Not wsa.AllordCliContrattoDistinta.Servizio.Equals(TECNO_ALL1)))
        Dim allIntFiltrati = intFiltrati.ToList
        'Anche questa lavora bene
        Dim alldistinte = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta)
        Dim ll = alldistinte.ToList

        If 1 = 2 Then
            intFiltrati = intFiltrati.Where(Function(oDate) oDate.InizioAllarme.Value.Date >= "20230101" And oDate.InizioAllarme.Value.Date <= "20231231")
            If 2 = 2 Then distWithInt = intFiltrati.Where(Function(oFiliale) oFiliale.Filiale.Equals("filialE"))
        Else
            'distWithInt = distWithInt.Where(Function(x) x.IntegraInterventi.Count > 0 AndAlso x.IntegraInterventi.Any(Function(oDate) oDate.Contratto.Equals("935/PR")))
            '.Include(Function(inte) inte.IntegraInterventi) _
            'distWithInt = distWithInt.Where(Function(n) n.IntegraInterventi.Count > 0)
            'intFiltrati = intFiltrati.Where(Function(oDate) oDate.Contratto.Equals("935/PR"))
        End If
        'Rigiro l'estrazione per avere le distinte
        Dim aalldistinte = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta)
        Dim aall = alldistinte.ToList
        'Dim allordini = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta.IdOrdCli).Distinct().ToList

        Dim d = (From o In OrdContext.AllordCliContrattoDistinta.Include(Function(sa) sa.AllordCliContrattoDistintaServAgg))
    End Sub


End Module