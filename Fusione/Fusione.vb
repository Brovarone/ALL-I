Imports System
Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Module Fusione

    'Tabelle database di origine
    Private dtIDS As DataTable
    Private dvIDS As DataView
    'Tabelle database di destinazione
    Private dtNewIds As DataTable
    Private dvNewIds As DataView
    Const PrefissoCespiti As String = "A"
    Const Prefisso As String = "1"
    Const Suffisso As String = "1"
    Const ContropartitaAcquisto As String = "3ACQ"
    'Contenitori delle tabelle da processare
    Private tabelle As List(Of TabelleDaEstrarre)
    Private tabelleNoEdit As List(Of TabelleDaEstrarre)
    Private listeIDs As List(Of ListaId)

    Private Class TabelleDaEstrarre
        Public Property QuerySelect As String
        Public Property Nome As String
        Public Property Paging As Boolean
        Public Property Gruppo As MacroGruppo
        Public Property GeneraListaId As Boolean
        Public Property PrimaryKey As String
        Public Sub New()
            QuerySelect = ""
            Nome = ""
            Paging = False
            Gruppo = MacroGruppo.Nessuno
            GeneraListaId = False
            PrimaryKey = ""
        End Sub
    End Class
    Private Class ListaId
        Public Property Ids As List(Of Integer)
        Public Property Nome As String
        Public Sub New()
            Ids = New List(Of Integer)
            Nome = ""
        End Sub
    End Class

    Friend Enum MacroGruppo As Integer
        Nessuno = 0
        Vendita = 1
        Acquisto = 2
        Analitica = 3
        OrdiniClienti = 4
        Cespiti = 5
        Agenti = 6
        Clienti = 7
        Articoli = 8
    End Enum
    Public Function EseguiFusione(dts As DataSet) As Boolean
        Dim ok As Boolean
        Dim someTrouble As Boolean

        'Popolo lista con le tabelle e cosa fare
        ok = EstraiTabelle()
        If Not ok Then someTrouble = True

        'Carico IDs da file xls partenza
        dtIDS = dts.Tables("IDS")
        dvIDS = New DataView(dtIDS, "", "Key", DataViewRowState.CurrentRows)
        'Carico IDS da database di destinazione
        Using adpIDS As New SqlDataAdapter("Select * FROM MA_IDNumbers", ConnDestination)
            dtNewIds = New DataTable
            adpIDS.FillSchema(dtNewIds, SchemaType.Source)
            adpIDS.Fill(dtNewIds)
            dvNewIds = New DataView(dtNewIds, "", "CodeType", DataViewRowState.CurrentRows)
        End Using

        'Processo una tabella alla volta
        listeIDs = New List(Of ListaId)
        Try
            Dim stopwatch As New System.Diagnostics.Stopwatch
            stopwatch.Start()
            FLogin.lstStatoConnessione.Items.Add("Processo tabelle in corso...")
            FLogin.prgCopy.Value = 0
            FLogin.prgCopy.Step = 1
            FLogin.prgCopy.Maximum = tabelle.Count + tabelleNoEdit.Count

            For Each t In tabelle
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico dati: " & t.Nome)
                Dim pageindex As Integer = 1
                Using dt As DataTable = CaricaDati(t, False, pageindex)
                    Dim newDt As New DataTable
                    If t.Paging Then
                        While t.Paging = True
                            newDt = ModificaDati(t, dt, ok)
                            If Not ok Then someTrouble = True
                            ok = ScriviDati(newDt, Not IsDebugging)
                            pageindex += 1
                            'Carica nuovi dati
                            CaricaDati(t, False, pageindex)
                        End While
                    End If
                    'Ultimo cilco while + Se non ho paging
                    newDt = New DataTable
                    newDt = ModificaDati(t, dt, ok)
                    If Not ok Then someTrouble = True
                    ok = ScriviDati(newDt, Not IsDebugging)

                End Using
                AvanzaBarra()
            Next
            'ciclo le tabelle senza Edit
            For Each t In tabelleNoEdit
                EditTestoBarra("Carico dati: " & t.Nome)
                Dim pageindex As Integer = 1
                Using dt As DataTable = CaricaDati(t, False, pageindex)
                    ok = ScriviDati(dt, Not IsDebugging)
                End Using
                AvanzaBarra()
            Next
            'Edit IDS
            If Not IsDebugging Then
                ok = ScriviIds(dvIDS)
                If Not ok Then someTrouble = True
            End If

            stopwatch.Stop()
            Debug.Print(stopwatch.Elapsed.ToString)
            FLogin.lstStatoConnessione.Items.Add("Fusione eseguita in : " & stopwatch.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
            Return False
        End Try

        Return someTrouble
    End Function

    ''' <summary>
    ''' Estraggo le tabelle
    ''' </summary>
    ''' <returns></returns>
    Private Function EstraiTabelle() As Boolean
        EditTestoBarra("Creazione elenco lavori")
        FLogin.lstStatoConnessione.Items.Add("Creazione elenco lavori")
#Region "Elenco Tabelle con modifiche"
        Dim qry As String = "SELECT * FROM "
        tabelle = New List(Of TabelleDaEstrarre)
        tabelleNoEdit = New List(Of TabelleDaEstrarre)
#Region "Fatture"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDoc", .QuerySelect = "", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocComponents", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocDetail", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocManufReasons", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocNotes", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocPymtSched", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocReferences", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocShipping", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocSummary", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocTaxSummary", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EIEventViewer", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITDocAdditionalData", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITAsyncComm", .Gruppo = MacroGruppo.Vendita})
#End Region
#Region "Acquisti ( solo bolle di carico)"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDoc", .QuerySelect = qry & "MA_PurchaseDoc WHERE DocumentType =  9830400", .Gruppo = MacroGruppo.Acquisto, .GeneraListaId = True, .PrimaryKey = "PurchaseDocId"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocDetail", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocNotes", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocPymtSched", .Gruppo = MacroGruppo.Acquisto})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocReferences", .Gruppo = MacroGruppo.acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocShipping", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocSummary", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocTaxSummary", .Gruppo = MacroGruppo.Acquisto})
#End Region
#Region "Ordini Clienti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrd", .QuerySelect = "", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdComponents", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdDetails", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdNotes", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdPymtSched", .Gruppo = MacroGruppo.OrdiniClienti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdReferences", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdShipping", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdSummary", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdTaxSummary", .Gruppo = MacroGruppo.OrdiniClienti})
        'Tabelle Personalizzate ALLSYSTEM UNO
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliAcc", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliAttivita", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliContratto", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliDescrizioni", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliTipologiaServizi", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdFiglio", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdPadre", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLCespiti", .Gruppo = MacroGruppo.OrdiniClienti})

