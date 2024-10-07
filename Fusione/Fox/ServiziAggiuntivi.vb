Partial Module Ordini
    Function VerificaPeriodo(ByVal data As DateTime) As String
        Dim mese As Integer = data.Month
        Dim risultato As String

        ' Determinare il bimestre
        Dim bimestre As Integer = (mese - 1) \ 2 + 1

        ' Determinare il trimestre
        Dim trimestre As Integer = (mese - 1) \ 3 + 1

        ' Determinare il quadrimestre
        Dim quadrimestre As Integer = (mese - 1) \ 4 + 1

        ' Determinare il semestre
        Dim semestre As Integer = (mese - 1) \ 6 + 1

        ' Verifica il tipo di periodo
        Select Case trimestre
            Case 1
                risultato = $"Primo trimestre ({mese}): Bimestre {bimestre}, Quadrimestre {quadrimestre}, Semestre {semestre}"
            Case 2
                risultato = $"Secondo trimestre ({mese}): Bimestre {bimestre}, Quadrimestre {quadrimestre}, Semestre {semestre}"
            Case 3
                risultato = $"Terzo trimestre ({mese}): Bimestre {bimestre}, Quadrimestre {quadrimestre}, Semestre {semestre}"
            Case 4
                risultato = $"Quarto trimestre ({mese}): Bimestre {bimestre}, Quadrimestre {quadrimestre}, Semestre {semestre}"
            Case Else
                risultato = $"Periodo fuori intervallo ({mese})"
        End Select

        Return risultato
    End Function
    Private Function DecodificaPeriodicita(ByVal periodo As Ordini.Periodo) As Integer
        Dim result As Integer

        Select Case periodo
            Case Periodo.Annuale
                result = 12  ' ANNUALE
            Case Periodo.Mensile
                result = 1  ' MENSILE
            Case Periodo.Bimestrale
                result = 2  ' BIMESTRALE
            Case Periodo.Trimestrale
                result = 3  ' TRIMESTRALE
            Case Periodo.Quadrimestrale
                result = 1 ' QUADRIMESTRALE
            Case Periodo.Semestrale
                result = 6  ' SEMESTRALE
            Case Periodo.Nessuno
                result = 0  ' SOLO CANONI SUPPLEMENTARI
            Case Else
                result = 999 ' CODICE NON VALIDO
        End Select
        Return result
    End Function
    ''' <summary>
    ''' Restituisce una data per il calcolo della franchigia
    ''' </summary>
    ''' <param name="toDataMese">Fine data estrazione</param>
    ''' <param name="periodicita"></param>
    ''' <param name="iniziale">Nel caso di iniziale = false restituisce la finale</param>
    ''' <returns></returns>
    Private Function GetDataPeriodoFranchigia(toDataMese As Date, periodicita As Integer?, iniziale As Boolean) As Date
        Dim mese As Integer = toDataMese.Month
        Dim d As Date
        ' Determinare il bimestre
        Dim bimestre As Integer = (mese - 1) \ 2 + 1
        Dim bimMeseInizio As Integer = (bimestre - 1) * 2 + 1
        'Dim bimMeseFine As Integer = bimMeseInizio + 1

        ' Determinare il trimestre
        Dim trimestre As Integer = (mese - 1) \ 3 + 1
        Dim trimMeseInizio As Integer = (trimestre - 1) * 3 + 1
        'Dim trimMeseFine As Integer = trimMeseInizio + 2

        ' Determinare il quadrimestre
        Dim quadrimestre As Integer = (mese - 1) \ 4 + 1
        Dim quadMeseInizio As Integer = (quadrimestre - 1) * 4 + 1
        'Dim quadMeseFine As Integer = quadMeseInizio + 3

        ' Determinare il semestre
        Dim semestre As Integer = (mese - 1) \ 6 + 1
        Dim semMeseInizio As Integer = (semestre - 1) * 6 + 1
        'Dim semMeseFine As Integer = semMeseInizio + 5

        Select Case periodicita
            Case Periodo.Annuale
                If iniziale Then
                    d = New Date(toDataMese.Year, 1, 1).Date
                Else
                    d = New Date(toDataMese.Year, 12, 31, 23, 59, 59)
                End If

            Case Periodo.Mensile
                If iniziale Then
                    d = New Date(toDataMese.Year, mese, 1).Date
                Else
                    d = New Date(toDataMese.Year, mese, Date.DaysInMonth(toDataMese.Year, mese), 23, 59, 59)
                End If

            Case Periodo.Bimestrale
                If iniziale Then
                    d = New Date(toDataMese.Year, bimMeseInizio, 1).Date
                Else
                    Dim bimMeseFineDate As Date = New Date(toDataMese.Year, bimMeseInizio, 1).AddMonths(2).AddDays(-1)
                    d = New Date(bimMeseFineDate.Year, bimMeseFineDate.Month, Date.DaysInMonth(bimMeseFineDate.Year, bimMeseFineDate.Month), 23, 59, 59)
                End If

            Case Periodo.Trimestrale
                If iniziale Then
                    d = New Date(toDataMese.Year, trimMeseInizio, 1).Date
                Else
                    Dim trimMeseFineDate As Date = New Date(toDataMese.Year, trimMeseInizio, 1).AddMonths(3).AddDays(-1)
                    d = New Date(trimMeseFineDate.Year, trimMeseFineDate.Month, Date.DaysInMonth(trimMeseFineDate.Year, trimMeseFineDate.Month), 23, 59, 59)
                End If

            Case Periodo.Quadrimestrale
                If iniziale Then
                    d = New Date(toDataMese.Year, quadMeseInizio, 1).Date
                Else
                    Dim quadMeseFineDate As Date = New Date(toDataMese.Year, quadMeseInizio, 1).AddMonths(4).AddDays(-1)
                    d = New Date(quadMeseFineDate.Year, quadMeseFineDate.Month, Date.DaysInMonth(quadMeseFineDate.Year, quadMeseFineDate.Month), 23, 59, 59)
                End If

            Case Periodo.Semestrale
                If iniziale Then
                    d = New Date(toDataMese.Year, semMeseInizio, 1).Date
                Else
                    Dim semMeseFineDate As Date = New Date(toDataMese.Year, semMeseInizio, 1).AddMonths(6).AddDays(-1)
                    d = New Date(semMeseFineDate.Year, semMeseFineDate.Month, Date.DaysInMonth(semMeseFineDate.Year, semMeseFineDate.Month), 23, 59, 59)
                End If

            Case Periodo.Nessuno
                ' Per il caso "Nessuno", consideriamo la data del mese come riferimento
                If iniziale Then
                    d = New Date(toDataMese.Year, mese, 1).Date
                Else
                    d = New Date(toDataMese.Year, mese, Date.DaysInMonth(toDataMese.Year, mese), 23, 59, 59)
                End If

            Case Else
                ' Gestione di valori non validi per periodicità
                d = New Date(2000, 1, 1)
        End Select

        Return d
    End Function

End Module
