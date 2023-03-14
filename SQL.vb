Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.MethodBase

Namespace SqlTools
    Module Connessione
        Public Function GetConnectionStringSPAAsync() As String
            Dim DB As String = If(DBisTMP, FLogin.TxtTmpDB_SPA.Text, FLogin.TxtDB_SPA.Text)
            ' To avoid storing the connection string in your code,            
            ' you can retrieve it from a configuration file. 

            ' If you have not included "Asynchronous Processing=true" in the
            ' connection string, the command is not able
            ' to execute asynchronously.
            Return "Data Source=" & FLogin.txtSERVER.Text & "; Database=" & DB & ";User Id=" & FLogin.txtID.Text & ";Password=" & FLogin.txtPSW.Text & ";" & " Asynchronous Processing=True;"
        End Function
        Public Function GetConnectionStringSPA() As String
            Dim DB As String = If(DBisTMP, FLogin.TxtTmpDB_SPA.Text, FLogin.TxtDB_SPA.Text)
            Return "Data Source=" & FLogin.txtSERVER.Text & "; Database=" & DB & ";User Id=" & FLogin.txtID.Text & ";Password=" & FLogin.txtPSW.Text & ";" & " Pooling=True;"
        End Function
        Public Function GetConnectionStringUNO() As String
            Dim DB As String = If(DBisTMP, FLogin.TxtTmpDB_UNO.Text, FLogin.TxtDB_UNO.Text)
            Return "Data Source=" & FLogin.txtSERVER.Text & "; Database=" & DB & ";User Id=" & FLogin.txtID.Text & ";Password=" & FLogin.txtPSW.Text & ";" & " Pooling=True;"
        End Function
        Public Sub RunNonQueryAsynchronously(ByVal commandText As String, ByVal connectionString As String)

            ' Given command text and connection string, asynchronously execute
            ' the specified command against the connection. For this example,
            ' the code displays an indicator as it is working, verifying the 
            ' asynchronous behavior. 
            Using connection As New SqlConnection(connectionString)
                Try
                    Dim count As Integer = 0
                    Dim command As New SqlCommand(commandText, connection)
                    connection.Open()
                    Dim result As IAsyncResult = command.BeginExecuteNonQuery()
                    While Not result.IsCompleted
                        Console.WriteLine("Waiting ({0})", count)
                        ' Wait for 1/10 second, so the counter
                        ' does not consume all available resources 
                        ' on the main thread.
                        Threading.Thread.Sleep(100)
                        count += 1
                    End While
                    Console.WriteLine("Command complete. Affected {0} rows.", command.EndExecuteNonQuery(result))
                Catch ex As SqlException
                    Console.WriteLine("Error ({0}): {1}", ex.Number, ex.Message)
                Catch ex As InvalidOperationException
                    Console.WriteLine("Error: {0}", ex.Message)
                Catch ex As Exception
                    ' You might want to pass these errors
                    ' back out to the caller.
                    Console.WriteLine("Error: {0}", ex.Message)
                End Try
            End Using
        End Sub
        Public Async Function RunNonScalarAsynchronously(ByVal commandText As String, ByVal connectionString As String) As Task(Of Integer)

            Dim nrRighe As Integer
            ' Given command text and connection string, asynchronously execute
            ' the specified command against the connection. For this example,
            ' the code displays an indicator as it is working, verifying the 
            ' asynchronous behavior. 
            Using sqlConn As New SqlConnection(connectionString)
                Try
                    Await sqlConn.OpenAsync()
                    Dim count As Integer = 0
                    Dim command As New SqlCommand(commandText, sqlConn)

                    nrRighe = Convert.ToInt32(Await command.ExecuteScalarAsync())

                    Dim result As IAsyncResult = command.ExecuteScalarAsync()
                    While Not result.IsCompleted
                        Console.WriteLine("Waiting ({0})", count)
                        ' Wait for 1/10 second, so the counter
                        ' does not consume all available resources 
                        ' on the main thread.
                        'Threading.Thread.Sleep(100)
                        count += 1
                    End While
                    Console.WriteLine("Command complete. Affected {0} rows.", nrRighe)
                Catch ex As SqlException
                    Console.WriteLine("Error ({0}): {1}", ex.Number, ex.Message)
                Catch ex As InvalidOperationException
                    Console.WriteLine("Error: {0}", ex.Message)
                Catch ex As Exception
                    ' You might want to pass these errors
                    ' back out to the caller.
                    Console.WriteLine("Error: {0}", ex.Message)
                End Try
            End Using
            Return nrRighe
        End Function
        Public Function RunNonQuery(ByVal commandText As String, ByVal connectionString As String) As Integer
            Dim rowsAffected As Integer
            Using connection As New SqlConnection(connectionString)
                Try
                    Dim command As New SqlCommand(commandText, connection)
                    connection.Open()
                    If connection.State = ConnectionState.Open Then
                        rowsAffected = command.ExecuteNonQuery()
                        Console.WriteLine("Command complete. Affected {0} rows.", rowsAffected)
                    End If
                Catch ex As SqlException
                    Console.WriteLine("Error ({0}): {1}", ex.Number, ex.Message)
                Catch ex As InvalidOperationException
                    Console.WriteLine("Error: {0}", ex.Message)
                Catch ex As Exception
                    ' You might want to pass these errors
                    ' back out to the caller.
                    Console.WriteLine("Error: {0}", ex.Message)
                End Try
            End Using
            Application.DoEvents()
            Return rowsAffected
        End Function
    End Module
