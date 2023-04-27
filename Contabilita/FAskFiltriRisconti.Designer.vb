<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAskFiltriRisconti
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtaScritture = New System.Windows.Forms.DateTimePicker()
        Me.chkFormatoRidotto = New System.Windows.Forms.CheckBox()
        Me.chkScriviAnalitica = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 95)
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
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Data Scritture"
        '
        'DtaScritture
        '
        Me.DtaScritture.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaScritture.Location = New System.Drawing.Point(39, 27)
        Me.DtaScritture.Name = "DtaScritture"
        Me.DtaScritture.Size = New System.Drawing.Size(96, 20)
        Me.DtaScritture.TabIndex = 14
        '
        'chkFormatoRidotto
        '
        Me.chkFormatoRidotto.AutoSize = True
        Me.chkFormatoRidotto.Checked = True
        Me.chkFormatoRidotto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFormatoRidotto.Location = New System.Drawing.Point(39, 54)
        Me.chkFormatoRidotto.Name = "chkFormatoRidotto"
        Me.chkFormatoRidotto.Size = New System.Drawing.Size(108, 17)
        Me.chkFormatoRidotto.TabIndex = 15
        Me.chkFormatoRidotto.Text = "xls formato ridotto"
        Me.chkFormatoRidotto.UseVisualStyleBackColor = True
        '
        'chkScriviAnalitica
        '
        Me.chkScriviAnalitica.AutoSize = True
        Me.chkScriviAnalitica.Enabled = False
        Me.chkScriviAnalitica.Location = New System.Drawing.Point(39, 72)
        Me.chkScriviAnalitica.Name = "chkScriviAnalitica"
        Me.chkScriviAnalitica.Size = New System.Drawing.Size(94, 17)
        Me.chkScriviAnalitica.TabIndex = 16
        Me.chkScriviAnalitica.Text = "Scrivi analitica"
        Me.chkScriviAnalitica.UseVisualStyleBackColor = True
        '
        'DataRiscontiDialogBox
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(172, 136)
        Me.Controls.Add(Me.chkScriviAnalitica)
        Me.Controls.Add(Me.chkFormatoRidotto)
        Me.Controls.Add(Me.DtaScritture)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DataRiscontiDialogBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Risconti"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DtaScritture As DateTimePicker
    Friend WithEvents chkFormatoRidotto As CheckBox
    Friend WithEvents chkScriviAnalitica As CheckBox
End Class
