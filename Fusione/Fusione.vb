Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports System.Text
Imports ALLSystemTools.SqlTools
Imports Microsoft.Win32

Module Fusione

    'Tabelle database di origine
    Private dtIDS As DataTable
    Private dvIDS As DataView
    'Tabelle database di destinazione
    Private dtNewIds As DataTable
    Private dvNewIds As DataView
    'Contenitori delle tabelle da processare
    Private tabelle As List(Of TabelleDaEstrarre)
    Private tabelleNoEdit As List(Of TabelleDaEstrarre)
    Private listeIDs As List(Of ListaId)

    Class TabelleDaEstrarre
        Public Property ModificaTutti As Boolean
        Public Property WhereClause As String
        Public Property AdditionalWhere As String
        Public Property JoinClause As String
        ''' <summary>
        ''' Nome Tabella
        ''' </summary>
        ''' <returns></returns>
        Public Property Nome As String
        Public Property FriendName As String
        Public Property Paging As Boolean
        Public Property Gruppo As MacroGruppo
        Public Property HaListaPKIds As Boolean
        Public Property GeneraListaPKIds As Boolean
        Public Property ListaPKIds As List(Of Integer)
        Public Property HaListaEsclusi As Boolean
        Public Property ListaEsclusi As List(Of String)
        Public Property NotInPK As String
        Public Property NotInPKClause As String

        ''' <summary>
        ''' Elenco di nomi tabella cui passare la lista ids estratta
        ''' </summary>
        ''' <returns></returns>
        Public Property TabelleDipendenti As List(Of String)
        Public Property PrimaryKey As String
        Public Property Coppia_CR As CR
        Public Sub New()
            ModificaTutti = False
            AdditionalWhere = ""
            WhereClause = ""
            JoinClause = ""
            Nome = ""
            FriendName = ""
            Paging = False
            Gruppo = MacroGruppo.Nessuno
            GeneraListaPKIds = False
            HaListaPKIds = False
            PrimaryKey = ""
        End Sub
        Public Function Ritorna_Clausola_IN() As String
            Dim s As String = " WHERE " & PrimaryKey & " IN ("
            s &= String.Join(",", ListaPKIds.ToArray)
            Return s & ")"
        End Function
        Private Function Crea_Clausola_AndNotIn(key As List(Of String)) As String
            Dim s As String
            If String.IsNullOrWhiteSpace(WhereClause) Then
                s = " WHERE " & NotInPK & " NOT IN ("
            Else
                s = " AND " & NotInPK & " NOT IN ("
            End If
            s &= "'" & String.Join("','", key.ToArray) & "'"
            Return s & ")"
        End Function
        Public Sub EstraiListaEsclusi(dv As DataView)
            Dim result As New List(Of String)
            Try
                Dim f As String = ""
                Select Case Gruppo
                    Case MacroGruppo.Clienti
                        f = "Cliente"
                    Case MacroGruppo.Fornitori
                        f = "Fornitore"
                    Case MacroGruppo.Agenti
                        f = "Agente"
                    Case MacroGruppo.BancheCli
                        f = "BancaCliente"
                End Select
                dv.RowFilter = "Tipo ='" & f & "'"

                For Each drv As DataRowView In dv
                    result.Add(drv("Valore").ToString)
                    Application.DoEvents()
                Next
            Catch ex As Exception
                Debug.Print(ex.Message)
                ScriviLog("#Errore# in EstraiListaEsclusi: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
                If Not IsDebugging Then
                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                End If
            End Try
            dv.Sort = [String].Empty
            dv.RowFilter = [String].Empty
            NotInPKClause = Crea_Clausola_AndNotIn(result)
            ListaEsclusi = result
        End Sub
    End Class
    Friend Class AccoppiamentiCrossReference
        Public Property OrdCli_NdC As New CR With {.Origine = 27066372, .Derivato = 27066389, .id = 1}
        Public Property OrdCli_FatImmm As New CR With {.Origine = 27066372, .Derivato = 27066387, .id = 2}
        Public Property OrdFor_BdC As New CR With {.Origine = 27066374, .Derivato = 27066400, .id = 3}
        '  Public Property OrdFor_FatAcq As New CR With {.Origine = 27066374, .Derivato = 27066402}
        Public Property DDT_FatImm As New CR With {.Origine = 27066383, .Derivato = 27066387, .id = 4}
        Public Property FatImm_ParCli As New CR With {.Origine = 27066387, .Derivato = 27066423, .id = 5}
        Public Property FatImm_NdC As New CR With {.Origine = 27066387, .Derivato = 27066389, .id = 6}
        Public Property FatImm_FatImm As New CR With {.Origine = 27066387, .Derivato = 27066387, .id = 7}
        Public Property NdC_OrdCli As New CR With {.Origine = 27066389, .Derivato = 27066372, .id = 8}
        Public Property BdC_ResFor As New CR With {.Origine = 27066400, .Derivato = 27066381, .id = 9}
        Public Property BdC_FatImm As New CR With {.Origine = 27066400, .Derivato = 27066387, .id = 10}
        Public Property BdC_NdCRic As New CR With {.Origine = 27066400, .Derivato = 27066404, .id = 11}
        Public Property NdCRic_NdCRic As New CR With {.Origine = 27066404, .Derivato = 27066404, .id = 12}
        Public Property ParFor_NdCRic As New CR With {.Origine = 27066422, .Derivato = 27066404, .id = 13}
        Public Property ParCli_NdC As New CR With {.Origine = 27066423, .Derivato = 27066389, .id = 14}
        Public Property Parc_ParFor As New CR With {.Origine = 27066425, .Derivato = 27066422, .id = 15}

    End Class
    Private Class ListaId
        Public Property Ids As List(Of Integer)
        Public Property Nome As String
        Public Sub New()
            Ids = New List(Of Integer)
            Nome = ""
        End Sub
    End Class

    Friend Enum MacroGruppo As Integer
        Nessuno = 0
        Vendita = 1
        Acquisto = 2
        Analitica = 3
        OrdiniClienti = 4
        Cespiti = 5
        Agenti = 6
        Clienti = 7
        Articoli = 8
        Partite = 9
        CrossRef = 10
        Fornitori = 11
        OrdiniFornitori = 12
        Parcelle = 13
        Magazzino = 14
        BancheCli = 15
    End Enum
    ''' <summary>
    ''' Restituisce il nome del MacroGruppo
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Friend Function NomeMacroGruppo(ByVal id As Integer) As String
        Select Case id
            Case 0
                Return "Nessuno"
            Case 1
                Return "Vendita"
            Case 2
                Return "Acquisto"
            Case 3
                Return "Analitica"
            Case 4
                Return "Ordini Clienti"
            Case 5
                Return "Cespiti"
            Case 6
                Return "Agenti"
            Case 7
                Return "Clienti"
            Case 8
                Return "Articoli"
            Case 9
                Return "Partite"
            Case 10
                Return "Cross Reference"
            Case 11
                Return "Fornitori"
            Case 12
                Return "Ordini Fornitori"
            Case 13
                Return "Parcelle"
            Case 14
                Return "Magazzino"
            Case 15
                Return "Banche Clienti"
            Case Else
                Return ""
        End Select
    End Function
    Public Function EseguiFusioneSQL(dts As DataSet) As Boolean
        Dim ok As Boolean
        Dim someTrouble As Boolean

        'Popolo lista con le tabelle e cosa fare
        If FLogin.ChkFusioneFull.Checked Then
            ok = EstraiTabelle()
        End If
        If FLogin.ChkFusioneClifor.Checked Then
            ok = EstraitabelleCliFor()
        End If
        If FLogin.ChkFusioneParcelle.Checked Then
            ok = EstraitabelleParcelle()
        End If
        If FLogin.ChkFusionePartite.Checked Then
            ok = EstraitabellePartite()
        End If
        If Not ok Then someTrouble = True

        'Carico IDs da file xls partenza
        dtIDS = dts.Tables("IDS")
        dvIDS = New DataView(dtIDS, "", "Key", DataViewRowState.CurrentRows)
        'Esclusi
        Dim dtEsclusi As DataTable = dts.Tables("ESCLUSI")
        Dim dvEsclusi As New DataView(dtEsclusi, "", "Tipo", DataViewRowState.CurrentRows)
        'Carico IDS da database di destinazione
        Using destConn As New SqlConnection(GetConnectionStringSPA)
            destConn.Open()
            If destConn.State = ConnectionState.Open Then
                Using adpIDS As New SqlDataAdapter("Select * FROM MA_IDNumbers", destConn)
                    dtNewIds = New DataTable
                    adpIDS.FillSchema(dtNewIds, SchemaType.Source)
                    adpIDS.Fill(dtNewIds)
                    dvNewIds = New DataView(dtNewIds, "", "CodeType", DataViewRowState.CurrentRows)
                End Using
            End If
        End Using

        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        Dim stopwatch2 As New System.Diagnostics.Stopwatch
        stopwatch2.Start()

        Try
            'Disattivo le relazioni
            DisattivaVincolieRelazioni()
            FLogin.lstStatoConnessione.Items.Add("Processo tabelle in corso...")
            FLogin.prgCopy.Value = 0
            FLogin.prgCopy.Step = 1
            FLogin.prgCopy.Maximum = tabelle.Count + tabelleNoEdit.Count
        Catch ex As Exception
            Debug.Print(ex.Message)
            ScriviLog("#Errore# EsguiFusioneSql : DISATTIVO VINCOLI ORIGINE " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try

        'Tabelle con Edit
        Try
            stopwatch2.Restart()
            'Processo una tabella alla volta
            listeIDs = New List(Of ListaId)

            For Each t In tabelle
                Dim n As String = If(String.IsNullOrWhiteSpace(t.FriendName), t.Nome, t.Nome & " - " & t.FriendName)
                FLogin.lstStatoConnessione.Items.Add(n)
                'Estraggo la ListaIDS
                Dim lIDS As New List(Of IDS)
                EditTestoBarra("Estrai IDS: " & n)
                lIDS = EstraiListaIds(t, dvIDS)

                EditTestoBarra("Modifica dati (origine): " & n)
                'Genero lista PK
                If t.GeneraListaPKIds Then
                    Dim PKList As List(Of Integer) = EstraiListaPK(t)
                    For Each table In t.TabelleDipendenti
                        tabelle.Find(Function(x) x.Nome = table).ListaPKIds = PKList
                    Next
                End If
                'Genero lista esclusi
                If t.HaListaEsclusi Then
                    t.EstraiListaEsclusi(dvEsclusi)
                End If
                'Metodo Sql Update
                Dim rows As Integer
                ok = ModificaSqlUpdate(t, lIDS, rows)
                ScriviLog("ModificaSql: " & n & " Esito:" & ok.ToString)
                Application.DoEvents()
                If Not ok Then someTrouble = True
                EditTestoBarra("Scrittura dati (destinazione): " & n)
                ok = ScriviDatiSql(t, Not IsDebugging)
                AvanzaBarra()
            Next
            ScriviLog("Processo tabelle in : " & stopwatch2.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            ScriviLog("#Errore# EseguiFusioneSql : MODIFICO E SCRIVO TABELLE " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try

        'Tabelle Senza Edit
        Try
            stopwatch2.Restart()
            FLogin.lstStatoConnessione.Items.Add("Processo tabelle senza modifiche in corso...")
            For Each t In tabelleNoEdit
                'Genero lista esclusi
                If t.HaListaEsclusi Then
                    t.EstraiListaEsclusi(dvEsclusi)
                End If
                EditTestoBarra("Scrittura dati (destinazione): " & t.Nome)
                ok = ScriviDatiSql(t, Not IsDebugging)
                AvanzaBarra()
            Next
            ScriviLog("Processo tabelle No edit in : " & stopwatch2.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            ScriviLog("#Errore# EseguiFusioneSql : SCRIVO TABELLE NO EDIT " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try

        'Ids
        Try
            stopwatch2.Restart()
            If Not IsDebugging Then
                ok = ScriviIds(dvIDS)
                If Not ok Then someTrouble = True
            End If
            ScriviLog("Scrivo Ids : " & stopwatch2.Elapsed.ToString)
        Catch ex As Exception
            Debug.Print(ex.Message)
            ScriviLog("#Errore# EseguiFusioneSql : SCRIVI IDS " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
            Return False
        End Try

        'Rimetto a posto le relazioni
        AttivaVincolieRelazioni()

        stopwatch2.Stop()
        stopwatch.Stop()
        Debug.Print(stopwatch.Elapsed.ToString)
        FLogin.lstStatoConnessione.Items.Add("Processo eseguito in : " & stopwatch.Elapsed.ToString)
        ScriviLog("Processo eseguito in : " & stopwatch.Elapsed.ToString)

        ScriviLog("Fine processo")
        Return someTrouble
    End Function

    Private Function EstraiListaPK(t As TabelleDaEstrarre) As List(Of Integer)
        Dim qryToExecute As String = "SELECT DISTINCT " & t.PrimaryKey & " FROM " & t.Nome
        Dim result As New List(Of Integer)
        Using origSelConn As New SqlConnection With {.ConnectionString = GetConnectionStringUNO()}
            Try
                origSelConn.Open()
                If origSelConn.State = ConnectionState.Open Then
                    Using cmdqry = New SqlCommand(qryToExecute, origSelConn)
                        cmdqry.CommandTimeout = 0
                        cmdqry.CommandType = CommandType.Text
                        '    cmdqry.ExecuteNonQuery()

                        '    'Solo per SQL 2017 in su
                        '    'cmdqry.CommandText = "DBCC TRACEON(460,1)" ' per cambiare errore ID 8152 with 2628
                        '    'cmdqry.ExecuteNonQuery()

                        '    cmdqry.CommandText = "ALTER TABLE " & t.Nome & " NOCHECK CONSTRAINT ALL"
                        '    cmdqry.ExecuteNonQuery()
                        qryToExecute &= t.JoinClause & t.WhereClause & t.AdditionalWhere
                        cmdqry.CommandText = qryToExecute
                        Debug.Print(qryToExecute)

                        Try
                            Using sdr As SqlDataReader = cmdqry.ExecuteReader()
                                While sdr.Read()
                                    result.Add(sdr.GetInt32(0))
                                End While
                            End Using

                        Catch exSql As SqlException
                            Debug.Print("Errore SQL:" & exSql.Number.ToString)
                            Select Case exSql.Number
                                Case 8152
                                    'Dato troppo lungo
                                    ScriviLog("#Errore# in EstraiListaPK.ExecuteNonQuery (Dato troppo lungo): " & exSql.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & exSql.StackTrace.ToString)
                                Case Else
                                    ScriviLog("#Errore# in EstraiListaPK.ExecuteNonQuery (SqlException): " & exSql.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & exSql.StackTrace.ToString)
                            End Select
                        Catch ex As Exception
                            ScriviLog("#Errore# in EstraiListaPK.ExecuteNonQuery (Exception Generica): " & ex.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & ex.StackTrace.ToString)

                        End Try
                    End Using
                    Application.DoEvents()

                    'cmdqry.CommandText = "ALTER TABLE " & t.Nome & " WITH CHECK CHECK CONSTRAINT ALL"
                    'cmdqry.ExecuteNonQuery()

                    ''cmdqry.CommandText = "DBCC TRACEOFF(460, 1)"
                    ''cmdqry.ExecuteNonQuery()
                    'cmdqry.CommandText = "DBCC TRACEOFF(610)"
                    'cmdqry.ExecuteNonQuery()
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
                ScriviLog("#Errore# in EstraiListaPK: " & ex.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & ex.StackTrace.ToString)
                If Not IsDebugging Then
                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                End If
            End Try
        End Using
        Return result
    End Function

    Private Function ModificaSqlUpdate(t As TabelleDaEstrarre, ByVal lids As List(Of IDS), ByRef rows As Integer) As Boolean
        Dim qryToExecute As String = "UPDATE " & t.Nome & " SET "
        Dim result As Boolean = False
        Using origUpdConn As New SqlConnection With {.ConnectionString = GetConnectionStringUNO()}
            Try
                origUpdConn.Open()
                If origUpdConn.State = ConnectionState.Open Then

                    Using cmdqry = New SqlCommand(qryToExecute, origUpdConn)
                        cmdqry.CommandTimeout = 0
                        '    cmdqry.ExecuteNonQuery()

                        '    'Solo per SQL 2017 in su
                        '    'cmdqry.CommandText = "DBCC TRACEON(460,1)" ' per cambiare errore ID 8152 with 2628
                        '    'cmdqry.ExecuteNonQuery()

                        '    cmdqry.CommandText = "ALTER TABLE " & t.Nome & " NOCHECK CONSTRAINT ALL"
                        '    cmdqry.ExecuteNonQuery()

                        Dim sb As New StringBuilder
                        Dim paramIndex As Integer = 0
                        For Each f As IDS In lids
                            paramIndex += 1
                            Dim field As String = t.Nome & "." & f.Nome
                            Dim parameter As String = "@P" & paramIndex.ToString
                            Dim value As String = ""
                            Select Case f.Operatore.ToUpper
                                Case IdsOp.Somma ' "+"
                                    value = "(CASE WHEN " & field & " = 0 THEN 0 ELSE " & field & " + " & f.Id.ToString & " END)"
                                    cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})
                                Case IdsOp.Nulla ' ""
                                    'value = f.Id.ToString
                                    cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})

                                Case IdsOp.Prefisso, IdsOp.Suffisso '"ADD", "END"
                                    value = "(CASE WHEN " & field & " ='' THEN '' ELSE "
                                    If f.Operatore = IdsOp.Prefisso Then
                                        value = value & "CONCAT('" & f.IdString & "', " & field & ") END)"
                                    Else
                                        'END" = Suffisso
                                        value = value & "CONCAT(" & field & " ,'" & f.IdString & "') END)"
                                    End If
                                Case IdsOp.Salva '"SAVE"
                                    value = "(CASE WHEN " & field & " <>'' AND " & field & " <> '" & f.IdString & "'  THEN '' ELSE " & field & " END)"
                                    cmdqry.Parameters.Add(parameter, SqlDbType.VarChar, f.MaxSize).Value = value
                                Case IdsOp.Sovrascrivi '"OVERWRITE"
                                    ' value = f.Id.ToString
                                    cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})

                            End Select

                            Select Case f.Operatore
                                Case IdsOp.Somma ' "+"
                                    sb.AppendLine(field & " = " & field & " + " & parameter & ", ")
                                Case IdsOp.Prefisso, IdsOp.Suffisso '"ADD", "END"
                                    sb.AppendLine(field & " = " & value & ", ")
                                Case Else
                                    sb.AppendLine(field & " = " & parameter & ", ")
                            End Select

                        Next
                        qryToExecute &= Strings.Left(sb.ToString, sb.Length - 4)

                        'Esclusi - Query NOT IN (xxx)

                        If t.ModificaTutti Then
                            'non ho bisogno di filtri
                        Else
                            qryToExecute &= t.JoinClause & t.WhereClause & t.AdditionalWhere
                        End If


                        cmdqry.CommandText = qryToExecute
                        Debug.Print(qryToExecute)
                        Try
                            rows = cmdqry.ExecuteNonQuery()
                            result = True
                        Catch exSql As SqlException
                            Debug.Print("Errore SQL:" & exSql.Number.ToString)
                            Select Case exSql.Number
                                Case 8152
                                    'Dato troppo lungo
                                    ScriviLog("#Errore# in ModificaSqlUpdate.ExecuteNonQuery (Dato troppo lungo): " & exSql.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & exSql.StackTrace.ToString)
                                Case Else
                                    ScriviLog("#Errore# in ModificaSqlUpdate.ExecuteNonQuery (SqlException): " & exSql.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & exSql.StackTrace.ToString)
                            End Select
                        Catch ex As Exception
                            ScriviLog("#Errore# in ModificaSqlUpdate.ExecuteNonQuery (Exception Generica): " & ex.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & ex.StackTrace.ToString)

                        End Try
                        Application.DoEvents()
                        cmdqry.Parameters.Clear()

                        'cmdqry.CommandText = "ALTER TABLE " & t.Nome & " WITH CHECK CHECK CONSTRAINT ALL"
                        'cmdqry.ExecuteNonQuery()

                        ''cmdqry.CommandText = "DBCC TRACEOFF(460, 1)"
                        ''cmdqry.ExecuteNonQuery()
                        'cmdqry.CommandText = "DBCC TRACEOFF(610)"
                        'cmdqry.ExecuteNonQuery()
                    End Using
                End If

            Catch ex As Exception
                Debug.Print(ex.Message)
                ScriviLog("#Errore# in ModificaSqlUpdate: " & ex.Message.ToString & Environment.NewLine & qryToExecute & Environment.NewLine & ex.StackTrace.ToString)
                If Not IsDebugging Then
                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                End If
            End Try
        End Using
        Return result
    End Function

    Private Sub DisattivaVincolieRelazioni()
        Try
            FLogin.lstStatoConnessione.Items.Add("TRACEON Origine...")
            RunNonQuery("DBCC TRACEON(610)", GetConnectionStringUNO)
            FLogin.lstStatoConnessione.Items.Add("TRACEON Destinazione...")
            RunNonQuery("DBCC TRACEON(610)", GetConnectionStringSPA)
            ' Solo per SQL 2017 in su
            ' RunNonQuery("DBCC TRACEON(460,1)", GetConnectionStringUNO)  ' per cambiare errore ID 8152 with 2628
            FLogin.lstStatoConnessione.Items.Add("Disattivo vincoli per Origine...")
            RunNonQuery("EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'", GetConnectionStringUNO)
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("ERRORE SU 'Disattivo vincoli e Relazioni'")
            ScriviLog("#Errore# DISATTIVO VINCOLI E RELAZIONI " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
        End Try
    End Sub
    Private Sub AttivaVincolieRelazioni()
        Try
            FLogin.lstStatoConnessione.Items.Add("Riattivo vincoli per Origine...")
            'In questo caso le riattiva ma non le controlla
            'RunNonQuery("EXEC sp_msforeachtable 'ALTER TABLE ? WITH NOCHECK CHECK CONSTRAINT ALL'", GetConnectionStringUNO)
            RunNonQuery("EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'", GetConnectionStringUNO)
            'RunNonQuery("DBCC TRACEOFF(460, 1)", GetConnectionStringUNO)
            FLogin.lstStatoConnessione.Items.Add("TRACEOFF Origine...")
            RunNonQuery("DBCC TRACEOFF(610)", GetConnectionStringUNO)
            FLogin.lstStatoConnessione.Items.Add("TRACEOFF Destinazione...")
            RunNonQuery("DBCC TRACEOFF(610)", GetConnectionStringSPA)

        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("ERRORE SU 'Attiva vincoli e Relazioni'")
            ScriviLog("#Errore# ATTIVA VINCOLI E RELAZIONI " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
        End Try
    End Sub
    Private Function EstraitabelleParcelle() As Boolean
        tabelle = New List(Of TabelleDaEstrarre)
        tabelleNoEdit = New List(Of TabelleDaEstrarre)
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Fees", .ModificaTutti = True, .WhereClause = " WHERE ( MA_Fees.PaymentDate = '17991231' Or MA_Fees.PaymentDate >= '20221201') ", .PrimaryKey = "FeeId", .GeneraListaPKIds = True, .TabelleDipendenti = New List(Of String) From {"MA_FeesDetails"}, .Gruppo = MacroGruppo.Parcelle})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FeesDetails", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "FeeId", .Gruppo = MacroGruppo.Parcelle})
        Return True

    End Function
    Private Function EstraitabellePartite() As Boolean
        tabelle = New List(Of TabelleDaEstrarre)
        tabelleNoEdit = New List(Of TabelleDaEstrarre)
        'Considero OpeningDate e Settled ( Aperte)
        Dim wp As String = " WHERE PymtSchedId IN (SELECT DISTINCT t.PymtSchedId FROM MA_PyblsRcvbls t left JOIN MA_PyblsRcvblsDetails d ON t.PymtSchedId = d.PymtSchedId WHERE  t.Settled = '0' OR d.OpeningDate>='20230331' ) "
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvbls", .ModificaTutti = True, .WhereClause = wp, .PrimaryKey = "PymtSchedId", .GeneraListaPKIds = True, .TabelleDipendenti = New List(Of String) From {"MA_PyblsRcvblsDetails"}, .Gruppo = MacroGruppo.Partite})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvblsDetails", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "PymtSchedId", .Gruppo = MacroGruppo.Partite})
        Return True

    End Function
    Private Function EstraitabelleCliFor() As Boolean
        'todo spostare sotto dopo aver provato
        tabelle = New List(Of TabelleDaEstrarre)
        tabelleNoEdit = New List(Of TabelleDaEstrarre)

        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Clienti})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppCustomerOptions", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "Customer", .Gruppo = MacroGruppo.Clienti})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Fornitori})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppSupplierOptions", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "Supplier", .Gruppo = MacroGruppo.Fornitori})

        Return True
    End Function
    ''' <summary>
    ''' Estraggo le tabelle
    ''' </summary>
    ''' <returns></returns>
    Friend Function EstraiTabelle() As Boolean
        EditTestoBarra("Creazione elenco lavori")
        FLogin.lstStatoConnessione.Items.Add("Creazione elenco lavori")
        tabelle = New List(Of TabelleDaEstrarre)
        tabelleNoEdit = New List(Of TabelleDaEstrarre)
        Dim w As String
