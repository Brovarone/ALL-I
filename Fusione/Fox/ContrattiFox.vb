Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Reflection.MethodBase
Imports System.Runtime.CompilerServices
Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
Imports ALLSystemTools.SqlTools


Module ContrattiFox
    'Gestisce l'import dei contratti da FoxPro a Mago
    Private ds As DataSet
    Dim dtContratti As DataTable
    Dim dtRaggTeste As DataTable
    Dim dtRaggDett As DataTable
    Dim dtTabelle As DataTable
    Dim dvTabelle As DataView
    Dim dtPagamentiFox As DataTable
    Dim dvPagamentiFox As DataView
    Private OrdiniCntx As OrdiniContext
    ReadOnly sLoginId As String = My.Settings.mLOGINID
    Private charSpeciali As New List(Of Carattere_Speciale)

    'Collection Globali per aggiornamento unico
    'Creo le entities che usero' poi con BulkInsert
    Private efMaSaleOrd As New List(Of MaSaleOrd)
    'Private efMaSaleOrdDetails As New List(Of MaSaleOrdDetails)
    Private efMaSaleOrdSummary As New List(Of MaSaleOrdSummary)
    Private efMaSaleOrdShipping As New List(Of MaSaleOrdShipping)
    Private efMaSaleOrdNotes As New List(Of MaSaleOrdNotes)
    Private efAllordCliAcc As New List(Of AllordCliAcc)
    Private efAllordCliContratto As New List(Of AllordCliContratto)
    Private efAllordCliDescrizioni As New List(Of AllordCliDescrizioni)
    Private efAllordCliTipologiaServizi As New List(Of AllordCliTipologiaServizi)
    Private efAllordPadre As New List(Of AllordPadre)
    Private efAllordFiglio As New List(Of AllordFiglio)
    Private efMaCustSupp As New List(Of MaCustSupp)
    Private efMaCustSuppBranches As New List(Of MaCustSuppBranches)
    Private efMaCustSuppCustomerOptions As New List(Of MaCustSuppCustomerOptions)
    Private efMaCustSuppNaturalPerson As New List(Of MaCustSuppNaturalPerson)
    Private efMaDeclarationOfIntent As New List(Of MaDeclarationOfIntent)
    Private efMaSddmandate As New List(Of MaSddmandate)
    Private efMaIdnumbers As New List(Of MaIdnumbers)
    Private efMaNonFiscalNumbers As New List(Of MaNonFiscalNumbers)
    ''' <summary>
    ''' Importo ContrattiFox su Mago tramite LINQ e OrdiniCntx
    ''' </summary>
    ''' <returns></returns>
    Public Function ImportaContrattiFox(dsFox As List(Of DataSet)) As Boolean
        GeneraDataset(dsFox)
        GeneraRelazionieDatatable()
        ConnettiContesto()

        Dim sb As List(Of String) = CheckOrdini()
        'TODO temporaneamente la sospendo Checkordini
        'If sb.Count > 0 Then
        '    For i = 0 To sb.Count - 1
        '        FLogin.lstStatoConnessione.Items.Add(sb(i))
        '    Next
        '    FLogin.lstStatoConnessione.Items.Add("Imposibile continuare controllare errori precedenti")
        '    Return False
        'End If

        'TODO temporaneamente la sospendo ScriviClientiNuovi()

        'LeggiOrdiniEsistenti()

        ScriviOrdini()

        SalvaClienti()
        SalvaOrdini()
        Return True
    End Function

    ''' <summary>
    ''' Ritorna un Dataset con dei Datatable dei primi fogli excel caricati contenenti i dati da importare
    ''' </summary>
    ''' <param name="dsFox"></param>
    Private Sub GeneraDataset(dsFox As List(Of DataSet))
        ds = New DataSet
        EditTestoBarra("Genera dataset")
        FLogin.prgCopy.Value = 1
        FLogin.prgCopy.Maximum = dsFox.Count
        FLogin.prgCopy.Step = 1
        For Each d As DataSet In dsFox
            ds.Tables.Add(d.Tables(0).Copy)
            AvanzaBarra()
        Next
    End Sub
    ''' <summary>
    ''' Crea solo le relazioni 1-n
    ''' </summary>
    Private Sub GeneraRelazionieDatatable()
        EditTestoBarra("Genera relazioni")
        ds.Relations.Add("Ordini Clienti", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_ONTRORD").Columns("CLIENTE"))
        ds.Relations.Add("Ordini Clienti Gruppo Testa", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("CLIENTE"))
        ds.Relations.Add("Ordini Clienti Gruppo Dettaglio", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("CLIENTE"))
        ds.Relations.Add("Raggruppamento_Ordine", ds.Tables("_ONTRORD").Columns("CONTRATTO"), ds.Tables("_AGRFATD").Columns("CONTRATTO"))
        ds.Relations.Add("Ordini Raggruppati", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_AGRFATD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("RAGRFATT")})
        ds.Relations.Add("RID", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_RID").Columns("CLIENTE"))
        ds.Relations.Add("ESENTI", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_SENTIIV").Columns("CLIENTE"))
        'ds.Relations.Add("FattEle", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_LIFTELE").Columns("CLIENTE"), ds.Tables("_LIFTELE").Columns("RAGRFATT")})
        'ds.Relations.Add("Pagamenti", ds.Tables("_ONTRORD").Columns("CPAGAM"), ds.Tables("ACGTRPG").Columns("CPAGAM"))
        dtContratti = ds.Tables("_ONTRORD")
        dtRaggTeste = ds.Tables("_AGRFATT")
        dtRaggDett = ds.Tables("_AGRFATD")
        dtTabelle = ds.Tables("_EWTAB")
        dvTabelle = New DataView(dtTabelle)
        dtPagamentiFox = ds.Tables("ACGTRPG")
        dvPagamentiFox = New DataView(dtPagamentiFox)
    End Sub
    Private Sub ConnettiContesto()
        EditTestoBarra("Connessione al contesto")
        Dim cs As String = GetConnectionStringSPA(True)
        Dim dbcb As New DbContextOptionsBuilder(Of OrdiniContext)
        dbcb.UseSqlServer(cs)

        OrdiniCntx = New OrdiniContext(dbcb.Options)
        If OrdiniCntx.Database.CanConnect Then
            OrdiniCntx.Database.ExecuteSqlRaw("SET ARITHABORT ON")
        End If
    End Sub
    ''' <summary>
    ''' Aggiungo Clienti Nuovi ( MaCustSupp,Options, Branches,NatualPerson)
    ''' </summary>
    Private Sub ScriviClientiNuovi()
        Dim dtCli As DataTable = ds.Tables("_LIENORD")
        Dim dtCliEle As DataTable = ds.Tables("_LIFTELE")
        Dim dtCliRid As DataTable = ds.Tables("_RID")
        Dim dtCliEse As DataTable = ds.Tables("_SENTIIV")
        Dim dvCliEle = New DataView(dtCliEle)
        Dim dvCliRid = New DataView(dtCliRid)
        Dim dvCliEse = New DataView(dtCliEse)

        For Each r As DataRow In dtCli.Rows
            Dim codice As String = r.Item("ACGCOD").ToString
            Dim c = OrdiniCntx.MaCustSupp.Find(CustSuppType.Cliente, codice)
            'Dim w = OrdiniCntx.MaCustSupp.AsNoTracking.Where(Function(k) k.CustSuppType.Equals(CustSuppType.Cliente) And k.CustSupp.Equals(codice)).FirstOrDefault
            If c Is Nothing Then
                'todo: completare inserimento nuovo cliente da CLIENORD ( vedere su import fatture ftpa300
                Debug.Print("Nuovo Cliente:(" & codice & ") ")
                dvCliEle.RowFilter = $"ACGCOD = '{codice}'"
                dvCliRid.RowFilter = $"ACGCOD = '{codice}'"
                dvCliEse.RowFilter = $"ACGCOD = '{codice}'"
                'TrovaFiliale()

