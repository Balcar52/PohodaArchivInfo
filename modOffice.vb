'Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Module modOffice

    Public oWsh1 As Excel.Worksheet = Nothing
    Public oWsh2 As Excel.Worksheet = Nothing
    Public oWsh3 As Excel.Worksheet = Nothing
    Public oWsh4 As Excel.Worksheet = Nothing

    Public oEx As Excel.Application
    Public aiIdMyExcel As New List(Of Integer)
    Public oProc As Process = Nothing
    Public oWbk As Excel.Workbook = Nothing

    Public oCurrentWsh As Excel.Worksheet = Nothing

    Public Const txExcelExporting As String = "Probíhají úpravy v listu aplikace MS Excel"
    Public Const txExcelFormatting As String = "Probíhá formátování listu aplikace MS Excel"
    Public txRFmt As String = "{0}:{0}"

    Public Values(,) As Object
    Public iValRowOff As Integer = 0
    Public iValColOff As Integer = 0

    Public ExcelProcessId As IntPtr

    <DllImport("user32.dll", SetLastError:=True)>
    Private Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, ByRef lpdwProcessId As IntPtr) As IntPtr : End Function

    ''' <summary> odkaz na defaultni - current worksheet </summary>
    Public Function oCsh() As Excel.Worksheet
        Return oCurrentWsh
    End Function

    ''' <summary> nastavi worksheet jako current - soucasny </summary>
    Public Sub SetCurrentSheet(Optional moWsh As Excel.Worksheet = Nothing, Optional bShowGrid As Boolean = False)
        oCurrentWsh = If(moWsh Is Nothing, oWsh1, moWsh)
        ShowGrid(bShowGrid)
    End Sub

    ''' <summary> fyzicky prvni worksheet </summary>
    Public Function oWs() As Excel.Worksheet
        Return oWsh1
    End Function

    ''' <summary> fyzicky prvni worksheet (kvuli jiz napsanym historickym kodum)</summary>
    Public Function oWsh() As Excel.Worksheet
        Return oWsh1
    End Function

    ''' <summary> vytvoreni instance Excelu a jeho zobrazeni </summary>
    ''' <param name="HardHidden"></param>
    ''' <param name="HardVisible"></param>
    ''' <param name="DisplayAlerts"></param>
    ''' <param name="SecondScreen"></param>
    Public Function CreateExcel(Optional HardHidden As Boolean = False, Optional HardVisible As Boolean = False, Optional DisplayAlerts As Boolean = True, Optional SecondScreen As Boolean = True) As Excel.Application
        CloseAllWorkbooks()
        Dim aiExc As New List(Of Integer)
        For Each oPr As Process In Process.GetProcesses
            If oPr.ProcessName.ToLower.Contains("excel") Then aiExc.Add(oPr.Id)
        Next
        oEx = New Excel.Application
        For Each oPr As Process In Process.GetProcesses
            If oPr.ProcessName.ToLower.Contains("excel") AndAlso Not aiExc.Contains(oPr.Id) Then
                aiIdMyExcel.Add(oPr.Id) ' proces, ktery jsem prave spustil
            End If
        Next
#If CMD Then
#Else
        SetExcelWindow(iUsr.chShowOn2ndScreen.Checked)
        If HardHidden Then
            oEx.Visible = False
        Else
            oEx.Visible = iUsr.ShowExcel OrElse iUsr.DebugVersion OrElse HardVisible
        End If
#End If
        DisplayExcelAlerts(DisplayAlerts)
        ScreenUpdatingExcel(oEx.Visible)
        CheckingNumberAsText(False)
        GetWindowThreadProcessId(CType(oEx.Application.Hwnd, IntPtr), ExcelProcessId)
        Return oEx
    End Function

    ''' <summary> vypne/zapne zobrazovani chyb a upozorneni v Excelu </summary>
    ''' <param name="ShowThem"></param>
    Public Function DisplayExcelAlerts(Optional ShowThem As Boolean = True) As Boolean
        Dim bRet As Boolean = False
        If TypeOf oEx Is Excel.Application Then
            bRet = (oEx.Application.DisplayAlerts <> ShowThem)
            If bRet Then oEx.Application.DisplayAlerts = ShowThem
        End If
        Return bRet
    End Function

    Public Sub ShowGrid(Optional bShowGrid As Boolean = False)
        If oEx IsNot Nothing AndAlso oEx.ActiveWindow IsNot Nothing Then
            oEx.ActiveWindow.DisplayGridlines = bShowGrid
        End If
    End Sub

    ''' <summary> zapne/vypne refresh Excelu </summary>
    ''' <param name="Value"></param>
    Public Function ScreenUpdatingExcel(Optional Value As Boolean = True) As Boolean
        Dim bRet As Boolean = False
        If TypeOf oEx Is Excel.Application Then
            bRet = (oEx.Application.ScreenUpdating <> Value)
            oEx.Application.ScreenUpdating = Value
        End If
        Return bRet
    End Function

    ''' <summary> vypne nebo zapne upozorneni, ze cislo je ulozeno jako text  </summary>
    ''' <param name="bValue"></param>
    Public Sub CheckingNumberAsText(bValue As Boolean)
        oEx.Application.ErrorCheckingOptions.NumberAsText = bValue
    End Sub

    ''' <summary> zobrazi Excel </summary>
    Public Function ShowExcel(Optional ClearStatusBar As Boolean = True, Optional bShowGrid As Boolean = False, Optional bFocusExcel As Boolean = True) As Boolean
#If Not CMD Then
        If TypeOf oEx Is Excel.Application Then
            oEx.Visible = True
            oEx.ScreenUpdating = True
            If ClearStatusBar Then oEx.StatusBar = Nothing
            ShowGrid(bShowGrid)
            If bFocusExcel Then FocusWindow(oEx.Hwnd)
            Return True
        End If
#End If
        Return False
    End Function

    Public Function FocusExcel() As Boolean
#If Not CMD Then
        If TypeOf oEx Is Excel.Application Then
            oEx.Visible = True
            oEx.ScreenUpdating = True
            FocusWindow(oEx.Hwnd)
            Return True
        End If
