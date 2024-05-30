<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAskFiltriOrdiniConsuntivo
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.LblMonth = New System.Windows.Forms.Label()
        Me.RadOnlyCheck = New System.Windows.Forms.RadioButton()
        Me.RadCheckAndFatt = New System.Windows.Forms.RadioButton()
        Me.RadOnlyFatt = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtaFatt = New System.Windows.Forms.DateTimePicker()
        Me.CmbMonth = New System.Windows.Forms.ComboBox()
        Me.TxtOrdFiliale = New System.Windows.Forms.TextBox()
        Me.ChkFiliale = New System.Windows.Forms.CheckBox()
        Me.firstLogDate = New System.Windows.Forms.DateTimePicker()
        Me.lastLogDate = New System.Windows.Forms.DateTimePicker()
        Me.ChkNoFilter = New System.Windows.Forms.CheckBox()
        Me.CmbYear = New System.Windows.Forms.ComboBox()
        Me.LblYear = New System.Windows.Forms.Label()
        Me.ChkRiassegna = New System.Windows.Forms.CheckBox()
        Me.GroupBoxCheck = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBoxCheck.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(154, 291)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annulla"
        '
        'LblMonth
        '
        Me.LblMonth.AutoSize = True
        Me.LblMonth.Location = New System.Drawing.Point(12, 36)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(33, 13)
        Me.LblMonth.TabIndex = 2
        Me.LblMonth.Text = "Mese"
        '
        'RadOnlyCheck
        '
        Me.RadOnlyCheck.AutoSize = True
        Me.RadOnlyCheck.Checked = True
        Me.RadOnlyCheck.Enabled = False
        Me.RadOnlyCheck.Location = New System.Drawing.Point(6, 19)
        Me.RadOnlyCheck.Name = "RadOnlyCheck"
        Me.RadOnlyCheck.Size = New System.Drawing.Size(90, 17)
        Me.RadOnlyCheck.TabIndex = 3
        Me.RadOnlyCheck.TabStop = True
        Me.RadOnlyCheck.Text = "Solo Controllo"
        Me.RadOnlyCheck.UseVisualStyleBackColor = True
        '
        'RadCheckAndFatt
        '
        Me.RadCheckAndFatt.AutoSize = True
        Me.RadCheckAndFatt.Enabled = False
        Me.RadCheckAndFatt.Location = New System.Drawing.Point(6, 42)
        Me.RadCheckAndFatt.Name = "RadCheckAndFatt"
        Me.RadCheckAndFatt.Size = New System.Drawing.Size(136, 17)
        Me.RadCheckAndFatt.TabIndex = 4
        Me.RadCheckAndFatt.Text = "Controllo + Fatturazione"
        Me.RadCheckAndFatt.UseVisualStyleBackColor = True
        '
        'RadOnlyFatt
        '
        Me.RadOnlyFatt.AutoSize = True
        Me.RadOnlyFatt.Enabled = False
        Me.RadOnlyFatt.Location = New System.Drawing.Point(6, 87)
        Me.RadOnlyFatt.Name = "RadOnlyFatt"
        Me.RadOnlyFatt.Size = New System.Drawing.Size(107, 17)
        Me.RadOnlyFatt.TabIndex = 5
        Me.RadOnlyFatt.Text = "Solo Fatturazione"
        Me.RadOnlyFatt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Data Fatt,"
        '
        'DtaFatt
        '
        Me.DtaFatt.Enabled = False
        Me.DtaFatt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaFatt.Location = New System.Drawing.Point(72, 220)
        Me.DtaFatt.Name = "DtaFatt"
        Me.DtaFatt.Size = New System.Drawing.Size(96, 20)
        Me.DtaFatt.TabIndex = 8
        '
        'CmbMonth
        '
        Me.CmbMonth.Enabled = False
        Me.CmbMonth.FormattingEnabled = True
        Me.CmbMonth.Location = New System.Drawing.Point(72, 33)
        Me.CmbMonth.Name = "CmbMonth"
        Me.CmbMonth.Size = New System.Drawing.Size(106, 21)
        Me.CmbMonth.TabIndex = 9
        '
        'TxtOrdFiliale
        '
        Me.TxtOrdFiliale.Enabled = False
        Me.TxtOrdFiliale.Location = New System.Drawing.Point(107, 246)
        Me.TxtOrdFiliale.Name = "TxtOrdFiliale"
        Me.TxtOrdFiliale.Size = New System.Drawing.Size(96, 20)
        Me.TxtOrdFiliale.TabIndex = 12
        '
        'ChkFiliale
        '
        Me.ChkFiliale.AutoSize = True
        Me.ChkFiliale.Enabled = False
        Me.ChkFiliale.Location = New System.Drawing.Point(6, 246)
        Me.ChkFiliale.Name = "ChkFiliale"
        Me.ChkFiliale.Size = New System.Drawing.Size(90, 17)
        Me.ChkFiliale.TabIndex = 11
        Me.ChkFiliale.Text = "Singola Filiale"
        Me.ChkFiliale.UseVisualStyleBackColor = True
        '
        'firstLogDate
        '
        Me.firstLogDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.firstLogDate.Location = New System.Drawing.Point(201, 33)
        Me.firstLogDate.Name = "firstLogDate"
        Me.firstLogDate.Size = New System.Drawing.Size(96, 20)
        Me.firstLogDate.TabIndex = 13
        '
        'lastLogDate
        '
        Me.lastLogDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.lastLogDate.Location = New System.Drawing.Point(201, 59)
        Me.lastLogDate.Name = "lastLogDate"
        Me.lastLogDate.Size = New System.Drawing.Size(96, 20)
        Me.lastLogDate.TabIndex = 14
        '
        'ChkNoFilter
        '
        Me.ChkNoFilter.AutoSize = True
        Me.ChkNoFilter.Location = New System.Drawing.Point(15, 10)
        Me.ChkNoFilter.Name = "ChkNoFilter"
        Me.ChkNoFilter.Size = New System.Drawing.Size(48, 17)
        Me.ChkNoFilter.TabIndex = 15
        Me.ChkNoFilter.Text = "Filtra"
        Me.ChkNoFilter.UseVisualStyleBackColor = True
        '
        'CmbYear
        '
        Me.CmbYear.Enabled = False
        Me.CmbYear.FormattingEnabled = True
        Me.CmbYear.Location = New System.Drawing.Point(72, 62)
        Me.CmbYear.Name = "CmbYear"
        Me.CmbYear.Size = New System.Drawing.Size(106, 21)
        Me.CmbYear.TabIndex = 17
        '
        'LblYear
        '
        Me.LblYear.AutoSize = True
        Me.LblYear.Location = New System.Drawing.Point(12, 65)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(33, 13)
        Me.LblYear.TabIndex = 16
        Me.LblYear.Text = "Mese"
        '
        'ChkRiassegna
        '
        Me.ChkRiassegna.AutoSize = True
        Me.ChkRiassegna.Enabled = False
        Me.ChkRiassegna.Location = New System.Drawing.Point(6, 65)
        Me.ChkRiassegna.Name = "ChkRiassegna"
        Me.ChkRiassegna.Size = New System.Drawing.Size(76, 17)
        Me.ChkRiassegna.TabIndex = 18
        Me.ChkRiassegna.Text = "Riassegna"
        Me.ChkRiassegna.UseVisualStyleBackColor = True
        '
        'GroupBoxCheck
        '
        Me.GroupBoxCheck.Controls.Add(Me.RadOnlyCheck)
        Me.GroupBoxCheck.Controls.Add(Me.ChkRiassegna)
        Me.GroupBoxCheck.Controls.Add(Me.RadCheckAndFatt)
        Me.GroupBoxCheck.Controls.Add(Me.RadOnlyFatt)
        Me.GroupBoxCheck.Location = New System.Drawing.Point(72, 89)
        Me.GroupBoxCheck.Name = "GroupBoxCheck"
        Me.GroupBoxCheck.Size = New System.Drawing.Size(200, 114)
        Me.GroupBoxCheck.TabIndex = 19
        Me.GroupBoxCheck.TabStop = False
        '
        'FAskFiltriOrdiniConsuntivo
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(312, 332)
        Me.Controls.Add(Me.GroupBoxCheck)
        Me.Controls.Add(Me.CmbYear)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.ChkNoFilter)
        Me.Controls.Add(Me.lastLogDate)
        Me.Controls.Add(Me.firstLogDate)
        Me.Controls.Add(Me.TxtOrdFiliale)
        Me.Controls.Add(Me.ChkFiliale)
        Me.Controls.Add(Me.CmbMonth)
        Me.Controls.Add(Me.DtaFatt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblMonth)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAskFiltriOrdiniConsuntivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consuntivazione"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBoxCheck.ResumeLayout(False)
        Me.GroupBoxCheck.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LblMonth As Label
    Friend WithEvents RadOnlyCheck As RadioButton
    Friend WithEvents RadCheckAndFatt As RadioButton
    Friend WithEvents RadOnlyFatt As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents DtaFatt As DateTimePicker
    Friend WithEvents CmbMonth As ComboBox
    Friend WithEvents TxtOrdFiliale As TextBox
    Friend WithEvents ChkFiliale As CheckBox
    Friend WithEvents firstLogDate As DateTimePicker
    Friend WithEvents lastLogDate As DateTimePicker
    Friend WithEvents ChkNoFilter As CheckBox
    Friend WithEvents CmbYear As ComboBox
    Friend WithEvents LblYear As Label
    Friend WithEvents ChkRiassegna As CheckBox
    Friend WithEvents GroupBoxCheck As GroupBox
End Class
