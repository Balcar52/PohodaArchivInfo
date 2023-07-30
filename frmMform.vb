' text upraven 21.06.2023 23:48:11 jiri/JIRIBARTUSEK
' CorrectForm 22.12.2021; 1.2.0.37; ©2016-19 Ing. Jiri Bartusek
' 
' Deklarace cisel sloupcu pro Flexgrid - pocet uprav: 1. 21.06.2023 23:48:05
Imports XControls
Imports XForms
Imports C1.Win.C1FlexGrid

Public Class MForm

    Public Const nmCurrentFile As String = "CurrentFile"


    ' deklarace promennych cisel sloupcu gridu 

    Dim iColFg0 As Integer ' [g:0]
    Dim iColFgFirma As Integer ' [g:1]
    Dim iColFgICO As Integer ' [g:1]
    Dim iColFgKlic As Integer ' [g:2]
    Dim iColFgDatum As Integer ' [g:3]
    Dim iColFgCislo As Integer ' [g:4]
    Dim iColFgNazevFirmy As Integer ' [g:5]
    Dim iColFgText As Integer ' [g:6]
    Dim iColFgPozn As Integer ' [g:7]
    Dim iColFgMnozstvi As Integer ' [g:8]
    Dim iColFgCena As Integer ' [g:8]
    Dim iColFgPocO As Integer ' [g:8]
    Dim iColFgPocP As Integer ' [g:8]
    Dim iColFgTree As Integer ' [g:8]

    Public Sub InitGrid(Fg As XC1Flexgrid, Nazev1 As String, oBackColor As Color, Optional bFaktMode As Boolean = False)
        Fg.BackColor = oBackColor
        FlexgridSet(Fg) '' [CorrectForm 17.4.2019 22:43]' [CorrectForm 21.6.2023 23:48]
        iColFg0 = FlexgridSetCol(">")
        iColFgFirma = FlexgridSetCol("firma,250,RSM<")
        iColFgICO = FlexgridSetCol("IČ,40,RM>")
        iColFgKlic = FlexgridSetCol("klíč,100,R<")
        iColFgTree = FlexgridSetCol(",30,R,")
        iColFgPocO = FlexgridSetCol("poč.,40,RI^", Nazev1)
        iColFgDatum = FlexgridSetCol("datum,80,RMd>", "*")
        iColFgCislo = FlexgridSetCol("číslo,80,RIM>", "*")
        iColFgNazevFirmy = FlexgridSetCol("název firmy,80,R<", "*")
        iColFgPocP = FlexgridSetCol("poč.,40,RI^", "položky")
        iColFgText = FlexgridSetCol("text,80,R<", "*")
        iColFgMnozstvi = FlexgridSetCol("množství,80,RID>,#####0", "*")
        If bFaktMode Then
            iColFgMnozstvi = FlexgridSetCol("cena,80,RID>,### ##0", "*")
        Else
            iColFgMnozstvi = FlexgridSetCol("@")
        End If
        iColFgPozn = FlexgridSetCol("pozn.,80,R<")
        FlexgridSetExec() ' [CorrectForm 21.6.2023 23:48]

        Fg.Cols(iColFgKlic).Visible = False
        Fg.Cols(iColFgICO).Visible = False
        Fg.Cols(iColFgNazevFirmy).Visible = False

        Fg.Tree.Column = iColFgTree

        AddFlexGridStyle(1, FontStyle.Bold, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
        AddFlexGridStyle(2, FontStyle.Italic, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)

        Fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom
        Fg.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus
        Fg.ExtendLastCol = True

        SetFlexGridStyleToCols(1, iColFgFirma)
        SetFlexGridStyleToCols(2, iColFgNazevFirmy)

        FlexgridSetGlobalFormat()
        Fg.SelectionMode = SelectionModeEnum.Default

        Fg.Styles.Highlight.BackColor = Fg.Styles.Normal.BackColor
        Fg.Styles.Highlight.ForeColor = Fg.Styles.Normal.ForeColor
        Fg.AutoSearch = AutoSearchEnum.FromCursor

        Fg.FocusRect = FocusRectEnum.Heavy
        Fg.SelectionMode = SelectionModeEnum.Cell
    End Sub

    Public Sub InitGridF(Fg As XC1Flexgrid, Nazev1 As String, oBackColor As Color)
        Fg.BackColor = oBackColor
        FlexgridSet(Fg) '' [CorrectForm 17.4.2019 22:43]' [CorrectForm 21.6.2023 23:48]
        iColFg0 = FlexgridSetCol(">")
        iColFgFirma = FlexgridSetCol("firma,250,RSM<")
        iColFgICO = FlexgridSetCol("IČ,40,RM>")
        iColFgKlic = FlexgridSetCol("klíč,100,R<")
        iColFgTree = FlexgridSetCol(",30,R,")
        iColFgPocO = FlexgridSetCol("poč.,40,RI^", Nazev1)
        iColFgDatum = FlexgridSetCol("datum,80,RMd>", "*")
        iColFgCislo = FlexgridSetCol("číslo,80,RIM>", "*")
        iColFgNazevFirmy = FlexgridSetCol("název firmy,80,R<", "*")
        iColFgPocP = FlexgridSetCol("poč.,40,RI^", "položky")
        iColFgText = FlexgridSetCol("text,80,R<", "*")
        iColFgMnozstvi = FlexgridSetCol("množství,80,RID>,#####0", "*")
        iColFgPozn = FlexgridSetCol("pozn.,80,R<")
        FlexgridSetExec() ' [CorrectForm 21.6.2023 23:48]

        Fg.Cols(iColFgKlic).Visible = False
        Fg.Cols(iColFgICO).Visible = False
        Fg.Cols(iColFgNazevFirmy).Visible = False

        Fg.Tree.Column = iColFgTree

        AddFlexGridStyle(1, FontStyle.Bold, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
        AddFlexGridStyle(2, FontStyle.Italic, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)

        Fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom
        Fg.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Fg.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.WithFocus
        Fg.ExtendLastCol = True

        SetFlexGridStyleToCols(1, iColFgFirma)
        SetFlexGridStyleToCols(2, iColFgNazevFirmy)

        FlexgridSetGlobalFormat()
        Fg.SelectionMode = SelectionModeEnum.Default

        Fg.Styles.Highlight.BackColor = Fg.Styles.Normal.BackColor
        Fg.Styles.Highlight.ForeColor = Fg.Styles.Normal.ForeColor
        Fg.AutoSearch = AutoSearchEnum.FromCursor

        Fg.FocusRect = FocusRectEnum.Heavy
        Fg.SelectionMode = SelectionModeEnum.Cell
    End Sub

    Public Sub LoadData()
        a_excel.Enabled = False
        FgO.ClearDataRows(True, True)
        FgN.ClearDataRows(True, True)
        FgFP.ClearDataRows(True, True)
        FgFV.ClearDataRows(True, True)
        Application.DoEvents()

        Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.ShowSplashLabel, "Načítám data z archivu " & IO.Path.GetFileName(AData.CurrentFile))
            AData.LoadXMLData()
            RefreshStb()
            With AData.oAdata
                LoadObjList(FgO, .aoFirmyObj)
                LoadObjList(FgN, .aoFirmyNab)
                LoadFakList(FgFV, .aoFirmyFVyd)
                LoadFakList(FgFP, .aoFirmyFPrij)
            End With
        End Using
        a_excel.Enabled = True
        Dim Fg As XC1Flexgrid
        If tbcMain.SelectedTab Is pgObj Then
            Fg = FgO
        ElseIf tbcMain.SelectedTab Is pgNab Then
            Fg = FgN
        ElseIf tbcMain.SelectedTab Is pgFaktVyd Then
            Fg = FgFV
        ElseIf tbcMain.SelectedTab Is pgFaktPrij Then
            Fg = FgFP
        Else
            Exit Sub
        End If
        SetTreeCol(FgO)
        SetTreeCol(FgN)
        SetTreeCol(FgFP)
        SetTreeCol(FgFV)
        Fg.Col = iColFgFirma
        Fg.Redraw = True
        Fg.Select()
        Fg.Focus()
    End Sub

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
            Fg(iRow, iColFgFirma) = oFrm.DisplayName
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
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 1
            Fg.Rows(iRow).UserData = oObj
        End If
        If oObjP IsNot Nothing Then
            'iRow = Fg.Rows.Add.Index
            Fg(iRow, iColFgText) = Trim(oObjP.Text)
            Fg.SetStyleToCell(iRow, iColFgText,,, FontStyle.Bold)
            Fg(iRow, iColFgPozn) = Trim(oObjP.Pozn)
            Fg(iRow, iColFgMnozstvi) = oObjP.Mnoz
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 2
            Fg.Rows(iRow).UserData = oObjP
        End If
    End Sub

    Public Sub LoadDataRowF(Fg As XC1Flexgrid, ByRef iRow As Integer, Optional oFrm As AData.AFirma = Nothing, Optional oFakt As AData.AFakt = Nothing, Optional oFakP As AData.AFaktPol = Nothing)
        iRow = Fg.Rows.Add.Index
        If oFrm IsNot Nothing Then
            'iRow = Fg.Rows.Add.Index
            Fg(iRow, iColFgFirma) = oFrm.DisplayName
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
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 1
            Fg.Rows(iRow).UserData = oFakt
        End If
        If oFakP IsNot Nothing Then
            'iRow = Fg.Rows.Add.Index
            Fg(iRow, iColFgText) = Trim(oFakP.Text)
            Fg.SetStyleToCell(iRow, iColFgText,,, FontStyle.Bold)
            Fg(iRow, iColFgPozn) = Trim(oFakP.Pozn)
            Fg(iRow, iColFgMnozstvi) = oFakP.Mnoz
            Fg.Rows(iRow).IsNode = True
            Fg.Rows(iRow).Node.Level = 2
            Fg.Rows(iRow).UserData = oFakP
        End If
    End Sub

    Private Sub MForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        WindowRestore(Me)
        FlexgridRestore(FgO,,,, False)
        FlexgridRestore(FgN,,,, False)
        AData.CurrentFile = StringRestore(nmCurrentFile)
        LoadData()
        FlexgridRestorePosition(FgO)
        FlexgridRestorePosition(FgN)
        TabControlRestore(tbcMain)
    End Sub

    Private Sub MForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        iMForm = Me
        sConnStdCtr = poConn.ConnectionString
        oConn = poConn
        RefreshStb()
        InitGrid(FgO, "objednávky", Color.FromArgb(&HFFE0FFE0))
        InitGrid(FgN, "nabídky", Color.FromArgb(&HFFE0E0FF))
        InitGrid(FgFV, "vydané faktury", Color.FromArgb(&HFFFFE0E0), True)
        InitGrid(FgFP, "přijaté faktury", Color.FromArgb(&HFFFFFFE0), True)
        FGridSearchText.RegisterForAllGrids(Me, a_searchtext, a_searchtextnext)
    End Sub

    Public Sub RefreshStb()
        If IO.File.Exists(AData.CurrentFile) Then
            lblArchiveFile.Text = AData.CurrentFile
            lblArchiveFileSize.Text = (New IO.FileInfo(AData.CurrentFile).Length).ToString("## ### ##0 B")
            lblArchiveFileTime.Text = IO.File.GetLastWriteTime(AData.CurrentFile).ToString
        Else
            lblArchiveFile.Text = ""
            lblArchiveFileSize.Text = ""
            lblArchiveFileTime.Text = ""
        End If
    End Sub

    Public Sub SaveCurrentFileName()
        WindowSet(Me)
        StringSave(nmCurrentFile, AData.CurrentFile)
    End Sub

    Private Sub MForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WindowSave(Me)
        TabControlSave(tbcMain)
        FlexgridSave(FgO)
        FlexgridSave(FgN)
        FlexgridSavePosition(FgO)
        FlexgridSavePosition(FgN)
        StringSave(nmCurrentFile, AData.CurrentFile)
    End Sub

    Private Sub a_close_Execute(sender As Object, e As EventArgs) Handles a_close.Execute
        Me.Close()
    End Sub

    Private Sub a_sprava_aplikace_Execute(sender As Object, e As EventArgs) Handles a_sprava_aplikace.Execute
        If FOptions.Run(Me) = DialogResult.OK Then LoadData()
    End Sub

    Private Sub a_znovunacist_data_Execute(sender As Object, e As EventArgs) Handles a_znovunacist_data.Execute
        LoadData()
    End Sub

    Private Function FgA() As XC1Flexgrid
        Select Case True
            Case tbcMain.SelectedTab Is pgObj
                Return FgO
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
    End Sub

    Private Sub a_sbalitrozbalit_polozku_na_radku_Execute(sender As Object, e As EventArgs) Handles a_sbalitrozbalit_polozku_na_radku.Execute
        Dim Fg As XC1Flexgrid = FgA()
        If Fg.Rows(Fg.Row).IsNode Then Fg.Rows(Fg.Row).Node.Expanded = Not Fg.Rows(Fg.Row).Node.Expanded
        If Fg.Rows(Fg.Row).Node.Expanded Then Fg.AutoSizeCol(iColFgText)
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles FgO.DoubleClick, FgN.DoubleClick, FgFP.DoubleClick, FgFV.DoubleClick
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
                Fg.EndInit()
            End Try
        End If
    End Sub

    Private Sub a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter__Execute(sender As Object, e As EventArgs) Handles a_sbalitrozbalit_vsechny_polozky_firmy_shift_enter_.Execute
        Dim Fg As XC1Flexgrid = FgA()
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
                    If bNewState Then Fg.AutoSizeCol(iColFgText)
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
            Fg.EndUpdate()
        End Try
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FgO.KeyPress, FgN.KeyPress, FgFP.KeyPress, FgFV.KeyPress
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
    End Sub

    Private Sub a_o_aplikaci_Execute(sender As Object, e As EventArgs) Handles a_o_aplikaci.Execute
        FAbout.Run(Me)
    End Sub

    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs) Handles FgO.KeyUp
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
            Case tbcMain.SelectedTab Is pgObj
                FgO.Select()
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
            Case tbcMain.SelectedTab Is pgFaktPrij
                FgFP.Select()
                a_najit_vlevo.Enabled = False
                a_najit_vpravo.Enabled = False
        End Select
    End Sub

    Private Sub FgFP_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles FgO.OwnerDrawCell, FgN.OwnerDrawCell, FgFV.OwnerDrawCell, FgFP.OwnerDrawCell
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

    Private Sub FgFP_AfterResizeColumn(sender As Object, e As RowColEventArgs) Handles FgFP.AfterResizeColumn, FgFV.AfterResizeColumn, FgO.AfterResizeColumn, FgN.AfterResizeColumn
        Dim Fg As XC1Flexgrid = FgA()
        SetTreeCol(Fg)
    End Sub

    Private Sub a_najit_vpravo_Execute(sender As Object, e As EventArgs) Handles a_najit_vpravo.Execute
        If tbcMain.SelectedTab Is pgNab Then
            NajdiFirmu(CStr(FgN(FgN.Row, iColFgNazevFirmy)), FgO, pgObj)
        ElseIf tbcMain.SelectedTab Is pgObj Then
            NajdiFirmu(CStr(FgO(FgO.Row, iColFgNazevFirmy)), FgFV, pgFaktVyd)
        End If
    End Sub

    Private Sub a_najit_vlevo_Execute(sender As Object, e As EventArgs) Handles a_najit_vlevo.Execute
        If tbcMain.SelectedTab Is pgFaktVyd Then
            NajdiFirmu(CStr(FgFV(FgFV.Row, iColFgNazevFirmy)), FgO, pgObj)
        ElseIf tbcMain.SelectedTab Is pgObj Then
            NajdiFirmu(CStr(FgN(FgN.Row, iColFgNazevFirmy)), FgN, pgNab)
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

    Private Sub a_excel_Execute(sender As Object, e As EventArgs) Handles a_excel.Execute
        Dim sFilename As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        sFilename = IO.Path.Combine(IO.Path.Combine(sFilename, tbcMain.SelectedTab.Text & Now.ToString("_yyyyMMdd_Hmm") & ".xlsx"))
        'FgA.SaveExcel(sFilename, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells Or C1.Win.C1FlexGrid.FileFlags.AsDisplayed Or C1.Win.C1FlexGrid.FileFlags.VisibleOnly Or C1.Win.C1FlexGrid.FileFlags.IncludeMergedRanges Or C1.Win.C1FlexGrid.FileFlags.SaveMergedRanges)
        FgA.BaseGrid.SaveExcel(sFilename, C1.Win.C1FlexGrid.FileFlags.AsDisplayed Or FileFlags.VisibleOnly Or FileFlags.IncludeFixedCells Or FileFlags.IncludeMergedRanges Or FileFlags.LoadMergedRanges)
        Dim oPr As New Process
        oPr.StartInfo.FileName = sFilename
        oPr.Start()
    End Sub
End Class
