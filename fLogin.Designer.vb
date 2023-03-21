<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FLogin
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FLogin))
        Me.BtnConnetti = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtPSW = New System.Windows.Forms.TextBox()
        Me.txtSERVER = New System.Windows.Forms.TextBox()
        Me.TxtDB_UNO = New System.Windows.Forms.TextBox()
        Me.PanelAdmin = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDB_SPA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtTmpDB_SPA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTmpDB_UNO = New System.Windows.Forms.TextBox()
        Me.BtnApriLog = New System.Windows.Forms.Button()
        Me.DtDataInizio = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabFusione = New System.Windows.Forms.TabPage()
        Me.ChkFusionePartite = New System.Windows.Forms.CheckBox()
        Me.ChkFusioneAcquisti = New System.Windows.Forms.CheckBox()
        Me.ChkFusioneVendite = New System.Windows.Forms.CheckBox()
        Me.BtnFusione = New System.Windows.Forms.Button()
        Me.ChkFusioneFull = New System.Windows.Forms.CheckBox()
        Me.TabPageCancella = New System.Windows.Forms.TabPage()
        Me.BtnCancellaAnaliticaDaFatt = New System.Windows.Forms.Button()
        Me.BtnCancellaPNota = New System.Windows.Forms.Button()
        Me.BtnCancellaRID = New System.Windows.Forms.Button()
        Me.BtnCancellaFatture = New System.Windows.Forms.Button()
        Me.BtnCancellaPartiteFornitore = New System.Windows.Forms.Button()
        Me.BtnCancellaPartite = New System.Windows.Forms.Button()
        Me.BtnCancellaFornitori = New System.Windows.Forms.Button()
        Me.BtnCancellaClienti = New System.Windows.Forms.Button()
        Me.TabOrdini = New System.Windows.Forms.TabPage()
        Me.BtnCancellaRigheOrdini = New System.Windows.Forms.Button()
        Me.TabPageFatture = New System.Windows.Forms.TabPage()
        Me.ChkCreaSDD = New System.Windows.Forms.CheckBox()
        Me.ChkInsertSepaOnFoxFields = New System.Windows.Forms.CheckBox()
        Me.ChkInsertSepaOnBankAuth = New System.Windows.Forms.CheckBox()
        Me.ChkOnlyWESEIVA = New System.Windows.Forms.CheckBox()
        Me.ChkFatture = New System.Windows.Forms.CheckBox()
        Me.TabPagePaghe = New System.Windows.Forms.TabPage()
        Me.ChkPaghe = New System.Windows.Forms.CheckBox()
        Me.TabPageAnagrafiche = New System.Windows.Forms.TabPage()
        Me.ChkNoteCliente = New System.Windows.Forms.CheckBox()
        Me.ChkFornitori = New System.Windows.Forms.CheckBox()
        Me.ChkClienti = New System.Windows.Forms.CheckBox()
        Me.TabPagePartite = New System.Windows.Forms.TabPage()
        Me.ChkDifferenzialeCliente = New System.Windows.Forms.CheckBox()
        Me.ChkDifferenzialeFornitori = New System.Windows.Forms.CheckBox()
        Me.ChkPartiteFornitori = New System.Windows.Forms.CheckBox()
        Me.ChkPartiteCliente = New System.Windows.Forms.CheckBox()
        Me.TabPagePnota = New System.Windows.Forms.TabPage()
        Me.ChkRiscontiRidotto = New System.Windows.Forms.CheckBox()
        Me.ChkRisconti = New System.Windows.Forms.CheckBox()
        Me.ChkPNotaForDaPartitario = New System.Windows.Forms.CheckBox()
        Me.ChkPNotaCliDaPartitario = New System.Windows.Forms.CheckBox()
        Me.TabCespiti = New System.Windows.Forms.TabPage()
        Me.ChkCespiti = New System.Windows.Forms.CheckBox()
        Me.BtnProcessa = New System.Windows.Forms.Button()
        Me.lblDataInizio = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.LblLoginId = New System.Windows.Forms.Label()
        Me.txtLoginId = New System.Windows.Forms.TextBox()
        Me.BtnPath = New System.Windows.Forms.Button()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.PanelUser = New System.Windows.Forms.Panel()
        Me.BtnOrdiniISTAT = New System.Windows.Forms.Button()
        Me.BtnOrdini = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnAnalitica = New System.Windows.Forms.Button()
        Me.BtnLastLog = New System.Windows.Forms.Button()
        Me.BtnPaghe = New System.Windows.Forms.Button()
        Me.BtnFatture = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lstStatoConnessione = New System.Windows.Forms.ListBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnettiAdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComandiToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestOrdiniToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestISTATToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestRiscontiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestRiscontiRidottoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiaDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.UNOSuTESTUNOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SPASuTESTSPAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiparaMaschereMagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExeLocationToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AppLogToolStripMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserSettingFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FusioneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EseguiTraTestToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EseguiInDefinitivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EseguiStep = New System.Windows.Forms.ToolStripMenuItem()
        Me.CespitiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancellaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTracciatoVecchio = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDebugging = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComandiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CaricaSchemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EseguiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaliticaDaFattureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiorganizzaCartelleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegioneDaProvinciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelDB = New System.Windows.Forms.Panel()
        Me.CHKDBTemporaneo = New System.Windows.Forms.CheckBox()
        Me.BtnSelSPA = New System.Windows.Forms.Button()
        Me.BtnSelUNO = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PanelAdmin.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabFusione.SuspendLayout()
        Me.TabPageCancella.SuspendLayout()
        Me.TabOrdini.SuspendLayout()
        Me.TabPageFatture.SuspendLayout()
        Me.TabPagePaghe.SuspendLayout()
        Me.TabPageAnagrafiche.SuspendLayout()
        Me.TabPagePartite.SuspendLayout()
        Me.TabPagePnota.SuspendLayout()
        Me.TabCespiti.SuspendLayout()
        Me.PanelUser.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.PanelDB.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnConnetti
        '
        Me.BtnConnetti.BackColor = System.Drawing.Color.PaleGreen
        Me.BtnConnetti.Location = New System.Drawing.Point(370, 112)
        Me.BtnConnetti.Name = "BtnConnetti"
        Me.BtnConnetti.Size = New System.Drawing.Size(76, 37)
        Me.BtnConnetti.TabIndex = 9
        Me.BtnConnetti.Text = "Connetti"
        Me.BtnConnetti.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Server"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "DB1"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(77, 31)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(34, 20)
        Me.txtID.TabIndex = 3
        Me.txtID.Text = "sa"
        '
        'txtPSW
        '
        Me.txtPSW.Location = New System.Drawing.Point(77, 55)
        Me.txtPSW.Name = "txtPSW"
        Me.txtPSW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPSW.Size = New System.Drawing.Size(100, 20)
        Me.txtPSW.TabIndex = 4
        '
        'txtSERVER
        '
        Me.txtSERVER.Location = New System.Drawing.Point(283, 3)
        Me.txtSERVER.Name = "txtSERVER"
        Me.txtSERVER.Size = New System.Drawing.Size(130, 20)
        Me.txtSERVER.TabIndex = 5
        '
        'TxtDB_UNO
        '
        Me.TxtDB_UNO.Location = New System.Drawing.Point(251, 27)
        Me.TxtDB_UNO.Name = "TxtDB_UNO"
        Me.TxtDB_UNO.Size = New System.Drawing.Size(56, 20)
        Me.TxtDB_UNO.TabIndex = 6
        '
        'PanelAdmin
        '
        Me.PanelAdmin.Controls.Add(Me.Label7)
        Me.PanelAdmin.Controls.Add(Me.TxtDB_SPA)
        Me.PanelAdmin.Controls.Add(Me.Label6)
        Me.PanelAdmin.Controls.Add(Me.TxtTmpDB_SPA)
        Me.PanelAdmin.Controls.Add(Me.Label1)
        Me.PanelAdmin.Controls.Add(Me.TxtTmpDB_UNO)
        Me.PanelAdmin.Controls.Add(Me.BtnApriLog)
        Me.PanelAdmin.Controls.Add(Me.BtnConnetti)
        Me.PanelAdmin.Controls.Add(Me.DtDataInizio)
        Me.PanelAdmin.Controls.Add(Me.TabControl1)
        Me.PanelAdmin.Controls.Add(Me.BtnProcessa)
        Me.PanelAdmin.Controls.Add(Me.lblDataInizio)
        Me.PanelAdmin.Controls.Add(Me.txtPath)
        Me.PanelAdmin.Controls.Add(Me.LblLoginId)
        Me.PanelAdmin.Controls.Add(Me.Label2)
        Me.PanelAdmin.Controls.Add(Me.txtLoginId)
        Me.PanelAdmin.Controls.Add(Me.Label3)
        Me.PanelAdmin.Controls.Add(Me.BtnPath)
        Me.PanelAdmin.Controls.Add(Me.Label4)
        Me.PanelAdmin.Controls.Add(Me.lblPath)
        Me.PanelAdmin.Controls.Add(Me.Label5)
        Me.PanelAdmin.Controls.Add(Me.txtID)
        Me.PanelAdmin.Controls.Add(Me.txtPSW)
        Me.PanelAdmin.Controls.Add(Me.TxtDB_UNO)
        Me.PanelAdmin.Controls.Add(Me.txtSERVER)
        Me.PanelAdmin.Location = New System.Drawing.Point(0, 24)
        Me.PanelAdmin.Name = "PanelAdmin"
        Me.PanelAdmin.Size = New System.Drawing.Size(456, 240)
        Me.PanelAdmin.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(334, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "DBSPA"
        '
        'TxtDB_SPA
        '
        Me.TxtDB_SPA.Location = New System.Drawing.Point(383, 29)
        Me.TxtDB_SPA.Name = "TxtDB_SPA"
        Me.TxtDB_SPA.Size = New System.Drawing.Size(56, 20)
        Me.TxtDB_SPA.TabIndex = 48
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(313, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "TmpDBSPA"
        '
        'TxtTmpDB_SPA
        '
        Me.TxtTmpDB_SPA.Location = New System.Drawing.Point(383, 55)
        Me.TxtTmpDB_SPA.Name = "TxtTmpDB_SPA"
        Me.TxtTmpDB_SPA.Size = New System.Drawing.Size(56, 20)
        Me.TxtTmpDB_SPA.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(196, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "TmpDB1"
        '
        'TxtTmpDB_UNO
        '
        Me.TxtTmpDB_UNO.Location = New System.Drawing.Point(251, 55)
        Me.TxtTmpDB_UNO.Name = "TxtTmpDB_UNO"
        Me.TxtTmpDB_UNO.Size = New System.Drawing.Size(56, 20)
        Me.TxtTmpDB_UNO.TabIndex = 43
        '
        'BtnApriLog
        '
        Me.BtnApriLog.Location = New System.Drawing.Point(370, 155)
        Me.BtnApriLog.Name = "BtnApriLog"
        Me.BtnApriLog.Size = New System.Drawing.Size(75, 23)
        Me.BtnApriLog.TabIndex = 10
        Me.BtnApriLog.Text = "Apri Logs"
        Me.BtnApriLog.UseVisualStyleBackColor = True
        '
        'DtDataInizio
        '
        Me.DtDataInizio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtDataInizio.Location = New System.Drawing.Point(77, 5)
        Me.DtDataInizio.Name = "DtDataInizio"
        Me.DtDataInizio.Size = New System.Drawing.Size(100, 20)
        Me.DtDataInizio.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabFusione)
        Me.TabControl1.Controls.Add(Me.TabPageCancella)
        Me.TabControl1.Controls.Add(Me.TabOrdini)
        Me.TabControl1.Controls.Add(Me.TabPageFatture)
        Me.TabControl1.Controls.Add(Me.TabPagePaghe)
        Me.TabControl1.Controls.Add(Me.TabPageAnagrafiche)
        Me.TabControl1.Controls.Add(Me.TabPagePartite)
        Me.TabControl1.Controls.Add(Me.TabPagePnota)
        Me.TabControl1.Controls.Add(Me.TabCespiti)
        Me.TabControl1.Enabled = False
        Me.TabControl1.Location = New System.Drawing.Point(10, 113)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(330, 127)
        Me.TabControl1.TabIndex = 42
        '
        'TabFusione
        '
        Me.TabFusione.BackColor = System.Drawing.SystemColors.Control
        Me.TabFusione.Controls.Add(Me.ChkFusionePartite)
        Me.TabFusione.Controls.Add(Me.ChkFusioneAcquisti)
        Me.TabFusione.Controls.Add(Me.ChkFusioneVendite)
        Me.TabFusione.Controls.Add(Me.BtnFusione)
        Me.TabFusione.Controls.Add(Me.ChkFusioneFull)
        Me.TabFusione.Location = New System.Drawing.Point(4, 22)
        Me.TabFusione.Name = "TabFusione"
        Me.TabFusione.Padding = New System.Windows.Forms.Padding(3)
        Me.TabFusione.Size = New System.Drawing.Size(322, 101)
        Me.TabFusione.TabIndex = 8
        Me.TabFusione.Text = "Fusione"
        '
        'ChkFusionePartite
        '
        Me.ChkFusionePartite.AutoSize = True
        Me.ChkFusionePartite.Location = New System.Drawing.Point(15, 72)
        Me.ChkFusionePartite.Name = "ChkFusionePartite"
        Me.ChkFusionePartite.Size = New System.Drawing.Size(96, 17)
        Me.ChkFusionePartite.TabIndex = 5
        Me.ChkFusionePartite.Text = "Fusione Partite"
        Me.ChkFusionePartite.UseVisualStyleBackColor = True
        '
        'ChkFusioneAcquisti
        '
        Me.ChkFusioneAcquisti.AutoSize = True
        Me.ChkFusioneAcquisti.Location = New System.Drawing.Point(15, 26)
        Me.ChkFusioneAcquisti.Name = "ChkFusioneAcquisti"
        Me.ChkFusioneAcquisti.Size = New System.Drawing.Size(110, 17)
        Me.ChkFusioneAcquisti.TabIndex = 4
        Me.ChkFusioneAcquisti.Text = "Acquisti da Nrdoc"
        Me.ChkFusioneAcquisti.UseVisualStyleBackColor = True
        '
        'ChkFusioneVendite
        '
        Me.ChkFusioneVendite.AutoSize = True
        Me.ChkFusioneVendite.Location = New System.Drawing.Point(15, 49)
        Me.ChkFusioneVendite.Name = "ChkFusioneVendite"
        Me.ChkFusioneVendite.Size = New System.Drawing.Size(108, 17)
        Me.ChkFusioneVendite.TabIndex = 3
        Me.ChkFusioneVendite.Text = "Fatture da NrDoc"
        Me.ChkFusioneVendite.UseVisualStyleBackColor = True
        '
        'BtnFusione
        '
        Me.BtnFusione.Location = New System.Drawing.Point(237, 6)
        Me.BtnFusione.Name = "BtnFusione"
        Me.BtnFusione.Size = New System.Drawing.Size(75, 37)
        Me.BtnFusione.TabIndex = 2
        Me.BtnFusione.Text = "Esegui Fusione"
        Me.BtnFusione.UseVisualStyleBackColor = True
        '
        'ChkFusioneFull
        '
        Me.ChkFusioneFull.AutoSize = True
        Me.ChkFusioneFull.Location = New System.Drawing.Point(6, 6)
        Me.ChkFusioneFull.Name = "ChkFusioneFull"
        Me.ChkFusioneFull.Size = New System.Drawing.Size(82, 17)
        Me.ChkFusioneFull.TabIndex = 1
        Me.ChkFusioneFull.Text = "Fusione Full"
        Me.ChkFusioneFull.UseVisualStyleBackColor = True
        '
        'TabPageCancella
        '
        Me.TabPageCancella.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaAnaliticaDaFatt)
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaPNota)
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaRID)
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaFatture)
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaPartiteFornitore)
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaPartite)
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaFornitori)
        Me.TabPageCancella.Controls.Add(Me.BtnCancellaClienti)
        Me.TabPageCancella.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCancella.Name = "TabPageCancella"
        Me.TabPageCancella.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCancella.Size = New System.Drawing.Size(322, 101)
        Me.TabPageCancella.TabIndex = 1
        Me.TabPageCancella.Text = "Cancella"
        '
        'BtnCancellaAnaliticaDaFatt
        '
        Me.BtnCancellaAnaliticaDaFatt.BackColor = System.Drawing.Color.SandyBrown
        Me.BtnCancellaAnaliticaDaFatt.Location = New System.Drawing.Point(207, 38)
        Me.BtnCancellaAnaliticaDaFatt.Name = "BtnCancellaAnaliticaDaFatt"
        Me.BtnCancellaAnaliticaDaFatt.Size = New System.Drawing.Size(97, 24)
        Me.BtnCancellaAnaliticaDaFatt.TabIndex = 54
        Me.BtnCancellaAnaliticaDaFatt.Text = "Analitica da fatt."
        Me.BtnCancellaAnaliticaDaFatt.UseVisualStyleBackColor = False
        '
        'BtnCancellaPNota
        '
        Me.BtnCancellaPNota.BackColor = System.Drawing.Color.OrangeRed
        Me.BtnCancellaPNota.Location = New System.Drawing.Point(209, 70)
        Me.BtnCancellaPNota.Name = "BtnCancellaPNota"
        Me.BtnCancellaPNota.Size = New System.Drawing.Size(97, 24)
        Me.BtnCancellaPNota.TabIndex = 53
        Me.BtnCancellaPNota.Text = "P.nota"
        Me.BtnCancellaPNota.UseVisualStyleBackColor = False
        '
        'BtnCancellaRID
        '
        Me.BtnCancellaRID.BackColor = System.Drawing.Color.LightCoral
        Me.BtnCancellaRID.Location = New System.Drawing.Point(3, 70)
        Me.BtnCancellaRID.Name = "BtnCancellaRID"
        Me.BtnCancellaRID.Size = New System.Drawing.Size(97, 27)
        Me.BtnCancellaRID.TabIndex = 52
        Me.BtnCancellaRID.Text = "Cancella RID"
        Me.BtnCancellaRID.UseVisualStyleBackColor = False
        '
        'BtnCancellaFatture
        '
        Me.BtnCancellaFatture.BackColor = System.Drawing.Color.Firebrick
        Me.BtnCancellaFatture.Location = New System.Drawing.Point(207, 7)
        Me.BtnCancellaFatture.Name = "BtnCancellaFatture"
        Me.BtnCancellaFatture.Size = New System.Drawing.Size(97, 24)
        Me.BtnCancellaFatture.TabIndex = 51
        Me.BtnCancellaFatture.Text = "Cancella Fatture"
        Me.BtnCancellaFatture.UseVisualStyleBackColor = False
        '
        'BtnCancellaPartiteFornitore
        '
        Me.BtnCancellaPartiteFornitore.BackColor = System.Drawing.Color.RosyBrown
        Me.BtnCancellaPartiteFornitore.Location = New System.Drawing.Point(106, 37)
        Me.BtnCancellaPartiteFornitore.Name = "BtnCancellaPartiteFornitore"
        Me.BtnCancellaPartiteFornitore.Size = New System.Drawing.Size(97, 27)
        Me.BtnCancellaPartiteFornitore.TabIndex = 50
        Me.BtnCancellaPartiteFornitore.Text = "Cancella Partite"
        Me.BtnCancellaPartiteFornitore.UseVisualStyleBackColor = False
        '
        'BtnCancellaPartite
        '
        Me.BtnCancellaPartite.BackColor = System.Drawing.Color.LightCoral
        Me.BtnCancellaPartite.Location = New System.Drawing.Point(3, 37)
        Me.BtnCancellaPartite.Name = "BtnCancellaPartite"
        Me.BtnCancellaPartite.Size = New System.Drawing.Size(97, 27)
        Me.BtnCancellaPartite.TabIndex = 49
        Me.BtnCancellaPartite.Text = "Cancella Partite"
        Me.BtnCancellaPartite.UseVisualStyleBackColor = False
        '
        'BtnCancellaFornitori
        '
        Me.BtnCancellaFornitori.BackColor = System.Drawing.Color.RosyBrown
        Me.BtnCancellaFornitori.Location = New System.Drawing.Point(106, 7)
        Me.BtnCancellaFornitori.Name = "BtnCancellaFornitori"
        Me.BtnCancellaFornitori.Size = New System.Drawing.Size(97, 24)
        Me.BtnCancellaFornitori.TabIndex = 48
        Me.BtnCancellaFornitori.Text = "Cancella Fornitori"
        Me.BtnCancellaFornitori.UseVisualStyleBackColor = False
        '
        'BtnCancellaClienti
        '
        Me.BtnCancellaClienti.BackColor = System.Drawing.Color.LightCoral
        Me.BtnCancellaClienti.Location = New System.Drawing.Point(3, 7)
        Me.BtnCancellaClienti.Name = "BtnCancellaClienti"
        Me.BtnCancellaClienti.Size = New System.Drawing.Size(97, 24)
        Me.BtnCancellaClienti.TabIndex = 47
        Me.BtnCancellaClienti.Text = "Cancella Clienti"
        Me.BtnCancellaClienti.UseVisualStyleBackColor = False
        '
        'TabOrdini
        '
        Me.TabOrdini.BackColor = System.Drawing.SystemColors.Control
        Me.TabOrdini.Controls.Add(Me.BtnCancellaRigheOrdini)
        Me.TabOrdini.Location = New System.Drawing.Point(4, 22)
        Me.TabOrdini.Name = "TabOrdini"
        Me.TabOrdini.Padding = New System.Windows.Forms.Padding(3)
        Me.TabOrdini.Size = New System.Drawing.Size(322, 101)
        Me.TabOrdini.TabIndex = 7
        Me.TabOrdini.Text = "Ordini"
        '
        'BtnCancellaRigheOrdini
        '
        Me.BtnCancellaRigheOrdini.BackColor = System.Drawing.Color.Firebrick
        Me.BtnCancellaRigheOrdini.Location = New System.Drawing.Point(17, 7)
        Me.BtnCancellaRigheOrdini.Name = "BtnCancellaRigheOrdini"
        Me.BtnCancellaRigheOrdini.Size = New System.Drawing.Size(139, 23)
        Me.BtnCancellaRigheOrdini.TabIndex = 0
        Me.BtnCancellaRigheOrdini.Text = "Cancella righe Ordini"
        Me.BtnCancellaRigheOrdini.UseVisualStyleBackColor = False
        '
        'TabPageFatture
        '
        Me.TabPageFatture.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageFatture.Controls.Add(Me.ChkCreaSDD)
        Me.TabPageFatture.Controls.Add(Me.ChkInsertSepaOnFoxFields)
        Me.TabPageFatture.Controls.Add(Me.ChkInsertSepaOnBankAuth)
        Me.TabPageFatture.Controls.Add(Me.ChkOnlyWESEIVA)
        Me.TabPageFatture.Controls.Add(Me.ChkFatture)
        Me.TabPageFatture.Location = New System.Drawing.Point(4, 22)
        Me.TabPageFatture.Name = "TabPageFatture"
        Me.TabPageFatture.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageFatture.Size = New System.Drawing.Size(322, 101)
        Me.TabPageFatture.TabIndex = 2
        Me.TabPageFatture.Text = "Fatture"
        '
        'ChkCreaSDD
        '
        Me.ChkCreaSDD.AutoSize = True
        Me.ChkCreaSDD.Location = New System.Drawing.Point(213, 75)
        Me.ChkCreaSDD.Name = "ChkCreaSDD"
        Me.ChkCreaSDD.Size = New System.Drawing.Size(102, 17)
        Me.ChkCreaSDD.TabIndex = 24
        Me.ChkCreaSDD.Text = "+ Crea Mandato"
        Me.ChkCreaSDD.UseVisualStyleBackColor = True
        '
        'ChkInsertSepaOnFoxFields
        '
        Me.ChkInsertSepaOnFoxFields.AutoSize = True
        Me.ChkInsertSepaOnFoxFields.Location = New System.Drawing.Point(9, 75)
        Me.ChkInsertSepaOnFoxFields.Name = "ChkInsertSepaOnFoxFields"
        Me.ChkInsertSepaOnFoxFields.Size = New System.Drawing.Size(198, 17)
        Me.ChkInsertSepaOnFoxFields.TabIndex = 23
        Me.ChkInsertSepaOnFoxFields.Text = "Inserisci UMR e IBAN su campi FOX"
        Me.ChkInsertSepaOnFoxFields.UseVisualStyleBackColor = True
        '
        'ChkInsertSepaOnBankAuth
        '
        Me.ChkInsertSepaOnBankAuth.AutoSize = True
        Me.ChkInsertSepaOnBankAuth.Location = New System.Drawing.Point(9, 52)
        Me.ChkInsertSepaOnBankAuth.Name = "ChkInsertSepaOnBankAuth"
        Me.ChkInsertSepaOnBankAuth.Size = New System.Drawing.Size(201, 17)
        Me.ChkInsertSepaOnBankAuth.TabIndex = 22
        Me.ChkInsertSepaOnBankAuth.Text = "Inserisci SEPA su Bank Authorization"
        Me.ChkInsertSepaOnBankAuth.UseVisualStyleBackColor = True
        '
        'ChkOnlyWESEIVA
        '
        Me.ChkOnlyWESEIVA.AutoSize = True
        Me.ChkOnlyWESEIVA.Location = New System.Drawing.Point(35, 29)
        Me.ChkOnlyWESEIVA.Name = "ChkOnlyWESEIVA"
        Me.ChkOnlyWESEIVA.Size = New System.Drawing.Size(99, 17)
        Me.ChkOnlyWESEIVA.TabIndex = 21
        Me.ChkOnlyWESEIVA.Text = "Solo WESEIVA"
        Me.ChkOnlyWESEIVA.UseVisualStyleBackColor = True
        '
        'ChkFatture
        '
        Me.ChkFatture.AutoSize = True
        Me.ChkFatture.Location = New System.Drawing.Point(9, 6)
        Me.ChkFatture.Name = "ChkFatture"
        Me.ChkFatture.Size = New System.Drawing.Size(229, 17)
        Me.ChkFatture.TabIndex = 20
        Me.ChkFatture.Text = "Fatture (FTPA300F CLIENORD WESEIVA)"
        Me.ChkFatture.UseVisualStyleBackColor = True
        '
        'TabPagePaghe
        '
        Me.TabPagePaghe.BackColor = System.Drawing.SystemColors.Control
        Me.TabPagePaghe.Controls.Add(Me.ChkPaghe)
        Me.TabPagePaghe.Location = New System.Drawing.Point(4, 22)
        Me.TabPagePaghe.Name = "TabPagePaghe"
        Me.TabPagePaghe.Size = New System.Drawing.Size(322, 101)
        Me.TabPagePaghe.TabIndex = 5
        Me.TabPagePaghe.Text = "Paghe"
        '
        'ChkPaghe
        '
        Me.ChkPaghe.AutoSize = True
        Me.ChkPaghe.Location = New System.Drawing.Point(9, 6)
        Me.ChkPaghe.Name = "ChkPaghe"
        Me.ChkPaghe.Size = New System.Drawing.Size(63, 17)
        Me.ChkPaghe.TabIndex = 21
        Me.ChkPaghe.Text = "PAGHE"
        Me.ChkPaghe.UseVisualStyleBackColor = True
        '
        'TabPageAnagrafiche
        '
        Me.TabPageAnagrafiche.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageAnagrafiche.Controls.Add(Me.ChkNoteCliente)
        Me.TabPageAnagrafiche.Controls.Add(Me.ChkFornitori)
        Me.TabPageAnagrafiche.Controls.Add(Me.ChkClienti)
        Me.TabPageAnagrafiche.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAnagrafiche.Name = "TabPageAnagrafiche"
        Me.TabPageAnagrafiche.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAnagrafiche.Size = New System.Drawing.Size(322, 101)
        Me.TabPageAnagrafiche.TabIndex = 0
        Me.TabPageAnagrafiche.Text = "Anagrafiche"
        '
        'ChkNoteCliente
        '
        Me.ChkNoteCliente.AutoSize = True
        Me.ChkNoteCliente.Location = New System.Drawing.Point(9, 58)
        Me.ChkNoteCliente.Name = "ChkNoteCliente"
        Me.ChkNoteCliente.Size = New System.Drawing.Size(192, 17)
        Me.ChkNoteCliente.TabIndex = 19
        Me.ChkNoteCliente.Text = "Note Clienti da FoxPro (NOTE_CLI)"
        Me.ChkNoteCliente.UseVisualStyleBackColor = True
        '
        'ChkFornitori
        '
        Me.ChkFornitori.AutoSize = True
        Me.ChkFornitori.Location = New System.Drawing.Point(9, 29)
        Me.ChkFornitori.Name = "ChkFornitori"
        Me.ChkFornitori.Size = New System.Drawing.Size(179, 17)
        Me.ChkFornitori.TabIndex = 18
        Me.ChkFornitori.Text = "Fornitori (ANFO200F ANFF200F)"
        Me.ChkFornitori.UseVisualStyleBackColor = True
        '
        'ChkClienti
        '
        Me.ChkClienti.AutoSize = True
        Me.ChkClienti.Location = New System.Drawing.Point(9, 6)
        Me.ChkClienti.Name = "ChkClienti"
        Me.ChkClienti.Size = New System.Drawing.Size(289, 17)
        Me.ChkClienti.TabIndex = 17
        Me.ChkClienti.Text = "Clienti (ANCL200F ANFC200F FTEU400F ACGSEP00F)"
        Me.ChkClienti.UseVisualStyleBackColor = True
        '
        'TabPagePartite
        '
        Me.TabPagePartite.BackColor = System.Drawing.SystemColors.Control
        Me.TabPagePartite.Controls.Add(Me.ChkDifferenzialeCliente)
        Me.TabPagePartite.Controls.Add(Me.ChkDifferenzialeFornitori)
        Me.TabPagePartite.Controls.Add(Me.ChkPartiteFornitori)
        Me.TabPagePartite.Controls.Add(Me.ChkPartiteCliente)
        Me.TabPagePartite.Location = New System.Drawing.Point(4, 22)
        Me.TabPagePartite.Name = "TabPagePartite"
        Me.TabPagePartite.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagePartite.Size = New System.Drawing.Size(322, 101)
        Me.TabPagePartite.TabIndex = 3
        Me.TabPagePartite.Text = "Partite"
        '
        'ChkDifferenzialeCliente
        '
        Me.ChkDifferenzialeCliente.AutoSize = True
        Me.ChkDifferenzialeCliente.Location = New System.Drawing.Point(25, 29)
        Me.ChkDifferenzialeCliente.Name = "ChkDifferenzialeCliente"
        Me.ChkDifferenzialeCliente.Size = New System.Drawing.Size(250, 17)
        Me.ChkDifferenzialeCliente.TabIndex = 24
        Me.ChkDifferenzialeCliente.Text = "Differenziale Cliente (GCPA200F QTMP_CPAG)"
        Me.ChkDifferenzialeCliente.UseVisualStyleBackColor = True
        '
        'ChkDifferenzialeFornitori
        '
        Me.ChkDifferenzialeFornitori.AutoSize = True
        Me.ChkDifferenzialeFornitori.Location = New System.Drawing.Point(25, 78)
        Me.ChkDifferenzialeFornitori.Name = "ChkDifferenzialeFornitori"
        Me.ChkDifferenzialeFornitori.Size = New System.Drawing.Size(258, 17)
        Me.ChkDifferenzialeFornitori.TabIndex = 23
        Me.ChkDifferenzialeFornitori.Text = "Differenziale Fornitore (GFPA200F QTMP_CPAG)"
        Me.ChkDifferenzialeFornitori.UseVisualStyleBackColor = True
        '
        'ChkPartiteFornitori
        '
        Me.ChkPartiteFornitori.AutoSize = True
        Me.ChkPartiteFornitori.Location = New System.Drawing.Point(9, 55)
        Me.ChkPartiteFornitori.Name = "ChkPartiteFornitori"
        Me.ChkPartiteFornitori.Size = New System.Drawing.Size(230, 17)
        Me.ChkPartiteFornitori.TabIndex = 22
        Me.ChkPartiteFornitori.Text = "Partite Fornitore (GFPA200F QTMP_CPAG)"
        Me.ChkPartiteFornitori.UseVisualStyleBackColor = True
        '
        'ChkPartiteCliente
        '
        Me.ChkPartiteCliente.AutoSize = True
        Me.ChkPartiteCliente.Location = New System.Drawing.Point(9, 6)
        Me.ChkPartiteCliente.Name = "ChkPartiteCliente"
        Me.ChkPartiteCliente.Size = New System.Drawing.Size(222, 17)
        Me.ChkPartiteCliente.TabIndex = 21
        Me.ChkPartiteCliente.Text = "Partite Cliente (GCPA200F QTMP_CPAG)"
        Me.ChkPartiteCliente.UseVisualStyleBackColor = True
        '
        'TabPagePnota
        '
        Me.TabPagePnota.BackColor = System.Drawing.SystemColors.Control
        Me.TabPagePnota.Controls.Add(Me.ChkRiscontiRidotto)
        Me.TabPagePnota.Controls.Add(Me.ChkRisconti)
        Me.TabPagePnota.Controls.Add(Me.ChkPNotaForDaPartitario)
        Me.TabPagePnota.Controls.Add(Me.ChkPNotaCliDaPartitario)
        Me.TabPagePnota.Location = New System.Drawing.Point(4, 22)
        Me.TabPagePnota.Name = "TabPagePnota"
        Me.TabPagePnota.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagePnota.Size = New System.Drawing.Size(322, 101)
        Me.TabPagePnota.TabIndex = 4
        Me.TabPagePnota.Text = "Prima Nota"
        '
        'ChkRiscontiRidotto
        '
        Me.ChkRiscontiRidotto.AutoSize = True
        Me.ChkRiscontiRidotto.Location = New System.Drawing.Point(173, 29)
        Me.ChkRiscontiRidotto.Name = "ChkRiscontiRidotto"
        Me.ChkRiscontiRidotto.Size = New System.Drawing.Size(96, 17)
        Me.ChkRiscontiRidotto.TabIndex = 26
        Me.ChkRiscontiRidotto.Text = "Risconti ridotto"
        Me.ChkRiscontiRidotto.UseVisualStyleBackColor = True
        '
        'ChkRisconti
        '
        Me.ChkRisconti.AutoSize = True
        Me.ChkRisconti.Location = New System.Drawing.Point(173, 6)
        Me.ChkRisconti.Name = "ChkRisconti"
        Me.ChkRisconti.Size = New System.Drawing.Size(64, 17)
        Me.ChkRisconti.TabIndex = 25
        Me.ChkRisconti.Text = "Risconti"
        Me.ChkRisconti.UseVisualStyleBackColor = True
        '
        'ChkPNotaForDaPartitario
        '
        Me.ChkPNotaForDaPartitario.AutoSize = True
        Me.ChkPNotaForDaPartitario.Location = New System.Drawing.Point(9, 29)
        Me.ChkPNotaForDaPartitario.Name = "ChkPNotaForDaPartitario"
        Me.ChkPNotaForDaPartitario.Size = New System.Drawing.Size(122, 17)
        Me.ChkPNotaForDaPartitario.TabIndex = 24
        Me.ChkPNotaForDaPartitario.Text = "Fornitori da Partitario"
        Me.ChkPNotaForDaPartitario.UseVisualStyleBackColor = True
        '
        'ChkPNotaCliDaPartitario
        '
        Me.ChkPNotaCliDaPartitario.AutoSize = True
        Me.ChkPNotaCliDaPartitario.Location = New System.Drawing.Point(9, 6)
        Me.ChkPNotaCliDaPartitario.Name = "ChkPNotaCliDaPartitario"
        Me.ChkPNotaCliDaPartitario.Size = New System.Drawing.Size(113, 17)
        Me.ChkPNotaCliDaPartitario.TabIndex = 23
        Me.ChkPNotaCliDaPartitario.Text = "Clienti da Partitario"
        Me.ChkPNotaCliDaPartitario.UseVisualStyleBackColor = True
        '
        'TabCespiti
        '
        Me.TabCespiti.BackColor = System.Drawing.SystemColors.Control
        Me.TabCespiti.Controls.Add(Me.ChkCespiti)
        Me.TabCespiti.Location = New System.Drawing.Point(4, 22)
        Me.TabCespiti.Name = "TabCespiti"
        Me.TabCespiti.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCespiti.Size = New System.Drawing.Size(322, 101)
        Me.TabCespiti.TabIndex = 6
        Me.TabCespiti.Text = "Cespiti"
        '
        'ChkCespiti
        '
        Me.ChkCespiti.AutoSize = True
        Me.ChkCespiti.Location = New System.Drawing.Point(7, 7)
        Me.ChkCespiti.Name = "ChkCespiti"
        Me.ChkCespiti.Size = New System.Drawing.Size(57, 17)
        Me.ChkCespiti.TabIndex = 0
        Me.ChkCespiti.Text = "Cespiti"
        Me.ChkCespiti.UseVisualStyleBackColor = True
        '
        'BtnProcessa
        '
        Me.BtnProcessa.Enabled = False
        Me.BtnProcessa.Location = New System.Drawing.Point(370, 184)
        Me.BtnProcessa.Name = "BtnProcessa"
        Me.BtnProcessa.Size = New System.Drawing.Size(76, 43)
        Me.BtnProcessa.TabIndex = 11
        Me.BtnProcessa.Text = "Processa Selezionati"
        Me.BtnProcessa.UseVisualStyleBackColor = True
        '
        'lblDataInizio
        '
        Me.lblDataInizio.AutoSize = True
        Me.lblDataInizio.Location = New System.Drawing.Point(7, 8)
        Me.lblDataInizio.Name = "lblDataInizio"
        Me.lblDataInizio.Size = New System.Drawing.Size(56, 13)
        Me.lblDataInizio.TabIndex = 20
        Me.lblDataInizio.Text = "Data inizio"
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(77, 85)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(279, 20)
        Me.txtPath.TabIndex = 7
        '
        'LblLoginId
        '
        Me.LblLoginId.AutoSize = True
        Me.LblLoginId.Location = New System.Drawing.Point(123, 34)
        Me.LblLoginId.Name = "LblLoginId"
        Me.LblLoginId.Size = New System.Drawing.Size(47, 13)
        Me.LblLoginId.TabIndex = 38
        Me.LblLoginId.Text = "Login ID"
        '
        'txtLoginId
        '
        Me.txtLoginId.Location = New System.Drawing.Point(176, 31)
        Me.txtLoginId.Name = "txtLoginId"
        Me.txtLoginId.Size = New System.Drawing.Size(26, 20)
        Me.txtLoginId.TabIndex = 2
        '
        'BtnPath
        '
        Me.BtnPath.Location = New System.Drawing.Point(362, 86)
        Me.BtnPath.Name = "BtnPath"
        Me.BtnPath.Size = New System.Drawing.Size(26, 20)
        Me.BtnPath.TabIndex = 8
        Me.BtnPath.Text = "..."
        Me.BtnPath.UseVisualStyleBackColor = True
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(7, 88)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(29, 13)
        Me.lblPath.TabIndex = 33
        Me.lblPath.Text = "Path"
        '
        'PanelUser
        '
        Me.PanelUser.Controls.Add(Me.BtnOrdiniISTAT)
        Me.PanelUser.Controls.Add(Me.BtnOrdini)
        Me.PanelUser.Controls.Add(Me.Button1)
        Me.PanelUser.Controls.Add(Me.BtnAnalitica)
        Me.PanelUser.Controls.Add(Me.BtnLastLog)
        Me.PanelUser.Controls.Add(Me.BtnPaghe)
        Me.PanelUser.Controls.Add(Me.BtnFatture)
        Me.PanelUser.Location = New System.Drawing.Point(97, 281)
        Me.PanelUser.Name = "PanelUser"
        Me.PanelUser.Size = New System.Drawing.Size(395, 295)
        Me.PanelUser.TabIndex = 46
        Me.PanelUser.Visible = False
        '
        'BtnOrdiniISTAT
        '
        Me.BtnOrdiniISTAT.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOrdiniISTAT.Location = New System.Drawing.Point(195, 79)
        Me.BtnOrdiniISTAT.Name = "BtnOrdiniISTAT"
        Me.BtnOrdiniISTAT.Size = New System.Drawing.Size(84, 23)
        Me.BtnOrdiniISTAT.TabIndex = 6
        Me.BtnOrdiniISTAT.Text = "ISTAT"
        Me.BtnOrdiniISTAT.UseVisualStyleBackColor = False
        '
        'BtnOrdini
        '
        Me.BtnOrdini.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOrdini.Image = Global.ALLSystemTools.My.Resources.Resources.navigate_48
        Me.BtnOrdini.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnOrdini.Location = New System.Drawing.Point(195, 17)
        Me.BtnOrdini.Name = "BtnOrdini"
        Me.BtnOrdini.Size = New System.Drawing.Size(84, 62)
        Me.BtnOrdini.TabIndex = 5
        Me.BtnOrdini.Text = "Ordini"
        Me.BtnOrdini.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnOrdini.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "XML Log"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'BtnAnalitica
        '
        Me.BtnAnalitica.Image = Global.ALLSystemTools.My.Resources.Resources.pie_chart_48
        Me.BtnAnalitica.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAnalitica.Location = New System.Drawing.Point(105, 17)
        Me.BtnAnalitica.Name = "BtnAnalitica"
        Me.BtnAnalitica.Size = New System.Drawing.Size(84, 84)
        Me.BtnAnalitica.TabIndex = 3
        Me.BtnAnalitica.Text = "Analitica"
        Me.BtnAnalitica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnAnalitica.UseVisualStyleBackColor = True
        '
        'BtnLastLog
        '
        Me.BtnLastLog.Location = New System.Drawing.Point(119, 110)
        Me.BtnLastLog.Name = "BtnLastLog"
        Me.BtnLastLog.Size = New System.Drawing.Size(207, 23)
        Me.BtnLastLog.TabIndex = 2
        Me.BtnLastLog.Text = "Apri cartella ultimo Log"
        Me.BtnLastLog.UseVisualStyleBackColor = True
        '
        'BtnPaghe
        '
        Me.BtnPaghe.Image = Global.ALLSystemTools.My.Resources.Resources.users_two_add_48
        Me.BtnPaghe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnPaghe.Location = New System.Drawing.Point(307, 17)
        Me.BtnPaghe.Name = "BtnPaghe"
        Me.BtnPaghe.Size = New System.Drawing.Size(131, 84)
        Me.BtnPaghe.TabIndex = 1
        Me.BtnPaghe.Text = "Paghe"
        Me.BtnPaghe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPaghe.UseVisualStyleBackColor = True
        '
        'BtnFatture
        '
        Me.BtnFatture.Image = Global.ALLSystemTools.My.Resources.Resources.book_48
        Me.BtnFatture.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFatture.Location = New System.Drawing.Point(15, 17)
        Me.BtnFatture.Name = "BtnFatture"
        Me.BtnFatture.Size = New System.Drawing.Size(84, 84)
        Me.BtnFatture.TabIndex = 0
        Me.BtnFatture.Text = "Fatture"
        Me.BtnFatture.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnFatture.UseVisualStyleBackColor = True
        '
        'lstStatoConnessione
        '
        Me.lstStatoConnessione.FormattingEnabled = True
        Me.lstStatoConnessione.Location = New System.Drawing.Point(12, 270)
        Me.lstStatoConnessione.Name = "lstStatoConnessione"
        Me.lstStatoConnessione.Size = New System.Drawing.Size(429, 69)
        Me.lstStatoConnessione.TabIndex = 27
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 296)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(285, 63)
        Me.DataGridView1.TabIndex = 30
        Me.DataGridView1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsToolStripMenuItem, Me.FileToolStripMenuItem, Me.FusioneToolStripMenuItem, Me.CespitiToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ComandiToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(456, 24)
        Me.MenuStrip1.TabIndex = 45
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministratorToolStripMenuItem, Me.DisconnettiAdminToolStripMenuItem, Me.ComandiToolStripMenuItem1, Me.ToolStripSeparator6, Me.BackupDatabaseToolStripMenuItem, Me.CopiaDatabase, Me.RiparaMaschereMagoToolStripMenuItem, Me.ToolStripSeparator7, Me.ExeLocationToolStripMenu, Me.AppLogToolStripMenu, Me.UserSettingFolderToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'AdministratorToolStripMenuItem
        '
        Me.AdministratorToolStripMenuItem.Image = Global.ALLSystemTools.My.Resources.Resources.lock_48
        Me.AdministratorToolStripMenuItem.Name = "AdministratorToolStripMenuItem"
        Me.AdministratorToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.AdministratorToolStripMenuItem.Text = "&Login Administrator"
        '
        'DisconnettiAdminToolStripMenuItem
        '
        Me.DisconnettiAdminToolStripMenuItem.Image = Global.ALLSystemTools.My.Resources.Resources.lock_open_48
        Me.DisconnettiAdminToolStripMenuItem.Name = "DisconnettiAdminToolStripMenuItem"
        Me.DisconnettiAdminToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.DisconnettiAdminToolStripMenuItem.Text = "Disconnetti Admin"
        Me.DisconnettiAdminToolStripMenuItem.Visible = False
        '
        'ComandiToolStripMenuItem1
        '
        Me.ComandiToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestOrdiniToolStripMenuItem, Me.TestISTATToolStripMenuItem, Me.TestRiscontiToolStripMenuItem, Me.TestRiscontiRidottoToolStripMenuItem})
        Me.ComandiToolStripMenuItem1.Name = "ComandiToolStripMenuItem1"
        Me.ComandiToolStripMenuItem1.Size = New System.Drawing.Size(195, 22)
        Me.ComandiToolStripMenuItem1.Text = "Comandi"
        '
        'TestOrdiniToolStripMenuItem
        '
        Me.TestOrdiniToolStripMenuItem.Name = "TestOrdiniToolStripMenuItem"
        Me.TestOrdiniToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TestOrdiniToolStripMenuItem.Text = "Test_Ordini"
        '
        'TestISTATToolStripMenuItem
        '
        Me.TestISTATToolStripMenuItem.Name = "TestISTATToolStripMenuItem"
        Me.TestISTATToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TestISTATToolStripMenuItem.Text = "Test_ISTAT"
        '
        'TestRiscontiToolStripMenuItem
        '
        Me.TestRiscontiToolStripMenuItem.Name = "TestRiscontiToolStripMenuItem"
        Me.TestRiscontiToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TestRiscontiToolStripMenuItem.Text = "Test_Risconti"
        '
        'TestRiscontiRidottoToolStripMenuItem
        '
        Me.TestRiscontiRidottoToolStripMenuItem.Name = "TestRiscontiRidottoToolStripMenuItem"
        Me.TestRiscontiRidottoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TestRiscontiRidottoToolStripMenuItem.Text = "Test_RiscontiRidotto"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(192, 6)
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Image = Global.ALLSystemTools.My.Resources.Resources.designfloat_48
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.BackupDatabaseToolStripMenuItem.Text = "Backup database"
        Me.BackupDatabaseToolStripMenuItem.Visible = False
        '
        'CopiaDatabase
        '
        Me.CopiaDatabase.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UNOSuTESTUNOToolStripMenuItem, Me.SPASuTESTSPAToolStripMenuItem})
        Me.CopiaDatabase.Image = Global.ALLSystemTools.My.Resources.Resources.database_add_48
        Me.CopiaDatabase.Name = "CopiaDatabase"
        Me.CopiaDatabase.Size = New System.Drawing.Size(195, 22)
        Me.CopiaDatabase.Text = "Copia Database"
        '
        'UNOSuTESTUNOToolStripMenuItem
        '
        Me.UNOSuTESTUNOToolStripMenuItem.Name = "UNOSuTESTUNOToolStripMenuItem"
        Me.UNOSuTESTUNOToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.UNOSuTESTUNOToolStripMenuItem.Text = "UNO su TEST_UNO"
        '
        'SPASuTESTSPAToolStripMenuItem
        '
        Me.SPASuTESTSPAToolStripMenuItem.Name = "SPASuTESTSPAToolStripMenuItem"
        Me.SPASuTESTSPAToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SPASuTESTSPAToolStripMenuItem.Text = "SPA su TEST_SPA"
        '
        'RiparaMaschereMagoToolStripMenuItem
        '
        Me.RiparaMaschereMagoToolStripMenuItem.Image = Global.ALLSystemTools.My.Resources.Resources.mixx_48
        Me.RiparaMaschereMagoToolStripMenuItem.Name = "RiparaMaschereMagoToolStripMenuItem"
        Me.RiparaMaschereMagoToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.RiparaMaschereMagoToolStripMenuItem.Text = "Ripara maschere Mago"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(192, 6)
        '
        'ExeLocationToolStripMenu
        '
        Me.ExeLocationToolStripMenu.Name = "ExeLocationToolStripMenu"
        Me.ExeLocationToolStripMenu.Size = New System.Drawing.Size(195, 22)
        Me.ExeLocationToolStripMenu.Text = "Exe Location"
        '
        'AppLogToolStripMenu
        '
        Me.AppLogToolStripMenu.Name = "AppLogToolStripMenu"
        Me.AppLogToolStripMenu.Size = New System.Drawing.Size(195, 22)
        Me.AppLogToolStripMenu.Text = "App Log Folder"
        '
        'UserSettingFolderToolStripMenuItem
        '
        Me.UserSettingFolderToolStripMenuItem.Name = "UserSettingFolderToolStripMenuItem"
        Me.UserSettingFolderToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.UserSettingFolderToolStripMenuItem.Text = "User.Setting Folder"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.toolStripSeparator1, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        Me.FileToolStripMenuItem.Visible = False
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(151, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PrintToolStripMenuItem.Text = "&Print"
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Pre&view"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(151, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'FusioneToolStripMenuItem
        '
        Me.FusioneToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EseguiTraTestToolStripMenuItem1, Me.EseguiInDefinitivoToolStripMenuItem, Me.EseguiStep})
        Me.FusioneToolStripMenuItem.Name = "FusioneToolStripMenuItem"
        Me.FusioneToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.FusioneToolStripMenuItem.Text = "Fusione"
        '
        'EseguiTraTestToolStripMenuItem1
        '
        Me.EseguiTraTestToolStripMenuItem1.Name = "EseguiTraTestToolStripMenuItem1"
        Me.EseguiTraTestToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.EseguiTraTestToolStripMenuItem1.Text = "Esegui tra TEST"
        '
        'EseguiInDefinitivoToolStripMenuItem
        '
        Me.EseguiInDefinitivoToolStripMenuItem.Enabled = False
        Me.EseguiInDefinitivoToolStripMenuItem.Name = "EseguiInDefinitivoToolStripMenuItem"
        Me.EseguiInDefinitivoToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EseguiInDefinitivoToolStripMenuItem.Text = "Esegui in Definitivo"
        '
        'EseguiStep
        '
        Me.EseguiStep.Name = "EseguiStep"
        Me.EseguiStep.Size = New System.Drawing.Size(175, 22)
        Me.EseguiStep.Text = "STEP"
        '
        'CespitiToolStripMenuItem
        '
        Me.CespitiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportaToolStripMenuItem, Me.CancellaToolStripMenuItem})
        Me.CespitiToolStripMenuItem.Name = "CespitiToolStripMenuItem"
        Me.CespitiToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.CespitiToolStripMenuItem.Text = "Cespiti"
        '
        'ImportaToolStripMenuItem
        '
        Me.ImportaToolStripMenuItem.Name = "ImportaToolStripMenuItem"
        Me.ImportaToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ImportaToolStripMenuItem.Text = "Importa"
        '
        'CancellaToolStripMenuItem
        '
        Me.CancellaToolStripMenuItem.Name = "CancellaToolStripMenuItem"
        Me.CancellaToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.CancellaToolStripMenuItem.Text = "Cancella"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTracciatoVecchio, Me.ToolStripMenuItemDebugging})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripTracciatoVecchio
        '
        Me.ToolStripTracciatoVecchio.CheckOnClick = True
        Me.ToolStripTracciatoVecchio.Name = "ToolStripTracciatoVecchio"
        Me.ToolStripTracciatoVecchio.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripTracciatoVecchio.Text = "Vecchio Flusso"
        Me.ToolStripTracciatoVecchio.ToolTipText = "Il flusso NON presenta le nuove colonne  ( dalla IB) dedicate alla contabilità an" &
    "alitica ( NrCanoni e Data decorrenza)"
        '
        'ToolStripMenuItemDebugging
        '
        Me.ToolStripMenuItemDebugging.CheckOnClick = True
        Me.ToolStripMenuItemDebugging.Name = "ToolStripMenuItemDebugging"
        Me.ToolStripMenuItemDebugging.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItemDebugging.Text = "Debugging"
        '
        'ComandiToolStripMenuItem
        '
        Me.ComandiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IDToolStripMenuItem, Me.CaricaSchemaToolStripMenuItem, Me.EseguiToolStripMenuItem, Me.XLSToolStripMenuItem, Me.CSVToolStripMenuItem, Me.AnaliticaDaFattureToolStripMenuItem, Me.RiorganizzaCartelleToolStripMenuItem, Me.RegioneDaProvinciaToolStripMenuItem})
        Me.ComandiToolStripMenuItem.Name = "ComandiToolStripMenuItem"
        Me.ComandiToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.ComandiToolStripMenuItem.Text = "Comandi"
        Me.ComandiToolStripMenuItem.Visible = False
        '
        'IDToolStripMenuItem
        '
        Me.IDToolStripMenuItem.Name = "IDToolStripMenuItem"
        Me.IDToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.IDToolStripMenuItem.Text = "ID"
        '
        'CaricaSchemaToolStripMenuItem
        '
        Me.CaricaSchemaToolStripMenuItem.Name = "CaricaSchemaToolStripMenuItem"
        Me.CaricaSchemaToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.CaricaSchemaToolStripMenuItem.Text = "Carica Schema"
        '
        'EseguiToolStripMenuItem
        '
        Me.EseguiToolStripMenuItem.Name = "EseguiToolStripMenuItem"
        Me.EseguiToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.EseguiToolStripMenuItem.Text = "Esegui"
        Me.EseguiToolStripMenuItem.ToolTipText = "Analizza la cartella e per ogni file esegue l'azione corrispondente. DEPRECATO"
        '
        'XLSToolStripMenuItem
        '
        Me.XLSToolStripMenuItem.Name = "XLSToolStripMenuItem"
        Me.XLSToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.XLSToolStripMenuItem.Text = "XLS"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        'AnaliticaDaFattureToolStripMenuItem
        '
        Me.AnaliticaDaFattureToolStripMenuItem.Image = Global.ALLSystemTools.My.Resources.Resources.pie_chart_48
        Me.AnaliticaDaFattureToolStripMenuItem.Name = "AnaliticaDaFattureToolStripMenuItem"
        Me.AnaliticaDaFattureToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AnaliticaDaFattureToolStripMenuItem.Text = "Analitica da fatture"
        '
        'RiorganizzaCartelleToolStripMenuItem
        '
        Me.RiorganizzaCartelleToolStripMenuItem.Name = "RiorganizzaCartelleToolStripMenuItem"
        Me.RiorganizzaCartelleToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RiorganizzaCartelleToolStripMenuItem.Text = "Riorganizza Cartelle"
        '
        'RegioneDaProvinciaToolStripMenuItem
        '
        Me.RegioneDaProvinciaToolStripMenuItem.Name = "RegioneDaProvinciaToolStripMenuItem"
        Me.RegioneDaProvinciaToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RegioneDaProvinciaToolStripMenuItem.Text = "Regione da Provincia"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.toolStripSeparator5, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(24, 20)
        Me.HelpToolStripMenuItem.Text = "&?"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        Me.ContentsToolStripMenuItem.Visible = False
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        Me.IndexToolStripMenuItem.Visible = False
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        Me.SearchToolStripMenuItem.Visible = False
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(119, 6)
        Me.toolStripSeparator5.Visible = False
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'PanelDB
        '
        Me.PanelDB.Controls.Add(Me.CHKDBTemporaneo)
        Me.PanelDB.Controls.Add(Me.BtnSelSPA)
        Me.PanelDB.Controls.Add(Me.BtnSelUNO)
        Me.PanelDB.Controls.Add(Me.Label8)
        Me.PanelDB.Location = New System.Drawing.Point(2, 345)
        Me.PanelDB.Name = "PanelDB"
        Me.PanelDB.Size = New System.Drawing.Size(200, 234)
        Me.PanelDB.TabIndex = 47
        '
        'CHKDBTemporaneo
        '
        Me.CHKDBTemporaneo.AutoSize = True
        Me.CHKDBTemporaneo.Location = New System.Drawing.Point(162, 114)
        Me.CHKDBTemporaneo.Name = "CHKDBTemporaneo"
        Me.CHKDBTemporaneo.Size = New System.Drawing.Size(121, 17)
        Me.CHKDBTemporaneo.TabIndex = 3
        Me.CHKDBTemporaneo.Text = "Azienda Demo/Test"
        Me.CHKDBTemporaneo.UseVisualStyleBackColor = True
        '
        'BtnSelSPA
        '
        Me.BtnSelSPA.Location = New System.Drawing.Point(233, 40)
        Me.BtnSelSPA.Name = "BtnSelSPA"
        Me.BtnSelSPA.Size = New System.Drawing.Size(117, 68)
        Me.BtnSelSPA.TabIndex = 2
        Me.BtnSelSPA.Text = "SPA"
        Me.BtnSelSPA.UseVisualStyleBackColor = True
        '
        'BtnSelUNO
        '
        Me.BtnSelUNO.Location = New System.Drawing.Point(90, 40)
        Me.BtnSelUNO.Name = "BtnSelUNO"
        Me.BtnSelUNO.Size = New System.Drawing.Size(117, 68)
        Me.BtnSelUNO.TabIndex = 1
        Me.BtnSelUNO.Text = "UNO"
        Me.BtnSelUNO.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(92, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(271, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "SELEZIONARE L'AZIENDA SULLA QUALE OPERARE"
        '
        'FLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 371)
        Me.Controls.Add(Me.PanelDB)
        Me.Controls.Add(Me.PanelUser)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lstStatoConnessione)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PanelAdmin)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FLogin"
        Me.Text = "ALL-I"
        Me.PanelAdmin.ResumeLayout(False)
        Me.PanelAdmin.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabFusione.ResumeLayout(False)
        Me.TabFusione.PerformLayout()
        Me.TabPageCancella.ResumeLayout(False)
        Me.TabOrdini.ResumeLayout(False)
        Me.TabPageFatture.ResumeLayout(False)
        Me.TabPageFatture.PerformLayout()
        Me.TabPagePaghe.ResumeLayout(False)
        Me.TabPagePaghe.PerformLayout()
        Me.TabPageAnagrafiche.ResumeLayout(False)
        Me.TabPageAnagrafiche.PerformLayout()
        Me.TabPagePartite.ResumeLayout(False)
        Me.TabPagePartite.PerformLayout()
        Me.TabPagePnota.ResumeLayout(False)
        Me.TabPagePnota.PerformLayout()
        Me.TabCespiti.ResumeLayout(False)
        Me.TabCespiti.PerformLayout()
        Me.PanelUser.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanelDB.ResumeLayout(False)
        Me.PanelDB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnConnetti As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtPSW As TextBox
    Friend WithEvents txtSERVER As TextBox
    Friend WithEvents TxtDB_UNO As TextBox
    Friend WithEvents PanelAdmin As Panel
    Friend WithEvents DtDataInizio As DateTimePicker
    Friend WithEvents lblDataInizio As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lstStatoConnessione As ListBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnPath As Button
    Friend WithEvents lblPath As Label
    Friend WithEvents txtPath As TextBox
    Friend WithEvents txtLoginId As TextBox
    Friend WithEvents LblLoginId As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageAnagrafiche As TabPage
    Friend WithEvents TabPageCancella As TabPage
    Friend WithEvents BtnCancellaPNota As Button
    Friend WithEvents BtnCancellaRID As Button
    Friend WithEvents BtnCancellaFatture As Button
    Friend WithEvents BtnCancellaPartiteFornitore As Button
    Friend WithEvents BtnCancellaPartite As Button
    Friend WithEvents BtnCancellaFornitori As Button
    Friend WithEvents BtnCancellaClienti As Button
    Friend WithEvents BtnProcessa As Button
    Friend WithEvents ChkFornitori As CheckBox
    Friend WithEvents ChkClienti As CheckBox
    Friend WithEvents TabPageFatture As TabPage
    Friend WithEvents ChkFatture As CheckBox
    Friend WithEvents TabPagePartite As TabPage
    Friend WithEvents ChkPartiteFornitori As CheckBox
    Friend WithEvents ChkPartiteCliente As CheckBox
    Friend WithEvents BtnApriLog As Button
    Friend WithEvents ChkDifferenzialeFornitori As CheckBox
    Friend WithEvents ChkDifferenzialeCliente As CheckBox
    Friend WithEvents ChkNoteCliente As CheckBox
    Friend WithEvents TabPagePnota As TabPage
    Friend WithEvents ChkPNotaForDaPartitario As CheckBox
    Friend WithEvents ChkPNotaCliDaPartitario As CheckBox
    Friend WithEvents ChkOnlyWESEIVA As CheckBox
    Friend WithEvents ChkInsertSepaOnBankAuth As CheckBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdministratorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPagePaghe As TabPage
    Friend WithEvents ComandiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChkPaghe As CheckBox
    Friend WithEvents BackupDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CaricaSchemaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EseguiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XLSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelUser As Panel
    Friend WithEvents DisconnettiAdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnPaghe As Button
    Friend WithEvents BtnFatture As Button
    Friend WithEvents BtnLastLog As Button
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ExeLocationToolStripMenu As ToolStripMenuItem
    Friend WithEvents AppLogToolStripMenu As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents BtnAnalitica As Button
    Friend WithEvents AnaliticaDaFattureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTracciatoVecchio As ToolStripMenuItem
    Friend WithEvents ChkInsertSepaOnFoxFields As CheckBox
    Friend WithEvents ChkCreaSDD As CheckBox
    Friend WithEvents ToolStripMenuItemDebugging As ToolStripMenuItem
    Friend WithEvents BtnCancellaAnaliticaDaFatt As Button
    Friend WithEvents RiorganizzaCartelleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChkRisconti As CheckBox
    Friend WithEvents TabCespiti As TabPage
    Friend WithEvents ChkCespiti As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtTmpDB_UNO As TextBox
    Friend WithEvents CespitiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancellaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents TabOrdini As TabPage
    Friend WithEvents BtnOrdini As Button
    Friend WithEvents BtnOrdiniISTAT As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtTmpDB_SPA As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtDB_SPA As TextBox
    Friend WithEvents PanelDB As Panel
    Friend WithEvents BtnSelSPA As Button
    Friend WithEvents BtnSelUNO As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents CHKDBTemporaneo As CheckBox
    Friend WithEvents BtnCancellaRigheOrdini As Button
    Friend WithEvents RiparaMaschereMagoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopiaDatabase As ToolStripMenuItem
    Friend WithEvents ComandiToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TestOrdiniToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestISTATToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestRiscontiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestRiscontiRidottoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChkRiscontiRidotto As CheckBox
    Friend WithEvents FusioneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EseguiTraTestToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TabFusione As TabPage
    Friend WithEvents ChkFusioneFull As CheckBox
    Friend WithEvents RegioneDaProvinciaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UNOSuTESTUNOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SPASuTESTSPAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EseguiInDefinitivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnFusione As Button
    Friend WithEvents ChkFusioneAcquisti As CheckBox
    Friend WithEvents ChkFusioneVendite As CheckBox
    Friend WithEvents ChkFusionePartite As CheckBox
    Friend WithEvents EseguiStep As ToolStripMenuItem
    Friend WithEvents UserSettingFolderToolStripMenuItem As ToolStripMenuItem
End Class
