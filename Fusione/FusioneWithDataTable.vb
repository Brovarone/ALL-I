﻿Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports System.Text
Imports ALLSystemTools.SqlTools
Module FusioneWithDataTable
    'Tabelle database di origine
    Private dtIDS As DataTable
    Private dvIDS As DataView
    'Tabelle database di destinazione
    Private dtNewIds As DataTable
    Private dvNewIds As DataView
    'Contenitori delle tabelle da processare
    Private tabelle As List(Of TabelleDaEstrarre)
    Private tabelleNoEdit As List(Of TabelleDaEstrarre)
    'todo Prov a mettere 100k , lento, abbassare a 20k
    Private Const pageSize As Integer = 20000
    Private listeIDs As List(Of ListaId)

    ''' <summary>
    ''' Deprecata. Lenta. Usare EseguiFusioneSql
    ''' </summary>
    ''' <param name="dts"></param>
    ''' <returns></returns>
    Public Function EseguiFusione(dts As DataSet) As Boolean
        Dim ok As Boolean
        Dim someTrouble As Boolean

        'Popolo lista con le tabelle e cosa fare
        ok = EstraiTabelle()
        If Not ok Then someTrouble = True

        'Carico IDs da file xls partenza
        dtIDS = dts.Tables("IDS")
        dvIDS = New DataView(dtIDS, "", "Key", DataViewRowState.CurrentRows)
        'Carico IDS da database di destinazione
        Using adpIDS As New SqlDataAdapter("Select * FROM MA_IDNumbers", ConnDestination)
            dtNewIds = New DataTable
            adpIDS.FillSchema(dtNewIds, SchemaType.Source)
            adpIDS.Fill(dtNewIds)
            dvNewIds = New DataView(dtNewIds, "", "CodeType", DataViewRowState.CurrentRows)
        End Using

        'Processo una tabella alla volta
        listeIDs = New List(Of ListaId)
        Try
            Dim stopwatch As New System.Diagnostics.Stopwatch
            stopwatch.Start()
            FLogin.lstStatoConnessione.Items.Add("Processo tabelle in corso...")
            FLogin.prgCopy.Value = 0
            FLogin.prgCopy.Step = 1
            FLogin.prgCopy.Maximum = tabelle.Count + tabelleNoEdit.Count

            Dim stopwatch2 As New System.Diagnostics.Stopwatch
            stopwatch2.Start()
            For Each t In tabelle
                'Estraggo la ListaIDS
                Dim lIDS As New List(Of IDS)
                lIDS = EstraiListaIds(t, dvIDS)
                EditTestoBarra("Carico dati: " & t.Nome)
                Dim pageindex As Integer = 1
                Dim dt As New DataTable
                Dim newDt As New DataTable

                'Prova con DataRow ( lenta)
                'Dim dtVuota As New DataTable
                'Dim dtNuova As New DataTable
                'dtVuota = GetSchemaAndPaging(t, 1)
                'dtNuova = CaricaConDatarow(dtVuota, t, lIDS, 1)

                'Metodo Datatable
                'Primo caricamento 
                dt = CaricaDati(t, False, pageindex)
                If t.Paging Then
                    While t.Paging = True
                        newDt = New DataTable
                        newDt = ModificaDati(t.Gruppo, dt, lIDS, ok)
                        If Not ok Then someTrouble = True
                        ok = ScriviDati(newDt, Not IsDebugging)
                        pageindex += 1
                        'Carica nuovi dati
                        dt = New DataTable
                        dt = CaricaDati(t, False, pageindex)
                        FLogin.prgFusion.PerformStep()
                        FLogin.prgFusion.Update()
                        Application.DoEvents()
                    End While
                End If
                'Ultimo ciclo while + Se non ho paging
                newDt = New DataTable
                newDt = ModificaDati(t.Gruppo, dt, lIDS, ok)
                If Not ok Then someTrouble = True
                ok = ScriviDati(newDt, Not IsDebugging)
                FLogin.prgFusion.Visible = False
                AvanzaBarra()
            Next
            My.Application.Log.WriteEntry("Processo tabelle in : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()

            'ciclo le tabelle senza Edit
            For Each t In tabelleNoEdit
                EditTestoBarra("Carico dati: " & t.Nome)
                Dim pageindex As Integer = 1
                Dim dt As New DataTable
                'Primo caricamento
                dt = CaricaDati(t, False, pageindex)
                If t.Paging Then
                    While t.Paging = True
                        ok = ScriviDati(dt, Not IsDebugging)
                        pageindex += 1
                        'Carica nuovi dati
                        dt = New DataTable
                        dt = CaricaDati(t, False, pageindex)
                    End While
                End If
                'Ultimo ciclo while + Se non ho paging
                ok = ScriviDati(dt, Not IsDebugging)
                AvanzaBarra()
            Next
            My.Application.Log.WriteEntry("Processo tabelle No edit in : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()
            'Edit IDS
            If Not IsDebugging Then
                ok = ScriviIds(dvIDS)
                If Not ok Then someTrouble = True
            End If
            stopwatch2.Stop()
            stopwatch.Stop()
            Debug.Print(stopwatch.Elapsed.ToString)
            FLogin.lstStatoConnessione.Items.Add("Processo eseguito in : " & stopwatch.Elapsed.ToString)
            My.Application.Log.WriteEntry("Processo eseguito in : " & stopwatch.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# EseguiFusione " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try
        My.Application.Log.WriteEntry("Fine processo")
        Return someTrouble
    End Function

    Private Function CaricaDati(t As TabelleDaEstrarre, Optional withConstraint As Boolean = True, Optional pageindex As Integer = 1, Optional ByVal withData As Boolean = True) As DataTable
        Dim result As New StringBuilder()
        Dim stopwatch As New Stopwatch
        Dim stopwatch2 As New Stopwatch
        stopwatch.Start()
        stopwatch2.Start()
        Debug.Print("Carico Dati: " & t.Nome)
        Dim dt As New DataTable(t.Nome)
        Dim SQLquery As String
        Dim qryCount As String
        Dim errorLevel As String = ""
        Dim pageTot As Integer

        If withData Then
            SQLquery = "SELECT * FROM " & t.Nome & t.JoinClause & t.WhereClause
            qryCount = "SELECT COUNT(1) FROM " & t.Nome & t.JoinClause & t.WhereClause

        Else
            SQLquery = "SELECT * FROM " & t.Nome & " WHERE 1=2"
            qryCount = "SELECT COUNT(1) FROM " & t.Nome
        End If
        If Connection.State <> ConnectionState.Open Then
            MessageBox.Show("Connessione non aperta.")
            End
        End If
        Using da As New SqlDataAdapter(SQLquery, Connection)
            da.FillSchema(dt, SchemaType.Source)
            'Debug.Print("Creazione fillschema : " & stopwatch2.Elapsed.ToString)
            stopwatch2.Restart()
            Dim msg As String
            If pageindex = 1 Then
                Using cmd As New SqlCommand(qryCount, Connection)
                    cmd.CommandTimeout = 0
                    cmd.CommandType = CommandType.Text
                    Dim rowsCount As Integer = CInt(cmd.ExecuteScalar())
                    If rowsCount > pageSize Then
                        t.Paging = True
                        pageTot = Math.Ceiling(rowsCount / pageSize)
                        msg = "Estrazione dati : " & t.Nome & "(" & rowsCount.ToString & ") Paging (" & pageTot.ToString & ")"
                        'Faccio vedere la nuova barra
                        FLogin.prgFusion.Value = 0
                        FLogin.prgFusion.Step = 1
                        FLogin.prgFusion.Maximum = pageTot
                        FLogin.prgFusion.Text = t.Nome & " - Tot page: " & pageTot.ToString
                        FLogin.prgFusion.Visible = True
                        FLogin.prgFusion.PerformStep()
                        FLogin.prgFusion.Update()
                        Application.DoEvents()
                    Else
                        msg = "Estrazione dati : " & t.Nome & "(" & rowsCount.ToString & ") No Paging"
                    End If
                End Using
                'Aqggiungo la lista ID alla collection
                If t.GeneraListaId Then listeIDs.Add(New ListaId With {.Nome = t.Nome})
                FLogin.lstStatoConnessione.Items.Add(msg)
                My.Application.Log.WriteEntry(msg)
            End If
            If t.Paging Then
                msg = "--- Page: " & pageindex.ToString
                FLogin.lstStatoConnessione.Items.Add(msg)
                My.Application.Log.WriteEntry(msg)
                Dim qry As String = "SELECT * FROM " & t.Nome & " ORDER BY " & dt.PrimaryKey(0).ColumnName.ToString & " OFFSET (" & (pageindex - 1) * pageSize & ") ROWS FETCH NEXT " & pageSize & " ROWS ONLY"
                da.SelectCommand.CommandText = qry
                da.Fill(dt)
                Dim rowsReturned As Integer = dt.Rows.Count
                'Se ho estratto tutto posso uscire dal paging
                If rowsReturned <> pageSize Then t.Paging = False

            Else
                da.Fill(dt)
            End If
            Debug.Print("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
            My.Application.Log.WriteEntry("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
            'Aggiungo gli id
            If t.GeneraListaId Then AggiungiIds(dt, t.Nome, listeIDs, t.PrimaryKey)
            stopwatch2.Restart()
            If withConstraint Then
                Using cmd As New SqlCommand("sys.sp_recompile", Connection)
                    cmd.CommandTimeout = 0
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@objname", SqlDbType.NVarChar, 776)
                    cmd.Parameters(0).Value = t.Nome  '"sp_helpconstraint"
                    cmd.ExecuteNonQuery()
                    'Debug.Print("recompile : " & stopwatch2.Elapsed.ToString)
                    stopwatch2.Restart()

                    cmd.CommandText = "sp_helpconstraint"
                    'cmd.Parameters.Clear()
                    'cmd.Parameters.Add("@objname", SqlDbType.NVarChar, 776)
                    'cmd.Parameters(0).Value = t.Nome
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
                            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in CaricaDati: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                            If Not IsDebugging Then
                                Dim mb As New MessageBoxWithDetails(errorLevel & Environment.NewLine & ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                                mb.ShowDialog()
                            End If
                        End Try
                        Application.DoEvents()
                    End While
                    dr.Close()
                End Using
            End If
        End Using

        'Debug.Print(result.ToString())
        Debug.Print("Carica Dati : " & t.Nome & " " & stopwatch.Elapsed.ToString)
        stopwatch.Stop()
        stopwatch2.Stop()
        Application.DoEvents()
        Return dt
    End Function

    Private Sub AggiungiIds(dt As DataTable, nome As String, listeIDs As List(Of ListaId), primarykey As String)
        Dim l As ListaId = listeIDs.Find(Function(x) x.Nome.Contains(nome))
        For Each dr As DataRow In dt.Rows
            l.Ids.Add(dr.Item(primarykey))
        Next

    End Sub
End Module
