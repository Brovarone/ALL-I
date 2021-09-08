Imports System.Data.SqlClient
Imports System.Text
Module Anagrafiche
    Public Function ClentiXLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Clienti - MA_CustSupp
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bDuplicate As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Creo Clienti")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables("ANCL200F")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Clienti")
                Using dtCF As DataTable = CaricaSchema("MA_CustSupp")
                    EditTestoBarra("Carico Schema: ")
                    Using dtCFOpt As DataTable = CaricaSchema("MA_CustSuppCustomerOptions")
                        EditTestoBarra("Scrittura Anagrafica")
                        'popolo un Datatable con i soli codici
                        Dim adpClienti As SqlDataAdapter
                        Dim ds As DataSet = New DataSet
                        adpClienti = New SqlDataAdapter("SELECT CustSupp FROM MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente, Connection)
                        adpClienti.Fill(ds, "Clienti")
                        'creo la dataview associata per le ricerche
                        Dim dvClienti As DataView = New DataView(ds.Tables("Clienti"), "", "CustSupp", DataViewRowState.CurrentRows)
                        'per le condizioni di pagamento 
                        Dim cmd As SqlCommand = New SqlCommand("SELECT Payment, ACGCode FROM MA_PaymentTerms", Connection)
                        adpClienti.SelectCommand = cmd
                        Dim dtCP As DataTable = New DataTable("CondPag")
                        adpClienti.Fill(dtCP)
                        Dim dvCP As DataView = New DataView(dtCP, "", "ACGCode", DataViewRowState.CurrentRows)
                        'per le contropartite 
                        cmd = New SqlCommand("Select Account, ACGCode FROM MA_ChartOfAccounts", Connection)
                        adpClienti.SelectCommand = cmd
                        Dim dtCntrp As DataTable = New DataTable("Contropartita")
                        adpClienti.Fill(dtCntrp)
                        Dim dvCntrp As DataView = New DataView(dtCntrp, "", "ACGCode", DataViewRowState.CurrentRows)
                        'Per le banche Azienda
                        cmd = New SqlCommand("Select * FROM MA_Banks where IsACompanyBank=1", Connection)
                        adpClienti.SelectCommand = cmd
                        Dim dtBanche As DataTable = New DataTable("Banche")
                        adpClienti.Fill(dtBanche)
                        Dim dvBanche As DataView = New DataView(dtBanche, "", "ABI,CAB", DataViewRowState.CurrentRows)
                        Dim aBanca(1) As String

                        Dim stopwatch1 As New System.Diagnostics.Stopwatch
                        stopwatch1.Start()
                        ' Ciclo le righe del file XLS
                        'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                        Dim irxls As Integer = 0
                        Dim i As Byte = 0
                        If bConIntestazione Then i = 1

                        Dim drCF As DataRow
                        Dim drCFOpt As DataRow

                        'popolo un Datatable con la tabella di transcodifica
                        'Dim dtCondPag As DataTable = dts.Tables("transcode")
                        'creo la dataview associata per le ricerche
                        'Dim dvCondPag As DataView = New DataView(dts.Tables("transcode"), "", "A", DataViewRowState.CurrentRows)

                        For irxls = i To drXLS.Count - 1
                            'Devo controllare che il cliente non esista già
                            If dvClienti.Find(drXLS(irxls).Item("D").ToString) = -1 Then

                                'Inserisco nuovo cliente
                                drCF = dtCF.NewRow
                                drCFOpt = dtCFOpt.NewRow

                                With drXLS(irxls) ' accorcio per comodità di scrittura
                                    Debug.Print("Codice " & .Item("D").ToString & " : " & .Item("E").ToString)
                                    'drCF("WorkingTime") = (irxls + 1).ToString ' Riga Excel

                                    drCF("CustSupp") = .Item("D").ToString
                                    Dim sRagSoc As String = .Item("E").ToString
                                    'se F allora persona fisica  
                                    drCF("NaturalPerson") = If(.Item("BO").ToString = "G", "0", "1")
                                    'Sulle persone fisiche la colonna "F" riporta nome e cognome, e risulta brutto
                                    If drCF("NaturalPerson") = "0" Then sRagSoc = If(String.IsNullOrEmpty(.Item("F").ToString), sRagSoc, sRagSoc & vbCrLf & .Item("F").ToString)
                                    drCF("CompanyName") = sRagSoc
                                    drCF("Address") = .Item("H").ToString
                                    drCF("City") = .Item("I").ToString
                                    drCF("County") = .Item("J").ToString
                                    drCF("ZIPCode") = .Item("K").ToString
                                    drCF("Telephone1") = .Item("L").ToString
                                    ' drCF ( "Telephone2")= .Item("M").toString
                                    drCF("FiscalCode") = .Item("P").ToString
                                    drCF("TaxIdNumber") = .Item("Q").ToString
                                    drCF("Currency") = If(.Item("R").ToString = "EURO", "EUR", .Item("R").ToString)
                                    If Not String.IsNullOrWhiteSpace(.Item("S").ToString) Then
                                        Dim iCP As Integer = dvCP.Find(.Item("S").ToString)
                                        If iCP <> -1 Then
                                            drCF("Payment") = dvCP.Item(iCP).Item("Payment").ToString
                                        Else
                                            drCF("Payment") = .Item("S").ToString
                                        End If
                                    End If

                                    Dim sbanca As String = .Item("T").ToString & "-" & .Item("U").ToString
                                    'Cerco Banca Azienda e c/c
                                    'Darà parecchi messaggi in quanto molti clienti pagano con contanti e sono qundi senza banca
                                    Erase aBanca
                                    ReDim aBanca(1)
                                    aBanca(0) = .Item("T").ToString ' ABI
                                    aBanca(1) = .Item("U").ToString ' ABI
                                    Dim ib As Integer = dvBanche.Find(aBanca)
                                    If ib <> -1 Then
                                        drCF("CompanyBank") = dvBanche(ib).Item("Bank")
                                        drCF("CustomerCompanyCA") = dvBanche(ib).Item("PreferredCA") 'C/C
                                        'drDoc("CompanyCA") = If(sbanca = "-", "", sbanca)  'Conto effetti
                                    Else
                                        result.AppendLine("Cliente: " & .Item("D").ToString() & " senza Banca Azienda.")
                                        'bNoBanca = True
                                    End If
                                    drCF("CustSuppBank") = If(sbanca = "-", "", sbanca)
                                    drCF("Account") = TrovaContropartita(.Item("AC").ToString & "01", dvCntrp)
                                    drCF("LinkedCustSupp") = .Item("AD").ToString
                                    drCF("Fax") = Left(.Item("BX").ToString, 15)
                                    drCF("CA") = .Item("BY").ToString
                                    drCF("email") = Left(.Item("CF").ToString, 128)
                                    'Checkare data
                                    'If .Item("").ToString <> "0" Then drCF("InsertionDate") = MagoFormatta(.Item("CG").ToString, GetType(DateTime)).DataTempo
                                    'Altri dati obbligatori
                                    drCF("CustSuppType") = CustSuppType.Cliente
                                    drCF("ISOCountryCode") = "IT"
                                    drCF("Presentation") = 1376260
                                    drCF("MailSendingType") = 12451840 'Tipo invio mail ( A: 12451841, non inviare: 12451840)
                                    'drCF("CostCenter") = .Item("BR").ToString ' Filiale / Ara di Vendita
                                    drCF("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                    drCF("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                    ''''''''''''''''''''''
                                    'Fattura Elettronica
                                    ''''''''''''''''''''''
                                    drCF("ElectronicInvoicing") = "1"
                                    drCF("IPACode") = "0000000"
                                    drCF("SendByCertifiedEmail") = "0"
                                    drCF("EICertifiedEMail") = ""

                                    ''''''''''''''''''''''''''''
                                    'MA_CustSuppCustomerOptions'
                                    ''''''''''''''''''''''''''''
                                    drCFOpt("Customer") = .Item("D").ToString
                                    drCFOpt("CustSuppType") = CustSuppType.Cliente
                                    drCFOpt("Area") = .Item("BR").ToString ' Filiale / Ara di Vendita
                                    drCFOpt("UseReqForPymt") = "1"
                                    drCFOpt("Category") = .Item("Z").ToString 'CATEG
                                    drCFOpt("CustomerClassification") = .Item("AE").ToString 'CLPAR
                                    If .Item("X").ToString <> "N" Then
                                        drCFOpt("TaxCode") = .Item("Y").ToString
                                        drCFOpt("ExemptFromTax") = "1"
                                    End If
                                    drCFOpt("PASplitPayment") = If(String.IsNullOrEmpty(.Item("EA").ToString) OrElse .Item("EA").ToString = "N", "0", "1") 'Se nulla o = N, no split )
                                    drCFOpt("DebitStampCharges") = If(String.IsNullOrEmpty(.Item("BD").ToString) OrElse .Item("BD").ToString = "N", "0", "1") ' Bolli SPMAF
                                    drCFOpt("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                    drCFOpt("TBModifiedID") = My.Settings.mLOGINID 'ID utente


                                End With
                                dtCF.Rows.Add(drCF)
                                dtCFOpt.Rows.Add(drCFOpt)
                            Else
                                bDuplicate = True
                                result.AppendLine("Cliente già presente: " & drXLS(irxls).Item("D").ToString & " " & drXLS(irxls).Item("E").ToString)
                                'MessageBox.Show("Cliente già presente:" & drXLS(irxls).Item("D").ToString & " " & drXLS(irxls).Item("E").ToString)
                                Continue For
                            End If
                            FLogin.prgCopy.PerformStep()
                            FLogin.prgCopy.Update()
                            Application.DoEvents()
                        Next
                        Debug.Print(result.ToString)
                        If bDuplicate Then MessageBox.Show(result.ToString)
                        My.Application.Log.WriteEntry(result.ToString)
                        Debug.Print("Elaborazione Clienti: " & dtCF.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                        EditTestoBarra("Salvataggio testate")
                        Using bulkTrans = Connection.BeginTransaction
                            okBulk = ScriviBulk("MA_CustSupp", dtCF, bulkTrans)
                            EditTestoBarra("Salvataggio options")
                            okBulk = ScriviBulk("MA_CustSuppCustomerOptions", dtCFOpt, bulkTrans)
                            bulkTrans.Commit()
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                MessageBox.Show(ex.Message)
            End Try

            Debug.Print("Creazione Clienti" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okBulk

    End Function
    Public Function ClientiPFXLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Clienti Persone Fisiche- MA_CustSupp
        'effettua sempre insert ( POSSIBILE SCONTRO DI CHIAVI)
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bDuplicate As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Creo Clienti - Persone fisiche")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables("ANFC200F")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Clienti Persone Fisiche")
                Using dtCFNat As DataTable = CaricaSchema("MA_CustSuppNaturalPerson")
                    EditTestoBarra("Scrittura Anagrafica")
                    'popolo un Datatable con i soli codici
                    Dim adpClienti As SqlDataAdapter
                    Dim ds As DataSet = New DataSet
                    adpClienti = New SqlDataAdapter("SELECT CustSupp, NaturalPerson FROM MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente, Connection)
                    adpClienti.Fill(ds, "Clienti")
                    'creo la dataview associata per le ricerche
                    Dim dvClienti As DataView = New DataView(ds.Tables("Clienti"), "", "CustSupp", DataViewRowState.CurrentRows)

                    Dim stopwatch1 As New System.Diagnostics.Stopwatch
                    stopwatch1.Start()
                    ' Ciclo le righe del file XLS
                    'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                    Dim irxls As Integer = 0
                    Dim i As Byte = 0
                    If bConIntestazione Then i = 1
                    Dim drCF As DataRow

                    For irxls = i To drXLS.Count - 1
                        'Devo controllare che il codice esista già altrimenti lo segnalo
                        If dvClienti.Find(drXLS(irxls).Item("D").ToString) = -1 Then
                            bDuplicate = True
                            result.AppendLine("Cliente PF - NON presente: " & drXLS(irxls).Item("D").ToString & " " & drXLS(irxls).Item("E").ToString)
                        End If
                        'Inserisco nuovo cliente
                        drCF = dtCFNat.NewRow
                        With drXLS(irxls) ' accorcio per comodità di scrittura
                            Debug.Print("Codice " & .Item("D").ToString & " : " & .Item("E").ToString)
                            drCF("CustSuppType") = CustSuppType.Cliente
                            drCF("CustSupp") = .Item("D").ToString
                            drCF("Name") = .Item("F").ToString
                            drCF("LastName") = .Item("E").ToString
                            'drCF("DateOfBirth") = MagoFormatta(.Item("L").ToString, GetType(DateTime)).DataTempo
                            'drCF("Gender") = IF(String.IsNullOrEmpty(.Item("M").ToString), 2097152, 2097153)
                            'drCF("CityOfBirth") = .Item("N").ToString
                            'drCF("CountyOfBirth") = .Item("O").ToString
                            'drCF("Professional") = IF(.Item("R").ToString = "EURO", "EUR", .Item("R").ToString)
                            'drCF("FeeTpl") = .Item("S").ToString
                            'drCF("INPSAccount") = .Item("AC").ToString
                            'drCF("Form770Letter") = .Item("AD").ToString
                            drCF("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                            drCF("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                        End With
                        dtCFNat.Rows.Add(drCF)
                        FLogin.prgCopy.PerformStep()
                        FLogin.prgCopy.Update()
                        Application.DoEvents()
                    Next
                    Debug.Print(result.ToString)
                    If bDuplicate Then MessageBox.Show(result.ToString)
                    My.Application.Log.WriteEntry(result.ToString)
                    Debug.Print("Elaborazione Clienti Persone Fisiche: " & dtCFNat.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                    EditTestoBarra("Salvataggio ")
                    Using bulkTrans = Connection.BeginTransaction
                        okBulk = ScriviBulk("MA_CustSuppNaturalPerson", dtCFNat, bulkTrans)
                        bulkTrans.Commit()
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Debug.Print("Creazione Clienti Persone Fisiche" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okbulk
    End Function
    Public Function SEPA_RID_XLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'SEPA/RID
        'effettua sempre insert ( POSSIBILE SCONTRO DI CHIAVI)
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bExixts As Boolean
        Dim aIBAN(5) As String
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Creo RID")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables("ACGSEP00F")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Mandati")
                Using dtRID As DataTable = CaricaSchema("MA_SDDMandate")
                    EditTestoBarra("Scrittura Mandati")
                    'popolo un Datatable con i soli codici
                    Dim adpRID As SqlDataAdapter
                    Dim ds As DataSet = New DataSet
                    adpRID = New SqlDataAdapter("SELECT * FROM MA_SDDMandate", Connection)
                    adpRID.Fill(ds, "RID")
                    'creo la dataview associata per le ricerche
                    Dim dvRID As DataView = New DataView(ds.Tables("RID"), "", "Customer", DataViewRowState.CurrentRows)
                    Dim dvRIDXls As DataView = New DataView(dtRID, "", "Customer", DataViewRowState.CurrentRows)

                    Dim stopwatch1 As New System.Diagnostics.Stopwatch
                    stopwatch1.Start()
                    ' Ciclo le righe del file XLS
                    'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                    Dim irxls As Integer = 0
                    Dim i As Byte = 0
                    If bConIntestazione Then i = 1
                    Dim drRID As DataRow

                    For irxls = i To drXLS.Count - 1
                        'Devo controllare se il codice esista già 
                        'Il campo MandateCode e' univoco, loro mi lo passsano UMRCode
                        'Controllo sul campo codice che valorizzo con il codice Cliente + un contatore
                        Dim ACGCliente As String = drXLS(irxls).Item("A").ToString
                        Dim ir As Integer = dvRID.Find(ACGCliente)
                        'Dim ir2 As Integer = dvRIDXls.Find(ACGCliente)
                        Dim drv As DataRowView() = dvRIDXls.FindRows(ACGCliente)
                        Dim iMandateCounter As Integer = 0
                        'Dim MagoRIDCode As String = drXLS(irxls).Item("A").ToString & "_" & iMandateCounter.ToString

                        If (ir <> -1 OrElse drv.Length > 0) Then
                            'Ho trovato già un cliente con il RID a questo punto aumento il contatore
                            bExixts = True
                            result.AppendLine("Cliente con piu' RID/SEPA: " & drXLS(irxls).Item("A").ToString)
                            iMandateCounter += drv.Length
                        End If
                        'Inserisco nuovo Mandato/Rid
                        drRID = dtRID.NewRow
                        With drXLS(irxls) ' accorcio per comodità di scrittura
                            Debug.Print("Codice: " & drXLS(irxls).Item("B").ToString & " Cliente:" & drXLS(irxls).Item("A").ToString)
                            drRID("MandateCode") = .Item("A").ToString & "_" & iMandateCounter.ToString
                            drRID("UMRCode") = .Item("B").ToString
                            drRID("Customer") = .Item("A").ToString
                            Erase aIBAN
                            ReDim aIBAN(5)
                            aIBAN = EstrapolaIBAN(.Item("C").ToString)
                            drRID("CustomerBank") = aIBAN(3) & "-" & aIBAN(4)
                            drRID("CustomerCA") = aIBAN(5)
                            drRID("CustomerIBAN") = .Item("C").ToString
                            drRID("CustomerIBANIsManual") = "1"
                            Dim data As String = "20" & If(String.IsNullOrWhiteSpace(.Item("E").ToString), .Item("F").ToString, .Item("E").ToString)
                            drRID("MandateFirstDate") = MagoFormatta(data, GetType(DateTime)).DataTempo
                            'drRID("MandateLastDate") = "1"
                            drRID("MandateType") = 2686989
                            drRID("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                            drRID("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                        End With
                        dtRID.Rows.Add(drRID)

                        FLogin.prgCopy.PerformStep()
                        FLogin.prgCopy.Update()
                        Application.DoEvents()
                    Next
                    Debug.Print(result.ToString)
                    If bExixts Then MessageBox.Show(result.ToString)
                    My.Application.Log.WriteEntry(result.ToString)
                    Debug.Print("Elaborazione Mandati: " & dtRID.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                    EditTestoBarra("Salvataggio ")
                    Using bulkTrans = Connection.BeginTransaction
                        okBulk = ScriviBulk("MA_SDDMandate", dtRID, bulkTrans)
                        bulkTrans.Commit()
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                MessageBox.Show(ex.Message)
            End Try
            Debug.Print("Creazione Mandati" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okBulk
    End Function

    Public Function DichIntentoCSV(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        'Dim result As StringBuilder = New StringBuilder("Clienti con dich Intento duplicata:")
        Dim bExixts As Boolean
        Dim newInsert As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Creo le Dichiarazioni di intento")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables(0)
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            'Identificatore  Documento
            Debug.Print("Estraggo ID")
            EditTestoBarra("Estraggo gli ID")
            Dim idDich As Integer = LeggiID(IdType.DicIntento)
            Dim nrProt As String(,) = LeggiDichInt()
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Dichiarazioni di intento")
                Using dtInt As DataTable = CaricaSchema("MA_DeclarationOfIntent")
                    'Creo Datatable e vista per gli altri dati dei clienti, mi serve per gestire il flag esente iva
                    Dim dtCliOpt = CaricaSchema("MA_CustSuppCustomerOptions", True, True, "SELECT * FROM MA_CustSuppCustomerOptions Where CustSuppType=" & CustSuppType.Cliente)
                    Using adpCliOpt As SqlDataAdapter = New SqlDataAdapter("Select * FROM MA_CustSuppCustomerOptions Where CustSuppType=" & CustSuppType.Cliente, Connection)
                        Dim cbMar = New SqlCommandBuilder(adpCliOpt)
                        adpCliOpt.UpdateCommand = cbMar.GetUpdateCommand(True)
                        Dim dvCliOpt As DataView = New DataView(dtCliOpt, "", "Customer", DataViewRowState.CurrentRows)

                        Dim dtIntNr As DataTable = CaricaSchema("MA_DeclarationOfIntentNumbers")
                        EditTestoBarra("Scrittura Dichiarazioni di intento")
                        'popolo un Datatable con i soli codici
                        Dim adpInt As SqlDataAdapter
                        Dim ds As DataSet = New DataSet
                        adpInt = New SqlDataAdapter("SELECT * FROM MA_DeclarationOfIntent WHERE CustSuppType=" & CustSuppType.Cliente, Connection)
                        adpInt.Fill(ds, "MA_DeclarationOfIntent")
                        'creo la dataview associata per le ricerche
                        Dim dvInt As DataView = New DataView(ds.Tables("MA_DeclarationOfIntent"), "", "CustSupp", DataViewRowState.CurrentRows)

                        Dim stopwatch1 As New System.Diagnostics.Stopwatch
                        stopwatch1.Start()
                        ' Ciclo le righe del file XLS
                        'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                        Dim irxls As Integer = 0
                        Dim i As Byte = 0
                        If bConIntestazione Then i = 1
                        Dim drInt As DataRow

                        For irxls = i To drXLS.Count - 1
                            'lavoro solo sulla prima riga
                            If drXLS(irxls).Item("J").ToString = 1 Then
                                Dim dichFound As Integer
                                'A seconda che esista il protocollo telematico faccio ricerche diverse
                                Dim custsupp = drXLS(irxls).Item("A").ToString
                                If Not String.IsNullOrWhiteSpace(drXLS(irxls).Item("L").ToString) Then
                                    Dim telProtocol As String = Mid(drXLS(irxls).Item("L").ToString, 42, 17)
                                    Dim docProtocol As String = Right(drXLS(irxls).Item("L").ToString, 6)
                                    dvInt.RowFilter = "CustSupp='" & custsupp & "' AND TelProtocol='" & telProtocol & "' AND DocProtocol='" & docProtocol & "'"
                                    dichFound = dvInt.Count
                                Else
                                    Dim fromdate As DateTime = MagoFormatta("20" & drXLS(irxls).Item("D").ToString, GetType(DateTime)).DataTempo
                                    Dim todate As DateTime = MagoFormatta("20" & drXLS(irxls).Item("E").ToString, GetType(DateTime)).DataTempo
                                    dvInt.RowFilter = "CustSupp='" & custsupp & "' AND FromDate='" & fromdate & "' AND ToDate='" & todate & "'"
                                    dichFound = dvInt.Count
                                End If
                                If dichFound = 0 Then
                                    'Inserisco nuovo Dich/Intento
                                    idDich += 1
                                    drInt = dtInt.NewRow
                                    With drXLS(irxls) ' accorcio per comodità di scrittura
                                        drInt("DeclId") = idDich
                                        Debug.Print("Cliente: " & drXLS(irxls).Item("A").ToString)
                                        drInt("CustSuppType") = CustSuppType.Cliente
                                        drInt("CustSupp") = .Item("A").ToString
                                        Dim iTipo As Integer
                                        Select Case .Item("H").ToString
                                            Case "1"
                                                iTipo = DeclType.Specifica
                                            Case "2"
                                                iTipo = DeclType.FinoA
                                                drInt("LimitAmount") = MagoFormatta(.Item("I").ToString, GetType(Double)).MONey
                                            Case "3"
                                                iTipo = DeclType.Periodo
                                        End Select
                                        drInt("DeclType") = iTipo
                                        drInt("DeclDate") = MagoFormatta("20" & .Item("C").ToString, GetType(DateTime)).DataTempo
                                        drInt("DeclYear") = "20" & Left(.Item("D").ToString, 2) ' Anno in base alla data inizio
                                        Dim codeFound As Boolean = False
                                        If nrProt IsNot Nothing Then
                                            For n As Short = 0 To nrProt.GetUpperBound(1)
                                                If nrProt(0, n) = drInt("DeclYear").ToString Then
                                                    codeFound = True
                                                    drInt("LogNo") = (Integer.Parse(nrProt(1, n)) + 1).ToString("000000")
                                                    nrProt(2, n) = sOggi
                                                End If
                                                If codeFound Then Exit For
                                            Next
                                        End If
                                        If Not codeFound Then
                                            'Devo creare una nuova riga
                                            newInsert = True
                                            Dim newI As Integer = If(nrProt Is Nothing, 0, nrProt.GetUpperBound(1) + 1)
                                            ReDim Preserve nrProt(2, newI)
                                            nrProt(0, newI) = drInt("DeclYear").ToString
                                            nrProt(1, newI) = "1"
                                            drInt("LogNo") = "000001"
                                            nrProt(2, newI) = sOggi
                                            Dim drNR As DataRow = dtIntNr.NewRow
                                            drNR("BalanceYear") = nrProt(0, newI)
                                            drNR("LastLogNo") = nrProt(1, newI)
                                            drNR("LastDate") = nrProt(2, newI)
                                            drNR("Received") = "1"
                                            drNR("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                            drNR("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                            dtIntNr.Rows.Add(drNR)

                                        End If

                                        drInt("CustomerNo") = .Item("G").ToString ' a volte e' il numero a volte e' incompleto.
                                        drInt("CustomerDate") = MagoFormatta("20" & .Item("C").ToString, GetType(DateTime)).DataTempo
                                        drInt("FromDate") = MagoFormatta("20" & .Item("D").ToString, GetType(DateTime)).DataTempo
                                        drInt("ToDate") = MagoFormatta("20" & .Item("E").ToString, GetType(DateTime)).DataTempo
                                        If Not String.IsNullOrWhiteSpace(.Item("L").ToString) Then
                                            drInt("TelProtocol") = Mid(.Item("L").ToString, 42, 17)
                                            drInt("DocProtocol") = Right(.Item("L").ToString, 6)
                                        End If
                                        drInt("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                        drInt("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                    End With
                                    dtInt.Rows.Add(drInt)

                                    FLogin.prgCopy.PerformStep()
                                    FLogin.prgCopy.Update()
                                    Application.DoEvents()
                                End If
                                'Aggiorno il flag sull'anagrafica cliente
                                Dim iCliopt As Integer = dvCliOpt.Find(drXLS(irxls).Item("A").ToString)
                                If iCliopt <> -1 AndAlso dvCliOpt(iCliopt)("ExemptFromTax") = "0" Then
                                    dvCliOpt(iCliopt).BeginEdit()
                                    dvCliOpt(iCliopt)("ExemptFromTax") = "1"
                                    dvCliOpt(iCliopt).EndEdit()
                                End If
                            End If
                        Next
                        Debug.Print(result.ToString)
                        If bExixts Then MessageBox.Show(result.ToString)
                        My.Application.Log.WriteEntry(result.ToString)
                        Debug.Print("Elaborazione Dich. Intento: " & dtInt.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                        EditTestoBarra("Salvataggio ")
                        Using bulkTrans = Connection.BeginTransaction
                            okBulk = ScriviBulk("MA_DeclarationOfIntent", dtInt, bulkTrans)
                            If newInsert Then okBulk = ScriviBulk("MA_DeclarationOfIntentNumbers", dtIntNr, bulkTrans)
                            If okBulk Then
                                bulkTrans.Commit()
                            Else
                                bulkTrans.Rollback()
                            End If
                        End Using
                        Dim irows As Integer = adpCliOpt.Update(dtCliOpt)
                        result.AppendLine("Aggiornamento Vista ClientiOptions: " & irows.ToString & " record")
                        Debug.Print("Aggiornamento Vista ClientiOptions: " & irows.ToString & " record")

                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                MessageBox.Show(ex.Message)
            End Try
            'Scrivi Gli ID ( faccio solo a fine elaborazione)
            AggiornaID(IdType.DicIntento, idDich)

            Debug.Print("Creazione Dich. intento" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okBulk
    End Function
    Public Function NoteClientiFoxproXLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Note ClientiFoxpre- ALLNoteFoxPro
        'effettua sempre insert ( POSSIBILE SCONTRO DI CHIAVI)
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bAbsent As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Creo Note Clienti da FoxPro")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables("CLI_NOTE")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Note Clienti da FoxPro")
                Using dtFox As DataTable = CaricaSchema("ALLNoteFoxPro")
                    EditTestoBarra("Scrittura Note")
                    'popolo un Datatable con i soli codici
                    Dim adpClienti As SqlDataAdapter
                    Dim ds As DataSet = New DataSet
                    adpClienti = New SqlDataAdapter("SELECT CustSupp FROM MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente, Connection)
                    adpClienti.Fill(ds, "Clienti")
                    'creo la dataview associata per le ricerche
                    Dim dvClienti As DataView = New DataView(ds.Tables("Clienti"), "", "CustSupp", DataViewRowState.CurrentRows)

                    Dim stopwatch1 As New System.Diagnostics.Stopwatch
                    stopwatch1.Start()
                    ' Ciclo le righe del file XLS
                    'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                    Dim irxls As Integer = 0
                    Dim i As Byte = 0
                    If bConIntestazione Then i = 1
                    Dim drCF As DataRow

                    For irxls = i To drXLS.Count - 1
                        If Not String.IsNullOrWhiteSpace(drXLS(irxls).Item("B").ToString) Then
                            'Devo controllare che il codice esista già altrimenti lo segnalo
                            If dvClienti.Find(drXLS(irxls).Item("A").ToString) = -1 Then
                                bAbsent = True
                                result.AppendLine("Cliente NON presente con Note: " & drXLS(irxls).Item("A").ToString)
                            End If
                            'Inserisco nuovo cliente
                            drCF = dtFox.NewRow
                            With drXLS(irxls) ' accorcio per comodità di scrittura
                                'Debug.Print("Codice " & .Item("A").ToString )
                                drCF("CustSuppType") = CustSuppType.Cliente
                                drCF("CustSupp") = .Item("A").ToString
                                drCF("NotaFoxPro") = .Item("B").ToString
                                drCF("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                drCF("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                            End With
                            Try
                                dtFox.Rows.Add(drCF)
                            Catch ex As Exception
                                Debug.Print(ex.Message)
                                My.Application.Log.WriteEntry(ex.Message)
                                'If ex.HResult = -2146232022 Then Continue For
                            End Try
                        End If
                        FLogin.prgCopy.PerformStep()
                        FLogin.prgCopy.Update()
                        Application.DoEvents()
                    Next
                    Debug.Print(result.ToString)
                    'If bAbsent Then MessageBox.Show(result.ToString)
                    My.Application.Log.WriteEntry(result.ToString)
                    Debug.Print("Elaborazione Note Clienti da FoxPro: " & dtFox.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                    EditTestoBarra("Salvataggio ")
                    Using bulkTrans = Connection.BeginTransaction
                        okBulk = ScriviBulk("ALLNoteFoxPro", dtFox, bulkTrans)
                        bulkTrans.Commit()
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                My.Application.Log.WriteEntry(ex.Message)
            End Try
            Debug.Print("Creazione Note Clienti da Foxpro" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okbulk
    End Function

    Public Function EstrapolaIBAN(IBAN As String) As String()
        IBAN = UCase(Replace(IBAN, " ", ""))
        Dim s(5) As String
        s(0) = Left(IBAN, 2) 'codstato
        s(1) = Mid(IBAN, 3, 2) ' Carattere di controllo
        s(2) = Mid(IBAN, 5, 1) 'cin
        s(3) = Mid(IBAN, 6, 5) 'abi
        s(4) = Mid(IBAN, 11, 5) 'cab
        s(5) = Mid(IBAN, 16, 12) 'cc
        Return s
    End Function

    Public Function FornitoriXLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Fornitori - MA_CustSupp
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bDuplicate As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Creo Fornitori")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables("ANFO200F")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Fornitori")
                Using dtCF As DataTable = CaricaSchema("MA_CustSupp")
                    EditTestoBarra("Carico Schema: ")
                    Using dtCFOpt As DataTable = CaricaSchema("MA_CustSuppSupplierOptions")
                        EditTestoBarra("Scrittura Anagrafica")
                        'popolo un Datatable con i soli codici
                        Dim adpFor As SqlDataAdapter
                        Dim ds As DataSet = New DataSet
                        adpFor = New SqlDataAdapter("SELECT CustSupp FROM MA_CustSupp WHERE CustSuppType=" & CustSuppType.Fornitore, Connection)
                        adpFor.Fill(ds, "Fornitori")
                        'creo la dataview associata per le ricerche
                        Dim dvFornitori As DataView = New DataView(ds.Tables("Fornitori"), "", "CustSupp", DataViewRowState.CurrentRows)
                        'per le condizioni di pagamento 
                        Dim cmd As SqlCommand = New SqlCommand("SELECT Payment, ACGCode FROM MA_PaymentTerms", Connection)
                        adpFor.SelectCommand = cmd
                        Dim dtCP As DataTable = New DataTable("CondPag")
                        adpFor.Fill(dtCP)
                        Dim dvCP As DataView = New DataView(dtCP, "", "ACGCode", DataViewRowState.CurrentRows)
                        'per le contropartite 
                        cmd = New SqlCommand("Select Account, ACGCode FROM MA_ChartOfAccounts", Connection)
                        adpFor.SelectCommand = cmd
                        Dim dtCntrp As DataTable = New DataTable("Contropartita")
                        adpFor.Fill(dtCntrp)
                        Dim dvCntrp As DataView = New DataView(dtCntrp, "", "ACGCode", DataViewRowState.CurrentRows)

                        Dim stopwatch1 As New System.Diagnostics.Stopwatch
                        stopwatch1.Start()
                        ' Ciclo le righe del file XLS
                        'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                        Dim irxls As Integer = 0
                        Dim i As Byte = 0
                        If bConIntestazione Then i = 1

                        Dim drCF As DataRow
                        Dim drCFOpt As DataRow

                        'popolo un Datatable con la tabella di transcodifica
                        'Dim dtCondPag As DataTable = dts.Tables("transcode")
                        'creo la dataview associata per le ricerche
                        'Dim dvCondPag As DataView = New DataView(dts.Tables("transcode"), "", "A", DataViewRowState.CurrentRows)
                        For irxls = i To drXLS.Count - 1
                            'Devo controllare che il cliente non esista già
                            If dvFornitori.Find(drXLS(irxls).Item("D").ToString) = -1 Then

                                'Inserisco nuovo cliente
                                drCF = dtCF.NewRow
                                drCFOpt = dtCFOpt.NewRow

                                With drXLS(irxls) ' accorcio per comodità di scrittura
                                    Debug.Print("Codice " & .Item("D").ToString & " : " & .Item("E").ToString)

                                    drCF("CustSupp") = .Item("D").ToString
                                    Dim sRagSoc As String = .Item("E").ToString
                                    sRagSoc = If(String.IsNullOrEmpty(.Item("F").ToString), sRagSoc, sRagSoc & vbCrLf & .Item("F").ToString)
                                    drCF("CompanyName") = sRagSoc
                                    drCF("Address") = .Item("H").ToString
                                    drCF("City") = .Item("I").ToString
                                    drCF("County") = .Item("J").ToString
                                    drCF("ZIPCode") = .Item("K").ToString
                                    drCF("Telephone1") = .Item("L").ToString
                                    ' drCF ( "Telephone2")= .Item("M").toString
                                    drCF("FiscalCode") = .Item("O").ToString
                                    drCF("TaxIdNumber") = .Item("P").ToString
                                    drCF("Currency") = If(.Item("Q").ToString = "EURO", "EUR", .Item("Q").ToString)
                                    If Not String.IsNullOrWhiteSpace(.Item("S").ToString) Then
                                        Dim iCP As Integer = dvCP.Find(.Item("W").ToString)
                                        If iCP <> -1 Then
                                            drCF("Payment") = dvCP.Item(iCP).Item("Payment").ToString
                                        Else
                                            drCF("Payment") = .Item("S").ToString
                                        End If
                                    End If
                                    Dim sbanca As String = .Item("R").ToString & "-" & .Item("S").ToString
                                    drCF("CustSuppBank") = If(sbanca = "-", "", sbanca)
                                    'A volte il c/c sono tutti zeri
                                    If Not String.IsNullOrWhiteSpace(.Item("AD").ToString) Then
                                        Dim cc As Double
                                        Double.TryParse(.Item("AD").ToString, cc)
                                        If cc > 0 Then drCF("CA") = .Item("AD").ToString
                                    End If
                                    drCF("Account") = TrovaContropartita(.Item("Z").ToString & "01", dvCntrp)
                                    drCF("LinkedCustSupp") = .Item("AA").ToString
                                    'AddF(Of String)(cmd, sInsert, "Dove?", .Item("AC").ToString) 'FOPAR (Fornitore contrassegnato)
                                    'se non e' escluso = Inntax =si
                                    drCF("InTaxLists") = If((String.IsNullOrEmpty(.Item("AE").ToString) OrElse .Item("AE").ToString = "N"), "1", "0")
                                    'se F allora persona fisica  
                                    drCF("NaturalPerson") = If(.Item("AM").ToString = "G", "0", "1")
                                    drCF("Fax") = Left(.Item("AP").ToString, 15)
                                    drCF("email") = Left(.Item("AQ").ToString, 128)
                                    'drCF("CostCenter") = .Item("AT").ToString ' Filiale / Ara di Vendita
                                    'Checkare data
                                    'If .Item("").ToString <> "0" Then drCF("InsertionDate") = MagoFormatta(.Item("CG").ToString, GetType(DateTime)).DataTempo
                                    'Altri dati obbligatori
                                    drCF("CustSuppType") = CustSuppType.Fornitore
                                    drCF("ISOCountryCode") = "IT"
                                    drCF("Presentation") = 1376260
                                    drCF("InvoiceAccTpl") = "FR"
                                    drCF("CreditNoteAccTpl") = "NR"
                                    drCF("MailSendingType") = 12451840 'Tipo invio mail ( A: 12451841, non inviare: 12451840)
                                    drCF("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                    drCF("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                    ''''''''''''''''''''''
                                    'Fattura Elettronica
                                    ''''''''''''''''''''''
                                    'drCF("ElectronicInvoicing") = "1"
                                    'drCF("IPACode") = "0000000"
                                    'drCF("SendByCertifiedEmail") = "1"
                                    'drCF("EICertifiedEMail") = ""

                                    ''''''''''''''''''''''''''''
                                    'MA_CustSuppCustomerOptions'
                                    ''''''''''''''''''''''''''''
                                    drCFOpt("Supplier") = .Item("D").ToString
                                    drCFOpt("CustSuppType") = CustSuppType.Fornitore
                                    drCFOpt("Area") = .Item("AT").ToString ' Filiale / Ara di Vendita
                                    drCFOpt("Category") = .Item("X").ToString 'CATEG
                                    drCFOpt("SupplierClassification") = .Item("AC").ToString 'FOPAR
                                    drCFOpt("BlockPayments") = If((String.IsNullOrEmpty(.Item("AB").ToString) OrElse .Item("AB").ToString = "N"), "0", "1")
                                    drCFOpt("ServicesOffset") = TrovaContropartita(.Item("AS").ToString, dvCntrp)
                                    drCFOpt("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                    drCFOpt("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                    'controllare
                                    'drCFOpt ("ExemptFromTax")= .Item("V").ToString ' In Esenzione
                                    'drCFOpt ("UseReqForPymt")= "1"

                                End With
                                dtCF.Rows.Add(drCF)
                                dtCFOpt.Rows.Add(drCFOpt)
                                FLogin.prgCopy.PerformStep()
                                FLogin.prgCopy.Update()
                                Application.DoEvents()

                            Else
                                bDuplicate = True
                                'Esco dal ciclo ( magari devo correggere le descrizioni ma per ora esco)
                                'MessageBox.Show("Fornitore già presente:" & drXLS(irxls).Item("D").ToString & " " & drXLS(irxls).Item("E").ToString)
                                result.AppendLine("Fornitore già presente:" & drXLS(irxls).Item("D").ToString & " " & drXLS(irxls).Item("E").ToString)
                                Continue For
                            End If
                        Next
                        Debug.Print(result.ToString)
                        If bDuplicate Then MessageBox.Show(result.ToString)
                        My.Application.Log.WriteEntry(result.ToString)
                        Debug.Print("Elaborazione Fornitori: " & dtCF.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                        EditTestoBarra("Salvataggio testate")
                        Using bulkTrans = Connection.BeginTransaction
                            okBulk = ScriviBulk("MA_CustSupp", dtCF, bulkTrans)
                            EditTestoBarra("Salvataggio options")
                            okBulk = ScriviBulk("MA_CustSuppSupplierOptions", dtCFOpt, bulkTrans)
                            bulkTrans.Commit()
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                MessageBox.Show(ex.Message)
            End Try
            Debug.Print("Creazione Fornitori" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okbulk
    End Function
    Public Function FornitoriPFXLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Fornitori Persone Fisiche- MA_CustSupp
        'effettua sempre insert ( POSSIBILE SCONTRO DI CHIAVI)
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bDuplicate As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Creo Fornitori - Persone fisiche")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables("ANFF200F")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Fornitori Persone Fisiche")
                Using dtCF As DataTable = CaricaSchema("MA_CustSuppNaturalPerson")
                    EditTestoBarra("Scrittura Anagrafica")
                    'popolo un Datatable con i soli codici
                    Dim adpFornitori As SqlDataAdapter
                    Dim ds As DataSet = New DataSet
                    adpFornitori = New SqlDataAdapter("SELECT CustSupp, NaturalPerson FROM MA_CustSupp WHERE CustSuppType=" & CustSuppType.Fornitore, Connection)
                    adpFornitori.Fill(ds, "Fornitori")
                    'creo la dataview associata per le ricerche
                    Dim dvFornitore As DataView = New DataView(ds.Tables("Fornitori"), "", "CustSupp", DataViewRowState.CurrentRows)

                    Dim stopwatch1 As New System.Diagnostics.Stopwatch
                    stopwatch1.Start()
                    ' Ciclo le righe del file XLS
                    'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                    Dim irxls As Integer = 0
                    Dim i As Byte = 0
                    If bConIntestazione Then i = 1
                    Dim drCF As DataRow

                    For irxls = i To drXLS.Count - 1
                        'Devo controllare che il codice esista già altrimenti lo segnalo
                        If dvFornitore.Find(drXLS(irxls).Item("D").ToString) = -1 Then
                            bDuplicate = True
                            result.AppendLine("Fornitore PF - NON presente: " & drXLS(irxls).Item("D").ToString & " " & drXLS(irxls).Item("E").ToString)
                        End If
                        'Inserisco nuovo fornitore
                        drCF = dtCF.NewRow
                        With drXLS(irxls) ' accorcio per comodità di scrittura
                            Debug.Print("Codice " & .Item("D").ToString & " : " & .Item("E").ToString)
                            drCF("CustSuppType") = CustSuppType.Fornitore
                            drCF("CustSupp") = .Item("D").ToString
                            drCF("Name") = .Item("F").ToString
                            drCF("LastName") = .Item("E").ToString
                            If .Item("L").ToString <> "0" Then
                                drCF("DateOfBirth") = MagoFormatta(.Item("L").ToString, GetType(DateTime)).DataTempo
                            End If
                            drCF("Gender") = If(String.IsNullOrEmpty(.Item("M").ToString), 2097152, 2097153)
                            drCF("CityOfBirth") = .Item("N").ToString
                            drCF("CountyOfBirth") = .Item("O").ToString
                            'drCF("Professional") = IF(.Item("R").ToString = "EURO", "EUR", .Item("R").ToString)
                            'drCF("FeeTpl") = .Item("S").ToString
                            'drCF("INPSAccount") = .Item("AC").ToString
                            'drCF("Form770Letter") = .Item("AD").ToString
                            drCF("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                            drCF("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                        End With
                        dtCF.Rows.Add(drCF)
                        FLogin.prgCopy.PerformStep()
                        FLogin.prgCopy.Update()
                        Application.DoEvents()
                    Next
                    Debug.Print(result.ToString)
                    If bDuplicate Then MessageBox.Show(result.ToString)
                    My.Application.Log.WriteEntry(result.ToString)
                    Debug.Print("Elaborazione Fornitori Persone Fisiche: " & dtCF.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                    EditTestoBarra("Salvataggio ")
                    Using bulkTrans = Connection.BeginTransaction
                        okBulk = ScriviBulk("MA_CustSuppNaturalPerson", dtCF, bulkTrans)
                        bulkTrans.Commit()
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Debug.Print("Creazione Fornitori Persone Fisiche" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okBulk
    End Function
    Public Function UpdCondPagXLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Condizioni di pagamento - MA_PaymentTerms
        'effettua solo UPDATE
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bAssente As Boolean

        stopwatch.Start()
        EditTestoBarra("Aggiornamento condizioni di pagamento")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables(0) 'dts.Tables("CPAG_ALL1")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: condizioni di pagamento")
                Using dtCondPag As DataTable = CaricaSchema("MA_PaymentTerms")
                    EditTestoBarra("Aggiornamento condizioni di pagamento")
                    'popolo un Datatable con i soli codici
                    Dim adpCondPag As SqlDataAdapter
                    Dim ds As DataSet = New DataSet
                    adpCondPag = New SqlDataAdapter("SELECT Payment, ACGCode, TBModifiedID FROM MA_PaymentTerms", Connection)
                    adpCondPag.Fill(ds, "CondPag")
                    Dim cbMar = New SqlCommandBuilder(adpCondPag)
                    'adpCondPag.InsertCommand = cbMar.GetInsertCommand(True)
                    adpCondPag.UpdateCommand = cbMar.GetUpdateCommand(True)
                    'creo la dataview associata per le ricerche
                    Dim dvCondPag As DataView = New DataView(ds.Tables("CondPag"), "", "Payment", DataViewRowState.CurrentRows)
                    'dvCondPag.AllowEdit = True

                    Dim stopwatch1 As New System.Diagnostics.Stopwatch
                    stopwatch1.Start()
                    ' Ciclo le righe del file XLS
                    'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                    Dim irxls As Integer = 0
                    Dim i As Byte = 0
                    If bConIntestazione Then i = 1

                    For irxls = i To drXLS.Count - 1
                        'Devo controllare che il codice esista già altrimenti lo segnalo
                        Dim ir As Integer = dvCondPag.Find(drXLS(irxls).Item("B").ToString)
                        If ir = -1 Then
                            bAssente = True
                            result.AppendLine("Condizione di pagamento senza corrispondenza ACG: " & drXLS(irxls).Item("B").ToString)
                        Else
                            'Edito la condizione di pagamento
                            dvCondPag(ir).BeginEdit()
                            dvCondPag(ir)("ACGCode") = drXLS(irxls)("A").ToString
                            'dvCondPag(ir)("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                            dvCondPag(ir)("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                            dvCondPag(ir).EndEdit()
                        End If
                        FLogin.prgCopy.PerformStep()
                        FLogin.prgCopy.Update()
                        Application.DoEvents()
                    Next
                    Debug.Print(result.ToString)
                    If bAssente Then MessageBox.Show(result.ToString)
                    My.Application.Log.WriteEntry(result.ToString)
                    Debug.Print("Elaborazione condizioni di pagamento: " & dtCondPag.Rows.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                    EditTestoBarra("Salvataggio ")
                    adpCondPag.Update(ds, "CondPag")
                    'dtCondPag.AcceptChanges()
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Debug.Print("Aggiornamento condizioni di pagamento" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return True
    End Function
    Public Function UpdPdCXLS(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Piano dei Conti - MA_PaymentTerms
        'effettua solo UPDATE
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bExist As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Aggiornamento piano dei conti")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables(0) 'dts.Tables("ACGPC12")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Piano dei conti")
                Using dtPdc As DataTable = CaricaSchema("MA_ChartOfAccounts")
                    EditTestoBarra("Aggiornamento Piano dei Conti")
                    'popolo un Datatable con i soli codici
                    Dim aspPdc As SqlDataAdapter
                    Dim ds As DataSet = New DataSet
                    aspPdc = New SqlDataAdapter("SELECT Account, ACGCode, TBModifiedID FROM MA_ChartOfAccounts", Connection)
                    aspPdc.Fill(ds, "Pdc")
                    Dim cbMar = New SqlCommandBuilder(aspPdc)
                    'adpCondPag.InsertCommand = cbMar.GetInsertCommand(True)
                    aspPdc.UpdateCommand = cbMar.GetUpdateCommand(True)
                    'creo la dataview associata per le ricerche su Tabella mago
                    Dim dvPdc As DataView = New DataView(ds.Tables("Pdc"), "", "Account", DataViewRowState.CurrentRows)
                    'creo la dataview associata per le ricerche su xls ( non posso avere doppi)
                    Dim dvPdcXls As DataView = New DataView(dtPdc, "", "Account", DataViewRowState.CurrentRows)

                    Dim stopwatch1 As New System.Diagnostics.Stopwatch
                    stopwatch1.Start()
                    ' Ciclo le righe del file XLS
                    'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                    Dim irxls As Integer = 0
                    Dim i As Byte = 0
                    If bConIntestazione Then i = 1
                    Dim drPdc As DataRow

                    For irxls = i To drXLS.Count - 1
                        If String.IsNullOrWhiteSpace(drXLS(irxls).Item("B").ToString) Then Continue For
                        'Devo controllare che il codice esista già altrimenti lo inserisco
                        Dim ir As Integer = dvPdc.Find(drXLS(irxls).Item("B").ToString)
                        Dim ir2 As Integer = dvPdcXls.Find(drXLS(irxls).Item("B").ToString)

                        If (ir <> -1 OrElse ir2 <> -1) Then
                            bExist = True
                            result.AppendLine("Piano dei Conti presenti piu' volte: " & drXLS(irxls).Item("B").ToString)
                        Else
                            'Inserisco pdc
                            drPdc = dtPdc.NewRow
                            With drXLS(irxls) ' accorcio per comodità di scrittura
                                Debug.Print("Codice " & .Item("B").ToString & " : " & .Item("E").ToString)
                                drPdc("Account") = .Item("B").ToString
                                drPdc("Description") = Left(.Item("C").ToString, 64)

                                drPdc("ACGCode") = .Item("A").ToString
                                drPdc("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                drPdc("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                drPdc("PostableInJE") = "1"
                                drPdc("PostableInCostAcc") = "0"
                                drPdc("Ledger") = Left(.Item("B").ToString, 1)
                                drPdc("CashFlowType") = 8781824


                            End With
                            dtPdc.Rows.Add(drPdc)
                        End If
                        FLogin.prgCopy.PerformStep()
                        FLogin.prgCopy.Update()
                        Application.DoEvents()
                    Next
                    Debug.Print(result.ToString)
                    If bExist Then MessageBox.Show(result.ToString)
                    My.Application.Log.WriteEntry(result.ToString)
                    EditTestoBarra("Salvataggio ")
                    Using bulkTrans = Connection.BeginTransaction
                        okBulk = ScriviBulk("MA_ChartOfAccounts", dtPdc, bulkTrans)
                        bulkTrans.Commit()
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Debug.Print("Aggiornamento Piano dei Conti" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okbulk
    End Function
    Public Function UpdClientiFE(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'MA_CustSupp - Dati fatturazion elettronica
        'effettua solo UPDATE
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim result As StringBuilder = New StringBuilder()
        Dim bAssente As Boolean
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Aggiornamento dati fattura Elettronica")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables(0) 'dts.Tables("FTEU400F")
        Dim drXLS As DataRow() = dtXLS.Select("", "F")
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                EditTestoBarra("Aggiornamento Clienti")
                'popolo un Datatable con i soli codici
                Using adpCli As SqlDataAdapter = New SqlDataAdapter("SELECT CustSupp ,CustSuppType, CompanyName, Address, City, County , ZIPCode, ElectronicInvoicing, IPACode, AdministrationReference, SendByCertifiedEmail, EICertifiedEMail, TBModifiedID FROM MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente, Connection)
                    Dim ds As DataSet = New DataSet
                    adpCli.Fill(ds, "MA_CustSupp")
                    Dim cbMar = New SqlCommandBuilder(adpCli)
                    adpCli.UpdateCommand = cbMar.GetUpdateCommand(True)
                    'creo la dataview associata per le ricerche
                    Dim dvCli As DataView = New DataView(ds.Tables("MA_CustSupp"), "", "CustSupp", DataViewRowState.CurrentRows)
                    'per gli Altri Dati 
                    Using adpOpt As SqlDataAdapter = New SqlDataAdapter("SELECT Customer, CustSuppType, SuspendedTax, PublicAuthority, PASplitPayment FROM MA_CustSuppCustomerOptions WHERE CustSuppType=" & CustSuppType.Cliente, Connection)
                        adpOpt.Fill(ds, "MA_CustSuppCustomerOptions")
                        'Rigenero script di aggiornamento tabella per gli Altri dati
                        cbMar = New SqlCommandBuilder(adpOpt)
                        adpOpt.UpdateCommand = cbMar.GetUpdateCommand(True)
                        Dim dvOpt As DataView = New DataView(ds.Tables("MA_CustSuppCustomerOptions"), "", "Customer", DataViewRowState.CurrentRows)
                        ' Carico tabelle per sedi Clienti
                        Using dtCustSede As DataTable = CaricaSchema("MA_CustSuppBranches")
                            Dim stopwatch1 As New System.Diagnostics.Stopwatch
                            stopwatch1.Start()
                            ' Ciclo le righe del file XLS
                            'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                            Dim irxls As Integer = 0
                            Dim i As Byte = 0
                            If bConIntestazione Then i = 1

                            Dim bDoppione As Byte
                            Dim iSede As Integer

                            For irxls = i To drXLS.Count - 1
                                'Devo controllare che il codice esista già altrimenti lo segnalo
                                Dim ir As Integer = dvCli.Find(drXLS(irxls).Item("F").ToString)
                                If ir = -1 Then
                                    bAssente = True
                                    result.AppendLine("DATI FATT. ELE. Codice cliente assente: " & drXLS(irxls).Item("F").ToString)
                                Else
                                    'Edito l'anagrafica
                                    dvCli(ir).BeginEdit()
                                    'dvCli(ir)("ACGCode") = drXLS(irxls)("A").ToString
                                    dvCli(ir)("ElectronicInvoicing") = "1"
                                    Dim isPA As Boolean = If(Len(drXLS(irxls)("G").ToString) = 6, True, False)
                                    If isPA Then
                                        Dim idOpt As Integer = dvOpt.Find(drXLS(irxls).Item("F").ToString)
                                        dvOpt(idOpt).BeginEdit()
                                        dvOpt(idOpt).Item("PublicAuthority") = "1"
                                        dvOpt(idOpt).Item("PASplitPayment") = "1"  'lo faccio in fase di primo import con controllo CondPag, magari andrebbe fatto anche qui'
                                        'dvOpt(idOpt).Item("SuspendedTax") = "1" ' No per le PA
                                        dvOpt(idOpt).EndEdit()
                                    End If
                                    dvCli(ir)("IPACode") = drXLS(irxls)("G").ToString
                                    dvCli(ir)("AdministrationReference") = drXLS(irxls)("H").ToString
                                    'Dim sPec As String = drXLS(irxls)("AJ").ToString
                                    Dim sPec As String() = Split(drXLS(irxls)("AJ").ToString, ";")
                                    If Len(sPec(0)) > 64 Then result.AppendLine("PEC troppo lunga su Cliente: " & drXLS(irxls).Item("F").ToString & "!")
                                    dvCli(ir)("EICertifiedEMail") = sPec(0).ToLower
                                    dvCli(ir)("SendByCertifiedEmail") = If(dvCli(ir)("IPACode") = "0000000" AndAlso Not String.IsNullOrWhiteSpace(dvCli(ir)("EICertifiedEMail")), "1", "0")
                                    'dvCli(ir)("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                    dvCli(ir)("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                    dvCli(ir).EndEdit()
                                    'Controllo se devo creare sede
                                    bDoppione = drXLS(irxls).Item("AN")
                                    If bDoppione > 1 Then
                                        Dim drCustSede = dtCustSede.NewRow
                                        iSede += 1
                                        drCustSede("Branch") = iSede.ToString("0000")
                                        drCustSede("CustSupp") = drXLS(irxls).Item("F").ToString
                                        drCustSede("CustSuppType") = CustSuppType.Cliente
                                        drCustSede("CompanyName") = dvCli(ir)("CompanyName")
                                        drCustSede("Address") = If(String.IsNullOrWhiteSpace(drXLS(irxls).Item("U").ToString), dvCli(ir)("Address"), drXLS(irxls).Item("U").ToString)
                                        drCustSede("City") = If(String.IsNullOrWhiteSpace(drXLS(irxls).Item("V").ToString), dvCli(ir)("City"), drXLS(irxls).Item("V").ToString)
                                        drCustSede("County") = If(String.IsNullOrWhiteSpace(drXLS(irxls).Item("X").ToString), dvCli(ir)("County"), drXLS(irxls).Item("X").ToString) ' provincia
                                        drCustSede("ZIPCode") = If(String.IsNullOrWhiteSpace(drXLS(irxls).Item("Y").ToString), dvCli(ir)("ZIPCode"), drXLS(irxls).Item("Y").ToString)
                                        Dim sEmail As String = drXLS(irxls).Item("T").ToString
                                        If Len(sEmail) > 128 Then result.AppendLine("Email troppo lunga su Cliente: " & drXLS(irxls).Item("F").ToString)
                                        drCustSede("EMail") = Left(sEmail, 128).ToLower
                                        'drCustSede("ContactPerson") = drXLS(irxls).Item("C").ToString
                                        drCustSede("ISOCountryCode") = "IT"
                                        drCustSede("MailSendingType") = 12451840 'Tipo invio mail ( A: 12451841, non inviare: 12451840)
                                        drCustSede("AdministrationReference") = drXLS(irxls).Item("H").ToString
                                        drCustSede("IPACode") = drXLS(irxls).Item("G").ToString
                                        drCustSede("Notes") = drXLS(irxls).Item("S").ToString

                                        drCustSede("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                        drCustSede("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                        dtCustSede.Rows.Add(drCustSede)
                                    Else
                                        iSede = 0
                                    End If
                                End If
                                FLogin.prgCopy.PerformStep()
                                FLogin.prgCopy.Update()
                                Application.DoEvents()
                            Next
                            Debug.Print(result.ToString)
                            If bAssente Then MessageBox.Show(result.ToString)
                            My.Application.Log.WriteEntry(result.ToString)
                            Debug.Print("Elaborazione Clienti fatt. elettroniche: " & drXLS.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                            EditTestoBarra("Salvataggio ")
                            adpCli.Update(ds, "MA_CustSupp")
                            adpOpt.Update(ds, "MA_CustSuppCustomerOptions")
                            'Scrivo le altre sedi
                            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                'cmd.Transaction = Trans
                                cmdqry.ExecuteNonQuery()
                                Using bulkTrans = Connection.BeginTransaction
                                    EditTestoBarra("Salvataggio: Sedi")
                                    okBulk = ScriviBulk("MA_CustSuppBranches", dtCustSede, bulkTrans)
                                    bulkTrans.Commit()
                                End Using
                                cmdqry.CommandText = "DBCC TRACEOFF(610)"
                                cmdqry.ExecuteNonQuery()
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Debug.Print("Aggiornamento Clienti" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okbulk
    End Function
    Public Function InsUpdBancheCli(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = True) As Boolean
        'Banche Clienti INSERT-UPDATE
        'MA_Banks
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim aBanca As String()
        Dim okBulk As Boolean

        stopwatch.Start()
        EditTestoBarra("Aggiornamento banche Cliente")
        FLogin.prgCopy.Value = 1

        'Assegno un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables(0) 'dts.Tables("ANAB201L")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Count > 0 Then
            FLogin.prgCopy.Maximum = drXLS.Count
            FLogin.prgCopy.Step = 1
            Try
                EditTestoBarra("Aggiornamento Banche")
                'popolo un Datatable con i soli codici
                Using adpBanche As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM MA_Banks WHERE IsACompanyBank=0", Connection)
                    Dim ds As DataSet = New DataSet
                    adpBanche.Fill(ds, "MA_Banks")
                    Dim cbMar = New SqlCommandBuilder(adpBanche)
                    adpBanche.UpdateCommand = cbMar.GetUpdateCommand(True)
                    'creo la dataview associata per le ricerche
                    Dim dvbanche As DataView = New DataView(ds.Tables("MA_Banks"), "", "ABI,CAB", DataViewRowState.CurrentRows)
                    ' Carico tabelle per INSERT
                    Using dtBanche As DataTable = CaricaSchema("MA_Banks")
                        Dim stopwatch1 As New System.Diagnostics.Stopwatch
                        stopwatch1.Start()
                        ' Ciclo le righe del file XLS
                        'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                        Dim irxls As Integer = 0
                        Dim i As Byte = 0
                        If bConIntestazione Then i = 1

                        For irxls = i To drXLS.Count - 1
                            With drXLS(irxls)
                                'Devo controllare che la banca esista già altrimenti la inserisco
                                Erase aBanca
                                ReDim aBanca(1)
                                aBanca(0) = .Item("D").ToString ' ABI
                                aBanca(1) = .Item("E").ToString ' CAB
                                Dim ib As Integer = dvbanche.Find(aBanca)
                                If ib = -1 Then
                                    'Assente
                                    Dim drBanche = dtBanche.NewRow
                                    drBanche("ABI") = .Item("D").ToString
                                    drBanche("CAB") = .Item("E").ToString
                                    drBanche("Bank") = .Item("D").ToString & "-" & .Item("E").ToString
                                    drBanche("Description") = .Item("F").ToString
                                    drBanche("IsACompanyBank") = 0
                                    drBanche("Address") = .Item("H").ToString
                                    drBanche("City") = .Item("I").ToString
                                    drBanche("County") = .Item("J").ToString ' provincia
                                    drBanche("ZIPCode") = .Item("K").ToString
                                    drBanche("Notes") = .Item("G").ToString

                                    drBanche("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                    drBanche("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                    dtBanche.Rows.Add(drBanche)
                                Else
                                    'Edito l'anagrafica
                                    'dvbanche(ib).BeginEdit()
                                    'dvbanche(ib)("Description") = .Item("F").ToString
                                    'dvbanche(ib)("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                    'dvbanche(ib).EndEdit()
                                End If
                            End With
                            FLogin.prgCopy.PerformStep()
                            FLogin.prgCopy.Update()
                            Application.DoEvents()
                        Next
                        Debug.Print("Inserimento Banche Clienti: " & drXLS.Count.ToString & " in " & stopwatch1.Elapsed.ToString())
                        EditTestoBarra("Salvataggio ")
                        adpBanche.Update(ds, "MA_Banks")
                        'Scrivo le altre sedi
                        Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                            'cmd.Transaction = Trans
                            cmdqry.ExecuteNonQuery()
                            Using bulkTrans = Connection.BeginTransaction
                                EditTestoBarra("Salvataggio: banche")
                                okBulk = ScriviBulk("MA_Banks", dtBanche, bulkTrans)
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
            Debug.Print("Aggiornamento Banche" & " " & stopwatch.Elapsed.ToString)
        End If
        stopwatch.Stop()
        Return okBulk
    End Function

End Module