#Region "clienord da Fatture"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Creo nuovo cliente passando informazioni dalla fattura ed dal CLIENORD
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Debug.Print("Nuovo cliente: " & .Item("AA").ToString)
                'listOfNewClienti.Add(.Item("AA").ToString & ": " & .Item("AB").ToString)
                ''TAG l_NewCli.Add("N01", .Item("AA").ToString & ": " & .Item("AB").ToString, LogLevel.None, .Item("AA").ToString)
                'l_NewCli.Add("N01", .Item("AA").ToString & ": " & .Item("AB").ToString)
                'drCli = dtClientiNew.NewRow
                'drCliOpt = dtCliOptNew.NewRow
                'drCli("CustSupp") = .Item("AA").ToString
                'drCli("CustSuppType") = CustSuppType.Cliente
                'Dim sRagSoc As String = dvClienOrd(iClienOrdFound).Item("F").ToString
                'If dvClienOrd(iClienOrdFound).Item("E").ToString = "1" Then sRagSoc = If(String.IsNullOrEmpty(dvClienOrd(iClienOrdFound).Item("G").ToString), sRagSoc, sRagSoc & Environment.NewLine & dvClienOrd(iClienOrdFound).Item("G").ToString)
                'drCli("CompanyName") = sRagSoc '("AB" della fattura)
                'drCli("Address") = dvClienOrd(iClienOrdFound).Item("I").ToString '("AC" della fattura)
                'drCli("City") = dvClienOrd(iClienOrdFound).Item("J").ToString '("AE" della fattura)
                'drCli("County") = dvClienOrd(iClienOrdFound).Item("K").ToString '("AF" della fattura)
                'drCli("Region") = Get_Regione(dvClienOrd(iClienOrdFound).Item("K").ToString)
                'Dim iCAP As Integer
                'If Integer.TryParse(dvClienOrd(iClienOrdFound).Item("L").ToString, iCAP) Then
                '    drCli("ZIPCode") = iCAP.ToString("00000") '("AE" della fattura)
                'End If
                'drCli("Telephone1") = dvClienOrd(iClienOrdFound).Item("S").ToString
                'drCli("Fax") = dvClienOrd(iClienOrdFound).Item("T").ToString
                'drCli("ISOCountryCode") = Left(dvClienOrd(iClienOrdFound).Item("M").ToString, 2).ToUpper
                'drCli("CustSuppKind") = TrovaNaturaCliFor(drCli("ISOCountryCode").ToString, dvISO, "Cliente: " & .Item("AA").ToString & " Doc. nr: " & .Item("O").ToString & Environment.NewLine, errori)
                'drCli("FiscalCode") = dvClienOrd(iClienOrdFound).Item("O").ToString '("AI" della fattura)
                'drCli("TaxIdNumber") = dvClienOrd(iClienOrdFound).Item("N").ToString '("AJ" della fattura)
                'drCli("Currency") = If(.Item("R").ToString = "EUR", "EUR", .Item("O").ToString)
                'drCli("NaturalPerson") = If(dvClienOrd(iClienOrdFound).Item("E").ToString = "1", "0", "1")
                'If drCli("NaturalPerson") = "1" Then
                '    Dim cognomeNome As String() = Split(dvClienOrd(iClienOrdFound).Item("G").ToString, "*")
                '    If UBound(cognomeNome) <> -1 Then
                '        Dim ok As Boolean = False
                '        If cognomeNome.Length = 2 Then
                '            ok = True
                '        ElseIf cognomeNome.Length > 2 Then
                '            'Cognomi composti controllare su Mago
                '            avvisi.AppendLine("ANC1: Controllare correttezza Nome e Cognome: Cliente " & .Item("AA").ToString & ": " & .Item("AB").ToString)
                '            ok = True
                '        Else
                '            'Assenza carattere split
                '            errori.AppendLine("ENC1: Impossibile determinare Nome e Cognome: Cliente " & .Item("AA").ToString & ": " & .Item("AB").ToString)
                '            ok = False
                '        End If
                '        If ok Then
                '            drCliNatPers = dtCliNatPersNew.NewRow
                '            drCliNatPers("CustSuppType") = CustSuppType.Cliente
                '            drCliNatPers("CustSupp") = .Item("AA").ToString
                '            drCliNatPers("Name") = cognomeNome(1)
                '            drCliNatPers("LastName") = cognomeNome(0)
                '            drCliNatPers("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                '            drCliNatPers("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                '            dtCliNatPersNew.Rows.Add(drCliNatPers)
                '        End If
                '    End If
                'End If
                ''Deprecata
                ''drCli("Account") = "1CLI" & Int16.Parse((TrovaFiliale(.Item("AA").ToString, False))).ToString("000")
                'drCli("Account") = "1CLI001"
                'drCli("Presentation") = 1376260
                'drCli("MailSendingType") = 12451840 'Tipo invio mail ( A: 12451841, non inviare: 12451840)
                '''''''''''''''''''''''
                ''Fattura Elettronica
                '''''''''''''''''''''''
                'drCli("ElectronicInvoicing") = "1"
                'Dim isPA As Boolean = .Item("Z").ToString.Length = 6
                'If isPA Then
                '    drCliOpt("PublicAuthority") = "1"
                '    drCliOpt("PASplitPayment") = "1"
                'End If
                'If IsDeprecated AndAlso dvClienOrd(iClienOrdFound).Item("P").ToString() = "A" Then 'CLPAR
                '    '05/10/2021 : era stata aggiunta il 14/07/2021, ma non era cosi' vero che la lettera fosse giusta
                '    'Il campo classe cliente =  A identifica una Pubblica Amministrazione
                '    drCliOpt("PublicAuthority") = "1"
                '    drCliOpt("PASplitPayment") = "1"
                'End If

                'drCli("IPACode") = If(.Item("Z").ToString = "0", "0000000", .Item("Z").ToString)
                'Dim sPec As String() = Split(.Item("HI").ToString, ";")
                'If Len(sPec(0)) > 64 Then
                '    errori.AppendLine("E06: PEC troppo lunga su Cliente: " & .Item("AA").ToString & " dato non salvato")
                '    l_Err.Add("E06", "PEC troppo lunga su Cliente: " & .Item("AA").ToString & " dato non salvato")
                'Else
                '    drCli("EICertifiedEMail") = sPec(0).ToLower
                'End If
                'drCli("SendByCertifiedEmail") = If(drCli("IPACode") = "0000000" AndAlso Not String.IsNullOrWhiteSpace(drCli("EICertifiedEMail")), "1", "0")
                'drCli("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                'drCli("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                ''Options
                'drCliOpt("Customer") = .Item("AA").ToString
                'drCliOpt("CustSuppType") = CustSuppType.Cliente
                'drCliOpt("Area") = TrovaFiliale(.Item("AA").ToString, True) ' Filiale / Ara di Vendita
                'drCliOpt("UseReqForPymt") = "1"
                'Dim cat As String = dvClienOrd(iClienOrdFound).Item("C").ToString
                'Select Case cat
                '    Case "O"
                '        cat = "OR"
                '    Case "S"
                '        cat = "SP"
                '    Case Else
                '        cat = "OR"
                'End Select
                'drCliOpt("Category") = cat ' "OR" 'CATEG
                'drCliOpt("CustomerClassification") = dvClienOrd(iClienOrdFound).Item("P").ToString 'CLPAR
                'drCliOpt("DebitStampCharges") = "1" ' Bolli SPMAF
                'drCliOpt("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                'drCliOpt("TBModifiedID") = My.Settings.mLOGINID 'ID utente

#End Region
#Region "Testa"
                Dim rCli As New MaCustSupp With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = codice,
                                    .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId
                                    }
                'Aggiungo la riga alla collection
                efMaCustSupp.Add(rCli)

#End Region
#Region "Options - Altri dati"
                Dim rCliOpt As New MaCustSuppCustomerOptions With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .Customer = codice,
                                    .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId
                                    }
                'Aggiungo la riga alla collection
                efMaCustSuppCustomerOptions.Add(rCliOpt)

#End Region
#Region "Sedi"
                Dim rCliBr As New MaCustSuppBranches With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = codice,
                                    .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId
                                    }
                'Aggiungo la riga alla collection
                efMaCustSuppBranches.Add(rCliBr)