#Region "Elenco Tabelle con modifiche"
#Region "Fatture"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDoc", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocComponents", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocDetail", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocManufReasons", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocNotes", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocPymtSched", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocReferences", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocShipping", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocSummary", .Gruppo = MacroGruppo.Vendita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocTaxSummary", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EIEventViewer", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITDocAdditionalData", .Gruppo = MacroGruppo.Vendita})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_EI_ITAsyncComm", .Gruppo = MacroGruppo.Vendita})
#End Region
#Region "Acquisti"
        'Adeguo gli ID su tutta la tabella ma mi copio solo il tipo documento desiderato
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDoc", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocDetail", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocNotes", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocPymtSched", .Gruppo = MacroGruppo.Acquisto})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocReferences", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocShipping", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocSummary", .Gruppo = MacroGruppo.Acquisto})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocTaxSummary", .Gruppo = MacroGruppo.Acquisto})
#End Region
#Region "Ordini Clienti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrd", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdComponents", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdDetails", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdNotes", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdPymtSched", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdReferences", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdShipping", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdSummary", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleOrdTaxSummary", .Gruppo = MacroGruppo.OrdiniClienti})
        'Tabelle Personalizzate ALLSYSTEM UNO
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliAcc", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliAttivita", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliContratto", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliDescrizioni", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdCliTipologiaServizi", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdFiglio", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLOrdPadre", .Gruppo = MacroGruppo.OrdiniClienti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "ALLCespiti", .Gruppo = MacroGruppo.OrdiniClienti})

