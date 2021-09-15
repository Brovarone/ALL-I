Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports ExcelDataReader
Imports CsvHelper
Imports CsvHelper.Configuration
Imports FileHelpers
Imports System.Reflection
Imports System.Reflection.MethodBase
Module Variabili
    ' Definisco variabili connessione e tabelle
    Public Connection As SqlConnection
    Public Trans As SqlTransaction
    Public DataInizio As String
    Public isAdmin As Boolean = False
    'Nuovo tracciato introduce altri campi quindi se reimporto cose vecchie mi si schianta
    Public bOldtrack As Boolean = False
    Public bIsDebugging As Boolean = False
    Public Const IsDeprecated As Boolean = False ' Da utilizzare per funzioni DEPRECATE da All-System
    Public FolderPath As String ' percorso globale

    Public Sub EditTestoBarra(ByVal testo As String)
        FLogin.prgCopy.Text = testo
        FLogin.prgCopy.Update()
        Application.DoEvents()
    End Sub
End Module

' Per file Excel
' https://github.com/ExcelDataReader/ExcelDataReader
' OTTIMO.

' Per file CSV  - CSVHELPER
' Non funziona l'import senza la riga di intestazione
' .HasHeaderRecord = hasHeader non funziona

Module CSV
    Public Function LoadCsvDataFH(ByVal refPath As String, Optional hasHeader As Boolean = False, Optional ByVal sheetname As String = "", Optional delimiter As String = ",") As DataTable
        'FileHelpers
        Dim stopwatch As New Stopwatch
        stopwatch.Start()


        Dim dt As DataTable = CsvEngine.CsvToDataTable(refPath, delimiter)
        dt.TableName = If(String.IsNullOrWhiteSpace(sheetname), "Foglio1", sheetname)
        If Not hasHeader Then
            'prime le metto ad un valore che non esiste
            For Each c As DataColumn In dt.Columns
                c.ColumnName = "IMPROBABILE" & (c.Ordinal + 1).ToString
            Next
            'poi assegno nomenclatura Excel
            For Each c As DataColumn In dt.Columns
                c.ColumnName = ColumnIndexToColumnLetter(c.Ordinal + 1)
            Next
        End If

        Application.DoEvents()
        Debug.Print("Estratto file " & System.IO.Path.GetFileName(refPath).ToString & " " & stopwatch.Elapsed.ToString)
        stopwatch.Stop()
        Return dt
    End Function
    ''' <summary>
    ''' Carico dal disco un file CSV con libreria CSVHELPER
    ''' </summary>
    ''' <param name="refPath"></param>
    ''' <param name="hasHeader"></param>
    ''' <param name="sheetname"></param>
    ''' <param name="delimiter"></param>
    ''' <returns></returns>
    Public Function LoadCsvData(ByVal refPath As String, Optional hasHeader As Boolean = False, Optional ByVal sheetname As String = "", Optional delimiter As String = ",") As DataTable
        'CSVHELPER
        ' Non funziona l'import senza la riga di intestazione
        ' .HasHeaderRecord = hasHeader non funziona
        Dim stopwatch As New Stopwatch
        stopwatch.Start()
        Dim cfg As CsvConfiguration = New CsvConfiguration(CultureInfo.InvariantCulture) With {
            .Delimiter = delimiter
        }

        Dim dt = New DataTable()

        Using reader = New StreamReader(refPath, Encoding.UTF8, False, 16384 * 2)
            Using csv = New CsvReader(reader, cfg)
                FLogin.prgCopy.Minimum = 0
                FLogin.prgCopy.Maximum = 100

                If Not hasHeader Then
                    csv.Read()
                    csv.ReadHeader()
                    Dim fRow As DataRow = dt.NewRow
                    'Creo le colonne
                    For id As Integer = 0 To csv.Context.HeaderRecord.Length - 1
                        'id += 1
                        dt.Columns.Add(ColumnIndexToColumnLetter(id + 1))
                    Next

                    For Each c As DataColumn In dt.Columns
                        fRow(c.ColumnName) = csv.Context.HeaderRecord(c.Ordinal)
                    Next
                    dt.Rows.Add(fRow)

                End If
                While csv.Read
                    Dim row As DataRow = dt.NewRow
                    For Each c As DataColumn In dt.Columns
                        row(c.ColumnName) = csv.Item(c.Ordinal)
                    Next
                    dt.Rows.Add(row)
                    FLogin.prgCopy.Value = reader.BaseStream.Position / reader.BaseStream.Length * 100
                    FLogin.prgCopy.Update()
                    Application.DoEvents()
                End While
                dt.TableName = If(String.IsNullOrWhiteSpace(sheetname), "Foglio1", sheetname)

            End Using
        End Using
        Application.DoEvents()
        Debug.Print("Estratto file " & System.IO.Path.GetFileName(refPath).ToString & " " & stopwatch.Elapsed.ToString)
        stopwatch.Stop()
        Return dt
    End Function
    Public Function LoadCsvHelperDataNO(ByVal refPath As String, Optional hasHeader As Boolean = False, Optional ByVal sheetname As String = "", Optional delimiter As String = ",") As DataTable
        'CSVHELPER
        ' Non funziona l'import senza la riga di intestazione
        ' .HasHeaderRecord = hasHeader non funziona
        Dim stopwatch As New Stopwatch
        stopwatch.Start()
        Dim cfg As CsvConfiguration = New CsvConfiguration(CultureInfo.InvariantCulture) With {
            .Delimiter = delimiter,
            .HasHeaderRecord = hasHeader
        }

        Dim dt = New DataTable()

        Using sr = New StreamReader(refPath, Encoding.UTF8, False, 16384 * 2)
            'Using sr = New StreamReader(refPath)
            Using rdr = New CsvReader(sr, cfg)

                Using dataRdr = New CsvDataReader(rdr)
                    dt.Load(dataRdr)
                End Using
                dt.TableName = If(String.IsNullOrWhiteSpace(sheetname), "Foglio1", sheetname)
                If Not hasHeader Then
                    'prime le metto ad un valore che non esiste
                    For Each c As DataColumn In dt.Columns
                        c.ColumnName = "IMPROBABILE" & (c.Ordinal + 1).ToString
                    Next
                    'poi assegno nomenclatura Excel
                    For Each c As DataColumn In dt.Columns
                        c.ColumnName = ColumnIndexToColumnLetter(c.Ordinal + 1)
                    Next
                End If
            End Using
        End Using
        Application.DoEvents()
        Debug.Print("Estratto file " & System.IO.Path.GetFileName(refPath).ToString & " " & stopwatch.Elapsed.ToString)
        stopwatch.Stop()
        Return dt
    End Function
    Private Function ColumnIndexToColumnLetter(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While
        Return columnName
    End Function
    ''' <summary>
    ''' Carico dal disco un file con libreria ExcelDataReader
    ''' </summary>
    ''' <param name="fullPath"></param>
    ''' <param name="conIntestazione"></param>
    ''' <param name="sheetname"></param>
    ''' <param name="saveHeader"></param>
    ''' <returns></returns>
    Public Function ProcessaCSV(ByVal fullPath As String, ByVal conIntestazione As Boolean, Optional ByVal sheetname As String = "", Optional ByVal saveHeader As Boolean = True) As DataTable
        'ExcelDataReader
        Dim stopwatch As New Stopwatch
        stopwatch.Start()
        Dim reader As IExcelDataReader
        Dim ds As DataSet
        Dim dt = New DataTable

        'Load file into a stream
        Using st As FileStream = File.Open(fullPath, FileMode.Open, FileAccess.Read)
            reader = ExcelReaderFactory.CreateCsvReader(st)
            Application.DoEvents()
            Debug.Print("Aperto file " & System.IO.Path.GetFileName(fullPath).ToString & " " & stopwatch.Elapsed.ToString)
            stopwatch.Restart()

            If Not IsNothing(reader) Then
                Dim conf = New ExcelDataSetConfiguration With {
                .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration With {
                .UseHeaderRow = conIntestazione
                }
            }
                'Fill DataSet
                ds = reader.AsDataSet(conf)
                If Not saveHeader Then
                    For Each t As DataTable In ds.Tables
                        For Each c As DataColumn In t.Columns
                            c.ColumnName = ColumnIndexToColumnLetter(c.Ordinal + 1)
                        Next
                    Next
                End If
                'Read....
                'Rinomino e levo dal ds in quanto mi basta un dt
                reader.Close()
                ds.Tables(0).TableName = If(String.IsNullOrWhiteSpace(sheetname), "Foglio1", sheetname)
                dt = ds.Tables(0)
                ds.Tables.RemoveAt(0)
                ds.Dispose()
            End If
        End Using
        Application.DoEvents()
        Debug.Print("Estratto file " & System.IO.Path.GetFileName(fullPath).ToString & " " & stopwatch.Elapsed.ToString)
        stopwatch.Stop()
        Return dt
    End Function

End Module
Module XLS
    Private Function ColumnIndexToColumnLetter(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function
    Public Function LoadXLS(ByVal fullPath As String, ByVal conIntestazione As Boolean, Optional ByVal saveHeader As Boolean = True) As DataSet
        Dim stopwatch As New Stopwatch
        Dim reader As IExcelDataReader = Nothing
        stopwatch.Start()
        Dim ext As String = System.IO.Path.GetExtension(fullPath)
        Dim ds = New DataSet

        'Load file into a stream
        Using st As FileStream = File.Open(fullPath, FileMode.Open, FileAccess.Read)

            'Must check file extension to adjust the reader to the excel file type
            If String.Equals(".xls", ext.ToLower) Then
                reader = ExcelReaderFactory.CreateBinaryReader(st)
            ElseIf String.Equals(".xlsx", ext.ToLower) Then
                reader = ExcelReaderFactory.CreateOpenXmlReader(st)
            End If
            Application.DoEvents()

            Debug.Print("Apro e leggo file " & System.IO.Path.GetFileName(fullPath).ToString & " " & stopwatch.Elapsed.ToString)
            stopwatch.Restart()
            If Not IsNothing(reader) Then
                Dim conf = New ExcelDataSetConfiguration With {
                .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration With {
                .UseHeaderRow = conIntestazione
                   }
                }
                'Fill DataSet
                ds = reader.AsDataSet(conf)

                If Not saveHeader Then
                    For Each t As DataTable In ds.Tables
                        For Each dt As DataColumn In t.Columns
                            dt.ColumnName = ColumnIndexToColumnLetter(dt.Ordinal + 1)
                        Next
                    Next
                End If
                'Read....

            End If
        End Using

        Application.DoEvents()
        Debug.Print("Estratto file " & System.IO.Path.GetFileName(fullPath).ToString & " " & stopwatch.Elapsed.ToString)
        stopwatch.Stop()
        Return ds
    End Function

End Module

Module MagoNet
    Public sOggi As String = DateTime.Today.ToString("yyyy-MM-dd")
    Public sDataNulla As String = New DateTime(1799, 12, 31).ToString
    Public Const ACGIVASplit As String = "32" 'Codice iva che identifica l'iva SPLIT

    Public Function TrovaContropartita(ByVal Descri As String, ByRef dv As DataView) As String
        Dim esito As String = ""
        Dim ACGOffset As String
        If Not String.IsNullOrWhiteSpace(Descri) Then
            If Len(Descri) = 8 Then
                esito = Descri
            Else
                ACGOffset = Left(Right(Descri, 7), 6)
                'ottengo una contropartita lunga 8
                esito = Left(ACGOffset, 2) & "0" & Mid(ACGOffset, 3, 1) & "0" & Right(ACGOffset, 3)
                'la cerco nel dataview e restituisco la contropartita mago
            End If
            Dim iCP As Integer = dv.Find(esito)
            If iCP <> -1 Then esito = dv.Item(iCP).Item("Account").ToString
        End If
        Return esito
    End Function
    Public Function TryTrovaContropartita(ByVal Descri As String, ByRef dv As DataView, ByRef Conto As String) As Boolean
        Dim esito As String = ""
        Dim res As Boolean = False
        Dim ACGOffset As String
        If Not String.IsNullOrWhiteSpace(Descri) Then
            If Len(Descri) = 8 Then
                esito = Descri
            Else
                ACGOffset = Left(Right(Descri, 7), 6)
                'ottengo una contropartita lunga 8
                esito = Left(ACGOffset, 2) & "0" & Mid(ACGOffset, 3, 1) & "0" & Right(ACGOffset, 3)
                'la cerco nel dataview e restituisco la contropartita mago
            End If
            Dim iCP As Integer = dv.Find(esito)
            If iCP <> -1 Then
                esito = dv.Item(iCP).Item("Account").ToString
                res = True
            End If
        End If
        Conto = esito
        Return res
    End Function

    Friend Structure CustSuppType
        Public Shared Cliente As Integer = 3211264
        Public Shared Fornitore As Integer = 3211265
        Public Shared ClienteSTR As String = "Cliente"
        Public Shared FornitoreSTR As String = "Fornitore"
        Public Shared ClienteIgnora As Integer = 6094848
        Public Shared FornitoreIgnora As Integer = 6094849
        Public Shared IgnoraIgnora As Integer = 6094850
    End Structure
    Friend Structure DocumentType
        'Tipo documento , 52
        Public Shared Fattura As Integer = 3407874
        Public Shared FatturaAcc As Integer = 3407875
        Public Shared NotaCredito As Integer = 3407876
    End Structure
    Friend Structure CrossReference
        'Riferimenti Incrociati , 413
        Public Shared Tutti As Integer = 27066368  'DEFAULT
        Public Shared FatturaImmediata As Integer = 27066387
        Public Shared NotaDiCredito As Integer = 27066389
        Public Shared PnotaPuro As Integer = 27066418
        Public Shared PnotaEmesso As Integer = 27066419
        Public Shared MovimentoAnalitico As Integer = 27066424
    End Structure
    Friend Structure LineType
        Public Shared Nota As Integer = 3538944
        Public Shared Riferimento As Integer = 3538945
        Public Shared Servizio As Integer = 3538946
        Public Shared Merce As Integer = 3538947
        Public Shared Descrittiva As Integer = 3538948
    End Structure
    Friend Structure PaymentTerm
        Public Shared Contante As Integer = 2686976
        Public Shared RimessaDiretta As Integer = 2686977
        Public Shared Contrassegno As Integer = 2686978
        Public Shared VistaFattura As Integer = 2686979
        Public Shared Cambiale As Integer = 2686980
        Public Shared RicevutaBancaria As Integer = 2686981
        Public Shared Bonifico As Integer = 2686982
        Public Shared AssegnoBancario As Integer = 2686983
        Public Shared AssegnoCircolare As Integer = 2686984
        Public Shared VagliaPostale As Integer = 2686985
        Public Shared VagliaNazionale As Integer = 2686986
        Public Shared VagliaInternazionale As Integer = 2686987
        Public Shared MAV As Integer = 2686988
        Public Shared RID_SEPA_SDD_CORE As Integer = 2686989
        Public Shared AssegnoBancarioEstero As Integer = 2686990
        Public Shared BonificoEstero As Integer = 2686991
        Public Shared CartaDiCredito As Integer = 2686992
        Public Shared BollettinoBancario As Integer = 2686993
        Public Shared BollettinoPostale As Integer = 2686994
        Public Shared LetteraDiCredito As Integer = 2686995
        Public Shared Factoring As Integer = 2686996
        Public Shared RIDVeloce_SEPA_SDD_B2B As Integer = 2686997
    End Structure

    Friend NotInheritable Class IdType
        'Specie Archivio 58
        Public Shared PNota As Integer = 3801095
        Public Shared MovAna As Integer = 3801102
        Public Const DocVend As Integer = 3801088
        Public Shared OrdCli As Integer = 3801098
        Public Shared Partite As Integer = 3801094
        Public Shared DicIntento As Integer = 3801122
        Public Shared MovCespite As Integer = 3801097
    End Class
    Friend NotInheritable Class CodeType
        'Tipo Documento non fiscale 57
        Public Shared PNota As Integer = 3735558
        Public Shared MovAna As Integer = 3735561
        Public Shared MovCes = 3735585 '  Nr. Riferimento Movimenti Cespiti

    End Class

    Friend NotInheritable Class DeclType
        Public Shared Specifica As Integer = 1507328
        Public Shared FinoA As Integer = 1507329
        Public Shared Periodo As Integer = 1507330
    End Class
    Public Function ReturnVarName(ByVal i As Integer, ByVal t As Type) As String
        Dim result As String = ""
        Dim dict = t.GetFields(BindingFlags.Static Or BindingFlags.Public).ToDictionary(Function(f) f.GetValue(Nothing), Function(f) f.Name)

        If dict.TryGetValue(i, result) Then
            result += " (" & i.ToString & ")"
        Else
            result = ""
        End If
        Return result

    End Function
    Public Function LeggiID(ByVal IdType As Integer, Optional ByRef MyReturnString As String = "") As Integer
        Dim id As Integer

        Using cmd = New SqlCommand("SELECT LastId FROM MA_IDNumbers WHERE CodeType=@CodeType", Connection)
            cmd.Transaction = Trans
            cmd.Parameters.AddWithValue("@CodeType", IdType)
            Using reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read()
                    id = reader.Item(0)
                End While

                reader.Close()
            End Using
        End Using
        Dim r As String = ReturnVarName(IdType, GetType(MagoNet.IdType))

        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo ID letto: " & id.ToString & " su tipo: " & r)
        Else
            MyReturnString = "Ultimo ID letto: " & id.ToString & " su tipo: " & r
        End If
        Return id
    End Function
    Public Sub AggiornaID(ByVal IdType As Integer, ByVal value As Integer, Optional ByRef MyReturnString As String = "")
        Using cmd = New SqlCommand("UPDATE MA_IDNumbers SET LastId =" & value.ToString & " WHERE CodeType=@CodeType",
                                 Connection)
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
    Public Function LeggiDichInt() As String(,)
        Dim result(2, 0) As String
        Using cmd = New SqlCommand("SELECT * FROM MA_DeclarationOfIntentNumbers WHERE Received=1 ORDER BY BalanceYear", Connection)
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader
            Dim i As Short = 0
            'Al primo Ciclo popolo gli anni
            While reader.Read()
                ReDim Preserve result(2, i) ' Anno, ultimo numero, data
                result(0, i) = reader.Item("BalanceYear").ToString
                i += 1
            End While
            reader.Close()
            'Al secondo ciclo ottengo il numero che mi serve
            If result IsNot Nothing Then
                For x As Short = 0 To result.GetUpperBound(1)
                    result(1, x) = LeggiDichIntNumber(result(0, x)).ToString
                Next
            End If
        End Using
        Return result
    End Function
    Public Function LeggiDichIntNumber(ByVal Year As Short, Optional ByRef MyReturnString As String = "") As Integer
        Dim id As Integer
        Using cmd = New SqlCommand("SELECT * FROM MA_DeclarationOfIntentNumbers WHERE BalanceYear=@BalanceYear AND Received=1", Connection)
            cmd.Parameters.AddWithValue("@BalanceYear", Year)
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader
            While reader.Read()
                id = reader.Item("LastLogNo")
            End While
            reader.Close()
        End Using
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo protocollo Dich. Intento letto: " & id.ToString & " anno: " & Year.ToString)
        Else
            MyReturnString = "Ultimo protocollo Dich. Intento letto: " & id.ToString & " anno: " & Year.ToString
        End If
        Return id
    End Function
    Public Sub AggiornaDichIntNumber(ByVal anni As String(,), Optional ByRef MyReturnString As String = "")
        For i As Short = 0 To UBound(anni, 2) - 1
            Dim annualita As Short = anni(0, i)
            Dim lastDate As String = anni(1, i)
            Dim value As Integer = anni(1, i)
            If Not String.IsNullOrWhiteSpace(value) AndAlso value > 0 Then
                Using cmd = New SqlCommand("UPDATE MA_DeclarationOfIntentNumbers SET LastLogNo =@Value, LastDate=@LastdDate WHERE BalanceYear=@BalanceYear", Connection)
                    cmd.Transaction = Trans
                    cmd.Parameters.AddWithValue("@Value", value)
                    cmd.Parameters.AddWithValue("@LastDate", lastDate)
                    cmd.Parameters.AddWithValue("@BalanceYear", annualita)
                    Dim irows As Integer = cmd.ExecuteNonQuery()
                    If irows <= 0 Then
                        cmd.CommandText = "INSERT INTO MA_DeclarationOfIntentNumbers ( LastLogNo, BalanceYear, LastDate, Received, TBCreatedID, TBModifiedID) VALUES ( @Value, @BalanceYear, @LastdDate, @Rec, @TBCreatedID ,@TBModifiedID )"
                        cmd.Parameters.AddWithValue("@Rec", "1")
                        cmd.Parameters.AddWithValue("@TBCreatedID", My.Settings.mLOGINID)
                        cmd.Parameters.AddWithValue("@TBModifiedID", My.Settings.mLOGINID)
                        irows = cmd.ExecuteNonQuery()
                    End If
                End Using
                If String.IsNullOrWhiteSpace(MyReturnString) Then
                    My.Application.Log.WriteEntry("Ultimo protocollo Dich. Intento scritto: " & value.ToString & " anno: " & annualita.ToString)
                Else
                    MyReturnString = "Ultimo protocollo Dich. Intento scritto: " & value.ToString & " anno: " & annualita.ToString
                End If
            End If
        Next
    End Sub

    Public Function LeggiNonFiscalNumber(ByVal IdType As Integer, ByVal Year As Short, Optional ByRef MyReturnString As String = "") As Integer
        'Magari creare classe adHoc
        Dim id As Integer
        Using cmd = New SqlCommand("SELECT * FROM MA_NonFiscalNumbers WHERE CodeType=@CodeType and BalanceYear=@BalanceYear", Connection)
            cmd.Parameters.AddWithValue("@CodeType", IdType)
            cmd.Parameters.AddWithValue("@BalanceYear", Year)
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader
            While reader.Read()
                id = reader.Item("LastDocNo")
            End While
            reader.Close()
        End Using
        Dim r As String = ReturnVarName(IdType, GetType(MagoNet.IdType))
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo Nr non fiscale letto: " & id.ToString & " su tipo: " & r & " anno: " & Year.ToString)
        Else
            MyReturnString = "Ultimo Nr non fiscale letto: " & id.ToString & " su tipo: " & r & " anno: " & Year.ToString
        End If
        Return id
    End Function
    Public Sub AggiornaNonFiscalNumber(ByVal IdType As Integer, ByVal Year As Short, ByVal value As Integer, Optional ByRef MyReturnString As String = "")
        Using cmd = New SqlCommand("UPDATE MA_NonFiscalNumbers SET LastDocNo =" & value.ToString & " WHERE CodeType=@CodeType AND BalanceYear=@BalanceYear", Connection)
            cmd.Transaction = Trans
            cmd.Parameters.AddWithValue("@CodeType", IdType)
            cmd.Parameters.AddWithValue("@BalanceYear", Year)
            Dim irows As Integer = cmd.ExecuteNonQuery()
            If irows <= 0 Then
                cmd.CommandText = "INSERT INTO MA_NonFiscalNumbers (CodeType, LastDocNo, BalanceYear, TBCreatedID, TBModifiedID) VALUES (@CodeType, @Value, @BalanceYear, @TBCreatedID ,@TBModifiedID )"
                cmd.Parameters.AddWithValue("@Value", value)
                cmd.Parameters.AddWithValue("@TBCreatedID", My.Settings.mLOGINID)
                cmd.Parameters.AddWithValue("@TBModifiedID", My.Settings.mLOGINID)
                irows = cmd.ExecuteNonQuery()
            End If
        End Using
        Dim r As String = ReturnVarName(IdType, GetType(MagoNet.IdType))
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo Nr non fiscale scritto: " & value.ToString & " su tipo: " & r & " anno: " & Year.ToString & vbCrLf)
        Else
            MyReturnString = "Ultimo Nr non fiscale scritto: " & value.ToString & " su tipo: " & r & " anno: " & Year.ToString
        End If
    End Sub
    Public Function LeggiRegistriIva(ByVal Year As Short, Optional ByRef MyReturnString As String = "") As String(,)
        Dim result(2, 0) As String
        Dim s As StringBuilder = New StringBuilder
        s.AppendLine("Ultimo Fiscal Number letto")
        Using cmd = New SqlCommand("SELECT TaxJournal FROM MA_TaxJournals WHERE Disabled = 0 AND CodeType=131073", Connection)
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader
            Dim i As Int16 = 0
            While reader.Read()
                ReDim Preserve result(2, i)
                result(0, i) = reader.Item("TaxJournal")
                i += 1
            End While
            reader.Close()
            For x As Int16 = 0 To result.GetUpperBound(1)
                result(1, x) = LeggiFiscalNumber(Year, result(0, x))
                s.AppendLine("Reg: " & result(0, x) & " Nr:" & result(1, x) & " Anno : " & Year.ToString)
            Next
        End Using
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry(s.ToString)
        Else
            MyReturnString = s.ToString
        End If
        Return result
    End Function
    Public Function LeggiFiscalNumber(ByVal Year As Short, ByVal Registro As String) As Integer
        Dim id As Integer
        Using sqcmd = New SqlCommand("SELECT LastDocNo, Suffix, BalanceYear, TaxJournal, LastDocDate FROM MA_TaxJournalNumbers WHERE TaxJournal=@CodeType and BalanceYear=@BalanceYear", Connection)
            sqcmd.Parameters.AddWithValue("@CodeType", Registro)
            sqcmd.Parameters.AddWithValue("@BalanceYear", Year)
            Dim sqReader As SqlDataReader
            sqReader = sqcmd.ExecuteReader
            While sqReader.Read()
                id = sqReader.Item(0)
            End While
            sqReader.Close()
        End Using
        Return id
    End Function
    Public Sub AggiornaFiscalNumber(ByVal year As Short, ByVal registri As String(,), Optional ByRef MyReturnString As String = "")
        Dim s As StringBuilder = New StringBuilder
        s.AppendLine("Ultimo Fiscal Number scritto")
        For i As Short = 0 To UBound(registri, 2)
            Dim taxJournal As String = registri(0, i)
            Dim value As Integer = registri(2, i)
            If Not String.IsNullOrWhiteSpace(value) AndAlso value > 0 Then
                Using cmd = New SqlCommand("UPDATE MA_TaxJournalNumbers SET LastDocNo =@Value WHERE TaxJournal=@CodeType and BalanceYear=@BalanceYear",
                               Connection)
                    cmd.Transaction = Trans
                    cmd.Parameters.AddWithValue("@Value", value.ToString)
                    cmd.Parameters.AddWithValue("@CodeType", taxJournal)
                    cmd.Parameters.AddWithValue("@BalanceYear", year)
                    Dim irows As Integer = cmd.ExecuteNonQuery()
                    If irows <= 0 Then
                        'cmd.CommandText = "INSERT INTO MA_TaxJournalNumbers (TaxJournal, BalanceYear, LastDocNo, TBCreatedID, TBModifiedID) VALUES ('" & taxJournal & "', " & year.ToString & ", " & value.ToString & ", " & My.Settings.mLOGINID & ", " & My.Settings.mLOGINID & ")"
                        cmd.CommandText = "INSERT INTO MA_TaxJournalNumbers (TaxJournal, BalanceYear, LastDocNo, TBCreatedID, TBModifiedID) VALUES (@CodeType, @BalanceYear, @Value, @TBCreatedID ,@TBModifiedID )"
                        cmd.Parameters.AddWithValue("@TBCreatedID", My.Settings.mLOGINID)
                        cmd.Parameters.AddWithValue("@TBModifiedID", My.Settings.mLOGINID)
                        irows = cmd.ExecuteNonQuery()
                    End If
                    s.AppendLine("Reg: " & registri(0, i) & " Nr:" & registri(2, i) & " Anno : " & year.ToString)
                End Using
            End If
        Next
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry(s.ToString)
        Else
            MyReturnString = s.ToString
        End If
    End Sub
    Public Structure MagoType
        Public BOOLeano As Boolean
        Public STRinga As String
        Public sDataSlash As String
        Public DataTempo As DateTime
        Public INTero As Integer
        Public MONey As Double
    End Structure

    ''' <summary>
    ''' Restituisce un valore utilizzabile in mago
    ''' sDataSlash = "dd/MM/yyyy"
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="Tipo"></param>
    ''' <returns></returns>
    Public Function MagoFormatta(ByVal value As String, ByVal Tipo As Type, Optional ByVal IsITA_Culture As Boolean = False) As MagoType
        Dim res As New MagoType With {
        .BOOLeano = True,
        .STRinga = "",
        .sDataSlash = "",
        .DataTempo = Now,''2020-03-25' ( anno-mese-giorno),
        .INTero = 0,
        .MONey = 0
        }
        Dim ITCult As CultureInfo = New CultureInfo("it-IT")

        Try


            Select Case Tipo
                Case GetType(DateTime)
                    'PASSARE SE POSSIBILE LA DATA CON yyyyMMdd
                    'res.DataTempo = DateTime.ParseExact("20111120", "yyyyMMdd", CultureInfo.InvariantCulture)
                    If IsITA_Culture Then
                        'la stringa passata e' scritta come gg/MM/aaaa = 02/05/2021 = 2 maggio
                        res.DataTempo = DateTime.ParseExact(value, "d", ITCult)
                    Else
                        res.DataTempo = DateTime.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture)
                    End If
                    res.STRinga = res.DataTempo.ToString("yyyy-MM-dd")
                    res.sDataSlash = res.DataTempo.ToString("dd/MM/yyyy")

                Case GetType(Double)
                    Dim dbl As Double = Double.Parse(value, New CultureInfo("en-US"))
                    res.STRinga = dbl.ToString("0.00", ITCult)
                    res.MONey = dbl
                'dbl = Double.Parse(res.STRinga,ITCult)
                Case GetType(String)
                    DateTime.TryParse(value, ITCult, DateTimeStyles.AdjustToUniversal, res.DataTempo)
                    res.STRinga = res.DataTempo.ToString("yyyy-MM-dd")
                    res.sDataSlash = res.DataTempo.ToString("dd/MM/yyyy")
            End Select
        Catch ex As Exception
            Dim mb As MessageBoxWithDetails = New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        Return res

    End Function
    Public Sub BulkBar(sender As Object, e As SqlRowsCopiedEventArgs)
        FLogin.prgCopy.Value = e.RowsCopied
        FLogin.prgCopy.Update()
        Application.DoEvents()
    End Sub
    Public Function ScriviBulk(ByVal TableName As String, ByRef dt As DataTable, ByVal tr As SqlTransaction, Optional ByVal rowState As DataRowState = DataRowState.Unchanged, Optional ByRef MyReturnString As String = "") As Boolean
        Dim esito As Boolean
        Dim logTxt As String
        If dt.Rows.Count > 0 Then
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(Connection, SqlBulkCopyOptions.KeepIdentity, tr)
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
                    'Dim cmd As SqlCommand = New SqlCommand("", Connection)
                    'cmd.Transaction = Trans
                    'cmd.CommandText = "ALTER INDEX ALL ON " & TableName & " DISABLE"
                    ' cmd.ExecuteNonQuery()
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
                    Dim mb As MessageBoxWithDetails = New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
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

    Public Function CaricaSchema(TableName As String, Optional withConstraint As Boolean = True, Optional ByVal withData As Boolean = False, Optional query As String = "") As DataTable
        Dim result As StringBuilder = New StringBuilder()
        Dim stopwatch As New Stopwatch
        Dim stopwatch2 As New Stopwatch
        stopwatch.Start()
        stopwatch2.Start()
        Debug.Print("Carico schema: " & TableName)
        Dim dt As DataTable = New DataTable(TableName)
        Dim SQLquery As String
        If withData Then
            SQLquery = If(String.IsNullOrWhiteSpace(query), "SELECT * FROM " & TableName, query)
        Else
            SQLquery = "SELECT * FROM " & TableName & " where 1=2"
        End If
        Using da As SqlDataAdapter = New SqlDataAdapter(SQLquery, Connection)
            da.FillSchema(dt, SchemaType.Source)
            'Debug.Print("Creazione fillschema : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()
            da.Fill(dt)
            Debug.Print("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
            'Debug.Print("Creazione fill : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()
            If withConstraint Then
                Using cmd As SqlCommand = New SqlCommand("sys.sp_recompile", Connection)
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
                                            defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
                                        Case GetType(Date)
                                            defaultValue = constraintKeys.Substring(1, constraintKeys.Length - 2)
                                            Select Case defaultValue
                                                Case "getdate()"
                                                    defaultValue = sOggi
                                                Case Else
                                                    defaultValue = defaultValue.Substring(1, 4) & "-" & defaultValue.Substring(5, 2) & "-" & defaultValue.Substring(7, 2)
                                            End Select
                                        Case GetType(Double)
                                            defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
                                        Case GetType(Guid)
                                            defaultValue = Guid.Empty.ToString
                                        Case GetType(String)
                                            'If dt.Columns(colName).MaxLength = 1 Then
                                            defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
                                            'Else
                                            'defaultValue = constraintKeys.Substring(1, constraintKeys.Length - 2)
                                            'End If
                                        Case Else
                                            defaultValue = constraintKeys.Substring(1, constraintKeys.Length - 2)

                                    End Select

                                    ' Only strips single quotes for numeric default types
                                    ' add necessary handling as required for nonnumeric defaults

                                    dt.Columns(colName).DefaultValue = defaultValue

                                    result.Append("Column: " & colName & " Default: " & defaultValue & Environment.NewLine)
                                End If

                            End If
                        Catch ex As Exception
                            Debug.Print(ex.Message)
                            Dim mb As MessageBoxWithDetails = New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
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
Public Module FiltriAnalitica
    Public Class FiltriAnalitici
        Public Property DataDA As Date
        Public Property DataA As Date
        Public Property GiaRegistrati As Boolean
        Public Property MovInAnalitica As Boolean
        Public Property NumberFirst As String
        Public Property NumberLast As String
        Public Property AllNumbers As Boolean
        Public Sub New()
            DataA = Today
            DataDA = Today
            GiaRegistrati = False
            MovInAnalitica = False
            NumberFirst = ""
            NumberLast = ""
            AllNumbers = True
        End Sub
    End Class
    Public NotInheritable Class DareAvereIgnora
        'Dare Avere ignora - segno analitica 125
        Public Shared Dare As Integer = 8192000
        Public Shared Avere As Integer = 8192001
        Public Shared Ignora As Integer = 8192002
    End Class
End Module

Public Module Common
    Public Sub LiberaRam()
        GC.Collect()
        GC.WaitForPendingFinalizers()

    End Sub
    Public Sub ScriviLogESposta()
        Dim s As List(Of String) = New List(Of String)
        ScriviLogESposta(s)
    End Sub
    Public Sub ScriviLogESposta(lista As List(Of String))
        My.Application.Log.DefaultFileLogWriter.Flush()
        My.Application.Log.DefaultFileLogWriter.Close()

        'Sposto i file e il log
        Dim b As DialogResult = If(isAdmin, MessageBox.Show("Elaborazione terminata" & vbCrLf & "Si vogliono storicizzare i file?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question), DialogResult.Yes)
        If b = DialogResult.Yes Then
            SpostaFile(lista)
        End If
    End Sub

    Private Sub SpostaFile(lista As List(Of String))
        Const sl As String = "\"
        'Dim newFolder As String = FolderPath & "\PROCESSATI\" & DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")
        Dim d As DateTime = DateTime.Now
        Dim periodo As String = d.ToString("yyyy") & sl & d.ToString("MMMM", New Globalization.CultureInfo("it-IT")).ToUpper
        Dim newFolder As String = FolderPath & sl & "PROCESSATI" & sl & periodo & sl & d.ToString("yyyy-MM-dd HH-mm-ss")
        Try
            Directory.CreateDirectory(newFolder)
        Catch ex As Exception
            Dim mb As MessageBoxWithDetails = New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        If lista.Count > 0 Then
            For Each f As String In lista
                Dim newFilename As String = System.IO.Path.GetFileName(f)
                File.Move(f, newFolder & sl & newFilename)
            Next
        End If
        Dim l As String = My.Application.Log.DefaultFileLogWriter.FullLogFileName
        File.Copy(l, newFolder & sl & System.IO.Path.GetFileName(l))
        My.Settings.mLastLogPath = newFolder
        My.Settings.Save()

    End Sub

End Module