#End Region
#Region "Natural Person"
                Dim rCliNatPer As New MaCustSuppNaturalPerson With {
                                 .CustSuppType = CustSuppType.Cliente,
                                 .CustSupp = codice,
                                 .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId
                                 }
                'Aggiungo la riga alla collection
                efMaCustSuppNaturalPerson.Add(rCliNatPer)
#End Region
#Region "Dichiarazioni di Intento"
                If dvCliEle.Count > 0 Then
                    If dvCliEle.Count = 1 Then
                        Dim rIntento As New MaDeclarationOfIntent With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = codice,
                                 .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId
                                    }
                        'Aggiungo la riga alla collection
                        efMaDeclarationOfIntent.Add(rIntento)
                    Else
                        Dim mb As New MessageBoxWithDetails("Cliente: " & codice & " con piu' dichiarazioni di intento", GetCurrentMethod.Name, "")
                        mb.ShowDialog()
                    End If
                End If
#End Region
#Region "Mandati"
                If dvCliRid.Count > 0 Then
                    If dvCliRid.Count = 1 Then
                        Dim rRid As New MaSddmandate With {
                                    .Customer = codice,
                                 .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId
                                    }
                        'Aggiungo la riga alla collection
                        efMaSddmandate.Add(rRid)
                    Else
                        Dim mb As New MessageBoxWithDetails("Cliente: " & codice & " con piu' mandati", GetCurrentMethod.Name, "")
                        mb.ShowDialog()
                    End If
                End If
#End Region
            End If
        Next
#Region "Dispose"
        dtCli.Dispose()
        dtCliEle.Dispose()
        dtCliRid.Dispose()
        dtCliEse.Dispose()
#End Region
        'Dim efCli = From c In OrdiniCntx.MaCustSupp _
        '            .Include(Function(o) o.MaCustSuppCustomerOptions) _
        '            .Include(Function(br) br.MaCustSuppBranches) _
        '            .Include(Function(np) np.MaCustSuppNaturalPerson) _
        '            .Include(Function(nt) nt.MaCustSuppNotes) _
        '            .ToList

    End Sub
    Private Sub LeggiOrdiniEsistenti()
        'era cosi' Dim q = (From o In OrdContext.MaSaleOrd _
        Dim q = (From o In OrdiniCntx.MaSaleOrd _
                           .Include(Function(r) r.MaSaleOrdDetails) _
                           .Include(Function(acc) acc.ALLOrdCliAcc) _
                           .Include(Function(des) des.ALLordCliDescrizioni) _
                           .Include(Function(con) con.ALLordCliContratto) _
                               .ThenInclude(Of MaItems)(Function(it) it.MaItems) _
                           .Include(Function(con) con.ALLordCliContratto) _
                               .ThenInclude(Of AlltipoRigaServizio)(Function(trs) trs.AlltipoRigaServizio) _
                           .Include(Function(con) con.ALLordCliContratto) _
                                .ThenInclude(Function(att) att.AllordCliAttivita) _
                                       .ThenInclude(Of Allattivita)(Function(at) at.Allattivita) _
                           .Include(Function(att) att.AllordCliAttivita) _
                               .ThenInclude(Of Allattivita)(Function(at) at.Allattivita)) ' _
        'q = q.Where(Function(i) i.MaSaleOrdDetails..)
        'AGGIUNGO  FILTRI
        'Vengono esclusi a priori gli ordini con data cessazione > di Data Competenza
        'Il filtro where che prende quelli senza data cessazione o con data successiva ( preimpostata da loro)
        ' q = q.Where(Function(facc) facc.ALLOrdCliAcc.DataCessazione = sDataNulla OrElse facc.ALLOrdCliAcc.DataCessazione.Value.Date >= dataFattA)
        '
        ' q = q.Where(Function(oDate) oDate.OrderDate.Value.Date >= fromOrdDate And oDate.OrderDate.Value.Date <= toOrdDate)
        'Sostituisco la logica di "uguale" aggiungendo un giorno, in questo modo prendo anche le cose create nello stesso giorno
        ' q = q.Where(Function(oDate) oDate.OrderDate <= toOrdDate)
        q.ToList

        Debug.Print("Ordini estratti: " & q.Count.ToString)
    End Sub
    Private Sub LeggiTesteOrdiniEsistenti()
        Dim q = From o In OrdiniCntx.MaSaleOrd.ToList
        Debug.Print("Teste Ordini estratti: " & q.Count.ToString)
    End Sub
    ''' <summary>
    ''' Esegue check sulla presenza dei dati di match nelle tabelle di mago
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckOrdini() As List(Of String)

        Dim avvisi As New List(Of String)
        Dim dvPdc As DataView = LINQResultToDataView(From o In OrdiniCntx.MaChartOfAccounts.ToList)
        EditTestoBarra("Check Ordini")
        FLogin.prgCopy.Value = 1
        FLogin.prgCopy.Maximum = dtContratti.Rows.Count
        FLogin.prgCopy.Step = 1

        For Each r As DataRow In dtContratti.Rows
            'Numeratore Ordini
            If OrdiniCntx.MaNonFiscalNumbers.FirstOrDefault(Function(k) k.CodeType = CodeType.OrdCli And k.BalanceYear = Year(r("DTPRODUZ"))) Is Nothing Then avvisi.Add("Contatore Ordini non trovato:" & r("DTPRODUZ").ToString)
            'Codice Iva
            If OrdiniCntx.MaTaxCodes.AsNoTracking.FirstOrDefault(Function(k) k.Acgcode.Equals(r("CIVA").ToString)) Is Nothing Then avvisi.Add("Valore assente su Mago - Iva:" & (r("CIVA")).ToString)
            'Pagamento
            ' If OrdiniCntx.MaPaymentTerms.AsNoTracking.FirstOrDefault(Function(k) k.Acgcode.Equals(r("CPAGAM").ToString)) Is Nothing Then avvisi.AppendLine("Valore assente su Mago - Pagamento:" & (r("CPAGAM")).ToString)
            'Contropartita
            Dim contropartitaFox As String = dvTabelle.CercaValoreSuTabelleFox("TS", r("TIPSERV").ToString)
            If String.IsNullOrEmpty(dvPdc.CercaContropartitaFox(contropartitaFox)) Then avvisi.Add("Valore assente su Mago - Contropartita(TIPSERV):" & r("TIPSERV").ToString)
            'AGENTE
            Dim produttore As String = dvTabelle.CercaValoreSuTabelleFox("PT", r("PRODUTTORE").ToString)
            If TrovaAgente(r("PRODUTTORE").ToString) = "XXX" Then avvisi.Add("Agente assente su Mago:" & r("PRODUTTORE").ToString)
            'Fattura elettronica


            If Len(r("DNOTE").ToString.Trim) > 251 Then avvisi.Add("DNOTE troppo lunga su contratto:" & (r("CONTRATTO")).ToString)
            'Rimpiazzo caratteri Speciali conosciuti e cerco per non gestiti
            'Elenco Caratteri speciali
            Dim s As String() = {"DNOTE", "DNOTE2", "DNOTE3", "DNOTE4", "DNOTE5", "DNOTE6", "DNOTE7", "DNOTE8", "DESCAN", "DFAT1", "DFAT2", "DFAT3", "DFAT4"}
            r = Cerca_Sostituisci_CaratteriSpeciali(r, s)
            AvanzaBarra()
        Next
        If charSpeciali.Count > 0 Then
            For Each c In charSpeciali.ToArray
                avvisi.Add(String.Concat("Carattere speciale: ", c.Carattere, " Ascii: ", c.Asc.ToString, " Nr: ", c.Occorrenze.ToString))
            Next
        End If
        Return avvisi
    End Function
    Private Sub ScriviOrdini()

#Region "Variabili"
        Dim errori As New StringBuilder()
        Dim avvisi As New StringBuilder()

        Dim defVendite = (From dv In OrdiniCntx.MaUserDefaultSales.ToList Select dv).FirstOrDefault
        Dim defOrdini = (From dv In OrdiniCntx.MaUserDefaultSaleOrders.ToList Select dv).FirstOrDefault
        ' Dim defContabili = (From dc In OrdiniCntx.MaAccountingDefaults.ToList Select dc).FirstOrDefault
        Dim defIva = (From dc In OrdiniCntx.MaTaxCodesDefaults.ToList Select dc).FirstOrDefault
        Dim sDefContropartita As String = defVendite.ServicesSalesAccount
        Dim sDefCodIva As String = defIva.TaxCode

        Dim dtFattEle As DataTable = ds.Tables("_LIFTELE")
        Dim dvFattEle As New DataView(dtFattEle)

#End Region
#Region "Inizializzazione"
        'Resetto alcune cose 
        'Dim iNewRowsCount As Integer = 0
        'Dim isNewRows As Boolean = False    ' Indica se ci sono righe contratto che vengono fatturate e quindi inserite nelle righe
        'Dim isUpdateRows As Boolean = False ' Indica se ci sono righe contratto che vengono aggiorate
        'Inizializzo alcuni valori
        'Dim curLastLine As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Line), 0)
        'Dim curLastPosition As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Position), 0)
        'Dim iNrRigheNota As Integer = 0
        'Dim iNrRigheAValore As Integer = 0
        efMaIdnumbers.Add(OrdiniCntx.MaIdnumbers.FirstOrDefault(Function(k) k.CodeType = IdType.OrdCli))
        Dim saleOrdId As Integer = efMaIdnumbers(0).LastId
        efMaNonFiscalNumbers = OrdiniCntx.MaNonFiscalNumbers.Where(Function(k) k.CodeType = CodeType.OrdCli).ToList

#End Region

        EditTestoBarra("Scrivi Ordini")
        FLogin.prgCopy.Value = 1
        FLogin.prgCopy.Maximum = dtContratti.Rows.Count
        FLogin.prgCopy.Step = 1
        For Each r As DataRow In dtContratti.Rows
            If FLogin.prgCopy.Value = 13 Then Exit For
            Dim contratto As String = r("CONTRATTO").ToString
            Dim clienteFox As String = r("CLIENTE").ToString
            'Cerco se esite:
            Dim o As MaSaleOrd = OrdiniCntx.MaSaleOrd.AsNoTracking.FirstOrDefault(Function(k) k.IdContractIntegra.Equals(contratto))

            If o Is Nothing Then
#Region "Controlli ed estrazioni"
                'todo: inserimento nuovo ORDINE
                'dvRaggDett.RowFilter = $"CONTRATTO = '{contratto}'"
                'Dim codiceRaggruppamento As String = dvRaggDett(0)("RAGRFATT")
                Dim codiceRaggruppamento As String = r.GetChildRows("Raggruppamento_Ordine").SingleOrDefault()("RAGRFATT").ToString
                'dvRaggTeste.RowFilter = $"RAGRFATT = '{codiceRaggruppamento}'"

                'Cerco riferimento coerente con (raggruppamento se esiste)
                dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                Dim drFattEle As DataRow = dtFattEle.NewRow
                If dvFattEle.Count = 1 Then
                    drFattEle = dvFattEle(0).Row
                Else
                    dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}'"
                    If dvFattEle.Count = 1 Then
                        drFattEle = dvFattEle(0).Row
                    Else
                        Dim mb As New MessageBoxWithDetails("Errore nel determinare la riga di Fatturazione Elettronica (CLIFTELE): " & contratto, GetCurrentMethod.Name)
                        mb.ShowDialog()
                    End If
                End If

                dvPagamentiFox.RowFilter = "CPAGAM = '" & r("CPAGAM").ToString & "' AND ( SPLITPAY IS NULL OR SPLITPAY = '' )"
                Dim condPagAcg = dvPagamentiFox(0)("ACGCOD").ToString
                Dim condPag As String = OrdiniCntx.MaPaymentTerms.AsNoTracking.FirstOrDefault(Function(k) k.Acgcode.Equals(condPagAcg)).Payment

                Dim vettore As String = If(codiceRaggruppamento.Equals(contratto), "", CInt(codiceRaggruppamento).ToString)
                Dim codIva As String = OrdiniCntx.MaTaxCodes.AsNoTracking.FirstOrDefault(Function(k) k.Acgcode.Equals(r("CIVA").ToString)).TaxCode

                Dim ordNo As String
                Dim curNfCounter = efMaNonFiscalNumbers.FirstOrDefault(Function(k) k.BalanceYear = Year(r("DTPRODUZ")))
                curNfCounter.LastDocNo += 1
                efMaNonFiscalNumbers.FirstOrDefault(Function(k) k.BalanceYear = Year(r("DTPRODUZ"))).LastDocNo = curNfCounter.LastDocNo
                ordNo = Right(Year(r("DTPRODUZ")), 2) & curNfCounter.Separators & CInt(curNfCounter.LastDocNo).ToString("00000")

                saleOrdId += 1
                efMaIdnumbers(0).LastId = saleOrdId

                Dim driv As String = String.Concat(r("DRIV1").ToString, r("DRIV2").ToString, r("DRIV3").ToString, r("DRIV4").ToString).Trim
                Dim agente As String = TrovaAgente(r("PRODUTTORE").ToString)

                'SEDE:
                'Devo cercare il campo Codice Sdi su _LIFTELE e Matcharlo con "Codice Sdi" Cliente e poi Sede
                'sdi e dati FE
                'su LIftele ci sono solo i dati accessori oltre al codice sdi se 00000 allora devo cercare la pec
                'se c'e' corrispondenza con rRAGRFATT uso quella altrimenti esiste un generico senza valore
