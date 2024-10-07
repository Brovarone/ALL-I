Imports EFMago.Models
Imports ALLSystemTools.Ordini
Public Class CurFattRow
    Public Property SaleDocId As Integer
    Public Property IsOk As Boolean
    Public Property Line As Short
    Public Property Contropartita As String
    Public Property CodIva As String
    Public Property PercIva As Double?
    Public Property Commessa As String
    Public Property CdC As String
    Public Property Parent As CurFatt
    Public Property ContrattoFox As String
    Public Property CodiceIntegra As String
    Public Property NrCanoni As Double
    Public Property CanoniDataIn As Date
    Public Property CanoniDataFin As Date
    Public Property Impianto As String

    Public Sub New()
        Dim d As Date = OnlyDate(Now)
        SaleDocId = 0
        IsOk = True ' Usata anche per aggiornare data prossima fatturazione
        Line = 0
        NrCanoni = 0
        CanoniDataIn = d
        CanoniDataFin = d
        Contropartita = String.Empty
        CodIva = String.Empty
        PercIva = 0
        Commessa = String.Empty
        CdC = String.Empty
        ContrattoFox = String.Empty
        CodiceIntegra = String.Empty
        Impianto = String.Empty
    End Sub
    ''' <summary>
    ''' Popola la classe a partire da una riga contratto
    ''' </summary>
    ''' <param name="c"></param>
    Public Sub New(ByVal c As AllordCliContratto)
        Dim nextDate As Date = c.DataProssimaFatt
        Dim d As New DateTime(1799, 12, 31)

        SaleDocId = 0
        IsOk = True
        Line = c.Line
        NrCanoni = c.Qta
        CanoniDataIn = d
        CanoniDataFin = d
        Contropartita = String.Empty
        CodIva = String.Empty
        PercIva = 0
        Commessa = String.Empty
        CdC = String.Empty
        ContrattoFox = c.CodContratto
        CodiceIntegra = c.CodIntegra
        Impianto = String.Empty
    End Sub
    ''' <summary>
    ''' Popola la classe a partire da una riga di Servizio Aggiuntivo
    ''' per ora lavora male non usare
    ''' </summary>
    ''' <param name="s"></param>
    Public Sub New(ByVal s As AllordCliContrattoDistintaServAgg)
        Dim nextDate As Date = s.DataProssimaFatt
        Dim d As New DateTime(1799, 12, 31)

        SaleDocId = 0
        IsOk = True
        Line = 0
        NrCanoni = s.Qta
        CanoniDataIn = d
        CanoniDataFin = d
        Contropartita = String.Empty
        CodIva = String.Empty
        PercIva = 0
        Commessa = String.Empty
        CdC = String.Empty
        ContrattoFox = String.Empty
        CodiceIntegra = String.Empty
        Impianto = String.Empty
    End Sub
End Class
