Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase
Public Module Paghe
    Private dtTeste As DataTable
    Private dtRighe As DataTable
    Private Const cTrans = "2DIP999"
    Private Const ModCont = "PAGHE"
    Private Const CauRiga = "PAGHE"
    Private Const ContoTransitorioACG = "20890101"

    Public Function CaricaFlussoPaghe(ByVal refPath As String) As Boolean
        Dim result As Boolean

        InizializzaMascheraMatching()
        Using rdr As New StreamReader(refPath)
            Dim currentLine As String = rdr.ReadLine()
            While currentLine IsNot Nothing
                Dim currentRow As String()

                If String.IsNullOrWhiteSpace(Left(currentLine, 6)) Then
                    currentRow = Testata(currentLine)
                    dtTeste.Rows.Add(currentRow)
                Else
                    currentRow = Riga(currentLine)
                    dtRighe.Rows.Add(currentRow)
                End If

                If currentRow IsNot Nothing Then
                    'Process current set of fields
                End If

                currentLine = rdr.ReadLine()
            End While
        End Using
        'FLogin.DataGridView1.DataSource = dtRighe
        result = CreaPNotaPaghe(dtTeste, dtRighe)
        Return result
    End Function

    ''' <summary>
    ''' This method uses a TextFieldParser to process a single line of a file that is passed in
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
    ''' This method uses a TextFieldParser to process a single line of a file that is passed in
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

    End Sub
    Private Sub InitalizeRighe()

        dtRighe.Columns.Add("Filler0") '1
        dtRighe.Columns.Add("CdC") '2
        dtRighe.Columns.Add("Filler1") '21
        dtRighe.Columns.Add("Prot") '6
        dtRighe.Columns.Add("Imponibile") '13 ultimi 2 decimali
        dtRighe.Columns.Add("CodIva") '2
        dtRighe.Columns.Add("Imposta") '11
        dtRighe.Columns.Add("Filler2") '2
        dtRighe.Columns.Add("Filler3") ' 13
        dtRighe.Columns.Add("ContoDare") '12
        dtRighe.Columns.Add("ContoAvere") '12
        dtRighe.Columns.Add("Filler4") '14
        dtRighe.Columns.Add("Continua") '1 "C" sui dettagli " " su ultimo dettaglio
        dtRighe.Columns.Add("TotaleDoc") '13 solo su ultima riga somma gli imponibili
        dtRighe.Columns.Add("Cdc1") '2
        dtRighe.Columns.Add("Filler5") '49
        dtRighe.Columns.Add("Riferimento") '7 =0000010 x testate pn causali 267 =0000020 per pn causali 216     
        dtRighe.Columns.Add("Filler6") '30
        dtRighe.Columns.Add("Utente") '8
        dtRighe.Columns.Add("DataReg") '6 'AAMMGG
        dtRighe.Columns.Add("NrRif") '6
        dtRighe.Columns.Add("NrSequenza") '2

    End Sub
    Private Sub InizializzaMascheraMatching()
        dtTeste = New DataTable
        InitializeTestata()
        dtRighe = New DataTable
        InitalizeRighe()
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
                            Dim dtPNSaldi As DataTable = CaricaSchema("MA_ChartOfAccountsBalances", True, True, qrySaldi)
                            adpPNSaldi.Fill(dtPNSaldi)
                            Dim dvPNSaldi As New DataView(dtPNSaldi, "", "Account", DataViewRowState.CurrentRows)
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
                                        If filToReg <> .Item("CdC") OrElse bChiudiRegistrazione Then
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
                                                drPnD("Account") = cTrans
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
                                            If filToReg <> .Item("CdC") Then ireg = 0
                                            filToReg = .Item("CdC")
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
                                        Dim isDare As Boolean = .Item("ContoDare") <> ContoTransitorioACG
                                        Dim c As String = If(isDare, .Item("ContoDare"), .Item("ContoAvere"))
                                        Dim sConto As String = ""
                                        If TryTrovaContropartita(c, dvCntrp, sConto) Then
                                            drPnD("Account") = sConto
                                        Else
                                            Debug.Print("Conto senza corrispondenza: " & c)
                                            My.Application.Log.WriteEntry("Conto senza corrispondenza: " & c & "f iliale: " & filToReg)
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
                                drPnD("Account") = cTrans
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
                                        okBulk = ScriviBulk("MA_JournalEntries", dtPN, bulkTrans)
                                        If Not okBulk Then someTrouble = True
                                        EditTestoBarra("Salvataggio: Righe")
                                        okBulk = ScriviBulk("MA_JournalEntriesGLDetail", dtPND, bulkTrans)
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
                        If Not someTrouble Then CreaAnalitica(dtPN, dtPND)
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
                        Dim qrySaldi As String = "SELECT * FROM MA_CostCentersBalances WHERE BalanceYear = " & Year(DataRiga) & " AND BalanceMonth = " & Month(DataRiga)
                        Using adpMovAnaSaldi As New SqlDataAdapter(qrySaldi, Connection)
                            Dim cbMar = New SqlCommandBuilder(adpMovAnaSaldi)
                            adpMovAnaSaldi.UpdateCommand = cbMar.GetUpdateCommand(True)
                            Dim dtMovAnaSaldi As New DataTable("MA_CostCentersBalances")
                            adpMovAnaSaldi.Fill(dtMovAnaSaldi)
                            Dim dvMovAnaSaldi As New DataView(dtMovAnaSaldi, "", "CostCenter,Account", DataViewRowState.CurrentRows)

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
                                                Dim CdC As String = Left(TestePN.Rows(irow).Item("DocNo"), 2)
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
                                                AggiornaSaldoAnalitico(drAnaD("Account"), CdC, Year(DataRiga), Month(DataRiga), isDare, drAnaD("Amount"), dvMovAnaSaldi)
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
                                        okBulk = ScriviBulk("MA_CostAccEntries", dtMovAna, bulkTrans)
                                        If Not okBulk Then someTrouble = True
                                        EditTestoBarra("Salvataggio: Righe")
                                        okBulk = ScriviBulk("MA_CostAccEntriesDetail", dtMovAnaD, bulkTrans)
                                        If Not okBulk Then someTrouble = True
                                        EditTestoBarra("Salvataggio: Riferimenti incrociati")
                                        okBulk = ScriviBulk("MA_CrossReferences", dtCR, bulkTrans)
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
Public Module Analitica
    Public Function AggiornaSaldoAnalitico(ByVal conto As String, centro As String, anno As Short, mese As Short, isDebit As Boolean, valore As Double, vista As DataView) As Boolean
        Dim result As Boolean
        Dim found As Integer = vista.Find({centro, conto})
        Try
            If found <> -1 Then
                With vista(found)
                    .BeginEdit()
                    If isDebit Then
                        .Item("ActualDebit") += valore
                    Else
                        .Item("ActualCredit") += valore
                    End If
                    .EndEdit()
                End With
            Else
                Dim r As DataRow = vista.Table.NewRow
                r.Item("CostCenter") = centro
                r.Item("Account") = conto
                r.Item("FiscalYear") = anno
                r.Item("BalanceYear") = anno
                r.Item("BalanceType") = 3145730
                r.Item("BalanceMonth") = mese
                If isDebit Then
                    r.Item("ActualDebit") = valore
                    r.Item("ActualCredit") = 0
                Else
                    r.Item("ActualDebit") = 0
                    r.Item("ActualCredit") = valore
                End If
                r.Item("BudgetDebitQty") = 0
                r.Item("ActualDebitQty") = 0
                r.Item("ForecastDebitQty") = 0
                r.Item("BudgetCreditQty") = 0
                r.Item("ActualCreditQty") = 0
                r.Item("ForecastCreditQty") = 0
                r.Item("BudgetDebit") = 0
                r.Item("ForecastDebit") = 0
                r.Item("BudgetCredit") = 0
                r.Item("ForecastCredit") = 0
                r.Item("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                r.Item("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                vista.Table.Rows.Add(r)
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        Return result
    End Function

End Module
Public Module Contabilita

    Private Const ModCont = "RISCONTI"
    Private Const CauRiga = "GIROCONT"
    Private Const RiscAtt = "1RIS001"
    'Private Const RiscPass = "2RIS001"

    ''' <summary>
    ''' Creo la scrittura dei risconti in contabilità 
    ''' </summary>
    ''' <param name="r">Righe</param>
    ''' <returns></returns>
    Public Function CreaPNotaRisconti(ByVal r As DataTable) As Boolean
        'Movimenti Contabili PURI - MA_JournalEntries
        'Righe - MA_JournalEntriesGLDetail
        'I vari conti che leggo vanno matchati con quelli nuovi

        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim DataRiga As Date = MagoFormatta("20210102", GetType(DateTime)).DataTempo
        FLogin.prgCopy.Value = 1

        If r.Rows.Count > 0 Then
            FLogin.prgCopy.Maximum = r.Rows.Count
            FLogin.prgCopy.Step = 1
            'Identificatore Prima Nota
            Dim idPn As Integer = LeggiID(IdType.PNota)
            Dim iRefNo As Integer = LeggiNonFiscalNumber(CodeType.PNota, Year(DataRiga))
            'Identificatore Prima Nota Analitica
            Dim idMovAna As Integer = LeggiID(IdType.MovAna)
            Dim iRefNoAna As Integer = LeggiNonFiscalNumber(CodeType.MovAna, Year(DataRiga))

            Try
                Dim quadratura As Double
                Dim quadraturaDaFile As Double
                Dim totDare As Double
                Dim totAvere As Double
                Dim isNewReg As Boolean = True
                Dim irow As Integer = 0
                Dim i As Byte = 0
                Dim ireg As Integer = 0
                Dim iNrRegistrazioni As Integer = 0
                Dim iLine As Integer ' Contatore delle righe

                Using dtPN As DataTable = CaricaSchema("MA_JournalEntries", True)
                    Using dtPND As DataTable = CaricaSchema("MA_JournalEntriesGLDetail", True)
                        Using dtMovAna As DataTable = CaricaSchema("MA_CostAccEntries", True)
                            Using dtMovAnaD As DataTable = CaricaSchema("MA_CostAccEntriesDetail", True)
                                Using dtCR As DataTable = CaricaSchema("MA_CrossReferences", True)
                                    Debug.Print("Popolo tabella saldi")
                                    'Saldi Contabili 
                                    Dim qrySaldi As String = "SELECT * FROM MA_ChartOfAccountsBalances WHERE BalanceYear = " & Year(DataRiga) & " AND BalanceMonth = " & Month(DataRiga)
                                    Using adpPNSaldi As New SqlDataAdapter(qrySaldi, Connection)
                                        Dim cbMar = New SqlCommandBuilder(adpPNSaldi)
                                        adpPNSaldi.UpdateCommand = cbMar.GetUpdateCommand(True)
                                        Dim dtPNSaldi As DataTable = CaricaSchema("MA_ChartOfAccountsBalances", True, True, qrySaldi)
                                        adpPNSaldi.Fill(dtPNSaldi)
                                        Dim dvPNSaldi As New DataView(dtPNSaldi, "", "Account", DataViewRowState.CurrentRows)
                                        'Saldi Analitici 
                                        qrySaldi = "SELECT * FROM MA_CostCentersBalances WHERE BalanceYear = " & Year(DataRiga) & " AND BalanceMonth = " & Month(DataRiga)
                                        Using adpMovAnaSaldi As New SqlDataAdapter(qrySaldi, Connection)
                                            cbMar = New SqlCommandBuilder(adpMovAnaSaldi)
                                            adpMovAnaSaldi.UpdateCommand = cbMar.GetUpdateCommand(True)
                                            Dim dtMovAnaSaldi As New DataTable("MA_CostCentersBalances")
                                            adpMovAnaSaldi.Fill(dtMovAnaSaldi)
                                            Dim dvMovAnaSaldi As New DataView(dtMovAnaSaldi, "", "CostCenter,Account", DataViewRowState.CurrentRows)

                                            'per le contropartite 
                                            Debug.Print("Popolo tabella contropartite")
                                            Using adp As New SqlDataAdapter("Select Account, ACGCode, PostableInCostAcc FROM MA_ChartOfAccounts", Connection)
                                                Dim dtCntrp As New DataTable("Contropartita")
                                                adp.Fill(dtCntrp)
                                                Dim dvCntrp As New DataView(dtCntrp, "", "ACGCode", DataViewRowState.CurrentRows)
                                                Using adpCdC As New SqlDataAdapter("Select * FROM MA_CostCenters", Connection)
                                                    Dim dtCdc As New DataTable("Centri")
                                                    adpCdC.Fill(dtCdc)
                                                    Dim dvCdC As New DataView(dtCdc, "", "CostCenter", DataViewRowState.CurrentRows)

                                                    Dim isQDare As Boolean
                                                    Dim drPn As DataRow = dtPN.NewRow
                                                    Dim drPnD As DataRow = dtPND.NewRow
                                                    For irow = i To r.Rows.Count - 1
                                                        With r.Rows(irow)
                                                            iLine += 1

                                                            If isNewReg Then
                                                                'Creo la testa della registrazione
                                                                drPn = dtPN.NewRow
                                                                idPn += 1
                                                                iRefNo += 1
                                                                ireg += 1
                                                                iNrRegistrazioni += 1
                                                                isNewReg = False
                                                                drPn("AccTpl") = ModCont
                                                                drPn("PostingDate") = DataRiga
                                                                drPn("RefNo") = Right(Year(DataRiga), 2) & "-" & iRefNo.ToString("00000")
                                                                drPn("DocumentDate") = DataRiga
                                                                drPn("DocNo") = iNrRegistrazioni.ToString & "RISC"
                                                                drPn("JournalEntryId") = idPn
                                                                drPn("AccrualDate") = DataRiga
                                                                drPn("Currency") = "EUR"
                                                                drPn("ValueDate") = DataRiga
                                                                drPn("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                drPn("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                            End If

                                                            '''''''''''''''''''''''''''''''''
                                                            'Righe MA_JournalEntriesGLDetail'
                                                            '''''''''''''''''''''''''''''''''
                                                            drPnD = dtPND.NewRow
                                                            drPnD("JournalEntryId") = idPn
                                                            drPnD("Line") = iLine
                                                            drPnD("PostingDate") = DataRiga
                                                            drPnD("AccrualDate") = DataRiga
                                                            drPnD("AccRsn") = CauRiga
                                                            Dim nota As String = .Item("L").ToString & " " & .Item("B").ToString & " " & MagoFormatta(.Item("A"), GetType(DateTime)).sDataSlash
                                                            drPnD("Notes") = nota
                                                            'drPnD ("CodeType")= 5177344 ' Normale / Apertura / Assestamento
                                                            Dim isDare As Boolean = True
                                                            Dim c As String = .Item("H")
                                                            Dim sConto As String = ""
                                                            If TryTrovaContropartita(c, dvCntrp, sConto) Then
                                                                drPnD("Account") = sConto
                                                            Else
                                                                Debug.Print("Conto senza corrispondenza: " & c)
                                                                My.Application.Log.WriteEntry("Conto senza corrispondenza:" & c)
                                                                MessageBox.Show("Impossibile continuare, conto senza corrispondenza:" & c)
                                                                End
                                                            End If
                                                            drPnD("DebitCreditSign") = If(isDare, 4980736, 4980737)
                                                            Dim imp As Double = .Item("G")  ' Math.Round(CDbl(.Item("Imponibile")), 2)
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

                                                            'Scrivo analitica
                                                            Try
                                                                Dim iRegAna As Integer = 0
                                                                Dim drAna As DataRow = dtMovAna.NewRow
                                                                ' Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                                Dim drCR As DataRow = dtCR.NewRow

                                                                Dim conF As Integer = dvCntrp.Find(.Item("H"))
                                                                Dim isAnalitico As Boolean = dvCntrp(conF).Item("PostableInCostAcc") = "1"
                                                                If isAnalitico Then
                                                                    ' Uso il datarow precedente
                                                                    With drPnD
                                                                        'Creo la testa della registrazione
                                                                        idMovAna += 1
                                                                        iRefNoAna += 1
                                                                        iRegAna += 1
                                                                        drAna = dtMovAna.NewRow
                                                                        drAna("Account") = .Item("Account")
                                                                        drAna("DebitCreditSign") = If(.Item("DebitCreditSign") = 4980736, DareAvereIgnora.Dare, DareAvereIgnora.Avere)
                                                                        drAna("CodeType") = 7995393 ' Consuntivo
                                                                        drAna("RefNo") = Right(Year(DataRiga), 2) & "-" & iRefNoAna.ToString("00000")
                                                                        drAna("PostingDate") = .Item("PostingDate")
                                                                        drAna("AccrualDate") = .Item("AccrualDate")
                                                                        drAna("DocumentDate") = .Item("PostingDate")
                                                                        drAna("DocNo") = drPn.Item("DocNo")
                                                                        drAna("RefDocNo") = drPn.Item("RefNo")
                                                                        drAna("TotalAmount") = .Item("Amount")
                                                                        drAna("Notes") = .Item("Notes")
                                                                        drAna("EntryId") = idMovAna
                                                                        drAna("JournalEntryId") = .Item("JournalEntryId")
                                                                        drAna("CRRefType") = CrossReference.PnotaPuro ' Riferimento incrociato: Contabili puri
                                                                        drAna("CRRefID") = .Item("JournalEntryId")
                                                                        drAna("CRRefSubID") = .Item("Line")
                                                                        drAna("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                        drAna("TBModifiedID") = My.Settings.mLOGINID 'ID utente


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
                                                                        'Creo n righe
                                                                        Dim importo As Double = .Item("Amount")
                                                                        Dim tempAmount As Double = 0
                                                                        Dim iLineMovAna As Integer = 0
                                                                        Dim iCanoni = If(r.Rows(irow).Item("K") = 0, 1, Math.Abs(r.Rows(irow).Item("K")))
                                                                        Dim importoMensile As Double = importo / iCanoni
                                                                        Dim dataDecorrenza As Date = DataRiga
                                                                        Dim isDareAna = drAna("DebitCreditSign") = 8192000
                                                                        Dim CdC As String = r.Rows(irow).Item("L")

                                                                        Dim iCdcFound As Integer = dvCdC.Find(CdC)
                                                                        If iCdcFound = -1 Then
                                                                            Debug.Print("Centro di Costo senza corrispondenza: " & CdC)
                                                                            My.Application.Log.WriteEntry("Centro di Costo senza corrispondenza:" & CdC)
                                                                            MessageBox.Show("Impossibile continuare, centro di costo non presente:" & CdC)
                                                                            End
                                                                        End If


                                                                        For n = 0 To iCanoni - 1

                                                                            Dim dataMensile As DateTime = dataDecorrenza.AddMonths(n)
                                                                            iLineMovAna += 1
                                                                            Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                                            drAnaD("EntryId") = idMovAna
                                                                            drAnaD("Line") = iLineMovAna
                                                                            drAnaD("Account") = .Item("Account")
                                                                            drAnaD("PostingDate") = .Item("PostingDate")
                                                                            drAnaD("AccrualDate") = MagoFormatta(dataMensile.ToString, GetType(String)).DataTempo
                                                                            drAnaD("CodeType") = 7995393 ' Consuntivo
                                                                            drAnaD("CostCenter") = CdC
                                                                            drAnaD("HasCostCenter") = 1
                                                                            drAnaD("Perc") = 100
                                                                            drAnaD("DebitCreditSign") = .Item("DebitCreditSign")
                                                                            'Se e' l'ultima riga saldo
                                                                            drAnaD("Amount") = Math.Round(If(n = iCanoni - 1, importo - tempAmount, importoMensile), 2)
                                                                            tempAmount += Math.Round(importoMensile, 2)
                                                                            drAnaD("Notes") = ""
                                                                            drAnaD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                            drAnaD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                            dtMovAnaD.Rows.Add(drAnaD)
                                                                            AggiornaSaldoAnalitico(drAnaD("Account"), CdC, Year(DataRiga), Month(DataRiga), isDareAna, drAnaD("Amount"), dvMovAnaSaldi)
                                                                        Next
                                                                    End With
                                                                    RicalcolaPerc(dtMovAnaD, idMovAna, drAna("TotalAmount"))
                                                                    dtMovAna.Rows.Add(drAna)
                                                                End If

                                                            Catch ex As Exception
                                                                Debug.Print(ex.Message)
                                                                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                                                                mb.ShowDialog()
                                                            End Try

                                                            If .Item("M") IsNot DBNull.Value AndAlso Double.TryParse(.Item("M"), quadraturaDaFile) Then 'OrElse bChiudiRegistrazione Then
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
                                                                    iLine += 1
                                                                    drPnD("Line") = iLine
                                                                    drPnD("PostingDate") = DataRiga
                                                                    drPnD("AccrualDate") = DataRiga
                                                                    drPnD("AccRsn") = CauRiga
                                                                    drPnD("Account") = RiscAtt
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
                                                                    ' bChiudiRegistrazione = False
                                                                End If
                                                                'resetto e rivalorizzo
                                                                ireg = 0
                                                                quadratura = 0
                                                                quadraturaDaFile = 0
                                                                totDare = 0
                                                                totAvere = 0
                                                                'FIX forse va messa a zero 
                                                                iLine = 0

                                                            End If
                                                        End With
                                                        FLogin.prgCopy.PerformStep()
                                                        FLogin.prgCopy.Update()
                                                        Application.DoEvents()
                                                    Next

                                                    Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                                        cmdqry.ExecuteNonQuery()
                                                        Using bulkTrans = Connection.BeginTransaction
                                                            EditTestoBarra("Salvataggio: Prima Nota")
                                                            okBulk = ScriviBulk("MA_JournalEntries", dtPN, bulkTrans)
                                                            If Not okBulk Then someTrouble = True
                                                            EditTestoBarra("Salvataggio: Righe  Prima Nota")
                                                            okBulk = ScriviBulk("MA_JournalEntriesGLDetail", dtPND, bulkTrans)
                                                            If Not okBulk Then someTrouble = True
                                                            EditTestoBarra("Salvataggio: Movimenti Analitici")
                                                            okBulk = ScriviBulk("MA_CostAccEntries", dtMovAna, bulkTrans)
                                                            If Not okBulk Then someTrouble = True
                                                            EditTestoBarra("Salvataggio: Righe Movimenti Analitici")
                                                            okBulk = ScriviBulk("MA_CostAccEntriesDetail", dtMovAnaD, bulkTrans)
                                                            If Not okBulk Then someTrouble = True
                                                            EditTestoBarra("Salvataggio: Riferimenti incrociati")
                                                            okBulk = ScriviBulk("MA_CrossReferences", dtCR, bulkTrans)
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
                                                            Debug.Print("Aggiornamento Saldi contabili: " & irows.ToString & " record")
                                                            irows = adpMovAnaSaldi.Update(dtMovAnaSaldi)
                                                            'Result.AppendLine("Aggiornamento Saldi analitici: " & irows.ToString & " record")
                                                            Debug.Print("Aggiornamento Saldi analitici: " & irows.ToString & " record")

                                                        End If
                                                        cmdqry.CommandText = "DBCC TRACEOFF(610)"
                                                        cmdqry.ExecuteNonQuery()
                                                    End Using
                                                End Using
                                            End Using
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                        ' If Not someTrouble Then CreaAnalitica(dtPN, dtPND)
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                My.Application.Log.WriteEntry(ex.Message)
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
                someTrouble = True
            End Try

            If Not someTrouble Then
                'Scrivi Gli ID ( faccio solo a fine elaborazione)
                AggiornaID(IdType.PNota, idPn)
                AggiornaNonFiscalNumber(CodeType.PNota, Year(DataRiga), iRefNo)

                AggiornaID(IdType.MovAna, idMovAna)
                AggiornaNonFiscalNumber(CodeType.MovAna, Year(DataRiga), iRefNoAna)
            End If
        End If

        Return Not someTrouble

    End Function
    Private Sub RicalcolaPerc(dt As DataTable, id As Integer, tot As Double)
        Dim dvDoc As New DataView(dt, "EntryId=" & id, "Line", DataViewRowState.CurrentRows)
        Dim pSum As Double
        Try
            For i = 0 To dvDoc.Count - 1
                Dim am As Double = dvDoc(i).Item("Amount")
                Dim p As Double = If(tot = 0, 0, Math.Round((am / tot) * 100, 2))
                'In quanto posso NON scrivere delle righe questo tipo di ragionamento non funziona.
                'dvDoc(i).Item("Perc") = Math.Round(If(i = dvDoc.Count - 1, 100 - pSum, p), 2)
                dvDoc(i).Item("Perc") = Math.Round(p, 2)
                pSum += Math.Round(p, 2)
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

    End Sub
    Public Function AggiornaSaldoContabile(ByVal conto As String, anno As Short, mese As Short, isDebit As Boolean, valore As Double, vista As DataView) As Boolean
        Dim result As Boolean
        Dim found As Integer = vista.Find(conto)
        Try
            If found <> -1 Then
                With vista(found)
                    .BeginEdit()
                    If isDebit Then
                        .Item("Debit") += valore
                    Else
                        .Item("Credit") += valore
                    End If
                    .EndEdit()
                End With
            Else
                Dim r As DataRow = vista.Table.NewRow
                r.Item("Account") = conto
                r.Item("FiscalYear") = anno
                r.Item("BalanceYear") = anno
                r.Item("BalanceType") = 3145730
                r.Item("BalanceMonth") = mese
                If isDebit Then
                    r.Item("Debit") += valore
                Else
                    r.Item("Credit") += valore
                End If
                r.Item("Nature") = 9306112
                r.Item("Currency") = "EUR"
                r.Item("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                r.Item("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                vista.Table.Rows.Add(r)
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        Return result
    End Function

End Module