#End Region
#Region "Testa"
                Dim rOrd As New MaSaleOrd With {
                     .Priority = 88,
                    .CustSuppType = CustSuppType.Cliente,
                    .InternalOrdNo = ordNo,
                    .ExternalOrdNo = "",
                    .OrderDate = Valid_Data(r("DTPRODUZ").ToString),
                    .Customer = r("ACGCOD").ToString,
                    .Payment = condPag,
                    .CustomerBank = "todo",
                    .CompanyBank = "todo",
                    .SendDocumentsTo = "todo",
                    .PaymentAddress = "todo",
                    .Area = r("FILIALE").ToString,
                    .Salesperson = agente,
                    .Notes = driv,
                    .AccTpl = defOrdini.SaleOrderAccTpl,
                    .TaxJournal = "VEN",
                    .InvRsn = defOrdini.SaleOrderInvRsn,
                    .ShippingReason = "Vend. cliente",
                    .StubBook = "CLIENTI",
                    .StoragePhase1 = "SEDE",
                    .SpecificatorPhase1 = "",
                    .SaleOrdId = saleOrdId,
                    .Job = "",
                    .CostCenter = dvTabelle.CercaValoreSuTabelleFox("CC", r("CCOSTO").ToString),
                    .PriceListValidityDate = Valid_Data(r("DTPRODUZ").ToString),
                    .InvoicingCustomer = r("ACGCOD").ToString,
                    .ExpectedDeliveryDate = Valid_Data(r("DTPRODUZ").ToString),
                    .ConfirmedDeliveryDate = sDataNulla,
                    .Carrier1 = vettore,
                    .OurReference = r("FILFATT").ToString,
                    .YourReference = contratto,
                    .CompanyCa = "todo",
                    .CompanyPymtCa = "todo",
                    .Presentation = 1376260,
                    .CompulsoryDeliveryDate = sDataNulla,
                    .ShipToAddress = "todo",
                    .BankAuthorization = "todo",
                    .ContractCode = drFattEle("F2126").ToString.Trim,
                    .ProjectCode = drFattEle("F2127").ToString.Trim,
                    .Tbguid = Guid.NewGuid,
                    .IdContractIntegra = contratto,
                    .Currency = "EUR",
                    .AccrualPercAtInvoiceDate = 100,
                    .InstallmStartDateIsAuto = "1",
                    .SalespersonCommAuto = "0",
                    .AreaManagerCommAuto = "0",
                    .SalespersonCommPercAuto = "0",
                    .AreaManagerCommPercAuto = "0",
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                }
#Region "campi non usati"
                '.Language VARCHAR(8),
                '.NonStandardPayment Char(1)	, ZERO
                '.PriceList VARCHAR(8)
                ', NetOfTax CHAR (1) UNO
                ', FixingDate DATETIME DATA NULLA
                ', FixingIsManual CHAR (1) ZERO
                ', Fixing FLOAT
                ', AccrualType INT

                ', AreaManager VARCHAR (8)
                ', StoragePhase2 VARCHAR (8)
                ', SpecificatorPhase2 VARCHAR (12)
                ', Delivered CHAR (1)
                ', Invoiced CHAR (1)
                ', PreShipped CHAR (1)
                ', Printed CHAR (1)
                ', SentByEMail CHAR (1)
                ', UseBusinessYear CHAR (1)
                ', Cancelled CHAR (1)
                ', ProductLine VARCHAR (8)
                ', PriceListFromDeliveryDate CHAR (1)
                ', SingleDelivery CHAR (1)
                ', LastSubId INT
                ', ContractType INT
                ', AccGroup VARCHAR (2)
                ', Picked CHAR (1)
                ', SaleTypeByLine CHAR (1)
                ', SaleType INT
                ', Allocated CHAR (1)
                ', AllocationArea VARCHAR (8)
                ', IsBlocked CHAR (1)
                ', BlockType INT
                ', UnblockWorker INT
                ', UnblockDate DATETIME
                ', Port VARCHAR (8)
                ', Package VARCHAR (8)
                ', Transport VARCHAR (16)
                ', TaxCommunicationGroup VARCHAR (16)
                ', SentByPostaLite CHAR (1)
                ', Archived CHAR (1)
                ', FromExternalProgram INT
                ', ActiveSubcontracting CHAR (1)
                ', InvoiceFollows CHAR (1)
                ', InstallmStartDate DATETIME DATANULLA
                ', SalespersonCommTot FLOAT
                ', AreaManagerCommTot FLOAT
                ', BaseSalesperson FLOAT
                ', BaseAreaManager FLOAT
                ', SalespersonCommPerc FLOAT
                ', AreaManagerCommPerc FLOAT
                ', SalespersonPolicy VARCHAR (9)
                ', AreaManagerPolicy VARCHAR (9)
                ', Specificator1Type INT
                ', Specificator2Type INT
                ', OpenOrder CHAR (1)
                ', ContractNo VARCHAR (8)
                ', SubIdAttivita SMALLINT
                ', SubIdContratto SMALLINT
                ', SubIdDescrizione SMALLINT

