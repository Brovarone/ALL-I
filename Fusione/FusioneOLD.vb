Imports System
Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Module FusioneOLD

    ''' <summary>
    ''' 
    ''' 
    ''' TROPPO ESOSO DI MEMORIA
    ''' Segnala Out Of Memory sui dati della allsystem
    ''' 
    ''' 
    ''' 
    ''' </summary>
    ''' 
    Private dsOrigin As DataSet
    Private dsDestination As DataSet
    Private dtIDS As DataTable
    Private dtNewIds As DataTable
    Private dvNewIds As DataView
    Const PrefissoCespiti As String = "A"
    Const Prefisso As String = "1"
    Const Suffisso As String = "1"
    Const ContropartitaAcquisto As String = "3ACQ"

    Private Class TabelleDaEstrarre
        Public Property Filtro As String
        Public Property Nome As String
        Public Sub New()
            Filtro = ""
            Nome = ""
        End Sub
    End Class

    Public Function EseguiFusioneOLD(dts As DataSet) As Boolean
        Dim ok As Boolean
        Dim someTrouble As Boolean

        ok = EstraiDati()
        If Not ok Then someTrouble = True
        dtIDS = dts.Tables("IDS")
        ok = ModificaDati()
        If Not ok Then someTrouble = True
        ok = ScriviDati()
        If Not ok Then someTrouble = True

        Return someTrouble
    End Function

    ''' <summary>
    ''' Estraggo i dati
    ''' </summary>
    ''' <returns></returns>
    Private Function EstraiDati() As Boolean
        EditTestoBarra("Estraggo dati")
        Dim errori As New StringBuilder()
        Dim avvisi As New StringBuilder()
#Region "Elenco Tabelle"
        Dim qry As String = "SELECT * FROM "
        Dim tabelle = New List(Of TabelleDaEstrarre)
        Dim tabelleNoEdit = New List(Of TabelleDaEstrarre)
#Region "Fatture"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDoc", .Filtro = ""})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocComponents"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocDetail"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocManufReasons"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocNotes"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocPymtSched"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocReferences"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocShipping"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocSummary"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocTaxSummary"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EIEventViewer"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITDocAdditionalData"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITAsyncComm"})
#End Region
#Region "Acquisti ( solo bolle di carico)"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDoc", .Filtro = qry & "MA_PurchaseDoc WHERE DocumentType =  9830400"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocDetail"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocNotes"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocPymtSched"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocReferences"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocShipping"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocSummary"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocTaxSummary"})
#End Region
#Region "Ordini Clienti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrd", .Filtro = ""})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdComponents"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdDetails"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdNotes"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdPymtSched"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdReferences"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdShipping"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdSummary"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdTaxSummary"})
        'Tabelle Personalizzate ALLSYSTEM UNO
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliAcc"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliAttivita"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliContratto"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliDescrizioni"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliTipologiaServizi"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdFiglio"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdPadre"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLCespiti"})

#End Region
#Region "Cespiti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssets", .Filtro = qry & "MA_FixedAssets WHERE DisposalType <> 7143424"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsBalance"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsCoeff"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFinancial"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFiscal"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsPeriod"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetLocations"})
#End Region
#Region "Analitica ( Centri di Costo + Commesse)"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CostCenters"})

#End Region
#Region "Agenti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Areas"})
#End Region
#Region "Clienti : Dichiarazioni di Intento"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_DeclarationOfIntent"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppCustomerOptions", .Filtro = qry & "MA_CustSuppCustomerOptions WHERE CustSuppType=" & CustSuppType.Cliente})

#End Region
#Region "Magazzino : Articoli"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Items"})
#End Region