#End Region
#Region "Ordini Fornitori"
        w = " WHERE OrderDate >= '20220101'"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrd", .ModificaTutti = True, .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
        w = " WHERE PurchaseOrdId IN (SELECT DISTINCT PurchaseOrdId
                FROM MA_PurchaseOrd WHERE OrderDate >= '20220101' ) "
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrdDetails", .ModificaTutti = True, .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrdNotes", .ModificaTutti = True, .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrdPymtSched", .ModificaTutti = True, .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrdReferences",.ModificaTutti = True,  .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrdShipping", .ModificaTutti = True, .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrdSummary", .ModificaTutti = True, .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseOrdTaxSummay", .ModificaTutti = True, .WhereClause = w, .Gruppo = MacroGruppo.OrdiniFornitori})
#End Region
#Region "Cespiti"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssets", .ModificaTutti = True, .WhereClause = " WHERE DisposalType <> 7143424", .Gruppo = MacroGruppo.Cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsBalance", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsCoeff", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFinancial", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFiscal", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsPeriod", .Gruppo = MacroGruppo.cespiti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetLocations", .Gruppo = MacroGruppo.Cespiti})
#End Region
#Region "Analitica ( Centri di Costo + Commesse)"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CostCenters", .Gruppo = MacroGruppo.Analitica})

