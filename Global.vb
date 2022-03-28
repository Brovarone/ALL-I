Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports ExcelDataReader
Imports CsvHelper
Imports CsvHelper.Configuration
'dipendeza system.valuetuple
Imports FileHelpers
Imports System.Reflection
Imports System.Reflection.MethodBase
'Classe BBALogger
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Threading
Imports System.Text.RegularExpressions

Imports EFMago.Models

' Per file Excel
' https://github.com/ExcelDataReader/ExcelDataReader
' OTTIMO.

' Per file CSV  - CSVHELPER
' Non funziona l'import senza la riga di intestazione
' .HasHeaderRecord = hasHeader non funziona

' Entity Framework Core versione 3.1
' Il contesto EFMago usa come riferimenti 
'.net4.7.2 ! che e' quello che uso 
' e .net standard 2.0

'BULK Insert per Entity Framework
'https://github.com/borisdj/EFCore.BulkExtensions

Module Variabili
    ' Definisco variabili connessione e tabelle
    Public DBInUse As String = ""
    Public DBisTMP As Boolean
    Public Connection As SqlConnection
    Public Trans As SqlTransaction
    Public DataInizio As String
    Public isAdmin As Boolean = False
    'Nuovo tracciato introduce altri campi quindi se reimporto cose vecchie mi si schianta
    Public bOldtrack As Boolean = False
    Public bIsDebugging As Boolean = False
    Public Const IsDeprecated As Boolean = False ' Da utilizzare per funzioni DEPRECATE da All-System
    Public FolderPath As String ' percorso globale

    'Contesto LINQ2EF Core
    'Public InitialMagoContext As MagoContext
    Public OrdContext As OrdiniContext

    'Public ftDC As FattDataContext
    Public Sub EditTestoBarra(ByVal testo As String)
        FLogin.prgCopy.Text = testo
        FLogin.prgCopy.Update()
        Application.DoEvents()
    End Sub
