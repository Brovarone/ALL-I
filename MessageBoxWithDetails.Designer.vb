<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MessageBoxWithDetails
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDetails = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.tbDetails = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(267, 37)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Chiudi"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDetails
        '
        Me.btnDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDetails.Enabled = False
        Me.btnDetails.Location = New System.Drawing.Point(12, 37)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Size = New System.Drawing.Size(75, 23)
        Me.btnDetails.TabIndex = 1
        Me.btnDetails.Text = "Dettagli"
        Me.btnDetails.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.Location = New System.Drawing.Point(93, 37)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(102, 23)
        Me.btnCopy.TabIndex = 4
        Me.btnCopy.Text = "Copia"
        Me.btnCopy.UseVisualStyleBackColor = True
        Me.btnCopy.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(12, 9)
        Me.lblMessage.MaximumSize = New System.Drawing.Size(310, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(35, 13)
        Me.lblMessage.TabIndex = 5
        Me.lblMessage.Text = "label1"
        '
        'tbDetails
        '
        Me.tbDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tbDetails.Location = New System.Drawing.Point(12, 68)
        Me.tbDetails.MaximumSize = New System.Drawing.Size(328, 100)
        Me.tbDetails.Multiline = True
        Me.tbDetails.Name = "tbDetails"
        Me.tbDetails.ReadOnly = True
        Me.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbDetails.Size = New System.Drawing.Size(328, 100)
        Me.tbDetails.TabIndex = 6
        Me.tbDetails.Visible = False
        '
        'MessageBoxWithDetails
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 72)
        Me.Controls.Add(Me.tbDetails)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnDetails)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageBoxWithDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents btnClose As Button
    Friend WithEvents btnDetails As Button
    Friend WithEvents btnCopy As Button
    Friend WithEvents lblMessage As Label
    Friend WithEvents tbDetails As TextBox
End Class
