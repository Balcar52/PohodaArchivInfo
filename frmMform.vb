' text upraven 21.06.2023 23:48:11 jiri/JIRIBARTUSEK
' text upraven 21.06.2023 23:48:11 jiri/JIRIBARTUSEK
' CorrectForm 22.12.2021; 1.2.0.37; ©2016-19 Ing. Jiri Bartusek
' 
' Deklarace cisel sloupcu pro Flexgrid - pocet uprav: 1. 21.06.2023 23:48:05
Imports XControls
Imports XForms
Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop
Imports System.Reflection

Public Class MForm3

    Public Const FormVersion As String = "v. 18.4.2024"

    Public Const nmCurrentFile As String = "CurrentFile"
    Public Const nmbSetTabColors As String = "SetTabColors"
    Public Const nmbCenaZaJednText As String = "CanaJednText"
    Public Const nmbSimpleExcel As String = "SimpleExcel"
    Public Const nmbUseExcel As String = "UseExcel"
    Public Const nmsExcelExpDir As String = "ExcelDir"
    Public Const nmsAutoSizeText As String = "AutoSizeText"
    Public Const nmsColorFgOP As String = "ColorsFgOP"
    Public Const nmsColorFgOV As String = "ColorsFgOV"
    Public Const nmsColorFgN As String = "ColorsFgN"
    Public Const nmsColorFgFV As String = "ColorsFgFV"
    Public Const nmsColorFgFP As String = "ColorsFgFP"

    Public Const txText As String = " (text)"
    Public Const txFontNarrow As String = "Arial Narrow"

    Public bLoading As Boolean = True

    Public clrFgOP As New ColorPair(SystemColors.WindowText, SystemColors.Window)
    Public clrFgN As New ColorPair(SystemColors.WindowText, SystemColors.Window)
    Public clrFgFV As New ColorPair(SystemColors.WindowText, SystemColors.Window)
    Public clrFgFP As New ColorPair(SystemColors.WindowText, SystemColors.Window)
    Public clrFgOV As New ColorPair(SystemColors.WindowText, SystemColors.Window)

    Public bSetTabColors As Boolean = True
    Public bSimpleExcel As Boolean = True
    Public sExcelExpDir As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath))
    Public bUseExcel As Boolean = True

    Public bAutoUpdate As Boolean = True

    ' deklarace promennych cisel sloupcu gridu 

    Dim iColFg0 As Integer ' [g:0]
    Dim iColFgFirma As Integer ' [g:1]
    Dim iColFgICO As Integer ' [g:1]
    Dim iColFgKlic As Integer ' [g:2]
    Dim iColFgDatum As Integer ' [g:3]
    Dim iColFgCislo As Integer ' [g:4]
    Dim iColFgNazevFirmy As Integer ' [g:5]
    Dim iColFgText As Integer ' [g:6]
    Dim iColFgMnozstvi As Integer ' [g:8]
    Dim iColFgCena As Integer ' 
    Dim iColFgCenaJ As Integer ' 
    Dim iColFgCena2 As Integer '
    Dim iColFgCena2J As Integer '
    Dim iColFgPocO As Integer ' 
    Dim iColFgPocP As Integer ' 
    Dim iColFgPozn As Integer ' 
    Dim iColFgZdroj As Integer ' 
    Dim iColFgTree As Integer ' 

    Public Sub InitGrid(Fg As XC1Flexgrid, oColor As ColorPair, Optional bSetColors As Boolean = True)
        Fg.Styles.Clear()
        If bSetColors AndAlso Not ColorPairIsEmpty(oColor) Then
            Fg.ForeColor = oColor.ForeColor
            Fg.BackColor = oColor.BackColor
        End If
    End Sub

    Public Sub InitGrid(Fg As XC1Flexgrid, Nazev1 As String, oColor As ColorPair, Optional bSetColors As Boolean = True)
        InitGrid(Fg, oColor, bSetColors)
        FlexgridSet(Fg) '' [CorrectForm 17.4.2019 22:43]' [CorrectForm 21.6.2023 23:48]
        iColFg0 = FlexgridSetCol(">")
        iColFgFirma = FlexgridSetCol("firma,250,RM<")
        iColFgICO = FlexgridSetCol("IČ,40,RM>")
        iColFgKlic = FlexgridSetCol("klíč,100,R<")
        iColFgTree = FlexgridSetCol(",30,R,")
        iColFgPocO = FlexgridSetCol("poč.,40,RI^", Nazev1)
        iColFgDatum = FlexgridSetCol("datum,80,RMd>", "*")
        iColFgCislo = FlexgridSetCol("číslo,80,R>", "*")
        iColFgNazevFirmy = FlexgridSetCol("název firmy,80,RF<", "*")
        iColFgPocP = FlexgridSetCol("poč.,40,RI^", "položky")
        iColFgText = FlexgridSetCol("text,80,R<", "*")
        iColFgMnozstvi = FlexgridSetCol("množ.,80,RID>,#####0", "*")
        iColFgCena = FlexgridSetCol("cena,80,RID>,### ##0,00", "*")
        iColFgCenaJ = FlexgridSetCol("j.cena,80,RID>,### ##0,00", "*")
        iColFgCena2 = FlexgridSetCol("[měna]\ncena,80,R>", "*")
        iColFgCena2J = FlexgridSetCol("[měna]\nj.cena,80,R>", "*")
        iColFgZdroj = FlexgridSetCol("mdb,80,R<")
        iColFgPozn = FlexgridSetCol("pozn.,80,R<")
        FlexgridSetExec() ' [CorrectForm 21.6.2023 23:48]

        AddFlexGridStyle(1, FontStyle.Bold, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
        AddFlexGridStyle(2, FontStyle.Italic, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
        SetFlexGridStyleToCols(1, iColFgFirma)
        SetFlexGridStyleToCols(2, iColFgNazevFirmy)
        SetFlexGridStyleToCols(1, iColFgTree)
        SetFlexGridStyleToCols(1, iColFgPocO)
        SetFlexGridStyleToCols(1, iColFgDatum)
        SetFlexGridStyleToCols(1, iColFgCislo)
        Fg.Styles.Highlight.BackColor = Fg.Styles.Normal.BackColor
        Fg.Styles.Highlight.ForeColor = Fg.Styles.Normal.ForeColor


        Fg.Cols(iColFgKlic).Visible = False
        Fg.Cols(iColFgICO).Visible = False
        Fg.Cols(iColFgNazevFirmy).Visible = False
        Fg.Cols(iColFgZdroj).Visible = False

        Fg.Tree.Column = iColFgTree

        Fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom
        Fg.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus
        Fg.ExtendLastCol = True

        FlexgridSetGlobalFormat()
        Fg.SelectionMode = SelectionModeEnum.Default

        Fg.AutoSearch = AutoSearchEnum.FromCursor

        Fg.FocusRect = FocusRectEnum.Heavy
        Fg.SelectionMode = SelectionModeEnum.Cell
    End Sub

    Public Function LoadData() As Boolean
        bLoading = True
        a_excel.Enabled = False
        FgOP.ClearDataRows(True, True)
        FgN.ClearDataRows(True, True)
        FgFV.ClearDataRows(True, True)
        FgOV.ClearDataRows(True, True)
        FgFP.ClearDataRows(True, True)
        Application.DoEvents()

LoadIt: Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.ShowSplashLabel, "Načítám data z archivu """ & AData.CurrentFile & """")
            Dim sCurrentFile As String = ""
            If AData.LoadXMLData(AData.ValidFileVersion, sCurrentFile) Then
                If AutoUpdateMdbData(sCurrentFile, clck) Then
                    GoTo Reload
                End If
                RefreshStb()
                With AData.oAdata
                    LoadObjList(FgN, .aoFirmyNab)
                    LoadObjList(FgOP, .aoFirmyObjPrij)
                    LoadObjList(FgOV, .aoFirmyObjVyd)
                    LoadFakList(FgFV, .aoFirmyFVyd)
                    LoadFakList(FgFP, .aoFirmyFPrij)
                End With
                a_excel.Enabled = True
                Dim Fg As XC1Flexgrid
                If tbcMain.SelectedTab Is pgObjPrij Then
                    Fg = FgOP
                ElseIf tbcMain.SelectedTab Is pgNab Then
                    Fg = FgN
                ElseIf tbcMain.SelectedTab Is pgFaktVyd Then
                    Fg = FgFV
                ElseIf tbcMain.SelectedTab Is pgObjVyd Then
                    Fg = FgOV
                ElseIf tbcMain.SelectedTab Is pgFaktPrij Then
                    Fg = FgFP
                Else
                    Return False
                End If
                SetTreeCol(FgOP)
                SetTreeCol(FgN)
                SetTreeCol(FgFP)
                SetTreeCol(FgOV)
                SetTreeCol(FgFV)
                Fg.Col = iColFgFirma
                Fg.Redraw = True
                Fg.Select()
                Fg.Focus()
                bLoading = False
                Return True
            Else
                lblArchiveFile.Text = AData.sError
                lblArchiveFileTimeSize.Text = ""
                bLoading = False
                MessageBox.Show(Me, String.Format("Chyba načítání vstupních dat.{0}{0}{1}.", vbCrLf, AData.sError), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End Using
Reload: GoTo LoadIt
    End Function

    Public Sub LoadObjList(Fg As XC1Flexgrid, List As List(Of AData.AFirma), Optional SelectGrid As Boolean = False)
        Fg.MergedRanges.Clear()
        Fg.Redraw = False
        Dim oRg As CellRange
        With AData.oAdata
            For Each oFrm As AData.AFirma In List
                Dim iRow As Integer = 0
                Dim iRow11 As Integer = Fg.Rows.Count
                LoadDataRow(Fg, iRow, oFrm)
                For Each oObj As AData.AObjNab In oFrm.aoDoc
                    Dim iRow21 As Integer = Fg.Rows.Count
                    LoadDataRow(Fg, iRow, oFrm, oObj)
                    'Dim iRow31 As Integer = Fg.Rows.Count + 1
                    For Each oObjp As AData.AObjNabPol In oObj.aoObjPol
                        If oObj.aoObjPol.Count = 1 Then
                            'Debug.WriteLine()
                        End If
                        LoadDataRow(Fg, iRow, oFrm, oObj, oObjp)
                    Next
                    oRg = Fg.GetCellRange(iRow21, iColFgCislo, iRow, iColFgCislo)
                    Fg.MergedRanges.Add(oRg)
                    oRg = Fg.GetCellRange(iRow21, iColFgDatum, iRow, iColFgDatum)
                    Fg.MergedRanges.Add(oRg)
                    oRg = Fg.GetCellRange(iRow21, iColFgPocP, iRow, iColFgPocP)
                    Fg.MergedRanges.Add(oRg)
                Next
                oRg = Fg.GetCellRange(iRow11, iColFgFirma, iRow, iColFgFirma)
                Fg.MergedRanges.Add(oRg)
                oRg = Fg.GetCellRange(iRow11, iColFgICO, iRow, iColFgICO)
                Fg.MergedRanges.Add(oRg)
                oRg = Fg.GetCellRange(iRow11, iColFgPocO, iRow, iColFgPocO)
                Fg.MergedRanges.Add(oRg)
            Next
            For i As Integer = Fg.Row1 To Fg.RowN
                Fg.Rows(i).Node.Expanded = False
            Next
        End With
        Fg.Col = iColFgFirma
        Fg.Redraw = True
        'FgO.Select()
        'FgO.Focus()

    End Sub

    Public Sub LoadFakList(Fg As XC1Flexgrid, List As List(Of AData.AFirma), Optional SelectGrid As Boolean = False)
        Fg.MergedRanges.Clear()
        Fg.Redraw = False
        Dim oRg As CellRange
        With AData.oAdata
            For Each oFrm As AData.AFirma In List
                Dim iRow As Integer = 0
                Dim iRow11 As Integer = Fg.Rows.Count
                LoadDataRowF(Fg, iRow, oFrm)
                For Each oFak As AData.AFakt In oFrm.aoDocF
                    Dim iRow21 As Integer = Fg.Rows.Count
                    LoadDataRowF(Fg, iRow, oFrm, oFak)
                    'Dim iRow31 As Integer = Fg.Rows.Count + 1
                    For Each oFakP As AData.AFaktPol In oFak.aoFaktPol
                        If oFak.aoFaktPol.Count = 1 Then
                            'Debug.WriteLine()
                        End If
                        LoadDataRowF(Fg, iRow, oFrm, oFak, oFakP)
                    Next
                    oRg = Fg.GetCellRange(iRow21, iColFgCislo, iRow, iColFgCislo)
                    Fg.MergedRanges.Add(oRg)
                    oRg = Fg.GetCellRange(iRow21, iColFgDatum, iRow, iColFgDatum)
                    Fg.MergedRanges.Add(oRg)
                    oRg = Fg.GetCellRange(iRow21, iColFgPocP, iRow, iColFgPocP)
                    Fg.MergedRanges.Add(oRg)
                Next
                oRg = Fg.GetCellRange(iRow11, iColFgFirma, iRow, iColFgFirma)
                Fg.MergedRanges.Add(oRg)
                oRg = Fg.GetCellRange(iRow11, iColFgICO, iRow, iColFgICO)
                Fg.MergedRanges.Add(oRg)
                oRg = Fg.GetCellRange(iRow11, iColFgPocO, iRow, iColFgPocO)
                Fg.MergedRanges.Add(oRg)
            Next
            For i As Integer = Fg.Row1 To Fg.RowN
                Fg.Rows(i).Node.Expanded = False
            Next
        End With
        Fg.Col = iColFgFirma
        Fg.Redraw = True
        'FgO.Select()
        'FgO.Focus()
    End Sub

    Public Sub LoadDataRow(Fg As XC1Flexgrid, ByRef iRow As Integer, Optional oFrm As AData.AFirma = Nothing, Optional oObj As AData.AObjNab = Nothing, Optional oObjP As AData.AObjNabPol = Nothing)
        iRow = Fg.Rows.Add.Index
        If oFrm IsNot Nothing Then
            Fg(iRow, iColFgFirma) = oFrm.GetDisplayName
            If oFrm.ICO > 0 Then Fg(iRow, iColFgICO) = oFrm.ICO
            If Not String.IsNullOrWhiteSpace(oFrm.Email) AndAlso oObj Is Nothing Then
                Fg(iRow, iColFgPozn) = oFrm.Email
                Fg.SetStyleToCell(iRow, iColFgPozn,,, FontStyle.Italic)
            End If
            Fg(iRow, iColFgKlic) = oFrm.KeyName
            Fg(iRow, iColFgPocO) = oFrm.aoDoc.Count
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 0
            Fg.Rows(iRow).UserData = oFrm
        End If
        If oObj IsNot Nothing Then
            'iRow = Fg.Rows.Add.Index
            Fg(iRow, iColFgDatum) = oObj.dtDatum
            Fg(iRow, iColFgCislo) = oObj.Cislo
            Fg(iRow, iColFgPocP) = oObj.aoObjPol.Count
            Fg(iRow, iColFgNazevFirmy) = oObj.Name
            Fg(iRow, iColFgText) = oObj.Text
            Fg.SetStyleToCell(iRow, iColFgText,,, New Font(txFontNarrow, Me.Font.Size))
            If oObjP Is Nothing Then
                If oObj.JeCena Then
                    Fg(iRow, iColFgCena) = oObj.Kc
                End If
                If oObj.JeCiziMena Then
                    Fg(iRow, iColFgCena2) = oObj.CiziMena
                End If
            End If
            Fg(iRow, iColFgZdroj) = AData.oAdata.aoFileDic(oObj.FileID).PureFileName
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 1
            Fg.Rows(iRow).UserData = oObj
        End If
        If oObjP IsNot Nothing Then
            Fg(iRow, iColFgText) = Trim(oObjP.Text)
            Fg.SetStyleToCell(iRow, iColFgText,,, FontStyle.Bold)
            Fg(iRow, iColFgPozn) = Trim(oObjP.Pozn)
            If oObjP.JeMnozstvi Then Fg(iRow, iColFgMnozstvi) = oObjP.Mnoz
            If oObjP.JeCenaMnozstvi Then
                Fg(iRow, iColFgCena) = oObjP.Cena
                Fg(iRow, iColFgCenaJ) = oObjP.CenaJ
                Fg.SetStyleToCell(iRow, iColFgCena,,, FontStyle.Bold, TextAlignEnum.RightCenter)
                Fg.SetStyleToCell(iRow, iColFgMnozstvi,,, FontStyle.Bold, TextAlignEnum.RightCenter)
                If oObjP.JeCiziMena(oObj) Then
                    Fg(iRow, iColFgCena2) = oObjP.CiziMena(oObj)
                    Fg.SetStyleToCell(iRow, iColFgCena2,,, FontStyle.Bold, TextAlignEnum.RightCenter)
                    Fg(iRow, iColFgCena2J) = oObjP.CiziMenaJ(oObj)
                End If
            Else
                If String.IsNullOrWhiteSpace(CStr(Fg(iRow, iColFgPozn))) Then Fg(iRow, iColFgPozn) = Trim(CStr(Fg(iRow, iColFgPozn)) & txText)
                Fg.SetStyleToCell(iRow, iColFgPozn,,, FontStyle.Italic)
                Fg.SetStyleToCell(iRow, iColFgText,,, FontStyle.Regular)
            End If
            Fg(iRow, iColFgZdroj) = AData.oAdata.aoFileDic(oObj.FileID).PureFileName
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 2
            Fg.Rows(iRow).UserData = oObjP
        End If
    End Sub

    Public Sub LoadDataRowF(Fg As XC1Flexgrid, ByRef iRow As Integer, Optional oFrm As AData.AFirma = Nothing, Optional oFakt As AData.AFakt = Nothing, Optional oFakP As AData.AFaktPol = Nothing)
        iRow = Fg.Rows.Add.Index
        If oFrm IsNot Nothing Then
            'iRow = Fg.Rows.Add.Index
            Fg(iRow, iColFgFirma) = oFrm.GetDisplayName
            If oFrm.ICO > 0 Then Fg(iRow, iColFgICO) = oFrm.ICO
            If Not String.IsNullOrWhiteSpace(oFrm.Email) AndAlso oFakt Is Nothing Then
                Fg(iRow, iColFgPozn) = oFrm.Email
                Fg.SetStyleToCell(iRow, iColFgPozn,,, FontStyle.Italic)
            End If
            Fg(iRow, iColFgKlic) = oFrm.KeyName
            Fg(iRow, iColFgPocO) = oFrm.aoDocF.Count
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 0
            Fg.Rows(iRow).UserData = oFrm
        End If
        If oFakt IsNot Nothing Then
            'iRow = Fg.Rows.Add.Index
            Fg(iRow, iColFgDatum) = oFakt.dtDatum
            Fg(iRow, iColFgCislo) = oFakt.Cislo
            Fg(iRow, iColFgPocP) = oFakt.aoFaktPol.Count
            Fg(iRow, iColFgNazevFirmy) = oFakt.Name
            Fg(iRow, iColFgText) = oFakt.Text
            If oFakP Is Nothing Then
                If oFakt.JeCena Then
                    Fg(iRow, iColFgCena) = oFakt.Kc
                End If
                If oFakt.JeCiziMena Then
                    Fg(iRow, iColFgCena2) = oFakt.CiziMena
                End If
            End If
            'Fg.SetStyleToCell(iRow, iColFgText,,, FontStyle.Italic)
            Fg.SetStyleToCell(iRow, iColFgText,,, New Font(txFontNarrow, Me.Font.Size))
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 1
            Fg.Rows(iRow).UserData = oFakt
        End If
        If oFakP IsNot Nothing Then
            'iRow = Fg.Rows.Add.Index
            'If oFrm.GetDisplayName.Contains("Ease Camp") Then
            '    Debug.WriteLine("tady")
            'End If
            Fg(iRow, iColFgText) = Trim(oFakP.Text)
            Fg.SetStyleToCell(iRow, iColFgText,,, FontStyle.Bold)
            Fg(iRow, iColFgPozn) = Trim(oFakP.Pozn)
            If oFakP.JeMnozstvi Then Fg(iRow, iColFgMnozstvi) = oFakP.Mnoz
            If oFakP.JeCenaMnozstvi Then
                Fg(iRow, iColFgCena) = oFakP.Cena
                Fg(iRow, iColFgCenaJ) = oFakP.CenaJ
                Fg.SetStyleToCell(iRow, iColFgCena,,, FontStyle.Bold, TextAlignEnum.RightCenter)
                Fg.SetStyleToCell(iRow, iColFgMnozstvi,,, FontStyle.Bold, TextAlignEnum.RightCenter)
                If oFakP.JeCiziMena(oFakt) Then
                    Fg(iRow, iColFgCena2) = oFakP.CiziMena(oFakt)
                    Fg.SetStyleToCell(iRow, iColFgCena2,,, FontStyle.Bold, TextAlignEnum.RightCenter)
                    Fg(iRow, iColFgCena2J) = oFakP.CiziMenaJ(oFakt)
                End If
            Else
                If String.IsNullOrWhiteSpace(CStr(Fg(iRow, iColFgPozn))) Then Fg(iRow, iColFgPozn) = Trim(CStr(Fg(iRow, iColFgPozn)) & txText)
                Fg.SetStyleToCell(iRow, iColFgPozn,,, FontStyle.Italic)
                Fg.SetStyleToCell(iRow, iColFgText,,, FontStyle.Regular)
            End If
            'If oFakP.je > 0 Then Fg(iRow, iColFgMnozstvi) = oFakP.Mnoz
            'If oFakP.Kc > 0 Then Fg(iRow, iColFgCena) = oFakP.Kc
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 2
            Fg.Rows(iRow).UserData = oFakP
        End If
    End Sub

    Private Sub MForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        FDevMsg.InitDevMsg(Me)

        If Not FormVersionChanged(Me, FormVersion, False) Then
            WindowRestore(Me)
            FlexgridRestore(FgOP,,,, False)
            FlexgridRestore(FgN,,,, False)
            FlexgridRestore(FgFV,,,, False)
            FlexgridRestore(FgFP,,,, False)
            LoadData()
            FlexgridRestorePosition(FgOP)
            FlexgridRestorePosition(FgN)
            FlexgridRestorePosition(FgFV)
            FlexgridRestorePosition(FgFP)
            TabControlRestore(tbcMain)
        Else
            LoadData()
        End If
        tbcMain_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub MForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        iMForm = Me
        sConnStdCtr = poConn.ConnectionString
        oConn = poConn
        RefreshStb()
        WindowRestore(Me)
        clrFgOP = ColorPairFromString(StringRestore(nmsColorFgOP), True)
        clrFgN = ColorPairFromString(StringRestore(nmsColorFgN), True)
        clrFgFV = ColorPairFromString(StringRestore(nmsColorFgFV), True)
        clrFgFP = ColorPairFromString(StringRestore(nmsColorFgFP), True)
        clrFgOV = ColorPairFromString(StringRestore(nmsColorFgOV), True)
        If ColorPairIsEmpty(clrFgOP) OrElse ColorPairIsEmpty(clrFgN) OrElse ColorPairIsEmpty(clrFgFV) OrElse ColorPairIsEmpty(clrFgFP) OrElse ColorPairIsEmpty(clrFgOV) Then
            Dim oOpt As New FOptions(Nothing, False)
            If ColorPairIsEmpty(clrFgOP) Then clrFgOP = oOpt.clrFgOP.ColorSetting
            If ColorPairIsEmpty(clrFgN) Then clrFgN = oOpt.clrFgN.ColorSetting
            If ColorPairIsEmpty(clrFgFV) Then clrFgFV = oOpt.clrFgFV.ColorSetting
            If ColorPairIsEmpty(clrFgFP) Then clrFgFP = oOpt.clrFgFP.ColorSetting
            If ColorPairIsEmpty(clrFgOV) Then clrFgOV = oOpt.clrFgOV.ColorSetting
            oOpt = Nothing
        End If
        AData.CurrentFile = StringRestore(nmCurrentFile,, AData.CurrentFile)
        sExcelExpDir = StringRestore(nmsExcelExpDir,, sExcelExpDir)
        bUseExcel = BooleanRestore(nmsExcelExpDir,, bUseExcel)
        bSimpleExcel = BooleanRestore(nmbSimpleExcel,, bSimpleExcel)
        bSetTabColors = BooleanRestore(nmbSetTabColors,, bSetTabColors)
        a_automaticky_upravovat_sirku_sloupce_textu.Checked = BooleanRestore(nmsAutoSizeText,, True)
        InitGrid(FgN, "nabídky", clrFgN, bSetTabColors)
        InitGrid(FgOP, "objednávky", clrFgOP, bSetTabColors)
        InitGrid(FgFV, "vydané faktury", clrFgFV, bSetTabColors)
        InitGrid(FgOV, "objednávky", clrFgOV, bSetTabColors)
        InitGrid(FgFP, "přijaté faktury", clrFgFP, bSetTabColors)

        FGridSearchText.RegisterForAllGrids(Me, a_searchtext, a_searchtextnext)
        FGridSearchText.gaoGridFirmaColList.Add(FgFP, iColFgFirma)
        FGridSearchText.gaoGridFirmaColList.Add(FgFV, iColFgFirma)
        FGridSearchText.gaoGridFirmaColList.Add(FgN, iColFgFirma)
        FGridSearchText.gaoGridFirmaColList.Add(FgOP, iColFgFirma)
        FGridSearchText.gaoGridFirmaColList.Add(FgOV, iColFgFirma)

        lblVer.Text = GetAssemblyVersion(Assembly.GetExecutingAssembly, "") & IO.File.GetLastWriteTime(Application.ExecutablePath).ToString(" (d.M.yyyy H:mm)")
    End Sub

    Public Sub RefreshStb()
        If IO.File.Exists(AData.CurrentFile) Then
            lblArchiveFile.Text = AData.CurrentFile
            lblArchiveFileTimeSize.Text = IO.File.GetLastWriteTime(AData.CurrentFile).ToString(" (d.M.yyyy H:mm, ") & New IO.FileInfo(AData.CurrentFile).Length.ToString("## ### ##0 B)")
        Else
            'lblArchiveFile.Text = "není definován aktuální soubor archivu. Nastav, nebo vytvoř aktuální soubor archivu."
            lblArchiveFile.Text = ""
            lblArchiveFileTimeSize.Text = ""
        End If
    End Sub

    Public Sub SaveCurrentFileName()
        WindowSet(Me)
        StringSave(nmCurrentFile, AData.CurrentFile)
    End Sub

    Private Sub MForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveForm()
    End Sub

    Public Sub SaveForm()
        WindowSave(Me)
        TabControlSave(tbcMain)
        FlexgridSave(FgOP)
        FlexgridSave(FgOV)
        FlexgridSave(FgN)
        FlexgridSave(FgFV)
        FlexgridSave(FgFP)
        FlexgridSavePosition(FgOP)
        FlexgridSavePosition(FgOV)
        FlexgridSavePosition(FgN)
        FlexgridSavePosition(FgFV)
        FlexgridSavePosition(FgFP)
        StringSave(nmCurrentFile, AData.CurrentFile)
        StringSave(nmsExcelExpDir, sExcelExpDir)
        BooleanSave(nmbSimpleExcel, bSimpleExcel)
        BooleanSave(nmbUseExcel, bSimpleExcel)
        BooleanSave(nmbSetTabColors, bSetTabColors)
        BooleanSave(nmsAutoSizeText, a_automaticky_upravovat_sirku_sloupce_textu.Checked)
        SaveColors()
    End Sub

    Public Sub SaveColors()
        WindowSet(Me)
        If Not ColorPairIsEmpty(clrFgOP) Then StringSave(nmsColorFgOP, ColorPairToString(clrFgOP))
        If Not ColorPairIsEmpty(clrFgN) Then StringSave(nmsColorFgN, ColorPairToString(clrFgN))
        If Not ColorPairIsEmpty(clrFgFV) Then StringSave(nmsColorFgFV, ColorPairToString(clrFgFV))
        If Not ColorPairIsEmpty(clrFgFP) Then StringSave(nmsColorFgFP, ColorPairToString(clrFgFP))
        If Not ColorPairIsEmpty(clrFgOV) Then StringSave(nmsColorFgOV, ColorPairToString(clrFgOV))
    End Sub

    Private Sub a_close_Execute(sender As Object, e As EventArgs) Handles a_close.Execute
        Me.Close()
    End Sub

    Private Sub a_sprava_aplikace_Execute(sender As Object, e As EventArgs) Handles a_sprava_aplikace.Execute
        Dim oRetForm As FOptions = Nothing
        If FOptions.Run(Me, oRetForm) = DialogResult.OK Then
            WindowSet(Me)
            StringSave(nmCurrentFile, AData.CurrentFile)
            AData.CurrentFile = oRetForm.txtCurrentFile.Text
            clrFgOP = oRetForm.clrFgOP.ColorSetting
            clrFgN = oRetForm.clrFgN.ColorSetting
            clrFgFV = oRetForm.clrFgFV.ColorSetting
            clrFgFP = oRetForm.clrFgFP.ColorSetting
            clrFgOV = oRetForm.clrFgOV.ColorSetting
            bSetTabColors = oRetForm.gbColors.Checked
            bSimpleExcel = oRetForm.chkSimpleExcel.Checked
            bUseExcel = oRetForm.chkUseExcel.Checked
            sExcelExpDir = oRetForm.txtMSExcelDir.Text
            InitGrid(FgOP, "objednávky", clrFgOP, bSetTabColors)
            InitGrid(FgN, "nabídky", clrFgN, bSetTabColors)
            InitGrid(FgFV, "vydané faktury", clrFgFV, bSetTabColors)
            InitGrid(FgOV, "objednávky", clrFgOV, bSetTabColors)
            InitGrid(FgFP, "přijaté faktury", clrFgFP, bSetTabColors)
            SaveForm()
            LoadData()
        End If
    End Sub

    Private Sub a_znovunacist_data_Execute(sender As Object, e As EventArgs) Handles a_znovunacist_data.Execute
        LoadData()
    End Sub

    Private Function FgA() As XC1Flexgrid
        Select Case True
            Case tbcMain.SelectedTab Is pgObjPrij
                Return FgOP
            Case tbcMain.SelectedTab Is pgObjVyd
                Return FgOV
            Case tbcMain.SelectedTab Is pgNab
                Return FgN
            Case tbcMain.SelectedTab Is pgFaktVyd
                Return FgFV
            Case tbcMain.SelectedTab Is pgFaktPrij
                Return FgFP
        End Select
        Return Nothing
    End Function

    Private Sub a_colwidths_Execute(sender As Object, e As EventArgs) Handles a_colwidths.Execute
        AutoSizeFg(FgA)
        'Select Case True
        '    Case tbcMain.SelectedTab Is pgObj
        '        AutosizeFg(FgO)
        '    Case tbcMain.SelectedTab Is pgNab
        '        AutosizeFg(FgN)
        'End Select
        ''Fg.autosizemode = AutoSizeMode.GrowAndShrink
    End Sub

    Private Sub a_cols_Execute(sender As Object, e As EventArgs) Handles a_cols.Execute
        ColDialog(FgA)
    End Sub

    Private Sub AutoSizeFg(Fg As XC1Flexgrid)
        Try
            Dim oPar As Control = Fg.Parent
            Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.ShowSplashLabel, "Upravuji vzhled formuláře")
                Fg.BeginUpdate()
                Fg.AutoSizeCols()
                SetTreeCol(Fg)
                Fg.EndUpdate()
            End Using
        Catch : End Try
    End Sub

    Private Sub SetTreeCol(Fg As XC1Flexgrid)
        Fg.Cols(iColFgTree).Width = (Fg.Rows.DefaultSize * 2) + 0
    End Sub

    Private Sub ColDialog(Fg As XC1Flexgrid)
        FlexgridColDialog(Fg.BaseGrid)
    End Sub

    Private Sub a_sbalit_vse_Execute(sender As Object, e As EventArgs) Handles a_sbalit_vse.Execute, a_rozbalit_vse.Execute
        SbalitRozbalit(FgA, sender Is a_rozbalit_vse)
    End Sub

    Private Sub SbalitRozbalit(Fg As XC1Flexgrid, bRozbalit As Boolean)
        bLoading = True
        Application.DoEvents()
        Fg.BeginUpdate()
        If Not bRozbalit Then
            For iRow As Integer = Fg.Row To Fg.Row1 Step -1
                If Fg.RowIsValid(iRow) AndAlso Fg.Rows(iRow).IsNode Then
                    '§ nasel jsem koren
                    If Fg.Rows(iRow).Node.Level > 0 Then Continue For
                    Fg.Row = Fg.Rows(iRow).Node.Row.Index
                    Exit For
                End If
            Next
        End If
        For i As Integer = Fg.RowN To Fg.Row1 Step -1
            If Fg.Rows(i).IsNode Then Fg.Rows(i).Node.Expanded = bRozbalit
        Next
        Fg.EnsureVisibleSelectedRow(Fg.Row)
        Fg.EndUpdate()
        bLoading = False
    End Sub

    Private Sub a_sbalitrozbalit_polozku_na_radku_Execute(sender As Object, e As EventArgs) Handles a_sbalitrozbalit_polozku_na_radku.Execute
        Dim Fg As XC1Flexgrid = FgA()
        If Fg.Rows(Fg.Row).IsNode Then Fg.Rows(Fg.Row).Node.Expanded = Not Fg.Rows(Fg.Row).Node.Expanded
        If Fg.Rows(Fg.Row).Node.Expanded Then AutoSizeText(Fg) 'Fg.AutoSizeCol(iColFgText)
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles FgOP.DoubleClick, FgN.DoubleClick, FgFP.DoubleClick, FgFV.DoubleClick
        bLoading = True
        Dim Fg As XC1Flexgrid = FgA()
        If Fg.RowIsValid Then
            Try
                Fg.BeginInit()
                If Fg.Col <= iColFgTree Then
                    a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter__Execute(Nothing, Nothing)
                Else
                    Dim iRow As Integer = Fg.Row
                    If Fg.Rows(iRow).IsNode AndAlso Fg.Rows(Fg.Row).Node.Level = 1 Then
                        Fg.Rows(iRow).Node.Expanded = Not Fg.Rows(iRow).Node.Expanded
                        Fg.Row = iRow
                        Fg.EnsureVisibleSelectedRow()
                    Else
                        For iRow = Fg.Row To Fg.Row1 Step -1
                            If Fg.Rows(iRow).IsNode AndAlso Fg.Rows(iRow).Node.Level > 1 Then
                            Else
                                Fg.Rows(iRow).Node.Expanded = Not Fg.Rows(iRow).Node.Expanded
                                Fg.Row = iRow
                                Fg.EnsureVisibleSelectedRow()
                                Exit For
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
            Finally
                AutoSizeText(Fg)
                Fg.EndInit()
                bLoading = False
            End Try
        End If
    End Sub

    Private Sub a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter__Execute(sender As Object, e As EventArgs) Handles a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Execute
        bLoading = True
        Dim Fg As XC1Flexgrid = FgA()
        Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.ShowSplashLabel, "Upravuji zobrazení dat..")
            Try
                Fg.BeginUpdate()
                For iRow As Integer = Fg.Row To Fg.Row1 Step -1
                    If Fg.RowIsValid(iRow) AndAlso Fg.Rows(iRow).IsNode Then
                        '§ nasel jsem koren
                        If Fg.Rows(iRow).Node.Level > 0 Then Continue For
                        Dim iRowRoot As Integer = Fg.Rows(iRow).Node.Row.Index
                        Dim iExp As Integer = If(Fg.Rows(iRow).Node.Expanded, 1, 0)
                        Dim iCnt As Integer = 1
                        For Each oNd In Fg.Rows(iRow).Node.Nodes
                            iExp += If(oNd.Expanded, 1, 0)
                            iCnt += 1
                            For Each oNd2 In oNd.Nodes
                                iExp += If(oNd2.Expanded, 1, 0)
                                iCnt += 1
                            Next
                        Next
                        Dim bNewState As Boolean = If(iExp = iCnt, False, True)
                        Fg.Rows(iRowRoot).Node.Expanded = bNewState
                        For Each oNd In Fg.Rows(iRow).Node.Nodes
                            oNd.Expanded = bNewState
                            For Each oNd2 In oNd.Nodes
                                oNd2.Expanded = bNewState
                            Next
                        Next
                        If Not bNewState Then Fg.Row = iRow
                        If bNewState Then AutoSizeText(Fg)
                        Fg.Refresh()
                        Fg.EnsureVisibleSelectedRow()
                        'MsgBox("Node " & iRow)
                        Exit Try
                    Else
                        Exit Try
                    End If
                Next
            Catch
            Finally
                AutoSizeText(Fg)
                Fg.EndUpdate()
                bLoading = False
            End Try
        End Using
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FgOP.KeyPress, FgOV.KeyPress, FgN.KeyPress, FgFP.KeyPress, FgFV.KeyPress
        bLoading = True
        Dim Fg As XC1Flexgrid = FgA()
        If e.KeyChar = " "c OrElse e.KeyChar = vbCr Then
            If Control.ModifierKeys And Keys.Shift Then
                a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter__Execute(Nothing, Nothing)
            Else
                If Fg.Rows(Fg.Row).IsNode Then
                    If Fg.Rows(Fg.Row).Node.Nodes.Count > 0 Then
                        Fg.Rows(Fg.Row).Node.Expanded = Not Fg.Rows(Fg.Row).Node.Expanded
                    ElseIf Fg.Rows(Fg.Row).Node.Parent IsNot Nothing Then
                        Fg.Rows(Fg.Row).Node.Parent.Expanded = Not Fg.Rows(Fg.Row).Node.Parent.Expanded
                        If Not Fg.Rows(Fg.Row).Node.Parent.Expanded Then Fg.Row = Fg.Rows(Fg.Row).Node.Parent.Row.Index
                    End If
                End If
                'If Fg.Rows(Fg.Row).IsNode Then Fg.Rows(Fg.Row).Node.Expanded = Not Fg.Rows(Fg.Row).Node.Expanded
            End If
        ElseIf e.KeyChar = "+"c Then
            If Fg.Rows(Fg.Row).IsNode Then Fg.Rows(Fg.Row).Node.Expanded = True
        ElseIf e.KeyChar = "-"c Then
            If Fg.Rows(Fg.Row).IsNode Then Fg.Rows(Fg.Row).Node.Expanded = False
        End If
        bLoading = False
    End Sub

    Private Sub a_o_aplikaci_Execute(sender As Object, e As EventArgs) Handles a_o_aplikaci.Execute
        FAbout.Run(Me)
    End Sub

    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs) Handles FgOP.KeyUp
        If e.KeyValue = 107 AndAlso e.Control Then
            a_sbalit_vse_Execute(a_rozbalit_vse, Nothing)
        ElseIf e.KeyValue = 109 AndAlso e.Control Then
            a_sbalit_vse_Execute(a_sbalit_vse, Nothing)
        End If
    End Sub

    Public Shared Sub ShowError(oForm As Form, ex As Exception)
        MessageBox.Show(oForm, "POZOR!" & vbCrLf & vbCrLf & "Nyní bude povolen import dat do archivu z databáze. Archiv může být importem změněn nebo zničen!", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub tbcMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcMain.SelectedIndexChanged
        Select Case True
            Case tbcMain.SelectedTab Is pgObjPrij
                FgOP.Select()
                a_najit_vlevo.Enabled = True
                a_najit_vpravo.Enabled = True
            Case tbcMain.SelectedTab Is pgNab
                FgN.Select()
                a_najit_vlevo.Enabled = False
                a_najit_vpravo.Enabled = True
            Case tbcMain.SelectedTab Is pgFaktVyd
                FgFV.Select()
                a_najit_vlevo.Enabled = True
                a_najit_vpravo.Enabled = False
            Case tbcMain.SelectedTab Is pgObjVyd
                FgOV.Select()
                a_najit_vlevo.Enabled = False
                a_najit_vpravo.Enabled = True
            Case tbcMain.SelectedTab Is pgFaktPrij
                FgFP.Select()
                a_najit_vlevo.Enabled = True
                a_najit_vpravo.Enabled = False
        End Select
    End Sub

    Private Sub FgFP_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles FgOP.OwnerDrawCell, FgN.OwnerDrawCell, FgFV.OwnerDrawCell, FgFP.OwnerDrawCell
        Dim Fg As XC1Flexgrid = DirectCast(sender, XC1Flexgrid)
        If e.Col = iColFgTree AndAlso e.Row >= Fg.Row1 Then
            Try
                If e.Graphics IsNot Nothing Then
                    e.DrawCell(DrawCellFlags.Background)
                    e.DrawCell(DrawCellFlags.Content)
                    Dim oPen As Pen = New Pen(Fg.Styles.Normal.Border.Color)
                    e.Graphics.DrawLine(oPen, New Point(e.Bounds.X + e.Bounds.Width - 1, e.Bounds.Y), New Point(e.Bounds.X + e.Bounds.Width - 1, e.Bounds.Y + e.Bounds.Height - 1))
                    Try
                        Dim iNxtVis As Integer = -1
                        For iNxt As Integer = e.Row + 1 To Fg.RowN
                            If Not Fg.Rows(iNxt).IsCollapsed Then
                                iNxtVis = iNxt
                                Exit For
                            End If
                        Next
                        If iNxtVis < 0 OrElse CStr(Fg(e.Row, iColFgFirma)) <> CStr(Fg(iNxtVis, iColFgFirma)) Then
                            e.Graphics.DrawLine(oPen, New Point(e.Bounds.X, e.Bounds.Y + e.Bounds.Height - 1), New Point(e.Bounds.X + e.Bounds.Width - 1, e.Bounds.Y + e.Bounds.Height - 1))
                        End If
                    Catch ex As Exception
                        Debug.WriteLine(ex.Message)
                    End Try
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FgFP_AfterResizeColumn(sender As Object, e As RowColEventArgs) Handles FgFP.AfterResizeColumn, FgFV.AfterResizeColumn, FgOP.AfterResizeColumn, FgN.AfterResizeColumn
        Dim Fg As XC1Flexgrid = FgA()
        SetTreeCol(Fg)
    End Sub

    Private Sub a_najit_vpravo_Execute(sender As Object, e As EventArgs) Handles a_najit_vpravo.Execute
        If tbcMain.SelectedTab Is pgNab Then
            NajdiFirmu(CStr(FgN(FgN.Row, iColFgNazevFirmy)), FgOP, pgObjPrij)
        ElseIf tbcMain.SelectedTab Is pgObjPrij Then
            NajdiFirmu(CStr(FgOP(FgOP.Row, iColFgNazevFirmy)), FgFV, pgFaktVyd)
        ElseIf tbcMain.SelectedTab Is pgObjVyd Then
            NajdiFirmu(CStr(FgOV(FgOV.Row, iColFgNazevFirmy)), FgFP, pgFaktPrij)
        End If
    End Sub

    Private Sub a_najit_vlevo_Execute(sender As Object, e As EventArgs) Handles a_najit_vlevo.Execute
        If tbcMain.SelectedTab Is pgFaktVyd Then
            NajdiFirmu(CStr(FgFV(FgFV.Row, iColFgNazevFirmy)), FgOP, pgObjPrij)
        ElseIf tbcMain.SelectedTab Is pgObjPrij Then
            NajdiFirmu(CStr(FgN(FgN.Row, iColFgNazevFirmy)), FgN, pgNab)
        ElseIf tbcMain.SelectedTab Is pgFaktPrij Then
            NajdiFirmu(CStr(FgFP(FgFP.Row, iColFgNazevFirmy)), FgOV, pgObjVyd)
        End If
    End Sub

    Private Function NajdiFirmu(sText As String, FgNew As XC1Flexgrid, PgNew As TabPage) As Boolean
        Dim oFg As XC1Flexgrid = FgA()
        Dim bRet As Boolean = False
        Dim s0 As String = CStr(FgA(FgA.Row, iColFgFirma))
        Dim s1 As String = XControls.CutDiacritic(Replace(s0, " ", ""))
        For iRow As Integer = FgNew.Row1 To FgNew.RowN
            Dim s2 As String = XControls.CutDiacritic(Replace(CStr(FgNew(iRow, iColFgFirma)), " ", ""))
            If String.Compare(s1, s2, True) = 0 Then
                FgNew.Row = iRow
                tbcMain.SelectedTab = PgNew
                FgNew.EnsureVisibleSelectedRow()
                FgNew.Select()
                FgNew.Focus()
                bRet = True
                Exit For
            End If
        Next
        If Not bRet Then
            MessageBox.Show(Me, String.Format("Firma ""{0}"" nebyla na záložce ""{1}"" nalezena.", s0, PgNew.Text), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return bRet
    End Function

    Public oEx As Excel.Application

    Private Sub a_excel_Execute(sender As Object, e As EventArgs) Handles a_excel.Execute
        Dim oEx As Excel.Application = Nothing
        Dim oWbk As Excel.Workbook = Nothing
        Dim oWsh As Excel.Worksheet = Nothing
        Dim sFilename As String = sExcelExpDir
        Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.ShowSplashLabel, "Vytváří se sešit MS Excel (může trvat i několik minut).. ")
            If Not IO.Directory.Exists(sExcelExpDir) Then
                Try
                    IO.Directory.CreateDirectory(sExcelExpDir)
                Catch : End Try
            End If
            sFilename = IO.Path.Combine(IO.Path.Combine(sFilename, tbcMain.SelectedTab.Text & Now.ToString("_yyyyMMdd_HHmm") & ".xlsx"))
            'FgA.SaveExcel(sFilename, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells Or C1.Win.C1FlexGrid.FileFlags.AsDisplayed Or C1.Win.C1FlexGrid.FileFlags.VisibleOnly Or C1.Win.C1FlexGrid.FileFlags.IncludeMergedRanges Or C1.Win.C1FlexGrid.FileFlags.SaveMergedRanges)
            FgA.BaseGrid.SaveExcel(sFilename, C1.Win.C1FlexGrid.FileFlags.AsDisplayed Or FileFlags.VisibleOnly Or FileFlags.IncludeFixedCells Or FileFlags.IncludeMergedRanges Or FileFlags.LoadMergedRanges)

            If bUseExcel Then
                Try
                    oEx = New Excel.Application
                    oEx.ScreenUpdating = False
                    oWbk = oEx.Workbooks.Open(sFilename)
                    oEx.WindowState = Excel.XlWindowState.xlNormal
                    oWsh = oWbk.Sheets(1)
                Catch ex As Exception
                    MessageBox.Show(Me, String.Format("Na této stanici zřejmě není nainstalována funkční aplikace MS Excel.{0}{0}Nelze provést žádné dodatečné úpravy exportovaného souboru.", vbCrLf, AData.CurrentFile), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GoTo endexcel
                End Try

                'Dim iMaxCol As Integer = 0
                'For i As Integer = 0 To FgA.ColN
                '    If FgA.Cols(i).Visible Then iMaxCol += 1
                'Next
                clck.SetProgressText("Nastavuje se viditelnost jednotlivých řádků")
                Dim iRow As Integer = 0
                Dim iExr As Integer = FgA.Rows.Fixed
                Dim oRg As Excel.Range = oWsh.Rows(String.Format("{0}:{1}", FgA.Rows.Fixed + 1, FgA.Rows.Count))
                If bSimpleExcel Then oRg.Hidden = True
                For iRow = FgA.Row1 To FgA.RowN
                    If FgA.Rows(iRow).IsNode AndAlso FgA.Rows(iRow).Node.Level = 0 Then iExr += 1
                    If FgA.Rows(iRow).IsNode AndAlso FgA.Rows(iRow).Node.Level = 0 AndAlso FgA.Rows(iRow).Node.Expanded Then
                        oRg = oWsh.Rows(iExr)
                        oRg.Hidden = False
                        For Each oNd As Node In FgA.Rows(iRow).Node.Nodes
                            iExr += 1
                            oRg = oWsh.Rows(iExr)
                            oRg.Hidden = False
                            If oNd.Expanded Then
                                For Each oNd2 As Node In oNd.Nodes
                                    iExr += 1
                                    oRg = oWsh.Rows(iExr)
                                    oRg.Hidden = False
                                Next
                            End If
                        Next
                    End If
                Next
                oRg = oWsh.Range(oWsh.Cells(1, 1), oWsh.Cells(2, FgA.Cols.Count + 1))
                With oRg
                    .Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    .Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    .Font.Size = 7
                    .Font.Italic = True
                    With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlHairline
                    End With
                    With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlHairline
                    End With
                    With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlHairline
                    End With
                    With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlHairline
                    End With
                    With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlHairline
                    End With
                End With
                oRg = oWsh.Range(oWsh.Cells(FgA.Rows.Fixed + 1, 1), oWsh.Cells(iExr, FgA.Cols.Count + 1))
                With oRg
                    .Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    .Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                    End With
                    With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                    End With
                    With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                    End With
                    With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                    End With
                    With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                    End With
                    With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                    End With
                End With
                oRg = oWsh.Range(oWsh.Cells(FgA.Rows.Fixed + 1, 1), oWsh.Cells(iExr, 2))
                oRg.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                oRg.VerticalAlignment = Excel.XlVAlign.xlVAlignTop
            End If
endexcel:
        End Using
        If oEx Is Nothing Then
            If MessageBox.Show(Me, String.Format("Export do formátu MS Excel byl uložen do souboru{0}{0}{1}{0}{0}{0}Chceš tento soubor nyní otevřít?", vbCrLf, sFilename), txtAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim oPr As New Process
                oPr.StartInfo.FileName = sFilename
                oPr.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(sFilename)
                oPr.StartInfo.UseShellExecute = True
                oPr.Start()
            End If
        Else
            oEx.ScreenUpdating = True
            oEx.Visible = True
        End If

    End Sub

    Public Sub FgO_AfterCollapse(sender As Object, e As RowColEventArgs) Handles FgOP.AfterCollapse, FgN.AfterCollapse, FgFP.AfterCollapse, FgFV.AfterCollapse, FgOV.AfterCollapse
        If Not bLoading Then
            Dim Fg As XC1Flexgrid = DirectCast(sender, XC1Flexgrid)
            If e Is Nothing OrElse (Fg.Rows(e.Row).IsNode AndAlso Fg.Rows(e.Row).Node.Expanded) Then
                'Fg.AutoSizeCol(iColFgText)
                AutoSizeText(sender)
            End If
        End If
    End Sub

    Public Sub AutoSizeText(sender As Object)
        If TypeOf (sender) Is XC1Flexgrid AndAlso a_automaticky_upravovat_sirku_sloupce_textu.Checked Then
            With CType(sender, XC1Flexgrid)
                Dim oSize As Size = .ClientSize
                .AutoSizeCol(iColFgText)
                If .Cols(.ColN).Right > .ClientSize.Width Then
                    Dim iWid = .Cols(iColFgText).Width - (.ClientSize.Width - .Cols(.ColN).Right) - (.Width - .ClientSize.Width)
                    If iWid > 100 Then .Cols(iColFgText).Width = iWid
                End If
            End With
        End If
    End Sub

    Private Sub a_statistika_polozek_v_databazi_Execute(sender As Object, e As EventArgs) Handles a_statistika_polozek_v_databazi.Execute
        Dim iPolN As Integer = 0
        Dim iPolOP As Integer = 0
        Dim iPolFV As Integer = 0
        Dim iPolFP As Integer = 0
        Dim iPolOV As Integer = 0
        Dim iPolNi As Integer = 0
        Dim iPolOPi As Integer = 0
        Dim iPolOVi As Integer = 0
        Dim iPolFVi As Integer = 0
        Dim iPolFPi As Integer = 0
        If AData.LoadXMLData(AData.ValidFileVersion) Then
            For Each o As AData.AFirma In AData.oAdata.aoFirmyNab
                iPolN += o.aoDoc.Count
                For Each o2 In o.aoDoc
                    iPolNi += o2.aoObjPol.Count
                Next
            Next
            For Each o As AData.AFirma In AData.oAdata.aoFirmyObjPrij
                iPolOP += o.aoDoc.Count
                For Each o2 In o.aoDoc
                    iPolOPi += o2.aoObjPol.Count
                Next
            Next
            For Each o As AData.AFirma In AData.oAdata.aoFirmyObjVyd
                iPolOV += o.aoDoc.Count
                For Each o2 In o.aoDoc
                    iPolOVi += o2.aoObjPol.Count
                Next
            Next
            For Each o As AData.AFirma In AData.oAdata.aoFirmyFVyd
                iPolFV += o.aoDocF.Count
                For Each o2 In o.aoDocF
                    iPolFVi += o2.aoFaktPol.Count
                Next
            Next
            For Each o As AData.AFirma In AData.oAdata.aoFirmyFPrij
                iPolFP += o.aoDocF.Count
                For Each o2 In o.aoDocF
                    iPolFPi += o2.aoFaktPol.Count
                Next
            Next
        End If
        Dim s1 As String = "Nabídky: {2}{0} firem, {2}{1} položek"
        Dim s2 As String = "Objednávky přij.: {2}{0} firem, {2}{1} položek"
        Dim s3 As String = "Faktury vydané: {2}{0} firem, {2}{1} položek"
        Dim s4 As String = "Objednávky vyd.: {2}{0} firem, {2}{1} položek"
        Dim s5 As String = "Faktury přijaté: {2}{0} firem, {2}{1} položek"
        Dim s6 As String = "Celkem: {1}{0} položek"
        Dim s As String = String.Format(s1, iPolN, iPolNi, vbTab) & vbCrLf & String.Format(s2, iPolOP, iPolOPi, vbTab) & vbCrLf & String.Format(s3, iPolFV, iPolFVi, vbTab) &
                          vbCrLf & String.Format(s4, iPolOV, iPolOVi, vbTab) & vbCrLf & String.Format(s5, iPolFP, iPolFPi, vbTab) & vbCrLf & vbCrLf &
                          String.Format(s6, iPolNi + iPolOPi + iPolOVi + iPolFVi + iPolFPi, vbTab)
        MessageBox.Show(Me, String.Format("Statistika počtů položek archivu ""{2}"":{0}{0}{1}", vbCrLf, s, AData.CurrentFile), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub a_zobrazit_skryte_polozky_Execute(sender As Object, e As EventArgs)
        For iRow As Integer = FgA.Row1 To FgA.RowN
            FgA.Rows(iRow).Visible = True
        Next
        FgA.EnsureVisibleSelectedRow()
    End Sub

    Private Sub a_prejit_na_dalsi_nalezeby_radek_Execute(sender As Object, e As EventArgs) Handles a_prejit_na_dalsi_nalezeby_radek.Execute
        For iRow As Integer = FgA.Row + 1 To FgA.RowN
            If FgA.GetCellStyle(iRow, 0) IsNot Nothing Then ' AndAlso FgA.GetCellStyle(iRow, 0).BackColor.ToArgb = SystemColors.HighlightText.ToArgb Then
                FgA.Row = iRow
                FgA.EnsureVisibleSelectedRow()
                Exit For
            End If
        Next
    End Sub

    Private Sub a_prejit_na_predchozi_nalezeny_radek_Execute(sender As Object, e As EventArgs) Handles a_prejit_na_predchozi_nalezeny_radek.Execute
        For iRow As Integer = FgA.Row - 1 To FgA.Row1 Step -1
            If FgA.GetCellStyle(iRow, 0) IsNot Nothing Then ' AndAlso FgA.GetCellStyle(iRow, 0).BackColor.ToArgb = SystemColors.HighlightText.ToArgb Then
                FgA.Row = iRow
                FgA.EnsureVisibleSelectedRow()
                Exit For
            End If
        Next
    End Sub

    Private Function AutoUpdateMdbData(sCurrentFile As String, cLck As cLockForm) As Boolean
        Dim bRet As Boolean = False
        If AData.oAdata IsNot Nothing AndAlso bAutoUpdate Then
            Dim maoFiles As New List(Of AData.AFile)
            Dim bUpd As Boolean = False
            maoFiles.AddRange(AData.oAdata.aoFiles)
            For Each o In maoFiles
                If (o.Attr And AData.AFile.Attributes.AutoUpdate) <> 0 AndAlso DriveInfo.CheckAccessibility(o.UsedFileName) AndAlso IO.File.Exists(o.UsedFileName) Then
                    If IO.File.GetLastWriteTime(o.UsedFileName) <> o.FileDate AndAlso o.DateImported.Date < Now.Date Then
                        If MessageBox.Show(Me, String.Format("Data v databázi:{1}{0} byla změněna.{1}{1}Chceš nyní archiv aktualizovat?", o.UsedFileName, vbCrLf), txtAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            cLck.SetProgressText("Nyní probíhá aktualizace archivu Pohoda (může trvat několik vteřin)..")
                            Application.DoEvents()
                            Dim iRemoved As Integer = 0
                            Dim iAdded As Integer = 0
                            Dim bCancel As Boolean = False
                            AData.oAdata = AData.LoadMdbData(o.UsedFileName, PwDecode(o.Pw), sCurrentFile, iRemoved, iAdded, bCancel)
                            AData.oAdata.FileVersion = AData.ValidFileVersion
                            IO.File.WriteAllText(sCurrentFile, AData.oAdata.ToXml)
                            bRet = True
                        Else
                            bAutoUpdate = False
                        End If
                    End If
                End If
            Next
        End If
        Return bRet
    End Function

    Private Sub a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace__Execute(sender As Object, e As EventArgs) Handles a_zprava_vyvojare_soupis_zmen_a_uprav_teto_aplikace_.Execute
        FDevMsg.ShowForm(Me)
    End Sub

    Private Sub a_logika_vyhledavani_v_tabulce_Execute(sender As Object, e As EventArgs) Handles a_logika_vyhledavani_v_tabulce.Execute
        FInfo.Run(Me, "LogikaVyhledavani.rtf",, a_logika_vyhledavani_v_tabulce.Text)
    End Sub
End Class
