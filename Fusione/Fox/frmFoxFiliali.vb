Public Class frmFoxFiliali
    Public okFil As List(Of String)
    Private Sub frmFoxFiliali_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ChkOrdBI.Checked = True
        'ChkOrdVA.Checked = True
        'ChkOrdNO.Checked = True
        'ChkOrdAL.Checked = True
        'ChkOrdAT.Checked = True
        'ChkOrdAO.Checked = True
        'ChkOrdTO.Checked = True
        'ChkOrdCN.Checked = True
        'ChkOrdMI.Checked = True
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        GeneraListaPathFiliali()
        ALSO2023 = ChkAlso2023.Checked
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnAnnulla_Click(sender As Object, e As EventArgs) Handles BtnAnnulla.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GeneraListaPathFiliali()
        okFil = New List(Of String)
        ' GroupOrdinari 
        If ChkOrdAL.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdAL.Text))
        If ChkOrdAO.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdAO.Text))
        If ChkOrdAT.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdAT.Text))
        If ChkOrdCN.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdCN.Text))
        If ChkOrdMI.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdMI.Text))
        If ChkOrdNO.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdNO.Text))
        If ChkOrdTO.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdTO.Text))
        If ChkOrdVA.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdVA.Text))
        If ChkOrdBI.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkOrdBI.Text))
        'GroupSpeciali             
        If ChkSpeAL.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeAL.Text))
        If ChkSpeAO.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeAO.Text))
        If ChkSpeAT.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeAT.Text))
        If ChkSpeCN.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeCN.Text))
        If ChkSpeMI.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeMI.Text))
        If ChkSpeNO.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeNO.Text))
        If ChkSpeTO.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeTO.Text))
        If ChkSpeVA.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeVA.Text))
        If ChkSpeBI.Checked Then okFil.Add(String.Concat(If(String.IsNullOrWhiteSpace(My.Settings.mFOXPATH), FolderPath, My.Settings.mFOXPATH), "\Fox", ChkSpeBI.Text))

    End Sub
End Class