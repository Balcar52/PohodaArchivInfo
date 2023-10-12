Option Strict Off

Public Class FGridSearchText

    Inherits System.Windows.Forms.Form

#Region "Designer"
    Public Sub New(oOwner As Object)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Init(oOwner)
    End Sub

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

    Friend WithEvents pnBoxes As Panel
    Friend WithEvents chkSearchFromTop As CheckBox
    Friend WithEvents chkCaseSensitive As CheckBox
    Friend WithEvents pnText As Panel
    Friend WithEvents chkBackward As CheckBox
    Friend WithEvents pnColumn As Panel
    Friend WithEvents cmbColumn As ComboBox
    Friend WithEvents chkFindInColumn As CheckBox
    Friend WithEvents chkRespectAccents As CheckBox
    Friend WithEvents searchMenuStrip As ContextMenuStrip
    Friend WithEvents itmSrcText As ToolStripMenuItem
    Friend WithEvents itmSrcNext As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents itmCols As ToolStripMenuItem
    Friend WithEvents PřizpůsobitŠířkySloupcůToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnSearchAll As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pnFirma As Panel
    Friend WithEvents cmbFirma As ComboBox
    Friend WithEvents chkRangeFirma As CheckBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FGridSearchText))
        Me.ButtonPanel1 = New XControls.ButtonPanel()
        Me.btnSearchAll = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnMain = New System.Windows.Forms.Panel()
        Me.pnBoxes = New System.Windows.Forms.Panel()
        Me.pnColumn = New System.Windows.Forms.Panel()
        Me.cmbColumn = New System.Windows.Forms.ComboBox()
        Me.chkFindInColumn = New System.Windows.Forms.CheckBox()
        Me.pnFirma = New System.Windows.Forms.Panel()
        Me.cmbFirma = New System.Windows.Forms.ComboBox()
        Me.chkRangeFirma = New System.Windows.Forms.CheckBox()
        Me.chkRespectAccents = New System.Windows.Forms.CheckBox()
        Me.chkCaseSensitive = New System.Windows.Forms.CheckBox()
        Me.chkBackward = New System.Windows.Forms.CheckBox()
        Me.chkSearchFromTop = New System.Windows.Forms.CheckBox()
        Me.pnText = New System.Windows.Forms.Panel()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblText = New System.Windows.Forms.Label()
        Me.searchMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itmSrcText = New System.Windows.Forms.ToolStripMenuItem()
        Me.itmSrcNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.itmCols = New System.Windows.Forms.ToolStripMenuItem()
        Me.PřizpůsobitŠířkySloupcůToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonPanel1.SuspendLayout()
        Me.pnMain.SuspendLayout()
        Me.pnBoxes.SuspendLayout()
        Me.pnColumn.SuspendLayout()
        Me.pnFirma.SuspendLayout()
        Me.pnText.SuspendLayout()
        Me.searchMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonPanel1
        '
        Me.ButtonPanel1.AutoButtonSpaceControl = Me.ButtonPanel1
        Me.ButtonPanel1.Controls.Add(Me.btnSearchAll)
        Me.ButtonPanel1.Controls.Add(Me.btnOK)
        Me.ButtonPanel1.Controls.Add(Me.btnCancel)
        Me.ButtonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonPanel1.Location = New System.Drawing.Point(0, 199)
        Me.ButtonPanel1.Name = "ButtonPanel1"
        Me.ButtonPanel1.Padding = New System.Windows.Forms.Padding(9, 8, 9, 13)
        Me.ButtonPanel1.PaddingAutomaticCoef = New System.Drawing.SizeF(0.2!, 0.08!)
        Me.ButtonPanel1.Size = New System.Drawing.Size(390, 44)
        Me.ButtonPanel1.TabIndex = 1
        '
        'btnSearchAll
        '
        Me.btnSearchAll.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnSearchAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSearchAll.Location = New System.Drawing.Point(77, 8)
        Me.btnSearchAll.Name = "btnSearchAll"
        Me.btnSearchAll.Size = New System.Drawing.Size(166, 23)
        Me.btnSearchAll.TabIndex = 2
        Me.btnSearchAll.Text = "Hromadné vyhledávání (F3)"
        Me.ToolTip1.SetToolTip(Me.btnSearchAll, "Vyhledá všechny řádky s hledaným textem a rozbalí, ostatří řádky se sbalí")
        Me.btnSearchAll.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOK.Location = New System.Drawing.Point(243, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(312, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Stor&no"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnMain
        '
        Me.pnMain.Controls.Add(Me.pnBoxes)
        Me.pnMain.Controls.Add(Me.pnText)
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnMain.Location = New System.Drawing.Point(0, 0)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Padding = New System.Windows.Forms.Padding(10, 10, 10, 5)
        Me.pnMain.Size = New System.Drawing.Size(390, 199)
        Me.pnMain.TabIndex = 0
        '
        'pnBoxes
        '
        Me.pnBoxes.Controls.Add(Me.pnColumn)
        Me.pnBoxes.Controls.Add(Me.pnFirma)
        Me.pnBoxes.Controls.Add(Me.chkRespectAccents)
        Me.pnBoxes.Controls.Add(Me.chkCaseSensitive)
        Me.pnBoxes.Controls.Add(Me.chkBackward)
        Me.pnBoxes.Controls.Add(Me.chkSearchFromTop)
        Me.pnBoxes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBoxes.Location = New System.Drawing.Point(10, 41)
        Me.pnBoxes.Name = "pnBoxes"
        Me.pnBoxes.Padding = New System.Windows.Forms.Padding(5)
        Me.pnBoxes.Size = New System.Drawing.Size(370, 153)
        Me.pnBoxes.TabIndex = 1
        '
        'pnColumn
        '
        Me.pnColumn.Controls.Add(Me.cmbColumn)
        Me.pnColumn.Controls.Add(Me.chkFindInColumn)
        Me.pnColumn.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnColumn.Location = New System.Drawing.Point(5, 128)
        Me.pnColumn.Name = "pnColumn"
        Me.pnColumn.Padding = New System.Windows.Forms.Padding(0, 5, 2, 0)
        Me.pnColumn.Size = New System.Drawing.Size(360, 27)
        Me.pnColumn.TabIndex = 5
        '
        'cmbColumn
        '
        Me.cmbColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumn.Location = New System.Drawing.Point(135, 5)
        Me.cmbColumn.Name = "cmbColumn"
        Me.cmbColumn.Size = New System.Drawing.Size(223, 21)
        Me.cmbColumn.TabIndex = 1
        '
        'chkFindInColumn
        '
        Me.chkFindInColumn.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkFindInColumn.Location = New System.Drawing.Point(0, 5)
        Me.chkFindInColumn.Name = "chkFindInColumn"
        Me.chkFindInColumn.Size = New System.Drawing.Size(135, 22)
        Me.chkFindInColumn.TabIndex = 0
        Me.chkFindInColumn.Text = "hledat ve &sloupci"
        Me.chkFindInColumn.UseVisualStyleBackColor = True
        '
        'pnFirma
        '
        Me.pnFirma.Controls.Add(Me.cmbFirma)
        Me.pnFirma.Controls.Add(Me.chkRangeFirma)
        Me.pnFirma.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnFirma.Location = New System.Drawing.Point(5, 101)
        Me.pnFirma.Name = "pnFirma"
        Me.pnFirma.Padding = New System.Windows.Forms.Padding(0, 5, 2, 0)
        Me.pnFirma.Size = New System.Drawing.Size(360, 27)
        Me.pnFirma.TabIndex = 4
        '
        'cmbFirma
        '
        Me.cmbFirma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFirma.Location = New System.Drawing.Point(135, 5)
        Me.cmbFirma.Name = "cmbFirma"
        Me.cmbFirma.Size = New System.Drawing.Size(223, 21)
        Me.cmbFirma.TabIndex = 1
        '
        'chkRangeFirma
        '
        Me.chkRangeFirma.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkRangeFirma.Location = New System.Drawing.Point(0, 5)
        Me.chkRangeFirma.Name = "chkRangeFirma"
        Me.chkRangeFirma.Size = New System.Drawing.Size(135, 22)
        Me.chkRangeFirma.TabIndex = 0
        Me.chkRangeFirma.Text = "hledat v rámci &firmy"
        Me.chkRangeFirma.UseVisualStyleBackColor = True
        '
        'chkRespectAccents
        '
        Me.chkRespectAccents.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkRespectAccents.Location = New System.Drawing.Point(5, 77)
        Me.chkRespectAccents.Name = "chkRespectAccents"
        Me.chkRespectAccents.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.chkRespectAccents.Size = New System.Drawing.Size(360, 24)
        Me.chkRespectAccents.TabIndex = 3
        Me.chkRespectAccents.Text = "rozlišovat znaky s diakritikou"
        Me.chkRespectAccents.UseVisualStyleBackColor = True
        '
        'chkCaseSensitive
        '
        Me.chkCaseSensitive.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkCaseSensitive.Location = New System.Drawing.Point(5, 53)
        Me.chkCaseSensitive.Name = "chkCaseSensitive"
        Me.chkCaseSensitive.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.chkCaseSensitive.Size = New System.Drawing.Size(360, 24)
        Me.chkCaseSensitive.TabIndex = 2
        Me.chkCaseSensitive.Text = "rozlišovat &velká/malá písmena"
        Me.chkCaseSensitive.UseVisualStyleBackColor = True
        '
        'chkBackward
        '
        Me.chkBackward.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkBackward.Location = New System.Drawing.Point(5, 29)
        Me.chkBackward.Name = "chkBackward"
        Me.chkBackward.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.chkBackward.Size = New System.Drawing.Size(360, 24)
        Me.chkBackward.TabIndex = 1
        Me.chkBackward.Text = "hledat směrem z&pět"
        Me.chkBackward.UseVisualStyleBackColor = True
        '
        'chkSearchFromTop
        '
        Me.chkSearchFromTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkSearchFromTop.Location = New System.Drawing.Point(5, 5)
        Me.chkSearchFromTop.Name = "chkSearchFromTop"
        Me.chkSearchFromTop.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.chkSearchFromTop.Size = New System.Drawing.Size(360, 24)
        Me.chkSearchFromTop.TabIndex = 0
        Me.chkSearchFromTop.Text = "hledat od &začátku"
        Me.chkSearchFromTop.UseVisualStyleBackColor = True
        '
        'pnText
        '
        Me.pnText.Controls.Add(Me.txtValue)
        Me.pnText.Controls.Add(Me.lblText)
        Me.pnText.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnText.Location = New System.Drawing.Point(10, 10)
        Me.pnText.Name = "pnText"
        Me.pnText.Padding = New System.Windows.Forms.Padding(5)
        Me.pnText.Size = New System.Drawing.Size(370, 31)
        Me.pnText.TabIndex = 0
        '
        'txtValue
        '
        Me.txtValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValue.Location = New System.Drawing.Point(102, 5)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(263, 21)
        Me.txtValue.TabIndex = 1
        '
        'lblText
        '
        Me.lblText.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblText.Location = New System.Drawing.Point(5, 5)
        Me.lblText.Name = "lblText"
        Me.lblText.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.lblText.Size = New System.Drawing.Size(97, 21)
        Me.lblText.TabIndex = 0
        Me.lblText.Text = "hledaný &text :"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'searchMenuStrip
        '
        Me.searchMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itmSrcText, Me.itmSrcNext, Me.ToolStripSeparator1, Me.itmCols, Me.PřizpůsobitŠířkySloupcůToolStripMenuItem})
        Me.searchMenuStrip.Name = "searchMenuStrip"
        Me.searchMenuStrip.Size = New System.Drawing.Size(251, 98)
        '
        'itmSrcText
        '
        Me.itmSrcText.Name = "itmSrcText"
        Me.itmSrcText.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.itmSrcText.Size = New System.Drawing.Size(250, 22)
        Me.itmSrcText.Text = "Hledat text"
        '
        'itmSrcNext
        '
        Me.itmSrcNext.Name = "itmSrcNext"
        Me.itmSrcNext.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.itmSrcNext.Size = New System.Drawing.Size(250, 22)
        Me.itmSrcNext.Text = "Hledat další text"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(247, 6)
        '
        'itmCols
        '
        Me.itmCols.Name = "itmCols"
        Me.itmCols.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.itmCols.Size = New System.Drawing.Size(250, 22)
        Me.itmCols.Text = "Sloupce tabulky"
        '
        'PřizpůsobitŠířkySloupcůToolStripMenuItem
        '
        Me.PřizpůsobitŠířkySloupcůToolStripMenuItem.Name = "PřizpůsobitŠířkySloupcůToolStripMenuItem"
        Me.PřizpůsobitŠířkySloupcůToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.PřizpůsobitŠířkySloupcůToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.PřizpůsobitŠířkySloupcůToolStripMenuItem.Text = "Přizpůsobit šířky sloupců"
        '
        'FGridSearchText
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(390, 243)
        Me.Controls.Add(Me.pnMain)
        Me.Controls.Add(Me.ButtonPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 282)
        Me.Name = "FGridSearchText"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hledání textu"
        Me.ButtonPanel1.ResumeLayout(False)
        Me.pnMain.ResumeLayout(False)
        Me.pnBoxes.ResumeLayout(False)
        Me.pnColumn.ResumeLayout(False)
        Me.pnFirma.ResumeLayout(False)
        Me.pnText.ResumeLayout(False)
        Me.pnText.PerformLayout()
        Me.searchMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonPanel1 As XControls.ButtonPanel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnMain As System.Windows.Forms.Panel
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblText As System.Windows.Forms.Label

    Public Shared ResultText As String = ""

    'Public Function Run(oOwner As Form, sText As String, ByRef sValue As String, ByRef SearchAgain As Boolean, ByRef CaseSensitive As Boolean)
    '    Dim oFrm As New FSearchText(oOwner As form)
    '    With oFrm
    '        .Owner = oOwner
    '        .lblText.Text = sText + If(sText.EndsWith(":"), "", " :")
    '        .txtValue.Text = sValue
    '        .txtValue.Font = New Font(txtValue.Font, If(BoldText, FontStyle.Bold, FontStyle.Regular))
    '        .bLoadPrevious = LoadPreviousValue
    '        .bCheckNotEmpty = CheckStringValueNotEmpty
    '        ResultText = Nothing
    '        If .ShowDialog = Windows.Forms.DialogResult.OK Then ResultText = Trim(.txtValue.Text)
    '        Application.DoEvents()
    '        Return ResultText
    '    End With
    'End Function
