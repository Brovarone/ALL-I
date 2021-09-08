Imports System.Windows.Forms

Public Class FAskDialog
    Private DTRadar As DataView
    Private SFiltri As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' DTRadar.RowFilter = SFiltri
        DataGridView1.DataSource = DTRadar

    End Sub
    Public Sub GetDataTable(value As DataView)
        DTRadar = value
    End Sub
    Public Sub GetFiltri(value As String)
        SFiltri = value
    End Sub

End Class
