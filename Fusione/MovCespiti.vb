Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports ALLSystemTools.SqlTools
Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions

Module MovCespiti
    Private MovCesUnoCntx As MovCespiteContext
    Private MovCesSpaCntx As MovCespiteContext

    Public Function RipresaSaldiCespiti() As Boolean
        Dim ok As Boolean
        ok = ScriviMovimentoCespite(Not IsDebugging)
        ScriviLog("Fine processo")
        Return ok
    End Function

    Private Function ScriviMovimentoCespite(commit As Boolean) As Boolean
        Dim sLoginId As String = My.Settings.mLOGINID
        Dim sdata As String = New DateTime(2023, 4, 1).ToString
        Dim fiscalYear As Integer = 2024
        Dim someTrouble As Boolean = False
        Dim prefisso As String = "A"

        If LINQ_Cespiti() Then

            'Estraggo le due entità Fiscale e Bilancio
            Dim f = From c In MovCesUnoCntx.MaFixedAssetsFiscal _
                        .Include("MaFixedAssets") _
                        .Where(Function(ffis) ffis.FiscalYear = fiscalYear)


            Dim b = From c In MovCesUnoCntx.MaFixedAssetsBalance _
                        .Include("MaFixedAssets") _
                        .Where(Function(fbil) fbil.FiscalYear = fiscalYear)

            Dim idLinq = From ids In MovCesSpaCntx.MaIdnumbers.Where(Function(fi) fi.CodeType = IdType.MovCespite)

            'NON VA provare a migrare a .net 6 !!!!
            'Dim q = From c In MovCesUnoCntx.MaFixedAssets _
            '.Include(Function(fis) fis.MaFixedAssetsFiscal) _
            '.Include(Function(bal) bal.MaFixedAssetsBalance) _
            '.Include(Function(fin) fin.MaFixedAssetsFinancial)

            'q = q.Where(Function(ffis) ffis.MaFixedAssetsFiscal.Any(Function(ff) ff.FiscalYear = fiscalYear))
            'q = q.Where(Function(fbil) fbil.MaFixedAssetsBalance.Any(Function(fb) fb.FiscalYear = fiscalYear))

            'Creo le entities che usero' poi con BulkInsert
            Dim efFixAssEntries As New List(Of MaFixAssetEntries)
            Dim efFixAssetEntriesDetail As New List(Of MaFixAssetEntriesDetail)
            Dim efIdNumbers As List(Of MaIdnumbers) = idLinq.ToList

            Dim entryId As Integer = efIdNumbers.FirstOrDefault.LastId ' Ultimo ID
            Dim entryIdFondo As Integer = entryId + 1 ' Ultimo ID
            'devo prevedere un salto scrittura ogni tot righe ( 100??)
            Dim iNewRowsCount As Integer
            Dim iNrReg As Integer

            'Genero 4 movimenti di ripresa
            'FISCALE
            If f.Any Then
                Dim totCespiti As Integer = f.Count
                Dim msg As String = "Fis_Cespiti : " & totCespiti.ToString
                ScriviLog_Debug(msg)
                FLogin.lstStatoConnessione.Items.Add(msg)
                EditTestoBarra(msg)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totCespiti
                FLogin.prgCopy.Step = 1

                iNewRowsCount = 1
                entryId += 1
                entryIdFondo = entryId + 1
                efIdNumbers.FirstOrDefault.LastId = entryIdFondo
                iNrReg = 1
                For Each c In f
                    AvanzaBarra()
                    Debug.Print("Fis_Cespite: " & c.FixedAsset)
                    'Inizializzazione
                    If iNewRowsCount >= 99 Then
                        'Nuova scrittura
                        iNewRowsCount = 1
                        entryId += 2 ' due perche' devo contare anche la scrittura del Fondo "entryfondo
                        entryIdFondo = entryId + 1
                        efIdNumbers.FirstOrDefault.LastId = entryIdFondo
                        iNrReg += 1
                    End If
                    'Testa
                    If iNewRowsCount = 1 Then
                        'Creo testa Totale ammortizzabile
                        Dim head As New MaFixAssetEntries With {
                            .Farsn = CauCes.RipTotAmF.Codice,
                            .PostingDate = sdata,
                            .DocumentDate = sdata,
                            .DocNo = iNrReg.ToString,
                            .CustSuppType = 6094850,
                            .EntryId = entryId,
                            .Currency = "EUR",
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efFixAssEntries.Add(head)
                        'Creo testa Fondo
                        Dim headFondo As New MaFixAssetEntries With {
                            .Farsn = CauCes.RipFondoF.Codice,
                            .PostingDate = sdata,
                            .DocumentDate = sdata,
                            .DocNo = iNrReg.ToString,
                            .CustSuppType = 6094850,
                            .EntryId = entryIdFondo,
                            .Currency = "EUR",
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efFixAssEntries.Add(headFondo)
                    End If
                    'Creo Righe Totale ammortizzabile
                    Dim det As New MaFixAssetEntriesDetail With {
                                 .EntryId = entryId,
                                 .Line = iNewRowsCount,
                                 .CodeType = c.CodeType,
                                 .FixedAsset = prefisso & c.FixedAsset,
                                 .PostingDate = sdata,
                                 .Qty = 0, '???
                                 .Perc = 0,
                                 .Amount = c.InitialTotalDepreciable,
                                 .Notes = String.Empty,
                                 .Currency = c.Currency,  'EUR
                                 .AmountDocCurr = 0,
                                 .Tbcreated = Now,
                                 .Tbmodified = Now,
                                 .TbcreatedId = sLoginId,
                                 .TbmodifiedId = sLoginId
                             }
                    'Aggiungo la riga alla collection
                    efFixAssetEntriesDetail.Add(det)
                    'Creo Righe Fondo
                    Dim detFondo As New MaFixAssetEntriesDetail With {
                                 .EntryId = entryIdFondo,
                                 .Line = iNewRowsCount,
                                 .CodeType = c.CodeType,
                                 .FixedAsset = prefisso & c.FixedAsset,
                                 .PostingDate = sdata,
                                 .Qty = 0, '???
                                 .Perc = 0,
                                 .Amount = c.InitialAccumDepr + c.InitialAcceleratedAccumDepr,
                                 .Notes = String.Empty,
                                 .Currency = c.Currency,  'EUR
                                 .AmountDocCurr = 0,
                                 .Tbcreated = Now,
                                 .Tbmodified = Now,
                                 .TbcreatedId = sLoginId,
                                 .TbmodifiedId = sLoginId
                             }
                    'Aggiungo la riga alla collection
                    efFixAssetEntriesDetail.Add(detFondo)
                    iNewRowsCount += 1
                Next
            End If
            'BILANCIO
            If b.Any Then
                Dim totCespiti As Integer = b.Count
                Dim msg As String = "Bil_Cespiti : " & totCespiti.ToString
                ScriviLog_Debug(msg)
                FLogin.lstStatoConnessione.Items.Add(msg)
                EditTestoBarra(msg)
                FLogin.prgCopy.Value = 1
                FLogin.prgCopy.Maximum = totCespiti
                FLogin.prgCopy.Step = 1

                iNewRowsCount = 1
                entryId += 2 ' due perche' devo contare anche la scrittura del Fondo "entryfondo
                entryIdFondo = entryId + 1
                efIdNumbers.FirstOrDefault.LastId = entryIdFondo
                iNrReg = 1
                For Each c In b
                    AvanzaBarra()
                    Debug.Print("Bil_Cespite : " & c.FixedAsset)
                    'Inizializzazione
                    If iNewRowsCount = 99 Then
                        'Nuova scrittura
                        iNewRowsCount = 1
                        entryId += 2 ' due perche' devo contare anche la scrittura del Fondo "entryfondo
                        entryIdFondo = entryId + 1
                        efIdNumbers.FirstOrDefault.LastId = entryIdFondo
                        iNrReg += 1
                    End If
                    'Testa
                    If iNewRowsCount = 1 Then
                        'Creo testa Totale ammortizzabile
                        Dim head As New MaFixAssetEntries With {
                            .Farsn = CauCes.RipTotAmB.Codice,
                            .PostingDate = sdata,
                            .DocumentDate = sdata,
                            .DocNo = iNrReg.ToString,
                            .CustSuppType = 6094850,
                            .EntryId = entryId,
                            .Currency = "EUR",
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efFixAssEntries.Add(head)
                        'Creo testa Fondo
                        Dim headFondo As New MaFixAssetEntries With {
                            .Farsn = CauCes.RipFondoB.Codice,
                            .PostingDate = sdata,
                            .DocumentDate = sdata,
                            .DocNo = iNrReg.ToString,
                            .CustSuppType = 6094850,
                            .EntryId = entryIdFondo,
                            .Currency = "EUR",
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efFixAssEntries.Add(headFondo)
                    End If
                    'Creo Righe Totale ammortizzabile
                    Dim det As New MaFixAssetEntriesDetail With {
                                 .EntryId = entryId,
                                 .Line = iNewRowsCount,
                                 .CodeType = c.CodeType,
                                 .FixedAsset = prefisso & c.FixedAsset,
                                 .PostingDate = sdata,
                                 .Qty = 0, '???
                                 .Perc = 0,
                                 .Amount = c.InitialTotalDepreciable,
                                 .Notes = String.Empty,
                                 .Currency = c.Currency,  'EUR
                                 .AmountDocCurr = 0,
                                 .Tbcreated = Now,
                                 .Tbmodified = Now,
                                 .TbcreatedId = sLoginId,
                                 .TbmodifiedId = sLoginId
                             }
                    'Aggiungo la riga alla collection
                    efFixAssetEntriesDetail.Add(det)
                    'Creo Righe Fondo
                    Dim detFondo As New MaFixAssetEntriesDetail With {
                                 .EntryId = entryIdFondo,
                                 .Line = iNewRowsCount,
                                 .CodeType = c.CodeType,
                                 .FixedAsset = prefisso & c.FixedAsset,
                                 .PostingDate = sdata,
                                 .Qty = 0, '???
                                 .Perc = 0,
                                 .Amount = c.InitialAccumDepr,
                                 .Notes = String.Empty,
                                 .Currency = c.Currency,  'EUR
                                 .AmountDocCurr = 0,
                                 .Tbcreated = Now,
                                 .Tbmodified = Now,
                                 .TbcreatedId = sLoginId,
                                 .TbmodifiedId = sLoginId
                             }
                    'Aggiungo la riga alla collection
                    efFixAssetEntriesDetail.Add(detFondo)
                    iNewRowsCount += 1

                Next
            End If

            Using bulkTrans = MovCesSpaCntx.Database.BeginTransaction
                Dim iStep As Integer
                Try
                    MovCesSpaCntx.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento teste Ammortamenti")
                    If efFixAssEntries.Any Then
                        Dim t = efFixAssEntries.Count
                        Dim cfgFixAss As New BulkConfig With {
                                .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                .BulkCopyTimeout = 0,
                                .CalculateStats = True,
                                .BatchSize = If(t < 5000, 0, t / 10),
                                .NotifyAfter = t / 10
                                }
                        MovCesSpaCntx.BulkInsertOrUpdate(efFixAssEntries, cfgFixAss, Function(d) d)
                        Dim msg As String = "FixAssEntries Ins:" & cfgFixAss.StatsInfo.StatsNumberInserted.ToString
                        ScriviLog_Debug(msg)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento righe Ammortamenti")
                    If efFixAssetEntriesDetail.Any Then
                        Dim t = efFixAssetEntriesDetail.Count
                        Dim cfgFixAssDet As New BulkConfig With {
                                .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                .BulkCopyTimeout = 0,
                                .CalculateStats = True,
                                .BatchSize = If(t < 5000, 0, t / 10),
                                .NotifyAfter = t / 10
                                }
                        MovCesSpaCntx.BulkInsertOrUpdate(efFixAssetEntriesDetail, cfgFixAssDet, Function(d) d)
                        Dim msg As String = "FixAssetEntriesDetail Ins:" & cfgFixAssDet.StatsInfo.StatsNumberInserted.ToString
                        ScriviLog_Debug(msg)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Ids Ammortamenti")
                    If efIdNumbers.Any Then
                        Dim t = efIdNumbers.Count
                        Dim cfgIdNumbers As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        MovCesSpaCntx.BulkInsertOrUpdate(efIdNumbers, cfgIdNumbers, Function(d) d)
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
                    MovCesSpaCntx.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

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

            MovCesUnoCntx.Dispose()
            MovCesSpaCntx.Dispose()

        End If
        Return someTrouble
    End Function
    ''' <summary>
    ''' Si collega a entrambi i database con context CESPITI
    ''' </summary>
    ''' <returns></returns>
    Private Function LINQ_Cespiti() As Boolean
        Dim bStatus As Boolean = False

        Dim cs As String = GetConnectionStringUNO(True)
        Dim dbcb As New DbContextOptionsBuilder(Of MovCespiteContext)
        dbcb.UseSqlServer(cs)
        MovCesUnoCntx = New MovCespiteContext(dbcb.Options)
        Debug.Print("Connessione a Context EF: " & MovCesUnoCntx.Database.CanConnect.ToString & " Su DB: Uno") ' & DB)

        cs = GetConnectionStringSPA(True)
        'dbcb = New DbContextOptionsBuilder(Of MovCespiteContext)
        dbcb.UseSqlServer(cs)
        ' lstStatoConnessione.Items.Add("Connessione al database: " & DB)
        MovCesSpaCntx = New MovCespiteContext(dbcb.Options)
        Debug.Print("Connessione a Context EF: " & MovCesSpaCntx.Database.CanConnect.ToString & " Su DB: Spa") ' & DB)

        If MovCesUnoCntx.Database.CanConnect Then ' connection ok
            MovCesUnoCntx.Database.ExecuteSqlRaw("SET ARITHABORT ON")
            bStatus = True
        End If
        If MovCesSpaCntx.Database.CanConnect Then ' connection ok
            MovCesSpaCntx.Database.ExecuteSqlRaw("SET ARITHABORT ON")
            bStatus = True
        End If

        Return bStatus
    End Function
End Module
