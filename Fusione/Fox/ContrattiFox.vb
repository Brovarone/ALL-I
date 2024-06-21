Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Reflection.MethodBase
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
Imports ALLSystemTools.SqlTools


Module ContrattiFox
    Private ReadOnly lOk3 As String() = {"H00008", "H80157", "H00010", "H00012", "H00050", "H00074", "H00088", "H00126", "H00140", "H00172", "H00242", "H00616", "H00626", "H00650", "H01588"}
    Private ReadOnly lOK As String() = {"I00198"}
    Private ReadOnly uselOk As Boolean = False ' se true allora filtra solo lOk
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
    Private ReadOnly charSpeciali As New List(Of Carattere_Speciale)
    Dim dtElencoClientiSpa As DataTable
    Dim dvElencoClientiSpa As DataView

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
    Private efAllordCliAttivita As New List(Of AllordCliAttivita)
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

    Private nrDistinte As Integer
    Private nrDistinteUNO As Integer
    ''' <summary>
    ''' Importo ContrattiFox su Mago tramite LINQ e OrdiniCntx
    ''' </summary>
    ''' <returns></returns>
    Public Function ImportaContrattiFox(dsFox As List(Of DataSet)) As Boolean
        GeneraDataset(dsFox)
        GeneraRelazionieDatatable()
        CheckColonneExcel()
        ConnettiContesto()

        'TODO ( elimnare) POTREI GESTIRE UNA RELAZIONE TRA ELENCO CLIENTI E ORDINI
        'ds.Relations.Add("CodCliente", ds.Tables("ELENCO CLIENTI SPA").Columns("CliFor"), ds.Tables("_ONTRORD").Columns("ACGCOD"), False)
        Dim avvisiList As List(Of List(Of String)) = AssociaClienti()
        If avvisiList.Count > 0 Then
            For i = 0 To avvisiList.Count - 1
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Avvisi  ---" & Environment.NewLine)
                Dim l As List(Of String) = avvisiList(i)
                For n = 0 To l.Count - 1
                    My.Application.Log.DefaultFileLogWriter.WriteLine(l(n))
                    FLogin.lstStatoConnessione.Items.Add(l(n))
                Next
            Next
            FLogin.lstStatoConnessione.Items.Add("Riscontrati Clienti non Associati. Controllare log.")
        End If

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
        efMaSaleOrd = New List(Of MaSaleOrd)
        ' efMaSaleOrdDetails = New List(Of MaSaleOrdDetails)
        efMaSaleOrdSummary = New List(Of MaSaleOrdSummary)
        efMaSaleOrdShipping = New List(Of MaSaleOrdShipping)
        efMaSaleOrdNotes = New List(Of MaSaleOrdNotes)
        efAllordCliAcc = New List(Of AllordCliAcc)
        efAllordCliFattEle = New List(Of AllordCliFattEle)
        efAllordCliContratto = New List(Of AllordCliContratto)
        efAllordCliAttivita = New List(Of AllordCliAttivita)
        efAllordCliContrattoDescFatt = New List(Of AllordCliContrattoDescFatt)
        efAllordCliContrattoDistinta = New List(Of AllordCliContrattoDistinta)
        efAllordCliContrattoDistintaServAgg = New List(Of AllordCliContrattoDistintaServAgg)
        efAllordCliDescrizioni = New List(Of AllordCliDescrizioni)
        efAllordCliTipologiaServizi = New List(Of AllordCliTipologiaServizi)
        efAllordPadre = New List(Of AllordPadre)
        efAllordFiglio = New List(Of AllordFiglio)
        efMaCustSupp = New List(Of MaCustSupp)
        efMaCustSuppBranches = New List(Of MaCustSuppBranches)
        efMaCustSuppCustomerOptions = New List(Of MaCustSuppCustomerOptions)
        efMaCustSuppNaturalPerson = New List(Of MaCustSuppNaturalPerson)
        efMaDeclarationOfIntent = New List(Of MaDeclarationOfIntent)
        efMaSddmandate = New List(Of MaSddmandate)
        efMaIdnumbers = New List(Of MaIdnumbers)
        efMaNonFiscalNumbers = New List(Of MaNonFiscalNumbers)
    End Sub
    ''' <summary>
    ''' Crea solo le relazioni 1-n
    ''' </summary>
    Private Sub GeneraRelazionieDatatable()
        EditTestoBarra("Genera relazioni")
        Dim istep As Integer
        Try
            Dim sa As List(Of String)
            Dim t1 As DataTable
            Dim v2 As DataView
            'Try
            istep = 1
            '    ds.Relations.Add("Ordini Clienti", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_ONTRORD").Columns("CLIENTE"))
            'Catch ex As System.ArgumentException
            sa = FindRelationTrouble(ds.Tables("_ONTRORD"), ds.Tables("_LIENORD"), "ACGCOD", "", 0)
            'ds.Relations.Remove("Ordini Clienti")
            t1 = ds.Tables("_LIENORD")
            v2 = ds.Tables("_LIENORD.2023").AsDataView
            For Each c In sa
                v2.RowFilter = "ACGCOD='" & c & "'"
                If v2.Count = 1 Then
                    t1.ImportRow(v2(0).Row)
                Else
                    Debug.Print("no")
                End If
            Next
            ds.Relations.Add("Ordini Clienti", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_ONTRORD").Columns("CLIENTE"))
            'End Try
            istep = 2
            ds.Relations.Add("Ordini Clienti Gruppo Testa", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("CLIENTE"))
            istep = 3
            ds.Relations.Add("Ordini Clienti Gruppo Dettaglio", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("CLIENTE"))
            'Viste le modifiche non creo la Constraints
            'Try
            istep = 4
            '    ds.Relations.Add("Raggruppamento_Ordine", ds.Tables("_ONTRORD").Columns("CONTRATTO"), ds.Tables("_AGRFATD").Columns("CONTRATTO"))
            'Catch ex As System.ArgumentException
            sa = FindRelationTrouble(ds.Tables("_ONTRORD"), ds.Tables("_AGRFATD"), "CONTRATTO", "", 3)
            'ds.Relations.Remove("Raggruppamento_Ordine")
            t1 = ds.Tables("_AGRFATD")
            v2 = ds.Tables("_AGRFATD.2023").AsDataView
            For Each c In sa
                v2.RowFilter = "CONTRATTO='" & c & "'"
                For i = 0 To v2.Count - 1
                    t1.ImportRow(v2(i).Row)
                Next
            Next
            ds.Relations.Add("Raggruppamento_Ordine", ds.Tables("_ONTRORD").Columns("CONTRATTO"), ds.Tables("_AGRFATD").Columns("CONTRATTO"), False)
            'End Try
            'Try
            istep = 5
            '    ds.Relations.Add("Ordini Raggruppati", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_AGRFATD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("RAGRFATT")}, False)
            'Catch ex As System.ArgumentException
            sa = FindRelationTrouble(ds.Tables("_AGRFATD"), ds.Tables("_AGRFATT"), "RAGRFATT", "ACGCOD", 5, 30)
            'ds.Relations.Remove("Ordini Raggruppati")
            t1 = ds.Tables("_AGRFATT")
            v2 = ds.Tables("_AGRFATT.2023").AsDataView
            For Each c In sa
                Dim arr() As String = c.Split("|")
                v2.RowFilter = $"RAGRFATT = '{arr(0)}' AND ACGCOD = '{arr(1)}' "
                For i = 0 To v2.Count - 1
                    t1.ImportRow(v2(i).Row)
                Next
            Next
            ds.Relations.Add("Ordini Raggruppati", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_AGRFATD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("RAGRFATT")}, False)

            'End Try
            'Try
            istep = 6
            '    ds.Relations.Add("RID", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_RID").Columns("CLIENTE"))
            'Catch ex As System.ArgumentException
            sa = FindRelationTrouble(ds.Tables("_LIENORD"), ds.Tables("_RID"), "CLIENTE", "", 17)
            ' ds.Relations.Remove("RID")
            t1 = ds.Tables("_RID")
            v2 = ds.Tables("_RID.2023").AsDataView
            For Each c In sa
                v2.RowFilter = "ACGCOD='" & c & "'"
                For i = 0 To v2.Count - 1
                    t1.ImportRow(v2(i).Row)
                Next
            Next
            ds.Relations.Add("RID", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_RID").Columns("CLIENTE"))
            'End Try
            If ds.Tables("_SENTIIV").Rows.Count > 0 Then ds.Relations.Add("ESENTI", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_SENTIIV").Columns("CLIENTE"), False)
            'ds.Relations.Add("FattEle", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_LIFTELE").Columns("CLIENTE"), ds.Tables("_LIFTELE").Columns("RAGRFATT")})
            'ds.Relations.Add("Pagamenti", ds.Tables("_ONTRORD").Columns("CPAGAM"), ds.Tables("ACGTRPG").Columns("CPAGAM"))
        Catch ex As System.ArgumentException
            Debug.Print(istep.ToString & " " & ex.Message)

        End Try
        dtContratti = ds.Tables("_ONTRORD")
        dtFattEle = ds.Tables("_LIFTELE")
        dtRaggTeste = ds.Tables("_AGRFATT")
        dtRaggDett = ds.Tables("_AGRFATD")
        dtTabelle = ds.Tables("_EWTAB")
        dvTabelle = New DataView(dtTabelle)
        dtPagamentiFox = ds.Tables("ACGTRPG")
        dvPagamentiFox = New DataView(dtPagamentiFox)
        dtElencoClientiSpa = ds.Tables("ELENCO CLIENTI SPA")
        dvElencoClientiSpa = New DataView(dtElencoClientiSpa, "", "CliFor", DataViewRowState.CurrentRows)
    End Sub
    Private Function FindRelationTrouble(t1 As DataTable, t2 As DataTable, key As String, Optional key1 As String = "", Optional col As Integer = 0, Optional col1 As Integer = 0) As List(Of String)
        Dim log As New List(Of String)
        ' Dim w1 As DataView = t1.DefaultView
        'Dim w2 As DataView = t2.DefaultView
        If key1 = "" Then
            Dim assenti = From p In t1.AsEnumerable()
                          Group Join t In t2.AsEnumerable()
                       On p(key) Equals t(key) Into Group
                          From t In Group.DefaultIfEmpty()
                          Where t Is Nothing
                          Select New With {.First = p(key).ToString}
            Dim a = assenti.ToList
            For Each r In a
                If Not log.Contains(r.First.ToString) Then
                    log.Add(r.First.ToString)
                End If
            Next
        Else
            Dim assenti = From p In t1.AsEnumerable()
                          Group Join t In t2.AsEnumerable()
                       On p(key) Equals t(key) And p(key1) Equals t(key1) Into Group
                          From t In Group.DefaultIfEmpty()
                          Where t Is Nothing
                          Select New With {.First = p(key), .Second = p(key1)}
            Dim a = assenti.ToList
            For Each r In a
                If Not log.Contains(r.First.ToString & "|" & r.Second.ToString) Then
                    log.Add(r.First.ToString & "|" & r.Second.ToString)
                End If
            Next
        End If

        Return log
    End Function

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
        'SUBConnetti(TxtTmpDB_SPA.Text)
        Dim cs As String = GetConnectionStringUNO(True)
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
            'Dim w = OrdiniCntx.MaCustSupp.AsNoTracking.Where(Function(k) k.CustSuppType.Equals(CustSuppType.Cliente) AndAlso k.CustSupp.Equals(codice)).First
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
        ' q = q.Where(Function(oDate) oDate.OrderDate.Value.Date >= fromOrdDate AndAlso oDate.OrderDate.Value.Date <= toOrdDate)
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
        If Not dtContratti.Columns.Contains("scadenza") Then
            MessageBox.Show("Impossibile continuare colonne assenti scadenza su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If
        If Not dtContratti.Columns.Contains("data inizio sospensione") Then
            MessageBox.Show("Impossibile continuare colonne assenti data inizio sospensione su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            dtContratti.Columns("data inizio sospensione").ColumnName = "DATA_INIZIO_SOSP"
        End If
        If Not dtContratti.Columns.Contains("data fine sospensione") Then
            MessageBox.Show("Impossibile continuare colonne assenti data fine sospensione su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            dtContratti.Columns("data fine sospensione").ColumnName = "DATA_FINE_SOSP"
        End If
        If Not dtContratti.Columns.Contains("motivo sospensione") Then
            MessageBox.Show("Impossibile continuare colonne assenti motivo sospensione su _ONTRORD", "Check Ordini", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Else
            dtContratti.Columns("motivo sospensione").ColumnName = "motivo"
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
            'Non necessaria -> Cliente 
            'If Not OrdiniCntx.MaCustSupp.AsNoTracking.Any(Function(k) k.CustSupp.Equals(r("ACGCOD").ToString) AndAlso k.CustSuppType.Equals(CustSuppType.Cliente)) Then errori.Add("Cliente assente su Mago :" & (r("ACGCOD")).ToString)
            'Si gestiscE un codice unico tramite tabella di macth ( elenco clienti spa)
            'Cliente
            If Not CheckNuovoCliente(r("ACGCOD").ToString) Then errori.Add("Cliente assente su Mago :" & (r("ACGCOD")).ToString)
            'Numeratore Ordini
            Dim d As Date
            'Debug.Print(Date.TryParse(r("DTPRODUZ"), d))
            If Not Date.TryParse(r("DTPRODUZ"), d) OrElse d < New Date(1900, 1, 1) Then
                avvisi.Add("DTAPRODUZ illeggibile contratto:" & r("CONTRATTO").ToString)
            Else
                If Not OrdiniCntx.MaNonFiscalNumbers.AsNoTracking.Any(Function(k) k.CodeType = CodeType.OrdCli AndAlso k.BalanceYear = Year(r("DTPRODUZ"))) Then avvisi.Add("Contatore Ordini non trovato:" & r("DTPRODUZ").ToString)
            End If
            'Codice Iva
            If Not OrdiniCntx.MaTaxCodes.AsNoTracking.Any(Function(k) k.Acgcode.Equals(r("CIVA").ToString)) Then avvisi.Add("Valore assente su Mago - Iva(CIVA):" & (r("CIVA")).ToString)
            'Pagamento
            If OrdiniCntx.MaPaymentTerms.AsNoTracking.Any(Function(k) k.Acgcode.Equals(r("CPAGAM").ToString)) Then avvisi.Add("Valore assente su Mago - Pagamento:" & (r("CPAGAM")).ToString)
            'Contropartita
            Dim contropartitaFox As String = dvTabelle.CercaValoreSuTabelleFox("TS", r("TIPSERV").ToString)
            If String.IsNullOrEmpty(dvPdc.CercaContropartitaFox(contropartitaFox)) Then avvisi.Add("Valore assente su Mago - Contropartita(TIPSERV):" & r("TIPSERV").ToString)
            'AGENTE
            Dim produttore As String = dvTabelle.CercaValoreSuTabelleFox("PT", r("PRODUTTORE").ToString)
            If Right(TrovaAgente(r("PRODUTTORE").ToString, r("FILIALE")), 3) = "XXX" Then avvisi.Add("Agente assente su Mago(PRODUTTORE):" & r("PRODUTTORE").ToString & " Contratto: " & r("CONTRATTO").ToString)
            'Tipo Servizio
            If TranscodificaServizio(r("TIPSERV").ToString).Equals("XXXXX") Then avvisi.Add("Trascodifica Servizio assente: " & r("TIPSERV").ToString & " Contratto: " & r("CONTRATTO").ToString)
            'Frequenza = NO e Canone <> 0
            If r("FREQ").ToString = "NO" AndAlso CDbl(r("CANONE")) <> 0 Then errori.Add("Contratto con frequenza = NO ma Canone <> 0 :" & r("CONTRATTO").ToString)
            'GRP_Contratto
            If String.IsNullOrWhiteSpace(r("GRP_CONTRATTO").ToString) Then errori.Add("Contratto con GRP Contratto assente :" & r("CONTRATTO").ToString)
            'GRP_distinta_fattura
            If String.IsNullOrWhiteSpace(r("GRP_distinta_fattura").ToString) Then errori.Add("Contratto con GRP distinta fattura :" & r("CONTRATTO").ToString)
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

    ''' <summary>
    ''' Cerca su tabella di trascodifica se esiste il codice cliente in analisi
    ''' </summary>
    ''' <param name="cliente"></param>
    ''' <returns></returns>
    Private Function CheckNuovoCliente(cliente As String) As Boolean
        If dvElencoClientiSpa.Find(cliente) = -1 Then Return False
        Return Not String.IsNullOrEmpty(dvElencoClientiSpa.Item(dvElencoClientiSpa.Find(cliente))("CODICE FINALE"))
    End Function

    ''' <summary>
    ''' Esegue associazione nuovi cliente su tabella dtContratti partendo da elenco clienti spa
    ''' </summary>
    ''' <returns></returns>
    Private Function AssociaClienti() As List(Of List(Of String))
        Dim avvisi As New List(Of String)
        EditTestoBarra("Assegnazione nuovo codice Cliente")
        FLogin.prgCopy.Value = 1
        FLogin.prgCopy.Maximum = dtContratti.Rows.Count
        FLogin.prgCopy.Step = 1
        dtContratti.Columns.Add("NEWCODCLI", GetType(String))
        For Each r As DataRow In dtContratti.Rows
            Dim n As String = SostituisciCliente(r("ACGCOD").ToString)
            If n.Equals(String.Empty) Then
                avvisi.Add("Cliente: " & r("ACGCOD").ToString & " senza transcodifica")
                n = r("ACGCOD").ToString
            End If
            r("NEWCODCLI") = n
            AvanzaBarra()
        Next
        Return New List(Of List(Of String)) From {avvisi}
    End Function

    Private Function SostituisciCliente(cliente As String) As String
        If dvElencoClientiSpa.Find(cliente) = -1 Then Return String.Empty
        Return dvElencoClientiSpa.Item(dvElencoClientiSpa.Find(cliente))("CODICE FINALE")
    End Function
    Private Sub ScriviOrdini()
        Try
