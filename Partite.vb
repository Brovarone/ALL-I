Imports System.Data.SqlClient
Imports System.Text

Module Partite
    Private Const Causale As String = "APE"
    Private isDiff As Boolean
    'Se ho un differenziale leggo tutto il file Excel e inserisco SOLO quelle che non trovo già su mago 
    'confrontanto il NUMOV+RIMOV con il campo Notes della tabella Partite
    'successivamente devo fare lo stesso ragionamento partendo dalla partita e 
    'Provo a creare una colonna MIA e filtrare poi su quella.

    Public Function PartiteXLS(ByVal dts As DataSet, TipoCliFor As String, Optional ByVal bConIntestazione As Boolean = False) As Boolean
        'QUANDO PASSO UN DOUBLE DEVO FARE ATTENZIONE
        'Testa Partite - MA_PyblsRcvbls
        'In "Notes" importo il numero movimento : Colonna Y : NUMOV0
        'description, notes, ADVANCE (ACCONTO), Area?
        'Righe - MA_PyblsRcvblsDetails

        Dim result As StringBuilder = New StringBuilder()
        Dim okBulk As Boolean
        Dim incongruenze As StringBuilder = New StringBuilder()
        Dim NUMOV As String = ""
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        isDiff = If(TipoCliFor = "Fornitore", FLogin.ChkDifferenzialeFornitori.Checked, FLogin.ChkDifferenzialeCliente.Checked)
        Dim cliForType As Integer = If(TipoCliFor = "Fornitore", CustSuppType.Fornitore, CustSuppType.Cliente)
        EditTestoBarra("Creo Partite " & TipoCliFor)
        FLogin.prgCopy.Value = 1
        'Inizializzo un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables(0)
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Length > 0 Then
            'Identificatore  Documento
            Debug.Print("Estraggo ID")
            EditTestoBarra("Estraggo gli ID")
            Dim idPartita As Integer = LeggiID(IdType.Partite)
            FLogin.prgCopy.Maximum = drXLS.Length
            FLogin.prgCopy.Step = 1

            Dim iNrCliFor As Integer 'usato per contare i Clienti ( non che serva a granche' )
            Dim iNrPartita As Integer 'usato per contare le partite/rate
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                'Se devi eseguire il differenziale mi carico anche i dati
                EditTestoBarra("Carico Schema: Partite")
                Dim sQry As String = "SELECT * FROM MA_PyblsRcvbls WHERE  CustSuppType=" & cliForType
                Using dtPartita As DataTable = CaricaSchema("MA_PyblsRcvbls", True, isDiff, sQry)
                    If isDiff Then
                        Dim newC As DataColumn = New DataColumn With {
                            .ColumnName = "DACANC",
                            .Caption = "DACANC",
                            .DataType = GetType(String),
                            .MaxLength = 2,
                            .DefaultValue = "SI"
                            }
                        dtPartita.Columns.Add(newC)
                    End If
                    Dim dvPartita As DataView = New DataView(dtPartita, "", "Notes", DataViewRowState.CurrentRows)
                    EditTestoBarra("Carico Schema: Righe")
                    sQry = "SELECT * FROM MA_PyblsRcvblsDetails WHERE CustSuppType=" & cliForType
                    Using dtDettPartita As DataTable = CaricaSchema("MA_PyblsRcvblsDetails", True, isDiff, sQry)
                        Dim dvDettPartite As DataView = New DataView(dtDettPartita, "", "PymtSchedId", DataViewRowState.CurrentRows)
                        EditTestoBarra("Scrittura partite")
                        Dim stopwatch1 As New System.Diagnostics.Stopwatch
                        stopwatch1.Start()
                        ' Ciclo le righe del file XLS
                        'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                        Dim irxls As Integer = 0
                        Dim i As Integer = 0
                        Dim bIsFirstRow As Boolean = False
                        Dim bIsFirts20 As Boolean = True
                        Dim bExist25 As Boolean = False
                        Dim iParFound As Integer
                        Dim bNewPartita As Boolean = False
                        If bConIntestazione Then i = 1 ' Se c'e' l'intestazione parto dalla seconda riga

                        'La tabella xls e' strutturata 
                        'TIPOR0 Colonna A= 10 = Testata 20=Registrazione 25=Scadenza ...
                        ' Colonna
                        Dim drAppoggio As DataRow = drXLS(irxls)
                        Dim drPar As DataRow = dtPartita.NewRow
                        Dim drParDet As DataRow = dtDettPartita.NewRow

                        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT Payment, ACGCode FROM MA_PaymentTerms", Connection)
                        'per le condizioni di pagamento 
                        Dim dtCP As DataTable = New DataTable("CondPag")
                        da.Fill(dtCP)
                        Dim dvCP As DataView = New DataView(dtCP, "", "ACGCode", DataViewRowState.CurrentRows)

                        'popolo un Datatable con la tabella di transcodifica
                        'Dim dtCondPag As DataTable = dts.Tables("transcode")
                        'creo la dataview associata per le ricerche
                        Dim dvTranscode As DataView = New DataView(dts.Tables("transcode"), "", "A", DataViewRowState.CurrentRows)
                        For irxls = i To drXLS.Length - 1
                            ' accorcio per comodità di scrittura
                            With drXLS(irxls)
                                'Inizializzo la nuova riga solo se sono sulla prima
                                'Altrimenti continuo a leggere le righe
                                If bIsFirstRow Then
                                    bIsFirstRow = False
                                    drPar = dtPartita.NewRow
                                    drParDet = dtDettPartita.NewRow
                                    bIsFirts20 = True
                                End If
                                Select Case .Item("A").ToString
                                    Case "10" ' Nuovo cliente/fornitore
                                        iNrCliFor += 1
                                    Case "20"
                                        If bIsFirts20 Then
                                            'Ce ne sono diverse a me serve solo la prima di ogni partita
                                            bIsFirts20 = False
                                            NUMOV = .Item("Y").ToString() & "-" & .Item("Z").ToString
                                            'Cerco se esiste
                                            If isDiff Then
                                                iParFound = dvPartita.Find(NUMOV)
                                                bNewPartita = iParFound = -1
                                                If iParFound <> -1 Then
                                                    Dim k As String = dvPartita(iParFound).Item("PymtSchedId")
                                                    dvDettPartite.RowFilter = "PymtSchedId=" & k
                                                    dvPartita(iParFound).BeginEdit()
                                                    dvPartita(iParFound)("DACANC") = "NO"
                                                    dvPartita(iParFound).EndEdit()
                                                End If
                                            Else
                                                bNewPartita = True
                                            End If

                                            If bNewPartita Then
                                                'inizia una nuova partita
                                                idPartita += 1 ' Incremento Id
                                                'Mi salvo la riga per usarla nel caso di assenza di riga25
                                                If Not IsNothing(drAppoggio) Then drAppoggio.Delete()
                                                drAppoggio = drXLS(irxls)
                                                Debug.Print(TipoCliFor & ": " & .Item("I").ToString & " fatt/prot ('AD'): " & .Item("AD").ToString)
                                                'prendo le informazioni di fattura
                                                drPar("InstallmStartDate") = MagoFormatta(.Item("AF").ToString, GetType(DateTime)).DataTempo
                                                drPar("DocNo") = .Item("S").ToString()
                                                drPar("LogNo") = .Item("AD").ToString() 'Protocollo
                                                drPar("Notes") = NUMOV 'NUMOV + RIMOV0
                                                drPar("DocumentDate") = MagoFormatta(.Item("AF").ToString, GetType(DateTime)).DataTempo
                                                ' Leggo ora la condizione di pagamento in quanto il dataset qui' e' disponibile
                                                Dim iPag As Integer = dvTranscode.Find(.Item("Y").ToString) 'NUMOV
                                                Dim condPag As String = If(iPag >= 0, dvTranscode(iPag).Item("B"), "")
                                                'Converto questo valore in quello di mago
                                                If Not String.IsNullOrWhiteSpace(condPag) Then
                                                    Select Case condPag
                                                        Case "100"
                                                            drPar("Payment") = "BDF3"
                                                        Case "217"
                                                            drPar("Payment") = "BFM12+12"
                                                        Case "X03"
                                                            drPar("Payment") = "RID30+5"
                                                        Case "Y11"
                                                            drPar("Payment") = "RBFM6"
                                                        Case "Y16"
                                                            drPar("Payment") = "RBFM9"
                                                        Case "Y19"
                                                            drPar("Payment") = "RBFM12"
                                                        Case Else
                                                            Dim iCP As Integer = dvCP.Find(condPag)
                                                            If iCP >= 0 Then
                                                                drPar("Payment") = dvCP.Item(iCP).Item("Payment").ToString
                                                            Else
                                                                drPar("Payment") = condPag
                                                                result.AppendLine("Partita su fattura: " & .Item("S").ToString & " fatt/prot ('AD'): " & .Item("AD").ToString & " Pagamento non trovato: " & condPag & " Codice: " & .Item("I").ToString)
                                                            End If
                                                    End Select
                                                Else
                                                    drPar("Payment") = "RDRICFT"
                                                    result.AppendLine("Pagamento assente su fattura: " & .Item("S").ToString & " fatt/prot ('AD'): " & .Item("AD").ToString & " Codice: " & .Item("I").ToString & " Inserito : RDRICFT")
                                                End If
                                                If isDiff Then drPar("DACANC") = "XX"
                                                drPar("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                drPar("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                            End If
                                        End If
                                    Case "25"
                                        If bNewPartita Then
                                            ' SERVE SOLO PER DATA SCADENZA E TIPO RATA
                                            bExist25 = True
                                            If Not String.IsNullOrWhiteSpace(.Item("BV").ToString) AndAlso .Item("BV").ToString = "B" Then drPar("Blocked") = "1"
                                            Popola25Det(drParDet, drXLS(irxls))
                                        End If
                                    Case "30"
                                        'Saldo Partita
                                        ' quello letto nella prima riga 20
                                        'Nella riga 30 manca BU=tiporata , AF=DataFattura/Apertura AI=DataScadenza
                                        If bNewPartita Then
                                            If Not bExist25 Then Popola25Det(drParDet, drAppoggio)
                                            Popola30Testa(drPar, drXLS(irxls), idPartita)
                                            Popola30Det(drParDet, drXLS(irxls), idPartita)
                                            iNrPartita += 1
                                            Debug.Print("aggiungo fatt:" & drPar.Item("DocNo").ToString)
                                            dtPartita.Rows.Add(drPar)
                                            dtDettPartita.Rows.Add(drParDet)
                                        ElseIf isDiff Then
                                            Dim isDare As Boolean = Double.Parse(.Item("AN").ToString) > 0.001
                                            Dim sAmount As String = If(isDare, .Item("AN").ToString, Mid(.Item("AN").ToString, 2))
                                            If dvDettPartite(0)("DebitCreditSign") <> If(isDare, 4980736, 4980737).ToString Then
                                                incongruenze.AppendLine("Partita con segno diverso. Numov/Notes:" & NUMOV & " Mago: " & If(dvDettPartite(0)("DebitCreditSign").ToString = "4980736", "Dare", "Avere") & " File Excel: " & If(isDare, "Dare", "Avere").ToString)
                                                Debug.Print("Partita con segno diverso. Numov/Notes:" & NUMOV & " Mago: " & If(dvDettPartite(0)("DebitCreditSign").ToString = "4980736", "Dare", "Avere") & " " & dvDettPartite(0)("Amount").ToString & " File Excel: " & If(isDare, "Dare", "Avere").ToString & sAmount)
                                            End If
                                            If dvDettPartite(0)("Amount") <> sAmount Then
                                                incongruenze.AppendLine("Partita con importo diverso. Numov/Notes:" & NUMOV & " Mago: " & dvDettPartite(0)("Amount").ToString & " File Excel: " & sAmount)
                                                Debug.Print("Partita con importo diverso. Numov/Notes:" & NUMOV & " Mago:" & dvDettPartite(0)("Amount").ToString & " File Excel:" & sAmount)
                                            End If
                                        End If
                                        'resetto i controlli
                                        bIsFirstRow = True
                                        bExist25 = False
                                        bNewPartita = False
                                    Case "42"
                                        '40= totale, 41= per partita, 42= consolidato (Boh?)

                                    Case "91"
                                        Debug.Print("Nr " & TipoCliFor & " (rigo 10): " & iNrCliFor.ToString)
                                        Debug.Print("Nr Partite (rigo 30): " & iNrPartita.ToString)
                                        Debug.Print("Totale Letto da rigo 91: " & .Item("AO").ToString)
                                    Case Else
                                        '90 = totali per divisa, 91 = totali 

                                End Select
                            End With
                            FLogin.prgCopy.PerformStep()
                            FLogin.prgCopy.Update()
                            Application.DoEvents()
                        Next
                        'Devo gestire quelle da cancellare
                        Dim ListofIDs As List(Of Integer) = New List(Of Integer)
                        If isDiff Then
                            dvPartita.RowFilter = "DACANC='SI'"
                            Debug.Print("Partite da cancellare :" & dvPartita.Count.ToString)
                            My.Application.Log.WriteEntry("Partite Flaggate :" & dvPartita.Count.ToString)
                            Dim fistGennaio As DateTime = New DateTime(2021, 1, 1)
                            For i = 0 To dvPartita.Count - 1
                                If TipoCliFor = "Fornitore" Then
                                    Debug.Print(dvPartita(i).Item("TBCreatedID").ToString & " idPartita=" & dvPartita(i).Item("PymtSchedId").ToString & " IdGiornale" & dvPartita(i).Item("JournalEntryId").ToString)
                                    If dvPartita(i).Item("TBCreatedID") = My.Settings.mLOGINID Then
                                        If dvPartita(i).Item("JournalEntryId") <> 0 Then
                                            My.Application.Log.WriteEntry("!!!! Partita da cancellare ma con JournalEntryId :" & dvPartita(i).Item("JournalEntryId").ToString)
                                        End If
                                        Debug.Print(TipoCliFor & ": " & dvPartita(i).Item("CustSupp").ToString & " cancellare fatt/prot ('AD'): " & dvPartita(i).Item("DocNo").ToString & ", IDPartita: " & dvPartita(i).Item("PymtSchedId").ToString)
                                        ListofIDs.Add(dvPartita(i).Item("PymtSchedId"))
                                    End If
                                Else
                                    If dvPartita(i).Item("DocumentDate") < fistGennaio Then
                                        Debug.Print(TipoCliFor & ": " & dvPartita(i).Item("CustSupp").ToString & " cancellare fatt/prot ('AD'): " & dvPartita(i).Item("DocNo").ToString & ", IDPartita: " & dvPartita(i).Item("PymtSchedId").ToString)
                                        ListofIDs.Add(dvPartita(i).Item("PymtSchedId"))
                                        'dvPartita(i).Row.Delete()
                                    End If
                                End If
                            Next
                            My.Application.Log.WriteEntry("Partite realmente da cancellare :" & ListofIDs.Count.ToString)

                            dvPartita.RowFilter = "DACANC='XX'"
                            Debug.Print("Partite da inserire :" & dvPartita.Count.ToString)
                            My.Application.Log.WriteEntry("Partite da inserire :" & dvPartita.Count.ToString)
                            'dvPartita.RowFilter = ""
                            'dvPartita.RowStateFilter = DataRowState.Added
                            dtPartita.Columns.Remove("DACANC")
                        End If
                        Debug.Print("Elaborazione partite: " & dtPartita.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                        My.Application.Log.WriteEntry(result.ToString)
                        My.Application.Log.WriteEntry(incongruenze.ToString)
                        'dvPartita.RowStateFilter = DataViewRowState.Added
                        EditTestoBarra("Salvataggio: Partite")

                        Using bulkTrans = Connection.BeginTransaction
                            okBulk = ScriviBulk("MA_PyblsRcvbls", dtPartita, bulkTrans, If(isDiff, DataRowState.Added, DataRowState.Unchanged))
                            EditTestoBarra("Salvataggio: Righe")
                            okBulk = ScriviBulk("MA_PyblsRcvblsDetails", dtDettPartita, bulkTrans, If(isDiff, DataRowState.Added, DataRowState.Unchanged))
                            bulkTrans.Commit()
                            If isDiff AndAlso ListofIDs.Count > 0 Then
                                Using cmdqry = New SqlCommand("delete from MA_PyblsRcvblsDetails where PymtSchedId=@ID", Connection)
                                    Using cmdqry2 = New SqlCommand("delete from MA_PyblsRcvbls where PymtSchedId=@ID2", Connection)
                                        cmdqry.CommandType = CommandType.Text
                                        cmdqry2.CommandType = CommandType.Text
                                        cmdqry.Parameters.Add("@ID", SqlDbType.Int)
                                        cmdqry2.Parameters.Add("@ID2", SqlDbType.Int)
                                        FLogin.prgCopy.Text = "Eliminazione partite chiuse"
                                        FLogin.prgCopy.Value = 1
                                        FLogin.prgCopy.Maximum = ListofIDs.Count
                                        FLogin.prgCopy.Step = 1
                                        For Each ID As Integer In ListofIDs
                                            cmdqry.Parameters("@ID").Value = ID
                                            cmdqry2.Parameters("@ID2").Value = ID
                                            cmdqry.ExecuteNonQuery()
                                            cmdqry2.ExecuteNonQuery()
                                            FLogin.prgCopy.PerformStep()
                                            FLogin.prgCopy.Update()
                                            Application.DoEvents()
                                        Next
                                    End Using
                                End Using
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                MessageBox.Show(ex.Message)
            End Try
            'Scrivi Gli ID ( faccio solo a fine elaborazione)
            AggiornaID(IdType.Partite, idPartita)

            Debug.Print("Gestione Partite" & " " & stopwatch.Elapsed.ToString)

            'Scrivo sul Database
            'PROCEDURA DEPRECATA USO BULK COPY
            'Dim cbMar = New SqlCommandBuilder(da)
            'da.InsertCommand = cbMar.GetInsertCommand(True)
            'da.UpdateCommand = cbMar.GetUpdateCommand(True)
            'da.Update(dtDoc)
        End If
        '    End Using
        ' End Using

        stopwatch.Stop()
        Return True

    End Function
    Private Sub Popola25Det(ByVal dr As DataRow, ByVal drOrigine As DataRow)
        With drOrigine
            '"AI" e' a ZERO sulla riga 30 verrà letto da drAppoggio
            Dim dataScad As String = If(.Item("AI").ToString = "0", .Item("AF").ToString, .Item("AI").ToString)
            dr("InstallmentDate") = MagoFormatta(dataScad, GetType(DateTime)).DataTempo
            '"AF" e' a ZERO sulla riga con (tiporata/TIPRT0) "BU" = RD/Rid
            'Non sono diverse ?!
            'Dim dataApertura As String = If(.Item("AF").ToString = "0", .Item("AI").ToString, .Item("AF").ToString)
            'dr("OpeningDate") = MagoFormatta(dataApertura, GetType(DateTime)).DataTempo
            dr("OpeningDate") = MagoFormatta(dataScad, GetType(DateTime)).DataTempo
            Dim paymTerm As Integer
            Select Case .Item("BU").ToString
                'Assente in riga 30 verrà messo rimessa diretta
                Case "C1"
                    paymTerm = PaymentTerm.Contante
                    dr("AtSight") = "1"
                'Case "C2"
                Case "C3"
                    paymTerm = PaymentTerm.Bonifico
                    dr("AtSight") = "0"
                Case "C4" 'c/c postale
                    paymTerm = PaymentTerm.BollettinoPostale
                    dr("AtSight") = "0"
                Case "RB"
                    paymTerm = PaymentTerm.RicevutaBancaria
                    dr("AtSight") = "0"
                Case "RD"
                    paymTerm = PaymentTerm.RID_SEPA_SDD_CORE
                    dr("AtSight") = "0"
                Case Else
                    paymTerm = PaymentTerm.RimessaDiretta
                    dr("AtSight") = "1"
            End Select
            dr("PaymentTerm") = paymTerm
            Dim sbanca As String = .Item("BX").ToString & "-" & .Item("BY").ToString
            dr("CustSuppBank") = If(sbanca = "-", "", sbanca)
            If Not String.IsNullOrWhiteSpace(.Item("BV").ToString) AndAlso .Item("BV").ToString = "B" Then dr("Blocked") = "1"
        End With
    End Sub

    Private Sub Popola30Testa(ByVal dr As DataRow, ByVal drOrigine As DataRow, idPartita As Integer)
        ' Colonna W FSCAD ES o SC ?? Sono usati per e riba e i RID ma non li considero
        With drOrigine
            dr("CustSupptype") = If(.Item("E").ToString = "C", CustSuppType.Cliente, CustSuppType.Fornitore) ' 3211264 = Cliente
            dr("CustSupp") = .Item("I").ToString
            'dr("TaxAmount") = .Item("").ToString
            Dim isDare As Boolean = Double.Parse(.Item("AN").ToString) > 0.001
            If .Item("E").ToString = "C" Then
                dr("CreditNote") = If(isDare, "0", "1") '0 Fattura in Dare / 1 NdC in Avere
            Else
                dr("CreditNote") = If(isDare, "1", "0") '0 Fattura in Avere / 1 NdC in Dare
            End If
            Dim sAmount As String = If(isDare, .Item("AN").ToString, Mid(.Item("AN").ToString, 2))
            dr("TotalAmount") = sAmount
            'dr("SalesPerson") = .Item("T").ToString
            dr("Area") = .Item("T").ToString
            dr("PymtSchedId") = idPartita
            dr("Currency") = If(.Item("AM").ToString = "EURO", "EUR", .Item("AM").ToString)
            'dr("SendDocumentTo") = .Item("").ToString
            'dr("ContractCode") = .Item("").ToString 'CIG
            'dr("ProjectCode") = .Item("").ToString 'CUP
            'Recupero da CSV di appoggio condizione di pagamento
            'dr("Payment") = .Item("BU").ToString

        End With

    End Sub
    Private Sub Popola30Det(ByVal dr As DataRow, ByVal drOrigine As DataRow, idPartita As Integer)
        With drOrigine
            dr("PymtSchedId") = idPartita
            dr("CustSupptype") = If(.Item("E").ToString = "C", CustSuppType.Cliente, CustSuppType.Fornitore) ' 3211264 = Cliente
            dr("CustSupp") = .Item("I").ToString
            'dr("SalesPerson") = .Item("T").ToString
            dr("Area") = .Item("T").ToString
            dr("InstallmentNo") = 1
            dr("InstallmentType") = 5505024 'Apertura
            dr("ClosingType") = 6946816 'Normale
            dr("Presentation") = 1376260
            dr("Currency") = If(.Item("AM").ToString = "EURO", "EUR", .Item("AM").ToString)
            Dim isDare As Boolean = Double.Parse(.Item("AN").ToString) > 0.001
            Dim sAmount As String = If(isDare, .Item("AN").ToString, Mid(.Item("AN").ToString, 2))
            dr("Amount") = sAmount
            dr("PayableAmountInBaseCurr") = sAmount
            'dr("DebitCreditSign") = IF(.Item("E").ToString = "C", 4980736, 4980737) 'Dare
            dr("DebitCreditSign") = If(isDare, 4980736, 4980737) 'Dare
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
        End With

    End Sub

    Public Function CreaAperturaDaPartite(ByVal TipoClifor As Integer) As Boolean
        'Movimenti Contabili PURI - MA_JournalEntries
        'Righe - MA_JournalEntriesGLDetail
        Dim okBulk As Boolean

        Dim dtPartite As DataTable = New DataTable
        'Creo una vista con le righe delle partite che mi servono e poi le ciclo creando la scrittura di apertura
        Dim sqry As String = "SELECT T.PymtSchedId, T.CustSuppType, T.CustSupp, Left(T.CustSupp,1) as Filiale, C.Account, T.DocNo , T.LogNo, T.DocumentDate, T.TotalAmount,  D.DebitCreditSign, D.Amount " &
                            "FROM MA_PyblsRcvblsDetails AS D  JOIN MA_PyblsRcvbls AS T ON d.PymtSchedId = t.PymtSchedId JOIN MA_CustSupp AS C ON T.CustSuppType = C.CustSuppType AND T.CustSupp = C.CustSupp " &
                            "WHERE T.CustSuppType=" & TipoClifor & " And D.InstallmentType=5505024 And t.TBCreatedID=" & My.Settings.mLOGINID
        Using da As SqlDataAdapter = New SqlDataAdapter(sqry, Connection)
            da.Fill(dtPartite)
            Dim dvPartite As DataView = New DataView(dtPartite, "", "CustSupp", DataViewRowState.CurrentRows)

            'Identificatore Prima Nota
            Dim idPn As Integer = LeggiID(IdType.PNota)
            Dim iRefNo As Integer = LeggiNonFiscalNumber(CodeType.PNota, 2020)

            If dvPartite.Count > 0 Then
                Try
                    Dim bilApe As String = "5STP"
                    Dim quadratura As Double
                    Dim totDare As Double
                    Dim totAvere As Double
                    Dim isNewReg As Boolean = True
                    Dim iV As Integer = 0
                    Dim i As Byte = 0
                    Dim ireg As Integer = 0
                    Dim iLine As Integer ' Contatore delle righe
                    Dim d3112 As Date = MagoFormatta("20201231", GetType(DateTime)).DataTempo
                    Using dtPN As DataTable = CaricaSchema("MA_JournalEntries", True)
                        Using dtPND As DataTable = CaricaSchema("MA_JournalEntriesGLDetail", True)

                            Dim drPn As DataRow = dtPN.NewRow
                            Dim drPnD As DataRow = dtPND.NewRow
                            'Campo Filiale che sto elaborando, serve per cambiare movimento/registrazione
                            Dim filToReg As String = "" ' = dvPartite(i).Item("Filiale")
                            For iV = i To dvPartite.Count - 1
                                With dvPartite(iV)
                                    iLine += 1
                                    'Controllo la filiale e se diversa chiudo la registrazione, 
                                    'quadro a bilancio di apertura e creo nuovo movimento
                                    If iLine = 100 OrElse filToReg <> .Item("Filiale") Then
                                        If Not isNewReg Then
                                            'Aggiorno la testa con quello che ho calcolato
                                            drPn("TotalAmount") = If(totDare > totAvere, totDare, totAvere)
                                            drPn("LastSubId") = iLine
                                            dtPN.Rows.Add(drPn)
                                            'Creo quella nuova per quadrare
                                            drPnD = dtPND.NewRow
                                            drPnD("JournalEntryId") = idPn
                                            drPnD("Line") = iLine
                                            drPnD("PostingDate") = d3112
                                            drPnD("AccrualDate") = d3112
                                            drPnD("AccRsn") = "BIA"
                                            drPnD("Account") = bilApe
                                            'drPnD("CustSupptype") = .Item("CustSupptype")
                                            'drPnD("CustSupp") = ""
                                            drPnD("DebitCreditSign") = If(quadratura > 0.001, 4980737, 4980736) 'T= Dare 4980736 / Avere 4980737
                                            drPnD("Amount") = Math.Abs(Math.Round(quadratura, 2))
                                            drPnD("FiscalAmount") = Math.Abs(Math.Round(quadratura, 2))
                                            drPnD("Currency") = "EUR"
                                            drPnD("ValueDate") = d3112
                                            drPnD("SubId") = iLine
                                            drPnD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                            drPnD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                            dtPND.Rows.Add(drPnD)
                                            isNewReg = True
                                        End If
                                        'resetto e rivalorizzo
                                        If filToReg <> .Item("Filiale") Then ireg = 0
                                        filToReg = .Item("Filiale")
                                        quadratura = 0
                                        totDare = 0
                                        totAvere = 0
                                        iLine = 1

                                    End If
                                    If isNewReg Then
                                        'Creo la testa della registrazione
                                        drPn = dtPN.NewRow
                                        idPn += 1
                                        iRefNo += 1
                                        ireg += 1
                                        isNewReg = False
                                        drPn("AccTpl") = Causale
                                        drPn("PostingDate") = d3112
                                        drPn("RefNo") = "20-" & iRefNo.ToString("00000")
                                        drPn("DocumentDate") = d3112
                                        drPn("DocNo") = filToReg & ireg.ToString
                                        'drPN( "TotalAmount", .Item("K").ToString)
                                        drPn("JournalEntryId") = idPn
                                        drPn("AccrualDate") = d3112
                                        ''AddF(Of Integer)(cmd, sInsert, "CodeType", .Item("O").ToString) ' Normale / Apertura / Assestamento
                                        drPn("Currency") = "EUR"
                                        drPn("ValueDate") = d3112
                                        drPn("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                        drPn("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                    End If

                                    ''''''''''''''''''''''
                                    'Righe MA_JournalEntriesGLDetail
                                    ''''''''''''''''''''''
                                    drPnD = dtPND.NewRow
                                    drPnD("JournalEntryId") = idPn
                                    drPnD("Line") = iLine
                                    drPnD("PostingDate") = d3112
                                    drPnD("AccrualDate") = d3112
                                    drPnD("AccRsn") = "BIA"
                                    Dim docdata As String = Left(.Item("DocumentDate").ToString, 10)
                                    Dim nota As String = "Doc. nr. " & .Item("DocNo") & " prot. " & .Item("LogNo") & " del " & docdata
                                    drPnD("Notes") = nota
                                    'drPnD ("CodeType")= 5177344 ' Normale / Apertura / Assestamento
                                    drPnD("Account") = .Item("Account").ToString
                                    If String.IsNullOrWhiteSpace(.Item("Account").ToString) Then
                                        Debug.Print("Conto non presente su " & TipoClifor & " : " & .Item("CustSupp").ToString)
                                        My.Application.Log.WriteEntry("Conto non presente su " & TipoClifor & " : " & .Item("CustSupp").ToString)
                                    End If
                                    'drPnD("AmountType") = 6356992 ' usato su FR e FE  ( imponibile, imposta, totale)
                                    drPnD("CustSupptype") = .Item("CustSupptype")
                                    drPnD("CustSupp") = .Item("CustSupp").ToString
                                    drPnD("DebitCreditSign") = .Item("DebitCreditSign")
                                    Dim imp As Double = Math.Round(.Item("Amount"), 2)
                                    drPnD("Amount") = imp
                                    drPnD("FiscalAmount") = imp
                                    quadratura += If(.Item("DebitCreditSign") = 4980736, imp, -imp)
                                    If .Item("DebitCreditSign") = 4980736 Then
                                        totDare += imp
                                    Else
                                        totAvere += imp
                                    End If
                                    drPnD("Currency") = "EUR"
                                    drPnD("ValueDate") = d3112
                                    drPnD("SubId") = iLine
                                    drPnD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                    drPnD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                    dtPND.Rows.Add(drPnD)
                                End With

                            Next
                            'Inserisco le ultime righe nella tabelle
                            drPn("TotalAmount") = If(totDare > totAvere, totDare, totAvere)
                            drPn("LastSubId") = iLine + 1
                            dtPN.Rows.Add(drPn)
                            'Creo quella nuova per quadrare
                            drPnD = dtPND.NewRow
                            drPnD("JournalEntryId") = idPn
                            drPnD("Line") = iLine + 1
                            drPnD("PostingDate") = d3112
                            drPnD("AccrualDate") = d3112
                            drPnD("AccRsn") = "BIA"
                            drPnD("Account") = bilApe
                            'drPnD("CustSupptype") = .Item("CustSupptype")
                            'drPnD("CustSupp") = ""
                            drPnD("DebitCreditSign") = If(quadratura > 0.001, 4980737, 4980736) 'T= Dare 4980736 / Avere 4980737
                            drPnD("Amount") = Math.Abs(Math.Round(quadratura, 2))
                            drPnD("FiscalAmount") = Math.Abs(Math.Round(quadratura, 2))
                            drPnD("Currency") = "EUR"
                            drPnD("ValueDate") = d3112
                            drPnD("SubId") = iLine + 1
                            drPnD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                            drPnD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                            dtPND.Rows.Add(drPnD)

                            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                cmdqry.ExecuteNonQuery()
                                Using bulkTrans = Connection.BeginTransaction
                                    EditTestoBarra("Salvataggio: Prima Nota")
                                    okBulk = ScriviBulk("MA_JournalEntries", dtPN, bulkTrans)
                                    EditTestoBarra("Salvataggio: Righe")
                                    okBulk = ScriviBulk("MA_JournalEntriesGLDetail", dtPND, bulkTrans)
                                    bulkTrans.Commit()
                                End Using
                                cmdqry.CommandText = "DBCC TRACEOFF(610)"
                                cmdqry.ExecuteNonQuery()
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    Debug.Print(ex.Message)

                End Try
                'Scrivi Gli ID ( faccio solo a fine elaborazione)
                AggiornaID(IdType.PNota, idPn)
                AggiornaNonFiscalNumber(3735558, 2020, iRefNo)

            End If
        End Using
        Return okBulk

    End Function

End Module
