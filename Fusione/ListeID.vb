Module ListeID
    Const PrefissoCespiti As String = "A"
    Const Prefisso As String = "1"
    Const Suffisso As String = "1"
    Private ReadOnly sDataInizioAmmortamento As String = New DateTime(2023, 4, 1).ToString
    Private Const iFiscalYear = 2024
    Const ContoFusione As String = "1IMI029"
    Const ContoBilancioApertura As String = "5STP001"
    Const CausaleBIA As String = "FUSIONE"


    Friend Function EstraiListaIds(ByVal table As TabelleDaEstrarre, ByVal dvids As DataView) As List(Of IDS)
        Dim g As MacroGruppo = table.Gruppo
        Dim n As String = table.Nome
        Dim lIDS As New List(Of IDS)
        Select Case g
            Case MacroGruppo.Vendita
                EditTestoBarra("Modifiche: Documenti Vendita")
                lIDS = IdsVendite(dvids, n)
            Case MacroGruppo.Acquisto
                EditTestoBarra("Modifiche: Documenti Acquisto")
                'Logica diversa perche' ho un filtro
                lIDS = IdsAcquisti(dvids, n)
            Case MacroGruppo.Analitica
                EditTestoBarra("Modifiche: Analitica")
                lIDS = IdsAnalitica(n)
            Case MacroGruppo.OrdiniClienti
                EditTestoBarra("Modifiche: Ordini Clienti")
                lIDS = IdsOrdiniClienti(dvids, n)
            Case MacroGruppo.Cespiti
                EditTestoBarra("Modifiche: Cespiti")
                lIDS = IdsCespiti(n)
            Case MacroGruppo.Agenti
                EditTestoBarra("Modifiche: Agenti")
                lIDS = IdsAgenti(n)
            Case MacroGruppo.Clienti
                EditTestoBarra("Modifiche: Clienti")
                lIDS = IdsClienti(dvids, n)
            Case MacroGruppo.Articoli
                EditTestoBarra("Modifiche: Articoli")
                lIDS = IdsArticoli(n)
            Case MacroGruppo.Partite
                EditTestoBarra("Modifiche: Partite")
                lIDS = IdsPartite(dvids, n)
            Case MacroGruppo.CrossRef
                EditTestoBarra("Modifiche: Cross Reference " & table.Coppia_CR.ToString)
                lIDS = IdsCrossRef(dvids, table)
            Case MacroGruppo.Fornitori
                EditTestoBarra("Modifiche: Fornitori")
                lIDS = IdsFornitori(n)
            Case MacroGruppo.OrdiniFornitori
                EditTestoBarra("Modifiche: Ordini Fornitori")
                lIDS = IdsOrdiniFornitori(dvids, n)
            Case MacroGruppo.Parcelle
                EditTestoBarra("Modifiche: Parcelle")
                lIDS = IdsParcelle(dvids, n)
            Case MacroGruppo.Magazzino
                EditTestoBarra("Modifiche: Magazzino")
                lIDS = IdsMovMag(dvids, n)
            Case MacroGruppo.Contabilita
                EditTestoBarra("Modifiche: Fornitori")
                lIDS = IdsApertura(dvids, n)

            Case Else
                MessageBox.Show("Non gestito:" & g.ToString)
        End Select

        Return lIDS
    End Function

    ''' <summary>
    ''' Incremento SaleDocId sulle tabelle delle Vendite
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsVendite(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim SaleDocId As Integer
        Dim found As Integer = dv.Find("SaleDocId")
        If found = -1 Then
            Debug.Print("Vendite SaleDocId: non trovato")
            ScriviLog("Fatture SaleDocId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare,Vendite SaleDocId: non trovato nel file IDS")
                End
            End If
        Else
            SaleDocId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_SaleDoc"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                    Dim fPartita As Integer = dv.Find("PymtSchedId")
                    If fPartita = -1 Then
                        Debug.Print("Fatture: PymtSchedId: non trovato")
                        ScriviLog("Fatture: PymtSchedId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Fatture: PymtSchedId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "IntrastatId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "AdvancePymtSchedId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectedDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InventoryIDReturn", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ParagonID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProFormaInvoiceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJECollectionPaymentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentIdInCN", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "WorkerIDIssue", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ExtAccAEID", .Operatore = IdsOp.Sovrascrivi})
                    'Aggiungo campo aggiuntivo cost center
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                    'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                Case "MA_SaleDocComponents", "MA_SaleDocManufReasons", "MA_SaleDocNotes", "MA_SaleDocShipping", "MA_SaleDocSummary", "MA_SaleDocTaxSummary"
                    '"MA_SaleDocReferences", "MA_EIEventViewer", "MA_EI_ITDocAdditionalData", "MA_EI_ITAsyncComm"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                Case "MA_SaleDocPymtSched"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                Case "MA_SaleDocDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                    Dim fOrdine As Integer = dv.Find("SaleOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Fatture: SaleOrdId: non trovato")
                        ScriviLog("Fatture: SaleOrdId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Fatture: SaleOrdId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fOrdine)("NewKey")), .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReturnFromCustomerId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "DocIdToBeUnloaded", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceForAdvanceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProFormaInvoiceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "TRId", .Operatore = IdsOp.Sovrascrivi})
            End Select
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Incremento PurchaseDocId sulle sole Bolle di Carico
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsAcquisti(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim PurchaseDocId As Integer
        Dim found As Integer = dv.Find("PurchaseDocId")
        If found = -1 Then
            Debug.Print("Acquisti PurchaseDocId: non trovato")
            ScriviLog("Acquisti PurchaseDocId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Acquisti PurchaseDocId: non trovato nel file IDS")
                End
            End If
        Else
            PurchaseDocId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_PurchaseDoc"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                    Dim fPartita As Integer = dv.Find("PymtSchedId")
                    If fPartita = -1 Then
                        Debug.Print("Acquisti: PymtSchedId: non trovato")
                        ScriviLog("Acquisti: PymtSchedId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Acquisti: PymtSchedId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "IntrastatId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "RMAId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionOrdId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ScrapInvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReturnInvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "AdvancePymtSchedId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "AdjValueOnlyInvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectedDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJECollectionPaymentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentIdInCN", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "WorkerIDIssue", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJETaxTransferId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ExtAccAEID", .Operatore = IdsOp.Sovrascrivi})
                    'Campi accessori
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                Case "MA_PurchaseDocNotes", "MA_PurchaseDocShipping", "MA_PurchaseDocSummary", "MA_PurchaseDocTaxSummary"
                    '"MA_PurchaseDocReferences"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                Case "MA_PurchaseDocPymtSched"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                Case "MA_PurchaseDocDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    Dim fOrdine As Integer = dv.Find("PurchaseOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Acquisti: PurchaseOrdId: non trovato")
                        ScriviLog("Acquisti: PurchaseOrdId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Acquisti: PurchaseOrdId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fOrdine)("NewKey")), .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionOrdId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionBillId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "RMAId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "BillOfLadingId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SaleDocId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceForAdvanceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SuppQuotaId", .Operatore = IdsOp.Sovrascrivi})
            End Select
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Incremento SaleOrdId sugli Ordini
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsOrdiniClienti(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Dim SaleOrdId As Integer
        Dim SaleDocId As Integer
        Dim found As Integer = dv.Find("SaleOrdId")
        If found = -1 Then
            Debug.Print("Ordini SaleOrdId: non trovato")
            ScriviLog("Ordini SaleOrdId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Ordini SaleOrdId: non trovato nel file IDS")
                End
            End If
        Else
            Dim fVen As Integer = dv.Find("SaleDocId")
            If fVen = -1 Then
                Debug.Print("Crossref SaleDocId: non trovato")
                ScriviLog("Crossref SaleDocId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare, Crossref SaleDocId: non trovato nel file IDS")
                    End
                End If
            Else
                SaleOrdId = CInt(dv(found)("NewKey"))
                SaleDocId = CInt(dv(fVen)("NewKey"))
                Select Case tablename
                    Case "MA_SaleOrdComponents", "MA_SaleOrdNotes", "MA_SaleOrdPymtSched", "MA_SaleOrdShipping", "MA_SaleOrdSummary", "MA_SaleOrdTaxSummary"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                    Case "MA_SaleOrd"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                    'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                    Case "MA_SaleOrdDetails"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ProductionPlanId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ProductionJobId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceQuotationId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    Case "ALLOrdCliDescrizioni", "ALLOrdCliContratto", "ALLOrdCliTipologiaServizi", "ALLOrdCliAttivita"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                    Case "ALLOrdFiglio"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "IdOrdFiglio", .Operatore = IdsOp.Somma})
                    Case "ALLOrdPadre"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "IdOrdPadre", .Operatore = IdsOp.Somma})
                    Case "ALLOrdCliAcc"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Cdc", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    Case "ALLCespiti"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = PrefissoCespiti, .Nome = "Cespite", .Operatore = IdsOp.Prefisso, .MaxSize = 10})
                    Case "MA_SaleOrdReferences"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DocumentId", .Operatore = IdsOp.Somma})

                End Select
            End If
        End If

        Return lIDS
    End Function
    ''' <summary>
    ''' Incremento PurchaseOrdId sugli Ordini
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsOrdiniFornitori(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Dim PurchaseOrdId As Integer
        Dim found As Integer = dv.Find("PurchaseOrdId")
        If found = -1 Then
            Debug.Print("Ordini PurchaseOrdId: non trovato")
            ScriviLog("Ordini PurchaseOrdId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Ordini PurchaseOrdId: non trovato nel file IDS")
                End
            End If
        Else
            PurchaseOrdId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_PurchaseOrdNotes", "MA_PurchaseOrdPymtSched", "MA_PurchaseOrdShipping", "MA_PurchaseOrdSummary", "MA_PurchaseOrdTaxSummay"
                    '"MA_PurchaseOrdReferences"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                Case "MA_PurchaseOrd"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                    'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                Case "MA_PurchaseOrdDetails"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PurchaseReqId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SuppQuotaId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SaleOrdId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
            End Select
        End If

        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso 'A' ai Cepiti e suffisso '1' ad Ubicazioni
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsCespiti(ByVal tablename As String) As List(Of IDS)
        'dati presenti in 4 tabelle
        'MA_FixAssetEntriesDetail   'Esclusa
        'MA_FixedAssets
        'MA_FixedAssetsBalance      'Per movimento ripresa
        'MA_FixedAssetsFiscal       'Per movimento ripresa
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_FixedAssets"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = PrefissoCespiti, .Nome = "FixedAsset", .Operatore = IdsOp.Prefisso, .MaxSize = 10})
                lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Location", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                lIDS.Add(New IDS With {.Id = iFiscalYear, .Nome = "DepreciationStart", .Operatore = IdsOp.Sovrascrivi})
                lIDS.Add(New IDS With {.IdString = sDataInizioAmmortamento, .Nome = "DepreciationStartingDate", .Operatore = IdsOp.Sovrascrivi})
            Case "MA_FixAssetLocations"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Location", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Movimenti di magazzino
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsMovMag(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim EntryId As Integer
        Dim found As Integer = dv.Find("EntryId")
        If found = -1 Then
            Debug.Print("Magazzino EntryId: non trovato")
            ScriviLog("Magazzino EntryId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare,Magazzino EntryId: non trovato nel file IDS")
                End
            End If
        Else
            Dim SaleDocId As Integer
            Dim foundVen As Integer = dv.Find("SaleDocId")
            If foundVen = -1 Then
                Debug.Print("Magazzino SaleDocId: non trovato")
                ScriviLog("Magazzino SaleDocId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare,Magazzino SaleDocId: non trovato nel file IDS")
                    End
                End If
            Else
                SaleDocId = CInt(dv(foundVen)("NewKey"))
                EntryId = CInt(dv(found)("NewKey"))
                Select Case tablename
                    Case "MA_InventoryEntries"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = EntryId, .Nome = "EntryId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    Case "MA_InventoryEntriesDetail"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = EntryId, .Nome = "EntryId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "OrderId", .Operatore = IdsOp.Sovrascrivi}) ' per pigrizia lo metto a zero non so se e' ordine cliente o fornitore
                        lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "BolId", .Operatore = IdsOp.Somma}) ' IdBolla
                        lIDS.Add(New IDS With {.Id = EntryId, .Nome = "VariationInvEntryID", .Operatore = IdsOp.Somma})
                    Case "MA_InventoryEntriesReference"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = EntryId, .Nome = "EntryId", .Operatore = IdsOp.Somma})
                End Select
            End If
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' DEPRECATA
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsArticoli(ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_Items"
                ' lIDS.Add(New IDS With {.IdString = ContropartitaAcquisto, .Nome = "PurchaseOffset", .Operatore = IdsOp.Salva, .MaxSize = 16})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto suffisso
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsAgenti(ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_Areas"
                'lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Dichiarazioni di Intento. Clienti
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsClienti(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_DeclarationOfIntent"
                Dim DeclId As Integer
                Dim found As Integer = dv.Find("DeclId")
                If found = -1 Then
                    Debug.Print("Clienti DeclId: non trovato")
                    ScriviLog("Clienti DeclId: non trovato")
                    If Not IsDebugging Then
                        MessageBox.Show("Impossibile continuare, Clienti DeclId: non trovato nel file IDS")
                        End
                    End If
                Else
                    DeclId = CInt(dv(found)("NewKey"))
                    lIDS.Add(New IDS With {.Chiave = True, .Id = DeclId, .Nome = "DeclId", .Operatore = IdsOp.Somma})
                End If
            Case "MA_SDDMandate"
                lIDS.Add(New IDS With {.IdString = "20231231", .Is_data = True, .Nome = "MandateFirstDate", .Operatore = IdsOp.Sovrascrivi})

            Case "MA_CustSuppCustomerOptions"
                'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Fornitori
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsFornitori(ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_CustSuppSupplierOptions"
                ' lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto il suffisso 1 ai Centri di Costo
    ''' Viene aggiunto il prefisso A ai Cesptiti indicati in "Contract"
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsAnalitica(ByVal tablename As String) As List(Of IDS)
        'Presente su 21 tabelle !!!!!
        'MA_ChartOfAccountsCostAccTpl   'Esclusa
        'MA_CostAccEntriesDetail        'Esclusa
        'MA_CostCenters
        'MA_CostCentersBalances         'Esclusa
        'MA_CustSupp                    '2 Voci
        'MA_FixedAssets
        'MA_InventoryEntries            'Esclusa
        'MA_InventoryEntriesDetail      'Esclusa
        'MA_Items                       '2 Voci
        'MA_PurchaseDoc                 'Aggiunta
        'MA_PurchaseDocDetail           'Aggiunta
        'MA_PurchaseDocPymtSched        'Aggiunta
        'MA_PurchaseOrd                 'Aggiunta
        'MA_PurchaseOrdDetails          'Aggiunta
        'MA_PyblsRcvblsDetails          'Stand by
        'MA_SaleDoc                     'Aggiunta
        'MA_SaleDocDetail               'Aggiunta
        'MA_SaleDocPymtSched            'Aggiunta
        'MA_SaleOrd                     'Aggiunta
        'MA_SaleOrdDetails              'Aggiunta
        'MA_Workers                     'Esclusa
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_CostCenters"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
            Case "MA_Jobs"
                lIDS.Add(New IDS With {.IdString = PrefissoCespiti, .Nome = "Contract", .Operatore = IdsOp.Prefisso, .MaxSize = 10})
        End Select

        Return lIDS
    End Function
    ''' <summary>
    ''' Solo Partite Cliente Aperte
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsPartite(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim PymtSchedId As Integer
        Dim SaleDocId As Integer
        Dim PurchaseDocId As Integer
        Dim found As Integer = dv.Find("PymtSchedId")
        If found = -1 Then
            Debug.Print("Partite PymtSchedId: non trovato")
            ScriviLog("Partite PymtSchedId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Partite PymtSchedId: non trovato nel file IDS")
                End
            End If
        Else
            Dim foundVen As Integer = dv.Find("SaleDocId")
            If foundVen = -1 Then
                Debug.Print("Partite SaleDocId: non trovato")
                ScriviLog("Partite SaleDocId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare,Partite SaleDocId: non trovato nel file IDS")
                    End
                End If
            Else
                Dim foundAcq As Integer = dv.Find("PurchaseDocId")
                If foundAcq = -1 Then
                    Debug.Print("Partite PurchaseDocId: non trovato")
                    ScriviLog("Partite PurchaseDocId: non trovato")
                    If Not IsDebugging Then
                        MessageBox.Show("Impossibile continuare,Partite PurchaseDocId: non trovato nel file IDS")
                        End
                    End If
                Else
                    PymtSchedId = CInt(dv(found)("NewKey"))
                    SaleDocId = CInt(dv(foundVen)("NewKey"))
                    PurchaseDocId = CInt(dv(foundAcq)("NewKey"))
                    Select Case tablename
                        Case "MA_PyblsRcvbls"
                            lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                        Case "MA_PyblsRcvblsDetails"
                            lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "PresentationJEId", .Operatore = IdsOp.Sovrascrivi})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                            lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DocumentId", .Operatore = IdsOp.SommaCondizionata, .IdSecondario = PurchaseDocId, .Clausola_IsString = False, .Clausola_Nome = "DocumentId = 0 THEN 0 ELSE (CASE WHEN DocumentType", .Clausola_ControlloZero = True, .Clausola_ValoreInt = IdType.DocVend}) ' = id Documento di ven/acq
                            'lIDS.Add(New IDS With {.Id = 0, .Nome = "DocumentType", .Operatore = IdsOp.Uguale})  '=3801088 = Documenti Di vendita
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "CollectionJEId", .Operatore = IdsOp.Sovrascrivi})
                            'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                            lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "CostCenter", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                            'RIBA -> Nulla da modificare
                            'Mandato RID -> Nulla da Modificare
                    End Select
                End If
            End If
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Parcelle
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsParcelle(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim FeeId As Integer
        Dim PymtSchedId As Integer
        Dim found As Integer = dv.Find("FeeId")
        If found = -1 Then
            Debug.Print("Parcelle FeeId: non trovato")
            ScriviLog("Parcelle FeeId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Parcelle FeeId: non trovato nel file IDS")
                End
            End If
        Else
            Dim foundScad As Integer = dv.Find("PymtSchedId")
            If foundScad = -1 Then
                Debug.Print("Parcelle PymtSchedId: non trovato")
                ScriviLog("Parcelle PymtSchedId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare,Parcelle PymtSchedId: non trovato nel file IDS")
                    End
                End If
            Else
                FeeId = CInt(dv(found)("NewKey"))
                PymtSchedId = CInt(dv(foundScad)("NewKey"))
                Select Case tablename
                    Case "MA_Fees"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = FeeId, .Nome = "FeeId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "TransferJournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ClosingJournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = PymtSchedId, .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    Case "MA_FeesDetails"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = FeeId, .Nome = "FeeId", .Operatore = IdsOp.Somma})
                End Select
            End If
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Aperture 'BIA'
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsApertura(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim JournalEntryId As Integer
        Dim found As Integer = dv.Find("JournalEntryId")
        If found = -1 Then
            Debug.Print("Apertura JournalEntryId: non trovato")
            ScriviLog("Apertura JournalEntryId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Apertura JournalEntryId: non trovato nel file IDS")
                End
            End If
        Else
            JournalEntryId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_JournalEntries"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = JournalEntryId, .Nome = "JournalEntryId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = CausaleBIA, .Nome = "AccTpl", .UseCase = True, .FirtsCase = "BIA", .Operatore = IdsOp.Sovrascrivi, .MaxSize = 8})
                    lIDS.Add(New IDS With {.IdString = "A", .Nome = "RefNo", .Operatore = IdsOp.Inserisci, .PosizioneInsert = 4, .MaxSize = 8})
                    lIDS.Add(New IDS With {.Id = TipoPNota.Normale, .Nome = "CodeType", .Operatore = IdsOp.Sovrascrivi})
                Case "MA_JournalEntriesGLDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = JournalEntryId, .Nome = "JournalEntryId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = ContoFusione, .Nome = "Account", .UseCase = True, .FirtsCase = ContoBilancioApertura, .MaxSize = 16, .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.IdString = CausaleBIA, .Nome = "AccRsn", .UseCase = True, .FirtsCase = "BIA", .Operatore = IdsOp.Sovrascrivi, .MaxSize = 8})
                    lIDS.Add(New IDS With {.Id = TipoPNota.Normale, .Nome = "CodeType", .Operatore = IdsOp.Sovrascrivi})
            End Select
        End If

        Return lIDS
    End Function
    ''' <summary>
    ''' Riferimenti Incrociati
    ''' </summary>
    Private Function IdsCrossRef(ByVal dv As DataView, ByVal tablename As TabelleDaEstrarre) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim PymtSchedId As Integer
        Dim SaleDocId As Integer
        Dim SaleOrdId As Integer
        Dim PurchaseDocId As Integer
        Dim PurchaseOrdId As Integer
        Dim FeeId As Integer
        Dim ok As Boolean = True

#Region "Controllo presenza ids"
        Dim f As Integer = dv.Find("PymtSchedId")
        If f = -1 Then
            Debug.Print("Crossref PymtSchedId: non trovato")
            ScriviLog("Crossref PymtSchedId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref PymtSchedId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fVen As Integer = dv.Find("SaleDocId")
        If fVen = -1 Then
            Debug.Print("Crossref SaleDocId: non trovato")
            ScriviLog("Crossref SaleDocId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref SaleDocId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fOrdCli As Integer = dv.Find("SaleOrdId")
        If fOrdCli = -1 Then
            Debug.Print("Crossref SaleOrdId: non trovato")
            ScriviLog("Crossref SaleOrdId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref SaleOrdId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fAcq As Integer = dv.Find("PurchaseDocId")
        If fAcq = -1 Then
            Debug.Print("Crossref PurchaseDocId: non trovato")
            ScriviLog("Crossref PurchaseDocId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref PurchaseDocId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fOrdFor As Integer = dv.Find("PurchaseOrdId")
        If fOrdCli = -1 Then
            Debug.Print("Crossref PurchaseOrdId: non trovato")
            ScriviLog("Crossref PurchaseOrdId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Ordini PurchaseOrdId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fParcella As Integer = dv.Find("FeeId")
        If fParcella = -1 Then
            Debug.Print("Crossref FeeId: non trovato")
            ScriviLog("Crossref FeeId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref FeeId: non trovato nel file IDS")
                End
            End If
        End If
#End Region

        If ok Then
            PymtSchedId = CInt(dv(f)("NewKey"))
            SaleDocId = CInt(dv(fVen)("NewKey"))
            SaleOrdId = CInt(dv(fOrdCli)("NewKey"))
            PurchaseDocId = CInt(dv(fAcq)("NewKey"))
            PurchaseOrdId = CInt(dv(fOrdFor)("NewKey"))
            FeeId = CInt(dv(fParcella)("NewKey"))
            Dim cr As New AccoppiamentiCrossReference
            Select Case tablename.Coppia_CR.id
                Case cr.OrdCli_NdC.id, cr.OrdCli_FatImmm.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.OrdFor_BdC.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PurchaseDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.DDT_FatImm.id, cr.FatImm_FatImm.id, cr.FatImm_NdC.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.FatImm_ParCli.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PymtSchedId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.NdC_OrdCli.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.BdC_ResFor.id, cr.BdC_FatImm.id, cr.BdC_NdCRic.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.ParFor_NdCRic.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PurchaseDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.ParCli_NdC.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.Parc_ParFor.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = FeeId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PymtSchedId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case Else
                    MessageBox.Show("Coppia non trovata")

            End Select
        End If

        Return lIDS
    End Function
End Module