#Region "Variabili"
            Dim errori As New StringBuilder()
            Dim avvisi As New StringBuilder()
            Dim esclusi As New StringBuilder()

            Dim defVendite = (From dv In OrdiniCntx.MaUserDefaultSales.ToList Select dv).First
            Dim defOrdini = (From dor In OrdiniCntx.MaUserDefaultSaleOrders.ToList Select dor).First
            ' Dim defContabili = (From dc In OrdiniCntx.MaAccountingDefaults.ToList Select dc).First
            Dim defIva = (From di In OrdiniCntx.MaTaxCodesDefaults.ToList Select di).First
            Dim sDefContropartita As String = defVendite.ServicesSalesAccount
            Dim sDefCodIva As String = defIva.TaxCode
            Dim tecno_All1Descri As String = (From da In OrdiniCntx.MaItems.Where(Function(f) f.Item.Equals(TECNO_ALL1)).ToList Select da).First.Description

            Dim dvFattEle As New DataView(dtFattEle)

            Dim dtRID As DataTable = ds.Tables("_RID")
            Dim dvRID As New DataView(dtRID)

            efMaIdnumbers.Add(OrdiniCntx.MaIdnumbers.First(Function(k) k.CodeType = IdType.OrdCli))
            Dim saleOrdId As Integer = efMaIdnumbers(0).LastId
            efMaNonFiscalNumbers = OrdiniCntx.MaNonFiscalNumbers.Where(Function(k) k.CodeType = CodeType.OrdCli).ToList

            Dim cliMago As New MaCustSupp
            'Dim cliLINQ = From c In OrdiniCntx.MaCustSupp.Include(Function(o) o.MaCustSuppCustomerOptions)
            Dim sediCliente As New List(Of MaCustSuppBranches)
            Dim drDatiFatturaXls As DataRow = dtRaggTeste.NewRow
            Dim drClienord As DataRow = ds.Tables("_LIENORD").NewRow
            Dim drElencoClientiSpa As DataRow = ds.Tables("ELENCO CLIENTI SPA").NewRow
            Dim masterDistinta As New DistintaMaster
            'Dim rowsToExclude As Integer            'Totale righe da escludere
            Dim rowToExclude_cnt As Integer         'Contatore delle righe da escludere
            Dim masterOrder As New OrdineMaster
            Dim rowInOrder_cnt As Integer           'Contatore delle righe ordine

            'Ordino 
            'Al 15/09/23: si raggruppa solo se GRP_CONTRATTO sono uguali
            'Dim dvContratti As New DataView(dtContratti, "", "ACGCOD, GRP_CONTRATTO, GRP_distinta_fattura, CANONE DESC", DataViewRowState.CurrentRows)
            'Si e' scelto di riassegnare gli ordini ad un codice cliente diverso pertanto la dv deve essere ordinta per questo nuovo campo ( aggiunto precedentemente)
            Dim dvContratti As New DataView(dtContratti, "", "ACGCOD, GRP_CONTRATTO, GRP_distinta_fattura, CANONE DESC", DataViewRowState.CurrentRows)
            '11/10/2023 E' possibile che alcuni contratti vadano assegnati ad altri e hanno codice cliente diverso ma GRP_CONTRATTO uguale
            Dim dvChkContratto_Cliente As New DataView(dtContratti, "", "CONTRATTO, ACGCOD", DataViewRowState.CurrentRows)
            Dim contrattiDaUnire As New List(Of DataRow)
            Dim iLineContratto As Short
            Dim iLineDistinta As Short
            Dim iLineDescFatt As Short
            nrDistinte = 0
            nrDistinteUNO = 0
            Dim nextDataFatt As String = New DateTime(2024, 7, 1).ToString
            Dim nextDataFattAnnAnt As String = New DateTime(2025, 1, 1).ToString
            Dim nextDataFattAnnPost As String = New DateTime(2024, 12, 31).ToString

