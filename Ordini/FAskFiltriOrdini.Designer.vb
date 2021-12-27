<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAskFiltriOrdini
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DtaDA = New System.Windows.Forms.DateTimePicker()
        Me.DtaA = New System.Windows.Forms.DateTimePicker()
        Me.LblDallaData = New System.Windows.Forms.Label()
        Me.LblAlladata = New System.Windows.Forms.Label()
        Me.GroupOrdini = New System.Windows.Forms.GroupBox()
        Me.TxtOrdFiliale = New System.Windows.Forms.TextBox()
        Me.ChkFiliale = New System.Windows.Forms.CheckBox()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.ChkNrOrdine = New System.Windows.Forms.CheckBox()
        Me.RadFinoAllaData = New System.Windows.Forms.RadioButton()
        Me.RadDalAl = New System.Windows.Forms.RadioButton()
        Me.TxtOrdCliente = New System.Windows.Forms.TextBox()
        Me.TxtNrOrdine = New System.Windows.Forms.TextBox()
        Me.DtaCompA = New System.Windows.Forms.DateTimePicker()
        Me.GroupCompetenza = New System.Windows.Forms.GroupBox()
        Me.GroupPeriodo = New System.Windows.Forms.GroupBox()
        Me.ChkP_Tutti = New System.Windows.Forms.CheckBox()
        Me.ChkP_Mensili = New System.Windows.Forms.CheckBox()
        Me.ChkP_Bimestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Trimestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Quadrimestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Semestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Annuali = New System.Windows.Forms.CheckBox()
        Me.GroupIstat = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPercIstat = New System.Windows.Forms.TextBox()
        Me.TxtIstatAttivita = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupOrdini.SuspendLayout()
        Me.GroupCompetenza.SuspendLayout()
        Me.GroupPeriodo.SuspendLayout()
        Me.GroupIstat.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(88, 398)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 18
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 19
        Me.Cancel_Button.Text = "Cancel"
        '
        'DtaDA
        '
        Me.DtaDA.Enabled = False
        Me.DtaDA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaDA.Location = New System.Drawing.Point(96, 65)
        Me.DtaDA.Name = "DtaDA"
        Me.DtaDA.Size = New System.Drawing.Size(96, 20)
        Me.DtaDA.TabIndex = 3
        '
        'DtaA
        '
        Me.DtaA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaA.Location = New System.Drawing.Point(96, 94)
        Me.DtaA.Name = "DtaA"
        Me.DtaA.Size = New System.Drawing.Size(96, 20)
        Me.DtaA.TabIndex = 4
        '
        'LblDallaData
        '
        Me.LblDallaData.AutoSize = True
        Me.LblDallaData.Location = New System.Drawing.Point(35, 65)
        Me.LblDallaData.Name = "LblDallaData"
        Me.LblDallaData.Size = New System.Drawing.Size(55, 13)
        Me.LblDallaData.TabIndex = 3
        Me.LblDallaData.Text = "Dalla data"
        '
        'LblAlladata
        '
        Me.LblAlladata.AutoSize = True
        Me.LblAlladata.Location = New System.Drawing.Point(35, 94)
        Me.LblAlladata.Name = "LblAlladata"
        Me.LblAlladata.Size = New System.Drawing.Size(48, 13)
        Me.LblAlladata.TabIndex = 4
        Me.LblAlladata.Text = "Alla data"
        '
        'GroupOrdini
        '
        Me.GroupOrdini.Controls.Add(Me.TxtOrdFiliale)
        Me.GroupOrdini.Controls.Add(Me.ChkFiliale)
        Me.GroupOrdini.Controls.Add(Me.ChkCliente)
        Me.GroupOrdini.Controls.Add(Me.ChkNrOrdine)
        Me.GroupOrdini.Controls.Add(Me.RadFinoAllaData)
        Me.GroupOrdini.Controls.Add(Me.RadDalAl)
        Me.GroupOrdini.Controls.Add(Me.TxtOrdCliente)
        Me.GroupOrdini.Controls.Add(Me.TxtNrOrdine)
        Me.GroupOrdini.Controls.Add(Me.DtaA)
        Me.GroupOrdini.Controls.Add(Me.DtaDA)
        Me.GroupOrdini.Controls.Add(Me.LblAlladata)
        Me.GroupOrdini.Controls.Add(Me.LblDallaData)
        Me.GroupOrdini.Location = New System.Drawing.Point(6, 3)
        Me.GroupOrdini.Name = "GroupOrdini"
        Me.GroupOrdini.Size = New System.Drawing.Size(228, 215)
        Me.GroupOrdini.TabIndex = 7
        Me.GroupOrdini.TabStop = False
        Me.GroupOrdini.Text = "Ordini Ciente"
        '
        'TxtOrdFiliale
        '
        Me.TxtOrdFiliale.Enabled = False
        Me.TxtOrdFiliale.Location = New System.Drawing.Point(110, 172)
        Me.TxtOrdFiliale.Name = "TxtOrdFiliale"
        Me.TxtOrdFiliale.Size = New System.Drawing.Size(96, 20)
        Me.TxtOrdFiliale.TabIndex = 10
        '
        'ChkFiliale
        '
        Me.ChkFiliale.AutoSize = True
        Me.ChkFiliale.Location = New System.Drawing.Point(9, 172)
        Me.ChkFiliale.Name = "ChkFiliale"
        Me.ChkFiliale.Size = New System.Drawing.Size(90, 17)
        Me.ChkFiliale.TabIndex = 9
        Me.ChkFiliale.Text = "Singola Filiale"
        Me.ChkFiliale.UseVisualStyleBackColor = True
        '
        'ChkCliente
        '
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Location = New System.Drawing.Point(9, 146)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(96, 17)
        Me.ChkCliente.TabIndex = 7
        Me.ChkCliente.Text = "Singolo Cliente"
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'ChkNrOrdine
        '
        Me.ChkNrOrdine.AutoSize = True
        Me.ChkNrOrdine.Location = New System.Drawing.Point(9, 123)
        Me.ChkNrOrdine.Name = "ChkNrOrdine"
        Me.ChkNrOrdine.Size = New System.Drawing.Size(95, 17)
        Me.ChkNrOrdine.TabIndex = 5
        Me.ChkNrOrdine.Text = "Singolo Ordine"
        Me.ChkNrOrdine.UseVisualStyleBackColor = True
        '
        'RadFinoAllaData
        '
        Me.RadFinoAllaData.AutoSize = True
        Me.RadFinoAllaData.Checked = True
        Me.RadFinoAllaData.Location = New System.Drawing.Point(9, 19)
        Me.RadFinoAllaData.Name = "RadFinoAllaData"
        Me.RadFinoAllaData.Size = New System.Drawing.Size(100, 17)
        Me.RadFinoAllaData.TabIndex = 1
        Me.RadFinoAllaData.TabStop = True
        Me.RadFinoAllaData.Text = "Fino alla data ..."
        Me.RadFinoAllaData.UseVisualStyleBackColor = True
        '
        'RadDalAl
        '
        Me.RadDalAl.AutoSize = True
        Me.RadDalAl.Location = New System.Drawing.Point(9, 42)
        Me.RadDalAl.Name = "RadDalAl"
        Me.RadDalAl.Size = New System.Drawing.Size(140, 17)
        Me.RadDalAl.TabIndex = 2
        Me.RadDalAl.Text = "Dalla data ... alla data ..."
        Me.RadDalAl.UseVisualStyleBackColor = True
        '
        'TxtOrdCliente
        '
        Me.TxtOrdCliente.Enabled = False
        Me.TxtOrdCliente.Location = New System.Drawing.Point(110, 146)
        Me.TxtOrdCliente.Name = "TxtOrdCliente"
        Me.TxtOrdCliente.Size = New System.Drawing.Size(96, 20)
        Me.TxtOrdCliente.TabIndex = 8
        '
        'TxtNrOrdine
        '
        Me.TxtNrOrdine.Enabled = False
        Me.TxtNrOrdine.Location = New System.Drawing.Point(110, 120)
        Me.TxtNrOrdine.Name = "TxtNrOrdine"
        Me.TxtNrOrdine.Size = New System.Drawing.Size(96, 20)
        Me.TxtNrOrdine.TabIndex = 6
        '
        'DtaCompA
        '
        Me.DtaCompA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaCompA.Location = New System.Drawing.Point(110, 16)
        Me.DtaCompA.Name = "DtaCompA"
        Me.DtaCompA.Size = New System.Drawing.Size(96, 20)
        Me.DtaCompA.TabIndex = 11
        '
        'GroupCompetenza
        '
        Me.GroupCompetenza.Controls.Add(Me.DtaCompA)
        Me.GroupCompetenza.Location = New System.Drawing.Point(6, 224)
        Me.GroupCompetenza.Name = "GroupCompetenza"
        Me.GroupCompetenza.Size = New System.Drawing.Size(228, 46)
        Me.GroupCompetenza.TabIndex = 14
        Me.GroupCompetenza.TabStop = False
        Me.GroupCompetenza.Text = "Competenza"
        '
        'GroupPeriodo
        '
        Me.GroupPeriodo.Controls.Add(Me.ChkP_Tutti)
        Me.GroupPeriodo.Controls.Add(Me.ChkP_Mensili)
        Me.GroupPeriodo.Controls.Add(Me.ChkP_Bimestrali)
        Me.GroupPeriodo.Controls.Add(Me.ChkP_Trimestrali)
        Me.GroupPeriodo.Controls.Add(Me.ChkP_Quadrimestrali)
        Me.GroupPeriodo.Controls.Add(Me.ChkP_Semestrali)
        Me.GroupPeriodo.Controls.Add(Me.ChkP_Annuali)
        Me.GroupPeriodo.Enabled = False
        Me.GroupPeriodo.Location = New System.Drawing.Point(6, 276)
        Me.GroupPeriodo.Name = "GroupPeriodo"
        Me.GroupPeriodo.Size = New System.Drawing.Size(228, 114)
        Me.GroupPeriodo.TabIndex = 15
        Me.GroupPeriodo.TabStop = False
        Me.GroupPeriodo.Text = "Periodo"
        '
        'ChkP_Tutti
        '
        Me.ChkP_Tutti.AutoSize = True
        Me.ChkP_Tutti.Checked = True
        Me.ChkP_Tutti.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkP_Tutti.Location = New System.Drawing.Point(9, 20)
        Me.ChkP_Tutti.Name = "ChkP_Tutti"
        Me.ChkP_Tutti.Size = New System.Drawing.Size(47, 17)
        Me.ChkP_Tutti.TabIndex = 11
        Me.ChkP_Tutti.Text = "Tutti"
        Me.ChkP_Tutti.UseVisualStyleBackColor = True
        '
        'ChkP_Mensili
        '
        Me.ChkP_Mensili.AutoSize = True
        Me.ChkP_Mensili.Enabled = False
        Me.ChkP_Mensili.Location = New System.Drawing.Point(110, 89)
        Me.ChkP_Mensili.Name = "ChkP_Mensili"
        Me.ChkP_Mensili.Size = New System.Drawing.Size(58, 17)
        Me.ChkP_Mensili.TabIndex = 17
        Me.ChkP_Mensili.Text = "Mensili"
        Me.ChkP_Mensili.UseVisualStyleBackColor = True
        '
        'ChkP_Bimestrali
        '
        Me.ChkP_Bimestrali.AutoSize = True
        Me.ChkP_Bimestrali.Enabled = False
        Me.ChkP_Bimestrali.Location = New System.Drawing.Point(110, 66)
        Me.ChkP_Bimestrali.Name = "ChkP_Bimestrali"
        Me.ChkP_Bimestrali.Size = New System.Drawing.Size(70, 17)
        Me.ChkP_Bimestrali.TabIndex = 16
        Me.ChkP_Bimestrali.Text = "Bimestrali"
        Me.ChkP_Bimestrali.UseVisualStyleBackColor = True
        '
        'ChkP_Trimestrali
        '
        Me.ChkP_Trimestrali.AutoSize = True
        Me.ChkP_Trimestrali.Enabled = False
        Me.ChkP_Trimestrali.Location = New System.Drawing.Point(110, 43)
        Me.ChkP_Trimestrali.Name = "ChkP_Trimestrali"
        Me.ChkP_Trimestrali.Size = New System.Drawing.Size(68, 17)
        Me.ChkP_Trimestrali.TabIndex = 15
        Me.ChkP_Trimestrali.Text = "Trimetrali"
        Me.ChkP_Trimestrali.UseVisualStyleBackColor = True
        '
        'ChkP_Quadrimestrali
        '
        Me.ChkP_Quadrimestrali.AutoSize = True
        Me.ChkP_Quadrimestrali.Enabled = False
        Me.ChkP_Quadrimestrali.Location = New System.Drawing.Point(9, 89)
        Me.ChkP_Quadrimestrali.Name = "ChkP_Quadrimestrali"
        Me.ChkP_Quadrimestrali.Size = New System.Drawing.Size(92, 17)
        Me.ChkP_Quadrimestrali.TabIndex = 14
        Me.ChkP_Quadrimestrali.Text = "Quadrimestrali"
        Me.ChkP_Quadrimestrali.UseVisualStyleBackColor = True
        '
        'ChkP_Semestrali
        '
        Me.ChkP_Semestrali.AutoSize = True
        Me.ChkP_Semestrali.Enabled = False
        Me.ChkP_Semestrali.Location = New System.Drawing.Point(9, 66)
        Me.ChkP_Semestrali.Name = "ChkP_Semestrali"
        Me.ChkP_Semestrali.Size = New System.Drawing.Size(74, 17)
        Me.ChkP_Semestrali.TabIndex = 13
        Me.ChkP_Semestrali.Text = "Semestrali"
        Me.ChkP_Semestrali.UseVisualStyleBackColor = True
        '
        'ChkP_Annuali
        '
        Me.ChkP_Annuali.AutoSize = True
        Me.ChkP_Annuali.Enabled = False
        Me.ChkP_Annuali.Location = New System.Drawing.Point(9, 43)
        Me.ChkP_Annuali.Name = "ChkP_Annuali"
        Me.ChkP_Annuali.Size = New System.Drawing.Size(61, 17)
        Me.ChkP_Annuali.TabIndex = 12
        Me.ChkP_Annuali.Text = "Annuali"
        Me.ChkP_Annuali.UseVisualStyleBackColor = True
        '
        'GroupIstat
        '
        Me.GroupIstat.Controls.Add(Me.Label2)
        Me.GroupIstat.Controls.Add(Me.TxtIstatAttivita)
        Me.GroupIstat.Controls.Add(Me.Label1)
        Me.GroupIstat.Controls.Add(Me.TxtPercIstat)
        Me.GroupIstat.Location = New System.Drawing.Point(12, 430)
        Me.GroupIstat.Name = "GroupIstat"
        Me.GroupIstat.Size = New System.Drawing.Size(228, 76)
        Me.GroupIstat.TabIndex = 15
        Me.GroupIstat.TabStop = False
        Me.GroupIstat.Text = "ISTAT"
        Me.GroupIstat.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Percentuale"
        '
        'TxtPercIstat
        '
        Me.TxtPercIstat.Location = New System.Drawing.Point(110, 20)
        Me.TxtPercIstat.Name = "TxtPercIstat"
        Me.TxtPercIstat.Size = New System.Drawing.Size(100, 20)
        Me.TxtPercIstat.TabIndex = 0
        '
        'TxtIstatAttivita
        '
        Me.TxtIstatAttivita.Location = New System.Drawing.Point(110, 46)
        Me.TxtIstatAttivita.Name = "TxtIstatAttivita"
        Me.TxtIstatAttivita.Size = New System.Drawing.Size(100, 20)
        Me.TxtIstatAttivita.TabIndex = 21
        Me.TxtIstatAttivita.Text = "ISTAT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Attività"
        '
        'FAskFiltriOrdini
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(246, 439)
        Me.Controls.Add(Me.GroupPeriodo)
        Me.Controls.Add(Me.GroupIstat)
        Me.Controls.Add(Me.GroupCompetenza)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupOrdini)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAskFiltriOrdini"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtri"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupOrdini.ResumeLayout(False)
        Me.GroupOrdini.PerformLayout()
        Me.GroupCompetenza.ResumeLayout(False)
        Me.GroupPeriodo.ResumeLayout(False)
        Me.GroupPeriodo.PerformLayout()
        Me.GroupIstat.ResumeLayout(False)
        Me.GroupIstat.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DtaDA As DateTimePicker
    Friend WithEvents DtaA As DateTimePicker
    Friend WithEvents LblDallaData As Label
    Friend WithEvents LblAlladata As Label
    Friend WithEvents GroupOrdini As GroupBox
    Friend WithEvents TxtOrdCliente As TextBox
    Friend WithEvents TxtNrOrdine As TextBox
    Friend WithEvents DtaCompA As DateTimePicker
    Friend WithEvents RadDalAl As RadioButton
    Friend WithEvents RadFinoAllaData As RadioButton
    Friend WithEvents ChkCliente As CheckBox
    Friend WithEvents ChkNrOrdine As CheckBox
    Friend WithEvents GroupCompetenza As GroupBox
    Friend WithEvents GroupPeriodo As GroupBox
    Friend WithEvents ChkP_Tutti As CheckBox
    Friend WithEvents ChkP_Mensili As CheckBox
    Friend WithEvents ChkP_Bimestrali As CheckBox
    Friend WithEvents ChkP_Trimestrali As CheckBox
    Friend WithEvents ChkP_Quadrimestrali As CheckBox
    Friend WithEvents ChkP_Semestrali As CheckBox
    Friend WithEvents ChkP_Annuali As CheckBox
    Friend WithEvents TxtOrdFiliale As TextBox
    Friend WithEvents ChkFiliale As CheckBox
    Friend WithEvents GroupIstat As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtPercIstat As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtIstatAttivita As TextBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