#End Region
#Region "Cespiti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssets", .QuerySelect = qry & "MA_FixedAssets WHERE DisposalType <> 7143424", .Gruppo = MacroGruppo.Cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsBalance", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsCoeff", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFinancial", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFiscal", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsPeriod", .Gruppo = MacroGruppo.cespiti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetLocations", .Gruppo = MacroGruppo.Cespiti})
#End Region
#Region "Analitica ( Centri di Costo + Commesse)"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CostCenters", .Gruppo = MacroGruppo.Analitica})

#End Region
#Region "Agenti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Areas", .Gruppo = MacroGruppo.Agenti})
#End Region
#Region "Clienti : Dichiarazioni di Intento"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_DeclarationOfIntent", .Gruppo = MacroGruppo.Clienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppCustomerOptions", .QuerySelect = qry & "MA_CustSuppCustomerOptions WHERE CustSuppType=" & CustSuppType.Cliente, .Gruppo = MacroGruppo.Clienti})

#End Region
#Region "Magazzino : Articoli"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Items", .Gruppo = MacroGruppo.Articoli})
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
#Region "Nessuna modifica"
        '''''''''''''''''''''''
        ''''NESSUNA MODIFICA'''
        '''''''''''''''''''''''
#Region "Clienti"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .QuerySelect = qry & "MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppBranches", .QuerySelect = qry & "MA_CustSuppBranches WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNaturalPerson", .QuerySelect = qry & "MA_CustSuppNaturalPerson WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNotes", .QuerySelect = qry & "MA_CustSuppNotes WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppOutstandings", .QuerySelect = qry & "MA_CustSuppOutstandings WHERE CustSuppType=" & CustSuppType.Cliente}) ' Insoluti
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppPeople", .QuerySelect = qry & "MA_CustSuppPeople WHERE CustSuppType=" & CustSuppType.Cliente})
        '
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_SDDMandate"})
#End Region
#Region "Banche"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Banks", .QuerySelect = qry & "MA_Banks WHERE IsACompanyBank = 0"})
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
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalData", .QuerySelect = qry & "MA_ItemsFiscalData WHERE FiscalYear = 2022"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalDataDomCurr", .QuerySelect = qry & "MA_ItemsFiscalDataDomCurr WHERE FiscalYear = 2022"})

#End Region
#Region "Magazzino : Depositi"
        'Da Export di mago tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Storages"})
#End Region
#Region "Agenti"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_SalesPeople"})
#End Region
#End Region
        Return True
    End Function

    ''' <summary>
    ''' Eseguo le modifiche ai dati
    ''' </summary>
    ''' <returns></returns>
    Private Function ModificaDati(ByVal t As TabelleDaEstrarre, ByRef dt As DataTable, ByRef result As Boolean) As DataTable
        Dim ok As Boolean
        Dim newDt As New DataTable
        Select Case t.Gruppo
            Case MacroGruppo.Vendita
                EditTestoBarra("Modifiche: Documenti Vendita")
                newDt = EditVendite(dvIDS, dt, ok)
            Case MacroGruppo.Acquisto
                EditTestoBarra("Modifiche: Documenti Acquisto")
                'Logica diversa perche' ho un filtro
                newDt = EditAcquisti(dvIDS, dt, ok)
            Case MacroGruppo.Analitica
                EditTestoBarra("Modifiche: Analitica")
                newDt = EditCentriDiCosto(dt, ok)
            Case MacroGruppo.OrdiniClienti
                EditTestoBarra("Modifiche: Ordini Clienti")
                newDt = EditOrdiniClienti(dvIDS, dt, ok)
            Case MacroGruppo.Cespiti
                EditTestoBarra("Modifiche: Cespiti")
                newDt = EditCespiti(dt, ok)
            Case MacroGruppo.Agenti
                EditTestoBarra("Modifiche: Agenti")
                newDt = EditAgenti(dt, ok)
            Case MacroGruppo.Clienti
                EditTestoBarra("Modifiche: Clienti")
                newDt = EditClienti(dvIDS, dt, ok)
            Case MacroGruppo.Articoli
                EditTestoBarra("Modifiche: Articoli")
                newDt = EditArticoli(dt, ok)
        End Select

        If Not ok Then result = True

        Return newDt
    End Function
    Private Function ScriviIds(ByVal dv As DataView) As Boolean
        Try
            'Vendite
            Dim found As Integer = dv.Find("SaleDocId")
            Dim saleDocId As Integer = CInt(dv(found)("NewKey"))
            Dim lastId As Integer = dtNewIds(dvNewIds.Find(IdType.DocVend)).Item("LastId")
            AggiornaIDs(IdType.DocVend, lastId + saleDocId)
            'Acquisti
            found = dv.Find("PurchaseDocId")
            Dim PurchaseDocId As Integer = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.DocAcq)).Item("LastId")
            AggiornaIDs(IdType.DocAcq, lastId + PurchaseDocId)
            'Ordini Clienti
            found = dv.Find("SaleOrdId")
            Dim SaleOrdId = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.OrdCli)).Item("LastId")
            AggiornaIDs(IdType.OrdCli, lastId + SaleOrdId)
            'Ordini Fornitori
            found = dv.Find("PurchaseOrdId")
            Dim PurchaseOrdId = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.OrdFor)).Item("LastId")
            AggiornaIDs(IdType.OrdFor, lastId + PurchaseOrdId)
            'Dichiarazione di intento
            found = dv.Find("DeclId")
            Dim DeclId As Integer = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.DicIntento)).Item("LastId")
            AggiornaIDs(IdType.DicIntento, lastId + DeclId)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub AggiornaIDs(ByVal IdType As Integer, ByVal value As Integer, Optional ByRef MyReturnString As String = "")
        Using cmd = New SqlCommand("UPDATE MA_IDNumbers SET LastId =" & value.ToString & " WHERE CodeType=@CodeType",
                              ConnDestination)
            cmd.Transaction = Trans
            cmd.Parameters.AddWithValue("@CodeType", IdType)
            Dim irows As Integer = cmd.ExecuteNonQuery()
            If irows <= 0 Then
                cmd.CommandText = "INSERT INTO MA_IDNumbers (CodeType, LastId, TBCreatedID, TBModifiedID) VALUES (@CodeType, @Value, @TBCreatedID ,@TBModifiedID )"
                cmd.Parameters.AddWithValue("@Value", value)
                cmd.Parameters.AddWithValue("@TBCreatedID", My.Settings.mLOGINID)
                cmd.Parameters.AddWithValue("@TBModifiedID", My.Settings.mLOGINID)
                irows = cmd.ExecuteNonQuery()
            End If
        End Using
        Dim r As String = ReturnVarName(IdType, GetType(MagoNet.IdType))
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo ID scritto: " & value.ToString & " su tipo: " & r)
        Else
            MyReturnString = "Ultimo ID scritto: " & value.ToString & " su tipo: " & r
        End If
    End Sub
    ''' <summary>
    ''' Incremento SaleDocId sulle tabelle delle Vendite
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function EditVendite(ByVal dv As DataView, ByRef dt As DataTable, ByRef result As Boolean) As DataTable

        Dim lIDS As New List(Of IDS)
        Dim saleDocId As Integer
        Dim found As Integer = dv.Find("SaleDocId")
        Dim newDt As New DataTable
        If found = -1 Then
            Debug.Print("Vendite SaleDocId: non trovato")
            My.Application.Log.WriteEntry("Fatture SaleDocId: non trovato")
            MessageBox.Show("Impossibile continuare,Vendite SaleDocId: non trovato nel file IDS")
            End
        Else
            saleDocId = CInt(dv(found)("NewKey"))
            Select Case dt.TableName
                Case "MA_SaleDoc"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = saleDocId, .Nome = "SaleDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PymtSchedId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "IntrastatId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvEntryId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "AdvancePymtSchedId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectedDocumentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InventoryIDReturn", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ParagonID", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProFormaInvoiceID", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJECollectionPaymentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentIdInCN", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "WorkerIDIssue", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ExtAccAEID", .Operatore = "="})
                    'Aggiungo campo aggiuntivo cost center
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = "END"})
                Case "MA_SaleDocComponents", "MA_SaleDocManufReasons", "MA_SaleDocNotes", "MA_SaleDocShipping", "MA_SaleDocSummary", "MA_SaleDocTaxSummary"
                    '"MA_SaleDocReferences", "MA_EIEventViewer", "MA_EI_ITDocAdditionalData", "MA_EI_ITAsyncComm"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = saleDocId, .Nome = "SaleDocId", .Operatore = "+"})
                Case "MA_SaleDocPymtSched"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = saleDocId, .Nome = "SaleDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                Case "MA_SaleDocDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = saleDocId, .Nome = "SaleDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                    Dim fOrdine As Integer = dv.Find("SaleOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Fatture: SaleOrdId: non trovato")
                        My.Application.Log.WriteEntry("Fatture: SaleOrdId: non trovato")
                        MessageBox.Show("Impossibile continuare, Fatture: SaleOrdId: non trovato nel file IDS")
                        End
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fOrdine)("NewKey")), .Nome = "SaleOrdId", .Operatore = "+"})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReturnFromCustomerId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocumentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "DocIdToBeUnloaded", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceForAdvanceID", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProFormaInvoiceID", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "TRId", .Operatore = "="})
            End Select
            Try
                newDt = Edit(dt, lIDS)
                result = True
            Catch ex As Exception
                result = False
            End Try
        End If
        Return newDt
    End Function
    ''' <summary>
    ''' Incremento PurchaseDocId sulle sole Bolle di Carico
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function EditAcquisti(ByVal dv As DataView, ByRef dt As DataTable, ByRef result As Boolean) As DataTable

        Dim lIDS As New List(Of IDS)
        Dim PurchaseDocId As Integer
        Dim found As Integer = dv.Find("PurchaseDocId")
        Dim withFilter As Boolean
        Dim newDt As New DataTable
        If found = -1 Then
            Debug.Print("Acquisti PurchaseDocId: non trovato")
            My.Application.Log.WriteEntry("Acquisti PurchaseDocId: non trovato")
            MessageBox.Show("Impossibile continuare, Acquisti PurchaseDocId: non trovato nel file IDS")
            End
        Else
            PurchaseDocId = CInt(dv(found)("NewKey"))
            Select Case dt.TableName
                Case "MA_PurchaseDoc"
                    withFilter = False
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PymtSchedId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "IntrastatId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvEntryId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "RMAId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionOrdId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ScrapInvEntryId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReturnInvEntryId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "AdvancePymtSchedId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "AdjValueOnlyInvEntryId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectedDocumentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJECollectionPaymentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentIdInCN", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "WorkerIDIssue", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJETaxTransferId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ExtAccAEID", .Operatore = "="})
                    'Campi accessori
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                Case "MA_PurchaseDocNotes", "MA_PurchaseDocShipping", "MA_PurchaseDocSummary", "MA_PurchaseDocTaxSummary"
                    '"MA_PurchaseDocReferences"
                    withFilter = True
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = "+"})
                Case "MA_PurchaseDocPymtSched"
                    withFilter = True
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                Case "MA_PurchaseDocDetail"
                    withFilter = True
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                    Dim fOrdine As Integer = dv.Find("PurchaseOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Acquisti: PurchaseOrdId: non trovato")
                        My.Application.Log.WriteEntry("Acquisti: PurchaseOrdId: non trovato")
                        MessageBox.Show("Impossibile continuare, Acquisti: PurchaseOrdId: non trovato nel file IDS")
                        End
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fOrdine)("NewKey")), .Nome = "PurchaseOrdId", .Operatore = "+"})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionOrdId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionBillId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "RMAId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "BillOfLadingId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SaleDocId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocumentId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceForAdvanceID", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SuppQuotaId", .Operatore = "="})
            End Select
            Try
                'Filtro e edito in un colpo solo
                newDt = Edit(If(withFilter, FilterRows(dt, listeIDs.Find(Function(x) x.Nome.Contains("MA_PurchaseDoc")), "PurchaseDocId"), dt), lIDS)
                result = True
            Catch ex As Exception
                result = False
            End Try
        End If
        Return newDt
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso UNO ai Cepiti e Ubicazioni
    ''' </summary>
    ''' <returns></returns>
    Private Function EditCespiti(ByRef dt As DataTable, ByRef result As Boolean) As DataTable
        'dati presenti in 4 tabelle
        'MA_FixAssetEntriesDetail   'Esclusa
        'MA_FixedAssets
        'MA_FixedAssetsBalance      'Esclusa
        'MA_FixedAssetsFiscal       'Esclusa
        Dim lIDS As New List(Of IDS)
        Dim newDt As New DataTable
        Select Case dt.TableName
            Case "MA_FixedAssets"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = PrefissoCespiti, .Nome = "FixedAsset", .Operatore = "ADD"})
                lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Location", .Operatore = "END"})
            Case "MA_FixAssetLocations"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Location", .Operatore = "END"})
        End Select
        Try
            newDt = Edit(dt, lIDS)
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return newDt
    End Function
    ''' <summary>
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function EditArticoli(ByRef dt As DataTable, ByRef result As Boolean) As DataTable

        Dim lIDS As New List(Of IDS)
        Dim newDt As New DataTable
        Select Case dtIDS.TableName
            Case "MA_Items"
                lIDS.Add(New IDS With {.IdString = ContropartitaAcquisto, .Nome = "PurchaseOffset", .Operatore = "SAVE"})
        End Select
        Try
            newDt = Edit(dt, lIDS)
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return newDt
    End Function
    ''' <summary>
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function EditAgenti(ByRef dt As DataTable, ByRef result As Boolean) As DataTable
        Dim lIDS As New List(Of IDS)
        Dim newDt As New DataTable
        Select Case dtIDS.TableName
            Case "MA_Areas"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Area", .Operatore = "End"})
        End Select
        Try
            newDt = Edit(dt, lIDS)
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return newDt
    End Function
    ''' <summary>
    ''' Dichiarazioni di Intento
    ''' </summary>
    ''' <returns></returns>
    Private Function EditClienti(ByVal dv As DataView, ByRef dt As DataTable, ByRef result As Boolean) As DataTable
        Dim lIDS As New List(Of IDS)
        Dim newDt As New DataTable
        Select Case dt.TableName
            Case "MA_DeclarationOfIntent"
                Dim DeclId As Integer
                Dim found As Integer = dv.Find("DeclId")
                If found = -1 Then
                    Debug.Print("Clienti DeclId: non trovato")
                    My.Application.Log.WriteEntry("Clienti DeclId: non trovato")
                    MessageBox.Show("Impossibile continuare, Clienti DeclId: non trovato nel file IDS")
                    End
                Else
                    DeclId = CInt(dv(found)("NewKey"))
                    lIDS.Add(New IDS With {.Chiave = True, .Id = DeclId, .Nome = "DeclId", .Operatore = "+"})
                End If

            Case "MA_CustSuppCustomerOptions"
                lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = "END"})
        End Select
        Try
            newDt = Edit(dt, lIDS)
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return newDt
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso UNO ai Centri di Costo
    ''' </summary>
    ''' <returns></returns>
    Private Function EditCentriDiCosto(ByRef dt As DataTable, ByRef result As Boolean) As DataTable
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
        Dim newDt As New DataTable
        Select Case dtIDS.TableName
            Case "MA_CostCenters"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
        End Select
        Try
            newDt = Edit(dt, lIDS)
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return newDt
    End Function
    ''' <summary>
    ''' Incremento SaleOrdId sugli Ordini
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function EditOrdiniClienti(ByVal dv As DataView, dt As DataTable, ByRef result As Boolean) As DataTable
        Dim lIDS As New List(Of IDS)
        Dim SaleOrdId As Integer
        Dim found As Integer = dv.Find("SaleOrdId")
        Dim newDt As New DataTable
        If found = -1 Then
            Debug.Print("Ordini SaleOrdId: non trovato")
            My.Application.Log.WriteEntry("Ordini SaleOrdId: non trovato")
            MessageBox.Show("Impossibile continuare,Ordini SaleOrdId: non trovato nel file IDS")
            End
        Else
            SaleOrdId = CInt(dv(found)("NewKey"))
            Select Case dt.TableName
                Case "MA_SaleOrdComponents", "MA_SaleOrdNotes", "MA_SaleOrdPymtSched", "MA_SaleOrdShipping", "MA_SaleOrdSummary", "MA_SaleOrdTaxSummary"
                    '"MA_SaleOrdReferences"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = "+"})
                Case "MA_SaleOrd"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = "END"})
                Case "MA_SaleOrdDetails"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD"})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProductionPlanId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProductionJobId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceQuotationId", .Operatore = "="})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = "="})
                Case "ALLOrdCliDescrizioni", "ALLOrdCliContratto", "ALLOrdCliTipologiaServizi", "ALLOrdCliAttivita"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = "+"})
                Case "ALLOrdFiglio"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = "+"})
                    lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "IdOrdFiglio", .Operatore = "+"})
                Case "ALLOrdPadre"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = "+"})
                    lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "IdOrdPadre", .Operatore = "+"})
                Case "ALLOrdCliAcc"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "Cdc", .Operatore = "ADD"})
                Case "ALLCespiti"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = PrefissoCespiti, .Nome = "Cespite", .Operatore = "ADD"})
            End Select
        End If
        Try
            newDt = Edit(dt, lIDS)
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return newDt
    End Function
    ''' <summary>
    ''' Restituisce una datatable filtrata in base a una datatable filter secondo la primaryKey
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="filter"></param>
    ''' <param name="primaryKey"></param>
    ''' <returns></returns>
    Private Function FilterRows(ByVal dt As DataTable, ByVal filter As ListaId, ByVal primaryKey As String) As DataTable
        Dim newDt As DataTable = dt.Clone
        Try
            For Each r As DataRow In dt.Rows
                If filter.Ids.Contains(r.Item(primaryKey)) Then newDt.ImportRow(r)
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori durante il FiltroRows " & dt.TableName)
            Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        Return newDt
    End Function
    Private Function Edit(ByRef dt As DataTable, id As List(Of IDS)) As DataTable
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
                                'TODO da togliere
                                If Not IsDebugging Then End
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
    Private Function ScriviDati(dt As DataTable, Commit As Boolean) As Boolean
        'dsDestination 
        'ConnectionSpa

        Dim loggingTxt As String = "Si"
        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()

        'Parametri
        'https://github.com/borisdj/EFCore.BulkExtensions

        Dim iStep As Integer
        Try

            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", ConnDestination)
                cmdqry.ExecuteNonQuery()
                Using bulkTrans = ConnDestination.BeginTransaction
                    okBulk = ScriviBulk(dt.TableName, dt, bulkTrans, ConnDestination, DataRowState.Unchanged, loggingTxt, True)
                    If Not okBulk Then someTrouble = True
                    bulkMessage.AppendLine(loggingTxt)
                    If someTrouble Then
                        FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                        My.Application.Log.DefaultFileLogWriter.WriteLine("Riscontrati errori: annullamento operazione...")
                        bulkTrans.Rollback()
                    Else
                        If Commit Then bulkTrans.Commit()
                        Debug.Print("Commit !")
                        'FLogin.lstStatoConnessione.Items.Add("Scrittura")
                        FLogin.lstStatoConnessione.TopIndex = FLogin.lstStatoConnessione.Items.Count - 1
                    End If

                End Using
                cmdqry.CommandText = "DBCC TRACEOFF(610)"
                cmdqry.ExecuteNonQuery()
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
        If bulkMessage.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine("+ Scrittura: " & bulkMessage.ToString)
        If errori.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Errori ---" & vbCrLf & errori.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
            Debug.Print(errori.ToString)
        End If

        Return Not someTrouble
    End Function

    Private Function CaricaDati(t As TabelleDaEstrarre, Optional withConstraint As Boolean = True, Optional pageindex As Integer = 1, Optional ByVal withData As Boolean = True) As DataTable
        Dim result As New StringBuilder()
        Dim stopwatch As New Stopwatch
        Dim stopwatch2 As New Stopwatch
        stopwatch.Start()
        stopwatch2.Start()
        Debug.Print("Carico schema: " & t.Nome)
        Dim dt As New DataTable(t.Nome)
        Dim SQLquery As String
        Dim qryCount As String
        Dim errorLevel As String = ""
        'todo Prov a mettere 100k , lento, abbassare a 10k
        Dim pageSize As Integer = 10000

        If withData Then
            If String.IsNullOrWhiteSpace(t.QuerySelect) Then
                SQLquery = "SELECT * FROM " & t.Nome
                qryCount = "SELECT COUNT(1) FROM " & t.Nome
            Else
                SQLquery = t.QuerySelect
                'cerco posizione del Where
                Dim p As Integer = InStr(t.QuerySelect, " WHERE")
                Dim filter As String = Mid(t.QuerySelect, p)
                qryCount = "SELECT COUNT(1) FROM " & t.Nome & filter
            End If
        Else
            SQLquery = "SELECT * FROM " & t.Nome & " WHERE 1=2"
            qryCount = "SELECT COUNT(1) FROM " & t.Nome
        End If
        If Connection.State <> ConnectionState.Open Then
            MessageBox.Show("Connessione non aperta.")
            End
        End If
        Using da As New SqlDataAdapter(SQLquery, Connection)
            da.FillSchema(dt, SchemaType.Source)
            'Debug.Print("Creazione fillschema : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()
            Dim msg As String
            If pageindex = 1 Then
                Using cmd As New SqlCommand(qryCount, Connection)
                    cmd.CommandTimeout = 0
                    cmd.CommandType = CommandType.Text
                    Dim rowsCount As Integer = CInt(cmd.ExecuteScalar())
                    If rowsCount > pageSize Then
                        t.Paging = True
                        msg = "Estrazione dati : " & t.Nome & "(" & rowsCount.ToString & ") Paging (" & Math.Ceiling(rowsCount / pageSize).ToString & ")"
                    Else
                        msg = "Estrazione dati : " & t.Nome & "(" & rowsCount.ToString & ") No Paging"
                    End If
                End Using
                'Aqggiungo la lista ID alla collection
                If t.GeneraListaId Then listeIDs.Add(New ListaId With {.Nome = t.Nome})
                FLogin.lstStatoConnessione.Items.Add(msg)
                My.Application.Log.WriteEntry(msg)
            End If
            If t.Paging Then
                msg = "--- Page: " & pageindex.ToString
                FLogin.lstStatoConnessione.Items.Add(msg)
                My.Application.Log.WriteEntry(msg)
                Dim qry As String = "SELECT * FROM " & t.Nome & " ORDER BY " & dt.PrimaryKey(0).ColumnName.ToString & " OFFSET (" & (pageindex - 1) * pageSize & ") ROWS FETCH NEXT " & pageSize & " ROWS ONLY"
                da.SelectCommand.CommandText = qry
                da.Fill(dt)
                Dim rowsReturned As Integer = dt.Rows.Count
                'Se ho estratto tutto posso uscire dal paging
                If rowsReturned <> pageSize Then t.Paging = False

            Else
                da.Fill(dt)
            End If
            Debug.Print("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
            'Aggiungo gli id
            If t.GeneraListaId Then AggiungiIds(dt, t.Nome, listeIDs, t.PrimaryKey)
            stopwatch2.Restart()
            If withConstraint Then
                Using cmd As New SqlCommand("sys.sp_recompile", Connection)
                    cmd.CommandTimeout = 0
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@objname", SqlDbType.NVarChar, 776)
                    cmd.Parameters(0).Value = t.Nome  '"sp_helpconstraint"
                    cmd.ExecuteNonQuery()
                    'Debug.Print("recompile : " & stopwatch2.Elapsed.ToString)
                    stopwatch2.Restart()

                    cmd.CommandText = "sp_helpconstraint"
                    'cmd.Parameters.Clear()
                    'cmd.Parameters.Add("@objname", SqlDbType.NVarChar, 776)
                    'cmd.Parameters(0).Value = t.Nome
                    cmd.Parameters.Add("@nomsg", SqlDbType.VarChar, 5)
                    cmd.Parameters(1).Value = "nomsg"
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    'Debug.Print("Executereader : " & stopwatch2.Elapsed.ToString)
                    stopwatch2.Restart()

                    'Iterate over the constraints records in the DataReader.
                    While dr.Read()
                        Try
                            ' Select the default value constraints only.
                            Dim constraintType As String = dr("constraint_type").ToString()
                            'Dim constraintType As String = dr(1).ToString()
                            If (constraintType.StartsWith("DEFAULT")) Then
                                Dim constraintKeys As String = dr("constraint_keys").ToString()
                                Dim colName As String = constraintType.Substring((constraintType.LastIndexOf("column") + 7))
                                Dim defaultValue As String
                                If dt.Columns.Contains(colName) Then

                                    Select Case dt.Columns(colName).DataType
                                        Case GetType(Integer), GetType(Short)
                                            errorLevel = "Integer " & colName
                                            'defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
                                            defaultValue = constraintKeys.Replace("(", "").Replace(")", "")
                                        Case GetType(Date)
                                            errorLevel = "Date " & colName
                                            defaultValue = constraintKeys.Substring(1, constraintKeys.Length - 2)
                                            Select Case defaultValue
                                                Case "getdate()"
                                                    defaultValue = sOggi
                                                Case Else
                                                    defaultValue = defaultValue.Substring(1, 4) & "-" & defaultValue.Substring(5, 2) & "-" & defaultValue.Substring(7, 2)
                                            End Select
                                        Case GetType(Double)
                                            errorLevel = "Double " & colName
                                            'defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
                                            defaultValue = constraintKeys.Replace("(", "").Replace(")", "")
                                        Case GetType(Guid)
                                            errorLevel = "Guid " & colName
                                            defaultValue = Guid.Empty.ToString
                                        Case GetType(String)
                                            errorLevel = "String " & colName
                                            'If dt.Columns(colName).MaxLength = 1 Then
                                            'defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
                                            defaultValue = constraintKeys.Replace("(", "").Replace(")", "").Replace("'", "")
                                            'Else
                                            'defaultValue = constraintKeys.Substring(1, constraintKeys.Length - 2)
                                            'End If
                                        Case Else
                                            errorLevel = "Case Else " & colName
                                            'defaultValue = constraintKeys.Substring(1, constraintKeys.Length - 2)
                                            defaultValue = constraintKeys.Replace("(", "").Replace(")", "")
                                    End Select

                                    ' Only strips single quotes for numeric default types
                                    ' add necessary handling as required for nonnumeric defaults

                                    dt.Columns(colName).DefaultValue = defaultValue

                                    result.Append("Column: " & colName & " Default: " & defaultValue & Environment.NewLine)
                                End If

                            End If
                        Catch ex As Exception
                            Debug.Print(ex.Message)
                            Dim mb As New MessageBoxWithDetails(errorLevel & Environment.NewLine & ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                            mb.ShowDialog()
                        End Try
                        Application.DoEvents()
                    End While
                    dr.Close()
                End Using
            End If
        End Using

        'Debug.Print(result.ToString())
        Debug.Print("Creazione schema : " & t.Nome & " " & stopwatch.Elapsed.ToString)
        stopwatch.Stop()
        stopwatch2.Stop()
        Application.DoEvents()
        Return dt
    End Function

    Private Sub AggiungiIds(dt As DataTable, nome As String, listeIDs As List(Of ListaId), primarykey As String)
        Dim l As ListaId = listeIDs.Find(Function(x) x.Nome.Contains(nome))
        For Each dr As DataRow In dt.Rows
            l.Ids.Add(dr.Item(primarykey))
        Next
    End Sub
End Module