#End Region

            EditTestoBarra("Scrivi Ordini")
            FLogin.prgCopy.Value = 1
            FLogin.prgCopy.Maximum = dtContratti.Rows.Count
            FLogin.prgCopy.Step = 1
            For Each drv As DataRowView In dvContratti
                Try
                    Dim r As DataRow = drv.Row
                    'Limite temporaneo a SOLO ALCUNI CLIENTI righe ( solo per xls intero)
                    If uselOk AndAlso Not lOK.Contains(r.Item("ACGCOD").ToString) Then Continue For
                    'If lExclude.Contains(r.Item("ACGCOD").ToString) Then Continue For

                    '''''''''''''''''''''''''''''''''
                    '            ESCUSIONI
                    '    vari su singolo contratto
                    '''''''''''''''''''''''''''''''''
                    If r("GRP_CONTRATTO").ToString.Equals("CRS + QUOTA") Then Continue For
                    If r("GRP_CONTRATTO").ToString.Equals("ft cc speciale") Then Continue For

                    'Gestione contratti assegnati a cliente diverso 
                    If Not String.IsNullOrWhiteSpace(r("GRP_CONTRATTO").ToString) Then
                        Dim irows As Integer
                        If r("GRP_CONTRATTO").ToString.Equals("SOSPESO") Then
                            'CONTROLLO SU CAMPO GRP_Distinta
                            irows = dvChkContratto_Cliente.FindRows(New Object() {r("GRP_distinta_fattura").ToString.Trim, r("ACGCOD").ToString.Trim}).Length
                            avvisi.AppendLine("Contratto SOSPESO " & r("CONTRATTO").ToString.Trim & " del cliente " & r("ACGCOD").ToString.Trim & "")
                        Else
                            irows = dvChkContratto_Cliente.FindRows(New Object() {r("GRP_CONTRATTO").ToString.Trim, r("ACGCOD").ToString.Trim}).Length
                        End If
                        Select Case irows
                            Case 0
                                'Contratto da raggruppare con altro cliente
                                Debug.Print(r("ACGCOD").ToString & " " & r("CONTRATTO").ToString.Trim & " da raggruppare dopo")
                                avvisi.AppendLine("Contratto " & r("CONTRATTO").ToString.Trim & " del cliente " & r("ACGCOD").ToString.Trim & " raggruppato con altro cliente")
                                contrattiDaUnire.Add(r)
                                Continue For
                            Case 1
                                'ok
                            Case Else
                                Dim msgLog As String = "Impossibile continuare!" & Environment.NewLine & "Esistono piu' contratti con codice:" & r("GRP_CONTRATTO").ToString.Trim
                                errori.AppendLine("ERRORE FATALE : Esistono piu' contratti con codice:" & r("GRP_CONTRATTO").ToString.Trim)
                                Dim mb As New MessageBoxWithDetails(msgLog, GetCurrentMethod.Name)
                                mb.ShowDialog()
                                End
                        End Select
                    Else
                        Debug.Print(r("ACGCOD").ToString & " " & r("CONTRATTO").ToString.Trim & " senza GRP Contratto")
                        esclusi.AppendLine("Contratto " & r("CONTRATTO").ToString.Trim & " cliente " & r("ACGCOD").ToString.Trim & " senza GRP Contratto. Note: " & r("note"))
                        Continue For
                    End If


                    Dim contratto As String = r("CONTRATTO").ToString.Trim
                    Dim clienteFox As String = r("CLIENTE").ToString.Trim
                    Dim clienteACG As String = r("ACGCOD").ToString.Trim
                    Dim clienteContratto As String = r("NEWCODCLI").ToString.Trim
                    Debug.Print(contratto & " ACGCOD: " & clienteACG & " -> NEW: " & clienteContratto)
                    Dim centro As String = dvTabelle.CercaValoreSuTabelleFox("CC", r("CCOSTO").ToString).Trim

                    'Check Cambio cliente -> Carico Sedi
                    If Not masterOrder.ClienteMago.Equals(clienteContratto) Then
                        sediCliente = OrdiniCntx.MaCustSuppBranches.AsNoTracking.Where(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) AndAlso f.CustSupp.Equals(clienteContratto)).ToList
                        'Carico ClienOrd
                        drClienord = r.GetParentRow("Ordini Clienti") '_LIENORD
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
                    If Not String.IsNullOrWhiteSpace(r("DTCESSFATT").ToString.Trim) Then avvisi.AppendLine("Indicata data cessazione fattura DTCESSFATT su Contratto: " & contratto)

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
                        If Not String.IsNullOrWhiteSpace(r("GRP_CONTRATTO").ToString.Trim) Then
                            Dim sGRP As String = If(r("GRP_CONTRATTO").ToString.Trim.Equals("SOSPESO"), r("GRP_distinta_fattura").ToString.Trim, r("GRP_CONTRATTO").ToString.Trim)
                            Dim dvMasterOrd As New DataView(dtContratti, "GRP_CONTRATTO='" & sGRP & "'", "ACGCOD, GRP_CONTRATTO", DataViewRowState.CurrentRows)
                            masterOrder = New OrdineMaster With {
                                    .ClienteFox = clienteFox,
                                    .ClienteMago = clienteContratto,
                                    .ClienteACG = clienteACG,
                                    .Contratto = sGRP,
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
                            Dim dvGroup As New DataView(dtContratti, "GRP_distinta_fattura='" & r("GRP_distinta_fattura").ToString.Trim & "'", "ACGCOD, GRP_CONTRATTO, GRP_distinta_fattura", DataViewRowState.CurrentRows)
                            masterDistinta = New DistintaMaster With {
                                    .GruppoDistinta = r("GRP_distinta_fattura").ToString.Trim,
                                    .RigheDistinta = dvGroup.Count
                                     }
                        End If
                    End If

                    Dim sito As String = ""
#Region "Sito/Impianto = Sede Cliente"
                    'Ricerca e creazione Sito/Impianto = Sede Cliente
                    ' Dim c = OrdiniCntx.MaCustSuppBranches.Select(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) AndAlso f.CustSupp.Equals(clienteMago))
                    Dim newBranches As Boolean = False
                    Dim ragSocSito As String
                    If drClienord("PRAGSOC").ToString.Contains("*") Then
                        'Persona Fisica : escludo la seconda parte
                        'drClienord("CODRSO") = 1 
                        ragSocSito = Left(r("RAGSOC").Trim, 128)
                    Else
                        ragSocSito = Left(String.Concat(r("RAGSOC"), " ", r("PRAGSOC")).Trim, 128)
                    End If

                    If sediCliente.Any Then
                        'Controllo esistenza con RAGSOC + (replace CrLf  ) + PRAGSOC e INDIRIZZO
                        Dim sediRidotte As List(Of MaCustSuppBranches) = sediCliente.FindAll(Function(f) f.CompanyName.Replace(Environment.NewLine, " ").Equals(ragSocSito) AndAlso f.Address.Equals(r("INDIRIZZO").ToString.Trim)).ToList
                        If sediRidotte.Count = 0 Then
                            newBranches = True
                            sito = "I" & (sediCliente.Count + 1).ToString("0000")
                        ElseIf sediRidotte.Count = 1 Then
                            sito = sediRidotte.First.Branch
                        ElseIf sediRidotte.Count > 1 Then
                            'Se ho piu' righe segnalo
                            Dim msgLog As String = "(NO SAVE) Più sedi simili, impossibile determinare corretta. Ordine:" & contratto
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
                                            .CustSupp = clienteContratto,
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

                    If rowInOrder_cnt = 0 Then
                        'Nuovo Ordine
                        'Cliente
                        clienteACG = r.Item("ACGCOD").ToString.Trim
                        drElencoClientiSpa = r.GetParentRow("ELENCO CLIENTI SPA")
                        clienteContratto = If(drElencoClientiSpa Is Nothing, clienteACG, drElencoClientiSpa("CODICE FINALE"))
                        'cliMago = OrdiniCntx.MaCustSupp.Find(CustSuppType.Cliente, clienteACG)
                        cliMago = OrdiniCntx.MaCustSupp.Find(CustSuppType.Cliente, clienteContratto)
                        If cliMago Is Nothing Then
                            Dim mb As New MessageBoxWithDetails("Cliente non trovato su Mago:" & clienteContratto, GetCurrentMethod.Name)
                            mb.ShowDialog()
                            Continue For
                        End If

                        masterOrder.Banca.CompanyBank = cliMago.CompanyBank.Trim
                        masterOrder.Banca.CompanyCa = cliMago.CompanyCa.Trim
                        masterOrder.Banca.CustSuppBank = cliMago.CustSuppBank.Trim
                        masterOrder.Banca.CustomerCompanyCa = cliMago.CustomerCompanyCa.Trim

                        'CodiceRaggruppamento
                        Select Case r.GetChildRows("Raggruppamento_Ordine").Count
                            Case 0
                                errori.AppendLine("Cliente _AGRFATT senza corrispondente righe di raggruppamento su: " & contratto & " CodiceRaggruppamento: " & codiceRaggruppamento)
                            Case 1
                                codiceRaggruppamento = r.GetChildRows("Raggruppamento_Ordine").SingleOrDefault()("RAGRFATT").ToString.Trim '_AGRFATD
                                Try
                                    drDatiFatturaXls = r.GetChildRows("Raggruppamento_Ordine").SingleOrDefault.GetParentRow("Ordini Raggruppati") ' _AGRFATT
                                    If drDatiFatturaXls Is Nothing Then
                                        errori.AppendLine("Cliente _AGRFATT non trovato su Contratto: " & contratto & " CodiceRaggruppamento: " & codiceRaggruppamento)
                                    End If
                                Catch ex As InvalidOperationException
                                    errori.AppendLine("Cliente _AGRFATT con piu' righe di raggruppamento su: " & contratto & " CodiceRaggruppamento: " & codiceRaggruppamento)
                                End Try
                            Case Else
                                errori.AppendLine("Cliente _AGRFATT con piu' righe di raggruppamento su: " & contratto & " CodiceRaggruppamento: " & codiceRaggruppamento)
                        End Select
                        masterOrder.RaggruppamentoFattura = codiceRaggruppamento
                        newCodragg = r("vettore").ToString.Trim
                        masterOrder.Vettore = newCodragg

                        'Cerco dati fattura elettronica coerenti con (raggruppamento se esiste)
                        dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                        drFattEle = dtFattEle.NewRow
                        If dvFattEle.Count = 1 Then
                            drFattEle = dvFattEle(0).Row
                        Else
                            dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}'"
                            If dvFattEle.Count = 0 Then
                                errori.AppendLine("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto)
                                'Dim mb As New MessageBoxWithDetails("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto, GetCurrentMethod.Name)
                                ' mb.ShowDialog()
                            ElseIf dvFattEle.Count = 1 Then
                                drFattEle = dvFattEle(0).Row
                            Else
                                errori.AppendLine("Più righe di Fatturazione Elettronica (CLIFTELE) impossibile determinare quella corretta: " & contratto)
                                'Dim mb As New MessageBoxWithDetails("Più righe di Fatturazione Elettronica (CLIFTELE) impossibile determinare quella corretta: " & contratto, GetCurrentMethod.Name)
                                'mb.ShowDialog()
                            End If
                        End If
                        masterOrder.CodiceSdi = drFattEle("F114").ToString.Trim
                        masterOrder.Pec = drFattEle("F116").ToString.Trim
                        masterOrder.RiferimentoAmministrazione = drFattEle("F126").ToString.Trim
                        'Sede invio Documenti // Codice SDI
                        If masterOrder.Contratto.Equals(contratto) Then
                            'Cerco se Ragione Sociale e' quella di invio fattura o serve la sede
                            'RAGRFATT.RAGSOC(PRAGSOC) = CLIENTE MAGO /SEDE LEGALE
                            'RAGRFATT.R_RSO(R_PSO) = SEDE INVIO DOCUMENTO
                            Dim newSendDoc As Boolean = False
                            Dim ragSocDatifatturaXls As String
                            Dim indirizzoDatifatturaXls As String
                            If drDatiFatturaXls IsNot Nothing Then
                                ragSocDatifatturaXls = Left(String.Concat(drDatiFatturaXls("R_RSO").ToString.Trim, If(IsPrivato(cliMago.TaxIdNumber, cliMago.FiscalCode), "", " " & drDatiFatturaXls("R_PSO").ToString.Trim)).Trim, 128)
                                indirizzoDatifatturaXls = drDatiFatturaXls("INDIRIZZO").ToString()
                            End If
                            Dim sendDocumentTo As String = ""
                            'Dim IpaZero As String = If(cli.MaCustSuppCustomerOptions.PublicAuthority = "1", "000000", "0000000")
                            If ragSocDatifatturaXls.Equals(cliMago.CompanyName.Replace(Environment.NewLine, " ")) AndAlso indirizzoDatifatturaXls.Equals(cliMago.Address) AndAlso masterOrder.CodiceSdi.Equals(cliMago.Ipacode) Then
                                'Corrette RagSoc, Indirizzo , IPA Code
                                sendDocumentTo = ""
                            Else
                                'Filtro sedi uguale a RagSoc, Indirizzo
                                Dim sediRidotte As List(Of MaCustSuppBranches) = sediCliente.FindAll(Function(f) f.CompanyName.Replace(Environment.NewLine, " ").Equals(ragSocDatifatturaXls) AndAlso f.Address.Equals(indirizzoDatifatturaXls)).ToList
                                If sediRidotte.Count = 0 Then
                                    'Se non trovo niente di simile nemmeno come RagSoc+Indirizzo la devo per forza creare
                                    newSendDoc = True
                                    sendDocumentTo = "FT" & (sediCliente.Count + 1).ToString("000")
                                ElseIf sediRidotte.Count = 1 Then
                                    'Se ne ho una controllo ipa
                                    If sediRidotte.First.Ipacode.Equals(cliMago.Ipacode) OrElse sediRidotte.First.Ipacode.Equals("") Then
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
                                        Dim msgLog As String = "(NO SAVE) Più sedi simili (SendDocumenTo) con lo stesso CodiceSdi, impossibile determinare corretta. Ordine:" & contratto
                                        errori.AppendLine(msgLog)
                                        Debug.Print(msgLog)
                                    End If
                                End If
                            End If
                            masterOrder.SedeInvioDoc = sendDocumentTo
                            If newSendDoc Then
                                'todo: riferimento amministrazione(vedere dove va)
                                If drDatiFatturaXls IsNot Nothing Then
                                    Dim rCliBr As New MaCustSuppBranches With {
                                                .CustSuppType = CustSuppType.Cliente,
                                                .CustSupp = clienteContratto,
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
                        End If

                        'Cond pag
                        dvPagamentiFox.RowFilter = "CPAGAM = '" & r("CPAGAM").ToString.Trim & "' AND ( SPLITPAY IS NULL OR SPLITPAY = '' )"
                        condPagAcg = dvPagamentiFox(0)("ACGCOD").ToString.Trim
                        condPag = OrdiniCntx.MaPaymentTerms.AsNoTracking.First(Function(k) k.Acgcode.Equals(condPagAcg)).Payment
                        masterOrder.CondPag = condPag
                        'RID
                        dvRID.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                        masterOrder.UMRCode = If(dvRID.Count = 1, dvRID(0)("CODINDIVID").ToString.Trim, "")

                        vettore = newCodragg
                        codIva = OrdiniCntx.MaTaxCodes.AsNoTracking.First(Function(k) k.Acgcode.Equals(r("CIVA").ToString.Trim)).TaxCode
                        masterOrder.CodIva = codIva
                        Try
                            curNfCounter = efMaNonFiscalNumbers.First(Function(k) k.BalanceYear = Year(r("DTPRODUZ")))
                        Catch ex As Exception
                            Debug.Print("Numeratore non fiscale (Anno Assente)")
                            Dim nfn As New MaNonFiscalNumbers With {
                                .BalanceYear = Year(r("DTPRODUZ")),
                                .CodeType = CodeType.OrdCli,
                                .LastDocNo = 0,
                                .Separators = "/"
                                }

                            efMaNonFiscalNumbers.Add(nfn)
                            curNfCounter = nfn
                        End Try
                        curNfCounter.LastDocNo += 1
                        efMaNonFiscalNumbers.First(Function(k) k.BalanceYear = Year(r("DTPRODUZ"))).LastDocNo = curNfCounter.LastDocNo
                        ordNo = Right(Year(r("DTPRODUZ")), 2) & curNfCounter.Separators & CInt(curNfCounter.LastDocNo).ToString("00000")
                        masterOrder.OrderNo = ordNo
                        iLineContratto = 0

                        sRivolgersiA = String.Concat(r("DRIV1").ToString, r("DRIV2").ToString, r("DRIV3").ToString, r("DRIV4").ToString).Trim
                        agente = TrovaAgente(r("PRODUTTORE").ToString.Trim, r("FILIALE"))
                    Else
#Region "Controlli di congruenza"
                        'CodiceRaggruppamento
                        Select Case r.GetChildRows("Raggruppamento_Ordine").Count
                            Case 0
                                errori.AppendLine("Raggruppamento assente dal file RAGRFATD (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                            Case 1
                                codiceRaggruppamento = r.GetChildRows("Raggruppamento_Ordine").SingleOrDefault()("RAGRFATT").ToString.Trim '_AGRFATD
                                'Cerco riferimento coerente con (raggruppamento se esiste)
                                dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                                drFattEle = dtFattEle.NewRow
                                If dvFattEle.Count = 1 Then
                                    drFattEle = dvFattEle(0).Row
                                Else
                                    dvFattEle.RowFilter = $"CLIENTE = '{clienteFox}'"
                                    If dvFattEle.Count = 0 Then
                                        errori.AppendLine("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto)
                                        'Dim mb As New MessageBoxWithDetails("Cliente (" & clienteACG & ") assente dai dati di Fatturazione Elettronica (CLIFTELE): " & contratto, GetCurrentMethod.Name)
                                        'mb.ShowDialog()
                                    ElseIf dvFattEle.Count = 1 Then
                                        drFattEle = dvFattEle(0).Row
                                    Else
                                        errori.AppendLine("Più righe di Fatturazione Elettronica (CLIFTELE) impossibile determinare quella corretta: " & contratto)
                                        'Dim mb As New MessageBoxWithDetails("Più righe di Fatturazione Elettronica (CLIFTELE) impossibile determinare quella corretta: " & contratto, GetCurrentMethod.Name)
                                        'mb.ShowDialog()
                                    End If
                                End If
                                If Not codiceRaggruppamento.Equals(masterOrder.RaggruppamentoFattura) AndAlso CDbl(r("CANONE").ToString) <> 0 Then
                                    errori.AppendLine("Raggruppamento fattura diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                                End If
                            Case Else
                                errori.AppendLine("Cliente _AGRFATT con piu' righe di raggruppamento su: " & contratto & " CodiceRaggruppamento: " & codiceRaggruppamento)
                        End Select

                        'Cond pag
                        dvPagamentiFox.RowFilter = "CPAGAM = '" & r("CPAGAM").ToString.Trim & "' AND ( SPLITPAY IS NULL OR SPLITPAY = '' )"
                        condPagAcg = dvPagamentiFox(0)("ACGCOD").ToString.Trim
                        condPag = OrdiniCntx.MaPaymentTerms.AsNoTracking.First(Function(k) k.Acgcode.Equals(condPagAcg)).Payment
                        If Not condPag.Equals(masterOrder.CondPag) Then
                            errori.AppendLine("Pagamento diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                        End If
                        'Stesso RID
                        dvRID.RowFilter = $"CLIENTE = '{clienteFox}' AND RAGRFATT = '{codiceRaggruppamento}'"
                        If Not masterOrder.UMRCode.Equals(If(dvRID.Count = 1, dvRID(0)("CODINDIVID").ToString.Trim, "")) Then
                            errori.AppendLine("Codice UMR diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                        End If
                        'Codice Iva
                        codIva = OrdiniCntx.MaTaxCodes.AsNoTracking.First(Function(k) k.Acgcode.Equals(r("CIVA").ToString.Trim)).TaxCode
                        If Not masterOrder.CodIva.Equals(codIva) Then
                            errori.AppendLine("Codice IVA diverso da quello Master (" & masterOrder.Contratto & ") su Contratto: " & contratto)
                        End If

#End Region
                    End If

#End Region
#Region "Riga Contratto (Fatturativa)"
                    Dim servizioMago As String = TranscodificaServizio(r("TIPSERV").ToString)
                    If servizioMago.Equals("XXXXX") Then errori.AppendLine("Trascodifica Servizio non esitente: " & r("TIPSERV").ToString & " su Contratto: " & contratto)
                    Dim descriCanone As String = Left(r("DESCAN").ToString.Trim, 128)
                    If descriCanone = "*" OrElse descriCanone = "-" OrElse descriCanone = "*/" Then descriCanone = ""
                    If Left(descriCanone, 1).Equals("*") Then descriCanone = descriCanone.Substring(1).Trim
                    'Valori
                    Dim qtaOrdine As Double = TranscodificaQuantita(r("FREQ").ToString)
                    'Gli importi sono sempre mensili
                    Dim imponibileFattura As Double
                    Double.TryParse(r("CANONE").ToString, imponibileFattura)
                    Dim imponibileContratto As Double
                    Double.TryParse(r("CANALLEUR").ToString, imponibileContratto)
                    Dim impCanone_ALL1 As Double
                    Double.TryParse(r("CANONE_ALL1").ToString, impCanone_ALL1)
                    imponibileContratto -= impCanone_ALL1
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
                            .Descrizione = "",
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
                            .DataProssimaFatt = If(.TipoRigaServizio.Equals("12A"), nextDataFattAnnAnt, If(.TipoRigaServizio.Equals("12P"), nextDataFattAnnPost, nextDataFatt)),
                            .CodiceIva = codIva,
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId,
                            .SubLineDescFatt = 0,
                            .SubLineDistinta = 0,
                            .CdC = centro,
                            .CodIntegra = contratto,
                            .CodContratto = contratto,
                            .Impianto = ""
                            }
                        '.Descrizione = If(String.IsNullOrWhiteSpace(descriCanone), r("DTS"), descriCanone),

                        'Aggiungo la riga alla collection
                        efAllordCliContratto.Add(rOrdContratto)

#Region "Descrizioni Fattura"
                        Dim descriFatt As String = String.Concat(r("DFAT1"), r("DFAT2"), r("DFAT3"), r("DFAT4")).Trim
                        If descriFatt = "*" OrElse descriFatt = "-" OrElse descriFatt = "*/" Then descriFatt = ""

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
                            '20/10/2023 : Mail Laura dice di togliere a capo e righe vuote
                            'Dim descriList As List(Of String) = GetListTextWithNewLines(descriFatt, 128)
                            Dim descriList As List(Of String) = GetListTextWithoutNewLines(descriFatt, 128)
                            If descriList.Count > 0 Then
                                'If masterDistinta.RigheDistinta > 0 AndAlso rowToExclude_cnt > 0 Then
                                '    errori.AppendLine("(NO SAVE) DescFatt: presente DFAT* Ordine:" & contratto)
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
                        .DataProssimaFatt = If(.TipoRigaServizio.Equals("12A"), nextDataFattAnnAnt, If(.TipoRigaServizio.Equals("12P"), nextDataFattAnnPost, nextDataFatt)),
                        .CodIntegra = contratto,
                        .CodContratto = contratto,
                        .Tbcreated = Now,
                        .Tbmodified = Now,
                        .TbcreatedId = sLoginId,
                        .TbmodifiedId = sLoginId,
                        .Nota = "",
                        .CdC = centro,
                        .Impianto = sito,
                        .SubLineServAgg = 0
                         }
                    'Aggiungo la riga alla collection
                    efAllordCliContrattoDistinta.Add(rOrdDistinta)
                    nrDistinte += 1
#End Region
#Region "Attività di Sospensione"
                    If Not masterDistinta.Sospeso Then
                        If r("GRP_CONTRATTO").ToString.Equals("SOSPESO") Then
                            r("motivo") = "SOSPESO"
                            r("DATA_INIZIO_SOSP") = "01/01/2000"
                            r("DATA_FINE_SOSP") = "31/12/2099"
                        End If
                        If Not String.IsNullOrWhiteSpace(r("motivo").ToString) Then
                            Dim motivo As String = If(r("motivo").Equals("ATTESA ATTIVAZIONE"), "ATTATT", r("motivo"))
                            If Len(motivo) > 10 Then
                                errori.AppendLine("Motivo sospensione troppo lungo su Contratto: " & contratto)
                                motivo = "ERRORE"
                            End If
                            Dim rOrdAttivita As New AllordCliAttivita With {
                            .IdOrdCli = saleOrdId,
                            .Line = 1,
                            .RifLinea = iLineContratto,
                            .Attivita = motivo,
                            .DataInizio = Valid_Data(r("DATA_INIZIO_SOSP").ToString),
                            .DataFine = Valid_Data(r("DATA_FINE_SOSP").ToString),
                            .DaFatturare = "0",
                            .DataRifatturazione = sDataNulla,
                            .Fatturata = "0",
                            .Nota = "",
                            .RifServizio = servizioMago,
                            .ValUnit = valunitFattura,
                            .TestoFattura = "",
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                        }
                            efAllordCliAttivita.Add(rOrdAttivita)
                            masterDistinta.Sospeso = True
                        End If
                    End If
#End Region
#Region "Servizi Aggiuntivi"
                    Try
                        Dim iLineServAgg As Short = 0
                        'Costo Servizi Aggiuntivi (loro li chiamano Canone)
                        'ISPEZIONI
                        If Not String.IsNullOrWhiteSpace(r("CANISP").ToString) AndAlso r("CANISP") > 0 Then
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
                                .DataProssimaFatt = nextDataFatt,
                                .Periodicita = TranscodificaPeriodicita(r("PERISP").ToString),
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId
                                }
                            'Aggiungo la riga alla collection
                            efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                        End If
                        'INTERVENTI
                        If Not String.IsNullOrWhiteSpace(r("CANINT").ToString) AndAlso r("CANINT") > 0 Then
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
                                .DataProssimaFatt = nextDataFatt,
                                .Periodicita = TranscodificaPeriodicita(r("PERINT").ToString),
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId
                                }
                            'Aggiungo la riga alla collection
                            efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                        End If
                        'APERTURA/CHIUSURA
                        If Not String.IsNullOrWhiteSpace(r("CANAPECHIU").ToString) AndAlso r("CANAPECHIU") > 0 Then
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
                                .DataProssimaFatt = nextDataFatt,
                                .Periodicita = TranscodificaPeriodicita(r("PERAPE").ToString),
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId
                                }
                            'Aggiungo la riga alla collection
                            efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                        End If
                        'ASSISTENZA
                        If Not String.IsNullOrWhiteSpace(r("CANASSIST").ToString) AndAlso r("CANASSIST") > 0 Then
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
                                .DataProssimaFatt = nextDataFatt,
                                .Periodicita = TranscodificaPeriodicita(r("PERASS").ToString),
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId
                                }
                            'Aggiungo la riga alla collection
                            efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                        End If
                        'PIANTONI
                        If Not String.IsNullOrWhiteSpace(r("CANPIA").ToString) AndAlso r("CANPIA") > 0 Then
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
                                .DataProssimaFatt = nextDataFatt,
                                .Periodicita = TranscodificaPeriodicita(r("PERPIA").ToString),
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId
                                }
                            'Aggiungo la riga alla collection
                            efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                        End If
                        'VIDEO ISP.
                        If Not String.IsNullOrWhiteSpace(r("CANVID").ToString) AndAlso r("CANVID") > 0 Then
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
                             .DataProssimaFatt = nextDataFatt,
                             .Periodicita = TranscodificaPeriodicita(r("PERVID").ToString),
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
                    Catch ex As Exception
                        Dim mb As New MessageBoxWithDetails("Errore su analisi servizi aggiuntivi!" & Environment.NewLine & "Valori Assenti. Codice GRP_CONTRATTO (" & r("GRP_CONTRATTO").ToString, GetCurrentMethod.Name, ")")
                        mb.ShowDialog()
                    End Try
