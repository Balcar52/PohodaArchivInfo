Option Strict On

''' <summary>
''' Trida pro zapouzdreni izolovanych procesu v ramci formulare
''' </summary>
''' <remarks>
''' pomoci konstrukce Using zajisti nastaveni kurzoru, disablovani materskeho formulare (resp. control),
''' zobrazeni zpravy do labelu
''' soucasne zajisti automaticke vraceni do puvodniho stavu po opusteni Using bloku
''' </remarks>
Public Class cLockForm
    Implements IDisposable
    ' Flag: Has Dispose already been called?
    Dim bDisposed As Boolean = False
    Dim oStb As clsStatusBar = Nothing
    Dim oOldCursor As Cursor = Nothing
    Dim oOldPgs As PrgsTyp = Nothing
    Dim sOldStbText As String = ""
    Dim bAutoRestoreStatusBarText As Boolean

    Public oCtl As Control = Nothing

    ''' <summary>
    ''' konstruktor objektu pro prekryti a zamceni formulare
    ''' </summary>
    Public Sub New(oCtl As Control, Optional ProgressText As String = "",
                   Optional SplashMode As XFormBase.SurfaceSplashMode = XFormBase.SurfaceSplashMode.None,
                   Optional StatusbarProgresstyp As PrgsTyp = PrgsTyp.Inactive,
                   Optional ByVal StdIcon As StdIcons = StdIcons.NoIcon,
                   Optional ByVal AllowAbort As Boolean = False,
                   Optional ByVal AutoRestoreStatusBarText As Boolean = True)
        MyBase.New()
        Me.oCtl = oCtl
        Me.bAutoRestoreStatusBarText = AutoRestoreStatusBarText
        oOldCursor = oCtl.Cursor
        oCtl.Cursor = Cursors.WaitCursor
        If StatusbarProgresstyp <> PrgsTyp.Empty Then
            Dim oStbCtl As Control = oCtl
            Do
                Me.oStb = clsStatusBar.GetStatusBarObject(oStbCtl)
                If (Not oStb Is Nothing) OrElse oStbCtl.Parent Is Nothing Then Exit Do
                oStbCtl = oStbCtl.Parent()
            Loop
            If Not oStb Is Nothing Then
                oOldPgs = oStb.GetProgressTyp
                sOldStbText = oStb.GetText
                oStb.SetProgress(StatusbarProgresstyp, ProgressText)
            End If
        End If
        If ProgressText <> "" AndAlso StatusbarProgresstyp = PrgsTyp.Inactive AndAlso SplashMode = XFormBase.SurfaceSplashMode.None Then SplashMode = XFormBase.SurfaceSplashMode.ShowSplashLabel
        If ProgressText = "" AndAlso StatusbarProgresstyp = PrgsTyp.Inactive AndAlso SplashMode = XFormBase.SurfaceSplashMode.None Then SplashMode = XFormBase.SurfaceSplashMode.DisableFormOnly
        If SplashMode <> XFormBase.SurfaceSplashMode.NotDefined Then LockForm(oCtl, ProgressText, AllowAbort, SplashMode)
        Application.DoEvents()
    End Sub

    ''' <summary>
    ''' konstruktor objektu pro prekryti a zamceni formulare
    ''' </summary>
    Public Sub New(oCtl As Control, SplashMode As XFormBase.SurfaceSplashMode, Optional SplashText As String = "",
                   Optional StatusbarProgresstyp As PrgsTyp = PrgsTyp.Inactive,
                   Optional ByVal AllowAbort As Boolean = False,
                   Optional ByVal AutoRestoreStatusBarText As Boolean = True)
        MyBase.New()
        Me.oCtl = oCtl
        Me.bAutoRestoreStatusBarText = AutoRestoreStatusBarText
        oOldCursor = oCtl.Cursor
        oCtl.Cursor = Cursors.WaitCursor
        Select Case SplashMode
            Case XFormBase.SurfaceSplashMode.DisableFormOnly

                Dim oStbCtl As Control = oCtl
                Do
                    Me.oStb = clsStatusBar.GetStatusBarObject(oStbCtl)
                    If (Not oStb Is Nothing) OrElse oStbCtl.Parent Is Nothing Then Exit Do
                    oStbCtl = oStbCtl.Parent()
                Loop
                If oStb Is Nothing Then
                    Me.oStb = clsStatusBar.GetStatusBarObject(oCtl)
                    If (Not oStb Is Nothing) AndAlso Not oCtl.Parent Is Nothing Then oStb.SetProgress(StatusbarProgresstyp, SplashText)
                Else
                    oOldPgs = oStb.GetProgressTyp
                    sOldStbText = oStb.GetText
                    oStb.SetProgress(StatusbarProgresstyp, SplashText)
                End If
            Case XFormBase.SurfaceSplashMode.ShowSplashLabel, XFormBase.SurfaceSplashMode.StretchAboveAllForm, XFormBase.SurfaceSplashMode.StretchAboveControl
                If SplashText = "" Then Throw New Exception("cLockForm - chybí parametr SplashText.")
            Case Else
                Throw New Exception("cLockForm - nepovolený parametr SplashMode: " & SplashMode.ToString)
        End Select
        LockForm(oCtl, SplashText, AllowAbort, SplashMode)
        Application.DoEvents()
    End Sub

    ''' <summary> konstruktor pro label vytvoreny z Action </summary>
    ''' <param name="oCtl"></param>
    ''' <param name="a"> pridruzena action </param>
    ''' <param name="AllowAbort"></param>
    Public Sub New(oCtl As Control, a As ActionListLib.Action, Optional ByVal AllowAbort As Boolean = False)
        MyBase.New()
        Me.oCtl = oCtl
        Me.bAutoRestoreStatusBarText = AutoRestoreStatusBarText
        oOldCursor = oCtl.Cursor
        oCtl.Cursor = Cursors.WaitCursor
        LockForm(oCtl, a.Text, AllowAbort, XFormBase.SurfaceSplashMode.ShowSplashLabel)
        Application.DoEvents()
    End Sub

    Public Property AutoRestoreStatusBarText() As Boolean
        Get
            Return bAutoRestoreStatusBarText
        End Get
        Set(ByVal value As Boolean)
            bAutoRestoreStatusBarText = value
        End Set
    End Property

    Public ReadOnly Property Stb As clsStatusBar
        Get
            Return oStb
        End Get
    End Property

    'Public Function AbortAllowed() As Boolean
    '    Return LockForm()
    'End Function

    Public Sub SetProgressText(ProgressText As String, Optional SetSplashLabel As Boolean = True, Optional SetStatusBarText As Boolean = True)
        If SetSplashLabel Then
            If UpdateLockForm(oCtl, ProgressText) Then
                If SetStatusBarText AndAlso Not oStb Is Nothing Then oStb.SetText(ProgressText)
            End If
        End If
    End Sub

    ''' <summary> vidtelnost prvku pro preruseni </summary>
    ''' <param name="bVisible"></param>
    Public Function SetAbortVisibility(bVisible As Boolean) As Boolean
        Dim bRet As Boolean = False
        If AbortControl IsNot Nothing Then
            AbortControl.Visible = bVisible
            Application.DoEvents()
            bRet = AbortControl.Visible
        End If
        Return bRet
    End Function

    ' Public implementation of Dispose pattern callable by consumers.
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overridable Sub Dispose(disposing As Boolean)
        If bDisposed Then Return

        If disposing Then
            ' Free any other managed objects here.
            '
            oCtl.Cursor = oOldCursor
            UnLockForm(oCtl)
            If Not oStb Is Nothing Then
                If Me.bAutoRestoreStatusBarText Then
                    oStb.SetProgress(oOldPgs)
                    oStb.SetText(sOldStbText)
                Else
                    oStb.SetProgress(oOldPgs, oStb.moSbd.Text) ' zachovame zmeneny text
                End If
            End If
        End If
        ' Free any unmanaged objects here.
        '
        bDisposed = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    Public Shared Function AbortAllowed() As Boolean
        Return modLockForm.AbortAllowed
    End Function

    Public Shared Function AbortClicked() As Boolean
        Return modLockForm.AbortAllowed AndAlso modLockForm.AbortClicked
    End Function
