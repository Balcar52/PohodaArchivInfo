<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MForm3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MForm3))
        Me.poConn = New System.Data.OleDb.OleDbConnection()
        Me.tbcMain = New XControls.XTabControl()
        Me.pgNab = New System.Windows.Forms.TabPage()
        Me.pnNab = New System.Windows.Forms.Panel()
        Me.FgN = New XForms.XC1Flexgrid()
        Me.pgObjPrij = New System.Windows.Forms.TabPage()
        Me.pnObjP = New System.Windows.Forms.Panel()
        Me.FgOP = New XForms.XC1Flexgrid()
        Me.pgFaktVyd = New System.Windows.Forms.TabPage()
        Me.pnVydFakt = New System.Windows.Forms.Panel()
        Me.FgFV = New XForms.XC1Flexgrid()
        Me.pgObjVyd = New System.Windows.Forms.TabPage()
        Me.pnObjV = New System.Windows.Forms.Panel()
        Me.FgOV = New XForms.XC1Flexgrid()
        Me.pgFaktPrij = New System.Windows.Forms.TabPage()
        Me.pnFgP = New System.Windows.Forms.Panel()
        Me.FgFP = New XForms.XC1Flexgrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tp1 = New System.Windows.Forms.ToolStrip()
        Me.tpClose = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblArchiveFile = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblArchiveFileTimeSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SpringPanel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblVer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ActionList0 = New ActionListLib.ActionList(Me.components)
        Me.m_popup1 = New ActionListLib.Menu(Me.components)
        Me.m_znovunacist_data = New ActionListLib.Menu(Me.components)
        Me.m_delimiter1 = New ActionListLib.Menu(Me.components)
        Me.m_searchtext = New ActionListLib.Menu(Me.components)
        Me.m_searchtextnext = New ActionListLib.Menu(Me.components)
        Me.m_delimiter2 = New ActionListLib.Menu(Me.components)
        Me.m_rozbalit_vse = New ActionListLib.Menu(Me.components)
        Me.m_sbalit_vse = New ActionListLib.Menu(Me.components)
        Me.m_sbalitrozbalit_polozku_na_radku = New ActionListLib.Menu(Me.components)
        Me.m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_ = New ActionListLib.Menu(Me.components)
        Me.m_delimiter3 = New ActionListLib.Menu(Me.components)
        Me.m_najit_vlevo = New ActionListLib.Menu(Me.components)
        Me.m_najit_vpravo = New ActionListLib.Menu(Me.components)
        Me.m_prejit_na_dalsi_nalezeby_radek = New ActionListLib.Menu(Me.components)
        Me.m_delimiter4 = New ActionListLib.Menu(Me.components)
        Me.m_cols = New ActionListLib.Menu(Me.components)
        Me.m_colwidths = New ActionListLib.Menu(Me.components)
        Me.a_searchtext = New ActionListLib.Action(Me.components)
        Me.a_searchtextnext = New ActionListLib.Action(Me.components)
        Me.a_najit_vlevo = New ActionListLib.Action(Me.components)
        Me.a_najit_vpravo = New ActionListLib.Action(Me.components)
        Me.a_prejit_na_dalsi_nalezeby_radek = New ActionListLib.Action(Me.components)
        Me.a_prejit_na_predchozi_nalezeny_radek = New ActionListLib.Action(Me.components)
        Me.a_rozbalit_vse = New ActionListLib.Action(Me.components)
        Me.a_sbalit_vse = New ActionListLib.Action(Me.components)
        Me.a_sbalitrozbalit_polozku_na_radku = New ActionListLib.Action(Me.components)
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_ = New ActionListLib.Action(Me.components)
        Me.a_znovunacist_data = New ActionListLib.Action(Me.components)
        Me.a_excel = New ActionListLib.Action(Me.components)
        Me.a_close = New ActionListLib.Action(Me.components)
        Me.a_cols = New ActionListLib.Action(Me.components)
        Me.a_colwidths = New ActionListLib.Action(Me.components)
        Me.m_excel = New ActionListLib.Menu(Me.components)
        Me.m_close = New ActionListLib.Menu(Me.components)
        Me.m_sprava_aplikace = New ActionListLib.Menu(Me.components)
        Me.a_sprava_aplikace = New ActionListLib.Action(Me.components)
        Me.m_o_aplikaci = New ActionListLib.Menu(Me.components)
        Me.a_o_aplikaci = New ActionListLib.Action(Me.components)
        Me.m_statistika_polozek_v_databazi = New ActionListLib.Menu(Me.components)
        Me.a_statistika_polozek_v_databazi = New ActionListLib.Action(Me.components)
        Me.m_automaticky_upravovat_sirku_sloupce_textu = New ActionListLib.Menu(Me.components)
        Me.a_automaticky_upravovat_sirku_sloupce_textu = New ActionListLib.Action(Me.components)
        Me.m_prejit_na_predchozi_nalezeny_radek = New ActionListLib.Menu(Me.components)
        Me.m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_ = New ActionListLib.Menu(Me.components)
        Me.a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_ = New ActionListLib.Action(Me.components)
        Me.ActionListConn = New ActionListLib.ActionListConn(Me.components)
        Me.m_main = New ActionListLib.Menu(Me.components)
        Me.m_file = New ActionListLib.Menu(Me.components)
        Me.m_edit = New ActionListLib.Menu(Me.components)
        Me.m_view = New ActionListLib.Menu(Me.components)
        Me.m_tools = New ActionListLib.Menu(Me.components)
        Me.m_nastaveni = New ActionListLib.Menu(Me.components)
        Me.m_window = New ActionListLib.Menu(Me.components)
        Me.m_help = New ActionListLib.Menu(Me.components)
        Me.a_nastaveni = New ActionListLib.Action(Me.components)
        Me.m_logika_vyhledavani_v_tabulce = New ActionListLib.Menu(Me.components)
        Me.a_logika_vyhledavani_v_tabulce = New ActionListLib.Action(Me.components)
        Me.tbcMain.SuspendLayout()
        Me.pgNab.SuspendLayout()
        Me.pnNab.SuspendLayout()
        CType(Me.FgN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgObjPrij.SuspendLayout()
        Me.pnObjP.SuspendLayout()
        CType(Me.FgOP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgFaktVyd.SuspendLayout()
        Me.pnVydFakt.SuspendLayout()
        CType(Me.FgFV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgObjVyd.SuspendLayout()
        Me.pnObjV.SuspendLayout()
        CType(Me.FgOV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgFaktPrij.SuspendLayout()
        Me.pnFgP.SuspendLayout()
        CType(Me.FgFP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.tp1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ActionList0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'poConn
        '
        Me.poConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1}"
        '
        'tbcMain
        '
        Me.tbcMain.Controls.Add(Me.pgNab)
        Me.tbcMain.Controls.Add(Me.pgObjPrij)
        Me.tbcMain.Controls.Add(Me.pgFaktVyd)
        Me.tbcMain.Controls.Add(Me.pgObjVyd)
        Me.tbcMain.Controls.Add(Me.pgFaktPrij)
        Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tbcMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tbcMain.Location = New System.Drawing.Point(0, 41)
        Me.tbcMain.Name = "tbcMain"
        Me.tbcMain.SelectedIndex = 0
        Me.tbcMain.Size = New System.Drawing.Size(990, 498)
        Me.tbcMain.TabIndex = 1
        '
        'pgNab
        '
        Me.pgNab.Controls.Add(Me.pnNab)
        Me.pgNab.Location = New System.Drawing.Point(4, 23)
        Me.pgNab.Name = "pgNab"
        Me.pgNab.Padding = New System.Windows.Forms.Padding(3)
        Me.pgNab.Size = New System.Drawing.Size(982, 471)
        Me.pgNab.TabIndex = 1
        Me.pgNab.Text = "Archiv vydaných nabídek"
        Me.pgNab.UseVisualStyleBackColor = True
        '
        'pnNab
        '
        Me.pnNab.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnNab.Controls.Add(Me.FgN)
        Me.pnNab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnNab.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnNab.Location = New System.Drawing.Point(3, 3)
        Me.pnNab.Name = "pnNab"
        Me.pnNab.Size = New System.Drawing.Size(976, 465)
        Me.pnNab.TabIndex = 8
        '
        'FgN
        '
        Me.FgN.AllowEditing = False
        Me.FgN.BackColor = System.Drawing.Color.LightBlue
        Me.FgN.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgN.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.FgN.FillStandardContextMenu = False
        Me.FgN.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.FgN.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgN.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgN.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgN.Location = New System.Drawing.Point(0, 0)
        Me.FgN.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgN.Name = "FgN"
        Me.ActionList0.SetPopupMenu(Me.FgN, Me.m_popup1)
        Me.FgN.Rows.DefaultSize = 20
        Me.FgN.ShowCursor = True
        Me.FgN.Size = New System.Drawing.Size(976, 465)
        Me.FgN.StyleInfo = resources.GetString("FgN.StyleInfo")
        Me.FgN.TabIndex = 7
        Me.FgN.Tree.Column = 1
        Me.FgN.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgN.UseCompatibleTextRendering = False
        Me.FgN.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'pgObjPrij
        '
        Me.pgObjPrij.Controls.Add(Me.pnObjP)
        Me.pgObjPrij.Location = New System.Drawing.Point(4, 23)
        Me.pgObjPrij.Name = "pgObjPrij"
        Me.pgObjPrij.Padding = New System.Windows.Forms.Padding(3)
        Me.pgObjPrij.Size = New System.Drawing.Size(982, 471)
        Me.pgObjPrij.TabIndex = 0
        Me.pgObjPrij.Text = "Archiv přijatých objednávek"
        Me.pgObjPrij.UseVisualStyleBackColor = True
        '
        'pnObjP
        '
        Me.pnObjP.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnObjP.Controls.Add(Me.FgOP)
        Me.pnObjP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnObjP.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnObjP.Location = New System.Drawing.Point(3, 3)
        Me.pnObjP.Name = "pnObjP"
        Me.pnObjP.Size = New System.Drawing.Size(976, 465)
        Me.pnObjP.TabIndex = 7
        '
        'FgOP
        '
        Me.FgOP.AllowEditing = False
        Me.FgOP.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.FgOP.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgOP.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.FgOP.FillStandardContextMenu = False
        Me.FgOP.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.FgOP.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgOP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgOP.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgOP.Location = New System.Drawing.Point(0, 0)
        Me.FgOP.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgOP.Name = "FgOP"
        Me.ActionList0.SetPopupMenu(Me.FgOP, Me.m_popup1)
        Me.FgOP.Rows.DefaultSize = 20
        Me.FgOP.ShowCursor = True
        Me.FgOP.Size = New System.Drawing.Size(976, 465)
        Me.FgOP.StyleInfo = resources.GetString("FgOP.StyleInfo")
        Me.FgOP.TabIndex = 6
        Me.FgOP.Tree.Column = 1
        Me.FgOP.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgOP.UseCompatibleTextRendering = False
        Me.FgOP.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'pgFaktVyd
        '
        Me.pgFaktVyd.Controls.Add(Me.pnVydFakt)
        Me.pgFaktVyd.Location = New System.Drawing.Point(4, 23)
        Me.pgFaktVyd.Name = "pgFaktVyd"
        Me.pgFaktVyd.Padding = New System.Windows.Forms.Padding(3)
        Me.pgFaktVyd.Size = New System.Drawing.Size(982, 471)
        Me.pgFaktVyd.TabIndex = 2
        Me.pgFaktVyd.Text = "Archiv vydaných faktur"
        Me.pgFaktVyd.UseVisualStyleBackColor = True
        '
        'pnVydFakt
        '
        Me.pnVydFakt.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnVydFakt.Controls.Add(Me.FgFV)
        Me.pnVydFakt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnVydFakt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnVydFakt.Location = New System.Drawing.Point(3, 3)
        Me.pnVydFakt.Name = "pnVydFakt"
        Me.pnVydFakt.Size = New System.Drawing.Size(976, 465)
        Me.pnVydFakt.TabIndex = 9
        '
        'FgFV
        '
        Me.FgFV.AllowEditing = False
        Me.FgFV.BackColor = System.Drawing.Color.Magenta
        Me.FgFV.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgFV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgFV.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.FgFV.FillStandardContextMenu = False
        Me.FgFV.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.FgFV.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgFV.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgFV.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgFV.Location = New System.Drawing.Point(0, 0)
        Me.FgFV.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgFV.Name = "FgFV"
        Me.ActionList0.SetPopupMenu(Me.FgFV, Me.m_popup1)
        Me.FgFV.Rows.DefaultSize = 20
        Me.FgFV.ShowCursor = True
        Me.FgFV.Size = New System.Drawing.Size(976, 465)
        Me.FgFV.StyleInfo = resources.GetString("FgFV.StyleInfo")
        Me.FgFV.TabIndex = 7
        Me.FgFV.Tree.Column = 1
        Me.FgFV.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgFV.UseCompatibleTextRendering = False
        Me.FgFV.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'pgObjVyd
        '
        Me.pgObjVyd.Controls.Add(Me.pnObjV)
        Me.pgObjVyd.Location = New System.Drawing.Point(4, 23)
        Me.pgObjVyd.Name = "pgObjVyd"
        Me.pgObjVyd.Padding = New System.Windows.Forms.Padding(3)
        Me.pgObjVyd.Size = New System.Drawing.Size(982, 471)
        Me.pgObjVyd.TabIndex = 4
        Me.pgObjVyd.Text = "Archiv vydaných objednávek"
        Me.pgObjVyd.UseVisualStyleBackColor = True
        '
        'pnObjV
        '
        Me.pnObjV.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnObjV.Controls.Add(Me.FgOV)
        Me.pnObjV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnObjV.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnObjV.Location = New System.Drawing.Point(3, 3)
        Me.pnObjV.Name = "pnObjV"
        Me.pnObjV.Size = New System.Drawing.Size(976, 465)
        Me.pnObjV.TabIndex = 11
        '
        'FgOV
        '
        Me.FgOV.AllowEditing = False
        Me.FgOV.BackColor = System.Drawing.Color.Wheat
        Me.FgOV.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgOV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgOV.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.FgOV.FillStandardContextMenu = False
        Me.FgOV.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.FgOV.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgOV.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgOV.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgOV.Location = New System.Drawing.Point(0, 0)
        Me.FgOV.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgOV.Name = "FgOV"
        Me.ActionList0.SetPopupMenu(Me.FgOV, Me.m_popup1)
        Me.FgOV.Rows.DefaultSize = 20
        Me.FgOV.ShowCursor = True
        Me.FgOV.Size = New System.Drawing.Size(976, 465)
        Me.FgOV.StyleInfo = resources.GetString("FgOV.StyleInfo")
        Me.FgOV.TabIndex = 7
        Me.FgOV.Tree.Column = 1
        Me.FgOV.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgOV.UseCompatibleTextRendering = False
        Me.FgOV.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'pgFaktPrij
        '
        Me.pgFaktPrij.Controls.Add(Me.pnFgP)
        Me.pgFaktPrij.Location = New System.Drawing.Point(4, 23)
        Me.pgFaktPrij.Name = "pgFaktPrij"
        Me.pgFaktPrij.Padding = New System.Windows.Forms.Padding(3)
        Me.pgFaktPrij.Size = New System.Drawing.Size(982, 471)
        Me.pgFaktPrij.TabIndex = 3
        Me.pgFaktPrij.Text = "Archiv přijatých faktur"
        Me.pgFaktPrij.UseVisualStyleBackColor = True
        '
        'pnFgP
        '
        Me.pnFgP.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnFgP.Controls.Add(Me.FgFP)
        Me.pnFgP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnFgP.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnFgP.Location = New System.Drawing.Point(3, 3)
        Me.pnFgP.Name = "pnFgP"
        Me.pnFgP.Size = New System.Drawing.Size(976, 465)
        Me.pnFgP.TabIndex = 10
        '
        'FgFP
        '
        Me.FgFP.AllowEditing = False
        Me.FgFP.BackColor = System.Drawing.Color.Wheat
        Me.FgFP.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgFP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgFP.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.FgFP.FillStandardContextMenu = False
        Me.FgFP.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.FgFP.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgFP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgFP.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgFP.Location = New System.Drawing.Point(0, 0)
        Me.FgFP.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgFP.Name = "FgFP"
        Me.ActionList0.SetPopupMenu(Me.FgFP, Me.m_popup1)
        Me.FgFP.Rows.DefaultSize = 20
        Me.FgFP.ShowCursor = True
        Me.FgFP.Size = New System.Drawing.Size(976, 465)
        Me.FgFP.StyleInfo = resources.GetString("FgFP.StyleInfo")
        Me.FgFP.TabIndex = 7
        Me.FgFP.Tree.Column = 1
        Me.FgFP.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgFP.UseCompatibleTextRendering = False
        Me.FgFP.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbcMain)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 539)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip2)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.tp1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(990, 41)
        Me.Panel2.TabIndex = 4
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton6, Me.ToolStripButton5, Me.ToolStripButton12, Me.ToolStripButton13, Me.ToolStripButton7, Me.ToolStripButton10, Me.ToolStripButton9, Me.ToolStripButton8, Me.ToolStripButton11})
        Me.ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip2.Location = New System.Drawing.Point(191, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(624, 41)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip1"
        '
        'ToolStripButton3
        '
        Me.ActionList0.SetAction(Me.ToolStripButton3, Me.a_searchtext)
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(46, 38)
        Me.ToolStripButton3.Text = "Hledat"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton3.ToolTipText = "&Hledat text"
        '
        'ToolStripButton4
        '
        Me.ActionList0.SetAction(Me.ToolStripButton4, Me.a_searchtextnext)
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(50, 38)
        Me.ToolStripButton4.Text = "Hl.další"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton4.ToolTipText = "Vyhledat další výskyt zadaného textového řetězce"
        '
        'ToolStripButton6
        '
        Me.ActionList0.SetAction(Me.ToolStripButton6, Me.a_najit_vlevo)
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(40, 38)
        Me.ToolStripButton6.Text = "Vlevo"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton6.ToolTipText = "Najít firmu na záložce vpravo"
        '
        'ToolStripButton5
        '
        Me.ActionList0.SetAction(Me.ToolStripButton5, Me.a_najit_vpravo)
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(48, 38)
        Me.ToolStripButton5.Text = "Vpravo"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton5.ToolTipText = "Najít firmu na záložce vlevo"
        '
        'ToolStripButton12
        '
        Me.ActionList0.SetAction(Me.ToolStripButton12, Me.a_prejit_na_dalsi_nalezeby_radek)
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(36, 38)
        Me.ToolStripButton12.Text = "Další"
        Me.ToolStripButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton12.ToolTipText = "Přejít na následující řádek, nalezený pomocí hromadného vyhledávání"
        '
        'ToolStripButton13
        '
        Me.ActionList0.SetAction(Me.ToolStripButton13, Me.a_prejit_na_predchozi_nalezeny_radek)
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(63, 38)
        Me.ToolStripButton13.Text = "Předchozí"
        Me.ToolStripButton13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton13.ToolTipText = "Přejít na předchozí řádek, nalezený pomocí hromadného vyhledávání"
        '
        'ToolStripButton7
        '
        Me.ActionList0.SetAction(Me.ToolStripButton7, Me.a_rozbalit_vse)
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(53, 38)
        Me.ToolStripButton7.Text = "Rozbalit"
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton7.ToolTipText = "Rozbalit všechny položky"
        '
        'ToolStripButton10
        '
        Me.ActionList0.SetAction(Me.ToolStripButton10, Me.a_sbalit_vse)
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(40, 38)
        Me.ToolStripButton10.Text = "Sbalit"
        Me.ToolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton10.ToolTipText = "Sbalit všechny položky"
        '
        'ToolStripButton9
        '
        Me.ActionList0.SetAction(Me.ToolStripButton9, Me.a_sbalitrozbalit_polozku_na_radku)
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(71, 38)
        Me.ToolStripButton9.Text = "Sb./r. řádek"
        Me.ToolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton9.ToolTipText = "Sbalit/rozbalit položku na aktuálním řádku"
        '
        'ToolStripButton8
        '
        Me.ActionList0.SetAction(Me.ToolStripButton8, Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_)
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(71, 38)
        Me.ToolStripButton8.Text = "Sb./r. firmu"
        Me.ToolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton8.ToolTipText = "Sbalit/rozbalit všechny položky firmy na aktuálním řádku"
        '
        'ToolStripButton11
        '
        Me.ActionList0.SetAction(Me.ToolStripButton11, Me.a_sbalitrozbalit_polozku_na_radku)
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(71, 38)
        Me.ToolStripButton11.Text = "Sb./r. řádek"
        Me.ToolStripButton11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton11.ToolTipText = "Sbalit/rozbalit položku na aktuálním řádku"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton1})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(71, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(120, 41)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ActionList0.SetAction(Me.ToolStripButton2, Me.a_znovunacist_data)
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(54, 38)
        Me.ToolStripButton2.Text = "Obnovit"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton2.ToolTipText = "Znovunačíst data"
        '
        'ToolStripButton1
        '
        Me.ActionList0.SetAction(Me.ToolStripButton1, Me.a_excel)
        Me.ToolStripButton1.Enabled = False
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(38, 38)
        Me.ToolStripButton1.Text = "&Excel"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.ToolTipText = "Export do MS Excel"
        '
        'tp1
        '
        Me.tp1.AutoSize = False
        Me.tp1.Dock = System.Windows.Forms.DockStyle.Left
        Me.tp1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tpClose})
        Me.tp1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tp1.Location = New System.Drawing.Point(0, 0)
        Me.tp1.Name = "tp1"
        Me.tp1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tp1.Size = New System.Drawing.Size(71, 41)
        Me.tp1.TabIndex = 2
        Me.tp1.Text = "ToolStrip1"
        '
        'tpClose
        '
        Me.ActionList0.SetAction(Me.tpClose, Me.a_close)
        Me.tpClose.Image = CType(resources.GetObject("tpClose.Image"), System.Drawing.Image)
        Me.tpClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tpClose.Name = "tpClose"
        Me.tpClose.Size = New System.Drawing.Size(41, 38)
        Me.tpClose.Text = "&Zavřít"
        Me.tpClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tpClose.ToolTipText = "&Zavřít"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblArchiveFile, Me.lblArchiveFileTimeSize, Me.SpringPanel, Me.ToolStripStatusLabel2, Me.lblVer})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(990, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "aktuální soubor archivu:"
        '
        'lblArchiveFile
        '
        Me.lblArchiveFile.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblArchiveFile.Name = "lblArchiveFile"
        Me.lblArchiveFile.Size = New System.Drawing.Size(19, 17)
        Me.lblArchiveFile.Text = "    "
        '
        'lblArchiveFileTimeSize
        '
        Me.lblArchiveFileTimeSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblArchiveFileTimeSize.Name = "lblArchiveFileTimeSize"
        Me.lblArchiveFileTimeSize.Size = New System.Drawing.Size(19, 17)
        Me.lblArchiveFileTimeSize.Text = "    "
        '
        'SpringPanel
        '
        Me.SpringPanel.Name = "SpringPanel"
        Me.SpringPanel.Size = New System.Drawing.Size(741, 17)
        Me.SpringPanel.Spring = True
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(75, 17)
        Me.ToolStripStatusLabel2.Text = "verze aplikace:"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVer
        '
        Me.lblVer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(0, 17)
        '
        'ActionList0
        '
        Me.ActionListConn.SetActionListConn(Me.ActionList0, Me)
        Me.ActionList0.DisplayMenuMismatchSetAction = False
        Me.ActionList0.ID = "202306182317.99774"
        Me.ActionList0.MenuStyle = ActionListLib.ActionList.MenuStyles.[Default]
        Me.ActionList0.Redraw = True
        Me.ActionList0.ShowDynamicItemsOnDebug = False
        Me.ActionList0.WindowDynamicMenuMergeNode = 810
        '
        'm_popup1
        '
        Me.m_popup1.MenuList.Add(Me.m_znovunacist_data)
        Me.m_popup1.MenuList.Add(Me.m_delimiter1)
        Me.m_popup1.MenuList.Add(Me.m_searchtext)
        Me.m_popup1.MenuList.Add(Me.m_searchtextnext)
        Me.m_popup1.MenuList.Add(Me.m_delimiter2)
        Me.m_popup1.MenuList.Add(Me.m_rozbalit_vse)
        Me.m_popup1.MenuList.Add(Me.m_sbalit_vse)
        Me.m_popup1.MenuList.Add(Me.m_sbalitrozbalit_polozku_na_radku)
        Me.m_popup1.MenuList.Add(Me.m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_)
        Me.m_popup1.MenuList.Add(Me.m_delimiter3)
        Me.m_popup1.MenuList.Add(Me.m_najit_vlevo)
        Me.m_popup1.MenuList.Add(Me.m_najit_vpravo)
        Me.m_popup1.MenuList.Add(Me.m_prejit_na_dalsi_nalezeby_radek)
        Me.m_popup1.MenuList.Add(Me.m_delimiter4)
        Me.m_popup1.MenuList.Add(Me.m_cols)
        Me.m_popup1.MenuList.Add(Me.m_colwidths)
        Me.m_popup1.MenuType = ActionListLib.Menu.MenuTypes.PopupMenu
        Me.m_popup1.Name = "m_popup1"
        Me.m_popup1.Parent = Me.ActionList0
        Me.m_popup1.Text = "  (popupmenu)"
        '
        'm_znovunacist_data
        '
        Me.ActionList0.SetAction(Me.m_znovunacist_data, Me.a_znovunacist_data)
        Me.m_znovunacist_data.Name = "m_znovunacist_data"
        Me.m_znovunacist_data.Parent = Me.ActionList0
        Me.m_znovunacist_data.Text = Nothing
        '
        'm_delimiter1
        '
        Me.m_delimiter1.MenuType = ActionListLib.Menu.MenuTypes.Delimiter
        Me.m_delimiter1.Name = "m_delimiter1"
        Me.m_delimiter1.Parent = Me.ActionList0
        Me.m_delimiter1.Text = "  (delimiter)"
        '
        'm_searchtext
        '
        Me.ActionList0.SetAction(Me.m_searchtext, Me.a_searchtext)
        Me.m_searchtext.Name = "m_searchtext"
        Me.m_searchtext.Parent = Me.ActionList0
        '
        'm_searchtextnext
        '
        Me.ActionList0.SetAction(Me.m_searchtextnext, Me.a_searchtextnext)
        Me.m_searchtextnext.Name = "m_searchtextnext"
        Me.m_searchtextnext.Parent = Me.ActionList0
        '
        'm_delimiter2
        '
        Me.m_delimiter2.MenuType = ActionListLib.Menu.MenuTypes.Delimiter
        Me.m_delimiter2.Name = "m_delimiter2"
        Me.m_delimiter2.Parent = Me.ActionList0
        Me.m_delimiter2.Text = "  (delimiter)"
        '
        'm_rozbalit_vse
        '
        Me.ActionList0.SetAction(Me.m_rozbalit_vse, Me.a_rozbalit_vse)
        Me.m_rozbalit_vse.Name = "m_rozbalit_vse"
        Me.m_rozbalit_vse.Parent = Me.ActionList0
        Me.m_rozbalit_vse.Text = Nothing
        '
        'm_sbalit_vse
        '
        Me.ActionList0.SetAction(Me.m_sbalit_vse, Me.a_sbalit_vse)
        Me.m_sbalit_vse.Name = "m_sbalit_vse"
        Me.m_sbalit_vse.Parent = Me.ActionList0
        Me.m_sbalit_vse.Text = Nothing
        '
        'm_sbalitrozbalit_polozku_na_radku
        '
        Me.ActionList0.SetAction(Me.m_sbalitrozbalit_polozku_na_radku, Me.a_sbalitrozbalit_polozku_na_radku)
        Me.m_sbalitrozbalit_polozku_na_radku.Name = "m_sbalitrozbalit_polozku_na_radku"
        Me.m_sbalitrozbalit_polozku_na_radku.Parent = Me.ActionList0
        Me.m_sbalitrozbalit_polozku_na_radku.Text = Nothing
        '
        'm_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_
        '
        Me.ActionList0.SetAction(Me.m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_, Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_)
        Me.m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Name = "m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_"
        Me.m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Parent = Me.ActionList0
        Me.m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Text = Nothing
        '
        'm_delimiter3
        '
        Me.m_delimiter3.MenuType = ActionListLib.Menu.MenuTypes.Delimiter
        Me.m_delimiter3.Name = "m_delimiter3"
        Me.m_delimiter3.Parent = Me.ActionList0
        Me.m_delimiter3.Text = "  (delimiter)"
        '
        'm_najit_vlevo
        '
        Me.ActionList0.SetAction(Me.m_najit_vlevo, Me.a_najit_vlevo)
        Me.m_najit_vlevo.Name = "m_najit_vlevo"
        Me.m_najit_vlevo.Parent = Me.ActionList0
        Me.m_najit_vlevo.Text = Nothing
        '
        'm_najit_vpravo
        '
        Me.ActionList0.SetAction(Me.m_najit_vpravo, Me.a_najit_vpravo)
        Me.m_najit_vpravo.Name = "m_najit_vpravo"
        Me.m_najit_vpravo.Parent = Me.ActionList0
        Me.m_najit_vpravo.Text = Nothing
        '
        'm_prejit_na_dalsi_nalezeby_radek
        '
        Me.ActionList0.SetAction(Me.m_prejit_na_dalsi_nalezeby_radek, Me.a_prejit_na_dalsi_nalezeby_radek)
        Me.m_prejit_na_dalsi_nalezeby_radek.Name = "m_prejit_na_dalsi_nalezeby_radek"
        Me.m_prejit_na_dalsi_nalezeby_radek.Parent = Me.ActionList0
        Me.m_prejit_na_dalsi_nalezeby_radek.Text = Nothing
        '
        'm_delimiter4
        '
        Me.m_delimiter4.MenuType = ActionListLib.Menu.MenuTypes.Delimiter
        Me.m_delimiter4.Name = "m_delimiter4"
        Me.m_delimiter4.Parent = Me.ActionList0
        Me.m_delimiter4.Text = "  (delimiter)"
        '
        'm_cols
        '
        Me.ActionList0.SetAction(Me.m_cols, Me.a_cols)
        Me.m_cols.Name = "m_cols"
        Me.m_cols.Parent = Me.ActionList0
        '
        'm_colwidths
        '
        Me.ActionList0.SetAction(Me.m_colwidths, Me.a_colwidths)
        Me.m_colwidths.Name = "m_colwidths"
        Me.m_colwidths.Parent = Me.ActionList0
        '
        'a_searchtext
        '
        Me.a_searchtext.AltText = "Hledat"
        Me.a_searchtext.Image = CType(resources.GetObject("a_searchtext.Image"), System.Drawing.Image)
        Me.a_searchtext.Name = "a_searchtext"
        Me.a_searchtext.Parent = Me.ActionList0
        Me.a_searchtext.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.a_searchtext.Text = "&Hledat text"
        '
        'a_searchtextnext
        '
        Me.a_searchtextnext.AltText = "Hl.další"
        Me.a_searchtextnext.Image = CType(resources.GetObject("a_searchtextnext.Image"), System.Drawing.Image)
        Me.a_searchtextnext.Name = "a_searchtextnext"
        Me.a_searchtextnext.Parent = Me.ActionList0
        Me.a_searchtextnext.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftF
        Me.a_searchtextnext.Text = "&Znovu hledat text"
        Me.a_searchtextnext.TipText = "Vyhledat další výskyt zadaného textového řetězce"
        '
        'a_najit_vlevo
        '
        Me.a_najit_vlevo.AltText = "Vlevo"
        Me.a_najit_vlevo.Image = CType(resources.GetObject("a_najit_vlevo.Image"), System.Drawing.Image)
        Me.a_najit_vlevo.Name = "a_najit_vlevo"
        Me.a_najit_vlevo.Parent = Me.ActionList0
        Me.a_najit_vlevo.Text = "Najít vlevo"
        Me.a_najit_vlevo.TipText = "Najít firmu na záložce vpravo"
        '
        'a_najit_vpravo
        '
        Me.a_najit_vpravo.AltText = "Vpravo"
        Me.a_najit_vpravo.Image = CType(resources.GetObject("a_najit_vpravo.Image"), System.Drawing.Image)
        Me.a_najit_vpravo.Name = "a_najit_vpravo"
        Me.a_najit_vpravo.Parent = Me.ActionList0
        Me.a_najit_vpravo.Text = "Najít vpravo"
        Me.a_najit_vpravo.TipText = "Najít firmu na záložce vlevo"
        '
        'a_prejit_na_dalsi_nalezeby_radek
        '
        Me.a_prejit_na_dalsi_nalezeby_radek.AltText = "Další"
        Me.a_prejit_na_dalsi_nalezeby_radek.Image = CType(resources.GetObject("a_prejit_na_dalsi_nalezeby_radek.Image"), System.Drawing.Image)
        Me.a_prejit_na_dalsi_nalezeby_radek.Name = "a_prejit_na_dalsi_nalezeby_radek"
        Me.a_prejit_na_dalsi_nalezeby_radek.Parent = Me.ActionList0
        Me.a_prejit_na_dalsi_nalezeby_radek.Text = "Přejít na další nalezený řádek"
        Me.a_prejit_na_dalsi_nalezeby_radek.TipText = "Přejít na následující řádek, nalezený pomocí hromadného vyhledávání"
        '
        'a_prejit_na_predchozi_nalezeny_radek
        '
        Me.a_prejit_na_predchozi_nalezeny_radek.AltText = "Předchozí"
        Me.a_prejit_na_predchozi_nalezeny_radek.Image = CType(resources.GetObject("a_prejit_na_predchozi_nalezeny_radek.Image"), System.Drawing.Image)
        Me.a_prejit_na_predchozi_nalezeny_radek.Name = "a_prejit_na_predchozi_nalezeny_radek"
        Me.a_prejit_na_predchozi_nalezeny_radek.Parent = Me.ActionList0
        Me.a_prejit_na_predchozi_nalezeny_radek.Text = "Přejít na předchozí nalezený řádek"
        Me.a_prejit_na_predchozi_nalezeny_radek.TipText = "Přejít na předchozí řádek, nalezený pomocí hromadného vyhledávání"
        '
        'a_rozbalit_vse
        '
        Me.a_rozbalit_vse.AltText = "Rozbalit"
        Me.a_rozbalit_vse.Image = CType(resources.GetObject("a_rozbalit_vse.Image"), System.Drawing.Image)
        Me.a_rozbalit_vse.Name = "a_rozbalit_vse"
        Me.a_rozbalit_vse.Parent = Me.ActionList0
        Me.a_rozbalit_vse.Text = "Rozbalit vše (Ctrl +)"
        Me.a_rozbalit_vse.TipText = "Rozbalit všechny položky"
        '
        'a_sbalit_vse
        '
        Me.a_sbalit_vse.AltText = "Sbalit"
        Me.a_sbalit_vse.Image = CType(resources.GetObject("a_sbalit_vse.Image"), System.Drawing.Image)
        Me.a_sbalit_vse.Name = "a_sbalit_vse"
        Me.a_sbalit_vse.Parent = Me.ActionList0
        Me.a_sbalit_vse.Text = "Sbalit vše (Ctrl -)"
        Me.a_sbalit_vse.TipText = "Sbalit všechny položky"
        '
        'a_sbalitrozbalit_polozku_na_radku
        '
        Me.a_sbalitrozbalit_polozku_na_radku.AltText = "Sb./r. řádek"
        Me.a_sbalitrozbalit_polozku_na_radku.Image = CType(resources.GetObject("a_sbalitrozbalit_polozku_na_radku.Image"), System.Drawing.Image)
        Me.a_sbalitrozbalit_polozku_na_radku.Name = "a_sbalitrozbalit_polozku_na_radku"
        Me.a_sbalitrozbalit_polozku_na_radku.Parent = Me.ActionList0
        Me.a_sbalitrozbalit_polozku_na_radku.Text = "Sbalit/rozbalit položku na řádku (Enter)"
        Me.a_sbalitrozbalit_polozku_na_radku.TipText = "Sbalit/rozbalit položku na aktuálním řádku"
        '
        'a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_
        '
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.AltText = "Sb./r. firmu"
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Image = CType(resources.GetObject("a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Image"), System.Drawing.Image)
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Name = "a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_"
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Parent = Me.ActionList0
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Text = "Sbalit/rozbalit všechny položky firmy (Shift+Enter)"
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.TipText = "Sbalit/rozbalit všechny položky firmy na aktuálním řádku"
        '
        'a_znovunacist_data
        '
        Me.a_znovunacist_data.AltText = "Obnovit"
        Me.a_znovunacist_data.Image = CType(resources.GetObject("a_znovunacist_data.Image"), System.Drawing.Image)
        Me.a_znovunacist_data.Name = "a_znovunacist_data"
        Me.a_znovunacist_data.Parent = Me.ActionList0
        Me.a_znovunacist_data.Text = "Znovunačíst data"
        '
        'a_excel
        '
        Me.a_excel.Enabled = False
        Me.a_excel.Image = CType(resources.GetObject("a_excel.Image"), System.Drawing.Image)
        Me.a_excel.Name = "a_excel"
        Me.a_excel.Parent = Me.ActionList0
        Me.a_excel.Text = "&Excel"
        Me.a_excel.TipText = "Export do MS Excel"
        '
        'a_close
        '
        Me.a_close.Image = CType(resources.GetObject("a_close.Image"), System.Drawing.Image)
        Me.a_close.Name = "a_close"
        Me.a_close.Parent = Me.ActionList0
        Me.a_close.Shortcut = System.Windows.Forms.Shortcut.AltF4
        Me.a_close.Text = "&Zavřít"
        '
        'a_cols
        '
        Me.a_cols.Image = CType(resources.GetObject("a_cols.Image"), System.Drawing.Image)
        Me.a_cols.Name = "a_cols"
        Me.a_cols.Parent = Me.ActionList0
        Me.a_cols.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.a_cols.Text = "Sloupce &tabulky"
        Me.a_cols.TipText = "Vybrat zobrazované sloupce tabulky"
        '
        'a_colwidths
        '
        Me.a_colwidths.Image = CType(resources.GetObject("a_colwidths.Image"), System.Drawing.Image)
        Me.a_colwidths.Name = "a_colwidths"
        Me.a_colwidths.Parent = Me.ActionList0
        Me.a_colwidths.Shortcut = System.Windows.Forms.Shortcut.CtrlW
        Me.a_colwidths.Text = "Upravit šířky &sloupců"
        '
        'm_excel
        '
        Me.ActionList0.SetAction(Me.m_excel, Me.a_excel)
        Me.m_excel.MergeNode = 189
        Me.m_excel.Name = "m_excel"
        Me.m_excel.Parent = Me.ActionList0
        '
        'm_close
        '
        Me.ActionList0.SetAction(Me.m_close, Me.a_close)
        Me.m_close.MergeNode = 199
        Me.m_close.Name = "m_close"
        Me.m_close.Parent = Me.ActionList0
        '
        'm_sprava_aplikace
        '
        Me.ActionList0.SetAction(Me.m_sprava_aplikace, Me.a_sprava_aplikace)
        Me.m_sprava_aplikace.Name = "m_sprava_aplikace"
        Me.m_sprava_aplikace.Parent = Me.ActionList0
        Me.m_sprava_aplikace.Text = Nothing
        '
        'a_sprava_aplikace
        '
        Me.a_sprava_aplikace.AltText = "Správa aplik."
        Me.a_sprava_aplikace.Image = CType(resources.GetObject("a_sprava_aplikace.Image"), System.Drawing.Image)
        Me.a_sprava_aplikace.Name = "a_sprava_aplikace"
        Me.a_sprava_aplikace.Parent = Me.ActionList0
        Me.a_sprava_aplikace.Text = "Nastavení aplikace a správa dat"
        '
        'm_o_aplikaci
        '
        Me.ActionList0.SetAction(Me.m_o_aplikaci, Me.a_o_aplikaci)
        Me.m_o_aplikaci.Name = "m_o_aplikaci"
        Me.m_o_aplikaci.Parent = Me.ActionList0
        Me.m_o_aplikaci.Text = Nothing
        '
        'a_o_aplikaci
        '
        Me.a_o_aplikaci.AltText = "O aplik."
        Me.a_o_aplikaci.Name = "a_o_aplikaci"
        Me.a_o_aplikaci.Parent = Me.ActionList0
        Me.a_o_aplikaci.Text = "O aplikaci"
        '
        'm_statistika_polozek_v_databazi
        '
        Me.ActionList0.SetAction(Me.m_statistika_polozek_v_databazi, Me.a_statistika_polozek_v_databazi)
        Me.m_statistika_polozek_v_databazi.Name = "m_statistika_polozek_v_databazi"
        Me.m_statistika_polozek_v_databazi.Parent = Me.ActionList0
        Me.m_statistika_polozek_v_databazi.Text = Nothing
        '
        'a_statistika_polozek_v_databazi
        '
        Me.a_statistika_polozek_v_databazi.AltText = "Stat. polož. v datab."
        Me.a_statistika_polozek_v_databazi.Name = "a_statistika_polozek_v_databazi"
        Me.a_statistika_polozek_v_databazi.Parent = Me.ActionList0
        Me.a_statistika_polozek_v_databazi.Text = "Statistika položek v databázi"
        '
        'm_automaticky_upravovat_sirku_sloupce_textu
        '
        Me.ActionList0.SetAction(Me.m_automaticky_upravovat_sirku_sloupce_textu, Me.a_automaticky_upravovat_sirku_sloupce_textu)
        Me.m_automaticky_upravovat_sirku_sloupce_textu.Name = "m_automaticky_upravovat_sirku_sloupce_textu"
        Me.m_automaticky_upravovat_sirku_sloupce_textu.Parent = Me.ActionList0
        Me.m_automaticky_upravovat_sirku_sloupce_textu.Text = Nothing
        '
        'a_automaticky_upravovat_sirku_sloupce_textu
        '
        Me.a_automaticky_upravovat_sirku_sloupce_textu.AltText = "Autom. uprav. šířku sloup. textu"
        Me.a_automaticky_upravovat_sirku_sloupce_textu.AutoCheck = True
        Me.a_automaticky_upravovat_sirku_sloupce_textu.Checked = True
        Me.a_automaticky_upravovat_sirku_sloupce_textu.Name = "a_automaticky_upravovat_sirku_sloupce_textu"
        Me.a_automaticky_upravovat_sirku_sloupce_textu.Parent = Me.ActionList0
        Me.a_automaticky_upravovat_sirku_sloupce_textu.Text = "Automaticky upravovat šířku sloupce textu"
        '
        'm_prejit_na_predchozi_nalezeny_radek
        '
        Me.ActionList0.SetAction(Me.m_prejit_na_predchozi_nalezeny_radek, Me.a_prejit_na_predchozi_nalezeny_radek)
        Me.m_prejit_na_predchozi_nalezeny_radek.Name = "m_prejit_na_predchozi_nalezeny_radek"
        Me.m_prejit_na_predchozi_nalezeny_radek.Parent = Me.ActionList0
        Me.m_prejit_na_predchozi_nalezeny_radek.Text = Nothing
        '
        'm_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_
        '
        Me.ActionList0.SetAction(Me.m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_, Me.a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_)
        Me.m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.Name = "m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_"
        Me.m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.Parent = Me.ActionList0
        Me.m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.Text = Nothing
        '
        'a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_
        '
        Me.a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.AltText = "Zpráva vývoj. (soup. změn a úprav této aplik."
        Me.a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.Name = "a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_"
        Me.a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.Parent = Me.ActionList0
        Me.a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.Text = "Zpráva vývojáře (soupis změn a úprav této aplikace)"
        '
        'ActionListConn
        '
        Me.ActionListConn.ActionList = Me.ActionList0
        Me.ActionListConn.ParentControl = Me
        Me.ActionListConn.ParentForm = Me
        '
        'm_main
        '
        Me.m_main.MenuList.Add(Me.m_file)
        Me.m_main.MenuList.Add(Me.m_edit)
        Me.m_main.MenuList.Add(Me.m_view)
        Me.m_main.MenuList.Add(Me.m_tools)
        Me.m_main.MenuList.Add(Me.m_nastaveni)
        Me.m_main.MenuList.Add(Me.m_window)
        Me.m_main.MenuList.Add(Me.m_help)
        Me.m_main.MenuType = ActionListLib.Menu.MenuTypes.MainMenu
        Me.m_main.Name = "m_main"
        Me.m_main.Parent = Me.ActionList0
        Me.m_main.Text = "  (mainmenu)"
        '
        'm_file
        '
        Me.m_file.MenuList.Add(Me.m_excel)
        Me.m_file.MenuList.Add(Me.m_close)
        Me.m_file.MergeNode = 100
        Me.m_file.Name = "m_file"
        Me.m_file.Parent = Me.ActionList0
        Me.m_file.Text = "&Soubor"
        '
        'm_edit
        '
        Me.m_edit.MenuList.Add(Me.m_searchtext)
        Me.m_edit.MenuList.Add(Me.m_searchtextnext)
        Me.m_edit.MergeNode = 200
        Me.m_edit.Name = "m_edit"
        Me.m_edit.Parent = Me.ActionList0
        Me.m_edit.Text = "Úprav&y"
        '
        'm_view
        '
        Me.m_view.MenuList.Add(Me.m_znovunacist_data)
        Me.m_view.MenuList.Add(Me.m_delimiter3)
        Me.m_view.MenuList.Add(Me.m_sbalit_vse)
        Me.m_view.MenuList.Add(Me.m_rozbalit_vse)
        Me.m_view.MenuList.Add(Me.m_sbalitrozbalit_polozku_na_radku)
        Me.m_view.MenuList.Add(Me.m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_)
        Me.m_view.MenuList.Add(Me.m_delimiter2)
        Me.m_view.MenuList.Add(Me.m_najit_vpravo)
        Me.m_view.MenuList.Add(Me.m_najit_vlevo)
        Me.m_view.MenuList.Add(Me.m_prejit_na_dalsi_nalezeby_radek)
        Me.m_view.MenuList.Add(Me.m_prejit_na_predchozi_nalezeny_radek)
        Me.m_view.MenuList.Add(Me.m_automaticky_upravovat_sirku_sloupce_textu)
        Me.m_view.MergeNode = 300
        Me.m_view.Name = "m_view"
        Me.m_view.Parent = Me.ActionList0
        Me.m_view.Text = "&Zobrazení"
        '
        'm_tools
        '
        Me.m_tools.MenuList.Add(Me.m_statistika_polozek_v_databazi)
        Me.m_tools.MergeNode = 400
        Me.m_tools.Name = "m_tools"
        Me.m_tools.Parent = Me.ActionList0
        Me.m_tools.Text = "&Nástroje"
        '
        'm_nastaveni
        '
        Me.m_nastaveni.MenuList.Add(Me.m_sprava_aplikace)
        Me.m_nastaveni.MergeNode = 700
        Me.m_nastaveni.Name = "m_nastaveni"
        Me.m_nastaveni.Parent = Me.ActionList0
        Me.m_nastaveni.Text = "Nas&tavení"
        '
        'm_window
        '
        Me.m_window.MergeNode = 800
        Me.m_window.Name = "m_window"
        Me.m_window.Parent = Me.ActionList0
        Me.m_window.Text = "&Okno"
        Me.m_window.Visible = False
        '
        'm_help
        '
        Me.m_help.MenuList.Add(Me.m_logika_vyhledavani_v_tabulce)
        Me.m_help.MenuList.Add(Me.m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_)
        Me.m_help.MenuList.Add(Me.m_o_aplikaci)
        Me.m_help.MergeNode = 900
        Me.m_help.Name = "m_help"
        Me.m_help.Parent = Me.ActionList0
        Me.m_help.Text = "&Nápověda"
        '
        'a_nastaveni
        '
        Me.a_nastaveni.AltText = "Nast."
        Me.a_nastaveni.Name = "a_nastaveni"
        Me.a_nastaveni.Parent = Me.ActionList0
        Me.a_nastaveni.Text = "Nastavení"
        '
        'm_logika_vyhledavani_v_tabulce
        '
        Me.ActionList0.SetAction(Me.m_logika_vyhledavani_v_tabulce, Me.a_logika_vyhledavani_v_tabulce)
        Me.m_logika_vyhledavani_v_tabulce.Name = "m_logika_vyhledavani_v_tabulce"
        Me.m_logika_vyhledavani_v_tabulce.Parent = Me.ActionList0
        Me.m_logika_vyhledavani_v_tabulce.Text = Nothing
        '
        'a_logika_vyhledavani_v_tabulce
        '
        Me.a_logika_vyhledavani_v_tabulce.AltText = "Návod na vyhledávání"
        Me.a_logika_vyhledavani_v_tabulce.Name = "a_logika_vyhledavani_v_tabulce"
        Me.a_logika_vyhledavani_v_tabulce.Parent = Me.ActionList0
        Me.a_logika_vyhledavani_v_tabulce.Text = "Návod na vyhledávání ve formulářích"
        '
        'MForm3
        '
        Me.ActionListConn.SetActionListConn(Me, Me.ActionList0)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 561)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "MForm3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prohlížeč vybraných dat archivu účetnictví Pohoda"
        Me.tbcMain.ResumeLayout(False)
        Me.pgNab.ResumeLayout(False)
        Me.pnNab.ResumeLayout(False)
        CType(Me.FgN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgObjPrij.ResumeLayout(False)
        Me.pnObjP.ResumeLayout(False)
        CType(Me.FgOP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgFaktVyd.ResumeLayout(False)
        Me.pnVydFakt.ResumeLayout(False)
        CType(Me.FgFV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgObjVyd.ResumeLayout(False)
        Me.pnObjV.ResumeLayout(False)
        CType(Me.FgOV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgFaktPrij.ResumeLayout(False)
        Me.pnFgP.ResumeLayout(False)
        CType(Me.FgFP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tp1.ResumeLayout(False)
        Me.tp1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ActionList0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents poConn As OleDb.OleDbConnection
    Friend WithEvents tbcMain As XControls.XTabControl
    Friend WithEvents pgObjPrij As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents FgOP As XC1Flexgrid
    Friend WithEvents ActionList0 As ActionListLib.ActionList
    Friend WithEvents ActionListConn As ActionListLib.ActionListConn
    Friend WithEvents m_main As ActionListLib.Menu
    Friend WithEvents m_file As ActionListLib.Menu
    Friend WithEvents m_excel As ActionListLib.Menu
    Friend WithEvents a_excel As ActionListLib.Action
    Friend WithEvents m_close As ActionListLib.Menu
    Friend WithEvents a_close As ActionListLib.Action
    Friend WithEvents m_edit As ActionListLib.Menu
    Friend WithEvents m_view As ActionListLib.Menu
    Friend WithEvents m_tools As ActionListLib.Menu
    Friend WithEvents m_window As ActionListLib.Menu
    Friend WithEvents m_help As ActionListLib.Menu
    Friend WithEvents m_nastaveni As ActionListLib.Menu
    Friend WithEvents m_sprava_aplikace As ActionListLib.Menu
    Friend WithEvents a_sprava_aplikace As ActionListLib.Action
    Friend WithEvents a_nastaveni As ActionListLib.Action
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblArchiveFile As ToolStripStatusLabel
    Friend WithEvents m_znovunacist_data As ActionListLib.Menu
    Friend WithEvents a_znovunacist_data As ActionListLib.Action
    Friend WithEvents pnObjP As Panel
    Friend WithEvents m_popup1 As ActionListLib.Menu
    Friend WithEvents m_cols As ActionListLib.Menu
    Friend WithEvents a_cols As ActionListLib.Action
    Friend WithEvents m_colwidths As ActionListLib.Menu
    Friend WithEvents a_colwidths As ActionListLib.Action
    Friend WithEvents m_delimiter1 As ActionListLib.Menu
    Friend WithEvents m_searchtext As ActionListLib.Menu
    Friend WithEvents a_searchtext As ActionListLib.Action
    Friend WithEvents m_searchtextnext As ActionListLib.Menu
    Friend WithEvents a_searchtextnext As ActionListLib.Action
    Friend WithEvents m_delimiter2 As ActionListLib.Menu
    Friend WithEvents m_delimiter3 As ActionListLib.Menu
    Friend WithEvents m_sbalit_vse As ActionListLib.Menu
    Friend WithEvents a_sbalit_vse As ActionListLib.Action
    Friend WithEvents m_rozbalit_vse As ActionListLib.Menu
    Friend WithEvents a_rozbalit_vse As ActionListLib.Action
    Friend WithEvents m_sbalitrozbalit_polozku_na_radku As ActionListLib.Menu
    Friend WithEvents a_sbalitrozbalit_polozku_na_radku As ActionListLib.Action
    Friend WithEvents m_o_aplikaci As ActionListLib.Menu
    Friend WithEvents a_o_aplikaci As ActionListLib.Action
    Friend WithEvents pgNab As TabPage
    Friend WithEvents FgN As XC1Flexgrid
    Friend WithEvents pnNab As Panel
    Friend WithEvents m_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_ As ActionListLib.Menu
    Friend WithEvents a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_ As ActionListLib.Action
    Friend WithEvents pgFaktVyd As TabPage
    Friend WithEvents pnVydFakt As Panel
    Friend WithEvents FgFV As XC1Flexgrid
    Friend WithEvents pgFaktPrij As TabPage
    Friend WithEvents pnFgP As Panel
    Friend WithEvents FgFP As XC1Flexgrid
    Friend WithEvents lblArchiveFileTimeSize As ToolStripStatusLabel
    Friend WithEvents tp1 As ToolStrip
    Friend WithEvents tpClose As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents m_najit_vlevo As ActionListLib.Menu
    Friend WithEvents a_najit_vlevo As ActionListLib.Action
    Friend WithEvents m_najit_vpravo As ActionListLib.Menu
    Friend WithEvents a_najit_vpravo As ActionListLib.Action
    Friend WithEvents m_delimiter4 As ActionListLib.Menu
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripButton10 As ToolStripButton
    Friend WithEvents ToolStripButton9 As ToolStripButton
    Friend WithEvents ToolStripButton8 As ToolStripButton
    Friend WithEvents ToolStripButton11 As ToolStripButton
    Friend WithEvents SpringPanel As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lblVer As ToolStripStatusLabel
    Friend WithEvents m_statistika_polozek_v_databazi As ActionListLib.Menu
    Friend WithEvents a_statistika_polozek_v_databazi As ActionListLib.Action
    Friend WithEvents pgObjVyd As TabPage
    Friend WithEvents pnObjV As Panel
    Friend WithEvents FgOV As XC1Flexgrid
    Friend WithEvents m_automaticky_upravovat_sirku_sloupce_textu As ActionListLib.Menu
    Friend WithEvents a_automaticky_upravovat_sirku_sloupce_textu As ActionListLib.Action
    Friend WithEvents m_prejit_na_dalsi_nalezeby_radek As ActionListLib.Menu
    Friend WithEvents a_prejit_na_dalsi_nalezeby_radek As ActionListLib.Action
    Friend WithEvents ToolStripButton12 As ToolStripButton
    Friend WithEvents ToolStripButton13 As ToolStripButton
    Friend WithEvents a_prejit_na_predchozi_nalezeny_radek As ActionListLib.Action
    Friend WithEvents m_prejit_na_predchozi_nalezeny_radek As ActionListLib.Menu
    Friend WithEvents m_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_ As ActionListLib.Menu
    Friend WithEvents a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_ As ActionListLib.Action
    Friend WithEvents m_logika_vyhledavani_v_tabulce As ActionListLib.Menu
    Friend WithEvents a_logika_vyhledavani_v_tabulce As ActionListLib.Action
End Class