#End Region

    Private bLoading As Boolean = True
    Friend aoSloupce As New List(Of Object)
    Friend oOwnerCtl As Control
    Friend iColFirma As Integer = -1

    Private Shared gaoConnectorList As New List(Of Connector)

    Friend Shared gaoGridFirmaColList As New Dictionary(Of Control, Integer)

    Public Class Member
        Public Shared Function GetMembers(InpText As String, CaseSensitive As Boolean, CutDiactitics As Boolean) As List(Of Member)
            Dim sText As String = Replace(Replace(InpText, "|", vbTab & "|"), "&", vbTab & "&")
            If CutDiactitics Then sText = XControls.CutDiacritic(sText)
            If Not CaseSensitive Then sText = UCase(sText)
            Dim oRes As New List(Of Member)
            For Each s In Split(sText, vbTab)
                s = Trim(s)
                If Not String.IsNullOrWhiteSpace(s) Then
                    oRes.Add(New Member(s))
                End If
            Next
            Return oRes
        End Function
        Public Shared Function FoundInExpression(sText As String, Expression As List(Of Member)) As Boolean
            Dim bRes As Boolean = False
            Dim bFst As Boolean = True
            For Each oMember In Expression
                Dim bFound As Boolean = sText.Contains(oMember.Text)
                If bFst Then
                    bRes = bFound
                Else
                    If oMember.AndExpr Then
                        '§ and clause
                        bRes = bRes AndAlso bFound
                    Else
                        '§ or clause
                        If bRes Then Exit For
                        'If bFound Then bRes = True Else bRes = False
                        bRes = bFound
                    End If
                End If
                bFst = False
            Next
            Return bRes
        End Function
        Public Sub New(ByRef sText As String)
            sText = Trim(sText)
            If Trim(sText & " ").StartsWith("&") Then
                AndExpr = True
                Text = Trim((sText & " ").Substring(sText.IndexOf("&") + 1))
            ElseIf Trim(sText & " ").StartsWith("|") Then
                AndExpr = False
                Text = Trim((sText & " ").Substring(sText.IndexOf("|") + 1))
            Else
                AndExpr = False
                Text = Trim(sText)
            End If
        End Sub
        Public AndExpr As Boolean = False
        Public Text As String = ""
    End Class

    Private Sub Init(oOwner As Control)
        'Me.Owner = oOwner
        'Restore()
        oOwnerCtl = oOwner
        Me.Name = Me.Name & "." & oOwner.Name
        WindowSetParentAndRestore(Me, oOwner)
        TextBoxRestore(Me.txtValue)
        CheckBoxRestore(Me.chkBackward)
        CheckBoxRestore(Me.chkCaseSensitive)
        CheckBoxRestore(Me.chkRespectAccents)
        CheckBoxRestore(Me.chkSearchFromTop)
        CheckBoxRestore(Me.chkFindInColumn)
        If TypeOf oOwner Is XC1Flexgrid OrElse oOwner.GetType.IsSubclassOf(GetType(XC1Flexgrid)) Then
            Dim oFg As XC1Flexgrid = DirectCast(oOwner, XC1Flexgrid)
            With oFg
                Sloupec.CreateItem(DirectCast(oOwner, XC1Flexgrid), -1, aoSloupce)
                For iCol As Integer = 0 To .Cols.Count - 1
                    Sloupec.CreateItem(DirectCast(oOwner, XC1Flexgrid), iCol, aoSloupce)
                Next
                If aoSloupce IsNot Nothing Then Me.cmbColumn.Items.AddRange(aoSloupce.ToArray)
                ComboBoxRestore(Me.cmbColumn)
                If Me.cmbColumn.SelectedIndex < 0 Then Me.cmbColumn.SelectedIndex = 0
                If gaoGridFirmaColList.ContainsKey(oFg) Then
                    iColFirma = gaoGridFirmaColList(oFg)
                    Dim asFirmalist As New List(Of String)
                    Dim sFirma As String = ""
                    For iRow As Integer = .Row1 To .RowN
                        sFirma = CStr(oFg(iRow, iColFirma))
                        If Not asFirmalist.Contains(sFirma) Then asFirmalist.Add(sFirma)
                    Next
                    asFirmalist.Sort()
                    sFirma = CStr(oFg(oFg.Row, iColFirma))
                    For Each s In asFirmalist
                        cmbFirma.Items.Add(s)
                        If String.Compare(s, sFirma, True) = 0 Then
                            cmbFirma.SelectedIndex = cmbFirma.Items.Count - 1
                        End If
                    Next
                    iColFirma = gaoGridFirmaColList(oFg)
                    CheckBoxRestore(Me.chkRangeFirma)
                Else
                    pnFirma.Parent = Nothing
                End If
            End With
        Else
            pnColumn.Parent = Nothing
            chkRespectAccents.Parent = Nothing
        End If
        bLoading = False
        chkFindInColumn_CheckedChanged(Nothing, Nothing)
        chkRangeFirma_CheckedChanged(Nothing, Nothing)
    End Sub

    ''' <summary> trida pro pripojeni hledani ve vsech gridech formulare </summary>
    Public Class Connector
        Implements IDisposable

        Public Sub New(oForm As Form, oAction As ActionListLib.Action, oActionNext As ActionListLib.Action, Optional iFirmaColumnIndex As Integer = -1)
            MyBase.New()
            Me.oForm = oForm
            Me.oActionSearch = oAction
            Me.oActionSearchNext = oActionNext
            oActionSearchNext.Enabled = False
            oActionSearchNext.Tag = False
            iFirmaColumn = iFirmaColumnIndex
        End Sub

        Public Sub New(oForm As Form, oControl As Control, oControlNext As Control)
            MyBase.New()
            Me.oForm = oForm
            Me.oControlSearch = oControl
            Me.oControlSearchNext = oControlNext
            oActionSearchNext.Enabled = False
            oActionSearchNext.Tag = False
        End Sub

        Public Sub New(oForm As Form, oToolStrip As ToolStripItem, oToolStripNext As ToolStripItem)
            MyBase.New()
            Me.oForm = oForm
            Me.oToolStripSearch = oToolStrip
            Me.oToolStripNext = oToolStripNext
            oActionSearchNext.Enabled = False
            oActionSearchNext.Tag = False
        End Sub

        Public Sub AddGrid(oGrid As Control)
            If Not aoGridList.Contains(oGrid) Then aoGridList.Add(oGrid)
        End Sub

        Friend oForm As Form
        Friend oActionSearch As ActionListLib.Action
        Friend oActionSearchNext As ActionListLib.Action
        Friend oControlSearch As Control
        Friend oControlSearchNext As Control
        Friend oToolStripSearch As ToolStripItem
        Friend oToolStripNext As ToolStripItem
        Friend oActiveGrid As Object = Nothing
        Friend aoGridList As New List(Of Control)
        Friend bOptimize As Boolean = False  ' pokud je jen jeden grid, tak se pripoji, a uz se nebude odpojovat
        Friend bOptimized As Boolean = False ' je pripojen, tak s tim uz nebudeme hybat
        Friend iFirmaColumn As Integer = -1

        Public ReadOnly Property IsEmpty
            Get
                Return aoGridList.Count <= 0
            End Get
        End Property

        Public Property OptimizeActivation As Boolean
            Get
                Return bOptimize
            End Get
            Set(value As Boolean)
                bOptimize = value
            End Set
        End Property

        Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs)
            RemoveHandler oForm.FormClosing, AddressOf Form_Closing
            For Each oCtl As Control In aoGridList
                RemoveHandler oCtl.Enter, AddressOf Grid_Enter
                RemoveHandler oCtl.Leave, AddressOf Grid_Leave
            Next
            If gaoConnectorList.Contains(Me) Then gaoConnectorList.Remove(Me)
            Me.Dispose()
        End Sub

        Private Sub Grid_Enter(sender As Object, e As System.EventArgs)
            If bOptimized Then Exit Sub
            oActiveGrid = sender
            Dim oTextboxName As String = String.Format("{0}\{1}.{2}", oForm.Name, "FGridSearchText", DirectCast(oActiveGrid, Control).Name)
            Dim sVal As String = ReadFromReg(oTextboxName, "txtValue")
            If oActionSearchNext IsNot Nothing Then oActionSearchNext.Tag = Not (String.IsNullOrWhiteSpace(sVal))
            SetActEnabled()
            If aoGridList.Count = 1 Then
                If bOptimize Then bOptimized = True
            End If
        End Sub

        Private Sub Grid_Leave(sender As Object, e As System.EventArgs)
            If bOptimized Then Exit Sub
            oActiveGrid = Nothing
            SetActEnabled()
        End Sub

        Public Sub Action_Execute(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If oActiveGrid IsNot Nothing Then
                If FGridSearchText.Run(oActiveGrid, sender Is oActionSearchNext) Then
                    If oActionSearchNext IsNot Nothing Then
                        oActionSearchNext.Tag = True
                        SetActEnabled()
                    End If
                End If
            End If
        End Sub

        Public Sub SetActEnabled()
            If oActionSearch IsNot Nothing Then
                oActionSearch.Enabled = oActiveGrid IsNot Nothing
                oActionSearchNext.Enabled = CBool(oActionSearchNext.Tag) AndAlso oActiveGrid IsNot Nothing
            ElseIf oControlSearch IsNot Nothing Then
                oControlSearch.Enabled = oActiveGrid IsNot Nothing
                oControlSearchNext.Enabled = CBool(oActionSearchNext.Tag) AndAlso oActiveGrid IsNot Nothing
            ElseIf oToolStripSearch IsNot Nothing Then
                oToolStripSearch.Enabled = oActiveGrid IsNot Nothing
                oToolStripNext.Enabled = CBool(oActionSearchNext.Tag) AndAlso oActiveGrid IsNot Nothing
            End If
        End Sub

        Public Sub Activate()
            If Not IsEmpty Then
                If Not gaoConnectorList.Contains(Me) Then gaoConnectorList.Add(Me)
                AddHandler oForm.FormClosing, AddressOf Form_Closing
                If oActionSearch IsNot Nothing Then
                    For Each oCtl As Control In aoGridList
                        RemoveHandler oCtl.Enter, AddressOf Grid_Enter
                        RemoveHandler oCtl.Leave, AddressOf Grid_Leave
                        AddHandler oCtl.Enter, AddressOf Grid_Enter
                        AddHandler oCtl.Leave, AddressOf Grid_Leave
                    Next
                    SetActEnabled()
                    RemoveHandler oActionSearch.Execute, AddressOf Action_Execute
                    RemoveHandler oActionSearchNext.Execute, AddressOf Action_Execute
                    AddHandler oActionSearch.Execute, AddressOf Action_Execute
                    AddHandler oActionSearchNext.Execute, AddressOf Action_Execute
                ElseIf oControlSearch IsNot Nothing Then
                    For Each oCtl As Control In aoGridList
                        RemoveHandler oCtl.Enter, AddressOf Grid_Enter
                        RemoveHandler oCtl.Leave, AddressOf Grid_Leave
                        AddHandler oCtl.Enter, AddressOf Grid_Enter
                        AddHandler oCtl.Leave, AddressOf Grid_Leave
                    Next
                    SetActEnabled()
                    RemoveHandler oControlSearch.Click, AddressOf Action_Execute
                    RemoveHandler oControlSearchNext.Click, AddressOf Action_Execute
                    AddHandler oControlSearch.Click, AddressOf Action_Execute
                    AddHandler oControlSearchNext.Click, AddressOf Action_Execute
                ElseIf oToolStripSearch IsNot Nothing Then
                    For Each oCtl As Control In aoGridList
                        RemoveHandler oCtl.Enter, AddressOf Grid_Enter
                        RemoveHandler oCtl.Leave, AddressOf Grid_Leave
                        AddHandler oCtl.Enter, AddressOf Grid_Enter
                        AddHandler oCtl.Leave, AddressOf Grid_Leave
                    Next
                    SetActEnabled()
                    RemoveHandler oToolStripSearch.Click, AddressOf Action_Execute
                    RemoveHandler oToolStripNext.Click, AddressOf Action_Execute
                    AddHandler oToolStripSearch.Click, AddressOf Action_Execute
                    AddHandler oToolStripNext.Click, AddressOf Action_Execute
                End If
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    ''' <summary> registrovat hledani textu pro vsechny gridy </summary>
    ''' <param name="oOwner"></param>
    ''' <param name="oActionSearch"></param>
    ''' <param name="oActionSearchNext"></param>
    ''' <param name="ExcludeGridList"></param>
    Public Shared Sub RegisterForAllGrids(oOwner As Form, oActionSearch As ActionListLib.Action, oActionSearchNext As ActionListLib.Action, Optional ExcludeGridList() As Object = Nothing,
                                          Optional bOptimizeActivation As Boolean = True, Optional iColumnFirmaIndex As Integer = -1)
        Dim oConn As New Connector(oOwner, oActionSearch, oActionSearchNext)
        For Each oCtl As Object In XControls.GetAllControls(oOwner)
            If (TypeOf oCtl Is XC1Flexgrid OrElse oCtl.GetType.IsSubclassOf(GetType(XC1Flexgrid))) AndAlso Not (ExcludeGridList IsNot Nothing AndAlso Array.IndexOf(ExcludeGridList, oCtl) >= 0) Then
                oConn.AddGrid(oCtl)
            End If
        Next
        oConn.iFirmaColumn = iColumnFirmaIndex
        oConn.OptimizeActivation = bOptimizeActivation AndAlso oConn.aoGridList.Count = 1 'povolim jen pokud je jen jeden grid
        oConn.Activate()
    End Sub

    ''' <summary> registrovat hledani textu pro vsechny gridy </summary>
    ''' <param name="oOwner"></param>
    ''' <param name="oControlSearch"></param>
    ''' <param name="oControlSearchNext"></param>
    ''' <param name="ExcludeGridList"></param>
    Public Shared Sub RegisterForAllGrids(oOwner As Form, oControlSearch As Control, oControlSearchNext As Control, Optional ExcludeGridList() As Object = Nothing, Optional bOptimizeActivation As Boolean = True)
        Dim oConn As New Connector(oOwner, oControlSearch, oControlSearchNext)
        For Each oCtl As Object In XControls.GetAllControls(oOwner)
            If (TypeOf oCtl Is XC1Flexgrid OrElse oCtl.GetType.IsSubclassOf(GetType(XC1Flexgrid))) AndAlso Not (ExcludeGridList IsNot Nothing AndAlso Array.IndexOf(ExcludeGridList, oCtl) >= 0) Then
                oConn.AddGrid(oCtl)
            End If
        Next
        oConn.OptimizeActivation = bOptimizeActivation AndAlso oConn.aoGridList.Count = 1 'povolim jen pokud je jen jeden grid
        oConn.Activate()
    End Sub

    ''' <summary> registrovat hledani textu pro vsechny gridy </summary>
    ''' <param name="oOwner"></param>
    Public Shared Sub RegisterForAllGrids(oOwner As Form, oToolstripSearch As ToolStripItem, oToolstripNext As ToolStripItem, Optional ExcludeGridList() As Object = Nothing, Optional bOptimizeActivation As Boolean = True)
        Dim oConn As New Connector(oOwner, oToolstripSearch, oToolstripNext)
        For Each oCtl As Object In XControls.GetAllControls(oOwner)
            If (TypeOf oCtl Is XC1Flexgrid OrElse oCtl.GetType.IsSubclassOf(GetType(XC1Flexgrid))) AndAlso Not (ExcludeGridList IsNot Nothing AndAlso Array.IndexOf(ExcludeGridList, oCtl) >= 0) Then
                oConn.AddGrid(oCtl)
            End If
        Next
        oConn.OptimizeActivation = bOptimizeActivation AndAlso oConn.aoGridList.Count = 1 'povolim jen pokud je jen jeden grid
        oConn.Activate()
    End Sub

    'Private Sub Restore()
    '    WindowRestore(Me)
    '    TextBoxRestore(Me.txtValue)
    '    CheckBoxRestore(Me.chkBackward)
    '    CheckBoxRestore(Me.chkCaseSensitive)
    '    CheckBoxRestore(Me.chkSearchAgain)
    '    CheckBoxRestore(Me.chkFindInColumn)
    '    ComboBoxRestore(Me.cmbColumn)
    'End Sub

    ''' <summary> hleda v danem flexgridu </summary>
    ''' <param name="oFg"> dany grid </param>
    ''' <param name="NoDialog"> bez zobrazeni dialogu (hledat dalsi vyskyt) </param>
    Public Shared Function Run(oFg As XC1Flexgrid, Optional NoDialog As Boolean = False, Optional TopMost As Boolean = True) As Boolean
        Dim oFrm As New FGridSearchText(oFg)
        With oFrm
            If TopMost Then .TopMost = True
            Return .SearchText(oFg, NoDialog)
        End With
    End Function

    ''' <summary> hleda v danem flexgridu </summary>
    ''' <param name="NoDialog"> bez zobrazeni dialogu (hledat dalsi vyskyt) </param>
    Public Shared Function Run(oOwner As RichTextBox, Optional NoDialog As Boolean = False, Optional TopMost As Boolean = True) As Boolean
        Dim oFrm As New FGridSearchText(oOwner)
        With oFrm
            If TopMost Then .TopMost = True
            Return .SearchText(oOwner, NoDialog)
        End With
    End Function


    ''' <summary> prohleda rekurzivne dany ovladaci prvek, a provede postupne vyhledavani na vsech nalezenych gridech </summary>
    ''' <param name="oCtl"></param>
    ''' <param name="NoDialog"></param>
    ''' <returns> true, pokud neco nasel </returns>
    Public Shared Function Run(oCtl As Control, Optional NoDialog As Boolean = False) As Boolean
        Dim oGridList As New List(Of XC1Flexgrid)
        Dim iIndx0 As Integer = 0
        Dim iIndx As Integer = 0
        For Each oFg As XC1Flexgrid In XControls.GetAllControls(oCtl, , , , New Type() {GetType(C1.Win.C1FlexGrid.C1FlexGrid)})
            If XControls.GetTopForm(oCtl).ActiveControl Is oFg Then
                iIndx0 = oGridList.Count
                iIndx = oGridList.Count
            End If
            oGridList.Add(oFg)
        Next
        If oGridList.Count = 0 Then Return False
        Dim bNodialog As Boolean = NoDialog
        Do
            Dim bRes As Boolean = Run(oGridList(iIndx), bNodialog)
            If bRes Then Return True
            bNodialog = True
            iIndx += 1
            If iIndx >= oGridList.Count Then iIndx = 0
            If iIndx = iIndx0 Then Exit Do
        Loop
        Return False
    End Function

    Private Class Sloupec
        Public Shared Function CreateItem(oFg As XC1Flexgrid, iCol As Integer, ByRef aoSloupce As List(Of Object)) As Boolean
            Dim oSloupec As Sloupec = Nothing
            If iCol < 0 Then
                oSloupec = New Sloupec
            ElseIf iCol < oFg.Cols.Count AndAlso oFg.Cols(iCol).Visible AndAlso oFg.Rows.Fixed > 0 AndAlso Not (iCol = 0 AndAlso oFg.ShowCursor) Then
                oSloupec = New Sloupec(oFg, iCol)
            End If
            If oSloupec Is Nothing Then Return False
            If oSloupec.IsValid Then aoSloupce.Add(oSloupec)
            Return oSloupec.IsValid
        End Function
        Public Sub New()
            MyBase.New()
            Column = -1
            Text = "všechny sloupce"
        End Sub
        Public Sub New(oFg As XC1Flexgrid, iCol As Integer)
            Dim sTitle0 As String = Trim(oFg(0, iCol))
            Dim sTitle As String = sTitle0
            For i As Integer = 1 To oFg.Rows.Fixed - 1
                If Trim(oFg(i, iCol)) <> sTitle0 Then sTitle &= " " & Trim(oFg(i, iCol))
            Next
            Text = Replace(sTitle, "\n", " ")
            Column = iCol
        End Sub
        Friend Column As Integer
        Friend Text As String
        Friend ReadOnly Property IsValid As Boolean
            Get
                Return Trim(Text) <> ""
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return Trim(Text)
        End Function
    End Class

    Private Function GetComboValue() As Sloupec
        If cmbColumn.SelectedIndex > 0 AndAlso Me.chkFindInColumn.Checked Then Return DirectCast(cmbColumn.SelectedItem, Sloupec)
        Return DirectCast(cmbColumn.Items(0), Sloupec)
    End Function

    Public Function SearchText(oFg As XC1Flexgrid, Optional NoDialog As Boolean = False, Optional ShowNotFind As Boolean = True) As Boolean
        Dim bRet As Boolean = False
        If oFg.Rows.Count <= oFg.Rows.Fixed Then
            MessageBox.Show(Me.Owner, "Text nelze vyhledat." & vbCrLf & "(tabulka neobsahuje žádná data)", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim sColVal As String = cmbColumn.Text
            Dim iItmIndx As Integer = 0
            For iCol As Integer = If(oFg.ShowCursor, 1, 0) To oFg.Cols.Count - 1
                If oFg.Cols(iCol).Visible AndAlso True Then
                    Dim s As String = ""
                    For iRow As Integer = 0 To oFg.Rows.Fixed - 1
                        s &= " " & oFg(iRow, iCol)
                    Next
                    s = Trim(s)
                End If
            Next

            Dim bBwd As Boolean = False
            Dim bCaseSens As Boolean = False
            Dim bAgain As Boolean = False
            Dim sColumn As String = ""
            Dim bColumn As Boolean = False
            If oFg.Row < oFg.Rows.Fixed Then oFg.Row = oFg.Rows.Fixed
            Dim oResult As DialogResult = DialogResult.None
            If Not NoDialog Then oResult = ShowDialog()
            Dim sValue As String = txtValue.Text
            If Not chkRespectAccents.Checked Then sValue = XControls.CutDiacritic(sValue)
            Dim aoMembers As List(Of Member) = Member.GetMembers(sValue, chkCaseSensitive.Checked, chkRespectAccents.Checked) ' seznam vyrazu pro vyhledavani
            If NoDialog OrElse oResult = DialogResult.OK OrElse oResult = DialogResult.Yes Then
                Dim aiCols As New List(Of Integer)
                For iCol As Integer = If(oFg.ShowCursor, 1, 0) To oFg.Cols.Count - 1
                    Select Case GetComboValue.Column
                        Case -1, iCol
                            If oFg.Cols(iCol).Visible Then aiCols.Add(iCol)
                    End Select
                Next
                If Me.chkSearchFromTop.Checked Then oFg.Row = oFg.Rows.Fixed
                Dim iOff As Integer = If(NoDialog, 1, 0)
                If oResult = DialogResult.Yes Then
                    'rezim vyber a skryj ostatni
                    Dim aiShowRows As New List(Of Integer) 'ktere radky zobrazim
                    Dim iSel As Integer = -1
                    For iRow As Integer = If(chkBackward.Checked, oFg.Row - iOff, oFg.Row + iOff) To If(chkBackward.Checked, oFg.Rows.Fixed, oFg.Rows.Count - 1) Step If(chkBackward.Checked, -1, 1)
                        For Each iCol As Integer In aiCols
                            Dim sFgValue As String = CStr(oFg(iRow, iCol))
                            If Not String.IsNullOrWhiteSpace(sFgValue) Then
                                If Not chkRespectAccents.Checked Then sFgValue = XControls.CutDiacritic(sFgValue)
                                If Not chkCaseSensitive.Checked Then sFgValue = UCase(sFgValue)
                                If Member.FoundInExpression(sFgValue, aoMembers) Then
                                    ' nalezeno
                                    ' ted jeste vyhodnotim, jestli je to v ramci hledane firmy
                                    If chkRangeFirma.Checked AndAlso iColFirma > 0 Then
                                        ' hledam jen v ramci firmy
                                        Dim sFirma As String = CStr(oFg(iRow, iColFirma))
                                        If TypeOf (cmbFirma.SelectedItem) Is String AndAlso String.Compare(CStr(cmbFirma.SelectedItem), sFirma, True) <> 0 Then GoTo nomatch
                                    End If
                                    bRet = True
                                    If iSel < 0 Then iSel = iRow
                                    If Not aiShowRows.Contains(iRow) Then aiShowRows.Add(iRow)
nomatch:                        End If
                            End If
                            '                            If Not chkRespectAccents.Checked Then sFgValue = XControls.CutDiacritic(sFgValue)
                            '                            If (Not oFg(iRow, iCol) Is Nothing) Then
                            '                                If sFgValue.IndexOf(Trim(sValue), If(Me.chkCaseSensitive.Checked, StringComparison.CurrentCulture, StringComparison.CurrentCultureIgnoreCase)) >= 0 Then
                            '                                    ' nalezeno
                            '                                    ' ted jeste vyhodnotim, jestli je to v ramci hledane firmy
                            '                                    If chkRangeFirma.Checked AndAlso iColFirma > 0 Then
                            '                                        ' hledam jen v ramci firmy
                            '                                        Dim sFirma As String = CStr(oFg(iRow, iColFirma))
                            '                                        If TypeOf (cmbFirma.SelectedItem) Is String AndAlso String.Compare(CStr(cmbFirma.SelectedItem), sFirma, True) <> 0 Then GoTo nomatch
                            '                                    End If
                            '                                    bRet = True
                            '                                    If iSel < 0 Then iSel = iRow
                            '                                    If Not aiShowRows.Contains(iRow) Then aiShowRows.Add(iRow)
                            'nomatch:                        End If
                            '                            End If
                        Next
                    Next
                    If bRet Then
                        CType(Me.Owner, MForm3).bLoading = True
                        oFg.BeginInit()
                        ' ted nastavim viditelnost radku
                        For iRow As Integer = oFg.Row1 To oFg.RowN
                            oFg.SetStyleToRow(iRow, oFg.ForeColor.ToArgb, oFg.BackColor.ToArgb)
                            If oFg.Rows(iRow).IsNode Then oFg.Rows(iRow).Node.Expanded = False
                            'oFg.Rows(iRow).Visible = aiShowRows.Contains(iRow)
                        Next
                        For Each iRow As Integer In aiShowRows
                            'If TypeOf (oFg.Rows(iRow).UserData) Is AData.AFaktPol Then
                            '    Dim oPol As AData.AFaktPol
                            'ElseIf TypeOf (oFg.Rows(iRow).UserData) Is AData.AObjNabPol Then

                            'End If
                            'oFg.SetStyleToRow(iRow, oFg.BackColor.ToArgb, oFg.ForeColor.ToArgb)
                            oFg.SetStyleToRow(iRow, SystemColors.HighlightText.ToArgb, SystemColors.Highlight.ToArgb)
                            oFg.SetStyleToCell(iRow, 0, SystemColors.HighlightText.ToArgb, SystemColors.Highlight.ToArgb)
                            If oFg.Rows(iRow).IsNode Then
                                oFg.Rows(iRow).Node.Expanded = True
                                If oFg.Rows(iRow).Node.Parent IsNot Nothing Then
                                    oFg.Rows(iRow).Node.Parent.Expanded = True
                                    'oFg.Rows(oFg.Rows(iRow).Node.Parent.Row.Index).Visible = True
                                    If oFg.Rows(iRow).Node.Parent.Parent IsNot Nothing Then
                                        oFg.Rows(iRow).Node.Parent.Parent.Expanded = True
                                        'oFg.Rows(oFg.Rows(iRow).Node.Parent.Parent.Row.Index).Visible = True
                                    End If
                                End If
                            End If
                        Next
                        oFg.EndInit()
                        oFg.Row = iSel
                        oFg.EnsureVisibleSelectedRow()
                        CType(Me.Owner, MForm3).bLoading = False
                        CType(Me.Owner, MForm3).FgO_AfterCollapse(oFg, Nothing)
                        'With CType(Me.Owner, MForm3)
                        '    .bHiddenBySearch = True
                        '    .lblHidden.Text = "POLOŽKY NEVYHOVUJÍCÍ VYHLEDÁVACÍ PODMÍNCE BYLY SKRYTY"
                        'End With
                    End If
                Else
                    For iRow As Integer = If(chkBackward.Checked, oFg.Row - iOff, oFg.Row + iOff) To If(chkBackward.Checked, oFg.Rows.Fixed, oFg.Rows.Count - 1) Step If(chkBackward.Checked, -1, 1)
                        If oFg.Rows(iRow).Visible Then
                            For Each iCol As Integer In aiCols
                                Dim sFgValue As String = CStr(oFg(iRow, iCol))
                                If Not String.IsNullOrWhiteSpace(sFgValue) Then
                                    If Not chkRespectAccents.Checked Then sFgValue = XControls.CutDiacritic(sFgValue)
                                    If Not chkCaseSensitive.Checked Then sFgValue = UCase(sFgValue)
                                    If Member.FoundInExpression(sFgValue, aoMembers) Then
                                        'If sFgValue.IndexOf(Trim(sValue), If(Me.chkCaseSensitive.Checked, StringComparison.CurrentCulture, StringComparison.CurrentCultureIgnoreCase)) >= 0 Then
                                        'nalezeno
                                        ' ted jeste vyhodnotim, jestli je to v ramci hledane firmy
                                        If chkRangeFirma.Checked AndAlso iColFirma > 0 Then
                                            ' hledam jen v ramci firmy
                                            Dim sFirma As String = CStr(oFg(iRow, iColFirma))
                                            If TypeOf (cmbFirma.SelectedItem) Is String AndAlso String.Compare(CStr(cmbFirma.SelectedItem), sFirma, True) <> 0 Then GoTo nomatch2
                                        End If
                                        FlexgridSelectAndShowRow(oFg, iRow)
                                        oFg.Select(iRow, iCol, True)
                                        chkSearchFromTop.Checked = False
                                        oFg.EnsureVisibleSelectedRow()
                                        bRet = True
                                        Exit For
nomatch2:                           End If
                                End If
                                '                                End If'                                If (Not oFg(iRow, iCol) Is Nothing) Then
                                '                                    If sFgValue.IndexOf(Trim(sValue), If(Me.chkCaseSensitive.Checked, StringComparison.CurrentCulture, StringComparison.CurrentCultureIgnoreCase)) >= 0 Then
                                '                                        'nalezeno
                                '                                        ' ted jeste vyhodnotim, jestli je to v ramci hledane firmy
                                '                                        If chkRangeFirma.Checked AndAlso iColFirma > 0 Then
                                '                                            ' hledam jen v ramci firmy
                                '                                            Dim sFirma As String = CStr(oFg(iRow, iColFirma))
                                '                                            If TypeOf (cmbFirma.SelectedItem) Is String AndAlso String.Compare(CStr(cmbFirma.SelectedItem), sFirma, True) <> 0 Then GoTo nomatch2
                                '                                        End If
                                '                                        FlexgridSelectAndShowRow(oFg, iRow)
                                '                                        oFg.Select(iRow, iCol, True)
                                '                                        chkSearchFromTop.Checked = False
                                '                                        oFg.EnsureVisibleSelectedRow()
                                '                                        bRet = True
                                '                                        Exit For
                                'nomatch2:                           End If
                                '                                End If
                            Next
                        End If
                        If bRet Then Exit For
                    Next
                End If
                SaveState()
                If ShowNotFind AndAlso Not bRet Then
                    MessageBox.Show(Me.Owner, String.Format("Text ""{0}"" nebyl nalezen", Trim(txtValue.Text)), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        Return bRet
    End Function

    Public Function SearchText(oRtb As RichTextBox, Optional NoDialog As Boolean = False, Optional ShowNotFind As Boolean = True) As Boolean
        Dim bRet As Boolean = False
        Try
            If NoDialog OrElse ShowDialog() = DialogResult.OK Then
                oRtb.SelectionBackColor = SystemColors.Highlight
                oRtb.SelectionColor = SystemColors.HighlightText
                Dim sValue As String = txtValue.Text
                Dim oOpt As RichTextBoxFinds = RichTextBoxFinds.None
                If chkBackward.Checked Then oOpt = oOpt Or RichTextBoxFinds.Reverse
                If chkCaseSensitive.Checked Then oOpt = oOpt Or RichTextBoxFinds.MatchCase
                'oOpt =
                If IsNumeric(oRtb.Tag) AndAlso NoDialog Then
                    oRtb.Tag = oRtb.Find(CStr(txtValue.Text), CInt(oRtb.Tag), oOpt)
                Else
                    oRtb.Tag = oRtb.Find(txtValue.Text, oOpt)
                End If
                If IsNumeric(oRtb.Tag) Then oRtb.Select(CInt(oRtb.Tag), txtValue.Text.Length)
                oRtb.ScrollToCaret()
                bRet = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        SaveState()
        If ShowNotFind AndAlso Not bRet Then
            MessageBox.Show(Me.Owner, String.Format("Text ""{0}"" nebyl nalezen", Trim(txtValue.Text)), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return bRet
    End Function


    Private Sub FSearchText_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If String.IsNullOrWhiteSpace(txtValue.Text) AndAlso DialogResult = DialogResult.OK Then
            MessageBox.Show(Me.Owner, "Není zadán žádný text pro hledání.", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub SaveState()
        WindowSave(Me)
        TextBoxSave(Me.txtValue)
        CheckBoxSave(Me.chkBackward)
        CheckBoxSave(Me.chkCaseSensitive)
        CheckBoxSave(Me.chkSearchFromTop)
        CheckBoxSave(Me.chkFindInColumn)
        ComboBoxSave(Me.cmbColumn)
        If iColFirma > 0 Then CheckBoxSave(Me.chkRangeFirma)
    End Sub

    Private Sub chkFindInColumn_CheckedChanged(sender As Object, e As EventArgs) Handles chkFindInColumn.CheckedChanged
        If Not bLoading Then Me.cmbColumn.Enabled = chkFindInColumn.Checked
    End Sub

    Private Sub chkRangeFirma_CheckedChanged(sender As Object, e As EventArgs) Handles chkRangeFirma.CheckedChanged
        If Not bLoading Then Me.cmbFirma.Enabled = chkRangeFirma.Checked AndAlso iColFirma > 0
    End Sub


    Private Sub txtValue_TextChanged(sender As Object, e As System.EventArgs) Handles txtValue.TextChanged
        If Not bLoading Then Me.chkSearchFromTop.Checked = True
    End Sub

    Private Sub FGridSearchText_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F3 Then
            DialogResult = DialogResult.Yes
        End If
    End Sub

End Class