Imports System.Text
Public Class FiltriOrdini
    Public Property FiltroDateOrdini As Boolean
    Public Property FromOrdDate As Date
    Public Property FromOrdDate_String As String
    Public Property ToOrdDate As Date
    Public Property ToOrdDate_String As String
    Public Property SingoloOrdine As Boolean
    Public Property NrOrd As String
    Public Property SingoloCliente As Boolean
    Public Property Cliente As String
    Public Property SingolaFiliale As Boolean
    Public Property Filiale As String
    Public Property SingolaPriorita As Boolean
    Public Property Priorita As String
    Public Property DataFattDa As Date
    Public Property DataFattDa_String As String
    Public Property DataFattA As Date
    Public Property DataFattA_String As String
    Public Property Tipo_Canoni As Boolean
    Public Property Tipo_ServiziAggiuntivi As Boolean
    Public Property Periodo_Tutti As Boolean
    Public Property Periodo_Annuali As Boolean
    Public Property Periodo_Semestrali As Boolean
    Public Property Periodo_Quadrimestrali As Boolean
    Public Property Periodo_Trimestrali As Boolean
    Public Property Periodo_Bimestrali As Boolean
    Public Property Periodo_Mensili As Boolean
    Public Property Periodi As Boolean()
    Public Property LogFiltri As StringBuilder
    Public Property Divisione_Tutti As Boolean
    Public Property Divisione_Tecnologia As Boolean
    Public Property Divisione_Vigilanza As Boolean
    'ISTAT
    Public Property IsIstat As Boolean
    Public Property DataDecorrenza As Date
    Public Property PercIstat As Double
    Public Property CausaleAttivita As String
    Public Property AnnoAdeguamento As Integer
    Public Property TestoFattura As String

    ' Costruttore
    Public Sub New()
        FromOrdDate_String = FromOrdDate.ToShortDateString
        ToOrdDate_String = ToOrdDate.ToShortDateString
        DataFattDa_String = DataFattDa.ToShortDateString
        DataFattA_String = DataFattA.ToShortDateString
        NrOrd = String.Empty
        Cliente = String.Empty
        Filiale = String.Empty
        Priorita = String.Empty
        CausaleAttivita = String.Empty
        TestoFattura = String.Empty
        LogFiltri = New StringBuilder()
        ReDim Periodi(6)
    End Sub

    ' Metodo per inizializzare i campi dai valori del form
    Public Sub InizializzaDaForm(ff As FAskFiltriOrdini)
        FiltroDateOrdini = ff.RadDalAl.Checked
        FromOrdDate = OnlyDate(ff.DtaOrdineDA.Value)
        ToOrdDate = OnlyDate(ff.DtaOrdineA.Value)
        SingoloOrdine = ff.ChkNrOrdine.Checked
        NrOrd = ff.TxtNrOrdine.Text
        SingoloCliente = ff.ChkCliente.Checked
        Cliente = ff.TxtOrdCliente.Text
        SingolaFiliale = ff.ChkFiliale.Checked
        Filiale = ff.TxtOrdFiliale.Text
        SingolaPriorita = ff.ChkPriorita.Checked
        Priorita = ff.TxtordPriorita.Text
        DataFattDa = OnlyDate(ff.DtaFattDa.Value)
        DataFattA = OnlyDate(ff.DtaFattA.Value)
        Tipo_Canoni = ff.RadioTipoCanoni.Checked
        Tipo_ServiziAggiuntivi = ff.RadioTipoServAgg.Checked
        Periodo_Tutti = ff.ChkP_Tutti.Checked
        Periodo_Annuali = ff.ChkP_Annuali.Checked
        Periodo_Semestrali = ff.ChkP_Semestrali.Checked
        Periodo_Quadrimestrali = ff.ChkP_Quadrimestrali.Checked
        Periodo_Trimestrali = ff.ChkP_Trimestrali.Checked
        Periodo_Bimestrali = ff.ChkP_Bimestrali.Checked
        Periodo_Mensili = ff.ChkP_Mensili.Checked
        Periodi(0) = Periodo_Tutti
        Periodi(1) = Periodo_Mensili
        Periodi(2) = Periodo_Bimestrali
        Periodi(3) = Periodo_Trimestrali
        Periodi(4) = Periodo_Quadrimestrali
        Periodi(5) = Periodo_Semestrali
        Periodi(6) = Periodo_Annuali
        FromOrdDate_String = FromOrdDate.ToShortDateString
        ToOrdDate_String = ToOrdDate.ToShortDateString
        DataFattDa_String = DataFattDa.ToShortDateString
        DataFattA_String = DataFattA.ToShortDateString
        Divisione_Tutti = ff.RadioDivTutti.Checked
        Divisione_Tecnologia = ff.RadioDivTecnologia.Checked
        Divisione_Vigilanza = ff.RadioDivVigilanza.Checked
        'ISTAT
        DataDecorrenza = OnlyDate(ff.DtaDecorrenza.Value) 'Data giorno di fatturazione
        CausaleAttivita = ff.TxtIstatAttivita.Text
        AnnoAdeguamento = CInt(ff.TxtAnnoAdeguamento.Text)
        TestoFattura = ff.TxtIstatTesto.Text
        isIstat = ff.IsIstat
        'Double.TryParse(ff.TxtPercIstat.Text, PercIstat)
        CostruisciFiltri()
    End Sub

    ' Metodo per costruire la stringa dei filtri
    Private Sub CostruisciFiltri()
        LogFiltri.Clear()
        LogFiltri.AppendLine(" --- Filtri ---")
        LogFiltri.AppendLine(If(FiltroDateOrdini, "Dal " & FromOrdDate.ToShortDateString & " al " & ToOrdDate.ToShortDateString, "Fino al " & ToOrdDate.ToShortDateString))
        LogFiltri.AppendLine("Ordine : " & If(SingoloOrdine, NrOrd, "TUTTI"))
        LogFiltri.AppendLine("Cliente : " & If(SingoloCliente, Cliente, "TUTTI"))
        LogFiltri.AppendLine("Filiale : " & If(SingolaFiliale, Filiale, "TUTTI"))
        LogFiltri.AppendLine("Priorità : " & If(SingolaPriorita, Priorita, "TUTTI"))
        If isIstat Then
            LogFiltri.AppendLine("Data Decorrenza: " & DataDecorrenza.ToShortDateString)
            LogFiltri.AppendLine("Percentuale ISTAT: " & PercIstat.ToString)
            LogFiltri.AppendLine("Attività: " & CausaleAttivita)
            LogFiltri.AppendLine("Anno adeguamento: " & AnnoAdeguamento)
            LogFiltri.AppendLine("Testo: " & TestoFattura)
        Else
            If Tipo_Canoni Then
                LogFiltri.AppendLine("Tipo : Canoni")
                LogFiltri.AppendLine("Dalla data Fatt. :" & DataFattDa.ToShortDateString)
                LogFiltri.AppendLine("Alla data Fatt. :" & DataFattA.ToShortDateString)
            Else
                LogFiltri.AppendLine("Tipo : Servizi Aggiuntivi")
            End If
            If Periodo_Tutti Then
                LogFiltri.AppendLine("Periodo : Tutti")
            Else
                If Periodo_Annuali Then LogFiltri.AppendLine("Periodo : Annuali")
                If Periodo_Semestrali Then LogFiltri.AppendLine("Periodo : Semestrali")
                If Periodo_Quadrimestrali Then LogFiltri.AppendLine("Periodo : Quadrimestrali")
                If Periodo_Trimestrali Then LogFiltri.AppendLine("Periodo : Trimestrali")
                If Periodo_Bimestrali Then LogFiltri.AppendLine("Periodo : Bimestrali")
                If Periodo_Mensili Then LogFiltri.AppendLine("Periodo : Mensili")
            End If
        End If
        If Divisione_Tutti Then LogFiltri.AppendLine("Divisione : Tutti")
        If Divisione_Tecnologia Then LogFiltri.AppendLine("Divisione : Tecnologia")
        If Divisione_Vigilanza Then LogFiltri.AppendLine("Divisione : Vigilanza")

        'My.Application.Log.DefaultFileLogWriter.WriteLine(Environment.NewLine & filtri.ToString)
    End Sub
End Class
