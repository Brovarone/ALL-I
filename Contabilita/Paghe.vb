Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports ALLSystemTools.SqlTools.Bulk
Public Module Paghe
    Private dtTeste As DataTable
    Private dtRighe As DataTable
    Private dtTranscode As DataTable
    Private Const ContoTransitorioMAGO = "2DIP999"
    Private Const ModCont = "PAGHE"
    Private Const CauRiga = "PAGHE"
    Private Const ContoTransitorioACG = "20890101"

    Private contoTransitorio As String

    Public Function CaricaFlussoPaghe(ByVal refPath As String, ByVal IsMago As Boolean) As Boolean
        Dim result As Boolean

        InizializzaMascheraMatching()
        Using rdr As New StreamReader(refPath)
            Dim currentLine As String = rdr.ReadLine()
            While currentLine IsNot Nothing
                Dim currentRow As String()
                'Debug.Print(currentLine)
                If Not String.IsNullOrWhiteSpace(currentLine) Then
                    If String.IsNullOrWhiteSpace(Left(currentLine, 6)) Then
                        currentRow = Testata(currentLine)
                        currentRow = currentRow.Append(TranscodeCdc(currentRow(9))).ToArray
                        dtTeste.Rows.Add(currentRow)
                    Else
                        currentRow = Riga(currentLine)
                        currentRow = currentRow.Append(TranscodeCdc(currentRow(1))).ToArray
                        dtRighe.Rows.Add(currentRow)
                    End If

                    If currentRow IsNot Nothing Then
                        'Process current set of fields
                    End If
                End If
                currentLine = rdr.ReadLine()
            End While
        End Using
        'FLogin.DataGridView1.DataSource = dtRighe
        contoTransitorio = If(IsMago, ContoTransitorioMAGO, ContoTransitorioACG)
        result = CreaPNotaPaghe(dtTeste, dtRighe)
        Return result
    End Function

    ''' <summary>
    ''' Questo Metodo utilizza un TextFieldParser per processare una singola riga del file che le viene passata
    ''' </summary>
    ''' <param name="currentLine"></param>
    ''' <returns></returns>
    Private Function Testata(currentLine As String) As String()
        Dim result As String() = Array.Empty(Of String)()
        Using strStream = New StringReader(currentLine)
            Using MyReader As New TextFieldParser(strStream)
                MyReader.TextFieldType = FieldType.FixedWidth
                'Tracciato Carbone
                MyReader.FieldWidths = {6, 6, 16, 3, 12, 2, 33, 6, 39, 2, 49, 7, 30, 8, 6, 6, 2}
                Try
                    result = MyReader.ReadFields()
                    'Dim currentField As String
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End Using
        End Using

        Return result
    End Function
    ''' <summary>
    ''' Questo Metodo utilizza un TextFieldParser per processare una singola riga del file che le viene passata
    ''' </summary>
    ''' <param name="currentLine"></param>
    ''' <returns></returns>
    Private Function Riga(currentLine As String) As String()
        Dim result As String() = Array.Empty(Of String)()
        Using strStream = New StringReader(currentLine)
            Using MyReader As New TextFieldParser(strStream)
                MyReader.TextFieldType = FieldType.FixedWidth
                'Tracciato Carbone
                MyReader.FieldWidths = {1, 2, 21, 6, 13, 2, 11, 2, 13, 12, 12, 14, 1, 13, 2, 49, 7, 30, 8, 6, 6, 2}
                Try
                    result = MyReader.ReadFields()
                    'Dim currentField As String
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End Using
        End Using

        Return result
    End Function
    Private Sub InitializeTestata()

        dtTeste.Columns.Add("Filler0") '6
        dtTeste.Columns.Add("DataDoc") '6 'AAMMGG
        dtTeste.Columns.Add("Filler1") '16
        dtTeste.Columns.Add("Causale") '3
        dtTeste.Columns.Add("Filler2") '12
        dtTeste.Columns.Add("Giorni") '2
        dtTeste.Columns.Add("Filler3") '33
        dtTeste.Columns.Add("Prot") '6
        dtTeste.Columns.Add("Filler4") '39
        dtTeste.Columns.Add("CdC") '2
        dtTeste.Columns.Add("Filler5") '49
        dtTeste.Columns.Add("Riferimento") '7 =0000010 x testate pn causali 267 =0000020 per pn causali 216  
        dtTeste.Columns.Add("Filler6") '30
        dtTeste.Columns.Add("Utente") '8
        dtTeste.Columns.Add("DataReg") '6 'AAMMGG
        dtTeste.Columns.Add("NrRif") '6
        dtTeste.Columns.Add("NrSequenza") '2
        dtTeste.Columns.Add("CdCMago") 'Varchar(8) Campo di Mago da Valorizzare con tabela di Transcodifica

    End Sub
    Private Sub InitializeRighe()

        dtRighe.Columns.Add("Filler0")      '1
        dtRighe.Columns.Add("CdC")          '2
        dtRighe.Columns.Add("Filler1")      '21
        dtRighe.Columns.Add("Prot")         '6
        dtRighe.Columns.Add("Imponibile")   '13 ultimi 2 decimali
        dtRighe.Columns.Add("CodIva")       '2
        dtRighe.Columns.Add("Imposta")      '11
        dtRighe.Columns.Add("Filler2")      '2
        dtRighe.Columns.Add("Filler3")      '13
        dtRighe.Columns.Add("ContoDare")    '12
        dtRighe.Columns.Add("ContoAvere")   '12
        dtRighe.Columns.Add("Filler4")      '14
        dtRighe.Columns.Add("Continua")     '1 "C" sui dettagli " " su ultimo dettaglio
        dtRighe.Columns.Add("TotaleDoc")    '13 solo su ultima riga somma gli imponibili
        dtRighe.Columns.Add("Cdc1")         '2
        dtRighe.Columns.Add("Filler5")      '49
        dtRighe.Columns.Add("Riferimento")  '7 =0000010 x testate pn causali 267 =0000020 per pn causali 216     
        dtRighe.Columns.Add("Filler6")      '30
        dtRighe.Columns.Add("Utente")       '8
        dtRighe.Columns.Add("DataReg")      '6 'AAMMGG
        dtRighe.Columns.Add("NrRif")        '6
        dtRighe.Columns.Add("NrSequenza")   '2
        dtRighe.Columns.Add("CdCMago") 'Varchar(8) Campo di Mago da Valorizzare con tabela di Transcodifica

    End Sub

    ''' <summary> 
    ''' Transcodifica Centri di Costo Da Paghe a Mago <br/>
    ''' A Seguito accorpamento UNO -- SPA
    ''' </summary>
    Private Sub InitializeTranscode()
        dtTranscode = New DataTable
        dtTranscode.Columns.Add("CodPaghe")
        dtTranscode.PrimaryKey = New DataColumn() {dtTranscode.Columns("CodPaghe")}
        dtTranscode.Columns.Add("CodMago")
        dtTranscode.Rows.Add("A1", "AL1")
        dtTranscode.Rows.Add("A2", "ALBA1")
        dtTranscode.Rows.Add("A3", "AO1")
        dtTranscode.Rows.Add("A4", "AT1")
        dtTranscode.Rows.Add("BI", "BI1")
        dtTranscode.Rows.Add("BO", "BO1")
        dtTranscode.Rows.Add("CI", "CI1")
        dtTranscode.Rows.Add("C2", "CN1")
        dtTranscode.Rows.Add("M1", "MI1")
        dtTranscode.Rows.Add("N1", "NO1")
        dtTranscode.Rows.Add("RO", "RO1")
        dtTranscode.Rows.Add("T1", "TO1")
        dtTranscode.Rows.Add("UT", "UT1")
        dtTranscode.Rows.Add("V1", "VC1")
    End Sub
    Private Function TranscodeCdc(Cdc As String) As String
        Dim dr As DataRow = dtTranscode.Rows.Find(Cdc)
        If dr Is Nothing Then
            Return Cdc
        Else
            Return dr("CodMago").ToString
        End If
    End Function
    Private Sub InizializzaMascheraMatching()
        dtTeste = New DataTable
        InitializeTestata()
        dtRighe = New DataTable
        InitializeRighe()
        InitializeTranscode()
    End Sub
    ''' <summary>
    ''' Creo la scrittura in contabilità per le paghe
    ''' </summary>
    ''' <param name="t">Testate documenti</param>
    ''' <param name="r">Righe</param>
    ''' <returns></returns>
    Private Function CreaPNotaPaghe(ByVal t As DataTable, ByVal r As DataTable) As Boolean
        'Movimenti Contabili PURI - MA_JournalEntries
        'Righe - MA_JournalEntriesGLDetail
        'I vari conti che leggo vanno matchati con quelli nuovi
        'Ciclo le righe in quanto sulla testa non so cosa ce' che mi serve

        Dim okBulk As Boolean
        Dim okAnalitica As Boolean
        Dim someTrouble As Boolean

        If r.Rows.Count > 0 Then
            Dim DataRiga As Date = MagoFormatta("20" & r.Rows(0).Item("DataReg"), GetType(DateTime)).DataTempo
            'Identificatore Prima Nota
            Dim idPn As Integer = LeggiID(IdType.PNota)
            Dim iRefNo As Integer = LeggiNonFiscalNumber(CodeType.PNota, Year(DataRiga))

            Try
                Dim quadratura As Double
                Dim quadraturaDaFile As Double
                Dim totDare As Double
                Dim totAvere As Double
                Dim isNewReg As Boolean = True
                Dim bChiudiRegistrazione As Boolean = False
                Dim irow As Integer = 0
                Dim i As Byte = 0
                Dim ireg As Integer = 0
                Dim iLine As Integer ' Contatore delle righe

                Using dtPN As DataTable = CaricaSchema("MA_JournalEntries", True)
                    Using dtPND As DataTable = CaricaSchema("MA_JournalEntriesGLDetail", True)
                        Debug.Print("Popolo tabella saldi")
                        Dim qrySaldi As String = "SELECT * FROM MA_ChartOfAccountsBalances WHERE BalanceYear = " & Year(DataRiga) & " AND BalanceMonth = " & Month(DataRiga)
                        Using adpPNSaldi As New SqlDataAdapter(qrySaldi, Connection)
                            Dim cbMar = New SqlCommandBuilder(adpPNSaldi)
                            adpPNSaldi.UpdateCommand = cbMar.GetUpdateCommand(True)
                            adpPNSaldi.InsertCommand = cbMar.GetInsertCommand(True)
                            Dim dtPNSaldi As DataTable = CaricaSchema("MA_ChartOfAccountsBalances", True, True, qrySaldi)
                            adpPNSaldi.Fill(dtPNSaldi)
                            Dim dvPNSaldi As New DataView(dtPNSaldi, "Nature=9306112 AND BalanceType = 3145730", "Account", DataViewRowState.CurrentRows)
                            'per le contropartite 
                            Debug.Print("Popolo tabella contropartite")
                            Using adp As New SqlDataAdapter("Select Account, ACGCode, PostableInCostAcc FROM MA_ChartOfAccounts", Connection)
                                Dim dtCntrp As New DataTable("Contropartita")
                                adp.Fill(dtCntrp)
                                Dim dvCntrp As New DataView(dtCntrp, "", "ACGCode", DataViewRowState.CurrentRows)

                                Dim isQDare As Boolean
                                Dim drPn As DataRow = dtPN.NewRow
                                Dim drPnD As DataRow = dtPND.NewRow
                                'Campo Filiale che sto elaborando, serve per cambiare movimento/registrazione
                                Dim filToReg As String = ""
                                For irow = i To r.Rows.Count - 1
                                    With r.Rows(irow)
                                        iLine += 1
                                        DataRiga = MagoFormatta("20" & .Item("DataReg"), GetType(DateTime)).DataTempo
                                        'Controllo la filiale e se diversa chiudo la registrazione, 
                                        'quadro a conto transitorio e creo nuovo movimento
                                        '02/08/2023 Cambio Campo per adeguamento e transcodifica UNO-SPA
                                        If filToReg <> .Item("CdCMago") OrElse bChiudiRegistrazione Then
                                            If Not isNewReg Then
                                                'Aggiorno la testa con quello che ho calcolato
                                                drPn("TotalAmount") = Math.Round(If(totDare > totAvere, totDare, totAvere), 2)
                                                If drPn("TotalAmount") <> quadraturaDaFile Then
                                                    Dim avviso As String = ("Sulla registrazione rif." & drPn("RefNo").ToString & " il totale calcolato " & drPn("TotalAmount").ToString & " differisce da quello letto dal flusso " & quadraturaDaFile.ToString)
                                                    Debug.Print(avviso)
                                                    My.Application.Log.WriteEntry(avviso)
                                                End If
                                                drPn("LastSubId") = iLine
                                                dtPN.Rows.Add(drPn)
                                                'Creo quella nuova per quadrare
                                                drPnD = dtPND.NewRow
                                                drPnD("JournalEntryId") = idPn
                                                drPnD("Line") = iLine
                                                drPnD("PostingDate") = DataRiga
                                                drPnD("AccrualDate") = DataRiga
                                                drPnD("AccRsn") = CauRiga
                                                drPnD("Account") = contoTransitorio
                                                isQDare = quadratura <= 0.001
                                                drPnD("DebitCreditSign") = If(quadratura > 0.001, 4980737, 4980736) 'T= Dare 4980736 / Avere 4980737
                                                drPnD("Amount") = Math.Abs(Math.Round(quadratura, 2))
                                                drPnD("FiscalAmount") = Math.Abs(Math.Round(quadratura, 2))
                                                drPnD("Currency") = "EUR"
                                                drPnD("ValueDate") = DataRiga
                                                drPnD("SubId") = iLine
                                                drPnD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                drPnD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                AggiornaSaldoContabile(drPnD("Account"), Year(DataRiga), Month(DataRiga), isQDare, drPnD("Amount"), dvPNSaldi)
                                                dtPND.Rows.Add(drPnD)
                                                isNewReg = True
                                                bChiudiRegistrazione = False
                                            End If
                                            'resetto e rivalorizzo
                                            If filToReg <> .Item("CdCMago") Then ireg = 0
                                            filToReg = .Item("CdCMago")
                                            quadratura = 0
                                            quadraturaDaFile = 0
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
                                            drPn("AccTpl") = ModCont
                                            drPn("PostingDate") = DataRiga
                                            drPn("RefNo") = Right(Year(DataRiga), 2) & "-" & iRefNo.ToString("00000")
                                            drPn("DocumentDate") = DataRiga
                                            drPn("DocNo") = filToReg & "-" & ireg.ToString
                                            drPn("JournalEntryId") = idPn
                                            drPn("AccrualDate") = DataRiga
                                            drPn("Currency") = "EUR"
                                            drPn("ValueDate") = DataRiga
                                            drPn("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                            drPn("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                        End If

                                        ''''''''''''''''''''''
                                        'Righe MA_JournalEntriesGLDetail
                                        ''''''''''''''''''''''
                                        drPnD = dtPND.NewRow
                                        drPnD("JournalEntryId") = idPn
                                        drPnD("Line") = iLine
                                        drPnD("PostingDate") = DataRiga
                                        drPnD("AccrualDate") = DataRiga
                                        drPnD("AccRsn") = CauRiga
                                        Dim nota As String = ""
                                        drPnD("Notes") = nota
                                        'drPnD ("CodeType")= 5177344 ' Normale / Apertura / Assestamento
                                        Dim isDare As Boolean = .Item("ContoDare") <> contoTransitorio
                                        Dim c As String = If(isDare, .Item("ContoDare"), .Item("ContoAvere"))
                                        Dim sConto As String = ""
                                        If TryTrovaContropartita(c, dvCntrp, sConto) Then
                                            drPnD("Account") = sConto
                                        Else
                                            Debug.Print("Conto senza corrispondenza: " & c)
                                            My.Application.Log.WriteEntry("Conto senza corrispondenza: " & c & "filiale: " & filToReg)
                                            MessageBox.Show("Conto senza corrispondenza: " & c & Environment.NewLine & "Su Filiale: " & filToReg & Environment.NewLine & "Impossibile continuare!", "Importazione Paghe - Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End
                                        End If
                                        If String.IsNullOrWhiteSpace(drPnD("Account").ToString) Then
                                            Debug.Print("Conto senza corrispondenza " & c)
                                            My.Application.Log.WriteEntry("Conto senza corrispondenza " & c)
                                        End If
                                        drPnD("DebitCreditSign") = If(isDare, 4980736, 4980737)
                                        Dim imp As Double = MagoFormatta(.Item("Imponibile"), GetType(Double)).MONey / 100 ' Math.Round(CDbl(.Item("Imponibile")), 2)
                                        drPnD("Amount") = imp
                                        drPnD("FiscalAmount") = imp
                                        quadratura += If(isDare, imp, -imp)
                                        If isDare Then
                                            totDare += imp
                                        Else
                                            totAvere += imp
                                        End If
                                        drPnD("Currency") = "EUR"
                                        drPnD("ValueDate") = DataRiga
                                        drPnD("SubId") = iLine
                                        drPnD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                        drPnD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                        AggiornaSaldoContabile(drPnD("Account"), Year(DataRiga), Month(DataRiga), isDare, drPnD("Amount"), dvPNSaldi)
                                        dtPND.Rows.Add(drPnD)

                                        'Controllo di non essere sull'ultima riga della scrittura
                                        If .Item("Continua") <> "C" Then
                                            bChiudiRegistrazione = True
                                            quadraturaDaFile = MagoFormatta(.Item("TotaleDoc"), GetType(Double)).MONey / 100
                                        End If
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
                                drPnD("PostingDate") = DataRiga
                                drPnD("AccrualDate") = DataRiga
                                drPnD("AccRsn") = CauRiga
                                drPnD("Account") = contoTransitorio
                                isQDare = quadratura <= 0.001
                                drPnD("DebitCreditSign") = If(quadratura > 0.001, 4980737, 4980736) 'T= Dare 4980736 / Avere 4980737
                                drPnD("Amount") = Math.Abs(Math.Round(quadratura, 2))
                                drPnD("FiscalAmount") = Math.Abs(Math.Round(quadratura, 2))
                                drPnD("Currency") = "EUR"
                                drPnD("ValueDate") = DataRiga
                                drPnD("SubId") = iLine + 1
                                drPnD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                drPnD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                AggiornaSaldoContabile(drPnD("Account"), Year(DataRiga), Month(DataRiga), isQDare, drPnD("Amount"), dvPNSaldi)
                                dtPND.Rows.Add(drPnD)

                                Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                    cmdqry.ExecuteNonQuery()
                                    Using bulkTrans = Connection.BeginTransaction
                                        EditTestoBarra("Salvataggio: Prima Nota")
                                        okBulk = ScriviBulk("MA_JournalEntries", dtPN, bulkTrans, Connection)
                                        If Not okBulk Then someTrouble = True
                                        EditTestoBarra("Salvataggio: Righe")
                                        okBulk = ScriviBulk("MA_JournalEntriesGLDetail", dtPND, bulkTrans, Connection)
                                        If Not okBulk Then someTrouble = True
                                        If someTrouble Then
                                            FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                                            bulkTrans.Rollback()
                                        Else
                                            bulkTrans.Commit()
                                        End If
                                    End Using
                                    If Not someTrouble Then
                                        Dim irows As Integer
                                        irows = adpPNSaldi.Update(dtPNSaldi)
                                        'Result.AppendLine("Aggiornamento Vista Clienti: " & irows.ToString & " record")
                                        Debug.Print("Aggiornamento Saldi: " & irows.ToString & " record")
                                    End If
                                    cmdqry.CommandText = "DBCC TRACEOFF(610)"
                                    cmdqry.ExecuteNonQuery()
                                End Using

                            End Using
                        End Using
                        If Not someTrouble Then
                            okAnalitica = CreaAnalitica(dtPN, dtPND)
                            If Not okAnalitica Then
                                Dim mb As New MessageBoxWithDetails("Errore su Salvataggio Analitica", GetCurrentMethod.Name, "")
                                mb.ShowDialog()
                                someTrouble = True
                            End If
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End Try
            'Scrivi Gli ID ( faccio solo a fine elaborazione)
            AggiornaID(IdType.PNota, idPn)
            AggiornaNonFiscalNumber(CodeType.PNota, Year(DataRiga), iRefNo)


        End If

        Return Not someTrouble

    End Function

    ''' <summary>
    ''' Creo le scritture analitiche a partire dalle righe Prima Nota che mi vengono passate
    ''' </summary>
    ''' <param name="TestePN"></param>
    ''' <param name="RighePN"></param>
    ''' <returns></returns>
    Private Function CreaAnalitica(ByVal TestePN As DataTable, ByVal RighePN As DataTable) As Boolean
        'Testa Analitica - MA_CostAccEntries

        If TestePN.Rows.Count = 0 Then
            Return False
            Exit Function
        End If

        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim DataRiga As Date = TestePN.Rows(0).Item("PostingDate")
        'Identificatore Prima Nota Analitica
        Dim idMovAna As Integer = LeggiID(IdType.MovAna)
        Dim iRefNo As Integer = LeggiNonFiscalNumber(CodeType.MovAna, Year(DataRiga))

        Try
            Dim ireg As Integer = 0

            Using dtMovAna As DataTable = CaricaSchema("MA_CostAccEntries", True)
                Using dtMovAnaD As DataTable = CaricaSchema("MA_CostAccEntriesDetail", True)
                    Using dtCR As DataTable = CaricaSchema("MA_CrossReferences", True)
                        Dim qrySaldi As String = "SELECT * FROM MA_CostCentersBalances"
                        Using adpMovAnaSaldi As New SqlDataAdapter(qrySaldi, Connection)
                            Dim cbMar = New SqlCommandBuilder(adpMovAnaSaldi)
                            adpMovAnaSaldi.UpdateCommand = cbMar.GetUpdateCommand(True)
                            Dim dtMovAnaSaldi As New DataTable("MA_CostCentersBalances")
                            adpMovAnaSaldi.Fill(dtMovAnaSaldi)
                            Dim dvMovAnaSaldi As New DataView(dtMovAnaSaldi, "", "", DataViewRowState.CurrentRows)

                            Using adp As New SqlDataAdapter("Select Account, PostableInCostAcc FROM MA_ChartOfAccounts", Connection)
                                Dim dtCntrp As New DataTable("Contropartita")
                                adp.Fill(dtCntrp)
                                Dim dvCntrp As New DataView(dtCntrp, "", "Account", DataViewRowState.CurrentRows)

                                Dim drAna As DataRow = dtMovAna.NewRow
                                Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                Dim drCR As DataRow = dtCR.NewRow
                                For irow = 0 To TestePN.Rows.Count - 1
                                    'Ciclo sulle teste PN
                                    'Filtro sull' id pnota
                                    Dim rv As New DataView(RighePN, "JournalEntryId=" & TestePN.Rows(irow).Item("JournalEntryId"), "Line", DataViewRowState.CurrentRows)
                                    For ir = 0 To rv.Count - 1
                                        'Ciclo sulle righe
                                        With rv(ir)
                                            Dim conF As Integer = dvCntrp.Find(.Item("Account"))
                                            Dim isAnalitico As Boolean = dvCntrp(conF).Item("PostableInCostAcc") = "1"
                                            If isAnalitico Then
                                                'Creo la testa della registrazione
                                                idMovAna += 1
                                                iRefNo += 1
                                                ireg += 1
                                                drAna = dtMovAna.NewRow
                                                drAna("Account") = .Item("Account")
                                                drAna("DebitCreditSign") = If(.Item("DebitCreditSign") = 4980736, DareAvereIgnora.Dare, DareAvereIgnora.Avere)
                                                drAna("CodeType") = 7995393 ' Consuntivo
                                                drAna("RefNo") = Right(Year(DataRiga), 2) & "-" & iRefNo.ToString("00000")
                                                drAna("PostingDate") = .Item("PostingDate")
                                                drAna("AccrualDate") = .Item("AccrualDate")
                                                drAna("DocumentDate") = .Item("PostingDate")
                                                drAna("DocNo") = TestePN.Rows(irow).Item("DocNo")
                                                drAna("RefDocNo") = TestePN.Rows(irow).Item("RefNo")
                                                drAna("TotalAmount") = .Item("Amount")
                                                drAna("Notes") = "Paghe"
                                                drAna("EntryId") = idMovAna
                                                drAna("JournalEntryId") = .Item("JournalEntryId")
                                                drAna("CRRefType") = CrossReference.PnotaPuro ' Riferimento incrociato: Contabili puri
                                                drAna("CRRefID") = .Item("JournalEntryId")
                                                drAna("CRRefSubID") = .Item("Line")
                                                drAna("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                drAna("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                dtMovAna.Rows.Add(drAna)

                                                'Creo il riferimento Cross Reference
                                                'Origine = P.Nota Puri // Derivato =  Mov. Analitico
                                                drCR = dtCR.NewRow
                                                drCR("OriginDocType") = CrossReference.PnotaPuro
                                                drCR("OriginDocID") = .Item("JournalEntryId")
                                                drCR("OriginDocSubID") = 0
                                                drCR("OriginDocLine") = 0
                                                drCR("DerivedDocType") = CrossReference.MovimentoAnalitico
                                                drCR("DerivedDocID") = idMovAna
                                                drCR("DerivedDocSubID") = 0
                                                drCR("DerivedDocLine") = 0
                                                drCR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                drCR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                dtCR.Rows.Add(drCR)

                                                ''''''''''''''''''''''
                                                'Righe MA_CostAccEntriesDetail
                                                ''''''''''''''''''''''
                                                Dim isDare = .Item("DebitCreditSign") = 4980736
                                                Dim CdC As String = Split(TestePN.Rows(irow).Item("DocNo"), "-").First
                                                drAnaD = dtMovAnaD.NewRow
                                                drAnaD("EntryId") = idMovAna
                                                drAnaD("Line") = 1 'Linea dettaglio Cdc, ne ho sempre solo una
                                                drAnaD("Account") = .Item("Account")
                                                drAnaD("PostingDate") = .Item("PostingDate")
                                                drAnaD("AccrualDate") = .Item("AccrualDate")
                                                drAnaD("CodeType") = 7995393 ' Consuntivo
                                                drAnaD("CostCenter") = CdC
                                                drAnaD("HasCostCenter") = 1
                                                drAnaD("Perc") = 100
                                                drAnaD("DebitCreditSign") = .Item("DebitCreditSign")
                                                drAnaD("Amount") = .Item("Amount")
                                                drAnaD("Notes") = ""
                                                drAnaD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                drAnaD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                dtMovAnaD.Rows.Add(drAnaD)
                                                Dim wAnaBal As New MySaldoAnalitico With {
                                                    .Conto = drAnaD("Account").ToString,
                                                    .Centro = drAnaD("CostCenter").ToString,
                                                    .Anno = Year(DataRiga),
                                                    .Mese = Month(DataRiga)
                                                    }
                                                AggiornaSaldoAnalitico(wAnaBal, isDare, drAnaD("Amount"), dvMovAnaSaldi)
                                            End If
                                        End With
                                    Next
                                Next

                                Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                    cmdqry.ExecuteNonQuery()
                                    Dim irows As Integer
                                    irows = adpMovAnaSaldi.Update(dtMovAnaSaldi)
                                    'Result.AppendLine("Aggiornamento Saldi analitici: " & irows.ToString & " record")
                                    Debug.Print("Aggiornamento Saldi analitici: " & irows.ToString & " record")
                                    Using bulkTrans = Connection.BeginTransaction
                                        EditTestoBarra("Salvataggio: Movimenti Analitici")
                                        okBulk = ScriviBulk("MA_CostAccEntries", dtMovAna, bulkTrans, Connection)
                                        If Not okBulk Then someTrouble = True
                                        EditTestoBarra("Salvataggio: Righe")
                                        okBulk = ScriviBulk("MA_CostAccEntriesDetail", dtMovAnaD, bulkTrans, Connection)
                                        If Not okBulk Then someTrouble = True
                                        EditTestoBarra("Salvataggio: Riferimenti incrociati")
                                        okBulk = ScriviBulk("MA_CrossReferences", dtCR, bulkTrans, Connection)
                                        If Not okBulk Then someTrouble = True
                                        If someTrouble Then
                                            FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                                            bulkTrans.Rollback()
                                        Else
                                            bulkTrans.Commit()
                                        End If
                                    End Using
                                    cmdqry.CommandText = "DBCC TRACEOFF(610)"
                                    cmdqry.ExecuteNonQuery()
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        If Not someTrouble Then
            'Scrivi Gli ID ( faccio solo a fine elaborazione)
            AggiornaID(IdType.MovAna, idMovAna)
            AggiornaNonFiscalNumber(CodeType.MovAna, Year(DataRiga), iRefNo)
        End If

        Return Not someTrouble

    End Function

End Module

