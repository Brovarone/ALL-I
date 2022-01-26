Imports System.Windows.Forms
Imports System.Globalization
Public Class FAskFiltriOrdini
    Public IsIstat As Boolean
    Private perc As Double
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'DtaPickDA.Value = New DateTime(2021, 3, 19)
        DtaFattA.Value = Now
        TxtAnnoAdeguamento.Text = Now.Year.ToString
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
        DtaOrdineDA.Enabled = Not RadFinoAllaData.Checked
        DtaOrdineDA.Value = New Date(Year(DtaOrdineA.Value), 1, 1)
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
        Me.Size = New Size(262, 516) ' Misura standard
        ToolTip1 = New ToolTip()
        If IsIstat Then
            Me.Size = New Size(262, 498)
            GroupDataFatt.Visible = False
            GroupPeriodo.Visible = False
            GroupDecorrenza.Enabled = True
            GroupDecorrenza.Location = GroupDataFatt.Location
            GroupIstat.Enabled = True
            GroupIstat.Location = New Point(6, 279)
            GroupIstat.Visible = True
            AssignValidation(Me.TxtPercIstat, ValidationType.Only_Numbers)
            'AssignValidation(Me.TextBox2, ValidationType.Only_Characters)
            'AssignValidation(Me.TextBox3, ValidationType.No_Blank)
            'AssignValidation(Me.TextBox4, ValidationType.Only_Email)
            Dim s As String = "Contratti con data decorrenza minore a questa data"
            ToolTip1.SetToolTip(Me.DtaFattA, s)
            s = "Valorizzato con Anno della 'Data decorrenza' -1." & Environment.NewLine & "Se per l'anno indicato e' già stata eseguita" & Environment.NewLine & "una rivalutazione la riga non verrà processata."
            ToolTip1.SetToolTip(Me.TxtAnnoAdeguamento, s)
            ToolTip1.SetToolTip(Me.LblAnnoAdeguamento, s)

        End If
    End Sub

    Private Sub TxtPercIstat_TextChanged(sender As Object, e As EventArgs) Handles TxtPercIstat.TextChanged
        Dim ok As Boolean = Double.TryParse(TxtPercIstat.Text, perc)
    End Sub

    Private Sub DtaDecorrenza_ValueChanged(sender As Object, e As EventArgs) Handles DtaDecorrenza.ValueChanged
        DtaIstatRifatt.Value = DtaDecorrenza.Value.AddYears(1)
        TxtAnnoAdeguamento.Text = DtaDecorrenza.Value.AddYears(1).Year.ToString
        Dim s As String = "Il canone è aggiornato sulla base dell'indice ISTAT relativo al mese di "
        s += DtaDecorrenza.Value.AddMonths(-2).ToString("MMMM", CultureInfo.CreateSpecificCulture("it-IT")) & " " & DtaIstatRifatt.Value.Year.ToString
        TxtIstatTesto.Text = s
    End Sub

    Private Sub DtaFattDa_ValueChanged(sender As Object, e As EventArgs) Handles DtaFattDa.ValueChanged
        DtaFattA.Value = DtaFattDa.Value
    End Sub


    'Private Sub TxtPercIstat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPercIstat.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not e.KeyChar = "," AndAlso Not e.KeyChar = "-" Then
    '        e.Handled = True
    '    End If
    'End Sub
End Class
