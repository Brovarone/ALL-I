Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports System.Text
Imports ALLSystemTools.SqlTools
Module FusioneWithDataTable
    'Tabelle database di origine
    Private dtIDSw As DataTable
    Private dvIDSw As DataView
    'Tabelle database di destinazione
    Private dtNewIdsw As DataTable
    Private dvNewIdsw As DataView
    'Contenitori delle tabelle da processare
    'Prov a mettere 100k , lento, abbassare a 20k
    Private Const pageSize As Integer = 20000
    Private listeIDsw As List(Of ListaId)

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
        dtIDSw = dts.Tables("IDS")
        dvIDSw = New DataView(dtIDSw, "", "Key", DataViewRowState.CurrentRows)
        'Carico IDS da database di destinazione
        Using adpIDS As New SqlDataAdapter("Select * FROM MA_IDNumbers", ConnDestination)
            dtNewIdsw = New DataTable
            adpIDS.FillSchema(dtNewIdsw, SchemaType.Source)
            adpIDS.Fill(dtNewIdsw)
            dvNewIdsw = New DataView(dtNewIdsw, "", "CodeType", DataViewRowState.CurrentRows)
        End Using

        'Processo una tabella alla volta
        listeIDsw = New List(Of ListaId)
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
                lIDS = EstraiListaIds(t, dvIDSw)
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
                ok = ScriviIds(dvIDSw)
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

    ''' <summary>
    ''' Eseguo le modifiche ai dati
    ''' </summary>
    ''' <returns></returns>
    Private Function ModificaDati(ByVal g As MacroGruppo, ByVal dt As DataTable, ByVal lids As List(Of IDS), ByRef result As Boolean) As DataTable
        Dim newDt As New DataTable
        Select Case g
            Case MacroGruppo.Vendita, MacroGruppo.Analitica, MacroGruppo.OrdiniClienti, MacroGruppo.Cespiti, MacroGruppo.Agenti, MacroGruppo.Clienti, MacroGruppo.Articoli
                Try
                    newDt = Edit(dt, lids)
                    result = True
                Catch ex As Exception
                    ScriviLog("#Errore# in ModificaDati " & NomeMacroGruppo(g) & ": " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Acquisto
                'Logica diversa perche' ho un filtro
                Dim withFiltro As Boolean = dt.TableName <> "MA_PurchaseDoc"
                Try
                    'Filtro e edito in un colpo solo
                    newDt = Edit(If(withFiltro, FilterRows(dt, listeIDsw.Find(Function(x) x.Nome.Contains("MA_PurchaseDoc")), "PurchaseDocId"), dt), lids)
                    result = True
                Catch ex As Exception
                    ScriviLog("#Errore# in ModificaDati Acquisti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
        End Select
        Return newDt
    End Function

    Private Function Edit(ByVal dt As DataTable, id As List(Of IDS)) As DataTable
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim dv As DataView = dt.DefaultView
        Dim keyIDS As IDS = id.Find(Function(p) p.Chiave = True)
        If keyIDS IsNot Nothing Then dv.Sort = keyIDS.Nome & " desc"
        Dim iRow As Integer
        Try
            For Each r As DataRowView In dv
                iRow += 1
                For Each f As IDS In id
                    Select Case f.Operatore
                        Case IdsOp.Somma '"+"
                            Dim iAttuale As Integer = CInt(r.Item(f.Nome))
                            If iAttuale > 0 Then r.Item(f.Nome) = iAttuale + f.Id
                        Case IdsOp.SommaCondizionata '"+"
                            Dim iAttuale As Integer = CInt(r.Item(f.Nome))
                            Dim iDaSommare As Integer
                            If iAttuale > 0 Then
                                If f.Clausola_IsString Then
                                    If r.Item(f.Clausola_Nome).ToString.Equals(f.Clausola_ValoreStr) Then
                                        iDaSommare = f.IdSecondario
                                    Else
                                        iDaSommare = f.Id
                                    End If
                                Else
                                    If r.Item(f.Clausola_Nome).Equals(f.Clausola_ValoreInt) Then
                                        iDaSommare = f.IdSecondario
                                    Else
                                        iDaSommare = f.Id
                                    End If
                                End If
                                r.Item(f.Nome) = iAttuale + iDaSommare
                            End If
                        Case IdsOp.Nulla '""
                            r.Item(f.Nome) = f.Id
                        Case IdsOp.Prefisso, IdsOp.Suffisso '"ADD", "END"
                            Dim lprefix As Short = f.IdString.Length
                            If r.Item(f.Nome).ToString.Length + lprefix > r.Row.Table.Columns(f.Nome).MaxLength Then
                                Dim msg As String = "Riscontrati errori durante l'EditAddPrefix " & dt.TableName
                                FLogin.lstStatoConnessione.Items.Add(msg)
                                ScriviLog("#Errore# in EditAddPrefix: " & r.Item(dt.PrimaryKey.First.ColumnName) & " - " & dt.TableName & "." & f.Nome & " - Valore troppo grosso " & r.Item(f.Nome) & f.IdString)
                                If Not IsDebugging Then
                                    Dim mb As New MessageBoxWithDetails(msg & "." & f.Nome, GetCurrentMethod.Name, "Valore troppo grosso " & r.Item(f.Nome) & " " & f.IdString)
                                    mb.ShowDialog()
                                    End
                                End If
                            Else
                                If Not String.IsNullOrWhiteSpace(r.Item(f.Nome).ToString) Then
                                    If f.Operatore = IdsOp.Prefisso Then
                                        r.Item(f.Nome) = String.Concat(f.IdString, r.Item(f.Nome))
                                    Else
                                        'END" = Suffisso
                                        r.Item(f.Nome) = String.Concat(r.Item(f.Nome), f.IdString)
                                    End If
                                End If
                            End If
                        Case IdsOp.Salva ' "SAVE"
                            If Not String.IsNullOrWhiteSpace(r.Item(f.Nome).ToString) AndAlso r.Item(f.Nome) <> f.IdString Then
                                r.Item(f.Nome) = String.Empty
                            End If
                        Case IdsOp.Sovrascrivi '"OVERWRITE"
                            r.Item(f.Nome) = f.Id
                    End Select
                Next
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Riscontrata exception durante l'EditId " & dt.TableName)
            ScriviLog("#Errore# in Edit: " & dt.TableName & " - " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        Debug.Print("Edit(ok): " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        ScriviLog("Edit(ok): " & dt.TableName & " " & stopwatch.Elapsed.ToString)
        Return dv.ToTable
    End Function


    ''' <summary>
    ''' Restituisce una datatable filtrata in base a una datatable filter secondo la primaryKey
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="filter"></param>
    ''' <param name="primaryKey"></param>
    ''' <returns></returns>
    Private Function FilterRows(ByVal dt As DataTable, ByVal filter As ListaId, ByVal primaryKey As String) As DataTable
        Dim newDt As DataTable = dt.Clone
        Try
            For Each r As DataRow In dt.Rows
                If filter.Ids.Contains(r.Item(primaryKey)) Then newDt.ImportRow(r)
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Riscontrati errori durante il FiltroRows " & dt.TableName)
            ScriviLog("#Errore# FiltroRows " & dt.TableName & " " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message & " " & dt.TableName, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        Return newDt
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
                If t.GeneraListaPKIds Then listeIDsw.Add(New ListaId With {.Nome = t.Nome})
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
            If t.GeneraListaPKIds Then AggiungiIds(dt, t.Nome, listeIDsw, t.PrimaryKey)
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

    ''' <summary>
    ''' Eseguo la preparazione alla BULK INSERT dell'intero dataset nel database di destinazione
    ''' </summary>
    ''' <returns></returns>
    Private Function ScriviDati(dt As DataTable, ByVal Commit As Boolean) As Boolean
        'dsDestination 
        'ConnectionSpa

        Dim loggingTxt As String = "Si"
        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()

        'Parametri
        'https://github.com/borisdj/EFCore.BulkExtensions

        Dim iStep As Integer
        Try

            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", ConnDestination)
                cmdqry.ExecuteNonQuery()
                Using bulkTrans = ConnDestination.BeginTransaction
                    okBulk = ScriviBulk(dt.TableName, dt, bulkTrans, ConnDestination, DataRowState.Unchanged, loggingTxt, True)
                    If Not okBulk Then someTrouble = True
                    bulkMessage.AppendLine(loggingTxt)
                    If someTrouble Then
                        FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                        ScriviLog("Riscontrati errori: annullamento operazione...")
                        bulkTrans.Rollback()
                    Else
                        If Commit Then bulkTrans.Commit()
                        Debug.Print("Commit !")
                        'FLogin.lstStatoConnessione.Items.Add("Scrittura")
                        FLogin.lstStatoConnessione.TopIndex = FLogin.lstStatoConnessione.Items.Count - 1
                    End If

                End Using
                cmdqry.CommandText = "DBCC TRACEOFF(610)"
                cmdqry.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            someTrouble = True
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori allo step " & iStep)
            bulkMessage.AppendLine("[Salvataggio] - STEP: " & iStep & " - Sono stati riscontrati degli errori. (Vedere sezione Errori)")
            errori.AppendLine("[Salvataggio] Messaggio:" & ex.Message)
            errori.AppendLine("[Salvataggio] Stack:" & ex.StackTrace)

            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try

        'Scrivo i Log
        If bulkMessage.Length > 0 Then ScriviLog("+ Scrittura: " & bulkMessage.ToString)
        If errori.Length > 0 Then
            ScriviLog(" --- Errori ---" & vbCrLf & errori.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
            Debug.Print(errori.ToString)
        End If

        Return Not someTrouble
    End Function
    Private Sub AggiungiIds(dt As DataTable, nome As String, listeIDs As List(Of ListaId), primarykey As String)
        Dim l As ListaId = listeIDs.Find(Function(x) x.Nome.Contains(nome))
        For Each dr As DataRow In dt.Rows
            l.Ids.Add(dr.Item(primarykey))
        Next

    End Sub
End Module

