Imports System.Windows.Forms

Public Class FAskFiltriOrdini
    Public IsIstat As Boolean
    Private perc As Double
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DtaPickDA.Value = New DateTime(2021, 3, 19)
        DtaCompA.Value = Now

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
        If IsIstat Then
            Me.Size = New Size(262, 445)
            'GroupCompetenza.Visible = False
            GroupPeriodo.Visible = False
            GroupIstat.Location = GroupPeriodo.Location
            GroupIstat.Visible = True
            AssignValidation(Me.TxtPercIstat, ValidationType.Only_Numbers)
            'AssignValidation(Me.TextBox2, ValidationType.Only_Characters)
            'AssignValidation(Me.TextBox3, ValidationType.No_Blank)
            'AssignValidation(Me.TextBox4, ValidationType.Only_Email)

        End If
    End Sub

    Private Sub TxtPercIstat_TextChanged(sender As Object, e As EventArgs) Handles TxtPercIstat.TextChanged
        Dim ok As Boolean = Double.TryParse(TxtPercIstat.Text, perc)
    End Sub

    'Private Sub TxtPercIstat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPercIstat.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "," AndAlso Not e.KeyChar = "-" Then
    '        e.Handled = True
    '    End If
    'End Sub
End Class
