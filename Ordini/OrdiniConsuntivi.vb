Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Imports EFMago.Linq
Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
Imports ALLSystemTools
Imports ALLSystemTools.SqlTools
'TODO: valutare implementazioni Fattura elettronica ( da ordine non ho modo, serve elaborazione successiva)

Partial Module Ordini
    Private FattureCntx As FattureContext
    Private Const regIvaPosticipate As String = "V2"
    ''' <summary>
    ''' Genero righe su fattura tramite LINQ e FattureCntx
    ''' </summary>
    ''' <returns></returns>
    Public Function GeneraFattureConsuntivo(filtri As FiltriOrdiniConsuntivo) As Boolean

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
        Dim totFatture As Integer
#End Region
        FLogin.lstStatoConnessione.Items.Add("Estrazione ordini Corrispondenti... ")
        FLogin.prgCopy.Value = 1
        FLogin.Refresh()
        Application.DoEvents()

        'test_LINQ.LinqStringQuery()

        Try
            OrdiniCntx.Database.SetCommandTimeout(120)
#Region "Estrazioni dati Ordine con Query LINQ"
            'https://entityframework.net/why-first-query-slow
            EditTestoBarra("Precaricamento Tabelle ")
            OrdiniCntx.IntegraInterventi.Load()
            PrecaricaTabelleOrdini()
            ConnettiContestoFatture()
            PrecaricaTabelleClienti()
            'NON serve precaricare i dati dato che vanno create ex-novo
            'PrecaricaTabelleFatture()
            'PrecaricaTabelleFatturaElettronica()

            'Usato solo per Test
            'Dim s = (From o In FattureCntx.MaSaleDoc)
            'Dim iAllDoc As IQueryable(Of MaSaleDoc) = s

            Dim intFiltrati = (From interv In OrdiniCntx.IntegraInterventi _
                           .Where(Function(wdis) Not wdis.AllordCliContrattoDistinta.Servizio.Equals(TECNO_ALL1)))

            If filtri.AskFilter Then
                'todo: rivedere filtri
                'intFiltrati = intFiltrati.Where(Function(oDate) oDate.InizioAllarme.Value.Date >= fromLogDate And oDate.InizioAllarme.Value.Date <= toLogDate)
                If filtri.SingolaFiliale Then intFiltrati = intFiltrati.Where(Function(oFiliale) oFiliale.Filiale.Equals(filtri.Filiale))

            End If
            Dim interventiList = intFiltrati.ToList

            'Rigiro l'estrazione per avere le Distinte/Contratti
            'Dim distinte = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta).ToList
            'Rigiro per avere gli ordini
            'Dim ooo = intFiltrati.Select(Of MaSaleOrd)(Function(u) u.SaleOrd)
            'Dim oooList = ooo.ToList

            ' Metto in una lista gli id ordine li filtro e ordino
            Dim aOrdini As Integer() = intFiltrati.Select(Of Integer)(Function(s) s.MIdOrdCli).ToArray
            'Dim ordini = (From o In OrdiniCntx.MaSaleOrd Where aOrdini.Contains(o.SaleOrdId)) _
            '.OrderBy(Function(o1) o1.InvoicingCustomer).ThenBy(Function(o2) o2.ContractCode).ThenBy(Function(o3) o3.Payment).ThenBy(Function(o4) o4.Carrier1)
            Dim ordini = (From o In OrdiniCntx.MaSaleOrd Where aOrdini.Contains(o.SaleOrdId))


            Dim ordiniList As List(Of MaSaleOrd) = ordini.ToList
            Dim paramSaleOrd = (From dc In OrdiniCntx.MaSalesOrdParameters.ToList Select dc).FirstOrDefault

            MaSaleOrd.SortSaleOrd(ordiniList, paramSaleOrd)

#End Region
            'Creo le entities che usero' poi con BulkInsert
            Dim efMaSaleDoc As New List(Of MaSaleDocNoRef)
            Dim efMaSaleDocDetails As New List(Of MaSaleDocDetailNoRef)
            Dim efMaSaleDocSummary As New List(Of MaSaleDocSummaryNoRef)
            Dim efMaSaleDocNotes As New List(Of MaSaleDocNotesNoRef)
            Dim efMaSaleDocPymtSched As New List(Of MaSaleDocPymtSchedNoRef)
            Dim efMaSaleDocReferences As New List(Of MaSaleDocReferencesNoRef)
            Dim efMaSaleDocShipping As New List(Of MaSaleDocShippingNoRef)
            Dim efMaSaleDocTaxSummary As New List(Of MaSaleDocTaxSummaryNoRef)
            Dim efIntegraInterventi As New List(Of IntegraInterventi)
            Dim efMaEiItdocAdditionalData As New List(Of MaEiItdocAdditionalData)
            Dim efMaCrossReferences As New List(Of MaCrossReferences)
            Dim efMaCrossReferencesNotes As New List(Of MaCrossReferencesNotes)

            If ordini?.Any Then
                bIsSomething = True
                totInterventi = interventiList.Count
                Debug.Print("Interventi Estratti : " & totInterventi.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi Estratti : " & totInterventi.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi Estratti : " & totInterventi.ToString)

                totOrdini = ordiniList.Count
                Debug.Print("Ordini Corrispondenti : " & totOrdini.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Ordini Corrispondenti : " & totOrdini.ToString)
                FLogin.lstStatoConnessione.Items.Add("Ordini Corrispondenti : " & totOrdini.ToString)
                EditTestoBarra("Ordini Corrispondenti : " & totOrdini.ToString)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totOrdini
                FLogin.prgCopy.Step = 1
#Region "Variabili Default"
                Dim defVendite = (From dv In OrdiniCntx.MaUserDefaultSales.ToList Select dv).FirstOrDefault
                ' Dim defContabili = (From dc In OrdContext.MaAccountingDefaults.ToList Select dc).FirstOrDefault
                Dim defIva = (From dc In OrdiniCntx.MaTaxCodesDefaults.ToList Select dc).FirstOrDefault
                Dim codiciIva = (From c In OrdiniCntx.MaTaxCodes.ToList Select c)
                Dim sDefContropartita As String = defVendite.ServicesSalesAccount
                Dim sDefCodIva As String = defIva.TaxCode
                Dim dDefPercIva As Double = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = sDefCodIva).Perc.Value, decPerc)
                Dim idNumbers As MaIdnumbers = OrdiniCntx.MaIdnumbers.First(Function(k) k.CodeType = IdType.DocVend)
                Dim saleDocId As Integer = idNumbers.LastId
                Dim cFattura As New CurFatt()
                Dim clienti = From c In OrdiniCntx.MaCustSupp.Where(Function(w) w.CustSuppType.Equals(CustSuppType.Cliente)).ToList Select c
                Dim scriviTesta As Boolean = True
                Dim isNewRows As Boolean = False    ' Indica se ci sono righe che vengono fatturate e quindi inserite nelle righe in fattura
                'Prima inizializzazione
                Dim saleDoc As New MaSaleDocNoRef