#End If
        Return False
    End Function

    ''' <summary> Zavre Excel. Soucasne zavre vsechny workbooks BEZ ULOZENI !</summary>
    Public Function CloseExcel() As Boolean
        Try
            If TypeOf oEx Is Excel.Application Then
                CloseAllWorkbooks()
                oEx.Application.Quit()
                oEx = Nothing
            End If
            Try
                For Each oPr As Process In Process.GetProcesses
                    If aiIdMyExcel.Contains(oPr.Id) Then
                        Try
                            oPr.Kill()
                            aiIdMyExcel.Remove(oPr.Id)
                            Debug.WriteLine("Kill process " & oPr.ProcessName & " OK.")
                        Catch : End Try
                    End If
                Next
            Catch ex As System.Exception
                Debug.WriteLine("Kill My Excels: " & ex.Message)
            End Try
            Return True
        Catch ex As System.Exception
            Dim sErr = " " & UCase(ex.Message)
            If sErr.Contains("HRESULT") AndAlso (sErr.Contains("0x80010001") OrElse sErr.Contains("REJECTED")) Then Return True ' nevyznamna chyba - nic nehlasim
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
        Return False
    End Function

    ''' <summary> zavre vsechny workbooks BEZ ULOZENI !</summary>
    Public Function CloseAllWorkbooks() As Boolean
        Dim bRes As Boolean = False
        Try
            If TypeOf oEx Is Excel.Application Then
                If oEx.Workbooks.Count > 0 Then
                    For i As Integer = oEx.Workbooks.Count To 1 Step -1
                        oEx.Workbooks(i).Saved = True
                        oEx.Workbooks(i).Close()
                        bRes = True
                    Next
                End If
                oWbk = Nothing
                oWsh1 = Nothing
                oWsh2 = Nothing
                oWsh3 = Nothing
                oWsh4 = Nothing
            End If
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return bRes
    End Function

    ''' <summary> otevre existujici tabulku Excel JEN CTENI </summary>
    ''' <param name="sFilename"></param>
    Public Function OpenReadOnlyWorkBook(sFilename As String, Optional bShowGrid As Boolean = False) As Boolean
        Return OpenWorkBook(sFilename, True, bShowGrid)
    End Function

    Public Function OpenWorkBook(sFilename As String, Optional [ReadOnly] As Boolean = False, Optional bShowGrid As Boolean = False) As Boolean
        If oEx Is Nothing Then CreateExcel()
        Dim bRet As Boolean = False
        Try
            oEx.Workbooks.Open(sFilename,, [ReadOnly])
            oEx.WindowState = Excel.XlWindowState.xlNormal
            bRet = SetWorkSheets(bShowGrid)
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            bRet = False
        End Try
        Return bRet
    End Function

    ''' <summary> ulozi workbook jako... </summary>
    ''' <param name="sFilename"></param>
    ''' <param name="DeleteExisting"></param>
    ''' <param name="mCloseAndQuitExcel"></param>
    ''' <param name="mExclusiveAcces"></param>
    ''' <returns></returns>
    Public Function SaveWorkBookAs(sFilename As String, Optional DeleteExisting As Boolean = True, Optional mCloseAndQuitExcel As Boolean = True, Optional mExclusiveAcces As Boolean = False) As Boolean
        Try
            If DeleteExisting AndAlso IO.File.Exists(sFilename) Then IO.File.Delete(sFilename)
            DisplayExcelAlerts(True)
            oEx.ActiveWorkbook.SaveAs(sFilename, xlExcelFileType,,,,, If(mExclusiveAcces, Excel.XlSaveAsAccessMode.xlExclusive, Excel.XlSaveAsAccessMode.xlShared))
            oEx.Application.ActiveWorkbook.Saved = True
            If mCloseAndQuitExcel Then CloseExcel()
            Return True
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    ''' <summary> ulozi aktivni list jako PDF soubor </summary>
    Public Function SaveWorkSheetToPDF(sFilename As String, Optional DeleteExisting As Boolean = True, Optional mCloseAndQuitExcel As Boolean = True) As Boolean
        Return SaveWorkSheetToPDF(oCurrentWsh, sFilename, DeleteExisting, mCloseAndQuitExcel)
    End Function

    ''' <summary> zobarzi text do stavoveho radku. Muze byt formatovan argumenty </summary>
    ''' <param name="Text"></param>
    ''' <param name="Arguments"></param>
    Public Sub ExcelStatusBarMessage(Text As String, ParamArray Arguments() As String)
        oEx.Application.StatusBar = String.Format(Text, Arguments)
    End Sub

    ''' <summary> ulozi list jako PDF soubor </summary>
    ''' <param name="oWsh"></param>
    ''' <param name="sFilename"></param>
    ''' <param name="DeleteExisting"></param>
    ''' <param name="mCloseAndQuitExcel"></param>
    Public Function SaveWorkSheetToPDF(oWsh As Excel.Worksheet, sFilename As String, Optional DeleteExisting As Boolean = True, Optional mCloseAndQuitExcel As Boolean = True) As Boolean
        Try
            If DeleteExisting AndAlso IO.File.Exists(sFilename) Then IO.File.Delete(sFilename)
            oWsh.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, sFilename)
            If mCloseAndQuitExcel Then CloseExcel()
            Return True
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    ''' <summary> otevrit sablobu</summary>
    ''' <param name="sFilename">jmeno sablony</param>
    ''' <param name="GetFromResource">True znamena, ze se bude hledat v resources a ulozi se potom do tempdir</param>
    Public Function AddWorkBook(sFilename As String, Optional GetFromResource As Boolean = False, Optional TryLocal As Boolean = True, Optional bShowgrid As Boolean = False, Optional bSetWorksheets As Boolean = True) As Boolean
        If oEx Is Nothing Then CreateExcel()
        Dim bRet As Boolean = False
        Try
            If TryLocal Then
                ' dam moznost podhodit sablonu lokalne - jen pro mimoradne potreby
                Dim sLocalFilename As String = IO.Path.GetDirectoryName(ExePath)
                sLocalFilename = IO.Path.Combine(sLocalFilename, sFilename)
                If IO.File.Exists(sLocalFilename) Then
                    GetFromResource = False
                    sFilename = sLocalFilename
                End If
            End If
            If GetFromResource Then
                oEx.Workbooks.Add(GetResourceFileByTemporary(sFilename))
            Else
                oEx.Workbooks.Add(sFilename)
            End If
            bRet = If(bSetWorksheets, SetWorkSheets(bShowgrid), True)
        Catch ex As System.Exception
            iLog.ErrLogMsg(ex, sFilename)
            bRet = False
        End Try
        Return bRet
    End Function


    ''' <summary> test, jestli je Excel otevren </summary>
    ''' <param name="CheckWorkbookIsOpened"></param>
    Public Function ExcelActive(Optional CheckWorkbookIsOpened As Boolean = True) As Boolean
        If oEx IsNot Nothing AndAlso TypeOf oEx Is Excel.Application Then
            If CheckWorkbookIsOpened AndAlso oEx.Workbooks.Count > 0 Then Return True
            Return True
        End If
        Return False
    End Function

    ''' <summary> nalezeni listu. Test, jesli exisuje a vraceni reference </summary>
    ''' <param name="sSheetName"></param>
    ''' <param name="oSh"></param>
    Public Function TestWorkSheetExists(sSheetName As String, Optional ByRef oSh As Excel.Worksheet = Nothing, Optional SelectIt As Boolean = False, Optional bScrollToBegin As Boolean = True) As Boolean
        If ExcelActive(True) Then
            oSh = CType(oWbk.Sheets(sSheetName), Excel.Worksheet)
            If SelectIt AndAlso oSh IsNot Nothing Then
                oSh.Select()
                If bScrollToBegin Then ScrollToBegin()
            End If
            Return oSh IsNot Nothing
        End If
        Return False
    End Function

    ''' <summary> zarolovani na zacatek </summary>
    Public Function ScrollToBegin() As Boolean
        Return ScrollTo(1, 1)
    End Function

    ''' <summary> zarolovani na dany radek,sloupec </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iCol"></param>
    Public Function ScrollTo(Optional iRow As Integer = 0, Optional iCol As Integer = 0) As Boolean
        Dim bRet As Boolean = False
        If ExcelActive(True) Then
            If iRow > 0 Then
                oEx.ActiveWindow.ScrollRow = iRow
                bRet = True
            End If
            If iCol > 0 Then
                oEx.ActiveWindow.ScrollColumn = iCol
                bRet = True
            End If
        End If
        Return bRet
    End Function

    ''' <summary> odstraneni listu z workbooku </summary>
    ''' <param name="oSh"> ktery worksheet ma byt vymazan </param>
    Public Function DeleteWorkSheet(Optional ByRef oSh As Excel.Worksheet = Nothing) As Boolean
        Try
            If oSh Is Nothing Then oSh = oWsh()
            If oSh IsNot Nothing Then
                oSh.Delete()
                Return True
            End If
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function


    ''' <summary> odstraneni listu z workbooku </summary>
    ''' <param name="sSheetName"> jmeno listu </param>
    ''' <returns></returns>
    Public Function DeleteWorkSheet(sSheetName As String) As Boolean
        Try
            If TestWorkSheetExists(sSheetName, oCurrentWsh) Then
                DeleteWorkSheet(oCurrentWsh)
                SetWorkSheets()
                Return True
            End If
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function DeleteWorkSheetsExcept(sSheetName As String, Optional bShowGrid As Boolean = False) As Boolean
        Dim bRet As Boolean = False
        Dim bOldAlerts As Boolean = oEx.Application.DisplayAlerts
        Try
            oEx.Application.DisplayAlerts = False ' nektere verze excelu zobrazuji dotaz pred odstranenim listu - takhle to vypnu
            For i As Integer = oWbk.Worksheets.Count To 1 Step -1
                Dim sName As String = CType(oWbk.Worksheets(i), Excel.Worksheet).Name
                If String.Compare(sName, sSheetName, True) <> 0 Then
                    DeleteWorkSheet(CType(oWbk.Worksheets(i), Excel.Worksheet))
                    bRet = True
                End If
            Next
            SetWorkSheets()
            SetCurrentSheet(, bShowGrid)
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        Finally
            oEx.Application.DisplayAlerts = bOldAlerts
        End Try
        Return bRet
    End Function

    ''' <summary> nastaveni odkazů na listy (treba po otevreni workbooku) </summary>
    Private Function SetWorkSheets(Optional bShowGrid As Boolean = False) As Boolean
        Dim bRet As Boolean = False
        Try
            oWbk = oEx.Workbooks(1)
            oWsh1 = Nothing
            oWsh2 = Nothing
            oWsh3 = Nothing
            oWsh4 = Nothing
            For i As Integer = 1 To oEx.Workbooks(1).Worksheets.Count
                bRet = True
                Select Case i
                    Case 1
                        oWsh1 = CType(oWbk.Worksheets(i), Excel.Worksheet)
                        SetCurrentSheet(oWsh1)
                    Case 2
                        oWsh2 = CType(oWbk.Worksheets(i), Excel.Worksheet)
                    Case 3
                        oWsh3 = CType(oWbk.Worksheets(i), Excel.Worksheet)
                    Case 4
                        oWsh4 = CType(oWbk.Worksheets(i), Excel.Worksheet)
                End Select
            Next
            ShowGrid(bShowGrid)
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
        Return bRet
    End Function

    Public Function ReplaceWorkSheetReferenceName(Optional ByRef oSh As Excel.Worksheet = Nothing, Optional sName As String = "", Optional sReference As String = "") As Boolean
        Dim bRet As Boolean = False
        Try
            If oSh Is Nothing Then oSh = oWsh()
            If oSh IsNot Nothing Then
                Debug.WriteLine(CStr(oSh.Names.Count))
                For i As Integer = 1 To oSh.Names.Count
                    If String.Compare(CStr(oSh.Names.Item(i).Name), sName, True) = 0 Then
                        oSh.Names.Item(i).Delete()
                        bRet = True
                        Exit For
                    End If
                Next
                If Not String.IsNullOrWhiteSpace(sReference) Then
                    oSh.Names.Add(sName, sReference)
                    bRet = True
                End If
            End If
        Catch ex As System.Exception
            MsgBox("Excel:" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bRet
    End Function

    Public iExcRow1 As Integer = 0
    Public iExcMaxRow As Integer = 0
    Public iExcMaxCol As Integer = 0

    ''' <summary> sirka sloupce v points </summary>
    ''' <param name="iCol"></param>
    ''' <returns></returns>
    Public Function GetColWidthInPoints(iCol As Integer) As Double
        If iCol < 0 Then iCol = -iCol
        Dim dblLeft As Double = CDbl(CType(oCsh.Columns(iCol), Excel.Range).Left)
        Dim dblLeft1 As Double = CDbl(CType(oCsh.Columns(iCol + 1), Excel.Range).Left)
        Return dblLeft1 - dblLeft - 0.1
    End Function

    Public UnitWidthInPoints As Double = Double.MinValue

    Public Function GetUnitWidthInPoints(Optional iUseCol As Integer = 10) As Double
        If UnitWidthInPoints = Double.MinValue Then
            Dim dblLeft As Double = CDbl(CType(oCsh.Columns(iUseCol), Excel.Range).Left)
            Dim dblLeft1 As Double = CDbl(CType(oCsh.Columns(iUseCol + 1), Excel.Range).Left)
            Dim dblUnits As Double = CDbl(CType(oCsh.Columns(iUseCol), Excel.Range).ColumnWidth)
            UnitWidthInPoints = (dblLeft1 - dblLeft - 0.1) / dblUnits
        End If
        Return UnitWidthInPoints
    End Function


    ''' <summary> nastaveni sirky sloupce v bodech </summary>
    ''' <param name="iCol"></param>
    ''' <param name="dblNewWidth"></param>
    Public Sub SetColWidthInPoints(iCol As Integer, dblNewWidth As Double)
        If iCol < 0 Then iCol = -iCol
        'Dim dbl1 As Double = CSng(CType(oCsh.Columns(iCol), Excel.Range).Width)
        'Dim dbl2 As Double = GetColWidthInPoints(iCol) / CSng(CType(oCsh.Columns(iCol), Excel.Range).Width) 'pocet bodu jedne jednotky(sirky znaku 0 Arial)
        CType(oCsh.Columns(iCol), Excel.Range).ColumnWidth = dblNewWidth / GetUnitWidthInPoints()
    End Sub

    ''' <summary> adjustace sirek sloupcu </summary>
    ''' <param name="WidthCm"> cilova sirka stranky v centimetrech </param>
    ''' <param name="aiCols"> seznam cisel sloupcu - kladne cislo - autosize, zaporne cislo - autosize a nasledne rozsireni sloupce na danou sirku stranky </param>
    Public Sub AdjutsColsToPage(WidthCm As Double, ParamArray aiCols() As Integer)
        AdjutsColsToPage(iExcRow1, iExcMaxRow, WidthCm, aiCols)
    End Sub

    ''' <summary> nastaveni sirek sloupcu (v jednotkach - cca sirka jednoho znaku) </summary>
    ''' <param name="Widths"></param>
    Public Sub SetColWidths(ParamArray Widths() As Single)
        Dim iCol As Integer = 0
        For Each iWidth As Single In Widths
            iCol += 1
            If iWidth >= 0 Then CType(oCsh.Columns(iCol), Excel.Range).ColumnWidth = iWidth
        Next
    End Sub

    ''' <summary> adjustace sirek sloupcu </summary>
    ''' <param name="iRow1"></param>
    ''' <param name="iRowN"></param>
    ''' <param name="WidthCm"></param>
    ''' <param name="aiCols"></param>
    Public Sub AdjutsColsToPage(iRow1 As Integer, iRowN As Integer, WidthCm As Double, ParamArray aiCols() As Integer)
        Dim iAdjusts As Integer = 0
        Dim sngPoints As Double = oEx.Application.CentimetersToPoints(WidthCm)
        For Each iCol As Integer In aiCols
            Dim iColP As Integer = Math.Abs(iCol)
            ColumnsAutoFit(iColP)
            sngPoints -= GetColWidthInPoints(iColP)
            If iCol < 0 Then iAdjusts += 1
        Next
        sngPoints = sngPoints / iAdjusts
        For Each iCol As Integer In aiCols
            If iCol < 0 Then
                Dim dblWid As Double = GetColWidthInPoints(iCol)
                SetColWidthInPoints(iCol, dblWid + sngPoints)
            End If
        Next
    End Sub

    Private sLogoFilename As String = ""
    ''' <summary> Nastaveni standardniho zahlavi a zapati </summary>
    Public Sub SetStandardHeader(oWsh As Excel.Worksheet, CenterHeader As String, Optional RightHeader As String = "Informační systém ISOB", Optional LandScape As Boolean = True, Optional HeaderRowCount As Integer = -1, Optional HeaderFontSize As Integer = 13, Optional HeaderFontSmallSize As Integer = 10, Optional IncludeLogo As Boolean = True)
        With oWsh
            .Range(.Cells(1, 1), .Cells(1, 1)).Select()
        End With
        With oWsh.PageSetup
            If IncludeLogo Then
                If String.IsNullOrWhiteSpace(sLogoFilename) Then sLogoFilename = GetResourceFileByTemporary(txLogoFileName2)
                'Dim sImageFilename As String = IO.Path.GetDirectoryName(Application.ExecutablePath)
                'sImageFilename = IO.Path.Combine(sImageFilename, txLogoFileName2)
                If IO.File.Exists(sLogoFilename) Then
                    .LeftHeaderPicture.Filename = sLogoFilename
                    .LeftHeaderPicture.Height = 25
                End If
                '.LeftHeaderPicture.Height = 15.75
                '.LeftHeaderPicture.Width = 15.75
            End If
            .LeftHeader = "&G"
            '.CenterHeader = "&""Tahoma,Tuèné""&12" & CenterHeader
            .CenterHeader = "" & vbLf & String.Format("&""Tahoma,Tučné""&{0} {1} ", HeaderFontSize, Trim(CenterHeader))
            .RightHeader = RightHeader
            'datum vpravo
            '.LeftFooter = String.Format("&{0}{3} {1} / {2}", HeaderFontSmallSize, Environment.MachineName, Environment.UserName, "ISOB " & GetAssemblyVersion(System.Reflection.Assembly.GetExecutingAssembly, "v.:"))
            '.RightFooter = String.Format("&{0}&D &T" & Chr(10) & "strana &P / &N", HeaderFontSmallSize)
            'datum vlevo
            .LeftFooter = String.Format("&{0}&D &T" & Chr(10) & "{3} {1} / {2}", HeaderFontSmallSize, Environment.MachineName, Environment.UserName, "ISOB " & GetAssemblyVersion(System.Reflection.Assembly.GetExecutingAssembly, "v.:"))
            .RightFooter = String.Format("&{0}strana &P / &N", HeaderFontSmallSize)
            .Orientation = If(LandScape, Excel.XlPageOrientation.xlLandscape, Excel.XlPageOrientation.xlPortrait)
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = False
            If HeaderRowCount = 0 Then
                .PrintTitleRows = ""
            ElseIf HeaderRowCount > 0 Then
                .PrintTitleRows = String.Format("${0}:${1}", 1, HeaderRowCount)
            End If
        End With
    End Sub

    Public Function HeaderFontSetting(Optional iSize As Integer = 12, Optional bBold As Boolean = True, Optional bItalic As Boolean = False) As String
        Dim sVal As String = ""
        If bBold Then
            sVal &= "&B"
        ElseIf bItalic Then
            sVal &= "&I"
        End If
        If iSize > 0 Then sVal &= "&" & iSize
        Return sVal & " "
    End Function

    Public Function HeaderString(Text As String, Optional iSize As Integer = 12, Optional bBold As Boolean = True, Optional bItalic As Boolean = False) As String
        Return HeaderFontSetting(iSize, bBold, bItalic) & Text & HeaderFontSetting(-1, bBold, bItalic)
    End Function

    ''' <summary> radek s teckami pro podpis </summary>
    ''' <param name="oWsh"></param>
    ''' <param name="iRow"></param>
    ''' <param name="LowerText"></param>
    ''' <param name="PointCount"></param>
    ''' <param name="OffsetCm"></param>
    ''' <param name="WidthCm"></param>
    ''' <param name="HeightCm"></param>
    Public Sub SetLineForSignature(oWsh As Excel.Worksheet, iRow As Integer, LowerText As String, Optional PointCount As Integer = 50, Optional OffsetCm As Single = 0, Optional WidthCm As Single = 5.5, Optional HeightCm As Single = 2.5)
        Dim txPoints As String = "".PadRight(PointCount, "."c)
        Dim oRg As Excel.Range = ExcelRange(iRow, 1)
        Dim sng1 As Single = CSng(oRg.Left)
        With oWsh1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
                                     CSng(oRg.Left) + CSng(oEx.Application.CentimetersToPoints(OffsetCm)), CSng(oRg.Top), CSng(oEx.Application.CentimetersToPoints(WidthCm)), CSng(oEx.Application.CentimetersToPoints(HeightCm)))
            .Placement = Excel.XlPlacement.xlFreeFloating
            .TextFrame2.TextRange.Characters.Text = txPoints & vbCr & LowerText
            .TextFrame2.TextRange.ParagraphFormat.Alignment = Microsoft.Office.Core.MsoParagraphAlignment.msoAlignCenter
            .Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse
            .Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse
        End With
    End Sub

    '''' <summary> radek s teckami pro podpis </summary>
    '''' <param name="oWsh"></param>
    '''' <param name="iRow"></param>
    '''' <param name="iCol"></param>
    '''' <param name="LowerText"></param>
    '''' <param name="ToLeft"></param>
    '''' <param name="PointCount"></param>
    '''' <param name="Width"></param>
    '''' <param name="Height"></param>
    'Public Sub SetLineForSignature(oWsh As Excel.Worksheet, iRow As Integer, iCol As Integer, LowerText As String, Optional ToLeft As Boolean = False, Optional PointCount As Integer = 60, Optional Width As Single = 200, Optional Height As Single = 40)
    '    Dim txPoints As String = "".PadRight(PointCount, "."c)
    '    Dim oRg As Excel.Range = ExcelRange(iRow, iCol)
    '    With oWsh1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, CSng(oRg.Left) - If(ToLeft, Width, 0), CSng(oRg.Top), Width, Height)
    '        .TextFrame2.TextRange.Characters.Text = txPoints & vbCr & LowerText
    '        .TextFrame2.TextRange.ParagraphFormat.Alignment = Microsoft.Office.Core.MsoParagraphAlignment.msoAlignCenter
    '        .Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse
    '        .Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse
    '    End With
    'End Sub

    Public Function GetISOBWorkFile(FileName As String, Optional Ext As String = Nothing) As String
        Dim sDir As String = GetISOBWorkDirectory()
        If String.IsNullOrWhiteSpace(Ext) Then Ext = IO.Path.GetExtension(FileName)
        'FileName = IO.Path.GetFileNameWithoutExtension(FileName)
        If Not String.IsNullOrWhiteSpace(Ext) AndAlso Not Ext.StartsWith(".") Then Ext = "." & Ext
        Return IO.Path.Combine(sDir, FileName & Ext)
    End Function

    Public Function GetISOBWorkDirectory() As String
#If xDEBUG Then
        Dim sDir As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), txtAplikName)
#Else
        Dim sDir As String = IO.Path.Combine(IO.Path.GetTempPath, txtAppName)
#End If
        If Not IO.Directory.Exists(sDir) Then IO.Directory.CreateDirectory(sDir)
        Return sDir
    End Function

    ''' <summary>
    ''' priklad: SetFontByFamily(New Object() {"FixedSys", 8.5, "Courier New", 7.5, "Consolas", 8.5},pnPanel)
    ''' </summary>
    Public Function SetFontByFamily(ByVal aoDefinition() As Object, Optional ByRef oCtl As Control = Nothing) As System.Drawing.Font
        Dim sngSize As Single = -1
        Dim oRes As System.Drawing.Font = Nothing
        If oCtl IsNot Nothing Then sngSize = oCtl.Font.Size
        For i As Integer = 0 To aoDefinition.Length - 1 Step 2
            Dim sngWk As Single = sngSize
            Dim oFnt As System.Drawing.Font
            If IsNumeric(aoDefinition(i + 1)) Then sngWk = CSng(aoDefinition(i + 1))
            If sngWk > 0 Then
                oFnt = New System.Drawing.Font(CStr(aoDefinition(i)), sngWk)
                If String.Compare(oFnt.FontFamily.Name, CStr(aoDefinition(i)), True) = 0 Then
                    oRes = oFnt
                    Exit For
                End If
            End If
        Next
        If oRes IsNot Nothing AndAlso oCtl IsNot Nothing Then oCtl.Font = oRes
        Return oRes
    End Function

    'Public Sub WriteAndShowTextfile(sFileName As String, sProtokol As String, Optional bWait As Boolean = False)
    '    If Not sFileName.ToLower.EndsWith(".txt") Then sFileName &= ".txt"
    '    'sFileName = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), String.Format(sFileName, Now.ToString("yyyyMMdd_HHmm")))
    '    sFileName = IO.Path.Combine(DocISOBDir, String.Format(sFileName, Now.ToString("yyyyMMdd_HHmm")))
    '    IO.File.Delete(sFileName)
    '    IO.File.WriteAllText(sFileName, sProtokol)
    '    Dim oPrc As New Process
    '    oPrc.StartInfo.FileName = "notepad.exe"
    '    oPrc.StartInfo.Arguments = sFileName
    '    oPrc.Start()
    '    If bWait Then oPrc.WaitForExit()
    'End Sub

    ''' <summary> nastavi matici Values a naimportuje vstupni data, ktera jsou indexovana od 1 (z VBA Excel) </summary>
    ''' <param name="iOffRow"> offset pro pristup pres radek </param>
    ''' <param name="iOffCol"> offset pro pristup pres sloupec </param>
    ''' <param name="iMaxRow"> nejvyssi cislo radku </param>
    ''' <param name="iMaxCol"> nejvyssi cislo sloupce </param>
    ''' <param name="oInputValuesFrom1"> vstupni pole indexovane od 1 </param>
    Public Sub SetValuesDims(iOffRow As Integer, iOffCol As Integer, iMaxRow As Integer, iMaxCol As Integer, Optional oInputValuesFrom1 As Object(,) = Nothing)
        iValRowOff = iOffRow
        iValColOff = iOffCol
        ReDim Values(iMaxRow - iOffRow, iMaxCol - iOffCol)
        If oInputValuesFrom1 IsNot Nothing AndAlso TypeOf oInputValuesFrom1 Is Object(,) Then
            For i As Integer = 1 To oInputValuesFrom1.GetUpperBound(0)
                For j As Integer = 1 To oInputValuesFrom1.GetUpperBound(1)
                    Values(i - 1, j - 1) = oInputValuesFrom1(i, j)
                Next
            Next
        End If
    End Sub

    Public Function RangeStr(iRow As Integer, iCol As Integer, ByRef Optional sOldStr As String = "") As String
        If Not String.IsNullOrEmpty(sOldStr) Then sOldStr &= ";"
        sOldStr &= RangeStr(iRow, iCol)
        Return sOldStr
    End Function

    Public Function RangeStr(iRow As Integer, ByRef Optional sOldStr As String = "") As String
        If Not String.IsNullOrEmpty(sOldStr) Then sOldStr &= ";"
        sOldStr &= String.Format("{0}:{0}", iRow)
        Return sOldStr
    End Function

    Public Function RangeStr(iRow As Integer, iCol As Integer) As String
        Return Chr(Asc("A"c) - 1 + iCol) & iRow
    End Function

    Public Function RangeColStr(iCol As Integer, ByRef Optional sOldStr As String = "") As String
        If Not String.IsNullOrEmpty(sOldStr) Then sOldStr &= ";"
        sOldStr &= RangeColStr(iCol)
        Return sOldStr
    End Function

    ''' <summary> vrati cislo sloupce jako pismeno (jen do Z) </summary>
    ''' <param name="iCol"></param>
    Public Function RangeColStr(iCol As Integer) As String
        Return Chr(Asc("A"c) - 1 + iCol)
    End Function

    ''' <summary> vybere obsah bunky z mezipameti Values </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iCol"></param>
    Public Function SelectCellValue(iRow As Integer, iCol As Integer) As Object
        iRow -= iValRowOff
        iCol -= iValColOff
        Try
            Return Values(iRow, iCol)
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return Nothing
    End Function

    'ulozi obsah bunky do mezipameti Values

    ''' <summary> ulozi obsah bunky do mezipameti Values </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iCol"></param>
    ''' <param name="oValue"></param>
    ''' <param name="SetAsFormula"></param>
    Public Function StoreCellValue(iRow As Integer, iCol As Integer, oValue As Object, Optional SetAsFormula As Boolean = False, Optional SetAsString As Boolean = False) As Boolean
        iRow -= iValRowOff
        iCol -= iValColOff
        Dim bRet As Boolean = False
        Try
            If SetAsFormula Then
                If oValue Is Nothing Then
                    Values(iRow, iCol) = Nothing
                Else
                    Dim sForm As String = oValue.ToString
                    If (Not String.IsNullOrWhiteSpace(sForm)) AndAlso Not sForm.StartsWith("=") Then sForm = "=" + sForm
                    Values(iRow, iCol) = CObj("=" & sForm)
                End If
            ElseIf SetAsString Then
                Values(iRow, iCol) = "'" & CStr(oValue)
            Else
                Values(iRow, iCol) = oValue
            End If
            bRet = True
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return bRet
    End Function

    Public Function SetCellValue(iRow As Integer, iCol As Integer, oValue As Object, Optional SetAsFormula As Boolean = False, Optional sComment As String = "", Optional SelectIt As Boolean = False, Optional oFont As System.Drawing.Font = Nothing) As Boolean
        Dim bRet As Boolean = False
        Try
            Dim oRng As Excel.Range = CType(oCsh.Cells(iRow, iCol), Excel.Range)
            If SetAsFormula Then
                If oValue Is Nothing Then
                    oRng.Formula = Nothing
                Else
                    Dim sForm As String = oValue.ToString
                    If (Not String.IsNullOrWhiteSpace(sForm)) AndAlso Not sForm.StartsWith("=") Then sForm = "=" + sForm
                    oRng.Formula = CObj(sForm)
                End If
            Else
                oRng.Value = oValue
            End If
            If Not String.IsNullOrWhiteSpace(sComment) Then
                oRng.AddComment(sComment)
            End If
            If oFont IsNot Nothing Then
                With oRng.Font
                    .Name = oFont.Name
                    .Size = oFont.Size
                    .Bold = oFont.Bold
                    .Italic = oFont.Italic
                    .Underline = oFont.Underline
                    .Strikethrough = oFont.Strikeout
                End With
            End If
            If SelectIt Then oRng.Select()
            bRet = True
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return bRet
    End Function

    Public Function SetCellComment(iRow As Integer, iCol As Integer, Optional sComment As String = "") As Boolean
        Dim bRet As Boolean = False
        Try
            Dim oRng As Excel.Range = CType(oCsh.Cells(iRow, iCol), Excel.Range)
            If String.IsNullOrWhiteSpace(sComment) Then
                Try
                    If oRng.Comment IsNot Nothing Then oRng.Comment.Delete()
                Catch : End Try
            Else
                oRng.AddComment(sComment)
            End If
            bRet = True
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return bRet
    End Function


    ''' <summary> vrati pozice pojmenovane oblasti: radek, sloupec levy horni - radek, sloupec pravy dolni </summary>
    ''' <param name="Name">jmeno bunky, oblasti</param>
    ''' <param name="iRow1"></param>
    ''' <param name="iCol1"></param>
    ''' <param name="iRowN"></param>
    ''' <param name="iColN"></param>
    ''' <returns></returns>
    Public Function GetExcelRangeLimits(Name As String, Optional ByRef iRow1 As Integer = -1, Optional ByRef iCol1 As Integer = -1, Optional ByRef iRowN As Integer = -1, Optional ByRef iColN As Integer = -1) As Excel.Range
        Dim oRg As Excel.Range = oCsh.Range(Name)
        Return GetExcelRangeLimits(oRg, iRow1, iCol1, iRowN, iColN)
    End Function

    ''' <summary> vrati pozice pojmenovane oblasti: radek, sloupec levy horni - radek, sloupec pravy dolni </summary>
    ''' <param name="oRg"></param>
    ''' <param name="iRow1"></param>
    ''' <param name="iCol1"></param>
    ''' <param name="iRowN"></param>
    ''' <param name="iColN"></param>
    ''' <returns></returns>
    Public Function GetExcelRangeLimits(oRg As Excel.Range, Optional ByRef iRow1 As Integer = -1, Optional ByRef iCol1 As Integer = -1, Optional ByRef iRowN As Integer = -1, Optional ByRef iColN As Integer = -1) As Excel.Range
        Try
            Dim oCells As Excel.Range = CType(oRg.Cells, Excel.Range)
            Dim oRg1 As Excel.Range = CType(oCells(1), Excel.Range)
            Dim oRg2 As Excel.Range = CType(oCells(oCells.Count), Excel.Range)
            iRow1 = oRg1.Row
            iCol1 = oRg1.Column
            iRowN = oRg2.Row
            iColN = oRg2.Column
            Return oRg
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return Nothing
    End Function

    ''' <summary> range pojmenovaneho objektu </summary>
    ''' <param name="Name"></param>
    ''' <param name="oFont"></param>
    ''' <param name="oColor"></param>
    ''' <returns></returns>
    Public Function ExcelRange(Name As String, Optional oFont As System.Drawing.Font = Nothing, Optional oColor As Color = Nothing) As Excel.Range
        Try
            Dim oRg As Excel.Range = oCsh.Range(Name)
            If Not oRg Is Nothing Then
                Dim oCells As Excel.Range = CType(oRg.Cells, Excel.Range)
                Dim oRg1 As Excel.Range = CType(oCells(0), Excel.Range)
                Dim oRg2 As Excel.Range = CType(oCells(oCells.Count), Excel.Range)
                Dim iRow1 As Integer = oRg1.Row
                Dim iCol1 As Integer = oRg1.Column
                Dim iRow2 As Integer = oRg2.Row
                Dim iCol2 As Integer = oRg2.Column
                Return ExcelRange(iRow1, iCol1, iRow2, iCol2, oFont, oColor)
            End If
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return Nothing
        'If oRg IsNot Nothing Then Return ExcelRange(oRg.Cells.
    End Function

    ''' <summary> vytvori a vrati oblast dle radku, sloupcu </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iCol"></param>
    ''' <param name="iRow2"></param>
    ''' <param name="iCol2"></param>
    ''' <param name="oFont"></param>
    ''' <param name="oColor"></param>
    ''' <returns></returns>
    Public Function ExcelRange(iRow As Integer, iCol As Integer, Optional iRow2 As Integer = -1, Optional iCol2 As Integer = -1, Optional oFont As System.Drawing.Font = Nothing, Optional oColor As Color = Nothing) As Excel.Range
        If iRow2 < 0 Then iRow2 = iRow
        If iCol2 < 0 Then iCol2 = iCol
        Dim oRg As Excel.Range = Nothing
        Try
            If iRow2 < 0 Then iRow2 = iRow
            If iCol2 < 0 Then iCol2 = iCol
            If iRow = iRow2 AndAlso iCol = iCol2 Then
                oRg = CType(oCsh.Cells(iRow, iCol), Excel.Range)
            Else
                oRg = oCsh.Range(oCsh.Cells(iRow, iCol), oCsh.Cells(iRow2, iCol2))
            End If
            If Not oColor = Nothing Then
                With oRg.Interior
                    .Pattern = Excel.XlPattern.xlPatternSolid
                    .Color = oColor
                End With
            End If
            If Not oFont Is Nothing Then
                With oRg.Font
                    oRg.Font.Name = oFont.Name
                    .Size = oFont.Size
                    .Bold = oFont.Bold
                    .Italic = oFont.Italic
                    .Underline = oFont.Underline
                    .Strikethrough = oFont.Strikeout
                End With
            End If
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRg
    End Function

    Public Function ExcelRangeRows(iRow As Integer, Optional iRow2 As Integer = -1, Optional AutoFit As Boolean = False) As Excel.Range
        If iRow2 < 0 Then iRow2 = iRow
        Dim oRg As Excel.Range = Nothing
        Try
            oRg = CType(oCsh.Rows(String.Format("{0}:{1}", iRow, iRow2)), Excel.Range)
            If AutoFit Then oRg.Rows.AutoFit()
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRg
    End Function

    Public Function ExcelRangeColumns(iCol As Integer, Optional iCol2 As Integer = -1, Optional AutoFit As Boolean = False) As Excel.Range
        If iCol2 < 0 Then iCol2 = iCol
        Dim oRg As Excel.Range = Nothing
        Try
            oRg = oCsh.Range(oCsh.Columns(iCol), oCsh.Columns(iCol2))
            If AutoFit Then oRg.Columns.AutoFit()
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRg
    End Function

    ''' <summary> vypis objektu Range </summary>
    ''' <param name="oRg"></param>
    Public Function DebugRange(oRg As Excel.Range) As String
        Dim sRet As String = "Range: ???"
#If DEBUG Then
        If Not oRg Is Nothing Then
            Dim iRow1 As Integer = oRg.Row
            Dim iCol1 As Integer = oRg.Column
            Dim iRowN As Integer = iRow1 + oRg.Rows.Count - 1
            Dim iColN As Integer = iCol1 + oRg.Columns.Count - 1
            sRet = String.Format("Range: r:{0} c:{1} / r:{2} c:{3}", iRow1, iCol1, iRowN, iColN)
        End If
        Debug.WriteLine(sRet)
#End If
        Return sRet
    End Function

    ''' <summary> nastavi na oblesti locked/unlocked </summary>
    ''' <param name="oRg"> pokud neni zadano, zvoli se cely list </param>
    ''' <param name="LockIt"> zamknout / odemknout </param>
    Public Function ExcelRangeLockUnlock(Optional oRg As Excel.Range = Nothing, Optional LockIt As Boolean = True) As Excel.Range
        If oRg Is Nothing Then oRg = oCsh.Cells
        oRg.Locked = LockIt
        Return oRg
    End Function

    Public Sub WorkBookSetExclusive(Optional oWsh As Excel.Worksheet = Nothing, Optional bQuietMode As Boolean = True)
        Try
            If oEx IsNot Nothing AndAlso TypeOf oEx Is Excel.Application Then
                If oWsh Is Nothing Then oWsh = oCsh()
                If oWbk.MultiUserEditing Then
                    Dim bOldDisplayAlerts As Boolean = oEx.Application.DisplayAlerts
                    If bQuietMode Then oEx.Application.DisplayAlerts = False
                    oWbk.ExclusiveAccess()
                    If bQuietMode Then oEx.Application.DisplayAlerts = bOldDisplayAlerts
                End If
            End If
        Catch ex As System.Exception
            iLog.ErrLogMsg(ex)
        End Try
    End Sub

    ''' <summary> zamkne list  </summary>
    ''' <param name="oWsh"> worksheet neuveden > oCsh</param>
    ''' <param name="ProtectKey"> heslo </param>
    Public Function WorkSheetProtect(Optional oWsh As Excel.Worksheet = Nothing, Optional ByRef ProtectKey As String = Nothing) As Boolean
        Try
            If oWsh Is Nothing Then oWsh = oCsh()
            If String.IsNullOrWhiteSpace(ProtectKey) Then ProtectKey = Now.ToString("yyyyMMdd") ' heslo je datum vytvoreni
            oWsh.Protect(ProtectKey)
            Return True
        Catch ex As System.Exception
            iLog.ErrLogMsg(ex)
            Debug.Write("Protect:" & ProtectKey & vbCrLf & ex.Message)
        End Try
        Return False
    End Function

    ''' <summary> zamkne list  </summary>
    ''' <param name="oWsh"> worksheet neuveden > oCsh</param>
    ''' <param name="ProtectKey"> heslo </param>
    Public Function WorkSheetUnProtect(Optional oWsh As Excel.Worksheet = Nothing, Optional ByRef ProtectKey As String = Nothing) As Boolean
        Try
            If oWsh Is Nothing Then oWsh = oCsh()
            If String.IsNullOrWhiteSpace(ProtectKey) Then ProtectKey = Now.ToString("yyyyMMdd") ' heslo je datum vytvoreni
            oWsh.Unprotect(ProtectKey)
            Return True
        Catch ex As System.Exception
            iLog.ErrLogMsg(ex)
            Debug.Write("Unprotect:" & ProtectKey & vbCrLf & ex.Message)
        End Try
        Return False
    End Function

    ''' <summary> upravit sirky sloupcu </summary>
    ''' <param name="iCol"></param>
    ''' <param name="iCol2"></param>
    Public Sub ColumnsAutoFit(iCol As Integer, Optional iCol2 As Integer = -1)
        If iCol2 <= 0 Then iCol2 = iCol
        For i As Integer = iCol To iCol2
            CType(oCsh.Columns(i), Excel.Range).AutoFit()
        Next
    End Sub

    ''' <summary> upravit vysky radku </summary>
    ''' <param name="iRow"></param>
    ''' <param name="iRow2"></param>
    Public Sub RowsAutoFit(iRow As Integer, Optional iRow2 As Integer = -1)
        If iRow2 <= 0 Then iRow2 = iRow
        For i As Integer = iRow To iRow2
            CType(oCsh.Rows(i), Excel.Range).AutoFit()
        Next
    End Sub

    Public Sub ColumnsSetVisible(bVisible As Boolean, iCol As Integer, Optional iCol2 As Integer = -1)
        If iCol2 <= 0 Then iCol2 = iCol
        For i As Integer = iCol To iCol2
            CType(oCurrentWsh.Columns(i), Excel.Range).Hidden = Not bVisible
        Next
    End Sub

    ''' <summary> odstrani vsechna ohraniceni </summary>
    ''' <param name="oRng"></param>
    Public Sub ExcelClearBorders(Optional oRng As Excel.Range = Nothing)
        Dim moRng As Excel.Range = If(oRng Is Nothing, oCsh.Cells, oRng)
        With moRng
            .Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        End With
    End Sub

    ''' <summary> nastaveni okraju (Excel.XlLineStyle.xlSlantDashDot se bere jako nedefinovano, vezme se predchozi parametr) </summary>
    ''' <param name="oRng"></param>
    ''' <param name="Weight"></param>
    ''' <param name="EdgLeft"></param>
    ''' <param name="EdgTop"></param>
    ''' <param name="EdgBot"></param>
    ''' <param name="EdgRgt"></param>
    ''' <param name="InsVer"></param>
    ''' <param name="InsHor"></param>
    Public Sub ExcelBorders(oRng As Excel.Range, Weight As Excel.XlBorderWeight, Optional EdgLeft As Excel.XlLineStyle = Excel.XlLineStyle.xlSlantDashDot,
                            Optional EdgTop As Excel.XlLineStyle = Excel.XlLineStyle.xlSlantDashDot, Optional EdgBot As Excel.XlLineStyle = Excel.XlLineStyle.xlSlantDashDot, Optional EdgRgt As Excel.XlLineStyle = Excel.XlLineStyle.xlSlantDashDot,
                            Optional InsVer As Excel.XlLineStyle = Excel.XlLineStyle.xlSlantDashDot, Optional InsHor As Excel.XlLineStyle = Excel.XlLineStyle.xlSlantDashDot)
        Dim iNdf As Excel.XlLineStyle = Excel.XlLineStyle.xlSlantDashDot
        If EdgLeft = iNdf Then EdgLeft = Excel.XlLineStyle.xlContinuous
        If EdgTop = iNdf Then EdgTop = EdgLeft
        If EdgBot = iNdf Then EdgBot = EdgTop
        If EdgRgt = iNdf Then EdgRgt = EdgLeft
        If InsVer = iNdf Then InsVer = EdgLeft
        If InsHor = iNdf Then InsHor = InsVer
        With oRng
            .Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            If EdgLeft <> iNdf Then
                .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = EdgLeft
                .Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Weight
            End If
            If EdgTop <> iNdf Then
                .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = EdgTop
                .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Weight
            End If
            If EdgBot <> iNdf Then
                .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = EdgBot
                .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Weight
            End If
            If EdgRgt <> iNdf Then
                .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = EdgRgt
                .Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Weight
            End If
            If InsVer <> iNdf Then
                .Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = InsVer
                If InsVer <> Excel.XlLineStyle.xlLineStyleNone Then .Borders(Excel.XlBordersIndex.xlInsideVertical).Weight = Weight
            End If
            If InsHor <> iNdf Then
                .Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = InsHor
                If InsHor <> Excel.XlLineStyle.xlLineStyleNone Then .Borders(Excel.XlBordersIndex.xlInsideHorizontal).Weight = Weight
            End If
        End With
    End Sub

    '    Public Function WaitForWorkbookClose(Optional ByVal WorkbookObject As Excel.Workbook = Nothing, Optional ByVal WorkbookName As String = "", Optional oFormLockObject As Object = Nothing) As Boolean

    '        bWaiting = True
    '        Dim dt As Date
    '        Dim sNm As String = Nothing
    '        Dim bFound As Boolean
    '        Dim aoLockList As Hashtable = Nothing
    '        Dim bAutoFormsActivate As Boolean = True

    '        If Not oFormLockObject Is Nothing Then
    '            If TypeOf oFormLockObject Is Boolean Then bAutoFormsActivate = CBool(oFormLockObject)
    '            If TypeOf oFormLockObject Is Hashtable Then aoLockList = CType(oFormLockObject, Hashtable)
    '        Else
    '            If Not LastOpenedWindowsStates Is Nothing Then aoLockList = LastOpenedWindowsStates
    '        End If

    '        Try
    '            If WorkbookObject Is Nothing AndAlso WorkbookName = "" Then Return False
    '            If exc.Workbooks.Count = 0 Then Return False
    '            If bAutoFormsActivate AndAlso aoLockList Is Nothing Then aoLockList = AllOpenedFormsStates()

    '            bFound = False
    '            For Each itm As Excel.Workbook In GetWorkbookCollection()
    '                If (itm Is WorkbookObject) OrElse (String.Compare(IO.Path.GetFileName(itm.FullName), IO.Path.GetFileName(WorkbookName), True) = 0) Then
    '                    WorkbookObject = itm
    '                    sNm = WorkbookObject.FullName
    '                    dt = IO.File.GetLastWriteTime(sNm)
    '                    bFound = True
    '                    Exit For
    '                End If
    '            Next
    '            If Not bFound Then GoTo 99
    '        Catch ex As system.Exception
    '            If InStr(UCase(ex.Message), "ODMÍTL") = 0 AndAlso InStr(UCase(ex.Message), "REFUSE") = 0 Then
    '                Debug.WriteLine(ex.Message)
    '                If bAutoFormsActivate Then AllOpenedFormsStates(aoLockList)
    '                Return False
    '            End If
    '        End Try

    '        bFound = False
    '        'XMainForm.SetWaitingForExcel()
    '        Try
    '            Do
    '                DoEvents()
    '                Threading.Thread.Sleep(MilisecondsOfIntervalWaitingForClose)
    '                DoEvents()
    '                bFound = False
    '                For Each itm As Excel.Workbook In GetWorkbookCollection()
    '                    If (itm Is WorkbookObject) Then
    '                        bFound = True
    '                        Exit For
    '                    End If
    '                Next
    '                If Not bFound Then Exit Do
    '            Loop
    '        Catch ex As system.Exception
    '            Debug.WriteLine(ex.Message)
    '        End Try
    '        'MainForm.ClearWaitingForExcel()
    '        Try
    '            If bAutoFormsActivate Then AllOpenedFormsStates(aoLockList)
    '            Return (dt <> IO.File.GetLastWriteTime(sNm))
    '        Catch : End Try
    '99:     If bAutoFormsActivate Then AllOpenedFormsStates(aoLockList)
    '        Return False
    '    End Function


    Public Function SetCellValue(iRow As Integer, CellName As String, value As Object, Optional SetAsFormula As Boolean = False, Optional sComment As String = "") As Boolean
        Dim bRet As Boolean = False
        Try
            Dim iCol As Integer = oCsh.Range(CellName).Column
            bRet = SetCellValue(iRow, iCol, value, SetAsFormula, sComment)
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return bRet
    End Function

    Public Function SetCellValue(CellName As String, value As Object, Optional SetAsFormula As Boolean = False, Optional sComment As String = "", Optional SelectIt As Boolean = False) As Boolean
        Dim bRet As Boolean = False
        Try
            Dim iCol As Integer = oCsh.Range(CellName).Column
            Dim iRow As Integer = oCsh.Range(CellName).Row
            bRet = SetCellValue(iRow, iCol, value, SetAsFormula, sComment, SelectIt)
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return bRet
    End Function

    Public Function GetCellValue(iRow As Integer, iCol As Integer) As Object
        Dim oRet As Object = Nothing
        Try
            Dim oRng As Excel.Range = CType(oCsh.Cells(iRow, iCol), Excel.Range)
            oRet = oRng.Value
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRet
    End Function

    Public Function GetCellStringValue(iRow As Integer, iCol As Integer) As String
        Dim oRet As Object = Nothing
        Try
            Dim oRng As Excel.Range = CType(oCsh.Cells(iRow, iCol), Excel.Range)
            oRet = oRng.Value
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        If oRet Is Nothing Then Return "" Else Return Trim(CStr(oRet))
    End Function

    Public Function GetCellStringsValue(iRow As Integer, iCol As Integer, Optional Delimiter As String = " ", Optional ClearMoreSpaces As Boolean = False) As String()
        Dim sVal As String = Trim(GetCellStringValue(iRow, iCol))
        If ClearMoreSpaces Then
            While Not String.IsNullOrWhiteSpace(sVal) AndAlso sVal.Contains("  ")
                sVal = Replace(sVal, "  ", " ")
            End While
        End If
        Return Split(sVal, Delimiter)
    End Function

    Public Function IntValue(oValue As Object) As Integer
        If oValue IsNot Nothing AndAlso IsNumeric(oValue) Then Return CInt(oValue)
        Return 0
    End Function

    Public Function DecValue(oValue As Object) As Decimal
        If oValue IsNot Nothing AndAlso IsNumeric(oValue) Then Return CDec(oValue)
        Return 0
    End Function

    Public Function GetCellValue(iRow As Integer, CellName As String) As Object
        Dim oRet As Object = Nothing
        Try
            Dim iCol As Integer = oCsh.Range(CellName).Column
            oRet = GetCellValue(iRow, iCol)
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRet
    End Function

    Public Function GetCellValue(CellName As String) As Object
        Dim oRet As Object = Nothing
        Try
            Dim iCol As Integer = oCsh.Range(CellName).Column
            Dim iRow As Integer = oCsh.Range(CellName).Row
            oRet = GetCellValue(iRow, iCol)
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRet
    End Function

    Public Function GetCellFormula(iRow As Integer, iCol As Integer, Optional ReplaceStr As String = "", Optional Replacement As String = "{0}") As Object
        Dim oRet As Object = Nothing
        Try
            Dim oRng As Excel.Range = CType(oCsh.Cells(iRow, iCol), Excel.Range)
            oRet = CObj(Replace(oRng.Formula.ToString, ReplaceStr, Replacement))
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRet
    End Function

    Public Function GetCellFormula(iRow As Integer, CellName As String, Optional ReplaceStr As String = "", Optional Replacement As String = "{0}") As Object
        Dim oRet As Object = Nothing
        Try
            Dim iCol As Integer = oCsh.Range(CellName).Column
            oRet = GetCellFormula(iRow, iCol)
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRet
    End Function

    Public Function GetCellFormula(CellName As String, Optional ReplaceStr As String = "", Optional Replacement As String = "{0}") As Object
        Dim oRet As Object = Nothing
        Try
            Dim iCol As Integer = oCsh.Range(CellName).Column
            Dim iRow As Integer = oCsh.Range(CellName).Row
            oRet = GetCellFormula(iRow, iCol, ReplaceStr, Replacement)
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return oRet
    End Function

    Public Function GetCellColumn(CellName As String) As Integer
        Dim iRet As Integer = -1
        Try
            iRet = oCsh.Range(CellName).Column
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return iRet
    End Function

    Public Function GetCellColumn2(CellName As String) As Integer
        Dim iRet As Integer = -1
        Try
            With oCsh.Range(CellName)
                iRet = .Column + .Columns.Count - 1
            End With
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return iRet
    End Function

    Public Function GetCellRow(CellName As String) As Integer
        Dim iRet As Integer = -1
        Try
            iRet = oCsh.Range(CellName).Row
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return iRet
    End Function

    ''' <summary> odstrani nepovolene znaky ze jmena listu a zkrati ho, pokud je delsi nez 31 znaku </summary>
    ''' <param name="sName"></param>
    ''' <param name="CutLength"> upravi delku, pokud je vic nez 31 znaku</param>
    Public Function NormalizeSheetName(sName As String, Optional CutLength As Boolean = True) As String
        Dim sRet As String = Replace(Replace(Replace(Replace(Replace(Replace(sName, "/", "|"), "\", "|"), "?", "|"), "*", "|"), "[", "|"), "]", "|")
        If CutLength AndAlso sRet.Length > 31 Then sRet = sRet.Substring(0, 31)
        Return sRet
    End Function

    Public Function SetRowVisibility(iRow As Integer, bVisible As Boolean, Optional iNextRow As Integer = -1) As Boolean
        Dim bRet As Boolean = False
        Try
            Dim oRngN As Excel.Range = Nothing
            If iNextRow > 0 Then
                oRngN = CType(oCsh.Range("A" & iNextRow), Excel.Range)
            End If
            Dim oRng As Excel.Range = CType(oCsh.Range("A" & iRow), Excel.Range)
            oRng.EntireRow.Hidden = Not bVisible
            If oRngN IsNot Nothing Then
                oRng.EntireRow.RowHeight = oRngN.EntireRow.RowHeight
            End If
            bRet = True
        Catch ex As System.Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return bRet
    End Function

    ' trida k vytvoreni odkazu na owner treba pro Messagebox
    Public Class WindowWrapper
        Implements IWin32Window
        Private hwnd As IntPtr

        Public Sub New(handle As IntPtr)
            hwnd = handle
        End Sub
        Public Sub New(handle As Integer)
            hwnd = New IntPtr(handle)
        End Sub

        Public ReadOnly Property Handle As IntPtr Implements IWin32Window.Handle
            Get
                Return hwnd
            End Get
        End Property
    End Class

End Module
