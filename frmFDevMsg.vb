Imports Microsoft.Win32

Public Class FDevMsg
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cbNosh As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnHledat As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHledatDalsi As System.Windows.Forms.Button
    Friend WithEvents dBox As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FDevMsg))
        Me.cbNosh = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dBox = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnHledat = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnHledatDalsi = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'cbNosh
        '
        Me.cbNosh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbNosh.Checked = True
        Me.cbNosh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNosh.Location = New System.Drawing.Point(12, 198)
        Me.cbNosh.Name = "cbNosh"
        Me.cbNosh.Size = New System.Drawing.Size(185, 26)
        Me.cbNosh.TabIndex = 2
        Me.cbNosh.Text = "Pøíštì tuto zprávu nezobrazovat"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(616, 198)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(94, 26)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Zavøít"
        '
        'dBox
        '
        Me.dBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.dBox.Location = New System.Drawing.Point(2, 2)
        Me.dBox.Multiline = True
        Me.dBox.Name = "dBox"
        Me.dBox.ReadOnly = True
        Me.dBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.dBox.Size = New System.Drawing.Size(718, 190)
        Me.dBox.TabIndex = 1
        Me.dBox.Text = "TextBox1"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(292, 202)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(234, 21)
        Me.txtSearch.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtSearch, "Text který se má vyhledat. Velká/malá písmena a diakritika se ignorují.")
        '
        'btnHledat
        '
        Me.btnHledat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHledat.Image = CType(resources.GetObject("btnHledat.Image"), System.Drawing.Image)
        Me.btnHledat.Location = New System.Drawing.Point(532, 198)
        Me.btnHledat.Name = "btnHledat"
        Me.btnHledat.Size = New System.Drawing.Size(34, 26)
        Me.btnHledat.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnHledat, "Vyhledat text")
        Me.btnHledat.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(203, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "hledat text :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnHledatDalsi
        '
        Me.btnHledatDalsi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHledatDalsi.Image = CType(resources.GetObject("btnHledatDalsi.Image"), System.Drawing.Image)
        Me.btnHledatDalsi.Location = New System.Drawing.Point(572, 198)
        Me.btnHledatDalsi.Name = "btnHledatDalsi"
        Me.btnHledatDalsi.Size = New System.Drawing.Size(34, 26)
        Me.btnHledatDalsi.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btnHledatDalsi, "Vyhledat další výskyt textu")
        Me.btnHledatDalsi.UseVisualStyleBackColor = True
        '
        'FDevMsg
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(722, 239)
        Me.Controls.Add(Me.cbNosh)
        Me.Controls.Add(Me.btnHledatDalsi)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnHledat)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dBox)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(730, 260)
        Me.Name = "FDevMsg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informace o úpravách a zmìnách, vztahujících se k aktuální verzi této aplikace"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Shared DevMsg As New FDevMsg

    Public DevMsgs As New Hashtable
    Public ShowDeveloperMessage As Boolean = False
    Public DevMsgChksum As String
    Public asTesterText As String() = Nothing

    Dim sMfrmName As String
    Dim iChecksum As Integer
    Dim dtVar, dtOld, dtMsg As Date
    Dim bWasDate As Boolean
    Private Const iChecksumInit As Integer = &H55AA55AA

    Public Sub InitDevMsg(oOwner As Form)
        Dim bDebug As Boolean = False
#If DEBUG Then
        bDebug = True