#End Region
                'Ciclo su tutti gli ordini corrispondenti
                For Each o In ordiniList
                    'C'e' la possibilità di estrarre interventi senza ordine
                    If o Is Nothing Then
                        errori.AppendLine("FATAL ERROR: esistono interventi sanza corrispondenza")
                        Continue For
                    End If
                    AvanzaBarra()
                    Debug.Print("Ordine: " & o.InternalOrdNo & " Cliente: " & o.Customer)
                    debugging.AppendLine("Ordine: " & o.InternalOrdNo & " Cliente: " & o.Customer)
                    'todo: testare breck
#Region "Criteri di rottura e accorpamento"
                    If Break(o, saleDoc, cFattura.Cliente, paramSaleOrd) Then
                        ' If cFattura.CodCliente <> o.Customer Then
                        scriviTesta = True
                        isNewRows = False
                        cFattura = New CurFatt(o)
                        saleDocId += 1
                        cFattura.SaleDocId = saleDocId
                        cFattura.Cliente = clienti.Where(Function(w) w.CustSupp.Equals(o.InvoicingCustomer)).SingleOrDefault
                        cFattura.DataFattura = filtri.DataFattura
                        If cFattura.PercIva = 0 Then cFattura.PercIva = dDefPercIva
                    End If
#End Region
#Region "Inizializzazione"
                    'Resetto alcune cose 
                    Dim iNewRowsCount As Integer = 0
                    'Inizializzo alcuni valori
                    Dim bWritedHeadDescription As Boolean = False
                    Dim bWritedRowDescription As Boolean = False
                    Dim iNrRigheNota As Integer = 0
                    Dim iNrRigheAValore As Integer = 0
#End Region
                    'STEP 1 : Ciclo le righe contratto
                    If o.ALLordCliContratto?.Any Then
                        For Each c As AllordCliContratto In o.ALLordCliContratto
                            If c.AllordCliContrattoDistinta?.Any Then
                                For Each d As AllordCliContrattoDistinta In c.AllordCliContrattoDistinta
                                    If d.IntegraInterventi?.Any AndAlso d.AllordCliContrattoDistintaServAgg?.Any Then
                                        For Each s As AllordCliContrattoDistintaServAgg In d.AllordCliContrattoDistintaServAgg
#Region "Calcolo Interventi"
                                            Dim evento As String = TranscodificaEventoIntegra(s.Servizio)
                                            Dim periodFranchigia As Periodo = s.Periodicita
                                            Dim n = d.IntegraInterventi.Where(Function(w) w.TipoEvento.Equals(evento))
                                            If n?.Any Then
                                                s.AnnoIntervento = Year(filtri.ToLogDate)
                                                Dim toDataMese As New Date(Year(filtri.ToLogDate), Month(filtri.ToLogDate), Date.DaysInMonth(Year(filtri.ToLogDate), Month(filtri.ToLogDate)))
                                                toDataMese = toDataMese.AddDays(1).AddSeconds(-1)
                                                Dim fromDataMese As New Date(toDataMese.Year, toDataMese.Month, 1)
                                                s.NrInterventiMese = n.Where(Function(wp) wp.InizioAllarme >= fromDataMese And wp.InizioAllarme <= toDataMese).Sum(Function(q) q.Qta)
                                                Dim dtaPeriodoFranchigiaFrom As Date = GetDataPeriodoFranchigia(toDataMese, s.Periodicita, True)
                                                Dim dtaPeriodoFranchigiaTo As Date = GetDataPeriodoFranchigia(toDataMese, s.Periodicita, False)
                                                s.NrInterventiInFranchigia = n.Where(Function(wp) wp.InizioAllarme >= dtaPeriodoFranchigiaFrom And wp.InizioAllarme <= dtaPeriodoFranchigiaTo).Sum(Function(q) q.Qta)
                                                If periodFranchigia = Periodo.Nessuno Then
                                                    s.NrInterventiInFranchigia = 0
                                                    s.NrInterventiOltreFranchigia = s.NrInterventiMese
                                                Else
                                                    ' Prndo tutti gli interventi del periodo di franchigia e sottraggo la Franchigia del servizio
                                                    s.NrInterventiOltreFranchigia = s.NrInterventiInFranchigia - s.Franchigia
                                                    s.NrInterventiInFranchigia = If(s.NrInterventiOltreFranchigia <= 0, s.NrInterventiInFranchigia, s.Franchigia)
                                                End If
                                                debugging.AppendLine(evento & " Int mese=" & s.NrInterventiMese.ToString & " PeriodoFranchigia(" & Periodo.GetName(GetType(Periodo), periodFranchigia) & " Int=" & s.NrInterventiInFranchigia.ToString & " in Franc=" & s.Franchigia)
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
                                                debugging.AppendLine(evento & " in fattura=" & s.NrInterventiOltreFranchigia.ToString)