#Region "Note"
        '--Tabelle della UNO a 0 Records
        'MA_ItemCodes
        'MA_ItemCustomersBudget
        'MA_ItemCustomersPriceLists
        'MA_ItemsAnalysisParameters
        'MA_ItemsBRFiscalCtg
        'MA_ItemsBRTaxes
        'MA_ItemsComparableUoM
        'MA_ItemsConai
        'MA_ItemsLanguageDescri
        'MA_ItemsLocations
        'MA_ItemsLocationsMonthly
        'MA_ItemsManufacturingData
        'MA_ItemsMaterials
        'MA_ItemsPriceLists
        'MA_ItemsPurchaseBarCode
        'MA_ItemsStorageRetailPrices
        'MA_ItemsTechDataDefinition
        'MA_ItemsTechnicalData
        'MA_ItemSuppliersOperations
        'MA_ItemsWMS
        'MA_ItemsWMSZones
        'MA_ItemToCtgAssociations
        'MA_ItemTypeBudget
        'MA_ItemTypeCustomers
        'MA_ItemTypeCustomersBudget
        'MA_ItemTypeSuppliers

        '-- Da gestire
        '21335 MA_Items   
        '13 MA_ItemCustomers
        '80 MA_ItemNotes
        'xxx MA_ItemsGoodsData
        'xxx MA_ItemsIntrastat
        'xxx MA_ItemsKit
        '3 MA_ItemsSubstitute
        '30 MA_ItemTypes
        '?? NON HO I CODICI FORNITORE
        'xxx MA_ItemSuppliers
        'xxx MA_ItemSuppliersPriceLists

        '-- Da riebolare
        'xxx MA_ItemsFiscalData
        'xxx MA_ItemsFiscalDataDomCurr

        '-- Da gestire a mano
        '1 MA_ItemParameters

        '--Da non Importare
        'xxx MA_ItemsFIFO
        'xxx MA_ItemsFIFODomCurr
        'xxx MA_ItemsLIFO
        'xxx MA_ItemsLIFODomCurr
        'xxx MA_ItemsMonthlyBalances                       
        'xxx MA_ItemsStorageQty
        'xxx MA_ItemsStorageQtyMonthly
#End Region