#End Region
                    'Parte di tecnologia Allsystem 1 (CANONE ALL1)
                    Dim impTecno_ALL1 As Double
                    Double.TryParse(r("CANONE_ALL1").ToString, impTecno_ALL1)
                    If masterDistinta.RigheDistinta > 0 AndAlso impTecno_ALL1 <> 0 Then
                        iLineDistinta += 1
                        Dim rOrdDistintaAll1 As New AllordCliContrattoDistinta With {
                            .IdOrdCli = saleOrdId,
                            .Line = iLineDistinta,
                            .RifLinea = iLineContratto,
                            .Servizio = TECNO_ALL1,
                            .Descrizione = tecno_All1Descri,
                            .Qta = qtaOrdine,
                            .Um = "",
                            .ValUnit = Math.Round(impTecno_ALL1, 2),
                            .ValUnitIstat = Math.Round(impTecno_ALL1, 2),
                            .DataUltRivIstat = Valid_Data(r("DTVARCAN").ToString),
                            .TipoRigaServizio = TranscodificaFrequenza(r("FREQ").ToString),
                            .DataDecorrenza = Valid_Data(r("DTDECORR").ToString),
                            .DataFineElaborazione = sDataNulla,
                            .DataProssimaFatt = If(.TipoRigaServizio.Equals("12A"), nextDataFattAnnAnt, If(.TipoRigaServizio.Equals("12P"), nextDataFattAnnPost, nextDataFatt)),
                            .CodIntegra = "",
                            .CodContratto = contratto,
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId,
                            .Nota = "",
                             .CdC = r("CDC_ALL1").ToString,
                            .Impianto = sito,
                            .SubLineServAgg = 0
                         }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDistinta.Add(rOrdDistintaAll1)
                        nrDistinteUNO += 1
                    End If
                    'Aggiorno Sub
                    efAllordCliContratto.Last.SubLineDistinta = iLineDistinta

