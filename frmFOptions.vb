﻿' text upraven 22.06.2023 3:58:31 jiri/JIRIBARTUSEK
' CorrectForm 22.12.2021; 1.2.0.37; ©2016-19 Ing. Jiri Bartusek
' 
' Deklarace cisel sloupcu pro Flexgrid - pocet uprav: 1. 22.06.2023 3:58:26
Imports System.Data.OleDb

Public Class FOptions

    Dim oMainForm As MForm3
    Dim bLoading As Boolean = True
    Dim bLoaded As Boolean = False

    ' deklarace promennych cisel sloupcu gridu 
    Dim iColFgF0 As Integer ' [g:0]
    Dim iColFgFKlicoveJmeno As Integer ' [g:1]
    Dim iColFgFCesta As Integer ' [g:2]
    Dim iColFgFDatum As Integer ' [g:3]
    Dim iColFgFImportovano As Integer ' [g:3]
    Dim iColFgFDel As Integer ' [g:3]
    Dim iColFgFId As Integer ' [g:4]
    Dim iColFgFUpd As Integer ' [g:4]

    Dim dfFgOP As ColorPair
    Dim dfFgOV As ColorPair
    Dim dfFgN As ColorPair
    Dim dfFgFV As ColorPair
    Dim dfFgFP As ColorPair

    Public Sub New(oOwner As MForm3, Optional RestoreMain As Boolean = True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dfFgOP = clrFgOP.ColorSetting
        dfFgOV = clrFgOV.ColorSetting
        dfFgN = clrFgN.ColorSetting
        dfFgFV = clrFgFV.ColorSetting
        dfFgFP = clrFgFP.ColorSetting
        If RestoreMain Then
            clrFgN.ColorSetting = oOwner.clrFgN
            clrFgOP.ColorSetting = oOwner.clrFgOP
            clrFgFV.ColorSetting = oOwner.clrFgFV
            clrFgFP.ColorSetting = oOwner.clrFgFP
            clrFgOV.ColorSetting = oOwner.clrFgOV
            gbColors.Checked = oOwner.bSetTabColors
            chkUseExcel.Checked = oOwner.bUseExcel
            chkSimpleExcel.Checked = oOwner.bSimpleExcel
            txtMSExcelDir.Text = oOwner.sExcelExpDir
            SetSimpleExcel()
        End If
        If oOwner IsNot Nothing Then
            oMainForm = oOwner
            Me.Owner = oOwner
            Init()
            RestoreFrm()
        End If
    End Sub

    Public Shared Function Run(oOwner As MForm3, Optional ByRef oRetForm As FOptions = Nothing) As DialogResult
        Dim oFrm As New FOptions(oOwner)
        Dim oRes As DialogResult = DialogResult.None
        oRes = oFrm.ShowDialog
        oRetForm = oFrm
        Return oRes
    End Function

    Private Sub btnProcessImport_Click(sender As Object, e As EventArgs) Handles btnProcessImport.Click
        Try
            Dim iRemoved As Integer = 0
            Dim iAdded As Integer = 0
            Dim bCancel As Boolean = False
            Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.ShowSplashLabel, "Načítám data z databáze Pohoda (může trvat několik vteřin)..")
                AData.oAdata = AData.LoadMdbData(txtMdbFile.Text, txtMdbPassword.Text, txtCurrentFile.Text, iRemoved, iAdded, bCancel)
                If bCancel Then Exit Sub
                If AData.oAdata IsNot Nothing Then
                    AData.oAdata.FileVersion = AData.ValidFileVersion
                    IO.File.WriteAllText(txtCurrentFile.Text, AData.oAdata.ToXml)
                    LoadFgData(txtCurrentFile.Text)
                Else
                    MessageBox.Show(Me, String.Format("{0}.{1}{1}Existující soubor je zřejmě potřeba nejprve vymazat a vytvořit nový (např. použitím buttonu ""{2}"").", AData.sError, vbCrLf, btnCreateA.Text), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If bLoaded Then btnClose.DialogResult = DialogResult.OK
                'LoadFgData(txtCurrentFile.Text)
            End Using
            MessageBox.Show(Me, String.Format("Import dat z databáze ""{0}"" do archivu ""{1}"" byl úspěšně dokončen.{2}{2}Počet položek: odstraněných: {3}, přidaných: {4}.",
                                              txtMdbFile.Text, txtCurrentFile.Text, vbCrLf, iRemoved, iAdded), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MForm3.ShowError(Me, ex)
        End Try
    End Sub



    Private Sub btnUpdateAll_Click(sender As Object, e As EventArgs) Handles btnUpdateAll.Click
        Dim oSb As New Text.StringBuilder
        If AData.oAdata IsNot Nothing Then
            Dim maoFiles As New List(Of AData.AFile)
            Dim bUpd As Boolean = False
            maoFiles.AddRange(AData.oAdata.aoFiles)
            For Each o In maoFiles
                Try
                    If IO.File.Exists(o.UsedFileName) Then
                        If IO.File.GetLastWriteTime(o.UsedFileName) = o.FileDate Then
                            oSb.AppendLine(String.Format("{0}{1}{2}- soubor nezměněn.", o.UsedFileName, vbCrLf, vbTab))
                        Else
                            Dim iRemoved As Integer = 0
                            Dim iAdded As Integer = 0
                            Dim bCancel As Boolean = False
                            AData.oAdata = AData.LoadMdbData(o.UsedFileName, PwDecode(o.Pw), txtCurrentFile.Text, iRemoved, iAdded, bCancel)
                            AData.oAdata.FileVersion = AData.ValidFileVersion
                            IO.File.WriteAllText(txtCurrentFile.Text, AData.oAdata.ToXml)
                            bUpd = True
                            oSb.AppendLine(String.Format("{0}{1}{2}- SOUBOR AKTUALIZOVÁN.", o.UsedFileName, vbCrLf, vbTab))
                        End If
                    Else
                        oSb.AppendLine(String.Format("{0}{1}{2}- ** soubor není dostupný.", o.UsedFileName, vbCrLf, vbTab))
                    End If
                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message, txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            Next
            If bUpd Then btnClose.DialogResult = DialogResult.OK
            LoadFgData(txtCurrentFile.Text)
            MessageBox.Show(Me, String.Format("Aktualizace archivu:{0}{0}{1}", vbCrLf, oSb.ToString), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FOptions_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadFgData(txtCurrentFile.Text)
        bLoaded = True
        bLoading = False
    End Sub

    Private Sub Init()
        FlexgridSet(FgF) '' [CorrectForm 17.4.2019 22:43]' [CorrectForm 21.6.2023 23:48]' [CorrectForm 22.6.2023 3:58]
        iColFgF0 = FlexgridSetCol(">")
        iColFgFKlicoveJmeno = FlexgridSetCol("klíčové jméno,100,RS<", "databáze")
        iColFgFCesta = FlexgridSetCol("cesta,100,RS<", "*")
        iColFgFDatum = FlexgridSetCol("verze z,100,RDT>", "*")
        iColFgFImportovano = FlexgridSetCol("importováno,100,RDT>", "*")
        iColFgFUpd = FlexgridSetCol("aut.\naktualizace,50,BE^", "*")
        iColFgFDel = FlexgridSetCol(",50,^", "*")
        iColFgFId = FlexgridSetCol("ID,80,RI>", "*")
        FlexgridSetExec() ' [CorrectForm 22.6.2023 3:58]

        FlexgridSetGlobalFormat()

        FgF.Styles.Highlight.BackColor = FgF.Styles.Normal.BackColor
        FgF.Styles.Highlight.ForeColor = FgF.Styles.Normal.ForeColor
        FgF.SelectionMode = SelectionModeEnum.Cell
        FgF.AllowEditing = False

        ShowDelImages()

    End Sub

    Public Sub ShowDelImages()
        FgF.Cols(iColFgFDel).Visible = chkAllowImport.Checked
    End Sub

    Private Sub LoadFgData(sFileName As String)
        FgF.ClearDataRows()
        FgF.Redraw = False
        Dim oData As AData = AData.LoadXMLDataInfo(sFileName)
        If oData IsNot Nothing Then
            With oData
                For Each o In .aoFiles
                    Dim iRow As Integer = FgF.Rows.Add.Index
                    FgF(iRow, iColFgFKlicoveJmeno) = o.PureFileName
                    FgF(iRow, iColFgFCesta) = o.UsedFileName
                    FgF(iRow, iColFgFDatum) = o.FileDate
                    FgF(iRow, iColFgFUpd) = (o.Attr And AData.AFile.Attributes.AutoUpdate) <> 0
                    FgF.SetCellImage(iRow, iColFgFDel, ImageList1.Images(0))
                    If ValidDate(o.DateImported) Then FgF(iRow, iColFgFImportovano) = o.DateImported
                    FgF(iRow, iColFgFId) = o.Id
                Next
            End With
        ElseIf oData IsNot Nothing Then
            oData = Nothing
            MessageBox.Show(Me, "Chyba při otvírání databáze." & vbCrLf & vbCrLf & AData.sError, txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        FgF.AutoSizeCols()
        FgF.Redraw = True
    End Sub

    Private Sub FOptions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        SaveFrm()
    End Sub

    Public Sub SaveFrm()
        WindowSave(Me)
        TextBoxSave(txtMdbFile)
        TextBoxSave(txtMdbPassword)
        TabControlSave(tbcMain)
        CheckBoxSave(chkUNC)
    End Sub

    Public Sub RestoreFrm()
        WindowRestore(Me)
        TextBoxRestore(txtMdbFile)
        TextBoxRestore(txtMdbPassword)
        TabControlRestore(tbcMain)
        If String.IsNullOrEmpty(txtCurrentFile.Text) Then txtCurrentFile.Text = AData.CurrentFile
        If String.IsNullOrEmpty(txtMdbPassword.Text) Then txtMdbPassword.Text = AData.txDefaultPassword
        CheckBoxRestore(chkUNC)
        'If String.IsNullOrEmpty(txtMSExcelDir.Text) Then txtMSExcelDir.Text = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath))
    End Sub

    Private Sub brnDefaultMdbPassword_Click(sender As Object, e As EventArgs) Handles brnDefaultMdbPassword.Click
        txtMdbPassword.Text = AData.txDefaultPassword
        SaveFrm()
    End Sub

    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs)
        oMainForm.SaveCurrentFileName()
        LoadFgData(txtCurrentFile.Text)
    End Sub

    Private Sub btnSearchMdb_Click(sender As Object, e As EventArgs) Handles btnSearchMdb.Click
        If String.IsNullOrEmpty(txtMdbFile.Text) Then txtMdbFile.Text = IO.Path.GetDirectoryName(Application.ExecutablePath)
        With opnMdbDlg
            If IO.Directory.Exists(IO.Path.GetDirectoryName(txtMdbFile.Text)) Then .InitialDirectory = IO.Path.GetDirectoryName(txtMdbFile.Text)
            If .ShowDialog = DialogResult.OK AndAlso IO.File.Exists(.FileName) Then
                If IO.File.Exists(.FileName) Then
                    txtMdbFile.Text = .FileName
                    If chkUNC.Checked Then txtMdbFile.Text = DriveInfo.GetUNCPath(txtMdbFile.Text)
                    WindowSet(Me)
                    TextBoxSave(txtMdbFile)
                Else
                End If
            End If
        End With
    End Sub

    Private Sub btnOpenA_Click(sender As Object, e As EventArgs) Handles btnOpenA.Click
        With opnDlgXml
            If String.IsNullOrEmpty(txtCurrentFile.Text) Then txtCurrentFile.Text = IO.Path.GetDirectoryName(Application.ExecutablePath)
            If Not IO.File.Exists(txtCurrentFile.Text) Then
                If IO.Directory.Exists(IO.Path.GetDirectoryName(txtCurrentFile.Text)) Then .InitialDirectory = IO.Path.GetDirectoryName(txtCurrentFile.Text)
            End If
            If .ShowDialog = DialogResult.OK AndAlso IO.File.Exists(.FileName) Then
                If IO.File.Exists(.FileName) Then
                    Dim sName As String = .FileName
                    If chkUNC.Checked Then sName = DriveInfo.GetUNCPath(sName)
                    AData.CurrentFile = sName
                    oMainForm.SaveCurrentFileName()
                    txtCurrentFile.Text = sName
                    LoadFgData(sName)
                    MessageBox.Show(Me, "Nyní byl nastaven jako aktuální soubor archivu " & sName & ".", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    oMainForm.RefreshStb()
                    btnClose.DialogResult = DialogResult.OK
                End If
            End If
        End With
    End Sub

    Private Sub btnCreateA_Click(sender As Object, e As EventArgs) Handles btnCreateA.Click
        With opnSaveNewArchiv
            .FileName = AData.CurrentFile
            If .ShowDialog = DialogResult.OK Then
                Dim sName As String = DriveInfo.GetUNCPath(.FileName)
                If Not IO.File.Exists(.FileName) Then
                    AData.oAdata.FileVersion = AData.ValidFileVersion
                    IO.File.WriteAllText(sName, "")
                    txtCurrentFile.Text = sName
                    LoadFgData(sName)
                    MessageBox.Show(Me, "Nyní byl vytvořen nový, prázdný soubor archivu " & .FileName & " a nastaven jako aktuální.", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    oMainForm.RefreshStb()
                    btnOK.Visible = True
                Else
                    Dim tx2 As String = ""
                    Select Case MessageBox.Show(Me, "Soubor " & .FileName & " již existuje." & vbCrLf & vbCrLf & "Chceš jeho obsah nyní vymazat?", txtAppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        Case DialogResult.Yes
                            IO.File.Delete(sName)
                            IO.File.WriteAllText(sName, "")
                            tx2 = " vyprázdněn a"
                        Case DialogResult.No
                        Case Else
                            Exit Sub
                    End Select
                    txtCurrentFile.Text = sName
                    LoadFgData(sName)
                    MessageBox.Show(Me, "Nyní byl soubor archivu " & .FileName & tx2 & " nastaven jako aktuální.", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    oMainForm.RefreshStb()
                    btnOK.Visible = True
                End If
            End If
        End With
    End Sub

    Dim bPrc As Boolean = False
    Private Sub chkAllowImport_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllowImport.CheckedChanged
        If bPrc Then Exit Sub
        If chkAllowImport.Checked AndAlso bShowAttentionImportMdb Then
            If MessageBox.Show(Me, "POZOR!" & vbCrLf & vbCrLf & "Nyní bude povolen výmaz, vytvoření a import dat do archivu z databáze. Archiv může být importem změněn nebo zničen!", txtAppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                bShowAttentionImportMdb = False
            Else
                bPrc = True
                chkAllowImport.Checked = False
                bShowAttentionImportMdb = True
                bPrc = False
            End If
        End If
        ShowDelImages()
        FgF.AllowEditing = chkAllowImport.Checked
        gbImport.Enabled = chkAllowImport.Checked
        btnCreateA.Enabled = chkAllowImport.Checked
        btnUpdateAll.Enabled = chkAllowImport.Checked
    End Sub

    Private Sub txtCurrentFile_Validated(sender As Object, e As EventArgs)
        If bLoaded Then btnClose.DialogResult = DialogResult.OK
        LoadFgData(txtCurrentFile.Text)
        AData.CurrentFile = txtCurrentFile.Text
        WindowSet(oMainForm)
        StringSave(MForm3.nmCurrentFile, AData.CurrentFile)
        txtCurrentFile.Text = AData.CurrentFile
        oMainForm.RefreshStb()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            Dim oPr As New Process
            oPr.StartInfo.FileName = txtCurrentFile.Text
            oPr.Start()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub txtCurrentFile_TextChanged(sender As Object, e As EventArgs) Handles txtCurrentFile.TextChanged, txtMdbFile.TextChanged, txtMdbPassword.TextChanged, txtMSExcelDir.TextChanged,
                                                                                     clrFgOP.ColorChange, clrFgOV.ColorChange, clrFgN.ColorChange, clrFgFP.ColorChange, clrFgFV.ColorChange,
                                                                                     chkSimpleExcel.CheckedChanged, gbColors.CheckedChanged, chkSimpleExcel.CheckedChanged,
                                                                                     chkUseExcel.CheckedChanged
        If Not bLoading Then btnOK.Visible = True
        If sender Is chkUseExcel Then SetSimpleExcel()
    End Sub

    Private Sub SetSimpleExcel()
        chkSimpleExcel.Enabled = chkUseExcel.Checked
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        SaveFrm()
    End Sub

    Private Sub btnDefaultFgColors_Click(sender As Object, e As EventArgs) Handles btnDefaultFgColors.Click
        clrFgOP.ColorSetting = dfFgOP
        clrFgN.ColorSetting = dfFgN
        clrFgFV.ColorSetting = dfFgFV
        clrFgFP.ColorSetting = dfFgFP
        clrFgOV.ColorSetting = dfFgOV
        btnOK.Visible = True
    End Sub

    Private Sub FgF_Click(sender As Object, e As EventArgs) Handles FgF.Click
        If FgF.Col = iColFgFDel AndAlso FgF.RowIsValid(FgF.Row) Then
            Dim iRemoved As Integer = 0
            If MessageBox.Show(Me.Owner, String.Format("Chceš nyní skutečně odstranit data, importovaná z databáze {0}?", CStr(FgF(FgF.Row, iColFgFCesta))), txtAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.ShowSplashLabel, "Odstaňuji data z archivu databáze Pohoda")
                    AData.oAdata.RemoveDataMdbFile(CStr(FgF(FgF.Row, iColFgFCesta)), iRemoved)
                    IO.File.WriteAllText(txtCurrentFile.Text, AData.oAdata.ToXml)
                    LoadFgData(txtCurrentFile.Text)
                End Using
                MessageBox.Show(Me, String.Format("Odstranění dat z archivu databáze ""{0}"" z archivu ""{1}"" bylo úspěšně dokončeno.{2}{2}Bylo celkem odstraněno {3} položek.", txtMdbFile.Text, txtCurrentFile.Text, vbCrLf, iRemoved), txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnClose.DialogResult = DialogResult.OK
            End If
        End If
    End Sub

    Private Sub btnOK_VisibleChanged(sender As Object, e As EventArgs) Handles btnOK.VisibleChanged
        Debug.WriteLine("visChanged")
    End Sub

    Private Sub FgF_AfterEdit(sender As Object, e As RowColEventArgs) Handles FgF.AfterEdit
        If e.Col = iColFgFUpd Then
            Dim iAttr As Integer = AData.oAdata.aoFiles(e.Row - FgF.Rows.Fixed).Attr
            iAttr = iAttr Xor (AData.AFile.Attributes.AutoUpdate)
            AData.oAdata.aoFiles(e.Row - FgF.Rows.Fixed).Attr = iAttr
            IO.File.WriteAllText(txtCurrentFile.Text, AData.oAdata.ToXml)
            btnClose.DialogResult = DialogResult.OK
            btnOK.Visible = True
            LoadFgData(txtCurrentFile.Text)
        End If
    End Sub
End Class
