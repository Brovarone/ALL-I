Public Class FiltriAnalitici
    Public Property DataDA As Date
    Public Property DataA As Date
    Public Property GiaRegistrati As Boolean
    Public Property MovInAnalitica As Boolean
    Public Property NumberFirst As String
    Public Property NumberLast As String
    Public Property AllNumbers As Boolean
    Public Sub New()
        DataA = Today
        DataDA = Today
        GiaRegistrati = False
        MovInAnalitica = False
        NumberFirst = ""
        NumberLast = ""
        AllNumbers = True
    End Sub
End Class
Public NotInheritable Class DareAvereIgnora
    'Dare Avere ignora - segno analitica 125
    Public Shared Dare As Integer = 8192000
    Public Shared Avere As Integer = 8192001
    Public Shared Ignora As Integer = 8192002
End Class