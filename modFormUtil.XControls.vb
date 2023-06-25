Option Strict On

'Imports System
'Imports System.Drawing
'Imports System.Windows.Forms
'Imports Microsoft.Win32
Imports System.Reflection

' doplneno save TextBox
'
' Modul rutin pro praci s formulari
'
' obsahuje rutiny pro ulozeni a obnoveni stavu okna
' podporuje zapis parametru do registru aplikace
Public Module modFormUtil_XControls

    Public Sub CheckedGroupBoxSave(ByVal ChBox As CheckedGroupBox)
        If ChBox Is Nothing OrElse ChBox.Parent Is Nothing Then Exit Sub
        If Not GetCtlFormName(CType(ChBox, Control), gsFormName) Then Exit Sub
        NullPstr()
        AddPstr(ChBox.Checked)
        WriteToReg(psPstr, , ChBox.Name)
    End Sub

    Public Sub CheckedGroupBoxRestore(ByVal ChBox As CheckedGroupBox)
        If ChBox Is Nothing OrElse ChBox.Parent Is Nothing Then Exit Sub
        If Not GetCtlFormName(CType(ChBox, Control), gsFormName) Then Exit Sub
        ReadFromReg(, ChBox.Name)
        ChBox.Checked = CBool(GetPVal(0, CInt(ChBox.Checked)))
    End Sub

    ''' <summary>
    ''' ulozi stav XSplitteru
    ''' </summary>
    Public Sub XSplitterSave(oXSplitter As XSplitter)
        If oXSplitter Is Nothing OrElse oXSplitter.GetCurrentAttachedControl Is Nothing Then Exit Sub
        If Not GetCtlFormName(CType(oXSplitter, Control), gsFormName) Then Exit Sub
        NullPstr()
        AddPstr(oXSplitter.Expanded)
        AddPstr(oXSplitter.GetCurrentAttachedControl.Width)
        AddPstr(oXSplitter.GetCurrentAttachedControl.Height)
        WriteToReg(psPstr, , oXSplitter.Name)
    End Sub

    ''' <summary>
    ''' Obnovi stav XSplitteru.
    ''' Pokud je zadana komponenta (t.c. Action/Checkbox) - provede se propojeni Xsplitteru a prvku - neni potreba zadny dalsi kod pro obsluhu stavu
    ''' </summary>
    Public Sub XSplitterRestore(oXSplitter As XSplitter, Optional oConnectedComponent As Object = Nothing)
        Dim oAttCtl As Control = oXSplitter.GetCurrentAttachedControl
        If oXSplitter Is Nothing Then Exit Sub
        If GetCtlFormName(CType(oXSplitter, Control), gsFormName) Then
            ReadFromReg(, oXSplitter.Name)
            oXSplitter.SetExpandedState(CBool(GetPVal(0, CInt(oXSplitter.Expanded))))
            ' nastavim velikost pripojeneho Control
            If oXSplitter.IsSplitter AndAlso oAttCtl IsNot Nothing Then
                'velikost prvku nastavim jen v rezimu splitteru
                oAttCtl.Width = CInt(GetPVal(1, CInt(oAttCtl.Width)))
                oAttCtl.Height = CInt(GetPVal(2, CInt(oAttCtl.Height)))
            End If
        End If
        XSplitterProcessConnectedComponent(oXSplitter, oConnectedComponent)
    End Sub

    Public Sub XSplitterProcessConnectedComponent(oXSplitter As XSplitter, Optional oConnectedComponent As Object = Nothing)
        ' pripojim Action/CheckBox/ToolstripItem
        If TypeOf oConnectedComponent Is ActionListLib.Action Then
            Dim oAction As ActionListLib.Action = CType(oConnectedComponent, ActionListLib.Action)
            RemoveHandler oXSplitter.ExpandedChanged, AddressOf XSplitterHandleConnectedComponent
            RemoveHandler oAction.CheckedChanged, AddressOf ConnectedControlHandleXSplitter
            oXSplitter.Tag = oAction
            oAction.Tag = oXSplitter
            oAction.AutoCheck = True
            AddHandler oXSplitter.ExpandedChanged, AddressOf XSplitterHandleConnectedComponent
            AddHandler oAction.CheckedChanged, AddressOf ConnectedControlHandleXSplitter
            XSplitterHandleConnectedComponent(oXSplitter, Nothing)
        ElseIf TypeOf oConnectedComponent Is CheckBox Then
            Dim oChkBox As CheckBox = CType(oConnectedComponent, CheckBox)
            RemoveHandler oXSplitter.ExpandedChanged, AddressOf XSplitterHandleConnectedComponent
            RemoveHandler oChkBox.CheckedChanged, AddressOf ConnectedControlHandleXSplitter
            oXSplitter.Tag = oChkBox
            oChkBox.Tag = oXSplitter
            oChkBox.AutoCheck = True
            AddHandler oXSplitter.ExpandedChanged, AddressOf XSplitterHandleConnectedComponent
            AddHandler oChkBox.CheckedChanged, AddressOf ConnectedControlHandleXSplitter
            XSplitterHandleConnectedComponent(oXSplitter, Nothing)
        ElseIf False Then
            '    zde se muzou dodelat dalsi typy controls pro pripojeni...
            '...
        Else
            If Not oConnectedComponent Is Nothing Then MsgBox(String.Format("XSplitterRestore - nepovoleny typ prvku pro pripojeni k XSplitteru ({0})", oConnectedComponent.GetType.ToString), MsgBoxStyle.Critical)
        End If
    End Sub

    'toto propoji XSplitter a Action, resp. CheckBox pro zobrazeni pripojeneho panelu
    Private Sub XSplitterHandleConnectedComponent(sender As Object, e As System.EventArgs)
        If TypeOf sender Is XSplitter Then
            Dim oXSplitter As XControls.XSplitter = CType(sender, XSplitter)
            With oXSplitter
                If TypeOf .Tag Is ActionListLib.Action Then
                    CType(.Tag, ActionListLib.Action).SetCheckedState(oXSplitter.Expanded) ' toto nevyvola CheckedChanged na action
                ElseIf TypeOf .Tag Is CheckBox Then
                    ' zabranim provedeni CheckedChanged
                    RemoveHandler CType(.Tag, CheckBox).CheckedChanged, AddressOf ConnectedControlHandleXSplitter
                    CType(.Tag, CheckBox).Checked = oXSplitter.Expanded
                    ' obnovim handler
                    AddHandler CType(.Tag, CheckBox).CheckedChanged, AddressOf ConnectedControlHandleXSplitter
                End If
            End With
        End If
    End Sub

    'toto propoji Action resp.checkbox pro zobrazeni pripojeneho panelu a XSplitter
    Private Sub ConnectedControlHandleXSplitter(sender As Object, e As System.EventArgs)
        If TypeOf sender Is ActionListLib.Action Then
            With CType(sender, ActionListLib.Action)
                If TypeOf .Tag Is XSplitter Then
                    CType(.Tag, XControls.XSplitter).SetExpandedState(.Checked)
                End If
            End With
        ElseIf TypeOf sender Is CheckBox Then
            With CType(sender, CheckBox)
                If TypeOf .Tag Is XSplitter Then
                    CType(.Tag, XControls.XSplitter).SetExpandedState(.Checked)
                End If
            End With
        End If
    End Sub

    ''' <summary>
    ''' ulozi hodnotu DatumBoxu.
    ''' </summary>
    Public Sub DatumBoxSave(oDbox As XControls.DatumBox)
        If Not GetCtlFormName(CType(oDbox, Control), gsFormName) Then Exit Sub
        NullPstr()
        AddPstr(oDbox.Value.ToString)
        WriteToReg(psPstr, , oDbox.Name)
    End Sub

    Public Sub DateRangeSave(ByVal Name As String, oValue As DateRange, Optional ByVal FormName As String = "", Optional bClearRegIfEmpty As Boolean = False)
        If FormName <> "" Then gsFormName = FormName
        If bClearRegIfEmpty AndAlso (oValue Is Nothing OrElse Not oValue.IsValidInterval) Then
            DeleteKeyFromReg(Name)
        Else
            NullPstr()
            AddPstr(oValue.Start.ToString & ";" & oValue.End.ToString)
            WriteToReg(psPstr, , Name)
        End If
    End Sub

    Public Function DateRangeRestore(ByVal Name As String, Optional ByVal FormName As String = "", Optional oDefaultValue As DateRange = Nothing) As DateRange
        Dim oRes As New DateRange(True)
        If FormName <> "" Then gsFormName = FormName
        Try
            Dim sx() As String = Split(ReadFromReg(, Name) & ";", ";")
            If IsDate(sx(0)) Then oRes.Start = CDate(sx(0)) Else oRes.Start = If(oDefaultValue Is Nothing, New Date(1900, 1, 1), oDefaultValue.Start)
            If sx.Length > 1 AndAlso IsDate(sx(1)) Then oRes.End = CDate(sx(1)) Else oRes.End = If(oDefaultValue Is Nothing, New Date(3333, 3, 3), oDefaultValue.End)
        Catch : End Try
        Return oRes
    End Function



    Public Sub MonthBoxSave(ByVal oMbox As XControls.MonthBox)
        If Not GetCtlFormName(CType(oMbox, Control), gsFormName) Then Exit Sub
        NullPstr()
        AddPstr(oMbox.Value.ToString)
        WriteToReg(psPstr, , oMbox.Name)
    End Sub

    ''' <summary> cas posledniho ulozeni stavu formulare </summary>
    Public Function LastSaveDate() As Date
        Dim s As String = ReadFromReg(, nmLss)
        If IsDate(s) Then Return CDate(s).Date
        Return New Date
    End Function

    ''' <summary>
    ''' obnovi hodnotu DatumBoxu.
    ''' Je-li RestoreOnlyForLastDays vetsi nez 0, tak hodnotu obnovy pouze tehdy, kdyz .LastStateSaved datum, neni starsi nez RestoreOnlyForLastDays dni.
    ''' Jinak se nastavi datum na hodnotu DefaultDate (neni-li nastaveno, tak se DefaultDate rozumi "Dnes")
    ''' </summary>
    Public Function DatumBoxRestore(oDbox As XControls.DatumBox, Optional RestoreOnlyForLastDays As Integer = -1, Optional DefaultDate As Date = Nothing) As Boolean
        If Not GetCtlFormName(CType(oDbox, Control), gsFormName) Then Return False
        Dim s As String = ReadFromReg(, oDbox.Name)
        If IsDate(s) Then
            Dim dt As Date = CDate(s).Date
            If RestoreOnlyForLastDays <= 0 OrElse (RestoreOnlyForLastDays > 0 AndAlso LastSaveDate.Date.AddDays(RestoreOnlyForLastDays - 1) >= Now.Date) Then
                oDbox.Value = dt
                Return True
            End If
        End If
        If DefaultDate.Year > 2999 Then ' např 3.3.3333 se povazuje za platne
            oDbox.Value = MaxDate
        ElseIf DefaultDate.Year >= 1980 Then
            oDbox.Value = DefaultDate
        Else
            oDbox.Value = Now.Date
        End If
        Return False
    End Function

    ''' <summary>
    ''' obnovi hodnotu MonthBoxu.
    ''' Je-li RestoreOnlyForLastDays vetsi nez 0, tak hodnotu obnovy pouze tehdy, kdyz .LastStateSaved datum, neni starsi nez RestoreOnlyForLastDays dni.
    ''' Jinak se nastavi datum na hodnotu DefaultDate (neni-li nastaveno, tak se DefaultDate rozumi "Dnes")
    ''' </summary>
    Public Function MonthBoxRestore(ByVal oMbox As XControls.MonthBox, Optional ByVal RestoreOnlyForLastDays As Integer = -1, _
                                    Optional ByVal DefaultDate As Date = #12:00:00 PM#) As Boolean
        If Not GetCtlFormName(CType(oMbox, Control), gsFormName) Then Return False
        Dim s As String = ReadFromReg(, oMbox.Name)
        Dim s2 As String = ReadFromReg(, nmLss)
        If IsDate(s) Then
            Dim dt As Date = CDate(s).Date
            If RestoreOnlyForLastDays > 0 AndAlso IsDate(s2) Then
                Dim dt2 As Date = CDate(s2).Date
                If ValidDate(dt2) AndAlso dt2.Date.AddDays(RestoreOnlyForLastDays - 1).Date >= Now.Date Then
                    oMbox.Value = dt
                    Return True
                End If
            End If
        End If
        If DefaultDate.Year > 2999 Then ' např 3.3.3333 se povazuje za platne
            oMbox.Value = MaxDate
        ElseIf DefaultDate.Year >= 1980 Then
            oMbox.Value = DefaultDate
        Else
            oMbox.Value = Now.Date
        End If
        Return False
    End Function

    ''' <summary>
    ''' ulozi hodnotu DecimalBoxu.
    ''' </summary>
    Public Sub DecimalBoxSave(oDbox As DecimalBox)
        If Not GetCtlFormName(CType(oDbox, Control), gsFormName) Then Exit Sub
        NullPstr()
        AddPstr(oDbox.Value.ToString)
        WriteToReg(psPstr, , oDbox.Name)
    End Sub

    ''' <summary>
    ''' obnovi hodnotu DecimalBoxu.
    ''' Jinak se nastavi hodnota DefaultValue
    ''' </summary>
    Public Function DecimalBoxRestore(oDbox As DecimalBox, Optional DefaultValue As Decimal = 0D) As Boolean
        If Not GetCtlFormName(CType(oDbox, Control), gsFormName) Then Return False
        Dim s As String = ReadFromReg(, oDbox.Name)
        Try
            If IsNumeric(s) Then
                oDbox.Text = oDbox.Value.ToString
                oDbox.Value = CDec(s)
                Return True
            Else
                oDbox.Value = DefaultValue
            End If
        Catch : End Try
        Return False
    End Function

    Public Sub ColorSettingBoxSave(oCsb As ColorSettingBox)
        If Not GetCtlFormName(CType(oCsb, Control), gsFormName) Then Exit Sub
        NullPstr()
        AddPstr(String.Format("0x{0},0x{1}", Hex(oCsb.ForeColorSetting.ToArgb), Hex(oCsb.BackColorSetting.ToArgb)))
        WriteToReg(psPstr, , oCsb.Name)
    End Sub

    Public Function ColorSettingBoxRestore(oCsb As ColorSettingBox, Optional Forecolor As Color = Nothing, Optional Backcolor As Color = Nothing) As Boolean
        If Not GetCtlFormName(CType(oCsb, Control), gsFormName) Then Return False
        Dim s As String = ReadFromReg(, oCsb.Name)
        Try
            Dim sx() As String = Split(UCase(s) & ",,", ",")
            If sx(0).Length > 2 AndAlso sx(0).StartsWith("0X") Then
                oCsb.ForeColorSetting = Color.FromArgb(Convert.ToInt32(sx(0).Substring(2), 16))
            ElseIf Forecolor <> Nothing Then
                oCsb.ForeColorSetting = Forecolor
            End If
            If sx(1).Length > 2 AndAlso sx(1).StartsWith("0X") Then
                oCsb.BackColorSetting = Color.FromArgb(Convert.ToInt32(sx(1).Substring(2), 16))
            ElseIf Backcolor <> Nothing Then
                oCsb.BackColorSetting = Backcolor
            End If
        Catch : End Try
        Return False
    End Function

End Module

