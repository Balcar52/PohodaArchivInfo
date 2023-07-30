Option Strict On

Imports System.Reflection

Public Class FAbout
    Inherits System.Windows.Forms.Form

    Public Shared SpecialInfoText As String = "" ' specialni text do About - pro jednorazove specialni pouziti

    Public Shared Sub Run(oOwner As Form)
        Dim oFrm As New FAbout
        oFrm.Owner = oOwner
        oFrm.ShowDialog()
    End Sub

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pnBott As System.Windows.Forms.Panel
    Friend WithEvents pnTop As System.Windows.Forms.Panel
    Friend WithEvents l0 As System.Windows.Forms.Label
    Friend WithEvents l7 As System.Windows.Forms.Label
    Friend WithEvents l3 As System.Windows.Forms.Label
    Friend WithEvents l1 As System.Windows.Forms.Label
    Friend WithEvents l2 As System.Windows.Forms.Label
    Friend WithEvents l4 As System.Windows.Forms.Label
    Friend WithEvents l5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents l8 As System.Windows.Forms.Label
    Friend WithEvents pnMid As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAutor As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents l6 As Label
    Friend WithEvents l9 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAbout))
        Me.l0 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnBott = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAutor = New System.Windows.Forms.Label()
        Me.pnTop = New System.Windows.Forms.Panel()
        Me.l7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.l9 = New System.Windows.Forms.Label()
        Me.l6 = New System.Windows.Forms.Label()
        Me.l5 = New System.Windows.Forms.Label()
        Me.l4 = New System.Windows.Forms.Label()
        Me.l3 = New System.Windows.Forms.Label()
        Me.l2 = New System.Windows.Forms.Label()
        Me.l1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.l8 = New System.Windows.Forms.Label()
        Me.pnMid = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnBott.SuspendLayout()
        Me.pnTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnMid.SuspendLayout()
        Me.SuspendLayout()
        '
        'l0
        '
        Me.l0.Dock = System.Windows.Forms.DockStyle.Top
        Me.l0.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l0.Location = New System.Drawing.Point(0, 0)
        Me.l0.Name = "l0"
        Me.l0.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.l0.Size = New System.Drawing.Size(330, 43)
        Me.l0.TabIndex = 2
        Me.l0.Text = "XXXXXX"
        Me.l0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(242, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 24)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "OK"
        '
        'pnBott
        '
        Me.pnBott.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnBott.Controls.Add(Me.Label3)
        Me.pnBott.Controls.Add(Me.Label4)
        Me.pnBott.Controls.Add(Me.Label2)
        Me.pnBott.Controls.Add(Me.Label1)
        Me.pnBott.Controls.Add(Me.lblAutor)
        Me.pnBott.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnBott.Location = New System.Drawing.Point(0, 324)
        Me.pnBott.Name = "pnBott"
        Me.pnBott.Size = New System.Drawing.Size(334, 101)
        Me.pnBott.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label2.Location = New System.Drawing.Point(57, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Tag = "www.chaps.cz"
        Me.Label2.Text = "Hartmanice 76, okres Svitavy"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 11)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "vývoj a autorská práva"
        '
        'lblAutor
        '
        Me.lblAutor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAutor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblAutor.Location = New System.Drawing.Point(57, 27)
        Me.lblAutor.Name = "lblAutor"
        Me.lblAutor.Size = New System.Drawing.Size(252, 13)
        Me.lblAutor.TabIndex = 17
        Me.lblAutor.Tag = "www.chaps.cz"
        Me.lblAutor.Text = "Ing. Jiøí Bartùšek"
        '
        'pnTop
        '
        Me.pnTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnTop.Controls.Add(Me.l7)
        Me.pnTop.Controls.Add(Me.Panel3)
        Me.pnTop.Controls.Add(Me.l9)
        Me.pnTop.Controls.Add(Me.l6)
        Me.pnTop.Controls.Add(Me.l5)
        Me.pnTop.Controls.Add(Me.l4)
        Me.pnTop.Controls.Add(Me.l3)
        Me.pnTop.Controls.Add(Me.l2)
        Me.pnTop.Controls.Add(Me.l1)
        Me.pnTop.Controls.Add(Me.l0)
        Me.pnTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnTop.Location = New System.Drawing.Point(0, 0)
        Me.pnTop.Name = "pnTop"
        Me.pnTop.Size = New System.Drawing.Size(334, 251)
        Me.pnTop.TabIndex = 14
        '
        'l7
        '
        Me.l7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.l7.Location = New System.Drawing.Point(0, 196)
        Me.l7.Name = "l7"
        Me.l7.Size = New System.Drawing.Size(330, 51)
        Me.l7.TabIndex = 18
        Me.l7.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
        Me.l7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 186)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(330, 10)
        Me.Panel3.TabIndex = 25
        '
        'l9
        '
        Me.l9.Dock = System.Windows.Forms.DockStyle.Top
        Me.l9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l9.Location = New System.Drawing.Point(0, 164)
        Me.l9.Name = "l9"
        Me.l9.Size = New System.Drawing.Size(330, 22)
        Me.l9.TabIndex = 27
        Me.l9.Text = "xxx"
        Me.l9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.l9.Visible = False
        '
        'l6
        '
        Me.l6.Dock = System.Windows.Forms.DockStyle.Top
        Me.l6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l6.Location = New System.Drawing.Point(0, 142)
        Me.l6.Name = "l6"
        Me.l6.Size = New System.Drawing.Size(330, 22)
        Me.l6.TabIndex = 26
        Me.l6.Text = "xxx"
        Me.l6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'l5
        '
        Me.l5.Dock = System.Windows.Forms.DockStyle.Top
        Me.l5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l5.Location = New System.Drawing.Point(0, 120)
        Me.l5.Name = "l5"
        Me.l5.Size = New System.Drawing.Size(330, 22)
        Me.l5.TabIndex = 23
        Me.l5.Text = "xxx"
        Me.l5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'l4
        '
        Me.l4.Dock = System.Windows.Forms.DockStyle.Top
        Me.l4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l4.Location = New System.Drawing.Point(0, 106)
        Me.l4.Name = "l4"
        Me.l4.Size = New System.Drawing.Size(330, 14)
        Me.l4.TabIndex = 22
        Me.l4.Text = "xxx"
        Me.l4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'l3
        '
        Me.l3.Dock = System.Windows.Forms.DockStyle.Top
        Me.l3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l3.Location = New System.Drawing.Point(0, 92)
        Me.l3.Name = "l3"
        Me.l3.Size = New System.Drawing.Size(330, 14)
        Me.l3.TabIndex = 21
        Me.l3.Text = "xxx"
        Me.l3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'l2
        '
        Me.l2.Dock = System.Windows.Forms.DockStyle.Top
        Me.l2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l2.Location = New System.Drawing.Point(0, 57)
        Me.l2.Name = "l2"
        Me.l2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.l2.Size = New System.Drawing.Size(330, 35)
        Me.l2.TabIndex = 20
        Me.l2.Text = "xxx"
        Me.l2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'l1
        '
        Me.l1.Dock = System.Windows.Forms.DockStyle.Top
        Me.l1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l1.Location = New System.Drawing.Point(0, 43)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(330, 14)
        Me.l1.TabIndex = 19
        Me.l1.Text = "xxx"
        Me.l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.l1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 425)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(334, 51)
        Me.Panel1.TabIndex = 16
        '
        'l8
        '
        Me.l8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.l8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.l8.Location = New System.Drawing.Point(0, -15)
        Me.l8.Name = "l8"
        Me.l8.Padding = New System.Windows.Forms.Padding(10)
        Me.l8.Size = New System.Drawing.Size(330, 84)
        Me.l8.TabIndex = 27
        Me.l8.Text = "xxxxxxxxxxxxxxxxxxxx"
        Me.l8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnMid
        '
        Me.pnMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnMid.Controls.Add(Me.l8)
        Me.pnMid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnMid.Location = New System.Drawing.Point(0, 251)
        Me.pnMid.Name = "pnMid"
        Me.pnMid.Size = New System.Drawing.Size(334, 73)
        Me.pnMid.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "výhradní licence pro provoz"
        '
        'Label4
        '
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(252, 14)
        Me.Label4.TabIndex = 20
        Me.Label4.Tag = ""
        Me.Label4.Text = "Metapol spol. s r.o., Polièka"
        '
        'FAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(334, 476)
        Me.Controls.Add(Me.pnMid)
        Me.Controls.Add(Me.pnTop)
        Me.Controls.Add(Me.pnBott)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(350, 515)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 515)
        Me.Name = "FAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "O aplikaci ..."
        Me.pnBott.ResumeLayout(False)
        Me.pnTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnMid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            Dim asm As Assembly = Assembly.GetExecutingAssembly
            l0.Text = DirectCast(asm.GetCustomAttributes(GetType(AssemblyTitleAttribute), False)(0), AssemblyTitleAttribute).Title
            l1.Text = "" : l1.Visible = False
            l2.Text = Replace(DirectCast(asm.GetCustomAttributes(GetType(AssemblyCopyrightAttribute), False)(0), AssemblyCopyrightAttribute).Copyright, "\n", vbCrLf)
            l2.Cursor = Cursors.Hand
            AddHandler l2.Click, AddressOf pbDPP_Click
            l3.Text = DirectCast(asm.GetCustomAttributes(GetType(AssemblyProductAttribute), False)(0), AssemblyProductAttribute).Product
            l4.Text = GetAssemblyVersion(asm)
            l5.Text = "èas vytvoøení: " & IO.File.GetLastWriteTime(Application.ExecutablePath).ToString("d.M.yyyy H:mm")
            l6.Text = "Aplikace pro zobrazení a údržbu archivu úèetnictví Pohoda"
#If DEBUG Then
            l7.Text = "LADICÍ(DEBUG) VERZE."
#Else
            l7.Text = "Provozní(release) verze."
#End If
            If SpecialInfoText <> "" Then
                l7.Text &= vbCrLf & vbCrLf & SpecialInfoText
            End If
            l8.Text = Replace(DirectCast(asm.GetCustomAttributes(GetType(AssemblyDescriptionAttribute), False)(0), AssemblyDescriptionAttribute).Description, "\n", vbCrLf)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub pbDPP_Click(sender As System.Object, e As System.EventArgs) Handles lblAutor.Click
        If TypeOf (sender) Is Control Then
            With DirectCast(sender, Control)
                If TypeOf (.Tag) Is String AndAlso CStr(.Tag).ToLower.Contains("www.") Then
                    Dim oProc As New Process
                    oProc.StartInfo.FileName = CStr(.Tag)
                    oProc.Start()
                End If
            End With
        End If
    End Sub
End Class
