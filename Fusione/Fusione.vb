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
    'Contenitori delle tabelle da processare
    Private tabelle As List(Of TabelleDaEstrarre)
    Private tabelleNoEdit As List(Of TabelleDaEstrarre)
    Private listeIDs As List(Of ListaId)
    'todo Prov a mettere 100k , lento, abbassare a 20k
    Private Const pageSize As Integer = 20000

    Class TabelleDaEstrarre
        Public Property QuerySelect As String
        Public Property WhereClause As String
        Public Property JoinClause As String
        Public Property Nome As String
        Public Property Paging As Boolean
        Public Property Gruppo As MacroGruppo
        Public Property GeneraListaId As Boolean
        Public Property PrimaryKey As String
        Public Sub New()
            QuerySelect = ""
            WhereClause = ""
            JoinClause = ""
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

            Dim stopwatch2 As New System.Diagnostics.Stopwatch
            stopwatch2.Start()
            For Each t In tabelle
                'Estraggo la ListaIDS
                Dim lIDS As New List(Of IDS)
                lIDS = EstraiListaIds(t.Gruppo, t.Nome, dvIDS)
                EditTestoBarra("Carico dati: " & t.Nome)
                Dim pageindex As Integer = 1
                Dim dt As New DataTable
                Dim newDt As New DataTable

                'Prova con DataRow ( lenta)
                'Dim dtVuota As New DataTable
                'Dim dtNuova As New DataTable
                'dtVuota = GetSchemaAndPaging(t, 1)
                'dtNuova = CaricaConDatarow(dtVuota, t, lIDS, 1)

                'Metodo Datatable
                'Primo caricamento 
                dt = CaricaDati(t, False, pageindex)
                If t.Paging Then
                    While t.Paging = True
                        newDt = New DataTable
                        newDt = ModificaDati(t.Gruppo, dt, lIDS, ok)
                        If Not ok Then someTrouble = True
                        ok = ScriviDati(newDt, Not IsDebugging)
                        pageindex += 1
                        'Carica nuovi dati
                        dt = New DataTable
                        dt = CaricaDati(t, False, pageindex)
                        FLogin.prgFusion.PerformStep()
                        FLogin.prgFusion.Update()
                        Application.DoEvents()
                    End While
                End If
                'Ultimo ciclo while + Se non ho paging
                newDt = New DataTable
                newDt = ModificaDati(t.Gruppo, dt, lIDS, ok)
                If Not ok Then someTrouble = True
                ok = ScriviDati(newDt, Not IsDebugging)
                FLogin.prgFusion.Visible = False
                AvanzaBarra()
            Next
            My.Application.Log.WriteEntry("Processo tabelle in : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()

            'ciclo le tabelle senza Edit
            For Each t In tabelleNoEdit
                EditTestoBarra("Carico dati: " & t.Nome)
                Dim pageindex As Integer = 1
                Dim dt As New DataTable
                'Primo caricamento
                dt = CaricaDati(t, False, pageindex)
                If t.Paging Then
                    While t.Paging = True
                        ok = ScriviDati(dt, Not IsDebugging)
                        pageindex += 1
                        'Carica nuovi dati
                        dt = New DataTable
                        dt = CaricaDati(t, False, pageindex)
                    End While
                End If
                'Ultimo ciclo while + Se non ho paging
                ok = ScriviDati(dt, Not IsDebugging)
                AvanzaBarra()
            Next
            My.Application.Log.WriteEntry("Processo tabelle No edit in : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()
            'Edit IDS
            If Not IsDebugging Then
                ok = ScriviIds(dvIDS)
                If Not ok Then someTrouble = True
            End If
            stopwatch2.Stop()
            stopwatch.Stop()
            Debug.Print(stopwatch.Elapsed.ToString)
            FLogin.lstStatoConnessione.Items.Add("Processo eseguito in : " & stopwatch.Elapsed.ToString)
            My.Application.Log.WriteEntry("Processo eseguito in : " & stopwatch.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# EseguiFusione " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try
        My.Application.Log.WriteEntry("Fine processo")
        Return someTrouble
    End Function
    Public Function EseguiFusioneSQL(dts As DataSet) As Boolean
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

        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim stopwatch2 As New System.Diagnostics.Stopwatch
        stopwatch2.Start()

        Dim cmdqry As New SqlCommand("DBCC TRACEON(610)", Connection)
        Dim cmdDest As New SqlCommand("DBCC TRACEON(610)", ConnDestination)

        Try
            'Disattivo le relazioni
            FLogin.lstStatoConnessione.Items.Add("TRACEON Origine...")
            cmdqry.CommandTimeout = 180
            cmdqry.ExecuteNonQuery()
            FLogin.lstStatoConnessione.Items.Add("TRACEON Destinazione...")
            cmdDest.CommandTimeout = 180
            cmdDest.ExecuteNonQuery()
            Application.DoEvents()

            'Solo per SQL 2017 in su
            'cmdqry.CommandText = "DBCC TRACEON(460,1)" ' per cambiare errore ID 8152 with 2628
            'cmdqry.ExecuteNonQuery()
            FLogin.lstStatoConnessione.Items.Add("Disattivo vincoli per Origine...")
            cmdqry.CommandText = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'"
            cmdqry.ExecuteNonQuery()
            Application.DoEvents()
            FLogin.lstStatoConnessione.Items.Add("Processo tabelle in corso...")
            FLogin.prgCopy.Value = 0
            FLogin.prgCopy.Step = 1
            FLogin.prgCopy.Maximum = tabelle.Count + tabelleNoEdit.Count
        Catch ex As Exception
            Debug.Print(ex.Message)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# EsguiFusioneSql : DISATTIVO VINCOLI ORIGINE " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try

        Try
            stopwatch2.Restart()
            'Processo una tabella alla volta
            listeIDs = New List(Of ListaId)

            For Each t In tabelle
                FLogin.lstStatoConnessione.Items.Add(t.Nome)
                'Estraggo la ListaIDS
                Dim lIDS As New List(Of IDS)
                EditTestoBarra("Estrai IDS: " & t.Nome)
                lIDS = EstraiListaIds(t.Gruppo, t.Nome, dvIDS)

                EditTestoBarra("Modifica dati (origine): " & t.Nome)
                'Metodo Sql Update
                Dim rows As Integer
                ok = ModificaSqlUpdate(t, lIDS, rows)
                Application.DoEvents()
                If Not ok Then someTrouble = True
                EditTestoBarra("Scrittura dati (destinazione): " & t.Nome)
                ok = ScriviDatiSql(t, Not IsDebugging)
                AvanzaBarra()
            Next
            My.Application.Log.WriteEntry("Processo tabelle in : " & stopwatch2.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# EsguiFusioneSql : MODIFICO E SCRIVO TABELLE " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try

        Try
            stopwatch2.Restart()
            'ciclo le tabelle senza Edit
            FLogin.lstStatoConnessione.Items.Add("Processo tabelle senza modifiche in corso...")
            For Each t In tabelleNoEdit
                EditTestoBarra("Scrittura dati (destinazione): " & t.Nome)
                ok = ScriviDatiSql(t, Not IsDebugging)
                AvanzaBarra()
            Next
            My.Application.Log.WriteEntry("Processo tabelle No edit in : " & stopwatch2.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# EsguiFusioneSql : SCRIVO TABELLE NO EDIT " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try

        Try
            stopwatch2.Restart()
            'Edit IDS
            If Not IsDebugging Then
                ok = ScriviIds(dvIDS)
                If Not ok Then someTrouble = True
            End If
            My.Application.Log.WriteEntry("Scrivo Ids : " & stopwatch2.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# EsguiFusioneSql : SCRIVI IDS " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try


        'Rimetto a posto le relazioni
        FLogin.lstStatoConnessione.Items.Add("Riattivo vincoli per Origine...")
        Try
            cmdqry.CommandText = "EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'"
            cmdqry.ExecuteNonQuery()
            'cmdqry.CommandText = "DBCC TRACEOFF(460, 1)"
            'cmdqry.ExecuteNonQuery()
            FLogin.lstStatoConnessione.Items.Add("TRACEOFF Origine...")
            cmdqry.CommandText = "DBCC TRACEOFF(610)"
            cmdqry.ExecuteNonQuery()
            FLogin.lstStatoConnessione.Items.Add("TRACEOFF Destinazione...")
            cmdDest.CommandText = "DBCC TRACEOFF(610)"
            cmdDest.ExecuteNonQuery()
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("ERRORE SU 'Riattivo vincoli per Origine'")
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# RIATTIVO VINCOLI ORIGINE " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
        End Try

        stopwatch2.Stop()
        stopwatch.Stop()
        Debug.Print(stopwatch.Elapsed.ToString)
        FLogin.lstStatoConnessione.Items.Add("Processo eseguito in : " & stopwatch.Elapsed.ToString)
        My.Application.Log.WriteEntry("Processo eseguito in : " & stopwatch.Elapsed.ToString)

        My.Application.Log.WriteEntry("Fine processo")
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
        tabelle = New List(Of TabelleDaEstrarre)
        tabelleNoEdit = New List(Of TabelleDaEstrarre)
#Region "Fatture"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDoc", .Gruppo = MacroGruppo.Vendita})
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
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocDetail", .Gruppo = MacroGruppo.Acquisto, .JoinClause = " FROM MA_PurchaseDocDetail INNER JOIN MA_PurchaseDoc ON MA_PurchaseDocDetail.PurchaseDocId = MA_PurchaseDoc.PurchaseDocId", .WhereClause = " WHERE MA_PurchaseDoc.DocumentType =  9830400"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocNotes", .Gruppo = MacroGruppo.Acquisto, .JoinClause = " FROM MA_PurchaseDocNotes INNER JOIN MA_PurchaseDoc ON MA_PurchaseDocNotes.PurchaseDocId = MA_PurchaseDoc.PurchaseDocId", .WhereClause = " WHERE MA_PurchaseDoc.DocumentType =  9830400"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocPymtSched", .Gruppo = MacroGruppo.Acquisto, .JoinClause = " FROM MA_PurchaseDocPymtSched INNER JOIN MA_PurchaseDoc ON MA_PurchaseDocPymtSched.PurchaseDocId = MA_PurchaseDoc.PurchaseDocId", .WhereClause = " WHERE MA_PurchaseDoc.DocumentType =  9830400"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocReferences", .Gruppo = MacroGruppo.acquisto, .JoinClause = " FROM MA_PurchaseDocReferences INNER JOIN MA_PurchaseDoc ON MA_PurchaseDocReferences.PurchaseDocId = MA_PurchaseDoc.PurchaseDocId", .WhereClause = " WHERE MA_PurchaseDoc.DocumentType =  9830400"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocShipping", .Gruppo = MacroGruppo.Acquisto, .JoinClause = " FROM MA_PurchaseDocShipping INNER JOIN MA_PurchaseDoc ON MA_PurchaseDocShipping.PurchaseDocId = MA_PurchaseDoc.PurchaseDocId", .WhereClause = " WHERE MA_PurchaseDoc.DocumentType =  9830400"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocSummary", .Gruppo = MacroGruppo.Acquisto, .JoinClause = " FROM MA_PurchaseDocSummary INNER JOIN MA_PurchaseDoc ON MA_PurchaseDocSummary.PurchaseDocId = MA_PurchaseDoc.PurchaseDocId", .WhereClause = " WHERE MA_PurchaseDoc.DocumentType =  9830400"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocTaxSummary", .Gruppo = MacroGruppo.Acquisto, .JoinClause = " FROM MA_PurchaseDocTaxSummary INNER JOIN MA_PurchaseDoc ON MA_PurchaseDocTaxSummary.PurchaseDocId = MA_PurchaseDoc.PurchaseDocId", .WhereClause = " WHERE MA_PurchaseDoc.DocumentType =  9830400"})
        'Devo metterla per ultima perche' viene usata come filtro/join per quelle sopra
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDoc", .WhereClause = " WHERE DocumentType =  9830400", .Gruppo = MacroGruppo.Acquisto, .GeneraListaId = True, .PrimaryKey = "PurchaseDocId"})
#End Region
#Region "Ordini Clienti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrd", .Gruppo = MacroGruppo.OrdiniClienti})
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
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssets", .WhereClause = " WHERE DisposalType <> 7143424", .Gruppo = MacroGruppo.Cespiti})
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
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppCustomerOptions", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .Gruppo = MacroGruppo.Clienti})

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
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppBranches", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNaturalPerson", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNotes", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppOutstandings", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente}) ' Insoluti
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppPeople", .WhereClause = "WhereClause WHERE CustSuppType=" & CustSuppType.Cliente})
        '
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_SDDMandate"})
#End Region
#Region "Banche"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Banks", .WhereClause = " WHERE IsACompanyBank = 0"})
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
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalData", .WhereClause = " WHERE FiscalYear = 2022"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalDataDomCurr", .WhereClause = " WHERE FiscalYear = 2022"})

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
    Private Function ModificaDati(ByVal g As MacroGruppo, ByVal dt As DataTable, ByVal lids As List(Of IDS), ByRef result As Boolean) As DataTable
        Dim ok As Boolean
        Dim newDt As New DataTable
        Select Case g
            Case MacroGruppo.Vendita
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Vendite: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Acquisto
                'Logica diversa perche' ho un filtro
                Dim withFiltro As Boolean = dt.TableName <> "MA_PurchaseDoc"
                Try
                    'Filtro e edito in un colpo solo
                    newDt = Edit(If(withFiltro, FilterRows(dt, listeIDs.Find(Function(x) x.Nome.Contains("MA_PurchaseDoc")), "PurchaseDocId"), dt), lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in EditAcquisti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Analitica
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati CentriDiCosto: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.OrdiniClienti
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati OrdiniClienti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Cespiti
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Cespiti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Agenti
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Agenti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Clienti
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Clienti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Articoli
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Articoli: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
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
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ScriviIds: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            Return False
        End Try
    End Function
    Private Sub AggiornaIDs(ByVal IdType As Integer, ByVal value As Integer, Optional ByRef MyReturnString As String = "")
        Try
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
        Catch ex As Exception
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in AggiornaIDs: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
        End Try
    End Sub
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
            FLogin.lstStatoConnessione.Items.Add("Riscontrati errori durante il FiltroRows " & dt.TableName)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# FiltroRows " & dt.TableName & " " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        Return newDt
    End Function
    Private Function Edit(ByVal dt As DataTable, id As List(Of IDS)) As DataTable
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
                                Dim msg As String = "Riscontrati errori durante l'EditAddPrefix " & dt.TableName
                                FLogin.lstStatoConnessione.Items.Add(msg)
                                My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in EditAddPrefix: " & r.Item(dt.PrimaryKey.First.ColumnName) & " - " & dt.TableName & "." & f.Nome & " - Valore troppo grosso " & r.Item(f.Nome) & f.IdString)
                                If Not IsDebugging Then
                                    Dim mb As New MessageBoxWithDetails(msg & "." & f.Nome, GetCurrentMethod.Name, "Valore troppo grosso " & r.Item(f.Nome) & " " & f.IdString)
                                    mb.ShowDialog()
                                    End
                                End If
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
            FLogin.lstStatoConnessione.Items.Add("Riscontrata exception durante l'EditId " & dt.TableName)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in Edit: " & dt.TableName & " - " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        Debug.Print("Edit(ok): " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        My.Application.Log.DefaultFileLogWriter.WriteLine("Edit(ok): " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        Return dv.ToTable
    End Function

    Friend Class IDS
        Public Property Chiave As Boolean
        Public Property Nome As String
        Public Property Id As Integer
        Public Property IdString As String
        Public Property Operatore As String
        Public Property MaxSize As Integer

    End Class
    ''' <summary>
    ''' Eseguo la preparazione alla BULK INSERT SQL nel database di destinazione usando una SQLDatareader 
    ''' </summary>
    ''' <returns></returns>
    Private Function ScriviDatiSql(t As TabelleDaEstrarre, ByVal commit As Boolean) As Boolean
        'dsDestination 
        'ConnectionSpa

        Dim loggingTxt As String = "Si"
        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()
        Dim SQLquery As String
        Dim qryCount As String

        Dim originCount As Long
        'Parametri
        'https://github.com/borisdj/EFCore.BulkExtensions

        Try
            ' Definisco le query per le righe attuali nella tabella
            If String.IsNullOrWhiteSpace(t.JoinClause) Then
                SQLquery = "SELECT * FROM " & t.Nome & t.WhereClause
                qryCount = "SELECT COUNT(1) FROM " & t.Nome & t.WhereClause
            Else
                SQLquery = "SELECT " & t.Nome & ".* " & t.JoinClause & t.WhereClause
                qryCount = "SELECT COUNT(1) " & t.Nome & t.JoinClause & t.WhereClause
            End If

            'Righe origine
            Using cmdqry = New SqlCommand(qryCount, Connection)
                originCount = System.Convert.ToInt32(cmdqry.ExecuteScalar())
                bulkMessage.Append(t.Nome & " Orig:(" & originCount.ToString & ") ")
            End Using


            Dim destCommRowCount As New SqlCommand(qryCount, ConnDestination)
            Dim countStart As Long = System.Convert.ToInt32(destCommRowCount.ExecuteScalar())
            'Debug.Print("Starting row count = {0}", countStart)
            bulkMessage.Append("Dest In:(" & countStart.ToString & ") ")

            ' Recupero i dati dall'origine in un SqlDataReader.
            Dim commandSourceData As New SqlCommand(SQLquery, Connection)
            Dim reader As SqlDataReader = commandSourceData.ExecuteReader

            Using bulkTrans = ConnDestination.BeginTransaction
                ' Set up the bulk copy object. 
                ' The column positions in the source data reader 
                ' match the column positions in the destination table, 
                ' so there is no need to map columns.
                Try
                    'provo con column mappig = false
                    okBulk = ScriviBulkSQL(t.Nome, originCount, reader, bulkTrans, ConnDestination, loggingTxt, True)
                Catch ex As Exception
                    Debug.Print(ex.Message)
                Finally
                    reader.Close()
                End Try
                'Controllo lo stato
                If Not okBulk Then someTrouble = True
                bulkMessage.AppendLine(loggingTxt)
                If someTrouble Then
                    FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                    My.Application.Log.DefaultFileLogWriter.WriteLine("Riscontrati errori: annullamento operazione...")
                    bulkTrans.Rollback()
                Else
                    If commit Then bulkTrans.Commit()
                    Debug.Print("Commit !")
                    'FLogin.lstStatoConnessione.Items.Add("Scrittura")
                    FLogin.lstStatoConnessione.TopIndex = FLogin.lstStatoConnessione.Items.Count - 1
                End If

            End Using
            ' Perform a final count on the destination table
            ' to see how many rows were added.
            Dim countEnd As Long = System.Convert.ToInt32(destCommRowCount.ExecuteScalar())
            Debug.Print("Ending row count = {0}", countEnd)
            Debug.Print("{0} rows were added.", countEnd - countStart)
            bulkMessage.Append("Agg:(" & (countEnd - countStart).ToString & ") ")
            If (countEnd - countStart) <> originCount Then errori.AppendLine("Aggiunta righe diverse su " & t.Nome)

        Catch ex As Exception
            someTrouble = True
            Debug.Print(ex.Message)
            bulkMessage.AppendLine("[Salvataggio] - Sono stati riscontrati degli errori. (Vedere sezione Errori): " & t.Nome)
            errori.AppendLine(t.Nome)
            errori.AppendLine("[Salvataggio] Messaggio:" & ex.Message)
            errori.AppendLine("[Salvataggio] Stack:" & ex.StackTrace)

            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
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
    ''' <summary>
    ''' Eseguo la preparazione alla BULK INSERT dell'intero dataset nel database di destinazione
    ''' </summary>
    ''' <returns></returns>
    Private Function ScriviDati(dt As DataTable, ByVal Commit As Boolean) As Boolean
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

            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
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
    Private Function ModificaSqlUpdate(t As TabelleDaEstrarre, ByVal lids As List(Of IDS), ByRef rows As Integer) As Boolean
        Dim qryToExecute As String = "UPDATE " & t.Nome & " SET "
        Dim result As Boolean = False
        Try
            Using cmdqry = New SqlCommand(qryToExecute, Connection)
                '    cmdqry.CommandTimeout = 180
                '    cmdqry.ExecuteNonQuery()

                '    'Solo per SQL 2017 in su
                '    'cmdqry.CommandText = "DBCC TRACEON(460,1)" ' per cambiare errore ID 8152 with 2628
                '    'cmdqry.ExecuteNonQuery()

                '    cmdqry.CommandText = "ALTER TABLE " & t.Nome & " NOCHECK CONSTRAINT ALL"
                '    cmdqry.ExecuteNonQuery()

                'cmdqry.CommandText = "UPDATE " & t.Nome & " SET "
                Dim sb As New StringBuilder
                Dim paramIndex As Integer = 0
                For Each f As IDS In lids
                    paramIndex += 1
                    Dim field As String = t.Nome & "." & f.Nome
                    Dim parameter As String = "@P" & paramIndex.ToString
                    Dim value As String = ""
                    Select Case f.Operatore
                        Case "+"
                            value = field & " + " & f.Id.ToString
                            cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})
                            'cmdqry.Parameters.AddWithValue(parameter, value)
                        Case ""
                            'value = f.Id.ToString
                            cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})

                        Case "ADD", "END"
                            value = "(CASE WHEN " & field & " ='' THEN '' ELSE "
                            If f.Operatore = "ADD" Then
                                value = value & "CONCAT('" & f.IdString & "', " & field & ") END)"
                            Else
                                'END" = Suffisso
                                value = value & "CONCAT(" & field & " ,'" & f.IdString & "') END)"
                            End If
                            'cmdqry.Parameters.Add(parameter, SqlDbType.VarChar, 100).Value = value
                            'cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.VarChar, .Size = 100, .Direction = ParameterDirection.Input, .Value = value})

                        Case "SAVE"
                            value = "(CASE WHEN " & field & " <>'' AND " & field & " <> '" & f.IdString & "'  THEN '' ELSE " & field & " END)"
                            cmdqry.Parameters.Add(parameter, SqlDbType.VarChar, f.MaxSize).Value = value
                        Case "="
                            ' value = f.Id.ToString
                            cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})

                    End Select

                    Select Case f.Operatore
                        Case "+"
                            sb.AppendLine(field & " = " & field & " + " & parameter & ", ")
                        Case "ADD", "END"
                            sb.AppendLine(field & " = " & value & ", ")
                        Case Else
                            sb.AppendLine(field & " = " & parameter & ", ")
                    End Select

                Next
                qryToExecute &= Strings.Left(sb.ToString, sb.Length - 4)
                'Aggiungo JOIN E WHERE
                qryToExecute &= t.JoinClause & t.WhereClause

                cmdqry.CommandText = qryToExecute
                Debug.Print(qryToExecute)
                Try
                    rows = cmdqry.ExecuteNonQuery()
                    result = True
                Catch exSql As SqlException
                    Debug.Print("Errore SQL:" & exSql.Number.ToString)
                    Select Case exSql.Number
                        Case 8152
                            'Dato troppo lungo
                            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaSqlUpdate.ExecuteNonQuery (Dato troppo lungo): " & exSql.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & exSql.StackTrace.ToString)
                    End Select

                End Try
                Application.DoEvents()
                cmdqry.Parameters.Clear()

                'cmdqry.CommandText = "ALTER TABLE " & t.Nome & " WITH CHECK CHECK CONSTRAINT ALL"
                'cmdqry.ExecuteNonQuery()

                ''cmdqry.CommandText = "DBCC TRACEOFF(460, 1)"
                ''cmdqry.ExecuteNonQuery()
                'cmdqry.CommandText = "DBCC TRACEOFF(610)"
                'cmdqry.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Debug.Print(ex.Message)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaSqlUpdate: " & ex.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        Return result
    End Function

    Private Function CaricaDati(t As TabelleDaEstrarre, Optional withConstraint As Boolean = True, Optional pageindex As Integer = 1, Optional ByVal withData As Boolean = True) As DataTable
        Dim result As New StringBuilder()
        Dim stopwatch As New Stopwatch
        Dim stopwatch2 As New Stopwatch
        stopwatch.Start()
        stopwatch2.Start()
        Debug.Print("Carico Dati: " & t.Nome)
        Dim dt As New DataTable(t.Nome)
        Dim SQLquery As String
        Dim qryCount As String
        Dim errorLevel As String = ""
        Dim pageTot As Integer

        If withData Then
            SQLquery = "SELECT * FROM " & t.Nome & t.JoinClause & t.WhereClause
            qryCount = "SELECT COUNT(1) FROM " & t.Nome & t.JoinClause & t.WhereClause

        Else
            SQLquery = "SELECT * FROM " & t.Nome & " WHERE 1=2"
            qryCount = "SELECT COUNT(1) FROM " & t.Nome
        End If
        If Connection.State <> ConnectionState.Open Then
            MessageBox.Show("Connessione non aperta.")
            End
        End If
        Using da As New SqlDataAdapter(SQLquery, Connection)
            da.SelectCommand.CommandTimeout = 120
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
                        pageTot = Math.Ceiling(rowsCount / pageSize)
                        msg = "Estrazione dati : " & t.Nome & "(" & rowsCount.ToString & ") Paging (" & pageTot.ToString & ")"
                        'Faccio vedere la nuova barra
                        FLogin.prgFusion.Value = 0
                        FLogin.prgFusion.Step = 1
                        FLogin.prgFusion.Maximum = pageTot
                        FLogin.prgFusion.Text = t.Nome & " - Tot page: " & pageTot.ToString
                        FLogin.prgFusion.Visible = True
                        FLogin.prgFusion.PerformStep()
                        FLogin.prgFusion.Update()
                        Application.DoEvents()
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
            My.Application.Log.WriteEntry("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
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
                            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in CaricaDati: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                            If Not IsDebugging Then
                                Dim mb As New MessageBoxWithDetails(errorLevel & Environment.NewLine & ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                                mb.ShowDialog()
                            End If
                        End Try
                        Application.DoEvents()
                    End While
                    dr.Close()
                End Using
            End If
        End Using

        'Debug.Print(result.ToString())
        Debug.Print("Carica Dati : " & t.Nome & " " & stopwatch.Elapsed.ToString)
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
Module ListeID
    Const PrefissoCespiti As String = "A"
    Const Prefisso As String = "1"
    Const Suffisso As String = "1"
    Const ContropartitaAcquisto As String = "3ACQ"
    Friend Function EstraiListaIds(ByVal g As MacroGruppo, ByVal tablename As String, ByVal dvids As DataView) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case g
            Case MacroGruppo.Vendita
                EditTestoBarra("Modifiche: Documenti Vendita")
                lIDS = IdsVendite(dvids, tablename)
            Case MacroGruppo.Acquisto
                EditTestoBarra("Modifiche: Documenti Acquisto")
                'Logica diversa perche' ho un filtro
                lIDS = IdsAcquisti(dvids, tablename)
            Case MacroGruppo.Analitica
                EditTestoBarra("Modifiche: Analitica")
                lIDS = IdsCentriDiCosto(tablename)
            Case MacroGruppo.OrdiniClienti
                EditTestoBarra("Modifiche: Ordini Clienti")
                lIDS = IdsOrdiniClienti(dvids, tablename)
            Case MacroGruppo.Cespiti
                EditTestoBarra("Modifiche: Cespiti")
                lIDS = IdsCespiti(tablename)
            Case MacroGruppo.Agenti
                EditTestoBarra("Modifiche: Agenti")
                lIDS = IdsAgenti(tablename)
            Case MacroGruppo.Clienti
                EditTestoBarra("Modifiche: Clienti")
                lIDS = IdsClienti(dvids, tablename)
            Case MacroGruppo.Articoli
                EditTestoBarra("Modifiche: Articoli")
                lIDS = IdsArticoli(tablename)
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
        Dim saleDocId As Integer
        Dim found As Integer = dv.Find("SaleDocId")
        If found = -1 Then
            Debug.Print("Vendite SaleDocId: non trovato")
            My.Application.Log.WriteEntry("Fatture SaleDocId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare,Vendite SaleDocId: non trovato nel file IDS")
                End
            End If
        Else
            saleDocId = CInt(dv(found)("NewKey"))
            Select Case tablename
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
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = "END", .MaxSize = 8})
                Case "MA_SaleDocComponents", "MA_SaleDocManufReasons", "MA_SaleDocNotes", "MA_SaleDocShipping", "MA_SaleDocSummary", "MA_SaleDocTaxSummary"
                    '"MA_SaleDocReferences", "MA_EIEventViewer", "MA_EI_ITDocAdditionalData", "MA_EI_ITAsyncComm"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = saleDocId, .Nome = "SaleDocId", .Operatore = "+"})
                Case "MA_SaleDocPymtSched"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = saleDocId, .Nome = "SaleDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
                Case "MA_SaleDocDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = saleDocId, .Nome = "SaleDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
                    Dim fOrdine As Integer = dv.Find("SaleOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Fatture: SaleOrdId: non trovato")
                        My.Application.Log.WriteEntry("Fatture: SaleOrdId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Fatture: SaleOrdId: non trovato nel file IDS")
                            End
                        End If
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
            My.Application.Log.WriteEntry("Acquisti PurchaseDocId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Acquisti PurchaseDocId: non trovato nel file IDS")
                End
            End If
        Else
            PurchaseDocId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_PurchaseDoc"
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
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
                Case "MA_PurchaseDocNotes", "MA_PurchaseDocShipping", "MA_PurchaseDocSummary", "MA_PurchaseDocTaxSummary"
                    '"MA_PurchaseDocReferences"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = "+"})
                Case "MA_PurchaseDocPymtSched"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
                Case "MA_PurchaseDocDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
                    Dim fOrdine As Integer = dv.Find("PurchaseOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Acquisti: PurchaseOrdId: non trovato")
                        My.Application.Log.WriteEntry("Acquisti: PurchaseOrdId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Acquisti: PurchaseOrdId: non trovato nel file IDS")
                            End
                        End If
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
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso UNO ai Cepiti e Ubicazioni
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsCespiti(ByVal tablename As String) As List(Of IDS)
        'dati presenti in 4 tabelle
        'MA_FixAssetEntriesDetail   'Esclusa
        'MA_FixedAssets
        'MA_FixedAssetsBalance      'Esclusa
        'MA_FixedAssetsFiscal       'Esclusa
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_FixedAssets"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = PrefissoCespiti, .Nome = "FixedAsset", .Operatore = "ADD", .MaxSize = 10})
                lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Location", .Operatore = "END", .MaxSize = 8})
            Case "MA_FixAssetLocations"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Location", .Operatore = "END", .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsArticoli(ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_Items"
                lIDS.Add(New IDS With {.IdString = ContropartitaAcquisto, .Nome = "PurchaseOffset", .Operatore = "SAVE", .MaxSize = 16})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsAgenti(ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_Areas"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Area", .Operatore = "End", .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Dichiarazioni di Intento
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
                    My.Application.Log.WriteEntry("Clienti DeclId: non trovato")
                    If Not IsDebugging Then
                        MessageBox.Show("Impossibile continuare, Clienti DeclId: non trovato nel file IDS")
                        End
                    End If
                Else
                    DeclId = CInt(dv(found)("NewKey"))
                    lIDS.Add(New IDS With {.Chiave = True, .Id = DeclId, .Nome = "DeclId", .Operatore = "+"})
                End If

            Case "MA_CustSuppCustomerOptions"
                lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = "END", .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso UNO ai Centri di Costo
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsCentriDiCosto(ByVal tablename As String) As List(Of IDS)
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
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
        End Select

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
        Dim found As Integer = dv.Find("SaleOrdId")
        If found = -1 Then
            Debug.Print("Ordini SaleOrdId: non trovato")
            My.Application.Log.WriteEntry("Ordini SaleOrdId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare,Ordini SaleOrdId: non trovato nel file IDS")
                End
            End If
        Else
            SaleOrdId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_SaleOrdComponents", "MA_SaleOrdNotes", "MA_SaleOrdPymtSched", "MA_SaleOrdShipping", "MA_SaleOrdSummary", "MA_SaleOrdTaxSummary"
                    '"MA_SaleOrdReferences"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = "+"})
                Case "MA_SaleOrd"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
                    lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = "END", .MaxSize = 8})
                Case "MA_SaleOrdDetails"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = "ADD", .MaxSize = 8})
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
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "Cdc", .Operatore = "ADD", .MaxSize = 8})
                Case "ALLCespiti"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = "+"})
                    lIDS.Add(New IDS With {.IdString = PrefissoCespiti, .Nome = "Cespite", .Operatore = "ADD", .MaxSize = 10})
            End Select
        End If

        Return lIDS
    End Function
