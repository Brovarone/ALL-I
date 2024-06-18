<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFoxFiliali
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
        Me.ChkOrdAL = New System.Windows.Forms.CheckBox()
        Me.GroupOrdinari = New System.Windows.Forms.GroupBox()
        Me.ChkOrdBI = New System.Windows.Forms.CheckBox()
        Me.ChkOrdVA = New System.Windows.Forms.CheckBox()
        Me.ChkOrdTO = New System.Windows.Forms.CheckBox()
        Me.ChkOrdNO = New System.Windows.Forms.CheckBox()
        Me.ChkOrdMI = New System.Windows.Forms.CheckBox()
        Me.ChkOrdCN = New System.Windows.Forms.CheckBox()
        Me.ChkOrdAT = New System.Windows.Forms.CheckBox()
        Me.ChkOrdAO = New System.Windows.Forms.CheckBox()
        Me.GroupSpeciali = New System.Windows.Forms.GroupBox()
        Me.ChkSpeBI = New System.Windows.Forms.CheckBox()
        Me.ChkSpeVA = New System.Windows.Forms.CheckBox()
        Me.ChkSpeTO = New System.Windows.Forms.CheckBox()
        Me.ChkSpeNO = New System.Windows.Forms.CheckBox()
        Me.ChkSpeMI = New System.Windows.Forms.CheckBox()
        Me.ChkSpeCN = New System.Windows.Forms.CheckBox()
        Me.ChkSpeAT = New System.Windows.Forms.CheckBox()
        Me.ChkSpeAO = New System.Windows.Forms.CheckBox()
        Me.ChkSpeAL = New System.Windows.Forms.CheckBox()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.BtnAnnulla = New System.Windows.Forms.Button()
        Me.ChkAlso2024 = New System.Windows.Forms.CheckBox()
        Me.GroupOrdinari.SuspendLayout()
        Me.GroupSpeciali.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChkOrdAL
        '
        Me.ChkOrdAL.AutoSize = True
        Me.ChkOrdAL.Location = New System.Drawing.Point(6, 19)
        Me.ChkOrdAL.Name = "ChkOrdAL"
        Me.ChkOrdAL.Size = New System.Drawing.Size(80, 17)
        Me.ChkOrdAL.TabIndex = 0
        Me.ChkOrdAL.Tag = ""
        Me.ChkOrdAL.Text = "Alessandria"
        Me.ChkOrdAL.UseVisualStyleBackColor = True
        '
        'GroupOrdinari
        '
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdBI)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdVA)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdTO)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdNO)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdMI)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdCN)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdAT)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdAO)
        Me.GroupOrdinari.Controls.Add(Me.ChkOrdAL)
        Me.GroupOrdinari.Location = New System.Drawing.Point(13, 13)
        Me.GroupOrdinari.Name = "GroupOrdinari"
        Me.GroupOrdinari.Size = New System.Drawing.Size(146, 266)
        Me.GroupOrdinari.TabIndex = 1
        Me.GroupOrdinari.TabStop = False
        Me.GroupOrdinari.Text = "Ordinari"
        '
        'ChkOrdBI
        '
        Me.ChkOrdBI.AutoSize = True
        Me.ChkOrdBI.Location = New System.Drawing.Point(6, 203)
        Me.ChkOrdBI.Name = "ChkOrdBI"
        Me.ChkOrdBI.Size = New System.Drawing.Size(63, 17)
        Me.ChkOrdBI.TabIndex = 8
        Me.ChkOrdBI.Tag = ""
        Me.ChkOrdBI.Text = "Vigliano"
        Me.ChkOrdBI.UseVisualStyleBackColor = True
        '
        'ChkOrdVA
        '
        Me.ChkOrdVA.AutoSize = True
        Me.ChkOrdVA.Location = New System.Drawing.Point(6, 180)
        Me.ChkOrdVA.Name = "ChkOrdVA"
        Me.ChkOrdVA.Size = New System.Drawing.Size(59, 17)
        Me.ChkOrdVA.TabIndex = 7
        Me.ChkOrdVA.Tag = ""
        Me.ChkOrdVA.Text = "Varese"
        Me.ChkOrdVA.UseVisualStyleBackColor = True
        '
        'ChkOrdTO
        '
        Me.ChkOrdTO.AutoSize = True
        Me.ChkOrdTO.Location = New System.Drawing.Point(6, 157)
        Me.ChkOrdTO.Name = "ChkOrdTO"
        Me.ChkOrdTO.Size = New System.Drawing.Size(56, 17)
        Me.ChkOrdTO.TabIndex = 6
        Me.ChkOrdTO.Tag = ""
        Me.ChkOrdTO.Text = "Torino"
        Me.ChkOrdTO.UseVisualStyleBackColor = True
        '
        'ChkOrdNO
        '
        Me.ChkOrdNO.AutoSize = True
        Me.ChkOrdNO.Location = New System.Drawing.Point(6, 134)
        Me.ChkOrdNO.Name = "ChkOrdNO"
        Me.ChkOrdNO.Size = New System.Drawing.Size(61, 17)
        Me.ChkOrdNO.TabIndex = 5
        Me.ChkOrdNO.Tag = ""
        Me.ChkOrdNO.Text = "Novara"
        Me.ChkOrdNO.UseVisualStyleBackColor = True
        '
        'ChkOrdMI
        '
        Me.ChkOrdMI.AutoSize = True
        Me.ChkOrdMI.Location = New System.Drawing.Point(6, 111)
        Me.ChkOrdMI.Name = "ChkOrdMI"
        Me.ChkOrdMI.Size = New System.Drawing.Size(57, 17)
        Me.ChkOrdMI.TabIndex = 4
        Me.ChkOrdMI.Tag = ""
        Me.ChkOrdMI.Text = "Milano"
        Me.ChkOrdMI.UseVisualStyleBackColor = True
        '
        'ChkOrdCN
        '
        Me.ChkOrdCN.AutoSize = True
        Me.ChkOrdCN.Location = New System.Drawing.Point(6, 88)
        Me.ChkOrdCN.Name = "ChkOrdCN"
        Me.ChkOrdCN.Size = New System.Drawing.Size(57, 17)
        Me.ChkOrdCN.TabIndex = 3
        Me.ChkOrdCN.Tag = ""
        Me.ChkOrdCN.Text = "Cuneo"
        Me.ChkOrdCN.UseVisualStyleBackColor = True
        '
        'ChkOrdAT
        '
        Me.ChkOrdAT.AutoSize = True
        Me.ChkOrdAT.Location = New System.Drawing.Point(6, 65)
        Me.ChkOrdAT.Name = "ChkOrdAT"
        Me.ChkOrdAT.Size = New System.Drawing.Size(43, 17)
        Me.ChkOrdAT.TabIndex = 2
        Me.ChkOrdAT.Tag = ""
        Me.ChkOrdAT.Text = "Asti"
        Me.ChkOrdAT.UseVisualStyleBackColor = True
        '
        'ChkOrdAO
        '
        Me.ChkOrdAO.AutoSize = True
        Me.ChkOrdAO.Location = New System.Drawing.Point(6, 42)
        Me.ChkOrdAO.Name = "ChkOrdAO"
        Me.ChkOrdAO.Size = New System.Drawing.Size(53, 17)
        Me.ChkOrdAO.TabIndex = 1
        Me.ChkOrdAO.Tag = ""
        Me.ChkOrdAO.Text = "Aosta"
        Me.ChkOrdAO.UseVisualStyleBackColor = True
        '
        'GroupSpeciali
        '
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeBI)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeVA)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeTO)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeNO)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeMI)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeCN)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeAT)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeAO)
        Me.GroupSpeciali.Controls.Add(Me.ChkSpeAL)
        Me.GroupSpeciali.Location = New System.Drawing.Point(187, 13)
        Me.GroupSpeciali.Name = "GroupSpeciali"
        Me.GroupSpeciali.Size = New System.Drawing.Size(146, 266)
        Me.GroupSpeciali.TabIndex = 9
        Me.GroupSpeciali.TabStop = False
        Me.GroupSpeciali.Text = "Speciali"
        '
        'ChkSpeBI
        '
        Me.ChkSpeBI.AutoSize = True
        Me.ChkSpeBI.Location = New System.Drawing.Point(6, 203)
        Me.ChkSpeBI.Name = "ChkSpeBI"
        Me.ChkSpeBI.Size = New System.Drawing.Size(63, 17)
        Me.ChkSpeBI.TabIndex = 8
        Me.ChkSpeBI.Tag = ""
        Me.ChkSpeBI.Text = "Vigliano"
        Me.ChkSpeBI.UseVisualStyleBackColor = True
        '
        'ChkSpeVA
        '
        Me.ChkSpeVA.AutoSize = True
        Me.ChkSpeVA.Location = New System.Drawing.Point(6, 180)
        Me.ChkSpeVA.Name = "ChkSpeVA"
        Me.ChkSpeVA.Size = New System.Drawing.Size(59, 17)
        Me.ChkSpeVA.TabIndex = 7
        Me.ChkSpeVA.Tag = ""
        Me.ChkSpeVA.Text = "Varese"
        Me.ChkSpeVA.UseVisualStyleBackColor = True
        '
        'ChkSpeTO
        '
        Me.ChkSpeTO.AutoSize = True
        Me.ChkSpeTO.Location = New System.Drawing.Point(6, 157)
        Me.ChkSpeTO.Name = "ChkSpeTO"
        Me.ChkSpeTO.Size = New System.Drawing.Size(56, 17)
        Me.ChkSpeTO.TabIndex = 6
        Me.ChkSpeTO.Tag = ""
        Me.ChkSpeTO.Text = "Torino"
        Me.ChkSpeTO.UseVisualStyleBackColor = True
        '
        'ChkSpeNO
        '
        Me.ChkSpeNO.AutoSize = True
        Me.ChkSpeNO.Location = New System.Drawing.Point(6, 134)
        Me.ChkSpeNO.Name = "ChkSpeNO"
        Me.ChkSpeNO.Size = New System.Drawing.Size(61, 17)
        Me.ChkSpeNO.TabIndex = 5
        Me.ChkSpeNO.Tag = ""
        Me.ChkSpeNO.Text = "Novara"
        Me.ChkSpeNO.UseVisualStyleBackColor = True
        '
        'ChkSpeMI
        '
        Me.ChkSpeMI.AutoSize = True
        Me.ChkSpeMI.Location = New System.Drawing.Point(6, 111)
        Me.ChkSpeMI.Name = "ChkSpeMI"
        Me.ChkSpeMI.Size = New System.Drawing.Size(57, 17)
        Me.ChkSpeMI.TabIndex = 4
        Me.ChkSpeMI.Tag = ""
        Me.ChkSpeMI.Text = "Milano"
        Me.ChkSpeMI.UseVisualStyleBackColor = True
        '
        'ChkSpeCN
        '
        Me.ChkSpeCN.AutoSize = True
        Me.ChkSpeCN.Location = New System.Drawing.Point(6, 88)
        Me.ChkSpeCN.Name = "ChkSpeCN"
        Me.ChkSpeCN.Size = New System.Drawing.Size(57, 17)
        Me.ChkSpeCN.TabIndex = 3
        Me.ChkSpeCN.Tag = ""
        Me.ChkSpeCN.Text = "Cuneo"
        Me.ChkSpeCN.UseVisualStyleBackColor = True
        '
        'ChkSpeAT
        '
        Me.ChkSpeAT.AutoSize = True
        Me.ChkSpeAT.Location = New System.Drawing.Point(6, 65)
        Me.ChkSpeAT.Name = "ChkSpeAT"
        Me.ChkSpeAT.Size = New System.Drawing.Size(43, 17)
        Me.ChkSpeAT.TabIndex = 2
        Me.ChkSpeAT.Tag = ""
        Me.ChkSpeAT.Text = "Asti"
        Me.ChkSpeAT.UseVisualStyleBackColor = True
        '
        'ChkSpeAO
        '
        Me.ChkSpeAO.AutoSize = True
        Me.ChkSpeAO.Location = New System.Drawing.Point(6, 42)
        Me.ChkSpeAO.Name = "ChkSpeAO"
        Me.ChkSpeAO.Size = New System.Drawing.Size(53, 17)
        Me.ChkSpeAO.TabIndex = 1
        Me.ChkSpeAO.Tag = ""
        Me.ChkSpeAO.Text = "Aosta"
        Me.ChkSpeAO.UseVisualStyleBackColor = True
        '
        'ChkSpeAL
        '
        Me.ChkSpeAL.AutoSize = True
        Me.ChkSpeAL.Location = New System.Drawing.Point(6, 19)
        Me.ChkSpeAL.Name = "ChkSpeAL"
        Me.ChkSpeAL.Size = New System.Drawing.Size(80, 17)
        Me.ChkSpeAL.TabIndex = 0
        Me.ChkSpeAL.Tag = ""
        Me.ChkSpeAL.Text = "Alessandria"
        Me.ChkSpeAL.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Location = New System.Drawing.Point(84, 321)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnOk.TabIndex = 10
        Me.BtnOk.Text = "OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BtnAnnulla
        '
        Me.BtnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAnnulla.Location = New System.Drawing.Point(171, 321)
        Me.BtnAnnulla.Name = "BtnAnnulla"
        Me.BtnAnnulla.Size = New System.Drawing.Size(75, 23)
        Me.BtnAnnulla.TabIndex = 11
        Me.BtnAnnulla.Text = "Annulla"
        Me.BtnAnnulla.UseVisualStyleBackColor = True
        '
        'ChkAlso2024
        '
        Me.ChkAlso2024.AutoSize = True
        Me.ChkAlso2024.Checked = True
        Me.ChkAlso2024.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAlso2024.Location = New System.Drawing.Point(19, 286)
        Me.ChkAlso2024.Name = "ChkAlso2024"
        Me.ChkAlso2024.Size = New System.Drawing.Size(91, 17)
        Me.ChkAlso2024.TabIndex = 12
        Me.ChkAlso2024.Text = "Con File 2024"
        Me.ChkAlso2024.UseVisualStyleBackColor = True
        '
        'frmFoxFiliali
        '
        Me.AcceptButton = Me.BtnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnAnnulla
        Me.ClientSize = New System.Drawing.Size(345, 372)
        Me.Controls.Add(Me.ChkAlso2024)
        Me.Controls.Add(Me.BtnAnnulla)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupSpeciali)
        Me.Controls.Add(Me.GroupOrdinari)
        Me.Name = "frmFoxFiliali"
        Me.Text = "Scelta Filiali"
        Me.GroupOrdinari.ResumeLayout(False)
        Me.GroupOrdinari.PerformLayout()
        Me.GroupSpeciali.ResumeLayout(False)
        Me.GroupSpeciali.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChkOrdAL As CheckBox
    Friend WithEvents GroupOrdinari As GroupBox
    Friend WithEvents ChkOrdBI As CheckBox
    Friend WithEvents ChkOrdVA As CheckBox
    Friend WithEvents ChkOrdTO As CheckBox
    Friend WithEvents ChkOrdNO As CheckBox
    Friend WithEvents ChkOrdMI As CheckBox
    Friend WithEvents ChkOrdCN As CheckBox
    Friend WithEvents ChkOrdAT As CheckBox
    Friend WithEvents ChkOrdAO As CheckBox
    Friend WithEvents GroupSpeciali As GroupBox
    Friend WithEvents ChkSpeBI As CheckBox
    Friend WithEvents ChkSpeVA As CheckBox
    Friend WithEvents ChkSpeTO As CheckBox
    Friend WithEvents ChkSpeNO As CheckBox
    Friend WithEvents ChkSpeMI As CheckBox
    Friend WithEvents ChkSpeCN As CheckBox
    Friend WithEvents ChkSpeAT As CheckBox
    Friend WithEvents ChkSpeAO As CheckBox
    Friend WithEvents ChkSpeAL As CheckBox
    Friend WithEvents BtnOk As Button
    Friend WithEvents BtnAnnulla As Button
    Friend WithEvents ChkAlso2024 As CheckBox
End Class
