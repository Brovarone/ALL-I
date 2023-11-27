Imports EFMago.Models

Public Class CurOrd
    Public Property SaleOrdId As Integer
    Public Property LastLine As Integer
    Public Property LastPosition As Integer
    Public Property LastSubId As Integer
    Public Property CurrentLastLine As Integer
    Public Property CurrentLastPosition As Integer
    Public Property CurrentLastSubId As Integer
    Public Property Cliente As String
    Public Property OrdDate As Date
    Public Property OrdNo As String
    ''' <summary>
    ''' Indica solo che e' presente una data. Il controllo va poi fatto sulla riga
    ''' </summary>
    ''' <returns></returns>
    Public Property HaScadenzaFissa As Boolean
    Public Property DataScadenzaFissa As Date
    Public Property HaDataCessazione As Boolean
    Public Property DataCessazione As Date
    Public Property Commessa As String
    Public Property CdC As String
    Public Property CIG As String
    Public Property CUP As String
    ''' <summary>
    ''' Indica se e' presente una delle due date ( Cessazione o Scadenza Fissa) <br />
    ''' Non e' detto che sia raggiunta
    ''' </summary>
    ''' <returns></returns>
    Public Property EsisteDataScadenza As Boolean
    Public Sub New()
        Dim d As Date = OnlyDate(Now)
        SaleOrdId = 0
        LastLine = 0
        LastPosition = 0
        LastSubId = 0
        CurrentLastLine = 0
        CurrentLastPosition = 0
        CurrentLastSubId = 0
        Cliente = String.Empty
        OrdDate = d
        OrdNo = String.Empty
        HaScadenzaFissa = False
        DataScadenzaFissa = d
        HaDataCessazione = False
        DataCessazione = d
        Commessa = String.Empty
        CdC = String.Empty
        CIG = String.Empty
        CUP = String.Empty
        EsisteDataScadenza = False
    End Sub
    Public Sub New(ByVal o As MaSaleOrd)

        SaleOrdId = o.SaleOrdId
        LastLine = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Line), 0)
        LastPosition = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.Position), 0)
        LastSubId = If(o.MaSaleOrdDetails.Any, o.MaSaleOrdDetails.Max(Function(m) m.SubId), 0)
        CurrentLastLine = LastLine
        CurrentLastPosition = LastPosition
        CurrentLastSubId = LastSubId
        Cliente = o.Customer
        OrdDate = o.OrderDate
        OrdNo = o.InternalOrdNo
        DataScadenzaFissa = If(o.ALLOrdCliAcc Is Nothing, New DateTime(1799, 12, 31), o.ALLOrdCliAcc.DataScadenzaFissa)
        HaScadenzaFissa = DataScadenzaFissa <> sDataNulla ' True
        DataCessazione = If(o.ALLOrdCliAcc Is Nothing, New DateTime(1799, 12, 31), o.ALLOrdCliAcc.DataCessazione)
        HaDataCessazione = DataCessazione <> sDataNulla ' True
        Commessa = o.Job
        CdC = o.CostCenter
        CIG = o.ContractCode
        CUP = o.ProjectCode
        EsisteDataScadenza = DataCessazione <> sDataNulla OrElse DataScadenzaFissa <> sDataNulla
    End Sub
End Class
