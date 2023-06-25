Option Strict On

Imports System.Net

Public Class DriveInfo

    Private Declare Ansi Function GetDriveType Lib "kernel32" Alias "GetDriveTypeA" (ByVal nDrive As String) As Long

    Public Enum DRIVETYPE As Long
        DRIVE_UNKNOWN = 0
        DRIVE_NO_ROOT_DIR = 1
        DRIVE_REMOVABLE = 2
        DRIVE_FIXED = 3
        DRIVE_REMOTE = 4
        DRIVE_CDROM = 5
        DRIVE_RAMDISK = 6
    End Enum

    Public Shared Function GetInfo(Optional ByVal sPath As String = "") As DRIVETYPE
        Try
            If Len(sPath) = 1 AndAlso UCase(Mid(sPath, 1, 1)) >= "A" AndAlso UCase(Mid(sPath, 1, 1)) <= "Z" Then
                sPath = UCase(Mid(sPath, 1, 1)) & ":\"
            ElseIf sPath = "" Then
                sPath = Nothing
            Else
                sPath = IO.Path.GetFullPath(sPath)
                sPath = IO.Path.GetPathRoot(sPath)
                If Not sPath.EndsWith("\") Then sPath &= "\"
            End If
            Dim lngStat As Long = GetDriveType(sPath)
            Return CType(lngStat And &H7, DRIVETYPE)
        Catch : End Try
        Return DRIVETYPE.DRIVE_UNKNOWN
    End Function

    Public Shared Function CheckAccessibility(sPath As String, Optional ByRef sErrText As String = "") As Boolean
        Const txNet As String = "Síová "
        Const txPathNotAvailable As String = "Cesta ""{0}"" nyní není dostupná."
        sErrText = ""
        If sPath.StartsWith("\\") Then
            Dim sx() As String = Split(sPath.Substring(2), "\")
            Dim sAddr As IPAddress = Nothing
            If IPAddress.TryParse(sx(0), sAddr) Then
                Using oPing As New System.Net.NetworkInformation.Ping
                    With oPing
                        Dim bError As Boolean = False
                        Dim oReply As System.Net.NetworkInformation.PingReply = Nothing
                        Try
                            oReply = .Send(sAddr, 1000)
                        Catch ex As Exception
                            bError = True
                        End Try
                        If bError OrElse oReply.Status <> Net.NetworkInformation.IPStatus.Success Then
                            sErrText = String.Format(txNet & txPathNotAvailable.ToLower, sAddr.ToString)
                            Return False
                        Else
                            Return True
                        End If
                    End With
                End Using
            Else
                If IO.File.Exists(sPath) OrElse IO.Directory.Exists(sPath) Then Return True
                Return False ' nenalezeno
            End If
        End If
        If IO.Directory.Exists(sPath) Then Return True
        If IO.File.Exists(sPath) Then Return True
        sErrText = String.Format(txPathNotAvailable.ToLower, sPath)
        Return False
        'End If
    End Function

    Public Shared Function IsNetworkPath(ByVal sPath As String) As Boolean
        Return GetInfo(sPath) = DRIVETYPE.DRIVE_REMOTE
    End Function

    Public Shared Function IsCDROMPath(ByVal sPath As String) As Boolean
        Return GetInfo(sPath) = DRIVETYPE.DRIVE_CDROM
    End Function

    Public Shared Function IsHardDiskPath(ByVal sPath As String) As Boolean
        Return GetInfo(sPath) = DRIVETYPE.DRIVE_FIXED
    End Function

    Public Shared Function IsRemovableDiskPath(ByVal sPath As String) As Boolean
        Return GetInfo(sPath) = DRIVETYPE.DRIVE_REMOVABLE
    End Function

    Public Shared Function IsRamDiskPath(ByVal sPath As String) As Boolean
        Return GetInfo(sPath) = DRIVETYPE.DRIVE_RAMDISK
    End Function

    Public Shared Function GetUNCPath(sPath As String, Optional ToLowerCase As Boolean = True) As String
        sPath = Trim(sPath)
        If (Not String.IsNullOrWhiteSpace(sPath)) AndAlso DriveInfo.IsNetworkPath(sPath) AndAlso sPath.IndexOf(":") > 0 Then
            Dim sx() As String = Split(sPath, ":")
            Dim sUNC As String = GetUNCPath(sx(0).Chars(sx(0).Length - 1))
            If Not String.IsNullOrWhiteSpace(sUNC) Then sPath = sUNC & sx(1)
        End If
        If ToLowerCase Then sPath = LCase(sPath)
        Return sPath
    End Function

    Public Shared Function GetUNCPath(ByVal DriveLetter As Char) As String
        If String.IsNullOrEmpty(DriveLetter) Then Throw New ArgumentNullException("driveLetter")
        If (DriveLetter < "a"c OrElse DriveLetter > "z") AndAlso (DriveLetter < "A"c OrElse DriveLetter > "Z") Then Throw New ArgumentOutOfRangeException("driveLetter", "driveLetter must be a letter from A to Z")
        Dim P As New Process()
        With P.StartInfo
            .FileName = "net"
            .Arguments = String.Format("use {0}:", DriveLetter)
            .UseShellExecute = False
            .RedirectStandardOutput = True
            .CreateNoWindow = True
        End With
        P.Start()
        Dim sText As String = P.StandardOutput.ReadToEnd()
        P.WaitForExit()
        For Each sLine As String In Split(Replace(sText, vbCr, vbLf), vbLf)
            Dim iPos As Integer = -1
            If Not String.IsNullOrWhiteSpace(sLine) Then
                Dim sSlsl As String = " \\"
                If sLine.ToUpper.StartsWith("REMOTE") AndAlso sLine.ToLower.Contains("name ") AndAlso sLine.Contains(sSlsl) Then iPos = sLine.IndexOf(sSlsl) + 1
                If sLine.ToUpper.StartsWith("VZD") AndAlso sLine.ToLower.Contains("zev ") AndAlso sLine.Contains(sSlsl) Then iPos = sLine.IndexOf(sSlsl) + 1
            End If
            If iPos >= 0 Then
                Return sLine.Substring(iPos)
            End If
        Next
        Return Nothing
    End Function

End Class