#End Region
#Region "Agenti"
        'Non serve piu' Non viene esso suffisso
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Areas", .Gruppo = MacroGruppo.Agenti})
#End Region
#Region "NON VALIDE -- Clienti : Dichiarazioni di Intento"
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_DeclarationOfIntent", .Gruppo = MacroGruppo.Clienti})
#End Region
#Region "Clienti : Mandati"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SDDMandate", .Gruppo = MacroGruppo.Clienti})
#End Region
#Region "Partite"
        'Considero OpeningDate e Settled ( Aperte)
        Dim wp As String = " WHERE PymtSchedId IN (SELECT DISTINCT t.PymtSchedId FROM MA_PyblsRcvbls t left JOIN MA_PyblsRcvblsDetails d ON t.PymtSchedId = d.PymtSchedId WHERE  t.Settled = '0' OR d.OpeningDate>='20230331' ) "
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvbls", .ModificaTutti = True, .WhereClause = wp, .PrimaryKey = "PymtSchedId", .GeneraListaPKIds = True, .TabelleDipendenti = New List(Of String) From {"MA_PyblsRcvblsDetails"}, .Gruppo = MacroGruppo.Partite})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvblsDetails", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "PymtSchedId", .Gruppo = MacroGruppo.Partite})
#End Region
#Region "Parcelle"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Fees", .ModificaTutti = True, .WhereClause = " WHERE ( MA_Fees.PaymentDate = '17991231' Or MA_Fees.PaymentDate >= '20221201') ", .PrimaryKey = "FeeId", .GeneraListaPKIds = True, .TabelleDipendenti = New List(Of String) From {"MA_FeesDetails"}, .Gruppo = MacroGruppo.Parcelle})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FeesDetails", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "FeeId", .Gruppo = MacroGruppo.Parcelle})
#End Region
#Region "NON SI PUO' -- Movimenti di Magazzino"
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_InventoryEntries", .Gruppo = MacroGruppo.Magazzino})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_InventoryEntriesDetail", .Gruppo = MacroGruppo.Magazzino})
        ''tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_InventoryEntriesMA_InventoryEntriesReference", .Gruppo = MacroGruppo.Magazzino})
#End Region
#Region "Cross Reference"
        Dim cr As New AccoppiamentiCrossReference
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.OrdCli_NdC.WhereClause, .Coppia_CR = cr.OrdCli_NdC, .FriendName = "OrdCli_NdC", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.OrdCli_FatImmm.WhereClause, .Coppia_CR = cr.OrdCli_FatImmm, .FriendName = "OrdCli_FatImmm", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.OrdFor_BdC.WhereClause, .Coppia_CR = cr.OrdFor_BdC, .FriendName = "OrdFor_BdC", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.DDT_FatImm.WhereClause, .Coppia_CR = cr.DDT_FatImm, .FriendName = "DDT_FatImm", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.FatImm_ParCli.WhereClause, .Coppia_CR = cr.FatImm_ParCli, .FriendName = "FatImm_ParCli", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.FatImm_NdC.WhereClause, .Coppia_CR = cr.FatImm_NdC, .FriendName = "FatImm_NdC", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.FatImm_FatImm.WhereClause, .Coppia_CR = cr.FatImm_FatImm, .FriendName = "FatImm_FatImm", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.NdC_OrdCli.WhereClause, .Coppia_CR = cr.NdC_OrdCli, .FriendName = "NdC_OrdCli", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.BdC_ResFor.WhereClause, .Coppia_CR = cr.BdC_ResFor, .FriendName = "BdC_ResFor", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.BdC_FatImm.WhereClause, .Coppia_CR = cr.BdC_FatImm, .FriendName = "BdC_FatImm", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.BdC_NdCRic.WhereClause, .Coppia_CR = cr.BdC_NdCRic, .FriendName = "BdC_NdCRic", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.ParFor_NdCRic.WhereClause, .Coppia_CR = cr.ParFor_NdCRic, .FriendName = "ParFor_NdCRic", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.ParCli_NdC.WhereClause, .Coppia_CR = cr.ParCli_NdC, .FriendName = "ParCli_NdC", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .AdditionalWhere = cr.Parc_ParFor.WhereClause, .Coppia_CR = cr.Parc_ParFor, .FriendName = "Parc_ParFor", .Gruppo = MacroGruppo.CrossRef})
#End Region

#Region "Note"
        '--Tabelle della UNO a 0 Records
        'MA_ItemCodes
        'MA_ItemCustomersBudget
        'MA_ItemCustomersPriceLists
        'MA_ItemsAnalysisParameters
        'MA_ItemsBRFiscalCtg
        'MA_ItemsBRTaxes
        'MA_ItemsComparableUoM
        'MA_ItemsConai
        'MA_ItemsLanguageDescri
        'MA_ItemsLocations
        'MA_ItemsLocationsMonthly
        'MA_ItemsManufacturingData
        'MA_ItemsMaterials
        'MA_ItemsPriceLists
        'MA_ItemsPurchaseBarCode
        'MA_ItemsStorageRetailPrices
        'MA_ItemsTechDataDefinition
        'MA_ItemsTechnicalData
        'MA_ItemSuppliersOperations
        'MA_ItemsWMS
        'MA_ItemsWMSZones
        'MA_ItemToCtgAssociations
        'MA_ItemTypeBudget
        'MA_ItemTypeCustomers
        'MA_ItemTypeCustomersBudget
        'MA_ItemTypeSuppliers

        '-- Da riebolare
        'xxx MA_ItemsFiscalData
        'xxx MA_ItemsFiscalDataDomCurr

        '-- Da gestire a mano
        '1 MA_ItemParameters

        '--Da non Importare
        'xxx MA_ItemsFIFO
        'xxx MA_ItemsFIFODomCurr
        'xxx MA_ItemsLIFO
        'xxx MA_ItemsLIFODomCurr
        'xxx MA_ItemsMonthlyBalances                       
        'xxx MA_ItemsStorageQty
        'xxx MA_ItemsStorageQtyMonthly
#End Region