#End Region
                'Aggiungo la riga alla collection
                'Faccio in Fondo perche devo aggiungere dei contatori (righe contratto, descrizioni etc)
#End Region
#Region "Shipping"
                Dim rOrdShipping As New MaSaleOrdShipping With {
                    .SaleOrdId = saleOrdId,
                    .Carrier1 = vettore,
                    .ShipToAddress = "",
                    .NoOfPacksIsAuto = "1",
                    .NetWeightIsAuto = "1",
                    .GrossWeightIsAuto = "1",
                    .GrossVolumeIsAuto = "1",
                    .UseOrderPort = "0",
                    .PortAuto = "1",
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                     }
                efMaSaleOrdShipping.Add(rOrdShipping)
#End Region
#Region "Summary"
                Dim rOrdSummary As New MaSaleOrdSummary With {
                    .SaleOrdId = saleOrdId,
                    .StampsChargesTaxCode = defVendite.StampsTaxAmount,
                    .CollectionChargesTaxCode = defVendite.CollectionTaxAmount,
                    .InsuranceChargesIsAuto = "0",
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                     }
                efMaSaleOrdSummary.Add(rOrdSummary)
#End Region
#Region "All OrdiniAcc"
                Dim rOrdAcc As New AllordCliAcc With {
                                        .IdOrdCli = saleOrdId,
                                        .ApplicoIstat = If(r("AUMENTO") = 1, "1", "0"),
                                        .MesiDurata = CalcolaDurataContratto(r("GGDURATA")),
                                        .MesiRinnovo = 0,
                                        .Ggdisdetta = 0,
                                        .DataScadenzaFissa = Valid_Data(r("DTCESSFATT").ToString),
                                        .DataRiscatto = sDataNulla,
                                        .ImportoRiscatto = 0,
                                        .DataRiduzione = sDataNulla,
                                        .ImportoRiduzione = 0,
                                        .PercRiduzione = 0,
                                        .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                                        .DataCessazione = sDataNulla,
                                        .MotivoCessazione = "",
                                        .TipoContratto = 1108934656,
                                        .ImpiantoProprietaCliente = "0",
                                        .ImportoCanone = r("CANALLEUR"),
                                        .ContributoInstallazione = r("CANALLEUR"),
                                        .OrdineSospeso = "0",
                                        .DataSospensione = sDataNulla,
                                        .MotivoSospensione = r("WHYCESS").ToString,
                                        .Agente = agente,
                                        .ImportoProvvigione = 0,
                                        .Impianto = "todo",
                                        .Nota = "todo",
                                        .ModelloContratto = 1229717506,
                                        .CondPag = condPag,
                                        .SedeInvioDoc = "todo",
                                        .Vettore = vettore,
                                        .CdC = dvTabelle.CercaValoreSuTabelleFox("CC", r("CCOSTO").ToString),
                                        .ImpiantoDue = "",
                                        .Tbcreated = Now,
                                        .Tbmodified = Now,
                                        .TbcreatedId = sLoginId,
                                        .TbmodifiedId = sLoginId
                                        }
                rOrdAcc.DataPrevistaScadenza = rOrdAcc.DataDecorrenza.Value.AddMonths(rOrdAcc.MesiDurata)
                'Aggiungo la riga alla collection
                efAllordCliAcc.Add(rOrdAcc)

