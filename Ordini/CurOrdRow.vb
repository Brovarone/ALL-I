Imports EFMago.Models
Imports ALLSystemTools.Ordini
'Necessita di Ordini.vb
Public Class CurOrdRow
    Public Property IsOk As Boolean
    Public Property Line As Short
    Public Property Item As String
    Public Property Description As String
    Public Property UoM As String
    Public Property ValUnit As Double
    Public Property DataDecorrenza As Date
    Public Property DataProssimaFattura As Date
    Public Property DataPrevistaConsegna As Date
    Public Property DataConfermaConsegna As Date
    Public Property QtaOrdine As Double
    Public Property NrCanoniIniziale As Integer
    ''' <summary>
    ''' Iniziale = QtaOrdine <br />
    ''' Per Canoni e A Consumo riporta i Canoni calcolati dalle date considerando i periodi
    ''' </summary>
    ''' <returns></returns>
    Public Property QtaCorrente As Double
    ''' <summary>
    ''' Contiene la franchigia sui servizi a Consuntivo <br />
    ''' Le rate già fatturate nel caso di A Consumo
    ''' </summary>
    ''' <returns></returns>
    Public Property QtaFranchigia As Double
    ' Public Property NrCanoniCorrente As Integer
    Public Property QtaDaRifatturare As Double
    Public Property DaRifatturare As Boolean
    Public Property DataProssimaRifatturazione As Date
    Public Property CanoneFuoriRangeDate As Boolean
    Public Property QtaSospesa As Double
    Public Property SospesoDaAttivita As Boolean
    Public Property QtaAnnullata As Double
    ''' <summary>
    ''' Se True esiste un attività di annullamento, controllare le date
    ''' </summary>
    ''' <returns></returns>
    Public Property HaAnnullatoDaAttivita As Boolean
    Public Property DataCessazioneDaAttivita As Date
    Public Property CanoniDataIn As Date
    Public Property CanoniDataFin As Date
    Public Property PeriodoDataIn As Date
    Public Property PeriodoDataFin As Date
    Public Property IsCanone As Boolean
    Public Property IsConsuntivo As Boolean
    Public Property IsUnaTantum As Boolean
    Public Property IsAConsumo As Boolean
    Public Property IsContinuativo As Boolean
    ''' <summary>
    ''' Vale per righe attività di annullamento
    ''' </summary>
    ''' <returns></returns>
    Public Property PrecendementeCessato As Boolean
    ''' <summary>
    ''' Se True la data di Scadenza cessazione e' congrua con l'estrazione
    ''' </summary>
    ''' <returns></returns>
    Public Property HaDataCessazione As Boolean
    Public Property DataCessazione As Date
    ''' <summary>
    ''' Se True la data di Scadenza fissa e' congrua con l'estrazione
    ''' </summary>
    ''' <returns></returns>
    Public Property HaScadenzaFissa As Boolean
    Public Property DataScadenzaFissa As Date
    Public Property CodIva As String
    Public Property PercIva As Double
    Public Property Contropartita As String
    Public Property Parent As CurOrd
    Friend Property TipologiaServizio As TipologiaServizio

    Public Sub New()
        Dim d As Date = OnlyDate(Now)
        IsOk = True ' Usata anche per aggiornare data prossima fatturazione
        Line = 0
        Item = String.Empty
        Description = String.Empty
        UoM = String.Empty
        ValUnit = 0
        DataDecorrenza = d
        DataProssimaFattura = d
        DataPrevistaConsegna = d
        DataConfermaConsegna = d
        QtaOrdine = 0
        NrCanoniIniziale = 0
        QtaCorrente = 0
        QtaFranchigia = 0
        QtaDaRifatturare = 0
        DaRifatturare = False
        DataProssimaRifatturazione = d
        CanoneFuoriRangeDate = False
        QtaSospesa = 0
        SospesoDaAttivita = False
        QtaAnnullata = 0
        HaAnnullatoDaAttivita = False
        DataCessazioneDaAttivita = d
        CanoniDataIn = d
        CanoniDataFin = d
        PeriodoDataIn = d
        PeriodoDataFin = d
        IsCanone = False
        IsConsuntivo = False
        IsUnaTantum = False
        IsAConsumo = False
        IsContinuativo = False
        PrecendementeCessato = False
        DataCessazione = New DateTime(1799, 12, 31)
        DataScadenzaFissa = New DateTime(1799, 12, 31)
        Contropartita = String.Empty
        CodIva = String.Empty
        PercIva = 0
        TipologiaServizio = TipologiaServizio.Canone
    End Sub
    Public Sub New(ByVal c As AllordCliContratto)
        Dim nextDate As Date = c.DataProssimaFatt
        Dim d As New DateTime(1799, 12, 31)

        IsOk = True
        Line = c.Line
        Item = c.Servizio
        Description = c.Descrizione
        UoM = c.Um
        ValUnit = Math.Round(c.ValUnitIstat.Value, decValUnit)
        DataDecorrenza = c.DataDecorrenza
        DataProssimaFattura = nextDate
        DataPrevistaConsegna = nextDate
        DataConfermaConsegna = nextDate
        QtaOrdine = Math.Round(c.Qta.Value, decPerc)
        NrCanoniIniziale = 0
        QtaCorrente = Math.Round(c.Qta.Value, decPerc)
        QtaFranchigia = Math.Round(c.Franchigia.Value, decPerc)
        QtaDaRifatturare = 0
        DaRifatturare = False
        DataProssimaRifatturazione = d
        CanoneFuoriRangeDate = False
        QtaSospesa = 0
        SospesoDaAttivita = False
        QtaAnnullata = 0
        HaAnnullatoDaAttivita = False
        DataCessazioneDaAttivita = d
        CanoniDataIn = d
        CanoniDataFin = d
        PeriodoDataIn = d
        PeriodoDataFin = d
        TipologiaServizio = c.AlltipoRigaServizio.TipologiaServizio
        IsCanone = TipologiaServizio = TipologiaServizio.Canone
        IsConsuntivo = TipologiaServizio = TipologiaServizio.Consuntivo
        IsUnaTantum = TipologiaServizio = TipologiaServizio.UnaTantum
        IsAConsumo = TipologiaServizio = TipologiaServizio.AConsumo
        IsContinuativo = TipologiaServizio = TipologiaServizio.Continuativo
        PrecendementeCessato = False
        DataCessazione = d
        DataScadenzaFissa = d
        Contropartita = String.Empty
        CodIva = String.Empty
        PercIva = 0

        Dim iNrCanoni As Integer
        'Canoni e valori a Consumo seguono il corso delle cadenzepertanto considero i mesi
        If IsCanone OrElse IsAConsumo OrElse IsContinuativo Then
            If IsContinuativo Then
                If IsContinuativo Then iNrCanoni = 1
            Else
                Select Case c.AlltipoRigaServizio.Periodicita
                    Case Periodo.Annuale
                        iNrCanoni = 12
                    Case Periodo.Semestrale
                        iNrCanoni = 6
                    Case Periodo.Quadrimestrale
                        iNrCanoni = 4
                    Case Periodo.Trimestrale
                        iNrCanoni = 3
                    Case Periodo.Bimestrale
                        iNrCanoni = 2
                    Case Periodo.Mensile
                        iNrCanoni = 1
                End Select
            End If

            '28/02/2022: Devono sempre essere primo del mese / fine mese
            '23/03/2022: Creo una nuova data per i POSTICIPATI che e' sempre fine mese e sempre il primo per gli ANTICIPATI
            If c.AlltipoRigaServizio.Cadenza.Value = Cadenza.Anticipato Then
                Dim nextDateAnt = New Date(nextDate.Year, nextDate.Month, 1)
                'Sempre il primo del mese
                DataPrevistaConsegna = nextDateAnt
                DataConfermaConsegna = nextDateAnt
                CanoniDataIn = nextDateAnt
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '28/11/2022 Le date devono sempre essere corrispondenti ai periodi
                'In caso di decorrenza 1/11 e trimestrale si fattura solo fino al 31/12
                'Era
                'CanoniDataFin = nextDateAnt.AddMonths(iNrCanoni).AddDays(-1)
                'DataProssimaFattura = nextDateAnt.AddMonths(iNrCanoni) ' CanoniDataFin.AddDays(1)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Eseguo l'aggiunta dei mesi ed essendo il primo basta togliere un giorno
                Dim dta As Date = CalcolaDataProssimaFattura(nextDateAnt.AddMonths(iNrCanoni), c.AlltipoRigaServizio.Periodicita)
                DataProssimaFattura = dta
                CanoniDataFin = dta.AddDays(-1)
                'Per i continuativi non mi interessa
                If IsCanone OrElse IsAConsumo Then
                    If Year(CanoniDataFin) > Year(CanoniDataIn) Then
                        QtaCorrente = 12 + Month(CanoniDataFin) - Month(CanoniDataIn) + 1
                    Else
                        QtaCorrente = Month(CanoniDataFin) - Month(CanoniDataIn) + 1
                    End If
                End If

            Else
                'Imposto l'ultimo giorno del mese
                Dim nextDatePos = New Date(nextDate.Year, nextDate.Month, DateTime.DaysInMonth(nextDate.Year, nextDate.Month))
                DataPrevistaConsegna = nextDatePos
                DataConfermaConsegna = nextDatePos
                'La data e' posticipata quindi devo sottrarre dei mesi
                'prima aggiungo un giorno in modo da poter sottrarre correttamente
                Dim postPrimoGiorno = nextDatePos.AddDays(1).AddMonths(-iNrCanoni)
                'Poi porto al primo ( non dovrebbe essere necessario ma lo faccio)
                postPrimoGiorno = New Date(postPrimoGiorno.Year, postPrimoGiorno.Month, 1)
                CanoniDataIn = postPrimoGiorno
                CanoniDataFin = nextDatePos
                'Calcolo la data prossima fattura aggiungerdo i mesi e andando all'ultimo giorno
                Dim postUltimoGiorno As Date = nextDatePos.AddMonths(iNrCanoni)
                postUltimoGiorno = New Date(postUltimoGiorno.Year, postUltimoGiorno.Month, DateTime.DaysInMonth(postUltimoGiorno.Year, postUltimoGiorno.Month))
                DataProssimaFattura = postUltimoGiorno
            End If
            'Sui continuativi avendo solo un valore imposto data fattura/ dataInizio
            If IsContinuativo Then CanoniDataFin = CanoniDataIn

        ElseIf isUnaTantum Then
            iNrCanoni = 1
            CanoniDataIn = nextDate
            CanoniDataFin = nextDate
        End If
        NrCanoniIniziale = iNrCanoni
        PeriodoDataIn = CanoniDataIn
        PeriodoDataFin = CanoniDataFin

    End Sub
    ''' <summary>
    ''' La data e' sempre il primo del mese ed e' già adeguata/nuova, occorre solo correggerla se esce dai range
    ''' </summary>
    ''' <param name="dataFine"></param>
    ''' <param name="periodo"></param>
    ''' <returns></returns>
    Private Shared Function CalcolaDataProssimaFattura(ByVal dataFine As Date, ByVal periodo As Periodo) As Date
        Dim d As Date
        Dim m As Integer = Month(dataFine)
        Select Case periodo
            Case Periodo.Annuale
                d = New Date(dataFine.Year, 1, 1)
            Case Periodo.Semestrale
                If m >= 7 Then
                    d = New Date(dataFine.Year, 7, 1)
                Else
                    d = New Date(dataFine.Year, 1, 1)
                End If
            Case Periodo.Quadrimestrale
                If m >= 9 Then
                    d = New Date(dataFine.Year, 9, 1)
                ElseIf m >= 5 Then
                    d = New Date(dataFine.Year, 5, 1)
                Else
                    d = New Date(dataFine.Year, 1, 1)
                End If
            Case Periodo.Trimestrale
                If m >= 10 Then
                    d = New Date(dataFine.Year, 10, 1)
                ElseIf m >= 7 Then
                    d = New Date(dataFine.Year, 7, 1)
                ElseIf m >= 4 Then
                    d = New Date(dataFine.Year, 4, 1)
                Else
                    d = New Date(dataFine.Year, 1, 1)
                End If
            Case Periodo.Bimestrale
                If m >= 11 Then
                    d = New Date(dataFine.Year, 11, 1)
                ElseIf m >= 9 Then
                    d = New Date(dataFine.Year, 9, 1)
                ElseIf m >= 7 Then
                    d = New Date(dataFine.Year, 7, 1)
                ElseIf m >= 5 Then
                    d = New Date(dataFine.Year, 5, 1)
                ElseIf m >= 3 Then
                    d = New Date(dataFine.Year, 3, 1)
                Else
                    d = New Date(dataFine.Year, 1, 1)
                End If
            Case Periodo.Mensile
                d = dataFine
        End Select
        Return d
    End Function

    Public Sub AnnullaDaAttività(ByVal dataAnnullamento As Date)
        HaAnnullatoDaAttivita = True
        DataCessazioneDaAttivita = dataAnnullamento
    End Sub
End Class
