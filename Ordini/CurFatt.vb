Imports EFMago.Models
Public Class CurFatt
    Public Property SaleDocId As Integer
    Public Property Cliente As MaCustSupp
    Public Property DataFattura As Date
    Public Property LastLine As Integer?
    Public Property LastSubId As Integer?
    Public Property CodCliente As String
    Public Property Pagamento As String
    Public Property SedeInvioMerce As String
    Public Property SedeInvioDocumenti As String
    Public Property SedePagamenti As String
    Public Property Contropartita As String
    Public Property CodIva As String
    Public Property PercIva As Double?
    Public Property Commessa As String
    Public Property CdC As String
    Public Property CIG As String
    Public Property CUP As String
    Public Property Area As String
    Public Property AreaManager As String
    Public Property SalesPerson As String
    Public Property LetteraCausalePagamento As String


    Public Sub New()
        Dim d As Date = OnlyDate(Now)
        SaleDocId = 0
        Cliente = Nothing
        DataFattura = d
        LastLine = 0
        LastSubId = 0
        CodCliente = String.Empty
        Pagamento = String.Empty
        SedeInvioMerce = String.Empty
        SedeInvioDocumenti = String.Empty
        SedePagamenti = String.Empty
        Contropartita = String.Empty
        CodIva = String.Empty
        PercIva = 0
        Commessa = String.Empty
        CdC = String.Empty
        CIG = String.Empty
        CUP = String.Empty
        Area = String.Empty
        AreaManager = String.Empty
        SalesPerson = String.Empty
        LetteraCausalePagamento = String.Empty
    End Sub
    Public Sub New(ByVal o As MaSaleOrd)
        Dim d As Date = OnlyDate(Now)
        SaleDocId = 0
        Cliente = Nothing
        DataFattura = d
        LastLine = 0
        LastSubId = 0
        CodCliente = o.InvoicingCustomer
        Pagamento = o.Payment
        SedeInvioMerce = o.ShipToAddress
        SedeInvioDocumenti = o.SendDocumentsTo
        SedePagamenti = o.PaymentAddress
        Contropartita = String.Empty
        CodIva = String.Empty
        PercIva = 0
        Commessa = o.Job
        CdC = o.CostCenter
        CIG = o.ContractCode
        CUP = o.ProjectCode
        Area = o.Area
        AreaManager = o.AreaManager
        SalesPerson = o.Salesperson
        LetteraCausalePagamento = o.ALLOrdCliFattEle.F2_1_1_5_4
    End Sub
End Class
