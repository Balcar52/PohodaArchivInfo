Imports System.Reflection

Module modMisc

    Public Const MinDate As Date = #1/1/1900#
    Public Const MaxDate As Date = #3/3/3333#

    Public Const txtAppName As String = "PohodaArchivInfo"

    Public oConn As OleDb.OleDbConnection = Nothing
    Public sConnStdCtr As String = Nothing

    Public iMForm As Form = Nothing
    Public RealUserName As String = ""

    Public bShowAttentionImportMdb As Boolean = True

    Public Function ValidDate(Value As Date) As Boolean
        Return XControls.IsValidDate(Value)
    End Function

    Public Function CompareInteger(ByVal ValueA As Integer, ByVal ValueB As Integer) As Integer
        If ValueA < ValueB Then Return -1
        If ValueA > ValueB Then Return 1 Else Return 0
    End Function

    Public Function CompareLong(ByVal ValueA As Long, ByVal ValueB As Long) As Integer
        If ValueA < ValueB Then Return -1
        If ValueA > ValueB Then Return 1 Else Return 0
    End Function

    Public Function GetAssemblyVersion(Optional ByVal oAsm As System.Reflection.Assembly = Nothing, Optional ByVal sPrefix As String = "verze: ", Optional ByRef AssemblyName As String = "") As String
        If oAsm Is Nothing Then oAsm = Assembly.GetExecutingAssembly
        AssemblyName = Split(oAsm.ToString & ",", ",")(0)
        Dim s As String = oAsm.ToString + ",,,"
        Dim i As Integer = InStr(UCase(s), "VERSION=")
        If i > 0 Then
            s = Mid(s, i + 8)
            s = Trim(Mid(s, 1, InStr(s, ",") - 1))
            If Mid(s, Len(s) - 1) = ".0" Then s = Mid(s, 1, Len(s) - 2)
            Return sPrefix + s
        End If
        Return ""
    End Function

End Module
