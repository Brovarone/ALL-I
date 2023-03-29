Imports System.Windows.Forms

Public Class DocumentDialogBox
    Public Property Numero As String
    Public Property lbl As String
    Public Property lblSottotit As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If NumberMeetsCriteria(TxTNumero.Text) Then
            Me.Numero = Int16.Parse(TxTNumero.Text).ToString("000000")
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MessageBox.Show("Numero non valido, reinserirlo o premere annnulla.", "Numero non valido", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Shared Function NumberMeetsCriteria(text As String) As Boolean
        Dim validCharacters As String = "1234567890-/"
        For Each c As Char In text
            If validCharacters.IndexOf(c) = -1 Then Return False
        Next
        Return True
    End Function

    Private Sub DocumentDialogBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrWhiteSpace(lbl) Then
            lblNumero.Text = lbl
            lblSottotitolo.Text = lblSottotit
        End If
    End Sub
End Class