End Module
Module WithDataRow
    'Dublicate per eviatre errori in compilazione
    Private Const pageSize As Integer = 20000
    Private listeIDs As List(Of ListaId)

    Class TabelleDaEstrarre
        Public Property QuerySelect As String
        Public Property WhereClause As String
        Public Property JoinClause As String
        Public Property Nome As String
        Public Property Paging As Boolean
        Public Property Gruppo As MacroGruppo
        Public Property GeneraListaId As Boolean
        Public Property PrimaryKey As String
        Public Sub New()
            QuerySelect = ""
            WhereClause = ""
            JoinClause = ""
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

    Private Function GetSchemaAndPaging(t As TabelleDaEstrarre, Optional pageindex As Integer = 1) As DataTable
        Dim sqlQuery As String
        Dim qryCount As String
        Dim errorLevel As String = ""
        Dim pageTot As Integer
        Dim dtNew As New DataTable(t.Nome)

        sqlQuery = "SELECT TOP (1) * FROM " & t.Nome
        qryCount = "SELECT COUNT(1) FROM " & t.Nome & t.JoinClause & t.WhereClause

        If Connection.State <> ConnectionState.Open Then
            MessageBox.Show("Connessione non aperta.")
            End
        End If

        Using da As New SqlDataAdapter(sqlQuery, Connection)
            da.SelectCommand.CommandTimeout = 120
            da.FillSchema(dtNew, SchemaType.Source)
            Dim msg As String
            If pageindex = 1 Then
                Using cmd As New SqlCommand(qryCount, Connection)
                    cmd.CommandTimeout = 0
                    cmd.CommandType = CommandType.Text
                    Dim rowsCount As Integer = CInt(cmd.ExecuteScalar())
                    If rowsCount > pageSize Then
                        t.Paging = True
                        pageTot = Math.Ceiling(rowsCount / pageSize)
                        msg = "Estrazione schema : " & t.Nome & "(" & rowsCount.ToString & ") Paging (" & pageTot.ToString & ")"
                        'Faccio vedere la nuova barra
                        FLogin.prgFusion.Value = 0
                        FLogin.prgFusion.Step = 1
                        FLogin.prgFusion.Maximum = pageTot
                        FLogin.prgFusion.Text = t.Nome & " - Tot page: " & pageTot.ToString
                        FLogin.prgFusion.Visible = True
                        FLogin.prgFusion.PerformStep()
                        FLogin.prgFusion.Update()
                        Application.DoEvents()
                    Else
                        msg = "Estrazione schema : " & t.Nome & "(" & rowsCount.ToString & ") No Paging"
                    End If
                End Using
                FLogin.lstStatoConnessione.Items.Add(msg)
                My.Application.Log.WriteEntry(msg)
            End If
        End Using

        Return dtNew
    End Function

    Private Function CaricaConDatarow(dt As DataTable, t As TabelleDaEstrarre, ByVal lids As List(Of IDS), Optional pageindex As Integer = 1) As DataTable
        'Dim stopwatch As New Stopwatch
        Dim stopwatch2 As New Stopwatch
        'stopwatch.Start()
        stopwatch2.Start()
        Dim msg As String
        Dim SQLquery As String
        Dim dtNew As New DataTable
        'Creo la struttura
        dtNew = dt.Clone

        SQLquery = "SELECT * FROM " & t.Nome & t.JoinClause & t.WhereClause


        If t.Paging Then
            msg = "--- Page: " & pageindex.ToString
            FLogin.lstStatoConnessione.Items.Add(msg)
            My.Application.Log.WriteEntry(msg)
            SQLquery = "SELECT * FROM " & t.Nome & " ORDER BY " & t.PrimaryKey & " OFFSET (" & (pageindex - 1) * pageSize & ") ROWS FETCH NEXT " & pageSize & " ROWS ONLY"

        Else
            'SQLquery =
        End If
        Using cmd As New SqlCommand(SQLquery, Connection)

            Dim rowsReturned As Integer = 0
            'Se ho estratto tutto posso uscire dal paging
            If rowsReturned <> pageSize Then t.Paging = False
            'Cerco lista di appoggio con nome tabella 
            Dim indexLista As Integer
            If t.GeneraListaId Then
                indexLista = listeIDs.FindIndex(Function(x) x.Nome.Contains(t.Nome))
            End If
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    Dim ColArray As Object() = New Object(dr.FieldCount - 1) {}

                    For i As Integer = 0 To dr.FieldCount - 1
                        If dr(i) IsNot Nothing Then ColArray(i) = dr(i)
                    Next
                    Dim r As DataRow = dtNew.NewRow()
                    r.ItemArray = ColArray
                    'Faccio le mie modifiche
                    Dim nr As DataRow = EditDataRow(r, lids)
                    'Scrivo il nuovo dato su dtNew
                    'dtNew.LoadDataRow(ColArray, True)
                    dtNew.Rows.Add(nr)
                    'Aggiungo gli id
                    If t.GeneraListaId Then listeIDs(indexLista).Ids.Add(dr.Item(t.PrimaryKey))

                End While

                rowsReturned += 1
            End If
            Debug.Print("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
            My.Application.Log.WriteEntry("Riempimento tabella : " & stopwatch2.Elapsed.ToString)

            dr.Close()
        End Using
        Return dtNew
    End Function

    Private Function ModificaDataRow(ByVal g As MacroGruppo, ByVal row As DataRow, ByVal lids As List(Of IDS), ByRef result As Boolean) As DataRow
        Dim ok As Boolean
        Dim newDr As DataRow = row
        Select Case g
            Case MacroGruppo.Vendita
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Vendite: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Acquisto
                'Logica diversa perche' ho un filtro
                Dim withFiltro As Boolean = row.Table.TableName <> "MA_PurchaseDoc"
                Try
                    'Filtro e EditDataRow in un colpo solo
                    'TODO : accantonato
                    'newDr = EditDataRow(If(withFiltro, FilterRows(row, listeIDs.Find(Function(x) x.Nome.Contains("MA_PurchaseDoc")), "PurchaseDocId"), row), lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in EditDataRowAcquisti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Analitica
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati CentriDiCosto: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.OrdiniClienti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati OrdiniClienti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Cespiti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Cespiti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Agenti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Agenti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Clienti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Clienti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Articoli
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Articoli: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
        End Select

        If Not ok Then result = True

        Return newDr
    End Function
    Private Function EditDataRow(ByVal r As DataRow, id As List(Of IDS)) As DataRow
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim keyIDS As IDS = id.Find(Function(p) p.Chiave = True)
        Try
            For Each f As IDS In id
                Select Case f.Operatore
                    Case "+"
                        r.Item(f.Nome) = CInt(r.Item(f.Nome)) + f.Id
                    Case ""
                        r.Item(f.Nome) = f.Id
                    Case "ADD", "END"
                        Dim lprefix As Short = f.IdString.Length
                        If r.Item(f.Nome).ToString.Length + lprefix > r.Table.Columns(f.Nome).MaxLength Then
                            Dim msg As String = "Riscontrati errori durante l'EditAddPrefix " & r.Table.TableName
                            FLogin.lstStatoConnessione.Items.Add(msg)
                            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in EditAddPrefix: " & r.Item(r.Table.PrimaryKey.First.ColumnName) & " - " & r.Table.TableName & "." & f.Nome & " - Valore troppo grosso " & r.Item(f.Nome) & f.IdString)
                            If Not IsDebugging Then
                                Dim mb As New MessageBoxWithDetails(msg & "." & f.Nome, GetCurrentMethod.Name, "Valore troppo grosso " & r.Item(f.Nome) & " " & f.IdString)
                                mb.ShowDialog()
                                End
                            End If
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
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Riscontrata exception durante l'EditId " & r.Table.TableName)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in Edit: " & r.Table.TableName & " - " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message & " " & r.Table.TableName, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        Debug.Print("Edit(ok): " & r.Table.TableName & " " & stopwatch.Elapsed.ToString)
        My.Application.Log.DefaultFileLogWriter.WriteLine("Edit(ok): " & r.Table.TableName & " " & stopwatch.Elapsed.ToString)
        Return r
    End Function

End Module