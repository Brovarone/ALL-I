Imports System.Globalization
Imports System.Windows.Forms

Public Class FAskFiltriOrdiniConsuntivo

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ChkNoFilter.Checked Then
            If CmbMonth.SelectedIndex = 12 OrElse CmbMonth.SelectedIndex = -1 Then
                MsgBox("Il  mese indicato non e' valido")
                Return
            End If
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FAskFiltriOrdiniConsuntivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim it As CultureInfo = New CultureInfo("it-IT")
        CmbMonth.Items.AddRange(it.DateTimeFormat.MonthNames)
    End Sub

    Private Sub CmbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMonth.SelectedIndexChanged
        If CmbMonth.SelectedIndex >= 0 AndAlso CmbMonth.SelectedIndex <= 11 Then
            Dim y As Integer
            Dim m As Integer = CmbMonth.SelectedIndex + 1
            If Today.Month = 1 Then
                y = Today.Year - 1
            Else
                y = Today.Year
            End If
            DtaFatt.Value = New Date(y, m, Date.DaysInMonth(y, m))
            lastLogDate.Value = DtaFatt.Value
            firstLogDate.Value = New Date(lastLogDate.Value.Year, lastLogDate.Value.Month, 1)
        End If
    End Sub

    Private Sub ChkFiliale_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFiliale.CheckedChanged
        TxtOrdFiliale.Enabled = ChkFiliale.Checked

    End Sub

    Private Sub ChkNoFilter_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNoFilter.CheckedChanged
        Dim b As Boolean = ChkNoFilter.Checked

        CmbMonth.Enabled = b
        RadOnlyCheck.Enabled = b
        RadCheckAndFatt.Enabled = b
        RadOnlyFatt.Enabled = b
        DtaFatt.Enabled = b
        ChkFiliale.Enabled = b
        TxtOrdFiliale.Enabled = b And ChkFiliale.Checked


    End Sub
End Class