#End Region
#Region "All Ordini Contratto"
                Dim iLine As Integer = 1
                'Al momento non scrivo descrizione = left(r("DESCAN").ToString.Trim,128) perche' e' gestita con le righe sdescrittive
                'todo qta !!!
                Dim rOrdContratto As New AllordCliContratto With {
                                        .IdOrdCli = saleOrdId,
                                        .Line = iLine,
                                        .Servizio = r("TIPSERV"),
                                        .Descrizione = "",
                                        .Qta = 0,
                                        .Um = "",
                                        .ValUnit = If(r("OLDCANONE") = 0, r("CANONE"), r("OLDCANONE")),
                                        .ValUnitIstat = r("CANONE"),
                                        .DataUltRivIstat = Valid_Data(r("DTVARCAN").ToString),
                                        .Franchigia = 0,
                                        .Nota = "todo",
                                        .TipoRigaServizio = r("FREQ").ToString,
                                        .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                                        .NonRiportaInFatt = "0",
                                        .Fatturato = "0",
                                        .DataFineElaborazione = sDataNulla,
                                        .DataProssimaFatt = New DateTime(2023, 12, 31).ToString,
                                        .CodiceIva = codIva,
                                        .Tbcreated = Now,
                                        .Tbmodified = Now,
                                        .TbcreatedId = sLoginId,
                                        .TbmodifiedId = sLoginId
                                        }
                'Aggiungo la riga alla collection
                efAllordCliContratto.Add(rOrdContratto)

                'Costo Servizi Aggiuntivi (loro li chiamano Canone)
                'TODO:  PERIODICITA' SECONDO ME SBAGLIATA 1A,
                'DATA PROSSIMA FATTURA
                'If(String.IsNullOrWhiteSpace( r("PERISP").ToString), "1P",r("PERISP").ToString)
                'ISPEZIONI
                If r("CANISP") > 0 Then
                    iLine += 1
                    Dim rOrdContrattoAgg As New AllordCliContratto With {
                                       .IdOrdCli = saleOrdId,
                                       .Line = iLine,
                                       .Servizio = "CANISP",
                                       .Descrizione = "",
                                       .Qta = 1,
                                       .Um = "",
                                       .ValUnit = r("CANISP"),
                                       .ValUnitIstat = r("CANISP"),
                                       .DataUltRivIstat = sDataNulla,
                                       .Franchigia = r("FRAISP"),
                                       .Nota = "todo",
                                       .TipoRigaServizio = "CONS",
                                       .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                                       .NonRiportaInFatt = "0",
                                       .Fatturato = "0",
                                       .DataFineElaborazione = sDataNulla,
                                       .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                                       .CodiceIva = codIva,
                                       .Tbcreated = Now,
                                       .Tbmodified = Now,
                                       .TbcreatedId = sLoginId,
                                       .TbmodifiedId = sLoginId
                                       }
                    'Aggiungo la riga alla collection
                    efAllordCliContratto.Add(rOrdContrattoAgg)
                End If
                'INTERVENTI
                If r("CANINT") > 0 Then
                    iLine += 1
                    Dim rOrdContrattoAgg As New AllordCliContratto With {
                                      .IdOrdCli = saleOrdId,
                                      .Line = iLine,
                                      .Servizio = "CANINT",
                                      .Descrizione = "",
                                      .Qta = 1,
                                      .Um = "",
                                      .ValUnit = r("CANINT"),
                                      .ValUnitIstat = r("CANINT"),
                                      .DataUltRivIstat = sDataNulla,
                                      .Franchigia = r("FRAINT"),
                                      .Nota = "todo",
                                      .TipoRigaServizio = "CONS",
                                      .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                                      .NonRiportaInFatt = "0",
                                      .Fatturato = "0",
                                      .DataFineElaborazione = sDataNulla,
                                      .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                                      .CodiceIva = codIva,
                                      .Tbcreated = Now,
                                      .Tbmodified = Now,
                                      .TbcreatedId = sLoginId,
                                      .TbmodifiedId = sLoginId
                                      }
                    'Aggiungo la riga alla collection
                    efAllordCliContratto.Add(rOrdContrattoAgg)
                End If
                'APERTURA/CHIUSURA
                If r("CANAPECHIU") > 0 Then
                    iLine += 1
                    Dim rOrdContrattoAgg As New AllordCliContratto With {
                                      .IdOrdCli = saleOrdId,
                                      .Line = iLine,
                                      .Servizio = "CANAPECHIU",
                                      .Descrizione = "",
                                      .Qta = 1,
                                      .Um = "",
                                      .ValUnit = r("CANAPECHIU"),
                                      .ValUnitIstat = r("CANAPECHIU"),
                                      .DataUltRivIstat = sDataNulla,
                                      .Franchigia = r("FRAAPE"),
                                      .Nota = "todo",
                                      .TipoRigaServizio = "CONS",
                                      .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                                      .NonRiportaInFatt = "0",
                                      .Fatturato = "0",
                                      .DataFineElaborazione = sDataNulla,
                                      .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                                      .CodiceIva = codIva,
                                      .Tbcreated = Now,
                                      .Tbmodified = Now,
                                      .TbcreatedId = sLoginId,
                                      .TbmodifiedId = sLoginId
                                      }
                    'Aggiungo la riga alla collection
                    efAllordCliContratto.Add(rOrdContrattoAgg)
                End If
                'ASSISTENZA
                If r("CANASSIST") > 0 Then
                    iLine += 1
                    Dim rOrdContrattoAgg As New AllordCliContratto With {
                                      .IdOrdCli = saleOrdId,
                                      .Line = iLine,
                                      .Servizio = "CANASSIST",
                                      .Descrizione = "",
                                      .Qta = 1,
                                      .Um = "",
                                      .ValUnit = r("CANASSIST"),
                                      .ValUnitIstat = r("CANASSIST"),
                                      .DataUltRivIstat = sDataNulla,
                                      .Franchigia = r("FRAASS"),
                                      .Nota = "todo",
                                      .TipoRigaServizio = "CONS",
                                      .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                                      .NonRiportaInFatt = "0",
                                      .Fatturato = "0",
                                      .DataFineElaborazione = sDataNulla,
                                      .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                                      .CodiceIva = codIva,
                                      .Tbcreated = Now,
                                      .Tbmodified = Now,
                                      .TbcreatedId = sLoginId,
                                      .TbmodifiedId = sLoginId
                                      }
                    'Aggiungo la riga alla collection
                    efAllordCliContratto.Add(rOrdContrattoAgg)
                End If
                'PIANTONI
                If r("CANPIA") > 0 Then
                    iLine += 1
                    Dim rOrdContrattoAgg As New AllordCliContratto With {
                                      .IdOrdCli = saleOrdId,
                                      .Line = iLine,
                                      .Servizio = "CANPIA",
                                      .Descrizione = "",
                                      .Qta = 1,
                                      .Um = "",
                                      .ValUnit = r("CANPIA"),
                                      .ValUnitIstat = r("CANPIA"),
                                      .DataUltRivIstat = sDataNulla,
                                      .Franchigia = r("FRAPIA"),
                                      .Nota = "todo",
                                      .TipoRigaServizio = "CONS",
                                      .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                                      .NonRiportaInFatt = "0",
                                      .Fatturato = "0",
                                      .DataFineElaborazione = sDataNulla,
                                      .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                                      .CodiceIva = codIva,
                                      .Tbcreated = Now,
                                      .Tbmodified = Now,
                                      .TbcreatedId = sLoginId,
                                      .TbmodifiedId = sLoginId
                                      }
                    'Aggiungo la riga alla collection
                    efAllordCliContratto.Add(rOrdContrattoAgg)
                End If
                'VIDEO ISP.
                If r("CANVID") > 0 Then
                    iLine += 1
                    Dim rOrdContrattoAgg As New AllordCliContratto With {
                             .IdOrdCli = saleOrdId,
                             .Line = iLine,
                             .Servizio = "CANVID",
                             .Descrizione = "",
                             .Qta = 1,
                             .Um = "",
                             .ValUnit = r("CANVID"),
                             .ValUnitIstat = r("CANVID"),
                             .DataUltRivIstat = sDataNulla,
                             .Franchigia = r("FRAVID"),
                             .Nota = "todo",
                             .TipoRigaServizio = "CONS",
                             .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                             .NonRiportaInFatt = "0",
                             .Fatturato = "0",
                             .DataFineElaborazione = sDataNulla,
                             .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                             .CodiceIva = codIva,
                             .Tbcreated = Now,
                             .Tbmodified = Now,
                             .TbcreatedId = sLoginId,
                             .TbmodifiedId = sLoginId
                             }
                    'Aggiungo la riga alla collection
                    efAllordCliContratto.Add(rOrdContrattoAgg)
                End If
                rOrd.SubIdContratto = iLine
#End Region
#Region "Note Ordini"
                Dim rOrdNotes As New MaSaleOrdNotes With {
                    .SaleOrdId = saleOrdId,
                    .Notes = Left(r("DNOTE").ToString.Trim, 251),
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                     }
                efMaSaleOrdNotes.Add(rOrdNotes)
#End Region
#Region "Padre/Figlio"
                Dim rOrdFiglio As New AllordFiglio With {
                    .IdOrdCli = saleOrdId,
                    .IdOrdFiglio = 0,
                    .NrOrdFiglio = r("CONTRSUCC").ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                     }
                efAllordFiglio.Add(rOrdFiglio)
                Dim rOrdPadre As New AllordPadre With {
                    .IdOrdCli = saleOrdId,
                    .IdOrdPadre = 0,
                    .NrOrdPadre = r("CONTRPREC").ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                     }
                efAllordPadre.Add(rOrdPadre)
#End Region
#Region "All Ordini Descrizioni"
                ' Se i campi DFAT1-DFAT2-DFAT3-DFAT4 sono vuoti DESCAN è proprio la descrizione del dettaglio di fattura, viceversa è solo una descrizione.
                ' Quelli con DESCAN a * o /* sono probabilmente frutto delle varie acquisizioni/fusioni per incorporazione.
                iLine = 0
                'AggiungiDalAl
                Dim descriFatt As String = String.Concat(r("DFAT1"), r("DFAT2"), r("DFAT3"), r("DFAT4")).Trim
                If Len(descriFatt) = 0 Then
                    Dim descri As String = Left(r("DESCAN").ToString.Trim, 128)
                    If descri = "*" Or descri = "-" Or descri = "*/" Then descri = ""
                    Dim rOrdDescri As New AllordCliDescrizioni With {
                                     .IdOrdCli = saleOrdId,
                                     .Line = iLine + 1,
                                     .Codice = "",
                                     .Descrizione = descri,
                                     .Tbcreated = Now,
                                     .Tbmodified = Now,
                                     .TbcreatedId = sLoginId,
                                     .TbmodifiedId = sLoginId
                                     }
                    'Aggiungo la riga alla collection
                    efAllordCliDescrizioni.Add(rOrdDescri)
                Else
                    Dim descriList As List(Of String) = GetListTextWithNewLines(descriFatt, 128)
                    If descriList.Count > 0 Then
                        For i = 0 To descriList.Count - 1
                            Dim rOrdDescri As New AllordCliDescrizioni With {
                                         .IdOrdCli = saleOrdId,
                                         .Line = i + 1,
                                         .Codice = "",
                                         .Descrizione = descriList(i),
                                         .Tbcreated = Now,
                                         .Tbmodified = Now,
                                         .TbcreatedId = sLoginId,
                                         .TbmodifiedId = sLoginId
                                         }
                            'Aggiungo la riga alla collection
                            efAllordCliDescrizioni.Add(rOrdDescri)
                        Next
                    End If
                    iLine = descriList.Count
                End If
                rOrd.SubIdDescrizione = iLine
