Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports System.Text
Imports System.Text.RegularExpressions

Module Fatture
    'TODO: creare dei parametri: vedere qui' per modificare setting attuali http://www.blackbeltcoder.com/Articles/winforms/a-custom-settings-class-for-winforms
    ''' <summary>
    ''' 12/04/2021 Usato per determinare se aggiornare o meno codice fiscale e P.iva
    ''' </summary>
    Private Const UpdatePIvaCodFisc As Boolean = False
    ''' <summary>
    ''' 08/07/2021 Usato per determinare se aggiornare o meno email
    ''' </summary>
    Private Const UpdateEmailCliente As Boolean = False
    ''' <summary>
    ''' 12/04/2022 Usato per determinare se aggiornare o meno la Provincia
    ''' </summary>
    Private Const UpdateProvincia As Boolean = False
    ''' <summary>
    ''' 12/01/2023 Numero minimo colonne previste dal CSV
    ''' </summary>
    Private Const NrColonneCsv As Integer = 241

    Public Function FattEleCSV(dts As DataSet, Optional bConIntestazione As Boolean = False) As Boolean
        'QUESTO CSV HA I VALORI MONETARI CON IL PUNTO
        'QUANDO PASSO UN DOUBLE DEVO FARE ATTENZIONE
        'Colonne BJ (qta )  arriva con punto e 3 zeri 
        'BK (val unit )  con punto e 5 zeri)
        'Documenti di vendita - MA_SaleDoc
        'Righe - MA_SaleDocDetail
        'Totali - MA_SaleDocSummary
        'Castelletto - MA_SaleDocTaxSummary
        ' - MA_SaleDocShipping
        'Fatture elettroniche ( devono esssere su inviato)
        'Leggo il valore ad oggi dei contatori iva dei registri ( V1, V2, etc)

        'Ogni volta devo controllare se esiste il cliente altrimenti crearlo leggendo le info da 
        'FTPA300 ( ANAGRAFICA E DATI FE) info sede destinazione fattura
        'CLIENORD (CATEGORIA, ABI, CAB, TELEFONI): riporta info sede legale

        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        EditTestoBarra("Creo Fatture")
        FLogin.prgCopy.Value = 1
        Dim idAndNumber As New StringBuilder()
        Dim loggingTxt As String = "Si"
#Region "Gestione Logs xml"
        'Gestione Logs xml
        Dim log As New MyLogs With {.Nome = "Importazione_Fatture"}
        Dim l_Bulk As New MyLogRegistry With {.Nome = "Bulk", .Descrizione = "Inserimento Dati", .Origine = 1}
        Dim l_Err As New MyLogRegistry With {.Nome = "Errori", .Descrizione = "Errori", .Ordine = 1, .StampaCodice = True}
        Dim l_Warn As New MyLogRegistry With {.Nome = "Warning", .Descrizione = "Warnings. Queste modifiche non vengono salvate", .Ordine = 2}
        Dim l_Avv As New MyLogRegistry With {.Nome = "Avvisi", .Descrizione = "Avvisi", .Ordine = 3, .StampaCodice = True}
        Dim l_Agg As New MyLogRegistry With {.Nome = "Aggiornamenti", .Descrizione = "Aggiornamenti anagrafici (NUOVO VALORE ) [VECCHIO VALORE]", .Ordine = 4}
        'Dim l_Sicur As  New MyLogRegistry With {.Nome = "Sicuritalia", .Descrizione = "", .Ordine = 1}
        Dim l_NewBankCli As New MyLogRegistry With {.Nome = "NewBankCli", .Descrizione = "Nuove Banche Clienti (completare le informazioni su Mago)", .Ordine = 2}
        Dim l_NewCli As New MyLogRegistry With {.Nome = "NewClienti", .Descrizione = "Nuovi clienti", .Ordine = 2}
        Dim l_NewSedi As New MyLogRegistry With {.Nome = "NewSedi", .Descrizione = "Nuove Sedi", .Ordine = 2}
        Dim l_Ids As New MyLogRegistry With {.Nome = "Ids", .Descrizione = "Id e Numeratri", .Origine = 1}
        log.Corpo.Add(l_Bulk)
        log.Corpo.Add(l_Err)
        log.Corpo.Add(l_Warn)
        log.Corpo.Add(l_Avv)
        log.Corpo.Add(l_Agg)
        log.Corpo.Add(l_NewBankCli)
        log.Corpo.Add(l_NewCli)
        log.Corpo.Add(l_NewSedi)
        log.Corpo.Add(l_Ids)