End Module

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
        Dim cfg As New CsvConfiguration(CultureInfo.InvariantCulture) With {
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
                    For id As Integer = 0 To csv.HeaderRecord.Length - 1
                        'id += 1
                        dt.Columns.Add(ColumnIndexToColumnLetter(id + 1))
                    Next

                    For Each c As DataColumn In dt.Columns
                        fRow(c.ColumnName) = csv.HeaderRecord(c.Ordinal)
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
        Dim cfg As New CsvConfiguration(CultureInfo.InvariantCulture) With {
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
            End If
            'la cerco nel dataview e restituisco la contropartita mago
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
    Friend Enum DocumentType As Integer
        'Tipo documento , 52
        Fattura = 3407874
        FatturaAcc = 3407875
        NotaCredito = 3407876
    End Enum
    Friend Enum CrossReference As Integer
        'Riferimenti Incrociati , 413
        Tutti = 27066368  'DEFAULT
        FatturaImmediata = 27066387
        NotaDiCredito = 27066389
        PnotaPuro = 27066418
        PnotaEmesso = 27066419
        MovimentoAnalitico = 27066424
    End Enum
    Friend Enum LineType As Integer
        Nota = 3538944
        Riferimento = 3538945
        Servizio = 3538946
        Merce = 3538947
        Descrittiva = 3538948
    End Enum
    Friend Enum PaymentTerm As Integer
        Contante = 2686976
        RimessaDiretta = 2686977
        Contrassegno = 2686978
        VistaFattura = 2686979
        Cambiale = 2686980
        RicevutaBancaria = 2686981
        Bonifico = 2686982
        AssegnoBancario = 2686983
        AssegnoCircolare = 2686984
        VagliaPostale = 2686985
        VagliaNazionale = 2686986
        VagliaInternazionale = 2686987
        MAV = 2686988
        RID_SEPA_SDD_CORE = 2686989
        AssegnoBancarioEstero = 2686990
        BonificoEstero = 2686991
        CartaDiCredito = 2686992
        BollettinoBancario = 2686993
        BollettinoPostale = 2686994
        LetteraDiCredito = 2686995
        Factoring = 2686996
        RIDVeloce_SEPA_SDD_B2B = 2686997
    End Enum

    Friend Enum IdType As Integer
        'Specie Archivio 58
        PNota = 3801095
        MovAna = 3801102
        DocVend = 3801088
        OrdCli = 3801098
        Partite = 3801094
        DicIntento = 3801122
        MovCespite = 3801097
    End Enum
    Friend Enum CodeType As Integer
        'Tipo Documento non fiscale 57
        PNota = 3735558
        MovAna = 3735561
        MovCes = 3735585 '  Nr. Riferimento Movimenti Cespiti
    End Enum

    Friend Enum DeclType As Integer
        Specifica = 1507328
        FinoA = 1507329
        Periodo = 1507330
    End Enum
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
                    result(2, x) = LeggiDichIntData(result(0, x))
                Next
            End If
        End Using
        Return result
    End Function
    Public Function LeggiDichIntNumber(ByVal Year As Short, Optional ByRef MyReturnString As String = "") As Integer
        Dim id As Integer
        Using cmd = New SqlCommand("SELECT * FROM MA_DeclarationOfIntentNumbers WHERE BalanceYear=@BalanceYear AND Received=1", Connection)
            cmd.Parameters.AddWithValue("@BalanceYear", Year)
            Using reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read()
                    id = reader.Item("LastLogNo")
                End While
                reader.Close()
            End Using
        End Using
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo protocollo Dich. Intento letto: " & id.ToString & " anno: " & Year.ToString)
        Else
            MyReturnString = "Ultimo protocollo Dich. Intento letto: " & id.ToString & " anno: " & Year.ToString
        End If
        Return id
    End Function
    Public Function LeggiDichIntData(ByVal Year As Short, Optional ByRef MyReturnString As String = "") As String
        Dim dt As String = ""
        Using cmd = New SqlCommand("SELECT * FROM MA_DeclarationOfIntentNumbers WHERE BalanceYear=@BalanceYear AND Received=1", Connection)
            cmd.Parameters.AddWithValue("@BalanceYear", Year)
            Using reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read()
                    dt = reader.Item("LastDate")
                    dt = MagoFormatta(dt, GetType(DateTime), True).STRinga
                End While
                reader.Close()
            End Using
        End Using
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo data Dich. Intento letto: " & dt.ToString & " anno: " & Year.ToString)
        Else
            MyReturnString = "Ultimo data Dich. Intento letto: " & dt.ToString & " anno: " & Year.ToString
        End If
        Return dt
    End Function
    Public Sub AggiornaDichIntNumber(ByVal anni As String(,), Optional ByRef MyReturnString As String = "")
        For i As Short = 0 To UBound(anni, 2)
            Dim annualita As Short = anni(0, i)
            Dim value As Integer = anni(1, i)
            Dim lastDate As String = MagoFormatta(anni(2, i), GetType(String)).DataTempo
            If Not String.IsNullOrWhiteSpace(value) AndAlso value > 0 Then
                Using cmd = New SqlCommand("UPDATE MA_DeclarationOfIntentNumbers SET LastLogNo =@Value, LastDate=@LastDate WHERE BalanceYear=@BalanceYear", Connection)
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
        Dim s As New StringBuilder
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
        Dim s As New StringBuilder
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
        Dim ITCult As New CultureInfo("it-IT")

        Try


            Select Case Tipo
                Case GetType(DateTime)
                    'PASSARE SE POSSIBILE LA DATA CON yyyyMMdd
                    'res.DataTempo = DateTime.ParseExact("20111120", "yyyyMMdd", CultureInfo.InvariantCulture)
                    If IsITA_Culture Then
                        'la stringa passata e' scritta come gg/MM/aaaa = 02/05/2021 = 2 maggio
                        res.DataTempo = DateTime.ParseExact(Left(value, 10), "d", ITCult)
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
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
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
            Using bulkCopy As New SqlBulkCopy(Connection, SqlBulkCopyOptions.KeepIdentity, tr)
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
                    'Dim cmd As New SqlCommand("", Connection)
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
                                            defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
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
                                            defaultValue = constraintKeys.Substring(2, constraintKeys.Length - 4)
                                            'Else
                                            'defaultValue = constraintKeys.Substring(1, constraintKeys.Length - 2)
                                            'End If
                                        Case Else
                                            errorLevel = "Case Else " & colName
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
Public Module FiltriAnalitici
    Public Class FiltroAnalitica
        Public Property DataDA As Date
        Public Property DataA As Date
        Public Property GiaRegistrati As Boolean
        Public Property MovInAnalitica As Boolean
        Public Property NumberFirst As String
        Public Property NumberLast As String
        Public Property AllNumbers As Boolean
        Public Property AdeguaCanoniDate As Boolean
        Public Sub New()
            DataA = Today
            DataDA = Today
            GiaRegistrati = False
            MovInAnalitica = False
            NumberFirst = ""
            NumberLast = ""
            AllNumbers = True
            AdeguaCanoniDate = False
        End Sub
    End Class
    Public NotInheritable Class DareAvereIgnora
        'Dare Avere ignora - segno analitica 125
        Public Const Dare As Integer = 8192000
        Public Const Avere As Integer = 8192001
        Public Const Ignora As Integer = 8192002
    End Class
End Module

Public Module Common
    Public Sub LiberaRam()
        GC.Collect()
        GC.WaitForPendingFinalizers()

    End Sub
    Public Sub ScriviLogESposta()
        Dim s As New List(Of String)
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
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
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

    Public Function OnlyDate(ByVal d As Date) As Date
        Dim nd As New Date(d.Year, d.Month, d.Day)
        Return nd
    End Function
End Module
Public Module LogTools

    Public Sub OrdinaLog(log As MyLogs)
        log.Corpo.Sort()

        For Each r As MyLogRegistry In log.Corpo
            If r.Dettagli.Count > 0 AndAlso r.DaOrdinare Then
                r.Dettagli.Sort()
            End If
        Next

    End Sub
    Public Sub ScriviLogToXml(log As MyLogs)
        Dim XmlRoot As New XmlRootAttribute(log.Nome)
        Dim attrs As New XmlAttributes
        XmlRoot.Namespace = "http://brovarone"
        attrs.XmlRoot = XmlRoot
        Dim xOver As New XmlAttributeOverrides
        xOver.Add(GetType(MyLogs), attrs)
        'Escludo il tag
        attrs = New XmlAttributes With {
            .XmlIgnore = True
            }
        xOver.Add(log.GetType, "Versione", attrs)
        xOver.Add(log.Testa.GetType, "Origine", attrs)

        Dim ser As New XmlSerializer(log.[GetType](), xOver)

        Dim LogFileName As String = "AA" & DateTime.Now.ToString("dd-MM-yyyy") & ".xml"
        Dim LogPath As String = "C:\Users\Cristiano\Desktop\MIGRAZIONE ALLSYSTEM\"

        Dim path As String = LogPath & LogFileName
        Dim file As System.IO.FileStream = System.IO.File.Create(path)
        ser.Serialize(New StreamWriter(file, New System.Text.UTF8Encoding()), log)
        file.Close()

        'LINQ
        Dim xdoc = XDocument.Load(path)
        Dim xn As XNamespace = "http://brovarone"

        Dim xCorpo As XElement = xdoc.Root.Descendants(xn + "Corpo").First
        'Dim xMylog As XElement = xCorpo.Descendants("Corpo").First
        Dim xMylogggg As XElement = xdoc.Root.Descendants(xn + "MyLogRegistry").First
        ' FIX    Dim yyy As XElement = xdoc.Elements(xn + "MyLogRegistry").Where(Function(yyy) xdoc.Root.Elements(xn + "Codice")).Any


        'Sposto i codici su di un livello
        Dim doc = New XmlDocument()
        doc.Load(path)
        Dim nsmgr = New XmlNamespaceManager(doc.NameTable)
        nsmgr.AddNamespace("brovarone", "http://")
        Dim ll As XmlNodeList = doc.SelectNodes("//brovarone:MyLogRegistry", nsmgr)
        Dim RegToModify As XmlNode = doc.SelectSingleNode("//brovarone:MyLogRegistry")
        For i As Integer = 1 To 50

            Dim NewNode As XmlNode = doc.CreateElement("NewDett" & i.ToString)
            RegToModify.AppendChild(NewNode)
            For Each node As XmlNode In RegToModify.SelectNodes("Descrizione | Codice")
                node.ParentNode.RemoveChild(node)
                NewNode.AppendChild(node)
            Next
        Next

        LogFileName = "aanew.xml"
        path = LogPath & LogFileName
        doc.Save(path)

        ' ------------------------------------------------------------------------------------------
        ' IMPOSTO A NOTHING TUTTI I VALORI VUOTI "" PER EVITARE FILE LUNGHI CON CAMPI VUOTI CHE POSSONO VENIRE SCARTATI DA SDI
        ' ------------------------------------------------------------------------------------------
        Dim myXML As XElement
        myXML = XElement.Parse(System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8))
        RemoveEmptyNodes2(myXML)
        myXML.Save(path)
    End Sub
    Private Sub SetAsFirstChild(node As XmlNode, Optional parent As XmlNode = Nothing)
        If node Is Nothing Then Exit Sub
        If parent Is Nothing Then parent = node.ParentNode
        If parent Is Nothing Then Exit Sub
        parent.InsertBefore(node, parent.FirstChild)
    End Sub
    Private Sub RemoveEmptyNodes2(ByVal elem As XElement)
        Dim cntElems As Integer = elem.Descendants().Count()
        Dim cntPrev As Integer

        Do
            cntPrev = cntElems
            elem.Descendants().Where(Function(e) String.IsNullOrEmpty(e.Value.Trim()) AndAlso Not e.HasAttributes).Remove()
            cntElems = elem.Descendants().Count()
        Loop While cntPrev <> cntElems
    End Sub
    Public Class BBALogger
        '   BBALogger.Write("pp1", BBALogger.MsgType.Error);
        '   BBALogger.Write("pp2", BBALogger.MsgType.Error);
        '   BBALogger.Write("pp3", BBALogger.MsgType.Info);
        '   MessageBox.Show("done");

        Public Enum MsgType
            [Error]
            Info
        End Enum

        Public Shared ReadOnly Property Instance As BBALogger
            Get

                If _Instance Is Nothing Then

                    SyncLock _SyncRoot
                        If _Instance Is Nothing Then _Instance = New BBALogger()
                    End SyncLock
                End If

                Return _Instance
            End Get
        End Property

        Private Shared _Instance As BBALogger
        Private Shared ReadOnly _SyncRoot As New Object()
        Private Shared ReadOnly _readWriteLock As New ReaderWriterLockSlim()

        Private Sub New()
            LogFileName = DateTime.Now.ToString("dd-MM-yyyy")
            LogFileExtension = ".xml"
            LogPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\Log"
        End Sub

        Public Property Writer As StreamWriter
        Public Property LogPath As String
        Public Property LogFileName As String
        Public Property LogFileExtension As String

        Public ReadOnly Property LogFile As String
            Get
                Return LogFileName & LogFileExtension
            End Get
        End Property

        Public ReadOnly Property LogFullPath As String
            Get
                Return Path.Combine(LogPath, LogFile)
            End Get
        End Property

        Public ReadOnly Property LogExists As Boolean
            Get
                Return File.Exists(LogFullPath)
            End Get
        End Property

        Public Sub WriteToLog(ByVal inLogMessage As String, ByVal msgtype As MsgType)
            _readWriteLock.EnterWriteLock()

            Try
                LogFileName = DateTime.Now.ToString("dd-MM-yyyy")

                If Not Directory.Exists(LogPath) Then
                    Directory.CreateDirectory(LogPath)
                End If

                Dim settings = New System.Xml.XmlWriterSettings With {
                    .OmitXmlDeclaration = True,
                    .Indent = True
                }
                Dim sbuilder As New StringBuilder()

                Using sw As New StringWriter(sbuilder)

                    Using w As XmlWriter = XmlWriter.Create(sw, settings)
                        w.WriteStartElement("LogInfo")
                        w.WriteElementString("Time", DateTime.Now.ToString())

                        If msgtype = MsgType.[Error] Then
                            w.WriteElementString("Error", inLogMessage)
                        ElseIf msgtype = MsgType.Info Then
                            w.WriteElementString("Info", inLogMessage)
                        End If

                        w.WriteEndElement()
                    End Using
                End Using

                Using Writer As New StreamWriter(LogFullPath, True, Encoding.UTF8)
                    Writer.WriteLine(sbuilder.ToString())
                End Using

            Catch ex As Exception
            Finally
                _readWriteLock.ExitWriteLock()
            End Try
        End Sub

        Public Shared Sub Write(ByVal inLogMessage As String, ByVal msgtype As MsgType)
            Instance.WriteToLog(inLogMessage, msgtype)
        End Sub
    End Class


End Module
Module KeyValidation
    Public Enum ValidationType
        Only_Numbers = 1
        Only_Characters = 2
        Not_Null = 3
        Only_Email = 4
        Phone_Number = 5
    End Enum
    Public Sub AssignValidation(ByRef CTRL As Windows.Forms.TextBox, ByVal Validation_Type As ValidationType)
        Dim txt As Windows.Forms.TextBox = CTRL
        Select Case Validation_Type
            Case ValidationType.Only_Numbers
                AddHandler txt.KeyPress, AddressOf number_Leave
            Case ValidationType.Only_Characters
                AddHandler txt.KeyPress, AddressOf OCHAR_Leave
            Case ValidationType.Not_Null
                AddHandler txt.Leave, AddressOf NotNull_Leave
            Case ValidationType.Only_Email
                AddHandler txt.Leave, AddressOf Email_Leave
            Case ValidationType.Phone_Number
                AddHandler txt.KeyPress, AddressOf Phonenumber_Leave
        End Select
    End Sub
    Public Sub Number_Leave(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Valido la virgola e rimpiazzo il punto con virgola
        'chr 8 = Backspace
        Dim numbers As Windows.Forms.TextBox = sender
        If (e.KeyChar = ".") Then e.KeyChar = ","
        If InStr("1234567890,", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Or (e.KeyChar = "," And InStr(numbers.Text, ",") > 0) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If
    End Sub
    Public Sub Phonenumber_Leave(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim numbers As Windows.Forms.TextBox = sender
        If InStr("1234567890.()-+ ", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Or (e.KeyChar = "." And InStr(numbers.Text, ".") > 0) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If
    End Sub
    Public Sub OCHAR_Leave(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr("1234567890!@#$%^&*()_+=-", e.KeyChar) > 0 Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If
    End Sub
    Public Sub NotNull_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim No As Windows.Forms.TextBox = sender
        If No.Text.Trim = "" Then
            MsgBox("This field Must be filled!")
            No.Focus()
        End If
    End Sub
    Public Sub Email_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Email As Windows.Forms.TextBox = sender
        If Email.Text <> "" Then
            Dim rex As Match = Regex.Match(Trim(Email.Text), "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,3})$", RegexOptions.IgnoreCase)
            If rex.Success = False Then
                MessageBox.Show("Please Enter a valid Email Address", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Email.BackColor = Color.Red
                Email.Focus()
                Exit Sub
            Else
                Email.BackColor = Color.White
            End If
        End If
    End Sub
End Module