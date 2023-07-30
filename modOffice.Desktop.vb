Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Runtime.InteropServices

Module modOfficeDsk

    Public Const txWordNotInstalled As String = "Na tomto PC nebyla nalezena nainstalovaná aplikace MS Word."
    Public Const txExcelNotInstalled As String = "Na tomto PC nebyla nalezena nainstalovaná aplikace MS Excel."

    ''' <summary> obecny export gridu Do Excel </summary>
    ''' <param name="oOwner"></param>
    ''' <param name="Fg"></param>
    ''' <param name="DefaultName"></param>
    ''' <param name="CenterHeader"></param>
    ''' <param name="Landscape"></param>
    ''' <param name="TrueString"></param>
    ''' <param name="FalseString"></param>
    ''' <param name="AutoExpandFileName"></param>
    ''' <param name="SelCols"></param>
    Public Function ExportGridToExcel(oOwner As Form, Fg As XC1Flexgrid, DefaultName As String, Optional CenterHeader As String = "", Optional Landscape As Boolean = True,
                                 Optional TrueString As String = "ano", Optional FalseString As String = "", Optional AutoExpandFileName As Boolean = True,
                                 Optional SelCols As Integer() = Nothing, Optional ByRef sFilename As String = "", Optional ShowAfter As Boolean = True, Optional MaxNodeLevel As Integer = 0) As Boolean
        'Dim oSaveFileDIalog As New SaveFileDialog

        Dim bRet As Boolean = False

        iExcMaxRow = -1
        iExcMaxCol = -1
        iExcRow1 = Fg.Rows.Fixed + 1

        Using oSaveFileDialog As New SaveFileDialog
            With oSaveFileDialog
                .Title = "Urči jméno výstupního souboru MS Excel"
                'Dim sPath As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                If AutoExpandFileName Then
                    .FileName = IO.Path.ChangeExtension(IO.Path.Combine(DocISOBDir, DefaultName) & Now.ToString("_yyyyMMdd_HHmm"), ".xlsx")
                Else
                    .FileName = IO.Path.ChangeExtension(IO.Path.Combine(DocISOBDir, DefaultName), ".xlsx")
                End If
                .InitialDirectory = IO.Path.GetDirectoryName(.FileName)
                If oSaveFileDialog.ShowDialog = DialogResult.OK Then
                    sFilename = .FileName
                    Fg.Redraw = False
                    Dim aiVisibleCols As New List(Of Integer)
                    For iCol As Integer = 0 To Fg.Cols.Count - 1
                        If Fg.Cols(iCol).Visible Then aiVisibleCols.Add(iCol)
                    Next
                    If TypeOf SelCols Is Integer() AndAlso SelCols.Length > 0 Then
                        For iCol As Integer = 0 To Fg.Cols.Count - 1
                            Fg.Cols(iCol).Visible = (Array.IndexOf(SelCols, iCol) >= 0)
                        Next
                    End If
                    Fg.Redraw = True

                    If IO.File.Exists(sFilename) AndAlso FileInUse(sFilename) Then
                        MessageBox.Show(oOwner, String.Format("Tiskový dokument {0} již je vytvořen.{1}{1}Je však otevřen zřejmě jinou instancí aplikace Excel.{1}{1}Je nutno nejprve tuto aplikaci vyhledat a uzavřít, čímž se dokument uvolní.",
                                   sFilename, vbCrLf),
                                   "Export do MS Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If

                    Dim aiNodeStates As New Dictionary(Of Integer, Boolean)
                    Try
                        Using oLck As New cLockForm(oOwner, XFormBase.SurfaceSplashMode.ShowSplashLabel, "Probíhá export dat do aplikace MS Excel")

                            Fg.Redraw = False
                            For i As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
                                If Fg.Rows(i).IsNode Then
                                    aiNodeStates(i) = Fg.Rows(i).Node.Expanded
                                    If Fg.Rows(i).Node.Level > MaxNodeLevel Then Fg.Rows(i).Node.Parent.Expanded = False
                                End If
                            Next
                            Fg.Redraw = True

                            ' export gridu do excelu
                            Fg.SaveExcel(sFilename, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells Or C1.Win.C1FlexGrid.FileFlags.AsDisplayed Or C1.Win.C1FlexGrid.FileFlags.VisibleOnly Or C1.Win.C1FlexGrid.FileFlags.IncludeMergedRanges Or C1.Win.C1FlexGrid.FileFlags.SaveMergedRanges)

                            oLck.SetProgressText(txExcelExporting)
                            CreateExcel()
                            ExcelStatusBarMessage(txExcelExporting)
                            Application.DoEvents()
                            ScreenUpdatingExcel(False)
                            OpenWorkBook(sFilename)
                            Dim aiAutoCols As New List(Of Integer)
                            Dim aiBoolCols As New List(Of Integer)
                            Dim iColE As Integer = 0

                            iExcMaxRow = 0
                            iExcMaxCol = 0

                            Dim sBoolFont As String = iUsr.ExcBooleanFont
                            For iCol As Integer = 0 To Fg.Cols.Count - 1
                                Dim bSelCol As Boolean = Fg.Cols(iCol).Visible
                                If TypeOf SelCols Is Integer() AndAlso SelCols.Length > 0 Then
                                    bSelCol = Array.IndexOf(SelCols, iCol) >= 0
                                End If
                                'If Fg.Cols(iCol).Visible Then
                                If bSelCol Then
                                    iColE += 1
                                    If iColE > iExcMaxCol Then iExcMaxCol = iColE
                                    Dim iRowE As Integer = 0
                                    For iRow As Integer = 0 To Fg.Rows.Count - 1
                                        'Dim bVisibleNode As Boolean = (Fg.Rows(iRow).IsNode AndAlso ((Fg.Rows(iRow).Node.Parent Is Nothing) OrElse (Fg.Rows(iRow).Node.Parent.Expanded))) OrElse Not Fg.Rows(iRow).IsNode
                                        Dim bVisibleNode As Boolean = Not Fg.Rows(iRow).IsNode OrElse Fg.Rows(iRow).Node.Level <= MaxNodeLevel
                                        If Fg.Rows(iRow).Visible AndAlso bVisibleNode Then
                                            iRowE += 1
                                            If iRowE > iExcMaxRow Then iExcMaxRow = iRowE
                                            If iRow >= Fg.Rows.Fixed Then
                                                If Fg.Cols(iCol).DataType Is GetType(Boolean) Then
                                                    With oEx.Range(oEx.Cells(iRowE, iColE), oEx.Cells(iRowE, iColE))
                                                        If CBool(Fg(iRow, iCol)) Then
                                                            '.Value = TrueString
                                                            .Value = iUsr.ExcTrueValue
                                                        Else
                                                            '.Value = FalseString
                                                            .Value = iUsr.ExcFalseValue
                                                        End If
                                                        If iUsr.rbBoolExcWingdings.Checked Then
                                                            .Font.Name = "Wingdings"
                                                        End If
                                                    End With
                                                    If Not aiBoolCols.Contains(iColE) Then aiBoolCols.Add(iColE)
                                                ElseIf Fg.Cols(iCol).DataType Is GetType(String) Then
                                                    Dim sText As String = CStr(Fg(iRow, iCol))
                                                    If (Not String.IsNullOrWhiteSpace(sText)) AndAlso (sText.Contains(vbCr) OrElse sText.Contains(vbLf)) Then
                                                        sText = Replace(Replace(Replace(sText, vbCrLf, " "), vbCr, ""), vbLf, " ")
                                                        While InStr(sText, "  ") > 0
                                                            sText = Replace(sText, "  ", " ")
                                                        End While
                                                        oEx.Range(oEx.Cells(iRowE, iColE), oEx.Cells(iRowE, iColE)).Value = sText
                                                        If Not aiAutoCols.Contains(iColE) Then aiAutoCols.Add(iColE)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Next

                            ' sirka upravovaneho sloupce
                            For Each iCol As Integer In aiAutoCols
                                ColumnsAutoFit(iCol)
                            Next
                            ' wingdings bool sloupcu
                            If Not String.IsNullOrWhiteSpace(sBoolFont) Then
                                For Each iCol As Integer In aiBoolCols
                                    oEx.Range(oEx.Cells(Fg.Rows.Fixed + 1, iCol), oEx.Cells(iExcMaxRow, iCol)).Font.Name = sBoolFont
                                Next
                            End If

                            If iUsr.cmbFontForExcel.SelectedIndex >= 0 Then
                                oWsh1.Cells.Font.Name = iUsr.cmbFontForExcel.SelectedItem
                                oWsh1.Cells.Font.Size = CSng(iUsr.dbFontSize.Value)
                            End If

                            ScreenUpdatingExcel(True)
                            ExcelStatusBarMessage(txExcelFormatting)
                            Application.DoEvents()
                            ScreenUpdatingExcel(False)
                            oLck.SetProgressText(txExcelFormatting)
                            With oEx
                                .ActiveWindow.DisplayGridlines = False
                                Try
                                    .Range(.Cells(1, 1), .Cells(iExcMaxRow, iExcMaxCol)).Select()
                                    Dim oSel As Excel.Range = CType(.Selection, Excel.Range)
                                    With oSel.Borders(Excel.XlBordersIndex.xlDiagonalDown)
                                        .LineStyle = Excel.XlLineStyle.xlLineStyleNone
                                    End With
                                    With oSel.Borders(Excel.XlBordersIndex.xlDiagonalUp)
                                        .LineStyle = Excel.XlLineStyle.xlLineStyleNone
                                    End With
                                    With oSel.Borders(Excel.XlBordersIndex.xlEdgeTop)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .ColorIndex = 0
                                        '.TintAndShad = 0
                                        .Weight = Excel.XlBorderWeight.xlThin
                                    End With
                                    With oSel.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .ColorIndex = 0
                                        '.TintAndShade = 0
                                        .Weight = Excel.XlBorderWeight.xlThin
                                    End With
                                    With oSel.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .ColorIndex = 0
                                        '.TintAndShade = 0
                                        .Weight = Excel.XlBorderWeight.xlThin
                                    End With
                                    With oSel.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .ColorIndex = 0
                                        '.TintAndShade = 0
                                        .Weight = Excel.XlBorderWeight.xlThin
                                    End With
                                    With oSel.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .ColorIndex = 0
                                        '.TintAndShade = 0
                                        .Weight = Excel.XlBorderWeight.xlThin
                                    End With
                                    With oSel.Borders(Excel.XlBordersIndex.xlInsideVertical)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .ColorIndex = 0
                                        '.TintAndShade = 0
                                        .Weight = Excel.XlBorderWeight.xlThin
                                    End With
                                    SetStandardHeader(oWs, CenterHeader, DefaultName, Landscape, Fg.Rows.Fixed)

                                    oWsh1.Name = "List1"

                                Catch ex As Exception
                                    Debug.WriteLine(ex.Message)
                                End Try
                            End With
                            If ShowAfter Then ShowExcel()
                        End Using
                        bRet = True
                    Catch ex As Exception
                        iLog.ErrLogMsg(ex)
                    Finally
                        Fg.Redraw = False
                        For iCol As Integer = 0 To Fg.Cols.Count - 1
                            Fg.Cols(iCol).Visible = aiVisibleCols.Contains(iCol)
                        Next
                        For Each iNod As Integer In aiNodeStates.Keys
                            Fg.Rows(iNod).Node.Expanded = aiNodeStates(iNod)
                        Next
                        Fg.Redraw = True
                    End Try
                End If
            End With
        End Using
        Return bRet
    End Function

    ''' <summary> otevreni aplikace word </summary>
    Public LastFileDoc As String = ""
    Public LastFilePdf As String = ""
    Public LastFileDot As String = ""

    ''' <summary> ceka na excel. vrati true, pokud je bsaved na false </summary>
    ''' <param name="oOwnerForm"></param>
    Public Sub WaitForExcelClose(oOwnerForm As Form, Optional oClck As cLockForm = Nothing, Optional bDisplayAlerts As Boolean = True, Optional DisplayText As String = Nothing)
        Dim oTop As Control = CType(oOwnerForm, Control).TopLevelControl
        Dim bBrk As Boolean = False
        Dim moClck As cLockForm = Nothing
        DisplayExcelAlerts(bDisplayAlerts)

        Dim sText As String = If(String.IsNullOrWhiteSpace(DisplayText), txWaitForExcel, DisplayText)
        If oClck Is Nothing Then
            moClck = New cLockForm(oTop, sText, XFormBase.SurfaceSplashMode.ShowSplashLabel)
        Else
            oClck.SetProgressText(sText)
        End If
        'Using New cLockForm(oTop, txWaitForExcel, XFormBase.SurfaceSplashMode.StretchAboveAllForm)
        Do
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
            Try
                If oEx IsNot Nothing Then
                    If oEx.Workbooks.Count <= 0 Then bBrk = True
                Else bBrk = True
                End If
            Catch ex As Exception
                bBrk = True
            End Try
            If bBrk Then CloseExcel()
        Loop Until bBrk
        'End Using
        If moClck IsNot Nothing Then moClck.Dispose()
    End Sub

    ''' <summary> nastavi okno Excelu do centra obrazovky </summary>
    ''' <param name="SecondScreen"></param>
    Public Sub SetExcelWindow(Optional SecondScreen As Boolean = True)
        ' logika umisteni okna excel 
        Dim oScrn1 As Screen = Nothing
        Dim oScrn2 As Screen = Nothing
        Dim Scrns() As Screen = Screen.AllScreens
        Dim FormCenter As New Point(iMForm.Left + (iMForm.Width \ 2), iMForm.Top + (iMForm.Height \ 2))

        For Each oItm In Scrns
            If oItm.Bounds.Contains(FormCenter) Then oScrn1 = oItm Else oScrn2 = oItm
        Next
        If SecondScreen AndAlso oScrn2 IsNot Nothing Then oScrn1 = oScrn2
        Dim iOff As Integer = 8
        With oEx.Application
            .WindowState = Excel.XlWindowState.xlNormal
            .Left = CDbl(oScrn1.WorkingArea.X + iOff) * 72 / 96
            .Top = CDbl(oScrn1.WorkingArea.Y + iOff) * 72 / 96
            .Width = CDbl(oScrn1.WorkingArea.Width - iOff - iOff) * 72 / 96
            .Height = CDbl(oScrn1.WorkingArea.Height - iOff - iOff) * 72 / 96
        End With

    End Sub

    Public Function GetExcelWindowRect() As Rectangle
        Dim oRect As New Rectangle
        If TypeOf oEx Is Excel.Application Then
            With oEx.Application
                oRect.X = CInt(.Left * 96 / 72)
                oRect.Y = CInt(.Top * 96 / 72)
                oRect.Width = CInt(.Width * 96 / 72)
                oRect.Height = CInt(.Height * 96 / 72)
            End With
        End If
        Return oRect
    End Function


End Module
