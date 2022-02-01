Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Xml.Serialization

''' <summary>
''' Registro log / Livello / Ordine
''' </summary>
<XmlRoot("Registro")>
Public Class MyLogRegistry
    Implements IComparable(Of MyLogRegistry)

    Public Nome As String
    Public Descrizione As String
    Public Origine As String

    ''' <summary>
    ''' Importanza / ordine di stampa
    ''' </summary>
    Public Ordine As Short

    ''' <summary>
    ''' Determina se stampare o meno il Codice dell'entry
    ''' </summary>
    Public StampaCodice As Boolean

    ''' <summary>
    ''' Determina se il registro e' da riordinare / sort
    ''' </summary>
    Public DaOrdinare As Boolean

    ''' <summary>
    ''' Blocco contenente le linee di dettaglio del documento (gli elementi informativi del blocco si ripetono per ogni riga di dettaglio).
    ''' </summary>
    <XmlElement("Dettaglio")>
    Public Dettagli As List(Of MyLogEntry)

    Sub New()
        Nome = ""
        Descrizione = ""
        Origine = ""
        Ordine = 0
        DaOrdinare = False
        StampaCodice = False
        Dettagli = New List(Of MyLogEntry)()
        'DatiRiepilogo = New List(Of DatiRiepilogo)()
    End Sub

    Sub Add(codice As String, message As String, Optional minLevel As LogLevel = 0, Optional tag As String = "")
        Dim l As New MyLogEntry With {
            .Codice = codice,
            .Ordinale = CShort(Mid(codice, 2)),
            .Descrizione = message,
            .TAG = tag,
            .TimeStamp = DateAndTime.Now.ToString,
            .LogLevel = minLevel
        }
        Dettagli.Add(l)
        If minLevel.HasFlag(LogLevel.Console) Then Debug.Print(message)
    End Sub

    Public Function CompareTo(ByVal other As MyLogRegistry) As Integer Implements System.IComparable(Of MyLogRegistry).CompareTo
        If Ordine = other.Ordine Then
            Return 0
        Else
            If Ordine < other.Ordine Then
                Return -1
            Else
                Return 1
            End If
        End If
    End Function

End Class
<Flags()> Public Enum LogLevel As Integer
    'Debugging + Console = 3
    'Console + Standard = 5
    None = 0
    Console = 1
    Debugging = 2
    Standard = 4
End Enum