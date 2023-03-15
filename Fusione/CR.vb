Public Class CR
    Public id As Integer
    Public Property Origine As Integer
    Public Property Derivato As Integer
    Public Function WhereClause() As String
        Return " WHERE OriginDocType =  " & Origine & " AND DerivedDocType = " & Derivato & " "
    End Function
End Class