#Region "Variabili Correnti"
                                                Dim cFattRow As New CurFattRow With {
                                                        .Contropartita = If(String.IsNullOrWhiteSpace(s.MaItems.SaleOffset), sDefContropartita, s.MaItems.SaleOffset),
                                                        .CodIva = If(String.IsNullOrWhiteSpace(c.CodiceIva), sDefCodIva, c.CodiceIva),
                                                        .PercIva = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = .CodIva).Perc.Value, decPerc),
                                                        .ContrattoFox = d.CodContratto,
                                                        .CodiceIntegra = d.CodIntegra,
                                                        .CdC = d.CdC,
                                                        .Parent = cFattura
                                                    }
                                                If cFattRow.PercIva = 0 Then cFattRow.PercIva = cFattura.PercIva
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

                                                'todo: controllare efficiacia di questo controllo
                                                If Not o.ALLOrdCliAcc.DataCessazione = New DateTime(1799, 12, 31) Then
                                                    isNewRows = True
                                                    If Not bWritedHeadDescription Then
#Region "STEP 1 : INTERVENTI SUPPLEMENTARI"
                                                        bWritedHeadDescription = True
                                                        iNewRowsCount += 1
                                                        iNrRigheNota += 1
                                                        Dim rdi As MaSaleDocDetailNoRef = RigaDescrittivaFattura(iNewRowsCount, cFattura, "INTERVENTI SUPPLEMENTARI")
                                                        'Aggiungo la riga alla collection
                                                        efMaSaleDocDetails.Add(rdi)
                                                        Debug.Print("### Interventi supplementari:(" & rdi.Line.ToString & ") ")
                                                        debugging.AppendLine(" *DTi:" & rdi.Line.ToString)
#End Region
#Region "STEP 2 : DESCRIZIONI FATTURA TESTA"
                                                        If o.ALLordCliDescrizioni?.Any Then
                                                            For Each dTesta In o.ALLordCliDescrizioni
                                                                iNewRowsCount += 1
                                                                iNrRigheNota += 1
                                                                Dim rdt As MaSaleDocDetailNoRef = RigaDescrittivaFattura(iNewRowsCount, cFattura, dTesta.Descrizione)
                                                                'Aggiungo la riga alla collection
                                                                efMaSaleDocDetails.Add(rdt)
                                                                Debug.Print("### Riga descrittiva testa:(" & rdt.Line.ToString & ") " & rdt.Description)
                                                                debugging.AppendLine(" *DTt:" & rdt.Line.ToString)
                                                            Next
                                                        End If
#End Region
                                                    End If
#Region "STEP 3 : DESCRIZIONI RIGA CONTRATTO/FATTURATIVA "
                                                    If c.AllordCliContrattoDescFatt?.Any Then
                                                        For Each dRiga In c.AllordCliContrattoDescFatt
                                                            iNewRowsCount += 1
                                                            iNrRigheNota += 1
                                                            Dim rdr As MaSaleDocDetailNoRef = RigaDescrittivaFattura(iNewRowsCount, cFattura, dRiga.Descrizione)
                                                            'Aggiungo la riga alla collection
                                                            efMaSaleDocDetails.Add(rdr)
                                                            Debug.Print("### Riga descrittiva contratto:(" & rdr.Line.ToString & ") " & rdr.Description)
                                                            debugging.AppendLine(" *DD:" & rdr.Line.ToString)
                                                        Next
                                                    End If
#End Region
#Region "STEP 4 : DETTAGLIO SERVIZIO"
                                                    iNewRowsCount += 1
                                                    iNrRigheAValore += 1
                                                    Dim r As New MaSaleDocDetailNoRef With {
                                                        .Line = cFattura.LastLine + iNewRowsCount,
                                                        .SubId = cFattura.LastSubId + iNewRowsCount,
                                                        .SaleDocId = cFattura.SaleDocId,
                                                        .LineType = LineType.Servizio,
                                                        .Item = s.Servizio,
                                                        .IncludedInTurnover = "1"
                                                        }
                                                    Debug.Print("### R Ord:" & r.Line.ToString)
                                                    debugging.AppendLine(" *R:" & r.Line.ToString)
                                                    'Dim periodoDataFine As String = cOrdRow.PeriodoDataFin.ToShortDateString
                                                    Dim periodo As String = "Periodo dal " '& cOrdRow.PeriodoDataIn.ToShortDateString & " al " & periodoDataFine
                                                    'todo : vedere cosa scrivere qui
                                                    r.Description = If(String.IsNullOrWhiteSpace(s.Descrizione), periodo, s.Descrizione & " " & periodo)
                                                    r.UoM = s.Um
                                                    r.PacksUoM = s.Um
                                                    r.Qty = s.NrInterventiOltreFranchigia
                                                    r.UnitValue = Math.Round(s.ValUnit.GetValueOrDefault, decTax)
                                                    r.NetPrice = Math.Round(s.ValUnit.GetValueOrDefault, decTax)
                                                    r.TaxableAmount = Math.Round(r.Qty.GetValueOrDefault * s.ValUnit.GetValueOrDefault, decTax)
                                                    'TODO: chiedere se data fine competenza in caso di Scadenza fissa e' fine periodo o la data scadenza fissa
                                                    'todo:integrare con eventuali altri campi (vedi rigadescrittivafattura)
                                                    r.AllNrCanoni = r.Qty 'cOrdRow.NrCanoni '-> visto che potrebbe variare uso r.Qty
                                                    'r.AllCanoniDataI = cOrdRow.PeriodoDataIn
                                                    'r.AllCanoniDataF = cOrdRow.PeriodoDataFin
                                                    r.Invoiced = "0"
                                                    r.Notes = Trim(Left(c.Nota.ToString, 32))
                                                    r.CustSupp = cFattura.CodCliente
                                                    r.CustSuppType = CustSuppType.Cliente
                                                    r.DocumentDate = cFattura.DataFattura
                                                    r.ReferenceDocType = DocumentType.Fattura
                                                    r.CrrefType = CrossReference.Tutti
                                                    r.NoOfPacks = 0
                                                    r.ExternalLineReference = 0
                                                    r.InEi = 0
                                                    r.SubjectToWithholdingTax = cFattura.Cliente.MaCustSuppCustomerOptions.WithholdingTaxManagement
                                                    r.Tbcreated = Now
                                                    r.Tbmodified = Now
                                                    r.TbcreatedId = sLoginId
                                                    r.TbmodifiedId = sLoginId
                                                    'Sono della riga ordine/distinta
                                                    r.Job = cFattRow.Commessa
                                                    r.CostCenter = cFattRow.CdC
                                                    r.Offset = cFattRow.Contropartita
                                                    r.TaxCode = cFattRow.CodIva
                                                    r.TotalAmount = Math.Round((r.Qty.GetValueOrDefault * s.ValUnit.GetValueOrDefault) * ((100 + cFattRow.PercIva.GetValueOrDefault) / 100), decTax)

                                                    'Aggiungo la riga alla collection
                                                    efMaSaleDocDetails.Add(r)
