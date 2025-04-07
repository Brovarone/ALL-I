Imports System.Text.RegularExpressions
Imports Fastenshtein

Module Indirizzi

    Public Function NormalizzaIndirizzo(indirizzo As String) As String
        ' Rimuovi le parentesi e uniforma le abbreviazioni
        indirizzo = Regex.Replace(indirizzo, "\((V[IAEL]?\s+)(.*?)\s+(\d+[A-Z]?(\/\d+[A-Z]?)?)\)", "Via $2, $3", RegexOptions.IgnoreCase)

        ' Rimuovi numeri civici multipli (es. 12/14 -> 12)
        indirizzo = Regex.Replace(indirizzo, "(\d+[A-Z]?)/\d+[A-Z]?", "$1")

        ' Rimuovi punteggiatura e spazi superflui
        indirizzo = Regex.Replace(indirizzo, "[\.\,\(\)]", "")
        indirizzo = Regex.Replace(indirizzo, "\s+", " ").Trim()

        ' Uniforma le abbreviazioni
        indirizzo = Regex.Replace(indirizzo, "\bV\b", "Via", RegexOptions.IgnoreCase)
        indirizzo = Regex.Replace(indirizzo, "\bVIALE\b", "Via", RegexOptions.IgnoreCase)
        indirizzo = Regex.Replace(indirizzo, "\bP\.ZA\b", "Piazza", RegexOptions.IgnoreCase)

        ' Trasforma la stringa in maiuscolo
        indirizzo = indirizzo.ToUpper()

        Return indirizzo
    End Function

    Public Function CalcolaSomiglianza(s1 As String, s2 As String) As Double
        Dim distanza As Integer = Levenshtein.Distance(s1, s2)
        Dim lunghezzaMassima As Integer = Math.Max(s1.Length, s2.Length)

        If lunghezzaMassima = 0 Then
            Return 100.0 ' Se entrambe le stringhe sono vuote, sono uguali
        End If

        Return (1.0 - (CDbl(distanza) / CDbl(lunghezzaMassima))) * 100.0
    End Function

    ''' <summary>
    ''' Esempio di come eseguire
    ''' </summary>
    ''' <param name="indirizzo1"></param>
    ''' <param name="indirizzo2"></param>
    ''' <returns></returns>
    Public Function ConfrontaIndirizzi(indirizzo1 As String, indirizzo2 As String) As String
        Dim indirizzoNormalizzato1 As String = NormalizzaIndirizzo(indirizzo1)
        Dim indirizzoNormalizzato2 As String = NormalizzaIndirizzo(indirizzo2)

        Dim percentualeSomiglianza As Double = CalcolaSomiglianza(indirizzoNormalizzato1, indirizzoNormalizzato2)

        Return $"Percentuale di somiglianza: {percentualeSomiglianza:F2}%"
    End Function

    Sub proviamo()
        Dim indirizzo1 As String = "STRADA PADANA SUPERIORE 11 2B"
        Dim indirizzo2 As String = "Strada Padana Superiore 11, 2/B"

        Dim indirizzo3 As String = "Via Roma, 1"
        Dim indirizzo4 As String = "Via Rom, 2"

        Console.WriteLine(ConfrontaIndirizzi(indirizzo1, indirizzo2))
        Console.WriteLine(ConfrontaIndirizzi(indirizzo3, indirizzo4))

        Console.ReadKey()
    End Sub
End Module
