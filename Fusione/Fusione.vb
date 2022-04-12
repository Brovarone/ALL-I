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
        Public Property Nome As String
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
        dsDestination = New DataSet

        Dim dvIDS = New DataView(dtIDS, "", "Key", DataViewRowState.CurrentRows)
        FLogin.prgCopy.Value = 1
        FLogin.prgCopy.Step = 1
        FLogin.prgCopy.Maximum = 6

        ok = EditFatture(dvIDS)
        FLogin.prgCopy.PerformStep()
        If Not ok Then someTrouble = True
        'EditAcquisti
        'EditClienti
        'EditCespiti
        'EditBanche
        'EditOrdiniCliente
        Return someTrouble
    End Function

    Private Function EditFatture(ByVal dv As DataView) As Boolean

        Dim lIDS As New List(Of IDS)
        Dim SaleDocId As Integer
        Dim found As Integer = dv.Find("SaleDocId")
        If found = -1 Then
            Debug.Print("Fatture SaleDocId: non trovato")
            My.Application.Log.WriteEntry("Fatture SaleDocId: non trovato")
            MessageBox.Show("Impossibile continuare,Fatture SaleDocId: non trovato nel file IDS")
            End
        Else
            SaleDocId = CInt(dv(found)("NewKey"))
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = SaleDocId,
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

        End If

        Try
            'Fatture
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDoc"), lIDS))

            lIDS.Clear()
            lIDS.Add(New IDS With {
                .Chiave = True,
                .Id = SaleDocId,
                .Nome = "SaleDocId",
                .Operatore = "+"
            })
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocComponents"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocManufReasons"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocNotes"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocPymtSched"), lIDS))
            'dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocReferences"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocShipping"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocSummary"), lIDS))
            dsDestination.Tables.Add(EditId(dsOrigin.Tables("MA_SaleDocTaxSummary"), lIDS))
            '  dsDestination.Tables.Add( EditId(dsOrigin.Tables( "MA_EIEventViewer"), lIDS))
            '  dsDestination.Tables.Add( EditId(dsOrigin.Tables( "MA_EI_ITDocAdditionalData"), lIDS))
            '  dsDestination.Tables.Add( EditId(dsOrigin.Tables( "MA_EI_ITAsyncComm"), lIDS))
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

    Private Function EditId(ByVal dt As DataTable, id As List(Of IDS)) As DataTable
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim dv As DataView = dt.DefaultView
        Dim keyIDS As IDS = id.Find(Function(p) p.Chiave = True)
        dv.Sort = keyIDS.Nome & " desc"
        Try
            For Each r As DataRowView In dv
                For Each f As IDS In id
                    r.Item(f.Nome) = If(f.Operatore = "+", CInt(r.Item(f.Nome)) + f.Id, f.Id)
                Next
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori durante l'EditId " & dt.TableName)

            Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        Debug.Print("Edit " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        Return dv.ToTable
    End Function

    Private Class IDS
        Public Property Chiave As Boolean
        Public Property Nome As String
        Public Property Id As Integer
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