Imports System.Windows.Forms

Public Class FAskFiltriOrdini
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DtaPickDA.Value = New DateTime(2021, 3, 19)
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RadFinoAllaData_CheckedChanged(sender As Object, e As EventArgs) Handles RadFinoAllaData.CheckedChanged
        DtaDA.Enabled = Not RadFinoAllaData.Checked
        DtaDA.Value = New Date(Year(DtaA.Value), 1, 1)
    End Sub

    Private Sub ChkNrOrdine_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNrOrdine.CheckedChanged
        TxtNrOrdine.Enabled = ChkNrOrdine.Checked
    End Sub

    Private Sub ChkCliente_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCliente.CheckedChanged
        TxtOrdCliente.Enabled = ChkCliente.Checked
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFiliale.CheckedChanged
        TxtOrdFiliale.Enabled = ChkFiliale.Checked
    End Sub

    Private Sub ChkP_Tutti_CheckedChanged(sender As Object, e As EventArgs) Handles ChkP_Tutti.CheckedChanged
        ChkP_Annuali.Enabled = Not ChkP_Tutti.Checked
        ChkP_Semestrali.Enabled = Not ChkP_Tutti.Checked
        ChkP_Quadrimestrali.Enabled = Not ChkP_Tutti.Checked
        ChkP_Trimestrali.Enabled = Not ChkP_Tutti.Checked
        ChkP_Bimestrali.Enabled = Not ChkP_Tutti.Checked
        ChkP_Mensili.Enabled = Not ChkP_Tutti.Checked
    End Sub

    Private Sub FAskFiltriOrdini_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtaCompA.Value = Now
    End Sub

End Class
