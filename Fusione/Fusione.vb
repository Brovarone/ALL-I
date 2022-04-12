Imports System
Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.EF
Imports EFCore.BulkExtensions
'TODO: valutare implementazioni Fattura elettronica 
'Todo: Dichiarazione intento lettera W ( magari impostare un campo in anagrafica cliente/ordine) e aggiungerlo agli step di pre-invio( tipo quello dei dati canoni ) ma ne verrano fuori altri

Module Fusione

    Dim dsOrigin As DataSet
    Dim dsDestination As DataSet
    Dim dtIDS As DataTable

    Private Class TabelleDaEstrarre
        Public Property Filtro As String
        Public Nome As String
        Public Sub New()
            Filtro = ""
            Nome = ""
        End Sub
    End Class

    Public Function EseguiFusione(dts As DataSet) As Boolean
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
        'Fatture
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDoc", .Filtro = ""})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocComponents"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocDetail"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocManufReasons"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocNotes"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocPymtSched"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocReferences"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocShipping"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocSummary"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocTaxSummary"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EIEventViewer"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITDocAdditionalData"})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITAsyncComm"})

        'Acquisti ( solo bolle di carico)
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDoc", .Filtro = qry & "MA_PurchaseDoc WHERE DocumentType =  9830400"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocDetail"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocNotes"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocPymtSched"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocReferences"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocShipping"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocSummary"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocTaxSummary"})

        'Clienti
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .Filtro = qry & "MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppBranches", .Filtro = ""})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppCustomerOptions"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNaturalPerson"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNotes"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppOutstandings"}) ' Insoluti
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppPeople"})
        '
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_DeclarationOfIntent"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SDDMandate"})

        'Cespiti
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssets"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsBalance"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsCoeff"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFinancial"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFiscal"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsPeriod"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetLocations"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetsClasses"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetsCtg"})

        'Banche
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Banks", .Filtro = qry & "MA_Banks WHERE IsACompanyBank = 0"})

        'Ordini Clienti
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrd", .Filtro = ""})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdAllocationPriority"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdComponents"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdDetails"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdNotes"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdPymtSched"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdReferences"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdShipping"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdSummary"})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdTaxSummary"})
#End Region

        dsOrigin = New DataSet
        Try
            FLogin.prgCopy.Value = 1
            FLogin.prgCopy.Step = 1
            FLogin.prgCopy.Maximum = tabelle.Count
            Dim stopwatch As New System.Diagnostics.Stopwatch
            stopwatch.Start()

            For Each t In tabelle
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico dati: " & t.Nome)
                Using dt As DataTable = CaricaSchema(t.Nome, False, True, t.Filtro)
                    dsOrigin.Tables.Add(dt)
                End Using
                FLogin.prgCopy.PerformStep()
                FLogin.prgCopy.Update()
                Application.DoEvents()
            Next
            stopwatch.Stop()
            Debug.Print(stopwatch.Elapsed.ToString)
            FLogin.lstStatoConnessione.Items.Add(stopwatch.Elapsed.ToString)
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

        Dim dvIDS = New DataView(dtIDS, "", "NewKey", DataViewRowState.CurrentRows)
        'Dim iCIDFound As Integer = dvIDS.Find("SaleDocId")
        'If iCdcFound = -1 Then
        '    Debug.Print("Centro di Costo senza corrispondenza: " & CdC)
        '    My.Application.Log.WriteEntry("Centro di Costo senza corrispondenza:" & CdC)
        '    MessageBox.Show("Impossibile continuare, centro di costo non presente:" & CdC)
        '    End
        'End If
        ok = EditFatture()
        If Not ok Then someTrouble = True
        'EditAcquisti
        'EditClienti
        'EditCespiti
        'EditBanche
        'EditOrdiniCliente
        Return someTrouble
    End Function

    Private Function EditFatture() As Boolean
        dsDestination = New DataSet
        Dim id As Integer = 111
        Try
            'Fatture
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDoc"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocComponents"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocDetail"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocManufReasons"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocNotes"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocPymtSched"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocReferences"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocShipping"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocSummary"), "SaleDocId", id))
            dsDestination.Tables.Add(SumId(dsOrigin.Tables("MA_SaleDocTaxSummary"), "SaleDocId", id))
            '  dsDestination.Tables.Add( SumId(dsOrigin.Tables( "MA_EIEventViewer"), "SaleDocId", id))
            '  dsDestination.Tables.Add( SumId(dsOrigin.Tables( "MA_EI_ITDocAdditionalData"), "SaleDocId", id))
            '  dsDestination.Tables.Add( SumId(dsOrigin.Tables( "MA_EI_ITAsyncComm"), "SaleDocId", id))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function SumId(ByVal dt As DataTable, field As String, id As Integer) As DataTable
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim dv As DataView = dt.DefaultView
        dv.Sort = field & " desc"
        For Each r As DataRowView In dv
            r.Item(field) = r.Item(field) + id
        Next
        Debug.Print("Edit " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        Return dv.ToTable
    End Function
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

            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", ConnectionSpa)
                cmdqry.ExecuteNonQuery()
                Using bulkTrans = ConnectionSpa.BeginTransaction
                    'Ciclo su ogni tabella
                    FLogin.prgCopy.Maximum = dsDestination.Tables.Count
                    FLogin.prgCopy.Step = 1
                    FLogin.prgCopy.Value = 1
                    For Each t As DataTable In dsDestination.Tables
                        iStep += 1
                        Dim s As String = t.TableName
                        EditTestoBarra("Salvataggio: " & s)
                        okBulk = ScriviBulk(s, t, bulkTrans, ConnectionSpa, DataRowState.Unchanged, loggingTxt, True)
                        If Not okBulk Then someTrouble = True
                        bulkMessage.AppendLine(loggingTxt)
                        FLogin.prgCopy.PerformStep()
                        FLogin.prgCopy.Update()
                        Application.DoEvents()
                    Next

                    If someTrouble Then
                        FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                        bulkTrans.Rollback()
                    Else
                        bulkTrans.Commit()
                    End If
                    Debug.Print("Fine bulk")
                End Using
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