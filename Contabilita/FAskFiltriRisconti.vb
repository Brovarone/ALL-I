Imports System.Windows.Forms

Public Class FAskFiltriRisconti
    Public f As FiltroRisconti

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        f = New FiltroRisconti
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        f.Data = DtaScritture.Value
        f.ScriviAnalitica = chkScriviAnalitica.Checked AndAlso chkScriviAnalitica.Enabled
        f.FormatoRidotto = chkFormatoRidotto.Checked
        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DataRiscontiDialogBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtaScritture.Value = New Date(Now.Year, 1, 1)
    End Sub

    Private Sub chkFormatoRidotto_CheckedChanged(sender As Object, e As EventArgs) Handles chkFormatoRidotto.CheckedChanged
        chkScriviAnalitica.Enabled = Not chkFormatoRidotto.Checked
    End Sub
End Class
