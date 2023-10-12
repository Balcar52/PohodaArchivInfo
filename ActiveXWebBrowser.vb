Imports System
Imports System.Drawing
Imports System.windows.Forms

Namespace XWebBrowser

    <ToolboxBitmap(GetType(ActiveXWebBrowser), "AXWebBrowser.ActiveXWebBrowser.bmp")> _
    Public Class ActiveXWebBrowser
        Inherits System.Windows.Forms.Panel

        Public Exc As Exception

        Public Enum BrowserNavConstants As Integer
            navNone = &H0
            navOpenInNewWindow = &H1
            navNoHistory = &H2
            navNoReadFromCache = &H4
            navNoWriteToCache = &H8
            navAllowAutosearch = &H10
            navBrowserBar = &H20
            navHyperlink = &H40
            navEnforceRestricted = &H80
            navNewWindowsManaged = &H100
            navUntrustedForDownload = &H200
            navTrustedForActiveX = &H400
            navOpenInNewTab = &H800
            navOpenInBackgroundTab = &H1000
            navKeepWordWheelText = &H2000
            navVirtualTab = &H4000
            navBlockRedirectsXDomain = &H8000
            navOpenNewForegroundTab = &H10000
        End Enum

        Public Enum TargetTypes As Integer
            _None
            _blankLoad      'the link into a new unnamed window
            _parentLoad     'the link into the immediate parent of the document the link is in
            _selfLoad       'the link into the same window the link was clicked in
            _topLoad        'the link into the full body of the current window.
        End Enum

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Wbr.Dock = Windows.Forms.DockStyle.Fill
        End Sub

        ''UserControl overrides dispose to clean up the component list.
        'Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        '    If disposing Then
        '        If Not (components Is Nothing) Then
        '            components.Dispose()
        '        End If
        '    End If
        '    MyBase.Dispose(disposing)
        'End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        'Public WithEvents Wbr As AxSHDocVw.AxWebBrowser
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ActiveXWebBrowser))
            Me.Wbr = New AxSHDocVw.AxWebBrowser
            CType(Me.Wbr, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Wbr
            '
            Me.Wbr.Enabled = True
            Me.Wbr.Location = New System.Drawing.Point(22, 38)
            Me.Wbr.OcxState = CType(resources.GetObject("Wbr.OcxState"), System.Windows.Forms.AxHost.State)
            Me.Wbr.Size = New System.Drawing.Size(352, 250)
            Me.Wbr.TabIndex = 1
            '
            'ActiveXWebBrowser
            '
            Me.Controls.Add(Me.Wbr)
            Me.Name = "ActiveXWebBrowser"
            Me.Size = New System.Drawing.Size(406, 348)
            CType(Me.Wbr, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Function Navigate(ByVal sURL As String, _
                                 Optional ByVal iBrowserNavConstants As BrowserNavConstants = BrowserNavConstants.navNone, _
                                 Optional ByVal iTargetType As TargetTypes = TargetTypes._None, _
                                 Optional ByVal sTargetFrameName As String = "", _
                                 Optional ByVal oPostData As Object = Nothing, _
                                 Optional ByVal oHeaders As Object = Nothing _
                                  ) As Boolean
            Dim oFlags As Object = Nothing
            Dim oTarget As Object = Nothing
            If CStr(sTargetFrameName) <> "" Then
                oTarget = CObj(sTargetFrameName)
            Else
                If iTargetType <> TargetTypes._None Then
                    oTarget = CObj(CStr(iTargetType))
                End If
            End If
            If iBrowserNavConstants <> BrowserNavConstants.navNone Then oFlags = CObj(iBrowserNavConstants)
            Wbr.Tag = Nothing
            Exc = Nothing
            Try
                Wbr.Navigate(CStr(sURL), oFlags, oTarget, oPostData, oHeaders)
            Catch ex As Exception
                Exc = ex
            End Try
            Return Exc Is Nothing
        End Function

        Public Sub HideBrowser()
            Wbr.Parent = Nothing
            Application.DoEvents()
        End Sub

        Public Sub ShowBrowser()
            Wbr.Parent = Me
            Application.DoEvents()
        End Sub

        Public ReadOnly Property BodyPlainText() As String
            Get
                Try
                    Return GetBrowserDocument.body.innerText
                Catch : End Try
                Return ""
            End Get
        End Property

        Public ReadOnly Property BodyHtml() As String
            Get
                Try
                    Return GetBrowserDocument.body.innerHTML
                Catch : End Try
                Return ""
            End Get
        End Property

        Public Function CreateDocument(ByVal sHTMLDoc As String, Optional ByVal bHideBrowser As Boolean = False) As Boolean
            Wbr.Tag = Nothing
            Exc = Nothing
            CreateDocument = False
            If bHideBrowser Then HideBrowser()
            AddHandler Wbr.DocumentComplete, AddressOf wbr_DocumentComplete
            Try
                Me.Wbr.Tag = sHTMLDoc
                ClearBrowserDocument()
                Me.Wbr.Navigate("about:blank")
                For i As Integer = 1 To 300
                    Application.DoEvents()
                    Threading.Thread.Sleep(10)
                    If LCase(CStr(GetBrowserDocument.readyState)).IndexOf("loading") < 0 Then
                        CreateDocument = True
                        Exit Try
                    End If
                Next
            Catch ex As Exception
                Exc = ex
            Finally
                RemoveHandler Wbr.DocumentComplete, AddressOf wbr_DocumentComplete
                Wbr.Tag = Nothing
            End Try
        End Function

        Public Function CreateXMLDocument(ByVal sXMLDoc As String, Optional ByVal bHideBrowser As Boolean = False, Optional ByVal bAutoDelete As Boolean = True) As Boolean
            Wbr.Tag = Nothing
            Exc = Nothing
            CreateXMLDocument = False
            If bHideBrowser Then HideBrowser()
            AddHandler Wbr.DocumentComplete, AddressOf wbr_DocumentComplete
            Dim sTmp As String = IO.Path.ChangeExtension(System.IO.Path.GetTempFileName, ".xml")
            Try
                Me.Wbr.Tag = Nothing
                ClearBrowserDocument()
                Dim oTw As IO.TextWriter = New IO.StreamWriter(sTmp)
                oTw.Write(sXMLDoc)
                oTw.Close()
                'IO.File.WriteAllText(sTmp, sXMLDoc)
                Me.Wbr.Navigate(String.Format("file:///{0}", Replace(sTmp, ":", "|")))
                For i As Integer = 1 To 10
                    Application.DoEvents()
                    If LCase(CStr(GetBrowserDocument.readyState)).IndexOf("loading") < 0 Then
                        CreateXMLDocument = True
                        Exit Try
                    End If
                Next
            Catch ex As Exception
                Exc = ex
            Finally
                RemoveHandler Wbr.DocumentComplete, AddressOf wbr_DocumentComplete
                Wbr.Tag = Nothing
            End Try
            Try
                If bAutoDelete Then IO.File.Delete(sTmp)
            Catch ex As Exception
                iLog.ErrLog(ex)
            End Try
        End Function

        Public Sub Clear()
            ClearBrowserDocument()
            Me.Wbr.Navigate("about:blank")
            Application.DoEvents()
        End Sub

        Public Sub ClearBrowserDocument()
            Try
                Dim doc As mshtml.HTMLDocument = CType(Wbr.Document, mshtml.HTMLDocument)
                Dim doc2 As mshtml.IHTMLDocument2 = CType(CType(Wbr.Document, mshtml.HTMLDocument), mshtml.IHTMLDocument2)
                doc = Nothing
                doc2 = Nothing
            Catch : End Try
        End Sub

        Public ReadOnly Property GetBrowserDocument() As IHTMLDocument2
            Get
                Try
                    Dim doc2 As mshtml.IHTMLDocument2 = CType(CType(Wbr.Document, mshtml.HTMLDocument), mshtml.IHTMLDocument2)
                    Return doc2
                Catch : End Try
                Return Nothing
            End Get
        End Property

        Private Sub wbr_DocumentComplete(ByVal sender As Object, ByVal e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent)
            Try
                If TypeOf (Me.Wbr.Tag) Is String Then
                    GetBrowserDocument.write(CStr(Me.Wbr.Tag))
                End If
            Catch ex As Exception
                Exc = ex
            End Try
        End Sub

    End Class

End Namespace