#End If
        iChecksum = iChecksumInit
        GetResourceTextLines("AppDeveloperMessage.txt", IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "VVM_info.isp"))
        DevMsgChksum = Format(dtMsg, "d.M.yyyy") + " 0x" + Hex(iChecksum).PadLeft(4, "0"c)
        ReadFromReg("@", nmLdm)
        If bWasDate AndAlso (psPstr <> DevMsgChksum) Then
            If GetBoolSwitch("CDM") Then    ' prepinac - pouze vymaze zobrazeni developermessage
                WriteToReg(DevMsgChksum, "@", nmLdm)
            Else
                '#If ISPcompile Then
                '                If iMform.PreviousRunTime < New Date(2019, 11, 20, 9, 15, 0) AndAlso Now.Date <= New Date(2019, 11, 24) Then
                '                    FInfo.Run(Me, "ISP4Uvod.pdf")
                '                End If
                '#End If
                LoadMessage(DevMsgs, asTesterText)
                Me.Owner = oOwner
                ShowDialog()
                If cbNosh.Checked Or GetBoolSwitch("C") Then WriteToReg(DevMsgChksum, "@", nmLdm)
                ClearOldKeysAndValues()     ' vycistit balast z registru
            End If
        End If
    End Sub

    Public Sub ShowForm(oOwner As Form)
        cbNosh.Checked = False
        iChecksum = iChecksumInit
        GetResourceTextLines("AppDeveloperMessage.txt", IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "VVM_info.isp"))
        DevMsgChksum = Format(dtMsg, "d.M.yyyy") + " 0x" + Hex(iChecksum).PadLeft(4, "0"c)
        LoadMessage(DevMsgs, asTesterText)
        Me.Owner = oOwner
        ShowDialog()
        If cbNosh.Checked Then WriteToReg(DevMsgChksum, "@", nmLdm)
        ClearOldKeysAndValues()     ' vycistit balast z registru
    End Sub

    ' vycistit balast z registru
    Private Sub ClearOldKeysAndValues()
        Dim oRk As RegistryKey = Nothing
        Try
            oRk = Registry.CurrentUser.OpenSubKey(AppReg, True)
            For Each s As String In oRk.GetSubKeyNames
                If s = "@" Then
                    ' to je balast ze starych verzi
                    ' vycistime ten klic @ ...
                    oRk.DeleteSubKey(s)
                    ' ... a v rootu vse, krome toho, co zacina teckou a sDevnm
                    For Each s2 As String In oRk.GetValueNames
                        If Not (s2.StartsWith(".") OrElse String.Compare(s2, nmLdm, True) = 0) Then
                            oRk.DeleteValue(s2)
                        End If
                    Next
                    Exit Try
                End If
            Next
        Catch
        Finally
            If Not oRk Is Nothing Then oRk.Close()
        End Try
    End Sub

    Private Function GetResourceTextLines(ByVal sName As String, Optional ByVal sExName As String = "") As String()
        Dim s As String = ""
        Dim s0, s1 As String
        Dim oRes As String() = {""}

#If EXTERNALDEVINFO Then
        Try
            If sExName<>"" andalso IO.File.Exists(sExName) Then
                Dim oTxtRdr As IO.TextReader = New IO.StreamReader(sExName, System.Text.Encoding.Default)
                s = Replace(oTxtRdr.ReadToEnd(), vbCr, "") + vbLf
                oTxtRdr.Close()
                GoTo 10
            End If
        Catch ex As Exception
            iLog.ErrLog(ex)
        End Try
#End If

        Try
            Dim executing_assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly()
            Dim my_namespace As String = executing_assembly.GetName().Name.ToString()
            my_namespace = GetType(FDevMsg).Namespace
            Dim text_stream As IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(my_namespace + "." + sName)
            bWasDate = False
            If Not (text_stream Is Nothing) Then
                Dim stream_reader As New IO.StreamReader(text_stream, System.Text.Encoding.Default)
                s = Replace(stream_reader.ReadToEnd(), vbCr, "") + vbLf
                oRes = Split(s, vbLf)
                stream_reader.Close()
                Dim iEot As Integer = s.IndexOf("<END>")
                If iEot > 0 Then s = s.Substring(0, iEot) + vbLf
            End If
        Catch ex As Exception
            'iLog.ErrLog(ex)
        End Try

