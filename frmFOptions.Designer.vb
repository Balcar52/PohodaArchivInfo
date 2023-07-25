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
        Me.btnCreateA = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnOpenA = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtCurrentFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonPanel1 = New XControls.ButtonPanel()
        Me.chkAllowImport = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.XSplitter1 = New XControls.XSplitter()
        Me.opnDlgXml = New System.Windows.Forms.OpenFileDialog()
        Me.opnMdbDlg = New System.Windows.Forms.OpenFileDialog()
        Me.opnSaveNewArchiv = New System.Windows.Forms.SaveFileDialog()
        Me.gbImport.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.FgF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ButtonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbImport
        '
        Me.gbImport.Controls.Add(Me.Panel9)
        Me.gbImport.Controls.Add(Me.Panel8)
        Me.gbImport.Controls.Add(Me.Panel4)
        Me.gbImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbImport.Enabled = False
        Me.gbImport.Location = New System.Drawing.Point(0, 298)
        Me.gbImport.Name = "gbImport"
        Me.gbImport.Size = New System.Drawing.Size(764, 79)
        Me.gbImport.TabIndex = 5
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
        Me.Panel9.Size = New System.Drawing.Size(758, 21)
        Me.Panel9.TabIndex = 3
        '
        'brnDefaultMdbPassword
        '
        Me.brnDefaultMdbPassword.Dock = System.Windows.Forms.DockStyle.Left
        Me.brnDefaultMdbPassword.Location = New System.Drawing.Point(588, 0)
        Me.brnDefaultMdbPassword.Name = "brnDefaultMdbPassword"
        Me.brnDefaultMdbPassword.Size = New System.Drawing.Size(149, 21)
        Me.brnDefaultMdbPassword.TabIndex = 4
        Me.brnDefaultMdbPassword.Text = "Nastavit výchozí heslo"
        Me.brnDefaultMdbPassword.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(579, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(9, 21)
        Me.Panel11.TabIndex = 3
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
        Me.txtMdbPassword.TabIndex = 0
        Me.txtMdbPassword.Text = "168BF465F0FB19"
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label4.Size = New System.Drawing.Size(179, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Heslo pro přístup do databáze:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(3, 38)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(758, 8)
        Me.Panel8.TabIndex = 2
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
        Me.Panel4.Size = New System.Drawing.Size(758, 21)
        Me.Panel4.TabIndex = 1
        '
        'btnProcessImport
        '
        Me.btnProcessImport.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnProcessImport.Location = New System.Drawing.Point(631, 0)
        Me.btnProcessImport.Name = "btnProcessImport"
        Me.btnProcessImport.Size = New System.Drawing.Size(164, 21)
        Me.btnProcessImport.TabIndex = 4
        Me.btnProcessImport.Text = "Importovat data z databáze"
        Me.btnProcessImport.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(622, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(9, 21)
        Me.Panel6.TabIndex = 5
        '
        'btnSearchMdb
        '
        Me.btnSearchMdb.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSearchMdb.Location = New System.Drawing.Point(588, 0)
        Me.btnSearchMdb.Name = "btnSearchMdb"
        Me.btnSearchMdb.Size = New System.Drawing.Size(34, 21)
        Me.btnSearchMdb.TabIndex = 2
        Me.btnSearchMdb.Text = "..."
        Me.btnSearchMdb.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(579, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(9, 21)
        Me.Panel5.TabIndex = 3
        '
        'txtMdbFile
        '
        Me.txtMdbFile.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtMdbFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtMdbFile.Location = New System.Drawing.Point(179, 0)
        Me.txtMdbFile.MaximumSize = New System.Drawing.Size(400, 4)
        Me.txtMdbFile.Name = "txtMdbFile"
        Me.txtMdbFile.Size = New System.Drawing.Size(400, 21)
        Me.txtMdbFile.TabIndex = 0
        Me.txtMdbFile.Text = "d:\Projekty.Metapol\Data\47471255_2022.mdb"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label2.Size = New System.Drawing.Size(179, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Databáze pro import dat:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel10)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.MinimumSize = New System.Drawing.Size(0, 150)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(764, 292)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data k prohlížení"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.FgF)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 74)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(758, 215)
        Me.Panel10.TabIndex = 3
        '
        'FgF
        '
        Me.FgF.AllowEditing = False
        Me.FgF.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgF.FillStandardContextMenu = False
        Me.FgF.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgF.Location = New System.Drawing.Point(0, 0)
        Me.FgF.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgF.Name = "FgF"
        Me.FgF.Rows.DefaultSize = 20
        Me.FgF.Size = New System.Drawing.Size(758, 215)
        Me.FgF.StyleInfo = resources.GetString("FgF.StyleInfo")
        Me.FgF.TabIndex = 7
        Me.FgF.UseCompatibleTextRendering = False
        Me.FgF.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(3, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(5, 15, 5, 5)
        Me.Label3.Size = New System.Drawing.Size(758, 36)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "seznam databází, která archiv aktuálně obsahuje:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCreateA)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.btnOpenA)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.txtCurrentFile)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(758, 21)
        Me.Panel2.TabIndex = 1
        '
        'btnCreateA
        '
        Me.btnCreateA.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCreateA.Location = New System.Drawing.Point(631, 0)
        Me.btnCreateA.Name = "btnCreateA"
        Me.btnCreateA.Size = New System.Drawing.Size(112, 21)
        Me.btnCreateA.TabIndex = 4
        Me.btnCreateA.Text = "Vytvořit nový"
        Me.btnCreateA.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(622, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(9, 21)
        Me.Panel7.TabIndex = 5
        '
        'btnOpenA
        '
        Me.btnOpenA.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnOpenA.Location = New System.Drawing.Point(588, 0)
        Me.btnOpenA.Name = "btnOpenA"
        Me.btnOpenA.Size = New System.Drawing.Size(34, 21)
        Me.btnOpenA.TabIndex = 2
        Me.btnOpenA.Text = "..."
        Me.btnOpenA.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(579, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(9, 21)
        Me.Panel3.TabIndex = 3
        '
        'txtCurrentFile
        '
        Me.txtCurrentFile.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtCurrentFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentFile.Location = New System.Drawing.Point(179, 0)
        Me.txtCurrentFile.MaximumSize = New System.Drawing.Size(400, 4)
        Me.txtCurrentFile.Name = "txtCurrentFile"
        Me.txtCurrentFile.Size = New System.Drawing.Size(400, 21)
        Me.txtCurrentFile.TabIndex = 0
        Me.txtCurrentFile.Text = "d:\Projekty.Metapol\Data\ArchivData.xml"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label1.Size = New System.Drawing.Size(179, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Aktivní soubor dat k prohlížení:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonPanel1
        '
        Me.ButtonPanel1.AutoButtonSpaceControl = Me.ButtonPanel1
        Me.ButtonPanel1.Controls.Add(Me.chkAllowImport)
        Me.ButtonPanel1.Controls.Add(Me.btnClose)
        Me.ButtonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonPanel1.Location = New System.Drawing.Point(0, 377)
        Me.ButtonPanel1.Name = "ButtonPanel1"
        Me.ButtonPanel1.Padding = New System.Windows.Forms.Padding(9, 8, 9, 13)
        Me.ButtonPanel1.PaddingAutomaticCoef = New System.Drawing.SizeF(0.2!, 0.08!)
        Me.ButtonPanel1.Size = New System.Drawing.Size(764, 44)
        Me.ButtonPanel1.TabIndex = 6
        '
        'chkAllowImport
        '
        Me.chkAllowImport.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkAllowImport.Location = New System.Drawing.Point(9, 8)
        Me.chkAllowImport.Name = "chkAllowImport"
        Me.chkAllowImport.Size = New System.Drawing.Size(328, 23)
        Me.chkAllowImport.TabIndex = 6
        Me.chkAllowImport.Text = "Povolit import roční databáze do archivu"
        Me.chkAllowImport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.Location = New System.Drawing.Point(656, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Zavřít"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'XSplitter1
        '
        Me.XSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.XSplitter1.Location = New System.Drawing.Point(0, 292)
        Me.XSplitter1.Name = "XSplitter1"
        Me.XSplitter1.Size = New System.Drawing.Size(764, 6)
        Me.XSplitter1.TabIndex = 7
        Me.XSplitter1.TabStop = False
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
        'FOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 421)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.XSplitter1)
        Me.Controls.Add(Me.gbImport)
        Me.Controls.Add(Me.ButtonPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(650, 450)
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
    Friend WithEvents txtCurrentFile As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonPanel1 As ButtonPanel
    Friend WithEvents btnClose As Button
    Friend WithEvents XSplitter1 As XSplitter
    Friend WithEvents opnDlgXml As OpenFileDialog
    Friend WithEvents opnMdbDlg As OpenFileDialog
    Friend WithEvents opnSaveNewArchiv As SaveFileDialog
    Friend WithEvents chkAllowImport As CheckBox
End Class
