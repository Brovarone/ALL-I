Imports System.Text
Public Class FiltriOrdiniConsuntivo
    Public Property FromLogDate As Date
    Public Property ToLogDate As Date
    Public Property SingoloOrdine As Boolean
    Public Property NrMese As String
    Public Property DataFattura As Date
    Public Property SingoloCliente As Boolean
    Public Property Cliente As String
    Public Property SingolaFiliale As Boolean
    Public Property Filiale As String
    Public Property SingolaPriorita As Boolean
    Public Property Priorita As String
    Public Property Riassegna As Boolean
    Public Property AskFilter As Boolean
    Public Property LogFiltri As StringBuilder

    ' Costruttore
    Public Sub New()
        NrMese = String.Empty
        Cliente = String.Empty
        Filiale = String.Empty
        Priorita = String.Empty
        LogFiltri = New StringBuilder()

    End Sub

    ' Metodo per inizializzare i campi dai valori del form
    Public Sub InizializzaFiltriDaForm(ff As FAskFiltriOrdiniConsuntivo)
        AskFilter = ff.ChkNoFilter.Checked
        FromLogDate = ff.firstLogDate.Value.Date '.AddSeconds(1)
        ToLogDate = ff.lastLogDate.Value.Date.AddDays(1).AddSeconds(-1)
        NrMese = ff.CmbMonth.SelectedIndex + 1
        ' SingoloOrdine = ff.ChkNrOrdine.Checked
        'SingoloCliente = ff.ChkCliente.Checked
        'Cliente = ff.TxtOrdCliente.Text
        SingolaFiliale = ff.ChkFiliale.Checked
        Filiale = ff.TxtOrdFiliale.Text
        'Priorita = ff.ChkPriorita.Checked
        'Priorita_String = ff.TxtordPriorita.Text
        DataFattura = ff.DtaFatt.Value.Date 'Data giorno di fatturazione
        If ff.RadOnlyCheck.Checked OrElse ff.RadCheckAndFatt.Checked Then
            Riassegna = ff.ChkRiassegna.Checked
        End If
        CostruisciFiltri()
    End Sub

    ' Metodo per costruire la stringa dei filtri
    Private Sub CostruisciFiltri()
        LogFiltri.Clear()
        LogFiltri.AppendLine(" --- Filtri ---")
        LogFiltri.AppendLine("Dal " & FromLogDate.ToShortDateString & " al " & ToLogDate.ToShortDateString)
        LogFiltri.AppendLine("Mese : " & NrMese)
        LogFiltri.AppendLine("Cliente : " & If(SingoloCliente, Cliente, "TUTTI"))
        LogFiltri.AppendLine("Filiale : " & If(SingolaFiliale, Filiale, "TUTTI"))
        LogFiltri.AppendLine("Priorità : " & If(SingolaPriorita, Priorita, "TUTTI"))
        'My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & filtri.ToString)
    End Sub
End Class
