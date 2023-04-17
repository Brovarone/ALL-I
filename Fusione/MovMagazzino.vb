Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports ALLSystemTools.SqlTools
Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions

Module MovMagazzino
    'TODO Chiedere se sviluppare simile a saldo cespiti
    Private MovMagUnoCntx As MovMagContext
    Private MovMagSpaCntx As MovMagContext

    Public Function RipresaSaldiArticoli() As Boolean
        Dim ok As Boolean
        ok = ScriviMovimentoMagazzino(Not IsDebugging)
        ScriviLog("Fine processo")
        Return ok
    End Function

    Private Function ScriviMovimentoMagazzino(commit As Boolean) As Boolean
        Dim sLoginId As String = My.Settings.mLOGINID
        Dim sdata As String = New DateTime(2023, 4, 1).ToString
        Dim fiscalYear As Integer = 2024
        Dim someTrouble As Boolean = False
        Const Causale As String = "FUSIONE"

        If LINQ_MovMagazzino() Then

            'Estraggo Giacenza per Depositi
            Dim deps_qty = From c In MovMagUnoCntx.MaItemsStorageQty _
                               .OrderBy(Function(o) o.Storage).ThenBy(Function(o1) o1.Specificator).ThenBy(Function(o2) o2.Item) _
                               .Include(Of MaItemsNoRef)(Function(i) i.ItemNavigation) _
                               .Where(Function(fy) fy.FiscalYear = fiscalYear And (fy.InitialQty <> 0)).ToList
            'OrElse fy.OrderedPurchOrd <> 0 OrElse fy.ReservedSaleOrd <> 0
            Dim fisData = From fis In MovMagUnoCntx.MaItemsFiscalData.Where(Function(fi) fi.FiscalYear = fiscalYear)
            Dim idLinq = From ids In MovMagSpaCntx.MaIdnumbers.Where(Function(fi) fi.CodeType = IdType.MovMagazzino)

            'Creo le entities che usero' poi con BulkInsert
            Dim efInventoryEntries As New List(Of MaInventoryEntries)
            Dim efInventoryEntriesDetail As New List(Of MaInventoryEntriesDetail)
            Dim efIdNumbers As List(Of MaIdnumbers) = idLinq.ToList

            Dim entryId As Integer = efIdNumbers.FirstOrDefault.LastId ' Ultimo ID
            Dim iNewRowsCount As Integer 'Contatore Line e SubId
            Dim iNrEntryForStorage As Integer 'Contatore Scritture per Deposito
            Dim currentStorage As String
            Dim currentSpecificator As String

            If deps_qty.Any Then
                Dim totRighe As Integer = deps_qty.Count
                Dim msg As String = "Tot Righe : " & totRighe.ToString
                ScriviLog_Debug(msg)
                FLogin.lstStatoConnessione.Items.Add(msg)
                EditTestoBarra(msg)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totRighe
                FLogin.prgCopy.Step = 1

                iNewRowsCount = 1
                entryId += 1
                iNrEntryForStorage = 1
                efIdNumbers.FirstOrDefault.LastId = entryId
                currentStorage = deps_qty.FirstOrDefault.Storage
                currentSpecificator = deps_qty.FirstOrDefault.Specificator

                For Each d In deps_qty
                    AvanzaBarra()
                    Debug.Print("Deposito: " & d.Storage & " articolo " & d.Item)
                    'Inizializzazione
                    If iNewRowsCount = 100 OrElse Not currentStorage.Equals(d.Storage) OrElse Not currentSpecificator.Equals(d.Specificator) Then
                        'Nuova scrittura
                        iNewRowsCount = 1
                        entryId += 1
                        iNrEntryForStorage = 1
                        efIdNumbers.FirstOrDefault.LastId = entryId
                        currentStorage = d.Storage
                        currentSpecificator = d.Specificator

                    End If
                    'Testa
                    If iNewRowsCount = 1 Then
                        'Creo testa 
                        Dim head As New MaInventoryEntries With {
                            .InvRsn = Causale,
                            .StubBook = String.Empty,
                            .PostingDate = sdata,
                            .CustSuppType = 6094850,
                            .CustSupp = String.Empty,
                            .DocNo = Left(d.Storage, 7) & "_" & iNrEntryForStorage.ToString, ' Deposito
                            .DocumentDate = sdata,
                            .StoragePhase1 = d.Storage,
                            .Specificator1Type = d.SpecificatorType,
                            .SpecificatorPhase1 = d.Specificator,
                            .Currency = "EUR",
                            .Notes = String.Empty,
                            .EntryId = entryId, '.LastSubId = 1,
                            .AccrualDate = sdata,
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efInventoryEntries.Add(head)

                    End If
                    'Creo Righe 
                    'Estraggo Giacenza
                    Dim f = fisData.Single(Function(fy) fy.Item.Equals(d.Item))
                    Dim valIniziale As Double = f.InitialBookInvValue
                    Dim qtyIniziale As Double = f.InitialBookInv
                    Dim valUnit As Double = Math.Round(valIniziale / qtyIniziale, 5)
                    Dim qty As Double = d.InitialQty

                    Dim det As New MaInventoryEntriesDetail With {
                        .EntryId = entryId,
                        .PostingDate = sdata,
                        .Item = d.Item,
                        .UoM = d.ItemNavigation.BaseUoM,
                        .Qty = qty,
                        .UnitValue = valUnit,
                        .LineAmount = Math.Round(valUnit * qty, 5),
                        .Line = iNewRowsCount,
                        .SubId = iNewRowsCount,
                        .AccrualDate = sdata,
                        .InvRsn = Causale,
                        .Tbcreated = Now,
                        .Tbmodified = Now,
                        .TbcreatedId = sLoginId,
                        .TbmodifiedId = sLoginId
                        }
                    'Aggiungo la riga alla collection
                    efInventoryEntriesDetail.Add(det)
                    iNewRowsCount += 1
                Next

                'Adeguo LastSubId nelle teste
                For Each t In efInventoryEntries
                    t.LastSubId = efInventoryEntriesDetail.Where(Function(st) st.EntryId = t.EntryId).Max(Function(m) m.SubId)
                Next
            End If

            Using bulkTrans = MovMagSpaCntx.Database.BeginTransaction
                Dim iStep As Integer
                Try
                    MovMagSpaCntx.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento teste ")
                    If efInventoryEntries.Any Then
                        Dim t = efInventoryEntries.Count
                        Dim cfgFixAss As New BulkConfig With {
                                .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                .BulkCopyTimeout = 0,
                                .CalculateStats = True,
                                .BatchSize = If(t < 5000, 0, t / 10),
                                .NotifyAfter = t / 10
                                }
                        MovMagSpaCntx.BulkInsertOrUpdate(efInventoryEntries, cfgFixAss, Function(d) d)
                        Dim msg As String = "InvetoryEntries Ins:" & cfgFixAss.StatsInfo.StatsNumberInserted.ToString
                        ScriviLog_Debug(msg)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento righe ")
                    If efInventoryEntriesDetail.Any Then
                        Dim t = efInventoryEntriesDetail.Count
                        Dim cfgFixAssDet As New BulkConfig With {
                                .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                .BulkCopyTimeout = 0,
                                .CalculateStats = True,
                                .BatchSize = If(t < 5000, 0, t / 10),
                                .NotifyAfter = t / 10
                                }
                        MovMagSpaCntx.BulkInsertOrUpdate(efInventoryEntriesDetail, cfgFixAssDet, Function(d) d)
                        Dim msg As String = "InvetoryEntriesDetail Ins:" & cfgFixAssDet.StatsInfo.StatsNumberInserted.ToString
                        ScriviLog_Debug(msg)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Ids Movimenti Magazzino")
                    If efIdNumbers.Any Then
                        Dim t = efIdNumbers.Count
                        Dim cfgIdNumbers As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        MovMagSpaCntx.BulkInsertOrUpdate(efIdNumbers, cfgIdNumbers, Function(d) d)
                        Dim msg As String = "IdNumbers Ins:" & cfgIdNumbers.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgIdNumbers.StatsInfo.StatsNumberUpdated.ToString
                        ScriviLog_Debug(msg)
                    End If

                    If someTrouble Then
                        bulkTrans.Rollback()
                        ScriviLog_Debug("[Salvataggio] Sono stati riscontrati degli errori. Eseguita rollback")
                    Else
                        bulkTrans.Commit()
                        FLogin.lstStatoConnessione.Items.Add(" --- Inserimento Dati ---")
                    End If
                    MovMagSpaCntx.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

                Catch ex As Exception
                    someTrouble = True
                    Debug.Print(ex.Message)
                    FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori allo step " & iStep)
                    ScriviLog_Debug("[Salvataggio] - STEP: " & iStep & " - Sono stati riscontrati degli errori. (Vedere sezione Errori)")
                    ScriviLog_Debug("[Salvataggio] Messaggio:" & ex.Message)
                    ScriviLog_Debug("[Salvataggio] Stack:" & ex.StackTrace)

                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                End Try
            End Using

            MovMagUnoCntx.Dispose()
            MovMagSpaCntx.Dispose()

        End If
        Return someTrouble
    End Function
    ''' <summary>
    ''' Si collega a entrambi i database con context MovMagazzino
    ''' </summary>
    ''' <returns></returns>
    Private Function LINQ_MovMagazzino() As Boolean
        Dim bStatus As Boolean = False

        Dim cs As String = GetConnectionStringUNO(True)
        Dim dbcb As New DbContextOptionsBuilder(Of MovMagContext)
        dbcb.UseSqlServer(cs)
        MovMagUnoCntx = New MovMagContext(dbcb.Options)
        Debug.Print("Connessione a Context EF: " & MovMagUnoCntx.Database.CanConnect.ToString & " Su DB:") ' & DB)

        cs = GetConnectionStringSPA(True)
        'dbcb = New DbContextOptionsBuilder(Of MovCespiteContext)
        dbcb.UseSqlServer(cs)
        ' lstStatoConnessione.Items.Add("Connessione al database: " & DB)
        MovMagSpaCntx = New MovMagContext(dbcb.Options)
        Debug.Print("Connessione a Context EF: " & MovMagSpaCntx.Database.CanConnect.ToString & " Su DB:") ' & DB)

        If MovMagUnoCntx.Database.CanConnect Then ' connection ok
            MovMagUnoCntx.Database.ExecuteSqlRaw("SET ARITHABORT ON")
            bStatus = True
        End If
        If MovMagSpaCntx.Database.CanConnect Then ' connection ok
            MovMagSpaCntx.Database.ExecuteSqlRaw("SET ARITHABORT ON")
            bStatus = True
        End If

        Return bStatus
    End Function
End Module