#End Region

        '''''''''''''''''''''''
        ''''NESSUNA MODIFICA'''
        '''''''''''''''''''''''
#Region "Clienti"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .Filtro = qry & "MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppBranches", .Filtro = qry & "MA_CustSuppBranches WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNaturalPerson", .Filtro = qry & "MA_CustSuppNaturalPerson WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNotes", .Filtro = qry & "MA_CustSuppNotes WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppOutstandings", .Filtro = qry & "MA_CustSuppOutstandings WHERE CustSuppType=" & CustSuppType.Cliente}) ' Insoluti
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppPeople", .Filtro = qry & "MA_CustSuppPeople WHERE CustSuppType=" & CustSuppType.Cliente})
        '
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_SDDMandate"})
#End Region
#Region "Banche"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Banks", .Filtro = qry & "MA_Banks WHERE IsACompanyBank = 0"})
#End Region
#Region "Analitica (CdC + Commesse)"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Jobs"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_JobGroups"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_JobsLang"})
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_JobsBalances"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CostCenterGroups"}) ' nessuna modifica

#End Region
#Region "Cespiti Classi e Categorie"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetsClasses"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetsCtg"})
#End Region
#Region "Ordini - Dati Allsystem"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLAttivita"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLDescrizioni"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLTipoRigaServizio"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLNoteFoxPro"})
#End Region
#Region " Articoli"

        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemCustomers"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemNotes"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsGoodsData"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsIntrastat"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsKit"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsSubstitute"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemTypes"})
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemSuppliers"})
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemSuppliersPriceLists"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalData", .Filtro = qry & "MA_ItemsFiscalData WHERE FiscalYear = 2022"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalDataDomCurr", .Filtro = qry & "MA_ItemsFiscalDataDomCurr WHERE FiscalYear = 2022"})

#End Region
#Region "Magazzino : Depositi"
        'Da Export di mago tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Storages"})
#End Region
#Region "Agenti"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_SalesPeople"})
#End Region


        dsOrigin = New DataSet
        dsDestination = New DataSet
        Try
            FLogin.prgCopy.Value = 0
            FLogin.prgCopy.Step = 1
            FLogin.prgCopy.Maximum = tabelle.Count + tabelleNoEdit.Count
            Dim stopwatch As New System.Diagnostics.Stopwatch
            stopwatch.Start()

            For Each t In tabelle
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico dati: " & t.Nome)
                Using dt As DataTable = CaricaSchema(t.Nome, False, True, t.Filtro)
                    dsOrigin.Tables.Add(dt)
                End Using
                AvanzaBarra()
            Next
            'Li metto in dsDestination
            For Each t In tabelleNoEdit
                EditTestoBarra("Carico dati: " & t.Nome)
                Using dt As DataTable = CaricaSchema(t.Nome, False, True, t.Filtro)
                    dsDestination.Tables.Add(dt)
                End Using
                AvanzaBarra()
            Next
            'Carico IDS da database di destinazione
            Using adpIDS As New SqlDataAdapter("Select * FROM MA_IDNumbers", ConnDestination)
                dtNewIds = New DataTable
                adpIDS.Fill(dtNewIds)
                dvNewIds = New DataView(dtNewIds, "", "CodeType", DataViewRowState.CurrentRows)
            End Using

            stopwatch.Stop()
            Debug.Print(stopwatch.Elapsed.ToString)
            FLogin.lstStatoConnessione.Items.Add("Estrazione dati eseguita in : " & stopwatch.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Eseguo le modifiche ai dati
    ''' </summary>
    ''' <returns></returns>
    Private Function ModificaDati() As Boolean
        Dim ok As Boolean
        Dim someTrouble As Boolean

        Dim dvIDS = New DataView(dtIDS, "", "Key", DataViewRowState.CurrentRows)
        FLogin.prgCopy.Value = 0
        FLogin.prgCopy.Step = 1
        FLogin.prgCopy.Maximum = 8
        FLogin.lstStatoConnessione.Items.Add("Modifiche ai dati in corso...")
        AvanzaBarra()

        EditTestoBarra("Modifiche: Documenti Vendita")
        ok = EditFatture(dvIDS)
        AvanzaBarra()
        If Not ok Then someTrouble = True
        EditTestoBarra("Modifiche: Documenti Acquisto")
        ok = EditAcquisti(dvIDS)
        AvanzaBarra()
        If Not ok Then someTrouble = True
        EditTestoBarra("Modifiche: Analitica")
        ok = EditCentriDiCosto()
        AvanzaBarra()
        If Not ok Then someTrouble = True
        EditTestoBarra("Modifiche: Ordini Clienti")
        ok = EditOrdiniClienti(dvIDS)
        AvanzaBarra()
        If Not ok Then someTrouble = True
        EditTestoBarra("Modifiche: Cespiti")
        ok = EditCespiti()
        AvanzaBarra()
        If Not ok Then someTrouble = True
        EditTestoBarra("Modifiche: Agenti")
        ok = EditAgenti()
        AvanzaBarra()
        If Not ok Then someTrouble = True
        EditTestoBarra("Modifiche: Clienti")
        ok = EditClienti(dvIDS)
        AvanzaBarra()
        If Not ok Then someTrouble = True
        EditTestoBarra("Modifiche: Articoli")
        ok = EditArticoli()
        AvanzaBarra()
        If Not ok Then someTrouble = True

        Return someTrouble
    End Function
    ''' <summary>
    ''' Incremento SaleDocId sulle tabelle delle Vendite
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function EditFatture(ByVal dv As DataView) As Boolean

        Dim lIDS As New List(Of IDS)
        Dim saleDocId As Integer
        Dim found As Integer = dv.Find("SaleDocId")
        If found = -1 Then
            Debug.Print("Fatture SaleDocId: non trovato")
            My.Application.Log.WriteEntry("Fatture SaleDocId: non trovato")
            MessageBox.Show("Impossibile continuare,Fatture SaleDocId: non trovato nel file IDS")
            End
        Else
            saleDocId = CInt(dv(found)("NewKey"))
            Dim lastId As Integer = dtNewIds(dvNewIds.Find(IdType.DocVend)).Item("LastId")
            dtNewIds(dvNewIds.Find(IdType.DocVend)).Item("LastId") = lastId + saleDocId
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = saleDocId,
                .Nome = "SaleDocId",
                .Operatore = "+"
            })
            lIDS.Add(New IDS With {
              .Id = 0,
              .Nome = "PymtSchedId",
              .Operatore = "="
            })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "JournalEntryId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "IntrastatId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "InvEntryId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "AdvancePymtSchedId",
            .Operatore = "="
          })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "CorrectionDocumentId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "CorrectedDocumentId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
           .Id = 0,
           .Nome = "InventoryIDReturn",
           .Operatore = "="
         })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "ParagonID",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ProFormaInvoiceID",
            .Operatore = "="
          })
            lIDS.Add(New IDS With {
           .Id = 0,
           .Nome = "PureJECollectionPaymentId",
           .Operatore = "="
         })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "CorrectionDocumentIdInCN",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
           .Id = 0,
           .Nome = "WorkerIDIssue",
           .Operatore = "="
         })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ExtAccAEID",
            .Operatore = "="
          })
            'Aggiungo campo aggiuntivo cost center
            lIDS.Add(New IDS With {
                .IdString = Prefisso,
                .Nome = "CostCenter",
                .Operatore = "ADD"
            })
            lIDS.Add(New IDS With {
                .IdString = Suffisso,
                .Nome = "Area",
                .Operatore = "END"
            })
        End If

        Try
            'Fatture
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDoc"), lIDS))

            lIDS.Clear()
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = saleDocId,
                .Nome = "SaleDocId",
                .Operatore = "+"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocComponents"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocManufReasons"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocNotes"), lIDS))
            'dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocReferences"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocShipping"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocSummary"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocTaxSummary"), lIDS))
            '  dsDestination.Tables.Add( EditId(dsOrigin.Tables( "MA_EIEventViewer"), lIDS))
            '  dsDestination.Tables.Add( EditId(dsOrigin.Tables( "MA_EI_ITDocAdditionalData"), lIDS))
            '  dsDestination.Tables.Add( EditId(dsOrigin.Tables( "MA_EI_ITAsyncComm"), lIDS))
            'Aggiungo campo aggiuntivo cost center
            lIDS.Add(New IDS With {
                .IdString = Prefisso,
                .Nome = "CostCenter",
                .Operatore = "ADD"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocPymtSched"), lIDS))
            Dim fOrdine As Integer = dv.Find("SaleOrdId")
            If fOrdine = -1 Then
                Debug.Print("Fatture: SaleOrdId: non trovato")
                My.Application.Log.WriteEntry("Fatture: SaleOrdId: non trovato")
                MessageBox.Show("Impossibile continuare, Fatture: SaleOrdId: non trovato nel file IDS")
                End
            Else
                lIDS.Add(New IDS With {
                         .Id = CInt(dv(fOrdine)("NewKey")),
                        .Nome = "SaleOrdId",
                        .Operatore = "+"
                        })
            End If
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "MOId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ReturnFromCustomerId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ReferenceDocumentId",
            .Operatore = "="
             })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "DocIdToBeUnloaded",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "InvoiceId",
            .Operatore = "="
             })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "InvoiceForAdvanceID",
            .Operatore = "="
             })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ProFormaInvoiceID",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "CRRefID",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "TRId",
            .Operatore = "="
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocDetail"), lIDS))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Incremento PurchaseDocId sulle sole Bolle di Carico
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function EditAcquisti(ByVal dv As DataView) As Boolean

        Dim lIDS As New List(Of IDS)
        Dim PurchaseDocId As Integer
        Dim found As Integer = dv.Find("PurchaseDocId")
        If found = -1 Then
            Debug.Print("Acquisti PurchaseDocId: non trovato")
            My.Application.Log.WriteEntry("Acquisti PurchaseDocId: non trovato")
            MessageBox.Show("Impossibile continuare, Acquisti PurchaseDocId: non trovato nel file IDS")
            End
        Else
            PurchaseDocId = CInt(dv(found)("NewKey"))
            Dim lastId As Integer = dtNewIds(dvNewIds.Find(IdType.DocVend)).Item("LastId")
            dtNewIds(dvNewIds.Find(IdType.DocAcq)).Item("LastId") = lastId + PurchaseDocId
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = PurchaseDocId,
                .Nome = "PurchaseDocId",
                .Operatore = "+"
            })
            lIDS.Add(New IDS With {
              .Id = 0,
              .Nome = "PymtSchedId",
              .Operatore = "="
            })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "JournalEntryId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "IntrastatId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "InvEntryId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
              .Id = 0,
              .Nome = "RMAId",
              .Operatore = "="
            })
            lIDS.Add(New IDS With {
              .Id = 0,
              .Nome = "InspectionOrdId",
              .Operatore = "="
            })
            lIDS.Add(New IDS With {
              .Id = 0,
              .Nome = "ScrapInvEntryId",
              .Operatore = "="
            })
            lIDS.Add(New IDS With {
              .Id = 0,
              .Nome = "ReturnInvEntryId",
              .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "AdvancePymtSchedId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "AdjValueOnlyInvEntryId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "CorrectionDocumentId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "CorrectedDocumentId",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
           .Id = 0,
           .Nome = "PureJECollectionPaymentId",
           .Operatore = "="
         })
            lIDS.Add(New IDS With {
             .Id = 0,
             .Nome = "CorrectionDocumentIdInCN",
             .Operatore = "="
           })
            lIDS.Add(New IDS With {
           .Id = 0,
           .Nome = "WorkerIDIssue",
           .Operatore = "="
         })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "PureJETaxTransferId",
            .Operatore = "="
          })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ExtAccAEID",
            .Operatore = "="
          })
            ''Campi accessori
            lIDS.Add(New IDS With {
               .IdString = Prefisso,
               .Nome = "CostCenter",
               .Operatore = "ADD"
           })
        End If

        Try
            'Acquisti
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_PurchaseDoc"), lIDS))

            lIDS.Clear()
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = PurchaseDocId,
                .Nome = "PurchaseDocId",
                .Operatore = "+"
            })
            'Filtro e edito in un colpo solo
            dsDestination.Tables.Add(EditId(FilterRows(dsOrigin.Tables("MA_PurchaseDocNotes"), dsOrigin.Tables("MA_PurchaseDoc"), "PurchaseDocId"), lIDS))
            'dsDestination.Tables.Add(EditId(FilterRows(dsOrigin.Tables("MA_PurchaseDocReferences"), dsOrigin.Tables("MA_PurchaseDoc"), "PurchaseDocId"), lIDS))
            dsDestination.Tables.Add(EditId(FilterRows(dsOrigin.Tables("MA_PurchaseDocShipping"), dsOrigin.Tables("MA_PurchaseDoc"), "PurchaseDocId"), lIDS))
            dsDestination.Tables.Add(EditId(FilterRows(dsOrigin.Tables("MA_PurchaseDocSummary"), dsOrigin.Tables("MA_PurchaseDoc"), "PurchaseDocId"), lIDS))
            dsDestination.Tables.Add(EditId(FilterRows(dsOrigin.Tables("MA_PurchaseDocTaxSummary"), dsOrigin.Tables("MA_PurchaseDoc"), "PurchaseDocId"), lIDS))

            'Aggiungo campo aggiuntivo cost center
            lIDS.Add(New IDS With {
                .IdString = Prefisso,
                .Nome = "CostCenter",
                .Operatore = "ADD"
            })
            dsDestination.Tables.Add(EditId(FilterRows(dsOrigin.Tables("MA_PurchaseDocPymtSched"), dsOrigin.Tables("MA_PurchaseDoc"), "PurchaseDocId"), lIDS))

            Dim fOrdine As Integer = dv.Find("PurchaseOrdId")
            If fOrdine = -1 Then
                Debug.Print("Acquisti: PurchaseOrdId: non trovato")
                My.Application.Log.WriteEntry("Acquisti: PurchaseOrdId: non trovato")
                MessageBox.Show("Impossibile continuare, Acquisti: PurchaseOrdId: non trovato nel file IDS")
                End
            Else
                lIDS.Add(New IDS With {
                         .Id = CInt(dv(fOrdine)("NewKey")),
                        .Nome = "PurchaseOrdId",
                        .Operatore = "+"
                        })
            End If
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "InspectionOrdId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "InspectionBillId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "RMAId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "BillOfLadingId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "MOId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ReferenceDocId",
            .Operatore = "="
             })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "SaleDocId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ReferenceDocumentId",
            .Operatore = "="
             })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "InvoiceForAdvanceID",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "CRRefID",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "SuppQuotaId",
            .Operatore = "="
            })
            dsDestination.Tables.Add(EditId(FilterRows(dsOrigin.Tables("MA_PurchaseDocDetail"), dsOrigin.Tables("MA_PurchaseDoc"), "PurchaseDocId"), lIDS))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso UNO ai Cepiti e Ubicazioni
    ''' </summary>
    ''' <returns></returns>
    Private Function EditCespiti() As Boolean
        'dati presenti in 4 tabelle
        'MA_FixAssetEntriesDetail   'Esclusa
        'MA_FixedAssets
        'MA_FixedAssetsBalance      'Esclusa
        'MA_FixedAssetsFiscal       'Esclusa
        Try
            Dim lIDS As New List(Of IDS)
            lIDS.Add(New IDS With {
                .Chiave = True,
                .IdString = PrefissoCespiti,
                .Nome = "FixedAsset",
                .Operatore = "ADD"
            })
            lIDS.Add(New IDS With {
                .IdString = Suffisso,
                .Nome = "Location",
                .Operatore = "END"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_FixedAssets"), lIDS))

            lIDS.Clear()
            lIDS.Add(New IDS With {
                .Chiave = True,
                .IdString = Suffisso,
                .Nome = "Location",
                .Operatore = "END"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_FixAssetLocations"), lIDS))

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function EditArticoli() As Boolean
        Try
            Dim lIDS As New List(Of IDS)
            lIDS.Add(New IDS With {
                .IdString = ContropartitaAcquisto,
                .Nome = "PurchaseOffset",
                .Operatore = "SAVE"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_Items"), lIDS))

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function EditAgenti() As Boolean
        Try
            Dim lIDS As New List(Of IDS)
            lIDS.Add(New IDS With {
                .Chiave = True,
                .IdString = Suffisso,
                .Nome = "Area",
                .Operatore = "END"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_Areas"), lIDS))

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' Dichiarazioni di Intento
    ''' </summary>
    ''' <returns></returns>
    Private Function EditClienti(ByVal dv As DataView) As Boolean
        Dim lIDS As New List(Of IDS)
        Dim DeclId As Integer
        Dim found As Integer = dv.Find("DeclId")
        If found = -1 Then
            Debug.Print("Clienti DeclId: non trovato")
            My.Application.Log.WriteEntry("Clienti DeclId: non trovato")
            MessageBox.Show("Impossibile continuare, Clienti DeclId: non trovato nel file IDS")
            End
        Else
            DeclId = CInt(dv(found)("NewKey"))
            Dim lastId As Integer = dtNewIds(dvNewIds.Find(IdType.DicIntento)).Item("LastId")
            dtNewIds(dvNewIds.Find(IdType.DicIntento)).Item("LastId") = lastId + DeclId
            lIDS.Add(New IDS With {
                .Chiave = True,
                .IdString = 11,
                .Nome = "DeclId",
                .Operatore = "+"
                })
        End If

        Try
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_DeclarationOfIntent"), lIDS))
            lIDS.Clear()
            lIDS.Add(New IDS With {
                .IdString = Suffisso,
                .Nome = "Area",
                .Operatore = "END"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_CustSuppCustomerOptions"), lIDS))

            Return True

        Catch ex As Exception
            Return False
        End Try


    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso UNO ai Centri di Costo
    ''' </summary>
    ''' <returns></returns>
    Private Function EditCentriDiCosto() As Boolean
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
        Try
            Dim lIDS As New List(Of IDS)
            lIDS.Add(New IDS With {
                .Chiave = True,
                .IdString = Prefisso,
                .Nome = "CostCenter",
                .Operatore = "ADD"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_CostCenters"), lIDS))

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Incremento SaleOrdId sugli Ordini
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function EditOrdiniClienti(ByVal dv As DataView) As Boolean

        Dim lIDS As New List(Of IDS)
        Dim SaleOrdId As Integer
        Dim found As Integer = dv.Find("SaleOrdId")
        If found = -1 Then
            Debug.Print("Ordini SaleOrdId: non trovato")
            My.Application.Log.WriteEntry("Ordini SaleOrdId: non trovato")
            MessageBox.Show("Impossibile continuare,Ordini SaleOrdId: non trovato nel file IDS")
            End
        Else
            SaleOrdId = CInt(dv(found)("NewKey"))
            Dim lastId As Integer = dtNewIds(dvNewIds.Find(IdType.OrdCli)).Item("LastId")
            dtNewIds(dvNewIds.Find(IdType.OrdCli)).Item("LastId") = lastId + SaleOrdId
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = SaleOrdId,
                .Nome = "SaleOrdId",
                .Operatore = "+"
            })
        End If

        Try
            'Ordini
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdComponents"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdNotes"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdPymtSched"), lIDS))
            'dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdReferences"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdShipping"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdSummary"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdTaxSummary"), lIDS))

            'Aggiungo campo aggiuntivo Cost Center
            lIDS.Add(New IDS With {
                .IdString = Prefisso,
                .Nome = "CostCenter",
                .Operatore = "ADD"
            })
            lIDS.Add(New IDS With {
                .IdString = Suffisso,
                .Nome = "Area",
                .Operatore = "END"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrd"), lIDS))

            lIDS.RemoveAt(2)
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ProductionPlanId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ProductionJobId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ReferenceDocId",
            .Operatore = "="
             })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "ReferenceQuotationId",
            .Operatore = "="
            })
            lIDS.Add(New IDS With {
            .Id = 0,
            .Nome = "CRRefID",
            .Operatore = "="
             })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleOrdDetails"), lIDS))

            'Tabelle ALLSYSTEM UNO - Campo chiave diverso
            lIDS.Clear()
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = SaleOrdId,
                .Nome = "IdOrdCli",
                .Operatore = "+"
                })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLOrdCliDescrizioni"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLOrdCliContratto"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLOrdCliTipologiaServizi"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLOrdCliAttivita"), lIDS))
            lIDS.Add(New IDS With {
                .Id = SaleOrdId,
                .Nome = "IdOrdPadre",
                .Operatore = "+"
                })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLOrdPadre"), lIDS))

            lIDS.RemoveAt(1)

            lIDS.Add(New IDS With {
                .Id = SaleOrdId,
                .Nome = "IdOrdFiglio",
                .Operatore = "+"
                })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLOrdFiglio"), lIDS))

            lIDS.Clear()
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = SaleOrdId,
                .Nome = "IdOrdCli",
                .Operatore = "+"
                })
            lIDS.Add(New IDS With {
                .IdString = Prefisso,
                .Nome = "Cdc",
                .Operatore = "ADD"
                })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLOrdCliAcc"), lIDS))

            lIDS.Clear()
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = SaleOrdId,
                .Nome = "IdOrdCli",
                .Operatore = "+"
                })
            lIDS.Add(New IDS With {
                .IdString = PrefissoCespiti,
                .Nome = "Cespite",
                .Operatore = "ADD"
                })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("ALLCespiti"), lIDS))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function FilterRows(ByVal dt As DataTable, ByVal filter As DataTable, ByVal key As String) As DataTable
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim dv As DataView = filter.DefaultView
        dv.Sort = key
        Dim NewDt As DataTable = dt.Clone
        Try
            For Each r As DataRow In dt.Rows
                Dim found As Integer = dv.Find(r.Item(key))
                If found <> -1 Then NewDt.ImportRow(r)
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori durante il FiltroRows " & dt.TableName)
            Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        Return NewDt
    End Function
    Private Function EditId(ByVal dt As DataTable, id As List(Of IDS)) As DataTable
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim dv As DataView = dt.DefaultView
        Dim keyIDS As IDS = id.Find(Function(p) p.Chiave = True)
        If keyIDS IsNot Nothing Then dv.Sort = keyIDS.Nome & " desc"
        Dim iRow As Integer
        Try
            For Each r As DataRowView In dv
                iRow += 1
                For Each f As IDS In id
                    Select Case f.Operatore
                        Case "+"
                            r.Item(f.Nome) = CInt(r.Item(f.Nome)) + f.Id
                        Case ""
                            r.Item(f.Nome) = f.Id
                        Case "ADD", "END"
                            Dim lprefix As Short = f.IdString.Length
                            If r.Item(f.Nome).ToString.Length + lprefix > r.Row.Table.Columns(f.Nome).MaxLength Then
                                Dim msg As String = "Annullamento operazione: Riscontrati errori durante l'EditAddPrefix " & dt.TableName
                                FLogin.lstStatoConnessione.Items.Add(msg)
                                Dim mb As New MessageBoxWithDetails(msg & " " & dt.TableName, GetCurrentMethod.Name, "Valore troppo grosso " & r.Item(f.Nome) & " " & f.IdString)
                                mb.ShowDialog()
                                End
                            Else
                                If Not String.IsNullOrWhiteSpace(r.Item(f.Nome).ToString) Then
                                    If f.Operatore = "ADD" Then
                                        r.Item(f.Nome) = String.Concat(f.IdString, r.Item(f.Nome))
                                    Else
                                        'END" = Suffisso
                                        r.Item(f.Nome) = String.Concat(r.Item(f.Nome), f.IdString)
                                    End If
                                End If
                            End If
                        Case "SAVE"
                            If Not String.IsNullOrWhiteSpace(r.Item(f.Nome).ToString) AndAlso r.Item(f.Nome) <> f.IdString Then
                                r.Item(f.Nome) = String.Empty
                            End If
                        Case "="
                            r.Item(f.Nome) = f.Id
                    End Select

                Next
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrata exception durante l'EditId " & dt.TableName)
            Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        Debug.Print("Edit: " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        My.Application.Log.DefaultFileLogWriter.WriteLine("Edit: " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        Return dv.ToTable
    End Function

    Private Class IDS
        Public Property Chiave As Boolean
        Public Property Nome As String
        Public Property Id As Integer
        Public Property IdString As String
        Public Property Operatore As String

    End Class
    ''' <summary>
    ''' Eseguo la BULK INSERT dell'intero dataset nel database di destinazione
    ''' </summary>
    ''' <returns></returns>
    Private Function ScriviDati() As Boolean
        'dsDestination 
        'ConnectionSpa

        Dim msglog As String
        Dim loggingTxt As String = "Si"
        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()

        msglog = "Salvataggio dati in corso"
        My.Application.Log.DefaultFileLogWriter.WriteLine(msglog)
        FLogin.lstStatoConnessione.Items.Add(msglog)

        'Parametri
        'https://github.com/borisdj/EFCore.BulkExtensions

        Dim iStep As Integer
        Try

            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", ConnDestination)
                cmdqry.ExecuteNonQuery()
                Using bulkTrans = ConnDestination.BeginTransaction
                    'Ciclo su ogni tabella
                    FLogin.lstStatoConnessione.Items.Add("Scrittura dati in corso...")
                    FLogin.prgCopy.Maximum = dsDestination.Tables.Count
                    FLogin.prgCopy.Step = 1
                    FLogin.prgCopy.Value = 0
                    FLogin.prgCopy.Update()

                    For Each t As DataTable In dsDestination.Tables
                        iStep += 1
                        Dim s As String = t.TableName
                        EditTestoBarra("Salvataggio: " & s)
                        okBulk = ScriviBulk(s, t, bulkTrans, ConnDestination, DataRowState.Unchanged, loggingTxt, True)
                        If Not okBulk Then someTrouble = True
                        bulkMessage.AppendLine(loggingTxt)
                        AvanzaBarra()
                    Next

                    If someTrouble Then
                        FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                        bulkTrans.Rollback()
                    Else
                        bulkTrans.Commit()
                        Debug.Print("Commit !")
                    End If
                    Debug.Print("Fine bulk")
                End Using

                'Aggiorno la tabella degli IDS
                If Not someTrouble Then
                    Dim irows As Integer
                    Using updTrans = ConnDestination.BeginTransaction
                        EditTestoBarra("Aggiornamento IDS")
                        Using adpIDS As New SqlDataAdapter("Select * FROM MA_IDNumbers", ConnDestination)
                            Dim cbMar = New SqlCommandBuilder(adpIDS)
                            adpIDS.UpdateCommand = cbMar.GetUpdateCommand(True)
                            adpIDS.UpdateCommand.Transaction = updTrans

                            adpIDS.Fill(dtNewIds)
                            irows = adpIDS.Update(dtNewIds)
                            If irows > 0 Then
                                'Debug.Print("Aggiornamento IDS: " & irows.ToString & " record")
                            End If
                            Debug.Print("Aggiornamento IDS: " & irows.ToString & " record")
                            updTrans.Commit()
                        End Using
                    End Using
                End If
                cmdqry.CommandText = "DBCC TRACEOFF(610)"
                cmdqry.ExecuteNonQuery()
                Debug.Print("Fine update")
            End Using
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


        'Scrivo i Log
        If bulkMessage.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Inserimento Dati ---" & vbCrLf & bulkMessage.ToString)
        If errori.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Errori ---" & vbCrLf & errori.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
            Debug.Print(errori.ToString)
        End If

        Return Not someTrouble
    End Function

End Module