#End Region

#Region "Padre/Figlio"
                    If Not String.IsNullOrWhiteSpace(r("CONTRSUCC").ToString) Then
                        Dim rOrdFiglio As New AllordFiglio With {
                        .IdOrdCli = saleOrdId,
                        .IdOrdFiglio = 0,
                        .NrOrdFiglio = Strings.Right(r("CONTRSUCC").ToString, 10),
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
                            .NrOrdPadre = Strings.Right(r("CONTRPREC").ToString, 10),
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                             }
                        efAllordPadre.Add(rOrdPadre)
                    End If
#End Region
#Region "All Ordini Tipologia Servizi"
                    If Not efAllordCliTipologiaServizi.Exists(Function(f) f.IdOrdCli.Equals(saleOrdId) AndAlso f.Tipologia.Equals(r("TIPSERV").ToString)) Then
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
                             .Priority = r("FILIALE").ToString,
                            .CustSuppType = CustSuppType.Cliente,
                            .InternalOrdNo = masterOrder.OrderNo,
                            .ExternalOrdNo = TranscodificaFiliale(r("FILIALE").ToString) & Today.ToString("dd/MM/yy"),
                            .OrderDate = Valid_Data(r("DTPRODUZ").ToString),
                            .Customer = clienteContratto,
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
                            .InvoicingCustomer = clienteContratto,
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
                        .DataCessazione = Valid_Data(r("scadenza").ToString),
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
                        .Impianto = "",
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
                Catch ex As Exception
                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                    Continue For
                End Try
            Next

