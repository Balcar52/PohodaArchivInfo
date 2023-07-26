' text upraven 22.06.2023 3:58:31 jiri/JIRIBARTUSEK
' CorrectForm 22.12.2021; 1.2.0.37; ©2016-19 Ing. Jiri Bartusek
' 
' Deklarace cisel sloupcu pro Flexgrid - pocet uprav: 1. 22.06.2023 3:58:26
Imports System.Data.OleDb

Public Class FOptions

    Dim oMainForm As MForm
    Dim bLoaded As Boolean = False

    ' deklarace promennych cisel sloupcu gridu 
    Dim iColFgF0 As Integer ' [g:0]
    Dim iColFgFKlicoveJmeno As Integer ' [g:1]
    Dim iColFgFCesta As Integer ' [g:2]
    Dim iColFgFDatum As Integer ' [g:3]
    Dim iColFgFImportovano As Integer ' [g:3]
    Dim iColFgFId As Integer ' [g:4]

    Public Shared Function Run(oOwner As MForm) As DialogResult
        Dim oFrm As New FOptions
        With oFrm
            .Owner = oOwner
            .oMainForm = oOwner
            Return .ShowDialog()
        End With
    End Function

    Private Sub btnProcessImport_Click(sender As Object, e As EventArgs) Handles btnProcessImport.Click
        Try
            Using clck As New cLockForm(CType(Me, Control), XFormBase.SurfaceSplashMode.DisableFormOnly, "Načítám data z databáze Pohoda")
                AData.oAdata = AData.LoadMdbData(txtMdbFile.Text, txtMdbPassword.Text, txtCurrentFile.Text)
                If AData.oAdata IsNot Nothing Then
                    IO.File.WriteAllText(txtCurrentFile.Text, AData.oAdata.ToXml)
                    LoadFgData(txtCurrentFile.Text)
                End If
                If bLoaded Then btnClose.DialogResult = DialogResult.OK
                LoadFgData(txtCurrentFile.Text)
            End Using
        Catch ex As Exception
            MForm.ShowError(Me, ex)
        End Try
    End Sub

    Private Sub FOptions_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        WindowRestore(Me)
        XSplitterRestore(XSplitter1)
        TextBoxRestore(txtMdbFile)
        TextBoxRestore(txtMdbPassword)
        txtCurrentFile.Text = AData.CurrentFile
        If String.IsNullOrEmpty(txtMdbPassword.Text) Then txtMdbPassword.Text = AData.txDefaultPassword
        Init()
        LoadFgData(txtCurrentFile.Text)
        bLoaded = True
    End Sub

    Private Sub Init()
        FlexgridSet(FgF) '' [CorrectForm 17.4.2019 22:43]' [CorrectForm 21.6.2023 23:48]' [CorrectForm 22.6.2023 3:58]
        iColFgF0 = FlexgridSetCol(">")
        iColFgFKlicoveJmeno = FlexgridSetCol("klíčové jméno,100,RS<", "databáze")
        iColFgFCesta = FlexgridSetCol("cesta,100,RS<", "*")
        iColFgFDatum = FlexgridSetCol("datum,80,Rd>", "*")
        iColFgFImportovano = FlexgridSetCol("importováno,100,RDT>", "*")
        iColFgFId = FlexgridSetCol("ID,80,RI>", "*")
        FlexgridSetExec() ' [CorrectForm 22.6.2023 3:58]

        FlexgridSetGlobalFormat()

        FgF.Styles.Highlight.BackColor = FgF.Styles.Normal.BackColor
        FgF.Styles.Highlight.ForeColor = FgF.Styles.Normal.ForeColor
        FgF.SelectionMode = SelectionModeEnum.Cell

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
                    If ValidDate(o.DateImported) Then FgF(iRow, iColFgFImportovano) = o.DateImported
                    FgF(iRow, iColFgFId) = o.Id
                Next
            End With
        End If
        FgF.AutoSizeCols()
        FgF.Redraw = True
    End Sub

    Private Sub FOptions_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        SaveFrm()
    End Sub

    Public Sub SaveFrm()
        WindowSet(oMainForm)
        StringSave(MForm.nmCurrentFile, AData.CurrentFile)
        WindowSave(Me)
        XSplitterSave(XSplitter1)
        TextBoxSave(txtMdbFile)
        TextBoxSave(txtMdbPassword)
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
                    Dim sName As String = DriveInfo.GetUNCPath(.FileName)
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
                    IO.File.WriteAllText(sName, "")
                    txtCurrentFile.Text = sName
                    LoadFgData(sName)
                    MessageBox.Show(Me, "Nyní byl vytvořen nový, prázdný soubor archivu " & .FileName & " a nastaven jako aktuální.", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    oMainForm.RefreshStb()
                    btnClose.DialogResult = DialogResult.OK
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
                    btnClose.DialogResult = DialogResult.OK
                End If
            End If
        End With
    End Sub

    Private Sub chkAllowImport_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllowImport.CheckedChanged
        If chkAllowImport.Checked AndAlso bShowAttentionImportMdb Then
            MessageBox.Show(Me, "Pozor!" & vbCrLf & vbCrLf & "Nyní bude povolen výmaz, vytvoření a import dat do archivu z databáze. Archiv může být importem změněn nebo zničen!", txtAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bShowAttentionImportMdb = False
        End If
        gbImport.Enabled = chkAllowImport.Checked
        btnCreateA.Enabled = chkAllowImport.Checked
    End Sub

    Private Sub txtCurrentFile_Validated(sender As Object, e As EventArgs)
        If bLoaded Then btnClose.DialogResult = DialogResult.OK
        LoadFgData(txtCurrentFile.Text)
        AData.CurrentFile = txtCurrentFile.Text
        WindowSet(oMainForm)
        StringSave(MForm.nmCurrentFile, AData.CurrentFile)
        txtCurrentFile.Text = AData.CurrentFile
        oMainForm.RefreshStb()
    End Sub

End Class
