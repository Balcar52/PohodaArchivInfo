

<XmlRoot("ArchivInfoData")>
Partial Public Class AData

    Public Enum TypObj As Integer
        Prij = 1
        Vyd = 2
        FakV = 1
        FakP = 11
    End Enum

    Public Sub New()
        MyBase.New
    End Sub

    Public Shared Function ConvertMena(sMena As String) As String
        Return Replace(Replace(sMena, "EUR", "€"), "USD", "$")
    End Function

    Public Sub AddMdbFile(sMdbFilename As String, sPassword As String, iNewFileID As Integer, Optional ByRef iRemoved As Integer = 0)
        Dim oFile As New AFile(sMdbFilename, sPassword, iNewFileID)
        RemoveDataMdbFile(sMdbFilename, iRemoved)
        aoFiles.Add(oFile)
    End Sub

    Public Sub RemoveDataMdbFile(sMdbFilename As String, Optional ByRef iRemoved As Integer = 0)
        Dim oFile As New AFile(sMdbFilename)
        iRemoved = 0
        For i As Integer = aoFiles.Count - 1 To 0 Step -1
            If String.Compare(aoFiles(i).PureFileName, oFile.PureFileName, True) = 0 Then
                For i2 As Integer = aoFirmyObjPrij.Count - 1 To 0 Step -1
                    For i3 As Integer = aoFirmyObjPrij(i2).aoDoc.Count - 1 To 0 Step -1
                        If aoFirmyObjPrij(i2).aoDoc(i3).FileID = aoFiles(i).Id Then
                            iRemoved += aoFirmyObjPrij(i2).aoDoc(i3).aoObjPol.Count
                            aoFirmyObjPrij(i2).aoDoc.RemoveAt(i3)
                        End If
                    Next
                    If aoFirmyObjPrij(i2).aoDoc.Count = 0 Then aoFirmyObjPrij.RemoveAt(i2)
                Next
                For i2 As Integer = aoFirmyObjVyd.Count - 1 To 0 Step -1
                    For i3 As Integer = aoFirmyObjVyd(i2).aoDoc.Count - 1 To 0 Step -1
                        If aoFirmyObjVyd(i2).aoDoc(i3).FileID = aoFiles(i).Id Then
                            iRemoved += aoFirmyObjVyd(i2).aoDoc(i3).aoObjPol.Count
                            aoFirmyObjVyd(i2).aoDoc.RemoveAt(i3)
                        End If
                    Next
                    If aoFirmyObjVyd(i2).aoDoc.Count = 0 Then aoFirmyObjVyd.RemoveAt(i2)
                Next
                For i2 As Integer = aoFirmyNab.Count - 1 To 0 Step -1
                    For i3 As Integer = aoFirmyNab(i2).aoDoc.Count - 1 To 0 Step -1
                        If aoFirmyNab(i2).aoDoc(i3).FileID = aoFiles(i).Id Then
                            iRemoved += aoFirmyNab(i2).aoDoc(i3).aoObjPol.Count
                            aoFirmyNab(i2).aoDoc.RemoveAt(i3)
                        End If
                    Next
                    If aoFirmyNab(i2).aoDoc.Count = 0 Then aoFirmyNab.RemoveAt(i2)
                Next
                For i2 As Integer = aoFirmyFVyd.Count - 1 To 0 Step -1
                    For i3 As Integer = aoFirmyFVyd(i2).aoDocF.Count - 1 To 0 Step -1
                        If aoFirmyFVyd(i2).aoDocF(i3).FileID = aoFiles(i).Id Then
                            iRemoved += aoFirmyFVyd(i2).aoDocF(i3).aoFaktPol.Count
                            aoFirmyFVyd(i2).aoDocF.RemoveAt(i3)
                        End If
                    Next
                    If aoFirmyFVyd(i2).aoDocF.Count = 0 Then aoFirmyFVyd.RemoveAt(i2)
                Next
                For i2 As Integer = aoFirmyFPrij.Count - 1 To 0 Step -1
                    For i3 As Integer = aoFirmyFPrij(i2).aoDocF.Count - 1 To 0 Step -1
                        If aoFirmyFPrij(i2).aoDocF(i3).FileID = aoFiles(i).Id Then
                            iRemoved += aoFirmyFPrij(i2).aoDocF(i3).aoFaktPol.Count
                            aoFirmyFPrij(i2).aoDocF.RemoveAt(i3)
                        End If
                    Next
                    If aoFirmyFPrij(i2).aoDocF.Count = 0 Then aoFirmyFPrij.RemoveAt(i2)
                Next
                aoFiles.RemoveAt(i)
            End If
        Next
    End Sub

    Public ReadOnly Property IsEmpty As Boolean
        Get
            Return aoFiles.Count = 0
        End Get
    End Property

    Public ReadOnly Property IsNotEmpty As Boolean
        Get
            Return Not IsEmpty
        End Get
    End Property

    <XmlElement("ver")>
    Public FileVersion As String = "not defined"

    Public ReadOnly Property GetFileVersion As String
        Get
            Return CStr(FileVersion)
        End Get
    End Property

    <XmlElement("fil")>
    Public aoFiles As New List(Of AFile)

    <XmlElement("v")>
    Public aoFirmyNab As New List(Of AFirma)

    <XmlElement("o")>
    Public aoFirmyObjPrij As New List(Of AFirma)

    <XmlElement("f")>
    Public aoFirmyFVyd As New List(Of AFirma)

    <XmlElement("fp")>
    Public aoFirmyFPrij As New List(Of AFirma)

    <XmlElement("ov")>
    Public aoFirmyObjVyd As New List(Of AFirma)

    Public Function GetMaxFileID() As Integer
        Dim iRet As Integer = 0
        For Each oFile As AFile In aoFiles
            If oFile.Id > iRet Then iRet = oFile.Id
        Next
        Return iRet + 1
    End Function


    Public Function AddFirmaObjNab(JmenoFirmy As String, ICO As Decimal, Email As String, Zeme As String, iFId As Integer, aoFirmy As List(Of AFirma)) As AFirma
        Dim oFrm As New AFirma(JmenoFirmy, ICO, Email, Zeme, iFId)
        Dim iIdx As Integer = -1
        Dim o As AFirma = Nothing
        For i As Integer = 0 To aoFirmy.Count - 1
            o = aoFirmy(i)
            If (o.ICO = oFrm.ICO AndAlso o.ICO > 0) OrElse o.KeyName = oFrm.KeyName Then
                ' nic
                iIdx = i
                Exit For
            End If
        Next
        If iIdx < 0 Then
            aoFirmy.Add(oFrm)
            iIdx = aoFirmy.Count - 1
            o = aoFirmy(iIdx)
        End If
        'If Not o.Names.Contains(JmenoFirmy) Then
        '    o.Names.Add(JmenoFirmy)
        '    aoFirmy(iIdx) = o
        'End If
        Return oFrm
    End Function

    ''' <summary> Rocni soubory </summary>
    Public Class AFile
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(sFilename As String, sPassword As String, iId As Integer)
            MyBase.New
            UsedFileName = sFilename
            PureFileName = LCase(IO.Path.GetFileName(sFilename))
            Pw = sPassword
            FileDate = IO.File.GetLastWriteTime(sFilename)
            DateImported = Now
            Id = iId
        End Sub
        Public Sub New(sFileName)
            MyBase.New
            UsedFileName = sFileName
            PureFileName = LCase(IO.Path.GetFileName(sFileName))
        End Sub
        <XmlAttribute("pn")>
        Public PureFileName As String = ""
        <XmlAttribute("fn")>
        Public UsedFileName As String = ""
        <XmlAttribute("id")>
        Public Id As Integer = 0
        <XmlAttribute("pw")>
        Public Pw As String = ""
        <XmlAttribute("im")>
        Public DateImported As New Date
        <XmlAttribute("dt")>
        Public FileDate As New Date
    End Class

    ''' <summary> Firma v prijatych objednavkach a nabidkach </summary>
    Public Class AFirma
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(JmenoFirmy As String, dcICO As Decimal, sEmail As String, sZeme As String, iFileId As Integer)
            MyBase.New
            KeyName = Trim(XControls.CutDiacritic(UCase(JmenoFirmy)))
            While KeyName.Contains(". ")
                KeyName = Replace(KeyName, ". ", ".")
            End While
            While KeyName.Contains("  ")
                KeyName = Replace(KeyName, "  ", " ")
            End While
            While KeyName.Contains("- ")
                KeyName = Replace(KeyName, "- ", "-")
            End While
            While KeyName.Contains(" -")
                KeyName = Replace(KeyName, " -", "-")
            End While
            ICO = dcICO
            Email = sEmail
            Zeme = sZeme
        End Sub
        <XmlAttribute("k")>
        Public KeyName As String = ""
        <XmlAttribute("o")>
        Public ICO As Decimal = 0
        <XmlAttribute("e"), DefaultValue("")>
        Public Email As String = ""
        <XmlAttribute("z"), DefaultValue("")>
        Public Zeme As String = ""
        <XmlElement("d")>
        Public aoDoc As New List(Of AObjNab)
        <XmlElement("f")>
        Public aoDocF As New List(Of AFakt)
        <XmlIgnore>
        Public DisplayName As String = ""
        Public ReadOnly Property GetDisplayName(Optional FullText As Boolean = True) As String
            Get
                If String.IsNullOrEmpty(DisplayName) Then Return "(neuvedeno)"
                Dim sRet As String = DisplayName
                If Not String.IsNullOrEmpty(Zeme) Then sRet &= " [" & Zeme & "]"
                Return sRet
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0}; {1}; {2}; {3}; {4};", DisplayName, Email, aoDoc.Count, aoDocF.Count, KeyName)
        End Function

        Public Sub SetDisplayName()
            Dim aoNames As New Dictionary(Of String, Integer)
            Dim iMax As Integer = 0
            For i As Integer = 0 To aoDoc.Count - 1
                If Not aoNames.ContainsKey(aoDoc(i).Name) Then
                    aoNames(aoDoc(i).Name) = 1
                Else
                    aoNames(aoDoc(i).Name) = aoNames(aoDoc(i).Name) + 1
                End If
                If aoNames(aoDoc(i).Name) > iMax Then iMax = aoNames(aoDoc(i).Name)
            Next
            For Each s In aoNames.Keys
                If aoNames(s) = iMax Then
                    If String.IsNullOrWhiteSpace(s) Then
                        DisplayName = "(neuvedeno)"
                    Else
                        DisplayName = s
                    End If
                End If
            Next
        End Sub

        Public Sub SetDisplayNameF()
            Dim aoNames As New Dictionary(Of String, Integer)
            Dim iMax As Integer = 0
            For i As Integer = 0 To aoDocF.Count - 1
                If Not aoNames.ContainsKey(aoDocF(i).Name) Then
                    aoNames(aoDocF(i).Name) = 1
                Else
                    aoNames(aoDocF(i).Name) = aoNames(aoDocF(i).Name) + 1
                End If
                If aoNames(aoDocF(i).Name) > iMax Then iMax = aoNames(aoDocF(i).Name)
            Next
            For Each s In aoNames.Keys
                If aoNames(s) = iMax Then
                    If String.IsNullOrWhiteSpace(s) Then
                        DisplayName = "(neuvedeno)"
                    Else
                        DisplayName = s
                    End If
                End If
            Next
        End Sub

        Public Class Sorter
            Implements IComparer(Of AFirma)
            ''' <summary> sorter rekapitulace </summary>
            ''' <param name="x"></param>
            ''' <param name="y"></param>
            Public Function Compare(x As AFirma, y As AFirma) As Integer Implements IComparer(Of AFirma).Compare
                Dim iRet As Integer = String.Compare(x.DisplayName, y.DisplayName, True)
                If iRet = 0 Then iRet = String.Compare(x.KeyName, y.KeyName, True)
                Return iRet
            End Function
        End Class
    End Class

    ''' <summary> polozka prijate/vydane objednavky </summary>
    Public Class AObjNab
        Public Sub New()
            MyBase.New
        End Sub

        Public Const sOpt1 As String = "OBJEDNAVAMEUVAS"
        Public Const sOpt2 As String = "OBJEDNAVAME"
        Public Const sOpt3 As String = "OBJEDNAVAMEDODANI"
        Public Sub New(iRecID As Integer, iFileId As Integer, sName As String, lCislo As Long, dtDatum As Date, sText As String, dcKc As Decimal, sMena As String, dcKurs As Decimal)
            MyBase.New
            RecID = iRecID
            FileID = iFileId
            Name = sName
            Datum = dtDatum.ToString("ddMMyy")
            Cislo = lCislo
            Kc = dcKc
            Mena = Replace(sMena, "EUR", "€")
            Kurs = dcKurs
            Dim sOpt As String = XControls.CutDiacritic(Replace(Replace(UCase(sText), ":", ""), " ", ""))
            Select Case sOpt
                Case sOpt1, sOpt2, sOpt3
                Case Else
                    Text = sText
            End Select
        End Sub
        <XmlAttribute("r")>
        Public RecID As Integer = 0
        <XmlAttribute("f")>
        Public FileID As Integer = 0
        <XmlAttribute("n")>
        Public Name As String = ""
        <XmlAttribute("t"), DefaultValue("")>
        Public Text As String = ""
        <XmlAttribute("c")>
        Public Cislo As Long = 0L
        <XmlAttribute("d")>
        Public Datum As String = ""
        <XmlAttribute("p"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Kc As Decimal = 0
        <XmlAttribute("k"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Kurs As Decimal = 0
        <XmlAttribute("m"), DefaultValue("")>
        Public Mena As String
        <XmlElement("l")>
        Public aoObjPol As New List(Of AObjNabPol)
        Public ReadOnly Property JeCena As Boolean
            Get
                Return Kc > 0
            End Get
        End Property
        Public ReadOnly Property JeCiziMena As Boolean
            Get
                Return Kurs > 0
            End Get
        End Property
        Public ReadOnly Property CiziMena As String
            Get
                Dim sRet As String = ""
                If JeCiziMena AndAlso JeCena Then
                    sRet = Mena & " " & (Kc / Kurs).ToString("0.00")
                End If
                Return sRet
            End Get
        End Property
        Public ReadOnly Property dtDatum As Date
            Get
                If IsNumeric(Datum) AndAlso Datum.Length = 6 Then
                    Return New Date(CInt(Datum.Substring(4, 2) + 2000), CInt(Datum.Substring(2, 2)), CInt(Datum.Substring(0, 2)))
                End If
                Return New Date
            End Get
        End Property

        Public Class Sorter
            Implements IComparer(Of AObjNab)
            Public Function Compare(x As AObjNab, y As AObjNab) As Integer Implements IComparer(Of AObjNab).Compare
                Dim iRet As Integer = Date.Compare(x.dtDatum, y.dtDatum)
                If iRet = 0 Then iRet = CompareLong(x.Cislo, y.Cislo)
                If iRet = 0 Then iRet = String.Compare(x.Name, y.Name, True)
                Return -iRet
            End Function
        End Class

    End Class

    ''' <summary> Polozka nabidky/objednavky </summary>
    Public Class AObjNabPol
        Public Sub New()
            MyBase.New
        End Sub

        Public Sub New(iID As Integer, sText As String, sPozn As String, dcMnoz As Decimal, dcKc As Decimal)
            MyBase.New
            ID = iID
            Text = sText
            Pozn = sPozn
            Mnoz = dcMnoz
            Kc = dcKc
        End Sub
        <XmlAttribute("x")>
        Public ID As Integer = 0
        <XmlAttribute("t"), DefaultValue("")>
        Public Text As String = ""
        <XmlAttribute("n"), DefaultValue("")>
        Public Pozn As String = ""
        <XmlAttribute("a"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Mnoz As Decimal = -1
        <XmlAttribute("p"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Kc As Decimal = -1

        Public ReadOnly Property JeMnozstvi As Boolean
            Get
                Return Mnoz > 0
            End Get
        End Property
        Public ReadOnly Property JeCena As Boolean
            Get
                Return Kc > 0
            End Get
        End Property
        Public ReadOnly Property JeCenaMnozstvi As Boolean
            Get
                Return JeCena AndAlso JeMnozstvi
            End Get
        End Property
        Public ReadOnly Property JeCiziMena(oRoot As AObjNab) As Boolean
            Get
                Return oRoot.Kurs > 0
            End Get
        End Property
        Public ReadOnly Property CiziMena(oRoot As AObjNab) As String
            Get
                Dim sRet As String = ""
                If JeCiziMena(oRoot) AndAlso JeCenaMnozstvi Then
                    sRet = oRoot.Mena & " " & ((Kc * Mnoz) / oRoot.Kurs).ToString("0.00")
                End If
                Return sRet
            End Get
        End Property
        Public ReadOnly Property Cena() As String
            Get
                Dim sRet As String = ""
                If JeCenaMnozstvi Then
                    sRet = (Kc * Mnoz).ToString("0.00")
                End If
                Return sRet
            End Get
        End Property

    End Class

    Public Class APolozka
        Public Sub New(oFirma As AFirma, oObj As AObjNab, oObjP As AObjNabPol)
            MyBase.New
            Firma = oFirma
            Obj = oObj
            ObjP = oObjP
        End Sub
        Public Firma As AFirma = Nothing
        Public Obj As AObjNab = Nothing
        Public ObjP As AObjNabPol = Nothing
    End Class

    ''' <summary> prijata/vydana faktura </summary>
    Public Class AFakt
        Public Sub New()
            MyBase.New
        End Sub

        Public Const sOpt1 As String = "FAKTURUJEMEVAM"

        Public Sub New(iRecID As Integer, iFileId As Integer, sName As String, lCislo As Long, dtDatum As Date, sText As String, dcKc As Decimal, sMena As String, dcKurs As Decimal)
            MyBase.New
            RecID = iRecID
            FileID = iFileId
            Name = sName
            Datum = dtDatum.ToString("ddMMyy")
            Cislo = lCislo
            Kc = dcKc
            Mena = sMena
            Kurs = dcKurs
            'If Kurs > 0 Then
            '    Debug.WriteLine("zxzz")
            'End If
            Dim sOpt As String = XControls.CutDiacritic(Replace(Replace(UCase(sText), ":", ""), " ", ""))
            Select Case sOpt
                Case sOpt1
                Case Else
                    Text = sText
            End Select
        End Sub
        <XmlAttribute("r")>
        Public RecID As Integer = 0
        <XmlAttribute("f")>
        Public FileID As Integer = 0
        <XmlAttribute("n")>
        Public Name As String = ""
        <XmlAttribute("t"), DefaultValue("")>
        Public Text As String = ""
        <XmlAttribute("c")>
        Public Cislo As Long = 0L
        <XmlAttribute("d")>
        Public Datum As String = ""
        <XmlAttribute("p"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Kc As Decimal = -1
        <XmlAttribute("k"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Kurs As Decimal = -1
        <XmlAttribute("m"), DefaultValue("")>
        Public Mena As String = ""
        Public ReadOnly Property JeCena As Boolean
            Get
                Return Kc > 0
            End Get
        End Property
        Public ReadOnly Property JeCiziMena As Boolean
            Get
                Return Kurs > 0
            End Get
        End Property
        Public ReadOnly Property CiziMena As String
            Get
                Dim sRet As String = ""
                If JeCiziMena AndAlso JeCena Then
                    sRet = Mena & " " & (Kc / Kurs).ToString("0.00")
                End If
                Return sRet
            End Get
        End Property
        <XmlElement("l")>
        Public aoFaktPol As New List(Of AFaktPol)
        Public ReadOnly Property dtDatum As Date
            Get
                If IsNumeric(Datum) AndAlso Datum.Length = 6 Then
                    Return New Date(CInt(Datum.Substring(4, 2) + 2000), CInt(Datum.Substring(2, 2)), CInt(Datum.Substring(0, 2)))
                End If
                Return New Date
            End Get
        End Property

        Public Class Sorter
            Implements IComparer(Of AFakt)
            Public Function Compare(x As AFakt, y As AFakt) As Integer Implements IComparer(Of AFakt).Compare
                Dim iRet As Integer = Date.Compare(x.dtDatum, y.dtDatum)
                If iRet = 0 Then iRet = CompareLong(x.Cislo, y.Cislo)
                If iRet = 0 Then iRet = String.Compare(x.Name, y.Name, True)
                Return -iRet
            End Function
        End Class

    End Class

    ''' <summary> Polozka faktury </summary>
    Public Class AFaktPol
        Public Sub New()
            MyBase.New
        End Sub

        Public Sub New(iID As Integer, sText As String, sPozn As String, dcMnoz As Decimal, dcKc As Decimal)
            MyBase.New
            ID = iID
            Text = sText
            Pozn = sPozn
            Mnoz = dcMnoz
            Kc = dcKc
        End Sub
        <XmlAttribute("x")>
        Public ID As Integer = 0
        <XmlAttribute("t")>
        Public Text As String = ""
        <XmlAttribute("n"), DefaultValue("")>
        Public Pozn As String = ""
        <XmlAttribute("a"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Mnoz As Decimal = -1
        <XmlAttribute("p"), DefaultValue(GetType(Decimal), "0.0000")>
        Public Kc As Decimal = -1
        Public ReadOnly Property JeMnozstvi As Boolean
            Get
                Return Mnoz > 0
            End Get
        End Property
        Public ReadOnly Property JeCena As Boolean
            Get
                Return Kc > 0
            End Get
        End Property
        Public ReadOnly Property JeCenaMnozstvi As Boolean
            Get
                Return JeCena AndAlso JeMnozstvi
            End Get
        End Property
        Public ReadOnly Property JeCiziMena(oRoot As AFakt) As Boolean
            Get
                Return oRoot.Kurs > 0
            End Get
        End Property
        Public ReadOnly Property CiziMena(oRoot As AFakt) As String
            Get
                Dim sRet As String = ""
                If JeCiziMena(oRoot) AndAlso JeCenaMnozstvi Then
                    sRet = oRoot.Mena & " " & ((Kc * Mnoz) / oRoot.Kurs).ToString("0.00")
                End If
                Return sRet
            End Get
        End Property
        Public ReadOnly Property Cena() As String
            Get
                Dim sRet As String = ""
                If JeCenaMnozstvi Then
                    sRet = (Kc * Mnoz).ToString("0.00")
                End If
                Return sRet
            End Get
        End Property

    End Class

    'Public Class APolozkaF
    '    Public Sub New(oFirma As AFirma, oFPol As AFaktPol)
    '        MyBase.New
    '        Firma = oFirma
    '        FPol = oFPol
    '    End Sub
    '    Public Firma As AFirma = Nothing
    '    Public FPol As AFaktPol = Nothing
    'End Class

End Class
