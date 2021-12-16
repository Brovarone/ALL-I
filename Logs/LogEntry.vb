Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Public Class MyLogEntry
    Implements IComparable(Of MyLogEntry)

    ''' <summary>
    ''' Codice errore
    ''' </summary>
    Public Codice As String

    ''' <summary>
    ''' Descrizione
    ''' </summary>
    Public Descrizione As String

    ''' <summary>
    ''' TAG ( per ora inutilizzato)
    ''' </summary>
    Public TAG As String


    ''' <summary>
    ''' Ordinale Segue il codice e serve solo per ordinare
    ''' </summary>
    Public Ordinale As Short

    ''' <summary>
    ''' Data/ora
    ''' </summary>
    Public TimeStamp As String

    Public Function CompareTo(other As MyLogEntry) As Integer Implements IComparable(Of MyLogEntry).CompareTo
        If Ordinale = other.Ordinale Then
            Return 0
        Else
            If Ordinale < other.Ordinale Then
                Return -1
            Else
                Return 1
            End If
        End If

    End Function
End Class
