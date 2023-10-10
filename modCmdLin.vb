'   C o m m a n d L i n e		rutiny analyzy prikazoveho radku
'	6.6.2003		            CHAPS, Ing. Jiri Bartusek
'	CommandLine.vb
'
'------------------------------------------------------------
'
' Tento kod interpretuje dve funkce:
' 
' GetSwitch - vraci hodnotu, resp. existenci prepinace
' GetBoolSwitch - vraci true/false podle zjisteneho prepinace resp. podle default hodnoty
' GetCmdPar - vraci hodnotu, resp. existenci parametru (neprepinacoveho argumentu prikazoveho radku)
' GetCmdParNum - vraci pocet parametru (neprepinacovych argumentu)
'
'   pravidla pro zpracovani prikazoveho radku (vychazeji ze zabehlych zvyklosti):
'
' prepinace zacinaji pomlckou nebo lomitkem (oba znaky jsou rovnocenne).
' vice prepinacu muze, ale nemusi byt spojeno do jednoho retezce. Pri pouziti GetBoolSwitch NESMI byt
' prepinace sdruzovany do spojitych retezcu (zameni se minus na konci a zacatek noveho prepinace)
' prepinac muze mit prazdnou hodnotu, nebo hodnotu uvedenou za rovnitkem nebo dvojteckou. Hodnota 
'   muze byt uzavrena v apostrofech nebo uvozovkach (pak muze obsahovat i pomlcky a lomitka). Apostrofy
'   ani uvozovky se ve vysledku nevraceji
' kazdy argument, ktery nezacina pomlckou nebo lomitkem je bran jako parametr (neprepinacovy argument)
'   vcelku. Parametry jsou pristupne poradovym cislem podle vyskytu v prikazovem radku zleva (pocinaje 1)
'
'   F u n k c e   G E T S W I T C H
'                 -----------------
' GetSwitch vraci hodnotu prepinace. Ma-li prepinac prazdnou hodnotu, vrati se retezec <vbEmptyResult>. 
'   vbEmptyResult je definovana v tomto zdrojovem kodu a ma ASCII hodnotu 1, znamena existenci prepinace
'   s prazdnou hodnotou.
'   Neni-li prepinac v prikazovem radku vrati se prazdny retezec (Nothing).
'   Jeli funkce volana s parametrem Exact=true, nemohou byt prepinace spojeny, a jako hodnota se
'   vrati cely retezec, ktery zacina za akronymem prepinace. Akronymy prepinacu (Sw parametr) nejsou
'   case sensitivni. Vysledek se vraci ve tvaru, v jakem je v prikazove radce.
'   
'   Priklady:
'   
'   prikazovy radek                  volani funkce                  vysledek (navr.hodnota funkce)   
'
'   /YY/XX:ALFA/beta                 GetSwitch("XX")                ALFA
'   -YY-XX:'ALFA/beta'               GetSwitch("XX")                ALFA/beta
'   /YY/XX:'ALFA'                    GetSwitch("YY")                <vbEmptyResult>
'   /YY/XX:'ALFA'                    GetSwitch("ZZ")                Nothing (prazdny retezec)
'   -CC:/file.dat                    GetSwitch("C",true)            C:/file.dat 
'
'   F u n k c e   G E T B O O L S W I T C H
'                 -------------------------
' GetBoolSwitch vraci True/false, a to takto:
'   nenajde-li prepinac, vrati default hodnotu uvedenou ve volani funkce
'   najde-li prepinac s pomlckou na konci (ve vyznamu minus), vrati vzdy false
'   najde-li prepinac s plusem na konci nebo holy prepinac, vrati vzdy true
'   PRI POUZITI TECHTO TYPU PREPINACU MUSI BYT KAZDY PREPINAC ZVLAST (oddeleny mezerou)
' Neni-li v GetBoolSwitch uvedena default hodnota, je default True.
'
'   Priklady:
'   
'   prikazovy radek                  volani funkce                  vysledek (navr.hodnota funkce)   
'
'   -AA+ -BB -CC-                    GetSwitch("XX",true)           true (vraci default)
'   -AA+ -BB -CC-                    GetSwitch("AA",false)          true
'   -AA+ -BB -CC-                    GetSwitch("BB",false)          true (-BB jako pozitivni prebije)
'   -AA+ -BB -CC-                    GetSwitch("CC",true)           false (+CC- prebije)
'
'   F u n k c e   G E T C M D P A R
'                 -----------------
' GetCmdPar vraci hodnotu parametru, ktery je dan poradovym cislem. Argumenty, zacinajici pomlckou nebo
'   lomitkem se vyhodnoti jako prepinace, a do poradi argumentu se nepocitaji
'   
'   Priklady:
'   
'   prikazovy radek                  volani funkce                  vysledek (navr.hodnota funkce)   
'
'   -X /AA:1/BB soubor /CC text      GetCmdArg(1)                   soubor
'   -X /AA:1/BB soubor /CC text      GetCmdArg(5)                   Nothing (prazdny retezec)
'   -X /AA:1/BB soubor /CC text      GetCmdArg(2)                   text
'   soubor1 soubor2                  GetCmdArg(1)                   soubor1
'   soubor1 soubor2                  GetCmdArg(2)                   soubor2
'
'   F u n k c e   G E T C M D P A R N U M
'
' GetCmdParNum vraci pocet parametru (neprepinacovych argumentu) jako integer
'
#Region " Commandline - tridy umoznujici ziskat parametry prikazoveho radku a hodnoty prepinacu "
Public Module CommandLine

    Public Const vbEmptyResult As String = Chr(1) 'reprezentace pøepínaèe s prázdnou hodnotou

    'vraci hodnotu, resp. existenci prepinace
    Public Function GetSwitch(ByVal Sw As String, Optional ByVal Exact As Boolean = False, Optional ByVal KeepHyphen As Boolean = False) As String

        LoadArgs()

        Dim i, j As Integer, s, a, x, q As String

        _wasset = False
        _wasempty = False
        s = ""

        If (Mid(Sw, 1, 1) = "/") OrElse (Mid(Sw, 1, 1) = "-") Then Sw = Mid(Sw, 2)
        Sw = UCase(Trim(Sw))
        GetSwitch = ""
        For i = 0 To Args.Length - 1
            Dim bUvoz As Boolean = False
            Dim bApos As Boolean = False
            a = ""
            For ix As Integer = 0 To Args(i).Length - 1
                If Not bApos AndAlso Args(i).Chars(ix) = """"c Then
                    If bUvoz Then bUvoz = False Else bUvoz = True : If Len(a) = 0 OrElse a.Chars(Len(a) - 1) = " " Then a += Chr(255)
                    GoTo 5
                End If
                If Not bUvoz AndAlso Args(i).Chars(ix) = "'"c Then
                    If bApos Then bApos = False Else bApos = True : If Len(a) = 0 OrElse a.Chars(Len(a) - 1) = " " Then a += Chr(255)
                    GoTo 5
                End If
                If bApos OrElse bUvoz Then
                    a += Chr(255) + Replace(Replace(Replace(Replace(Replace(Args(i).Chars(ix), " ", Chr(7)), "-", Chr(6)), ":", Chr(3)), "=", Chr(2)), "/", Chr(1))
                Else
                    a += Args(i).Chars(ix)
                End If
5:          Next

            s = Replace(Replace(UCase(a), "://", Chr(5)), "//", Chr(4))
            If Exact Then
                If (Mid(s, 1, 1) = "/") Or (Mid(s, 1, 1) = "-") Then s = vbLf + Mid(s, 2)
            Else
                q = ""
                Dim ddot As Boolean = False
                For j = 1 To Len(s)
                    Dim qs As Boolean = False
                    If q = "" Then
                        If (Mid(s, j, 1) = "'") Or (Mid(s, j, 1) = """") Then
                            q = Mid(s, j, 1)
                            qs = True
                        End If
                    Else
                        If Mid(s, j, 1) = q Then
                            q = ""
                            qs = True
                        End If
                    End If
                    If (Not (qs)) And (q = "") Then
                        If (Mid(s, j, 1) = "/") OrElse ((Mid(s, j, 1) = "-") AndAlso ((Not ddot) OrElse (Not KeepHyphen))) Then
                            s = Mid(s, 1, j - 1) + vbLf + Mid(s, j + 1)
                        End If
                        If (Mid(s, j, 1) = "=") Then
                            s = Mid(s, 1, j - 1) + ":" + Mid(s, j + 1)
                            ddot = True
                        End If
                    End If
                Next
            End If
            While s <> ""
                x = Mid(a, 1, InStr(2, s + vbLf, vbLf) - 1)
                q = Mid(s, 1, InStr(2, s + vbLf, vbLf) - 1)
                a = Mid(a, Len(x) + 1)
                s = Mid(s, Len(x) + 1)
                If InStr(q, vbLf + Sw) = 1 Then
                    If Not Exact Then
                        j = InStr(q + ":", ":")
                        x = Mid(x, j + 1)
                        If Len(x) > 2 Then
                            If (Mid(x, 1, 1) = Mid(x, Len(x), 1)) And ((Mid(x, 1, 1) = "'") Or (Mid(x, 1, 1) = """")) Then
                                x = Mid(x, 2, Len(x) - 2)
                            End If
                        End If
                    Else
                        x = Mid(x, Len(Sw) + 2)
                        If (InStr(x, ":") = 1) OrElse (InStr(x, "=") = 1) Then
                            x = Mid(x, 2)
                        Else
                            If q = vbLf + Sw Then
                                _wasset = True
                                _wasempty = True
                                Return Sw + "+"
                            End If
                        End If
                        If Len(x) > 2 Then
                            If ((Mid(x, 1, 1) = """") OrElse (Mid(x, 1, 1) = "'")) AndAlso (Mid(x, 1, 1) = Mid(x, Len(x), 1)) Then
                                x = Mid(x, 2, Len(x) - 2)
                            End If
                        End If
                    End If
                    If x = "" Then x = vbEmptyResult
                    _wasset = True
                    _wasempty = (x = vbEmptyResult)
                    'x = Replace(Replace(x, "://", Chr(5)), "//", Chr(4))
                    Return DecodeArg(Chr(255) + x)
                End If
            End While
        Next
    End Function

    Public Function DecodeArg(s As String) As String
        If Len(s) > 1 AndAlso s.Chars(0) = Chr(255) Then Return Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(s, Chr(255), ""), Chr(7), " "), Chr(6), "-"), Chr(2), "="), Chr(3), ":"), Chr(1), "/"), Chr(4), "//"), Chr(5), "://")
        Return Replace(Replace(Replace(s, Chr(255), ""), Chr(4), "//"), Chr(5), "://")
    End Function

    'vraci true/false podle zjisteneho prepinace resp. podle default hodnoty
    Public Function GetBoolSwitch(ByVal Sw As String, Optional ByVal DefaultValue As Boolean = False, Optional ByVal Exact As Boolean = True) As Boolean
        Dim s As String = GetSwitch(Sw, Exact)
        If s = "" Then Return DefaultValue
        If Mid(s, Len(s), 1) = "+" Then Return True
        If Mid(s, Len(s), 1) = "-" Then Return False
        If Mid(s, Len(s), 1) = vbEmptyResult Then Return True
        Return SwitchWasSet()
    End Function

    'True, pokud byl naposledy dotazovany switch zapnut
    Public Function SwitchWasSet() As Boolean
        Return _wasset
    End Function

    'True, pokud naposledy dotazovany switch nebyl zapnut
    Public Function SwitchWasEmpty() As Boolean
        Return _wasempty
    End Function

    'vraci hodnotu, resp. existenci parametru (neprepinacoveho argumentu prikazoveho radku)
    Public Function GetCmdPar(ByVal Indx As Integer) As String

        LoadArgs()

        Dim j As Integer = 0
        For i As Integer = 0 To Args.Length - 1
            Dim a As String = Replace(Args(i), "//", Chr(4))
            If Not ((Mid(a, 1, 1) = "/") Or (Mid(a, 1, 1) = "-")) Then
                j += 1
                If j = Indx Then
                    Return DecodeArg(a)
                End If
            End If
        Next
        Return ""
    End Function

    'vraci pocet parametru (neprepinacovych argumentu)
    Public Function GetCmdParNum() As Integer

        LoadArgs()

        Dim j As Integer = 0
        For i As Integer = 0 To Args.Length - 1
            Dim a As String = Args(i)
            If a <> "" Then
                If Not ((Mid(a, 1, 1) = "/") Or (Mid(a, 1, 1) = "-")) Then
                    j += 1
                End If
            End If
        Next
        Return j

    End Function

