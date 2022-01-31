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
        Me.DtaOrdineDA = New System.Windows.Forms.DateTimePicker()
        Me.DtaOrdineA = New System.Windows.Forms.DateTimePicker()
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
        Me.DtaFattA = New System.Windows.Forms.DateTimePicker()
        Me.GroupDataFatt = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DtaFattDa = New System.Windows.Forms.DateTimePicker()
        Me.GroupPeriodo = New System.Windows.Forms.GroupBox()
        Me.ChkP_Tutti = New System.Windows.Forms.CheckBox()
        Me.ChkP_Mensili = New System.Windows.Forms.CheckBox()
        Me.ChkP_Bimestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Trimestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Quadrimestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Semestrali = New System.Windows.Forms.CheckBox()
        Me.ChkP_Annuali = New System.Windows.Forms.CheckBox()
        Me.GroupIstat = New System.Windows.Forms.GroupBox()
        Me.LblAnnoAdeguamento = New System.Windows.Forms.Label()
        Me.TxtAnnoAdeguamento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtIstatTesto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtIstatAttivita = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPercIstat = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupDecorrenza = New System.Windows.Forms.GroupBox()
        Me.DtaDecorrenza = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupOrdini.SuspendLayout()
        Me.GroupDataFatt.SuspendLayout()
        Me.GroupPeriodo.SuspendLayout()
        Me.GroupIstat.SuspendLayout()
        Me.GroupDecorrenza.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(337, 436)
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
        Me.OK_Button.TabIndex = 22
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 23
        Me.Cancel_Button.Text = "Cancel"
        '
        'DtaOrdineDA
        '
        Me.DtaOrdineDA.Enabled = False
        Me.DtaOrdineDA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaOrdineDA.Location = New System.Drawing.Point(96, 65)
        Me.DtaOrdineDA.Name = "DtaOrdineDA"
        Me.DtaOrdineDA.Size = New System.Drawing.Size(96, 20)
        Me.DtaOrdineDA.TabIndex = 3
        '
        'DtaOrdineA
        '
        Me.DtaOrdineA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaOrdineA.Location = New System.Drawing.Point(96, 94)
        Me.DtaOrdineA.Name = "DtaOrdineA"
        Me.DtaOrdineA.Size = New System.Drawing.Size(96, 20)
        Me.DtaOrdineA.TabIndex = 4
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
        Me.GroupOrdini.Controls.Add(Me.DtaOrdineA)
        Me.GroupOrdini.Controls.Add(Me.DtaOrdineDA)
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
        'DtaFattA
        '
        Me.DtaFattA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaFattA.Location = New System.Drawing.Point(110, 45)
        Me.DtaFattA.Name = "DtaFattA"
        Me.DtaFattA.Size = New System.Drawing.Size(96, 20)
        Me.DtaFattA.TabIndex = 11
        '
        'GroupDataFatt
        '
        Me.GroupDataFatt.Controls.Add(Me.Label6)
        Me.GroupDataFatt.Controls.Add(Me.Label7)
        Me.GroupDataFatt.Controls.Add(Me.DtaFattDa)
        Me.GroupDataFatt.Controls.Add(Me.DtaFattA)
        Me.GroupDataFatt.Location = New System.Drawing.Point(6, 224)
        Me.GroupDataFatt.Name = "GroupDataFatt"
        Me.GroupDataFatt.Size = New System.Drawing.Size(228, 81)
        Me.GroupDataFatt.TabIndex = 14
        Me.GroupDataFatt.TabStop = False
        Me.GroupDataFatt.Text = "Data prossima fattura"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Alla data"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Dalla data"
        '
        'DtaFattDa
        '
        Me.DtaFattDa.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaFattDa.Location = New System.Drawing.Point(110, 19)
        Me.DtaFattDa.Name = "DtaFattDa"
        Me.DtaFattDa.Size = New System.Drawing.Size(96, 20)
        Me.DtaFattDa.TabIndex = 12
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
        Me.GroupPeriodo.Location = New System.Drawing.Point(6, 311)
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
        Me.GroupIstat.Controls.Add(Me.LblAnnoAdeguamento)
        Me.GroupIstat.Controls.Add(Me.TxtAnnoAdeguamento)
        Me.GroupIstat.Controls.Add(Me.Label4)
        Me.GroupIstat.Controls.Add(Me.TxtIstatTesto)
        Me.GroupIstat.Controls.Add(Me.Label2)
        Me.GroupIstat.Controls.Add(Me.TxtIstatAttivita)
        Me.GroupIstat.Controls.Add(Me.Label1)
        Me.GroupIstat.Controls.Add(Me.TxtPercIstat)
        Me.GroupIstat.Enabled = False
        Me.GroupIstat.Location = New System.Drawing.Point(249, 279)
        Me.GroupIstat.Name = "GroupIstat"
        Me.GroupIstat.Size = New System.Drawing.Size(228, 131)
        Me.GroupIstat.TabIndex = 15
        Me.GroupIstat.TabStop = False
        Me.GroupIstat.Text = "ISTAT"
        Me.GroupIstat.Visible = False
        '
        'LblAnnoAdeguamento
        '
        Me.LblAnnoAdeguamento.AutoSize = True
        Me.LblAnnoAdeguamento.Location = New System.Drawing.Point(43, 43)
        Me.LblAnnoAdeguamento.Name = "LblAnnoAdeguamento"
        Me.LblAnnoAdeguamento.Size = New System.Drawing.Size(134, 13)
        Me.LblAnnoAdeguamento.TabIndex = 28
        Me.LblAnnoAdeguamento.Text = "Anno adeguamento ISTAT"
        '
        'TxtAnnoAdeguamento
        '
        Me.TxtAnnoAdeguamento.Location = New System.Drawing.Point(182, 40)
        Me.TxtAnnoAdeguamento.Name = "TxtAnnoAdeguamento"
        Me.TxtAnnoAdeguamento.Size = New System.Drawing.Size(40, 20)
        Me.TxtAnnoAdeguamento.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Testo"
        '
        'TxtIstatTesto
        '
        Me.TxtIstatTesto.Location = New System.Drawing.Point(46, 72)
        Me.TxtIstatTesto.Multiline = True
        Me.TxtIstatTesto.Name = "TxtIstatTesto"
        Me.TxtIstatTesto.Size = New System.Drawing.Size(176, 44)
        Me.TxtIstatTesto.TabIndex = 21
        Me.TxtIstatTesto.Text = "Il canone è aggiornato sulla base dell'indice ISTAT relativo al mese di novembre " &
    "2021"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Attività"
        '
        'TxtIstatAttivita
        '
        Me.TxtIstatAttivita.Location = New System.Drawing.Point(182, 13)
        Me.TxtIstatAttivita.Name = "TxtIstatAttivita"
        Me.TxtIstatAttivita.Size = New System.Drawing.Size(40, 20)
        Me.TxtIstatAttivita.TabIndex = 19
        Me.TxtIstatAttivita.Text = "ISTAT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Percentuale"
        '
        'TxtPercIstat
        '
        Me.TxtPercIstat.Location = New System.Drawing.Point(85, 13)
        Me.TxtPercIstat.Name = "TxtPercIstat"
        Me.TxtPercIstat.Size = New System.Drawing.Size(36, 20)
        Me.TxtPercIstat.TabIndex = 18
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 80
        '
        'GroupDecorrenza
        '
        Me.GroupDecorrenza.Controls.Add(Me.DtaDecorrenza)
        Me.GroupDecorrenza.Enabled = False
        Me.GroupDecorrenza.Location = New System.Drawing.Point(249, 224)
        Me.GroupDecorrenza.Name = "GroupDecorrenza"
        Me.GroupDecorrenza.Size = New System.Drawing.Size(228, 49)
        Me.GroupDecorrenza.TabIndex = 25
        Me.GroupDecorrenza.TabStop = False
        Me.GroupDecorrenza.Text = "Decorrenza inferiore a"
        '
        'DtaDecorrenza
        '
        Me.DtaDecorrenza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtaDecorrenza.Location = New System.Drawing.Point(110, 19)
        Me.DtaDecorrenza.Name = "DtaDecorrenza"
        Me.DtaDecorrenza.Size = New System.Drawing.Size(96, 20)
        Me.DtaDecorrenza.TabIndex = 12
        '
        'FAskFiltriOrdini
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(495, 477)
        Me.Controls.Add(Me.GroupDecorrenza)
        Me.Controls.Add(Me.GroupIstat)
        Me.Controls.Add(Me.GroupPeriodo)
        Me.Controls.Add(Me.GroupDataFatt)
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
        Me.GroupDataFatt.ResumeLayout(False)
        Me.GroupDataFatt.PerformLayout()
        Me.GroupPeriodo.ResumeLayout(False)
        Me.GroupPeriodo.PerformLayout()
        Me.GroupIstat.ResumeLayout(False)
        Me.GroupIstat.PerformLayout()
        Me.GroupDecorrenza.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DtaOrdineDA As DateTimePicker
    Friend WithEvents DtaOrdineA As DateTimePicker
    Friend WithEvents LblDallaData As Label
    Friend WithEvents LblAlladata As Label
    Friend WithEvents GroupOrdini As GroupBox
    Friend WithEvents TxtOrdCliente As TextBox
    Friend WithEvents TxtNrOrdine As TextBox
    Friend WithEvents DtaFattA As DateTimePicker
    Friend WithEvents RadDalAl As RadioButton
    Friend WithEvents RadFinoAllaData As RadioButton
    Friend WithEvents ChkCliente As CheckBox
    Friend WithEvents ChkNrOrdine As CheckBox
    Friend WithEvents GroupDataFatt As GroupBox
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
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtIstatTesto As TextBox
    Friend WithEvents LblAnnoAdeguamento As Label
    Friend WithEvents TxtAnnoAdeguamento As TextBox
    Friend WithEvents DtaFattDa As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupDecorrenza As GroupBox
    Friend WithEvents DtaDecorrenza As DateTimePicker
End Class
