Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
'Lento
Module FusioneWithDataRow
    Private Const pageSize As Integer = 20000
    Private listeIDs As List(Of ListaId)

    Class TabelleDaEstrarreWithDataRow
        Public Property QuerySelect As String
        Public Property WhereClause As String
        Public Property JoinClause As String
        Public Property Nome As String
        Public Property Paging As Boolean
        Public Property Gruppo As MacroGruppo
        Public Property GeneraListaId As Boolean
        Public Property PrimaryKey As String
        Public Sub New()
            QuerySelect = ""
            WhereClause = ""
            JoinClause = ""
            Nome = ""
            Paging = False
            Gruppo = MacroGruppo.Nessuno
            GeneraListaId = False
            PrimaryKey = ""
        End Sub
    End Class
    Private Class ListaId
        Public Property Ids As List(Of Integer)
        Public Property Nome As String
        Public Sub New()
            Ids = New List(Of Integer)
            Nome = ""
        End Sub
    End Class

    Private Function GetSchemaAndPaging(t As TabelleDaEstrarre, Optional pageindex As Integer = 1) As DataTable
        Dim sqlQuery As String
        Dim qryCount As String
        Dim errorLevel As String = ""
        Dim pageTot As Integer
        Dim dtNew As New DataTable(t.Nome)

        sqlQuery = "SELECT TOP (1) * FROM " & t.Nome
        qryCount = "SELECT COUNT(1) FROM " & t.Nome & t.JoinClause & t.WhereClause

        If Connection.State <> ConnectionState.Open Then
            MessageBox.Show("Connessione non aperta.")
            End
        End If

        Using da As New SqlDataAdapter(sqlQuery, Connection)
            da.FillSchema(dtNew, SchemaType.Source)
            Dim msg As String
            If pageindex = 1 Then
                Using cmd As New SqlCommand(qryCount, Connection)
                    cmd.CommandTimeout = 0
                    cmd.CommandType = CommandType.Text
                    Dim rowsCount As Integer = CInt(cmd.ExecuteScalar())
                    If rowsCount > pageSize Then
                        t.Paging = True
                        pageTot = Math.Ceiling(rowsCount / pageSize)
                        msg = "Estrazione schema : " & t.Nome & "(" & rowsCount.ToString & ") Paging (" & pageTot.ToString & ")"
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
                        msg = "Estrazione schema : " & t.Nome & "(" & rowsCount.ToString & ") No Paging"
                    End If
                End Using
                FLogin.lstStatoConnessione.Items.Add(msg)
                My.Application.Log.WriteEntry(msg)
            End If
        End Using

        Return dtNew
    End Function

    Private Function CaricaConDatarow(dt As DataTable, t As TabelleDaEstrarre, ByVal lids As List(Of IDS), Optional pageindex As Integer = 1) As DataTable
        'Dim stopwatch As New Stopwatch
        Dim stopwatch2 As New Stopwatch
        'stopwatch.Start()
        stopwatch2.Start()
        Dim msg As String
        Dim SQLquery As String
        Dim dtNew As New DataTable
        'Creo la struttura
        dtNew = dt.Clone

        SQLquery = "SELECT * FROM " & t.Nome & t.JoinClause & t.WhereClause


        If t.Paging Then
            msg = "--- Page: " & pageindex.ToString
            FLogin.lstStatoConnessione.Items.Add(msg)
            My.Application.Log.WriteEntry(msg)
            SQLquery = "SELECT * FROM " & t.Nome & " ORDER BY " & t.PrimaryKey & " OFFSET (" & (pageindex - 1) * pageSize & ") ROWS FETCH NEXT " & pageSize & " ROWS ONLY"

        Else
            'SQLquery =
        End If
        Using cmd As New SqlCommand(SQLquery, Connection)

            Dim rowsReturned As Integer = 0
            'Se ho estratto tutto posso uscire dal paging
            If rowsReturned <> pageSize Then t.Paging = False
            'Cerco lista di appoggio con nome tabella 
            Dim indexLista As Integer
            If t.GeneraListaId Then
                indexLista = listeIDs.FindIndex(Function(x) x.Nome.Contains(t.Nome))
            End If
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                While dr.Read
                    Dim ColArray As Object() = New Object(dr.FieldCount - 1) {}

                    For i As Integer = 0 To dr.FieldCount - 1
                        If dr(i) IsNot Nothing Then ColArray(i) = dr(i)
                    Next
                    Dim r As DataRow = dtNew.NewRow()
                    r.ItemArray = ColArray
                    'Faccio le mie modifiche
                    Dim nr As DataRow = EditDataRow(r, lids)
                    'Scrivo il nuovo dato su dtNew
                    'dtNew.LoadDataRow(ColArray, True)
                    dtNew.Rows.Add(nr)
                    'Aggiungo gli id
                    If t.GeneraListaId Then listeIDs(indexLista).Ids.Add(dr.Item(t.PrimaryKey))

                End While

                rowsReturned += 1
            End If
            Debug.Print("Riempimento tabella : " & stopwatch2.Elapsed.ToString)
            My.Application.Log.WriteEntry("Riempimento tabella : " & stopwatch2.Elapsed.ToString)

            dr.Close()
        End Using
        Return dtNew
    End Function

    Private Function ModificaDataRow(ByVal g As MacroGruppo, ByVal row As DataRow, ByVal lids As List(Of IDS), ByRef result As Boolean) As DataRow
        Dim ok As Boolean
        Dim newDr As DataRow = row
        Select Case g
            Case MacroGruppo.Vendita
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Vendite: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Acquisto
                'Logica diversa perche' ho un filtro
                Dim withFiltro As Boolean = row.Table.TableName <> "MA_PurchaseDoc"
                Try
                    'Filtro e EditDataRow in un colpo solo
                    'TODO : accantonato
                    'newDr = EditDataRow(If(withFiltro, FilterRows(row, listeIDs.Find(Function(x) x.Nome.Contains("MA_PurchaseDoc")), "PurchaseDocId"), row), lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in EditDataRowAcquisti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Analitica
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati CentriDiCosto: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.OrdiniClienti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati OrdiniClienti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Cespiti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Cespiti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Agenti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Agenti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Clienti
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Clienti: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
            Case MacroGruppo.Articoli
                Try
                    newDr = EditDataRow(row, lids)
                    result = True
                Catch ex As Exception
                    My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in ModificaDati Articoli: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                    result = False
                End Try
        End Select

        If Not ok Then result = True

        Return newDr
    End Function
    Private Function EditDataRow(ByVal r As DataRow, id As List(Of IDS)) As DataRow
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim keyIDS As IDS = id.Find(Function(p) p.Chiave = True)
        Try
            For Each f As IDS In id
                Select Case f.Operatore
                    Case "+"
                        r.Item(f.Nome) = CInt(r.Item(f.Nome)) + f.Id
                    Case ""
                        r.Item(f.Nome) = f.Id
                    Case "ADD", "END"
                        Dim lprefix As Short = f.IdString.Length
                        If r.Item(f.Nome).ToString.Length + lprefix > r.Table.Columns(f.Nome).MaxLength Then
                            Dim msg As String = "Riscontrati errori durante l'EditAddPrefix " & r.Table.TableName
                            FLogin.lstStatoConnessione.Items.Add(msg)
                            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in EditAddPrefix: " & r.Item(r.Table.PrimaryKey.First.ColumnName) & " - " & r.Table.TableName & "." & f.Nome & " - Valore troppo grosso " & r.Item(f.Nome) & f.IdString)
                            If Not IsDebugging Then
                                Dim mb As New MessageBoxWithDetails(msg & "." & f.Nome, GetCurrentMethod.Name, "Valore troppo grosso " & r.Item(f.Nome) & " " & f.IdString)
                                mb.ShowDialog()
                                End
                            End If
                        Else
                            If Not String.IsNullOrWhiteSpace(r.Item(f.Nome).ToString) Then
                                If f.Operatore = "ADD" Then
                                    r.Item(f.Nome) = String.Concat(f.IdString, r.Item(f.Nome))
                                Else
                                    'END" = Suffisso
                                    r.Item(f.Nome) = String.Concat(r.Item(f.Nome), f.IdString)
                                End If
                            End If
                        End If
                    Case "SAVE"
                        If Not String.IsNullOrWhiteSpace(r.Item(f.Nome).ToString) AndAlso r.Item(f.Nome) <> f.IdString Then
                            r.Item(f.Nome) = String.Empty
                        End If
                    Case "="
                        r.Item(f.Nome) = f.Id
                End Select
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("Riscontrata exception durante l'EditId " & r.Table.TableName)
            My.Application.Log.DefaultFileLogWriter.WriteLine("#Errore# in Edit: " & r.Table.TableName & " - " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message & " " & r.Table.TableName, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        Debug.Print("Edit(ok): " & r.Table.TableName & " " & stopwatch.Elapsed.ToString)
        My.Application.Log.DefaultFileLogWriter.WriteLine("Edit(ok): " & r.Table.TableName & " " & stopwatch.Elapsed.ToString)
        Return r
    End Function

End Module
