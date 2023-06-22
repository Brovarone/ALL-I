Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Reflection.MethodBase
Imports System.Text

Namespace SqlTools
    Module LINQ
        Public Function LINQResultToDataTable(Of T)(ByVal Linqlist As IEnumerable(Of T)) As DataTable
            Dim dt As DataTable = New DataTable()
            Dim columns As PropertyInfo() = Nothing
            If Linqlist Is Nothing Then Return dt

            For Each Record As T In Linqlist

                If columns Is Nothing Then
                    columns = (CType(Record.[GetType](), Type)).GetProperties()

                    For Each GetProperty As PropertyInfo In columns
                        Dim colType As Type = GetProperty.PropertyType

                        If (colType.IsGenericType) AndAlso (colType.GetGenericTypeDefinition() = GetType(Nullable(Of))) Then
                            colType = colType.GetGenericArguments()(0)
                        End If

                        dt.Columns.Add(New DataColumn(GetProperty.Name, colType))
                    Next
                End If

                Dim dr As DataRow = dt.NewRow()

                For Each pinfo As PropertyInfo In columns
                    dr(pinfo.Name) = If(pinfo.GetValue(Record, Nothing) Is Nothing, DBNull.Value, pinfo.GetValue(Record, Nothing))
                Next

                dt.Rows.Add(dr)
            Next

            Return dt
        End Function
        Public Function LINQResultToDataView(Of T)(ByVal Linqlist As IEnumerable(Of T)) As DataView
            Dim dt As DataTable = New DataTable()
            Dim dv As DataView = New DataView()
            Dim columns As PropertyInfo() = Nothing
            If Linqlist Is Nothing Then Return dv

            For Each Record As T In Linqlist

                If columns Is Nothing Then
                    columns = (CType(Record.[GetType](), Type)).GetProperties()

                    For Each GetProperty As PropertyInfo In columns
                        Dim colType As Type = GetProperty.PropertyType

                        If (colType.IsGenericType) AndAlso (colType.GetGenericTypeDefinition() = GetType(Nullable(Of))) Then
                            colType = colType.GetGenericArguments()(0)
                        End If

                        dt.Columns.Add(New DataColumn(GetProperty.Name, colType))
                    Next
                End If

                Dim dr As DataRow = dt.NewRow()

                For Each pinfo As PropertyInfo In columns
                    dr(pinfo.Name) = If(pinfo.GetValue(Record, Nothing) Is Nothing, DBNull.Value, pinfo.GetValue(Record, Nothing))
                Next

                dt.Rows.Add(dr)
            Next

            Return dt.DefaultView
        End Function
    End Module
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
        Public Function GetConnectionStringSPA(Optional trusted As Boolean = False) As String
            Dim DB As String = If(DBisTMP, FLogin.TxtTmpDB_SPA.Text, FLogin.TxtDB_SPA.Text)
            Return "Data Source=" & FLogin.txtSERVER.Text & "; Database=" & DB & ";User Id=" & FLogin.txtID.Text & ";Password=" & FLogin.txtPSW.Text & ";" & " Pooling=True;" & If(trusted = True, ";TrustServerCertificate=True", "")
        End Function
        Public Function GetConnectionStringUNO(Optional trusted As Boolean = False) As String
            Dim DB As String = If(DBisTMP, FLogin.TxtTmpDB_UNO.Text, FLogin.TxtDB_UNO.Text)
            Return "Data Source=" & FLogin.txtSERVER.Text & "; Database=" & DB & ";User Id=" & FLogin.txtID.Text & ";Password=" & FLogin.txtPSW.Text & ";" & " Pooling=True;" & If(trusted = True, ";TrustServerCertificate=True", "")
        End Function
    End Module
    Module RunQuery
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
                    command.CommandTimeout = 0
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
                    ScriviLog("Error: {0}", ex.Message)
                    Console.WriteLine("Error: {0}", ex.Message)
                End Try
            End Using
            Application.DoEvents()
            Return rowsAffected
        End Function
    End Module
    Module Bulk
        Public Function ScriviBulk(ByVal TableName As String, ByRef dt As DataTable, ByVal tr As SqlTransaction, ByVal Conn As SqlConnection, Optional ByVal rowState As DataRowState = DataRowState.Unchanged, Optional ByRef MyReturnString As String = "", Optional ColumnMapping As Boolean = False) As Boolean
            Dim esito As Boolean
            Dim logTxt As String
            If dt.Rows.Count > 0 Then
                Using bulkCopy As New SqlBulkCopy(Conn, SqlBulkCopyOptions.KeepIdentity, tr)
                    bulkCopy.BatchSize = If(dt.Rows.Count < 5000, 0, dt.Rows.Count / 10)
                    bulkCopy.BulkCopyTimeout = 0
                    bulkCopy.NotifyAfter = dt.Rows.Count / 10
                    FLogin.prgCopy.Minimum = 0
                    FLogin.prgCopy.Maximum = dt.Rows.Count
                    Application.DoEvents()
                    'bulkCopy.SqlRowsCopied += Function(sender, EventArgs) Console.WriteLine("Wrote " & eventArgs.RowsCopied & " records.")
                    AddHandler bulkCopy.SqlRowsCopied, AddressOf BulkBar

                    Dim stopwatch As New System.Diagnostics.Stopwatch
                    stopwatch.Start()
                    Debug.Print("Scrivo in Bulk Copy : " & TableName & " , " & dt.Rows.Count.ToString & " record totali.")
                    bulkCopy.DestinationTableName = TableName
                    Try
                        'Dim cmd As New SqlCommand("", Conn)
                        'cmd.Transaction = Trans
                        'cmd.CommandText = "ALTER INDEX ALL ON " & TableName & " DISABLE"
                        ' cmd.ExecuteNonQuery()

                        'Column Mapping
                        If ColumnMapping Then
                            For Each c As DataColumn In dt.Columns
                                bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName)
                            Next
                        End If
                        ' Write unchanged rows from the source to the destination.
                        If rowState = DataRowState.Unchanged Then
                            bulkCopy.WriteToServer(dt)
                        Else
                            bulkCopy.WriteToServer(dt, rowState)
                        End If
                        Debug.Print("OK - " & stopwatch.Elapsed.ToString)
                        logTxt = "OK - INSERIMENTO: " & TableName & " , " & dt.Rows.Count.ToString & " record totali, in: " & stopwatch.Elapsed.ToString
                        'stopwatch.Restart()
                        'cmd.CommandText = "ALTER INDEX ALL ON " & TableName & " REBUILD"
                        'cmd.ExecuteNonQuery()
                        ' Debug.Print("Rebuild index - " & stopwatch.Elapsed.ToString)
                        esito = True
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                        Debug.Print("NON OK la scrittura in Bulk Copy di : " & TableName & " , " & dt.Rows.Count.ToString & " record.")
                        logTxt = "ERRORE SU INSERIMENTO : " & TableName & " , " & dt.Rows.Count.ToString & " record." & vbCrLf & ex.Message.ToString
                        esito = False
                        Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                        mb.ShowDialog()
                    End Try
                    RemoveHandler bulkCopy.SqlRowsCopied, AddressOf BulkBar
                    Application.DoEvents()
                    stopwatch.Stop()
                End Using
            Else
                'MessageBox.Show("Nessuna riga da inserire su:" & TableName)
                logTxt = "Nessuna riga da inserire su: " & TableName
                esito = True
            End If
            If String.IsNullOrWhiteSpace(MyReturnString) Then
                My.Application.Log.WriteEntry(logTxt)
            Else
                MyReturnString = logTxt
            End If
            Return esito
        End Function

        Public Function ScriviBulkSQL(ByVal TableName As String, rowCount As Double, ByVal dr As SqlDataReader, ByVal tr As SqlTransaction, ByVal Conn As SqlConnection, Optional ByRef MyReturnString As String = "", Optional ColumnMapping As Boolean = False) As Boolean
            Dim esito As Boolean
            Dim logTxt As String
            If rowCount > 0 Then
                Using bulkCopy As New SqlBulkCopy(Conn, SqlBulkCopyOptions.KeepIdentity, tr)
                    'bulkCopy.BatchSize = If(rowCount < 5000, 0, rowCount / 10)
                    bulkCopy.BatchSize = If(rowCount < 5000, 0, 5000)
                    'bulkCopy.EnableStreaming = True
                    bulkCopy.BulkCopyTimeout = 0
                    bulkCopy.NotifyAfter = rowCount / 10
                    FLogin.prgCopy.Minimum = 0
                    FLogin.prgCopy.Maximum = rowCount
                    Application.DoEvents()
                    'bulkCopy.SqlRowsCopied += Function(sender, EventArgs) Console.WriteLine("Wrote " & eventArgs.RowsCopied & " records.")
                    AddHandler bulkCopy.SqlRowsCopied, AddressOf BulkBar

                    Dim stopwatch As New System.Diagnostics.Stopwatch
                    stopwatch.Start()
                    Debug.Print("Scrivo in Bulk Copy : " & TableName & " , " & rowCount.ToString & " record totali.")
                    bulkCopy.DestinationTableName = TableName
                    Try
                        'Column Mapping
                        If ColumnMapping Then
                            Dim schema As DataTable = dr.GetSchemaTable()
                            For Each r As DataRow In schema.Rows
                                bulkCopy.ColumnMappings.Add(r.Item("BaseColumnName"), r.Item("BaseColumnName"))
                            Next
                        End If
                        'Scrivo sul database
                        'Using validator As New ValidatingDataReader(dr, Conn, bulkCopy, tr)
                        'bulkCopy.WriteToServer(validator)
                        'End Using
                        bulkCopy.WriteToServer(dr)

                        Debug.Print("OK - " & stopwatch.Elapsed.ToString)
                        logTxt = "OK - INSERIMENTO: " & TableName & " , " & rowCount.ToString & " record totali, in: " & stopwatch.Elapsed.ToString
                        esito = True
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                        Debug.Print("NON OK la scrittura in Bulk Copy di : " & TableName & " , " & rowCount.ToString & " record.")
                        logTxt = "ERRORE SU INSERIMENTO : " & TableName & " , " & rowCount.ToString & " record." & vbCrLf & ex.Message.ToString
                        esito = False
                        If Not IsDebugging Then
                            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                            mb.ShowDialog()
                        End If
                    End Try
                    RemoveHandler bulkCopy.SqlRowsCopied, AddressOf BulkBar
                    Application.DoEvents()
                    stopwatch.Stop()
                End Using
            Else
                'MessageBox.Show("Nessuna riga da inserire su:" & TableName)
                logTxt = "Nessuna riga da inserire su: " & TableName
                esito = True
            End If
            MyReturnString = logTxt
            Return esito
        End Function
        Public Function CaricaSchema(TableName As String, Optional withConstraint As Boolean = True, Optional ByVal withData As Boolean = False, Optional query As String = "") As DataTable
            Dim result As New StringBuilder()
            Dim stopwatch As New Stopwatch
            Dim stopwatch2 As New Stopwatch
            stopwatch.Start()
            stopwatch2.Start()
            Debug.Print("Carico schema: " & TableName)
            Dim dt As New DataTable(TableName)
            Dim SQLquery As String
            Dim errorLevel As String = ""
            If withData Then
                SQLquery = If(String.IsNullOrWhiteSpace(query), "SELECT * FROM " & TableName, query)
            Else
                SQLquery = "SELECT * FROM " & TableName & " where 1=2"
            End If
            If Connection.State <> ConnectionState.Open Then
                MessageBox.Show("Connessione non aperta.")
                End
            End If
            Using da As New SqlDataAdapter(SQLquery, Connection)
                da.FillSchema(dt, SchemaType.Source)
                'Debug.Print("Creazione fillschema : " & stopwatch2.Elapsed.ToString)
                stopwatch2.Restart()
                da.Fill(dt)
                Debug.Print("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
                'Debug.Print("Creazione fill : " & stopwatch2.Elapsed.ToString)
                stopwatch2.Restart()
                If withConstraint Then
                    Using cmd As New SqlCommand("sys.sp_recompile", Connection)
                        cmd.CommandTimeout = 0
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@objname", SqlDbType.NVarChar, 776)
                        cmd.Parameters(0).Value = TableName  '"sp_helpconstraint"
                        cmd.ExecuteNonQuery()
                        'Debug.Print("recompile : " & stopwatch2.Elapsed.ToString)
                        stopwatch2.Restart()

                        cmd.CommandText = "sp_helpconstraint"
                        'cmd.Parameters.Clear()
                        'cmd.Parameters.Add("@objname", SqlDbType.NVarChar, 776)
                        'cmd.Parameters(0).Value = TableName
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
            Debug.Print("Creazione schema : " & TableName & " " & stopwatch.Elapsed.ToString)
            stopwatch.Stop()
            stopwatch2.Stop()
            Application.DoEvents()
            Return dt
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

                            'Lo fa già se li trova corretti su SQL
                            ''Cambio Nome logico Data
                            'sqlres = String.Format("ALTER DATABASE {0} MODIFY FILE (NAME=N'{1}', NEWNAME=N'Allsystem1Test_Data.MDF')", dbTestName, originFileName)
                            'cmdRes.CommandText = sqlres
                            'AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
                            'cmdRes.ExecuteNonQuery()
                            'RemoveHandler conn.InfoMessage, AddressOf OnInfoMessage

                            ''Cambio nome logico Log
                            'sqlres = String.Format("ALTER DATABASE {0} SET MULTI_USER", dbTestName)
                            'cmdRes.CommandText = sqlres
                            'AddHandler conn.InfoMessage, New SqlInfoMessageEventHandler(AddressOf OnInfoMessage)
                            'cmdRes.ExecuteNonQuery()
                            'RemoveHandler conn.InfoMessage, AddressOf OnInfoMessage
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
