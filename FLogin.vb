﻿Imports System.Text
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.MethodBase

'parametri publish locale che funziona
'folder:C:\inetpub\wwwroot\ALL-I\
'install folder:http://localhost/ALL-I/
'update folder : ?

'Parametri Publish su GitHub
'Publishing folder: Installer/
'Installation Folder: https://raw.githubusercontent.com/Brovarone/ALL-I/master/Installer/
'Update: https://raw.githubusercontent.com/Brovarone/ALL-I/master/Installer/

'Da testare x csv
'Imports FileHelpers.ExcelNPOIStorage

'Per file Excel
' https://github.com/ExcelDataReader/ExcelDataReader
' OTTIMO.

' DEPRECATE IN QUANTO TROPPO LENTE SU FILE GROSSI
'Imports NPOI.SS
'Imports NPOI.HSSF
Public Class FLogin
    'Ma_Saledoc  / Doc
    Public AdpDoc As SqlDataAdapter
    Public Ds As DataSet
    Public iIdCounter As Integer = 0 ' contatore degli id/fatture estratte
    Public prgCopy As New CustomProgress

    Const adminPsw = "123456"

    Private Sub BtnConnetti_Click(sender As Object, e As EventArgs) Handles BtnConnetti.Click
        SUBConnetti()
    End Sub
    Private Sub MostraNascondi(ByVal admin As Boolean)
        isAdmin = admin
        PanelUser.Visible = Not admin
        PanelAdmin.Visible = admin
        ComandiToolStripMenuItem.Visible = admin
        DisconnettiAdminToolStripMenuItem.Visible = admin
        AdministratorToolStripMenuItem.Enabled = Not admin
        'DisconnettiAdminToolStripMenuItem.Visible = admin
        'ToolsToolStripMenuItem.Enabled = admin
        'SettingsToolStripMenuItem.Enabled = admin
        Me.Refresh()
    End Sub
    Private Sub En_Dis_Controls(ByVal yes As Boolean, ByVal user As Boolean, ByVal admin As Boolean)
        If user Then
            'Controlli user
            BtnFatture.Enabled = yes
            BtnAnalitica.Enabled = yes
            BtnPaghe.Enabled = yes
            ToolsToolStripMenuItem.Enabled = yes
            SettingsToolStripMenuItem.Enabled = yes
            BtnApriLog.Enabled = yes

        End If
        If admin Then
            'Controlli admin
            txtLoginId.Enabled = yes
            txtPath.Enabled = yes
            BtnProcessa.Enabled = yes
            BtnPath.Enabled = yes
            TabControl1.Enabled = yes
        End If
        Me.Refresh()
    End Sub
    Private Sub SUBConnetti()
        Cursor = Cursors.WaitCursor
        BtnConnetti.Enabled = False

        Connection = New SqlConnection With {
            .ConnectionString = "Data Source=" & txtSERVER.Text & "; Database=" & txtDATABASE.Text & ";User Id=" & txtID.Text & ";Password=" & txtPSW.Text & ";"
            }
        Connection.Open()
        BtnConnetti.Text = Connection.State.ToString()
        If Connection.State = ConnectionState.Open Then
            Using comm As SqlCommand = New SqlCommand("SELECT  @@OPTIONS", Connection)
                'Imposto questo flag per velocizzare se StoredProcedure
                comm.CommandText = "SET ARITHABORT ON"
                'comm.CommandText = "SET QUOTED_IDENTIFIER ON" già presente
                'comm.CommandText = "SET ANSI_NULLS ON" già presente
                comm.ExecuteNonQuery()
                'comm.CommandText = "SELECT  @@OPTIONS"
            End Using
            BtnProcessa.Enabled = True
            TabControl1.Enabled = True
            txtDATABASE.Enabled = False
            txtID.Enabled = False
            txtPSW.Enabled = False
            txtSERVER.Enabled = False
            BtnProcessa.BackColor = BtnConnetti.BackColor
            BtnConnetti.BackColor = BtnPath.BackColor
            BackupDatabaseToolStripMenuItem.Enabled = True

        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub SUBConnetti(Optional ByVal DB As String = "")
        Cursor = Cursors.WaitCursor
        BtnConnetti.Enabled = False
        If String.IsNullOrWhiteSpace(DB) Then DB = txtDATABASE.Text
        Connection = New SqlConnection With {
            .ConnectionString = "Data Source=" & txtSERVER.Text & "; Database=" & DB & ";User Id=" & txtID.Text & ";Password=" & txtPSW.Text & ";"
            }
        Connection.Open()
        BtnConnetti.Text = Connection.State.ToString()
        If Connection.State = ConnectionState.Open Then
            Using comm As SqlCommand = New SqlCommand("SELECT  @@OPTIONS", Connection)
                'Imposto questo flag per velocizzare se StoredProcedure
                comm.CommandText = "SET ARITHABORT ON"
                'comm.CommandText = "SET QUOTED_IDENTIFIER ON" già presente
                'comm.CommandText = "SET ANSI_NULLS ON" già presente
                comm.ExecuteNonQuery()
                'comm.CommandText = "SELECT  @@OPTIONS"
            End Using
            BtnProcessa.Enabled = True
            TabControl1.Enabled = True
            txtDATABASE.Enabled = False
            txtID.Enabled = False
            txtPSW.Enabled = False
            txtSERVER.Enabled = False
            BtnProcessa.BackColor = BtnConnetti.BackColor
            BtnConnetti.BackColor = BtnPath.BackColor
            BackupDatabaseToolStripMenuItem.Enabled = True

        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'aggiungo controllo progressbar
        Me.Controls.Add(prgCopy)
        prgCopy.Style = ProgressBarStyle.Blocks
        prgCopy.Dock = DockStyle.Bottom
        prgCopy.Value = 0.0
        prgCopy.Minimum = 0.0
        prgCopy.Maximum = 100.0
        prgCopy.Style = ProgressBarStyle.Continuous

        Dim oggi As DateTime = DateTime.Today()
        Dim anno As Integer = oggi.Year
        Dim mese As Integer = oggi.Month

        Me.DtDataInizio.Text = (New DateTime(anno, mese, 1)).ToString("d")
        DataInizio = DtDataInizio.Value.ToString("yyyy-MM-dd")
        'Carico dal file config
        txtDATABASE.Text = My.Settings.mDATABASE
        txtSERVER.Text = My.Settings.mSQLSERVER
        txtID.Text = My.Settings.mID
        txtPSW.Text = My.Settings.mPSW
        txtPath.Text = My.Settings.mPATH
        txtLoginId.Text = My.Settings.mLOGINID
        FolderPath = txtPath.Text
        'Aggiungo la possibilità di eseguire il mio textChanged ( SULL'EVENTO LEAVE)
        For Each tx As TextBox In Me.PanelAdmin.Controls.OfType(Of TextBox)()
            'If tx.Name = txtPath.Name Then Continue For
            AddHandler tx.Leave, AddressOf MioTextChanged
        Next
        PanelAdmin.Visible = False

        'Controllo quali pulsanti abilitare in base all'esistenza o meno del file
        ControllaEAbilita()

        'Posiziono il pannello Utente
        PanelUser.Location = PanelAdmin.Location
        PanelUser.Size = PanelAdmin.Size
        lstStatoConnessione.Top = 170
        lstStatoConnessione.Size = New Size(429, 170)
        lstStatoConnessione.BringToFront()
    End Sub
    Private Sub MioTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tb As TextBox = DirectCast(sender, TextBox)
        Select Case tb.Name.ToUpper()

            Case "TXTDATABASE"
                My.Settings.mDATABASE = tb.Text
            Case "TXTSERVER"
                My.Settings.mSQLSERVER = tb.Text
            Case "TXTID"
                My.Settings.mID = tb.Text
            Case "TXTPSW"
                My.Settings.mPSW = tb.Text
            Case "TXTLOGINID"
                My.Settings.mLOGINID = tb.Text
            Case "TXTPATH"
                My.Settings.mPATH = tb.Text

        End Select
    End Sub
    Private Sub DtDataInizio_ValueChanged(sender As Object, e As EventArgs) Handles DtDataInizio.ValueChanged
        DataInizio = DtDataInizio.Value.ToString("yyyy-MM-dd")
    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        ''usare csvhelper per ottenere dataset
        'la libreria e' fallata e non funziona con file senza intestazione
        'ci ho perso la testa 3 giorni
        Dim dt As New DataTable
        Dim sPath As String
        sPath = "C:\Users\Cristiano\Desktop\MIGRAZIONE ALLSYSTEM\F1 Contabilità\FTPA300F.CSV"

        Using reader As New StreamReader(sPath)

            DataGridView1.Visible = True
            DataGridView1.BringToFront()
            DataGridView1.DataSource = dt
        End Using

    End Sub

    Private Sub XLSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XLSToolStripMenuItem.Click
        Dim sPath As String
        ' sPath = "C:\Users\Cristiano\Desktop\MIGRAZIONE ALLSYSTEM\F1 Contabilità\CliFor\01 - ANCL200F.xls"
        sPath = "C:\Users\Cristiano\Desktop\MIGRAZIONE ALLSYSTEM\F1 Contabilità\ANFC200F.xls"
        DataGridView1.Visible = True
        DataGridView1.BringToFront()
        DataGridView1.DataSource = LoadXLS(sPath, True, False).Tables(0)
    End Sub


    Private Sub EseguiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EseguiToolStripMenuItem.Click
        Dim bOkImport As Boolean

        If String.IsNullOrEmpty(FolderPath) Then
            MessageBox.Show("Inserire un percorso valido", My.Application.Info.ProductName)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        My.Application.Log.DefaultFileLogWriter.BaseFileName += "-" & DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss")
        En_Dis_Controls(False, False, True)
        lstStatoConnessione.Items.Add("Attendere... il processo potrebbe durare qualche minuto")

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(FolderPath)

            Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(foundFile)
            Dim sExt As String = System.IO.Path.GetExtension(foundFile)
            lstStatoConnessione.Items.Add(sNomeFile & sExt)
            bOkImport = ProcessaFile(sNomeFile, sExt)
            lstStatoConnessione.Items.Add("Esito elaborazione " & If(bOkImport, "OK", "Errore"))
        Next

        Me.Cursor = Cursors.Default
        MessageBox.Show("Finito", My.Application.Info.Title)
    End Sub

    Private Sub TxtPath_Validated(sender As Object, e As EventArgs) Handles txtPath.Validated
        FolderPath = txtPath.Text
    End Sub

    Private Sub BtnPath_Click_1(sender As Object, e As EventArgs) Handles BtnPath.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = FolderBrowserDialog1.SelectedPath
            FolderPath = FolderBrowserDialog1.SelectedPath
            My.Settings.mPATH = txtPath.Text
        End If
    End Sub

    Private Sub CaricaSchemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaricaSchemaToolStripMenuItem.Click
        Dim dt As DataTable
        '  dt = CaricaSchema("MA_Saledoc")
        '  dt = CaricaSchema("MA_SaledocDetail")
        '  dt = CaricaSchema("MA_PyblsRcvbls")
        dt = CaricaSchema("MA_PyblsRcvblsDetails")
        dt.Dispose()
    End Sub

    Private Sub BtnCancellaClienti_Click(sender As Object, e As EventArgs) Handles BtnCancellaClienti.Click
        Me.Cursor = Cursors.WaitCursor
        Dim result As StringBuilder = New StringBuilder("Clienti:" & vbCrLf)
        Using comm As SqlCommand = New SqlCommand("DELETE MA_CustSuppCustomerOptions WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID, Connection)
            comm.CommandTimeout = 0
            result.Append(" MA_CustSuppCustomerOptions: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_CustSuppNaturalPerson WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID
            result.Append(" MA_CustSuppNaturalPerson: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_CustSuppBranches WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID
            result.Append(" MA_CustSuppBranches: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_CustSuppBudget WHERE CustSuppType=" & CustSuppType.Cliente
            result.Append(" MA_CustSuppBudget: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_CustSuppBalances WHERE CustSuppType=" & CustSuppType.Cliente
            result.Append(" MA_CustSuppBalances: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_DeclarationOfIntent WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID
            result.Append(" MA_DeclarationOfIntent: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_CustSupp WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID
            result.Append(" MA_CustSupp: " & comm.ExecuteNonQuery().ToString)
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub BtnCancellaPartitCliente_Click(sender As Object, e As EventArgs) Handles BtnCancellaPartite.Click
        Me.Cursor = Cursors.WaitCursor
        Dim result As StringBuilder = New StringBuilder("Partite Clienti:" & vbCrLf)
        Dim b As DialogResult = MessageBox.Show("Si=Solo Importate ,  No=Tutte", My.Application.Info.Title, MessageBoxButtons.YesNo)

        If b = DialogResult.Yes Then
            Using comm As SqlCommand = New SqlCommand("DELETE MA_PyblsRcvblsDetails WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID, Connection)
                comm.CommandTimeout = 0
                result.Append(" MA_PyblsRcvblsDetails: " & comm.ExecuteNonQuery().ToString)
                comm.CommandText = "DELETE MA_PyblsRcvbls WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID
                result.Append(" MA_PyblsRcvbls: " & comm.ExecuteNonQuery().ToString)
            End Using
        ElseIf b = DialogResult.No Then
            Using comm As SqlCommand = New SqlCommand("DELETE MA_PyblsRcvblsDetails WHERE CustSuppType=" & CustSuppType.Cliente, Connection)
                comm.CommandTimeout = 0
                result.Append(" MA_PyblsRcvblsDetails: " & comm.ExecuteNonQuery().ToString)
                comm.CommandText = "DELETE MA_PyblsRcvbls WHERE CustSuppType=" & CustSuppType.Cliente
                result.Append(" MA_PyblsRcvbls: " & comm.ExecuteNonQuery().ToString)
            End Using
        End If
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancellaPartiteFornitore_Click(sender As Object, e As EventArgs) Handles BtnCancellaPartiteFornitore.Click
        Me.Cursor = Cursors.WaitCursor
        Dim result As StringBuilder = New StringBuilder("Partite Fornitori:" & vbCrLf)
        Using comm As SqlCommand = New SqlCommand("DELETE MA_PyblsRcvblsDetails WHERE CustSuppType=" & CustSuppType.Fornitore & " AND TBCreatedID=" & My.Settings.mLOGINID, Connection)
            comm.CommandTimeout = 0
            result.Append(" MA_PyblsRcvblsDetails: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_PyblsRcvbls WHERE CustSuppType=" & CustSuppType.Fornitore & " AND TBCreatedID=" & My.Settings.mLOGINID
            result.Append(" MA_PyblsRcvbls: " & comm.ExecuteNonQuery().ToString)
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancellaFatture_Click(sender As Object, e As EventArgs) Handles BtnCancellaFatture.Click
        Dim res As Integer
        Me.Cursor = Cursors.WaitCursor
        prgCopy.Minimum = 1
        prgCopy.Step = 1
        prgCopy.Maximum = 8
        prgCopy.Update()
        Application.DoEvents()
        Dim result As StringBuilder = New StringBuilder("Fatture:" & vbCrLf)
        Dim s As String = InputBox("Indicare la data di import nel formato AAAAMMGG" & vbCrLf & " Se lasciato AAAMMGG verranno cancellate tutte le fatture importate", "", "AAAAMMGG")
        Dim wCrID As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID
        'Dim wCr_Mod As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID
        Using comm As SqlCommand = New SqlCommand("DELETE MA_SaleDocDetail WHERE CustSuppType=" & CustSuppType.Cliente & " And TBCreatedID=" & My.Settings.mLOGINID, Connection)
            comm.CommandTimeout = 0
            'Dim b As DialogResult = MessageBox.Show("Si=Tutte ,  No=Indicare data", My.Application.Info.Title, MessageBoxButtons.YesNo)
            If String.IsNullOrWhiteSpace(s) Then
                'Ho premuto annulla
            ElseIf s = "AAAAMMGG" Then
                'Ho premuto ok ma senza inserire data
                result.Append(" MA_SaleDocDetail: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_SaleDocReferences" & wCrID
                result.Append(" MA_SaleDocReferences: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_SaleDocShipping" & wCrID
                result.Append(" MA_SaleDocShipping: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                prgCopy.Update()
                comm.CommandText = "DELETE MA_SaleDocPymtSched" & wCrID
                result.Append(" MA_SaleDocPymtSched: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_SaleDocSummary" & wCrID
                result.Append(" MA_SaleDocSummary: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_EI_ITDocAdditionalData" & wCrID
                result.Append(" MA_EI_ITDocAdditionalData: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_SaleDocTaxSummary" & wCrID
                result.Append(" MA_SaleDocTaxSummary: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_SaleDoc WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID
                result.Append(" MA_SaleDoc: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
            ElseIf Integer.TryParse(s, res) Then
                'se ho una data valida cancello solo quella data
                'Dim data As String = MagoFormatta(s, GetType(DateTime)).DataTempo
                If Len(s) = 8 Then
                    Dim wCr_Mod_CrDt As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID & " AND TBCreated='" & s & "'"
                    Dim wCL_Cr_Mod_CrDt As String = " WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID & " AND TBCreated='" & s & "'"

                    comm.CommandText = "DELETE MA_SaleDocDetail" & wCL_Cr_Mod_CrDt
                    result.Append(" MA_SaleDocDetail: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_SaleDocReferences" & wCr_Mod_CrDt
                    result.Append(" MA_SaleDocReferences: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_SaleDocShipping" & wCr_Mod_CrDt
                    result.Append(" MA_SaleDocShipping: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_SaleDocPymtSched" & wCr_Mod_CrDt
                    result.Append(" MA_SaleDocPymtSched: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_SaleDocSummary" & wCr_Mod_CrDt
                    result.Append(" MA_SaleDocSummary: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_EI_ITDocAdditionalData" & wCr_Mod_CrDt
                    result.Append(" MA_EI_ITDocAdditionalData: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_SaleDocTaxSummary" & wCr_Mod_CrDt
                    result.Append(" MA_SaleDocTaxSummary: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_SaleDoc" & wCL_Cr_Mod_CrDt
                    result.Append(" MA_SaleDoc: " & comm.ExecuteNonQuery().ToString)
                End If
            End If
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub BtnCancellaRID_Click(sender As Object, e As EventArgs) Handles BtnCancellaRID.Click
        Me.Cursor = Cursors.WaitCursor
        Dim result As StringBuilder = New StringBuilder("Rid:" & vbCrLf)
        Using comm As SqlCommand = New SqlCommand("DELETE MA_SDDMandate WHERE TBCreatedID=" & My.Settings.mLOGINID, Connection)
            comm.CommandTimeout = 0
            result.Append(" MA_SDDMandate: " & comm.ExecuteNonQuery().ToString)
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancellaPNota_Click(sender As Object, e As EventArgs) Handles BtnCancellaPNota.Click
        Me.Cursor = Cursors.WaitCursor
        Dim result As StringBuilder = New StringBuilder("Prima Nota:" & vbCrLf)
        Using comm As SqlCommand = New SqlCommand("DELETE MA_JournalEntriesTaxDetail", Connection)
            comm.CommandTimeout = 0
            result.Append(" MA_JournalEntriesTaxDetail: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_JournalEntriesTax"
            result.Append(" MA_JournalEntriesTax: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_JournalEntriesGLDetail"
            result.Append(" MA_JournalEntriesGLDetail: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_JournalEntries "
            result.Append(" MA_JournalEntries: " & comm.ExecuteNonQuery().ToString)
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BtnProcessa_Click(sender As Object, e As EventArgs) Handles BtnProcessa.Click
        SUBProcessa()
    End Sub
    Private Sub SUBProcessa(Optional ByVal pag As Boolean = False, Optional ByVal fatture As Boolean = False)
        If String.IsNullOrEmpty(FolderPath) Then
            MessageBox.Show("Inserire un percorso valido", My.Application.Info.ProductName)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        En_Dis_Controls(False, True, True)
        lstStatoConnessione.Items.Add("Attendere... il processo potrebbe durare qualche minuto")
        'INIZIALIZZO NUOVO LOG
        My.Application.Log.DefaultFileLogWriter.BaseFileName += "-" & DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss")
        Dim lista As List(Of String) = New List(Of String)

        If ChkClienti.Checked Then
            Dim bFound As Boolean
            Dim Cli As String() = {"ANCL200F", "ANFC200F", "FTEU400F", "ACGSEP00F"}
            Dim CliFound As Boolean() = {False, False, False, False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(Cli)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(Cli(i))
                    If bFound Then
                        CliFound(i) = True
                        Cli(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not CliFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione dei Clienti a causa di file mancanti")
                    Exit For
                End If
            Next
            ProcessaGruppo(Cli, "Clienti")
        End If

        If ChkFornitori.Checked Then
            Dim bFound As Boolean
            Dim Forn As String() = {"ANFO200F", "ANFF200F"}
            Dim ForFound As Boolean() = {False, False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(Forn)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(Forn(i))
                    If bFound Then
                        ForFound(i) = True
                        Forn(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not ForFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione dei Fornitori a causa di file mancanti")
                    Exit For
                End If
            Next
            ProcessaGruppo(Forn, "Fornitori")
        End If

        If ChkFatture.Checked OrElse fatture Then
            Dim bFound As Boolean
            Dim fat As String() = {"FTPA300F", "WESEIVA", "CLIENORD"}
            Dim fatFound As Boolean() = {False, False, False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(fat)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(fat(i))
                    If bFound Then
                        fatFound(i) = True
                        fat(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not fatFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione delle Fatture a causa di file mancanti")
                    Exit For
                End If
            Next
            'Elimino il file di transcode CLIENORD in quanto viene letto dalla procedura
            ReDim Preserve fat(1)
            If ChkOnlyWESEIVA.Checked Then
                Array.Reverse(fat)
                ReDim Preserve fat(0)
            End If
            'lista.RemoveAt(lista.Count)
            ProcessaGruppo(fat, "Fatture")
        End If

        If ChkInsertSepaOnBankAuth.Checked Then
            Dim bFound As Boolean
            Dim fatSe As String() = {"FTPA300F"}
            Dim fatFound As Boolean() = {False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(fatSe)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(fatSe(i))
                    If bFound Then
                        fatFound(i) = True
                        fatSe(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not fatFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione delle Fatture a causa di file mancanti")
                    Exit For
                End If
            Next
            ' Fatture elettroniche CSV 
            lstStatoConnessione.Items.Add("Inserisco i SEPA su bank Auth.")
            EditTestoBarra("Caricamento file in corso...")
            Dim dsXLS As DataSet = New DataSet
            dsXLS.Tables.Add(LoadCsvData(FolderPath & "\FTPA300F.CSV", False, "", ","))
            InsertSepaOnBankAuth(dsXLS, False)
        End If

        If ChkInsertSepaOnFoxFields.Checked Then
            Dim bFound As Boolean
            Dim fatSe As String() = {"FTPA300F"}
            Dim fatFound As Boolean() = {False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(fatSe)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(fatSe(i))
                    If bFound Then
                        fatFound(i) = True
                        fatSe(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not fatFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione delle Fatture a causa di file mancanti")
                    Exit For
                End If
            Next
            ' Fatture elettroniche CSV 
            lstStatoConnessione.Items.Add("Inserisco i SEPA sui campi Fox")
            EditTestoBarra("Caricamento file in corso...")
            Dim dsXLS As DataSet = New DataSet
            dsXLS.Tables.Add(LoadCsvData(FolderPath & "\FTPA300F.CSV", False, "", ","))
            InsertSepaOnFox(dsXLS, ChkCreaSDD.Checked, False)

        End If

        If ChkPaghe.Checked OrElse pag Then
            Dim bFound As Boolean
            Dim paghe As String() = {"ALL????"}
            Dim pagheFound As Boolean() = {False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(paghe)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile Like paghe(i)
                    If bFound Then
                        pagheFound(i) = True
                        paghe(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not pagheFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione delle Paghe a causa di file mancanti")
                    Exit For
                End If
            Next
            ProcessaGruppo(paghe, "Paghe")
        End If

        If ChkPartiteCliente.Checked OrElse ChkDifferenzialeCliente.Checked Then
            Dim bFound As Boolean
            Dim ParC As String() = {"GCPA200F", "QTMP_CPAG"}
            Dim ParCFound As Boolean() = {False, False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(ParC)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(ParC(i))
                    If bFound Then
                        ParCFound(i) = True
                        ParC(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not ParCFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione delle Partite Clienti a causa di file mancanti")
                    Exit For
                End If
            Next
            'Elimino il file di transcode QTMP_CPAG in quanto viene letto dalla procedura
            ReDim Preserve ParC(0)
            ' lista.RemoveAt(lista.Count)
            ProcessaGruppo(ParC, "Partite Clienti")
        End If

        If ChkPartiteFornitori.Checked OrElse ChkDifferenzialeFornitori.Checked Then
            Dim bFound As Boolean
            Dim ParF As String() = {"GFPA200F", "QTMP_CPAG"}
            Dim ParFFound As Boolean() = {False, False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(ParF)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(ParF(i))
                    If bFound Then
                        ParFFound(i) = True
                        ParF(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not ParFFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione delle Partite Fornitori a causa di file mancanti")
                    Exit For
                End If
            Next
            ReDim Preserve ParF(0)
            'lista.RemoveAt(lista.Count)
            ProcessaGruppo(ParF, "Partite Fornitori")
        End If

        If ChkNoteCliente.Checked Then
            Dim bFound As Boolean
            Dim NoteC As String() = {"CLI_NOTE"}
            Dim NoteCFound As Boolean() = {False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(NoteC)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(NoteC(i))
                    If bFound Then
                        NoteCFound(i) = True
                        NoteC(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not NoteCFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione delle Note Clienti a causa di file mancanti")
                    Exit For
                End If
            Next
            ProcessaGruppo(NoteC, "Note Clienti da FoxPro")
        End If

        If ChkPNotaCliDaPartitario.Checked OrElse ChkPNotaForDaPartitario.Checked Then
            Dim esito As Boolean
            Dim clifortype As Integer() = {CustSuppType.Cliente, CustSuppType.Fornitore}
            Dim cliforFound As Boolean() = {ChkPNotaCliDaPartitario.Checked, ChkPNotaForDaPartitario.Checked}

            For i = 0 To UBound(clifortype)
                If cliforFound(i) Then
                    esito = CreaAperturaDaPartite(clifortype(i))
                    lstStatoConnessione.Items.Add("Esito creazione P.Nota " & If(clifortype(i) = CustSuppType.Cliente, CustSuppType.ClienteSTR, CustSuppType.FornitoreSTR) & " : " & If(esito, "OK", "Errore"))
                End If
            Next
        End If

        If ChkRisconti.Checked Then
            Dim bFound As Boolean
            Dim risc As String() = {"RISCONTI"}
            Dim riscFound As Boolean() = {False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(risc)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.Equals(risc(i))
                    If bFound Then
                        riscFound(i) = True
                        risc(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not riscFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione dei risconti file RISCONTI.XLSX")
                    Exit For
                End If
            Next
            ProcessaGruppo(risc, "Risconti")
        End If

        If ChkCespiti.Checked Then
            Dim bFound As Boolean
            Dim cespiti As String() = {"CFIS", "CBIL"}
            Dim cespitiFound As Boolean() = {False, False}
            Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)

            For i = 0 To UBound(cespiti)
                For Each sFile As String In FileInFolder
                    Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                    bFound = sNomeFile.ToUpper.Equals(cespiti(i).ToUpper)
                    If bFound Then
                        cespitiFound(i) = True
                        cespiti(i) = sFile
                        lista.Add(sFile)
                        Exit For
                    End If
                Next
                If Not cespitiFound(i) Then
                    MessageBox.Show("Impossibile continuare l'elaborazione dei Cespiti a causa di file mancanti")
                    Exit For
                End If
            Next
            ProcessaGruppo(cespiti, "Cespiti")
        End If

        'Scrivo informazioni di Chiusura
        lstStatoConnessione.Items.Add("   ---   Elaborazione completata   ---")
        prgCopy.Value = 0
        prgCopy.Text = "Elaborazione completata"
        prgCopy.Refresh()
        BtnApriLog.Enabled = True
        Application.DoEvents()
        Me.Cursor = Cursors.Default
        Me.Refresh()
        'Salvo il log
        ScriviLogESposta(lista)

    End Sub
    Private Sub ProcessaGruppo(ByVal lista As String(), ByVal nomegruppo As String)
        Dim bOkImport As Boolean
        My.Application.Log.DefaultFileLogWriter.WriteLine("  ---  " & nomegruppo & "  ---  " & DateTime.Now.ToString("ddMMyyy-HHmmss"))
        For i = 0 To UBound(lista)
            Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(lista(i))
            Dim sExt As String = System.IO.Path.GetExtension(lista(i))
            lstStatoConnessione.Items.Add(sNomeFile & sExt)
            bOkImport = ProcessaFile(sNomeFile, sExt)
            lstStatoConnessione.Items.Add("Esito elaborazione " & nomegruppo & " (" & sNomeFile & "): " & If(bOkImport, "OK", "Errore"))
        Next

    End Sub


    Private Function ProcessaFile(ByVal filename As String, ByVal ext As String) As Boolean
        Dim esito As Boolean = False
        'Fixare a seguito del file paghe che forse e' un dat
        If ext.ToUpper = ".CSV" OrElse ext.ToUpper = ".XLS" OrElse ext.ToUpper = ".XLSX" OrElse ext.ToUpper = ".DAT" Then
            Dim spath = FolderPath & "\" & filename & ext
            EditTestoBarra("Processo file " & filename & ext)
            prgCopy.Minimum = 0
            prgCopy.Maximum = 100
            prgCopy.Update()
            If New System.IO.FileInfo(spath).Length > 0 Then
                Dim dsXLS As DataSet
                Application.DoEvents()
                'i CSV non hanno intestazione di solito ottengo il file in 
                'dsXLS = If(ext.ToUpper = ".CSV", ProcessaCSV(spath, False), ProcessaXLS(spath, True))
                '' Mettere select case sui nomi file e poi fare IF con csv , xls
                Select Case filename.ToUpper
                    Case "ALL_DATV3_ANCO200F"
                        lstStatoConnessione.Items.Add("Piano dei conti")
                        esito = True
                        ' Piano dei conti
                        Dim bok As Boolean
                        dsXLS = If(ext.ToUpper = ".CSV", ProcessaCSV(spath, False), LoadXLS(spath, True))
                        bok = Processa_PdCXLS(dsXLS, False)
                        If Not bok Then esito = False
                        bok = Processa_PdcAnaliticoXLS(dsXLS, True)
                        If Not bok Then esito = False
                        'bOK = Processa_PdcRubricaXLS(dsXLS, True)
                    Case "ACGPC12"
                        lstStatoConnessione.Items.Add("Piano dei conti")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = UpdPdCXLS(dsXLS, False)

                    Case "ANCL200F"
                        'Clienti (con riga di Intestazione) 
                        lstStatoConnessione.Items.Add("Clienti")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = ClentiXLS(dsXLS, False)
                    Case "ANFC200F"
                        'Clienti Persone Fisiche (con riga di Intestazione)
                        lstStatoConnessione.Items.Add("Clienti - persone fisiche")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = ClientiPFXLS(dsXLS, False)
                    Case "FTEU400F"
                        'CODICI UNIVOCI Fatturazione elettronica
                        lstStatoConnessione.Items.Add("Dati aggiuntivi fattura elettronica")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = UpdClientiFE(dsXLS, False)
                    Case "ACGSEP00F"
                        'Codidi RID/SEPA
                        lstStatoConnessione.Items.Add("Codici RID/SEPA")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = SEPA_RID_XLS(dsXLS, False)
                    Case "CLI_NOTE"
                        'Note Clienti da Foxpro  (con riga di Intestazione)
                        lstStatoConnessione.Items.Add("Note Clienti da Foxpro")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = NoteClientiFoxproXLS(dsXLS, False)
                    Case "RISCONTI"
                        'Risconti Xlsx  (con riga di Intestazione)
                        lstStatoConnessione.Items.Add("Risconti")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = CreaPNotaRisconti(dsXLS.Tables(0))


                    Case "ANFO200F"
                        'Fornitori (con riga di Intestazione)
                        lstStatoConnessione.Items.Add("Fornitori")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = FornitoriXLS(dsXLS, False)
                    Case "ANFF200F"
                        'Fornitori Persone Fisiche (con riga di Intestazione)
                        lstStatoConnessione.Items.Add("Fornitori - persone fisiche")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = FornitoriPFXLS(dsXLS, False)

                    Case "FTPA300F"
                        ' Fatture elettroniche CSV 
                        ' ho deciso di tenere tutto in pancia io 
                        ' leggo quindi questi file 
                        ' NON SO PIU' PERCHE USO 2 METODI DIVERSI
                        lstStatoConnessione.Items.Add("Fatture")
                        EditTestoBarra("Caricamento file Fatture in corso...")
                        dsXLS = New DataSet
                        dsXLS.Tables.Add(LoadCsvData(spath, False, "", ","))
                        Dim sclienord As String = FolderPath & "\CLIENORD.CSV"
                        EditTestoBarra("Caricamento file accessori...")
                        dsXLS.Tables.Add(ProcessaCSV(sclienord, False, "CLIENORD", False))
                        LiberaRam()
                        esito = FattEleCSV(dsXLS, False)
                    Case "WESEIVA"
                        'Dichiarazione di intento
                        lstStatoConnessione.Items.Add("Dichiarazioni di Intento")
                        dsXLS = New DataSet
                        dsXLS.Tables.Add(LoadCsvData(spath, False, "", ","))
                        esito = DichIntentoCSV(dsXLS, False)

                    Case "GCPA200F"
                        'Partite Clienti
                        lstStatoConnessione.Items.Add("Partite clienti")
                        EditTestoBarra("Caricamento file Partite Clienti in corso...")
                        dsXLS = LoadXLS(spath, True, False)
                        Dim transcode As String = FolderPath & "\QTMP_CPAG.CSV"
                        EditTestoBarra("Caricamento file transcodifica condizioni di pagamento in corso...")
                        dsXLS.Tables.Add(ProcessaCSV(transcode, False, "transcode", False))
                        esito = PartiteXLS(dsXLS, "Cliente", False)
                    Case "GFPA200F"
                        'Partite Fornitori
                        lstStatoConnessione.Items.Add("Partite fornitori")
                        EditTestoBarra("Caricamento file Partite Fornitori in corso...")
                        dsXLS = LoadXLS(spath, True, False)
                        Dim transcode As String = FolderPath & "\QTMP_CPAG.CSV"
                        EditTestoBarra("Caricamento file transcodifica condizioni di pagamento in corso...")
                        dsXLS.Tables.Add(ProcessaCSV(transcode, False, "transcode", False))
                        esito = PartiteXLS(dsXLS, "Fornitore", False)
                    Case "MOAZ200F"
                        'Movimenti contabili
                        lstStatoConnessione.Items.Add("Movimenti contabili")
                        '''''Da COMPLETARE'
                        dsXLS = If(ext.ToUpper = ".CSV", ProcessaCSV(spath, False), LoadXLS(spath, True))
                        esito = Processa_MovContXLS(dsXLS, True)
                    Case "MOAN200F"
                        'Movimenti Analitici
                        lstStatoConnessione.Items.Add("Movimenti analitici")
                    'DA FARE'

                    Case "ANAB201L"
                        'BANCHE Clienti
                        lstStatoConnessione.Items.Add("Banche Clienti")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = InsUpdBancheCli(dsXLS, False)
                    Case "CONDPAG"
                        'Condizioni di pagamento
                        lstStatoConnessione.Items.Add("Condizioni di pagamento")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = UpdCondPagXLS(dsXLS, False)

                    Case "CBIL"
                        'Cespiti Movimenti di Bilancio
                        lstStatoConnessione.Items.Add("Cespiti - Movimenti di bilancio")
                        dsXLS = LoadXLS(spath, True, False)
                        esito = CespitiXLS(dsXLS, False)
                    Case "CFIS"
                        'Cespiti Movimenti Fiscali
                        lstStatoConnessione.Items.Add("Cespiti - Movimenti Fiscali")
                        dsXLS = LoadXLS(spath, True, False)

                        esito = CespitiXLS(dsXLS, True)
                    Case Else

                        'Paghe
                        'ALL???
                        If Len(filename) = 7 AndAlso filename Like "ALL????" Then
                            lstStatoConnessione.Items.Add("Paghe")
                            esito = CaricaFlussoPaghe(spath)
                            ' dsXLS.Tables.Add(LoadCsvData(spath, False, "", ","))
                            ' esito = DichIntentoCSV(dsXLS, False)
                        End If

                End Select
            Else
                My.Application.Log.WriteEntry("File vuoto: " & filename & ext)
                lstStatoConnessione.Items.Add("File vuoto: " & filename & ext)
                esito = True
            End If
            LiberaRam()

        End If

        Return esito

    End Function


    Private Sub BtnCancellaFornitori_Click_1(sender As Object, e As EventArgs) Handles BtnCancellaFornitori.Click
        Me.Cursor = Cursors.WaitCursor
        Dim result As StringBuilder = New StringBuilder("Fornitori:" & vbCrLf)
        Using comm As SqlCommand = New SqlCommand("DELETE MA_CustSuppSupplierOptions WHERE CustSuppType=" & CustSuppType.Fornitore & " AND TBCreatedID=" & My.Settings.mLOGINID, Connection)
            comm.CommandTimeout = 0
            result.Append(" MA_CustSuppSupplierOptions: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_CustSuppNaturalPerson WHERE CustSuppType=" & CustSuppType.Fornitore & " AND TBCreatedID=" & My.Settings.mLOGINID
            result.Append(" MA_CustSuppNaturalPerson: " & comm.ExecuteNonQuery().ToString)
            comm.CommandText = "DELETE MA_CustSupp WHERE CustSuppType=" & CustSuppType.Fornitore & " AND TBCreatedID=" & My.Settings.mLOGINID
            result.Append(" MA_CustSupp: " & comm.ExecuteNonQuery().ToString)
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnApriLog_Click(sender As Object, e As EventArgs) Handles BtnApriLog.Click
        Process.Start(My.Application.Log.DefaultFileLogWriter.CustomLocation)
    End Sub

    Private Sub ChkPartiteFornitori_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPartiteFornitori.CheckedChanged
        ChkDifferenzialeFornitori.Enabled = Not ChkPartiteFornitori.Checked
    End Sub

    Private Sub ChkDifferenzialeFornitori_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDifferenzialeFornitori.CheckedChanged
        ChkPartiteFornitori.Enabled = Not ChkDifferenzialeFornitori.Checked
    End Sub

    Private Sub ChkPartiteCliente_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPartiteCliente.CheckedChanged
        ChkDifferenzialeCliente.Enabled = Not ChkPartiteCliente.Checked
    End Sub

    Private Sub ChkDifferenzialeCliente_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDifferenzialeCliente.CheckedChanged
        ChkPartiteCliente.Enabled = Not ChkDifferenzialeCliente.Checked
    End Sub

    Private Sub AdministratorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministratorToolStripMenuItem.Click
        Dim pwD As New PasswordDialogBox
        If pwD.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If pwD.Password = adminPsw Then
                MostraNascondi(True)
                lstStatoConnessione.Location = New Point(12, 270)
                lstStatoConnessione.Size = New Size(429, 69)
            End If
        Else
            'MessageBox.Show("The user cancelled.", "User Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Private Sub DisconnettiAdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisconnettiAdminToolStripMenuItem.Click
        MostraNascondi(False)
        lstStatoConnessione.Top = 170
        lstStatoConnessione.Size = New Size(429, 170)
        lstStatoConnessione.BringToFront()
    End Sub
    Private Sub IDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IDToolStripMenuItem.Click
        MessageBox.Show(LeggiID(IdType.DicIntento).ToString)
    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupDatabaseToolStripMenuItem.Click
        MySqlServerBackup.Backup()
    End Sub

    Private Sub TestPagheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestPagheToolStripMenuItem.Click
        CaricaFlussoPaghe("")
        DataGridView1.Visible = True
        DataGridView1.BringToFront()
    End Sub



    Private Sub ControllaEAbilita()
        If String.IsNullOrEmpty(FolderPath) Then
            Return
        End If
        'lstStatoConnessione.Items.Add("Analisi cartella in corso...")

        ' Fatture
        Dim bFound As Boolean
        Dim fat As String() = {"FTPA300F", "WESEIVA", "CLIENORD"}
        Dim fatFound As Boolean() = {False, False, False}
        Dim FileInFolder As String() = Directory.GetFiles(FolderPath, "*.*", SearchOption.TopDirectoryOnly)
        For i = 0 To UBound(fat)
            For Each sFile As String In FileInFolder
                Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile)
                bFound = sNomeFile.Equals(fat(i))
                If bFound Then
                    fatFound(i) = True
                    fat(i) = sFile
                    Exit For
                End If
            Next
            If Not fatFound(i) Then
                Debug.Print("Impossibile continuare l'elaborazione delle Fatture a causa di file mancanti")
                BtnFatture.Enabled = False
                Exit For
            End If
        Next

        ' Paghe ALLmmaa.dat
        Dim paghe As String() = {"ALL????"}
        Dim pagheFound As Boolean() = {False}
        For i = 0 To UBound(paghe)
            For Each sFile As String In FileInFolder
                Dim sNomeFile As String = System.IO.Path.GetFileNameWithoutExtension(sFile).ToUpper

                bFound = sNomeFile Like paghe(i)
                If bFound Then
                    Dim r As Integer
                    If Integer.TryParse(Mid(sNomeFile, 4), r) Then
                        pagheFound(i) = True
                        paghe(i) = sFile
                        Dim sB As StringBuilder = New StringBuilder(BtnPaghe.Text)
                        sB.Append(": " & DateAndTime.MonthName(Mid(sNomeFile, 4, 2)) & " 20" & Mid(sNomeFile, 6, 2))
                        BtnPaghe.Text = sB.ToString
                        Exit For
                    End If
                End If
            Next
            If Not pagheFound(i) Then
                Debug.Print("Impossibile continuare l'elaborazione delle Paghe a causa di file mancanti")
                BtnPaghe.Enabled = False
                Exit For
            End If
        Next

        Me.Cursor = Cursors.Default
        Me.Refresh()
    End Sub

    Private Sub BtnFatture_Click(sender As Object, e As EventArgs) Handles BtnFatture.Click
        SUBConnetti()
        If Connection.State = ConnectionState.Open Then SUBProcessa(False, True)
    End Sub

    Private Sub BtnPaghe_Click(sender As Object, e As EventArgs) Handles BtnPaghe.Click
        SUBConnetti()
        If Connection.State = ConnectionState.Open Then SUBProcessa(True, False)
    End Sub

    Private Sub BtnLastLog_Click(sender As Object, e As EventArgs) Handles BtnLastLog.Click
        Process.Start(My.Settings.mLastLogPath)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub UserSettingToolStripMenu_Click(sender As Object, e As EventArgs) Handles UserSettingToolStripMenu.Click
        Dim s = My.Settings.Context
        Dim k = s.Values(1)
        Process.Start(Path.GetDirectoryName(k.assembly.location.ToString))
    End Sub

    Private Sub AppLogToolStripMenu_Click(sender As Object, e As EventArgs) Handles AppLogToolStripMenu.Click
        Process.Start(My.Application.Log.DefaultFileLogWriter.CustomLocation)
    End Sub
    Private Sub SUBAnalitica()
        Dim f As FiltriAnalitici = New FiltriAnalitici
        Using frm As FAskFiltriAnalitica = New FAskFiltriAnalitica
            Dim result As DialogResult = frm.ShowDialog
            If result = DialogResult.OK Then
                f = frm.f
            ElseIf result = DialogResult.Cancel Then
                Exit Sub
            End If
        End Using

        SUBConnetti()
        If Connection.State = ConnectionState.Open Then
            Me.Cursor = Cursors.WaitCursor
            En_Dis_Controls(False, False, True)
            lstStatoConnessione.Items.Add("Attendere... il processo potrebbe durare qualche minuto")
            'INIZIALIZZO NUOVO LOG
            My.Application.Log.DefaultFileLogWriter.BaseFileName += "-" & DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss")
            Dim esito As Boolean

            'ESEGUO LA PROCEDURA
            esito = CreaAnaliticaDaFatture(f)
            lstStatoConnessione.Items.Add("Esito creazione Movimenti analitici " & If(esito, "OK", "Errore"))


            lstStatoConnessione.Items.Add("   ---   Elaborazione completata   ---")
            prgCopy.Value = 0
            prgCopy.Text = "Elaborazione completata"
            prgCopy.Refresh()
            Application.DoEvents()
            Me.Cursor = Cursors.Default
            Me.Refresh()

            'Salvo il log
            ScriviLogESposta()

        End If
    End Sub
    Private Sub BtnAnalitica_Click(sender As Object, e As EventArgs) Handles BtnAnalitica.Click
        SUBAnalitica()
    End Sub

    Private Sub AnaliticaDaFattureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnaliticaDaFattureToolStripMenuItem.Click
        SUBAnalitica()
    End Sub

    Private Sub ToolStripTracciatoVecchio_Click(sender As Object, e As EventArgs) Handles ToolStripTracciatoVecchio.Click
        bOldtrack = ToolStripTracciatoVecchio.Checked
        lstStatoConnessione.Items.Add("Flusso vecchio " & If(bOldtrack, "abilitato", "disabilitato"))

        BtnFatture.BackColor = If(bOldtrack, Color.Coral, BtnApriLog.BackColor)


    End Sub

    Private Sub ToolStripMenuItemDebugging_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDebugging.Click
        bIsDebugging = ToolStripTracciatoVecchio.Checked
        lstStatoConnessione.Items.Add("DEBUG - Log Dettagliato " & If(bOldtrack, "abilitato", "disabilitato"))

    End Sub

    Private Sub BtnCancellaAnaliticaDaFatt_Click(sender As Object, e As EventArgs) Handles BtnCancellaAnaliticaDaFatt.Click
        Dim res As Integer
        Me.Cursor = Cursors.WaitCursor
        Dim result As StringBuilder = New StringBuilder("Analitica:" & vbCrLf)
        Dim s As String = InputBox("Indicare la data di import nel formato AAAAMMGG" & vbCrLf & " Se lasciato AAAMMGG verranno cancellate tutte le fatture importate", "", "AAAAMMGG")
        'Dim wCrID As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID
        Dim wCr_Mod As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID
        Using comm As SqlCommand = New SqlCommand("DELETE MA_CostAccEntriesDetail " & wCr_Mod, Connection)
            comm.CommandTimeout = 0
            'Dim b As DialogResult = MessageBox.Show("Si=Tutte ,  No=Indicare data", My.Application.Info.Title, MessageBoxButtons.YesNo)
            If String.IsNullOrWhiteSpace(s) Then
                'Ho premuto annulla
            ElseIf s = "AAAAMMGG" Then
                'Ho premuto ok ma senza inserire data
                'LOW reimposta flag su documento
                'result.Append(" MA_CostAccEntriesDetail: " & comm.ExecuteNonQuery().ToString)
                'prgCopy.PerformStep()
                'Dim wCross As String = " WHERE DerivedDocType=" & CrossReference.MovimentoAnalitico & " AND TBCreatedID=" & My.Settings.mLOGINID
                'comm.CommandText = "DELETE MA_CrossReferences" & wCross
                'result.Append(" MA_CrossReferences: " & comm.ExecuteNonQuery().ToString)
                'prgCopy.PerformStep()
                'comm.CommandText = "DELETE MA_CostAccEntries" & wCr_Mod
                'result.Append(" MA_CostAccEntries: " & comm.ExecuteNonQuery().ToString)
                'prgCopy.PerformStep()
                'prgCopy.Update()
            ElseIf Integer.TryParse(s, res) Then
                'se ho una data valida cancello solo quella data
                'Dim data As String = MagoFormatta(s, GetType(DateTime)).DataTempo
                If Len(s) = 8 Then
                    Dim wCr_Mod_CrDt As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID & " AND TBCreated='" & s & "'"
                    Dim wCross As String = " WHERE DerivedDocType=" & CrossReference.MovimentoAnalitico & " AND TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID & " AND TBCreated='" & s & "'"

                    comm.CommandText = "DELETE MA_CostAccEntriesDetail" & wCr_Mod_CrDt
                    result.Append(" MA_CostAccEntriesDetail: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_CrossReferences" & wCross
                    result.Append(" MA_CrossReferences: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "UPDATE MA_SaleDoc SET PostedToCostAccounting = 0 WHERE SaleDocid IN ( SELECT SaleDocId FROM MA_CostAccEntries " & wCr_Mod_CrDt & ")"
                    result.Append(" Update MA_SaleDoc: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_CostAccEntries" & wCr_Mod_CrDt
                    result.Append(" MA_CostAccEntries: " & comm.ExecuteNonQuery().ToString)
                End If
            End If
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub RiorganizzaCartelleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiorganizzaCartelleToolStripMenuItem.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Const sl As String = "\"
            Dim p As String = FolderBrowserDialog1.SelectedPath
            Dim Folders As String() = Directory.GetDirectories(p)

            For Each f As String In Folders
                Dim d As DateTime
                Dim fName As String = Strings.Left(Path.GetFileName(f), 10)
                If DateTime.TryParse(fName, d) Then
                    Dim dest As String = p & sl & d.ToString("yyyy") & sl & d.ToString("MMMM", New Globalization.CultureInfo("it-IT")).ToUpper & sl & Path.GetFileName(f)
                    moveDirectory(f, dest, True)
                End If
            Next
        End If
    End Sub

    Private Sub MoveDirectory(ByVal origine As String, ByVal destino As String, Optional withDelete As Boolean = False)
        If Not System.IO.Directory.Exists(destino) Then
            System.IO.Directory.CreateDirectory(destino)
        End If

        Dim files As String() = Directory.GetFiles(origine)
        Dim directories As String() = Directory.GetDirectories(origine)

        For Each s As String In files
            System.IO.File.Copy(s, Path.Combine(destino, Path.GetFileName(s)), True)
        Next

        For Each d As String In directories
            MoveDirectory(Path.Combine(origine, Path.GetFileName(d)), Path.Combine(destino, Path.GetFileName(d)))
        Next
        If withDelete Then Directory.Delete(origine, True)
    End Sub

    Private Sub TestRiscontiToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TestRiscontiToolStripMenuItem.Click
        ChkRisconti.Checked = True
        SUBConnetti()
        SUBProcessa()
    End Sub

    Private Sub ImportaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportaToolStripMenuItem.Click
        'Processa Cespiti
        ChkCespiti.Checked = True
        Dim bok As Boolean = MessageBox.Show("Temporaneo [" & TxtTMPDB.Text & "] (SI) o definitivo [" & txtDATABASE.Text & "] (NO)?", "Import Cespiti", MessageBoxButtons.YesNoCancel) = DialogResult.Yes
        SUBConnetti(If(bok, TxtTMPDB.Text, ""))
        SUBProcessa()
    End Sub

    Private Sub CancellaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancellaToolStripMenuItem.Click
        'Elimina cespiti
        SUBConnetti()
        Dim res As Integer
        Me.Cursor = Cursors.WaitCursor
        prgCopy.Minimum = 1
        prgCopy.Step = 1
        prgCopy.Maximum = 8
        prgCopy.Update()
        Application.DoEvents()
        Dim result As StringBuilder = New StringBuilder("Saldi Cespiti:" & vbCrLf)
        Dim s As String = InputBox("Indicare la data di import nel formato AAAAMMGG" & vbCrLf & " Se lasciato AAAMMGG verranno cancellate tutti", "", "AAAAMMGG")
        Dim wCrID As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID
        'Dim wCr_Mod As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID
        Using comm As SqlCommand = New SqlCommand("DELETE MA_FixedAssetsBalance" & wCrID, Connection)
            comm.CommandTimeout = 0
            'Dim b As DialogResult = MessageBox.Show("Si=Tutte ,  No=Indicare data", My.Application.Info.Title, MessageBoxButtons.YesNo)
            If String.IsNullOrWhiteSpace(s) Then
                'Ho premuto annulla
            ElseIf s = "AAAAMMGG" Then
                'Ho premuto ok ma senza inserire data
                result.Append(" MA_FixedAssetsBalance: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_FixedAssetsFiscal" & wCrID
                result.Append(" MA_FixedAssetsFiscal: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_FixAssetEntriesDetail" & wCrID
                result.Append(" MA_FixAssetEntriesDetail: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                prgCopy.Update()
                comm.CommandText = "DELETE MA_FixAssetEntries" & wCrID
                result.Append(" MA_FixAssetEntries: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()
                comm.CommandText = "DELETE MA_FixedAssets" & wCrID
                result.Append(" MA_FixedAssets: " & comm.ExecuteNonQuery().ToString)
                prgCopy.PerformStep()

            ElseIf Integer.TryParse(s, res) Then
                'se ho una data valida cancello solo quella data
                'Dim data As String = MagoFormatta(s, GetType(DateTime)).DataTempo
                If Len(s) = 8 Then
                    Dim wCr_Mod_CrDt As String = " WHERE TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID & " AND TBCreated='" & s & "'"
                    Dim wCL_Cr_Mod_CrDt As String = " WHERE CustSuppType=" & CustSuppType.Cliente & " AND TBCreatedID=" & My.Settings.mLOGINID & " AND TBModifiedID=" & My.Settings.mLOGINID & " AND TBCreated='" & s & "'"

                    comm.CommandText = "DELETE MA_FixedAssetsBalance" & wCr_Mod_CrDt
                    result.Append(" MA_FixedAssetsBalance: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_FixedAssetsFiscal" & wCr_Mod_CrDt
                    result.Append(" MA_FixedAssetsFiscal: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_FixAssetEntriesDetail" & wCr_Mod_CrDt
                    result.Append(" MA_FixAssetEntriesDetail: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_FixAssetEntries" & wCr_Mod_CrDt
                    result.Append(" MA_FixAssetEntries: " & comm.ExecuteNonQuery().ToString)
                    comm.CommandText = "DELETE MA_FixedAssets" & wCr_Mod_CrDt
                    result.Append(" MA_FixedAssets: " & comm.ExecuteNonQuery().ToString)

                End If
            End If
        End Using
        MessageBox.Show(result.ToString)
        Me.Cursor = Cursors.Default
    End Sub

End Class