#End Region
        Dim errori As New StringBuilder()  ' Ultimo = 21
        Dim avvisi As New StringBuilder()  ' Ultimo = 12  / 50
        Dim aggiornamenti As New StringBuilder()
        Dim sicuritalia As New StringBuilder()
        Dim bulkMessage As New StringBuilder()
        Dim warnings As New StringBuilder() ' Gestisce gli aggiornamenti di P.iva e Cod. fisc.

        Dim totDoc(1) As Integer ' 0= Fatture 1 = Note di Credito
        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim bNoCondPag As Boolean
        Dim bNoBanca As Boolean
        '09/02/2021
        '(Deprecato) Dim listOfSEPA as New List(Of String)
        Dim listOfNewClienti As New List(Of String)
        Dim listOfNewSedi As New List(Of String)
        Dim listOfNewBancheCli As New List(Of String)
        'Inizializzo un datatable al file xls e un datarow con tutte le righe
        Dim irxls As Integer = 0
        Dim i As Integer = 0
        If bConIntestazione Then i = 1 ' Se c'e' l'intestazione parto dalla seconda riga
        Dim dtXLS As DataTable = dts.Tables("Foglio1")
        If dtXLS.Rows.Count > 0 AndAlso dtXLS.Columns.Count < NrColonneCsv Then
            Dim m As String
            m = "OPERAZIONE INTERROTTA" & Environment.NewLine & "Numero colonne non congruo" & Environment.NewLine & "Attese " & NrColonneCsv.ToString & " trovate " & dtXLS.Columns.Count
            My.Application.Log.DefaultFileLogWriter.WriteLine(m)
            FLogin.lstStatoConnessione.Items.Add("OPERAZIONE INTERROTTA")
            FLogin.lstStatoConnessione.Items.Add("Numero colonne non congruo. Attese " & NrColonneCsv.ToString & " trovate " & dtXLS.Columns.Count)
            someTrouble = True

        End If
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Length > 0 Then
            'Identificatore  Documento
            Debug.Print("Estraggo ID")
            EditTestoBarra("Estraggo gli ID")
            Dim idDoc As Integer = LeggiID(IdType.DocVend, loggingTxt)
            idAndNumber.AppendLine(loggingTxt)
            l_Ids.Add("I01", loggingTxt)
            'Ritorna array con Ultimo numero Salvato, {numero da valorizzare a seguito lettura excel}, Codice registro
            Dim annualita As Short = Short.Parse(Left(drXLS(i).Item("Q").ToString, 4))
            Dim nrRegIva As String(,) = LeggiRegistriIva(annualita, loggingTxt)
            idAndNumber.AppendLine(loggingTxt)
            l_Ids.Add("I01", loggingTxt)
            FLogin.prgCopy.Maximum = drXLS.Length
            FLogin.prgCopy.Step = 1
            Dim idCausale As Integer = 0 ' usato per l'id riga della Causale nelle fatture elettroniche
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Fatture")
                Using dtDoc As DataTable = CaricaSchema("MA_SaleDoc")
                    EditTestoBarra("Carico Schema: Righe")
                    Using dtDocDet As DataTable = CaricaSchema("MA_SaleDocDetail")
                        Dim dvDocDet As New DataView(dtDocDet, "", "SaleDocId", DataViewRowState.CurrentRows)
                        EditTestoBarra("Carico Schema: Dati accessori")
                        Using dtDocSumm As DataTable = CaricaSchema("MA_SaleDocSummary")
                            Using dtEI As DataTable = CaricaSchema("MA_EI_ITDocAdditionalData")
                                Using dtBancheCli As DataTable = CaricaSchema("MA_Banks", True, True, "Select ABI, CAB, Bank, IsACompanyBank, Description , TBCreatedID, TBModifiedID FROM MA_Banks where IsACompanyBank=0")
                                    Dim dvBancheCli As New DataView(dtBancheCli, "", "Bank", DataViewRowState.CurrentRows)
                                    Dim dtBancheCliNew As DataTable = dtBancheCli.Clone
                                    'Creo un dataset con le anagrafiche Clienti
                                    Using dsClienti As New DataSet
                                        dsClienti.Tables.Add(CaricaSchema("MA_CustSupp", True, True, "SELECT * FROM MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente))
                                        dsClienti.Tables.Add(CaricaSchema("MA_CustSuppCustomerOptions", True, True, "SELECT * FROM MA_CustSuppCustomerOptions"))
                                        dsClienti.Tables.Add(CaricaSchema("MA_CustSuppNaturalPerson", True, True, "SELECT * FROM MA_CustSuppNaturalPerson WHERE CustSuppType=" & CustSuppType.Cliente))
                                        dsClienti.Tables.Add(CaricaSchema("MA_CustSuppBranches", True, True, "SELECT * FROM MA_CustSuppBranches WHERE CustSuppType=" & CustSuppType.Cliente))
                                        dsClienti.Tables.Add(CaricaSchema("MA_SDDMandate", True, True, "SELECT * FROM MA_SDDMandate"))
                                        Dim isNewCliente As Boolean = False
                                        Dim isTipoSicuritalia As Boolean = False
                                        ' Ciclo le righe del file XLS
                                        'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                                        Dim bContratto As Boolean
                                        Dim sContratto(2) As String ' array con le informazioni di contratto
                                        Dim iNoContratto As Integer
                                        'Per dati aggiuntivi Sicuritalia
                                        Dim iLinea As Integer = 0
                                        Dim iSubLinea As Integer = 0
                                        'La tabella xls e' strutturata diversamente controllo i TIREH
                                        'TIREH Colonna G = 1=Testata 3=Riga Fattura 4o6=Riga descrittiva 9=Riepilogo fattura
                                        'SEQUH Colonna I = contatore righe ma forse non serve
                                        EditTestoBarra("Caricamento tabelle di conversione")
                                        'Creo le dataview 
                                        Using da As New SqlDataAdapter("SELECT Payment, ACGCode, InstallmentType FROM MA_PaymentTerms", Connection)
                                            'per le condizioni di pagamento 
                                            Dim dtCP As New DataTable("CondPag")
                                            da.Fill(dtCP)
                                            Dim dvCP As New DataView(dtCP, "", "ACGCode", DataViewRowState.CurrentRows)
                                            Dim isRimessaDiretta As Boolean
                                            'per le contropartite 
                                            Dim cmd As New SqlCommand("Select Account, ACGCode FROM MA_ChartOfAccounts", Connection)
                                            da.SelectCommand = cmd
                                            Dim dtCntrp As New DataTable("Contropartita")
                                            da.Fill(dtCntrp)
                                            Dim dvCntrp As New DataView(dtCntrp, "", "ACGCode", DataViewRowState.CurrentRows)
                                            'Per le banche Azienda NON disattive
                                            cmd = New SqlCommand("Select * FROM MA_Banks where IsACompanyBank=1 AND Disabled=0", Connection)
                                            da.SelectCommand = cmd
                                            Dim dtBanche As New DataTable("Banche")
                                            da.Fill(dtBanche)
                                            Dim dvBanche As New DataView(dtBanche, "", "ABI,CAB,PreferredCA", DataViewRowState.CurrentRows)
                                            Dim aBanca(2) As String ' Array contenente ABI, CAB  c/c preferenziale
                                            'per i Codici Iva 
                                            cmd = New SqlCommand("Select TaxCode, ACGCode, ExemptInvoice FROM MA_TaxCodes", Connection)
                                            da.SelectCommand = cmd
                                            Dim dtTax As New DataTable("CodIva")
                                            da.Fill(dtTax)
                                            Dim dvTax As New DataView(dtTax, "", "ACGCode", DataViewRowState.CurrentRows)
                                            'per i Default Vendite
                                            cmd = New SqlCommand("Select InvoiceAccTpl, AccompanyingInvoiceAccTpl, EUInvoiceAccTpl, CreditNoteAccTpl, EUCreditNoteAccTpl FROM MA_UserDefaultSales WHERE Branch = '*' AND WorkerID = 0", Connection)
                                            da.SelectCommand = cmd
                                            Dim dtDefVendite As New DataTable("DefVendite")
                                            da.Fill(dtDefVendite)
                                            'per gli ISO Stati 
                                            cmd = New SqlCommand("Select ISOCountryCode, EUCountry FROM MA_ISOCountryCodes", Connection)
                                            da.SelectCommand = cmd
                                            Dim dtISO As New DataTable("ISO")
                                            da.Fill(dtISO)
                                            Dim dvISO As New DataView(dtISO, "", "ISOCountryCode", DataViewRowState.CurrentRows)
                                            'per l'anagrafica Cliente 
                                            Dim dvClienOrd As New DataView(dts.Tables("CLIENORD"), "", "AF", DataViewRowState.CurrentRows)
                                            Using adpCF As New SqlDataAdapter("Select * FROM MA_CustSupp Where CustSuppType=" & CustSuppType.Cliente, Connection)
                                                Dim cbMar = New SqlCommandBuilder(adpCF)
                                                adpCF.UpdateCommand = cbMar.GetUpdateCommand(True)
                                                Dim dvClienti As New DataView(dsClienti.Tables("MA_CustSupp"), "", "CustSupp", DataViewRowState.CurrentRows)
                                                Dim dtClientiNew As DataTable = dsClienti.Tables("MA_CustSupp").Clone
                                                'Per gli altri dati
                                                Using adpCliOpt As New SqlDataAdapter("Select * FROM MA_CustSuppCustomerOptions Where CustSuppType=" & CustSuppType.Cliente, Connection)
                                                    cbMar = New SqlCommandBuilder(adpCliOpt)
                                                    adpCliOpt.UpdateCommand = cbMar.GetUpdateCommand(True)
                                                    Dim dvCliOpt As New DataView(dsClienti.Tables("MA_CustSuppCustomerOptions"), "", "Customer", DataViewRowState.CurrentRows)
                                                    Dim dtCliOptNew As DataTable = dsClienti.Tables("MA_CustSuppCustomerOptions").Clone
                                                    Dim dtCliNatPersNew As DataTable = dsClienti.Tables("MA_CustSuppNaturalPerson").Clone
                                                    'Per i Mandati SSD/RID
                                                    Using dtSSDNew As DataTable = dsClienti.Tables("MA_SDDMandate").Clone
                                                        EditTestoBarra("Carico Schema: Mandati SSD")
                                                        Dim dvSSD As New DataView(dsClienti.Tables("MA_SDDMandate"), "", "Customer", DataViewRowState.CurrentRows)
                                                        'per le Sedi 
                                                        Using adpCliSedi As New SqlDataAdapter("Select * FROM MA_CustSuppBranches Where CustSuppType=" & CustSuppType.Cliente, Connection)
                                                            cbMar = New SqlCommandBuilder(adpCliSedi)
                                                            adpCliSedi.UpdateCommand = cbMar.GetUpdateCommand(True)
                                                            Dim dvSedi As New DataView(dsClienti.Tables("MA_CustSuppBranches"), "", "CustSupp, IPACode", DataViewRowState.CurrentRows)
                                                            Dim dtSediNew As DataTable = dsClienti.Tables("MA_CustSuppBranches").Clone

                                                            EditTestoBarra("Scrittura documenti in corso...")
                                                            For irxls = i To drXLS.Length - 1
#Region "Definizione Datarows"
                                                                Dim drDoc As DataRow
                                                                Dim drDocDet As DataRow
                                                                Dim drDocSumm As DataRow
                                                                Dim drEI As DataRow
                                                                Dim drSSD As DataRow
                                                                Dim drCli As DataRow
                                                                Dim drCliOpt As DataRow
                                                                Dim drCliNatPers As DataRow
                                                                Dim drSedi As DataRow
#End Region
                                                                With drXLS(irxls)
                                                                    'TIREH Colonna G = 1=Testata 3=Riga Fattura 6=Riga descrittiva 9=Riepilogo fattura
                                                                    Select Case .Item("G").ToString
                                                                        Case "1" 'Testata ovvero nuova Fattura
                                                                            Debug.Print("Riga " & .Item("I").ToString & " Doc: " & .Item("O").ToString & " Cliente: " & .Item("AA").ToString)
                                                                            'Resetto questo check
                                                                            isNewCliente = False
                                                                            isTipoSicuritalia = False
                                                                            idCausale = 0
                                                                            drDoc = dtDoc.NewRow
                                                                            idDoc += 1 ' Incremento Id
                                                                            bContratto = False 'Lo uso per trovare le righe contratto
                                                                            Erase sContratto
                                                                            ReDim sContratto(2)
                                                                            iLinea = 0
                                                                            iSubLinea = 0
#Region "Controllo Cliente New/Update"
                                                                            'Controllo se il cliente esiste
                                                                            Dim iCliFound As Integer = dvClienti.Find(.Item("AA").ToString)
                                                                            Dim iCliOptFound As Integer = dvCliOpt.Find(.Item("AA").ToString)
                                                                            Dim iClienOrdFound = dvClienOrd.Find(.Item("AA").ToString)
                                                                            If iCliFound = -1 Then
                                                                                isNewCliente = True
                                                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                                                                'Creo nuovo cliente passando informazioni dalla fattura ed dal CLIENORD
                                                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                                                                Debug.Print("Nuovo cliente: " & .Item("AA").ToString)
                                                                                listOfNewClienti.Add(.Item("AA").ToString & ": " & .Item("AB").ToString)
                                                                                'TAG l_NewCli.Add("N01", .Item("AA").ToString & ": " & .Item("AB").ToString, LogLevel.None, .Item("AA").ToString)
                                                                                l_NewCli.Add("N01", .Item("AA").ToString & ": " & .Item("AB").ToString)
                                                                                drCli = dtClientiNew.NewRow
                                                                                drCliOpt = dtCliOptNew.NewRow
                                                                                drCli("CustSupp") = .Item("AA").ToString
                                                                                drCli("CustSuppType") = CustSuppType.Cliente
                                                                                Dim sRagSoc As String = dvClienOrd(iClienOrdFound).Item("F").ToString
                                                                                If dvClienOrd(iClienOrdFound).Item("E").ToString = "1" Then sRagSoc = If(String.IsNullOrEmpty(dvClienOrd(iClienOrdFound).Item("G").ToString), sRagSoc, sRagSoc & Environment.NewLine & dvClienOrd(iClienOrdFound).Item("G").ToString)
                                                                                drCli("CompanyName") = sRagSoc '("AB" della fattura)
                                                                                drCli("Address") = dvClienOrd(iClienOrdFound).Item("I").ToString '("AC" della fattura)
                                                                                drCli("City") = dvClienOrd(iClienOrdFound).Item("J").ToString '("AE" della fattura)
                                                                                drCli("County") = dvClienOrd(iClienOrdFound).Item("K").ToString '("AF" della fattura)
                                                                                drCli("Region") = Get_Regione(dvClienOrd(iClienOrdFound).Item("K").ToString)
                                                                                Dim iCAP As Integer
                                                                                If Integer.TryParse(dvClienOrd(iClienOrdFound).Item("L").ToString, iCAP) Then
                                                                                    drCli("ZIPCode") = iCAP.ToString("00000") '("AE" della fattura)
                                                                                End If
                                                                                drCli("Telephone1") = dvClienOrd(iClienOrdFound).Item("S").ToString
                                                                                drCli("Fax") = dvClienOrd(iClienOrdFound).Item("T").ToString
                                                                                drCli("ISOCountryCode") = Left(dvClienOrd(iClienOrdFound).Item("M").ToString, 2).ToUpper
                                                                                drCli("CustSuppKind") = TrovaNaturaCliFor(drCli("ISOCountryCode").ToString, dvISO, "Cliente: " & .Item("AA").ToString & " Doc. nr: " & .Item("O").ToString & Environment.NewLine, errori)
                                                                                drCli("FiscalCode") = dvClienOrd(iClienOrdFound).Item("O").ToString '("AI" della fattura)
                                                                                drCli("TaxIdNumber") = dvClienOrd(iClienOrdFound).Item("N").ToString '("AJ" della fattura)
                                                                                drCli("Currency") = If(.Item("R").ToString = "EUR", "EUR", .Item("O").ToString)
                                                                                drCli("NaturalPerson") = If(dvClienOrd(iClienOrdFound).Item("E").ToString = "1", "0", "1")
                                                                                If drCli("NaturalPerson") = "1" Then
                                                                                    Dim cognomeNome As String() = Split(dvClienOrd(iClienOrdFound).Item("G").ToString, "*")
                                                                                    If UBound(cognomeNome) <> -1 Then
                                                                                        Dim ok As Boolean = False
                                                                                        If cognomeNome.Length = 2 Then
                                                                                            ok = True
                                                                                        ElseIf cognomeNome.Length > 2 Then
                                                                                            'Cognomi composti controllare su Mago
                                                                                            avvisi.AppendLine("ANC1: Controllare correttezza Nome e Cognome: Cliente " & .Item("AA").ToString & ": " & .Item("AB").ToString)
                                                                                            ok = True
                                                                                        Else
                                                                                            'Assenza carattere split
                                                                                            errori.AppendLine("ENC1: Impossibile determinare Nome e Cognome: Cliente " & .Item("AA").ToString & ": " & .Item("AB").ToString)
                                                                                            ok = False
                                                                                        End If
                                                                                        If ok Then
                                                                                            drCliNatPers = dtCliNatPersNew.NewRow
                                                                                            drCliNatPers("CustSuppType") = CustSuppType.Cliente
                                                                                            drCliNatPers("CustSupp") = .Item("AA").ToString
                                                                                            drCliNatPers("Name") = cognomeNome(1)
                                                                                            drCliNatPers("LastName") = cognomeNome(0)
                                                                                            drCliNatPers("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                            drCliNatPers("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                                            dtCliNatPersNew.Rows.Add(drCliNatPers)
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                                'Deprecata
                                                                                'drCli("Account") = "1CLI" & Int16.Parse((TrovaFiliale(.Item("AA").ToString, False))).ToString("000")
                                                                                drCli("Account") = "1CLI001"
                                                                                drCli("Presentation") = 1376260
                                                                                drCli("MailSendingType") = 12451840 'Tipo invio mail ( A: 12451841, non inviare: 12451840)
                                                                                ''''''''''''''''''''''
                                                                                'Fattura Elettronica
                                                                                ''''''''''''''''''''''
                                                                                drCli("ElectronicInvoicing") = "1"
                                                                                Dim isPA As Boolean = .Item("Z").ToString.Length = 6
                                                                                If isPA Then
                                                                                    drCliOpt("PublicAuthority") = "1"
                                                                                    drCliOpt("PASplitPayment") = "1"
                                                                                End If
                                                                                If IsDeprecated AndAlso dvClienOrd(iClienOrdFound).Item("P").ToString() = "A" Then 'CLPAR
                                                                                    '05/10/2021 : era stata aggiunta il 14/07/2021, ma non era cosi' vero che la lettera fosse giusta
                                                                                    'Il campo classe cliente =  A identifica una Pubblica Amministrazione
                                                                                    drCliOpt("PublicAuthority") = "1"
                                                                                    drCliOpt("PASplitPayment") = "1"
                                                                                End If

                                                                                drCli("IPACode") = If(.Item("Z").ToString = "0", "0000000", .Item("Z").ToString)
                                                                                Dim sPec As String() = Split(.Item("HI").ToString, ";")
                                                                                If Len(sPec(0)) > 64 Then
                                                                                    errori.AppendLine("E06: PEC troppo lunga su Cliente: " & .Item("AA").ToString & " dato non salvato")
                                                                                    l_Err.Add("E06", "PEC troppo lunga su Cliente: " & .Item("AA").ToString & " dato non salvato")
                                                                                Else
                                                                                    drCli("EICertifiedEMail") = sPec(0).ToLower
                                                                                End If
                                                                                drCli("SendByCertifiedEmail") = If(drCli("IPACode") = "0000000" AndAlso Not String.IsNullOrWhiteSpace(drCli("EICertifiedEMail")), "1", "0")
                                                                                drCli("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                drCli("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                                                'Options
                                                                                drCliOpt("Customer") = .Item("AA").ToString
                                                                                drCliOpt("CustSuppType") = CustSuppType.Cliente
                                                                                drCliOpt("Area") = TrovaFiliale(.Item("AA").ToString, True) ' Filiale / Ara di Vendita
                                                                                drCliOpt("UseReqForPymt") = "1"
                                                                                Dim cat As String = dvClienOrd(iClienOrdFound).Item("C").ToString
                                                                                Select Case cat
                                                                                    Case "O"
                                                                                        cat = "OR"
                                                                                    Case "S"
                                                                                        cat = "SP"
                                                                                    Case Else
                                                                                        cat = "OR"
                                                                                End Select
                                                                                drCliOpt("Category") = cat ' "OR" 'CATEG
                                                                                drCliOpt("CustomerClassification") = dvClienOrd(iClienOrdFound).Item("P").ToString 'CLPAR
                                                                                drCliOpt("DebitStampCharges") = "1" ' Bolli SPMAF
                                                                                drCliOpt("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                drCliOpt("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                                            Else
                                                                                'Il cliente esiste ! Devo preoccuparmi di aggiornare la sua anagrafica
                                                                                Dim myLogsClienord As New MyLogsString
                                                                                Dim myLogs As New MyLogsString
                                                                                '08/04/2021
                                                                                'Aggiornare sempre anagrafica cliente da ClienOrd
                                                                                If iClienOrdFound <> -1 Then
                                                                                    myLogsClienord = AggiornaAnagraficaDaClienOrd(drXLS(irxls), dvClienOrd(iClienOrdFound), dvClienti(iCliFound), dvCliOpt(iCliOptFound))
                                                                                Else
                                                                                    errori.AppendLine("E17: Codice Cliente non presente in CLIENORD " & .Item("AA").ToString)
                                                                                    l_Err.Add("E17", "Codice Cliente non presente in CLIENORD " & .Item("AA").ToString)
                                                                                End If

                                                                                'Controllo se sulla Scheda "Comunicazioni digitali ho un IPA "valida"
                                                                                Dim isIPAClienteBlankOrZero As Boolean = String.IsNullOrWhiteSpace(dvClienti(iCliFound)("IPACode").ToString.Trim("0"))
                                                                                ' e se e' uguale al file FTPA300
                                                                                Dim bSameIPATesta As Boolean = .Item("Z").ToString = dvClienti(iCliFound).Item("IPACode")
                                                                                Dim bSameRifAmmTesta As Boolean = .Item("HE").ToString = dvClienti(iCliFound).Item("AdministrationReference")
                                                                                Dim bSameAddressTesta As Boolean = String.Equals(Regex.Replace(.Item("AC").ToString, "\s", ""), Regex.Replace(dvClienti(iCliFound).Item("Address"), "\s", ""), StringComparison.OrdinalIgnoreCase)

                                                                                If Not bSameIPATesta AndAlso Not isIPAClienteBlankOrZero AndAlso String.IsNullOrWhiteSpace(.Item("Z").ToString) Then
                                                                                    errori.AppendLine("E03: Cliente" & .Item("AA").ToString & " con IPA in anagrafica " & dvClienti(iCliFound)("IPACode") & " MA assente sul documento " & .Item("O").ToString)
                                                                                    l_Err.Add("E03", "Cliente" & .Item("AA").ToString & " con IPA in anagrafica " & dvClienti(iCliFound)("IPACode") & " MA assente sul documento " & .Item("O").ToString)
                                                                                End If

                                                                                If bSameIPATesta AndAlso bSameAddressTesta AndAlso bSameRifAmmTesta Then
                                                                                    'Posso usare i dati di Testa
                                                                                    'Aggiorno i dati cliente con quelli non presenti sul ClienOrd
                                                                                    myLogs = AggiornaAnagraficaCliente(drXLS(irxls), dvClienti(iCliFound), dvCliOpt(iCliOptFound))
                                                                                Else
                                                                                    'Devo usare i dati delle sedi
                                                                                    Dim bSameInd As Boolean = False
                                                                                    Dim bSameCitta As Boolean = False
                                                                                    Dim bSameRifAmm As Boolean = False

                                                                                    'Prima controllo se ho una SEDE in modo da aggiornare quella
                                                                                    Dim okUsaSede As Boolean = False
                                                                                    Dim okSedeFound As Boolean = False
                                                                                    'Potrebbero esserci piu' sedi con stesso IPA ma con dati diversi
                                                                                    '{CustSupp} {IPA} 
                                                                                    Dim sIPACode As String() = { .Item("AA").ToString, .Item("Z").ToString}
                                                                                    Dim rvSedi As DataRowView() = dvSedi.FindRows(sIPACode)
                                                                                    Dim cliSedeFound As Integer = rvSedi.Length
                                                                                    If cliSedeFound = 0 Then
                                                                                        'Non ho trovato IPA sulle sedi lo segno in modo da creare la sede dopo
                                                                                        okUsaSede = False
                                                                                        okSedeFound = False
                                                                                    Else
                                                                                        'Esistono delle SEDI con quell' IPA
                                                                                        okUsaSede = True
                                                                                        'Cerco la sede corretta tra le eventuali n con i campi indirizzo, rif. amministrazione etc 

                                                                                        For x = 0 To rvSedi.Length - 1
                                                                                            'Controllo corrispondenza di indirizzo , città e rif amministrativo con quelli della fattura
                                                                                            bSameInd = String.Equals(Regex.Replace(.Item("AC").ToString, "\s", ""), Regex.Replace(rvSedi(x).Item("Address"), "\s", ""), StringComparison.OrdinalIgnoreCase)
                                                                                            bSameCitta = .Item("AE").ToString = rvSedi(x).Item("City")
                                                                                            'bSameCap = .Item("AD").ToString = rvSedi(x).Item("ZipCode")
                                                                                            bSameRifAmm = .Item("HE").ToString = rvSedi(x).Item("AdministrationReference")
                                                                                            If bSameInd AndAlso bSameCitta AndAlso bSameRifAmm Then
                                                                                                'Ho trovato la sede e posso uscire dal ciclo
                                                                                                drDoc("SendDocumentsTo") = rvSedi(x).Item("Branch")

                                                                                                okSedeFound = True
                                                                                                Exit For
                                                                                            End If
                                                                                        Next
                                                                                    End If
                                                                                    If okUsaSede Then
                                                                                        If okSedeFound Then
                                                                                            'Aggiorno la sede, la cerco per codice in quanto l'ho trovata sopra
                                                                                            Using dvBranch As New DataView(dsClienti.Tables("MA_CustSuppBranches"), "CustSupp='" & .Item("AA").ToString & "'", "Branch", DataViewRowState.CurrentRows)
                                                                                                Dim branchFound As Integer = dvBranch.Find(drDoc("SendDocumentsTo").ToString)
                                                                                                If iClienOrdFound <> -1 Then myLogs = AggiornaAnagraficaSede(drXLS(irxls), dvClienOrd(iClienOrdFound), dvClienti(iCliFound), dvBranch(branchFound), dvCliOpt(iCliOptFound))
                                                                                            End Using
                                                                                        Else
                                                                                            drSedi = CreaSede(dvSedi, drXLS(irxls), dvClienOrd(iClienOrdFound), dtSediNew.NewRow, avvisi)
                                                                                            drDoc("SendDocumentsTo") = drSedi("Branch")
                                                                                            Dim sNewSede As String = "Cliente " & drSedi("CustSupp") & " , Sede : " & drSedi("Branch") & " , IPA: " & drSedi("IPACode") & " , doc: " & .Item("O").ToString
                                                                                            'Potrebbe schiantarsi quindi preferisco usare un try
                                                                                            Try
                                                                                                dtSediNew.Rows.Add(drSedi)
                                                                                                drSedi.AcceptChanges()
                                                                                                dvSedi.Table.ImportRow(drSedi)
                                                                                                listOfNewSedi.Add(sNewSede)
                                                                                                l_NewSedi.Add("N01", sNewSede)
                                                                                            Catch ex As Exception
                                                                                                Debug.Print("E16: Sede già presente: " & sNewSede)
                                                                                                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                                                                                                mb.ShowDialog()
                                                                                                errori.AppendLine("E16: Sede già presente: " & sNewSede)
                                                                                                l_Err.Add("E16", "Sede già presente: " & sNewSede)
                                                                                            End Try
                                                                                        End If
                                                                                    Else
                                                                                        'Uso i dati di testa / Comunicazioni Digitali
                                                                                        If Not okSedeFound Then
                                                                                            'Non ho trovato la sede e i dati di testa non corrispondono
                                                                                            'Creo quindi una nuova sede
                                                                                            drSedi = CreaSede(dvSedi, drXLS(irxls), dvClienOrd(iClienOrdFound), dtSediNew.NewRow, avvisi)
                                                                                            drDoc("SendDocumentsTo") = drSedi("Branch")
                                                                                            Dim sNewSede As String = "Cliente " & drSedi("CustSupp") & " , Sede : " & drSedi("Branch") & " , IPA: " & drSedi("IPACode") & " , doc: " & .Item("O").ToString
                                                                                            'Potrebbe schiantarsi quindi preferisco usare un try
                                                                                            Try
                                                                                                dtSediNew.Rows.Add(drSedi)
                                                                                                drSedi.AcceptChanges()
                                                                                                dvSedi.Table.ImportRow(drSedi)
                                                                                                listOfNewSedi.Add(sNewSede)
                                                                                                l_NewSedi.Add("N01", sNewSede)
                                                                                            Catch ex As Exception
                                                                                                Debug.Print("E16: Sede già presente: " & sNewSede)
                                                                                                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                                                                                                mb.ShowDialog()
                                                                                                errori.AppendLine("E16: Sede già presente: " & sNewSede)
                                                                                                l_Err.Add("E16", "Sede già presente: " & sNewSede)
                                                                                            End Try
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                                If Not String.IsNullOrWhiteSpace(myLogsClienord.Avvisi.ToString) Then
                                                                                    aggiornamenti.AppendLine(myLogsClienord.Avvisi.ToString)
                                                                                    l_Agg.Add("U01", myLogsClienord.Avvisi.ToString)
                                                                                End If
                                                                                If Not String.IsNullOrWhiteSpace(myLogsClienord.Warning.ToString) Then
                                                                                    warnings.AppendLine(myLogsClienord.Warning.ToString)
                                                                                    l_Warn.Add("W01", myLogsClienord.Warning.ToString)
                                                                                End If
                                                                                If Not String.IsNullOrWhiteSpace(myLogs.Avvisi.ToString) Then
                                                                                    aggiornamenti.AppendLine(myLogs.Avvisi.ToString)
                                                                                    l_Agg.Add("U02", myLogs.Avvisi.ToString)
                                                                                End If
                                                                                If Not String.IsNullOrWhiteSpace(myLogs.Warning.ToString) Then
                                                                                    warnings.AppendLine(myLogs.Warning.ToString)
                                                                                    l_Warn.Add("W02", myLogs.Warning.ToString)
                                                                                End If

                                                                            End If
#End Region
                                                                            ''''''''''''''''''''''
                                                                            'Scrivo la testa della Fattura
                                                                            ''''''''''''''''''''''
                                                                            'TP01H Colonna M = fattura o nota di credito
                                                                            Dim isNazionale As Boolean = If(iCliFound <> -1, dvClienti(iCliFound)("CustSuppKind"), drCli("CustSuppKind")) = CustSuppKind.Nazionale
                                                                            'Per il Modello contabile uso quelle standard di mago
                                                                            Select Case .Item("U").ToString.ToUpper

                                                                                Case "A"
                                                                                    drDoc("DocumentType") = DocumentType.FatturaAccompagnatoria
                                                                                    drDoc("AccTpl") = If(isNazionale, dtDefVendite.Rows(0).Item("AccompanyingInvoiceAccTpl"), dtDefVendite.Rows(0).Item("EUInvoiceAccTpl"))
                                                                                    totDoc(0) += 1 ' Fatture
                                                                                Case "F"
                                                                                    drDoc("DocumentType") = DocumentType.Fattura
                                                                                    drDoc("AccTpl") = If(isNazionale, dtDefVendite.Rows(0).Item("InvoiceAccTpl"), dtDefVendite.Rows(0).Item("EUInvoiceAccTpl"))
                                                                                    totDoc(0) += 1 ' Fatture
                                                                                Case "N"
                                                                                    drDoc("DocumentType") = DocumentType.NotaCredito
                                                                                    drDoc("AccTpl") = If(isNazionale, dtDefVendite.Rows(0).Item("CreditNoteAccTpl"), dtDefVendite.Rows(0).Item("EUCreditNoteAccTpl"))
                                                                                    totDoc(1) += 1 ' Note di Credito
                                                                                    'Controllo su DDT collegate
                                                                                    If .Item("FH").ToString = "1000" Then avvisi.AppendLine("A12: doc: " & .Item("O").ToString() & " presenti ddt collegate")
                                                                                Case Else
                                                                                    drDoc("DocumentType") = DocumentType.Fattura
                                                                                    drDoc("AccTpl") = "FE"
                                                                                    totDoc(0) += 1 ' Fatture
                                                                                    errori.AppendLine("E18: Tipo documento sconosciuto inserito come fattura: " & .Item("O").ToString)
                                                                                    l_Err.Add("E18", "Tipo documento sconosciuto inserito come fattura: " & .Item("O").ToString)
                                                                            End Select
                                                                            If String.IsNullOrWhiteSpace(drDoc("AccTpl")) Then errori.AppendLine("E22: Modello contabile di Default non trovato per " & .Item("O").ToString)
                                                                            drDoc("DocNo") = .Item("O").ToString()
                                                                            drDoc("DocumentDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            drDoc("TaxJournal") = .Item("N").ToString
                                                                            'Aggiorno array Contatore
                                                                            Dim codeFound As Boolean = False
                                                                            For n As Int16 = 0 To nrRegIva.GetUpperBound(1)
                                                                                If nrRegIva(0, n) = .Item("N").ToString Then
                                                                                    codeFound = True
                                                                                    If Integer.Parse(.Item("O").ToString) > Integer.Parse(nrRegIva(1, n)) Then
                                                                                        nrRegIva(2, n) = .Item("O").ToString
                                                                                    Else
                                                                                        errori.AppendLine("E01: Documento con numero inferiore al contatore: " & .Item("O").ToString)
                                                                                        l_Err.Add("E01", "Documento con numero inferiore al contatore: " & .Item("O").ToString)
                                                                                    End If
                                                                                End If
                                                                                If codeFound Then Exit For
                                                                            Next
                                                                            If Not codeFound Then
                                                                                errori.AppendLine("E05: Registro iva :" & .Item("N").ToString & " non presente su doc: " & .Item("O").ToString)
                                                                                l_Err.Add("E05", "Registro iva :" & .Item("N").ToString & " non presente su doc: " & .Item("O").ToString)
                                                                            End If
                                                                            drDoc("CustSupptype") = CustSuppType.Cliente ' 3211264 = Cliente
                                                                            drDoc("CustSupp") = .Item("AA").ToString
                                                                            drDoc("InstallmStartDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            drDoc("PostingDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            'drDoc("CustomerBank") = .Item("xxx").ToString
                                                                            'drDoc("CompanyBank") = .Item("xxx").ToString
                                                                            drDoc("InvoiceFollows") = "0"
                                                                            drDoc("Currency") = If(.Item("R").ToString = "EUR", "EUR", .Item("O").ToString)

                                                                            'drDoc("ContractCode") = .Item("HP").ToString 'CIG in "X" a  volte e' vuoto
                                                                            'drDoc("ProjectCode") = .Item("HO").ToString 'CUP in "Y" a  volte e' vuoto
                                                                            'drDoc("Job") = .Item("W").ToString  'Ordine (TROPPO LUNGA metto in nr commessa perche' mago lo legge
                                                                            'drDoc("YourReference") = .Item("W").ToString

                                                                            'Scrivo su tabelle dedicate alla Fatturazione Elettronica
                                                                            drDoc("EIDocumentType") = TrovaEIDocType(.Item("M").ToString) ' TD01
                                                                            iLinea += 1
                                                                            ScriviDatiAggiuntiviFE(dtEI, idDoc, drXLS(irxls), iLinea)
                                                                            'SVILUPPO Gestione Allegati ( da sviluppare se Carbone mi passa dei file)

                                                                            drDoc("Area") = TrovaFiliale(.Item("AA").ToString, True)
                                                                            'drDoc("AreaManager") = .Item("H").ToString
                                                                            'drDoc("SalePerson") = .Item("X").ToString
                                                                            drDoc("AccrualPercAtInvoiceDate") = 100
                                                                            drDoc("Issued") = "1" 'Emessa = SI
                                                                            drDoc("SaleDocId") = idDoc
                                                                            drDoc("DeliveryTerms") = 5963782
                                                                            drDoc("CountryOfDestination") = "IT"
                                                                            drDoc("DepartureDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            'drDoc( "CompanyCA")= .Item("H").ToString
                                                                            drDoc("Presentation") = 1376260
                                                                            drDoc("ValueDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            drDoc("IntrastatAccrualDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            drDoc("SalespersonCommAuto") = "0"
                                                                            drDoc("AreaManagerCommAuto") = "0"
                                                                            drDoc("SalespersonCommPercAuto") = "0"
                                                                            drDoc("AreaManagerCommPercAuto") = "0"
                                                                            drDoc("IntrastatBis") = "1"
                                                                            drDoc("CountryOfPayment") = "IT"
                                                                            drDoc("ActionOnLifoFifo") = 26411008
                                                                            drDoc("ModifyOriginalPymtSched") = "0"

                                                                            drDoc("WorkerIDIssue") = My.Settings.mLOGINID 'Matricola
                                                                            drDoc("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                            drDoc("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                                        Case "3", "6"
                                                                            ''''''''''''''''''''''
                                                                            'Righe MA_SaleDocDetail
                                                                            ''''''''''''''''''''''
                                                                            drDocDet = dtDocDet.NewRow
                                                                            drDocDet("SaleDocId") = idDoc
                                                                            drDocDet("Line") = CInt(.Item("BA").ToString)
                                                                            drDocDet("SubId") = CInt(.Item("BA").ToString) ' usato come riferimento tipo per i dati aggiuntivi fatt elettronica
                                                                            'Lo scrivo anche nella testa
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                                                                            drDoc("LastSubId") = .Item("BA").ToString
#Enable Warning BC42104 ' Variable is used before it has been assigned a value

                                                                            'Merce o servizio???
                                                                            Select Case .Item("G").ToString
                                                                                Case "3"
                                                                                    If bContratto Then
                                                                                        bContratto = False
                                                                                    Else
                                                                                        'Se non ho trovato prima delle righe contratto lo segnalo MA solo se non sono accessorie in quanto gestite sotto
                                                                                        If String.IsNullOrWhiteSpace(.Item("BB").ToString) Then
                                                                                            iNoContratto += 1
                                                                                            errori.AppendLine("E13: Doc: " & .Item("O").ToString & " Riga contratto non presente per questa riga :" & .Item("I").ToString)
                                                                                            l_Err.Add("E13", "Doc: " & .Item("O").ToString & " Riga contratto non presente per questa riga :" & .Item("I").ToString)
                                                                                            Debug.Print("Riga contratto non presente per questa riga :" & .Item("I").ToString & " fatt: " & .Item("O").ToString)
                                                                                        End If
                                                                                    End If
                                                                                    If .Item("BB").ToString = "AC" Then
                                                                                        'Riga accessoria usata per i Bolli
                                                                                        'Verosimilmente non ci possono essere righe AC e righe con W ( ritenuta Acconto)
                                                                                        'Loro le scrivono sul corpo, vanno gestite diversamente, non creo la riga
                                                                                        drDocSumm = dtDocSumm.NewRow
                                                                                        drDocSumm("SaleDocId") = idDoc
                                                                                        drDocSumm("StampsCharges") = MagoFormatta(.Item("BM").ToString, GetType(Double)).MONey ' Potrebbe anche calcolarlo Mago
                                                                                        drDocSumm("StampsChargesIsAuto") = "0" ' Impedisco il ricalcolo altrimenti sui clienti non in esenzione non la metterebbe
                                                                                        Dim isTaxEsclusoIva As Boolean
                                                                                        If Not String.IsNullOrWhiteSpace(.Item("CQ").ToString) Then
                                                                                            'Cerco Codice iva su tabella transcode
                                                                                            Dim iTax As Integer = dvTax.Find(.Item("CQ").ToString)
                                                                                            If iTax <> -1 Then
                                                                                                drDocSumm("StampsChargesTaxCode") = dvTax.Item(iTax).Item("TaxCode").ToString
                                                                                                isTaxEsclusoIva = dvTax.Item(iTax).Item("ExemptInvoice").ToString
                                                                                            Else
                                                                                                drDocSumm("StampsChargesTaxCode") = .Item("CQ").ToString
                                                                                                errori.AppendLine("E19: Doc: " & drDoc("DocNo") & " con Codice iva Spese Bolli senza corrispondenza: " & .Item("CQ").ToString)
                                                                                                l_Err.Add("E19", "Doc: " & drDoc("DocNo") & " con Codice iva Spese Bolli senza corrispondenza: " & .Item("CQ").ToString)
                                                                                            End If
                                                                                        End If
                                                                                        drDocSumm("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                        drDocSumm("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                                        'Se e' una nota di credito segnalo la cosa sul cmpo nr Xab Bolla
                                                                                        ' e inserisco importo di abbuono
                                                                                        If drDoc("DocumentType") = DocumentType.NotaCredito Then
                                                                                            drDoc("PreprintedDocNo") = "BOLLI"
                                                                                            avvisi.AppendLine("A01: Controllare bolli su Nota di credito nr: " & drDoc("DocNo").ToString)
                                                                                            drDocSumm("Allowances") = MagoFormatta(.Item("BM").ToString, GetType(Double)).MONey ' Potrebbe anche calcolarlo Mago
                                                                                        End If
                                                                                        dtDocSumm.Rows.Add(drDocSumm)

                                                                                        'Aggiorno il flag sull'anagrafica cliente
                                                                                        Dim iCliopt As Integer = dvCliOpt.Find(.Item("AA").ToString)
                                                                                        If iCliopt <> -1 Then
                                                                                            If dvCliOpt(iCliopt)("ExemptFromTax") = "0" Then avvisi.AppendLine("A02: Cliente " & .Item("AA").ToString & " non in esenzione ma con Bolli, su Doc: " & drDoc("DocNo").ToString)
                                                                                            dvCliOpt(iCliopt).BeginEdit()
                                                                                            dvCliOpt(iCliopt)("DebitStampCharges") = "1"
                                                                                            dvCliOpt(iCliopt).EndEdit()
                                                                                            If isTaxEsclusoIva AndAlso dvCliOpt(iCliopt)("ExemptFromTax") = "0" Then avvisi.AppendLine("A03: Cliente " & .Item("AA").ToString & " non in esenzione ma codice iva Bolli in esenzione, su Doc: " & drDoc("DocNo").ToString)
                                                                                        End If

                                                                                        'esco da questo ciclo
                                                                                        AvanzaBarra()
                                                                                        Continue For
                                                                                    Else
                                                                                        'processo riga Merce/Servizio
                                                                                        drDocDet("LineType") = LineType.Servizio ' Per far funzionare la ritenuta d'acconto
                                                                                        '13/04/2021 
                                                                                        ' Era Colonna "BG" ma essendo sempre vuota , inserisco colonna "IG" a seguito modifiche Sicuritalia 
                                                                                        ' porebbe schiantarsi perche' sono delle colonne nuove e forse vuote
                                                                                        drDocDet("Item") = .Item("IG").ToString
                                                                                        If Not String.IsNullOrWhiteSpace(.Item("IF").ToString) Then
                                                                                            isTipoSicuritalia = True
                                                                                            '13/05/2021 : Con Carbone decidiamo che in assenza di ODA /NSO (Colonna HG) non si scrive nulla anche se "IE" e' valorizzato
                                                                                            If Not String.IsNullOrWhiteSpace(.Item("HG").ToString) Then
                                                                                                iLinea += 1
                                                                                                'La SubLine deve aumentare di piu' solo nel caso in cui ci siano piu' righe con riferimento allo stesso ordine 
                                                                                                'Non dovrebbe succedere
                                                                                                iSubLinea += 1
                                                                                                If Not ScriviDatiAggiuntiviSicuritalia(dtEI, idDoc, drXLS(irxls), iLinea, iSubLinea) Then
                                                                                                    iLinea -= 1
                                                                                                    iSubLinea -= 1
                                                                                                End If
                                                                                            Else
                                                                                                sicuritalia.AppendLine("Doc: " & drDoc("DocNo") & " numero ODA / NSO assente")
                                                                                                'TAG l_Err.Add("E20", "Doc: " & drDoc("DocNo") & " numero ODA / NSO assente", LogLevel.None, "SICURITALIA")
                                                                                                l_Err.Add("E20", "Doc: " & drDoc("DocNo") & " numero ODA / NSO assente")
                                                                                            End If
                                                                                        End If
                                                                                        drDocDet("UoM") = .Item("BI").ToString
                                                                                        Dim dQty As Double = If(String.IsNullOrEmpty(.Item("BJ").ToString), "1", MagoFormatta(.Item("BJ"), GetType(Double)).MONey)
                                                                                        drDocDet("Qty") = If(dQty = 0, 1, dQty)
                                                                                        Dim dUnitValue As Double = MagoFormatta(.Item("BK").ToString, GetType(Double)).MONey
                                                                                        drDocDet("UnitValue") = If(dUnitValue = 0, MagoFormatta(.Item("BN").ToString, GetType(Double)).MONey, dUnitValue)
                                                                                        drDocDet("TaxableAmount") = MagoFormatta(.Item("BN").ToString, GetType(Double)).MONey
                                                                                        Dim isTaxEsclusoIva As Boolean
                                                                                        If Not String.IsNullOrWhiteSpace(.Item("CQ").ToString) Then
                                                                                            'Cerco Codice iva su tabella transcode
                                                                                            Dim iTax As Integer = dvTax.Find(.Item("CQ").ToString)
                                                                                            If iTax <> -1 Then
                                                                                                drDocDet("TaxCode") = dvTax.Item(iTax).Item("TaxCode").ToString
                                                                                                isTaxEsclusoIva = dvTax.Item(iTax).Item("ExemptInvoice").ToString
                                                                                            Else
                                                                                                drDocDet("TaxCode") = .Item("CQ").ToString
                                                                                                errori.AppendLine("E02: Doc: " & drDoc("DocNo") & " con Codice iva senza corrispondenza: " & .Item("CQ").ToString)
                                                                                                l_Err.Add("E02", "Doc: " & drDoc("DocNo") & " con Codice iva senza corrispondenza: " & .Item("CQ").ToString)
                                                                                            End If
                                                                                        End If

                                                                                        'Controllo 'esenzione sull'anagrafica cliente
                                                                                        Dim iCliopt As Integer = dvCliOpt.Find(.Item("AA").ToString)
                                                                                        If iCliopt <> -1 AndAlso isTaxEsclusoIva AndAlso dvCliOpt(iCliopt)("ExemptFromTax") = "0" Then avvisi.AppendLine("A04: Cliente " & .Item("AA").ToString & " non in esenzione ma codice iva in esenzione, su riga: " & drDocDet("Line").ToString & " , Doc: " & drDoc("DocNo").ToString)

                                                                                        '"BM" TOTALE RIGA
                                                                                        'drDocDet("TotalAmount") = MagoFormatta((.Item("BM") * CInt(drDocDet("Qty"))).ToString, GetType(Double)).money
                                                                                        drDocDet("TotalAmount") = MagoFormatta(.Item("BN").ToString, GetType(Double)).MONey
                                                                                        'scrivo le informazioni di nota commessa e contropartita
                                                                                        drDocDet("Notes") = sContratto(0)
                                                                                        drDocDet("CostCenter") = sContratto(1) ' Righe
                                                                                        drDoc("CostCenter") = sContratto(1) 'Testa

                                                                                        drDocDet("InEI") = "0"
                                                                                        drDocDet("IncludedInTurnover") = "1"
                                                                                        drDocDet("Offset") = sContratto(2)

                                                                                        '19/03/2021
                                                                                        'Popolamento campi ad uso Analitico
                                                                                        If Not bOldtrack Then
                                                                                            Dim dNrCanoni As Double = If(String.IsNullOrEmpty(.Item("IB").ToString), "1", MagoFormatta(.Item("IB"), GetType(Double)).MONey)
                                                                                            drDocDet("ALL_NrCanoni") = If(dNrCanoni = 0, 1, dNrCanoni)
                                                                                            drDocDet("ALL_CanoniDataI") = MagoFormatta(.Item("IC").ToString, GetType(DateTime)).DataTempo
                                                                                            drDocDet("ALL_CanoniDataF") = MagoFormatta(.Item("ID").ToString, GetType(DateTime)).DataTempo
                                                                                        End If

                                                                                        '29/03/2021
                                                                                        'Dati Fattura Elettronica
                                                                                        ScriviAltriDatiGestionaliFE(dtEI, idDoc, drXLS(irxls))
                                                                                    End If
                                                                                Case Else
                                                                                    drDocDet("LineType") = LineType.Nota
                                                                                    drDocDet("InEI") = "1"
                                                                                    drDocDet("IncludedInTurnover") = "0"
                                                                            End Select
                                                                            Dim sDescri As String = .Item("BH").ToString
                                                                            drDocDet("Description") = sDescri
                                                                            If Left(sDescri, 8) = "Codice :" Then
                                                                                'Ho trovato una riga contratto
                                                                                bContratto = True
                                                                                sContratto(0) = RTrim(Mid(sDescri, 10, 12))
                                                                                sContratto(1) = TrovaCdC(sDescri)
                                                                                Dim sConto As String = ""
                                                                                If Not TryTrovaContropartita(sDescri, dvCntrp, sConto) Then
                                                                                    errori.AppendLine("E21: Doc: " & .Item("O").ToString & " senza corrispondenza di contropartita : " & sDescri)
                                                                                End If
                                                                                sContratto(2) = sConto
                                                                                'drDocDet("Notes") = sContratto(0)
                                                                                'drDocDet("CostCenter") = sContratto(1)
                                                                                'drDocDet("Offset") = sContratto(2)
                                                                            End If
                                                                            drDocDet("DocumentDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            drDocDet("CustSupptype") = CustSuppType.Cliente ' 3211264 = Cliente
                                                                            drDocDet("CustSupp") = .Item("AA").ToString
                                                                            'drDocDEt( "SubId")= 0 ' gestire
                                                                            'drDocDEt( "InvoiceId")= 0 'Solo su Note di Credito
                                                                            'drDocDEt( "InvoiceSubId")= 0 'Solo su Note di Credito
                                                                            'drDocDEt( "DocIdToBeUnloaded")= 0 'Solo su Note di Credito
                                                                            drDocDet("DepartureDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                                                            Select Case .Item("U").ToString.ToUpper
                                                                                Case "A"
                                                                                    drDocDet("ReferenceDocType") = DocumentType.FatturaAccompagnatoria
                                                                                Case "N"
                                                                                    drDocDet("ReferenceDocType") = DocumentType.NotaCredito
                                                                                Case Else '"F"
                                                                                    drDocDet("ReferenceDocType") = DocumentType.Fattura
                                                                            End Select
                                                                            'drDocDEt( "CRRefType")= CrossReference.Tutti 'Valorizzato su Mago sulle NdC con riferimento alla fattura di Mago
                                                                            'drDocDEt( "CRRefID")= 0 'Solo su Note di Credito
                                                                            'drDocDEt( "CRRefSubID")= 0 'Solo su Note di Credito
                                                                            'drDocDEt( "NetPrice")= .Item("BM").ToString

                                                                            drDocDet("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                            drDocDet("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                                            'Aggiungo la riga all'insieme Rows del Datatable
                                                                            dtDocDet.Rows.Add(drDocDet)
                                                                        Case "9"
                                                                            'Totali, dati bancari, potrebbe riportare il numero della dichiarazione di intento,.. Causale
                                                                            If Not String.IsNullOrWhiteSpace(.Item("FI").ToString) Then
                                                                                Dim iCP As Integer = dvCP.Find(.Item("FI").ToString)
                                                                                If iCP <> -1 Then
                                                                                    drDoc("Payment") = dvCP.Item(iCP).Item("Payment").ToString
                                                                                    isRimessaDiretta = dvCP.Item(iCP).Item("InstallmentType") = 2686977

                                                                                Else
                                                                                    drDoc("Payment") = .Item("FI").ToString
                                                                                    errori.AppendLine("E08: Doc: " & .Item("O").ToString & " senza corrispondenza di condizione di pagamento: " & .Item("FI").ToString)
                                                                                    l_Err.Add("E08", "Doc: " & .Item("O").ToString & " senza corrispondenza di condizione di pagamento: " & .Item("FI").ToString)
                                                                                    bNoCondPag = True
                                                                                End If
                                                                            End If

                                                                            drDoc("ALL_IBAN") = .Item("FM").ToString ' IBAN 
                                                                            'Cerco banca Cliente e C/C 
                                                                            'Colonna "FM" solo se ho RID/SEPA e RIBA

                                                                            'Su RD=SEPA/RID ho iban
                                                                            If .Item("FN").ToString() = "RD" Then
                                                                                Dim aIBAN As String() = EstrapolaIBAN(.Item("FM").ToString())
                                                                                Dim bancaCli As String = aIBAN(3) & "-" & aIBAN(4)
                                                                                drDoc("CustomerBank") = bancaCli
                                                                                'Se assente la inserisco
                                                                                Dim iBankFound As Integer = dvBancheCli.Find(bancaCli)
                                                                                If iBankFound = -1 Then
                                                                                    Debug.Print("Nuova Banca cliente: " & bancaCli)
                                                                                    listOfNewBancheCli.Add(bancaCli)
                                                                                    l_NewBankCli.Add("N01", bancaCli)
                                                                                    Dim drBankCli = dtBancheCliNew.NewRow
                                                                                    drBankCli("Bank") = bancaCli
                                                                                    drBankCli("Description") = "Inserita da Importazione"
                                                                                    drBankCli("ABI") = aIBAN(3)
                                                                                    drBankCli("CAB") = aIBAN(4)
                                                                                    drBankCli("IsACompanyBank") = "0"
                                                                                    drBankCli("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                    drBankCli("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                                    dtBancheCliNew.Rows.Add(drBankCli)
                                                                                    drBankCli.AcceptChanges()
                                                                                    dvBancheCli.Table.ImportRow(drBankCli)

                                                                                End If
                                                                                'Codice mandato. necessario in quanto mago non gestisce bene il multimandato per cliente
                                                                                drDoc("ALL_UMRCode") = .Item("FL").ToString ' Codice mandato 
                                                                                'Cerco se esiste il codice mandato
                                                                                dvSSD.RowFilter = "MandateLastdate = '" & sDataNulla & "' AND UMRCode='" & .Item("FL").ToString & "' AND Customer='" & .Item("AA").ToString & "'"
                                                                                Dim ssdFound As Integer = dvSSD.Count()
                                                                                If ssdFound = 0 Then
                                                                                    'Inserisco nuovo RID/SDD 
                                                                                    'Sugli altri con le stesse coordinate ABI CAB e C/C
                                                                                    'setto Data Ultimo Invio RID in modo da disabilitarli
                                                                                    drSSD = dtSSDNew.NewRow
                                                                                    'Devo trovare il nuovo contatore dei mandati
                                                                                    dvSSD.RowFilter = "Customer='" & .Item("AA").ToString & "'"
                                                                                    Dim iMandateCounter As Integer = dvSSD.Count
                                                                                    drSSD("MandateCode") = .Item("AA").ToString & "_" & iMandateCounter.ToString
                                                                                    Debug.Print("Nuovo mandato: " & drSSD("MandateCode"))
                                                                                    drSSD("UMRCode") = .Item("FL").ToString
                                                                                    drSSD("Customer") = .Item("AA").ToString
                                                                                    drSSD("CustomerBank") = bancaCli
                                                                                    drSSD("CustomerCA") = aIBAN(5)
                                                                                    drSSD("CustomerIBAN") = .Item("FM").ToString
                                                                                    drSSD("CustomerIBANIsManual") = "1"
                                                                                    'Dim data As String = "20" & If(String.IsNullOrWhiteSpace(.Item("E").ToString), .Item("F").ToString, .Item("E").ToString)
                                                                                    'drSSD("MandateFirstDate") = MagoFormatta(data, GetType(DateTime)).DataTempo
                                                                                    drSSD("MandateType") = 2686989
                                                                                    drSSD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                    drSSD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                                    dtSSDNew.Rows.Add(drSSD)
                                                                                    drSSD.AcceptChanges()
                                                                                    dvSSD.Table.ImportRow(drSSD)
                                                                                    'Aggiorno anagrafica Cliente
                                                                                    Dim iCliFound As Integer = dvClienti.Find(.Item("AA").ToString)
                                                                                    If iCliFound <> -1 Then
                                                                                        dvClienti(iCliFound).BeginEdit()
                                                                                        dvClienti(iCliFound)("CustSuppBank") = bancaCli
                                                                                        dvClienti(iCliFound)("CA") = aIBAN(5)
                                                                                        dvClienti(iCliFound)("CIN") = aIBAN(2)
                                                                                        dvClienti(iCliFound)("CACheck") = aIBAN(1)
                                                                                        dvClienti(iCliFound)("IBANIsManual") = "1"
                                                                                        dvClienti(iCliFound)("IBAN") = .Item("FM").ToString
                                                                                        dvClienti(iCliFound).EndEdit()
                                                                                    End If
                                                                                Else
                                                                                    'Non devono esistere 2 UMR uguali a parità di cliente:
                                                                                    If Not String.Equals(dvSSD(0).Item("CustomerIBAN").ToString, .Item("FM").ToString, StringComparison.CurrentCultureIgnoreCase) Then
                                                                                        errori.AppendLine("E14: Doc: " & drDoc("DocNo") & " con UMRCode/Codice Mandato non univoco. Cliente: " & .Item("AA").ToString & " Controllare IBAN.")
                                                                                        l_Err.Add("E14", "Doc: " & drDoc("DocNo") & " con UMRCode/Codice Mandato non univoco. Cliente: " & .Item("AA").ToString & " Controllare IBAN.")
                                                                                    End If
                                                                                End If
                                                                                'Dopo averne creato oppure no disattivo quelli piu' vecchi con lo stesso IBAN
                                                                                'Mi segno gli eventuali RID vecchi con stesso IBAN da disattivare/chiudere
                                                                                'FORSE ANDREBBE MESSO UN ALTRO FILTRO PER ESTRARRE SOLO QUELLI CON UMRCODE DIVERSO
                                                                                'ORA INVECE IO SALVO L'ULTIMO
                                                                                '09/02/2021  non lo faccio piu' lascio tutti aperti
                                                                                'Da mago lancio report per associare UMR a quello in fattura
                                                                                'dvSSD.RowFilter = "Customer='" & .Item("AA").ToString & "' AND CustomerIBAN='" & .Item("FM").ToString & "' AND MandateLastdate = '" & sDataNulla & "'"
                                                                                'If dvSSD.Count > 1 Then
                                                                                '    dvSSD.Sort = "TBCreated"
                                                                                '    'dvSSD.Sort = "MandateFirstDate"

                                                                                '    'NE SALVO UNO PERTANTO MI FERMO A -2
                                                                                '    For i = 0 To dvSSD.Count - 2
                                                                                '        If dvSSD(i).Item("MandateLastdate").ToString = sDataNulla Then
                                                                                '            listOfSEPA.Add(dvSSD(i).Item("MandateCode"))
                                                                                '        End If
                                                                                '    Next
                                                                                'End If
                                                                            ElseIf .Item("FN").ToString() = "RB" Then
                                                                                'Su riba ho solo abi e cab sulla colonna "FM"
                                                                                drDoc("CustomerBank") = Left(.Item("FM"), 5) & "-" & Right(.Item("FM"), 5)
                                                                            Else
                                                                                If Not isRimessaDiretta Then
                                                                                    'Altrimenti Cerco Banca Azienda e c/c preferenziale
                                                                                    Erase aBanca
                                                                                    ReDim aBanca(2)
                                                                                    aBanca(0) = .Item("FJ").ToString ' ABI
                                                                                    aBanca(1) = .Item("FK").ToString ' CAB
                                                                                    aBanca(2) = Mid(.Item("FM").ToString, 16, 12) 'cc
                                                                                    Dim ib As Integer = dvBanche.Find(aBanca)
                                                                                    If ib <> -1 Then
                                                                                        drDoc("CompanyBank") = dvBanche(ib).Item("Bank")
                                                                                        drDoc("CompanyPymtCA") = dvBanche(ib).Item("PreferredCA") 'C/C
                                                                                        'drDoc("CompanyCA") = If(sbanca = "-", "", sbanca)  'Conto effetti
                                                                                    Else
                                                                                        If String.IsNullOrWhiteSpace(aBanca(0)) OrElse String.IsNullOrWhiteSpace(aBanca(1)) Then
                                                                                            errori.AppendLine("E09: Doc: " & .Item("O").ToString() & " ABI o CAB Banca Azienda assenti. Condizione di pagamento: " & drDoc("Payment").ToString)
                                                                                            l_Err.Add("E09", "Doc: " & .Item("O").ToString() & " ABI o CAB Banca Azienda assenti. Condizione di pagamento: " & drDoc("Payment").ToString)
                                                                                        ElseIf String.IsNullOrWhiteSpace(aBanca(2)) Then
                                                                                            'Fattura senza IBAN
                                                                                            'Cerco su abi e cab e imposto il c/c preferenziale
                                                                                            dvBanche.Sort = "ABI,CAB"
                                                                                            ReDim Preserve aBanca(1)
                                                                                            Dim ibl As Integer = dvBanche.Find(aBanca)
                                                                                            If ibl <> -1 Then
                                                                                                drDoc("CompanyBank") = dvBanche(ibl).Item("Bank")
                                                                                                drDoc("CompanyPymtCA") = dvBanche(ibl).Item("PreferredCA") 'C/C
                                                                                                avvisi.AppendLine("A09: doc: " & .Item("O").ToString() & " IBAN assente, impostato c/c preferenziale della banca " & aBanca(0) & "-" & aBanca(1))
                                                                                            Else
                                                                                                errori.AppendLine("E10: Doc: " & .Item("O").ToString() & " IBAN assente e Banca Azienda non trovata: " & aBanca(0) & "-" & aBanca(1))
                                                                                                l_Err.Add("E10", "Doc: " & .Item("O").ToString() & " IBAN assente e Banca Azienda non trovata: " & aBanca(0) & "-" & aBanca(1))
                                                                                            End If
                                                                                            'Ripristino vecchio ordinamento
                                                                                            dvBanche.Sort = "ABI,CAB,PreferredCA"
                                                                                        ElseIf Not String.IsNullOrWhiteSpace(aBanca(2)) Then
                                                                                            'Cerco se esitono almeno abi e cab
                                                                                            dvBanche.Sort = "ABI,CAB"
                                                                                            ReDim Preserve aBanca(1)
                                                                                            Dim ibl As Integer = dvBanche.Find(aBanca)
                                                                                            If ibl <> -1 Then
                                                                                                drDoc("CompanyBank") = dvBanche(ibl).Item("Bank")
                                                                                                avvisi.AppendLine("A11: doc: " & .Item("O").ToString() & " c/c preferenziale assente su banca " & aBanca(0) & "-" & aBanca(1))
                                                                                                'Ripristino vecchio ordinamento
                                                                                            End If
                                                                                            dvBanche.Sort = "ABI,CAB,PreferredCA"
                                                                                        Else
                                                                                            errori.AppendLine("E11: doc: " & .Item("O").ToString() & " Banca Azienda non trovata: " & aBanca(0) & "-" & aBanca(1))
                                                                                            l_Err.Add("E11", "Doc: " & .Item("O").ToString() & " Banca Azienda non trovata: " & aBanca(0) & "-" & aBanca(1))
                                                                                        End If
                                                                                    End If
                                                                                    bNoBanca = True
                                                                                Else
                                                                                    'E' una rimessa diretta e potrebbe non avere la banca azienda indicata pertanto me la segno ma vado oltre
                                                                                    'avvisi.AppendLine("A10: doc: " & .Item("O").ToString() & " rimessa diretta.")
                                                                                End If
                                                                            End If

                                                                            'Aggiungo informazioni al nuovo cliente
                                                                            If isNewCliente Then
                                                                                If Not String.IsNullOrWhiteSpace(.Item("FI").ToString) Then
                                                                                    Dim iCP As Integer = dvCP.Find(.Item("FI").ToString)
#Disable Warning BC42104 ' La variabile è stata usata prima dell'assegnazione di un valore
                                                                                    If iCP <> -1 Then
                                                                                        drCli("Payment") = dvCP.Item(iCP).Item("Payment").ToString
                                                                                    Else
                                                                                        drCli("Payment") = .Item("FI").ToString
                                                                                    End If
                                                                                End If

                                                                                If .Item("DU").ToString = ACGIVASplit Then drCliOpt("PASplitPayment") = "1"
#Enable Warning BC42104 ' La variabile è stata usata prima dell'assegnazione di un valore

                                                                                If Not String.IsNullOrWhiteSpace(drDoc("CompanyBank")) Then drCli("CompanyBank") = drDoc("CompanyBank")
                                                                                If Not String.IsNullOrWhiteSpace(drDoc("CompanyPymtCA")) Then drCli("CustomerCompanyCA") = drDoc("CompanyPymtCA")
                                                                                If Not String.IsNullOrWhiteSpace(drDoc("CustomerBank")) Then drCli("CustSuppBank") = drDoc("CustomerBank")

                                                                                'Aggiungo le righe alla tabella
                                                                                dtClientiNew.Rows.Add(drCli)
                                                                                drCli.AcceptChanges()
                                                                                dvClienti.Table.ImportRow(drCli)
                                                                                dtCliOptNew.Rows.Add(drCliOpt)
                                                                                drCliOpt.AcceptChanges()
                                                                                dvCliOpt.Table.ImportRow(drCliOpt)
                                                                            End If

                                                                            'Se e' un CODICE IVA SPLIT PAYMENT (32)
                                                                            Dim iCliopt As Integer = dvCliOpt.Find(.Item("AA").ToString)
                                                                            If .Item("DU").ToString = ACGIVASplit Then
                                                                                If iCliopt <> -1 AndAlso dvCliOpt(iCliopt)("PASplitPayment") <> "1" Then
                                                                                    avvisi.AppendLine("A07: doc: " & .Item("O").ToString & " in SPLIT payment ma Cliente: " & .Item("AA").ToString & " non in SPLIT. Aggiornato il Cliente.")
                                                                                    dvCliOpt(iCliopt).BeginEdit()
                                                                                    dvCliOpt(iCliopt)("PASplitPayment") = "1"
                                                                                    dvCliOpt(iCliopt).EndEdit()
                                                                                End If
                                                                            Else
                                                                                'Controllo solo che la fattura non sia strana tipo che abbia iva su cliente in SPLIT
                                                                                If iCliopt <> -1 AndAlso dvCliOpt(iCliopt)("PASplitPayment") = "1" Then
                                                                                    errori.AppendLine("E15: Doc: " & .Item("O").ToString & " con IVA ma Cliente: " & .Item("AA").ToString & " in SPLIT")
                                                                                    l_Err.Add("E15", "Doc: " & .Item("O").ToString & " con IVA ma Cliente: " & .Item("AA").ToString & " in SPLIT")
                                                                                End If
                                                                            End If
                                                                            'Riga di totale posso aggiungere la riga all'insieme Rows del Datatable
                                                                            dtDoc.Rows.Add(drDoc)

                                                                            'Se ho un cliente tipo "Sicuritalia" creo la riga Causale per la fattura elettronica
                                                                            If isTipoSicuritalia AndAlso Not String.IsNullOrWhiteSpace(.Item("BH").ToString) Then
                                                                                '2.1.1.11 <Causale>
                                                                                drEI = dtEI.NewRow
                                                                                drEI("DocID") = idDoc
                                                                                drEI("DocSubID") = 0
                                                                                idCausale += 1
                                                                                drEI("Line") = idCausale
                                                                                drEI("SubLine") = 0
                                                                                drEI("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Causale"
                                                                                drEI("FieldValue") = .Item("BH").ToString ' = Colonna BH (DSARH)
                                                                                drEI("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                drEI("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                                dtEI.Rows.Add(drEI)
                                                                            End If

                                                                            '28/06/2021 : de campo DSARH Colonna BH non e' vuoto scrivo nella Causale
                                                                            If Not String.IsNullOrWhiteSpace(.Item("BH").ToString) Then
                                                                                '2.1.1.11 <Causale>
                                                                                drEI = dtEI.NewRow
                                                                                drEI("DocID") = idDoc
                                                                                drEI("DocSubID") = 0
                                                                                idCausale += 1
                                                                                drEI("Line") = idCausale
                                                                                drEI("SubLine") = 0
                                                                                drEI("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.Causale"
                                                                                drEI("FieldValue") = .Item("BH").ToString ' = Colonna BH (DSARH)
                                                                                drEI("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                                drEI("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                                dtEI.Rows.Add(drEI)
                                                                            End If
                                                                        Case "R"
                                                                            'Ritenuta d'acconto
                                                                            drDocSumm = dtDocSumm.NewRow
                                                                            drDocSumm("SaleDocId") = idDoc
                                                                            drDocSumm("WithholdingTaxManagement") = "1"
                                                                            drDocSumm("WithholdingTax") = MagoFormatta(.Item("DB").ToString, GetType(Double)).MONey ' Potrebbe anche calcolarlo Mago
                                                                            drDocSumm("WithholdingTaxPerc") = MagoFormatta(.Item("DT").ToString, GetType(Double)).MONey '4%
                                                                            drDocSumm("WithholdingTaxBasePerc") = 100
                                                                            drDocSumm("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                            drDocSumm("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                            dtDocSumm.Rows.Add(drDocSumm)

                                                                            '2.1.1.5.4 <CausalePagamento>
                                                                            drEI = dtEI.NewRow
                                                                            drEI("DocID") = idDoc
                                                                            drEI("DocSubID") = 0
                                                                            drEI("Line") = 0
                                                                            drEI("SubLine") = 0
                                                                            drEI("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.CausalePagamento"
                                                                            If .Item("BB").ToString = "W" Then
                                                                                drEI("FieldValue") = "32440339" ' = lettera W Colonna BB (TPCEH)
                                                                            Else
                                                                                drEI("FieldValue") = "32440347" ' (blank)
                                                                                errori.AppendLine("E12: Doc: " & .Item("O").ToString & " senza corrispondenza lettera pagamento Ritenuta:" & .Item("BB").ToString)
                                                                                l_Err.Add("E12", "Doc: " & .Item("O").ToString & " senza corrispondenza lettera pagamento Ritenuta:" & .Item("BB").ToString)
                                                                            End If
                                                                            drEI("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                            drEI("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                            dtEI.Rows.Add(drEI)

                                                                            'Ora devo correggere le righe di dettaglio già inserite per mettere il Flag "SubjectToWithholdingTax" x la gestione della Ritenuta d'acconto
                                                                            dvDocDet.RowFilter = "(LineType= " & LineType.Servizio & " or LineType=" & LineType.Merce & ") AND SaleDocId=" & idDoc
                                                                            For Each drV As DataRowView In dvDocDet
                                                                                drV.BeginEdit()
                                                                                drV.Item("SubjectToWithholdingTax") = "1"
                                                                                drV.EndEdit()
                                                                            Next

                                                                            'Aggiorno il cliente con i flag per RA
                                                                            Dim iCliopt As Integer = dvCliOpt.Find(.Item("AA").ToString)
                                                                            If iCliopt <> -1 Then
                                                                                dvCliOpt(iCliopt).BeginEdit()
                                                                                dvCliOpt(iCliopt)("WithholdingTaxManagement") = "1"
                                                                                dvCliOpt(iCliopt)("WithholdingTaxPerc") = MagoFormatta(.Item("DT").ToString, GetType(Double)).MONey
                                                                                dvCliOpt(iCliopt)("WithholdingTaxBasePerc") = 100
                                                                                dvCliOpt(iCliopt).EndEdit()
                                                                            End If
                                                                    End Select
                                                                End With
                                                                AvanzaBarra()
                                                            Next
                                                            Debug.Print("Inizio Bulk")
                                                            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                                                'cmd.Transaction = Trans
                                                                cmdqry.ExecuteNonQuery()
                                                                Using bulkTrans = Connection.BeginTransaction
                                                                    EditTestoBarra("Salvataggio: Fatture")
                                                                    okBulk = ScriviBulk("MA_SaleDoc", dtDoc, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Righe")
                                                                    okBulk = ScriviBulk("MA_SaleDocDetail", dtDocDet, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Dati Aggiuntivi fatt. ele.")
                                                                    okBulk = ScriviBulk("MA_EI_ITDocAdditionalData", dtEI, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Totali")
                                                                    okBulk = ScriviBulk("MA_SaleDocSummary", dtDocSumm, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: SSD/RID")
                                                                    okBulk = ScriviBulk("MA_SDDMandate", dtSSDNew, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Clienti")
                                                                    okBulk = ScriviBulk("MA_CustSupp", dtClientiNew, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Altri dati Clienti")
                                                                    okBulk = ScriviBulk("MA_CustSuppCustomerOptions", dtCliOptNew, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Persona Fisica Clienti")
                                                                    okBulk = ScriviBulk("MA_CustSuppNaturalPerson", dtCliNatPersNew, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Sedi Clienti")
                                                                    okBulk = ScriviBulk("MA_CustSuppBranches", dtSediNew, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    EditTestoBarra("Salvataggio: Banche Clienti")
                                                                    okBulk = ScriviBulk("MA_Banks", dtBancheCliNew, bulkTrans, Connection, DataRowState.Unchanged, loggingTxt)
                                                                    If Not okBulk Then someTrouble = True
                                                                    bulkMessage.AppendLine(loggingTxt)
                                                                    l_Bulk.Add("B01", loggingTxt)
                                                                    If someTrouble Then
                                                                        FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                                                                        bulkTrans.Rollback()
                                                                    Else
                                                                        bulkTrans.Commit()
                                                                    End If
                                                                    Debug.Print("Fine bulk")
                                                                End Using
                                                                If Not someTrouble Then
                                                                    Dim irows As Integer
                                                                    Using updTrans = Connection.BeginTransaction
                                                                        EditTestoBarra("Aggiornamento Anagrafica Clienti")
                                                                        adpCF.UpdateCommand.Transaction = updTrans
                                                                        irows = adpCF.Update(dsClienti.Tables("MA_CustSupp"))
                                                                        If irows > 0 Then
                                                                            aggiornamenti.AppendLine("Aggiornamento Vista Clienti: " & irows.ToString & " record")
                                                                            l_Bulk.Add("B02", "Aggiornamento Vista Clienti: " & irows.ToString & " record")
                                                                        End If
                                                                        Debug.Print("Aggiornamento Vista Clienti: " & irows.ToString & " record")
                                                                        updTrans.Commit()
                                                                    End Using
                                                                    Using updTrans = Connection.BeginTransaction
                                                                        EditTestoBarra("Aggiornamento Anagrafica Clienti - Altri Dati")
                                                                        adpCliOpt.UpdateCommand.Transaction = updTrans
                                                                        irows = adpCliOpt.Update(dsClienti.Tables("MA_CustSuppCustomerOptions"))
                                                                        If irows > 0 Then
                                                                            aggiornamenti.AppendLine("Aggiornamento Vista ClientiOptions: " & irows.ToString & " record")
                                                                            l_Bulk.Add("B02", "Aggiornamento Vista ClientiOptions: " & irows.ToString & " record")
                                                                        End If
                                                                        Debug.Print("Aggiornamento Vista ClientiOptions: " & irows.ToString & " record")
                                                                        updTrans.Commit()
                                                                    End Using
                                                                    Using updTrans = Connection.BeginTransaction
                                                                        EditTestoBarra("Aggiornamento Sedi Clienti")
                                                                        adpCliSedi.UpdateCommand.Transaction = updTrans
                                                                        irows = adpCliSedi.Update(dsClienti.Tables("MA_CustSuppBranches"))
                                                                        If irows > 0 Then
                                                                            aggiornamenti.AppendLine("Aggiornamento Vista Sedi Clienti: " & irows.ToString & " record")
                                                                            l_Bulk.Add("B02", "Aggiornamento Vista Sedi Clienti: " & irows.ToString & " record")
                                                                        End If
                                                                        Debug.Print("Aggiornamento Vista Sedi Clienti: " & irows.ToString & " record")
                                                                        updTrans.Commit()
                                                                    End Using
                                                                    'Deprecata 09/02/2021
                                                                    'gestisco da mago tramite report
                                                                    'If listOfSEPA.Count > 0 Then
                                                                    '    Dim sDataFineSepa As String = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd")
                                                                    '    cmdqry.CommandText = "UPDATE MA_SDDMandate SET MandateLastdate=@Lastdate WHERE MandateCode=@Code"
                                                                    '    cmdqry.Parameters.Add("@Code", SqlDbType.VarChar)
                                                                    '    cmdqry.Parameters.Add("@Lastdate", SqlDbType.DateTime)
                                                                    '    For Each sepaCode As String In listOfSEPA
                                                                    '        cmdqry.Parameters("@Code").Value = sepaCode
                                                                    '        cmdqry.Parameters("@Lastdate").Value = sDataFineSepa
                                                                    '        cmdqry.ExecuteNonQuery()
                                                                    '        Application.DoEvents()
                                                                    '    Next
                                                                    '    cmdqry.Parameters.Clear()
                                                                    'End If
                                                                End If
                                                                cmdqry.CommandText = "DBCC TRACEOFF(610)"
                                                                cmdqry.ExecuteNonQuery()
                                                                Debug.Print("Fine update")
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
                    End Using
                End Using
            Catch ex As Exception
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & "OPERAZIONE INTERROTTA: " & GetCurrentMethod.Name)
                My.Application.Log.DefaultFileLogWriter.WriteLine(ex.Message & Environment.NewLine)
                Debug.Print(ex.Message)
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
                someTrouble = True
            End Try
            If Not someTrouble Then
                'Scrivi Gli ID ( faccio solo a fine elaborazione)
                AggiornaID(IdType.DocVend, idDoc, loggingTxt)
                idAndNumber.AppendLine(loggingTxt)
                l_Ids.Add("I02", loggingTxt)
                AggiornaFiscalNumber(annualita, nrRegIva, loggingTxt)
                idAndNumber.AppendLine(loggingTxt)
                l_Ids.Add("I02", loggingTxt)
                'Confermo scrittura
                My.Application.Log.DefaultFileLogWriter.WriteLine("Documenti importati: Fatture=" & totDoc(0).ToString & " Note di Credito=" & totDoc(1).ToString & Environment.NewLine)
                FLogin.lstStatoConnessione.Items.Add("Documenti importati: Fatture=" & totDoc(0).ToString & " Note di Credito=" & totDoc(1).ToString)
            End If
            'Scrivo i Log
            'TODO: riorganizzare, magari crearne 2 uno compatto con errori e avvisi e uno di dettaglio. vedi sotto NUOVI LOG
            If bulkMessage.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Inserimento Dati ---" & Environment.NewLine & bulkMessage.ToString)
            If errori.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Errori ---" & Environment.NewLine & errori.ToString)
                FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
                Debug.Print(errori.ToString)
            End If
            If sicuritalia.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Sicuritalia ---" & Environment.NewLine & sicuritalia.ToString)
            Debug.Print(sicuritalia.ToString)
            If listOfNewBancheCli.Count > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Nuove Banche Clienti (completare le informazioni su Mago) ---")
                For l = 0 To listOfNewBancheCli.Count - 1
                    My.Application.Log.DefaultFileLogWriter.WriteLine(listOfNewBancheCli(l).ToString)
                Next
                My.Application.Log.DefaultFileLogWriter.Write(vbLf)
            End If
            If warnings.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" ------------ Riassunto Warnings ------------")
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Queste modifiche non vengono salvate ---")
                'Riassunto Warning
                My.Application.Log.DefaultFileLogWriter.WriteLine(RiassuntoWarning(warnings).ToString)
                My.Application.Log.DefaultFileLogWriter.WriteLine(" - Dettaglio Warnings - " & Environment.NewLine & warnings.ToString)
                Debug.Print(warnings.ToString)
            End If
            If avvisi.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Avvisi ---" & Environment.NewLine & avvisi.ToString)
            Debug.Print(avvisi.ToString)
            If listOfNewClienti.Count > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Nuovi clienti ---")
                For l = 0 To listOfNewClienti.Count - 1
                    My.Application.Log.DefaultFileLogWriter.WriteLine(listOfNewClienti(l).ToString)
                Next
                My.Application.Log.DefaultFileLogWriter.Write(vbLf)
            End If
            If listOfNewSedi.Count > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Nuove Sedi --- ")
                For l = 0 To listOfNewSedi.Count - 1
                    My.Application.Log.DefaultFileLogWriter.WriteLine(listOfNewSedi(l).ToString)
                Next
                My.Application.Log.DefaultFileLogWriter.Write(vbLf)
            End If
            If aggiornamenti.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Aggiornamenti anagrafici (NUOVO VALORE ) [VECCHIO VALORE] ---" & Environment.NewLine & aggiornamenti.ToString)
            If idAndNumber.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Id e Numeratori ---" & Environment.NewLine & idAndNumber.ToString)
            Debug.Print(idAndNumber.ToString)

            Debug.Print("Gestione MA_SaleDoc" & " " & stopwatch.Elapsed.ToString)

            'SCRIVO I NUOVI LOG
            log.Testa.Nome = "Esito"
            log.Testa.Descrizione = "Documenti importati: Fatture=" & totDoc(0).ToString & " Note di Credito=" & totDoc(1).ToString
            OrdinaLog(log)

        End If
        stopwatch.Stop()
        Return Not someTrouble

    End Function

    Private Function GetNumeroColonne(dt As DataTable) As Integer

        If dt.Rows.Count > 0 AndAlso dt.Columns.Count >= NrColonneCsv Then
            Return dt.Columns.Count
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Passando il codice ISO restituisce l'enumerativo corretto
    ''' </summary>
    ''' <param name="ISOCode"></param>
    ''' <param name="IsoView"></param>
    ''' ''' <returns></returns>
    Private Function TrovaNaturaCliFor(ISOCode As String, IsoView As DataView, errorMsg As String, ByRef logs As StringBuilder) As Integer
        Dim esito As Integer = CustSuppKind.Nazionale
        Try

            If ISOCode = "IT" Then
                esito = CustSuppKind.Nazionale
            Else
                Dim ISOFound As Integer = IsoView.Find(ISOCode)
                If ISOFound = -1 Then
                    'ISO non presente !!
                    logs.Append("ETN1: ISO Stato non presente o incoerente sul " & errorMsg)
                    esito = CustSuppKind.Nazionale
                Else
                    esito = If(IsoView(ISOFound).Item("EUCountry").ToString = "1", CustSuppKind.CEE, CustSuppKind.ExtraCEE)
                End If
            End If
            Return esito
        Catch ex As Exception
            My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & "OPERAZIONE INTERROTTA: " & GetCurrentMethod.Name)
            My.Application.Log.DefaultFileLogWriter.WriteLine(ex.Message & Environment.NewLine)
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
            Return esito
        End Try
    End Function
    Private Function TrovaFiliale(ByVal codice As String, ByVal isArea As Boolean) As String
        Dim esito As String
        Dim s As String = Left(codice, 1).ToUpper
        Select Case s
            Case "A"
                esito = "01"    'TORINO
            Case "B"
                esito = "02"    'MILANO
            Case "C"
                esito = "03"    'ASTI
            Case "D"
                esito = "04"    'AOSTA
            Case "E"
                esito = "05"    'NOVARA
            Case "F"
                esito = "06"    'BERGAMO
            Case "G"
                esito = "07"    'GENOVA
            Case "H"
                esito = "08"    'VERCELLI/BIELLA
            Case "I"
                esito = "09"    'VARESE
            Case "J"
                If isArea Then
                    esito = "10"    'Area di vendita: SEDE
                Else
                    esito = "12"    'Conto Pdc:  SEDE
                End If
            Case "K"
                esito = "11"    'CUNEO
            Case "L"
                If isArea Then
                    esito = "12"    'Area di vendita: ALESSANDRIA
                Else
                    esito = "10"    'Conto Pdc:  ALESSANDRIA
                End If
            Case Else
                esito = s
        End Select
        Return esito
    End Function
    ''' <summary>
    ''' Passando il tipo documento TDxx restituisce l'enumerativo corretto
    ''' </summary>
    ''' <param name="Codice"></param>
    ''' <returns></returns>
    Private Function TrovaEIDocType(Codice As String) As Integer
        Dim esito As Integer

        Select Case Codice
            Case "TD01"
                esito = 22151169
            Case "TD02"
                esito = 22151170
            Case "TD03"
                esito = 22151171
            Case "TD04"
                esito = 22151172
            Case "TD05"
                esito = 22151173
            Case "TD06"
                esito = 22151174
            Case "TD16"
                esito = 22151175
            Case "TD17"
                esito = 22151176
            Case "TD18"
                esito = 22151177
            Case "TD19"
                esito = 22151178
            Case "TD20"
                esito = 22151179
            Case "TD21"
                esito = 22151180
            Case "TD22"
                esito = 22151181
            Case "TD23"
                esito = 22151182
            Case "TD24"
                esito = 22151183
            Case "TD25"
                esito = 22151184
            Case "TD26"
                esito = 22151185
            Case "TD27"
                esito = 22151186
            Case Else ' "Not Defined"
                esito = 22151168
        End Select
        Return esito
    End Function

    Private Function TrovaCdC(Codice As String) As String
        Dim s As String = Mid(Codice, InStr(Codice, "(", CompareMethod.Text) + 1, 2)

        Return s
    End Function

    ''' <summary>
    ''' Dati per la fatturazione elettronica
    ''' 2.2.1.7 e 8 Date di periodo
    ''' 2.2.1.16 Altri dati Gestionali
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="id"></param>
    ''' <param name="row"></param>
    Private Sub ScriviAltriDatiGestionaliFE(ByRef dt As DataTable, id As Integer, row As DataRow)
        Dim dr As DataRow
        Dim iLine As Integer

        'Solo su tracciato nuovo
        '28/04/2021 
        'DEPRECATA ( hanno avuto lamentele sopratutto dalla PA non le scrivo piu')
        If IsDeprecated AndAlso Not bOldtrack Then
            '2.2.1.7 <DataInizioPeriodo>
            If Not String.IsNullOrWhiteSpace(row.Item("IC").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = 0
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.DataInizioPeriodo"
                dr("FieldValue") = MagoFormatta(row.Item("IC").ToString, GetType(DateTime)).sDataSlash
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.2.1.8 <DataFinePeriodo>
            If Not String.IsNullOrWhiteSpace(row.Item("ID").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = 0
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.DataFinePeriodo"
                dr("FieldValue") = MagoFormatta(row.Item("ID").ToString, GetType(DateTime)).sDataSlash
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If
        '2.2.1.16 <AltriDatiGestionali>
        If Not String.IsNullOrWhiteSpace(row.Item("HX").ToString) Then
            'Primo Blocco 
            iLine += 1
            '2.2.1.16.1 <TipoDato>
            If Not String.IsNullOrWhiteSpace(row.Item("HX").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = iLine
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.AltriDatiGestionali.TipoDato"
                dr("FieldValue") = row.Item("HX").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.2.1.16.2 <RiferimentoTesto>
            If Not String.IsNullOrWhiteSpace(row.Item("HY").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = iLine
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.AltriDatiGestionali.RiferimentoTesto"
                dr("FieldValue") = row.Item("HY").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If

        If Not String.IsNullOrWhiteSpace(row.Item("HZ").ToString) Then
            'Secondo Blocco 
            iLine += 1
            '2.2.1.16.1 <TipoDato>
            If Not String.IsNullOrWhiteSpace(row.Item("HZ").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = iLine
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.AltriDatiGestionali.TipoDato"
                dr("FieldValue") = row.Item("HZ").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.2.1.16.2 <RiferimentoTesto>
            If Not String.IsNullOrWhiteSpace(row.Item("IA").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = iLine
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.AltriDatiGestionali.RiferimentoTesto"
                dr("FieldValue") = row.Item("IA").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If
    End Sub
    ''' <summary>
    ''' NON FUNZIONA ! Lo Gestisce MAGO tramite Default
    ''' Dati Articolo per la fatturazione elettronica Sicuritalia
    ''' 2.2.1.3.1 e 2 Tipo e Valore
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="id"></param>
    ''' <param name="row"></param>
    Private Sub ScriviDatiArticoliSicuritalia(ByRef dt As DataTable, id As Integer, row As DataRow)
        Dim dr As DataRow

        'Solo su tracciato nuovo
        If Not bOldtrack Then
            '2.2.1.3.1 <CodiceTipo>
            If Not String.IsNullOrWhiteSpace(row.Item("IF").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = 0
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.DataInizioPeriodo"
                dr("FieldValue") = row.Item("IF").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.2.1.3.2 <CodiceValore>
            If Not String.IsNullOrWhiteSpace(row.Item("IG").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = Integer.Parse(row.Item("BA"))
                dr("Line") = 0
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee.DataFinePeriodo"
                dr("FieldValue") = row.Item("IG").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If
    End Sub


    ''' <summary>
    ''' Dati aggiuntivi per la fatturazione elettronica Sicuritalia
    ''' 2.1.2 Dati Ordine Acquisto
    ''' 2.1.8 Dati DDT
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="id"></param>
    ''' <param name="row"></param>
    Private Function ScriviDatiAggiuntiviSicuritalia(ByRef dt As DataTable, id As Integer, row As DataRow, line As Integer, subLine As Integer) As Boolean
        Dim writeSomething As Boolean = False
        Dim dr As DataRow
        Dim newline As Integer = line
        Dim bOrdFound As Boolean
        Dim bDDTFound As Boolean
        '"IE" = "HG" + un numero loro che non mi viene passato
        If Not String.IsNullOrWhiteSpace(row.Item("IE").ToString) Then
            writeSomething = True
            '2.1.2 Dati ordine Acquisto  -  Codice NSO 
            'Colonna IE (ODA) Oda + nr Posizione 2.1.2.2
            'Colonna BA (NRRGH) Numero Riga 2.1.2.1
            'Colonna W ( RFCLH) Riferimento Cliente - Numero Ordine d'acquisto, unico per tutte le righe della fattura ==> Obbligatorio se si specificano CIG e/o CUP

            'Controllo che non esistano già  sulla stessa "Line"
            'potrebbe averlo scritto Un altra procedura ( tolgo filtro da Line)
            Dim key As Object() = {id, 0, 0, "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.IdDocumento"}
            dt.DefaultView.Sort = "DocId, DocSubID, SubLine, FieldName "
            Dim drv As DataRowView() = dt.DefaultView.FindRows(key)
            If drv.Length > 0 Then
                'nel caso di piu' righe mi prendo la prima e pace.
                'possibile incongruenza ma iniziamo cosi'
                newline = drv(0).Item("Line")
                bOrdFound = True
            Else
                'Ho già l'incremento
                newline = line
                '2.1.2.2 <IdDocumento> 
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = newline
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.IdDocumento"
                dr("FieldValue") = row.Item("IE").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.1.2.1 <RiferimentoNumeroLinea>
            dr = dt.NewRow
            dr("DocID") = id
            dr("DocSubID") = 0
            dr("Line") = newline
            dr("SubLine") = subLine
            dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.RiferimentoNumeroLinea"
            dr("FieldValue") = row.Item("BA").ToString
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            dt.Rows.Add(dr)


            ''2.1.2.3 <Data>
            'If Not String.IsNullOrWhiteSpace(row.Item("AK").ToString) Then
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = newline
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.Data"
            '    dr("FieldValue") = row.Item("AK").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If

            '2.1.2.4 <NumItem> 
            'In teoria il dato non ce l'ho, metto nr riga fattura
            'Se ho già una riga conl'idDocumento aggiungo
            Dim writeNuItem As Boolean = True
            If bOrdFound Then
                Dim keyNu As Object() = {id, 0, newline, 0, "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.NumItem"}
                dt.DefaultView.Sort = "DocId, DocSubID, Line, SubLine, FieldName "
                Dim drvNu As DataRowView() = dt.DefaultView.FindRows(keyNu)
                If drvNu.Length > 0 Then
                    drvNu(0)("FieldValue") = drvNu(0)("FieldValue") & "," & row.Item("BA").ToString
                    'CONTROLLO DI NON ANDARE OLTE 20 CARATTERI = LIMITE TRACCIATO AdE
                    If Len(drvNu(0)("FieldValue")) > 20 Then
                        Dim nValue As String = drvNu(0)("FieldValue")
                        Dim lastComa As Integer = InStrRev(nValue, ",", 20)
                        nValue = Left(nValue, lastComa - 1)
                        Select Case lastComa
                            Case 16, 17, 18
                                nValue += "..."
                            Case 19
                                nValue += ".."
                            Case 20
                                nValue += "."
                        End Select
                        drvNu(0)("FieldValue") = nValue
                    End If
                    writeNuItem = False
                End If
            End If
            If writeNuItem Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = newline
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.NumItem"
                dr("FieldValue") = row.Item("BA").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            ''2.1.2.5 <CodiceCommessaConvenzione>
            'If Not String.IsNullOrWhiteSpace(row.Item("HG").ToString) Then
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCommessaConvenzione"
            '    dr("FieldValue") = row.Item("HG").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If
            ''2.1.2.6 <CUP>
            'If Not String.IsNullOrWhiteSpace(row.Item("Y").ToString) AndAlso row.Item("Y").ToString <> "." Then
            '    isCigOrCup = True
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCUP"
            '    dr("FieldValue") = row.Item("Y").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If
            ''2.1.2.7 <CIG>
            'If Not String.IsNullOrWhiteSpace(row.Item("X").ToString) AndAlso row.Item("X").ToString <> "." Then
            '    isCigOrCup = True
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCIG"
            '    dr("FieldValue") = row.Item("X").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If
        End If

        If Not String.IsNullOrWhiteSpace(row.Item("ID").ToString) Then
            writeSomething = True
            Dim newlineDDT As Integer
            'Id documento 2.1.8 DatiDDT
            'FIX ScriviDatiAggiuntiviSicuritalia, colonne da fixare
            'Colonna HK (F2132)	 	
            'Colonna ID (C_DTAL)  Data AL
            'Colonna HM (F2134)  NumItem

            Dim key As Object() = {id, 0, 0, "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.NumeroDDT"}
            dt.DefaultView.Sort = "DocId, DocSubID, SubLine, FieldName "
            Dim drv As DataRowView() = dt.DefaultView.FindRows(key)
            If drv.Length > 0 Then
                'nel caso di piu' righe mi prendo la prima e pace.
                'possibile incongruenza ma iniziamo cosi'
                newlineDDT = drv(0).Item("Line")
                bDDTFound = True
            Else
                newlineDDT = 1
                '2.1.8.1 <NumeroDDT>
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = newlineDDT
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.NumeroDDT"
                dr("FieldValue") = "xxx" '"nrDDT"
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)

                '2.1.8.2 <DataDDT>
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = newlineDDT
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.DataDDT"
                dr("FieldValue") = MagoFormatta(row.Item("ID").ToString, GetType(DateTime)).sDataSlash
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            'Dim writeNuRif As Boolean = True
            'If bOrdFound Then
            '    Dim keyNu As Object() = {id, 0, newlineDDT, 0, "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.RiferimentoNumeroLinea"}
            '    dt.DefaultView.Sort = "DocId, DocSubID, Line, SubLine, FieldName "
            '    Dim drvNu As DataRowView() = dt.DefaultView.FindRows(keyNu)
            '    If drvNu.Length > 0 Then
            '        drvNu(0)("FieldValue") = drvNu(0)("FieldValue") & "," & row.Item("BA").ToString
            '        writeNuRif = False
            '    End If
            'End If


            '2.1.8.3 <RiferimentoNumeroLinea>
            dr = dt.NewRow
            dr("DocID") = id
            dr("DocSubID") = 0
            dr("Line") = newlineDDT
            dr("SubLine") = subLine
            dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.RiferimentoNumeroLinea"
            dr("FieldValue") = row.Item("BA").ToString
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            dt.Rows.Add(dr)

        End If
        Return writeSomething
    End Function

    ''' <summary>
    ''' Dati aggiuntivi per la fatturazione elettronica
    ''' 2.1.2 Dati Ordine Acquisto
    ''' 2.1.3 Dati Contratto
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="id"></param>
    ''' <param name="row"></param>
    Private Sub ScriviDatiAggiuntiviFE(ByRef dt As DataTable, id As Integer, row As DataRow, line As Integer)
        Dim dr As DataRow
        Dim isIdDocumento As Boolean

        If Not String.IsNullOrWhiteSpace(row.Item("W").ToString) Then
            '2.1.2 Dati ordine Acquisto
            'Colonna W (RFCLH)  Rif Cliente = Nr. ordine
            'Colonna X (CCIGH)  CIG 2.1.2.7
            'Colonna Y (CCUPH)  CUP 2.1.2.6
            Dim isCigOrCup As Boolean
            '2.1.2.6 <CUP>
            If Not String.IsNullOrWhiteSpace(row.Item("Y").ToString) AndAlso row.Item("Y").ToString <> "." Then
                isCigOrCup = True
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCUP"
                dr("FieldValue") = row.Item("Y").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.1.2.7 <CIG>
            If Not String.IsNullOrWhiteSpace(row.Item("X").ToString) AndAlso row.Item("X").ToString <> "." Then
                isCigOrCup = True
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCIG"
                dr("FieldValue") = row.Item("X").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.1.2.2 <IdDocumento> e ho anche un CIG o un CUP diversi da "."
            If Not String.IsNullOrWhiteSpace(row.Item("W").ToString) AndAlso isCigOrCup Then
                isIdDocumento = True
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.IdDocumento"
                dr("FieldValue") = row.Item("W").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If

        If Not String.IsNullOrWhiteSpace(row.Item("HG").ToString) Then
            '2.1.2 Dati ordine Acquisto  -  Codice NSO 
            'Colonna W (RFCLH) Rif Cliente = Nr. ordine ( e' già presente in quanto scritto sopra)
            'Colonna HG (CUFRH) Codice Commessa NSO 2.1.2.5
            'Colonna AK (CDFEH)  Cod.Fiscale Estero USATO per mettere la data ordine !!!

            '2.1.2.2 <IdDocumento>
            'Controllo che non esista già
            'Dim key As Object() = {id, 0, 1, 0, "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.IdDocumento"}
            'dt.DefaultView.Sort = "DocId, DocSubID, Line, SubLine, FieldName "
            'If Not String.IsNullOrWhiteSpace(row.Item("W").ToString) AndAlso dt.DefaultView.Find(key) = -1 Then
            If Not String.IsNullOrWhiteSpace(row.Item("W").ToString) AndAlso Not isIdDocumento Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.IdDocumento"
                dr("FieldValue") = row.Item("W").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.2.3 <Data>
            If Not String.IsNullOrWhiteSpace(row.Item("AK").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.Data"
                dr("FieldValue") = row.Item("AK").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.2.5 <CodiceCommessaConvenzione>
            If Not String.IsNullOrWhiteSpace(row.Item("HG").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCommessaConvenzione"
                dr("FieldValue") = row.Item("HG").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If

        If Not String.IsNullOrWhiteSpace(row.Item("HK").ToString) Then
            'Id documento 2.1.3 DatiContratto
            'Colonna HK (F2132)	 IdDocumento	
            'Colonna HL (F2133)  Data
            'Colonna HM (F2134)  NumItem

            '2.1.3.1 <RiferimentoNumeroLinea>
            'If Not String.IsNullOrWhiteSpace(row.Item("HJ").ToString) Then
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 1
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiContratto.RiferimentoNumeroLinea"
            '    dr("FieldValue") = MagoFormatta(row.Item("HJ").ToString, GetType(DateTime)).sDataSlash
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If

            '2.1.3.2 <IdDocumento>
            If Not String.IsNullOrWhiteSpace(row.Item("HK").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiContratto.IdDocumento"
                dr("FieldValue") = row.Item("HK").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.1.3.3 <Data>
            If Not String.IsNullOrWhiteSpace(row.Item("HL").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiContratto.Data"
                dr("FieldValue") = MagoFormatta(row.Item("HL").ToString, GetType(DateTime)).sDataSlash
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.3.4 <NumItem> 
            If Not String.IsNullOrWhiteSpace(row.Item("HM").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiContratto.NumItem"
                dr("FieldValue") = row.Item("HM").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.3.5 <CodiceCommessaConvenzione> 
            If Not String.IsNullOrWhiteSpace(row.Item("HN").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiContratto.CodiceCommessaConvenzione"
                dr("FieldValue") = row.Item("HN").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.3.6 <CUP> 
            If Not String.IsNullOrWhiteSpace(row.Item("HO").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiContratto.CodiceCUP"
                dr("FieldValue") = row.Item("HO").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            If Not String.IsNullOrWhiteSpace(row.Item("HP").ToString) Then
                '2.1.3.7 <CIG> 
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiContratto.CodiceCIG"
                dr("FieldValue") = row.Item("HP").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If

        If Not String.IsNullOrWhiteSpace(row.Item("HR").ToString) Then
            'Id documento 2.1.5 Dati  Ricezione
            'Colonna HR (F2152)	 IdDocumento	
            'Colonna HS (F2153)  Data
            'Colonna HT (F2154)  NumItem

            '2.1.5.1 <RiferimentoNumeroLinea>
            'If Not String.IsNullOrWhiteSpace(row.Item("HQ").ToString) Then
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 1
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiRicezione.RiferimentoNumeroLinea"
            '    dr("FieldValue") = MagoFormatta(row.Item("HQ").ToString, GetType(DateTime)).sDataSlash
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If

            '2.1.5.2 <IdDocumento>
            If Not String.IsNullOrWhiteSpace(row.Item("HR").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiRicezione.IdDocumento"
                dr("FieldValue") = row.Item("HR").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.1.3.3 <Data>
            If Not String.IsNullOrWhiteSpace(row.Item("HS").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiRicezione.Data"
                dr("FieldValue") = MagoFormatta(row.Item("HS").ToString, GetType(DateTime)).sDataSlash
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.3.4 <NumItem> 
            If Not String.IsNullOrWhiteSpace(row.Item("HT").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiRicezione.NumItem"
                dr("FieldValue") = row.Item("HT").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.3.5 <CodiceCommessaConvenzione> 
            If Not String.IsNullOrWhiteSpace(row.Item("HU").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiRicezione.CodiceCommessaConvenzione"
                dr("FieldValue") = row.Item("HU").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            '2.1.3.6 <CUP> 
            If Not String.IsNullOrWhiteSpace(row.Item("Hv").ToString) Then
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiRicezione.CodiceCUP"
                dr("FieldValue") = row.Item("Hv").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
            If Not String.IsNullOrWhiteSpace(row.Item("HW").ToString) Then
                '2.1.5.7 <CIG> 
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = line
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiRicezione.CodiceCIG"
                dr("FieldValue") = row.Item("HW").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If
        End If
    End Sub
    Private Function CreaSede(vistaSedi As DataView, origine As DataRow, clienord As DataRowView, destinazione As DataRow, ByRef log As StringBuilder) As DataRow

        vistaSedi.RowFilter = "CustSupp='" & origine.Item("AA").ToString & "' AND CustSuppType=" & CustSuppType.Cliente
        'Cerco tra le sedi esistenti in modo da non duplicare il numero del codice/contatore
        Dim iSedeCount As Integer = vistaSedi.Count
        iSedeCount += 1
        For xs As Integer = 0 To vistaSedi.Count - 1
            If vistaSedi(xs)("Branch") = iSedeCount.ToString("0000") Then
                iSedeCount += 1
                xs = -1
            End If
        Next
        vistaSedi.RowFilter = ""
        Try
            destinazione("Branch") = iSedeCount.ToString("0000")
            destinazione("CustSupp") = origine.Item("AA").ToString
            destinazione("CustSuppType") = CustSuppType.Cliente
            destinazione("CompanyName") = origine.Item("AB").ToString
            destinazione("FiscalCode") = origine.Item("AI").ToString
            destinazione("TaxIdNumber") = origine.Item("AJ").ToString
            destinazione("Address") = origine.Item("AC").ToString
            destinazione("City") = origine.Item("AE").ToString
            destinazione("County") = origine.Item("AF").ToString
            destinazione("Region") = Get_Regione(origine.Item("AF").ToString)
            destinazione("ZIPCode") = origine.Item("AD").ToString

            Dim sEmail As String = origine.Item("HH").ToString
            If Len(sEmail) > 128 Then log.AppendLine("A06: Email/pec troppo lunga su Sede Cliente: " & origine.Item("AA").ToString)
            destinazione("EMail") = Left(sEmail, 128).ToLower
            'drCustSede("ContactPerson") = drXLS(irxls).Item("C").ToString
            destinazione("ISOCountryCode") = Left(clienord.Item("M").ToString, 2).ToUpper
            destinazione("MailSendingType") = 12451840 'Tipo invio mail ( A: 12451841, non inviare: 12451840)
            destinazione("AdministrationReference") = origine.Item("HE").ToString
            destinazione("IPACode") = origine.Item("Z").ToString
            'drCustSede("Notes") = origine.Item("S").ToString
            destinazione("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            destinazione("TBModifiedID") = My.Settings.mLOGINID 'ID utente
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        Return destinazione
    End Function

    Private Function RiassuntoWarning(log As StringBuilder) As StringBuilder
        Dim t As String = log.ToString
        Dim ac As String = Environment.NewLine
        Dim ret As New StringBuilder

        For i = 1 To 14
            Dim nr As Integer
            Select Case i
                'TrovaNaturaCliFor
                Case 1
                    nr = ContaOccurrenze("WTN1:", t)
                    If nr > 0 Then ret.Append("WTN1:ISO Stato non presente o incoerente: " & nr.ToString & ac)
                'AggiornaAnagraficaCliente
                Case 2
                    nr = ContaOccurrenze("WA1:", t)
                    If nr > 0 Then ret.Append("WA1 - Mail: " & nr.ToString & ac)
                'AggiornaAnagraficaSede
                Case 3
                    nr = ContaOccurrenze("WAS1:", t)
                    If nr > 0 Then ret.Append("WAS1 - Codice Fiscale: " & nr.ToString & ac)
                Case 4
                    nr = ContaOccurrenze("WAS2:", t)
                    If nr > 0 Then ret.Append("WAS2 - Partita IVA inizia con 8 o 9: " & nr.ToString & ac)
                Case 5
                    nr = ContaOccurrenze("WAS3:", t)
                    If nr > 0 Then ret.Append("WAS3 - Partita IVA: " & nr.ToString & ac)
                Case 6
                    nr = ContaOccurrenze("WAS4:", t)
                    If nr > 0 Then ret.Append("WAS4 - Partita IVA inizia con 8 o 9: " & nr.ToString & ac)
                'AggiornaAnagraficadaClienOrd
                Case 7
                    nr = ContaOccurrenze("WAC1:", t)
                    If nr > 0 Then ret.Append("WAC1 - Flag Persona Fisica non impostato: " & nr.ToString & ac)
                Case 8
                    nr = ContaOccurrenze("WAC2:", t)
                    If nr > 0 Then ret.Append("WAC2 - Flag Persona Fisica impostato erroneamente: " & nr.ToString & ac)
                Case 9
                    nr = ContaOccurrenze("WAC3:", t)
                    If nr > 0 Then ret.Append("WAC3 - Controllare ISO Stato: " & nr.ToString & ac)
                Case 10
                    nr = ContaOccurrenze("WAC4:", t)
                    If nr > 0 Then ret.Append("WAC4 - Codice Fiscale: " & nr.ToString & ac)
                Case 11
                    nr = ContaOccurrenze("WAC5:", t)
                    If nr > 0 Then ret.Append("WAC5 - Partita IVA inizia con 8 o 9: " & nr.ToString & ac)
                Case 12
                    nr = ContaOccurrenze("WAC6:", t)
                    If nr > 0 Then ret.Append("WAC6 - Partita IVA: " & nr.ToString & ac)
                Case 13
                    nr = ContaOccurrenze("WAC7:", t)
                    If nr > 0 Then ret.Append("WAC7 - Partita IVA inizia con 8 o 9: " & nr.ToString & ac)
                Case 14
                    nr = ContaOccurrenze("WAC8:", t)
                    If nr > 0 Then ret.Append("WAC8 - Codice IPA Pubblica Amministrazione con lunghezza diversa da 6: " & nr.ToString & ac)
                Case Else

            End Select
        Next
        Return ret
    End Function
    Private Function ContaOccurrenze(cosa As String, dove As String) As Integer
        Return (dove.Length - dove.Replace(cosa, "").Length) / cosa.Length
    End Function

    ''' <summary>
    ''' Classe dedicata ai logs. I Warning contengono modfiche che NON vengono salvate
    ''' </summary>
    Private Class MyLogsString
        Public Property Avvisi As StringBuilder
        Public Property Warning As StringBuilder
        Public Sub New()
            Avvisi = New StringBuilder
            Warning = New StringBuilder
        End Sub
    End Class
    ''' <summary>
    ''' Aggiorna l'anagrafica della Sede
    ''' </summary>
    ''' <param name="origine">Riga della tabella di origina</param>
    ''' <param name="anagBranch">testat o sede del cliente</param>
    ''' <param name="opt">Altri dati / options</param>
    Private Function AggiornaAnagraficaSede(origine As DataRow, clienord As DataRowView, testaCli As DataRowView, anagBranch As DataRowView, opt As DataRowView) As MyLogsString
        Dim avvisi As New StringBuilder()
        Dim warnings As New StringBuilder()
        Dim mlog As New MyLogsString

        Try
            'Uso i dati FTPA300 ( fattura)
            With origine
                anagBranch.BeginEdit()
                'Questi dati sono stati controllati prima e non sono diversi

                'If anag.Item("Address").ToString <> .Item("AC").ToString Then
                '    avvisi.AppendLine("Indirizzo : (" & .Item("AC").ToString & ") [" & anag.Item("Address") & "]")
                '    anag.Item("Address") = .Item("AC").ToString
                'End If
                'If anag.Item("City").ToString <> .Item("AE").ToString Then
                '    avvisi.AppendLine("Città : (" & .Item("AE").ToString & ") [" & anag.Item("City") & "]")
                '    anag.Item("City") = .Item("AE").ToString
                'End If
                'If anag.Item("AdministrationReference").ToString <> .Item("HE").ToString Then
                '    avvisi.AppendLine("Riferimenti amministrazione : (" & .Item("HE").ToString & ") [" & anag.Item("AdministrationReference") & "]")
                '    anag.Item("AdministrationReference") = .Item("HE").ToString
                'End If

                If anagBranch.Item("CompanyName").ToString <> .Item("AB").ToString Then
                    'Potrebbe essere uguale ma avere degli a capo o invii
                    Dim sRagSoc As String = clienord.Item("F").ToString
                    sRagSoc = If(String.IsNullOrEmpty(clienord.Item("G").ToString), sRagSoc, sRagSoc & Environment.NewLine & clienord.Item("G").ToString)
                    If anagBranch.Item("CompanyName").ToString <> sRagSoc Then
                        avvisi.AppendLine("Ragione sociale : (" & sRagSoc & ") [" & anagBranch.Item("CompanyName") & "]")
                        anagBranch.Item("CompanyName") = sRagSoc
                    End If
                End If
                If UpdateProvincia AndAlso anagBranch.Item("County").ToString <> .Item("AF").ToString Then
                    avvisi.AppendLine("Provincia : (" & .Item("AF").ToString & ") [" & anagBranch.Item("County") & "]")
                    anagBranch.Item("County") = .Item("AF").ToString
                End If
                Dim regione As String = Get_Regione(.Item("AF").ToString)
                If anagBranch.Item("Region").ToString <> regione Then
                    avvisi.AppendLine("Regione : (" & regione & ") [" & anagBranch.Item("Region") & "]")
                    anagBranch.Item("Region") = regione
                End If
                If anagBranch.Item("ZIPCode").ToString <> .Item("AD").ToString Then
                    avvisi.AppendLine("CAP : (" & .Item("AD").ToString & ") [" & anagBranch.Item("ZIPCode") & "]")
                    anagBranch.Item("ZIPCode") = .Item("AD").ToString
                End If
                Dim iso As String = Left(clienord.Item("M").ToString, 2).ToUpper
                If iso = "IT" AndAlso anagBranch.Item("ISOCountryCode").ToString <> iso AndAlso Not String.IsNullOrWhiteSpace(iso) Then
                    '04/01/2023 : DEPRECATO Iso non deve essere sovrascritto.
                    'sposto log da Avvisi a Warnings e depreco la riga dove sovrascrivo
                    warnings.AppendLine("ISO Stato: (" & iso & ") [" & anagBranch.Item("ISOCountryCode") & "]")
                    If IsDeprecated Then anagBranch.Item("ISOCountryCode") = iso
                ElseIf iso <> "IT" Then
                    warnings.AppendLine("CONTROLLARE ISO Stato ")
                End If
                '12/04/2021 : Silvia mi dice di non aggiornare Cod.Fisc. e P.Iva ma di segnalarli solo.
                If anagBranch.Item("FiscalCode").ToString <> clienord.Item("O").ToString AndAlso Not String.IsNullOrWhiteSpace(clienord.Item("O").ToString) Then
                    If UpdatePIvaCodFisc Then
                        avvisi.AppendLine("Codice Fiscale : (" & clienord.Item("O").ToString & ") [" & anagBranch.Item("FiscalCode") & "]")
                        anagBranch.Item("FiscalCode") = clienord.Item("O").ToString
                    Else
                        warnings.AppendLine("WAS1: Codice Fiscale : (" & clienord.Item("O").ToString & ") [" & anagBranch.Item("FiscalCode") & "]")
                    End If
                End If
                'Sui clienti con p.Iva che inizia per 8 o 9  hanno solo CF quindi va tolta
                If anagBranch.Item("TaxIdNumber").ToString <> clienord.Item("N").ToString AndAlso Not String.IsNullOrWhiteSpace(clienord.Item("N").ToString) Then
                    If Left(clienord.Item("N").ToString, 1) = "8" OrElse Left(clienord.Item("N").ToString, 1) = "9" Then
                        If Not String.IsNullOrWhiteSpace(anagBranch.Item("TaxIdNumber").ToString) Then
                            warnings.AppendLine("WAS2: Partita IVA inizia con 8 o 9: (Cancellata) [" & anagBranch.Item("TaxIdNumber") & "]")
                            If UpdatePIvaCodFisc Then anagBranch.Item("TaxIdNumber") = ""
                        End If
                    Else
                        warnings.AppendLine("WAS3: Partita IVA : (" & clienord.Item("N").ToString & ") [" & anagBranch.Item("TaxIdNumber") & "]")
                        If UpdatePIvaCodFisc Then anagBranch.Item("TaxIdNumber") = clienord.Item("N").ToString
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(anagBranch.Item("TaxIdNumber").ToString) AndAlso (Left(clienord.Item("N").ToString, 1) = "8" OrElse Left(clienord.Item("N").ToString, 1) = "9") Then
                    warnings.AppendLine("WAS4: Partita IVA inizia con 8 o 9: (Cancellata) [" & anagBranch.Item("TaxIdNumber") & "]")
                    If UpdatePIvaCodFisc Then anagBranch.Item("TaxIdNumber") = ""
                End If

                If anagBranch.Item("Telephone1").ToString <> clienord.Item("S").ToString AndAlso Not String.IsNullOrWhiteSpace(clienord.Item("S").ToString) Then
                    avvisi.AppendLine("Telefono : (" & clienord.Item("S").ToString & ") [" & anagBranch.Item("Telephone1") & "]")
                    anagBranch.Item("Telephone1") = clienord.Item("S").ToString
                End If
                If anagBranch.Item("Fax").ToString <> clienord.Item("T").ToString AndAlso Not String.IsNullOrWhiteSpace(clienord.Item("T").ToString) Then
                    avvisi.AppendLine("Fax : (" & clienord.Item("T").ToString & ") [" & anagBranch.Item("Fax") & "]")
                    anagBranch.Item("Fax") = clienord.Item("T").ToString
                End If

                'Da qui' sono tutti dati comuni esclusivi presenti solo su FTPA300
                Dim sEmail As String = .Item("HH").ToString
                If Len(sEmail) > 128 Then
                    avvisi.AppendLine("Email/pec troppo lunga !")
                Else
                    If anagBranch.Item("EMail").ToString <> Trim(Left(sEmail, 128).ToLower) Then
                        avvisi.AppendLine("mail : (" & Trim(Left(sEmail, 128).ToLower) & ") [" & anagBranch.Item("EMail") & "]")
                        anagBranch.Item("EMail") = Trim(Left(sEmail, 128).ToLower)
                    End If
                End If

                'Se ho un codice ipa in "Z"
                'AggiornaAnagraficaCliente controllo ipa in Z
                'Se ho un IPA nel FTPA e in anagrafica e' nulla
                If String.IsNullOrWhiteSpace(anagBranch.Item("IPACode").ToString.Trim("0")) AndAlso Not String.IsNullOrWhiteSpace(.Item("Z").ToString.Trim("0")) Then
                    If anagBranch.Item("IPACode").ToString <> .Item("Z").ToString Then
                        avvisi.AppendLine("Codice IPA : (" & .Item("Z").ToString & ") [" & anagBranch.Item("IPACode") & "]")
                        anagBranch.Item("IPACode") = .Item("Z").ToString
                        ' If Not isSede Then
                        If testaCli.Item("ElectronicInvoicing").ToString <> "1" Then
                            testaCli.BeginEdit()
                            testaCli.Item("ElectronicInvoicing") = "1"
                            testaCli.EndEdit()
                        End If
                        If testaCli.Item("SendByCertifiedEmail").ToString <> "0" Then
                            testaCli.BeginEdit()
                            avvisi.AppendLine("Invia con pec : (NO) [" & testaCli.Item("SendByCertifiedEmail") & "]")
                            testaCli.Item("SendByCertifiedEmail") = "0"
                            testaCli.EndEdit()
                        End If
                    End If
                    'altrimenti se ho la pec e tutti zeri ( 
                ElseIf String.IsNullOrWhiteSpace(anagBranch.Item("IPACode").ToString.Trim("0")) AndAlso Not String.IsNullOrWhiteSpace(testaCli.Item("EICertifiedEMail")) Then
                    If testaCli.Item("ElectronicInvoicing").ToString <> "1" Then
                        testaCli.BeginEdit()
                        testaCli.Item("ElectronicInvoicing") = "1"
                        testaCli.EndEdit()
                    End If
                    If testaCli.Item("SendByCertifiedEmail").ToString <> "1" Then
                        testaCli.BeginEdit()
                        avvisi.AppendLine("Invia con pec : (SI) [" & testaCli.Item("SendByCertifiedEmail") & "]")
                        testaCli.Item("SendByCertifiedEmail") = "1"
                        testaCli.EndEdit()
                    End If

                End If
                anagBranch.EndEdit()

                ' Imposto sempre che venga gestita la fatturazione elettronica
                If testaCli.Item("ElectronicInvoicing").ToString <> "1" Then
                    testaCli.BeginEdit()
                    testaCli.Item("ElectronicInvoicing") = "1"
                    testaCli.EndEdit()
                End If

                'Dati su tabella MA_CustSuppCustomerOptions
                If anagBranch.Item("IPACode").ToString.Length = 6 Then
                    opt.BeginEdit()
                    If opt.Item("PublicAuthority").ToString <> "1" Then
                        avvisi.AppendLine("Pubblica amministrazione : (SI) [" & opt.Item("PublicAuthority") & "]")
                        opt.Item("PublicAuthority") = "1"
                    End If
                    If opt.Item("PASplitPayment").ToString <> "1" Then
                        avvisi.AppendLine("Split Payment : (SI) [" & opt.Item("PASplitPayment") & "]")
                        opt.Item("PASplitPayment") = "1"
                    End If
                    opt.EndEdit()
                End If
                If avvisi.Length > 0 Then mlog.Avvisi.Append("Cliente: " & .Item("AA").ToString & " Sede: " & anagBranch.Item("Branch") & " Doc. nr: " & .Item("O").ToString & Environment.NewLine & avvisi.ToString())
                If warnings.Length > 0 Then mlog.Warning.Append("Cliente: " & .Item("AA").ToString & " Sede: " & anagBranch.Item("Branch") & " Doc. nr: " & .Item("O").ToString & Environment.NewLine & warnings.ToString())
            End With
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        Return mlog
    End Function

    ''' <summary>
    ''' Aggiorna l'anagrafica del cliente da FTPA300
    ''' </summary>
    ''' <param name="origine">Riga della tabella di origina</param>
    ''' <param name="anag">testat o sede del cliente</param>
    ''' <param name="opt">Altri dati / options</param>
    Private Function AggiornaAnagraficaCliente(origine As DataRow, anag As DataRowView, opt As DataRowView) As MyLogsString
        Dim avvisi As New StringBuilder()
        Dim warnings As New StringBuilder()
        Dim mlog As New MyLogsString

        Try
            'Uso i dati FTPA300 ( fattura)
            With origine
                anag.BeginEdit()
                'Solo se ho delle sedi faccio alcuni aggiornamenti in quanto i dati principali sono stati processati dal CLIENORD
                'Dati presenti solo sulla testa
                Dim sPec As String() = Split(.Item("HI").ToString, ";")
                If sPec.Length > 0 Then
                    If Len(sPec(0)) > 64 Then
                        avvisi.AppendLine("PEC troppo lunga !")
                    Else
                        If anag.Item("EICertifiedEMail").ToString <> sPec(0).ToLower AndAlso Len(sPec(0)) > 0 Then
                            avvisi.AppendLine("Pec FE : (" & sPec(0).ToLower & ") [" & anag.Item("EICertifiedEMail") & "]")
                            anag.Item("EICertifiedEMail") = sPec(0).ToLower
                        End If
                    End If
                End If

                'Da qui' sono tutti dati comuni esclusivi presenti solo su FTPA300
                Dim sEmail As String = .Item("HH").ToString
                If Len(sEmail) > 128 Then
                    avvisi.AppendLine("Email/pec troppo lunga !")
                Else
                    If anag.Item("EMail").ToString <> Trim(Left(sEmail, 128).ToLower) Then
                        If UpdateEmailCliente Then
                            avvisi.AppendLine("mail : (" & Trim(Left(sEmail, 128).ToLower) & ") [" & anag.Item("EMail") & "]")
                            anag.Item("EMail") = Trim(Left(sEmail, 128).ToLower)
                        Else
                            warnings.AppendLine("WA1: mail : (" & Trim(Left(sEmail, 128).ToLower) & ") [" & anag.Item("EMail") & "]")
                        End If
                    End If
                End If

                'Se ho un codice ipa in "Z"
                'AggiornaAnagraficaCliente controllo ipa in Z
                'Se ho un IPA nel FTPA e in anagrafica e' nulla
                If String.IsNullOrWhiteSpace(anag.Item("IPACode").ToString.Trim("0")) AndAlso Not String.IsNullOrWhiteSpace(.Item("Z").ToString.Trim("0")) Then
                    If anag.Item("IPACode").ToString <> .Item("Z").ToString Then
                        avvisi.AppendLine("Codice IPA : (" & .Item("Z").ToString & ") [" & anag.Item("IPACode") & "]")
                        anag.Item("IPACode") = .Item("Z").ToString
                        ' If Not isSede Then
                        If anag.Item("ElectronicInvoicing").ToString <> "1" Then
                            anag.Item("ElectronicInvoicing") = "1"
                        End If
                        If anag.Item("SendByCertifiedEmail").ToString <> "0" Then
                            avvisi.AppendLine("Invia con pec : (NO) [" & anag.Item("SendByCertifiedEmail") & "]")
                            anag.Item("SendByCertifiedEmail") = "0"
                        End If
                    End If
                    'altrimenti  se ho la pec e tutti zeri ( 
                ElseIf String.IsNullOrWhiteSpace(anag.Item("IPACode").ToString.Trim("0")) AndAlso Not String.IsNullOrWhiteSpace(anag.Item("EICertifiedEMail")) Then
                    If anag.Item("ElectronicInvoicing").ToString <> "1" Then
                        anag.Item("ElectronicInvoicing") = "1"
                    End If
                    If anag.Item("SendByCertifiedEmail").ToString <> "1" Then
                        avvisi.AppendLine("Invia con pec : (SI) [" & anag.Item("SendByCertifiedEmail") & "]")
                        anag.Item("SendByCertifiedEmail") = "1"
                    End If
                End If

                ' Imposto sempre che venga gestita la fatturazione elettronica
                If anag.Item("ElectronicInvoicing").ToString <> "1" Then
                    anag.Item("ElectronicInvoicing") = "1"
                End If

                If anag.Item("AdministrationReference").ToString <> .Item("HE").ToString Then
                    avvisi.AppendLine("Riferimenti amministrazione : (" & .Item("HE").ToString & ") [" & anag.Item("AdministrationReference") & "]")
                    anag.Item("AdministrationReference") = .Item("HE").ToString
                End If
                anag.EndEdit()

                'Dati su tabella MA_CustSuppCustomerOptions
                If anag.Item("IPACode".ToString).Length = 6 Then
                    opt.BeginEdit()
                    If opt.Item("PublicAuthority").ToString <> "1" Then
                        avvisi.AppendLine("Pubblica amministrazione : (SI) [" & opt.Item("PublicAuthority") & "]")
                        opt.Item("PublicAuthority") = "1"
                    End If
                    If opt.Item("PASplitPayment").ToString <> "1" Then
                        avvisi.AppendLine("Split Payment : (SI) [" & opt.Item("PASplitPayment") & "]")
                        opt.Item("PASplitPayment") = "1"
                    End If
                    opt.EndEdit()
                End If
                If avvisi.Length > 0 Then mlog.Avvisi.Append("Cliente: " & .Item("AA").ToString & " Doc. nr: " & .Item("O").ToString & Environment.NewLine & avvisi.ToString())
                If warnings.Length > 0 Then mlog.Warning.Append("Cliente: " & .Item("AA").ToString & " Doc. nr: " & .Item("O").ToString & Environment.NewLine & warnings.ToString())
            End With
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        Return mlog
    End Function
    ''' <summary>
    ''' Aggiorna l'anagrafica del cliente partendo dal file CLIENORD.CSV
    ''' </summary>
    ''' <param name="origine">Riga della tabella di origina</param>
    ''' <param name="anag">Testata del cliente</param>
    ''' <param name="o">Altri dati / options</param>
    Private Function AggiornaAnagraficaDaClienOrd(origine As DataRow, clienord As DataRowView, anag As DataRowView, o As DataRowView) As MyLogsString
        Dim avvisi As New StringBuilder()
        Dim warnings As New StringBuilder()
        Dim mlog As New MyLogsString

        Try
            'Se ho il Flag useClienOrd aggiorno solo la testa del cliente con i dati CLIENORD
            With clienord
                anag.BeginEdit()
                'Potrebbe essere uguale ma avere degli a capo o invii
                'Controllo tramite RegEx
                Dim sRagSoc As String = .Item("F").ToString
                'Solo per le aziende [colonna E = 1] controllo il secondo campo ragione sociale
                If .Item("E").ToString = "1" Then sRagSoc = If(String.IsNullOrEmpty(.Item("G").ToString), sRagSoc, sRagSoc & Environment.NewLine & .Item("G").ToString)
                If Not String.Equals(Regex.Replace(anag.Item("CompanyName").ToString, "\s", ""), Regex.Replace(sRagSoc, "\s", ""), StringComparison.OrdinalIgnoreCase) Then
                    avvisi.AppendLine("Ragione sociale : (" & sRagSoc & ") [" & anag.Item("CompanyName") & "]")
                    anag.Item("CompanyName") = sRagSoc
                End If
                'TODO: cond pag, iva
                'Su clienord colonna E = 1 = azienda , = 2 persona fisica
                If .Item("E").ToString = "2" AndAlso anag.Item("NaturalPerson").ToString = "0" Then warnings.AppendLine("WAC1: Flag Persona Fisica non impostato")
                If .Item("E").ToString = "1" AndAlso anag.Item("NaturalPerson").ToString = "1" Then warnings.AppendLine("WAC2: Flag Persona Fisica impostato erroneamente")

                'If anag.Item("NaturalPerson").ToString <> sNatP Then
                '    avvisi.AppendLine("Persona Fisica : (" & sNatP & ") [" & anag.Item("NaturalPerson") & "]")
                '    anag.Item("NaturalPerson") = sNatP
                'End If
                'In I->M ho Sede Legale, in W-->AA Sede Fiscale
                If anag.Item("Address").ToString <> .Item("I").ToString Then
                    avvisi.AppendLine("Indirizzo : (" & .Item("I").ToString & ") [" & anag.Item("Address") & "]")
                    anag.Item("Address") = .Item("I").ToString
                End If
                If anag.Item("City").ToString <> .Item("J").ToString Then
                    avvisi.AppendLine("Città : (" & .Item("J").ToString & ") [" & anag.Item("City") & "]")
                    anag.Item("City") = .Item("J").ToString
                End If
                If UpdateProvincia AndAlso anag.Item("County").ToString <> .Item("K").ToString Then
                    avvisi.AppendLine("Provincia : (" & .Item("K").ToString & ") [" & anag.Item("County") & "]")
                    anag.Item("County") = .Item("K").ToString
                End If
                Dim regione = Get_Regione(.Item("K").ToString)
                If anag.Item("Region").ToString <> regione Then
                    avvisi.AppendLine("Regione : (" & regione & ") [" & anag.Item("Region") & "]")
                    anag.Item("Region") = regione
                End If
                Dim iCAP As Integer
                If Integer.TryParse(.Item("L").ToString, iCAP) AndAlso anag.Item("ZIPCode").ToString <> iCAP.ToString("00000") Then
                    avvisi.AppendLine("CAP : (" & iCAP.ToString("00000") & ") [" & anag.Item("ZIPCode") & "]")
                    anag.Item("ZIPCode") = iCAP.ToString("00000")
                End If
                Dim iso As String = Left(.Item("M").ToString, 2).ToUpper
                If iso = "IT" AndAlso anag.Item("ISOCountryCode").ToString <> iso AndAlso Not String.IsNullOrWhiteSpace(iso) Then
                    '04/01/2023 : DEPRECATO Iso non deve essere sovrascritto
                    'sposto log da Avvisi a Warnings e depreco la riga dove sovrascrivo
                    warnings.AppendLine("ISO Stato: (" & iso & ") [" & anag.Item("ISOCountryCode") & "]")
                    If IsDeprecated Then anag.Item("ISOCountryCode") = iso
                ElseIf iso <> "IT" Then
                    warnings.AppendLine("WAC3: Controllare ISO Stato ")
                End If
                If anag.Item("FiscalCode").ToString <> .Item("O").ToString AndAlso Not String.IsNullOrWhiteSpace(.Item("O").ToString) Then
                    warnings.AppendLine("WAC4: Codice Fiscale : (" & .Item("O").ToString & ") [" & anag.Item("FiscalCode") & "]")
                    If UpdatePIvaCodFisc Then anag.Item("FiscalCode") = .Item("O").ToString
                End If
                'Sui clienti con p.Iva che inizia per 8 o 9  hanno solo CF quindi va tolta
                If anag.Item("TaxIdNumber").ToString <> .Item("N").ToString AndAlso Not String.IsNullOrWhiteSpace(.Item("N").ToString) Then
                    If Left(.Item("N").ToString, 1) = "8" OrElse Left(.Item("N").ToString, 1) = "9" Then
                        If Not String.IsNullOrWhiteSpace(anag.Item("TaxIdNumber").ToString) Then
                            warnings.AppendLine("WAC5: Partita IVA inizia con 8 o 9: (Cancellata) [" & anag.Item("TaxIdNumber") & "]")
                            If UpdatePIvaCodFisc Then anag.Item("TaxIdNumber") = ""
                        End If
                    Else
                        warnings.AppendLine("WAC6: Partita IVA : (" & .Item("N").ToString & ") [" & anag.Item("TaxIdNumber") & "]")
                        If UpdatePIvaCodFisc Then anag.Item("TaxIdNumber") = .Item("N").ToString
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(anag.Item("TaxIdNumber").ToString) AndAlso (Left(.Item("N").ToString, 1) = "8" OrElse Left(.Item("N").ToString, 1) = "9") Then
                    warnings.AppendLine("WAC7: Partita IVA inizia con 8 o 9: (Cancellata) [" & anag.Item("TaxIdNumber") & "]")
                    If UpdatePIvaCodFisc Then anag.Item("TaxIdNumber") = ""
                End If
                If anag.Item("Telephone1").ToString <> .Item("S").ToString AndAlso Not String.IsNullOrWhiteSpace(.Item("S").ToString) Then
                    avvisi.AppendLine("Telefono : (" & .Item("S").ToString & ") [" & anag.Item("Telephone1") & "]")
                    anag.Item("Telephone1") = .Item("S").ToString
                End If
                If anag.Item("Fax").ToString <> .Item("T").ToString AndAlso Not String.IsNullOrWhiteSpace(.Item("T").ToString) Then
                    avvisi.AppendLine("Fax : (" & .Item("T").ToString & ") [" & anag.Item("Fax") & "]")
                    anag.Item("Fax") = .Item("T").ToString
                End If
                anag.EndEdit()

                If o.Item("CustomerClassification").ToString <> .Item("P").ToString AndAlso Not String.IsNullOrWhiteSpace(.Item("P").ToString) Then
                    o.BeginEdit()
                    avvisi.AppendLine("Classificazione cliente : (" & .Item("P").ToString & ") [" & o.Item("CustomerClassification") & "]")
                    o.Item("CustomerClassification") = .Item("P").ToString 'CLPAR
                    o.EndEdit()
                End If
                If IsDeprecated AndAlso o.Item("PublicAuthority").ToString <> "1" AndAlso .Item("P").ToString() = "A" Then 'CLPAR
                    '14/07/2021 : Aggiunto controllo su clienord per PA
                    '05/10/2021 : DEPRECATO la lettera A non e' significativa
                    o.BeginEdit()
                    avvisi.AppendLine("Pubblica Amministrazione : (1) [" & o.Item("PublicAuthority") & "]")
                    o.Item("PublicAuthority") = "1"
                    o.EndEdit()
                    If anag.Item("IPACode").ToString.Length <> 6 Then warnings.AppendLine("WAC8: Codice IPA Pubblica Amministrazione con lunghezza diversa da 6: [" & anag.Item("IPACode").ToString & "]")
                    If o.Item("PASplitPayment").ToString <> "1" Then
                        o.BeginEdit()
                        avvisi.AppendLine("Split Payment : (1) [" & o.Item("PASplitPayment") & "]")
                        o.Item("PASplitPayment") = "1"
                        o.EndEdit()
                    End If
                End If

                '10/09/2021 
                'DEPRECATA ()
                If IsDeprecated Then
                    Dim updCat As Boolean
                    Dim catClienord As String = .Item("C").ToString
                    Select Case catClienord
                        Case "O"
                            catClienord = "OR"
                        Case "S"
                            catClienord = "SP"
                        Case Else
                            catClienord = "OR"
                    End Select
                    Dim catMago = o.Item("Category").ToString
                    Select Case catMago
                        Case "OR", "SP", ""
                            updCat = catClienord <> catMago
                    End Select
                    If updCat Then
                        o.BeginEdit()
                        avvisi.AppendLine("Categoria cliente : (" & catClienord & ") [" & catMago & "]")
                        o.Item("Category") = catClienord
                        o.EndEdit()
                    End If
                End If

                If avvisi.Length > 0 Then mlog.Avvisi.Append("Cliente: " & origine.Item("AA").ToString & " Doc. nr: " & origine.Item("O").ToString & Environment.NewLine & avvisi.ToString())
                If warnings.Length > 0 Then mlog.Warning.Append("Cliente: " & origine.Item("AA").ToString & " Doc. nr: " & origine.Item("O").ToString & Environment.NewLine & warnings.ToString())

            End With

        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        Return mlog
    End Function

End Module

Module MovimentiAnaliticiDaFatture

    ''' <summary>
    ''' Le commese non vengono gestite
    ''' </summary>
    ''' <param name="filtri"></param>
    ''' <returns></returns>
    Public Function CreaAnaliticaDaFatture(filtri As FiltroAnalitica) As Boolean
        Dim errori As New StringBuilder()
        Dim avvisi As New StringBuilder()
        Dim annidiversiP As New StringBuilder()
        Dim annidiversiS As New StringBuilder()

        'dati succhiati dal filtro
        Dim fromDate As Date = filtri.DataDA
        Dim todate As Date = filtri.DataA
        Dim giaRegistrate As Boolean = filtri.GiaRegistrati
        Dim soloMovimentabili As Boolean = filtri.MovInAnalitica
        Dim nrFirst As String = filtri.NumberFirst
        Dim nrLast As String = filtri.NumberLast
        Dim allNumbers As Boolean = filtri.AllNumbers

        'variabili che lavorono a livello di documento
        Dim bIsAnnoPrecedente As Boolean
        Dim errorAnniDiversi As New StringBuilder()
        Dim bIsAnnoSuccessivo As Boolean
        Dim warningAnniDiversi As New StringBuilder()
        Dim debugging As New StringBuilder()

        'Testa Analitica - MA_CostAccEntries
        Dim okBulk As Boolean
        Dim someTrouble As Boolean
        Dim bIsSomething As Boolean
        Dim sFromDate As String = fromDate.ToString("yyyyMMdd")
        Dim sToDate As String = todate.ToString("yyyyMMdd")
        'Identificatore Prima Nota Analitica
        Dim idMovAna As Integer
        Dim iRefNo As Integer
        Dim Annualita As Short
        Try
            ' Inizializzo una query tra MA_SaleDoc e le righe con le informazioni che mi servono delle sole merci e servizi
            Using da As New SqlDataAdapter("SELECT MA_SaleDoc.DocNo, MA_SaleDoc.JournalEntryId, MA_SaleDoc.PostedToCostAccounting, MA_ChartOfAccounts.PostableInCostAcc,
                                                            MA_SaleDocDetail.* FROM MA_SaleDoc LEFT JOIN MA_SaleDocDetail
                                                            ON MA_SaleDoc.SaleDocId = MA_SaleDocDetail.SaleDocId JOIN MA_ChartOfAccounts ON MA_SaleDocDetail.Offset =  MA_ChartOfAccounts.Account 
                                                            WHERE (MA_SaleDocDetail.LineType = " & LineType.Merce & " OR MA_SaleDocDetail.LineType = " & LineType.Servizio & ") 
                                                            AND ( MA_SaleDoc.DocumentDate >=@FromDate  AND MA_SaleDoc.DocumentDate <=@ToDate ) 
                                                            AND (@AllNumbers = 1 Or (@AllNumbers = 0 and MA_SaleDoc.DocNo >=@NrFirst AND MA_SaleDoc.DocNo <=@NrLast )) 
                                                            AND MA_SaleDoc.PostedToCostAccounting = @GiaRegistrate 
                                                            AND MA_SaleDoc.PostedToAccounting = '1'
                                                            AND MA_ChartOfAccounts.PostableInCostAcc = @MovInAnalitica 
                                                            AND MA_SaleDoc.DocumentType IN (" & DocumentType.Fattura & " , " & DocumentType.FatturaAccompagnatoria & " , " & DocumentType.NotaCredito & " , " & DocumentType.AutoFattura & " , " & DocumentType.AutoNotaCredito & ")
                                                            ORDER BY MA_SaleDoc.DocNo, MA_SaleDocDetail.Offset", Connection)
                da.SelectCommand.Parameters.AddWithValue("@FromDate", sFromDate)
                da.SelectCommand.Parameters.AddWithValue("@ToDate", sToDate)
                da.SelectCommand.Parameters.AddWithValue("@AllNumbers", If(allNumbers, 1, 0))
                da.SelectCommand.Parameters.AddWithValue("@NrFirst", nrFirst)
                da.SelectCommand.Parameters.AddWithValue("@NrLast", nrLast)
                da.SelectCommand.Parameters.AddWithValue("@GiaRegistrate", If(giaRegistrate, "1", "0"))
                da.SelectCommand.Parameters.AddWithValue("@MovInAnalitica", If(soloMovimentabili, "1", "0"))
                Dim dtFatt As New DataTable("Fatture")
                da.Fill(dtFatt)
                'Dim dvFatt As New DataView(dtFatt, "", "", DataViewRowState.CurrentRows)
                If dtFatt.Rows.Count > 0 Then
                    bIsSomething = True
                    EditTestoBarra("Creo Movimenti Analitici")
                    FLogin.prgCopy.Value = 1
                    FLogin.prgCopy.Maximum = dtFatt.Rows.Count
                    FLogin.prgCopy.Step = 1
                    'Creo un adapter solo per aggiornare il flag di "Generato movimento analitico"
                    Dim sqry As String = "Select SaleDocId, PostedToCostAccounting FROM MA_SaleDoc WHERE (DocumentType=" & DocumentType.Fattura & " Or DocumentType=" & DocumentType.FatturaAccompagnatoria & " Or DocumentType=" & DocumentType.NotaCredito & ")  AND ( DocumentDate >=@FromDate AND DocumentDate <=@ToDate ) "
                    Using daSaleDoc As New SqlDataAdapter(sqry, Connection)
                        daSaleDoc.SelectCommand.Parameters.AddWithValue("@FromDate", sFromDate)
                        daSaleDoc.SelectCommand.Parameters.AddWithValue("@ToDate", sToDate)
                        Dim dtDoc As New DataTable("SaleDoc")
                        daSaleDoc.Fill(dtDoc)
                        Dim dvSaleDoc As New DataView(dtDoc, "", "SaleDocId", DataViewRowState.CurrentRows)
                        Dim cbSaleDoc = New SqlCommandBuilder(daSaleDoc)
                        daSaleDoc.UpdateCommand = cbSaleDoc.GetUpdateCommand(True)

                        Dim currentSaleDocId As Integer = dtFatt.Rows(0).Item("SaleDocId")
                        Dim currentDocNo As String = dtFatt.Rows(0).Item("DocNo").ToString
                        Dim currentOffset As String = dtFatt.Rows(0).Item("Offset").ToString
                        Dim currentDocDate As Date = dtFatt.Rows(0).Item("DocumentDate")
                        Dim currentPerc As Double
                        Dim tempAmount As Double
                        Annualita = Year(currentDocDate)
                        'Identificatore Prima Nota Analitica
                        idMovAna = LeggiID(IdType.MovAna)
                        iRefNo = LeggiNonFiscalNumber(CodeType.MovAna, Annualita)

                        Dim iSaleDoc As Integer = dvSaleDoc.Find(currentSaleDocId)
                        If iSaleDoc <> -1 Then
                            dvSaleDoc(iSaleDoc).Item("PostedToCostAccounting") = "1"
                        Else
                            errori.AppendLine("E52: doc: " & dtFatt.Rows(0).Item("DocNo") & " - Impossibile aggiornare lo stato. ID non trovato")
                        End If
                        Dim isNewMovAna As Boolean = True
                        'Dim ireg As Integer = 0 ' Idelamnete per il numero di registrazioni che faccio
                        Using dtMovAna As DataTable = CaricaSchema("MA_CostAccEntries", True)
                            Using dtMovAnaD As DataTable = CaricaSchema("MA_CostAccEntriesDetail", True)
                                Using dtCR As DataTable = CaricaSchema("MA_CrossReferences", True)
                                    sqry = "SELECT MA_SaleDocSummary.* FROM MA_SaleDocSummary JOIN MA_SaleDoc ON MA_SaleDoc.SaleDocId = MA_SaleDocSummary.SaleDocId WHERE (MA_SaleDoc.DocumentType=" & DocumentType.Fattura & " OR MA_SaleDoc.DocumentType=" & DocumentType.FatturaAccompagnatoria & " OR MA_SaleDoc.DocumentType=" & DocumentType.NotaCredito & ")  AND ( MA_SaleDoc.DocumentDate >=@FromDate AND MA_SaleDoc.DocumentDate <=@ToDate ) "
                                    Using daSaleDocSummary As New SqlDataAdapter(sqry, Connection)
                                        daSaleDocSummary.SelectCommand.Parameters.AddWithValue("@FromDate", sFromDate)
                                        daSaleDocSummary.SelectCommand.Parameters.AddWithValue("@ToDate", sToDate)
                                        Dim dtSaleDocSummary As New DataTable("MA_SaleDocSummary")
                                        daSaleDocSummary.Fill(dtSaleDocSummary)
                                        Dim dvSpese As New DataView(dtSaleDocSummary, "", "SaleDocId", DataViewRowState.CurrentRows)
                                        Using dtDefUserVendite As DataTable = CaricaSchema("MA_UserDefaultSales", True, True, "SELECT * FROM MA_UserDefaultSales WHERE Branch ='*' AND WorkerID = 0")
                                            Using dtDefContab As DataTable = CaricaSchema("MA_AccountingDefaults", True, True, "SELECT * FROM MA_AccountingDefaults WHERE AccountingDefaultsId =0")
                                                Dim qrySaldi As String = "SELECT * FROM MA_CostCentersBalances WHERE BalanceType=3145730"  ' AND BalanceYear = " & Year(currentDocDate) & " AND BalanceMonth = " & Month(currentDocDate)
                                                Using adpMovAnaSaldi As New SqlDataAdapter(qrySaldi, Connection)
                                                    Dim cbMar = New SqlCommandBuilder(adpMovAnaSaldi)
                                                    adpMovAnaSaldi.UpdateCommand = cbMar.GetUpdateCommand(True)
                                                    Dim dtMovAnaSaldi As New DataTable("MA_CostCentersBalances")
                                                    adpMovAnaSaldi.Fill(dtMovAnaSaldi)
                                                    Dim dvMovAnaSaldi As New DataView(dtMovAnaSaldi, "", "CostCenter,Account,BalanceYear,BalanceMonth", DataViewRowState.CurrentRows)
                                                    Dim drAna As DataRow = dtMovAna.NewRow
                                                    ' Dim drCR As DataRow = dtCR.NewRow
                                                    Dim iNrOffsetAna As Integer = 0
                                                    Dim iLineMovAna As Integer = 0  'Riga Movimento analitico
                                                    Debug.Print("Doc: " & dtFatt.Rows(0)("DocNo")) '& " Conto: " & dtFatt.Rows(0)("Account"))
                                                    'Ciclo sui documenti di vendita
                                                    For irow = 0 To dtFatt.Rows.Count - 1
                                                        With dtFatt.Rows(irow)
                                                            If .Item("SaleDocId") <> currentSaleDocId Then
                                                                'Fine Documento Fattura/ndc
                                                                'Se ha delle righe ( ovvero non ho avuto problemi con date precedenti)
                                                                If iLineMovAna > 0 Then
                                                                    'Ricalcolo le percentuali
                                                                    debugging.AppendLine("D1(drAna): ID:" & dtFatt.Rows(irow - 1).Item("SaleDocId") & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(irow - 1).Item("Line") & " Offset:" & currentOffset)
                                                                    RicalcolaPerc(dtMovAnaD, idMovAna, drAna("TotalAmount"))
                                                                    dtMovAna.Rows.Add(drAna)
                                                                Else
                                                                    Debug.Print("Elimino su Doc: " & drAna("DocNo") & " Conto: " & drAna("Account"))
                                                                    'Elimino la testa della registrazione
                                                                    Dim idDocToReset = dvSaleDoc.Find(drAna.Item("SaleDocId"))
                                                                    drAna.Delete()
                                                                    'Se non ho effettuato movimenti eliminino anche la cross referenze
                                                                    If iNrOffsetAna = 0 Then dtCR.Rows.RemoveAt(dtCR.Rows.Count - 1)
                                                                    'Resetto il flag "in analitica" sulla Fattura/ndC
                                                                    If idDocToReset <> -1 Then
                                                                        dvSaleDoc(idDocToReset).Item("PostedToCostAccounting") = "0"
                                                                    Else
                                                                        errori.AppendLine("E54: doc: " & dtFatt.Rows(0).Item("DocNo") & " - Impossibile aggiornare lo stato. ID non trovato")
                                                                    End If
                                                                End If
                                                                'Controllo se ho delle spese
                                                                'Inizio filtrando La vista delle spese per Saledocid
                                                                Dim iFound As Integer = dvSpese.Find(currentSaleDocId)
                                                                If iFound <> -1 Then
                                                                    'Bolli
                                                                    If dvSpese(iFound).Item("StampsCharges") > 0 Then
                                                                        idMovAna += 1
                                                                        iRefNo += 1
                                                                        'ireg += 1 ' BOH
                                                                        drAna = dtMovAna.NewRow
                                                                        drAna("Account") = dtDefUserVendite(0).Item("StampsCharges").ToString
                                                                        drAna("CustSupp") = dtFatt.Rows(irow - 1).Item("CustSupp")
                                                                        drAna("CustSupptype") = If(dtFatt.Rows(irow - 1).Item("CustSuppType") = CustSuppType.Cliente, CustSuppType.ClienteIgnora, CustSuppType.FornitoreIgnora)
                                                                        ' Se Nota di credito = Segno DARE
                                                                        drAna("DebitCreditSign") = If(dtFatt.Rows(irow - 1).Item("DocumentType") = DocumentType.NotaCredito, DareAvereIgnora.Dare, DareAvereIgnora.Avere)
                                                                        drAna("CodeType") = 7995393 ' Consuntivo
                                                                        drAna("RefNo") = Right(Year(currentDocDate), 2) & "/" & iRefNo.ToString("00000")
                                                                        drAna("PostingDate") = currentDocDate
                                                                        drAna("AccrualDate") = currentDocDate
                                                                        drAna("DocumentDate") = currentDocDate
                                                                        drAna("DocNo") = currentDocNo
                                                                        'drAna("RefDocNo") = ""
                                                                        drAna("TotalAmount") = dvSpese(iFound).Item("StampsCharges")
                                                                        drAna("Notes") = If(dtFatt.Rows(irow - 1).Item("DocumentType") = DocumentType.NotaCredito, "Nota credito ", "Fatt. ") & currentDocNo & " Cliente: " & dtFatt.Rows(irow - 1).Item("CustSupp").ToString
                                                                        drAna("EntryId") = idMovAna
                                                                        drAna("JournalEntryId") = dtFatt.Rows(irow - 1).Item("JournalEntryId")
                                                                        drAna("SaleDocId") = currentSaleDocId
                                                                        drAna("CRRefType") = CrossReference.PnotaEmesso ' Riferimento incrociato Doc. Emessi P.Nota
                                                                        drAna("CRRefID") = dtFatt.Rows(irow - 1).Item("JournalEntryId")
                                                                        drAna("CRRefSubID") = 0
                                                                        drAna("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                        drAna("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                        dtMovAna.Rows.Add(drAna)

                                                                        Dim isDar = drAna("DebitCreditSign") = 8192000
                                                                        Dim dtadecorr As Date = If(dtFatt.Rows(irow - 1).Item("ALL_CanoniDataI").ToString = sDataNulla, currentDocDate, dtFatt.Rows(irow - 1).Item("ALL_CanoniDataI"))
                                                                        Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                                        drAnaD("EntryId") = idMovAna
                                                                        drAnaD("Line") = 1 'iLineMovAna
                                                                        drAnaD("Account") = drAna("Account")
                                                                        drAnaD("PostingDate") = currentDocDate
                                                                        drAnaD("AccrualDate") = MagoFormatta(dtadecorr.ToString, GetType(String)).DataTempo
                                                                        drAnaD("CodeType") = 7995393 ' Consuntivo
                                                                        drAnaD("CostCenter") = dtFatt.Rows(irow - 1).Item("CostCenter")
                                                                        drAnaD("HasCostCenter") = 1
                                                                        drAnaD("Perc") = 100
                                                                        drAnaD("Qty") = 1
                                                                        drAnaD("DebitCreditSign") = If(isDar, 4980736, 4980737)
                                                                        drAnaD("Amount") = dvSpese(iFound).Item("StampsCharges")
                                                                        drAnaD("Notes") = "BOLLI"
                                                                        drAnaD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                        drAnaD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                        debugging.AppendLine("D7(drAnaD): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(irow - 1).Item("Line") & " Offset:" & dtDefUserVendite(0).Item("StampsCharges").ToString)
                                                                        dtMovAnaD.Rows.Add(drAnaD)
                                                                        Dim wAnarow As New MyAnaRow With {
                                                                                .Conto = drAnaD("Account").ToString,
                                                                                .Centro = drAnaD("CostCenter").ToString,
                                                                                .Anno = Year(dtadecorr),
                                                                                .Mese = Month(dtadecorr)
                                                                                }
                                                                        AggiornaSaldoAnaliticoDaFatt(wAnarow, isDar, drAnaD("Amount"), drAnaD("Qty"), dvMovAnaSaldi)

                                                                        'Creo il riferimento Cross Reference
                                                                        'Origine = P.Nota Doc emessi // Derivato =  Mov. Analitico
                                                                        Dim drCR As DataRow = dtCR.NewRow
                                                                        drCR("OriginDocType") = CrossReference.PnotaEmesso
                                                                        drCR("OriginDocID") = dtFatt.Rows(irow - 1).Item("JournalEntryId")
                                                                        drCR("OriginDocSubID") = 0
                                                                        drCR("OriginDocLine") = 0
                                                                        drCR("DerivedDocType") = CrossReference.MovimentoAnalitico
                                                                        drCR("DerivedDocID") = idMovAna
                                                                        drCR("DerivedDocSubID") = 0
                                                                        drCR("DerivedDocLine") = 0
                                                                        drCR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                        drCR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                        debugging.AppendLine("D8(drCR): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(irow - 1).Item("Line") & " Offset:" & dtDefUserVendite(0).Item("StampsCharges").ToString)
                                                                        dtCR.Rows.Add(drCR)
                                                                    End If
                                                                    'Abbuoni
                                                                    If dvSpese(iFound).Item("Allowances") > 0 Then
                                                                        idMovAna += 1
                                                                        iRefNo += 1
                                                                        'ireg += 1 ' BOH
                                                                        drAna = dtMovAna.NewRow
                                                                        drAna("CustSupp") = dtFatt.Rows(irow - 1).Item("CustSupp")
                                                                        drAna("CustSupptype") = If(dtFatt.Rows(irow - 1).Item("CustSuppType") = CustSuppType.Cliente, CustSuppType.ClienteIgnora, CustSuppType.FornitoreIgnora)
                                                                        'ATTENZIONE Se Nota di credito = Segno AVERE e conto sconti ribassi e abbuoni attivi
                                                                        drAna("DebitCreditSign") = If(dtFatt.Rows(irow - 1).Item("DocumentType") = DocumentType.NotaCredito, DareAvereIgnora.Avere, DareAvereIgnora.Dare)
                                                                        drAna("Account") = If(dtFatt.Rows(irow - 1).Item("DocumentType") = DocumentType.NotaCredito, dtDefContab(0).Item("CreditDiscount").ToString, dtDefContab(0).Item("DebitDiscount").ToString)
                                                                        drAna("CodeType") = 7995393 ' Consuntivo
                                                                        drAna("RefNo") = Right(Year(currentDocDate), 2) & "/" & iRefNo.ToString("00000")
                                                                        drAna("PostingDate") = currentDocDate
                                                                        drAna("AccrualDate") = currentDocDate
                                                                        drAna("DocumentDate") = currentDocDate
                                                                        drAna("DocNo") = currentDocNo
                                                                        'drAna("RefDocNo") = ""
                                                                        drAna("TotalAmount") = dvSpese(iFound).Item("Allowances")
                                                                        drAna("Notes") = If(dtFatt.Rows(irow - 1).Item("DocumentType") = DocumentType.NotaCredito, "Nota credito ", "Fatt. ") & currentDocNo & " Cliente: " & dtFatt.Rows(irow - 1).Item("CustSupp").ToString
                                                                        drAna("EntryId") = idMovAna
                                                                        drAna("JournalEntryId") = dtFatt.Rows(irow - 1).Item("JournalEntryId")
                                                                        drAna("SaleDocId") = currentSaleDocId
                                                                        drAna("CRRefType") = CrossReference.PnotaEmesso ' Riferimento incrociato Doc. Emessi P.Nota
                                                                        drAna("CRRefID") = dtFatt.Rows(irow - 1).Item("JournalEntryId")
                                                                        drAna("CRRefSubID") = 0
                                                                        drAna("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                        drAna("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                        dtMovAna.Rows.Add(drAna)

                                                                        Dim isDar = drAna("DebitCreditSign") = 8192000
                                                                        Dim dtadecorr As Date = If(dtFatt.Rows(irow - 1).Item("ALL_CanoniDataI").ToString = sDataNulla, currentDocDate, dtFatt.Rows(irow - 1).Item("ALL_CanoniDataI"))
                                                                        Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                                        drAnaD("EntryId") = idMovAna
                                                                        drAnaD("Line") = 1 'iLineMovAna
                                                                        drAnaD("Account") = drAna("Account")
                                                                        drAnaD("PostingDate") = currentDocDate
                                                                        drAnaD("AccrualDate") = MagoFormatta(dtadecorr.ToString, GetType(String)).DataTempo
                                                                        drAnaD("CodeType") = 7995393 ' Consuntivo
                                                                        drAnaD("CostCenter") = dtFatt.Rows(irow - 1).Item("CostCenter")
                                                                        drAnaD("HasCostCenter") = 1
                                                                        drAnaD("Perc") = 100
                                                                        drAnaD("Qty") = 1
                                                                        drAnaD("DebitCreditSign") = If(isDar, 4980736, 4980737)
                                                                        drAnaD("Amount") = dvSpese(iFound).Item("Allowances")
                                                                        drAnaD("Notes") = "ABBUONI"
                                                                        drAnaD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                        drAnaD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                        debugging.AppendLine("D9(drAnaD): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(irow - 1).Item("Line") & " Offset:" & drAnaD("Account"))
                                                                        dtMovAnaD.Rows.Add(drAnaD)
                                                                        Dim wAnarow As New MyAnaRow With {
                                                                                .Conto = drAnaD("Account").ToString,
                                                                                .Centro = drAnaD("CostCenter").ToString,
                                                                                .Anno = Year(dtadecorr),
                                                                                .Mese = Month(dtadecorr)
                                                                                }
                                                                        AggiornaSaldoAnaliticoDaFatt(wAnarow, isDar, drAnaD("Amount"), drAnaD("Qty"), dvMovAnaSaldi)

                                                                        'Creo il riferimento Cross Reference
                                                                        'Origine = P.Nota Doc emessi // Derivato =  Mov. Analitico
                                                                        Dim drCR As DataRow = dtCR.NewRow
                                                                        drCR("OriginDocType") = CrossReference.PnotaEmesso
                                                                        drCR("OriginDocID") = dtFatt.Rows(irow - 1).Item("JournalEntryId")
                                                                        drCR("OriginDocSubID") = 0
                                                                        drCR("OriginDocLine") = 0
                                                                        drCR("DerivedDocType") = CrossReference.MovimentoAnalitico
                                                                        drCR("DerivedDocID") = idMovAna
                                                                        drCR("DerivedDocSubID") = 0
                                                                        drCR("DerivedDocLine") = 0
                                                                        drCR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                        drCR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                        debugging.AppendLine("D10(drCR): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(irow - 1).Item("Line") & " Offset:" & drAnaD("Account"))
                                                                        dtCR.Rows.Add(drCR)
                                                                    End If

                                                                End If

                                                                If bIsAnnoPrecedente AndAlso annidiversiP.Length > 0 Then errorAnniDiversi.AppendLine("Doc: " & currentDocNo & Environment.NewLine & annidiversiP.ToString)
                                                                If bIsAnnoSuccessivo AndAlso annidiversiS.Length > 0 Then warningAnniDiversi.AppendLine("Doc: " & currentDocNo & Environment.NewLine & annidiversiS.ToString)
                                                                Debug.Print("Doc: " & .Item("DocNo"))
                                                                currentSaleDocId = .Item("SaleDocId")
                                                                currentDocNo = .Item("DocNo").ToString
                                                                currentOffset = .Item("Offset").ToString
                                                                currentDocDate = .Item("DocumentDate")
                                                                currentPerc = 0
                                                                iNrOffsetAna = 0
                                                                bIsAnnoPrecedente = False
                                                                bIsAnnoSuccessivo = False
                                                                annidiversiP = New StringBuilder()
                                                                annidiversiS = New StringBuilder()
                                                                iSaleDoc = dvSaleDoc.Find(currentSaleDocId)
                                                                If iSaleDoc <> -1 Then
                                                                    dvSaleDoc(iSaleDoc).Item("PostedToCostAccounting") = "1"
                                                                Else
                                                                    errori.AppendLine("E53: doc: " & currentDocNo & " - Impossibile aggiornare lo stato. ID non trovato (SaleDocId=" & currentSaleDocId.ToString & ")")
                                                                End If
                                                                isNewMovAna = True
                                                            End If
                                                            If Not isNewMovAna AndAlso .Item("Offset") <> currentOffset Then
                                                                'Fine Registrazione Analitica su questo conto

                                                                'Se ha delle righe ( ovvero non ho avuto problemi con date precedenti)
                                                                If iLineMovAna > 0 Then
                                                                    'Ricalcolo le percentuali
                                                                    debugging.AppendLine("D2(drAna): ID:" & dtFatt.Rows(irow).Item("SaleDocId") & " DocNo:" & .Item("DocNo") & " Line:" & .Item("Line") & " Offset:" & .Item("Offset"))
                                                                    RicalcolaPerc(dtMovAnaD, idMovAna, drAna("TotalAmount"))
                                                                    dtMovAna.Rows.Add(drAna)
                                                                Else
                                                                    Debug.Print("Elimino su Doc: " & drAna("DocNo") & " Conto: " & drAna("Account"))
                                                                    'Elimino la testa della registrazione
                                                                    drAna.Delete()
                                                                    'Se non ho effettuato movimenti eliminino anche la cross referenze
                                                                    dtCR.Rows.RemoveAt(dtCR.Rows.Count - 1)
                                                                End If
                                                                iNrOffsetAna += 1
                                                                currentOffset = .Item("Offset")
                                                                isNewMovAna = True
                                                            End If

                                                            'Creo la testa della registrazione
                                                            If isNewMovAna Then
                                                                isNewMovAna = False
                                                                idMovAna += 1
                                                                iRefNo += 1
                                                                'ireg += 1
                                                                iLineMovAna = 0
                                                                drAna = dtMovAna.NewRow
                                                                drAna("Account") = .Item("Offset")
                                                                drAna("CustSupp") = .Item("CustSupp")
                                                                drAna("CustSupptype") = If(.Item("CustSuppType") = CustSuppType.Cliente, CustSuppType.ClienteIgnora, CustSuppType.FornitoreIgnora)
                                                                ' Se Nota di credito = Segno DARE
                                                                drAna("DebitCreditSign") = If(.Item("DocumentType") = DocumentType.NotaCredito, DareAvereIgnora.Dare, DareAvereIgnora.Avere)
                                                                drAna("CodeType") = 7995393 ' Consuntivo
                                                                drAna("RefNo") = Right(Year(currentDocDate), 2) & "/" & iRefNo.ToString("00000")
                                                                drAna("PostingDate") = .Item("DocumentDate")
                                                                drAna("AccrualDate") = .Item("DocumentDate")
                                                                drAna("DocumentDate") = .Item("DocumentDate")
                                                                drAna("DocNo") = .Item("DocNo")
                                                                'drAna("RefDocNo") = ""
                                                                drAna("TotalAmount") = .Item("TaxableAmount")
                                                                drAna("Notes") = If(.Item("DocumentType") = DocumentType.NotaCredito, "Nota credito ", "Fatt. ") & .Item("DocNo").ToString & " Cliente: " & .Item("CustSupp").ToString
                                                                drAna("EntryId") = idMovAna
                                                                drAna("JournalEntryId") = .Item("JournalEntryId")
                                                                drAna("SaleDocId") = .Item("SaleDocid")
                                                                drAna("CRRefType") = CrossReference.PnotaEmesso ' Riferimento incrociato Doc. Emessi P.Nota
                                                                drAna("CRRefID") = .Item("JournalEntryId")
                                                                drAna("CRRefSubID") = 0 '.Item("Line")
                                                                drAna("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                drAna("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                                'Creo il riferimento Cross Reference
                                                                'Origine = P.Nota Doc emessi // Derivato =  Mov. Analitico
                                                                Dim drCR As DataRow = dtCR.NewRow
                                                                drCR("OriginDocType") = CrossReference.PnotaEmesso
                                                                drCR("OriginDocID") = .Item("JournalEntryId")
                                                                drCR("OriginDocSubID") = 0
                                                                drCR("OriginDocLine") = 0
                                                                drCR("DerivedDocType") = CrossReference.MovimentoAnalitico
                                                                drCR("DerivedDocID") = idMovAna
                                                                drCR("DerivedDocSubID") = 0
                                                                drCR("DerivedDocLine") = 0
                                                                drCR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                drCR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                debugging.AppendLine("D3(drCR): ID:" & dtFatt.Rows(irow).Item("SaleDocId") & " DocNo:" & .Item("DocNo") & " Line:" & .Item("Line") & " Offset:" & .Item("Offset"))
                                                                dtCR.Rows.Add(drCR)

                                                            Else
                                                                drAna("TotalAmount") += .Item("TaxableAmount")
                                                            End If
                                                            'Creo n righe
                                                            Dim importo As Double = .Item("TaxableAmount")
                                                            tempAmount = 0
                                                            Dim iCanoni As Double
                                                            If .Item("ALL_NrCanoni") = 0 Then
                                                                iCanoni = 1
                                                                avvisi.AppendLine("A01: NrCanoni = zero, imposto 1. Doc: " & .Item("DocNo") & " riga : " & .Item("Line"))
                                                            Else
                                                                iCanoni = Math.Abs(.Item("ALL_NrCanoni"))
                                                            End If
                                                            Dim importoMensile As Double = importo / iCanoni
                                                            Dim dataDecorrenza As Date
                                                            If .Item("ALL_CanoniDataI").ToString = sDataNulla Then
                                                                dataDecorrenza = .Item("DocumentDate")
                                                                avvisi.AppendLine("A02: DataInizio nulla, imposto Data Documento. Doc: " & .Item("DocNo") & " riga : " & .Item("Line"))
                                                            Else
                                                                dataDecorrenza = .Item("ALL_CanoniDataI")
                                                            End If
                                                            Dim isDare = drAna("DebitCreditSign") = 8192000
                                                            Dim CdC As String = .Item("CostCenter")
                                                            If String.IsNullOrWhiteSpace(CdC) Then errori.AppendLine("E50: Doc: " & .Item("DocNo") & " riga : " & .Item("Line") & " - Centro di Costo assente!")
                                                            Dim isNotOkAnnualita As Boolean = Annualita <> CShort(Year(dataDecorrenza))
                                                            For n = 0 To iCanoni - 1
                                                                ''''''''''''''''''''''
                                                                'Righe MA_CostAccEntriesDetail
                                                                ''''''''''''''''''''''
                                                                Dim dataMensile As DateTime = dataDecorrenza.AddMonths(n)
                                                                'Se vado all' anno precedente NON scrivere e segnalare !!!
                                                                'Sull'anno successivo scrivo ma segnala
                                                                If Annualita <> CShort(Year(dataMensile)) Then
                                                                    isNotOkAnnualita = True
                                                                    If CShort(Year(dataMensile)) < Annualita Then
                                                                        bIsAnnoPrecedente = True
                                                                        'Le righe con anni precedente non vanno generate
                                                                        annidiversiP.AppendLine("Riga:" & .Item("Line").ToString & " Conto:" & .Item("Offset") & " Competenza: " & dataMensile.ToString("dd-MM-yyyy"))
                                                                        'Conto ugualmente l'importo per poter scrivere i dati correttamente
                                                                        tempAmount += Math.Round(importoMensile, 2)
                                                                        '23/04/2021 lo sottraggo dal totale registrazione in modo che il report di Mago funzioni
                                                                        drAna("TotalAmount") -= Math.Round(importoMensile, 2)
                                                                        Continue For
                                                                    Else
                                                                        bIsAnnoSuccessivo = True
                                                                        annidiversiS.AppendLine("Riga:" & .Item("Line").ToString & " Conto:" & .Item("Offset") & " Competenza: " & dataMensile.ToString("dd-MM-yyyy"))
                                                                    End If
                                                                End If
                                                                iLineMovAna += 1
                                                                Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                                drAnaD("EntryId") = idMovAna
                                                                drAnaD("Line") = iLineMovAna
                                                                drAnaD("Account") = .Item("Offset")
                                                                drAnaD("PostingDate") = .Item("DocumentDate")
                                                                drAnaD("AccrualDate") = MagoFormatta(dataMensile.ToString, GetType(String)).DataTempo
                                                                drAnaD("CodeType") = 7995393 ' Consuntivo
                                                                drAnaD("CostCenter") = CdC
                                                                drAnaD("HasCostCenter") = 1
                                                                drAnaD("Perc") = 100
                                                                drAnaD("Qty") = 1
                                                                drAnaD("DebitCreditSign") = If(isDare, 4980736, 4980737)
                                                                'Se e' l'ultima riga saldo
                                                                drAnaD("Amount") = Math.Round(If(n = iCanoni - 1, importo - tempAmount, importoMensile), 2)
                                                                tempAmount += Math.Round(importoMensile, 2)
                                                                drAnaD("Notes") = Left(.Item("Description"), 64)
                                                                drAnaD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                                drAnaD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                                debugging.AppendLine("D4(drAnaD): ID:" & dtFatt.Rows(irow).Item("SaleDocId") & " DocNo:" & .Item("DocNo") & " Line:" & .Item("Line") & " Offset:" & .Item("Offset"))
                                                                dtMovAnaD.Rows.Add(drAnaD)
                                                                Dim wAnarow As New MyAnaRow With {
                                                            .Conto = drAnaD("Account").ToString,
                                                            .Centro = CdC,
                                                            .Anno = Year(dataMensile),
                                                            .Mese = Month(dataMensile)
                                                       }
                                                                AggiornaSaldoAnaliticoDaFatt(wAnarow, isDare, drAnaD("Amount"), drAnaD("Qty"), dvMovAnaSaldi)

                                                            Next

                                                        End With
                                                        AvanzaBarra()
                                                    Next
                                                    'FINE CICLO 

                                                    'Inserisco l'ultima testata 
                                                    Dim iLastRow As Integer = dtFatt.Rows.Count - 1
                                                    If iLineMovAna > 0 Then
                                                        'Ricalcolo le percentuali
                                                        debugging.AppendLine("D5(drAna): ID:" & dtFatt.Rows(iLastRow).Item("SaleDocId") & " DocNo:" & dtFatt.Rows(iLastRow).Item("DocNo") & " Line:" & dtFatt.Rows(iLastRow).Item("Line") & " Offset:" & dtFatt.Rows(iLastRow).Item("Offset"))
                                                        RicalcolaPerc(dtMovAnaD, idMovAna, drAna("TotalAmount"))
                                                        dtMovAna.Rows.Add(drAna)
                                                    Else
                                                        Debug.Print("Elimino su Doc: " & drAna("DocNo") & " Conto: " & drAna("Account"))
                                                        'Elimino la testa della registrazione
                                                        Dim idDocToReset = dvSaleDoc.Find(drAna.Item("SaleDocId"))
                                                        drAna.Delete()
                                                        'Se non ho effettuato movimenti eliminino anche la cross referenze
                                                        If iNrOffsetAna = 0 Then dtCR.Rows.RemoveAt(dtCR.Rows.Count - 1)
                                                        'Resetto il flag "in analitica" sulla Fattura/ndC
                                                        If idDocToReset <> -1 Then
                                                            dvSaleDoc(idDocToReset).Item("PostedToCostAccounting") = "0"
                                                        Else
                                                            errori.AppendLine("E55: doc: " & dtFatt.Rows(0).Item("DocNo") & " - Impossibile aggiornare lo stato. ID non trovato")
                                                        End If
                                                    End If

                                                    'Controllo se ho delle spese
                                                    'Inizio filtrando La vista delle spese per Saledocid
                                                    Dim liFound As Integer = dvSpese.Find(currentSaleDocId)
                                                    If liFound <> -1 Then
                                                        'Bolli
                                                        If dvSpese(liFound).Item("StampsCharges") > 0 Then
                                                            idMovAna += 1
                                                            iRefNo += 1
                                                            'ireg += 1 ' BOH
                                                            drAna = dtMovAna.NewRow
                                                            drAna("Account") = dtDefUserVendite(0).Item("StampsCharges").ToString
                                                            drAna("CustSupp") = dtFatt.Rows(iLastRow).Item("CustSupp")
                                                            drAna("CustSupptype") = If(dtFatt.Rows(iLastRow).Item("CustSuppType") = CustSuppType.Cliente, CustSuppType.ClienteIgnora, CustSuppType.FornitoreIgnora)
                                                            ' Se Nota di credito = Segno DARE
                                                            drAna("DebitCreditSign") = If(dtFatt.Rows(iLastRow).Item("DocumentType") = DocumentType.NotaCredito, DareAvereIgnora.Dare, DareAvereIgnora.Avere)
                                                            drAna("CodeType") = 7995393 ' Consuntivo
                                                            drAna("RefNo") = Right(Year(currentDocDate), 2) & "/" & iRefNo.ToString("00000")
                                                            drAna("PostingDate") = currentDocDate
                                                            drAna("AccrualDate") = currentDocDate
                                                            drAna("DocumentDate") = currentDocDate
                                                            drAna("DocNo") = currentDocNo
                                                            'drAna("RefDocNo") = ""
                                                            drAna("TotalAmount") = dvSpese(liFound).Item("StampsCharges")
                                                            drAna("Notes") = If(dtFatt.Rows(iLastRow).Item("DocumentType") = DocumentType.NotaCredito, "Nota credito ", "Fatt. ") & currentDocNo & " Cliente: " & dtFatt.Rows(iLastRow).Item("CustSupp").ToString
                                                            drAna("EntryId") = idMovAna
                                                            drAna("JournalEntryId") = dtFatt.Rows(iLastRow).Item("JournalEntryId")
                                                            drAna("SaleDocId") = currentSaleDocId
                                                            drAna("CRRefType") = CrossReference.PnotaEmesso ' Riferimento incrociato Doc. Emessi P.Nota
                                                            drAna("CRRefID") = dtFatt.Rows(iLastRow).Item("JournalEntryId")
                                                            drAna("CRRefSubID") = 0
                                                            drAna("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drAna("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                            dtMovAna.Rows.Add(drAna)

                                                            Dim isDar = drAna("DebitCreditSign") = 8192000
                                                            Dim dtadecorr As Date = If(dtFatt.Rows(iLastRow).Item("ALL_CanoniDataI").ToString = sDataNulla, currentDocDate, dtFatt.Rows(iLastRow).Item("ALL_CanoniDataI"))
                                                            Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                            drAnaD("EntryId") = idMovAna
                                                            drAnaD("Line") = 1 'iLineMovAna
                                                            drAnaD("Account") = drAna("Account")
                                                            drAnaD("PostingDate") = currentDocDate
                                                            drAnaD("AccrualDate") = MagoFormatta(dtadecorr.ToString, GetType(String)).DataTempo
                                                            drAnaD("CodeType") = 7995393 ' Consuntivo
                                                            drAnaD("CostCenter") = dtFatt.Rows(iLastRow).Item("CostCenter")
                                                            drAnaD("HasCostCenter") = 1
                                                            drAnaD("Perc") = 100
                                                            drAnaD("Qty") = 1
                                                            drAnaD("DebitCreditSign") = If(isDar, 4980736, 4980737)
                                                            drAnaD("Amount") = dvSpese(liFound).Item("StampsCharges")
                                                            drAnaD("Notes") = "BOLLI"
                                                            drAnaD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drAnaD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                            debugging.AppendLine("D7(drAnaD): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(iLastRow).Item("Line") & " Offset:" & dtDefUserVendite(0).Item("StampsCharges").ToString)
                                                            dtMovAnaD.Rows.Add(drAnaD)
                                                            Dim wAnarow As New MyAnaRow With {
                                                                                .Conto = drAnaD("Account").ToString,
                                                                                .Centro = drAnaD("CostCenter").ToString,
                                                                                .Anno = Year(dtadecorr),
                                                                                .Mese = Month(dtadecorr)
                                                                                }
                                                            AggiornaSaldoAnaliticoDaFatt(wAnarow, isDar, drAnaD("Amount"), drAnaD("Qty"), dvMovAnaSaldi)

                                                            'Creo il riferimento Cross Reference
                                                            'Origine = P.Nota Doc emessi // Derivato =  Mov. Analitico
                                                            Dim drCR As DataRow = dtCR.NewRow
                                                            drCR("OriginDocType") = CrossReference.PnotaEmesso
                                                            drCR("OriginDocID") = dtFatt.Rows(iLastRow).Item("JournalEntryId")
                                                            drCR("OriginDocSubID") = 0
                                                            drCR("OriginDocLine") = 0
                                                            drCR("DerivedDocType") = CrossReference.MovimentoAnalitico
                                                            drCR("DerivedDocID") = idMovAna
                                                            drCR("DerivedDocSubID") = 0
                                                            drCR("DerivedDocLine") = 0
                                                            drCR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drCR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                            debugging.AppendLine("D8(drCR): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(iLastRow).Item("Line") & " Offset:" & dtDefUserVendite(0).Item("StampsCharges").ToString)
                                                            dtCR.Rows.Add(drCR)
                                                        End If
                                                        'Abbuoni
                                                        If dvSpese(liFound).Item("Allowances") > 0 Then
                                                            idMovAna += 1
                                                            iRefNo += 1
                                                            'ireg += 1 ' BOH
                                                            drAna = dtMovAna.NewRow
                                                            drAna("CustSupp") = dtFatt.Rows(iLastRow).Item("CustSupp")
                                                            drAna("CustSupptype") = If(dtFatt.Rows(iLastRow).Item("CustSuppType") = CustSuppType.Cliente, CustSuppType.ClienteIgnora, CustSuppType.FornitoreIgnora)
                                                            'ATTENZIONE Se Nota di credito = Segno AVERE e conto sconti ribassi e abbuoni attivi
                                                            drAna("DebitCreditSign") = If(dtFatt.Rows(iLastRow).Item("DocumentType") = DocumentType.NotaCredito, DareAvereIgnora.Avere, DareAvereIgnora.Dare)
                                                            drAna("Account") = If(dtFatt.Rows(iLastRow).Item("DocumentType") = DocumentType.NotaCredito, dtDefContab(0).Item("CreditDiscount").ToString, dtDefContab(0).Item("DebitDiscount").ToString)
                                                            drAna("CodeType") = 7995393 ' Consuntivo
                                                            drAna("RefNo") = Right(Year(currentDocDate), 2) & "/" & iRefNo.ToString("00000")
                                                            drAna("PostingDate") = currentDocDate
                                                            drAna("AccrualDate") = currentDocDate
                                                            drAna("DocumentDate") = currentDocDate
                                                            drAna("DocNo") = currentDocNo
                                                            'drAna("RefDocNo") = ""
                                                            drAna("TotalAmount") = dvSpese(liFound).Item("Allowances")
                                                            drAna("Notes") = If(dtFatt.Rows(iLastRow).Item("DocumentType") = DocumentType.NotaCredito, "Nota credito ", "Fatt. ") & currentDocNo & " Cliente: " & dtFatt.Rows(iLastRow).Item("CustSupp").ToString
                                                            drAna("EntryId") = idMovAna
                                                            drAna("JournalEntryId") = dtFatt.Rows(iLastRow).Item("JournalEntryId")
                                                            drAna("SaleDocId") = currentSaleDocId
                                                            drAna("CRRefType") = CrossReference.PnotaEmesso ' Riferimento incrociato Doc. Emessi P.Nota
                                                            drAna("CRRefID") = dtFatt.Rows(iLastRow).Item("JournalEntryId")
                                                            drAna("CRRefSubID") = 0
                                                            drAna("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drAna("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                            dtMovAna.Rows.Add(drAna)

                                                            Dim isDar = drAna("DebitCreditSign") = 8192000
                                                            Dim dtadecorr As Date = If(dtFatt.Rows(iLastRow).Item("ALL_CanoniDataI").ToString = sDataNulla, currentDocDate, dtFatt.Rows(iLastRow).Item("ALL_CanoniDataI"))
                                                            Dim drAnaD As DataRow = dtMovAnaD.NewRow
                                                            drAnaD("EntryId") = idMovAna
                                                            drAnaD("Line") = 1 'iLineMovAna
                                                            drAnaD("Account") = drAna("Account")
                                                            drAnaD("PostingDate") = currentDocDate
                                                            drAnaD("AccrualDate") = MagoFormatta(dtadecorr.ToString, GetType(String)).DataTempo
                                                            drAnaD("CodeType") = 7995393 ' Consuntivo
                                                            drAnaD("CostCenter") = dtFatt.Rows(iLastRow).Item("CostCenter")
                                                            drAnaD("HasCostCenter") = 1
                                                            drAnaD("Perc") = 100
                                                            drAnaD("Qty") = 1
                                                            drAnaD("DebitCreditSign") = If(isDar, 4980736, 4980737)
                                                            drAnaD("Amount") = dvSpese(liFound).Item("Allowances")
                                                            drAnaD("Notes") = "ABBUONI"
                                                            drAnaD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drAnaD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                            debugging.AppendLine("D9(drAnaD): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(iLastRow).Item("Line") & " Offset:" & drAnaD("Account"))
                                                            dtMovAnaD.Rows.Add(drAnaD)
                                                            Dim wAnarow As New MyAnaRow With {
                                                                                .Conto = drAnaD("Account").ToString,
                                                                                .Centro = drAnaD("CostCenter").ToString,
                                                                                .Anno = Year(dtadecorr),
                                                                                .Mese = Month(dtadecorr)
                                                                                }
                                                            AggiornaSaldoAnaliticoDaFatt(wAnarow, isDar, drAnaD("Amount"), drAnaD("Qty"), dvMovAnaSaldi)

                                                            'Creo il riferimento Cross Reference
                                                            'Origine = P.Nota Doc emessi // Derivato =  Mov. Analitico
                                                            Dim drCR As DataRow = dtCR.NewRow
                                                            drCR("OriginDocType") = CrossReference.PnotaEmesso
                                                            drCR("OriginDocID") = dtFatt.Rows(iLastRow).Item("JournalEntryId")
                                                            drCR("OriginDocSubID") = 0
                                                            drCR("OriginDocLine") = 0
                                                            drCR("DerivedDocType") = CrossReference.MovimentoAnalitico
                                                            drCR("DerivedDocID") = idMovAna
                                                            drCR("DerivedDocSubID") = 0
                                                            drCR("DerivedDocLine") = 0
                                                            drCR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drCR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                            debugging.AppendLine("D10(drCR): ID:" & currentSaleDocId & " DocNo:" & currentDocNo & " Line:" & dtFatt.Rows(iLastRow).Item("Line") & " Offset:" & drAnaD("Account"))
                                                            dtCR.Rows.Add(drCR)
                                                        End If

                                                    End If
                                                    If bIsAnnoPrecedente AndAlso annidiversiP.Length > 0 Then errorAnniDiversi.AppendLine("Doc: " & currentDocNo & Environment.NewLine & annidiversiP.ToString)
                                                    If bIsAnnoSuccessivo AndAlso annidiversiS.Length > 0 Then warningAnniDiversi.AppendLine("Doc: " & currentDocNo & Environment.NewLine & annidiversiS.ToString)

                                                    Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                                        cmdqry.ExecuteNonQuery()
                                                        Dim irows As Integer
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
                                                                FLogin.lstStatoConnessione.Items.Add("Generati: " & dtMovAna.Rows.Count.ToString & " movimenti analitici,")
                                                            End If
                                                        End Using
                                                        If Not someTrouble Then
                                                            'Aggiornamento/inserimento Saldi Centri i Costo
                                                            irows = adpMovAnaSaldi.Update(dtMovAnaSaldi)
                                                            'Result.AppendLine("Aggiornamento Saldi analitici: " & irows.ToString & " record")
                                                            Debug.Print("Aggiornamento Saldi analitici: " & irows.ToString & " record")
                                                            'Aggiornamento flag su MA_SaleDoc
                                                            irows = daSaleDoc.Update(dtDoc)
                                                            Debug.Print("Aggiornamento FLAG documenti vendita: " & irows.ToString & " record")
                                                            'aggiornamenti.AppendLine("Aggiornamento Flag su Documenti: " & irows.ToString & " record")
                                                            FLogin.lstStatoConnessione.Items.Add("Relativi a " & irows.ToString & " documenti di vendita su " & dtDoc.Rows.Count.ToString & " complessivi.")
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
                Else
                    Debug.Print("Movimenti analitici - nessun documento estratto.")
                    FLogin.lstStatoConnessione.Items.Add("Movimenti analitici - nessun documento estratto.")
                End If
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
        If bIsSomething AndAlso Not someTrouble Then
            'Scrivi Gli ID ( faccio solo a fine elaborazione)
            AggiornaID(IdType.MovAna, idMovAna)
            AggiornaNonFiscalNumber(CodeType.MovAna, Annualita, iRefNo)
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
        If errorAnniDiversi.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Riparti di competenze analitiche su anni precedenti NON creati! ---" & Environment.NewLine & errorAnniDiversi.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riparti di competenze analitiche su anni precedenti NON creati! : Controllare file di Log")
        End If
        If warningAnniDiversi.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Riparti di competenze analitiche su anni successivi creati! ---" & Environment.NewLine & warningAnniDiversi.ToString)
            FLogin.lstStatoConnessione.Items.Add("WARNING ! Riparti di competenze analitiche su anni successivi creati! : Controllare file di Log")
        End If
        If IsDebugging AndAlso debugging.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Debugging ---" & Environment.NewLine & debugging.ToString)
        Return Not someTrouble

    End Function

    Private Class MyAnaRow
        Public Property Conto As String
        Public Property Centro As String
        Public Property Anno As Short
        Public Property Mese As Short

        Public Sub New()
            Conto = ""
            Centro = ""
            Anno = CShort(Year(Now))
            Mese = CShort(Month(Now))
        End Sub
    End Class

    Private Function AggiornaSaldoAnaliticoDaFatt(whatRow As MyAnaRow, isDebit As Boolean, valore As Double, qta As Double, vista As DataView) As Boolean
        Dim result As Boolean
        'vista.Sort = "CostCenter,Account,BalanceYear,BalanceMonth"
        Dim found As Integer = vista.Find({whatRow.Centro, whatRow.Conto, whatRow.Anno, whatRow.Mese})
        Try
            If found <> -1 Then
                With vista(found)
                    .BeginEdit()
                    If isDebit Then
                        .Item("ActualDebit") += valore
                        .Item("ActualDebitQty") += qta

                    Else
                        .Item("ActualCredit") += valore
                        .Item("ActualCreditQty") += qta
                    End If
                    .EndEdit()
                End With
            Else
                Dim r As DataRow = vista.Table.NewRow
                r.Item("CostCenter") = whatRow.Centro
                r.Item("Account") = whatRow.Conto
                r.Item("FiscalYear") = whatRow.Anno
                r.Item("BalanceYear") = whatRow.Anno
                r.Item("BalanceType") = 3145730
                r.Item("BalanceMonth") = whatRow.Mese
                If isDebit Then
                    r.Item("ActualDebit") = valore
                    r.Item("ActualCredit") = 0
                    r.Item("ActualDebitQty") = qta
                    r.Item("ActualCreditQty") = 0
                Else
                    r.Item("ActualDebit") = 0
                    r.Item("ActualCredit") = valore
                    r.Item("ActualDebitQty") = 0
                    r.Item("ActualCreditQty") = qta
                End If
                r.Item("BudgetDebitQty") = 0
                r.Item("ForecastDebitQty") = 0
                r.Item("BudgetCreditQty") = 0
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
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

    End Sub
End Module
Module SEPA

    ''' <summary>
    ''' Aggiorna il solo valore UMR Code (Codice Mandato) su BankAuthorization
    ''' Procedura DEPRECATA in quanto il campo BankAuthorization viene brasato dal ricalcolo che fa mago
    ''' </summary>
    ''' <param name="dts"></param>
    ''' <param name="bConIntestazione"></param>
    ''' <returns></returns>
    Public Function InsertSepaOnBankAuth(dts As DataSet, Optional bConIntestazione As Boolean = False) As Boolean
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        EditTestoBarra("Inserisco dati SEPA")
        FLogin.prgCopy.Value = 1
        'Inizializzo un datatable al file xls e un datarow con tutte le righe
        Dim irxls As Integer = 0
        Dim i As Integer = 0
        If bConIntestazione Then i = 1 ' Se c'e' l'intestazione parto dalla seconda riga
        Dim dtXLS As DataTable = dts.Tables("Foglio1")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Length > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Length
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Fatture")
                Using da As New SqlDataAdapter("SELECT Saledocid, DocNo, DocumentType, BankAuthorization FROM MA_SaleDoc Where  (DocumentType=" & DocumentType.Fattura & " Or DocumentType=" & DocumentType.FatturaAccompagnatoria & " Or DocumentType=" & DocumentType.NotaCredito & ")", Connection)
                    Dim dtDoc As New DataTable("Doc")
                    da.Fill(dtDoc)
                    Dim dvDoc As New DataView(dtDoc, "", "DocNo", DataViewRowState.CurrentRows)
                    Dim cbMar = New SqlCommandBuilder(da)
                    da.UpdateCommand = cbMar.GetUpdateCommand(True)

                    EditTestoBarra("Aggiornamento documenti in corso...")
                    For irxls = i To drXLS.Length - 1
                        With drXLS(irxls)
                            'TIREH Colonna G = 1=Testata 3=Riga Fattura 6=Riga descrittiva 9=Riepilogo fattura
                            Select Case .Item("G").ToString

                                Case "9"
                                    'Colonna "FM" solo se ho RID/SEPA e RIBA
                                    'Su rid ho iban
                                    If .Item("FN").ToString() = "RD" Then
                                        Dim ifo As Integer = dvDoc.Find(.Item("O"))
                                        If ifo <> -1 Then
                                            'Codice mandato. necessario in quanto mago non gestisce bene il multimandato per cliente non sapendo dove metterlo ....
                                            dvDoc(ifo).BeginEdit()
                                            dvDoc(ifo)("BankAuthorization") = .Item("FL").ToString ' Codice mandato ( non e' proprio qui' che devo metterlo)
                                            dvDoc(ifo).EndEdit()
                                        End If

                                    End If
                            End Select
                        End With
                        'Debug.Print("Fatt: " & iNrRighe.ToString() & " " & stopwatch2.Elapsed.ToString())
                        AvanzaBarra()
                    Next

                    Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                        'cmd.Transaction = Trans
                        cmdqry.ExecuteNonQuery()
                        Dim irows As Integer
                        irows = da.Update(dtDoc)
                        Debug.Print("Aggiornamento documenti: " & irows.ToString & " record")
                        cmdqry.CommandText = "DBCC TRACEOFF(610)"
                        cmdqry.ExecuteNonQuery()
                    End Using
                End Using

            Catch ex As Exception
                Debug.Print(ex.Message)
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End Try

            'Scrivo i LOG
            'If errori.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Errori ---" & Environment.NewLine & errori.ToString)
            Debug.Print("Aggiornamento sepa" & " " & stopwatch.Elapsed.ToString)

        End If
        stopwatch.Stop()
        Return True

    End Function

    Public Function InsertSepaOnFox(dts As DataSet, creaMandato As Boolean, Optional bConIntestazione As Boolean = False) As Boolean
        Dim errori As New StringBuilder()
        Dim loggingTxt As String = "Si"
        Dim bulkMessage As New StringBuilder()
        Dim okBulk As Boolean
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        EditTestoBarra("Inserisco dati SEPA su Fox Fields")
        FLogin.prgCopy.Value = 1
        'Inizializzo un datatable al file xls e un datarow con tutte le righe
        Dim irxls As Integer = 0
        Dim i As Integer = 0
        If bConIntestazione Then i = 1 ' Se c'e' l'intestazione parto dalla seconda riga
        Dim dtXLS As DataTable = dts.Tables("Foglio1")
        Dim drXLS As DataRow() = dtXLS.Select("G='9' AND FN='RD'")
        If drXLS.Length > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Length
            FLogin.prgCopy.Step = 1
            Try
                EditTestoBarra("Carico Dati: Fatture")
                Using da As New SqlDataAdapter("SELECT SaleDocId, DocNo, DocumentType, ALL_UMRCode, ALL_IBAN FROM MA_SaleDoc Where  (DocumentType=" & DocumentType.Fattura & " Or DocumentType=" & DocumentType.FatturaAccompagnatoria & " Or DocumentType=" & DocumentType.NotaCredito & ")", Connection)
                    Dim dtDoc As New DataTable("Doc")
                    da.Fill(dtDoc)
                    Dim dvDoc As New DataView(dtDoc, "", "DocNo", DataViewRowState.CurrentRows)
                    Dim cbMar = New SqlCommandBuilder(da)
                    da.UpdateCommand = cbMar.GetUpdateCommand(True)
                    'Per i Mandati SSD/RID
                    EditTestoBarra("Carico Schema: Mandati SSD")
                    Using dtSSDNew As DataTable = CaricaSchema("MA_SDDMandate", True, True, "SELECT * FROM MA_SDDMandate")
                        Dim dvSSD As New DataView(dtSSDNew, "", "Customer", DataViewRowState.CurrentRows)

                        EditTestoBarra("Aggiornamento documenti in corso...")
                        For irxls = i To drXLS.Length - 1
                            Dim drSSD As DataRow
                            With drXLS(irxls)
                                'TIREH Colonna G = 1=Testata 3=Riga Fattura 6=Riga descrittiva 9=Riepilogo fattura
                                Select Case .Item("G").ToString

                                    Case "9"
                                        'Colonna "FM" solo se ho RID/SEPA e RIBA
                                        'Su rid ho iban
                                        If .Item("FN").ToString() = "RD" Then
                                            Dim ifo As Integer = dvDoc.Find(.Item("O"))
                                            If ifo <> -1 Then
                                                Dim aIBAN As String() = EstrapolaIBAN(.Item("FM").ToString())
                                                'Codice mandato. necessario in quanto mago non gestisce bene il multimandato per cliente
                                                dvDoc(ifo).BeginEdit()
                                                dvDoc(ifo)("ALL_UMRCode") = .Item("FL").ToString ' Codice mandato
                                                dvDoc(ifo)("ALL_IBAN") = .Item("FM").ToString ' IBAN
                                                dvDoc(ifo).EndEdit()
                                                If creaMandato Then
                                                    'Cerco se esiste il codice mandato
                                                    dvSSD.RowFilter = "MandateLastdate = '" & sDataNulla & "' AND UMRCode='" & .Item("FL").ToString & "' AND Customer='" & .Item("AA").ToString & "'"
                                                    Dim ssdFound As Integer = dvSSD.Count()
                                                    If ssdFound = 0 Then
                                                        'Inserisco nuovo RID/SDD 
                                                        drSSD = dtSSDNew.NewRow
                                                        'Devo trovare il nuovo contatore dei mandati
                                                        dvSSD.RowFilter = "Customer='" & .Item("AA").ToString & "'"
                                                        Dim iMandateCounter As Integer = dvSSD.Count
                                                        drSSD("MandateCode") = .Item("AA").ToString & "_" & iMandateCounter.ToString
                                                        'Debug.Print("Nuovo mandato: " & drSSD("MandateCode"))
                                                        drSSD("UMRCode") = .Item("FL").ToString
                                                        drSSD("Customer") = .Item("AA").ToString
                                                        drSSD("CustomerBank") = aIBAN(3) & "-" & aIBAN(4)
                                                        drSSD("CustomerCA") = aIBAN(5)
                                                        drSSD("CustomerIBAN") = .Item("FM").ToString
                                                        drSSD("CustomerIBANIsManual") = "1"
                                                        drSSD("MandateType") = 2686989
                                                        drSSD("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                        drSSD("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                        dtSSDNew.Rows.Add(drSSD)
                                                        ' drSSD.AcceptChanges()
                                                        ' dvSSD.Table.ImportRow(drSSD)
                                                    End If
                                                End If
                                            Else
                                                errori.AppendLine("E04: Documento non trovato: " & .Item("O").ToString)

                                            End If
                                        End If
                                End Select
                            End With
                            'Debug.Print("Fatt: " & iNrRighe.ToString() & " " & stopwatch2.Elapsed.ToString())
                            AvanzaBarra()
                        Next

                        Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                            'cmd.Transaction = Trans
                            cmdqry.ExecuteNonQuery()
                            Using bulkTrans = Connection.BeginTransaction
                                EditTestoBarra("Salvataggio: SSD/RID")
                                okBulk = ScriviBulk("MA_SDDMandate", dtSSDNew, bulkTrans, Connection)
                                bulkMessage.AppendLine(loggingTxt)
                                If okBulk Then
                                    bulkTrans.Commit()
                                Else
                                    bulkTrans.Rollback()
                                End If
                            End Using
                            Dim irows As Integer
                            irows = da.Update(dtDoc)
                            Debug.Print("Aggiornamento documenti: " & irows.ToString & " record")
                            cmdqry.CommandText = "DBCC TRACEOFF(610)"
                            cmdqry.ExecuteNonQuery()
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                Debug.Print(ex.Message)
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End Try

            'Scrivo i LOG
            If bulkMessage.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Inserimento Dati ---" & Environment.NewLine & bulkMessage.ToString)
            If errori.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Errori ---" & Environment.NewLine & errori.ToString)
            Debug.Print("Aggiornamento sepa" & " " & stopwatch.Elapsed.ToString)

        End If
        stopwatch.Stop()
        Return okBulk

    End Function

End Module