<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FOptions))
        Me.gbImport = New System.Windows.Forms.GroupBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.brnDefaultMdbPassword = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtMdbPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnProcessImport = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnSearchMdb = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtMdbFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.FgF = New XForms.XC1Flexgrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtCurrentFile = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnOpenA = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCreateA = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.ButtonPanel1 = New XControls.ButtonPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.chkAllowImport = New System.Windows.Forms.CheckBox()
        Me.opnDlgXml = New System.Windows.Forms.OpenFileDialog()
        Me.opnMdbDlg = New System.Windows.Forms.OpenFileDialog()
        Me.opnSaveNewArchiv = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbcMain = New XControls.XTabControl()
        Me.pgVolby = New System.Windows.Forms.TabPage()
        Me.pnVolby = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gbExcel = New System.Windows.Forms.GroupBox()
        Me.FlexPanel1 = New XControls.FlexPanel()
        Me.txtMSExcelDir = New System.Windows.Forms.TextBox()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnDefaultExcDir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkSimpleExcel = New System.Windows.Forms.CheckBox()
        Me.gbColors = New XControls.CheckedGroupBox()
        Me.ButtonPanel2 = New XControls.ButtonPanel()
        Me.btnDefaultFgColors = New System.Windows.Forms.Button()
        Me.clrFgFP = New XControls.ColorSettingBox()
        Me.clrFgFV = New XControls.ColorSettingBox()
        Me.clrFgO = New XControls.ColorSettingBox()
        Me.clrFgN = New XControls.ColorSettingBox()
        Me.pgData = New System.Windows.Forms.TabPage()
        Me.pnData = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.gbImport.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.FgF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ButtonPanel1.SuspendLayout()
        Me.tbcMain.SuspendLayout()
        Me.pgVolby.SuspendLayout()
        Me.pnVolby.SuspendLayout()
        Me.gbExcel.SuspendLayout()
        Me.FlexPanel1.SuspendLayout()
        Me.gbColors.SuspendLayout()
        Me.ButtonPanel2.SuspendLayout()
        Me.pgData.SuspendLayout()
        Me.pnData.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbImport
        '
        Me.gbImport.BackColor = System.Drawing.SystemColors.Control
        Me.gbImport.Controls.Add(Me.Panel9)
        Me.gbImport.Controls.Add(Me.Panel8)
        Me.gbImport.Controls.Add(Me.Panel4)
        Me.gbImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbImport.Enabled = False
        Me.gbImport.Location = New System.Drawing.Point(0, 226)
        Me.gbImport.Name = "gbImport"
        Me.gbImport.Size = New System.Drawing.Size(800, 79)
        Me.gbImport.TabIndex = 1
        Me.gbImport.TabStop = False
        Me.gbImport.Text = "Databáze účetnictví Pohoda"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.brnDefaultMdbPassword)
        Me.Panel9.Controls.Add(Me.Panel11)
        Me.Panel9.Controls.Add(Me.txtMdbPassword)
        Me.Panel9.Controls.Add(Me.Label4)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(3, 46)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(794, 21)
        Me.Panel9.TabIndex = 3
        '
        'brnDefaultMdbPassword
        '
        Me.brnDefaultMdbPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.brnDefaultMdbPassword.Location = New System.Drawing.Point(588, 0)
        Me.brnDefaultMdbPassword.Name = "brnDefaultMdbPassword"
        Me.brnDefaultMdbPassword.Size = New System.Drawing.Size(149, 21)
        Me.brnDefaultMdbPassword.TabIndex = 3
        Me.brnDefaultMdbPassword.Text = "Nastavit výchozí heslo"
        Me.brnDefaultMdbPassword.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(579, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(9, 21)
        Me.Panel11.TabIndex = 2
        '
        'txtMdbPassword
        '
        Me.txtMdbPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtMdbPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtMdbPassword.Location = New System.Drawing.Point(179, 0)
        Me.txtMdbPassword.MaximumSize = New System.Drawing.Size(400, 4)
        Me.txtMdbPassword.Name = "txtMdbPassword"
        Me.txtMdbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMdbPassword.Size = New System.Drawing.Size(400, 21)
        Me.txtMdbPassword.TabIndex = 1
        Me.txtMdbPassword.Text = "168BF465F0FB19"
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label4.Size = New System.Drawing.Size(179, 21)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Heslo pro přístup do databáze:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(3, 38)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(794, 8)
        Me.Panel8.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnProcessImport)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.btnSearchMdb)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.txtMdbFile)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 17)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(794, 21)
        Me.Panel4.TabIndex = 1
        '
        'btnProcessImport
        '
        Me.btnProcessImport.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnProcessImport.Location = New System.Drawing.Point(631, 0)
        Me.btnProcessImport.Name = "btnProcessImport"
        Me.btnProcessImport.Size = New System.Drawing.Size(164, 21)
        Me.btnProcessImport.TabIndex = 5
        Me.btnProcessImport.Text = "Importovat data z databáze"
        Me.btnProcessImport.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(622, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(9, 21)
        Me.Panel6.TabIndex = 4
        '
        'btnSearchMdb
        '
        Me.btnSearchMdb.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSearchMdb.Location = New System.Drawing.Point(588, 0)
        Me.btnSearchMdb.Name = "btnSearchMdb"
        Me.btnSearchMdb.Size = New System.Drawing.Size(34, 21)
        Me.btnSearchMdb.TabIndex = 3
        Me.btnSearchMdb.Text = "..."
        Me.btnSearchMdb.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(579, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(9, 21)
        Me.Panel5.TabIndex = 2
        '
        'txtMdbFile
        '
        Me.txtMdbFile.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtMdbFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtMdbFile.Location = New System.Drawing.Point(179, 0)
        Me.txtMdbFile.MaximumSize = New System.Drawing.Size(400, 4)
        Me.txtMdbFile.Name = "txtMdbFile"
        Me.txtMdbFile.Size = New System.Drawing.Size(400, 21)
        Me.txtMdbFile.TabIndex = 1
        Me.txtMdbFile.Text = "d:\Projekty.Metapol\Data\47471255_2022.mdb"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label2.Size = New System.Drawing.Size(179, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Databáze pro import dat:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Panel10)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.MinimumSize = New System.Drawing.Size(0, 150)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 226)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data k prohlížení"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.FgF)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 74)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(794, 149)
        Me.Panel10.TabIndex = 3
        '
        'FgF
        '
        Me.FgF.AllowEditing = False
        Me.FgF.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgF.FillStandardContextMenu = False
        Me.FgF.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgF.Location = New System.Drawing.Point(0, 0)
        Me.FgF.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgF.Name = "FgF"
        Me.FgF.Rows.DefaultSize = 20
        Me.FgF.Size = New System.Drawing.Size(794, 149)
        Me.FgF.StyleInfo = resources.GetString("FgF.StyleInfo")
        Me.FgF.TabIndex = 0
        Me.FgF.UseCompatibleTextRendering = False
        Me.FgF.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(3, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(5, 15, 5, 5)
        Me.Label3.Size = New System.Drawing.Size(794, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "seznam databází, která archiv aktuálně obsahuje:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtCurrentFile)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.btnOpenA)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.btnCreateA)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.btnView)
        Me.Panel2.Controls.Add(Me.Panel12)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(794, 21)
        Me.Panel2.TabIndex = 1
        '
        'txtCurrentFile
        '
        Me.txtCurrentFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCurrentFile.Location = New System.Drawing.Point(179, 0)
        Me.txtCurrentFile.Name = "txtCurrentFile"
        Me.txtCurrentFile.Size = New System.Drawing.Size(381, 21)
        Me.txtCurrentFile.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(560, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(10, 21)
        Me.Panel7.TabIndex = 2
        '
        'btnOpenA
        '
        Me.btnOpenA.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOpenA.Location = New System.Drawing.Point(570, 0)
        Me.btnOpenA.Name = "btnOpenA"
        Me.btnOpenA.Size = New System.Drawing.Size(34, 21)
        Me.btnOpenA.TabIndex = 3
        Me.btnOpenA.Text = "..."
        Me.ToolTip1.SetToolTip(Me.btnOpenA, "Vyhledat soubor archivu")
        Me.btnOpenA.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(604, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(9, 21)
        Me.Panel3.TabIndex = 4
        '
        'btnCreateA
        '
        Me.btnCreateA.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCreateA.Enabled = False
        Me.btnCreateA.Location = New System.Drawing.Point(613, 0)
        Me.btnCreateA.Name = "btnCreateA"
        Me.btnCreateA.Size = New System.Drawing.Size(129, 21)
        Me.btnCreateA.TabIndex = 5
        Me.btnCreateA.Text = "Vymazat, vytvořit nový"
        Me.ToolTip1.SetToolTip(Me.btnCreateA, "Vytvoření nového souboru archivu, resp. vymazání obsahu souboru archivu")
        Me.btnCreateA.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label1.Size = New System.Drawing.Size(179, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Aktivní soubor dat k prohlížení:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(742, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(9, 21)
        Me.Panel1.TabIndex = 6
        '
        'btnView
        '
        Me.btnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnView.Image = Global.PohodaArchivInfo.My.Resources.Resources._026_doc_preview
        Me.btnView.Location = New System.Drawing.Point(751, 0)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(34, 21)
        Me.btnView.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btnView, "Zobrazení zdrojového souboru archivu")
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(785, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(9, 21)
        Me.Panel12.TabIndex = 11
        '
        'ButtonPanel1
        '
        Me.ButtonPanel1.AutoButtonSpaceControl = Me.ButtonPanel1
        Me.ButtonPanel1.Controls.Add(Me.btnOK)
        Me.ButtonPanel1.Controls.Add(Me.btnClose)
        Me.ButtonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonPanel1.Location = New System.Drawing.Point(0, 367)
        Me.ButtonPanel1.Name = "ButtonPanel1"
        Me.ButtonPanel1.Padding = New System.Windows.Forms.Padding(9, 8, 9, 13)
        Me.ButtonPanel1.PaddingAutomaticCoef = New System.Drawing.SizeF(0.2!, 0.08!)
        Me.ButtonPanel1.Size = New System.Drawing.Size(814, 44)
        Me.ButtonPanel1.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(607, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(99, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "Uložit"
        Me.btnOK.UseVisualStyleBackColor = True
        Me.btnOK.Visible = False
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.Location = New System.Drawing.Point(706, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Zavřít"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'chkAllowImport
        '
        Me.chkAllowImport.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkAllowImport.Location = New System.Drawing.Point(10, 3)
        Me.chkAllowImport.Name = "chkAllowImport"
        Me.chkAllowImport.Size = New System.Drawing.Size(328, 24)
        Me.chkAllowImport.TabIndex = 0
        Me.chkAllowImport.Text = "Povolit vytvoření, výmaz a import roční databáze do archivu"
        Me.chkAllowImport.UseVisualStyleBackColor = True
        '
        'opnDlgXml
        '
        Me.opnDlgXml.CheckFileExists = False
        Me.opnDlgXml.Filter = "soubory XML (*.xml)|*.xml|Všechny soubory(*.*)|*.*"";"
        Me.opnDlgXml.Title = "Vyhledání souboru archivu Pohoda"
        '
        'opnMdbDlg
        '
        Me.opnMdbDlg.CheckFileExists = False
        Me.opnMdbDlg.FileName = "*.*"
        Me.opnMdbDlg.Filter = "Databáze MS Access (*.mdb)|*.mdb|Všechny soubory(*.*)|*.*"
        Me.opnMdbDlg.ShowReadOnly = True
        Me.opnMdbDlg.Title = "Vyhledání databáze Pohoda"
        '
        'opnSaveNewArchiv
        '
        Me.opnSaveNewArchiv.OverwritePrompt = False
        '
        'tbcMain
        '
        Me.tbcMain.Controls.Add(Me.pgVolby)
        Me.tbcMain.Controls.Add(Me.pgData)
        Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tbcMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tbcMain.Location = New System.Drawing.Point(0, 0)
        Me.tbcMain.Name = "tbcMain"
        Me.tbcMain.SelectedIndex = 0
        Me.tbcMain.Size = New System.Drawing.Size(814, 367)
        Me.tbcMain.TabIndex = 0
        '
        'pgVolby
        '
        Me.pgVolby.Controls.Add(Me.pnVolby)
        Me.pgVolby.Location = New System.Drawing.Point(4, 22)
        Me.pgVolby.Name = "pgVolby"
        Me.pgVolby.Padding = New System.Windows.Forms.Padding(3)
        Me.pgVolby.Size = New System.Drawing.Size(806, 341)
        Me.pgVolby.TabIndex = 0
        Me.pgVolby.Text = "Vzhled a další nastavení aplikace"
        Me.pgVolby.UseVisualStyleBackColor = True
        '
        'pnVolby
        '
        Me.pnVolby.BackColor = System.Drawing.SystemColors.Control
        Me.pnVolby.Controls.Add(Me.GroupBox2)
        Me.pnVolby.Controls.Add(Me.gbExcel)
        Me.pnVolby.Controls.Add(Me.gbColors)
        Me.pnVolby.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnVolby.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnVolby.Location = New System.Drawing.Point(3, 3)
        Me.pnVolby.Name = "pnVolby"
        Me.pnVolby.Size = New System.Drawing.Size(800, 335)
        Me.pnVolby.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 234)
        Me.GroupBox2.MaximumSize = New System.Drawing.Size(800, 9999)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(20, 3, 10, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(800, 101)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ostatní nastavení"
        '
        'gbExcel
        '
        Me.gbExcel.Controls.Add(Me.FlexPanel1)
        Me.gbExcel.Controls.Add(Me.chkSimpleExcel)
        Me.gbExcel.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbExcel.Location = New System.Drawing.Point(0, 168)
        Me.gbExcel.MaximumSize = New System.Drawing.Size(800, 9999)
        Me.gbExcel.Name = "gbExcel"
        Me.gbExcel.Padding = New System.Windows.Forms.Padding(20, 3, 10, 3)
        Me.gbExcel.Size = New System.Drawing.Size(800, 66)
        Me.gbExcel.TabIndex = 1
        Me.gbExcel.TabStop = False
        Me.gbExcel.Text = "Export do MS Excel"
        '
        'FlexPanel1
        '
        Me.FlexPanel1.Controls.Add(Me.txtMSExcelDir)
        Me.FlexPanel1.Controls.Add(Me.Panel14)
        Me.FlexPanel1.Controls.Add(Me.btnDefaultExcDir)
        Me.FlexPanel1.Controls.Add(Me.Label5)
        Me.FlexPanel1.DependingPanels = Nothing
        Me.FlexPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlexPanel1.Location = New System.Drawing.Point(20, 34)
        Me.FlexPanel1.Name = "FlexPanel1"
        Me.FlexPanel1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.FlexPanel1.Processing = False
        Me.FlexPanel1.Size = New System.Drawing.Size(770, 26)
        Me.FlexPanel1.TabIndex = 1
        '
        'txtMSExcelDir
        '
        Me.txtMSExcelDir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMSExcelDir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtMSExcelDir.Location = New System.Drawing.Point(167, 2)
        Me.txtMSExcelDir.Name = "txtMSExcelDir"
        Me.txtMSExcelDir.Size = New System.Drawing.Size(564, 21)
        Me.txtMSExcelDir.TabIndex = 1
        '
        'Panel14
        '
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel14.Location = New System.Drawing.Point(731, 2)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(8, 22)
        Me.Panel14.TabIndex = 2
        '
        'btnDefaultExcDir
        '
        Me.btnDefaultExcDir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDefaultExcDir.Location = New System.Drawing.Point(739, 2)
        Me.btnDefaultExcDir.Name = "btnDefaultExcDir"
        Me.btnDefaultExcDir.Size = New System.Drawing.Size(31, 22)
        Me.btnDefaultExcDir.TabIndex = 7
        Me.btnDefaultExcDir.Text = "..."
        Me.btnDefaultExcDir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Location = New System.Drawing.Point(0, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label5.Size = New System.Drawing.Size(167, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Umístění exportu do MS Excel:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkSimpleExcel
        '
        Me.chkSimpleExcel.AutoSize = True
        Me.chkSimpleExcel.Checked = True
        Me.chkSimpleExcel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSimpleExcel.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkSimpleExcel.Location = New System.Drawing.Point(20, 17)
        Me.chkSimpleExcel.Name = "chkSimpleExcel"
        Me.chkSimpleExcel.Size = New System.Drawing.Size(770, 17)
        Me.chkSimpleExcel.TabIndex = 0
        Me.chkSimpleExcel.Text = "Zjednodušený export do MS Excel"
        Me.chkSimpleExcel.UseVisualStyleBackColor = True
        '
        'gbColors
        '
        Me.gbColors.Caption = "Barevné rozlišení záložek"
        Me.gbColors.Checked = True
        Me.gbColors.Controls.Add(Me.ButtonPanel2)
        Me.gbColors.Controls.Add(Me.clrFgFP)
        Me.gbColors.Controls.Add(Me.clrFgFV)
        Me.gbColors.Controls.Add(Me.clrFgO)
        Me.gbColors.Controls.Add(Me.clrFgN)
        Me.gbColors.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbColors.Location = New System.Drawing.Point(0, 0)
        Me.gbColors.MaximumSize = New System.Drawing.Size(450, 9999)
        Me.gbColors.Name = "gbColors"
        Me.gbColors.Size = New System.Drawing.Size(450, 168)
        Me.gbColors.TabIndex = 0
        Me.gbColors.TabStop = False
        '
        'ButtonPanel2
        '
        Me.ButtonPanel2.AutoButtonSpaceControl = Me.ButtonPanel2
        Me.ButtonPanel2.Controls.Add(Me.btnDefaultFgColors)
        Me.ButtonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonPanel2.Location = New System.Drawing.Point(3, 125)
        Me.ButtonPanel2.Name = "ButtonPanel2"
        Me.ButtonPanel2.Padding = New System.Windows.Forms.Padding(8, 8, 8, 9)
        Me.ButtonPanel2.PaddingAutomaticCoef = New System.Drawing.SizeF(0.2!, 0.08!)
        Me.ButtonPanel2.ShowSizingGrip = False
        Me.ButtonPanel2.Size = New System.Drawing.Size(444, 40)
        Me.ButtonPanel2.TabIndex = 5
        '
        'btnDefaultFgColors
        '
        Me.btnDefaultFgColors.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDefaultFgColors.Location = New System.Drawing.Point(355, 8)
        Me.btnDefaultFgColors.Name = "btnDefaultFgColors"
        Me.btnDefaultFgColors.Size = New System.Drawing.Size(81, 23)
        Me.btnDefaultFgColors.TabIndex = 6
        Me.btnDefaultFgColors.Text = "Výchozí"
        Me.btnDefaultFgColors.UseVisualStyleBackColor = True
        '
        'clrFgFP
        '
        Me.clrFgFP.BackColorSetting = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.clrFgFP.Caption = "Faktury přijaté :"
        Me.clrFgFP.Dock = System.Windows.Forms.DockStyle.Top
        Me.clrFgFP.ForeColorSetting = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.clrFgFP.Location = New System.Drawing.Point(3, 92)
        Me.clrFgFP.LogicalName = "Vydané nabídky"
        Me.clrFgFP.Name = "clrFgFP"
        Me.clrFgFP.Padding = New System.Windows.Forms.Padding(3)
        Me.clrFgFP.Size = New System.Drawing.Size(444, 25)
        Me.clrFgFP.TabIndex = 4
        '
        'clrFgFV
        '
        Me.clrFgFV.BackColorSetting = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.clrFgFV.Caption = "Faktury vydané :"
        Me.clrFgFV.Dock = System.Windows.Forms.DockStyle.Top
        Me.clrFgFV.ForeColorSetting = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.clrFgFV.Location = New System.Drawing.Point(3, 67)
        Me.clrFgFV.LogicalName = "Vydané nabídky"
        Me.clrFgFV.Name = "clrFgFV"
        Me.clrFgFV.Padding = New System.Windows.Forms.Padding(3)
        Me.clrFgFV.Size = New System.Drawing.Size(444, 25)
        Me.clrFgFV.TabIndex = 3
        '
        'clrFgO
        '
        Me.clrFgO.BackColorSetting = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.clrFgO.Caption = "Přijaté objednávky :"
        Me.clrFgO.Dock = System.Windows.Forms.DockStyle.Top
        Me.clrFgO.ForeColorSetting = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.clrFgO.Location = New System.Drawing.Point(3, 42)
        Me.clrFgO.LogicalName = "Vydané nabídky"
        Me.clrFgO.Name = "clrFgO"
        Me.clrFgO.Padding = New System.Windows.Forms.Padding(3)
        Me.clrFgO.Size = New System.Drawing.Size(444, 25)
        Me.clrFgO.TabIndex = 2
        '
        'clrFgN
        '
        Me.clrFgN.BackColorSetting = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.clrFgN.Caption = "Vydané nabídky :"
        Me.clrFgN.Dock = System.Windows.Forms.DockStyle.Top
        Me.clrFgN.ForeColorSetting = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.clrFgN.Location = New System.Drawing.Point(3, 17)
        Me.clrFgN.LogicalName = "Vydané nabídky"
        Me.clrFgN.Name = "clrFgN"
        Me.clrFgN.Padding = New System.Windows.Forms.Padding(3)
        Me.clrFgN.Size = New System.Drawing.Size(444, 25)
        Me.clrFgN.TabIndex = 1
        '
        'pgData
        '
        Me.pgData.Controls.Add(Me.pnData)
        Me.pgData.Location = New System.Drawing.Point(4, 22)
        Me.pgData.Name = "pgData"
        Me.pgData.Padding = New System.Windows.Forms.Padding(3)
        Me.pgData.Size = New System.Drawing.Size(806, 341)
        Me.pgData.TabIndex = 1
        Me.pgData.Text = "Správa dat"
        Me.pgData.UseVisualStyleBackColor = True
        '
        'pnData
        '
        Me.pnData.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnData.Controls.Add(Me.GroupBox1)
        Me.pnData.Controls.Add(Me.gbImport)
        Me.pnData.Controls.Add(Me.Panel13)
        Me.pnData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnData.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnData.Location = New System.Drawing.Point(3, 3)
        Me.pnData.Name = "pnData"
        Me.pnData.Size = New System.Drawing.Size(800, 335)
        Me.pnData.TabIndex = 8
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.SystemColors.Control
        Me.Panel13.Controls.Add(Me.chkAllowImport)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel13.Location = New System.Drawing.Point(0, 305)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.Panel13.Size = New System.Drawing.Size(800, 30)
        Me.Panel13.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "202-delete.gif")
        '
        'FOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 411)
        Me.Controls.Add(Me.tbcMain)
        Me.Controls.Add(Me.ButtonPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(830, 450)
        Me.Name = "FOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nastavení aplikace a správa dat"
        Me.gbImport.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.FgF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ButtonPanel1.ResumeLayout(False)
        Me.tbcMain.ResumeLayout(False)
        Me.pgVolby.ResumeLayout(False)
        Me.pnVolby.ResumeLayout(False)
        Me.gbExcel.ResumeLayout(False)
        Me.gbExcel.PerformLayout()
        Me.FlexPanel1.ResumeLayout(False)
        Me.FlexPanel1.PerformLayout()
        Me.gbColors.ResumeLayout(False)
        Me.gbColors.PerformLayout()
        Me.ButtonPanel2.ResumeLayout(False)
        Me.pgData.ResumeLayout(False)
        Me.pnData.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbImport As GroupBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents brnDefaultMdbPassword As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents txtMdbPassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnProcessImport As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnSearchMdb As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtMdbFile As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents FgF As XC1Flexgrid
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCreateA As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnOpenA As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonPanel1 As ButtonPanel
    Friend WithEvents btnClose As Button
    Friend WithEvents opnDlgXml As OpenFileDialog
    Friend WithEvents opnMdbDlg As OpenFileDialog
    Friend WithEvents opnSaveNewArchiv As SaveFileDialog
    Friend WithEvents chkAllowImport As CheckBox
    Friend WithEvents txtCurrentFile As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnView As Button
    Friend WithEvents Panel12 As Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents tbcMain As XTabControl
    Friend WithEvents pgData As TabPage
    Friend WithEvents pnData As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents pgVolby As TabPage
    Friend WithEvents pnVolby As Panel
    Friend WithEvents gbExcel As GroupBox
    Friend WithEvents chkSimpleExcel As CheckBox
    Friend WithEvents gbColors As CheckedGroupBox
    Friend WithEvents clrFgFP As ColorSettingBox
    Friend WithEvents clrFgFV As ColorSettingBox
    Friend WithEvents clrFgO As ColorSettingBox
    Friend WithEvents clrFgN As ColorSettingBox
    Friend WithEvents btnOK As Button
    Friend WithEvents FlexPanel1 As FlexPanel
    Friend WithEvents txtMSExcelDir As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ButtonPanel2 As ButtonPanel
    Friend WithEvents btnDefaultFgColors As Button
    Friend WithEvents Panel14 As Panel
    Friend WithEvents btnDefaultExcDir As Button
    Friend WithEvents ImageList1 As ImageList
End Class
