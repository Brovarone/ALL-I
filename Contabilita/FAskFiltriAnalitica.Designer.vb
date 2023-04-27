<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAskFiltriAnalitica
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DtaPickDA = New System.Windows.Forms.DateTimePicker()
        Me.DtaPickA = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkGiaRegistrati = New System.Windows.Forms.CheckBox()
        Me.ChkMovInAna = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtNumberLast = New System.Windows.Forms.TextBox()
        Me.TxtNumberFirst = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkAdeguaCampi = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(88, 238)
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
        Me.OK_Button.TabIndex = 7
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 8
        Me.Cancel_Button.Text = "Cancel"
        '
        'DtaPickDA
        '
        Me.DtaPickDA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaPickDA.Location = New System.Drawing.Point(87, 23)
        Me.DtaPickDA.Name = "DtaPickDA"
        Me.DtaPickDA.Size = New System.Drawing.Size(96, 20)
        Me.DtaPickDA.TabIndex = 0
        '
        'DtaPickA
        '
        Me.DtaPickA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaPickA.Location = New System.Drawing.Point(87, 52)
        Me.DtaPickA.Name = "DtaPickA"
        Me.DtaPickA.Size = New System.Drawing.Size(96, 20)
        Me.DtaPickA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Dalla data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Alla data"
        '
        'ChkGiaRegistrati
        '
        Me.ChkGiaRegistrati.AutoSize = True
        Me.ChkGiaRegistrati.Location = New System.Drawing.Point(81, 127)
        Me.ChkGiaRegistrati.Name = "ChkGiaRegistrati"
        Me.ChkGiaRegistrati.Size = New System.Drawing.Size(116, 17)
        Me.ChkGiaRegistrati.TabIndex = 4
        Me.ChkGiaRegistrati.Text = "Anche già registrati"
        Me.ChkGiaRegistrati.UseVisualStyleBackColor = True
        '
        'ChkMovInAna
        '
        Me.ChkMovInAna.AutoSize = True
        Me.ChkMovInAna.Checked = True
        Me.ChkMovInAna.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMovInAna.Location = New System.Drawing.Point(87, 201)
        Me.ChkMovInAna.Name = "ChkMovInAna"
        Me.ChkMovInAna.Size = New System.Drawing.Size(143, 17)
        Me.ChkMovInAna.TabIndex = 6
        Me.ChkMovInAna.Text = "Movimentabili in analitica"
        Me.ChkMovInAna.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNumberLast)
        Me.GroupBox1.Controls.Add(Me.TxtNumberFirst)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkGiaRegistrati)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 155)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documenti di vendita"
        '
        'TxtNumberLast
        '
        Me.TxtNumberLast.Location = New System.Drawing.Point(81, 101)
        Me.TxtNumberLast.Name = "TxtNumberLast"
        Me.TxtNumberLast.Size = New System.Drawing.Size(96, 20)
        Me.TxtNumberLast.TabIndex = 3
        '
        'TxtNumberFirst
        '
        Me.TxtNumberFirst.Location = New System.Drawing.Point(81, 75)
        Me.TxtNumberFirst.Name = "TxtNumberFirst"
        Me.TxtNumberFirst.Size = New System.Drawing.Size(96, 20)
        Me.TxtNumberFirst.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Al numero"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Dal numero"
        '
        'ChkAdeguaCampi
        '
        Me.ChkAdeguaCampi.AutoSize = True
        Me.ChkAdeguaCampi.Location = New System.Drawing.Point(15, 164)
        Me.ChkAdeguaCampi.Name = "ChkAdeguaCampi"
        Me.ChkAdeguaCampi.Size = New System.Drawing.Size(183, 17)
        Me.ChkAdeguaCampi.TabIndex = 5
        Me.ChkAdeguaCampi.Text = "Adegua Canoni e Date da Ordine"
        Me.ChkAdeguaCampi.UseVisualStyleBackColor = True
        '
        'FAskFiltriAnalitica
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(246, 279)
        Me.Controls.Add(Me.ChkAdeguaCampi)
        Me.Controls.Add(Me.ChkMovInAna)
        Me.Controls.Add(Me.DtaPickA)
        Me.Controls.Add(Me.DtaPickDA)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAskFiltriAnalitica"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtri"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DtaPickDA As DateTimePicker
    Friend WithEvents DtaPickA As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ChkGiaRegistrati As CheckBox
    Friend WithEvents ChkMovInAna As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtNumberLast As TextBox
    Friend WithEvents TxtNumberFirst As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ChkAdeguaCampi As CheckBox
End Class