#End Region
#Region "Nessuna modifica"
        '''''''''''''''''''''''
        ''''NESSUNA MODIFICA'''
        '''''''''''''''''''''''
#Region "Clienti"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Clienti})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppCustomerOptions", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "Customer", .Gruppo = MacroGruppo.Clienti})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppBranches", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Clienti})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNaturalPerson", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Clienti})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNotes", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Clienti})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppOutstandings", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Clienti}) ' Insoluti
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppPeople", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Cliente, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Clienti})

#End Region
#Region "Fornitori"
        'todo: aspettare risposta Silvia
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSupp", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Fornitori})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppSupplierOptions", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "Supplier", .Gruppo = MacroGruppo.Fornitori})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppBranches", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Fornitori})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNaturalPerson", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Fornitori})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppNotes", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Fornitori})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppOutstandings", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Fornitori}) ' Insoluti
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CustSuppPeople", .WhereClause = " WHERE CustSuppType=" & CustSuppType.Fornitore, .HaListaEsclusi = True, .NotInPK = "CustSupp", .Gruppo = MacroGruppo.Fornitori})
#End Region
#Region "Banche"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Banks", .WhereClause = " WHERE IsACompanyBank = 0", .HaListaEsclusi = True, .NotInPK = "Bank", .Gruppo = MacroGruppo.BancheCli})
#End Region
#Region "Analitica (CdC + Commesse)"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Jobs"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_JobGroups"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_JobsLang"})
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_JobsBalances"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_CostCenterGroups"}) ' nessuna modifica

#End Region
#Region "Cespiti Classi e Categorie"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetsClasses"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetsCtg"})
#End Region
#Region "Ordini - Dati Allsystem"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLAttivita"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLDescrizioni"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLTipoRigaServizio"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "ALLNoteFoxPro"})
#End Region
#Region "Articoli"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Items"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemCustomers"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemNotes"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsGoodsData"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsIntrastat"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsKit"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsSubstitute"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemTypes"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemSuppliers"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemSuppliersPriceLists"})
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalData", .WhereClause = " WHERE FiscalYear = 2023"})
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_ItemsFiscalDataDomCurr", .WhereClause = " WHERE FiscalYear = 2023"})
#End Region
#Region "Magazzino : Depositi"
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Storages"})
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_StorageGroups"})
#End Region
#Region "Agenti"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_SalesPeople", .HaListaEsclusi = True, .NotInPK = "Salesperson", .Gruppo = MacroGruppo.Agenti})
#End Region
#End Region
        Return True
    End Function

    Friend Function ScriviIds(ByVal dv As DataView) As Boolean
        Try
            'Vendite
            Dim found As Integer = dv.Find("SaleDocId")
            Dim SaleDocId As Integer = CInt(dv(found)("NewKey"))
            Dim lastId As Integer = dtNewIds(dvNewIds.Find(IdType.DocVend)).Item("LastId")
            AggiornaIDs(IdType.DocVend, lastId + SaleDocId)
            'Acquisti
            found = dv.Find("PurchaseDocId")
            Dim PurchaseDocId As Integer = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.DocAcq)).Item("LastId")
            AggiornaIDs(IdType.DocAcq, lastId + PurchaseDocId)
            'Ordini Clienti
            found = dv.Find("SaleOrdId")
            Dim SaleOrdId = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.OrdCli)).Item("LastId")
            AggiornaIDs(IdType.OrdCli, lastId + SaleOrdId)
            'Ordini Fornitori
            found = dv.Find("PurchaseOrdId")
            Dim PurchaseOrdId = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.OrdFor)).Item("LastId")
            AggiornaIDs(IdType.OrdFor, lastId + PurchaseOrdId)
            'Dichiarazione di intento 
            'found = dv.Find("DeclId")
            'Dim DeclId As Integer = CInt(dv(found)("NewKey"))
            'lastId = dtNewIds(dvNewIds.Find(IdType.DicIntento)).Item("LastId")
            'AggiornaIDs(IdType.DicIntento, lastId + DeclId)
            'Partite
            found = dv.Find("PymtSchedId")
            Dim PymtId As Integer = CInt(dv(found)("NewKey"))
            lastId = dtNewIds(dvNewIds.Find(IdType.Partite)).Item("LastId")
            AggiornaIDs(IdType.Partite, lastId + PymtId)

            Return True
        Catch ex As Exception
            ScriviLog("#Errore# in ScriviIds: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Aggiorna la tabella degli IdNumbers con i valori "adeguati"
    ''' </summary>
    ''' <param name="IdType"></param>
    ''' <param name="value"></param>
    ''' <param name="MyReturnString"></param>
    Private Sub AggiornaIDs(ByVal IdType As Integer, ByVal value As Integer, Optional ByRef MyReturnString As String = "")
        Try
            Using destConn As New SqlConnection With {.ConnectionString = GetConnectionStringSPA()}
                destConn.Open()
                If destConn.State = ConnectionState.Open Then
                    Using cmd = New SqlCommand("UPDATE MA_IDNumbers SET LastId =" & value.ToString & " WHERE CodeType=@CodeType",
                             ConnDestination)
                        Using idsTrans = destConn.BeginTransaction
                            cmd.Transaction = idsTrans
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
                    End Using
                End If
            End Using
            Dim r As String = ReturnVarName(IdType, GetType(MagoNet.IdType))
            If String.IsNullOrWhiteSpace(MyReturnString) Then
                ScriviLog("Ultimo ID scritto: " & value.ToString & " su tipo: " & r)
            Else
                MyReturnString = "Ultimo ID scritto: " & value.ToString & " su tipo: " & r
            End If
        Catch ex As Exception
            ScriviLog("#Errore# in AggiornaIDs: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
        End Try
    End Sub

    Friend Class IDS
        Public Property Chiave As Boolean
        Public Property Nome As String
        Public Property Id As Integer
        Public Property IdString As String
        Public Property Operatore As String
        Public Property MaxSize As Integer
        Public Property Clausola_Nome As String
        Public Property Clausola_IsString As Boolean
        Public Property Clausola_ValoreInt As Integer
        Public Property Clausola_ValoreStr As String
        Public Property IdSecondario As Integer

        Public Property Cr As CR

    End Class
    Friend Class CR
        Public id As Integer
        Public Property Origine As Integer
        Public Property Derivato As Integer
        Public Function WhereClause() As String
            Return " WHERE OriginDocType =  " & Origine & " AND DerivedDocType = " & Derivato & " "
        End Function
    End Class

    ''' <summary>
    ''' Esegue preparazione e BULK INSERT SQL nel database di destinazione usando un SQLDatareader 
    ''' </summary>
    ''' <returns></returns>
    Private Function ScriviDatiSql(t As TabelleDaEstrarre, ByVal commit As Boolean) As Boolean
        'dsDestination 
        'ConnectionSpa

        Dim loggingTxt As String = "Si"
        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim SQLquery As String
        Dim qryCount As String

        Dim originCount As Long
        'Parametri
        'https://github.com/borisdj/EFCore.BulkExtensions

        Try
            ' Definisco le query per le righe attuali nella tabella
            If String.IsNullOrWhiteSpace(t.JoinClause) Then
                If t.HaListaPKIds Then
                    SQLquery = "Select * FROM " & t.Nome & t.Ritorna_Clausola_IN
                    qryCount = "Select COUNT(1) FROM " & t.Nome & t.Ritorna_Clausola_IN
                ElseIf t.HaListaEsclusi Then
                    SQLquery = "Select * FROM " & t.Nome & t.WhereClause & t.NotInPKClause
                    qryCount = "Select COUNT(1) FROM " & t.Nome & t.WhereClause & t.NotInPKClause
                Else
                    SQLquery = "Select * FROM " & t.Nome & t.WhereClause & t.AdditionalWhere
                    qryCount = "Select COUNT(1) FROM " & t.Nome & t.WhereClause & t.AdditionalWhere
                End If
            Else
                SQLquery = "Select " & t.Nome & ".* " & t.JoinClause & t.WhereClause & t.AdditionalWhere
                qryCount = "Select COUNT(1) " & t.Nome & t.JoinClause & t.WhereClause & t.AdditionalWhere
            End If

            SqlConnection.ClearAllPools()

            'IMPLEMENTAZIONE ASINCRONA
            'Leggo numero record da SPA
            ' Dim taskDestRowCount As Integer = RunNonScalarAsynchronously(qryCount, GetConnectionStringSPA()).Result

            Using origConn As New SqlConnection With {.ConnectionString = GetConnectionStringUNO()}
                origConn.Open()
                If origConn.State = ConnectionState.Open Then
                    'Righe origine
                    Using originRowCount = New SqlCommand(qryCount, origConn)
                        originCount = System.Convert.ToInt32(originRowCount.ExecuteScalar())
                    End Using
                End If
            End Using

            Dim countStart As Long
            Using destConn As New SqlConnection With {.ConnectionString = GetConnectionStringSPA()}
                destConn.Open()
                If destConn.State = ConnectionState.Open Then
                    Using destCommRowCount = New SqlCommand(qryCount, destConn)
                        countStart = System.Convert.ToInt32(destCommRowCount.ExecuteScalar())
                        'Debug.Print("Starting row count = {0}", countStart)
                    End Using
                End If
            End Using
            ScriviLog(t.Nome & " Orig:(" & originCount.ToString & ") --> Dest Iniz:(" & countStart.ToString & ") ")

            Using origConn As New SqlConnection With {.ConnectionString = GetConnectionStringUNO()}
                origConn.Open()
                If origConn.State = ConnectionState.Open Then
                    ' Recupero i dati dall'origine in un SqlDataReader.
                    Dim commandSourceData As New SqlCommand(SQLquery, origConn) With {
                        .CommandTimeout = 0
                    }
                    'Dim reader As SqlDataReader = commandSourceData.ExecuteReader(CommandBehavior.SequentialAccess)
                    Dim reader As SqlDataReader = commandSourceData.ExecuteReader()
                    Using destConn As New SqlConnection With {.ConnectionString = GetConnectionStringSPA()}
                        destConn.Open()
                        If destConn.State = ConnectionState.Open Then
                            Using bulkTrans = destConn.BeginTransaction
                                ' Set up the bulk copy object. 
                                ' The column positions in the source data reader 
                                ' match the column positions in the destination table, 
                                ' so there is no need to map columns.
                                Try
                                    'provo con column mappig = false
                                    okBulk = ScriviBulkSQL(t.Nome, originCount, reader, bulkTrans, destConn, loggingTxt, True)
                                Catch ex As Exception
                                    Debug.Print(ex.Message)
                                Finally
                                    'spostato fuori reader.Close()
                                End Try
                                reader.Close()
                                ScriviLog(loggingTxt)
                                'Controllo lo stato
                                If Not okBulk Then someTrouble = True
                                If someTrouble Then
                                    FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                                    ScriviLog("Riscontrati errori: annullamento operazione...")
                                    bulkTrans.Rollback()
                                Else
                                    If commit Then
                                        bulkTrans.Commit()
                                        Debug.Print("Commit !")
                                    End If
                                    FLogin.lstStatoConnessione.TopIndex = FLogin.lstStatoConnessione.Items.Count - 1
                                End If
                            End Using
                        End If
                    End Using
                End If
            End Using

            ' Effettuo un conteggio finale sulla tabelle di destinazione
            ' per vedere quante righ sono state aggunte.
            Using destConn As New SqlConnection With {.ConnectionString = GetConnectionStringSPA()}
                destConn.Open()
                If destConn.State = ConnectionState.Open Then
                    Using destCommRowCount = New SqlCommand(qryCount, destConn)
                        'Metto ZERO perche' il Commit/RollBack precedente potrebbe metterci molto
                        destCommRowCount.CommandTimeout = 0
                        Dim countEnd As Long = System.Convert.ToInt32(destCommRowCount.ExecuteScalar())
                        Debug.Print("Righe aggiunte finali = {0}", countEnd)
                        Debug.Print("{0} righe aggiunte.", countEnd - countStart)
                        ScriviLog("Agg:(" & (countEnd - countStart).ToString & ")")
                        If (countEnd - countStart) <> originCount Then ScriviLog("Warning - Aggiunta righe diverse.")
                    End Using
                End If
            End Using
            SqlConnection.ClearAllPools()
            Application.DoEvents()

        Catch ex As Exception
            someTrouble = True
            Debug.Print(ex.Message)
            ScriviLog("[Salvataggio] - ERRORE")
            ScriviLog("[Errore Salvataggio] Messaggio:" & ex.Message)
            ScriviLog("[Errore Salvataggio] Stack:" & ex.StackTrace)

            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try

        'Scrivo i Log
        If someTrouble Then
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
        End If
        ScriviLog(String.Empty)

        Return Not someTrouble
    End Function

End Module

''' <summary>
''' Operazione da effettuare alla chiave (id) passata
''' </summary>
Module IdsOp
    Friend Const Somma As String = "+"
    Friend Const SommaCondizionata As String = "+"
    Friend Const Prefisso As String = "ADD"
    Friend Const Suffisso As String = "END"
    Friend Const Salva As String = "SAVE"
    Friend Const Sovrascrivi As String = "OVERWRITE"
    Friend Const Nulla As String = ""

