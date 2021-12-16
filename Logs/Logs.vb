Imports System.Xml.Serialization
Imports System.Xml

<Serializable>
Public Class MyLogs

    <XmlAttribute("versione")>
    Public Versione As String
    Public Nome As String
    Public Testa As MyLogRegistry
    Public Corpo As List(Of MyLogRegistry)

    Sub New()
        Versione = ""
        Nome = ""
        Testa = New MyLogRegistry
        Corpo = New List(Of MyLogRegistry)
    End Sub

End Class
