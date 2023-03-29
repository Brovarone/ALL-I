Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Namespace SqlTools
    Public Class ValidatingDataReader
        Implements IDataReader

        Private reader As IDataReader = Nothing
        Private disposed As Boolean = False
        Private currentRec As Integer = -1
        Private lookup As DataRow() = Nothing
        Private tableName As String = Nothing
        Private databaseName As String = Nothing
        Private serverName As String = Nothing
        Public Delegate Sub ColumnExceptionEventHandler(ByVal args As ColumnExceptionEventArgs)
        Public Event ColumnException As ColumnExceptionEventHandler

        Public Sub New(ByVal reader As IDataReader, ByVal conn As SqlConnection, ByVal bcp As SqlBulkCopy)
            Me.New(reader, conn, bcp, Nothing)
        End Sub

        Public Sub New(ByVal reader As IDataReader, ByVal conn As SqlConnection, ByVal bcp As SqlBulkCopy, ByVal tran As SqlTransaction)
            Me.reader = reader

            If bcp.DestinationTableName Is Nothing Then
                Throw New Exception("SqlBulkCopy.DestinationTableName must be set before validation can be done.")
            End If

            tableName = bcp.DestinationTableName
            databaseName = conn.Database
            serverName = conn.DataSource
            Dim origState As ConnectionState = conn.State

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            For Each mapping As SqlBulkCopyColumnMapping In bcp.ColumnMappings
                Dim sourceColumn As String = mapping.SourceColumn

                If sourceColumn.StartsWith("[") AndAlso sourceColumn.EndsWith("]") Then
                    sourceColumn = sourceColumn.Substring(1, sourceColumn.Length - 2)
                End If

                If sourceColumn <> "" Then

                    If reader.GetOrdinal(sourceColumn) = -1 Then
                        Dim bestFit As String = Nothing

                        For i As Integer = 0 To reader.FieldCount - 1
                            Dim existingColumn As String = reader.GetName(i)

                            If String.Equals(existingColumn, sourceColumn, StringComparison.InvariantCultureIgnoreCase) Then
                                bestFit = existingColumn
                            End If
                        Next

                        If bestFit Is Nothing Then
                            Throw New Exception("Source column " & mapping.SourceColumn & " does not exist in source.")
                        Else
                            Throw New Exception("Source column " & mapping.SourceColumn & " does not exist in source." & " Column name mappings are case specific and best found match is " & bestFit & ".")
                        End If
                    End If
                Else

                    If mapping.SourceOrdinal < 0 OrElse mapping.SourceOrdinal >= reader.FieldCount Then
                        Throw New Exception("No column exists at index " & mapping.SourceOrdinal & " in source.")
                    End If
                End If
            Next

            Dim schemaTable As DataTable = Nothing

            Try

                Using [select] As SqlCommand = New SqlCommand("select top 0 * from " & bcp.DestinationTableName, conn)

                    If tran IsNot Nothing Then
                        [select].Transaction = tran
                    End If

                    Using destReader As SqlDataReader = [select].ExecuteReader()
                        schemaTable = destReader.GetSchemaTable()
                    End Using
                End Using

            Catch e As SqlException

                If e.Message.StartsWith("Invalid object name") Then
                    Throw New Exception("Destination table " & bcp.DestinationTableName & " does not exist in database " & conn.Database & " on server " & conn.DataSource & ".")
                Else
                    Throw
                End If

            Finally

                If origState = ConnectionState.Closed Then
                    conn.Close()
                End If
            End Try

            lookup = New DataRow(reader.FieldCount - 1) {}

            If bcp.ColumnMappings.Count > 0 Then
                Dim columns As DataRow() = New DataRow(schemaTable.Rows.Count - 1) {}
                Dim columnLookup As Hashtable = New Hashtable()

                For Each column As DataRow In schemaTable.Rows
                    columns(CInt(column("ColumnOrdinal"))) = column
                    columnLookup(column("ColumnName")) = column("ColumnOrdinal")
                Next

                For Each mapping As SqlBulkCopyColumnMapping In bcp.ColumnMappings
                    Dim destColumn As String = mapping.DestinationColumn

                    If destColumn.StartsWith("[") AndAlso destColumn.EndsWith("]") Then
                        destColumn = destColumn.Substring(1, destColumn.Length - 2)
                    End If

                    If destColumn <> "" Then

                        If Not columnLookup.ContainsKey(destColumn) Then
                            Dim bestFit As String = Nothing

                            For Each existingColumn As String In columnLookup.Keys

                                If String.Equals(existingColumn, destColumn, StringComparison.InvariantCultureIgnoreCase) Then
                                    bestFit = existingColumn
                                End If
                            Next

                            If bestFit Is Nothing Then
                                Throw New Exception("Destination column " & mapping.DestinationColumn & " does not exist in destination table " & bcp.DestinationTableName & " in database " & conn.Database & " on server " & conn.DataSource & ".")
                            Else
                                Throw New Exception("Destination column " & mapping.DestinationColumn & " does not exist in destination table " & bcp.DestinationTableName & " in database " & conn.Database & " on server " & conn.DataSource & "." & " Column name mappings are case specific and best found match is " & bestFit & ".")
                            End If
                        End If
                    Else

                        If mapping.DestinationOrdinal < 0 OrElse mapping.DestinationOrdinal >= columns.Length Then
                            Throw New Exception("No column exists at index " & mapping.DestinationOrdinal & " in destination table " & bcp.DestinationTableName & " in database " & conn.Database & " on server " & conn.DataSource & ".")
                        End If
                    End If
                Next

                For Each mapping As SqlBulkCopyColumnMapping In bcp.ColumnMappings
                    Dim sourceIndex As Integer = -1
                    Dim sourceColumn As String = mapping.SourceColumn

                    If sourceColumn.StartsWith("[") AndAlso sourceColumn.EndsWith("]") Then
                        sourceColumn = sourceColumn.Substring(1, sourceColumn.Length - 2)
                    End If

                    If sourceColumn <> "" Then
                        sourceIndex = reader.GetOrdinal(sourceColumn)
                    Else
                        sourceIndex = mapping.SourceOrdinal
                    End If

                    Dim destColumnDef As DataRow = Nothing
                    Dim destColumn As String = mapping.DestinationColumn

                    If destColumn.StartsWith("[") AndAlso destColumn.EndsWith("]") Then
                        destColumn = destColumn.Substring(1, destColumn.Length - 2)
                    End If

                    If destColumn <> "" Then

                        For Each column As DataRow In schemaTable.Rows

                            If CStr(column("ColumnName")) = destColumn Then
                                destColumnDef = column
                            End If
                        Next
                    Else

                        For Each column As DataRow In schemaTable.Rows

                            If CInt(column("ColumnOrdinal")) = mapping.DestinationOrdinal Then
                                destColumnDef = column
                            End If
                        Next
                    End If

                    lookup(sourceIndex) = destColumnDef
                Next
            Else

                For Each column As DataRow In schemaTable.Rows
                    Dim destinationColumnOrdinal As Integer = CInt(column("ColumnOrdinal"))

                    If destinationColumnOrdinal < lookup.Length Then
                        lookup(destinationColumnOrdinal) = column
                    End If
                Next
            End If
        End Sub

        Public ReadOnly Property CurrentRecord As Integer
            Get
                Return currentRec
            End Get
        End Property

        Private Sub Dispose()
            If Not disposed Then
                Dispose(True)
                GC.SuppressFinalize(Me)
            End If
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            If Not disposed Then

                If disposing Then
                End If

                TryCast(reader, IDisposable).Dispose()
                reader = Nothing
                disposed = True
            End If
        End Sub

        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub

        Private ReadOnly Property RecordsAffected As Integer
            Get
                Return reader.RecordsAffected
            End Get
        End Property

        Private ReadOnly Property IsClosed As Boolean
            Get
                Return disposed
            End Get
        End Property

        Private Function NextResult() As Boolean
            Return reader.NextResult()
        End Function

        Public Sub Close()
            TryCast(Me, IDisposable).Dispose()
        End Sub

        Private Function Read() As Boolean
            Dim canRead As Boolean = reader.Read()

            If canRead Then
                currentRec += 1
            End If

            Return canRead
        End Function

        Private ReadOnly Property Depth As Integer
            Get
                Return reader.Depth
            End Get
        End Property

        Private Function GetSchemaTable() As DataTable
            Return reader.GetSchemaTable()
        End Function

        Private Function GetInt32(ByVal i As Integer) As Integer
            Return reader.GetInt32(i)
        End Function

        Private ReadOnly Property Item(ByVal name As String) As Object
            Get
                Dim ordinal As Integer = reader.GetOrdinal(name)

                If ordinal > -1 Then
                    Return (TryCast(Me, IDataRecord)).GetValue(ordinal)
                Else
                    Return reader(name)
                End If
            End Get
        End Property

        Private ReadOnly Property Item(ByVal i As Integer) As Object
            Get
                Return (TryCast(Me, IDataRecord)).GetValue(i)
            End Get
        End Property

        Private Function GetValue(ByVal i As Integer) As Object
            Dim columnValue As Object = reader.GetValue(i)
            If i > -1 AndAlso i < lookup.Length Then
                Dim columnDef As DataRow = lookup(i)

                Try
                    If (CStr(columnDef("DataTypeName")) = "varchar" OrElse CStr(columnDef("DataTypeName")) = "nvarchar" OrElse CStr(columnDef("DataTypeName")) = "char" OrElse CStr(columnDef("DataTypeName")) = "nchar") AndAlso (columnValue IsNot Nothing AndAlso columnValue <> DBNull.Value) Then
                        Dim stringValue As String = columnValue.ToString()
                        If stringValue.Length > CInt(columnDef("ColumnSize")) Then
                            Dim message As String = "Column value """ & stringValue.Replace("""", "\""") & """" & " with length " & stringValue.Length.ToString("###,##0") & " from source column " & (TryCast(Me, IDataRecord)).GetName(i) & " in record " & currentRec.ToString("###,##0") & " does not fit in destination column " & columnDef("ColumnName") & " with length " & (CInt(columnDef("ColumnSize"))).ToString("###,##0") & " in table " & tableName & " in database " & databaseName & " on server " & serverName & "."
                        End If
                    End If

                Catch ex As Exception
                    Dim args As ColumnExceptionEventArgs = New ColumnExceptionEventArgs()
                    args.DataTypeName = CStr(columnDef("DataTypeName"))
                    args.DataType = Type.[GetType](CStr(columnDef("DataType")))
                    args.Value = columnValue
                    args.SourceIndex = i
                    args.SourceColumn = reader.GetName(i)
                    args.DestIndex = CInt(columnDef("ColumnOrdinal"))
                    args.DestColumn = CStr(columnDef("ColumnName"))
                    args.ColumnSize = CInt(columnDef("ColumnSize"))
                    args.RecordIndex = currentRec
                    args.TableName = tableName
                    args.DatabaseName = databaseName
                    args.ServerName = serverName
                    args.Message = ex.Message
                    RaiseEvent ColumnException(args)
                    columnValue = args.Value

                End Try
            End If

            Return columnValue
        End Function

        Private Function IsDBNull(ByVal i As Integer) As Boolean
            Return reader.IsDBNull(i)
        End Function

        Private Function GetBytes(ByVal i As Integer, ByVal fieldOffset As Long, ByVal buffer As Byte(), ByVal bufferoffset As Integer, ByVal length As Integer) As Long
            Return reader.GetBytes(i, fieldOffset, buffer, bufferoffset, length)
        End Function

        Private Function GetByte(ByVal i As Integer) As Byte
            Return reader.GetByte(i)
        End Function

        Private Function GetFieldType(ByVal i As Integer) As Type
            Return reader.GetFieldType(i)
        End Function

        Private Function GetDecimal(ByVal i As Integer) As Decimal
            Return reader.GetDecimal(i)
        End Function

        Private Function GetValues(ByVal values As Object()) As Integer
            Return reader.GetValues(values)
        End Function

        Private Function GetName(ByVal i As Integer) As String
            Return reader.GetName(i)
        End Function

        Private ReadOnly Property FieldCount As Integer
            Get
                Return reader.FieldCount
            End Get
        End Property

        Private ReadOnly Property IDataReader_Depth As Integer Implements IDataReader.Depth
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Private ReadOnly Property IDataReader_IsClosed As Boolean Implements IDataReader.IsClosed
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Private ReadOnly Property IDataReader_RecordsAffected As Integer Implements IDataReader.RecordsAffected
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Private ReadOnly Property IDataRecord_FieldCount As Integer Implements IDataRecord.FieldCount
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Private ReadOnly Property IDataRecord_Item(i As Integer) As Object Implements IDataRecord.Item
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Private ReadOnly Property IDataRecord_Item1(name As String) As Object Implements IDataRecord.Item
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Private Function GetInt64(ByVal i As Integer) As Long
            Return reader.GetInt64(i)
        End Function

        Private Function GetDouble(ByVal i As Integer) As Double
            Return reader.GetDouble(i)
        End Function

        Private Function GetBoolean(ByVal i As Integer) As Boolean
            Return reader.GetBoolean(i)
        End Function

        Private Function GetGuid(ByVal i As Integer) As Guid
            Return reader.GetGuid(i)
        End Function

        Private Function GetDateTime(ByVal i As Integer) As DateTime
            Return reader.GetDateTime(i)
        End Function

        Private Function GetOrdinal(ByVal name As String) As Integer
            Return reader.GetOrdinal(name)
        End Function

        Private Function GetDataTypeName(ByVal i As Integer) As String
            Return reader.GetDataTypeName(i)
        End Function

        Private Function GetFloat(ByVal i As Integer) As Single
            Return reader.GetFloat(i)
        End Function

        Private Function GetData(ByVal i As Integer) As IDataReader
            Return reader.GetData(i)
        End Function

        Private Function GetChars(ByVal i As Integer, ByVal fieldoffset As Long, ByVal buffer As Char(), ByVal bufferoffset As Integer, ByVal length As Integer) As Long
            Return reader.GetChars(i, fieldoffset, buffer, bufferoffset, length)
        End Function

        Private Function GetString(ByVal i As Integer) As String
            Return CStr((TryCast(Me, IDataRecord)).GetValue(i))
        End Function

        Private Function GetChar(ByVal i As Integer) As Char
            Return reader.GetChar(i)
        End Function

        Private Function GetInt16(ByVal i As Integer) As Short
            Return reader.GetInt16(i)
        End Function

        Private Sub IDataReader_Close() Implements IDataReader.Close
            Throw New NotImplementedException()
        End Sub

        Private Function IDataReader_GetSchemaTable() As DataTable Implements IDataReader.GetSchemaTable
            Throw New NotImplementedException()
        End Function

        Private Function IDataReader_NextResult() As Boolean Implements IDataReader.NextResult
            Throw New NotImplementedException()
        End Function

        Private Function IDataReader_Read() As Boolean Implements IDataReader.Read
            Throw New NotImplementedException()
        End Function

        Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
            Throw New NotImplementedException()
        End Sub

        Private Function IDataRecord_GetName(i As Integer) As String Implements IDataRecord.GetName
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetDataTypeName(i As Integer) As String Implements IDataRecord.GetDataTypeName
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetFieldType(i As Integer) As Type Implements IDataRecord.GetFieldType
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetValue(i As Integer) As Object Implements IDataRecord.GetValue
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetValues(values() As Object) As Integer Implements IDataRecord.GetValues
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetOrdinal(name As String) As Integer Implements IDataRecord.GetOrdinal
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetBoolean(i As Integer) As Boolean Implements IDataRecord.GetBoolean
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetByte(i As Integer) As Byte Implements IDataRecord.GetByte
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetBytes(i As Integer, fieldOffset As Long, buffer() As Byte, bufferoffset As Integer, length As Integer) As Long Implements IDataRecord.GetBytes
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetChar(i As Integer) As Char Implements IDataRecord.GetChar
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetChars(i As Integer, fieldoffset As Long, buffer() As Char, bufferoffset As Integer, length As Integer) As Long Implements IDataRecord.GetChars
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetGuid(i As Integer) As Guid Implements IDataRecord.GetGuid
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetInt16(i As Integer) As Short Implements IDataRecord.GetInt16
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetInt32(i As Integer) As Integer Implements IDataRecord.GetInt32
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetInt64(i As Integer) As Long Implements IDataRecord.GetInt64
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetFloat(i As Integer) As Single Implements IDataRecord.GetFloat
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetDouble(i As Integer) As Double Implements IDataRecord.GetDouble
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetString(i As Integer) As String Implements IDataRecord.GetString
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetDecimal(i As Integer) As Decimal Implements IDataRecord.GetDecimal
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetDateTime(i As Integer) As Date Implements IDataRecord.GetDateTime
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_GetData(i As Integer) As IDataReader Implements IDataRecord.GetData
            Throw New NotImplementedException()
        End Function

        Private Function IDataRecord_IsDBNull(i As Integer) As Boolean Implements IDataRecord.IsDBNull
            Throw New NotImplementedException()
        End Function

        Public Class ColumnExceptionEventArgs
            Inherits EventArgs

            Public DataTypeName As String = Nothing
            Public DataType As Type = Nothing
            Public Value As Object = Nothing
            Public SourceIndex As Integer = -1
            Public SourceColumn As String = Nothing
            Public DestIndex As Integer = -1
            Public DestColumn As String = Nothing
            Public ColumnSize As Integer = -1
            Public RecordIndex As Integer = -1
            Public TableName As String = Nothing
            Public DatabaseName As String = Nothing
            Public ServerName As String = Nothing
            Public Message As String = Nothing
        End Class
    End Class
End Namespace

