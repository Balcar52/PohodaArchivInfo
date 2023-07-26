<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MForm))
        Me.poConn = New System.Data.OleDb.OleDbConnection()
        Me.tbcMain = New XControls.XTabControl()
        Me.pgNab = New System.Windows.Forms.TabPage()
        Me.pnNab = New System.Windows.Forms.Panel()
        Me.FgN = New XForms.XC1Flexgrid()
        Me.pgObj = New System.Windows.Forms.TabPage()
        Me.pnObj = New System.Windows.Forms.Panel()
        Me.FgO = New XForms.XC1Flexgrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblArchiveFile = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.m_cols = New ActionListLib.Menu(Me.components)
        Me.m_colwidths = New ActionListLib.Menu(Me.components)
        Me.a_znovunacist_data = New ActionListLib.Action(Me.components)
        Me.a_searchtext = New ActionListLib.Action(Me.components)
        Me.a_searchtextnext = New ActionListLib.Action(Me.components)
        Me.a_rozbalit_vse = New ActionListLib.Action(Me.components)
        Me.a_sbalit_vse = New ActionListLib.Action(Me.components)
        Me.a_sbalitrozbalit_polozku_na_radku = New ActionListLib.Action(Me.components)
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_ = New ActionListLib.Action(Me.components)
        Me.a_cols = New ActionListLib.Action(Me.components)
        Me.a_colwidths = New ActionListLib.Action(Me.components)
        Me.m_excel = New ActionListLib.Menu(Me.components)
        Me.a_excel = New ActionListLib.Action(Me.components)
        Me.m_close = New ActionListLib.Menu(Me.components)
        Me.a_close = New ActionListLib.Action(Me.components)
        Me.m_sprava_aplikace = New ActionListLib.Menu(Me.components)
        Me.a_sprava_aplikace = New ActionListLib.Action(Me.components)
        Me.m_o_aplikaci = New ActionListLib.Menu(Me.components)
        Me.a_o_aplikaci = New ActionListLib.Action(Me.components)
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
        Me.pgFaktVyd = New System.Windows.Forms.TabPage()
        Me.pgPrijFakt = New System.Windows.Forms.TabPage()
        Me.pnVydFakt = New System.Windows.Forms.Panel()
        Me.FgFV = New XForms.XC1Flexgrid()
        Me.pnFgP = New System.Windows.Forms.Panel()
        Me.FgFP = New XForms.XC1Flexgrid()
        Me.lblArchiveFileSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblArchiveFileTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbcMain.SuspendLayout()
        Me.pgNab.SuspendLayout()
        Me.pnNab.SuspendLayout()
        CType(Me.FgN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgObj.SuspendLayout()
        Me.pnObj.SuspendLayout()
        CType(Me.FgO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ActionList0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgFaktVyd.SuspendLayout()
        Me.pgPrijFakt.SuspendLayout()
        Me.pnVydFakt.SuspendLayout()
        CType(Me.FgFV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFgP.SuspendLayout()
        CType(Me.FgFP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'poConn
        '
        Me.poConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1}"
        '
        'tbcMain
        '
        Me.tbcMain.Controls.Add(Me.pgNab)
        Me.tbcMain.Controls.Add(Me.pgObj)
        Me.tbcMain.Controls.Add(Me.pgFaktVyd)
        Me.tbcMain.Controls.Add(Me.pgPrijFakt)
        Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tbcMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tbcMain.Location = New System.Drawing.Point(0, 0)
        Me.tbcMain.Name = "tbcMain"
        Me.tbcMain.SelectedIndex = 0
        Me.tbcMain.Size = New System.Drawing.Size(990, 539)
        Me.tbcMain.TabIndex = 1
        '
        'pgNab
        '
        Me.pgNab.Controls.Add(Me.pnNab)
        Me.pgNab.Location = New System.Drawing.Point(4, 22)
        Me.pgNab.Name = "pgNab"
        Me.pgNab.Padding = New System.Windows.Forms.Padding(3)
        Me.pgNab.Size = New System.Drawing.Size(982, 513)
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
        Me.pnNab.Size = New System.Drawing.Size(976, 507)
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
        Me.FgN.Size = New System.Drawing.Size(976, 507)
        Me.FgN.StyleInfo = resources.GetString("FgN.StyleInfo")
        Me.FgN.TabIndex = 7
        Me.FgN.Tree.Column = 1
        Me.FgN.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgN.UseCompatibleTextRendering = False
        Me.FgN.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'pgObj
        '
        Me.pgObj.Controls.Add(Me.pnObj)
        Me.pgObj.Location = New System.Drawing.Point(4, 22)
        Me.pgObj.Name = "pgObj"
        Me.pgObj.Padding = New System.Windows.Forms.Padding(3)
        Me.pgObj.Size = New System.Drawing.Size(982, 513)
        Me.pgObj.TabIndex = 0
        Me.pgObj.Text = "Archiv přijatých objednávek"
        Me.pgObj.UseVisualStyleBackColor = True
        '
        'pnObj
        '
        Me.pnObj.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnObj.Controls.Add(Me.FgO)
        Me.pnObj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnObj.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnObj.Location = New System.Drawing.Point(3, 3)
        Me.pnObj.Name = "pnObj"
        Me.pnObj.Size = New System.Drawing.Size(976, 507)
        Me.pnObj.TabIndex = 7
        '
        'FgO
        '
        Me.FgO.AllowEditing = False
        Me.FgO.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.FgO.ColumnInfo = "10,1,0,0,0,100,Columns:"
        Me.FgO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FgO.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.FgO.FillStandardContextMenu = False
        Me.FgO.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.FgO.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.FgO.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.FgO.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.FgO.Location = New System.Drawing.Point(0, 0)
        Me.FgO.MinimumSize = New System.Drawing.Size(250, 4)
        Me.FgO.Name = "FgO"
        Me.ActionList0.SetPopupMenu(Me.FgO, Me.m_popup1)
        Me.FgO.Rows.DefaultSize = 20
        Me.FgO.ShowCursor = True
        Me.FgO.Size = New System.Drawing.Size(976, 507)
        Me.FgO.StyleInfo = resources.GetString("FgO.StyleInfo")
        Me.FgO.TabIndex = 6
        Me.FgO.Tree.Column = 1
        Me.FgO.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgO.UseCompatibleTextRendering = False
        Me.FgO.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbcMain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 539)
        Me.Panel1.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblArchiveFile, Me.lblArchiveFileTime, Me.lblArchiveFileSize})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(990, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(134, 17)
        Me.ToolStripStatusLabel1.Text = "aktuální soubor archivu:"
        '
        'lblArchiveFile
        '
        Me.lblArchiveFile.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblArchiveFile.Name = "lblArchiveFile"
        Me.lblArchiveFile.Size = New System.Drawing.Size(19, 17)
        Me.lblArchiveFile.Text = "    "
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
        'a_znovunacist_data
        '
        Me.a_znovunacist_data.AltText = "Znov. data"
        Me.a_znovunacist_data.Image = CType(resources.GetObject("a_znovunacist_data.Image"), System.Drawing.Image)
        Me.a_znovunacist_data.Name = "a_znovunacist_data"
        Me.a_znovunacist_data.Parent = Me.ActionList0
        Me.a_znovunacist_data.Text = "Znovunačíst data"
        '
        'a_searchtext
        '
        Me.a_searchtext.Image = CType(resources.GetObject("a_searchtext.Image"), System.Drawing.Image)
        Me.a_searchtext.Name = "a_searchtext"
        Me.a_searchtext.Parent = Me.ActionList0
        Me.a_searchtext.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.a_searchtext.Text = "&Hledat text"
        '
        'a_searchtextnext
        '
        Me.a_searchtextnext.Image = CType(resources.GetObject("a_searchtextnext.Image"), System.Drawing.Image)
        Me.a_searchtextnext.Name = "a_searchtextnext"
        Me.a_searchtextnext.Parent = Me.ActionList0
        Me.a_searchtextnext.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftF
        Me.a_searchtextnext.Text = "&Znovu hledat text"
        '
        'a_rozbalit_vse
        '
        Me.a_rozbalit_vse.AltText = "Rozb. vše"
        Me.a_rozbalit_vse.Name = "a_rozbalit_vse"
        Me.a_rozbalit_vse.Parent = Me.ActionList0
        Me.a_rozbalit_vse.Text = "Rozbalit vše (Ctrl +)"
        '
        'a_sbalit_vse
        '
        Me.a_sbalit_vse.AltText = "Sbal. vše"
        Me.a_sbalit_vse.Name = "a_sbalit_vse"
        Me.a_sbalit_vse.Parent = Me.ActionList0
        Me.a_sbalit_vse.Text = "Sbalit vše (Ctrl -)"
        '
        'a_sbalitrozbalit_polozku_na_radku
        '
        Me.a_sbalitrozbalit_polozku_na_radku.AltText = "Sbal. polož. na řádku"
        Me.a_sbalitrozbalit_polozku_na_radku.Name = "a_sbalitrozbalit_polozku_na_radku"
        Me.a_sbalitrozbalit_polozku_na_radku.Parent = Me.ActionList0
        Me.a_sbalitrozbalit_polozku_na_radku.Text = "Sbalit/rozbalit položku na řádku (Enter)"
        '
        'a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_
        '
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.AltText = "Sbal. všec. polož. firmy (Shif."
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Name = "a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_"
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Parent = Me.ActionList0
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Text = "Sbalit/rozbalit všechny položky firmy (Shift+Enter)"
        Me.a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Visible = False
        '
        'a_cols
        '
        Me.a_cols.Name = "a_cols"
        Me.a_cols.Parent = Me.ActionList0
        Me.a_cols.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.a_cols.Text = "Sloupce &tabulky"
        '
        'a_colwidths
        '
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
        'a_excel
        '
        Me.a_excel.Enabled = False
        Me.a_excel.Name = "a_excel"
        Me.a_excel.Parent = Me.ActionList0
        Me.a_excel.Text = "&Excel"
        Me.a_excel.Visible = False
        '
        'm_close
        '
        Me.ActionList0.SetAction(Me.m_close, Me.a_close)
        Me.m_close.MergeNode = 199
        Me.m_close.Name = "m_close"
        Me.m_close.Parent = Me.ActionList0
        '
        'a_close
        '
        Me.a_close.Image = CType(resources.GetObject("a_close.Image"), System.Drawing.Image)
        Me.a_close.Name = "a_close"
        Me.a_close.Parent = Me.ActionList0
        Me.a_close.Shortcut = System.Windows.Forms.Shortcut.AltF4
        Me.a_close.Text = "&Zavřít"
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
        Me.m_view.MergeNode = 300
        Me.m_view.Name = "m_view"
        Me.m_view.Parent = Me.ActionList0
        Me.m_view.Text = "&Zobrazení"
        '
        'm_tools
        '
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
        'pgFaktVyd
        '
        Me.pgFaktVyd.Controls.Add(Me.pnVydFakt)
        Me.pgFaktVyd.Location = New System.Drawing.Point(4, 22)
        Me.pgFaktVyd.Name = "pgFaktVyd"
        Me.pgFaktVyd.Size = New System.Drawing.Size(982, 513)
        Me.pgFaktVyd.TabIndex = 2
        Me.pgFaktVyd.Text = "Archiv vydaných faktur"
        Me.pgFaktVyd.UseVisualStyleBackColor = True
        '
        'pgPrijFakt
        '
        Me.pgPrijFakt.Controls.Add(Me.pnFgP)
        Me.pgPrijFakt.Location = New System.Drawing.Point(4, 22)
        Me.pgPrijFakt.Name = "pgPrijFakt"
        Me.pgPrijFakt.Size = New System.Drawing.Size(982, 513)
        Me.pgPrijFakt.TabIndex = 3
        Me.pgPrijFakt.Text = "Archiv přijatých faktur"
        Me.pgPrijFakt.UseVisualStyleBackColor = True
        '
        'pnVydFakt
        '
        Me.pnVydFakt.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnVydFakt.Controls.Add(Me.FgFV)
        Me.pnVydFakt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnVydFakt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnVydFakt.Location = New System.Drawing.Point(0, 0)
        Me.pnVydFakt.Name = "pnVydFakt"
        Me.pnVydFakt.Size = New System.Drawing.Size(982, 513)
        Me.pnVydFakt.TabIndex = 9
        '
        'FgFV
        '
        Me.FgFV.AllowEditing = False
        Me.FgFV.BackColor = System.Drawing.Color.Pink
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
        Me.FgFV.Size = New System.Drawing.Size(982, 513)
        Me.FgFV.StyleInfo = resources.GetString("FgFV.StyleInfo")
        Me.FgFV.TabIndex = 7
        Me.FgFV.Tree.Column = 1
        Me.FgFV.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgFV.UseCompatibleTextRendering = False
        Me.FgFV.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'pnFgP
        '
        Me.pnFgP.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pnFgP.Controls.Add(Me.FgFP)
        Me.pnFgP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnFgP.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.pnFgP.Location = New System.Drawing.Point(0, 0)
        Me.pnFgP.Name = "pnFgP"
        Me.pnFgP.Size = New System.Drawing.Size(982, 513)
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
        Me.FgFP.Size = New System.Drawing.Size(982, 513)
        Me.FgFP.StyleInfo = resources.GetString("FgFP.StyleInfo")
        Me.FgFP.TabIndex = 7
        Me.FgFP.Tree.Column = 1
        Me.FgFP.Tree.LineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FgFP.UseCompatibleTextRendering = False
        Me.FgFP.XSearchTextMode = XForms.XC1Flexgrid.XSearchTextModes.[Default]
        '
        'lblArchiveFileSize
        '
        Me.lblArchiveFileSize.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblArchiveFileSize.Name = "lblArchiveFileSize"
        Me.lblArchiveFileSize.Size = New System.Drawing.Size(19, 17)
        Me.lblArchiveFileSize.Text = "    "
        '
        'lblArchiveFileTime
        '
        Me.lblArchiveFileTime.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblArchiveFileTime.Name = "lblArchiveFileTime"
        Me.lblArchiveFileTime.Size = New System.Drawing.Size(19, 17)
        Me.lblArchiveFileTime.Text = "    "
        '
        'MForm
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
        Me.Name = "MForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prohlížeč vybraných dat archivu účetnictví Pohoda"
        Me.tbcMain.ResumeLayout(False)
        Me.pgNab.ResumeLayout(False)
        Me.pnNab.ResumeLayout(False)
        CType(Me.FgN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgObj.ResumeLayout(False)
        Me.pnObj.ResumeLayout(False)
        CType(Me.FgO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ActionList0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgFaktVyd.ResumeLayout(False)
        Me.pgPrijFakt.ResumeLayout(False)
        Me.pnVydFakt.ResumeLayout(False)
        CType(Me.FgFV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFgP.ResumeLayout(False)
        CType(Me.FgFP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents poConn As OleDb.OleDbConnection
    Friend WithEvents tbcMain As XControls.XTabControl
    Friend WithEvents pgObj As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents FgO As XC1Flexgrid
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
    Friend WithEvents pnObj As Panel
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
    Friend WithEvents pgPrijFakt As TabPage
    Friend WithEvents pnFgP As Panel
    Friend WithEvents FgFP As XC1Flexgrid
    Friend WithEvents lblArchiveFileTime As ToolStripStatusLabel
    Friend WithEvents lblArchiveFileSize As ToolStripStatusLabel
End Class