End Class

Public Module modLockForm

    Private bAborted As Boolean

    ''' <summary> globalni kolekce controls, nad kterymi je zamek </summary>
    ''' <remarks></remarks>
    Public gaoSplashes As New Stack(Of XFormBase.FormSplashData)

    ''' <summary> Control pro preruseni kliknutim na nej </summary>
    Public AbortControl As Label = Nothing

    ''' <summary> je definovan control pro preruseni </summary>
    Friend Function AbortAllowed() As Boolean
        Return Not AbortControl Is Nothing
    End Function

    ''' <summary> zamkne formular </summary>
    Public Function LockForm(Optional oCtl As Control = Nothing, Optional sText As String = "",
                        Optional AllowAbort As Boolean = False, Optional SplashMode As XControls.XFormBase.SurfaceSplashMode = XFormBase.SurfaceSplashMode.ShowSplashLabel) As Boolean
        If oCtl Is Nothing Then oCtl = iMForm
        Return LockUnlockForm(True, oCtl, sText, AllowAbort, SplashMode)
    End Function

    ''' <summary> tise zamkne formular </summary>
    Public Function LockFormQuiet(oCtl As Control) As Boolean
        If oCtl Is Nothing Then oCtl = iMForm
        Return LockUnlockForm(True, oCtl, , , XFormBase.SurfaceSplashMode.DisableFormOnly)
    End Function

    ''' <summary> odemkne formular </summary>
    Public Function UnLockForm(Optional oCtl As Control = Nothing) As Boolean
        If oCtl Is Nothing Then oCtl = iMForm
        Return LockUnlockForm(False, oCtl)
    End Function

    ''' <summary> aktualizuje text ve splash label </summary>
    Public Function UpdateLockForm(Optional oCtl As Control = Nothing, Optional sText As String = "", Optional oImage As Image = Nothing,
                                   Optional oStb As clsStatusBar = Nothing, Optional iValueForTextSubstitute As Integer = Integer.MinValue,
                                   Optional bKeepImage As Boolean = True, Optional bRemoveEmptyFormatParams As Boolean = True) As Boolean
        Dim oTopCtl As Control = oCtl
        Do
            If oTopCtl Is Nothing OrElse oTopCtl.Parent Is Nothing Then
                Exit Do
            ElseIf TypeOf oTopCtl Is Form Then
                Exit Do
            End If
            oTopCtl = oTopCtl.Parent
        Loop

        Dim oItemList As New List(Of XFormBase.FormSplashData)(gaoSplashes)
        For i As Integer = oItemList.Count - 1 To 0 Step -1
            If oItemList(i).mForm Is oTopCtl Then
                With oItemList(i)
                    Dim bChng As Boolean = False
                    If iValueForTextSubstitute <> Integer.MinValue Then sText = String.Format(sText, iValueForTextSubstitute)
                    If Not String.IsNullOrEmpty(sText) Then
                        If .mSplashLabel.Text <> sText Then
                            .mSplashLabel.Text = sText
                            If bRemoveEmptyFormatParams Then .mSplashLabel.Text = Trim(Replace(Replace(sText, "{0}", ""), "{1}", ""))
                            bChng = True
                        End If
                    End If
                    If oImage Is Nothing Then
                        If (Not .mSplashLabel.Image Is Nothing) AndAlso (Not bKeepImage) Then .mSplashLabel.Image = Nothing : bChng = True
                    Else
                        If Not (.mSplashLabel.Image Is oImage) Then .mSplashLabel.Image = oImage : bChng = True
                    End If
                    If bChng Then
                        If oStb IsNot Nothing Then oStb.SetText(sText)
                        .mSplashLabel.Refresh()
                        Application.DoEvents()
                    End If
                    Return bChng
                End With
            End If
        Next
        Return False
    End Function

    ''' <summary> Zamceni/odemceni formulare pomoci mechanismu XControls.XFormBase.SurfaceSplashMode </summary>
    Private Function LockUnlockForm(bLock As Boolean, Optional oCtl As Control = Nothing, Optional sText As String = "",
                           Optional AllowAbort As Boolean = False,
                           Optional SplashMode As XControls.XFormBase.SurfaceSplashMode = XFormBase.SurfaceSplashMode.ShowSplashLabel) As Boolean
        Dim oTopCtl As Control = oCtl

        Do
            If oTopCtl Is Nothing OrElse oTopCtl.Parent Is Nothing Then
                Exit Do
            ElseIf TypeOf oTopCtl Is Form Then
                Exit Do
            End If
            oTopCtl = oTopCtl.Parent
        Loop
        If Not AbortControl Is Nothing Then RemoveHandler AbortControl.Click, AddressOf AbortEvent
        If bLock Then
            bAborted = False
            If IsLocked(oTopCtl) Then Return False
            Dim oFsd As New XFormBase.FormSplashData(oTopCtl) ', , , , , SystemColors.ControlLightLight, SystemColors.ControlText)
            oFsd.moLabelBackColor = SystemColors.ControlLightLight
            oFsd.moLabelForeColor = SystemColors.WindowText
            oFsd.mSplashLabel.Image = XFormBase.HourglasLoaderImage
            If AllowAbort Then
                AbortControl = DirectCast(oFsd.GetAbortControl("Pro přerušení klikni zde"), Label)
                AddHandler AbortControl.Click, AddressOf AbortEvent
            End If
            XFormBase.SetSurfacePanel(oFsd, SplashMode, If(sText = "", "Probíhá zpracování dat formuláře..", sText), 2S, , )
            gaoSplashes.Push(oFsd)
        Else
            AbortControl = Nothing
            If Not IsLocked(oTopCtl) Then Return False
            Dim oFsd As XFormBase.FormSplashData = Nothing
            If (Not gaoSplashes Is Nothing) AndAlso gaoSplashes.Count > 0 Then
                If gaoSplashes.Peek.mForm Is oTopCtl Then oFsd = gaoSplashes.Pop
                If oFsd Is Nothing Then
                    Debug.WriteLine("FormSplashData nebyl nalezen")
                    Return False
                End If
            End If
            Try
                XFormBase.ClearSplashPanel(oFsd)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
        Application.DoEvents()
        Return True
    End Function

    ''' <summary> control je zamcen </summary>
    Private Function IsLocked(oCtl As Control) As Boolean
        For Each oFsd As XFormBase.FormSplashData In gaoSplashes
            If oFsd.mForm Is oCtl Then Return True
        Next
        Return False
    End Function

    Private Function GetSplashData(oCtl As Control) As XFormBase.FormSplashData
        For Each oFsd As XFormBase.FormSplashData In gaoSplashes
            If oFsd.mForm Is oCtl Then Return oFsd
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Vyvola udalost preruseni cinnosti
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub AbortEvent(Optional sender As Object = Nothing, Optional e As System.EventArgs = Nothing)
        bAborted = True
        Application.DoEvents()
    End Sub

    ''' <summary>
    ''' dotaz, kterym je potreba prospikovat deletrvajici smycky
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AbortClicked() As Boolean
        'Dim oTop As Control = TopCtl(gaoSplashes.Last.mAbortControl)
        'If TypeOf oTop Is Form AndAlso DirectCast(oTop, Form).ActiveControl IsNot gaoSplashes.Last.mAbortControl Then
        '    Try
        '        DirectCast(oTop, Form).ActiveControl = gaoSplashes.Last.mAbortControl
        '        gaoSplashes.Last.mAbortControl.Focus()
        '    Catch ex As Exception
        '        Debug.WriteLine("chyba" & vbCrLf & ex.Message)
        '    End Try
        'End If
        Application.DoEvents()
        Return bAborted
    End Function

    Public Function ConstructPercentage(iPart As Long, iAmount As Long) As String
        If iAmount <= 0 Then Return "?"
        Dim iPerc = iPart * 100 \ iAmount
        Return " " & iPerc & "%"
    End Function

    Public Function ConstructPercentage(oPart As Object, oAmount As Object) As String
        If IsNumeric(oPart) AndAlso IsNumeric(oAmount) AndAlso CLng(oAmount) > 0 Then
            If CLng(oAmount) <= 0 Then Return "?"
            Dim iPerc = CLng(oPart) * 100 \ CLng(oAmount)
            Return " " & iPerc & "%"
        End If
        Return ""
    End Function

End Module

