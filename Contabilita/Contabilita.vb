Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase
Public Module Contabilita

    Private Const ModCont = "RISCONTI"
    Private Const CauRiga = "GIROCONT"
    Private Const RiscAtt = "1RIS001"
    'Private Const RiscPass = "2RIS001"
    Public Function CreaPNotaRisconti(ByVal r As DataTable, filtri As FiltroRisconti) As Boolean
        Return CreaPNotaRisconti(r, filtri.ScriviAnalitica, filtri.FormatoRidotto, filtri.Data)
    End Function
    ''' <summary>
    ''' Creo la scrittura dei risconti in contabilità. Il file si deve chiamare
    ''' </summary>
    ''' <param name="r">Righe</param>
    ''' <returns></returns>
    Public Function CreaPNotaRisconti(ByVal r As DataTable, ByVal withAnalitica As Boolean, Optional ByVal xlsRidotto As Boolean = False, Optional ByVal data As Date = Nothing) As Boolean
        'Movimenti Contabili PURI - MA_JournalEntries
        'Righe - MA_JournalEntriesGLDetail
        'I vari conti che leggo vanno matchati con quelli nuovi

        'Colonne xlsRidotto 
        'Gli importi sono sempre considerati in Dare
        'A = Conto
        'B = Descrizione conto ( non usata)
        'C = Importo
        'D = Nota riga PNota

        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        'todo: aggiungere form richiesta data
        Dim DataRiga As Date
        If data = Nothing Then
            DataRiga = MagoFormatta("20230101", GetType(DateTime)).DataTempo
        Else
            DataRiga = data
        End If
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
#Region "Schema E Tabelle"
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
                                                If xlsRidotto Then dvCntrp.Sort = "Account"
                                                Using adpCdC As New SqlDataAdapter("Select * FROM MA_CostCenters", Connection)
                                                    Dim dtCdc As New DataTable("Centri")
                                                    adpCdC.Fill(dtCdc)
                                                    Dim dvCdC As New DataView(dtCdc, "", "CostCenter", DataViewRowState.CurrentRows)
#End Region
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
                                                            Dim nota As String = If(xlsRidotto, .Item("D").ToString, .Item("L").ToString & " " & .Item("B").ToString & " " & MagoFormatta(.Item("A"), GetType(DateTime)).sDataSlash)
                                                            drPnD("Notes") = nota
                                                            'drPnD ("CodeType")= 5177344 ' Normale / Apertura / Assestamento
                                                            Dim isDare As Boolean = True
                                                            Dim sConto As String = ""
                                                            If xlsRidotto Then
                                                                sConto = .Item("A").ToString
                                                                Dim iCP As Integer = dvCntrp.Find(sConto)
                                                                If iCP = -1 Then
                                                                    Debug.Print("Conto senza corrispondenza: " & sConto)
                                                                    My.Application.Log.WriteEntry("Conto senza corrispondenza:" & sConto)
                                                                    MessageBox.Show("Impossibile continuare, conto senza corrispondenza:" & sConto)
                                                                    End
                                                                Else
                                                                    drPnD("Account") = sConto
                                                                End If
                                                            Else
                                                                Dim c As String = .Item("H")
                                                                If TryTrovaContropartita(c, dvCntrp, sConto) Then
                                                                    drPnD("Account") = sConto
                                                                Else
                                                                    Debug.Print("Conto senza corrispondenza: " & c)
                                                                    My.Application.Log.WriteEntry("Conto senza corrispondenza:" & c)
                                                                    MessageBox.Show("Impossibile continuare, conto senza corrispondenza:" & c)
                                                                    End
                                                                End If
                                                            End If

                                                            drPnD("DebitCreditSign") = If(isDare, 4980736, 4980737)
                                                            Dim imp As Double = If(xlsRidotto, .Item("C"), .Item("G"))  ' Math.Round(CDbl(.Item("Imponibile")), 2)
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
                                                            'todo checkanalitico
                                                            If withAnalitica Then
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
                                                            End If
                                                            'Chiudo le regitrazione
                                                            Dim bChiudi As Boolean = False
                                                            If xlsRidotto Then
                                                                'Faccio scritture da 100 righe
                                                                If iLine = 99 Then bChiudi = True
                                                            Else
                                                                If .Item("M") IsNot DBNull.Value AndAlso Double.TryParse(.Item("M"), quadraturaDaFile) Then bChiudi = True
                                                            End If

                                                            If bChiudi Then
                                                                If Not isNewReg Then
                                                                    'Aggiorno la testa con quello che ho calcolato
                                                                    drPn("TotalAmount") = Math.Round(If(totDare > totAvere, totDare, totAvere), 2)
                                                                    If Not xlsRidotto AndAlso drPn("TotalAmount") <> quadraturaDaFile Then
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
                                                                iLine = 0

                                                            End If
                                                        End With
                                                        AvanzaBarra()
                                                    Next
                                                    'Chiudo la registrazione
                                                    If xlsRidotto AndAlso Not isNewReg Then
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
                                                        ' isNewReg = True
                                                        ' bChiudiRegistrazione = False
                                                    End If

                                                    Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                                        cmdqry.ExecuteNonQuery()
                                                        Using bulkTrans = Connection.BeginTransaction
                                                            EditTestoBarra("Salvataggio: Prima Nota")
                                                            okBulk = ScriviBulk("MA_JournalEntries", dtPN, bulkTrans, Connection)
                                                            If Not okBulk Then someTrouble = True
                                                            EditTestoBarra("Salvataggio: Righe  Prima Nota")
                                                            okBulk = ScriviBulk("MA_JournalEntriesGLDetail", dtPND, bulkTrans, Connection)
                                                            If Not okBulk Then someTrouble = True
                                                            If withAnalitica Then
                                                                EditTestoBarra("Salvataggio: Movimenti Analitici")
                                                                okBulk = ScriviBulk("MA_CostAccEntries", dtMovAna, bulkTrans, Connection)
                                                                If Not okBulk Then someTrouble = True
                                                                EditTestoBarra("Salvataggio: Righe Movimenti Analitici")
                                                                okBulk = ScriviBulk("MA_CostAccEntriesDetail", dtMovAnaD, bulkTrans, Connection)
                                                                If Not okBulk Then someTrouble = True
                                                            End If
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
                                                        If Not someTrouble Then
                                                            Dim irows As Integer
                                                            irows = adpPNSaldi.Update(dtPNSaldi)
                                                            'Result.AppendLine("Aggiornamento Vista Clienti: " & irows.ToString & " record")
                                                            Debug.Print("Aggiornamento Saldi contabili: " & irows.ToString & " record")
                                                            If withAnalitica Then
                                                                irows = adpMovAnaSaldi.Update(dtMovAnaSaldi)
                                                                'Result.AppendLine("Aggiornamento Saldi analitici: " & irows.ToString & " record")
                                                                Debug.Print("Aggiornamento Saldi analitici: " & irows.ToString & " record")
                                                            End If

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
                If withAnalitica Then
                    AggiornaID(IdType.MovAna, idMovAna)
                    AggiornaNonFiscalNumber(CodeType.MovAna, Year(DataRiga), iRefNoAna)
                End If
            End If
        End If

        Return Not someTrouble

    End Function
    Private Sub RicalcolaPerc(dt As DataTable, id As Integer, tot As Double)
        Dim dvDoc As New DataView(dt, "EntryId=" & id, "Line", DataViewRowState.CurrentRows)
        Try
            For i = 0 To dvDoc.Count - 1
                Dim am As Double = dvDoc(i).Item("Amount")
                Dim p As Double = If(tot = 0, 0, Math.Round((am / tot) * 100, 2))
                dvDoc(i).Item("Perc") = Math.Round(p, 2)
                'In quanto posso NON scrivere delle righe questo tipo di ragionamento non funziona.
                'Dim pSum As Double
                'pSum += Math.Round(p, 2)
                'dvDoc(i).Item("Perc") = Math.Round(If(i = dvDoc.Count - 1, 100 - pSum, p), 2)
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