End Module
Module ListeID
    Const PrefissoCespiti As String = "A"
    Const Prefisso As String = "1"
    Const Suffisso As String = "1"
    Const ContropartitaAcquisto As String = "3ACQ"
    Friend Function EstraiListaIds(ByVal table As TabelleDaEstrarre, ByVal dvids As DataView) As List(Of IDS)
        Dim g As MacroGruppo = table.Gruppo
        Dim n As String = table.Nome
        Dim lIDS As New List(Of IDS)
        Select Case g
            Case MacroGruppo.Vendita
                EditTestoBarra("Modifiche: Documenti Vendita")
                lIDS = IdsVendite(dvids, n)
            Case MacroGruppo.Acquisto
                EditTestoBarra("Modifiche: Documenti Acquisto")
                'Logica diversa perche' ho un filtro
                lIDS = IdsAcquisti(dvids, n)
            Case MacroGruppo.Analitica
                EditTestoBarra("Modifiche: Analitica")
                lIDS = IdsCentriDiCosto(n)
            Case MacroGruppo.OrdiniClienti
                EditTestoBarra("Modifiche: Ordini Clienti")
                lIDS = IdsOrdiniClienti(dvids, n)
            Case MacroGruppo.Cespiti
                EditTestoBarra("Modifiche: Cespiti")
                lIDS = IdsCespiti(n)
            Case MacroGruppo.Agenti
                EditTestoBarra("Modifiche: Agenti")
                lIDS = IdsAgenti(n)
            Case MacroGruppo.Clienti
                EditTestoBarra("Modifiche: Clienti")
                lIDS = IdsClienti(dvids, n)
            Case MacroGruppo.Articoli
                EditTestoBarra("Modifiche: Articoli")
                lIDS = IdsArticoli(n)
            Case MacroGruppo.Partite
                EditTestoBarra("Modifiche: Partite")
                lIDS = IdsPartite(dvids, n)
            Case MacroGruppo.CrossRef
                EditTestoBarra("Modifiche: Cross Reference " & table.Coppia_CR.ToString)
                lIDS = IdsCrossRef(dvids, table)
            Case MacroGruppo.Fornitori
                EditTestoBarra("Modifiche: Fornitori")
                lIDS = IdsFornitori(n)
            Case MacroGruppo.OrdiniFornitori
                EditTestoBarra("Modifiche: Ordini Fornitori")
                lIDS = IdsOrdiniFornitori(dvids, n)
            Case MacroGruppo.Parcelle
                EditTestoBarra("Modifiche: Parcelle")
                lIDS = IdsParcelle(dvids, n)
            Case MacroGruppo.Magazzino
                EditTestoBarra("Modifiche: Magazzino")
                lIDS = IdsMovMag(dvids, n)

            Case Else
                MessageBox.Show("Non gestito:" & g.ToString)
        End Select

        Return lIDS
    End Function

    ''' <summary>
    ''' Incremento SaleDocId sulle tabelle delle Vendite
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsVendite(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim SaleDocId As Integer
        Dim found As Integer = dv.Find("SaleDocId")
        If found = -1 Then
            Debug.Print("Vendite SaleDocId: non trovato")
            ScriviLog("Fatture SaleDocId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare,Vendite SaleDocId: non trovato nel file IDS")
                End
            End If
        Else
            SaleDocId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_SaleDoc"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                    Dim fPartita As Integer = dv.Find("PymtSchedId")
                    If fPartita = -1 Then
                        Debug.Print("Fatture: PymtSchedId: non trovato")
                        ScriviLog("Fatture: PymtSchedId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Fatture: PymtSchedId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "IntrastatId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "AdvancePymtSchedId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectedDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InventoryIDReturn", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ParagonID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProFormaInvoiceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJECollectionPaymentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentIdInCN", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "WorkerIDIssue", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ExtAccAEID", .Operatore = IdsOp.Sovrascrivi})
                    'Aggiungo campo aggiuntivo cost center
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                Case "MA_SaleDocComponents", "MA_SaleDocManufReasons", "MA_SaleDocNotes", "MA_SaleDocShipping", "MA_SaleDocSummary", "MA_SaleDocTaxSummary"
                    '"MA_SaleDocReferences", "MA_EIEventViewer", "MA_EI_ITDocAdditionalData", "MA_EI_ITAsyncComm"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                Case "MA_SaleDocPymtSched"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                Case "MA_SaleDocDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "SaleDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    Dim fOrdine As Integer = dv.Find("SaleOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Fatture: SaleOrdId: non trovato")
                        ScriviLog("Fatture: SaleOrdId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Fatture: SaleOrdId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fOrdine)("NewKey")), .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReturnFromCustomerId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "DocIdToBeUnloaded", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceForAdvanceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ProFormaInvoiceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "TRId", .Operatore = IdsOp.Sovrascrivi})
            End Select
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Incremento PurchaseDocId sulle sole Bolle di Carico
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsAcquisti(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim PurchaseDocId As Integer
        Dim found As Integer = dv.Find("PurchaseDocId")
        If found = -1 Then
            Debug.Print("Acquisti PurchaseDocId: non trovato")
            ScriviLog("Acquisti PurchaseDocId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Acquisti PurchaseDocId: non trovato nel file IDS")
                End
            End If
        Else
            PurchaseDocId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_PurchaseDoc"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                    Dim fPartita As Integer = dv.Find("PymtSchedId")
                    If fPartita = -1 Then
                        Debug.Print("Acquisti: PymtSchedId: non trovato")
                        ScriviLog("Acquisti: PymtSchedId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Acquisti: PymtSchedId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "IntrastatId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "RMAId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionOrdId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ScrapInvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReturnInvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = CInt(dv(fPartita)("NewKey")), .Nome = "AdvancePymtSchedId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "AdjValueOnlyInvEntryId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectedDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJECollectionPaymentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CorrectionDocumentIdInCN", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "WorkerIDIssue", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PureJETaxTransferId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ExtAccAEID", .Operatore = IdsOp.Sovrascrivi})
                    'Campi accessori
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                Case "MA_PurchaseDocNotes", "MA_PurchaseDocShipping", "MA_PurchaseDocSummary", "MA_PurchaseDocTaxSummary"
                    '"MA_PurchaseDocReferences"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                Case "MA_PurchaseDocPymtSched"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                Case "MA_PurchaseDocDetail"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "PurchaseDocId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    Dim fOrdine As Integer = dv.Find("PurchaseOrdId")
                    If fOrdine = -1 Then
                        Debug.Print("Acquisti: PurchaseOrdId: non trovato")
                        ScriviLog("Acquisti: PurchaseOrdId: non trovato")
                        If Not IsDebugging Then
                            MessageBox.Show("Impossibile continuare, Acquisti: PurchaseOrdId: non trovato nel file IDS")
                            End
                        End If
                    Else
                        lIDS.Add(New IDS With {.Id = CInt(dv(fOrdine)("NewKey")), .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                    End If
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionOrdId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InspectionBillId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "RMAId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "BillOfLadingId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SaleDocId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocumentId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "InvoiceForAdvanceID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SuppQuotaId", .Operatore = IdsOp.Sovrascrivi})
            End Select
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Incremento SaleOrdId sugli Ordini
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsOrdiniClienti(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Dim SaleOrdId As Integer
        Dim SaleDocId As Integer
        Dim found As Integer = dv.Find("SaleOrdId")
        If found = -1 Then
            Debug.Print("Ordini SaleOrdId: non trovato")
            ScriviLog("Ordini SaleOrdId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Ordini SaleOrdId: non trovato nel file IDS")
                End
            End If
        Else
            Dim fVen As Integer = dv.Find("SaleDocId")
            If fVen = -1 Then
                Debug.Print("Crossref SaleDocId: non trovato")
                ScriviLog("Crossref SaleDocId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare, Crossref SaleDocId: non trovato nel file IDS")
                    End
                End If
            Else
                SaleOrdId = CInt(dv(found)("NewKey"))
                SaleDocId = CInt(dv(fVen)("NewKey"))
                Select Case tablename
                    Case "MA_SaleOrdComponents", "MA_SaleOrdNotes", "MA_SaleOrdPymtSched", "MA_SaleOrdShipping", "MA_SaleOrdSummary", "MA_SaleOrdTaxSummary"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                    Case "MA_SaleOrd"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                    Case "MA_SaleOrdDetails"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ProductionPlanId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ProductionJobId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceQuotationId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    Case "ALLOrdCliDescrizioni", "ALLOrdCliContratto", "ALLOrdCliTipologiaServizi", "ALLOrdCliAttivita"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                    Case "ALLOrdFiglio"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "IdOrdFiglio", .Operatore = IdsOp.Somma})
                    Case "ALLOrdPadre"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "IdOrdPadre", .Operatore = IdsOp.Somma})
                    Case "ALLOrdCliAcc"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "Cdc", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    Case "ALLCespiti"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "IdOrdCli", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = PrefissoCespiti, .Nome = "Cespite", .Operatore = IdsOp.Prefisso, .MaxSize = 10})
                    Case "MA_SaleOrdReferences"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "SaleOrdId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DocumentId", .Operatore = IdsOp.Somma})

                End Select
            End If
        End If

        Return lIDS
    End Function
    ''' <summary>
    ''' Incremento PurchaseOrdId sugli Ordini
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsOrdiniFornitori(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Dim PurchaseOrdId As Integer
        Dim found As Integer = dv.Find("PurchaseOrdId")
        If found = -1 Then
            Debug.Print("Ordini PurchaseOrdId: non trovato")
            ScriviLog("Ordini PurchaseOrdId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Ordini PurchaseOrdId: non trovato nel file IDS")
                End
            End If
        Else
            PurchaseOrdId = CInt(dv(found)("NewKey"))
            Select Case tablename
                Case "MA_PurchaseOrdNotes", "MA_PurchaseOrdPymtSched", "MA_PurchaseOrdShipping", "MA_PurchaseOrdSummary", "MA_PurchaseOrdTaxSummay"
                    '"MA_PurchaseOrdReferences"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                Case "MA_PurchaseOrd"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                Case "MA_PurchaseOrdDetails"
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "PurchaseOrdId", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "PurchaseReqId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SuppQuotaId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "MOId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "SaleOrdId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "ReferenceDocId", .Operatore = IdsOp.Sovrascrivi})
                    lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
            End Select
        End If

        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso UNO ai Cepiti e Ubicazioni
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsCespiti(ByVal tablename As String) As List(Of IDS)
        'dati presenti in 4 tabelle
        'MA_FixAssetEntriesDetail   'Esclusa
        'MA_FixedAssets
        'MA_FixedAssetsBalance      'Esclusa
        'MA_FixedAssetsFiscal       'Esclusa
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_FixedAssets"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = PrefissoCespiti, .Nome = "FixedAsset", .Operatore = IdsOp.Prefisso, .MaxSize = 10})
                lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Location", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
            Case "MA_FixAssetLocations"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Location", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Movimenti di magazzino
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsMovMag(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim EntryId As Integer
        Dim found As Integer = dv.Find("EntryId")
        If found = -1 Then
            Debug.Print("Magazzino EntryId: non trovato")
            ScriviLog("Magazzino EntryId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare,Magazzino EntryId: non trovato nel file IDS")
                End
            End If
        Else
            Dim SaleDocId As Integer
            Dim foundVen As Integer = dv.Find("SaleDocId")
            If foundVen = -1 Then
                Debug.Print("Magazzino SaleDocId: non trovato")
                ScriviLog("Magazzino SaleDocId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare,Magazzino SaleDocId: non trovato nel file IDS")
                    End
                End If
            Else
                SaleDocId = CInt(dv(foundVen)("NewKey"))
                EntryId = CInt(dv(found)("NewKey"))
                Select Case tablename
                    Case "MA_InventoryEntries"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = EntryId, .Nome = "EntryId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    Case "MA_InventoryEntriesDetail"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = EntryId, .Nome = "EntryId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "OrderId", .Operatore = IdsOp.Sovrascrivi}) ' per pigrizia lo metto a zero non so se e' ordine cliente o fornitore
                        lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "BolId", .Operatore = IdsOp.Somma}) ' IdBolla
                        lIDS.Add(New IDS With {.Id = EntryId, .Nome = "VariationInvEntryID", .Operatore = IdsOp.Somma})
                    Case "MA_InventoryEntriesReference"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = EntryId, .Nome = "EntryId", .Operatore = IdsOp.Somma})
                End Select
            End If
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' DEPRECATA
    ''' Viene controllata contropartita
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsArticoli(ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_Items"
                lIDS.Add(New IDS With {.IdString = ContropartitaAcquisto, .Nome = "PurchaseOffset", .Operatore = IdsOp.Salva, .MaxSize = 16})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto suffisso
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsAgenti(ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_Areas"
                'lIDS.Add(New IDS With {.Chiave = True, .IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Dichiarazioni di Intento. Clienti
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsClienti(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_DeclarationOfIntent"
                Dim DeclId As Integer
                Dim found As Integer = dv.Find("DeclId")
                If found = -1 Then
                    Debug.Print("Clienti DeclId: non trovato")
                    ScriviLog("Clienti DeclId: non trovato")
                    If Not IsDebugging Then
                        MessageBox.Show("Impossibile continuare, Clienti DeclId: non trovato nel file IDS")
                        End
                    End If
                Else
                    DeclId = CInt(dv(found)("NewKey"))
                    lIDS.Add(New IDS With {.Chiave = True, .Id = DeclId, .Nome = "DeclId", .Operatore = IdsOp.Somma})
                End If
            Case "MA_SDDMandate"
                lIDS.Add(New IDS With {.IdString = "20231231", .Nome = "MandateFirstDate", .Operatore = IdsOp.Sovrascrivi})

            Case "MA_CustSuppCustomerOptions"
                'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Fornitori
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsFornitori(ByVal tablename As String) As List(Of IDS)
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_CustSuppSupplierOptions"
                ' lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
        End Select
        Return lIDS
    End Function
    ''' <summary>
    ''' Viene aggiunto il prefisso 1 ai Centri di Costo
    ''' </summary>
    ''' <returns></returns>
    Private Function IdsCentriDiCosto(ByVal tablename As String) As List(Of IDS)
        'Presente su 21 tabelle !!!!!
        'MA_ChartOfAccountsCostAccTpl   'Esclusa
        'MA_CostAccEntriesDetail        'Esclusa
        'MA_CostCenters
        'MA_CostCentersBalances         'Esclusa
        'MA_CustSupp                    '2 Voci
        'MA_FixedAssets
        'MA_InventoryEntries            'Esclusa
        'MA_InventoryEntriesDetail      'Esclusa
        'MA_Items                       '2 Voci
        'MA_PurchaseDoc                 'Aggiunta
        'MA_PurchaseDocDetail           'Aggiunta
        'MA_PurchaseDocPymtSched        'Aggiunta
        'MA_PurchaseOrd                 'Aggiunta
        'MA_PurchaseOrdDetails          'Aggiunta
        'MA_PyblsRcvblsDetails          'Stand by
        'MA_SaleDoc                     'Aggiunta
        'MA_SaleDocDetail               'Aggiunta
        'MA_SaleDocPymtSched            'Aggiunta
        'MA_SaleOrd                     'Aggiunta
        'MA_SaleOrdDetails              'Aggiunta
        'MA_Workers                     'Esclusa
        Dim lIDS As New List(Of IDS)
        Select Case tablename
            Case "MA_CostCenters"
                lIDS.Add(New IDS With {.Chiave = True, .IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
        End Select

        Return lIDS
    End Function
    ''' <summary>
    ''' Solo Partite Cliente Aperte
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsPartite(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim PymtSchedId As Integer
        Dim SaleDocId As Integer
        Dim PurchaseDocId As Integer
        Dim found As Integer = dv.Find("PymtSchedId")
        If found = -1 Then
            Debug.Print("Partite PymtSchedId: non trovato")
            ScriviLog("Partite PymtSchedId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Partite PymtSchedId: non trovato nel file IDS")
                End
            End If
        Else
            Dim foundVen As Integer = dv.Find("SaleDocId")
            If foundVen = -1 Then
                Debug.Print("Partite SaleDocId: non trovato")
                ScriviLog("Partite SaleDocId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare,Partite SaleDocId: non trovato nel file IDS")
                    End
                End If
            Else
                Dim foundAcq As Integer = dv.Find("PurchaseDocId")
                If foundAcq = -1 Then
                    Debug.Print("Partite PurchaseDocId: non trovato")
                    ScriviLog("Partite PurchaseDocId: non trovato")
                    If Not IsDebugging Then
                        MessageBox.Show("Impossibile continuare,Partite PurchaseDocId: non trovato nel file IDS")
                        End
                    End If
                Else
                    PymtSchedId = CInt(dv(found)("NewKey"))
                    SaleDocId = CInt(dv(foundVen)("NewKey"))
                    PurchaseDocId = CInt(dv(foundAcq)("NewKey"))
                    Select Case tablename
                        Case "MA_PyblsRcvbls"
                            lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                        Case "MA_PyblsRcvblsDetails"
                            lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "PresentationJEId", .Operatore = IdsOp.Sovrascrivi})
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                            lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DocumentId", .Operatore = IdsOp.SommaCondizionata, .IdSecondario = PurchaseDocId, .Clausola_IsString = False, .Clausola_Nome = "CustSuppType", .Clausola_ValoreInt = CustSuppType.Fornitore}) ' = id Documento di ven/acq
                            'lIDS.Add(New IDS With {.Id = 0, .Nome = "DocumentType", .Operatore = IdsOp.Uguale})  '=3801088 = Documenti Di vendita
                            lIDS.Add(New IDS With {.Id = 0, .Nome = "CollectionJEId", .Operatore = IdsOp.Sovrascrivi})
                            'lIDS.Add(New IDS With {.IdString = Suffisso, .Nome = "Area", .Operatore = IdsOp.Suffisso, .MaxSize = 8})
                            lIDS.Add(New IDS With {.IdString = Prefisso, .Nome = "CostCenter", .Operatore = IdsOp.Prefisso, .MaxSize = 8})
                            'RIBA -> Nulla da modificare
                            'Mandato RID -> Nulla da Modificare
                    End Select
                End If
            End If
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Parcelle
    ''' </summary>
    ''' <param name="dv"></param>
    ''' <returns></returns>
    Private Function IdsParcelle(ByVal dv As DataView, ByVal tablename As String) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim FeeId As Integer
        Dim PymtSchedId As Integer
        Dim found As Integer = dv.Find("FeeId")
        If found = -1 Then
            Debug.Print("Parcelle FeeId: non trovato")
            ScriviLog("Parcelle FeeId: non trovato")
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Parcelle FeeId: non trovato nel file IDS")
                End
            End If
        Else
            Dim foundScad As Integer = dv.Find("PymtSchedId")
            If foundScad = -1 Then
                Debug.Print("Parcelle PymtSchedId: non trovato")
                ScriviLog("Parcelle PymtSchedId: non trovato")
                If Not IsDebugging Then
                    MessageBox.Show("Impossibile continuare,Parcelle PymtSchedId: non trovato nel file IDS")
                    End
                End If
            Else
                FeeId = CInt(dv(found)("NewKey"))
                PymtSchedId = CInt(dv(foundScad)("NewKey"))
                Select Case tablename
                    Case "MA_Fees"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = FeeId, .Nome = "FeeId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "TransferJournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "JournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "ClosingJournalEntryId", .Operatore = IdsOp.Sovrascrivi})
                        lIDS.Add(New IDS With {.Id = PymtSchedId, .Nome = "PymtSchedId", .Operatore = IdsOp.Somma})
                        lIDS.Add(New IDS With {.Id = 0, .Nome = "CRRefID", .Operatore = IdsOp.Sovrascrivi})
                    Case "MA_FeesDetails"
                        lIDS.Add(New IDS With {.Chiave = True, .Id = FeeId, .Nome = "FeeId", .Operatore = IdsOp.Somma})
                End Select
            End If
        End If
        Return lIDS
    End Function
    ''' <summary>
    ''' Riferimenti Incrociati
    ''' </summary>
    Private Function IdsCrossRef(ByVal dv As DataView, ByVal tablename As TabelleDaEstrarre) As List(Of IDS)

        Dim lIDS As New List(Of IDS)
        Dim PymtSchedId As Integer
        Dim SaleDocId As Integer
        Dim SaleOrdId As Integer
        Dim PurchaseDocId As Integer
        Dim PurchaseOrdId As Integer
        Dim FeeId As Integer
        Dim ok As Boolean = True

#Region "Controllo presenza ids"
        Dim f As Integer = dv.Find("PymtSchedId")
        If f = -1 Then
            Debug.Print("Crossref PymtSchedId: non trovato")
            ScriviLog("Crossref PymtSchedId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref PymtSchedId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fVen As Integer = dv.Find("SaleDocId")
        If fVen = -1 Then
            Debug.Print("Crossref SaleDocId: non trovato")
            ScriviLog("Crossref SaleDocId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref SaleDocId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fOrdCli As Integer = dv.Find("SaleOrdId")
        If fOrdCli = -1 Then
            Debug.Print("Crossref SaleOrdId: non trovato")
            ScriviLog("Crossref SaleOrdId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref SaleOrdId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fAcq As Integer = dv.Find("PurchaseDocId")
        If fAcq = -1 Then
            Debug.Print("Crossref PurchaseDocId: non trovato")
            ScriviLog("Crossref PurchaseDocId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref PurchaseDocId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fOrdFor As Integer = dv.Find("PurchaseOrdId")
        If fOrdCli = -1 Then
            Debug.Print("Crossref PurchaseOrdId: non trovato")
            ScriviLog("Crossref PurchaseOrdId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Ordini PurchaseOrdId: non trovato nel file IDS")
                End
            End If
        End If
        Dim fParcella As Integer = dv.Find("FeeId")
        If fParcella = -1 Then
            Debug.Print("Crossref FeeId: non trovato")
            ScriviLog("Crossref FeeId: non trovato")
            ok = False
            If Not IsDebugging Then
                MessageBox.Show("Impossibile continuare, Crossref FeeId: non trovato nel file IDS")
                End
            End If
        End If
#End Region

        If ok Then
            PymtSchedId = CInt(dv(f)("NewKey"))
            SaleDocId = CInt(dv(fVen)("NewKey"))
            SaleOrdId = CInt(dv(fOrdCli)("NewKey"))
            PurchaseDocId = CInt(dv(fAcq)("NewKey"))
            PurchaseOrdId = CInt(dv(fOrdFor)("NewKey"))
            FeeId = CInt(dv(fParcella)("NewKey"))
            Dim cr As New AccoppiamentiCrossReference
            Select Case tablename.Coppia_CR.id
                Case cr.OrdCli_NdC.id, cr.OrdCli_FatImmm.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleOrdId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.OrdFor_BdC.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseOrdId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PurchaseDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.DDT_FatImm.id, cr.FatImm_FatImm.id, cr.FatImm_NdC.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.FatImm_ParCli.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PymtSchedId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.NdC_OrdCli.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = SaleDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.BdC_ResFor.id, cr.BdC_FatImm.id, cr.BdC_NdCRic.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PurchaseDocId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleOrdId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.ParFor_NdCRic.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PurchaseDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.ParCli_NdC.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = PymtSchedId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = SaleDocId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case cr.Parc_ParFor.id
                    lIDS.Add(New IDS With {.Chiave = True, .Id = FeeId, .Nome = "OriginDocType", .Operatore = IdsOp.Somma})
                    lIDS.Add(New IDS With {.Id = PymtSchedId, .Nome = "DerivedDocID", .Operatore = IdsOp.Somma})
                Case Else
                    MessageBox.Show("Coppia non trovata")

            End Select
        End If

        Return lIDS
    End Function
End Module
