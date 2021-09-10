Imports System.Windows.Forms

Partial Public Class MessageBoxWithDetails
    Inherits Form

    Private Const DetailsFormat As String = "Details {0}"

    Public Sub New(ByVal message As String, ByVal title As String, ByVal Optional details As String = Nothing)
        InitializeComponent()
        lblMessage.Text = message
        Me.Text = title

        If details IsNot Nothing Then
            btnDetails.Enabled = True
            btnDetails.Text = DownArrow
            tbDetails.Text = details
        End If
    End Sub

    Private ReadOnly Property UpArrow As String
        Get
            Return String.Format(DetailsFormat, Char.ConvertFromUtf32(&H25B4))
        End Get
    End Property

    Private ReadOnly Property DownArrow As String
        Get
            Return String.Format(DetailsFormat, Char.ConvertFromUtf32(&H25BE))
        End Get
    End Property

    'Public Shared Sub Show(ByVal message As String, ByVal title As String, ByVal Optional details As String = Nothing)
    ' Dim x As MessageBoxWithDetails
    ' MyBase.New(message, title, details)
    '     x.MyNew(message, title, details)
    '    x.ShowDialog()
    ' Me
    ' End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        Dim height = lblMessage.Height
        SetMessageBoxHeight(height)
    End Sub

    Private Sub SetMessageBoxHeight(ByVal heightChange As Integer)
        Me.Height = Me.Height + heightChange

        If Me.Height < 150 Then
            Me.Height = 150
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        btnCopy.Anchor = AnchorStyles.Top
        btnClose.Anchor = AnchorStyles.Top
        btnDetails.Anchor = AnchorStyles.Top
        tbDetails.Anchor = AnchorStyles.Top
        tbDetails.Visible = Not tbDetails.Visible
        btnCopy.Visible = Not btnCopy.Visible
        btnDetails.Text = If(tbDetails.Visible, UpArrow, DownArrow)
        SetMessageBoxHeight(If(tbDetails.Visible, tbDetails.Height + 10, -tbDetails.Height - 10))
    End Sub

    Private Sub btnCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCopy.Click
        Clipboard.SetText(tbDetails.Text)
    End Sub

    Private Sub MessageBoxWithDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