#End Region
                                                End If
                                            End If
                                            Application.DoEvents()
                                        Next 'Servizio Aggiuntivo
                                    End If
                                    Application.DoEvents()
                                Next 'Distinta
                            End If
                            Application.DoEvents()
                        Next 'Contratto
                    End If
                    'Se ho scritto qualche riga 
                    'Aggiorno il contatore LastLine e LastSubId
                    If isNewRows Then
                        cFattura.LastLine = cFattura.LastLine + iNewRowsCount
                        cFattura.LastSubId = cFattura.LastSubId + iNewRowsCount
                        msgLog = "Nuove righe n:" & iNrRigheNota.ToString & " S:" & iNrRigheAValore.ToString
                        Debug.Print(msgLog)
                        debugging.AppendLine(msgLog)
                    End If

                    'Posizione della testa!??
                    If scriviTesta Then
                        totFatture += 1
                        Dim t As New MaSaleDocNoRef With {
                            .SaleDocId = cFattura.SaleDocId,
                            .DocumentType = DocumentType.Fattura,
                            .AccTpl = If(cFattura.Cliente.CustSuppKind = CustSuppKind.Nazionale, defVendite.InvoiceAccTpl, defVendite.EuinvoiceAccTpl),
                            .CustSupp = cFattura.CodCliente,
                            .CustSuppType = CustSuppType.Cliente,
                            .DocumentDate = cFattura.DataFattura,
                            .InstallmStartDate = cFattura.DataFattura,
                            .PostingDate = cFattura.DataFattura,
                            .TaxJournal = regIvaPosticipate, 'todo: deve essere sempre posticipato ! mettere costate
                            .CustomerBank = cFattura.Cliente.CustSuppBank,
                            .CompanyCa = cFattura.Cliente.CompanyCa,
                            .CompanyPymtCa = cFattura.Cliente.CustomerCompanyCa,
                            .CompanyBank = cFattura.Cliente.CompanyBank,
                            .InvoiceFollows = "0",
                            .EidocumentType = 22151169, ' TD01
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId,
                            .WorkerIdissue = sLoginId,
                            .Area = cFattura.Area,
                            .AreaManager = cFattura.AreaManager,
                            .Salesperson = cFattura.SalesPerson,
                            .AccrualPercAtInvoiceDate = 100,
                            .Issued = "0", 'Emessa = NO
                            .DeliveryTerms = 5963782,
                            .CountryOfDestination = "IT",
                            .DepartureDate = cFattura.DataFattura,
                            .Presentation = 1376260,
                            .ValueDate = cFattura.DataFattura,
                            .IntrastatAccrualDate = cFattura.DataFattura,
                            .SalespersonCommAuto = "0",
                            .AreaManagerCommAuto = "0",
                            .SalespersonCommPercAuto = "0",
                            .AreaManagerCommPercAuto = "0",
                            .IntrastatBis = "1",
                            .CountryOfPayment = "IT",
                            .ActionOnLifoFifo = 26411008,
                            .ModifyOriginalPymtSched = "0",
                            .Tbguid = Guid.NewGuid(),
                            .Payment = cFattura.Pagamento
                            }
                        'implementare
                        t.AllIban = ""
                        t.AllUmrcode = ""
                        t.SplitPaymentActive = "0"
                        t.Currency = "EUR"
                        t.ContractCode = ""
                        t.ContractCode = ""
                        t.YourReference = ""
                        efMaSaleDoc.Add(t)
                        scriviTesta = False
                        'todo: Dati fattura elettronica??
                    End If

                    'Cross references
                    efMaCrossReferences.Add(RigaCrossReference(o.SaleOrdId, saleDocId))
                    efMaCrossReferencesNotes.Add(RigaCrossReferenceNotes(o.SaleOrdId, saleDocId, ""))

                    'Ritenuta d'acconto lo fa mago?
                    If cFattura.Cliente.MaCustSuppCustomerOptions.WithholdingTaxManagement = "1" Then
                        Dim rS As New MaSaleDocSummaryNoRef With {
                            .WithholdingTaxManagement = "1",
                            .WithholdingTax = 0,
                            .WithholdingTaxPerc = cFattura.Cliente.MaCustSuppCustomerOptions.WithholdingTaxPerc,
                            .WithholdingTaxBasePerc = cFattura.Cliente.MaCustSuppCustomerOptions.WithholdingTaxBasePerc,
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                        }
                        efMaSaleDocSummary.Add(rS)
                        '2.1.1.5.4 <CausalePagamento>
                        'Lettera
                        Dim rEI As New MaEiItdocAdditionalData With {
                            .DocId = cFattura.SaleDocId,
                            .DocSubId = 0,
                            .Line = 0,
                            .SubLine = 0,
                            .FieldName = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.CausalePagamento",
                            .FieldValue = CausaliPagamentoFatturaElettronica(cFattura.LetteraCausalePagamento),
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        efMaEiItdocAdditionalData.Add(rEI)
                    End If
                    debugging.AppendLine()
                    Application.DoEvents()
                Next 'ordine

            End If
#Region "Post elaborazione"
            'Contatori sub
            For Each f In efMaSaleDoc
                Dim linesCount As List(Of MaSaleDocDetailNoRef) = efMaSaleDocDetails.FindAll(Function(d) d.SaleDocId = f.SaleDocId)
                f.LastSubId = linesCount.Count
            Next
            Application.DoEvents()
#End Region
            Dim alt As Boolean = False
#Region "Controllo se tutti gli interventi sono stati analizzati"
            Dim intNotOk = (From interv In OrdiniCntx.IntegraInterventi _
                            .Where(Function(wok) wok.Fatturare.Equals("0"))).ToList
            If intNotOk.Count <> 0 Then
                someTrouble = True
                msgLog = "Interventi non analizzati correttamente :   " & intNotOk.Count.ToString
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

                Using bulkTrans = OrdiniCntx.Database.BeginTransaction
                    Dim iStep As Integer
                    Try
                        OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEON(610)")
                        Dim tablesToUpdate As New Dictionary(Of String, IEnumerable(Of Object)) From {
                            {"MaSaleDoc|IU|teste ordini", efMaSaleDoc},
                            {"MaSaleDocDetails|IU|righe ordini", efMaSaleDocDetails},
                            {"MaSaleDocSummary|IU|totali ordini", efMaSaleDocSummary},
                            {"IntegraInterventi|U|interventi", efIntegraInterventi},
                            {"MaEiItdocAdditionalData|IU|dati aggiuntivi Fattura Elettronica", efMaEiItdocAdditionalData},
                            {"efMaCrossReferences|IU|riferimenti incrociati", efMaCrossReferences},
                            {"efMaCrossReferencesNotes|IU|riferimenti incrociati note", efMaCrossReferencesNotes}
                           }

                        For Each kvp As KeyValuePair(Of String, IEnumerable(Of Object)) In tablesToUpdate
                            Dim keys As String = kvp.Key
                            Dim entityList As List(Of Object) = kvp.Value.ToList

                            iStep += 1
                            EseguiBulkUpdate(OrdiniCntx, entityList, keys, bulkMessage)
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
                        OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

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

        FattureCntx.Dispose()
        Return Not someTrouble

    End Function


    Private Function RigaDescrittivaFattura(iNewRowsCount As Integer, cFattura As CurFatt, d As String) As MaSaleDocDetailNoRef
        Dim rd As New MaSaleDocDetailNoRef With {
                                                .Line = cFattura.LastLine + iNewRowsCount,
                                                .SubId = cFattura.LastSubId + iNewRowsCount,
                                                .SaleDocId = cFattura.SaleDocId,
                                                .LineType = LineType.Nota,
                                                .Description = d,
                                                .InEi = "1",
                                                .DocumentType = DocumentType.Fattura,
                                                .IncludedInTurnover = "0",
                                                .CustSupp = cFattura.CodCliente,
                                                .CustSuppType = CustSuppType.Cliente,
                                                .DepartureDate = cFattura.DataFattura, ' data fatt
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
                                                .AllNrCanoni = 0,
                                                .AllCanoniDataI = sDataNulla,
                                                .AllCanoniDataF = sDataNulla
                                            }
        '.SaleOrdId = cOrdRow.Parent.SaleOrdId,
        Return rd
    End Function

    Private Function RigaServizioFattura(iNewRowsCount As Integer, cFattura As CurFatt, d As String) As MaSaleDocDetailNoRef
        Dim rd As New MaSaleDocDetailNoRef With {
                                                .Line = cFattura.LastLine + iNewRowsCount,
                                                .SubId = cFattura.LastSubId + iNewRowsCount,
                                                .SaleDocId = cFattura.SaleDocId,
                                                .LineType = LineType.Servizio,
                                                .Description = d,
                                                .InEi = "1",
                                                .DocumentType = DocumentType.Fattura,
                                                .IncludedInTurnover = "0",
                                                .CustSupp = cFattura.CodCliente,
                                                .CustSuppType = CustSuppType.Cliente,
                                                .DepartureDate = "", ' data fatt
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
                                                .AllNrCanoni = 0,
                                                .AllCanoniDataI = sDataNulla,
                                                .AllCanoniDataF = sDataNulla
                                            }
        '.SaleOrdId = cOrdRow.Parent.SaleOrdId,
        Return rd
    End Function
    Private Function RigaCrossReference(idOrdine As Integer, idFattura As Integer) As MaCrossReferences
        Dim r As New MaCrossReferences With {
        .OriginDocType = CrossReference.OrdineCliente,
        .OriginDocId = idOrdine,
        .OriginDocSubId = 0,
        .OriginDocLine = 0,
        .DerivedDocType = CrossReference.FatturaImmediata,
        .DerivedDocId = idFattura,
        .DerivedDocSubId = 0,
        .DerivedDocLine = 0,
        .Manual = "1",
        .TbcreatedId = My.Settings.mLOGINID, 'ID utente
        .TbmodifiedId = My.Settings.mLOGINID 'ID utente
         }
        Return r
    End Function
    Private Function RigaCrossReferenceNotes(idOrdine As Integer, idFattura As Integer, notes As String) As MaCrossReferencesNotes
        Dim r As New MaCrossReferencesNotes With {
        .OriginDocType = CrossReference.OrdineCliente,
        .OriginDocId = idOrdine,
        .DerivedDocType = CrossReference.FatturaImmediata,
        .DerivedDocId = idFattura,
        .Notes = notes,
        .TbcreatedId = My.Settings.mLOGINID, 'ID utente
        .TbmodifiedId = My.Settings.mLOGINID 'ID utente
         }
        Return r
    End Function

    ''' <summary>
    ''' Controllo Flusso Integra
    ''' </summary>
    ''' <returns></returns>
    Public Function ControllaFlussoIntegra(filtri As FiltriOrdiniConsuntivo) As Boolean
        My.Application.Log.DefaultFileLogWriter.WriteLine("Controllo Flusso")

#Region "Variabili Selezione"

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
            Dim allDistinte = (From o In OrdiniCntx.AllordCliContrattoDistinta _
                         .Include(Function(sa) sa.AllordCliContrattoDistintaServAgg) _
                         .Where(Function(wsa) Not wsa.Servizio.Equals(TECNO_ALL1)) _
                         .Include(Function(o) o.AllordCliContratto) _
                            .ThenInclude(Function(ord) ord.SaleOrd) _
                                .ThenInclude(Function(info) info.ALLOrdCliAcc)) _
                                .Select(Function(x) New MiniDistinta With {.CodIntegra = x.CodIntegra,
                                                                   .DataCessazione = x.AllordCliContratto.SaleOrd.ALLOrdCliAcc.DataCessazione,
                                                                   .DataScadenzaFissa = x.AllordCliContratto.SaleOrd.ALLOrdCliAcc.DataScadenzaFissa,
                                                                   .AllordCliContrattoDistintaServAgg = x.AllordCliContrattoDistintaServAgg})


            Dim integraInterventi = (From o In OrdiniCntx.IntegraInterventi)
            If filtri.AskFilter Then
                If filtri.Riassegna Then integraInterventi = integraInterventi.Where(Function(oAss) oAss.MAssociato.Equals("0"))
                'todo : verificare date e ore minuti per i fine mese e la mezzanotte
                integraInterventi = integraInterventi.Where(Function(oDate) oDate.InizioAllarme.Value.Date >= filtri.FromLogDate AndAlso oDate.InizioAllarme.Value.Date <= filtri.ToLogDate)
                If filtri.SingolaFiliale Then integraInterventi = integraInterventi.Where(Function(oFiliale) oFiliale.Filiale.Equals(filtri.Filiale))

            End If
            Dim allInterventi As List(Of IntegraInterventi) = integraInterventi.ToList
#End Region
            If allInterventi?.Any Then
                Dim updIntList As New List(Of IntegraInterventi)
                totInterventi = allInterventi.Count
                Debug.Print("Interventi Estratti  " & totInterventi.ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine("Interventi Estratti  " & totInterventi.ToString)
                FLogin.lstStatoConnessione.Items.Add("Interventi Estratti  " & totInterventi.ToString)
                EditTestoBarra("Interventi Estratti  " & totInterventi.ToString)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totInterventi
                FLogin.prgCopy.Step = 1

                'Ciclo su tutti gli Interventi
                For Each i In allInterventi
                    AvanzaBarra()
                    Debug.Print("ID Intervento " & i.ID)
                    Dim allDistinteFiltered = allDistinte.Where(Function(x) x.CodIntegra.Equals(i.Contratto))
                    'todo: cosa volevo fare?
                    Dim allDistintexxx = allDistinte.Where(Function(d) d.DataCessazione.Equals(Nothing) _
                        OrElse d.DataCessazione.Equals(dataNulla) _
                        OrElse d.DataCessazione >= filtri.ToLogDate)
                    Dim allDistinteyyy = allDistinte.Where(Function(d) d.DataScadenzaFissa.Equals(Nothing) _
                        OrElse d.DataScadenzaFissa.Equals(dataNulla) _
                        OrElse d.DataScadenzaFissa >= filtri.ToLogDate)
                    If allDistinteFiltered?.Any Then
                        If allDistinteFiltered.Count = 1 Then
                            Dim distinta = allDistinteFiltered.SingleOrDefault
                            Dim eventoMago As String = TrascodificaServizioAggiuntivo(i.TipoEvento)
                            Dim allEventi = distinta.AllordCliContrattoDistintaServAgg.Where(Function(y) y.Servizio.Equals(eventoMago))
                            'Blocco Eventi
                            If allEventi?.Any Then
                                If allEventi.Count = 1 Then
                                    Dim row As AllordCliContrattoDistintaServAgg = allEventi.Single()
                                    'Aggiorno Flag
                                    i.MAssociato = "1"
                                    i.MIdOrdCli = row.IdOrdCli
                                    i.MLineaContratto = row.RifRifLinea
                                    i.MLineaDistinta = row.RifLinea
                                    Continue For
                                Else
                                    fatalEventoErrorCnt += 1
                                    Dim errorString As String = $"Contratto {i.Contratto} Evento: {i.TipoEvento}"
                                    If Not fatalEventoErrorList.Contains(errorString) Then
                                        fatalEventoErrorList.Add(errorString)
                                    End If
                                    Continue For
                                End If
                            Else
                                eventoErrorCnt += 1
                                Dim errorString As String = $"Contratto {i.Contratto} Evento: {i.TipoEvento}"
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
                Using bulkTrans = OrdiniCntx.Database.BeginTransaction
                    Dim someBulkTrouble As Boolean = False
                    Dim bulkMessage As New StringBuilder()
                    Dim msgLog As String
                    Try
                        OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                        EditTestoBarra("Salvataggio Aggiornamento interventi")
                        Dim t = allInterventi.Count
                        Dim iIntUpd As Integer = OrdiniCntx.SaveChanges()
                        Debug.Print("IntegraInterventi Agg: " & iIntUpd.ToString)
                        bulkMessage.AppendLine("IntegraInterventi Agg" & iIntUpd.ToString)

                        If someBulkTrouble Then
                            bulkTrans.Rollback()
                            bulkMessage.AppendLine("[Aggiornamento IntegraInterventi] Sono stati riscontrati degli errori. Eseguita rollback")
                        Else
                            bulkTrans.Commit()
                            FLogin.lstStatoConnessione.Items.Add(" --- Inserimento Dati ---")
                            msgLog = "Interventi Aggiornati  " & iIntUpd.ToString
                            Debug.Print(msgLog)
                            bulkMessage.AppendLine("[RIASSUNTO] " & msgLog)
                            FLogin.lstStatoConnessione.Items.Add(msgLog)
                        End If
                        OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

                    Catch ex As Exception
                        someBulkTrouble = True
                        Dim entries = OrdiniCntx.ChangeTracker.Entries.Where(Function(x) x.State <> EntityState.Unchanged)
                        For Each entry In entries
                            For Each prop In entry.CurrentValues.Properties
                                Dim val = prop.PropertyInfo.GetValue(entry.Entity)
                                Console.WriteLine($" {prop.PropertyInfo } {prop.ToString()} ~ ({val?.ToString().Length})({val})")
                            Next
                        Next
                        Debug.Print(ex.Message)
                        FLogin.lstStatoConnessione.Items.Add("Annullamento operazione Riscontrati errori")
                        bulkMessage.AppendLine("[Aggiornamento IntegraInterventi] - Sono stati riscontrati degli errori. (Vedere sezione Errori)")
                        errori.AppendLine("[Aggiornamento IntegraInterventi] Messaggio" & ex.Message)
                        errori.AppendLine("[Aggiornamento IntegraInterventi] Stack" & ex.StackTrace)

                        Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                        mb.ShowDialog()
                    End Try
                End Using
#End Region

            End If

        Catch ex As Exception
            Debug.Print(ex.Message)
            errori.AppendLine("[Procedura] Messaggio" & ex.Message)
            errori.AppendLine("[Procedura] Stack" & ex.StackTrace)
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
        'todo : COMPLETARE
        Dim ret As String = ""

        Dim mappings As New Dictionary(Of String, String) From {
            {"ISP", ServiziAggiuntivi.Ispezioni}, ' "ISPEZIONI"
            {"ISPD", ServiziAggiuntivi.Ispezioni_Descri}, ' "Ispezioni"
            {"INT", ServiziAggiuntivi.Interventi}, ' "INTERVENTI"
            {"INTD", ServiziAggiuntivi.Interventi_Descri}, ' "Interventi"
            {"1", ServiziAggiuntivi.AperturaChiusura}, ' "APECHIU"
            {"1d", ServiziAggiuntivi.AperturaChiusura_Descri}, ' "Apertura Chiusura"
            {"2", ServiziAggiuntivi.Assistenza}, ' "ASSISTENZA"
            {"2d", ServiziAggiuntivi.Assistenza_Descri}, ' "Assistenza"
            {"3", ServiziAggiuntivi.Piantoni}, ' "PIANTONI"
            {"3d", ServiziAggiuntivi.Piantoni_Descri}, ' "Piantoni"
            {"4", ServiziAggiuntivi.VideoIsp}, ' "VIDEOISPEZIONI"
            {"4d", ServiziAggiuntivi.VideoIsp_Descri}, ' "Video Ispezioni"
            {"5", ServiziAggiuntivi.Frequenza} ' "SUPPLEMENTAR"
            }

        If mappings.ContainsKey(value) Then
            ret = mappings(value)
        End If
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
    Private Sub ConnettiContestoFatture()
        EditTestoBarra("Connessione al contesto")
        Dim cs As String = GetConnectionStringSPA(True)
        Dim dbcb As New DbContextOptionsBuilder(Of FattureContext)
        dbcb.UseSqlServer(cs)

        FattureCntx = New FattureContext(dbcb.Options)
        If FattureCntx.Database.CanConnect Then
            FattureCntx.Database.ExecuteSqlRaw("SET ARITHABORT ON")
        End If
    End Sub

    Friend Sub PrecaricaTabelleFatture()
        FattureCntx.MaSaleDoc.Load()
        FattureCntx.MaSaleDocDetail.Load()
        FattureCntx.MaSaleDocNotes.Load()
        FattureCntx.MaSaleDocPymtSched.Load()
        FattureCntx.MaSaleDocReferences.Load()
        FattureCntx.MaSaleDocShipping.Load()
        FattureCntx.MaSaleDocSummary.Load()
        FattureCntx.MaSaleDocTaxSummary.Load()
    End Sub
    Friend Sub PrecaricaTabelleFatturaElettronica()
        FattureCntx.MaEiItcustSuppAddData.Load()
        FattureCntx.MaEiItcustSuppAddDataDet.Load()
        FattureCntx.MaEiItdocAdditionalData.Load()
        FattureCntx.MaEiItitemCustomers.Load()
        FattureCntx.MaEiItparameters.Load()
        FattureCntx.MaEiparameters.Load()
        FattureCntx.MaEipaymentType.Load()
    End Sub
    ''' <summary>
    ''' questa roba si applica al  saledoc
    ''' </summary>
    ''' <returns></returns>
    Public Function Break(ordine As MaSaleOrd, testaFattura As MaSaleDocNoRef, customer As MaCustSupp, salesOrdParameters As MaSalesOrdParameters) As Boolean

        Dim AuxBreaking As Boolean = False ' Variabile per i clientdoc
        Dim customerOptions As MaCustSuppCustomerOptions
        If customer Is Nothing OrElse customer.MaCustSuppCustomerOptions Is Nothing Then
            customerOptions = New MaCustSuppCustomerOptions
        Else
            customerOptions = customer.MaCustSuppCustomerOptions
        End If

        'Escludo questo per scelta
        'testaFattura.TaxJournal <> ordine.TaxJournal OrElse

        If testaFattura.CustSupp <> ordine.InvoicingCustomer OrElse
       testaFattura.Payment <> ordine.Payment OrElse
       testaFattura.Currency <> ordine.Currency OrElse
       testaFattura.Salesperson <> ordine.Salesperson OrElse
       (Not String.IsNullOrEmpty(testaFattura.Salesperson) AndAlso
       (testaFattura.Salesperson <> ordine.Salesperson OrElse
       testaFattura.SalespersonPolicy <> ordine.SalespersonPolicy OrElse
       testaFattura.SalespersonCommAuto <> ordine.SalespersonCommAuto OrElse
       testaFattura.SalespersonCommPercAuto <> ordine.SalespersonCommPercAuto)) OrElse
       testaFattura.AreaManager <> ordine.AreaManager OrElse
       (Not String.IsNullOrEmpty(testaFattura.AreaManager) AndAlso
       (testaFattura.AreaManager <> ordine.AreaManager OrElse
       testaFattura.AreaManagerPolicy <> ordine.AreaManagerPolicy OrElse
       testaFattura.AreaManagerCommAuto <> ordine.AreaManagerCommAuto OrElse
       testaFattura.AreaManagerCommPercAuto <> ordine.AreaManagerCommPercAuto)) OrElse
       customerOptions.OneInvoicePerOrder Then
            Return True
        End If


        ' Criteri di rottura definiti dall'utente
        If salesOrdParameters.FulfillmentBreakByArea AndAlso testaFattura.Area <> ordine.Area Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByInvRsn AndAlso testaFattura.InvRsn <> ordine.InvRsn Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByJob AndAlso testaFattura.Job <> ordine.Job Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByDocBranch AndAlso testaFattura.SendDocumentsTo <> ordine.SendDocumentsTo Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByGoodBranch AndAlso testaFattura.ShipToAddress <> ordine.ShipToAddress Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByShippRsn AndAlso testaFattura.ShippingReason <> ordine.ShippingReason Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByCarrier AndAlso testaFattura.Carrier1 <> ordine.Carrier1 Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByPort AndAlso testaFattura.Port <> ordine.Port Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByPackage AndAlso testaFattura.Package <> ordine.Package Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByTransport AndAlso testaFattura.Transport <> ordine.Transport Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByCig AndAlso (testaFattura.ContractCode <> ordine.ContractCode OrElse testaFattura.ProjectCode <> ordine.ProjectCode) Then
            Return True
        End If

        If salesOrdParameters.FulfillmentBreakByTcg AndAlso testaFattura.TaxCommunicationGroup <> ordine.TaxCommunicationGroup Then
            Return True
        End If

        ' Invio ai ClientDoc un messaggio
        'HO ROTTO !

        Return False
    End Function

    Private CausaliPagamentoFatturaElettronica As New Dictionary(Of String, Integer) From {
           {"", 32440347},
           {"A", 32440320},
           {"B", 32440321},
           {"C", 32440322},
           {"D", 32440323},
           {"E", 32440324},
           {"G", 32440325},
           {"H", 32440326},
           {"I", 32440327},
           {"L", 32440328},
           {"M", 32440329},
           {"N", 32440330},
           {"O", 32440331},
           {"P", 32440332},
           {"Q", 32440333},
           {"R", 32440334},
           {"S", 32440335},
           {"T", 32440336},
           {"U", 32440337},
           {"V", 32440338},
           {"W", 32440339},
           {"X", 32440340},
           {"Y", 32440341},
           {"Z", 32440342},
           {"L1", 32440343},
           {"M1", 32440344},
           {"O1", 32440345},
           {"V1", 32440346},
           {"M2", 32440348},
           {"ZO", 32440349}
       }
End Module

Module test_LINQ
    Public Sub LinqStringQuery()
        'https://entityframework.net/why-first-query-slow
        'Tipizzare con (Of ) solo le Tabelle singole 1-1 che NON hanno 1-n / Collection
        Dim l = (From o In OrdiniCntx.IntegraInterventi)
        If 1 = 2 Then
            l = l.Where(Function(oDate) oDate.DataInsert.Value.Date >= "20230101" AndAlso oDate.DataInsert.Value.Date <="20231231")
            If 2 = 2 Then l = l.Where(Function(oFiliale) oFiliale.Filiale.Equals("filialE"))
        End If
        Dim allInterventi = l.ToList

        Dim dist_con_join = (From dis In OrdiniCntx.AllordCliContrattoDistinta _
                                         .Where(Function(w) Not w.Servizio.Equals(TECNO_ALL1)) _
                                        .Include(Function(sa) sa.AllordCliContrattoDistintaServAgg)
                             Join i In OrdiniCntx.IntegraInterventi On dis.CodIntegra Equals i.Contratto
                             Select dis, i)

        'Solo gli Interventi con le loro distinte
        Dim soloInterventi = (From o In OrdiniCntx.IntegraInterventi _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(i) i.AllordCliContrattoDistintaServAgg) _
                                .Where(Function(wsa) Not wsa.AllordCliContrattoDistinta.Servizio.Equals(TECNO_ALL1)))
        Dim allInt = soloInterventi.ToList
        Dim allDistConjoin = dist_con_join.ToList



        'ESCLUDO DISTINTE Tecnologia Allsystem1
        'Solo le Distinte con Interventi
        Dim distWithInt = (From o In OrdiniCntx.AllordCliContrattoDistinta _
                                .Include(Function(sa) sa.AllordCliContrattoDistintaServAgg) _
                                .Where(Function(wsa) Not wsa.Servizio.Equals(TECNO_ALL1)) _
                                .Where(Function(n) n.IntegraInterventi.Count > 0)
                                )
        Dim allDist = distWithInt.ToList  '-> QUESTA LAVORA BENE

        'Interventi+Distinta con filtro ( partendo dagli iterventi)
        Dim intFiltrati = (From o In OrdiniCntx.IntegraInterventi _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                .Include(Function(sa) sa.AllordCliContrattoDistinta) _
                                    .ThenInclude(Function(i) i.AllordCliContrattoDistintaServAgg) _
                                .Where(Function(wsa) Not wsa.AllordCliContrattoDistinta.Servizio.Equals(TECNO_ALL1)))
        Dim allIntFiltrati = intFiltrati.ToList
        'Anche questa lavora bene
        Dim alldistinte = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta)
        Dim ll = alldistinte.ToList

        If 1 = 2 Then
            intFiltrati = intFiltrati.Where(Function(oDate) oDate.InizioAllarme.Value.Date >= "20230101" AndAlso oDate.InizioAllarme.Value.Date <= "20231231")
            If 2 = 2 Then distWithInt = intFiltrati.Where(Function(oFiliale) oFiliale.Filiale.Equals("filialE"))
        Else
            'distWithInt = distWithInt.Where(Function(x) x.IntegraInterventi.Count > 0 AndAlso x.IntegraInterventi?.Any(Function(oDate) oDate.Contratto.Equals("935/PR")))
            '.Include(Function(inte) inte.IntegraInterventi) _
            'distWithInt = distWithInt.Where(Function(n) n.IntegraInterventi.Count > 0)
            'intFiltrati = intFiltrati.Where(Function(oDate) oDate.Contratto.Equals("935/PR"))
        End If
        'Rigiro l'estrazione per avere le distinte
        Dim aalldistinte = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta)
        Dim aall = alldistinte.ToList
        'Dim allordini = intFiltrati.Select(Of AllordCliContrattoDistinta)(Function(u) u.AllordCliContrattoDistinta.IdOrdCli).Distinct().ToList

        Dim d = (From o In OrdiniCntx.AllordCliContrattoDistinta.Include(Function(sa) sa.AllordCliContrattoDistintaServAgg))
    End Sub


End Module