#Region "Righe accantonate "
            'Inserimento righe accantonate
            Dim currentCustomer As String = ""
            contrattiDaUnire.OrderBy(Function(f) f("ACGCOD"))
            Dim sediClienteMerged As New List(Of MaCustSuppBranches)
            For Each rAA In contrattiDaUnire
                Debug.Print(rAA("GRP_CONTRATTO").ToString() & vbCrLf)
            Next
            For Each rA In contrattiDaUnire
                Try
                    'Cerco id
                    Dim rifDistinta As AllordCliContrattoDistinta = efAllordCliContrattoDistinta.Find(Function(f) f.CodContratto.Equals(rA("GRP_CONTRATTO").ToString))
                    If rifDistinta Is Nothing Then
                        Dim mb As New MessageBoxWithDetails("Errore FATALE!" & Environment.NewLine & "Codice GRP_CONTRATTO (" & rA("GRP_CONTRATTO").ToString & ") assente in CONTRATTO", GetCurrentMethod.Name, "")
                        mb.ShowDialog()
                        Continue For
                    End If
                    Dim rifContratto As AllordCliContratto = efAllordCliContratto.Find(Function(f) f.IdOrdCli = rifDistinta.IdOrdCli AndAlso f.Line.Equals(rifDistinta.RifLinea))
                    Dim rifordine As MaSaleOrd = efMaSaleOrd.Find(Function(f) f.SaleOrdId = rifDistinta.IdOrdCli)
                    'Sedi
                    If Not currentCustomer.Equals(rA("ACGCOD").ToString) Then
                        sediClienteMerged = New List(Of MaCustSuppBranches)
                        'Attenzione le sedi sono quelle del clinte/contratto di riferimento
                        sediClienteMerged.AddRange(OrdiniCntx.MaCustSuppBranches.AsNoTracking.Where(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) AndAlso f.CustSupp.Equals(rifordine.Customer)).ToList)
                        sediClienteMerged.AddRange(efMaCustSuppBranches.Where(Function(f) f.CustSuppType.Equals(CustSuppType.Cliente) AndAlso f.CustSupp.Equals(rifordine.Customer)).ToList)
                        currentCustomer = rA("ACGCOD").ToString
                    End If
                    Dim sito As String = ""
                    Dim ragSocSito As String = Left(String.Concat(rA("RAGSOC"), " ", rA("PRAGSOC")).Trim, 128)
                    Dim newBranches As Boolean = False
                    If sediClienteMerged.Any Then
                        'Controllo esistenza con RAGSOC + (replace CrLf  ) + PRAGSOC e INDIRIZZO
                        Dim sediRidotte As List(Of MaCustSuppBranches) = sediClienteMerged.FindAll(Function(f) f.CompanyName.Replace(Environment.NewLine, " ").Equals(ragSocSito) AndAlso f.Address.Equals(rA("INDIRIZZO").ToString)).ToList
                        If sediRidotte.Count = 0 Then
                            newBranches = True
                            sito = "I" & (sediClienteMerged.Count + 1).ToString("0000")
                        ElseIf sediRidotte.Count = 1 Then
                            sito = sediRidotte.First.Branch
                        ElseIf sediRidotte.Count > 1 Then
                            'Se ho piu' righe segnalo
                            Dim msgLog As String = "(NO SAVE) Più sedi simili, impossibile determinare corretta. Ordine:" & rA("CONTRATTO").ToString
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
                                            .Address = rA("INDIRIZZO").ToString,
                                            .City = rA("COMUNE").ToString,
                                            .County = rA("PROV").ToString,
                                            .Region = Get_Regione(rA("PROV").ToString),
                                            .Zipcode = rA("CAP").ToString,
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

                    Dim servizioMago As String = TranscodificaServizio(rA("TIPSERV").ToString)
                    If servizioMago.Equals("XXXXX") Then errori.AppendLine("Trascodifica Servizio non esitente: " & rA("TIPSERV").ToString & " su Contratto: " & rA("CONTRATTO").ToString)
                    Dim descriCanone As String = Left(rA("DESCAN").ToString.Trim, 128)
                    If descriCanone = "*" OrElse descriCanone = "-" OrElse descriCanone = "*/" Then descriCanone = ""
                    If Left(descriCanone, 1).Equals("*") Then descriCanone = descriCanone.Substring(1).Trim
                    'Valori
                    Dim qtaOrdine As Double = rifDistinta.Qta
                    Dim imponibileFattura As Double = CDbl(rA("CANONE").ToString)
                    Dim imponibileContratto As Double = CDbl(rA("CANALLEUR").ToString)
                    Dim impCanone_ALL1 As Double
                    Double.TryParse(rA("CANONE_ALL1").ToString, impCanone_ALL1)
                    imponibileContratto -= impCanone_ALL1
                    Dim valunitFattura As Double = Math.Round(imponibileFattura, 2)
                    Dim valunitContratto As Double = Math.Round(imponibileContratto, 2)
                    If qtaOrdine = 0 OrElse qtaOrdine = 999 Then
                        errori.AppendLine("Indicato Canone ma frequenza uguale a NO su Contratto: " & rA("CONTRATTO").ToString)
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
                        .Descrizione = If(String.IsNullOrWhiteSpace(descriCanone), rA("DTS"), descriCanone),
                        .Qta = qtaOrdine,
                        .Um = "",
                        .ValUnit = valunitContratto,
                        .ValUnitIstat = valunitContratto,
                        .DataUltRivIstat = Valid_Data(rA("DTVARCAN").ToString),
                        .TipoRigaServizio = rifDistinta.TipoRigaServizio,
                        .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                        .DataFineElaborazione = sDataNulla,
                        .DataProssimaFatt = If(.TipoRigaServizio.Equals("12A"), nextDataFattAnnAnt, If(.TipoRigaServizio.Equals("12P"), nextDataFattAnnPost, nextDataFatt)),
                        .CodIntegra = rA("CONTRATTO").ToString,
                        .CodContratto = rA("CONTRATTO").ToString,
                        .Tbcreated = Now,
                        .Tbmodified = Now,
                        .TbcreatedId = sLoginId,
                        .TbmodifiedId = sLoginId,
                        .Nota = "",
                        .CdC = dvTabelle.CercaValoreSuTabelleFox("CC", rA("CCOSTO").ToString),
                        .Impianto = sito,
                        .SubLineServAgg = 0
                         }
                    'Aggiungo la riga alla collection
                    efAllordCliContrattoDistinta.Add(rOrdDistinta)
                    nrDistinte += 1