#End Region
#Region "All Ordini Tipologia Servizi"
                Dim rOrdTipologiaServizi As New AllordCliTipologiaServizi With {
                                     .IdOrdCli = saleOrdId,
                                     .Tipologia = r("TIPSERV").ToString,
                                     .Tbcreated = Now,
                                     .Tbmodified = Now,
                                     .TbcreatedId = sLoginId,
                                     .TbmodifiedId = sLoginId
                                     }
                'Aggiungo la riga alla collection
                efAllordCliTipologiaServizi.Add(rOrdTipologiaServizi)
#End Region
                efMaSaleOrd.Add(rOrd)

                AvanzaBarra()
            End If

        Next

#Region "Dispose"
        dvTabelle.Dispose()
        dtContratti.Dispose()
        dtRaggTeste.Dispose()
        dtRaggDett.Dispose()
        dtTabelle.Dispose()
#End Region

    End Sub
    Private Sub SalvaOrdini()

        Dim someTrouble As Boolean = False
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()
        'Dim avvisi As New StringBuilder()
        Dim msgLog As String

        Dim totOrdini As Integer = efMaSaleOrd.Count
        msgLog = "Ordini da Inserire : " & totOrdini.ToString
        My.Application.Log.DefaultFileLogWriter.WriteLine(msgLog)
        FLogin.lstStatoConnessione.Items.Add(msgLog)

        If totOrdini > 0 Then
            'Parametri
            'https://github.com/borisdj/EFCore.BulkExtensions

            Using bulkTrans = OrdiniCntx.Database.BeginTransaction
                Dim iStep As Integer
                Try
                    OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento teste ordini")
                    If efMaSaleOrd.Any Then
                        Dim t = efMaSaleOrd.Count
                        Dim cfgOrd As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = If(t <= 10, t, t / 10)
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efMaSaleOrd, cfgOrd, Function(d) d)
                        Debug.Print("MaSaleOrd Ins:" & cfgOrd.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrd.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaSaleOrd Ins:" & cfgOrd.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrd.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento totali ordini")
                    If efMaSaleOrdSummary.Any Then
                        Dim t = efMaSaleOrdSummary.Count
                        Dim cfgOrdTot As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efMaSaleOrdSummary, cfgOrdTot, Function(d) d)
                        Debug.Print("MaSaleOrdSummary Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaSaleOrdSummary Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento Dati Spedizione ordini")
                    If efMaSaleOrdShipping.Any Then
                        Dim t = efMaSaleOrdShipping.Count
                        Dim cfgOrdTot As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efMaSaleOrdShipping, cfgOrdTot, Function(d) d)
                        Debug.Print("MaSaleOrdShipping Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaSaleOrdShipping Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento note ordini")
                    If efMaSaleOrdNotes.Any Then
                        Dim t = efMaSaleOrdNotes.Count
                        Dim cfgOrdTot As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efMaSaleOrdNotes, cfgOrdTot, Function(d) d)
                        Debug.Print("MaSaleOrdNotes Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaSaleOrdNotes Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento dati accessori ordini")
                    If efAllordCliAcc.Any Then
                        Dim t = efAllordCliAcc.Count
                        Dim cfgOrdAcc As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliAcc, cfgOrdAcc, Function(d) d)
                        Debug.Print("ALLOrdCliAcc Ins:" & cfgOrdAcc.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAcc.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("ALLOrdCliAcc Ins:" & cfgOrdAcc.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAcc.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento righe contratto ")
                    If efAllordCliContratto.Any Then
                        Dim t = efAllordCliContratto.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliContratto, cfgOrdCon, Function(d) d)
                        Debug.Print("AllordCliContratto Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("AllordCliContratto Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento righe Descrizioni ")
                    If efAllordCliDescrizioni.Any Then
                        Dim t = efAllordCliDescrizioni.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliDescrizioni, cfgOrdCon, Function(d) d)
                        Debug.Print("AllordCliDescrizioni Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("AllordCliDescrizioni Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento ordini Figlio ")
                    If efAllordFiglio.Any Then
                        Dim t = efAllordFiglio.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordFiglio, cfgOrdCon, Function(d) d)
                        Debug.Print("AllordFiglio Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("AllordFiglio Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento ordini Padre ")
                    If efAllordPadre.Any Then
                        Dim t = efAllordPadre.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordPadre, cfgOrdCon, Function(d) d)
                        Debug.Print("AllordPadre Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("AllordPadre Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento righe Tipologie Servizi ")
                    If efAllordCliTipologiaServizi.Any Then
                        Dim t = efAllordCliTipologiaServizi.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliTipologiaServizi, cfgOrdCon, Function(d) d)
                        Debug.Print("AllordCliTipologiaServizi Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("AllordCliTipologiaServizi Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: IdNumbers ")
                    If efMaIdnumbers.Any Then
                        Dim t = efMaIdnumbers.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efMaIdnumbers, cfgOrdCon, Function(d) d)
                        Debug.Print("MaIdnumbers Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaIdnumbers Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Non Fiscal Numbers ")
                    If efMaNonFiscalNumbers.Any Then
                        Dim t = efMaNonFiscalNumbers.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efMaNonFiscalNumbers, cfgOrdCon, Function(d) d)
                        Debug.Print("MaNonFiscalNumbers Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaNonFiscalNumbers Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    If someTrouble Then
                        bulkTrans.Rollback()
                        bulkMessage.AppendLine("[Salvataggio] Sono stati riscontrati degli errori. Eseguita rollback")
                    Else
                        bulkTrans.Commit()
                        FLogin.lstStatoConnessione.Items.Add(" --- Inserimento Dati ---")
                        msgLog = "Ordini Inseriti : " & totOrdini.ToString
                        Debug.Print(msgLog)
                        bulkMessage.AppendLine("[RIASSUNTO] " & msgLog)
                        FLogin.lstStatoConnessione.Items.Add(msgLog)
                    End If
                    OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

                Catch ex As Exception
                    someTrouble = True
                    Debug.Print(ex.Message)
                    FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori allo step " & iStep)
                    bulkMessage.AppendLine("[Salvataggio] - STEP: " & iStep & " - Sono stati riscontrati degli errori. (Vedere sezione Errori)")
                    errori.AppendLine("[Salvataggio] Messaggio:" & ex.Message)
                    errori.AppendLine("[Salvataggio] Stack:" & ex.StackTrace)

                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                End Try
            End Using
        End If
    End Sub
    Private Sub SalvaClienti()

        Dim someTrouble As Boolean = False
        Dim bulkMessage As New StringBuilder()
        Dim errori As New StringBuilder()
        'Dim avvisi As New StringBuilder()
        Dim msgLog As String

        Dim totClienti As Integer = efMaCustSupp.Count
        msgLog = "Clienti da Inserire : " & totClienti.ToString
        My.Application.Log.DefaultFileLogWriter.WriteLine(msgLog)
        FLogin.lstStatoConnessione.Items.Add(msgLog)

        If totClienti > 0 Then
            'Parametri
            'https://github.com/borisdj/EFCore.BulkExtensions

            Using bulkTrans = OrdiniCntx.Database.BeginTransaction
                Dim iStep As Integer
                Try
                    OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEON(610)")

                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento Clienti")
                    If efMaCustSupp.Any Then
                        Dim t = efMaCustSupp.Count
                        Dim cfgOrd As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsert(efMaCustSupp, cfgOrd, Function(d) d)
                        Debug.Print("MaCustSupp Ins:" & cfgOrd.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrd.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaCustSupp Ins:" & cfgOrd.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrd.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento Sedi Clienti")
                    If efMaCustSuppBranches.Any Then
                        Dim t = efMaCustSuppBranches.Count
                        Dim cfgOrdTot As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsert(efMaCustSuppBranches, cfgOrdTot, Function(d) d)
                        Debug.Print("MaCustSuppBranches Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaCustSuppBranches Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento Altri dati Clienti")
                    If efMaCustSuppCustomerOptions.Any Then
                        Dim t = efMaCustSuppCustomerOptions.Count
                        Dim cfgOrdAcc As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsert(efMaCustSuppCustomerOptions, cfgOrdAcc, Function(d) d)
                        Debug.Print("MaCustSuppCustomerOptions Ins:" & cfgOrdAcc.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAcc.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaCustSuppCustomerOptions Ins:" & cfgOrdAcc.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdAcc.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento Persona Fisica")
                    If efMaCustSuppNaturalPerson.Any Then
                        Dim t = efMaCustSuppNaturalPerson.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsert(efMaCustSuppNaturalPerson, cfgOrdCon, Function(d) d)
                        Debug.Print("MaCustSuppNaturalPerson Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaCustSuppNaturalPerson Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento Dichiarazioni di Intento ")
                    If efMaDeclarationOfIntent.Any Then
                        Dim t = efMaDeclarationOfIntent.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsert(efMaDeclarationOfIntent, cfgOrdCon, Function(d) d)
                        Debug.Print("MaDeclarationOfIntent Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaDeclarationOfIntent Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento mandati ")
                    If efMaSddmandate.Any Then
                        Dim t = efMaSddmandate.Count
                        Dim cfgOrdCon As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsert(efMaSddmandate, cfgOrdCon, Function(d) d)
                        Debug.Print("MaSddmandate Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaSddmandate Ins:" & cfgOrdCon.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdCon.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    If someTrouble Then
                        bulkTrans.Rollback()
                        bulkMessage.AppendLine("[Salvataggio] Sono stati riscontrati degli errori. Eseguita rollback")
                    Else
                        bulkTrans.Commit()
                        FLogin.lstStatoConnessione.Items.Add(" --- Inserimento Dati ---")
                        msgLog = "Ordini Estratti : " & totClienti.ToString
                        Debug.Print(msgLog)
                        bulkMessage.AppendLine("[RIASSUNTO] " & msgLog)
                        FLogin.lstStatoConnessione.Items.Add(msgLog)
                    End If
                    OrdiniCntx.Database.ExecuteSqlRaw("DBCC TRACEOFF(610)")

                Catch ex As Exception
                    someTrouble = True
                    Debug.Print(ex.Message)
                    FLogin.lstStatoConnessione.Items.Add("Annullamento operazione: Riscontrati errori allo step " & iStep)
                    bulkMessage.AppendLine("[Salvataggio] - STEP: " & iStep & " - Sono stati riscontrati degli errori. (Vedere sezione Errori)")
                    errori.AppendLine("[Salvataggio] Messaggio:" & ex.Message)
                    errori.AppendLine("[Salvataggio] Stack:" & ex.StackTrace)

                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                End Try
            End Using
        End If
    End Sub

    <Extension()>
    Public Function CercaValoreSuTabelleFox(ByVal dv As DataView, ByVal tipo As String, ByVal valore As String, ByVal Optional excludeMessage As Boolean = True) As String
        Dim result As String = ""
        Dim originalFilter As String = dv.RowFilter
        dv.RowFilter = $"TIPO = '{tipo}' AND CODICE = '{valore}'"
        If dv.Count = 1 Then
            result = dv(0)("VALORE").ToString
        Else
            If Not excludeMessage Then
                Dim mb As New MessageBoxWithDetails("Dato non trovato:" & $"TIPO = '{tipo}' AND CODICE = '{valore}'", GetCurrentMethod.Name, "")
                mb.ShowDialog()
            End If
        End If
        dv.RowFilter = originalFilter
        Return result
    End Function

    <Extension()>
    Public Function CercaContropartitaFox(ByVal dv As DataView, ByVal valore As String, ByVal Optional excludeMessage As Boolean = True) As String
        If String.IsNullOrWhiteSpace(valore) Then Return ""
        If Len(valore) = 8 Then Return valore

        Dim ACGOffset As String = Left(Right(valore, 7), 6)
        'ottengo una valore lunga 8
        Dim key As String = Left(ACGOffset, 2) & "0" & Mid(ACGOffset, 3, 1) & "0" & Right(ACGOffset, 3)
        Dim originalFilter As String = dv.RowFilter
        dv.RowFilter = $"ACGCode = '{key}'"

        Dim result As String = ""
        If dv.Count = 1 Then
            result = dv(0)("ACCOUNT")
        Else
            If Not excludeMessage Then
                Dim mb As New MessageBoxWithDetails("Dato non trovato:" & $"AGCCODE = '{valore}'", GetCurrentMethod.Name, "")
                mb.ShowDialog()
            End If
        End If
        dv.RowFilter = originalFilter
        Return result
    End Function
    Private Function TrovaAgente(ByVal codice As String) As String
        Dim esito As String
        Select Case codice.ToUpper
            Case "017"
                esito = "UUUUUU"    'UFFICIO
            Case "018"
                esito = "BBBBBB"    'BURATTI PAOLO
            Case "019"
                esito = "AULETTA"    'AULETTA ANDREA
            Case "020"
                esito = "CCCCC"    'CARDAMONE UPPOLITO
            Case "021"
                esito = "GGGGG"    'GIULIANI
            Case "022"
                esito = "LUPA"    'LUPA
            Case "023"
                esito = "BOZZA P"    'BOZZA PIERO
            Case "024"
                esito = "BONO"    'BONO ROBERTO
            Case "025"
                esito = "SILVESTR"    'SILVESTRI
            Case "026"
                esito = "NEGRO"    'NEGRO DANIELE
            Case Else
                esito = "XXX"
        End Select
        Return esito
    End Function
    Private Function CalcolaDurataContratto(value As Integer) As Integer
        Dim i As Integer
        Select Case value
            Case <= 31
                i = 1
            Case 32 To 62
                i = 2
            Case 63 To 92
                i = 3
            Case 365
                i = 12
            Case 730
                i = 24
            Case 1095
                i = 36
            Case 1460
                i = 48
            Case 1825
                i = 60
            Case 3650
                i = 120
            Case Else
                i = CInt(Math.Round(value / 30, 0))
        End Select
        Return i
    End Function
    Private Function Cerca_Sostituisci_CaratteriSpeciali(dr As DataRow, campi As String()) As DataRow
        For Each value In campi
            'If String.IsNullOrWhiteSpace(value.ToString) Then
            '    Continue For
            'Else
            If String.IsNullOrWhiteSpace(dr(value).ToString) Then
                Continue For
            End If
            Dim s As String = dr(value).ToString
            'Rimpiazzo caratteri speciali conosciuti
            'https://www.asciitable.it/
            s = Regex.Replace(s, "Ó", "à")  '211 to 224
            s = Regex.Replace(s, "Þ", "è")  '222 to 232
            s = Regex.Replace(s, "ý", "ì")  '253 to 236
            s = Regex.Replace(s, "¨", "ù")  '168 to 249
            'value = Regex.Replace(value, "ý", "o")
            dr.Item(value) = s

            For Each c In value.ToCharArray
                Dim a As Integer = Asc(c)
                Select Case a
                    Case 0, 32 To 126, 128
                    Case 10, 13
                        'LF e CR
                    Case Else
                        Dim cha As Carattere_Speciale = charSpeciali.Find(Function(x) x.Asc = a)
                        If cha Is Nothing Then
                            cha = New Carattere_Speciale With {
                                    .Asc = a,
                                    .Carattere = c,
                                    .Occorrenze = 1
                                    }
                            charSpeciali.Add(cha)
                        Else
                            cha.Occorrenze += 1
                        End If
                        Continue For
                End Select
            Next
        Next
        Return dr
    End Function
    Private Class Carattere_Speciale
        Public Carattere As String
        Public Asc As Integer
        Public Occorrenze As Integer
    End Class
End Module

