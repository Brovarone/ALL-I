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
    Private efMaSaleOrdDetails As New List(Of MaSaleOrdDetails)
    Private efMaSaleOrdSummary As New List(Of MaSaleOrdSummary)
    Private efAllordCliAcc As New List(Of AllordCliAcc)
    Private efAllordCliAttivita As New List(Of AllordCliAttivita)
    Private efAllordCliContratto As New List(Of AllordCliContratto)
    Private efMaCustSupp As New List(Of MaCustSupp)

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

        ScriviOrdini
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
    Private Sub ScriviClientiNuovi()
        Dim dtCli As DataTable = ds.Tables("_LIENORD")
        For Each r As DataRow In dtCli.Rows
            Dim c As MaCustSupp = OrdiniCntx.MaCustSupp.Find(CustSuppType.Cliente, r.Item("ACGCOD").ToString)
            If c Is Nothing Then
                'CREARE
                Dim codice As String = r.Item("ACGCODE").ToString

                Dim rCli As New MaCustSupp With {
                                    .CustSuppType = CustSuppType.Cliente,
                                    .CustSupp = ""
                                    }
                'Aggiungo la riga alla collection
                efMaCustSupp.Add(rCli)
                Debug.Print("Nuovo Cliente:(" & codice & ") ")
                ' debugging.AppendLine(" *Rifatt:" & rRif.Position.ToString & " " & aDaRif.Attivita)

            End If
        Next


        Dim efCli = From c In OrdiniCntx.MaCustSupp _
                    .Include(Function(o) o.MaCustSuppCustomerOptions) _
                    .Include(Function(br) br.MaCustSuppBranches) _
                    .Include(Function(np) np.MaCustSuppNaturalPerson) _
                    .Include(Function(nt) nt.MaCustSuppNotes) _
                    .ToList

        For Each r As DataRow In dtCli.Rows
            Dim S As String = r.Item("ACGCODE")
        Next
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

    End Sub
End Module