#Region "Servizi Aggiuntivi"
                    Dim iLineServAgg As Short = 0
                    'Costo Servizi Aggiuntivi (loro li chiamano Canone)
                    'ISPEZIONI
                    If Not String.IsNullOrWhiteSpace(rA("CANISP").ToString) AndAlso rA("CANISP") > 0 Then
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
                            .ValUnit = rA("CANISP"),
                            .ValUnitIstat = rA("CANISP"),
                            .DataUltRivIstat = sDataNulla,
                            .Franchigia = rA("FRAISP"),
                            .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                            .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                            .DataFineElaborazione = sDataNulla,
                            .DataProssimaFatt = nextDataFatt,
                            .Periodicita = TranscodificaPeriodicita(rA("PERISP").ToString),
                             .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                    End If
                    'INTERVENTI
                    If Not String.IsNullOrWhiteSpace(rA("CANINT").ToString) AndAlso rA("CANINT") > 0 Then
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
                            .ValUnit = rA("CANINT"),
                            .ValUnitIstat = rA("CANINT"),
                            .DataUltRivIstat = sDataNulla,
                            .Franchigia = rA("FRAINT"),
                            .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                            .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                            .DataFineElaborazione = sDataNulla,
                            .DataProssimaFatt = nextDataFatt,
                            .Periodicita = TranscodificaPeriodicita(rA("PERINT").ToString),
                             .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                    End If
                    'APERTURA/CHIUSURA
                    If Not String.IsNullOrWhiteSpace(rA("CANAPECHIU").ToString) AndAlso rA("CANAPECHIU") > 0 Then
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
                            .ValUnit = rA("CANAPECHIU"),
                            .ValUnitIstat = rA("CANAPECHIU"),
                            .DataUltRivIstat = sDataNulla,
                            .Franchigia = rA("FRAAPE"),
                            .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                            .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                            .DataFineElaborazione = sDataNulla,
                            .DataProssimaFatt = nextDataFatt,
                            .Periodicita = TranscodificaPeriodicita(rA("PERAPE").ToString),
                             .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                    End If
                    'ASSISTENZA
                    If Not String.IsNullOrWhiteSpace(rA("CANASSIST").ToString) AndAlso rA("CANASSIST") > 0 Then
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
                            .ValUnit = rA("CANASSIST"),
                            .ValUnitIstat = rA("CANASSIST"),
                            .DataUltRivIstat = sDataNulla,
                            .Franchigia = rA("FRAASS"),
                            .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                            .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                            .DataFineElaborazione = sDataNulla,
                            .DataProssimaFatt = nextDataFatt,
                            .Periodicita = TranscodificaPeriodicita(rA("PERASS").ToString),
                             .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                    End If
                    'PIANTONI
                    If Not String.IsNullOrWhiteSpace(rA("CANPIA").ToString) AndAlso rA("CANPIA") > 0 Then
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
                            .ValUnit = rA("CANPIA"),
                            .ValUnitIstat = rA("CANPIA"),
                            .DataUltRivIstat = sDataNulla,
                            .Franchigia = rA("FRAPIA"),
                            .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                            .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                            .DataFineElaborazione = sDataNulla,
                            .DataProssimaFatt = nextDataFatt,
                            .Periodicita = TranscodificaPeriodicita(rA("PERPIA").ToString),
                             .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId
                            }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDistintaServAgg.Add(rOrdContrattoAgg)
                    End If
                    'VIDEO ISP.
                    If Not String.IsNullOrWhiteSpace(rA("CANVID").ToString) AndAlso rA("CANVID") > 0 Then
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
                             .ValUnit = rA("CANVID"),
                             .ValUnitIstat = rA("CANVID"),
                             .DataUltRivIstat = sDataNulla,
                             .Franchigia = rA("FRAVID"),
                             .TipoRigaServizio = ServiziAggiuntivi.Frequenza,
                             .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                             .DataFineElaborazione = sDataNulla,
                             .DataProssimaFatt = nextDataFatt,
                             .Periodicita = TranscodificaPeriodicita(rA("PERVID").ToString),
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
                    Dim impATecno_ALL1 As Double
                    Double.TryParse(rA("CANONE_ALL1").ToString, impATecno_ALL1)
                    If impATecno_ALL1 <> 0 Then
                        iLineDistinta += 1
                        Dim rOrdDistintaAll1 As New AllordCliContrattoDistinta With {
                            .IdOrdCli = rifDistinta.IdOrdCli,
                            .Line = iLineDistinta,
                            .RifLinea = iLineContratto,
                            .Servizio = TECNO_ALL1,
                            .Descrizione = tecno_All1Descri,
                            .Qta = qtaOrdine,
                            .Um = "",
                            .ValUnit = Math.Round(impATecno_ALL1, 2),
                            .ValUnitIstat = Math.Round(impATecno_ALL1, 2),
                            .DataUltRivIstat = Valid_Data(rA("DTVARCAN").ToString),
                            .TipoRigaServizio = rifDistinta.TipoRigaServizio,
                            .DataDecorrenza = Valid_Data(rA("DTDECORR").ToString),
                            .DataFineElaborazione = sDataNulla,
                            .DataProssimaFatt = If(.TipoRigaServizio.Equals("12A"), nextDataFattAnnAnt, If(.TipoRigaServizio.Equals("12P"), nextDataFattAnnPost, nextDataFatt)),
                            .CodIntegra = "",
                            .CodContratto = rA("CONTRATTO").ToString,
                            .Tbcreated = Now,
                            .Tbmodified = Now,
                            .TbcreatedId = sLoginId,
                            .TbmodifiedId = sLoginId,
                            .Nota = "",
                            .CdC = rA("CDC_ALL1").ToString,
                            .Impianto = sito,
                            .SubLineServAgg = 0
                         }
                        'Aggiungo la riga alla collection
                        efAllordCliContrattoDistinta.Add(rOrdDistintaAll1)
                        nrDistinteUNO += 1
                    End If
                    'Aggiorno Sub
                    rifContratto.SubLineDistinta = iLineDistinta

                    'Tipologie Servizio
                    If Not efAllordCliTipologiaServizi.Exists(Function(f) f.IdOrdCli.Equals(rifDistinta.IdOrdCli) AndAlso f.Tipologia.Equals(rA("TIPSERV").ToString)) Then
                        Dim rOrdTipologiaServizi As New AllordCliTipologiaServizi With {
                                 .IdOrdCli = rifDistinta.IdOrdCli,
                                 .Tipologia = rA("TIPSERV").ToString,
                                 .Tbcreated = Now,
                                 .Tbmodified = Now,
                                 .TbcreatedId = sLoginId,
                                 .TbmodifiedId = sLoginId
                                 }
                        'Aggiungo la riga alla collection
                        efAllordCliTipologiaServizi.Add(rOrdTipologiaServizi)
                    End If

                    'Padre Figlio
                    If Not String.IsNullOrWhiteSpace(rA("CONTRSUCC").ToString) Then
                        If Not efAllordFiglio.Exists(Function(f) f.IdOrdCli.Equals(rifDistinta.IdOrdCli AndAlso f.NrOrdFiglio.Equals(rA("CONTRSUCC").ToString))) Then
                            Dim rOrdFiglio As New AllordFiglio With {
                                .IdOrdCli = saleOrdId,
                                .IdOrdFiglio = 0,
                                .NrOrdFiglio = rA("CONTRSUCC").ToString,
                                .Tbcreated = Now,
                                .Tbmodified = Now,
                                .TbcreatedId = sLoginId,
                                .TbmodifiedId = sLoginId
                                 }
                            efAllordFiglio.Add(rOrdFiglio)
                        End If
                    End If
                    If Not String.IsNullOrWhiteSpace(rA("CONTRPREC").ToString) Then
                        If Not efAllordPadre.Exists(Function(f) f.IdOrdCli.Equals(rifDistinta.IdOrdCli AndAlso f.NrOrdPadre.Equals(rA("CONTRPREC").ToString))) Then
                            Dim rOrdPadre As New AllordPadre With {
                               .IdOrdCli = saleOrdId,
                               .IdOrdPadre = 0,
                               .NrOrdPadre = rA("CONTRPREC").ToString,
                               .Tbcreated = Now,
                               .Tbmodified = Now,
                               .TbcreatedId = sLoginId,
                               .TbmodifiedId = sLoginId
                                }
                            efAllordPadre.Add(rOrdPadre)
                        End If
                    End If
                Catch ex As Exception
                    Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                    mb.ShowDialog()
                    Continue For
                End Try
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
#Region "Adeguamenti post import"
            'Contatori sub
            For Each o In efMaSaleOrd
                Dim rifContratto As List(Of AllordCliContratto) = efAllordCliContratto.FindAll(Function(f) f.IdOrdCli = o.SaleOrdId)
                o.SubIdContratto = rifContratto.Count
            Next
            For Each c In efAllordCliContratto
                Dim listImpianto As List(Of String) = efAllordCliContrattoDistinta.FindAll(Function(f) f.IdOrdCli = c.IdOrdCli AndAlso f.RifLinea = c.Line).Select(Function(f) f.Impianto).Distinct().ToList
                If listImpianto.Count = 1 Then
                    c.Impianto = listImpianto.First
                    c.MultiImpianto = "0"
                Else
                    c.Impianto = ""
                    c.MultiImpianto = "1"
                End If
            Next
