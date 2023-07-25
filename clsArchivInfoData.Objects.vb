﻿

<XmlRoot("ArchivInfoData")>
Partial Public Class AData

    Public Enum TypObj As Integer
        Prij = 1
        Vyd = 2
    End Enum

    Public Sub New()
        MyBase.New
    End Sub

    Public Sub AddMdbFile(sMdbFilename As String, sPassword As String, iNewFileID As Integer)
        Dim oFile As New AFile(sMdbFilename, sPassword, iNewFileID)
        For i As Integer = aoFiles.Count - 1 To 0 Step -1
            If String.Compare(aoFiles(i).PureFileName, oFile.PureFileName, True) = 0 Then
                For i2 As Integer = aoFirmyObj.Count - 1 To 0 Step -1
                    For i3 As Integer = aoFirmyObj(i2).aoObj.Count - 1 To 0 Step -1
                        If aoFirmyObj(i2).aoObj(i3).FileID = aoFiles(i).Id Then aoFirmyObj(i2).aoObj.RemoveAt(i3)
                    Next
                Next
                For i2 As Integer = aoFirmyNab.Count - 1 To 0 Step -1
                    For i3 As Integer = aoFirmyNab(i2).aoObj.Count - 1 To 0 Step -1
                        If aoFirmyNab(i2).aoObj(i3).FileID = aoFiles(i).Id Then aoFirmyNab(i2).aoObj.RemoveAt(i3)
                    Next
                Next
                aoFiles.RemoveAt(i)
            End If
        Next
        aoFiles.Add(oFile)
    End Sub

    <XmlElement("fil")>
    Public aoFiles As New List(Of AFile)

    <XmlElement("p")>
    Public aoFirmyObj As New List(Of AFirma)

    <XmlElement("v")>
    Public aoFirmyNab As New List(Of AFirma)

    Public Function GetMaxFileID() As Integer
        Dim iRet As Integer = 0
        For Each oFile As AFile In aoFiles
            If oFile.Id > iRet Then iRet = oFile.Id
        Next
        Return iRet + 1
    End Function


    Public Function AddFirmaObj(JmenoFirmy As String, ICO As Decimal, Email As String, iFId As Integer, iTypRec As Integer, ByRef aoFirmy As List(Of AFirma)) As AFirma
        Dim oFrm As New AFirma(JmenoFirmy, ICO, Email, iFId)
        Dim iIdx As Integer = -1
        Dim o As AFirma = Nothing
        If iTypRec = TypObj.Prij Then
            aoFirmy = aoFirmyObj
        Else
            aoFirmy = aoFirmyNab
        End If
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
        Public Sub New(JmenoFirmy As String, dcICO As Decimal, sEmail As String, iFileId As Integer)
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
            'Typ = iTypRec
        End Sub
        <XmlAttribute("k")>
        Public KeyName As String = ""
        <XmlAttribute("i")>
        Public ICO As Decimal = 0
        <XmlAttribute("e")>
        Public Email As String = ""
        <XmlElement("d")>
        Public aoObj As New List(Of AObj)
        '<XmlAttribute("t"), DefaultValue(TypObj.Prij)>
        'Public Typ As Integer = TypObj.Prij
        <XmlIgnore>
        Public DisplayName As String = KeyName

        Public Sub SetDisplayName()
            Dim aoNames As New Dictionary(Of String, Integer)
            Dim iMax As Integer = 0
            For i As Integer = 0 To aoObj.Count - 1
                If Not aoNames.ContainsKey(aoObj(i).Name) Then
                    aoNames(aoObj(i).Name) = 1
                Else
                    aoNames(aoObj(i).Name) = aoNames(aoObj(i).Name) + 1
                End If
                If aoNames(aoObj(i).Name) > iMax Then iMax = aoNames(aoObj(i).Name)
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
                If iRet = 0 Then iRet = String.Compare(x.KeyName, y.KeyName, True)
                Return iRet
            End Function
        End Class
    End Class

    ''' <summary> polozka prijate/vydane objednavky </summary>
    Public Class AObj
        Public Sub New()
            MyBase.New
        End Sub

        Public Sub New(iRecID As Integer, iFileId As Integer, sName As String, lCislo As Long, dtDatum As Date)
            MyBase.New
            RecID = iRecID
            FileID = iFileId
            Name = sName
            Datum = dtDatum.ToString("ddMMyy")
            Cislo = lCislo
        End Sub
        <XmlAttribute("r")>
        Public RecID As Integer = 0
        <XmlAttribute("f")>
        Public FileID As Integer = 0
        <XmlAttribute("t")>
        Public Name As String = ""
        <XmlAttribute("c")>
        Public Cislo As Long = 0L
        <XmlAttribute("d")>
        Public Datum As String = ""
        <XmlElement("p")>
        Public aoObjPol As New List(Of AObjPol)
        Public ReadOnly Property dtDatum As Date
            Get
                If IsNumeric(Datum) AndAlso Datum.Length = 6 Then
                    Return New Date(CInt(Datum.Substring(4, 2) + 2000), CInt(Datum.Substring(2, 2)), CInt(Datum.Substring(0, 2)))
                End If
                Return New Date
            End Get
        End Property

        Public Class Sorter
            Implements IComparer(Of AObj)
            Public Function Compare(x As AObj, y As AObj) As Integer Implements IComparer(Of AObj).Compare
                Dim iRet As Integer = Date.Compare(x.dtDatum, y.dtDatum)
                If iRet = 0 Then iRet = CompareLong(x.Cislo, y.Cislo)
                If iRet = 0 Then iRet = String.Compare(x.Name, y.Name, True)
                Return -iRet
            End Function
        End Class

    End Class

    ''' <summary> Polozka prijate objednavky </summary>
    Public Class AObjPol
        Public Sub New()
            MyBase.New
        End Sub

        Public Sub New(iID As Integer, sText As String, sPozn As String, dcMnoz As Decimal)
            MyBase.New
            ID = iID
            Text = sText
            Pozn = sPozn
            Mnoz = dcMnoz
        End Sub
        <XmlAttribute("x")>
        Public ID As Integer = 0
        <XmlAttribute("t")>
        Public Text As String = ""
        <XmlAttribute("p")>
        Public Pozn As String = ""
        <XmlAttribute("m")>
        Public Mnoz As Decimal
    End Class


    Public Class APolozka
        Public Sub New(oFirma As AFirma, oObj As AObj, oObjP As AObjPol)
            MyBase.New
            Firma = oFirma
            Obj = oObj
            ObjP = oObjP
        End Sub
        Public Firma As AFirma = Nothing
        Public Obj As AObj = Nothing
        Public ObjP As AObjPol = Nothing
    End Class

End Class
