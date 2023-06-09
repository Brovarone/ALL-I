Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Imports EFMago.Models
Imports Microsoft.EntityFrameworkCore
Imports EFCore.BulkExtensions
Imports ALLSystemTools.SqlTools


Module ContrattiFox
    'Gestisce l'import dei contratti da FoxPro a Mago
    Private ds As DataSet
    Private OrdiniCntx As OrdiniContext

    'Collection Globali per aggiornamento unico
    'Creo le entities che usero' poi con BulkInsert
    Private efMaSaleOrd As New List(Of MaSaleOrd)
    'Private efMaSaleOrdDetails As New List(Of MaSaleOrdDetails)
    Private efMaSaleOrdSummary As New List(Of MaSaleOrdSummary)
    Private efAllordCliAcc As New List(Of AllordCliAcc)
    Private efAllordCliContratto As New List(Of AllordCliContratto)
    Private efAllordCliDescrizioni As New List(Of AllordCliDescrizioni)
    Private efAllordCliTipologiaServizi As New List(Of AllordCliTipologiaServizi)
    Private efMaCustSupp As New List(Of MaCustSupp)
    Private efMaCustSuppBranches As New List(Of MaCustSuppBranches)
    Private efMaCustSuppCustomerOptions As New List(Of MaCustSuppCustomerOptions)
    Private efMaCustSuppNaturalPerson As New List(Of MaCustSuppNaturalPerson)
    Private efMaDeclarationOfIntent As New List(Of MaDeclarationOfIntent)
    Private efMaSddmandate As New List(Of MaSddmandate)

    ''' <summary>
    ''' Importo ContrattiFox su Mago tramite LINQ e OrdContext
    ''' </summary>
    ''' <returns></returns>
    Public Function ImportaContrattiFox(dsFox As List(Of DataSet)) As Boolean
        GeneraDataset(dsFox)
        GeneraRelazioni()
        ConnettiContesto()
        ScriviClientiNuovi()

        LeggiOrdiniEsistenti()

        ScriviOrdini()
        Return True
    End Function

    Private Sub GeneraDataset(dsFox As List(Of DataSet))
        ds = New DataSet
        For Each d As DataSet In dsFox
            ds.Tables.Add(d.Tables(0).Copy)
        Next
    End Sub
    ''' <summary>
    ''' Crea solo le relazioni 1-n
    ''' </summary>
    Private Sub GeneraRelazioni()

        ds.Relations.Add("Ordini Clienti", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_ONTRORD").Columns("CLIENTE"))
        ds.Relations.Add("Ordini Clienti Gruppo Testa", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("CLIENTE"))
        ds.Relations.Add("Ordini Clienti Gruppo Dettaglio", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("CLIENTE"))
        ds.Relations.Add("Ordini Raggruppati ", {ds.Tables("_AGRFATT").Columns("CLIENTE"), ds.Tables("_AGRFATT").Columns("RAGRFATT")}, {ds.Tables("_AGRFATD").Columns("CLIENTE"), ds.Tables("_AGRFATD").Columns("RAGRFATT")})
        ds.Relations.Add("RID", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_RID").Columns("CLIENTE"))
        ds.Relations.Add("ESENTI", ds.Tables("_LIENORD").Columns("CLIENTE"), ds.Tables("_SENTIIV").Columns("CLIENTE"))
    End Sub
    Private Sub ConnettiContesto()
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
            Dim c As MaCustSupp = OrdiniCntx.MaCustSupp.Find(CustSuppType.Cliente, r.Item("ACGCOD").ToString)
            If c Is Nothing Then
                'todo: completare inserimento nuovo cliente da CLIENORD ( vedere su import fatture ftpa300
                Dim codice As String = r.Item("ACGCODE").ToString
                Debug.Print("Nuovo Cliente:(" & codice & ") ")

                dvCliEle.RowFilter = "CLIENTE='" & codice & "'"
                dvCliRid.RowFilter = "CLIENTE='" & codice & "'"
                dvCliEse.RowFilter = "CLIENTE='" & codice & "'"

#Region "Testa"
                Dim rCli As New MaCustSupp With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = codice
                                    }
                'Aggiungo la riga alla collection
                efMaCustSupp.Add(rCli)

#End Region
#Region "Options - Altri dati"
                Dim rCliOpt As New MaCustSuppCustomerOptions With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .Customer = codice
                                    }
                'Aggiungo la riga alla collection
                efMaCustSuppCustomerOptions.Add(rCliOpt)

#End Region
#Region "Sedi"
                Dim rCliBr As New MaCustSuppBranches With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = codice
                                    }
                'Aggiungo la riga alla collection
                efMaCustSuppBranches.Add(rCliBr)
#End Region
#Region "Natural Person"
                Dim rCliNatPer As New MaCustSuppNaturalPerson With {
                                 .CustSuppType = CustSuppType.Cliente,
                                 .CustSupp = codice
                                 }
                'Aggiungo la riga alla collection
                efMaCustSuppNaturalPerson.Add(rCliNatPer)
#End Region
#Region "Dichiarazioni di Intento"
                If dvCliEle.Count > 0 Then
                    If dvCliEle.Count = 1 Then
                        Dim rIntento As New MaDeclarationOfIntent With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = codice
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
                                    .Customer = codice
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
        Debug.Print(q.Count)
        'q.ToList
    End Sub
    Private Sub ScriviOrdini()
#Region "Variabili"

        Dim defVendite = (From dv In OrdiniCntx.MaUserDefaultSales.ToList Select dv).FirstOrDefault
        ' Dim defContabili = (From dc In OrdiniCntx.MaAccountingDefaults.ToList Select dc).FirstOrDefault
        Dim defIva = (From dc In OrdiniCntx.MaTaxCodesDefaults.ToList Select dc).FirstOrDefault
        Dim codiciIva = (From c In OrdiniCntx.MaTaxCodes.ToList Select c)

        Dim sDefContropartita As String = defVendite.ServicesSalesAccount
        Dim sDefCodIva As String = defIva.TaxCode
        Dim dDefPercIva As Double = Math.Round(codiciIva.FirstOrDefault(Function(tax) tax.TaxCode = sDefCodIva).Perc.Value, decPerc)
#End Region
#Region "Inizializzazione"
        'Resetto alcune cose 
        Dim iNewRowsCount As Integer = 0
        Dim isNewRows As Boolean = False    ' Indica se ci sono righe contratto che vengono fatturate e quindi inserite nelle righe
        Dim isUpdateRows As Boolean = False ' Indica se ci sono righe contratto che vengono aggiorate
        'Inizializzo alcuni valori
        'Dim curLastLine As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Line), 0)
        'Dim curLastPosition As Integer = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Position), 0)
        Dim iNrRigheNota As Integer = 0
        Dim iNrRigheAValore As Integer = 0
#End Region

        Dim dtContratti As DataTable = ds.Tables("_ONTRORD")
        Dim dtRaggTeste As DataTable = ds.Tables("_AGRFATT")
        Dim dtRaggDett As DataTable = ds.Tables("_AGRFATD")
        Dim dtTabelle As DataTable = ds.Tables("_EWTAB")
        Dim dvContratti = New DataView(dtContratti)
        Dim dvRaggTeste = New DataView(dtRaggTeste)
        Dim dvRaggDett = New DataView(dtRaggDett)
        Dim dvTabelle = New DataView(dtTabelle)

        'Parto dai dati del dettaglio raggruppamento ( che e' 1-1 con _ONTRORD)
        'NO
        'non va bene
        '
        'in modo da metterli tutti in un unico Ordine di Mago a parità di RAGRFATT
        'H80064 HA DIVERSI RAGGRUPPAMENTI, SICURITALIA, MA NON HANNO COSE STRANE SONO SOLO CONTRATTI LOGICI DIVERSEI ( FORSE)
        'FORSE NO, SI VEDA I CONTRATTI 1204 CHE HANNO COMUNQUE 2 GRUPPI DI FATTURA LA 22,23 E 25
        '
        'In fase di import Posso unire i contratti in uno solo solo se hanno stesso luogo / Impianto!!!
        'Ma ad esempio Panattaro già non passa in quanto PRAGSOC e' diversa 
        For Each r As DataRow In dtRaggDett.Rows
            ' Dim o As MaSaleOrd = OrdiniCntx.MaSaleOrd.Find(r.Item("CONTRATTO").ToString)

            'todo: completare inserimento nuovo ORDINE
            Dim codice As String = r.Item("ACGCODE").ToString
                Debug.Print("Nuovo Cliente:(" & codice & ") ")

                dvContratti.RowFilter = "CLIENTE='" & codice & "'"
                dvRaggTeste.RowFilter = "CLIENTE='" & codice & "'"
                dvRaggDett.RowFilter = "CLIENTE='" & codice & "'"

#Region "Testa"
                Dim rOrd As New MaSaleOrd With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .Customer = codice
                                    }
                'Aggiungo la riga alla collection
                efMaSaleOrd.Add(rOrd)

#End Region
#Region "All OrdiniAcc"
                Dim rOrdAcc As New AllordCliAcc With {
                                    .IdOrdCli = 11111
                                    }
                'Aggiungo la riga alla collection
                efAllordCliAcc.Add(rOrdAcc)

#End Region
#Region "All Ordini Contratto"
                Dim rOrdContratto As New AllordCliContratto With {
                                    .IdOrdCli = 1111
                                    }
                'Aggiungo la riga alla collection
                efAllordCliContratto.Add(rOrdContratto)
#End Region
#Region "All Ordini Descrizioni"
                Dim rOrdDescri As New AllordCliDescrizioni With {
                                 .IdOrdCli = 1111
                                 }
                'Aggiungo la riga alla collection
                efAllordCliDescrizioni.Add(rOrdDescri)
#End Region
#Region "All Ordini Tipologia Servizi"
                Dim rordTipologiaServizi As New AllordCliTipologiaServizi With {
                                 .IdOrdCli = 1111
                                 }
                'Aggiungo la riga alla collection
                efAllordCliTipologiaServizi.Add(rordTipologiaServizi)
#End Region
#Region "Mandati"
                Dim rMandato As New MaSddmandate With {
                                 .Customer = codice
                                 }
                'Aggiungo la riga alla collection
                efMaSddmandate.Add(rMandato)
#End Region

        Next
#Region "Dispose"
        dvContratti.Dispose()
        dvRaggTeste.Dispose()
        dvRaggDett.Dispose()
        dvTabelle.Dispose()
        dtContratti.Dispose()
        dtRaggTeste.Dispose()
        dtRaggDett.Dispose()
        dtTabelle.Dispose()
#End Region




    End Sub
End Module
