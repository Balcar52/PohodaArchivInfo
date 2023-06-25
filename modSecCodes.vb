Option Strict On
'SecCodes
'
'Nastroje pro sifrovani duvernych informaci v ConnectionString
'Jsou obecne pouzitelne. Kodovani je pomerne jednoduche, brani
'hrubemu zneuziti
Public Module SecCodes

    Private bStarted As Boolean = False

    'kodovani retezce 
    Public Function PwCode(ByVal LogStr As String) As String
        If Not bStarted Then Randomize()
        bStarted = True
        If Mid(LogStr + " ", 1, 1) = "$" Then LogStr = PwDecode(LogStr)
        If Mid(LogStr + " ", 1, 1) = "@" Then LogStr = PwDecode(LogStr)

        Dim msk As Integer = CInt(Int((254 - 16 + 1) * Rnd()) + 16)
        Dim s As String = "@" + Hex(msk)
        Dim i, j As Integer, s1 As String

        If Len(LogStr) > 0 Then
            If Mid(LogStr, 1, 1) = s Then Return LogStr
        End If
        For i = 1 To Len(LogStr)
            j = Asc(Mid(LogStr, i, 1)) Xor msk
            s1 = Hex(j)
            If Len(s1) < 2 Then s1 = "0" + s1
            s = s + s1
            msk = msk << 1
            If (msk And &H100) <> 0 Then msk = (msk And &HFF) Or 1
        Next
        Dim res As String = "  " + Hex((Not msk))
        Return s + Mid(res, Len(res) - 1, 2)
    End Function

    Public Function HasAsterisk(ByVal LogStr As String) As Boolean
        Return (Not String.IsNullOrWhiteSpace(LogStr)) AndAlso LogStr.Contains("*")
    End Function

    'dekodovani retezce    
    Public Function PwDecode(ByVal LogStr As String, Optional ByRef QuestionChars As Boolean = False) As String
        If QuestionChars AndAlso Not String.IsNullOrEmpty(LogStr) Then
            QuestionChars = LogStr.Contains("?")
            LogStr = Replace(LogStr, "?", "")
        End If
        If (Len(LogStr) = 5) AndAlso (Mid(LogStr, 1, 1) = "@") Then
            Return ""
        ElseIf (Len(LogStr) > 6) AndAlso (Mid(LogStr, 1, 1) = "@") Then
            Dim i As Long
            Dim s As String = ""
            Dim msk As Long = ConvHex(Mid(LogStr, 2, 2))
            Dim msk2 As Long = Not ConvHex(Mid(LogStr, Len(LogStr) - 1, 2))
            LogStr = Mid(LogStr, 4, Len(LogStr) - 5) + "   "
            While (Len(LogStr) > 2) And (Mid(LogStr, 2, 1) <> " ")
                i = (ConvHex(Mid(LogStr, 1, 2)))
                i = (ConvHex(Mid(LogStr, 1, 2)) Xor msk)
                s = s + Chr(CInt(ConvHex(Mid(LogStr, 1, 2)) Xor msk))
                msk = msk << 1
                If (msk And &H100) <> 0 Then msk = (msk And &HFF) Or 1
                LogStr = Mid(LogStr, 3)
            End While
            If (msk2 And &HFF) <> msk Then s = "?"
            Return s
        ElseIf (Len(LogStr) > 2) AndAlso (Mid(LogStr, 1, 1) = "$") Then
            Dim s$ = ""
            Dim msk% = 5
            LogStr = Mid(LogStr, 2) + "   "
            While (Len(LogStr) > 2) And (Mid(LogStr, 2, 1) <> " ")
                s = s + Chr(CInt(ConvHex(Mid(LogStr, 1, 2)) Xor msk))
                msk = msk << 1
                If (msk And &H100) <> 0 Then msk = (msk And &HFF) Or 1
                LogStr = Mid(LogStr, 3)
            End While
            Return s
        End If
        Return LogStr
    End Function

    'kodovani/dekodovani chranenych casti connectionstringu    
    Public Function SubsCodeKey(ByVal sValue As String, ByVal sKey As String, ByVal Decode As Boolean) As String

        Dim k, i, l As Integer, s As String

        sValue = ";" & Trim(sValue) & ";"
        k = InStr(UCase(sValue), UCase(sKey))
        If k > 0 Then
            i = Len(sKey)
            l = InStr(k + i, sValue, ";")
            If Decode Then
                s = Mid(sValue, 2, k - 2 + i) + PwDecode(Mid(sValue, k + i, l - (k + i)))
            Else
                s = Mid(sValue, 2, k - 2 + i) + PwCode(Mid(sValue, k + i, l - (k + i)))
            End If
            If l < Len(sValue) Then s = s + Mid(sValue, l, Len(sValue) - l)
            Return s
        End If
        Return sValue
    End Function

    'eliminace casti connectionstringu    
    Public Function ElimCodeKey(ByVal sValue As String, ByVal sKey As String) As String

        Dim k, i, l As Integer, s As String

        sValue = ";" & Trim(sValue) & ";"
        k = InStr(UCase(sValue), UCase(sKey))
        If k > 0 Then
            i = Len(sKey)
            l = InStr(k + i, sValue, ";")
            s = Mid(sValue, 1, k)
            If l < Len(sValue) Then s = s + Mid(sValue, l)
            Return TruncConnStr(s)
        End If
        Return sValue
    End Function

    'eliminace casti connectionstringu    
    Public Function ExtractCodeKey(ByVal sValue As String, ByVal sKey As String) As String

        Dim k As Integer, s As String

        sValue = ";" + Trim(sValue) + ";"
        k = InStr(UCase(sValue), UCase(sKey))
        If k > 0 Then
            s = sValue.Substring(k + sKey.Length - 1)
            s = Trim(UCase(s).Substring(0, s.IndexOf(";")))
            Return TruncConnStr(s)
        End If
        Return sValue
    End Function

    ''test na integrated security
    'Public Function IsIntegratredSecurity(ByVal ConnectionString As String) As Boolean
    '    Dim s As String = ExtractCodeKey(ConnectionString, ncIntegrSec)
    '    Return (s = ncIntegrSec1) OrElse (s = ncIntegrSec2)
    'End Function

    'Konverze hexadecimánlího øetìzce do Long
    Private Function ConvHex(ByVal sValue As String) As Long
        Dim i, j As Integer, s As String
        Dim lngRes As Long = 0
        Dim c As Char

        s = UCase(sValue)
        For i = 1 To Len(s)
            c = CChar(Mid(s, i, 1))
            j = AscW(c)
            lngRes = lngRes << 4
            If (j >= 48) And (j <= 57) Then
                lngRes = lngRes + (j - 48)
            End If
            If (j >= 65) And (j <= 70) Then
                lngRes = lngRes + (j - 65 + 10)
            End If
        Next
        Return lngRes
    End Function

    'uprava connection stringu
    '-odstraneni dvojitych stredniku
    '-odstraneni stredniku na konci
    Public Function TruncConnStr(ByVal sValue As String) As String
        sValue = Trim(sValue)
        While InStr(sValue, ";;") > 0
            sValue = Replace(sValue, ";;", ";")
        End While
        If Mid(sValue, 1, 1) = ";" Then sValue = Mid(sValue, 2)
        If sValue <> "" Then
            If Mid(sValue, Len(sValue), 1) = ";" Then sValue = Mid(sValue, 1, Len(sValue) - 1)
        End If
        Return sValue
    End Function

End Module