Imports System.Windows.Forms

Public Class FAskFiltriAnalitica
    Public f As FiltroAnalitica
    Public Sub New(Optional IsDBUno As Boolean = True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DtaPickDA.Value = New DateTime(2021, 3, 19)
        f = New FiltroAnalitica
        f.AdeguaCanoniDate = IsDBUno
        ChkGiaRegistrati.Enabled = isAdmin
        ChkMovInAna.Enabled = isAdmin
        TxtNumberFirst.Text = "PRIMO"
        TxtNumberLast.Text = "ULTIMO"
        ChkAdeguaCampi.Checked = IsDBUno
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        f.DataA = DtaPickA.Value
        f.DataDA = DtaPickDA.Value
        f.GiaRegistrati = ChkGiaRegistrati.Checked
        f.MovInAnalitica = ChkMovInAna.Checked
        f.NumberFirst = If(String.IsNullOrWhiteSpace(TxtNumberFirst.Text), "PRIMO", TxtNumberFirst.Text)
        f.NumberLast = If(String.IsNullOrWhiteSpace(TxtNumberLast.Text), "ULTIMO", TxtNumberLast.Text)
        f.AdeguaCanoniDate = ChkAdeguaCampi.Checked
        If f.NumberFirst <> "PRIMO" Then
            f.AllNumbers = False
            f.NumberFirst = f.NumberFirst.PadLeft(6, "0")
        Else
            f.NumberFirst = ""
        End If

        If f.NumberLast <> "ULTIMO" Then
            f.AllNumbers = False
            f.NumberLast = f.NumberLast.PadLeft(6, "0")
        Else
            f.NumberLast = "zzzzzz"
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TxtNumberFirst_Leave(sender As Object, e As EventArgs) Handles TxtNumberFirst.Leave
        If TxtNumberFirst.Modified Then
            If String.IsNullOrWhiteSpace(TxtNumberFirst.Text) Then
                TxtNumberFirst.Text = "PRIMO"
            Else
                TxtNumberLast.Text = TxtNumberFirst.Text
            End If
        End If
    End Sub

    Private Sub TxtNumberLast_Leave(sender As Object, e As EventArgs) Handles TxtNumberLast.Leave
        If String.IsNullOrWhiteSpace(TxtNumberLast.Text) Then
            TxtNumberFirst.Text = "ULTIMO"
        End If
    End Sub


End Class
