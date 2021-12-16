Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.MethodBase

Namespace MySqlServerBackup
    Module Utilities

        Public Sub Backup()
            FLogin.Cursor = Cursors.WaitCursor
            FLogin.PanelUser.Enabled = False
            Try
                Dim connectionString As String = "Data Source=" & My.Settings.mSQLSERVER & "; Database=msdb;User Id=" & My.Settings.mID & ";Password=" & My.Settings.mPSW & ";"
                Dim databaseName As String = My.Settings.mDATABASE

                'Dim backupFileName As String = "Backup_" & databaseName & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".bak"
                Dim backupFileName As String = databaseName & ".bak"
                Dim backupFilePath As String
                Dim sqry As String = "SELECT database_name AS DBName, physical_device_name AS BackupLocation, CASE WHEN [TYPE]='D' THEN 'FULL' WHEN [TYPE]='I' THEN 'DIFFERENTIAL' WHEN [TYPE]='L' THEN 'LOG' WHEN [TYPE]='F' THEN 'FILE / FILEGROUP' WHEN [TYPE]='G'  THEN 'DIFFERENTIAL FILE' WHEN [TYPE]='P' THEN 'PARTIAL' WHEN [TYPE]='Q' THEN 'DIFFERENTIAL PARTIAL' END AS BackupType ,backup_finish_date AS BackupFinishDate FROM backupset JOIN backupmediafamily ON(backupset.media_set_id=backupmediafamily.media_set_id) Where database_name = @DBname ORDER BY backup_finish_date DESC"
                FLogin.lstStatoConnessione.Items.Add("BACKUP DATABASE: " & databaseName)
                FLogin.lstStatoConnessione.Refresh()

                Using conn = New SqlConnection(connectionString)
                    conn.FireInfoMessageEventOnUserErrors = True
                    Dim cmd As New SqlCommand(sqry, conn)
                    cmd.Parameters.AddWithValue("@DBname", My.Settings.mDATABASE)
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 0
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    reader.Read()
                    If reader.HasRows Then
                        FLogin.lstStatoConnessione.Items.Add("Attendere... il processo potrebbe durare qualche minuto")
                        FLogin.lstStatoConnessione.Refresh()

                        FLogin.prgCopy.Minimum = 0
                        FLogin.prgCopy.Maximum = 100
                        FLogin.prgCopy.Step = 10
                        backupFilePath = Path.Combine(Path.GetDirectoryName(reader.Item("BackupLocation")), backupFileName)
                        FLogin.lstStatoConnessione.Items.Add("Destinazione: " & backupFilePath)
                        FLogin.lstStatoConnessione.Refresh()
                        reader.Close()

                        Dim sql = String.Format("BACKUP DATABASE {0} To DISK='{1}' WITH RETAINDAYS = 2,NOFORMAT, INIT, SKIP, STATS = 10", databaseName, backupFilePath)
                        Using cmdB As SqlCommand = conn.CreateCommand()
                            cmdB.CommandTimeout = 0
                            cmdB.CommandText = sql
                            AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
                            cmdB.ExecuteNonQuery()
                            RemoveHandler conn.InfoMessage, AddressOf OnInfoMessage

                        End Using
                    End If
                End Using

                '  For Each backupDir In backupDirs.Where(Function(x) x <> backupDirs(0))
                '  File.Copy(backupFilePath, Path.Combine(backupDir, backupFileName))
                '  Next

            Catch ex As Exception
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            Finally
            End Try
            FLogin.PanelUser.Enabled = True
            FLogin.lstStatoConnessione.Items.Add("Salvataggio completato.")
            FLogin.prgCopy.Value = 0
            FLogin.Cursor = Cursors.Arrow
        End Sub
        Private Sub OnInfoMessage(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlInfoMessageEventArgs)
            FLogin.prgCopy.PerformStep()
            FLogin.prgCopy.Refresh()
            Debug.Print(e.Message)
        End Sub
    End Module
End Namespace
