'  trida pro centralni obsluhu status baru
'  v projektu existuje jedina instance (stb). 
'  ta bude obsahovat i despecera pro distribuci dat ve statusbaru
'
'  pro tridu bude existovat struktura StatusbarData, pro uchovani dat konkretniho statusbaru
'  promenna teto struktury je soucasti struktury odpovidajici kazdemu formulari v kolekci formularu modMain

Option Strict On

Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

''' <summary>
''' Objekt, spravujici data statusbaru
''' Zprost5edkuje zobrazeni prislusnych casti statusbaru ISP/VVM
''' </summary>
Public Class clsStatusBar
    Inherits System.ComponentModel.Component

    Friend mbVisible As Boolean
    Friend moForm As Form
    Friend moSbd As StatusBarData
    Friend moSta As StatusBar 'aktivni statusbar
    Friend moStaLoc As StatusBar 'lokalni atatusbar
    Friend moPba As ProgressBar 'progressbar
    Friend moLbl As Label 'text-label
    Friend mbMainSelected As Boolean
    Friend mbMod As Boolean = False
    Friend mLastpupdateTime As Date = Nothing

    Private pbChanged As Boolean
    Private pbAutocurs As Boolean
    Private pbAutobloc As Boolean
    Private paoEnablelist As ArrayList
    Private piAmount As Long
    Private piAmountph As Integer
    Private piPhase As Integer
    Private piPrgs As Integer

    Public Shared gaoItem As New Dictionary(Of Control, clsStatusBar)

    ''' <summary>
    ''' datovy objekt clsStatusBaru
    ''' </summary>
    Public Class StatusBarData
        Public PrgsMain As Integer 'procenta progresbdaru, nebo:-1=ready,-2=busy,-3=neaktivni,-4=nic
        Public PrgsSub As Integer
        Public Text As String
        Public StIcon As Icon
        Public StImage As Image
        Public FindBuf As String
        Public Mode As StavTyp
        Public ConnectedGrid As C1FlexGrid
        Public GridText As String
        Public TopText As Integer = 0
        Public Desc As String

        Friend aoExcludedGrids As New ArrayList   ' seznam gridù, které se nemají pøipojovat k statusbaru
        Friend aoRegisteredGrids As New ArrayList ' seznam gridù, které se mají pøipojovat k statusbaru. Je-li prázdný, probíhá automatické pøipojování

        Public Sub New()
            PrgsMain = CInt(PrgsTyp.Empty)
            PrgsSub = -1
            Mode = StavTyp.Empty
        End Sub

    End Class

    ''' <summary>
    ''' konstruktor - parametrem je formular. najde si statusbar
    ''' zapise do tabulky formularu vse,co je potreba
    ''' </summary>
    ''' <param name="MyForm"></param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal MyForm As Form = Nothing)
        MyBase.New()
        If Not MyForm Is Nothing Then
            moForm = MyForm
            mbMainSelected = False
            moSbd = New StatusBarData
            moSbd.Desc = MyForm.Name
            pbAutocurs = True
            pbAutobloc = True
            MaintainAndAddToList(MyForm)
        End If
    End Sub

    ''' <summary>
    ''' pripoji se k formulari
    ''' </summary>
    Public Sub SetForm(ByVal MyForm As Form)
        moForm = MyForm
        mbMainSelected = False
        moSbd = New StatusBarData
        moSbd.Desc = MyForm.Name
        pbAutocurs = True
        pbAutobloc = True
        MaintainAndAddToList(MyForm)
    End Sub

    ''' <summary>
    ''' varianta konstruktoru pro instanci na hlavnim formulari - nezapisuje se do tabulky formularu
    ''' </summary>
    Public Sub New(ByVal MyForm As Form, ByVal Statb As StatusBar, Optional AutoAttach As Boolean = False)
        MyBase.New()
        moForm = MyForm
        mbMainSelected = True
        moSbd = New StatusBarData
        moSbd.Desc = MyForm.Name
        moSta = Statb
        moSta.Tag = moSbd
        moStaLoc = moSta
        pbAutocurs = False
        pbAutobloc = False
        InitStatusBar(moSta)
        AddHandler moSta.DrawItem, AddressOf stbDrawItem
        MaintainAndAddToList(MyForm)
        If AutoAttach Then AttachStatusBar(Statb)
    End Sub

    ''' <summary>
    ''' propoji clsStatusbar se statusbarem a formularem
    ''' </summary>
    Public Sub SetForm(ByVal MyForm As Form, ByVal Statb As StatusBar)
        moForm = MyForm
        mbMainSelected = True
        moSbd = New StatusBarData
        moSbd.Desc = MyForm.Name
        moSta = Statb
        moSta.Tag = moSbd
        moStaLoc = moSta
        pbAutocurs = False
        pbAutobloc = False
        InitStatusBar(moSta)
        AddHandler moSta.DrawItem, AddressOf stbDrawItem
        MaintainAndAddToList(MyForm)
    End Sub

    ''' <summary>
    ''' varianta konstruktoru
    ''' </summary>
    Public Sub New(ByVal MyForm As Form, ByRef Pgbar As ProgressBar, ByRef LbPgs As Label)
        mbMod = True
        moForm = MyForm
        mbMainSelected = True
        moSbd = New StatusBarData
        moSbd.Desc = MyForm.Name
        moPba = Pgbar
        moLbl = LbPgs
        pbAutocurs = False
        pbAutobloc = False
        LbPgs.Text = ""
        Pgbar.Value = 0
        Pgbar.Minimum = 0
        Pgbar.Maximum = 100
        MaintainAndAddToList(MyForm)
    End Sub

    ''' <summary>
    ''' udrzba seznamu objektu clsStatusbar
    ''' </summary>
    Private Sub MaintainAndAddToList(Optional MyForm As Form = Nothing)
        Dim oIndexList As New List(Of Control)(gaoItem.Keys)
        For i As Integer = oIndexList.Count - 1 To 0 Step -1
            Dim oCtl As Control = oIndexList(i)
            If TypeOf (oCtl) Is Form AndAlso DirectCast(oCtl, Form).IsDisposed Then
                gaoItem.Remove(oCtl)
            End If
        Next
        'For i As Integer = gaoItem.Keys.Count - 1 To 0 Step -1
        '    Dim oCtl As Control = gaoItem.Keys(i)
        '    If TypeOf (oCtl) Is Form AndAlso DirectCast(oCtl, Form).IsDisposed Then
        '        gaoItem.Remove(oCtl)
        '    End If
        'Next
        If Not MyForm Is Nothing Then gaoItem(MyForm) = Me
    End Sub

    ''' <summary>
    ''' destruktor
    ''' </summary>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If Not moForm Is Nothing Then
            If gaoItem.ContainsKey(moForm) Then gaoItem.Remove(moForm)
            MyBase.Dispose(disposing)
        End If
    End Sub

    ''' <summary>
    ''' vrati clsStatusbar daneho formulare
    ''' </summary>
    Public Shared ReadOnly Property GetStatusBarObject(oForm As Control) As clsStatusBar
        Get
            If clsStatusBar.gaoItem.ContainsKey(oForm) Then Return clsStatusBar.gaoItem(oForm)
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property OwnerFormName() As String
        Get
            Return moForm.Name
        End Get
    End Property

    Public ReadOnly Property GetProgressTyp() As PrgsTyp
        Get
            Try
                Return DirectCast(moSbd.PrgsMain, PrgsTyp)
            Catch : End Try
            Return PrgsTyp.Empty
        End Get
    End Property

    ''' <summary>
    ''' Registruje tabulky, které se mají pøipojovat ke statusbaru
    ''' Pokud je seznam prazdny, nastavi automaticke pripojovani vsech gridu vyjma tech, ktere jsou v seznamu ExcludedGrids
    ''' </summary>
    ''' <param name="aoFg"></param>
    Public Sub RegisterGrids(ParamArray aoFg() As C1FlexGrid)
        If aoFg Is Nothing Then
            moSbd.aoRegisteredGrids.Clear()
        End If
        For Each oFg As C1FlexGrid In aoFg
            moSbd.aoRegisteredGrids.Add(oFg)
        Next
    End Sub

    ''' <summary>
    ''' Registruje tabulky, které se nemají pøipojovat ke statusbaru
    ''' Pokud je seznam prazdny, seznam se vymaze
    ''' </summary>
    ''' <param name="aoFg"></param>
    Public Sub ExcludeGrids(ParamArray aoFg() As C1FlexGrid)
        If aoFg Is Nothing Then
            moSbd.aoExcludedGrids.Clear()
        End If
        For Each oFg As C1FlexGrid In aoFg
            moSbd.aoExcludedGrids.Add(oFg)
        Next
    End Sub

    Public Sub ActivateLocalStatusbar(Optional ByVal AutoAttachFlexgrids As Boolean = True, Optional ByVal AutoFindFlexgridOnTabPage As Boolean = True)
        AttachStatusbar(, AutoFindFlexgridOnTabPage)
        If AutoAttachFlexgrids Then FlexGridsAutoConnect(moForm)
        If Not moSta Is Nothing Then moSta.Show()
    End Sub

    Public Sub AttachStatusBar(Optional ByVal Statb As StatusBar = Nothing, Optional ByVal AutoFocusGridOnTabPage As Boolean = False)
        If mbMod Then Exit Sub
        If moStaLoc Is Nothing Then
            For Each ctl As Control In XControls.ControlHelper.Helper.GetAllControls(moForm)
                If TypeOf ctl Is StatusBar Then
                    moStaLoc = DirectCast(ctl, StatusBar)
                    InitStatusBar(moStaLoc)
                    AddHandler moStaLoc.DrawItem, AddressOf stbDrawItem
                    AddHandler moForm.Activated, AddressOf FActivate
                    Exit For
                ElseIf AutoFocusGridOnTabPage AndAlso TypeOf ctl Is TabControl Then
                    With CType(ctl, TabControl)
                        AddHandler .SelectedIndexChanged, AddressOf AutoFocusGrid
                    End With
                End If
            Next
        End If
        If Statb Is Nothing Then
            moSta = moStaLoc
            moStaLoc.Visible = True
        Else
            moSta = Statb
            If (Not mbMainSelected) AndAlso (Not moStaLoc Is Nothing) Then
                moStaLoc.Tag = Nothing
                moStaLoc.Visible = False
            End If
        End If
        moSta.Tag = Me.moSbd
        If TypeOf moForm Is Form Then
            For Each ctl As Control In XControls.ControlHelper.Helper.GetAllControls(moForm)
                If TypeOf ctl Is C1FlexGrid Then
                    If ((Me.moSbd.aoRegisteredGrids.Count = 0) OrElse Me.moSbd.aoRegisteredGrids.Contains(ctl)) AndAlso (Not Me.moSbd.aoExcludedGrids.Contains(ctl)) Then
                        With DirectCast(ctl, C1FlexGrid)
                            RemoveHandler .GotFocus, AddressOf FgridGotFocus
                            RemoveHandler .LostFocus, AddressOf FgridLostFocus
                            RemoveHandler .RowColChange, AddressOf RefreshGridCounterHandler
                            AddHandler .LostFocus, AddressOf FgridLostFocus
                            AddHandler .GotFocus, AddressOf FgridGotFocus
                            AddHandler .RowColChange, AddressOf RefreshGridCounterHandler
                        End With
                    End If
                    '        _ost = directcast(ctl, StatusBar)
                    '        InitStatusBar(_ost)
                    '        AddHandler _ost.DrawItem, AddressOf stbDrawItem
                    '        AddHandler _form.Activated, AddressOf FActivate
                    '        Exit For
                End If
            Next
        End If
        Repaint()
    End Sub

    Public Sub AutoFocusGrid(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf sender Is TabControl Then
            With CType(sender, TabControl)
                If Not .SelectedTab Is Nothing Then
                    For Each ctl As Control In GetAllControls(.SelectedTab)
                        If TypeOf ctl Is C1FlexGrid Then
                            ctl.Select()
                            ctl.Focus()
                            Exit For
                        End If
                    Next
                End If
            End With
        End If
    End Sub

    'vnuceni prekresleni panelu nebo celeho statusbar(neni-li uvedeno cislo panelu)
    Public Sub Repaint(Optional ByVal PanelIndex As Integer = -1)
        If mbMod OrElse (moSta Is Nothing) OrElse PanelIndex > moSta.Panels.Count - 1 Then Exit Sub
        Try
            If moSta Is Nothing Then Exit Sub
            Dim sb As StatusBarData = DirectCast(moSta.Tag, StatusBarData)
            If PanelIndex < 0 Then
                moSta.Refresh()
                Exit Sub
            End If
            Dim rc As Rectangle
            For i As Integer = 0 To PanelIndex - 1
                rc.X += moSta.Panels(i).Width
            Next
            rc.Width = moSta.Panels(PanelIndex).Width
            rc.Y = 0
            rc.Height = moSta.Height
            moSta.Invalidate(rc)
            moSta.Update()
        Catch : End Try
        ProcessEvents()
    End Sub

    'Public Sub Initialize()
    'End Sub

    Private Property Visible() As Boolean
        Get
            Return mbVisible
        End Get
        Set(ByVal Value As Boolean)
            If mbMod Then Exit Property
            mbVisible = Value
            moSta.Visible = mbVisible
        End Set
    End Property

    'vlastnost, ktera zpusobi automaticke prepnuti kurzoru:
    'Default, je li nastaveno Prgstyp.Ready, Empty nebo Inactive, jinak WaitCursor
    Public Property AutoSetCursor() As Boolean
        Get
            Return pbAutocurs
        End Get
        Set(ByVal Value As Boolean)
            pbAutocurs = Value
        End Set
    End Property

    Public ReadOnly Property GetPhase As Integer
        Get
            Return piPhase
        End Get
    End Property

    Public ReadOnly Property GetPart As Integer
        Get
            Return piPrgs
        End Get
    End Property

    'podobne jako automaticke nastaveni kurzoru, nastavi se blokovani formulare (enabled=false)
    Public Property AutoDisable() As Boolean
        Get
            Return pbAutobloc
        End Get
        Set(ByVal Value As Boolean)
            pbAutobloc = Value
        End Set
    End Property

    'jaky je nastaven mod (prohlzeni, upravy, novy zaznam)
    Public Property Editmode() As StavTyp
        Get
            If moSbd Is Nothing Then Return StavTyp.Empty Else Return moSbd.Mode
        End Get
        Set(ByVal Value As StavTyp)
            SetMode(Value)
        End Set
    End Property

    'vlastnost se nastavi na True, pokud pri posledni zmene Progress doslo k prekresleni
    Public ReadOnly Property Changed() As Boolean
        Get
            Return pbChanged
        End Get
    End Property

    Public Sub SetProperSize(ByVal Statb As StatusBar)
        If mbMod Then Exit Sub
        StatResize(Statb, New System.EventArgs)
        Statb.Panels(0).Width = 200
        Statb.Refresh()
    End Sub

    'nastavi vychozi vlastnosti statusbaru
    Public Sub Reset()
        If mbMod Then Exit Sub
        SetFlexGrid()
        SetText("")
        SetMode(StavTyp.Empty)
        SetProgress(PrgsTyp.Empty)
    End Sub

    'nastavi mod (prohlzeni, upravy, novy zaznam)
    Public Sub SetMode(ByVal Mode As StavTyp)
        If mbMod OrElse (moSbd Is Nothing) Then Exit Sub
        Dim e As Boolean = (moSbd.Mode = Mode)
        moSbd.Mode = Mode
        Repaint(4)
    End Sub

    ''' <summary>
    ''' nastavi mod, stav a text
    ''' </summary>
    Public Sub SetMode(ByVal Mode As StavTyp, ByVal ProgressTyp As PrgsTyp, Optional ByVal DisplayText As String = vbBack, Optional bFirstCharToLower As Boolean = True, Optional bResetStdIcon As Boolean = True)
        SetMode(Mode)
        SetProgress(ProgressTyp, DisplayText, bFirstCharToLower, bResetStdIcon)
    End Sub

    'text v 2. panelu
    Public Property Text() As String
        Get
            Return moSbd.Text
        End Get
        Set(ByVal Value As String)
            moSbd.Text = Value
            SetText(Value)
        End Set
    End Property

    'nastavi text v 2. panelu a pripadne i standardni ikonu
    Public Sub SetText(ByVal DisplayText As String, Optional ByVal StdIcon As StdIcons = StdIcons.NoIcon, Optional bFirstCharToLower As Boolean = True)
        If DisplayText <> "" Then
            If DisplayText.Length >= 2 AndAlso DisplayText.Substring(0, 2) = DisplayText.Substring(0, 2).ToUpper Then bFirstCharToLower = False ' pokud text zacina dvema velkymi pismeny, nebudu prvni znak prevadet do lowercase
            DisplayText = XControls.SetFirstLetterCase(DisplayText, bFirstCharToLower)
        End If
        If mbMod Then
            moLbl.Text = DisplayText
            Exit Sub
        End If
        Dim b As Boolean = (moSbd.Text = Trim(DisplayText))
        Dim i As Boolean
        moSbd.Text = Trim(DisplayText)
        i = _SetStdIcon(StdIcon)
        If (Not b) OrElse (Not i) Then Repaint(2)
    End Sub

    'vymaze text v panelu
    Public Sub SetText()
        If mbMod Then
            moLbl.Text = ""
        End If
        moSbd.Text = ""
        _SetStdIcon(StdIcons.NoIcon)
        Repaint(2)
    End Sub

    'vrati text v panelu
    Public Function GetText() As String
        If moSbd Is Nothing Then Return "" Else Return moSbd.Text
    End Function

    'nastavi ikonu do 2. panelu
    Public Sub SetIcon(Optional ByVal Value As Icon = Nothing)
        If mbMod Then Exit Sub
        Dim b As Boolean = (moSbd.StIcon Is Value)
        moSbd.StIcon = Value
        If Not b Then Repaint(2)
    End Sub

    Public Sub FlexGridsAutoConnect(ByVal oCtl As Control, Optional ByVal Recursive As Boolean = True)
        If TypeOf oCtl Is C1FlexGrid Then FlexGridAutoConnect(DirectCast(oCtl, C1FlexGrid))
        If (Not oCtl.Controls Is Nothing) AndAlso Recursive Then
            For Each oCtl2 As Control In oCtl.Controls
                FlexGridsAutoConnect(oCtl2, Recursive)
            Next
        End If
    End Sub

    Public Sub FlexGridAutoConnect(ByVal Fgrid As C1FlexGrid)
        AddHandler Fgrid.GotFocus, AddressOf FlexGridEnter
        AddHandler Fgrid.LostFocus, AddressOf FlexGridLeave
    End Sub

    'pripoji flexgrid pro zobrazeni citacu v 5. panelu
    Public Sub SetFlexGrid(Optional ByVal Fgrid As C1FlexGrid = Nothing)
        'Try
        '    If _pbMod Then Exit Sub
        '    If (Fgrid Is Nothing) OrElse (Not (Fgrid Is _sbd.ConnectedGrid)) Then
        '        Try
        '            If Not _sbd.ConnectedGrid Is Nothing Then
        '                RemoveHandler _sbd.ConnectedGrid.RowColChange, AddressOf FgridRowColChange
        '            End If
        '            _sbd.ConnectedGrid = Nothing
        '        Catch ex As Exception
        '        End Try
        '    End If
        '    Dim b As Boolean = (_sbd.ConnectedGrid Is Fgrid)
        '    _sbd.ConnectedGrid = Fgrid
        '    _sbd.GridText = ""
        '    Repaint(5)
        '    If Not _sbd.ConnectedGrid Is Nothing Then
        '        AddHandler _sbd.ConnectedGrid.RowColChange, AddressOf FgridRowColChange
        '    End If
        '    If Not b Then
        '        FgridRowColChange(Me, New System.EventArgs) 'vyvolam aby se naplnilo
        '    End If
        'Catch ex As Exception
        '    Debug.WriteLine(ex.Message)
        'End Try
    End Sub

    Friend Sub FlexGridEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        'If (Not StatusBarIsReady(_sta)) Then Exit Sub
        'If TypeOf sender Is C1FlexGrid Then
        '    With DirectCast(sender, C1FlexGrid)
        '        Me.SetFlexGrid(sender)
        '        FgridRowColChange(sender, e)
        '    End With
        'End If
    End Sub

    Friend Sub FlexGridLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        'If (Not StatusBarIsReady(_sta)) OrElse _sbd.ConnectedGrid Is Nothing Then Exit Sub
        'If TypeOf sender Is C1FlexGrid Then
        '    With DirectCast(sender, C1FlexGrid)
        '        Me.SetFlexGrid(Nothing)
        '        _sbd.GridText = ""
        '        Repaint(5)
        '    End With
        'End If
    End Sub

    Public Sub SetCounter(Optional iCount As Integer = -1, Optional iItemIndex As Integer = -1)
        Dim s As String = ""
        If iCount > 0 Then
            If iItemIndex >= 0 Then
                s = String.Format("{0} ({1})", iItemIndex + 1, iCount)
            Else
                s = String.Format("({0})", iCount)
            End If
        End If
        moSbd.GridText = s
        Repaint(5)
    End Sub

    Private Function _SetStdIcon(ByVal StdIcon As StdIcons) As Boolean
        If mbMod Then Return False
        Dim ic As Icon = Nothing
        Dim b As Boolean
        Select Case StdIcon
            Case StdIcons.NoIcon
                ic = Nothing
                'Case StdIcons.Excel
                '    ic = My.Resources.ic_142_excel
                'Case StdIcons.Printer
                '    ic = My.Resources.ic_142_excel
        End Select
        b = (moSbd.StIcon Is ic)
        moSbd.StIcon = ic
        Return b
    End Function

    'nastavi standardni ikonu v 2. panelu
    Public Sub SetStdIcon(ByVal StdIcon As StdIcons)
        If mbMod Then Exit Sub
        If Not _SetStdIcon(StdIcon) Then Repaint(2)
    End Sub

    'definuje obsah hledaciho bufferu pro zobrazeni do 3. panelu
    Public Sub ShowFindBuf(ByVal FindBuf As String)
        If mbMod Then Exit Sub
        moSbd.FindBuf = FindBuf
        If Not Me.moSta Is Nothing Then
            If (Trim(Me.moSbd.FindBuf) <> "") And (Me.moSta.Panels(3).Width = 0) Then
                Me.moSta.Panels(3).Width = 20
                Me.moSta.Panels(3).ToolTipText = sTip3
            Else
                Me.moSta.Panels(3).ToolTipText = Nothing
            End If
            Repaint(3)
        End If
    End Sub

    'vypne zobrazeni hledaciho bufferu
    Public Sub HideFindBuf()
        If mbMod Then Exit Sub
        moSbd.FindBuf = ""
        Me.moSta.Panels(3).Width = 0
        Me.moSta.Panels(3).ToolTipText = Nothing
        Repaint(3)
    End Sub

    'nastavi progressbar v 1. panelu (hodnota je v celych procentech)
    Public Sub SetProgress(ByVal value As PrgsTyp, Optional ByVal DisplayText As String = vbBack, Optional bFirstCharToLower As Boolean = True, Optional bResetStdIcon As Boolean = True)
        If mbMod Then
            moLbl.Text = XControls.SetFirstLetterCase(DisplayText, bFirstCharToLower)
            moPba.Value = 0
            Exit Sub
        End If
        If moSbd.PrgsMain <> CInt(value) Then
            moSbd.PrgsMain = CInt(value)
            moSbd.PrgsSub = -1
            Repaint(1)
        End If

        If Not moForm Is Nothing Then
            Dim mFrm As Control = DirectCast(moForm, Control)
            While (Not mFrm Is Nothing) AndAlso (Not mFrm.Parent Is Nothing)
                mFrm = mFrm.Parent
            End While
            Select Case value
                Case PrgsTyp.Ready, PrgsTyp.Inactive, PrgsTyp.Empty
                    If pbAutocurs Then mFrm.Cursor = Cursors.Default
                    'If _autobloc Then SetCtlEnabled(True)
                Case Else
                    'If _autobloc Then SetCtlEnabled(False)
                    If pbAutocurs Then mFrm.Cursor = Cursors.WaitCursor
            End Select
        End If

        If DisplayText <> vbBack Then SetText(DisplayText, , bFirstCharToLower) Else SetText()
        If bResetStdIcon Then SetIcon()
    End Sub

    Private Sub SetCtlEnabled(ByVal Value As Boolean)
        Dim i%
        If Not Value Then
            If paoEnablelist Is Nothing Then paoEnablelist = New ArrayList
            For i = 0 To moForm.Controls.Count - 1
                If moForm.Controls(i).Enabled Then
                    moForm.Controls(i).Enabled = False
                    paoEnablelist.Add(moForm.Controls(i))
                End If
            Next
        Else
            If paoEnablelist Is Nothing Then Exit Sub
            For i = 0 To paoEnablelist.Count - 1
                DirectCast(paoEnablelist(i), Control).Enabled = True
            Next
            paoEnablelist.Clear()
        End If
    End Sub

    Public Sub SetProgress(ByVal Percent As Integer, Optional ByVal DisplayText As String = vbNullString)
        SetProgress(CLng(Percent), DisplayText)
    End Sub

    ''' <summary>
    ''' nastavi progressbar v 1. panelu (hodnota je v celych procentech) vcetne textu v 2. panelu
    ''' </summary>
    Public Sub SetProgress(ByVal Percent As Long, Optional ByVal DisplayText As String = vbNullString)
        Dim doev As Boolean = False
        If Percent < 0 Then Percent = 0
        If Percent > 100 Then Percent = 100L
        If mbMod Then
            If DisplayText <> vbNullString Then
                moLbl.Text = DisplayText
                doev = True
            End If
            pbChanged = moPba.Value <> Percent
            If Changed Then
                moPba.Value = CInt(Percent)
                doev = True
            End If
            GoTo kon
        End If
        Try
            If moSbd.PrgsMain < 0 Then SetProgress(PrgsTyp.ShowOneBar)
            pbChanged = moSbd.PrgsMain <> Percent
            If pbChanged AndAlso (Not moSta Is Nothing) Then
                moSbd.PrgsMain = CInt(Percent)
                Dim wi As Integer = DirectCast(DirectCast(moSta.Controls(0), Panel).Tag, Panel).Width
                If moSbd.PrgsMain <> wi Then
                    DirectCast(DirectCast(moSta.Controls(0), Panel).Tag, Panel).Width = moSbd.PrgsMain
                    doev = True
                End If
            End If
            If DisplayText <> vbNullString Then
                SetText(DisplayText)
                doev = True
            End If
        Catch ex As Exception
        End Try
kon:    If doev OrElse ((Me.mLastpupdateTime <> Nothing) AndAlso (Now.Subtract(Me.mLastpupdateTime).TotalSeconds >= 5)) Then
            Me.mLastpupdateTime = Now
            ProcessEvents()
        End If
    End Sub

    ''' <summary>
    ''' nastavi progressbar v 1. panelu (parametry jsou: cast, celek). mozno dodefinovat text do 2. panelu
    ''' </summary>
    Public Sub SetProgress(ByVal Counter As Integer, ByVal ProgressCount As Integer, Optional ByVal DisplayText As String = vbNullString)
        If ProgressCount >= 0 Then piAmount = ProgressCount
        If piAmount > 0 Then SetProgress(100L * CLng(Counter) \ piAmount, DisplayText)
        piPrgs = Counter
    End Sub

    'nastavi progressbar v 1. panelu (parametry jsou: cast, celek). mozno dodefinovat text do 2. panelu

    ''' <summary>
    ''' Nastavi progressbar v 1. panelu na danou hodnotu
    ''' </summary>
    Public Sub SetProgressStep(ByVal Counter As Integer, Optional ByVal DisplayText As String = vbNullString)
        SetProgress(Counter, -1, DisplayText)
    End Sub

    ''' <summary>
    ''' nastavi progressbar v 1. panelu (parametry jsou: cast, celek). mozno dodefinovat text do 2. panelu
    ''' </summary>
    Public Sub SetProgress(ByVal Counter As Long, ByVal ProgressCount As Long, Optional ByVal DisplayText As String = vbNullString)
        If ProgressCount >= 0 Then piAmount = ProgressCount
        If piAmount > 0 Then SetProgress(100 * Counter \ piAmount, DisplayText)
        piPrgs = CInt(Counter)
    End Sub

    'nastavi progressbar v 1. panelu (parametry jsou: cast, celek). mozno dodefinovat text do 2. panelu

    ''' <summary>
    ''' Nastavi progressbar v 1. panelu na danou hodnotu
    ''' </summary>
    Public Sub SetProgressStep(ByVal Counter As Long, Optional ByVal DisplayText As String = vbNullString)
        SetProgress(Counter, -1, DisplayText)
    End Sub

    ''' <summary>
    ''' Posune progressbar v 1. panelu o jeden krk
    ''' </summary>
    Public Sub NextProgress(Optional ByVal DisplayText As String = vbNullString)
        SetProgress(piPrgs + 1, -1, DisplayText)
    End Sub

    ''' <summary>
    ''' nastavi stav 2. progresbaru hodnotou poctu procent procesu
    ''' </summary>
    Public Sub SetPhase(ByVal Percent As Integer, Optional ByVal DisplayText As String = vbNullString)
        Dim doev As Boolean = False
        If mbMod Then
            If DisplayText <> vbNullString Then
                moLbl.Text = DisplayText
                doev = True
            End If
            GoTo kon
        End If
        Try
            If moSbd.PrgsSub < 0 Then SetProgress(PrgsTyp.ShowTwoBars)
            If Percent < 0 Then Percent = 0
            If Percent > 100 Then Percent = 100
            If moSbd.PrgsSub <> Percent Then
                moSbd.PrgsSub = Percent
                Dim wi As Integer = -1
                If Not (moSta Is Nothing) AndAlso moSta.Controls.Count >= 2 Then wi = DirectCast(DirectCast(moSta.Controls(1), Panel).Tag, Panel).Width
                If wi >= 0 AndAlso moSbd.PrgsSub <> wi Then
                    DirectCast(DirectCast(moSta.Controls(1), Panel).Tag, Panel).Width = moSbd.PrgsSub
                    doev = True
                End If
            End If
            If DisplayText <> vbNullString Then
                Text = DisplayText
                Repaint()
                doev = True
            End If
        Catch ex As Exception
        End Try
kon:    If doev Then ProcessEvents()
    End Sub

    ''' <summary>
    ''' nastavi stav 2. progresbaru - analogicky se SetProgress
    ''' PhaseCount - celkovy pocet fazi procesu
    ''' Counter - okamzite por. cislo faze
    ''' </summary>
    Public Sub SetPhase(ByVal Counter As Integer, ByVal PhaseCount As Integer, Optional ByVal DisplayText As String = vbNullString)
        If PhaseCount >= 0 Then piAmountph = PhaseCount
        If piAmountph > 0 Then SetPhase(100 * Counter \ piAmountph, DisplayText)
        piPhase = Counter
    End Sub

    ''' <summary>
    ''' nastavi stav 2. progresbaru - pocitadlo fazi na danou hodnotu
    ''' Counter - okamzite por. cislo faze
    ''' </summary>
    Public Sub SetPhaseStep(ByVal Counter As Integer, Optional ByVal DisplayText As String = vbNullString)
        SetPhase(Counter, piAmountph, DisplayText)
    End Sub

    ''' <summary>
    ''' nastavi stav 2. progresbaru - posune pocitadlo fazi procesu o 1
    ''' </summary>
    Public Sub NextPhase(Optional ByVal DisplayText As String = vbNullString)
        SetPhaseStep(piPhase + 1, DisplayText)
    End Sub

    ' doevents je zablokovano, aby to neresetovalo kurzor
    Private Sub ProcessEvents()
        'Application.DoEvents()
        moSta.Update()
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Friend Sub FgridGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not StatusBarIsReady(moSta) Then Exit Sub
        If sender.GetType.IsSubclassOf(GetType(C1FlexGridBase)) AndAlso ((Me.moSbd.aoRegisteredGrids.Count = 0) OrElse Me.moSbd.aoRegisteredGrids.Contains(sender)) AndAlso (Not Me.moSbd.aoExcludedGrids.Contains(sender)) Then
            moSbd.ConnectedGrid = DirectCast(sender, C1FlexGrid)
            RefreshGridCounterHandler(sender, e)
        Else
            moSbd.ConnectedGrid = Nothing
        End If
    End Sub

    '<System.Diagnostics.DebuggerStepThrough()> _
    Friend Sub FgridLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not StatusBarIsReady(moSta) Then Exit Sub
        If sender.GetType.IsSubclassOf(GetType(C1FlexGridBase)) Then
            'If TypeOf sender Is C1FlexGrid Then
            moSbd.ConnectedGrid = Nothing
            Dim s As String = ""
            If s <> moSbd.GridText OrElse moSta.Panels(5).ToolTipText <> s Then
                moSbd.GridText = s
                moSta.Panels(5).ToolTipText = s
                Repaint(5)
            End If
        End If
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Public Sub RefreshGridCounterHandler(ByVal sender As Object, Optional ByVal e As System.EventArgs = Nothing)
        If Not StatusBarIsReady(moSta) Then Exit Sub
        If sender.GetType.IsSubclassOf(GetType(C1FlexGridBase)) Then
            'If TypeOf sender Is C1FlexGrid Then
            Try
                If sender Is moSbd.ConnectedGrid AndAlso moSbd.ConnectedGrid.TopLevelControl Is moSta.TopLevelControl Then
                    RefreshGridCounter(DirectCast(sender, C1FlexGridBase))
                End If
            Catch : End Try
        End If
    End Sub

    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Sub RefreshGridCounter(ByVal Fg As C1FlexGridBase)
        If Not StatusBarIsReady(moSta) Then Exit Sub
        Dim s As String = ""
        Dim iRow As Integer = Fg.Row
        If iRow >= Fg.Rows.Fixed AndAlso iRow < Fg.Rows.Count Then
            With Fg
                If iRow >= Fg.Rows.Fixed Then
                    s = String.Format("{0} ({1})", iRow - .Rows.Fixed + 1, .Rows.Count - .Rows.Fixed)
                Else
                    s = String.Format("({0})", .Rows.Count - .Rows.Fixed)
                End If
            End With
            's = String.Format("{0} ({1})", (iRow - Fg.Rows.Fixed) + 1, Fg.Rows.Count - Fg.Rows.Fixed)
        End If
        If s <> moSbd.GridText Then
            moSbd.GridText = s
            Repaint(5)
        End If
    End Sub

    Public Sub FActivate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        moSta.Tag = moSbd
    End Sub

End Class

Public Module StatBarDrawing

    Public Enum StavTyp As Integer
        Empty = 0
        Browse = 1
        Update = 2
        NewRec = 4
    End Enum

    Public Enum PrgsTyp As Integer
        Ready = -1
        Busy = -2
        Inactive = -3
        Empty = -4
        ShowOneBar = -5
        ShowTwoBars = -6
    End Enum

    Public Enum StdIcons As Integer
        NoIcon = 1
        Excel = 2
        Printer = 3
    End Enum

    Private Const txReady As String = "pøipraven"
    Private Const txInactive As String = "neaktivní"
    Private Const txBusy As String = "v èinnosti"
    Private Const txClient As String = "formuláø:"
    Private Const txBrowse As String = "prohlížení"
    Private Const txUpdate As String = "úpravy"
    Private Const txNewRec As String = "nový záznam"
    Friend Const sTip0 As String = "Právì pøihlášený uživatel aplikace"
    Friend Const sTip1 As String = "Aktuální stav aplikace"
    Friend Const sTip3 As String = "Hledaný øetìzec znakù"
    Friend Const sTip4 As String = "Aktuální režim"
    Friend Const sTip5 As String = "Aktuální èíslo øádku a poèet øádkù(uvedeno v závorce) aktivní tabulky zobrazovaného okna"

    Private _IID As String = ""

    Public AIDtext As String = "" 'textová identifikace instance aplikace
    Public AIDcolor As Color = SystemColors.Control 'barva pozadi okenka se jmenem uzivatele
    Public AIDactive As Boolean = False

    Friend Sub stbDrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.StatusBarDrawItemEventArgs)
        Try
            Dim mstb As StatusBar = DirectCast(sender, StatusBar)
            Dim mpan As StatusBarPanel = e.Panel
            Dim msbd As clsStatusBar.StatusBarData
            Dim f1 As New Font(e.Font, FontStyle.Regular)
            Dim f2 As New Font(e.Font, FontStyle.Bold)
            Dim bo As Rectangle = e.Bounds
            Dim gr As Graphics = e.Graphics
            Dim br As Brush
            Dim pe As Pen
            Dim r1 As RectangleF
            Dim r2 As RectangleF
            Dim r3 As RectangleF
            Dim r4 As RectangleF
            Dim p1 As Boolean
            Dim p2 As Boolean
            Dim ri1 As Rectangle
            Dim st1, st2, st3, st4 As String
            Dim idx As Integer = e.Index
            Dim w As Integer
            'dim br1 as Brush=new SolidBrush(systemcolors.ac
            'Dim sz As Size
            st1 = ""
            Dim szf As SizeF
            If (Not mstb.Tag Is Nothing) AndAlso (idx > 0) Then
                msbd = DirectCast(mstb.Tag, clsStatusBar.StatusBarData)
                If msbd.TopText = 0 Then msbd.TopText = GetTopText(gr, f1, bo)
                'tady kreslim to, co je ve strukture sbd
                Select Case idx
                    Case 1
                        If msbd.PrgsMain < 0 Then
                            'Debug.WriteLine("text")
                            p1 = False
                            p2 = False
                            Select Case DirectCast(msbd.PrgsMain, PrgsTyp)
                                Case PrgsTyp.Ready
                                    st1 = txReady
                                Case PrgsTyp.Busy
                                    st1 = txBusy
                                Case PrgsTyp.Inactive
                                    st1 = txInactive
                                Case PrgsTyp.ShowOneBar
                                    p1 = True
                                    p2 = False
                                    msbd.PrgsMain = 0
                                    msbd.PrgsSub = -1
                                Case PrgsTyp.ShowTwoBars
                                    p1 = True
                                    p2 = True
                                    msbd.PrgsMain = 0
                                    msbd.PrgsSub = 0
                                Case Else
                                    st1 = ""
                            End Select
                            e.DrawBackground()
                            If mstb.Controls.Count >= 1 Then
                                DirectCast(mstb.Controls(0), Panel).Visible = p1
                                DirectCast(mstb.Controls(1), Panel).Visible = p2
                                If p1 Or p2 Then
                                    DirectCast(DirectCast(mstb.Controls(0), Panel).Tag, Panel).Width = 0
                                    DirectCast(DirectCast(mstb.Controls(1), Panel).Tag, Panel).Width = 0
                                    StatResize(mstb, New System.EventArgs)
                                End If
                            End If
                            If st1 <> "" Then
                                br = New SolidBrush(SystemColors.ControlText)
                                pe = New Pen(SystemColors.WindowText)
                                gr.DrawString(txClient, f1, br, bo.X + 1, bo.Y + msbd.TopText)
                                szf = gr.MeasureString(txClient, f1)
                                gr.DrawString(st1, f2, br, bo.X + 1 + CInt(szf.Width), bo.Y + msbd.TopText)
                                br.Dispose()
                                pe.Dispose()
                            End If
                        End If
                    Case 2
                        e.DrawBackground()
                        Dim off As Integer = 0
                        If Not msbd.StIcon Is Nothing Then
                            'If Mid(_sbd.Text, 1, 3) = "ukl" Then Debug.WriteLine("je tam ikona")
                            off = 20
                            ri1.X = bo.X + 2
                            ri1.Y = bo.Y + 1 + (bo.Height - 16) \ 2
                            ri1.Width = 16
                            ri1.Height = 16
                            gr.DrawIcon(msbd.StIcon, ri1)
                        Else
                            'If Mid(_sbd.Text, 1, 3) = "ukl" Then Debug.WriteLine("neni tam ikona")
                        End If
                        st1 = Trim(msbd.Text)
                        If st1 <> "" Then
                            br = New SolidBrush(SystemColors.ControlText)
                            gr.DrawString(st1, f1, br, bo.X + 1 + off, bo.Y + msbd.TopText)
                            br.Dispose()
                        End If
                    Case 3
                        e.DrawBackground()
                        st1 = Trim(msbd.FindBuf)
                        mstb.Panels(3).ToolTipText = If(String.IsNullOrEmpty(Trim(st1)), Nothing, sTip3)
                        If st1 <> "" Then
                            Dim s2 As SizeF = gr.MeasureString(st1, f2)
                            w = CInt(s2.Width) + 8
                            If mpan.Width <> w Then
                                mpan.Width = w
                                CalculateSizes(mstb)
                                Exit Sub 'bude se znova kreslit
                            End If
                            br = New SolidBrush(SystemColors.ControlText)
                            gr.DrawString(msbd.FindBuf, f2, br, bo.X + 1, bo.Y + msbd.TopText)
                            br.Dispose()
                        Else
                            mpan.Width = 0
                            CalculateSizes(mstb)
                            Exit Sub 'bude se znova kreslit
                        End If
                    Case 4
                        e.DrawBackground()
                        st1 = ""
                        Select Case msbd.Mode
                            Case StavTyp.Empty
                                w = bo.Height
                            Case StavTyp.Browse
                                st1 = txBrowse
                            Case StavTyp.Update
                                st1 = txUpdate
                            Case StavTyp.NewRec
                                st1 = txNewRec
                        End Select
                        mstb.Panels(4).ToolTipText = If(String.IsNullOrEmpty(Trim(st1)), Nothing, sTip4)
                        If st1 <> "" Then
                            Dim s2 As SizeF = gr.MeasureString(st1, f1)
                            w = CInt(s2.Width) + 8
                        Else
                            w = mpan.MinWidth
                        End If
                        If mpan.Width <> w Then
                            If w < mpan.MinWidth Then w = mpan.MinWidth
                            mpan.Width = w
                            CalculateSizes(mstb)
                            Exit Sub 'bude se znova kreslit
                        End If
                        br = New SolidBrush(SystemColors.ControlText)
                        gr.DrawString(st1, f1, br, bo.X + 1, bo.Y + msbd.TopText)
                        br.Dispose()
                    Case 5
                        e.DrawBackground()
                        st1 = msbd.GridText
                        mstb.Panels(5).ToolTipText = If(String.IsNullOrEmpty(Trim(st1)), Nothing, sTip5)
                        If st1 <> "" Then
                            Dim s2 As SizeF = gr.MeasureString(st1, f1)
                            w = CInt(s2.Width) + 8
                        Else
                            w = mpan.MinWidth
                        End If
                        If mpan.Width <> w Then
                            If w < mpan.MinWidth Then w = mpan.MinWidth
                            mpan.Width = w
                            CalculateSizes(mstb)
                            Exit Sub 'bude se znova kreslit
                        End If
                        br = New SolidBrush(SystemColors.ControlText)
                        gr.DrawString(st1, f1, br, bo.X + 1, bo.Y + msbd.TopText)
                        br.Dispose()
                End Select
                Exit Sub
            End If
            Select Case idx
                Case 0
                    'e.DrawBackground()
                    st1 = "uživatel:"
                    st2 = RealUserName
                    If AIDactive Then
                        st3 = "databáze:"
                        st4 = Trim(AIDtext)
                        If st4 = "" Then
                            st3 = ""
                        Else
                            If st4.Contains(":") Then
                                st4 = " " + st4 + " "
                                Dim i As Integer = st4.IndexOf(":")
                                st3 = Trim(st4.Substring(0, i)) + ": "
                                st4 = Trim(st4.Substring(i + 1))
                            End If
                        End If
                    Else
                        st3 = ""
                        st4 = ""
                    End If
                    'If AnotherPCName Then st2 += "/" + LogicalComputerName
                    If st2 = "" Then Exit Sub
                    Dim s1 As SizeF = gr.MeasureString(st1, f1)
                    Dim s2 As SizeF = gr.MeasureString(st2, f2)
                    Dim s3 As SizeF = gr.MeasureString(st3, f1)
                    Dim s4 As SizeF = gr.MeasureString(st4, f2)
                    If s2.Height > s1.Height Then s1.Height = s2.Height
                    w = CInt(s1.Width + s2.Width + s3.Width + s4.Width + 2.0 + 2.0 + 1.0 + 3.0 + 1.0)
                    If mpan.Width <> w Then
                        mpan.Width = w
                        Exit Sub 'bude se znova kreslit
                    End If
                    If AIDactive Then
                        gr.FillRectangle(New SolidBrush(AIDcolor), e.Bounds)
                        'ControlPaint.DrawBorder3D(directcast(sender, Control).CreateGraphics(), e.Bounds, Border3DStyle.Sunken)
                        gr.DrawRectangle(New Pen(Color.Black, 1.0), New Rectangle(e.Bounds.Location, Size.Add(e.Bounds.Size, New Size(-1, -1))))
                    End If
                    r1.Height = s1.Height
                    r1.X = CSng(bo.X) + 2
                    r1.Y = CSng(bo.Y) + ((CSng(bo.Height) - s1.Height) / 2)
                    r2 = r1
                    r3 = r1
                    r4 = r1
                    r2.X = r1.X + s1.Width + 1
                    r1.Width = s1.Width
                    r2.Width = s2.Width
                    r3.Height = s1.Height
                    r3.Width = s3.Width
                    r4.Height = s4.Height
                    r4.Width = s4.Width
                    r3.X = r1.X + s1.Width + 1 + s2.Width + 1
                    r4.X = r3.X + s3.Width + 1
                    gr.DrawString(st1, f1, New SolidBrush(e.ForeColor), r1)
                    gr.DrawString(st2, f2, New SolidBrush(e.ForeColor), r2)
                    gr.DrawString(st3, f1, New SolidBrush(e.ForeColor), r3)
                    gr.DrawString(st4, f2, New SolidBrush(e.ForeColor), r4)
            End Select
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function GetTopText(ByVal gr As Graphics, ByVal fo As Font, ByVal bo As Rectangle) As Integer
        Dim siz As SizeF = gr.MeasureString("Èý", fo)
        Return CInt((CSng(bo.Height) - siz.Height) / 2)
    End Function

    Public Sub InitStatusBar(ByRef StatBar As StatusBar)
        SyncLock StatBar
            'Try
            StatBar.ShowPanels = False
            StatBar.Panels.Clear()
            StatBar.Height = 22
            'Dim i%
            Dim pn As StatusBarPanel
            Dim pp As Panel
            'Dim pp2 As Panel
            pn = New StatusBarPanel
            pn.MinWidth = 10
            pn.Width = 10
            pn.Style = StatusBarPanelStyle.OwnerDraw
            pn.ToolTipText = sTip0
            StatBar.Panels.Add(pn)  ' uzivatel
            pn = New StatusBarPanel
            pn.MinWidth = 120
            pn.Width = 120
            pn.ToolTipText = sTip1
            pn.Style = StatusBarPanelStyle.OwnerDraw
            StatBar.Panels.Add(pn) 'stav aplikace
            pn = New StatusBarPanel
            pn.MinWidth = 20
            'pn.Width = 50
            pn.AutoSize = StatusBarPanelAutoSize.Spring
            pn.Style = StatusBarPanelStyle.OwnerDraw
            pn.ToolTipText = ""
            StatBar.Panels.Add(pn) ' volny text
            pn = New StatusBarPanel
            pn.MinWidth = 0
            pn.Width = 20
            pn.Style = StatusBarPanelStyle.OwnerDraw
            pn.ToolTipText = ""
            StatBar.Panels.Add(pn) ' hledany retezec znaku
            pn = New StatusBarPanel
            pn.MinWidth = 20
            pn.Width = 20
            pn.Style = StatusBarPanelStyle.OwnerDraw
            StatBar.Panels.Add(pn) ' rezim
            pn = New StatusBarPanel
            pn.MinWidth = 20
            pn.Width = 20
            pn.Style = StatusBarPanelStyle.OwnerDraw
            pn.ToolTipText = ""
            StatBar.Panels.Add(pn)
            StatBar.ShowPanels = True
            Dim bCheckCross As Boolean = Control.CheckForIllegalCrossThreadCalls
            Control.CheckForIllegalCrossThreadCalls = False
            Try
                pp = CreateProgressPanel()
                StatBar.Controls.Add(pp) 'hlavni
                pp = CreateProgressPanel()
                StatBar.Controls.Add(pp) 'vedlejsi
            Catch ex As Exception
                Throw New Exception("Chyba - inicializace statusbaru z ciziho threadu")
            End Try
            Control.CheckForIllegalCrossThreadCalls = bCheckCross
            AddHandler StatBar.Resize, AddressOf StatResize
            'Catch ex As Exception
            '    Debug.WriteLine(ex.Message)
            'End Try
        End SyncLock
    End Sub

    Private Function CreateProgressPanel() As Panel
        Dim pp As Panel = New Panel
        pp.BackColor = SystemColors.Window
        pp.BorderStyle = BorderStyle.FixedSingle
        Dim pp1 As New Panel
        With pp1
            .BackColor = SystemColors.Highlight
            .Dock = DockStyle.Left
            .Width = 0
            .Visible = True
        End With
        pp.Visible = False
        pp.Controls.Add(pp1)
        pp.Tag = pp1
        Return pp
    End Function

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal msg As Int32, ByVal wParam As Int32, ByRef lParam As RECT) As Long
    Private Const WM_USER As Long = &H400
    Private Const SB_GETRECT As Long = (WM_USER + 10)
    ' RECT structure to get the panel's display rectangle
    Private Structure RECT
        Friend Left As Int32
        Friend Top As Int32
        Friend Right As Int32
        Friend Bottom As Int32
    End Structure

    Friend Sub StatResize(ByVal sender As Object, ByVal e As System.EventArgs)
        SyncLock sender
            Try
                Dim Rectangle As RECT
                ' Use the API to get the panel's display rectangle
                Dim sb As StatusBar = DirectCast(sender, StatusBar)
                SendMessage(DirectCast(sender, StatusBar).Handle.ToInt32, SB_GETRECT, 1, Rectangle)
                ' Resize
                Const margin As Integer = 3
                Dim p1 As Panel = DirectCast(DirectCast(sender, StatusBar).Controls(0), Panel)
                Dim p2 As Panel = DirectCast(DirectCast(sender, StatusBar).Controls(1), Panel)
                With p1
                    .Left = Rectangle.Left + margin
                    .Top = Rectangle.Top + margin
                    If p2.Visible Then
                        .Height = ((Rectangle.Bottom - Rectangle.Top - 2 * margin) \ 2)
                    Else
                        .Height = Rectangle.Bottom - Rectangle.Top - 2 * margin
                    End If
                    .Width = Rectangle.Right - Rectangle.Left - 2 * margin
                End With
                If p2.Visible Then
                    With p2
                        .Location = p1.Location
                        .Size = p1.Size
                        .Top = .Top + .Height + 1
                    End With
                End If
                CalculateSizes(sb)
            Catch ex As Exception
            End Try
        End SyncLock
    End Sub

    Friend Function StatusBarIsReady(ByVal sb As StatusBar) As Boolean
        Return (Not sb Is Nothing) AndAlso (Not sb.Panels Is Nothing) AndAlso (DirectCast(sb.Panels, ICollection).Count >= 6)
    End Function

    Friend Sub CalculateSizes(ByRef sb As StatusBar)
        If sb.Panels.Count >= 3 AndAlso sb.Tag Is Nothing Then
            If sb.Panels(2).AutoSize <> StatusBarPanelAutoSize.Spring Then sb.Panels(2).AutoSize = StatusBarPanelAutoSize.Spring
            Dim oCtl As Control = sb
            While Not oCtl.Parent Is Nothing
                oCtl = oCtl.Parent
            End While
            Dim bMax As Boolean = (TypeOf oCtl Is Form) AndAlso DirectCast(oCtl, Form).WindowState = FormWindowState.Maximized
            If sb.SizingGrip <> (Not bMax) Then sb.SizingGrip = Not bMax
            sb.Tag = True
        End If
    End Sub

    'Private Sub DumpSizes(ByRef sb As StatusBar)
    '    Debug.WriteLine("---- Statusbar" & _IID & vbTab & sb.Size.ToString)
    '    Dim ii As Integer = 0
    '    For i As Integer = 0 To sb.Panels.Count - 1
    '        ii += sb.Panels(i).Width
    '        Debug.WriteLine(i & vbTab & sb.Panels(i).Width.ToString & vbTab & sb.Panels(i).Style.ToString & vbTab & ii & vbTab & sb.Panels(i).Text)
    '    Next
    'End Sub

    Public Const txInstance As String = "InstanceAplikace"
    Public Sub SetInstanceID(ByVal Conn1 As SqlConnection, ByVal Conn2 As SqlConnection, ByVal Conn3 As SqlConnection)
        _IID = "InstanceID."
        If Not Conn1 Is Nothing Then _IID += Conn1.DataSource.ToString + "/" + Conn1.Database.ToString + "."
        If Not Conn2 Is Nothing Then _IID += Conn2.DataSource.ToString + "/" + Conn2.Database.ToString + "."
        If Not Conn3 Is Nothing Then _IID += Conn3.DataSource.ToString + "/" + Conn3.Database.ToString + "."
        SetInstanceID()
    End Sub

    Public Sub SetInstanceID()
        Dim s As String
        Try
            s = StringRestore(_IID + "color", txInstance)
            If s <> "" AndAlso IsNumeric(s) Then
                AIDcolor = Color.FromArgb(CInt(s))
            End If
            AIDtext = StringRestore(_IID + "text", txInstance)
            AIDactive = BooleanRestore(_IID + "active", txInstance)
        Catch ex As Exception
        End Try
        For Each oBar As clsStatusBar In clsStatusBar.gaoItem.Values
            oBar.Repaint()
        Next
    End Sub

    Public Function GetInstanceID() As String
        Return _IID
    End Function

    Public Sub WriteInstanceID(ByVal Text As String, ByVal Barva As Color, ShowIt As Boolean, Optional RefreshImmediately As Boolean = True)
        StringSave(_IID + "text", Text, txInstance)
        StringSave(_IID + "color", Barva.ToArgb.ToString, txInstance)
        BooleanSave(_IID + "active", ShowIt, txInstance)
        If RefreshImmediately Then SetInstanceID()
        SaveSettingsToDB(Nothing)
    End Sub

End Module