End Module
#End Region


#Region " CmdArgs - instance pole parametru prikazoveho radku "
Module CmdArgs

    Public Args() As String 'vlastní pole argumentù
    Friend ErrArgs As Boolean = False

    'naètení pole argumentù (volá se automaticky po Getswitch atd...)
    Public Sub LoadArgs()
        Try
            If Args Is Nothing Then
                Dim separators As String = " "

                Dim commands As String = Microsoft.VisualBasic.Command()
                Dim bUvoz As Boolean = False
                Dim bApos As Boolean = False
                Dim a As String = ""
                For ix As Integer = 0 To commands.Length - 1
                    If Not bApos AndAlso commands.Chars(ix) = """"c Then
                        If bUvoz Then bUvoz = False Else bUvoz = True : If Len(a) = 0 OrElse a.Chars(Len(a) - 1) = " " Then a += Chr(255)
                        GoTo 5
                    End If
                    If Not bUvoz AndAlso commands.Chars(ix) = "'"c Then
                        If bApos Then bApos = False Else bApos = True : If Len(a) = 0 OrElse a.Chars(Len(a) - 1) = " " Then a += Chr(255)
                        GoTo 5
                    End If
                    If bApos OrElse bUvoz Then
                        a += Replace(Replace(Replace(Replace(Replace(commands.Chars(ix), " ", Chr(7)), "-", Chr(6)), ":", Chr(3)), "=", Chr(2)), "/", Chr(1))
                    Else
                        a += commands.Chars(ix)
                    End If
5:              Next
                commands = a

                Args = commands.Split(separators.ToCharArray)
            End If
        Catch ex As system.Exception
            If Not ErrArgs Then
                MsgBox("Nelze zjistit parametry pøíkazové øádky." + vbLf + vbLf + ex.Message)
                ErrArgs = True
            End If
        End Try
    End Sub

    ''' <summary> pole aktualnich argumentu </summary>
    Public Function GetArgs() As String()
        Return Args
    End Function

    ''' <summary> vrati vsechny aktualni argumenty </summary>
    ''' <param name="AddParams"> dalsi argumenty k existujicim </param>
    ''' <returns></returns>
    Public Function AllCmdArgs(ParamArray AddParams() As String) As String
        Dim sRet As String = ""
        For Each s As String In GetArgs()
            If Not String.IsNullOrWhiteSpace(s) Then
                If sRet <> "" Then sRet &= " "
                sRet &= s
            End If
        Next
        For Each s As String In AddParams
            If Not String.IsNullOrWhiteSpace(s) AndAlso Array.IndexOf(Args, s) < 0 Then
                If sRet <> "" Then sRet &= " "
                sRet &= s
            End If
        Next
        Return sRet
    End Function

    Public _wasempty As Boolean
    Public _wasset As Boolean

End Module
#End Region
