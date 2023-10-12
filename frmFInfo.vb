Imports System.IO

Public Class FInfo
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnMain As System.Windows.Forms.Panel
    Friend WithEvents pnButt As System.Windows.Forms.Panel

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnClose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FInfo))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnMain = New System.Windows.Forms.Panel()
        Me.pnButt = New System.Windows.Forms.Panel()
        Me.pnButt.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(286, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(94, 25)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Zavøít"
        '
        'pnMain
        '
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnMain.Location = New System.Drawing.Point(0, 0)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Padding = New System.Windows.Forms.Padding(5)
        Me.pnMain.Size = New System.Drawing.Size(392, 338)
        Me.pnMain.TabIndex = 2
        '
        'pnButt
        '
        Me.pnButt.Controls.Add(Me.btnClose)
        Me.pnButt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnButt.Location = New System.Drawing.Point(0, 338)
        Me.pnButt.Name = "pnButt"
        Me.pnButt.Size = New System.Drawing.Size(392, 37)
        Me.pnButt.TabIndex = 3
        '
        'FInfo
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(392, 375)
        Me.Controls.Add(Me.pnMain)
        Me.Controls.Add(Me.pnButt)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(400, 400)
        Me.Name = "FInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informace k "
        Me.pnButt.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared oFrm As FInfo = Nothing
    Public Shared asExt() As String = {"RTF", "TXT", "MHT", "HTM", "HTML", "JPG", "JPEG", "BMP", "TIFF", "GIF"} ' pozor, pozice RTF a TXT se nesmi menit, dotazuji se na index

    Public Shared Sub DisplayString(OwnerForm As Form, sTitle As String, oStringBuilder As System.Text.StringBuilder, Optional bShowModal As Boolean = False)
        DisplayString(OwnerForm, sTitle, oStringBuilder.ToString)
    End Sub

    Public Shared Sub DisplayString(OwnerForm As Form, sTitle As String, sSource As String, Optional bShowModal As Boolean = False)
        Try
            oFrm = New FInfo
            If sTitle <> "" Then oFrm.Text = sTitle Else oFrm.Text = "Zobrazení zprávy"
            Dim oRtf As New RichTextBox
            oRtf.Text = sSource
            oRtf.Dock = DockStyle.Fill
            oRtf.BackColor = SystemColors.Info
            oRtf.ForeColor = SystemColors.InfoText
            oFrm.pnMain.Controls.Add(oRtf)
            oFrm.ShowInTaskbar = False
            If bShowModal Then
                oFrm.ShowInTaskbar = False
                oFrm.ShowDialog()
            Else
                oFrm.ShowInTaskbar = True
                oFrm.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function GetWorkDirectory() As String
        Dim sRet As String = ""
        Try
            sRet = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath))
            If Not IO.Directory.Exists(sRet) Then IO.Directory.CreateDirectory(sRet)
        Catch : End Try
        Return sRet
    End Function

    Public Shared Sub Run(oOwner As Control, ByVal oResourceName As Object, Optional bShowModal As Boolean = False,
                          Optional sTitle As String = "", Optional sAnchorName As String = "", Optional bTopMost As Boolean = False)

        Dim sResourceName As String = CStr(oResourceName)
        Dim sFileName As String
        Dim oRtf As RichTextBox
        Dim oCtl As Control = Nothing
        Dim oFrm As FInfo = Nothing
        If oOwner.GetType.IsSubclassOf(GetType(Form)) OrElse TypeOf oOwner Is Form Then
            oOwner = CType(oOwner, Form)
            Try
                ' vzdy to budu otvirat z resources - nedelam alternativu otvirat to z adresare !!!
                sFileName = IO.Path.Combine(GetWorkDirectory, CStr(oResourceName))
                If Not String.IsNullOrWhiteSpace(sFileName) Then
                    CopyResourceToFile(sResourceName, sFileName)
                    Try
                        Select Case IO.Path.GetExtension(sFileName).ToLower.Replace(".", "")
                            Case "rtf"
                                oRtf = New RichTextBox
                                oRtf.LoadFile(sFileName)
                                oCtl = CType(oRtf, Control)
                            Case "txt"
                                oRtf = New RichTextBox
                                oRtf.LoadFile(sFileName)
                                oCtl = CType(oRtf, Control)
                                Try
                                    oRtf.Font = New Font("Consolas", 9, FontStyle.Regular)
                                Catch : End Try
                                oCtl = oRtf
                                'Case "htm", "html", "xml", "pdf"
                                '    oWbr = New XWebBrowser.ActiveXWebBrowser
                                '    If sAnchorName <> "" Then sFileName &= "#" & sAnchorName
                                '    oWbr.Navigate(sFileName)
                                '    oCtl = oWbr
                            Case Else
                                Dim oPr As New Process
                                oPr.StartInfo.FileName = sFileName
                                oPr.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(sFileName)
                                oPr.Start()
                                oPr.WaitForExit()
                        End Select
                    Catch ex As Exception
                        MsgBox(ex.Message,)
                    End Try
                    If oFrm IsNot Nothing AndAlso (Not oFrm.IsDisposed) AndAlso (oFrm.Visible) Then oFrm.Close()
                    oFrm = New FInfo
                    If sTitle <> "" Then oFrm.Text = sTitle Else oFrm.Text = String.Format("Nápovìda k aplikaci {0}", IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath))
                    oFrm.Name = IO.Path.GetFileNameWithoutExtension(sFileName)
                    oCtl.Dock = DockStyle.Fill
                    oCtl.BackColor = SystemColors.Info
                    oCtl.ForeColor = SystemColors.InfoText
                    oFrm.pnMain.Controls.Add(oCtl)
                    oFrm.ShowInTaskbar = False
                    If bTopMost Then oFrm.TopMost = True
                    If bShowModal Then
                        oFrm.Owner = CType(oOwner, Form)
                        oFrm.StartPosition = FormStartPosition.CenterParent
                        oFrm.ShowInTaskbar = False
                        oFrm.ShowDialog()
                    Else
                        oFrm.StartPosition = FormStartPosition.CenterScreen
                        oFrm.ShowInTaskbar = True
                        oFrm.Show()
                    End If
                    Application.DoEvents()
                End If
                Exit Sub
            Catch ex As Exception
                MsgBox(String.Format("Chyba pøi zobrazování informaèního dokumentu:{0}{0}""{1}"".", vbCrLf, sResourceName), MsgBoxStyle.Exclamation)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub FInfo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If TypeOf sender Is Form Then
            WindowSave(CType(sender, Form))
        End If
    End Sub

    Private Sub Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowRestore(Me, , , , , , , , False)
    End Sub

    Private Sub Frm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        WindowSave(Me)
        Me.Dispose()
        oFrm = Nothing
    End Sub

    Private Sub Ownr_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub rtb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, btnClose.KeyPress
        If e.KeyChar = Chr(27) Then
            Ownr_Closed(Nothing, Nothing)
        End If
    End Sub

End Class
