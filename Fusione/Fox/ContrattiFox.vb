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
    Private ReadOnly lOk3 As String() = {"H00008", "H80157", "H00010", "H00012", "H00050", "H00074", "H00088", "H00126", "H00140", "H00172", "H00242", "H00616", "H00626", "H00650", "H01588"}
    Private ReadOnly lOK As String() = {"H01686", "H01620", "H00430", "H00650", "H01544"}
    Private ReadOnly lOK2 As String() = {"H01662", "H01686", "H00650", "H01479", "H00605"}
    Private ReadOnly lExclude As String() = {"H00430", "H01544"}
    '10 e 12 hanno 2 frequenze diverse
    '50 e 74 si potrebbero escludere,
    '88 ha 2 contratti con unica fattura
    '126 ha due contratti ma stesso indirizzo/sito 
    '140 anche ma ha gruppo inserito ovvero un canone a ZERO e quindi --> Distinta + raggruppamento su FT
    '242 ha 2 righe contratto fatturate in un unica fattura e raggruppamento su FT
    'entrambe hanno raggruppamento su FT
    '172 ha canone  zero , non viene fatturato, paga solo interventi ???
    '626 idem (FILFATT 94)
    '616 5 contratti, 3 in una ft, 1 e 1 -> 3 siti -> 3 ft
    '650 distinta di 3 contratti con 2 a conone a zero
    '1588 canoni a zero fattura qualcuno altro (FILFATT 94)


    'Gestisce l'import dei contratti da FoxPro a Mago
    Private ds As DataSet
    Dim dtContratti As DataTable
    Dim dtFattEle As DataTable
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
    Private efAllordCliFattEle As New List(Of AllordCliFattEle)
    Private efAllordCliContratto As New List(Of AllordCliContratto)
    Private efAllordCliContrattoDescFatt As New List(Of AllordCliContrattoDescFatt)
    Private efAllordCliContrattoDistinta As New List(Of AllordCliContrattoDistinta)
    Private efAllordCliContrattoDistintaServAgg As New List(Of AllordCliContrattoDistintaServAgg)
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
        CheckColonneExcel()
        ConnettiContesto()
        If Not FLogin.ChkEscludiControllo.Checked Then

            Dim sb As List(Of List(Of String)) = CheckOrdini()
            If sb.Count > 0 Then
                For i = 0 To sb.Count - 1
                    My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- " & If(i = 0, "Errori", "Avvisi") & "  ---" & Environment.NewLine)
                    Dim l As List(Of String) = sb(i)
                    For n = 0 To l.Count - 1
                        My.Application.Log.DefaultFileLogWriter.WriteLine(l(n))
                        FLogin.lstStatoConnessione.Items.Add(l(n))
                    Next
                Next
                FLogin.lstStatoConnessione.Items.Add("Impossibile continuare controllare errori precedenti")
                MessageBox.Show("Riscontrati Errori formali controllare log", "Importa Contratti Fox", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If
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
        'Viste le modifiche non creo la Constraints
        ds.Relations.Add("Raggruppamento_Ordine", ds.Tables("_ONTRORD").Columns("CONTRATTO"), ds.Tables("_AGRFATD").Columns("CONTRATTO"), False)
        ds.Relations.Add("Ordini Raggruppati", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_AGRFATD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("RAGRFATT")})
        ds.Relations.Add("RID", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_RID").Columns("CLIENTE"))
        ds.Relations.Add("ESENTI", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_SENTIIV").Columns("CLIENTE"))
        'ds.Relations.Add("FattEle", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_LIFTELE").Columns("CLIENTE"), ds.Tables("_LIFTELE").Columns("RAGRFATT")})
        'ds.Relations.Add("Pagamenti", ds.Tables("_ONTRORD").Columns("CPAGAM"), ds.Tables("ACGTRPG").Columns("CPAGAM"))
        dtContratti = ds.Tables("_ONTRORD")
        dtFattEle = ds.Tables("_LIFTELE")
        dtRaggTeste = ds.Tables("_AGRFATT")
        dtRaggDett = ds.Tables("_AGRFATD")
        dtTabelle = ds.Tables("_EWTAB")
        dvTabelle = New DataView(dtTabelle)
        dtPagamentiFox = ds.Tables("ACGTRPG")
        dvPagamentiFox = New DataView(dtPagamentiFox)
    End Sub
    Private Sub DisposeTables()
        dtContratti.Dispose()
        dtRaggTeste.Dispose()
        dtRaggDett.Dispose()
        dtTabelle.Dispose()
        dvTabelle.Dispose()
        dtPagamentiFox.Dispose()
        dvPagamentiFox.Dispose()
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
            'Dim w = OrdiniCntx.MaCustSupp.AsNoTracking.Where(Function(k) k.CustSuppType.Equals(CustSuppType.Cliente) And k.CustSupp.Equals(codice)).First
            If c Is Nothing Then
                'TODO: completare inserimento nuovo cliente da CLIENORD ( vedere su import fatture ftpa300
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
    Private Sub CheckColonneExcel()
        If Not dtContratti.Columns.Contains("GRP CONTRATTO") Then
            MessageBox.Show("Impossibile continuare colonne assenti GRP CONTRATTO su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            dtContratti.Columns("GRP CONTRATTO").ColumnName = "GRP_CONTRATTO"
        End If
        If Not dtContratti.Columns.Contains("GRP distinta/fattura") Then
            MessageBox.Show("Impossibile continuare colonne assenti GRP distinta/fattura su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            dtContratti.Columns("GRP distinta/fattura").ColumnName = "GRP_distinta_fattura"
        End If
        If Not dtContratti.Columns.Contains("CANONE ALL1") Then
            MessageBox.Show("Impossibile continuare colonne assenti CANONE ALL1 su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            dtContratti.Columns("CANONE ALL1").ColumnName = "CANONE_ALL1"
        End If
        If Not dtContratti.Columns.Contains("CDC ALL1") Then
            MessageBox.Show("Impossibile continuare colonne assenti CDC ALL1 su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            dtContratti.Columns("CDC ALL1").ColumnName = "CDC_ALL1"
        End If
        If Not dtContratti.Columns.Contains("CORREZIONI") Then
            MessageBox.Show("Impossibile continuare colonne assenti CORREZIONI su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If
        If Not dtContratti.Columns.Contains("vettore") Then
            MessageBox.Show("Impossibile continuare colonne assenti vettore su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If
    End Sub
    ''' <summary>
    ''' Esegue check sulla presenza dei dati di match nelle tabelle di mago
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckOrdini() As List(Of List(Of String))

        Dim avvisi As New List(Of String)
        Dim errori As New List(Of String)
        Dim dvPdc As DataView = LINQResultToDataView(From o In OrdiniCntx.MaChartOfAccounts.ToList)
        EditTestoBarra("Check Ordini")
        FLogin.prgCopy.Value = 1
        FLogin.prgCopy.Maximum = dtContratti.Rows.Count
        FLogin.prgCopy.Step = 1
        For Each r As DataRow In dtContratti.Rows
            'Numeratore Ordini
            If OrdiniCntx.MaNonFiscalNumbers.First(Function(k) k.CodeType = CodeType.OrdCli And k.BalanceYear = Year(r("DTPRODUZ"))) Is Nothing Then avvisi.Add("Contatore Ordini non trovato:" & r("DTPRODUZ").ToString)
            'Codice Iva
            If OrdiniCntx.MaTaxCodes.AsNoTracking.First(Function(k) k.Acgcode.Equals(r("CIVA").ToString)) Is Nothing Then avvisi.Add("Valore assente su Mago - Iva(CIVA):" & (r("CIVA")).ToString)
            'Pagamento
            ' If OrdiniCntx.MaPaymentTerms.AsNoTracking.First(Function(k) k.Acgcode.Equals(r("CPAGAM").ToString)) Is Nothing Then avvisi.AppendLine("Valore assente su Mago - Pagamento:" & (r("CPAGAM")).ToString)
            'Contropartita
            Dim contropartitaFox As String = dvTabelle.CercaValoreSuTabelleFox("TS", r("TIPSERV").ToString)
            If String.IsNullOrEmpty(dvPdc.CercaContropartitaFox(contropartitaFox)) Then avvisi.Add("Valore assente su Mago - Contropartita(TIPSERV):" & r("TIPSERV").ToString)
            'AGENTE
            Dim produttore As String = dvTabelle.CercaValoreSuTabelleFox("PT", r("PRODUTTORE").ToString)
            If TrovaAgente(r("PRODUTTORE").ToString, r("FILIALE")) = "XXX" Then avvisi.Add("Agente assente su Mago(PRODUTTORE):" & r("PRODUTTORE").ToString)
            'Frequenza = NO e Canone <> 0
            If r("FREQ").ToString = "NO" AndAlso CDbl(r("CANONE")) <> 0 Then errori.Add("Contratto con frequenza = NO ma Canone <> 0 :" & r("CONTRATTO").ToString)
            'contratto accorpato non presente
            Dim dvCheckGrp_Contratto As New DataView(dtContratti, "CONTRATTO='" & r("GRP_CONTRATTO").ToString & "'", "ACGCOD, GRP_CONTRATTO", DataViewRowState.CurrentRows)
            If dvCheckGrp_Contratto.Count = 0 Then errori.Add("Codice GRP_CONTRATTO (" & r("GRP_CONTRATTO").ToString & ") assente in CONTRATTO")

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
        For Each r As DataRow In dtFattEle.Rows
            'Campo invio fattura 1=Pec 2=SdI 3=Pubblica amministrazione (oggi dovrebbe essere per tutti 2 Sistema d'interscambio)
            If Len(r("SDI").ToString.Trim) = 0 OrElse CShort(r("SDI").ToString.Trim) = 0 Then avvisi.Add("SDI assente su cliente:" & r("CLIENTE").ToString & " raggruppamento:" & r("RAGRFATT").ToString)

        Next

        Return New List(Of List(Of String)) From {errori, avvisi}
    End Function
    Private Sub ScriviOrdini()

#Region "Variabili"
        Dim errori As New StringBuilder()
        Dim avvisi As New StringBuilder()

        Dim defVendite = (From dv In OrdiniCntx.MaUserDefaultSales.ToList Select dv).First
        Dim defOrdini = (From dor In OrdiniCntx.MaUserDefaultSaleOrders.ToList Select dor).First
        ' Dim defContabili = (From dc In OrdiniCntx.MaAccountingDefaults.ToList Select dc).First
        Dim defIva = (From di In OrdiniCntx.MaTaxCodesDefaults.ToList Select di).First
        Dim sDefContropartita As String = defVendite.ServicesSalesAccount
        Dim sDefCodIva As String = defIva.TaxCode
        Const TECNO_ALL1 As String = "NOLEGGIO SPA"
        Dim tecno_All1Descri As String = (From da In OrdiniCntx.MaItems.Where(Function(f) f.Item.Equals(TECNO_ALL1)).ToList Select da).First.Description

        Dim dvFattEle As New DataView(dtFattEle)

        Dim dtRID As DataTable = ds.Tables("_RID")
        Dim dvRID As New DataView(dtRID)

        efMaIdnumbers.Add(OrdiniCntx.MaIdnumbers.First(Function(k) k.CodeType = IdType.OrdCli))
        Dim saleOrdId As Integer = efMaIdnumbers(0).LastId
        efMaNonFiscalNumbers = OrdiniCntx.MaNonFiscalNumbers.Where(Function(k) k.CodeType = CodeType.OrdCli).ToList

        Dim cli As New MaCustSupp
        'Dim cliLINQ = From c In OrdiniCntx.MaCustSupp.Include(Function(o) o.MaCustSuppCustomerOptions)
        Dim sediCliente As New List(Of MaCustSuppBranches)
        Dim drDatiFatturaXls As DataRow = dtRaggTeste.NewRow
        Dim masterDistinta As New DistintaMaster
        'Dim rowsToExclude As Integer            'Totale righe da escludere
        Dim rowToExclude_cnt As Integer         'Contatore delle righe da escludere
        Dim masterOrder As New OrdineMaster
        Dim rowInOrder_cnt As Integer           'Contatore delle righe ordine

        'Ordino 
        'Al 15/09/23: si raggruppa solo se GRP_CONTRATTO sono uguali
        Dim dvContratti As New DataView(dtContratti, "", "ACGCOD, GRP_CONTRATTO, GRP_distinta_fattura, CANONE DESC", DataViewRowState.CurrentRows)
        '11/10/2023 E' possibile che alcuni contratti vadano assegnati ad altri e hanno codice cliente diverso ma GRP_CONTRATTO uguale
        Dim dvChkContratto_Cliente As New DataView(dtContratti, "", "CONTRATTO, ACGCOD", DataViewRowState.CurrentRows)
        Dim contrattiDaUnire As New List(Of DataRow)
        Dim iLineContratto As Short
        Dim iLineDistinta As Short
        Dim iLineDescFatt As Short

#End Region

        EditTestoBarra("Scrivi Ordini")
        FLogin.prgCopy.Value = 1
        FLogin.prgCopy.Maximum = dtContratti.Rows.Count
        FLogin.prgCopy.Step = 1
        'TODO: classe 1-n-n per le Attività, e rivedere anche sulla procedura di fatturazione (successivamente)

        For Each drv As DataRowView In dvContratti
            Dim r As DataRow = drv.Row
            'Limite temporaneo a SOLO ALCUNI CLIENTI righe ( solo per xls intero)
            'If Not lOK.Contains(r.Item("ACGCOD").ToString) Then Continue For
            'If lExclude.Contains(r.Item("ACGCOD").ToString) Then Continue For

            'Gestione contratti assegnati a cliente diverso 
            Select Case dvChkContratto_Cliente.FindRows(New Object() {r("GRP_CONTRATTO").ToString, r("ACGCOD").ToString}).Length
                Case 0
                    'Contratto da raggruppare con altro cliente
                    Debug.Print(r("ACGCOD").ToString & " " & r("CONTRATTO").ToString & " da raggruppare dopo")
                    avvisi.AppendLine("Contratto " & r("CONTRATTO").ToString & " del cliente " & r("ACGCOD").ToString & " raggruppato con altro cliente")
                    contrattiDaUnire.Add(r)
                    Continue For
                Case 1
                    'ok
                Case Else
                    Dim msgLog As String = "Impossibile continuare!" & Environment.NewLine & "Esistono piu' contratti con codice:" & r("GRP_CONTRATTO").ToString
                    errori.AppendLine("ERRORE FATALE : Esistono piu' contratti con codice:" & r("GRP_CONTRATTO").ToString)
                    Dim mb As New MessageBoxWithDetails(msgLog, GetCurrentMethod.Name)
                    mb.ShowDialog()
                    End
            End Select

            Dim contratto As String = r("CONTRATTO").ToString
            Dim clienteFox As String = r("CLIENTE").ToString
            Dim clienteACG As String = r("ACGCOD").ToString
            Debug.Print(clienteACG & " " & contratto)
            Dim centro As String = dvTabelle.CercaValoreSuTabelleFox("CC", r("CCOSTO").ToString)

            'Check Cambio cliente -> Carico Sedi
            If Not masterOrder.ClienteMago.Equals(clienteACG) Then
                sediCliente = OrdiniCntx.MaCustSuppBranches.AsNoTracking.Where(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) And f.CustSupp.Equals(clienteACG)).ToList
                'prevedo reset 
                rowInOrder_cnt = 0
                rowToExclude_cnt = 0
                'Ripristino anche la parte di distinta
                masterDistinta = New DistintaMaster
                masterOrder = New OrdineMaster
            End If
            '''''''''''''''''''''''''''''''''
            '            AVVISI
            '    vari su singolo contratto
            '''''''''''''''''''''''''''''''''
            'Data cessazione Fattura
            If Not String.IsNullOrWhiteSpace(r("DTCESSFATT").ToString) Then avvisi.AppendLine("Indicata data cessazione fattura DTCESSFATT su Contratto: " & contratto)

            'Prevedo il bypass di alcune righe a causa di accorpamento contratti (GRP -> Distinta)
            '19/09/2023:
            'GRP CONTRATTO --> ordine cappello Mago ( master)
            'GRP distinta/fattura --> distinta

            If masterOrder.RigheContratto > 0 Then
                rowInOrder_cnt += 1
                If rowInOrder_cnt = masterOrder.RigheContratto Then
                    'Ripristino
                    rowInOrder_cnt = 0
                    rowToExclude_cnt = 0
                    'Ripristino anche la parte di distinta
                    masterDistinta = New DistintaMaster
                End If
            End If
            If rowInOrder_cnt = 0 Then
                'Check Nuovo Ordine (Mago)
                If Not String.IsNullOrWhiteSpace(r("GRP_CONTRATTO").ToString) Then
                    Dim dvMasterOrd As New DataView(dtContratti, "GRP_CONTRATTO='" & r("GRP_CONTRATTO").ToString & "'", "ACGCOD, GRP_CONTRATTO", DataViewRowState.CurrentRows)
                    masterOrder = New OrdineMaster With {
                            .ClienteFox = clienteFox,
                            .ClienteMago = clienteACG,
                            .Contratto = r("GRP_CONTRATTO").ToString,
                            .RigheContratto = dvMasterOrd.Count,
                            .CdC = centro
                        }
                End If
                saleOrdId += 1
                efMaIdnumbers(0).LastId = saleOrdId
            End If

            'Analisi Distinta
            If masterDistinta.RigheDistinta > 0 Then
                rowToExclude_cnt += 1
                If rowToExclude_cnt = masterDistinta.RigheDistinta Then
                    'Ripristino
                    masterDistinta.RigheDistinta = 0
                    rowToExclude_cnt = 0
                    masterDistinta.GruppoDistinta = ""
                End If
            End If
            If rowToExclude_cnt = 0 Then
                If Not String.IsNullOrWhiteSpace(r("GRP_distinta_fattura").ToString) Then
                    Dim dvGroup As New DataView(dtContratti, "GRP_distinta_fattura='" & r("GRP_distinta_fattura") & "'", "ACGCOD, GRP_CONTRATTO, GRP_distinta_fattura", DataViewRowState.CurrentRows)
                    masterDistinta = New DistintaMaster With {
                            .GruppoDistinta = r("GRP_distinta_fattura").ToString,
                            .RigheDistinta = dvGroup.Count
                             }
                End If
            End If

            Dim sito As String = ""
#Region "Sito/Impianto = Sede Cliente"
            'Ricerca e creazione Sito/Impianto = Sede Cliente
            ' Dim c = OrdiniCntx.MaCustSuppBranches.Select(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) And f.CustSupp.Equals(clienteMago))
            Dim newBranches As Boolean = False
            Dim ragSocSito As String = Left(String.Concat(r("RAGSOC"), " ", r("PRAGSOC")).Trim, 128)

            If sediCliente.Any Then
                'Controllo esistenza con RAGSOC + (replace CrLf  ) + PRAGSOC e INDIRIZZO
                Dim sediRidotte As List(Of MaCustSuppBranches) = sediCliente.FindAll(Function(f) f.CompanyName.Replace(Environment.NewLine, " ").Equals(ragSocSito) And f.Address.Equals(r("INDIRIZZO").ToString)).ToList
                If sediRidotte.Count = 0 Then
                    newBranches = True
                    sito = "I" & (sediCliente.Count + 1).ToString("0000")
                ElseIf sediRidotte.Count = 1 Then
                    sito = sediRidotte.First.Branch
                ElseIf sediRidotte.Count > 1 Then
                    'Se ho piu' righe segnalo
                    Dim msgLog As String = "(NO SAVE) Più sedi simili, impossibile determinare corretta. Ordine:" & r("CONTRATTO").ToString
                    errori.AppendLine(msgLog)
                    Debug.Print(msgLog)
                End If
            Else
                newBranches = True
            End If

            If newBranches Then
                If String.IsNullOrWhiteSpace(sito) Then sito = "I0001"
                Dim rCliBr As New MaCustSuppBranches With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = clienteACG,
                                    .Branch = sito,
                                    .CompanyName = ragSocSito,
                                    .Address = r("INDIRIZZO").ToString,
                                    .City = r("COMUNE").ToString,
                                    .County = r("PROV").ToString,
                                    .Region = Get_Regione(r("PROV").ToString),
                                    .Zipcode = r("CAP").ToString,
                                    .IsocountryCode = "IT",
                                    .MailSendingType = 12451840,
                                    .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId,
                                    .Ipacode = "",
                                    .AdministrationReference = ""
                                    }
                'Aggiungo la riga alla collection
                efMaCustSuppBranches.Add(rCliBr)
                sediCliente.Add(rCliBr)

            End If
#End Region

#Region "Controlli ed estrazioni"
            'Variabili
            Dim codiceRaggruppamento As String = ""
            Dim newCodragg As String = ""
            Dim drFattEle As DataRow = dtFattEle.NewRow
            Dim condPagAcg As String = ""
            Dim condPag As String = ""
            Dim vettore As String = ""
            Dim codIva As String = ""
            Dim ordNo As String = ""
            Dim curNfCounter As New MaNonFiscalNumbers
            Dim sRivolgersiA As String = ""
            Dim agente As String = ""

            If rowInOrder_cnt = 0 Then '
                'Nuovo Ordine
                'Cliente
                clienteACG = r.Item("ACGCOD").ToString
                cli = OrdiniCntx.MaCustSupp.Find(CustSuppType.Cliente, clienteACG)
                If cli Is Nothing Then
                    Dim mb As New MessageBoxWithDetails("Cliente non trovato:" & clienteACG, GetCurrentMethod.Name)
                    mb.ShowDialog()
                    Continue For
                End If

                masterOrder.Banca.CompanyBank = cli.CompanyBank
                masterOrder.Banca.CompanyCa = cli.CompanyCa
                masterOrder.Banca.CustSuppBank = cli.CustSuppBank
                masterOrder.Banca.CustomerCompanyCa = cli.CustomerCompanyCa

                'CodiceRaggruppamento
                codiceRaggruppamento = r.GetChildRows("Raggruppamento_Ordine").SingleOrDefault()("RAGRFATT").ToString '_AGRFATD
                masterOrder.RaggruppamentoFattura = codiceRaggruppamento
                newCodragg = r("vettore").ToString
                masterOrder.Vettore = newCodragg
                drDatiFatturaXls = r.GetChildRows("Raggruppamento_Ordine").SingleOrDefault.GetParentRow("Ordini Raggruppati") ' _AGRFATT
                If drDatiFatturaXls Is Nothing Then
                    errori.AppendLine("Cliente _AGRFATT non trovato su Contratto: " & contratto & " CodiceRaggruppamento: " & codiceRaggruppamento)
                End If
                'Cerco dati fattura elettronica coerenti con (raggruppamento se esiste)
                dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                drFattEle = dtFattEle.NewRow
                If dvFattEle.Count = 1 Then
                    drFattEle = dvFattEle(0).Row
                Else
                    dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}'"
                    If dvFattEle.Count = 0 Then
                        errori.AppendLine("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto)
                        Dim mb As New MessageBoxWithDetails("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto, GetCurrentMethod.Name)
                        mb.ShowDialog()
                    ElseIf dvFattEle.Count = 1 Then
                        drFattEle = dvFattEle(0).Row
                    Else
                        Dim mb As New MessageBoxWithDetails("Più righe di Fatturazione Elettronica (CLIFTELE) impossibile determinare quella corretta: " & contratto, GetCurrentMethod.Name)
                        errori.AppendLine("Più righe di Fatturazione Elettronica (CLIFTELE) impossibile determinare quella corretta: " & contratto)
                        mb.ShowDialog()
                    End If
                End If
                masterOrder.CodiceSdi = drFattEle("F114").ToString
                masterOrder.Pec = drFattEle("F116").ToString
                masterOrder.RiferimentoAmministrazione = drFattEle("F126").ToString
                'Sede invio Documenti // Codice SDI
                If masterOrder.Contratto.Equals(contratto) Then
                    'Cerco se Ragione Sociale e' quella di invio fattura o serve la sede
                    'RAGRFATT.RAGSOC(PRAGSOC) = CLIENTE MAGO /SEDE LEGALE
                    'RAGRFATT.R_RSO(R_PSO) = SEDE INVIO DOCUMENTO
                    Dim newSendDoc As Boolean = False
                    '  Dim ragSocDatifatturaXls As String = Left(String.Concat(drDatiFatturaXls("RAGSOC").ToString, If(IsPrivato(cli.TaxIdNumber, cli.FiscalCode), "", " " & drDatiFatturaXls("PRAGSOC").ToString)).Trim, 128)
                    Dim ragSocDatifatturaXls As String = Left(String.Concat(drDatiFatturaXls("R_RSO").ToString, If(IsPrivato(cli.TaxIdNumber, cli.FiscalCode), "", " " & drDatiFatturaXls("R_PSO").ToString)).Trim, 128)
                    Dim sendDocumentTo As String = ""
                    'Dim IpaZero As String = If(cli.MaCustSuppCustomerOptions.PublicAuthority = "1", "000000", "0000000")
                    If ragSocDatifatturaXls.Equals(cli.CompanyName.Replace(Environment.NewLine, " ")) AndAlso drDatiFatturaXls("INDIRIZZO").Equals(cli.Address) AndAlso masterOrder.CodiceSdi.Equals(cli.Ipacode) Then
                        'Corrette RagSoc, Indirizzo , IPA Code
                        sendDocumentTo = ""
                    Else
                        'Filtro sedi uguale a RagSoc, Indirizzo
                        Dim sediRidotte As List(Of MaCustSuppBranches) = sediCliente.FindAll(Function(f) f.CompanyName.Replace(Environment.NewLine, " ").Equals(ragSocDatifatturaXls) AndAlso f.Address.Equals(drDatiFatturaXls("INDIRIZZO").ToString)).ToList
                        If sediRidotte.Count = 0 Then
                            'Se non trovo niente di simile nemmeno come RagSoc+Indirizzo la devo per forza creare
                            newSendDoc = True
                            sendDocumentTo = "FT" & (sediCliente.Count + 1).ToString("000")
                        ElseIf sediRidotte.Count = 1 Then
                            'Se ne ho una controllo ipa
                            If sediRidotte.First.Ipacode.Equals(cli.Ipacode) OrElse sediRidotte.First.Ipacode.Equals("") Then
                                'Solo se e' vuota posso usarla per l'indirizzo e lasciare IPA di Anagrafica
                                sendDocumentTo = sediRidotte.First.Branch
                            Else
                                newSendDoc = True
                                sendDocumentTo = "FT" & (sediCliente.Count + 1).ToString("000")
                            End If
                        Else
                            'Ho piu sedi con stesso indirizzo
                            'Ricomincio e cerco se l'IPA richiesto e' in una sede o se ho una sede senza nulla
                            Dim sediRidotte_IPA As List(Of MaCustSuppBranches) = sediRidotte.FindAll(Function(f) f.Ipacode.Equals(masterOrder.CodiceSdi))
                            If sediRidotte_IPA.Count = 0 Then
                                'Se non trovo niente controllo se ne ho una senza nulla
                                sediRidotte_IPA = sediRidotte.FindAll(Function(f) f.Ipacode.Equals(String.Empty))
                                'Se ne ho una controllo ipa
                                If sediRidotte_IPA.Count > 0 Then
                                    sendDocumentTo = sediRidotte_IPA.First.Branch
                                Else
                                    newSendDoc = True
                                    sendDocumentTo = "FT" & (sediCliente.Count + 1).ToString("000")
                                End If
                            ElseIf sediRidotte_IPA.Count = 1 Then
                                sendDocumentTo = sediRidotte_IPA.First.Branch
                            Else
                                Dim msgLog As String = "(NO SAVE) Più sedi simili (SendDocumenTo) con lo stesso CodiceSdi, impossibile determinare corretta. Ordine:" & r("CONTRATTO").ToString
                                errori.AppendLine(msgLog)
                                Debug.Print(msgLog)
                            End If
                        End If
                    End If
                    masterOrder.SedeInvioDoc = sendDocumentTo
                    If newSendDoc Then
                        'todo: riferimento amministrazione(vedere dove va)
                        Dim rCliBr As New MaCustSuppBranches With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = clienteACG,
                                    .Branch = sendDocumentTo,
                                    .CompanyName = ragSocDatifatturaXls,
                                    .Address = drDatiFatturaXls("INDIRIZZO").ToString,
                                    .City = drDatiFatturaXls("COMUNE").ToString,
                                    .County = drDatiFatturaXls("PROV").ToString,
                                    .Region = Get_Regione(drDatiFatturaXls("PROV").ToString),
                                    .Zipcode = drDatiFatturaXls("CAP").ToString,
                                    .IsocountryCode = "IT",
                                    .MailSendingType = 12451840,
                                    .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId,
                                    .Ipacode = masterOrder.CodiceSdi,
                                    .AdministrationReference = ""
                                    }
                        'Aggiungo la riga alla collection
                        efMaCustSuppBranches.Add(rCliBr)
                        sediCliente.Add(rCliBr)
                    End If
                End If

                'Cond pag
                dvPagamentiFox.RowFilter = "CPAGAM = '" & r("CPAGAM").ToString & "' AND ( SPLITPAY IS NULL OR SPLITPAY = '' )"
                condPagAcg = dvPagamentiFox(0)("ACGCOD").ToString
                condPag = OrdiniCntx.MaPaymentTerms.AsNoTracking.First(Function(k) k.Acgcode.Equals(condPagAcg)).Payment
                masterOrder.CondPag = condPag
                'RID
                dvRID.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                masterOrder.UMRCode = If(dvRID.Count = 1, dvRID(0)("CODINDIVID").ToString, "")

                'vettore = If(codiceRaggruppamento.Equals(contratto), "", CInt(codiceRaggruppamento).ToString)
                vettore = newCodragg
                codIva = OrdiniCntx.MaTaxCodes.AsNoTracking.First(Function(k) k.Acgcode.Equals(r("CIVA").ToString)).TaxCode
                masterOrder.CodIva = codIva
                curNfCounter = efMaNonFiscalNumbers.First(Function(k) k.BalanceYear = Year(r("DTPRODUZ")))
                curNfCounter.LastDocNo += 1
                efMaNonFiscalNumbers.First(Function(k) k.BalanceYear = Year(r("DTPRODUZ"))).LastDocNo = curNfCounter.LastDocNo
                ordNo = Right(Year(r("DTPRODUZ")), 2) & curNfCounter.Separators & CInt(curNfCounter.LastDocNo).ToString("00000")
                masterOrder.OrderNo = ordNo
                iLineContratto = 0

                sRivolgersiA = String.Concat(r("DRIV1").ToString, r("DRIV2").ToString, r("DRIV3").ToString, r("DRIV4").ToString).Trim
                agente = TrovaAgente(r("PRODUTTORE").ToString, r("FILIALE"))
            Else
#Region "Controlli di congruenza"
                'CodiceRaggruppamento
                codiceRaggruppamento = r.GetChildRows("Raggruppamento_Ordine").SingleOrDefault()("RAGRFATT").ToString
                'Cerco riferimento coerente con (raggruppamento se esiste)
                dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                drFattEle = dtFattEle.NewRow
                If dvFattEle.Count = 1 Then
                    drFattEle = dvFattEle(0).Row
                Else
                    dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}'"
                    If dvFattEle.Count = 0 Then
                        errori.AppendLine("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto)
                        Dim mb As New MessageBoxWithDetails("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto, GetCurrentMethod.Name)
                        mb.ShowDialog()
                    ElseIf dvFattEle.Count = 1 Then
                        drFattEle = dvFattEle(0).Row
                    Else
                        Dim mb As New MessageBoxWithDetails("Più righe di Fatturazione Elettronica (CLIFTELE) impossbile determinare quella corretta: " & contratto, GetCurrentMethod.Name)
                        errori.AppendLine("Più righe di Fatturazione Elettronica (CLIFTELE) impossbile determinare quella corretta: " & contratto)
                        mb.ShowDialog()
                    End If
                End If
                If Not codiceRaggruppamento.Equals(masterOrder.RaggruppamentoFattura) AndAlso CDbl(r("CANONE").ToString) <> 0 Then
                    errori.AppendLine("Raggruppamento fattura diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                End If
                'Cond pag
                dvPagamentiFox.RowFilter = "CPAGAM = '" & r("CPAGAM").ToString & "' AND ( SPLITPAY IS NULL OR SPLITPAY = '' )"
                condPagAcg = dvPagamentiFox(0)("ACGCOD").ToString
                condPag = OrdiniCntx.MaPaymentTerms.AsNoTracking.First(Function(k) k.Acgcode.Equals(condPagAcg)).Payment
                If Not condPag.Equals(masterOrder.CondPag) Then
                    errori.AppendLine("Pagamento diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                End If
                'Stesso RID
                dvRID.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                If Not masterOrder.UMRCode.Equals(If(dvRID.Count = 1, dvRID(0)("CODINDIVID").ToString, "")) Then
                    errori.AppendLine("Codice UMR diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                End If
                'Codice Iva
                codIva = OrdiniCntx.MaTaxCodes.AsNoTracking.First(Function(k) k.Acgcode.Equals(r("CIVA").ToString)).TaxCode
                If Not masterOrder.CodIva.Equals(codIva) Then
                    errori.AppendLine("Codice IVA diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                End If

#End Region
            End If

#End Region
#Region "Riga Contratto (Fatturativa)"
            Dim servizioMago As String = TranscodificaServizio(r("TIPSERV").ToString)
            Dim descriCanone As String = Left(r("DESCAN").ToString.Trim, 128)
            If descriCanone = "*" Or descriCanone = "-" Or descriCanone = "*/" Then descriCanone = ""
            If Left(descriCanone, 1).Equals("*") Then descriCanone = descriCanone.Substring(1).Trim
            'Valori
            Dim qtaOrdine As Double = TranscodificaQuantita(r("FREQ").ToString)
            'Gli importi sono sempre mensili
            ' Dim imponibile As Double = If(r("CANALLEUR") = 0, If(r("OLDCANONE") = 0, r("CANONE"), r("OLDCANONE")), r("CANALLEUR"))
            Dim imponibileFattura As Double = CDbl(r("CANONE").ToString)
            Dim imponibileContratto As Double = CDbl(r("CANALLEUR").ToString)
            If String.IsNullOrWhiteSpace(r("CANONE_ALL1").ToString) Then r("CANONE_ALL1") = 0
            If CDbl(r("CANONE_ALL1").ToString) <> 0 Then
                imponibileContratto -= CDbl(r("CANONE_ALL1").ToString)
            End If
            Dim valunitFattura As Double = Math.Round(imponibileFattura, 2)
            Dim valunitContratto As Double = Math.Round(imponibileContratto, 2)
            If qtaOrdine = 0 OrElse qtaOrdine = 999 Then
                errori.AppendLine("Indicato Canone ma frequenza uguale a NO su Contratto: " & contratto)
                valunitFattura = 0
                valunitContratto = 0
            End If
            If masterDistinta.GruppoDistinta.Equals(contratto) OrElse String.IsNullOrWhiteSpace(masterDistinta.GruppoDistinta) Then
                iLineDistinta = 0
                iLineDescFatt = 0
                iLineContratto += 1
                Dim rOrdContratto As New AllordCliContratto With {
                    .IdOrdCli = saleOrdId,
                    .Line = iLineContratto,
                    .Servizio = servizioMago,
                    .Descrizione = If(String.IsNullOrWhiteSpace(descriCanone), r("DTS"), descriCanone),
                    .Qta = qtaOrdine,
                    .Um = "",
                    .ValUnit = valunitFattura,
                    .ValUnitIstat = valunitFattura,
                    .DataUltRivIstat = Valid_Data(r("DTVARCAN").ToString),
                    .Franchigia = 0,
                    .Nota = "",
                    .TipoRigaServizio = TranscodificaFrequenza(r("FREQ").ToString),
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .NonRiportaInFatt = "0",
                    .Fatturato = "0",
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 12, 31).ToString,
                    .CodiceIva = codIva,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId,
                    .SubLineDescFatt = 0,
                    .SubLineDistinta = 0,
                    .CdC = centro,
                    .Impianto = "",
                    .Cespite = ""
                    }
                'Aggiungo la riga alla collection
                efAllordCliContratto.Add(rOrdContratto)

#Region "Descrizioni Fattura"
                Dim descriFatt As String = String.Concat(r("DFAT1"), r("DFAT2"), r("DFAT3"), r("DFAT4")).Trim
                If descriFatt = "*" Or descriFatt = "-" Or descriFatt = "*/" Then descriFatt = ""

                If Len(descriFatt) = 0 Then
                    ' Se i campi DFAT1-DFAT2-DFAT3-DFAT4 sono vuoti DESCAN è proprio la descrizione del dettaglio di fattura, viceversa è solo una descrizione.
                    ' Quelli con DESCAN a * o /* o - sono probabilmente frutto delle varie acquisizioni/fusioni per incorporazione.
                    iLineDescFatt = 0
                    'AggiungiDalAl
                    If Len(descriCanone) > 0 Then
                        Dim rOrdDescri As New AllordCliContrattoDescFatt With {
                                 .IdOrdCli = saleOrdId,
                                 .Line = iLineDescFatt + 1,
                                 .RifLinea = iLineContratto,
                                 .Codice = "",
                                 .Descrizione = descriCanone,
                                 .Tbcreated = Now,
                                 .Tbmodified = Now,
                                 .TbcreatedId = sLoginId,
                                 .TbmodifiedId = sLoginId
                                 }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDescFatt.Add(rOrdDescri)
                        'End If
                    End If
                Else
                    Dim descriList As List(Of String) = GetListTextWithNewLines(descriFatt, 128)
                    If descriList.Count > 0 Then
                        'If masterDistinta.RigheDistinta > 0 AndAlso rowToExclude_cnt > 0 Then
                        '    errori.AppendLine("(NO SAVE) DescFatt: presente DFAT* Ordine:" & r("CONTRATTO").ToString)
                        'Else
                        For i = 0 To descriList.Count - 1
                            Dim rOrdDescri As New AllordCliContrattoDescFatt With {
                                 .IdOrdCli = saleOrdId,
                                 .Line = i + 1,
                                 .RifLinea = iLineContratto,
                                 .Codice = "",
                                 .Descrizione = descriList(i),
                                 .Tbcreated = Now,
                                 .Tbmodified = Now,
                                 .TbcreatedId = sLoginId,
                                 .TbmodifiedId = sLoginId
                                 }
                            'Aggiungo la riga alla collection
                            efAllordCliContrattoDescFatt.Add(rOrdDescri)
                        Next
                        'End If
                    End If
                    iLineDescFatt = descriList.Count
                End If
                'Aggiorno Sub
                efAllordCliContratto.Last.SubLineDescFatt = iLineDescFatt
            End If
#End Region

#Region "Distinta"
            'E' obbligatorio avere una riga distinta !!
            iLineDistinta += 1
            Dim rOrdDistinta As New AllordCliContrattoDistinta With {
                .IdOrdCli = saleOrdId,
                .Line = iLineDistinta,
                .RifLinea = iLineContratto,
                .Servizio = servizioMago,
                .Descrizione = If(String.IsNullOrWhiteSpace(descriCanone), r("DTS"), descriCanone),
                .Qta = qtaOrdine,
                .Um = "",
                .ValUnit = valunitContratto,
                .ValUnitIstat = valunitContratto,
                .DataUltRivIstat = Valid_Data(r("DTVARCAN").ToString),
                .TipoRigaServizio = TranscodificaFrequenza(r("FREQ").ToString),
                .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                .DataFineElaborazione = sDataNulla,
                .DataProssimaFatt = New DateTime(2023, 12, 31).ToString,
                .CodIntegra = contratto,
                .Tbcreated = Now,
                .Tbmodified = Now,
                .TbcreatedId = sLoginId,
                .TbmodifiedId = sLoginId,
                .Nota = "",
                .Cespite = "",
                .CdC = centro,
                .Impianto = sito
                 }
            'Aggiungo la riga alla collection
            efAllordCliContrattoDistinta.Add(rOrdDistinta)

#Region "Servizi Aggiuntivi"
            Dim iLineServAgg As Short = 0
            'Costo Servizi Aggiuntivi (loro li chiamano Canone)
            'ISPEZIONI
            If r("CANISP") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = saleOrdId,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Ispezioni,
                    .Descrizione = ServiziAggiuntivi.Ispezioni_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANISP"),
                    .ValUnitIstat = r("CANISP"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAISP"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'INTERVENTI
            If r("CANINT") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = saleOrdId,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Interventi,
                    .Descrizione = ServiziAggiuntivi.Interventi_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANINT"),
                    .ValUnitIstat = r("CANINT"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAINT"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'APERTURA/CHIUSURA
            If r("CANAPECHIU") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = saleOrdId,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.AperturaChiusura,
                    .Descrizione = ServiziAggiuntivi.AperturaChiusura_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANAPECHIU"),
                    .ValUnitIstat = r("CANAPECHIU"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAAPE"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'ASSISTENZA
            If r("CANASSIST") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = saleOrdId,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Assistenza,
                    .Descrizione = ServiziAggiuntivi.Assistenza_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANASSIST"),
                    .ValUnitIstat = r("CANASSIST"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAASS"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'PIANTONI
            If r("CANPIA") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = saleOrdId,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Piantoni,
                    .Descrizione = ServiziAggiuntivi.Piantoni_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANPIA"),
                    .ValUnitIstat = r("CANPIA"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAPIA"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'VIDEO ISP.
            If r("CANVID") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                     .IdOrdCli = saleOrdId,
                     .Line = iLineServAgg,
                     .RifLinea = iLineDistinta,
                     .RifRifLinea = iLineContratto,
                     .Servizio = ServiziAggiuntivi.VideoIsp,
                     .Descrizione = ServiziAggiuntivi.VideoIsp_Descri,
                     .Qta = 1,
                     .Um = "",
                     .ValUnit = r("CANVID"),
                     .ValUnitIstat = r("CANVID"),
                     .DataUltRivIstat = sDataNulla,
                     .Franchigia = r("FRAVID"),
                     .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                     .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                     .DataFineElaborazione = sDataNulla,
                     .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                     .Tbcreated = Now,
                     .Tbmodified = Now,
                     .TbcreatedId = sLoginId,
                     .TbmodifiedId = sLoginId
                     }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'Aggiorno Sub
            efAllordCliContrattoDistinta.Last.SubLineServAgg = iLineServAgg
#End Region
            'Parte di tecnologia Allsystem 1 (CANONE ALL1)
            If masterDistinta.RigheDistinta > 0 AndAlso CDbl(r("CANONE_ALL1").ToString) <> 0 Then
                iLineDistinta += 1
                Dim rOrdDistintaAll1 As New AllordCliContrattoDistinta With {
                    .IdOrdCli = saleOrdId,
                    .Line = iLineDistinta,
                    .RifLinea = iLineContratto,
                    .Servizio = TECNO_ALL1,
                    .Descrizione = tecno_All1Descri,
                    .Qta = qtaOrdine,
                    .Um = "",
                    .ValUnit = Math.Round(If(CDbl(r("CANONE_ALL1").ToString) = 0, 0, CDbl(r("CANONE_ALL1").ToString)), 2),
                    .ValUnitIstat = Math.Round(If(CDbl(r("CANONE_ALL1").ToString) = 0, 0, CDbl(r("CANONE_ALL1").ToString)), 2),
                    .DataUltRivIstat = Valid_Data(r("DTVARCAN").ToString),
                    .TipoRigaServizio = TranscodificaFrequenza(r("FREQ").ToString),
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 12, 31).ToString,
                    .CodIntegra = contratto,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId,
                    .Nota = "",
                    .Cespite = "",
                    .CdC = r("CDC_ALL1").ToString,
                    .Impianto = sito
                 }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistinta.Add(rOrdDistintaAll1)
            End If
            'Aggiorno Sub
            efAllordCliContratto.Last.SubLineDistinta = iLineDistinta
#End Region
#End Region

#Region "Padre/Figlio"
            If Not String.IsNullOrWhiteSpace(r("CONTRSUCC").ToString) Then
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
            End If
            If Not String.IsNullOrWhiteSpace(r("CONTRPREC").ToString) Then
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
            End If
#End Region
#Region "All Ordini Tipologia Servizi"
            If Not efAllordCliTipologiaServizi.Exists(Function(f) f.IdOrdCli.Equals(saleOrdId And f.Tipologia.Equals(r("TIPSERV").ToString))) Then
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
            End If
#End Region
            If masterOrder.Contratto.Equals(contratto) Then
#Region "Testa"
                'Data Consegna il (ExpectedDeliveryDate) = Decorrenza
                'Data Confermata il (ConfirmedDeliveryDate) = non usata
                'Non oltre il (CompulsoryDeliveryDate) = Data scadenza fissa o cessazione ( ma non comanda nulla)
                'todo:PaymentAddress
                Dim rOrd As New MaSaleOrd With {
                     .Priority = 88,
                    .CustSuppType = CustSuppType.Cliente,
                    .InternalOrdNo = masterOrder.OrderNo,
                    .ExternalOrdNo = Today.ToShortDateString,
                    .OrderDate = Valid_Data(r("DTPRODUZ").ToString),
                    .Customer = clienteACG,
                    .Payment = condPag,
                    .CustomerBank = masterOrder.Banca.CustSuppBank,
                    .CompanyBank = masterOrder.Banca.CompanyBank,
                    .SendDocumentsTo = masterOrder.SedeInvioDoc,
                    .PaymentAddress = "",
                    .Area = r("FILIALE").ToString,
                    .Salesperson = agente,
                    .Notes = masterOrder.UMRCode,
                    .AccTpl = defOrdini.SaleOrderAccTpl,
                    .TaxJournal = "VEN",
                    .InvRsn = defOrdini.SaleOrderInvRsn,
                    .ShippingReason = "Vend. cliente",
                    .StubBook = "CLIENTI",
                    .StoragePhase1 = "SEDE",
                    .SpecificatorPhase1 = "",
                    .SaleOrdId = saleOrdId,
                    .Job = "",
                    .CostCenter = centro,
                    .PriceListValidityDate = Valid_Data(r("DTPRODUZ").ToString),
                    .InvoicingCustomer = r("ACGCOD").ToString,
                    .ExpectedDeliveryDate = Valid_Data(r("DTDECORR").ToString),
                    .ConfirmedDeliveryDate = sDataNulla,
                    .CompulsoryDeliveryDate = Valid_Data(r("DTCESSFATT").ToString),
                    .Carrier1 = vettore,
                    .OurReference = r("FILFATT").ToString,
                    .YourReference = "",
                    .CompanyCa = masterOrder.Banca.CompanyCa,
                    .CompanyPymtCa = masterOrder.Banca.CustomerCompanyCa,
                    .Presentation = 1376260,
                    .ShipToAddress = "sede",
                    .BankAuthorization = "",
                    .ContractCode = drFattEle("F2126").ToString.Trim,
                    .ProjectCode = drFattEle("F2127").ToString.Trim,
                    .Tbguid = Guid.NewGuid,
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
                    .TbmodifiedId = sLoginId,
                    .SubIdContratto = iLineContratto
                    }
                ' .SubIdDescrizione = iLineDescFatt
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
                efMaSaleOrd.Add(rOrd)
#End Region
#Region "All OrdiniAcc"
                Dim rOrdAcc As New AllordCliAcc With {
                .IdOrdCli = saleOrdId,
                .ApplicoIstat = If(r("AUMENTO") = 1, "1", "0"),
                .MesiDurata = If(String.IsNullOrWhiteSpace(r("GGDURATA").ToString), 0, CalcolaDurataContratto(r("GGDURATA"))),
                .MesiRinnovo = If(String.IsNullOrWhiteSpace(r("GGDURATA").ToString), 0, CalcolaDurataContratto(r("GGDURATA"))),
                .Ggdisdetta = CShort(r("GGPREAVVIS")),
                .DataScadenzaFissa = sDataNulla,
                .DataRiscatto = sDataNulla,
                .ImportoRiscatto = 0,
                .DataRiduzione = sDataNulla,
                .ImportoRiduzione = 0,
                .PercRiduzione = 0,
                .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                .DataCessazione = Valid_Data(r("DTCESSFATT").ToString),
                .MotivoCessazione = "",
                .TipoContratto = 1108934656,
                .ImpiantoProprietaCliente = "0",
                .ImportoCanone = If(String.IsNullOrWhiteSpace(r("CANORI").ToString), 0, Math.Round(CDbl(r("CANORI")), 2)),
                .ContributoInstallazione = 0,
                .OrdineSospeso = "0",
                .DataSospensione = sDataNulla,
                .MotivoSospensione = "",
                .Agente = agente,
                .ImportoProvvigione = 0,
                .Impianto = "REMOVE",
                .Nota = "",
                .ModelloContratto = 1229717507,
                .CondPag = condPag,
                .SedeInvioDoc = masterOrder.SedeInvioDoc,
                .Vettore = vettore,
                .CdC = centro,
                .ImpiantoDue = "",
                .Tbcreated = Now,
                .Tbmodified = Now,
                .TbcreatedId = sLoginId,
                .TbmodifiedId = sLoginId
                }
                '.ContributoInstallazione = If(String.IsNullOrWhiteSpace(r("CANALLEUR").ToString), 0, Math.Round(r("CANALLEUR"), 2)),
                '
                'incremento Data per portarla a post Data Odierna
                rOrdAcc.DataPrevistaScadenza = CalcolaScadenzaFutura(rOrdAcc)
                'Aggiungo la riga alla collection
                efAllordCliAcc.Add(rOrdAcc)

#End Region
#Region "Fattura Elettronica"
                Dim rOrdFattEle As New AllordCliFattEle With {
                    .IdOrdCli = saleOrdId,
                    .F2_1_1_5_4 = If(r("ZONAESA").ToString.Equals("4%"), "W", String.Empty),
                    .F2_1_1_11 = drFattEle("F211111").ToString,
                    .F2_1_2_1 = 0,
                    .F2_1_2_2 = drFattEle("F2122").ToString,
                    .F2_1_2_3 = Valid_Data(drFattEle("F2123").ToString),
                    .F2_1_2_4 = drFattEle("F2124").ToString,
                    .F2_1_2_5 = drFattEle("F2125").ToString,
                    .F2_1_2_6 = drFattEle("F2126").ToString,
                    .F2_1_2_7 = drFattEle("F2127").ToString,
                    .F2_1_3_1 = 0,
                    .F2_1_3_2 = drFattEle("F2132").ToString,
                    .F2_1_3_3 = Valid_Data(drFattEle("F2133").ToString),
                    .F2_1_3_4 = drFattEle("F2134").ToString,
                    .F2_1_3_5 = "",
                    .F2_1_3_6 = drFattEle("F2136").ToString,
                    .F2_1_3_7 = drFattEle("F2137").ToString,
                    .F2_1_5_1 = 0,
                    .F2_1_5_2 = drFattEle("F2152").ToString,
                    .F2_1_5_3 = Valid_Data(drFattEle("F2153").ToString),
                    .F2_1_5_4 = drFattEle("F2154").ToString,
                    .F2_1_5_5 = "",
                    .F2_1_5_6 = drFattEle("F2156").ToString,
                    .F2_1_5_7 = drFattEle("F2157").ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                }
                efAllordCliFattEle.Add(rOrdFattEle)
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
            End If
            AvanzaBarra()

        Next

#Region "Righe accantonate "
        'Inserimento righe accantonate
        Dim currentCustomer As String = ""
        contrattiDaUnire.OrderBy(Function(f) f("ACGCOD"))
        Dim sediClienteMerged As New List(Of MaCustSuppBranches)
        For Each r In contrattiDaUnire
            'Cerco id
            Dim rifDistinta As AllordCliContrattoDistinta = efAllordCliContrattoDistinta.Find(Function(f) f.CodIntegra.Equals(r("GRP_CONTRATTO").ToString))
            If rifDistinta Is Nothing Then
                Dim mb As New MessageBoxWithDetails("Errore FATALE!" & Environment.NewLine & "Codice GRP_CONTRATTO (" & r("GRP_CONTRATTO").ToString & ") assente in CONTRATTO", GetCurrentMethod.Name, "")
                mb.ShowDialog()
                End
            End If
            Dim rifContratto As AllordCliContratto = efAllordCliContratto.Find(Function(f) f.IdOrdCli = rifDistinta.IdOrdCli AndAlso f.Line.Equals(rifDistinta.RifLinea))
            Dim rifordine As MaSaleOrd = efMaSaleOrd.Find(Function(f) f.SaleOrdId = rifDistinta.IdOrdCli)
            'Sedi
            If Not currentCustomer.Equals(r("ACGCOD").ToString) Then
                sediClienteMerged = New List(Of MaCustSuppBranches)
                'Attenzione le sedi sono quelle del clinte/contratto di riferimento
                sediClienteMerged.AddRange(OrdiniCntx.MaCustSuppBranches.AsNoTracking.Where(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) And f.CustSupp.Equals(rifordine.Customer)).ToList)
                sediClienteMerged.AddRange(efMaCustSuppBranches.Where(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) And f.CustSupp.Equals(rifordine.Customer)).ToList)
                currentCustomer = r("ACGCOD").ToString
            End If
            Dim sito As String = ""
            Dim ragSocSito As String = Left(String.Concat(r("RAGSOC"), " ", r("PRAGSOC")).Trim, 128)
            Dim newBranches As Boolean = False
            If sediClienteMerged.Any Then
                'Controllo esistenza con RAGSOC + (replace CrLf  ) + PRAGSOC e INDIRIZZO
                Dim sediRidotte As List(Of MaCustSuppBranches) = sediClienteMerged.FindAll(Function(f) f.CompanyName.Replace(Environment.NewLine, " ").Equals(ragSocSito) And f.Address.Equals(r("INDIRIZZO").ToString)).ToList
                If sediRidotte.Count = 0 Then
                    newBranches = True
                    sito = "I" & (sediClienteMerged.Count + 1).ToString("0000")
                ElseIf sediRidotte.Count = 1 Then
                    sito = sediRidotte.First.Branch
                ElseIf sediRidotte.Count > 1 Then
                    'Se ho piu' righe segnalo
                    Dim msgLog As String = "(NO SAVE) Più sedi simili, impossibile determinare corretta. Ordine:" & r("CONTRATTO").ToString
                    errori.AppendLine(msgLog)
                    Debug.Print(msgLog)
                End If
            Else
                newBranches = True
            End If

            If newBranches Then
                If String.IsNullOrWhiteSpace(sito) Then sito = "I0001"

                Dim rCliBr As New MaCustSuppBranches With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = rifordine.Customer,
                                    .Branch = sito,
                                    .CompanyName = ragSocSito,
                                    .Address = r("INDIRIZZO").ToString,
                                    .City = r("COMUNE").ToString,
                                    .County = r("PROV").ToString,
                                    .Region = Get_Regione(r("PROV").ToString),
                                    .Zipcode = r("CAP").ToString,
                                    .IsocountryCode = "IT",
                                    .MailSendingType = 12451840,
                                    .Tbcreated = Now,
                                    .Tbmodified = Now,
                                    .TbcreatedId = sLoginId,
                                    .TbmodifiedId = sLoginId,
                                    .Ipacode = "",
                                    .AdministrationReference = ""
                                    }
                'Aggiungo la riga alla collection
                efMaCustSuppBranches.Add(rCliBr)
                sediClienteMerged.Add(rCliBr)
            End If

            Dim servizioMago As String = TranscodificaServizio(r("TIPSERV").ToString)
            Dim descriCanone As String = Left(r("DESCAN").ToString.Trim, 128)
            If descriCanone = "*" Or descriCanone = "-" Or descriCanone = "*/" Then descriCanone = ""
            If Left(descriCanone, 1).Equals("*") Then descriCanone = descriCanone.Substring(1).Trim
            'Valori
            Dim qtaOrdine As Double = rifDistinta.Qta
            Dim imponibileFattura As Double = CDbl(r("CANONE").ToString)
            Dim imponibileContratto As Double = CDbl(r("CANALLEUR").ToString)
            If String.IsNullOrWhiteSpace(r("CANONE_ALL1").ToString) Then r("CANONE_ALL1") = 0
            If CDbl(r("CANONE_ALL1").ToString) <> 0 Then
                imponibileContratto -= CDbl(r("CANONE_ALL1").ToString)
            End If
            Dim valunitFattura As Double = Math.Round(imponibileFattura, 2)
            Dim valunitContratto As Double = Math.Round(imponibileContratto, 2)
            If qtaOrdine = 0 OrElse qtaOrdine = 999 Then
                errori.AppendLine("Indicato Canone ma frequenza uguale a NO su Contratto: " & r("CONTRATTO").ToString)
                valunitFattura = 0
                valunitContratto = 0
            End If
            iLineDistinta = rifContratto.SubLineDistinta
            iLineContratto = rifContratto.Line
            iLineDistinta += 1
            Dim rOrdDistinta As New AllordCliContrattoDistinta With {
                .IdOrdCli = rifDistinta.IdOrdCli,
                .Line = iLineDistinta,
                .RifLinea = iLineContratto,
                .Servizio = servizioMago,
                .Descrizione = If(String.IsNullOrWhiteSpace(descriCanone), r("DTS"), descriCanone),
                .Qta = qtaOrdine,
                .Um = "",
                .ValUnit = valunitContratto,
                .ValUnitIstat = valunitContratto,
                .DataUltRivIstat = Valid_Data(r("DTVARCAN").ToString),
                .TipoRigaServizio = rifDistinta.TipoRigaServizio,
                .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                .DataFineElaborazione = sDataNulla,
                .DataProssimaFatt = New DateTime(2023, 12, 31).ToString,
                .CodIntegra = r("CONTRATTO").ToString,
                .Tbcreated = Now,
                .Tbmodified = Now,
                .TbcreatedId = sLoginId,
                .TbmodifiedId = sLoginId,
                .Nota = "",
                .Cespite = "",
                .CdC = dvTabelle.CercaValoreSuTabelleFox("CC", r("CCOSTO").ToString),
                .Impianto = sito,
                .SubLineServAgg = 0
                 }
            'Aggiungo la riga alla collection
            efAllordCliContrattoDistinta.Add(rOrdDistinta)

#Region "Servizi Aggiuntivi"
            Dim iLineServAgg As Short = 0
            'Costo Servizi Aggiuntivi (loro li chiamano Canone)
            'ISPEZIONI
            If r("CANISP") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = rifDistinta.IdOrdCli,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Ispezioni,
                    .Descrizione = ServiziAggiuntivi.Ispezioni_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANISP"),
                    .ValUnitIstat = r("CANISP"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAISP"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'INTERVENTI
            If r("CANINT") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = rifDistinta.IdOrdCli,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Interventi,
                    .Descrizione = ServiziAggiuntivi.Interventi_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANINT"),
                    .ValUnitIstat = r("CANINT"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAINT"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'APERTURA/CHIUSURA
            If r("CANAPECHIU") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = rifDistinta.IdOrdCli,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.AperturaChiusura,
                    .Descrizione = ServiziAggiuntivi.AperturaChiusura_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANAPECHIU"),
                    .ValUnitIstat = r("CANAPECHIU"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAAPE"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'ASSISTENZA
            If r("CANASSIST") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = rifDistinta.IdOrdCli,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Assistenza,
                    .Descrizione = ServiziAggiuntivi.Assistenza_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANASSIST"),
                    .ValUnitIstat = r("CANASSIST"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAASS"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'PIANTONI
            If r("CANPIA") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                    .IdOrdCli = rifDistinta.IdOrdCli,
                    .Line = iLineServAgg,
                    .RifLinea = iLineDistinta,
                    .RifRifLinea = iLineContratto,
                    .Servizio = ServiziAggiuntivi.Piantoni,
                    .Descrizione = ServiziAggiuntivi.Piantoni_Descri,
                    .Qta = 1,
                    .Um = "",
                    .ValUnit = r("CANPIA"),
                    .ValUnitIstat = r("CANPIA"),
                    .DataUltRivIstat = sDataNulla,
                    .Franchigia = r("FRAPIA"),
                    .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId
                    }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'VIDEO ISP.
            If r("CANVID") > 0 Then
                iLineServAgg += 1
                Dim rOrdContrattoAgg As New AllordCliContrattoDistintaServAgg With {
                     .IdOrdCli = rifDistinta.IdOrdCli,
                     .Line = iLineServAgg,
                     .RifLinea = iLineDistinta,
                     .RifRifLinea = iLineContratto,
                     .Servizio = ServiziAggiuntivi.VideoIsp,
                     .Descrizione = ServiziAggiuntivi.VideoIsp_Descri,
                     .Qta = 1,
                     .Um = "",
                     .ValUnit = r("CANVID"),
                     .ValUnitIstat = r("CANVID"),
                     .DataUltRivIstat = sDataNulla,
                     .Franchigia = r("FRAVID"),
                     .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                     .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                     .DataFineElaborazione = sDataNulla,
                     .DataProssimaFatt = New DateTime(2023, 1, 1).ToString,
                     .Tbcreated = Now,
                     .Tbmodified = Now,
                     .TbcreatedId = sLoginId,
                     .TbmodifiedId = sLoginId
                     }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
            End If
            'Aggiorno Sub
            efAllordCliContrattoDistinta.Last.SubLineServAgg = iLineServAgg
#End Region
            'Parte di tecnologia Allsystem 1 (CANONE ALL1)
            If CDbl(r("CANONE_ALL1").ToString) <> 0 Then
                iLineDistinta += 1
                Dim rOrdDistintaAll1 As New AllordCliContrattoDistinta With {
                    .IdOrdCli = rifDistinta.IdOrdCli,
                    .Line = iLineDistinta,
                    .RifLinea = iLineContratto,
                    .Servizio = TECNO_ALL1,
                    .Descrizione = tecno_All1Descri,
                    .Qta = qtaOrdine,
                    .Um = "",
                    .ValUnit = Math.Round(If(CDbl(r("CANONE_ALL1").ToString) = 0, 0, CDbl(r("CANONE_ALL1").ToString)), 2),
                    .ValUnitIstat = Math.Round(If(CDbl(r("CANONE_ALL1").ToString) = 0, 0, CDbl(r("CANONE_ALL1").ToString)), 2),
                    .DataUltRivIstat = Valid_Data(r("DTVARCAN").ToString),
                    .TipoRigaServizio = rifDistinta.TipoRigaServizio,
                    .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                    .DataFineElaborazione = sDataNulla,
                    .DataProssimaFatt = New DateTime(2023, 12, 31).ToString,
                    .CodIntegra = r("CONTRATTO").ToString,
                    .Tbcreated = Now,
                    .Tbmodified = Now,
                    .TbcreatedId = sLoginId,
                    .TbmodifiedId = sLoginId,
                    .Nota = "",
                    .Cespite = "",
                    .CdC = r("CDC_ALL1").ToString,
                    .Impianto = sito,
                    .SubLineServAgg = 0
                 }
                'Aggiungo la riga alla collection
                efAllordCliContrattoDistinta.Add(rOrdDistintaAll1)
            End If
            'Aggiorno Sub
            rifContratto.SubLineDistinta = iLineDistinta

            'Tipologie Servizio
            If Not efAllordCliTipologiaServizi.Exists(Function(f) f.IdOrdCli.Equals(rifDistinta.IdOrdCli And f.Tipologia.Equals(r("TIPSERV").ToString))) Then
                Dim rOrdTipologiaServizi As New AllordCliTipologiaServizi With {
                         .IdOrdCli = rifDistinta.IdOrdCli,
                         .Tipologia = r("TIPSERV").ToString,
                         .Tbcreated = Now,
                         .Tbmodified = Now,
                         .TbcreatedId = sLoginId,
                         .TbmodifiedId = sLoginId
                         }
                'Aggiungo la riga alla collection
                efAllordCliTipologiaServizi.Add(rOrdTipologiaServizi)
            End If

            'Padre Figlio
            If Not String.IsNullOrWhiteSpace(r("CONTRSUCC").ToString) Then
                If Not efAllordFiglio.Exists(Function(f) f.IdOrdCli.Equals(rifDistinta.IdOrdCli And f.NrOrdFiglio.Equals(r("CONTRSUCC").ToString))) Then
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
                End If
            End If
            If Not String.IsNullOrWhiteSpace(r("CONTRPREC").ToString) Then
                If Not efAllordPadre.Exists(Function(f) f.IdOrdCli.Equals(rifDistinta.IdOrdCli And f.NrOrdPadre.Equals(r("CONTRPREC").ToString))) Then
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
                End If
            End If
        Next
#End Region
#Region "Ordini Padre/Figlio"
        Dim idSub As Integer = 0
        For Each p In efAllordPadre
            idSub -= 1
            p.IdOrdPadre = idSub
        Next
        idSub = 0
        For Each f In efAllordFiglio
            idSub -= 1
            f.IdOrdFiglio = idSub
        Next
#End Region
#Region "Adeguo Contatori sub"
        For Each o In efMaSaleOrd
            Dim rifContratto As List(Of AllordCliContratto) = efAllordCliContratto.FindAll(Function(f) f.IdOrdCli = o.SaleOrdId)
            o.SubIdContratto = rifContratto.Count
        Next
#End Region
        DisposeTables()

        'Scrivo i LOG
        If errori.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Errori ---" & Environment.NewLine & errori.ToString)
            FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
        End If
        If avvisi.Length > 0 Then
            My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Avvisi ---" & Environment.NewLine & avvisi.ToString)
            FLogin.lstStatoConnessione.Items.Add("Presenti avvisi : Controllare file di Log")
        End If

    End Sub

    Private Function CalcolaScadenzaFutura(rOrdAcc As AllordCliAcc) As Date
        Dim d As Date = rOrdAcc.DataDecorrenza.Value
        While d < Today
            d = d.AddMonths(rOrdAcc.MesiDurata)
        End While
        Return d
    End Function

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
                    EditTestoBarra("Salvataggio: Inserimento dati Fattura Elettronica")
                    If efAllordCliFattEle.Any Then
                        Dim t = efAllordCliFattEle.Count
                        Dim cfgOrdFattEle As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliFattEle, cfgOrdFattEle, Function(d) d)
                        Debug.Print("ALLOrdCliFattEle Ins:" & cfgOrdFattEle.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdFattEle.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("ALLOrdCliFattEle Ins:" & cfgOrdFattEle.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdFattEle.StatsInfo.StatsNumberUpdated.ToString)
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
                    EditTestoBarra("Salvataggio: Inserimento righe descrizioni contratto ")
                    If efAllordCliContrattoDescFatt.Any Then
                        Dim t = efAllordCliContrattoDescFatt.Count
                        Dim cfgOrdConDescFatt As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliContrattoDescFatt, cfgOrdConDescFatt, Function(d) d)
                        Debug.Print("AllordCliContratto_DescFatt Ins:" & cfgOrdConDescFatt.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDescFatt.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("AllordCliContratto_DescFatt Ins:" & cfgOrdConDescFatt.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDescFatt.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento righe distinta contratto ")
                    If efAllordCliContrattoDistinta.Any Then
                        Dim t = efAllordCliContrattoDistinta.Count
                        Dim cfgOrdConDist As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliContrattoDistinta, cfgOrdConDist, Function(d) d)
                        Debug.Print("ALLOrdCliContratto_Distinta Ins:" & cfgOrdConDist.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDist.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("ALLOrdCliContratto_Distinta Ins:" & cfgOrdConDist.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConDist.StatsInfo.StatsNumberUpdated.ToString)
                    End If
                    iStep += 1
                    EditTestoBarra("Salvataggio: Inserimento righe servizi aggiuntivi contratto ")
                    If efAllordCliContrattoDistintaServAgg.Any Then
                        Dim t = efAllordCliContrattoDistintaServAgg.Count
                        Dim cfgOrdConServAgg As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliContrattoDistintaServAgg, cfgOrdConServAgg, Function(d) d)
                        Debug.Print("ALLOrdCliContratto_ServAgg Ins:" & cfgOrdConServAgg.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConServAgg.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("ALLOrdCliContratto_ServAgg Ins:" & cfgOrdConServAgg.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConServAgg.StatsInfo.StatsNumberUpdated.ToString)
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
                        OrdiniCntx.BulkInsertOrUpdate(efMaCustSuppBranches, cfgOrdTot, Function(d) d)
                        Debug.Print("MaCustSuppBranches Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("MaCustSuppBranches Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
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

            'Scrivo i LOG
            If bulkMessage.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Inserimento Dati ---" & Environment.NewLine & bulkMessage.ToString)
            If errori.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Errori ---" & Environment.NewLine & errori.ToString)
                FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori durante il salvataggio: Controllare file di Log")
            End If
            'If IsDebugging AndAlso debugging.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Debugging ---" & Environment.NewLine & debugging.ToString)

        End If

        'Return Not someTrouble
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
                    'iStep += 1
                    'EditTestoBarra("Salvataggio: Inserimento Sedi Clienti")
                    'If efMaCustSuppBranches.Any Then
                    '    Dim t = efMaCustSuppBranches.Count
                    '    Dim cfgOrdTot As New BulkConfig With {
                    '                .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                    '                .BulkCopyTimeout = 0,
                    '                .CalculateStats = True,
                    '                .BatchSize = If(t < 5000, 0, t / 10),
                    '                .NotifyAfter = t / 10
                    '                }
                    '    OrdiniCntx.BulkInsert(efMaCustSuppBranches, cfgOrdTot, Function(d) d)
                    '    Debug.Print("MaCustSuppBranches Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                    '    bulkMessage.AppendLine("MaCustSuppBranches Ins:" & cfgOrdTot.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdTot.StatsInfo.StatsNumberUpdated.ToString)
                    'End If
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
    Private Function TrovaAgente(ByVal codice As String, filiale As String) As String
        Dim esito As String
        Select Case filiale.ToUpper
            Case "08" 'Biella / Vigliano
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UFFICIO"    'UFFICIO
                    Case "018"
                        esito = "BURATTI"    'BURATTI PAOLO
                    Case "019"
                        esito = "AULETTA"    'AULETTA ANDREA
                    Case "020"
                        esito = "CARDAMON"    'CARDAMONE UPPOLITO
                    Case "021"
                        esito = "GIULIANI"    'GIULIANI
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
                    Case "N01"
                        esito = "BERTUCCI"
                    Case "N02"
                        esito = "AUDISIO"
                    Case "N03"
                        esito = "NICOTRA"
                    Case "N04"
                        esito = "GIANNI"
                    Case "N05"
                        esito = "GILETTI"
                    Case "N06"
                        esito = "GUERRIERO"
                    Case "N07"
                        esito = "GIORDANO"
                    Case "N08"
                        esito = "PAGANOTT"
                    Case "N09"
                        esito = "ARCHE"
                    Case "N10"
                        esito = "VSYSTEM"
                    Case "N11"
                        esito = "MORARDO"
                    Case Else
                        esito = "08BI_XXX"
                End Select
            Case "01" ' Torino
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "01TO_XXX"
                End Select
            Case "02" ' Milano
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "02MI_XXX"
                End Select
            Case "03" 'Asti
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "03AT_XXX"
                End Select
            Case "04" 'Aosta
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "04AO_XXX"
                End Select
            Case "05" ' Novara
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "05NO_XXX"
                End Select
            Case "08" 'Biella / Vigliano
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UFFICIO"    'UFFICIO
                    Case "018"
                        esito = "BURATTI"    'BURATTI PAOLO
                    Case "019"
                        esito = "AULETTA"    'AULETTA ANDREA
                    Case "020"
                        esito = "CARDAMON"    'CARDAMONE UPPOLITO
                    Case "021"
                        esito = "GIULIANI"    'GIULIANI
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
                    Case "N01"
                        esito = "BERTUCCI"
                    Case "N02"
                        esito = "AUDISIO"
                    Case "N03"
                        esito = "NICOTRA"
                    Case "N04"
                        esito = "GIANNI"
                    Case "N05"
                        esito = "GILETTI"
                    Case "N06"
                        esito = "GUERRIERO"
                    Case "N07"
                        esito = "GIORDANO"
                    Case "N08"
                        esito = "PAGANOTT"
                    Case "N09"
                        esito = "ARCHE"
                    Case "N10"
                        esito = "VSYSTEM"
                    Case "N11"
                        esito = "MORARDO"
                    Case Else
                        esito = "08BI_XXX"
                End Select
            Case "09" ' Varese
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "09VA_XXX"
                End Select
            Case "10" ' Sede
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "10_XXX"
                End Select
            Case "11" ' Cuneo
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "11CN_XXX"
                End Select
            Case "12" ' Alessandria
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "11AL_XXX"
                End Select
            Case Else
                esito = "XYZ"
        End Select

        Return esito
    End Function
    Private Function TranscodificaQuantita(ByVal codice As String) As Double
        Dim esito As Integer
        Select Case codice.ToUpper
            Case "0A", "0P"
                esito = 12      'ANNUALE
            Case "1A", "1P"
                esito = 1       'MENSILE
            Case "2A", "2P"
                esito = 2       'BIMESTRALE
            Case "3A", "3P"
                esito = 3       'TRIMESTRALE
            Case "4A", "4P"
                esito = 4       'QUADRIMESTRALE
            Case "6A", "6P"
                esito = 6       'SEMESTRALE
            Case "NO"
                esito = 0       'SOLO CANONI SUPPLEMENTARI
            Case Else
                esito = "999"
        End Select
        Return esito
    End Function
    Private Function TranscodificaFrequenza(ByVal codice As String) As String
        Dim esito As String
        Select Case codice.ToUpper
            Case "0A"
                esito = "12A"                'ANNUALE
            Case "0P"
                esito = "12P"
            Case Else
                esito = codice
        End Select
        Return esito
    End Function
    Private Function TranscodificaServizio(ByVal codice As String) As String
        Dim esito As String
        Select Case codice.ToUpper
            Case "AC"
                esito = "APECHIU"
            Case "CC"
                esito = "TENUTA CHIAVI"
            Case "CO"
                esito = "COLL ALLARME"
            Case "CT"
                esito = "COLL COMBINAT"
            Case "P1"
                esito = "PRONTO IN.TERZI"
            Case "PI"
                esito = "PRONTO INTERVEN"
            Case "PR"
                esito = "COLL RADIO"
            Case "RB"
                esito = "ISPEZIONI"
            Case "RO"
                esito = "BOLLATURA"
            Case "TD"
                esito = "TELEFONIA DEDIC"
            Case "TS"
                esito = "TELESOCCORSO"
            Case "VV"
                esito = "VIDEOISPEZIONI"
            Case Else
                esito = "XXXXX"
        End Select
        Return esito
    End Function
    Private Function CalcolaDurataContratto(value As Short) As Short
        Dim i As Short
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
                i = CShort(Math.Round(value / 30, 0))
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
    Private Function IsPrivato(partitaiva As String, codicefiscale As String) As Boolean
        If Len(partitaiva) > 0 Then Return False
        If String.IsNullOrWhiteSpace(codicefiscale) Then Return False
        If Char.IsLetter(codicefiscale.ToCharArray.First) Then Return True
        Return False
    End Function
    Private Class Carattere_Speciale
        Public Carattere As String
        Public Asc As Integer
        Public Occorrenze As Integer
    End Class

    Private Class OrdineMaster
        Public Contratto As String
        Public ClienteFox As String
        Public ClienteMago As String
        Public RaggruppamentoFattura As String
        Public RigheContratto As Integer
        Public CondPag As String
        Public CodIva As String
        Public UMRCode As String
        Public CdC As String
        Public OrderNo As String
        Public Vettore As String
        Public Agente As String
        Public Banca As BancaCliente
        Public CodiceSdi As String
        Public Pec As String
        Public SedeInvioDoc As String
        Public RiferimentoAmministrazione As String
        Public Sub New()
            ClienteMago = ""
            Banca = New BancaCliente
            CodiceSdi = ""
            Pec = ""
            SedeInvioDoc = ""
            RiferimentoAmministrazione = ""
        End Sub
    End Class
    Private Class BancaCliente
        Public CustSuppBank As String
        Public CompanyBank As String
        Public CompanyCa As String
        Public CustomerCompanyCa As String

    End Class
    Private Class DistintaMaster
        Public ClienteFox As String
        Public ClienteMago As String
        Public GruppoDistinta As String
        Public RigheDistinta As Integer
    End Class
    Friend Class ServiziAggiuntivi
        Public Shared Ispezioni As String = "ISPEZIONI"
        Public Shared Ispezioni_Descri As String = "Ispezioni"
        Public Shared Interventi As String = "INTERVENTI"
        Public Shared Interventi_Descri As String = "Interventi"
        Public Shared AperturaChiusura As String = "APECHIU"
        Public Shared AperturaChiusura_Descri As String = "Apertura Chiusura"
        Public Shared Assistenza As String = "ASSISTENZA"
        Public Shared Assistenza_Descri As String = "Assistenza"
        Public Shared Piantoni As String = "PIANTONI"
        Public Shared Piantoni_Descri As String = "Piantoni"
        Public Shared VideoIsp As String = "VIDEOISPEZIONI"
        Public Shared VideoIsp_Descri As String = "Video Ispezioni"
        Public Shared Frequenza As String = "SUPPLEMENTAR"
    End Class
End Module