#End Region
            DisposeTables()

            'Scrivo i LOG
            If esclusi.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Esclusi ---" & Environment.NewLine & esclusi.ToString)
                FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrate esclusioni : Controllare file di Log")
            End If
            If errori.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Errori ---" & Environment.NewLine & errori.ToString)
                FLogin.lstStatoConnessione.Items.Add("ATTENZIONE ! Riscontrati errori : Controllare file di Log")
            End If
            If avvisi.Length > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & " --- Avvisi ---" & Environment.NewLine & avvisi.ToString)
                FLogin.lstStatoConnessione.Items.Add("Presenti avvisi : Controllare file di Log")
            End If
        Catch ex As Exception
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try
    End Sub

    Private Function CalcolaScadenzaFutura(rOrdAcc As AllordCliAcc) As Date
        Dim d As Date = rOrdAcc.DataDecorrenza.Value
        While d < Today
            d = d.AddMonths(rOrdAcc.MesiDurata)
        End While
        Return d.AddDays(-1)
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
                    EditTestoBarra("Salvataggio: Inserimento righe attività contratto ")
                    If efAllordCliAttivita.Any Then
                        Dim t = efAllordCliAttivita.Count
                        Dim cfgOrdConAtt As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0,
                                    .CalculateStats = True,
                                    .BatchSize = If(t < 5000, 0, t / 10),
                                    .NotifyAfter = t / 10
                                    }
                        OrdiniCntx.BulkInsertOrUpdate(efAllordCliAttivita, cfgOrdConAtt, Function(d) d)
                        Debug.Print("ALLOrdCliAttivita Ins:" & cfgOrdConAtt.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConAtt.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("ALLOrdCliAttivita Ins:" & cfgOrdConAtt.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConAtt.StatsInfo.StatsNumberUpdated.ToString)
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
                        'Check di numeri
                        Debug.Print("Righe file Excel: " & dtContratti.Rows.Count.ToString)
                        bulkMessage.AppendLine("Righe file Excel: " & dtContratti.Rows.Count.ToString)
                        Debug.Print("Righe distinta: " & nrDistinte.ToString)
                        bulkMessage.AppendLine("Righe distinta: " & nrDistinte.ToString)
                        Debug.Print("Righe distinta UNO " & nrDistinteUNO.ToString)
                        bulkMessage.AppendLine("Righe distinta UNO " & nrDistinteUNO.ToString)
                        Debug.Print("Discrepanze " & cfgOrdConDist.StatsInfo.StatsNumberInserted - (nrDistinte + nrDistinteUNO).ToString)
                        bulkMessage.AppendLine("Discrepanze " & cfgOrdConDist.StatsInfo.StatsNumberInserted - (nrDistinte + nrDistinteUNO).ToString)
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
                        Debug.Print("ALLOrdCliContratto_Distinta_ServAgg Ins:" & cfgOrdConServAgg.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConServAgg.StatsInfo.StatsNumberUpdated.ToString)
                        bulkMessage.AppendLine("ALLOrdCliContratto_Distinta_ServAgg Ins:" & cfgOrdConServAgg.StatsInfo.StatsNumberInserted.ToString & " Agg:" & cfgOrdConServAgg.StatsInfo.StatsNumberUpdated.ToString)
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
                    If ex.Message.Contains("Il client per la copia bulk ha inviato una lunghezza di colonna non valida per il colid") Then
                        'Milano ha dato un errore: Ciclo su ogni riga per trovarla
                        Dim cfgOrd As New BulkConfig With {
                                    .SqlBulkCopyOptions = SqlBulkCopyOptions.KeepNulls,
                                    .BulkCopyTimeout = 0
                                    }
                        Try
                            bulkTrans.Rollback()
                            bulkTrans.Dispose()

                            Using bulkTrans1 = OrdiniCntx.Database.BeginTransaction

                                For Each o In efMaSaleOrd
                                    Dim Olist As New List(Of MaSaleOrd)
                                    Olist.Add(o)
                                    Debug.Print(o.InternalOrdNo & " " & o.Customer)
                                    OrdiniCntx.BulkInsertOrUpdate(Olist, cfgOrd, Function(d) d)
                                Next
                            End Using
                        Catch exxx As Exception

                        End Try
                        Dim pattern As String = "\d+"
                        Dim match As Match = Regex.Match(ex.Message.ToString(), pattern)
                        Dim index = Convert.ToInt32(match.Value) - 1

                        Dim fi As System.Reflection.FieldInfo = GetType(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic Or BindingFlags.Instance)
                        Dim sortedColumns = fi.GetValue(OrdiniCntx)
                        Dim items = CType(sortedColumns.[GetType]().GetField("_items", BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(sortedColumns), Object())
                        Dim itemdata As FieldInfo = items(index).[GetType]().GetField("_metadata", BindingFlags.NonPublic Or BindingFlags.Instance)
                        Dim metadata = itemdata.GetValue(items(index))

                        Dim column = metadata.[GetType]().GetField("column", BindingFlags.[Public] Or BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(metadata)
                        Dim length = metadata.[GetType]().GetField("length", BindingFlags.[Public] Or BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(metadata)
                        ' Throw New DataFormatException(String.Format("Column: {0} contains data with a length greater than: {1}", column, length));

                    End If
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

    Private Function TranscodificaQuantita(ByVal codice As String) As Double
        Dim esito As Double
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
    Private Function TranscodificaPeriodicita(ByVal codice As String) As Integer
        Dim esito As Integer
        Select Case codice.ToUpper
            Case "0A", "0P"
                esito = Periodo.Annuale
            Case "1A", "1P"
                esito = Periodo.Mensile
            Case "2A", "2P"
                esito = Periodo.Bimestrale
            Case "3A", "3P"
                esito = Periodo.Trimestrale
            Case "4A", "4P"
                esito = Periodo.Quadrimestrale
            Case "6A", "6P"
                esito = Periodo.Semestrale
            Case Else
                esito = Periodo.Nessuno
        End Select
        Return esito
    End Function
    Private Function TranscodificaFiliale(ByVal codice As String) As String
        Dim esito As String
        Select Case codice
            Case "01"
                esito = "TO"    'TORINO
            Case "02"
                esito = "MI"    'MILANO
            Case "03"
                esito = "AT"    'ASTI
            Case "04"
                esito = "AO"    'AOSTA
            Case "05"
                esito = "NO"    'NOVARA
            Case "08"
                esito = "BI"    'VERCELLI/BIELLA
            Case "09"
                esito = "VA"    'VARESE
            Case "11"
                esito = "CN"    'CUNEO
            Case "12"
                esito = "AL"    'ALESSANDRIA
            Case Else
                esito = ""
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
        Public ClienteACG As String
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
            Contratto = ""
            ClienteFox = ""
            ClienteACG = ""
            ClienteMago = ""
            RaggruppamentoFattura = ""
            RigheContratto = 0
            CondPag = ""
            CodIva = ""
            UMRCode = ""
            CdC = ""
            OrderNo = ""
            Vettore = ""
            Agente = ""
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
        Public ClienteContratto As String
        Public GruppoDistinta As String
        Public RigheDistinta As Integer
        Public Sospeso As Boolean

        Public Sub New()
            Me.ClienteFox = ""
            Me.ClienteMago = ""
            Me.ClienteContratto = ""
            Me.GruppoDistinta = ""
            Me.RigheDistinta = 0
            Me.Sospeso = False
        End Sub
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

