Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports System.Text
Imports ALLSystemTools.SqlTools


Module Fusione

    'Tabelle database di origine
    Friend dtIDS As DataTable
    Friend dvIDS As DataView
    'Tabelle database di destinazione
    Friend dtNewIds As DataTable
    Friend dvNewIds As DataView
    'Contenitori delle tabelle da processare
    Friend tabelle As List(Of TabelleDaEstrarre)
    Friend tabelleNoEdit As List(Of TabelleDaEstrarre)
    Friend listeIDs As List(Of ListaId)
    Private secondImport As Boolean

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
    Friend Class ListaId
        Public Property Ids As List(Of Integer)
        Public Property Nome As String
        Public Sub New()
            Ids = New List(Of Integer)
            Nome = ""
        End Sub
    End Class

    Public Enum MacroGruppo As Integer
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
        Contabilita = 16
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
            Case 16
                Return "Contabilità"
            Case Else
                Return ""
        End Select
    End Function
    Public Function EseguiFusioneSQL(dts As DataSet) As Boolean
        Dim ok As Boolean
        Dim someTrouble As Boolean

        'Popolo lista con le tabelle e cosa fare
        tabelle = New List(Of TabelleDaEstrarre)
        tabelleNoEdit = New List(Of TabelleDaEstrarre)

        If FLogin.ChkFusioneFull.Checked Then
            ok = EstraiTabelle()
        End If
        If FLogin.ChkFusioneAcquisti.Checked Then
            secondImport = True
            ok = EstraiTabelleAcquisti()
        End If
        If FLogin.ChkFusioneVendite.Checked Then
            secondImport = True
            ok = EstraiTabelleFatture()
        End If
        If FLogin.ChkFusionePartite.Checked Then
            secondImport = True
            ok = EstraiTabellePartite()
        End If
        If FLogin.chkBilancioApertura.Checked Then
            secondImport = True
            ok = EstraiTabelleApertura()
        End If


        If ok Then
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
                    'Genero lista esclusi
                    If t.HaListaEsclusi Then
                        t.EstraiListaEsclusi(dvEsclusi)
                    End If
                    'Metodo Sql Update
                    Dim rows As Integer
                    ok = ModificaSqlUpdate(t, lIDS, rows)
                    ScriviLog("ModificaSql: " & n & " Esito:" & ok.ToString)
                    Application.DoEvents()
                    'Genero lista PK dopo aver modificato gli ID
                    If t.GeneraListaPKIds Then
                        Dim PKList As List(Of Integer) = EstraiListaPK(t)
                        For Each table In t.TabelleDipendenti
                            If Left(table, 18).Equals("MA_CrossReferences") Then
                                tabelle.Find(Function(x) x.Nome = Left(table, 18) And x.FriendName = table.Substring(19)).ListaPKIds = PKList
                            Else
                                tabelle.Find(Function(x) x.Nome = table).ListaPKIds = PKList
                            End If
                        Next
                    End If
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
        Else
            someTrouble = True
        End If
        ScriviLog("Fine processo")
        Return someTrouble
    End Function


    Friend Function EstraiListaPK(t As TabelleDaEstrarre) As List(Of Integer)
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

    Friend Function ModificaSqlUpdate(t As TabelleDaEstrarre, ByVal lids As List(Of IDS), ByRef rows As Integer) As Boolean
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
                                    value = "(CASE WHEN " & field & " = 0 THEN 0 ELSE " & field & " + " & parameter & " END)"
                                    cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})

                                Case IdsOp.SommaCondizionata
                                    Dim iDaSommare As Integer
                                    If f.Clausola_IsString Then
                                        'non funziona
                                        If f.Clausola_Nome.Equals(f.Clausola_ValoreStr) Then
                                            iDaSommare = f.IdSecondarioString
                                        Else
                                            iDaSommare = f.IdString
                                        End If
                                        value = "(CASE WHEN " & field & " = 0 THEN 0 ELSE " & field & " + " & parameter & " END)"
                                        cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = iDaSommare})

                                    Else
                                        paramIndex += 1
                                        Dim parameterparameterSecond As String = "@P" & paramIndex.ToString

                                        value = "(CASE WHEN " & f.Clausola_Nome & " = " & f.Clausola_ValoreInt & " THEN " & field & " + " & parameter & " ELSE " & field & " + " & parameterparameterSecond & " END)"
                                        If f.Clausola_ControlloZero Then value &= " END)"
                                        cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})
                                        cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameterparameterSecond, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.IdSecondario})
                                    End If

                                Case IdsOp.Nulla ' ""
                                    'value = f.Id.ToString
                                    cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})

                                Case IdsOp.Prefisso, IdsOp.Suffisso '"ADD", "End"
                                    value = "(Case When " & field & " ='' THEN '' ELSE "
                                    If f.Operatore = IdsOp.Prefisso Then
                                        value = value & "CONCAT('" & f.IdString & "', " & field & ") END)"
                                    Else
                                        'END" = Suffisso
                                        value = value & "CONCAT(" & field & " ,'" & f.IdString & "') END)"
                                    End If
                                Case IdsOp.Salva '"SAVE"
                                    'Non la uso piu'
                                    value = "(CASE WHEN " & field & " <>'' AND " & field & " <> '" & f.IdString & "'  THEN '' ELSE " & field & " END)"
                                    cmdqry.Parameters.Add(parameter, SqlDbType.VarChar, f.MaxSize).Value = value
                                Case IdsOp.Sovrascrivi '"OVERWRITE"
                                    value = parameter
                                    If f.Id = 0 AndAlso Not String.IsNullOrWhiteSpace(f.IdString) Then
                                        If f.UseCase Then
                                            value = "(CASE WHEN " & field & " = '" & f.FirtsCase & "' THEN " & parameter & " ELSE " & field & " END)"
                                            cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.VarChar, .Size = f.MaxSize, .Direction = ParameterDirection.Input, .Value = f.IdString})
                                        End If
                                    Else
                                        cmdqry.Parameters.Add(New SqlParameter With {.ParameterName = parameter, .SqlDbType = SqlDbType.Int, .Direction = ParameterDirection.Input, .Value = f.Id})

                                    End If

                            End Select

                            'Chiudo la query
                            Select Case f.Operatore
                                Case IdsOp.Somma, IdsOp.SommaCondizionata, IdsOp.Sovrascrivi
                                    sb.AppendLine(field & " = " & value & ", ") 'Il parametro e' passato sopra nella composizione
                                Case IdsOp.Prefisso, IdsOp.Suffisso '"ADD", "END"
                                    sb.AppendLine(field & " = " & value & ", ")
                                Case Else
                                    sb.AppendLine(field & " = " & parameter & ", ")
                            End Select

                        Next
                        qryToExecute &= Strings.Left(sb.ToString, sb.Length - 4)

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

    Friend Sub DisattivaVincolieRelazioni()
        Try
            FLogin.lstStatoConnessione.Items.Add("TRACEON Origine...")
            RunNonQuery("DBCC TRACEON(610)", GetConnectionStringUNO)
            FLogin.lstStatoConnessione.Items.Add("TRACEON Destinazione...")
            RunNonQuery("DBCC TRACEON(610)", GetConnectionStringSPA)
            ' Solo per SQL 2017 in su
            ' RunNonQuery("DBCC TRACEON(460,1)", GetConnectionStringUNO)  ' per cambiare errore ID 8152 with 2628
            FLogin.lstStatoConnessione.Items.Add("Disattivo vincoli per Origine...")
            Debug.Print("Disattivo vincoli per Origine...")
            RunNonQuery("EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'", GetConnectionStringUNO)
        Catch ex As Exception
            Debug.Print(ex.Message)
            FLogin.lstStatoConnessione.Items.Add("ERRORE SU 'Disattivo vincoli e Relazioni'")
            ScriviLog("#Errore# DISATTIVO VINCOLI E RELAZIONI " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
        End Try
    End Sub
    Friend Sub AttivaVincolieRelazioni()
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
    ''' <summary>
    ''' Lanciata come seconda impostrazione. 
    ''' Su nuova copia DB quindi devo rimodificare comunque tutti gli IDS per
    ''' </summary>
    ''' <returns></returns>
    Private Function EstraiTabelleFatture() As Boolean
        Dim ddb As New DocumentDialogBox With {.Text = .Text & " - Vendita", .lbl = "Inserire il numero di partenza", .lblSottotit = "Data Fattura >= 01/01/2023"}
        If ddb.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim n As String = ddb.Numero
            Dim wf As String = " WHERE DocumentType IN (" & DocumentType.Fattura & ", " & DocumentType.FatturaAccompagnatoria & ", " & DocumentType.NotaCredito & ") And DocNo >= '" & n & "' AND DocumentDate >='20230101' "
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDoc", .WhereClause = wf, .PrimaryKey = "SaleDocId", .ModificaTutti = True, .GeneraListaPKIds = True, .Gruppo = MacroGruppo.Vendita,
                                                    .TabelleDipendenti = New List(Of String) From {"MA_SaleDoc", "MA_SaleDocComponents", "MA_SaleDocDetail", "MA_SaleDocManufReasons", "MA_SaleDocNotes", "MA_SaleDocPymtSched", "MA_SaleDocShipping", "MA_SaleDocSummary", "MA_SaleDocTaxSummary",
                                                                                                    "MA_CrossReferences_OrdCli_NdC", "MA_CrossReferences_OrdCli_FatImmm", "MA_CrossReferences_DDT_FatImm", "MA_CrossReferences_FatImm_NdC", "MA_CrossReferences_FatImm_FatImm", "MA_CrossReferences_NdC_OrdCli", "MA_CrossReferences_BdC_FatImm"}})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocComponents", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocDetail", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocManufReasons", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocNotes", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocPymtSched", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocShipping", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocSummary", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_SaleDocTaxSummary", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "SaleDocId", .Gruppo = MacroGruppo.Vendita})

            Dim cr As New AccoppiamentiCrossReference
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.OrdCli_NdC.WhereClause, .Coppia_CR = cr.OrdCli_NdC, .FriendName = "OrdCli_NdC", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "DerivedDocID", .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.OrdCli_FatImmm.WhereClause, .Coppia_CR = cr.OrdCli_FatImmm, .FriendName = "OrdCli_FatImmm", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "DerivedDocID", .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.DDT_FatImm.WhereClause, .Coppia_CR = cr.DDT_FatImm, .FriendName = "DDT_FatImm", .HaListaPKIds = True, .IncludiSempreWhere = True, .MultiPk = True, .PrimaryKeys = New List(Of String) From {"OriginDocID", "DerivedDocID"}, .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.FatImm_NdC.WhereClause, .Coppia_CR = cr.FatImm_NdC, .FriendName = "FatImm_NdC", .HaListaPKIds = True, .IncludiSempreWhere = True, .MultiPk = True, .PrimaryKeys = New List(Of String) From {"OriginDocID", "DerivedDocID"}, .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.FatImm_FatImm.WhereClause, .Coppia_CR = cr.FatImm_FatImm, .FriendName = "FatImm_FatImm", .HaListaPKIds = True, .IncludiSempreWhere = True, .MultiPk = True, .PrimaryKeys = New List(Of String) From {"OriginDocID", "DerivedDocID"}, .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.NdC_OrdCli.WhereClause, .Coppia_CR = cr.NdC_OrdCli, .FriendName = "NdC_OrdCli", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "OriginDocID", .Gruppo = MacroGruppo.CrossRef})
            'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences_BdC_ResFor", .WhereClause = cr.BdC_ResFor.WhereClause, .Coppia_CR = cr.BdC_ResFor, .FriendName = "BdC_ResFor", .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.BdC_FatImm.WhereClause, .Coppia_CR = cr.BdC_FatImm, .FriendName = "BdC_FatImm", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "DerivedDocID", .Gruppo = MacroGruppo.CrossRef})

            Return True
        Else Return False
        End If
    End Function

    Private Function EstraiTabellePartite() As Boolean

        Dim wp As String = " WHERE PymtSchedId IN (SELECT DISTINCT t.PymtSchedId FROM MA_PyblsRcvbls t left JOIN MA_PyblsRcvblsDetails d ON t.PymtSchedId = d.PymtSchedId WHERE  t.Settled = '0' OR d.OpeningDate >='20230331' ) "
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvbls",
                    .ModificaTutti = True, .WhereClause = wp, .PrimaryKey = "PymtSchedId", .GeneraListaPKIds = True,
                    .TabelleDipendenti = New List(Of String) From {"MA_PyblsRcvbls", "MA_PyblsRcvblsDetails", "MA_CrossReferences_FatImm_ParCli", "MA_CrossReferences_ParFor_NdCRic", "MA_CrossReferences_ParCli_NdC", "MA_CrossReferences_Parc_ParFor"},
                    .Gruppo = MacroGruppo.Partite})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvblsDetails", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "PymtSchedId", .Gruppo = MacroGruppo.Partite})

        'Cross Reference
        Dim cr As New AccoppiamentiCrossReference
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.FatImm_ParCli.WhereClause, .Coppia_CR = cr.FatImm_ParCli, .FriendName = "FatImm_ParCli", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "DerivedDocID", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.ParFor_NdCRic.WhereClause, .Coppia_CR = cr.ParFor_NdCRic, .FriendName = "ParFor_NdCRic", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "OriginDocID", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.ParCli_NdC.WhereClause, .Coppia_CR = cr.ParCli_NdC, .FriendName = "ParCli_NdC", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "OriginDocID", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.Parc_ParFor.WhereClause, .Coppia_CR = cr.Parc_ParFor, .FriendName = "Parc_ParFor", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "DerivedDocID", .Gruppo = MacroGruppo.CrossRef})

        Return True
    End Function
    Private Function EstraiTabelleAcquisti() As Boolean
        Dim ddb As New DocumentDialogBox With {.Text = .Text & " - Acquisti", .lbl = "Inserire il protocollo di partenza", .lblSottotit = "Data Protocollo >= 01/01/2023"}
        If ddb.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim n As String = ddb.Numero
            Dim wf As String = " WHERE DocumentType IN (" & DocumentType.AcqFattura & ", " & DocumentType.AcqBollaDiCarico & ", " & DocumentType.AcqNotaCredito & ") And DocNo >= '" & n & "' AND DocumentDate >='20230101' "
            'Adeguo gli ID su tutta la tabella ma mi copio solo il tipo documento desiderato
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDoc", .WhereClause = wf, .PrimaryKey = "PurchaseDocId", .ModificaTutti = True, .GeneraListaPKIds = True,
                                                    .TabelleDipendenti = New List(Of String) From {"MA_PurchaseDoc", "MA_PurchaseDocDetail", "MA_PurchaseDocNotes", "MA_PurchaseDocPymtSched", "MA_PurchaseDocShipping", "MA_PurchaseDocSummary", "MA_PurchaseDocTaxSummary",
                                                                                                    "MA_CrossReferences_OrdCli_NdC", "MA_CrossReferences_OrdCli_FatImmm", "MA_CrossReferences_DDT_FatImm", "MA_CrossReferences_FatImm_NdC", "MA_CrossReferences_FatImm_FatImm", "MA_CrossReferences_NdC_OrdCli", "MA_CrossReferences_BdC_FatImm"}, .Gruppo = MacroGruppo.Acquisto})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocDetail", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "PurchaseDocId", .Gruppo = MacroGruppo.Acquisto})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocNotes", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "PurchaseDocId", .Gruppo = MacroGruppo.Acquisto})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocPymtSched", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "PurchaseDocId", .Gruppo = MacroGruppo.Acquisto})
            'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocReferences", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "PurchaseDocId", .Gruppo = MacroGruppo.Acquisto})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocShipping", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "PurchaseDocId", .Gruppo = MacroGruppo.Acquisto})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocSummary", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "PurchaseDocId", .Gruppo = MacroGruppo.Acquisto})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PurchaseDocTaxSummary", .HaListaPKIds = True, .ModificaTutti = True, .PrimaryKey = "PurchaseDocId", .Gruppo = MacroGruppo.Acquisto})

            Dim cr As New AccoppiamentiCrossReference
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.OrdFor_BdC.WhereClause, .Coppia_CR = cr.OrdFor_BdC, .FriendName = "OrdFor_BdC", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "DerivedDocID", .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.BdC_ResFor.WhereClause, .Coppia_CR = cr.BdC_ResFor, .FriendName = "BdC_ResFor", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "OriginDocID", .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.BdC_FatImm.WhereClause, .Coppia_CR = cr.BdC_FatImm, .FriendName = "BdC_FatImm", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "OriginDocID", .Gruppo = MacroGruppo.CrossRef})
            tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.BdC_NdCRic.WhereClause, .Coppia_CR = cr.BdC_NdCRic, .FriendName = "BdC_NdCRic", .HaListaPKIds = True, .IncludiSempreWhere = True, .PrimaryKey = "OriginDocID", .Gruppo = MacroGruppo.CrossRef})

            Return True
        Else Return False
        End If
    End Function
    ''' <summary>
    ''' Scritture contabili Bilancio di Apertura.
    ''' </summary>
    ''' <returns></returns>
    Private Function EstraiTabelleApertura() As Boolean

        Dim wp As String = " WHERE AccTpl ='FUSIONE' AND PostingDate >='20230401' "
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_JournalEntries",
                    .ModificaTutti = True, .WhereClause = wp, .HaListaPKIds = True, .PrimaryKey = "JournalEntryId", .GeneraListaPKIds = True,
                    .TabelleDipendenti = New List(Of String) From {"MA_JournalEntries", "MA_JournalEntriesGLDetail"},
                    .Gruppo = MacroGruppo.Contabilita})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_JournalEntriesGLDetail", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "JournalEntryId", .Gruppo = MacroGruppo.Contabilita})

        Return True
    End Function
    ''' <summary>
    ''' Estraggo le tabelle
    ''' </summary>
    ''' <returns></returns>
    Friend Function EstraiTabelle() As Boolean
        EditTestoBarra("Creazione elenco lavori")
        FLogin.lstStatoConnessione.Items.Add("Creazione elenco lavori")
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
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssets", .ModificaTutti = True, .WhereClause = " WHERE DisposalType = 7143424", .Gruppo = MacroGruppo.Cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsBalance", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsCoeff", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFinancial", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsFiscal", .Gruppo = MacroGruppo.cespiti})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixedAssetsPeriod", .Gruppo = MacroGruppo.cespiti})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FixAssetLocations", .Gruppo = MacroGruppo.Cespiti})
#End Region
#Region "Analitica ( Centri di Costo + Commesse)"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CostCenters", .Gruppo = MacroGruppo.Analitica})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Jobs", .Gruppo = MacroGruppo.Analitica})

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
#Region "SPOSTATO A PASSAGGIO DEDICATO - Partite"
        'Considero OpeningDate e Settled ( Aperte)
        'Dim wp As String = " WHERE PymtSchedId IN (SELECT DISTINCT t.PymtSchedId FROM MA_PyblsRcvbls t left JOIN MA_PyblsRcvblsDetails d ON t.PymtSchedId = d.PymtSchedId WHERE  t.Settled = '0' OR d.OpeningDate>='20230331' ) "
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvbls", .ModificaTutti = True, .WhereClause = wp, .PrimaryKey = "PymtSchedId", .GeneraListaPKIds = True, .TabelleDipendenti = New List(Of String) From {"MA_PyblsRcvbls", "MA_PyblsRcvblsDetails"}, .Gruppo = MacroGruppo.Partite})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_PyblsRcvblsDetails", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "PymtSchedId", .Gruppo = MacroGruppo.Partite})
#End Region
#Region "Parcelle"
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_Fees", .ModificaTutti = True, .WhereClause = " WHERE ( MA_Fees.PaymentDate = '17991231' Or MA_Fees.PaymentDate >= '20230101') ", .PrimaryKey = "FeeId", .GeneraListaPKIds = True, .TabelleDipendenti = New List(Of String) From {"MA_Fees", "MA_FeesDetails"}, .Gruppo = MacroGruppo.Parcelle})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_FeesDetails", .ModificaTutti = True, .HaListaPKIds = True, .PrimaryKey = "FeeId", .Gruppo = MacroGruppo.Parcelle})
#End Region
#Region "NON SI PUO' -- Movimenti di Magazzino"
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_InventoryEntries", .Gruppo = MacroGruppo.Magazzino})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_InventoryEntriesDetail", .Gruppo = MacroGruppo.Magazzino})
        ''tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_InventoryEntriesMA_InventoryEntriesReference", .Gruppo = MacroGruppo.Magazzino})
#End Region
#Region "Cross Reference"
        Dim cr As New AccoppiamentiCrossReference
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.OrdCli_NdC.WhereClause, .Coppia_CR = cr.OrdCli_NdC, .FriendName = "OrdCli_NdC", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.OrdCli_FatImmm.WhereClause, .Coppia_CR = cr.OrdCli_FatImmm, .FriendName = "OrdCli_FatImmm", .Gruppo = MacroGruppo.CrossRef})
        Dim wCr As String = " AND OriginDocId >= (Select PurchaseOrdId FROM MA_PurchaseOrd WHERE OrderDate >= '20220101') "
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.OrdFor_BdC.WhereClause, .AdditionalWhere = wCr, .Coppia_CR = cr.OrdFor_BdC, .FriendName = "OrdFor_BdC", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.DDT_FatImm.WhereClause, .Coppia_CR = cr.DDT_FatImm, .FriendName = "DDT_FatImm", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.FatImm_NdC.WhereClause, .Coppia_CR = cr.FatImm_NdC, .FriendName = "FatImm_NdC", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.FatImm_FatImm.WhereClause, .Coppia_CR = cr.FatImm_FatImm, .FriendName = "FatImm_FatImm", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.NdC_OrdCli.WhereClause, .Coppia_CR = cr.NdC_OrdCli, .FriendName = "NdC_OrdCli", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.BdC_ResFor.WhereClause, .Coppia_CR = cr.BdC_ResFor, .FriendName = "BdC_ResFor", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.BdC_FatImm.WhereClause, .Coppia_CR = cr.BdC_FatImm, .FriendName = "BdC_FatImm", .Gruppo = MacroGruppo.CrossRef})
        tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.BdC_NdCRic.WhereClause, .Coppia_CR = cr.BdC_NdCRic, .FriendName = "BdC_NdCRic", .Gruppo = MacroGruppo.CrossRef})
        'Spostate nello step partitario
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.FatImm_ParCli.WhereClause, .Coppia_CR = cr.FatImm_ParCli, .FriendName = "FatImm_ParCli", .Gruppo = MacroGruppo.CrossRef})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.ParFor_NdCRic.WhereClause, .Coppia_CR = cr.ParFor_NdCRic, .FriendName = "ParFor_NdCRic", .Gruppo = MacroGruppo.CrossRef})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.ParCli_NdC.WhereClause, .Coppia_CR = cr.ParCli_NdC, .FriendName = "ParCli_NdC", .Gruppo = MacroGruppo.CrossRef})
        'tabelle.Add(New TabelleDaEstrarre With {.Nome = "MA_CrossReferences", .WhereClause = cr.Parc_ParFor.WhereClause, .Coppia_CR = cr.Parc_ParFor, .FriendName = "Parc_ParFor", .Gruppo = MacroGruppo.CrossRef})
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
#Region "Da Mago -Magazzino : Depositi"
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_Storages"})
        'tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_StorageGroups"})
#End Region
#Region "Agenti"
        tabelleNoEdit.Add(New TabelleDaEstrarre With {.Nome = "MA_SalesPeople", .HaListaEsclusi = True, .NotInPK = "Salesperson", .Gruppo = MacroGruppo.Agenti})
#End Region
#End Region
        Return True
    End Function

    Friend Function ScriviIds(ByVal dv As DataView) As Boolean
        Try
            SqlConnection.ClearAllPools()
            Using destConn As New SqlConnection With {.ConnectionString = GetConnectionStringSPA()}
                destConn.Open()
                'Vendite
                Dim found As Integer = dv.Find("SaleDocId")
                Dim SaleDocId As Integer = CInt(dv(found)("NewKey"))
                Dim lastId As Integer = dtNewIds(dvNewIds.Find(IdType.DocVend)).Item("LastId")
                AggiornaIDs(IdType.DocVend, lastId + SaleDocId, destConn)
                'Acquisti
                found = dv.Find("PurchaseDocId")
                Dim PurchaseDocId As Integer = CInt(dv(found)("NewKey"))
                lastId = dtNewIds(dvNewIds.Find(IdType.DocAcq)).Item("LastId")
                AggiornaIDs(IdType.DocAcq, lastId + PurchaseDocId, destConn)
                'Ordini Clienti
                found = dv.Find("SaleOrdId")
                Dim SaleOrdId = CInt(dv(found)("NewKey"))
                lastId = dtNewIds(dvNewIds.Find(IdType.OrdCli)).Item("LastId")
                AggiornaIDs(IdType.OrdCli, lastId + SaleOrdId, destConn)
                'Ordini Fornitori
                found = dv.Find("PurchaseOrdId")
                Dim PurchaseOrdId = CInt(dv(found)("NewKey"))
                lastId = dtNewIds(dvNewIds.Find(IdType.OrdFor)).Item("LastId")
                AggiornaIDs(IdType.OrdFor, lastId + PurchaseOrdId, destConn)
                'Dichiarazione di intento 
                'found = dv.Find("DeclId")
                'Dim DeclId As Integer = CInt(dv(found)("NewKey"))
                'lastId = dtNewIds(dvNewIds.Find(IdType.DicIntento)).Item("LastId")
                'AggiornaIDs(IdType.DicIntento, lastId + DeclId)
                'Partite
                found = dv.Find("PymtSchedId")
                Dim PymtId As Integer = CInt(dv(found)("NewKey"))
                lastId = dtNewIds(dvNewIds.Find(IdType.Partite)).Item("LastId")
                AggiornaIDs(IdType.Partite, lastId + PymtId, destConn)
            End Using
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
    Private Sub AggiornaIDs(ByVal IdType As Integer, ByVal value As Integer, ByRef con As SqlConnection)
        Dim r As String = ReturnVarName(IdType, GetType(MagoNet.IdType))
        Try
            If con.State = ConnectionState.Open Then
                Using cmd = New SqlCommand("UPDATE MA_IDNumbers SET LastId =" & value.ToString & " WHERE CodeType=@CodeType",
                         con)
                    cmd.CommandTimeout = 0
                    cmd.Parameters.AddWithValue("@CodeType", IdType)
                    ScriviLog(cmd.CommandText)
                    Dim irows As Integer = cmd.ExecuteNonQuery()
                    If irows <= 0 Then
                        cmd.CommandText = "INSERT INTO MA_IDNumbers (CodeType, LastId, TBCreatedID, TBModifiedID) VALUES (@CodeType, @Value, @TBCreatedID ,@TBModifiedID )"
                        cmd.Parameters.AddWithValue("@Value", value)
                        cmd.Parameters.AddWithValue("@TBCreatedID", My.Settings.mLOGINID)
                        cmd.Parameters.AddWithValue("@TBModifiedID", My.Settings.mLOGINID)
                        irows = cmd.ExecuteNonQuery()
                    End If
                End Using
            End If

            ScriviLog("Ultimo ID scritto: " & value.ToString & " su tipo: " & r)
        Catch ex As Exception
            ScriviLog("#Errore# in AggiornaID(IdType=" & r & "): " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Esegue preparazione e BULK INSERT SQL nel database di destinazione usando un SQLDatareader 
    ''' </summary>
    ''' <returns></returns>
    Friend Function ScriviDatiSql(t As TabelleDaEstrarre, ByVal commit As Boolean) As Boolean
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
                    Using destCommRowCount = New SqlCommand("Select COUNT(1) FROM " & t.Nome, destConn)
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
                                    'provo con column mapping = false
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
                    Using destCommRowCount = New SqlCommand("Select COUNT(1) FROM " & t.Nome, destConn)
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
