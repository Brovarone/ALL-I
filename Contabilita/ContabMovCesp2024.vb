Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase
Module ContabMovCesp2024

    ''' <summary>
    ''' Creo la scrittura dei risconti in contabilità. Il file si deve chiamare MOVCESP
    ''' </summary>
    Public Function CreaMovimentoContabileDaMovimentoCespite2024(ByVal r As DataTable, ByVal withAnalitica As Boolean) As Boolean
        'Movimenti Contabili PURI - MA_JournalEntries
        'Righe - MA_JournalEntriesGLDetail
        'I vari conti che leggo vanno matchati con quelli nuovi

        'Colonne xls  
        'Gli importi sono sempre considerati in Dare
        'A = Data reg.
        'B = Causale ( da gestire)
        'E = Centro di Costo
        'F = numero doc
        'M = Cespite
        'O = Descrizione cespite
        'Q = Importo
        'R = Segno
        'Q = Conto pdc
        'R = Ricavo ( non serve)
        'U = import in caso di Vendita

        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim DataRiga As Date
        Dim errori As New StringBuilder()
        Dim avvisi As New StringBuilder()

        FLogin.prgCopy.Value = 1

        If r.Rows.Count > 0 Then
            FLogin.prgCopy.Maximum = r.Rows.Count
            FLogin.prgCopy.Step = 1
            DataRiga = MagoFormatta(r.Rows(1).Item("A"), GetType(DateTime), True).DataTempo
            'Identificatore Prima Nota
            Dim idPn As Integer = LeggiID(IdType.PNota)
            Dim iRefNo As Integer = LeggiNonFiscalNumber(CodeType.PNota, Year(DataRiga))
            'Identificatore Prima Nota Analitica
            Dim idMovAna As Integer = LeggiID(IdType.MovAna)
            Dim iRefNoAna As Integer = LeggiNonFiscalNumber(CodeType.MovAna, Year(DataRiga))

            Try
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
                                        Dim dvPNSaldi As New DataView(dtPNSaldi, "Nature=9306112 AND BalanceType = 3145730", "Account", DataViewRowState.CurrentRows)
                                        'Saldi Analitici 
                                        qrySaldi = "SELECT * FROM MA_CostCentersBalances"
                                        Using adpMovAnaSaldi As New SqlDataAdapter(qrySaldi, Connection)
                                            cbMar = New SqlCommandBuilder(adpMovAnaSaldi)
                                            adpMovAnaSaldi.UpdateCommand = cbMar.GetUpdateCommand(True)
                                            Dim dtMovAnaSaldi As New DataTable("MA_CostCentersBalances")
                                            adpMovAnaSaldi.Fill(dtMovAnaSaldi)
                                            Dim dvMovAnaSaldi As New DataView(dtMovAnaSaldi, "", "", DataViewRowState.CurrentRows)

                                            'Piano dei conti / Contropartite 
                                            Debug.Print("Popolo tabella contropartite")
                                            Using adp As New SqlDataAdapter("Select Account, ACGCode, PostableInCostAcc FROM MA_ChartOfAccounts", Connection)
                                                Dim dtCntrp As New DataTable("Contropartita")
                                                adp.Fill(dtCntrp)
                                                Dim dvCntrp As New DataView(dtCntrp, "", "ACGCode", DataViewRowState.CurrentRows)
                                                'Centro di costo
                                                Using adpCdC As New SqlDataAdapter("Select * FROM MA_CostCenters", Connection)
                                                    Dim dtCdc As New DataTable("Centri")
                                                    adpCdC.Fill(dtCdc)
                                                    Dim dvCdC As New DataView(dtCdc, "", "CostCenter", DataViewRowState.CurrentRows)
#End Region
#Region "Variabili scrittura"
                                                    Dim totDare As Decimal       ' Totale Dare della registrazione contabile
                                                    Dim totAvere As Decimal      ' Totale Avere della registrazione contabile
                                                    Dim isNewReg As Boolean = False ' Indica se la registrazione corrente è nuova
                                                    Dim irow As Integer = 0     ' Contatore delle righe del ciclo principale
                                                    Dim i As Integer = 0        ' Contatore generico per il ciclo
                                                    Dim ireg As Integer = 0     ' Contatore delle registrazioni contabili
                                                    Dim iNrRegistrazioni As Integer = 0 ' Numero totale di registrazioni contabili
                                                    Dim iLine As Integer = 0    ' Contatore delle righe di dettaglio della registrazione
                                                    Dim ModCont As String = ""  ' Modello contabile utilizzato nella registrazione
                                                    Dim CauRiga As String = ""  ' Causale contabile della riga
                                                    Dim quadratura As Decimal    ' Valore per verificare la quadratura della scrittura contabile
                                                    Dim drPn As DataRow = dtPN.NewRow ' Riga della tabella principale della registrazione contabile
                                                    Dim drPnD As DataRow = dtPND.NewRow() ' Riga della tabella di dettaglio della registrazione contabile
                                                    Dim cespiteCorrente As String = "" ' Identificativo del cespite corrente per il controllo di cambio registrazione
                                                    Dim isVendita As Boolean    ' Indica se si tratta di una registrazione di vendita
                                                    Dim ammbilInAttesa As Boolean = False
                                                    Dim tempRowAmmBil As DataRow
                                                    Dim fondoAmmFound As Boolean = False
                                                    Dim nota As String = ""     ' Nota associata alla registrazione contabile

#End Region
                                                    For irow = i To r.Rows.Count - 1
                                                        With r.Rows(irow)
                                                            'Escludo le ultime righe magari aggiunte per controlli
                                                            If Not String.IsNullOrWhiteSpace(.Item("M").ToString) Then
                                                                Debug.Print("riga: " & irow.ToString & " Cespite: " & .Item("M").ToString)
                                                                'Controllo alcune cose sulla riga corrente 
                                                                If .Item("M").ToString <> cespiteCorrente Then
                                                                    isNewReg = True
                                                                    If irow > 0 Then
                                                                        'Controllo quadratura
                                                                        If totAvere = totDare Then
                                                                        Else
                                                                            errori.AppendLine("Registrazione non quadra: rif" & drPn("RefNo").ToString)
                                                                        End If
                                                                        'Aggiorno la testa con quello che ho calcolato
                                                                        drPn("AccTpl") = ModCont
                                                                        drPn("TotalAmount") = Math.Round(If(totDare > totAvere, totDare, totAvere), 2)
                                                                        drPn("LastSubId") = iLine
                                                                        dtPN.Rows.Add(drPn)
                                                                    End If
                                                                End If

                                                                If isNewReg Then
                                                                    'Imposto check e resetto
                                                                    cespiteCorrente = .Item("M").ToString.Trim
                                                                    isNewReg = False
                                                                    ammbilInAttesa = False
                                                                    fondoAmmFound = False
                                                                    tempRowAmmBil = Nothing
                                                                    iLine = 0
                                                                    quadratura = 0
                                                                    'Creo la testa della registrazione Contabile
                                                                    drPn = dtPN.NewRow
                                                                    idPn += 1       'Aumento contatore
                                                                    iRefNo += 1     'Aumento contatore
                                                                    ireg += 1
                                                                    iNrRegistrazioni += 1
                                                                    If String.IsNullOrWhiteSpace(.Item("A")) Then avvisi.AppendLine("Cespite :" & cespiteCorrente & "senza Nr Doc")
                                                                    nota = "Cespite " & cespiteCorrente & " " & .Item("O").ToString & " Nr. Doc. " & .Item("A")
                                                                    DataRiga = MagoFormatta(.Item("A"), GetType(DateTime), True).DataTempo
                                                                    '''''''''''''''''''''''''''''''''
                                                                    'TESTA MA_JournalEntries'
                                                                    '''''''''''''''''''''''''''''''''
                                                                    drPn("PostingDate") = DataRiga
                                                                    drPn("RefNo") = Right(Year(DataRiga), 2) & "-" & iRefNo.ToString("00000")
                                                                    drPn("DocumentDate") = DataRiga
                                                                    drPn("DocNo") = .Item("F")
                                                                    drPn("JournalEntryId") = idPn
                                                                    drPn("AccrualDate") = DataRiga
                                                                    drPn("Currency") = "EUR"
                                                                    drPn("ValueDate") = DataRiga
                                                                    drPn("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                    drPn("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                End If
                                                                Dim nrRipetizioni As Byte = 1
                                                                isVendita = False
                                                                Select Case .Item("B").ToString.ToUpper
                                                                    Case "ELIMBIL", "ELIMPBIL"
                                                                        ModCont = "ELIMCESP"
                                                                        CauRiga = "GIROCONT"
                                                                        'Case "ELIMPBIL"
                                                                    Case "VENDBIL", "VENDPBIL"
                                                                        isVendita = True
                                                                        ModCont = "VENDCESP"
                                                                        CauRiga = "GIROCONT"
                                                                        'Case "VENDPBIL"
                                                                    Case "PLUSVB"
                                                                        CauRiga = "PLUSV"
                                                                    Case "SOPPASSB"
                                                                        CauRiga = "SOPPAS"
                                                                    Case "AMMBIL"
                                                                        CauRiga = "AMM"
                                                                        ammbilInAttesa = True
                                                                        tempRowAmmBil = r.Rows(irow)
                                                                        nrRipetizioni = 2
                                                                    Case "STFONDOB"
                                                                        CauRiga = "GIROCONT"
                                                                        fondoAmmFound = True
                                                                        nrRipetizioni = 2
                                                                    Case Else
                                                                        errori.AppendLine("Causale 'B' non trovata su nuova registrazione:" & .Item("B"))
                                                                End Select

                                                                'Creo il riferimento Cross Reference
                                                                'Origine = P.Nota Puri // Derivato =  Mov. Cespite
                                                                Dim drCR As DataRow = dtCR.NewRow
                                                                drCR = dtCR.NewRow
                                                                drCR("OriginDocType") = CrossReference.MovimentoCespite
                                                                drCR("OriginDocID") = .Item("W")
                                                                drCR("OriginDocSubID") = 0
                                                                drCR("OriginDocLine") = 0
                                                                drCR("DerivedDocType") = CrossReference.PnotaPuro
                                                                drCR("DerivedDocID") = idPn
                                                                drCR("DerivedDocSubID") = 0
                                                                drCR("DerivedDocLine") = 0
                                                                drCR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                drCR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                dtCR.Rows.Add(drCR)

                                                                'Ripeto il ciclo per la riga di ammortamento
                                                                For x = 1 To nrRipetizioni
                                                                    '''''''''''''''''''''''''''''''''
                                                                    'Righe MA_JournalEntriesGLDetail'
                                                                    '''''''''''''''''''''''''''''''''
                                                                    iLine += 1
                                                                    drPnD = dtPND.NewRow
                                                                    drPnD("JournalEntryId") = idPn
                                                                    drPnD("Line") = iLine
                                                                    drPnD("PostingDate") = DataRiga
                                                                    drPnD("AccrualDate") = DataRiga
                                                                    drPnD("AccRsn") = CauRiga
                                                                    drPnD("Notes") = nota
                                                                    'drPnD ("CodeType")= 5177344 ' Normale / Apertura / Assestamento
                                                                    Dim isDare As Boolean
                                                                    If x = 1 Then
                                                                        isDare = .Item("R").ToString.ToUpper.Equals("DARE")
                                                                    Else
                                                                        isDare = Not tempRowAmmBil.Item("R").ToString.ToUpper.Equals("DARE")
                                                                    End If

                                                                    Dim sConto As String = ""
                                                                    Dim c As String = .Item("S").ToString.ToUpper    'Conto 
                                                                    If TryTrovaContropartita(c, dvCntrp, sConto) Then
                                                                        drPnD("Account") = sConto
                                                                    Else
                                                                        Debug.Print("Conto senza corrispondenza: " & c)
                                                                        errori.AppendLine("Conto senza corrispondenza:" & c)
                                                                        MessageBox.Show("Impossibile continuare, conto senza corrispondenza:" & c)
                                                                        End
                                                                    End If

                                                                    drPnD("DebitCreditSign") = If(isDare, 4980736, 4980737)
                                                                    Dim imp As Decimal
                                                                    If isVendita Then
                                                                        imp = CDec(.Item("U"))
                                                                    Else
                                                                        imp = CDec(.Item("Q"))
                                                                    End If
                                                                    If fondoAmmFound Then
                                                                        If x = 2 Then
                                                                            imp = CDec(tempRowAmmBil.Item("Q"))
                                                                            drPnD("AccRsn") = "AMM"
                                                                        End If
                                                                        If Not ammbilInAttesa Then x = 2
                                                                    Else
                                                                        x = 2
                                                                    End If
                                                                    imp = Math.Round(imp, 2)
                                                                    drPnD("Amount") = imp
                                                                    drPnD("FiscalAmount") = imp
                                                                    quadratura += Math.Round(If(isDare, imp, -imp), 2)
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
                                                                    If withAnalitica Then
                                                                        'Scrivo analitica
                                                                        Try
                                                                            Dim iRegAna As Integer = 0
                                                                            Dim drAna As DataRow = dtMovAna.NewRow
                                                                            drCR = dtCR.NewRow

                                                                            Dim conF As Integer = dvCntrp.Find(drPnD("Account"))
                                                                            Dim isAnalitico As Boolean = dvCntrp(conF).Item("PostableInCostAcc") = "1"
                                                                            If isAnalitico Then
                                                                                ' Uso il datarow precedente
                                                                                With drPnD
                                                                                    'Creo la testa della registrazione Analitica
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
                                                                                    drAna("Notes") = Left(.Item("Notes"), 64)
                                                                                    drAna("EntryId") = idMovAna
                                                                                    drAna("JournalEntryId") = .Item("JournalEntryId")
                                                                                    drAna("CustSuppType") = CustSuppType.IgnoraIgnora
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
                                                                                    'Creo sempre solo 1 riga
                                                                                    Dim importo As Decimal = .Item("Amount")
                                                                                    Dim iLineMovAna As Integer = 0
                                                                                    Dim isDareAna = drAna("DebitCreditSign") = 8192000

                                                                                    Dim CdC As String = r.Rows(irow).Item("E")
                                                                                    Dim iCdcFound As Integer = dvCdC.Find(CdC)
                                                                                    If iCdcFound = -1 Then
                                                                                        Debug.Print("Centro di Costo senza corrispondenza: " & CdC)
                                                                                        My.Application.Log.WriteEntry("Centro di Costo senza corrispondenza:" & CdC)
                                                                                        MessageBox.Show("Impossibile continuare, centro di costo non presente:" & CdC)
                                                                                        End
                                                                                    End If

                                                                                    iLineMovAna += 1
                                                                                    Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                                                    drAnaD("EntryId") = idMovAna
                                                                                    drAnaD("Line") = iLineMovAna
                                                                                    drAnaD("Account") = .Item("Account")
                                                                                    drAnaD("PostingDate") = .Item("PostingDate")
                                                                                    drAnaD("AccrualDate") = .Item("PostingDate")
                                                                                    drAnaD("CodeType") = 7995393 ' Consuntivo
                                                                                    drAnaD("CostCenter") = CdC
                                                                                    drAnaD("HasCostCenter") = 1
                                                                                    drAnaD("Perc") = 100
                                                                                    drAnaD("DebitCreditSign") = .Item("DebitCreditSign")
                                                                                    drAnaD("Amount") = importo
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
                                                                                    AggiornaSaldoAnalitico(wAnaBal, isDareAna, drAnaD("Amount"), dvMovAnaSaldi)
                                                                                End With
                                                                                dtMovAna.Rows.Add(drAna)
                                                                            End If

                                                                        Catch ex As Exception
                                                                            Debug.Print(ex.Message)
                                                                            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                                                                            mb.ShowDialog()
                                                                        End Try
                                                                    End If
                                                                Next
                                                            End If
                                                        End With
                                                        AvanzaBarra()
                                                    Next
                                                    'Chiudo la registrazione
                                                    If Not isNewReg Then
                                                        'Aggiorno la testa con quello che ho calcolato
                                                        drPn("AccTpl") = ModCont
                                                        drPn("TotalAmount") = Math.Round(If(totDare > totAvere, totDare, totAvere), 2)
                                                        drPn("LastSubId") = iLine
                                                        dtPN.Rows.Add(drPn)
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
                                                            Debug.Print("Aggiornamento Saldi contabili: " & irows.ToString & " record")
                                                            If withAnalitica Then
                                                                irows = adpMovAnaSaldi.Update(dtMovAnaSaldi)
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
            'Scrivo i LOG
            If errori.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Errori ---" & Environment.NewLine & errori.ToString)
                FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
                Debug.Print(errori.ToString)
            End If
            If avvisi.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Avvisi ---" & Environment.NewLine & avvisi.ToString)
                FLogin.lstStatoConnessione.Items.Add("WARNING ! Ci sono degli avvisi : Controllare file di Log")
            End If

        End If

        Return Not someTrouble

    End Function

End Module
