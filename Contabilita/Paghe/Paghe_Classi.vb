Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Data.SqlClient
Imports System.Reflection.MethodBase

''' <summary>
''' Il tracciato ( quello che uso) si puo' leggere nei metodi InitializeTestata e Initializerighe
''' TODO: modificare le chiamate a creapn e creaAnalitica per usare le classi e le liste
''' </summary>
Partial Public Module Paghe
    Private list_TestaPaghe As New List(Of TestaPaghe)()
    Private list_RighePaghe As New List(Of RigaPaghe)()
    Private transcodeDictCdc As New Dictionary(Of String, String)
    Public Function CaricaFlussoPagheClassi(ByVal refPath As String, ByVal IsMago As Boolean) As Boolean
        Dim result As Boolean

        InitializeTranscodeDict()
        Using rdr As New StreamReader(refPath)
            Dim currentLine As String = rdr.ReadLine()
            While currentLine IsNot Nothing
                If Not String.IsNullOrWhiteSpace(currentLine) Then
                    If String.IsNullOrWhiteSpace(Left(currentLine, 6)) Then
                        Dim testataRecord As TestaPaghe = testataRecord.Parse(currentLine)
                        If testataRecord IsNot Nothing Then
                            ' TranscodeCdc da sistemare
                            ' testataRecord.CdCMago = TranscodeCdc(testataRecord.CdC)
                            list_TestaPaghe.Add(testataRecord)
                        End If
                    Else
                        Dim rigaRecord As RigaPaghe = rigaRecord.Parse(currentLine)
                        If rigaRecord IsNot Nothing Then
                            ' TranscodeCdc da sistemare
                            ' rigaRecord.CdCMago = TranscodeCdc(rigaRecord.CdC)
                            list_RighePaghe.Add(rigaRecord)
                        End If
                    End If
                End If
                currentLine = rdr.ReadLine()
            End While
        End Using

        ' Qui dovrai adattare la logica di CreaPNotaPaghe per usare le classi
        ' result = CreaPNotaPagheClassi(listaTestate, listaRighe) ' Esempio
        ' o elaborare direttamente le liste se non hai bisogno di un metodo separato.
        Return True ' O il risultato appropriato

    End Function

    Private Function TranscodeCdc_Dict(Cdc As String) As String
        Dim codMago As String = String.Empty
        If transcodeDictCdc.TryGetValue(Cdc, codMago) Then
            Return codMago
        Else
            Return Cdc ' Restituisce il codice originale se non trovato
        End If

    End Function

    ''' <summary>
    ''' Transcodifica Centri di Costo Da Paghe a Mago <br/>
    ''' A Seguito accorpamento UNO -- SPA
    ''' </summary>
    Private Sub InitializeTranscodeDict()
        transcodeDictCdc = New Dictionary(Of String, String) From {
            {"A1", "AL1"},
            {"A2", "ALBA1"},
            {"A3", "AO1"},
            {"A4", "AT1"},
            {"BI", "BI1"},
            {"BO", "BO1"},
            {"CI", "CI1"},
            {"C2", "CN1"},
            {"M1", "MI1"},
            {"N1", "NO1"},
            {"RO", "RO1"},
            {"T1", "TO1"},
            {"UT", "UT1"},
            {"V1", "VC1"}
        }

    End Sub
End Module