10:     Dim i1, i2, i4 As Integer
        Dim c As Char
        i4 = 5
        For i1 = 0 To Len(s) - 1
            c = s.Chars(i1)
            i2 = AscW(c)
            i4 = (i4 Xor i2)
            If (i4 And &H8000) <> 0 Then
                i4 = ((i4 And &H7FFF) << 1) Or 1
            Else
                i4 = (i4 << 1)
            End If
        Next
        iChecksum = iChecksum Xor i4
        'napred to rozlozim do DevMsgs
        s0 = ""
        DevMsgs.Clear()
        While InStr(s, vbLf) > 0
            s1 = Trim(Mid(s, 1, InStr(s, vbLf) - 1))
            If TryMakeDate(s1) Then
                If s0 <> "" Then If Not DevMsgs.ContainsKey(dtOld) Then DevMsgs.Add(dtOld, s0)
                s0 = ""
            Else
                If bWasDate AndAlso s1 <> "" Then s0 += s1 + vbLf
            End If
            s = Mid(s, InStr(s, vbLf) + 1)
        End While
        If bWasDate Then If Not DevMsgs.ContainsKey(dtVar) Then DevMsgs.Add(dtVar, s0)
        Return oRes
    End Function

    Private Function TryMakeDate(ByVal s As String) As Boolean
        Dim s1 As String, i1, i2, i3 As Integer
        s = Replace(s + ".0.0.", " ", "")
        Try
            s1 = Mid(s, 1, InStr(s, ".") - 1)
            If Not IsNumeric(s1) Then Return False
            i1 = CInt(s1)
            If (i1 < 1) Or (i1 > 31) Then Return False
            s = Mid(s, InStr(s, ".") + 1)

            s1 = Mid(s, 1, InStr(s, ".") - 1)
            If Not IsNumeric(s1) Then Return False
            i2 = CInt(s1)
            If (i2 < 1) Or (i2 > 12) Then Return False
            s = Mid(s, InStr(s, ".") + 1)

            s1 = Mid(s, 1, InStr(s, ".") - 1)
            If Not IsNumeric(s1) Then Return False
            i3 = CInt(s1)
            If (i3 >= 4) AndAlso (i3 < 99) Then i3 += 2000
            If (i3 < 2004) Or (i3 > 2099) Then Return False

            dtOld = dtVar
            dtVar = New Date(i3, i2, i1)
            If Not bWasDate Then dtMsg = dtVar
            bWasDate = True
            If dtVar > dtMsg Then dtMsg = dtVar
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

    Public Sub LoadMessage(ByVal ht As Hashtable, Optional ByVal TesterText As String() = Nothing)
        dBox.Text = ""
        Dim al As New ArrayList
        Dim ll As New ArrayList
        Dim sa As String()
        For Each itm As Date In ht.Keys
            If Not al.Contains(itm) Then al.Add(itm)
        Next
        al.Sort()
        Dim fs As Boolean
        For i1 As Integer = al.Count - 1 To 0 Step -1
            ll.Add("")
            ll.Add(Format(CDate(al(i1)), "   d. MMMM yyyy"))
            ll.Add("")
            Dim s As String = Replace(Replace(CStr(ht(CDate(al(i1)))), "\t", vbTab), "\n", vbLf)
            fs = True
            While s <> ""
                Dim s1 As String = Mid(s, 1, InStr(s, vbLf) - 1).Replace("\s", " ")
                Dim admmsg As Boolean = (InStr(s1, "@") = 1)
                If admmsg Then s1 = Mid(s1, 2)
                If (s1 <> "") Or (Not fs) Then
                    ll.Add(s1)
                End If
                If s1 <> "" Then fs = False
                s = Mid(s, InStr(s, vbLf) + 1)
            End While
            ll.Add("")
            s = ""
            ll.Add(s.PadLeft(40, "_"c))
        Next
        ReDim sa(ll.Count - 1)
        For i1 As Integer = 0 To ll.Count - 1
            sa(i1) = CStr(ll(i1))
        Next
        If TesterText Is Nothing Then
            dBox.Lines = sa
        Else
            Dim aoTtx As New ArrayList
            aoTtx.AddRange(TesterText)
            aoTtx.AddRange(sa)
            dBox.Lines = CType(aoTtx.ToArray(GetType(String)), String())
        End If
    End Sub

    Private Sub FDevMsg_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Debug.WriteLine(Me.ActiveControl.Name)
        If Me.ActiveControl Is txtSearch AndAlso (txtSearch.Text) <> "" Then
            e.Cancel = True
            btnHledat_Click(txtSearch, Nothing)
        End If
    End Sub

    Private Sub FDevMsg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowRestore(Me)
    End Sub

    Private Sub FDevMsg_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        WindowSave(Me)
    End Sub

    Private Sub btnHledat_Click(sender As System.Object, e As System.EventArgs) Handles btnHledat.Click, btnHledatDalsi.Click
        Dim iOff0 As Integer = 0
        If sender Is btnHledatDalsi Then iOff0 = dBox.SelectionStart + 1
        If dBox.Text <> "" AndAlso txtSearch.Text <> "" Then
            Dim sText As String = XControls.CutDiacritic(UCase(Me.dBox.Text))
            Dim iOff As Integer = sText.IndexOf(UCase(txtSearch.Text), iOff0)
            If iOff >= 0 Then
                With dBox
                    .SelectionStart = iOff
                    .SelectionLength = txtSearch.Text.Length
                    .ScrollToCaret()
                    .Select()
                End With
            Else
                MsgBox("Zadaný text nebyl nalezen", MsgBoxStyle.Information)
            End If
        End If
    End Sub

End Class
