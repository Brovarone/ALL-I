Imports System.Windows.Forms

Public Class PasswordDialogBox
    Public Property Password As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If PasswordMeetsCriteria(TxTPassword.Text) Then
            Me.Password = TxTPassword.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MessageBox.Show("Password non valida, reinserirla o premere annnulla.", "Password non valida", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Shared Function PasswordMeetsCriteria(password As String) As Boolean
        Dim validCharacters As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`1234567890-=~!@#$%^&*()_+,./;'[]\<>?:""{}"
        For Each c As Char In password
            If validCharacters.IndexOf(c) = -1 Then Return False
        Next
        Return True
    End Function
End Class
