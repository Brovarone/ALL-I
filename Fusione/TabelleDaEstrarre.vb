Imports System.Reflection.MethodBase
Public Class TabelleDaEstrarre
    Public Property ModificaTutti As Boolean
    Public Property WhereClause As String
    Public Property AdditionalWhere As String
    Public Property JoinClause As String
    ''' <summary>
    ''' Nome Tabella
    ''' </summary>
    ''' <returns></returns>
    Public Property Nome As String
    Public Property FriendName As String
    Public Property Paging As Boolean
    Friend Property Gruppo As MacroGruppo
    Public Property HaListaPKIds As Boolean
    Public Property GeneraListaPKIds As Boolean
    Public Property ListaPKIds As List(Of Integer)
    Public Property HaListaEsclusi As Boolean
    Public Property ListaEsclusi As List(Of String)
    Public Property NotInPK As String
    Public Property NotInPKClause As String

    ''' <summary>
    ''' Elenco di nomi tabella cui passare la lista ids estratta
    ''' </summary>
    ''' <returns></returns>
    Public Property TabelleDipendenti As List(Of String)
    Public Property PrimaryKey As String
    Public Property Coppia_CR As CR
    Public Sub New()
        ModificaTutti = False
        AdditionalWhere = ""
        WhereClause = ""
        JoinClause = ""
        Nome = ""
        FriendName = ""
        Paging = False
        Gruppo = MacroGruppo.Nessuno
        GeneraListaPKIds = False
        HaListaPKIds = False
        PrimaryKey = ""
    End Sub
    Public Function Ritorna_Clausola_IN() As String
        Dim s As String = " WHERE " & PrimaryKey & " IN ("
        s &= String.Join(",", ListaPKIds.ToArray)
        Return s & ")"
    End Function
    Private Function Crea_Clausola_AndNotIn(key As List(Of String)) As String
        Dim s As String
        If String.IsNullOrWhiteSpace(WhereClause) Then
            s = " WHERE " & NotInPK & " NOT IN ("
        Else
            s = " AND " & NotInPK & " NOT IN ("
        End If
        s &= "'" & String.Join("','", key.ToArray) & "'"
        Return s & ")"
    End Function
    Public Sub EstraiListaEsclusi(dv As DataView)
        Dim result As New List(Of String)
        Try
            Dim f As String = ""
            Select Case Gruppo
                Case MacroGruppo.Clienti
                    f = "Cliente"
                Case MacroGruppo.Fornitori
                    f = "Fornitore"
                Case MacroGruppo.Agenti
                    f = "Agente"
                Case MacroGruppo.BancheCli
                    f = "BancaCliente"
            End Select
            dv.RowFilter = "Tipo ='" & f & "'"

            For Each drv As DataRowView In dv
                result.Add(drv("Valore").ToString)
                Application.DoEvents()
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
            ScriviLog("#Errore# in EstraiListaEsclusi: " & ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString)
            If Not IsDebugging Then
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End If
        End Try
        dv.Sort = [String].Empty
        dv.RowFilter = [String].Empty
        NotInPKClause = Crea_Clausola_AndNotIn(result)
        ListaEsclusi = result
    End Sub
End Class
