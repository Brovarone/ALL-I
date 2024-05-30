Imports System.Globalization
Imports System.Windows.Forms

Public Class FAskFiltriOrdiniConsuntivo
    Private loading As Boolean
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
        loading = True
        Dim it As CultureInfo = New CultureInfo("it-IT")
        CmbMonth.Items.AddRange(it.DateTimeFormat.MonthNames)
        CmbYear.Items.Add(Date.Today.Year - 1)
        CmbYear.Items.Add(Date.Today.Year)
        If Date.Today.Month = 1 Then
            CmbMonth.SelectedIndex = 12
            CmbYear.SelectedIndex = 0
        Else
            CmbMonth.SelectedIndex = Date.Today.Month - 1
            CmbYear.SelectedIndex = 1
        End If

        loading = False
        CalcolaDate()
    End Sub

    Private Sub CmbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMonth.SelectedIndexChanged
        If CmbMonth.SelectedIndex >= 0 AndAlso CmbMonth.SelectedIndex <= 11 Then
            CalcolaDate()
        End If
    End Sub
    Private Sub CmbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbYear.SelectedIndexChanged
        If CmbYear.SelectedIndex >= 0 AndAlso CmbYear.SelectedIndex <= 1 Then
            CalcolaDate()
        End If
    End Sub
    Private Sub CalcolaDate()
        If Not loading Then
            Dim y As Integer = CmbYear.SelectedItem
            Dim m As Integer = CmbMonth.SelectedIndex + 1
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
        CmbYear.Enabled = b
        RadOnlyCheck.Enabled = b
        RadCheckAndFatt.Enabled = b
        ChkRiassegna.Enabled = b
        RadOnlyFatt.Enabled = b
        DtaFatt.Enabled = b
        ChkFiliale.Enabled = b
        TxtOrdFiliale.Enabled = b And ChkFiliale.Checked

    End Sub

    Private Sub RadOnlyFatt_CheckedChanged(sender As Object, e As EventArgs) Handles RadOnlyFatt.CheckedChanged
        ChkRiassegna.Enabled = Not RadOnlyFatt.Checked
    End Sub

End Class