End Namespace

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
                    cmd.Parameters.AddWithValue("@DBname", databaseName)
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
        Public Sub CopiaDatabase(ByVal db1 As String, db2 As String)
            FLogin.Cursor = Cursors.WaitCursor
            FLogin.PanelUser.Enabled = False
            FLogin.lstStatoConnessione.Items.Add("Copia Database " & db1 & " su " & db2)
            FLogin.lstStatoConnessione.Refresh()

            Try
                Dim connectionString As String = "Data Source=" & My.Settings.mSQLSERVER & "; Database=msdb;User Id=" & My.Settings.mID & ";Password=" & My.Settings.mPSW & ";"
                Dim dbName As String = db1      ' My.Settings.mDATABASE
                Dim dbTestName As String = db2  ' My.Settings.mDBTEMPUNO

                'Dim backupFileName As String = "Backup_" & databaseName & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".bak"
                Dim backupFileName As String = dbName & ".bak"
                Dim backupFilePath As String
                Dim sqry As String = "SELECT database_name AS DBName, physical_device_name AS BackupLocation, CASE WHEN [TYPE]='D' THEN 'FULL' WHEN [TYPE]='I' THEN 'DIFFERENTIAL' WHEN [TYPE]='L' THEN 'LOG' WHEN [TYPE]='F' THEN 'FILE / FILEGROUP' WHEN [TYPE]='G'  THEN 'DIFFERENTIAL FILE' WHEN [TYPE]='P' THEN 'PARTIAL' WHEN [TYPE]='Q' THEN 'DIFFERENTIAL PARTIAL' END AS BackupType ,backup_finish_date AS BackupFinishDate FROM backupset JOIN backupmediafamily ON(backupset.media_set_id=backupmediafamily.media_set_id) Where database_name = @DBname ORDER BY backup_finish_date DESC"
                FLogin.lstStatoConnessione.Items.Add("BACKUP DATABASE: " & dbName)
                FLogin.lstStatoConnessione.Refresh()

                Using conn = New SqlConnection(connectionString)
                    conn.FireInfoMessageEventOnUserErrors = True
                    Dim cmd As New SqlCommand(sqry, conn)
                    cmd.Parameters.AddWithValue("@DBname", dbName)
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

                        Dim sql = String.Format("BACKUP DATABASE {0} To DISK='{1}' WITH NOFORMAT, INIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10", dbName, backupFilePath)
                        Using cmdB As SqlCommand = conn.CreateCommand()
                            cmdB.CommandTimeout = 0
                            cmdB.CommandText = sql
                            AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
                            cmdB.ExecuteNonQuery()
                            RemoveHandler conn.InfoMessage, AddressOf OnInfoMessage
                        End Using

                        'Restore Database
                        Using cmdRes As SqlCommand = conn.CreateCommand()
                            'Setto in single User
                            Dim sqlres = String.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", dbTestName)
                            cmdRes.CommandTimeout = 0
                            cmdRes.CommandText = sqlres
                            AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
                            cmdRes.ExecuteNonQuery()
                            RemoveHandler conn.InfoMessage, AddressOf OnInfoMessage

                            'Recupero informazioni su filename
                            'DATI ORIGINE
                            Dim originFileName As String
                            Dim sqlq = String.Format("SELECT name FROM sys.master_files WHERE database_id = DB_ID ('{0}') AND type_desc='ROWS'", dbName)
                            Using cmdQry As SqlCommand = conn.CreateCommand()
                                cmdQry.CommandType = CommandType.Text
                                cmdQry.CommandTimeout = 0
                                cmdQry.CommandText = sqlq
                                originFileName = cmdQry.ExecuteScalar
                            End Using
                            'LOG ORIGINE
                            Dim logFileName As String
                            sqlq = String.Format("SELECT name FROM sys.master_files WHERE database_id = DB_ID ('{0}') AND type_desc='LOG'", dbName)
                            Using cmdQry As SqlCommand = conn.CreateCommand()
                                cmdQry.CommandType = CommandType.Text
                                cmdQry.CommandTimeout = 0
                                cmdQry.CommandText = sqlq
                                logFileName = cmdQry.ExecuteScalar
                            End Using
                            'DATI DESTINAZIONE
                            Dim destDatiFileName As String
                            sqlq = String.Format("SELECT physical_name FROM sys.master_files WHERE database_id = DB_ID ('{0}') AND type_desc='ROWS'", dbTestName)
                            Using cmdQry As SqlCommand = conn.CreateCommand()
                                cmdQry.CommandType = CommandType.Text
                                cmdQry.CommandTimeout = 0
                                cmdQry.CommandText = sqlq
                                destDatiFileName = cmdQry.ExecuteScalar
                            End Using
                            'LOG DESTINAZIONE
                            Dim destLogFileName As String
                            sqlq = String.Format("SELECT physical_name FROM sys.master_files WHERE database_id = DB_ID ('{0}') AND type_desc='LOG'", dbTestName)
                            Using cmdQry As SqlCommand = conn.CreateCommand()
                                cmdQry.CommandType = CommandType.Text
                                cmdQry.CommandTimeout = 0
                                cmdQry.CommandText = sqlq
                                destLogFileName = cmdQry.ExecuteScalar
                            End Using
                            'Restore Database
                            FLogin.lstStatoConnessione.Items.Add("RESTORE DATABASE su " & dbTestName)
                            FLogin.lstStatoConnessione.Refresh()
                            FLogin.prgCopy.Minimum = 0
                            FLogin.prgCopy.Maximum = 100
                            FLogin.prgCopy.Step = 5
                            sqlres = String.Format("RESTORE DATABASE {0}  FROM  DISK = N'{1}' WITH  FILE = 1,  MOVE N'{2}' TO N'{3}' , MOVE N'{4}' TO N'{5}' ,  NOUNLOAD,  REPLACE,  STATS = 5 ", dbTestName, backupFilePath, originFileName, destDatiFileName, logFileName, destLogFileName)
                            cmdRes.CommandText = sqlres
                            AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
                            cmdRes.ExecuteNonQuery()
                            RemoveHandler conn.InfoMessage, AddressOf OnInfoMessage

                            'Setto  Multiutente
                            sqlres = String.Format("ALTER DATABASE {0} SET MULTI_USER", dbTestName)
                            cmdRes.CommandText = sqlres
                            AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
                            cmdRes.ExecuteNonQuery()
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
            FLogin.lstStatoConnessione.Items.Add("Copia completata.")
            FLogin.prgCopy.Value = 0
            FLogin.Cursor = Cursors.Arrow
        End Sub
        Private Sub OnInfoMessage(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlInfoMessageEventArgs)
            AvanzaBarra()
        End Sub
    End Module
End Namespace
