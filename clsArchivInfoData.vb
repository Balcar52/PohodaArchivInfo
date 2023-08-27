Imports System.Xml
Imports System.Xml.Serialization
Imports System.ComponentModel
Imports System.Reflection
Imports System.Data.OleDb
Imports System.IO

Public Class AData

    Public Const ValidFileVersion As String = "4.8.2023"

    Public Shared CurrentFile As String = ""
    Public Shared CurrentPsw As String = txDefaultPassword

    Public Shared oAdata As AData = Nothing
    Public Shared sError As String = ""

    Friend Shared oRdr As OleDbDataReader = Nothing

    Friend Const constXMLRedundant1 As String = " xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"""
    Friend Const constXMLRedundant2 As String = " xmlns:xsd=""http://www.w3.org/2001/XMLSchema"""
    Friend Const constXMLNS1 As String = "xsi:"
    Friend Const constXMLNS2 As String = "xsd:"

    Friend Const txSQL1 As String = "SELECT firma,ICO,ID,Cislo,Datum,Email,SText,RelTpObj,RefZeme,KcCelkem,RefCM,CMKurs from OBJ order by firma, datum desc"
    Friend Const txSQL2 As String = "SELECT RefAg,SText,Pozn,Mnozstvi,KcJedn from OBJpol where RefAg in (SELECT ID from OBJ)"
    Friend Const txSQL3 As String = "SELECT firma,ICO,ID,Cislo,Datum,Email,SText,RelTpFak,RefZeme,KcCelkem,RefCM,CMKurs from FA where RelTpFak in (1,11) order by firma, datum desc"
    Friend Const txSQL4 As String = "SELECT RefAg,SText,Pozn,Mnozstvi,KcJedn from FApol where RefAg in (SELECT ID from FA where RelTpFak in (1,11))"
    Friend Const txSQL5 As String = "SELECT firma,ICO,ID,Cislo,Datum,Email,SText,RelTpNab from NAB order by firma, datum desc"
    Friend Const txSQL6 As String = "SELECT RefAg,SText,Pozn,Mnozstvi,KcJedn from NABpol where RefAg in (SELECT ID from NAB)"
    Friend Const txSQL11 As String = "SELECT Kod,ID from sZeme"
    Friend Const txSQL12 As String = "SELECT ID,Kod from sCMeny"

    Friend Const ObjPrij As Integer = 1
    Friend Const Nabidky As Integer = 2
    Friend Const txConnStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password = {1}"
    Friend Const txDefaultPassword As String = "168BF465F0FB19"

    Public Const txLoadNotFound As String = "Soubor archivu ""{0}"" nebyl nalezen, nebo není dostupný"
    Public Const txLoadBadFormat As String = "Soubor archivu ""{0}"" má vadný formát, nebo je poškozen"
    Public Const txLoadBadVersion As String = "Verze souboru archivu ""{0}"" ({1}) není kompatibilní s požadovanou aktuální verzí této aplikace ({2})"

    Public Shared Function LoadXMLData(RequiredFileversion As String) As Boolean
        sError = ""
        oAdata = Nothing
        Try
            If Not IO.File.Exists(AData.CurrentFile) Then
                Throw New Exception(String.Format(txLoadNotFound, AData.CurrentFile))
            Else
                oAdata = AData.FromXML(IO.File.ReadAllText(CurrentFile), True)
                If oAdata Is Nothing Then
                    Throw New Exception(String.Format(txLoadBadFormat, AData.CurrentFile))
                ElseIf oAdata.FileVersion <> RequiredFileversion Then
                    Throw New Exception(String.Format(txLoadBadVersion, AData.CurrentFile, oAdata.FileVersion, RequiredFileversion))
                End If
                Return True
            End If
        Catch ex As Exception
            sError = ex.Message
        End Try
        Return False
    End Function

    Public Shared Function LoadXMLDataInfo(sXMLFileName As String) As AData
        sError = ""
        Dim oData As New AData
        Try
            If IO.File.Exists(sXMLFileName) Then
                oData = AData.FromXML(IO.File.ReadAllText(sXMLFileName), False)
                If oData.IsNotEmpty AndAlso oData.FileVersion <> AData.ValidFileVersion Then
                    sError = String.Format(txLoadBadVersion, sXMLFileName, oData.GetFileVersion, ValidFileVersion)
                    oData = Nothing
                    Return oData
                End If
            End If
        Catch ex As Exception
            sError = ex.Message
        End Try
        Return oData
    End Function

    Public Shared Function LoadMdbData(sMdbFileName As String, sPassword As String, ByRef sXMLFileName As String, ByRef iRemoved As Integer, ByRef iAdded As Integer) As AData

        sError = ""
        iRemoved = 0
        iAdded = 0
        Dim oData As New AData
        If Not IO.File.Exists(sMdbFileName) Then Throw New Exception(String.Format("Databázový soubor {0} nebyl nalezen", sMdbFileName))
        If IO.File.Exists(sXMLFileName) Then
            oData = AData.FromXML(IO.File.ReadAllText(sXMLFileName))
            If oData IsNot Nothing AndAlso oData.aoFiles.Count > 0 AndAlso oData.FileVersion <> AData.ValidFileVersion Then
                oData = Nothing
                sError = String.Format(txLoadBadVersion, sXMLFileName, oData.GetFileVersion, ValidFileVersion)
                Return oData
            End If
        End If
        Dim iNewID As Integer = 1
        If oData Is Nothing Then
            oData = New AData
        Else
            iNewID = oData.GetMaxFileID
        End If
        oData.AddMdbFile(sMdbFileName, sPassword, iNewID, iRemoved)

        oConn.ConnectionString = String.Format(txConnStr, sMdbFileName, sPassword)
        Dim oCmd As OleDbCommand = Nothing

        Try
            Dim aoDocs As New Dictionary(Of Integer, AObjNab)
            Dim aoDocsF As New Dictionary(Of Integer, AFakt)
            Dim aoZeme As New Dictionary(Of Integer, String)
            Dim aoMeny As New Dictionary(Of Integer, String)
            oConn.Open()
            oCmd = oConn.CreateCommand()

            'ciselnik zemi 
            oCmd.CommandText = txSQL11
            Debug.WriteLine(oCmd.CommandText)
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                Dim ID As Integer = GetInt(1)
                Dim s As String = GetStr(0)
                If ID > 0 AndAlso s <> "CZ" Then aoZeme(ID) = s
                'Debug.WriteLine(ID & vbTab & GetStr(0)) Then
            End While
            oRdr.Close()

            'ciselnik men
            oCmd.CommandText = txSQL12
            Debug.WriteLine(oCmd.CommandText)
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                aoMeny(GetInt(0)) = GetStr(1)
                'Debug.WriteLine(GetInt(0) & vbTab & GetStr(1))
            End While
            oRdr.Close()

            ' hlavicky objednavek/nabidek
            oCmd.CommandText = txSQL1
            Debug.WriteLine(oCmd.CommandText)
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                Try
                    Dim sName As String = GetStr(0)
                    Dim aoFirmy As List(Of AFirma) = If(GetInt(7) = TypObj.Prij, oData.aoFirmyObjPrij, oData.aoFirmyObjVyd)
                    Dim sZeme As String = ""
                    If aoZeme.ContainsKey(GetInt(8)) Then sZeme = aoZeme(GetInt(8))
                    Dim oFirma As AFirma = oData.AddFirmaObjNab(sName, GetDec(1), GetStr(5), sZeme, iNewID, aoFirmy)
                    Dim iRecId As Integer = GetInt(2)
                    Dim iIdx As Integer = -1
                    For i As Integer = 0 To aoFirmy.Count - 1
                        If aoFirmy(i).KeyName = oFirma.KeyName Then
                            iIdx = i
                            Exit For
                        End If
                    Next
                    If iIdx < 0 Then
                        aoFirmy.Add(oFirma)
                        iIdx = aoFirmy.Count - 1
                    End If
                    Dim sMen As String = ConvertMena(If(aoMeny.ContainsKey(GetInt(10)), aoMeny(GetInt(10)), ""))
                    Dim oObj As New AObjNab(iRecId, iNewID, sName, GetLong(3), GetDate(4), GetStr(6), GetDec(9), sMen, GetDec(11))
                    If oObj.Kurs > 0 Then
                        Debug.WriteLine(oObj.Kurs & " " & sMen)
                    End If
                    aoFirmy(iIdx).aoDoc.Add(oObj)
                    aoDocs(oObj.RecID) = oObj
                    'aoFirmy(iRecId) = oObj
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Debug.WriteLine(ex.Message)
                    Exit While
                End Try
            End While
            oRdr.Close()
            ' polozky prijatych/vydanych objednavek
            oCmd.CommandText = txSQL2
            Debug.WriteLine(oCmd.CommandText)
            oRdr = Nothing
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                Dim oObjP = New AObjNabPol(GetInt(0), GetStr(1), GetStr(2), GetDec(3), GetDec(4))
                If aoDocs.ContainsKey(oObjP.ID) Then
                    aoDocs(oObjP.ID).aoObjPol.Add(oObjP)
                    iAdded += 1
                End If
            End While
            oRdr.Close()
            aoDocs.Clear()

            ' hlavicky faktur
            oCmd.CommandText = txSQL3
            Debug.WriteLine(oCmd.CommandText)
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                Try
                    Dim sName As String = GetStr(0)
                    Dim aoFirmy As List(Of AFirma) = If(GetInt(7) = TypObj.FakV, oData.aoFirmyFVyd, oData.aoFirmyFPrij)
                    Dim sZeme As String = ""
                    If aoZeme.ContainsKey(GetInt(8)) Then sZeme = aoZeme(GetInt(8))
                    Dim oFirma As AFirma = oData.AddFirmaObjNab(sName, GetDec(1), GetStr(5), sZeme, iNewID, aoFirmy)
                    Dim iRecId As Integer = GetInt(2)
                    Dim iIdx As Integer = -1
                    For i As Integer = 0 To aoFirmy.Count - 1
                        If aoFirmy(i).KeyName = oFirma.KeyName Then
                            iIdx = i
                            Exit For
                        End If
                    Next
                    If iIdx < 0 Then
                        aoFirmy.Add(oFirma)
                        iIdx = aoFirmy.Count - 1
                    End If
                    Dim sMen As String = ConvertMena(If(aoMeny.ContainsKey(GetInt(10)), aoMeny(GetInt(10)), ""))
                    Dim oFak As New AFakt(iRecId, iNewID, sName, GetLong(3), GetDate(4), GetStr(6), GetDec(9), sMen, GetDec(11))
                    aoFirmy(iIdx).aoDocF.Add(oFak)
                    aoDocsF(oFak.RecID) = oFak
                    'aoFirmy(iRecId) = oObj
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Debug.WriteLine(ex.Message)
                    Exit While
                End Try
            End While
            oRdr.Close()
            ' polozky faktur
            oCmd.CommandText = txSQL4
            Debug.WriteLine(oCmd.CommandText)
            oRdr = Nothing
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                Dim oObjP = New AFaktPol(GetInt(0), GetStr(1), GetStr(2), GetDec(3), GetDec(4))
                If aoDocsF.ContainsKey(oObjP.ID) Then
                    aoDocsF(oObjP.ID).aoFaktPol.Add(oObjP)
                    iAdded += 1
                End If
                'If maoObjList.ContainsKey(oObjP.ID) Then
                '    Dim oObj As AObj = maoObjList(oObjP.ID)
                '    oObj.aoObjPol.Add(oObjP)
                'End If
            End While
            oRdr.Close()

            Return oData
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If oConn.State = ConnectionState.Open Then oConn.Close()
        End Try
        Return Nothing
    End Function

    Private Shared Function GetVal(i As Integer) As Object
        Return If(oRdr.IsDBNull(i), Nothing, oRdr.GetValue(i))
    End Function

    Private Shared Function GetStr(i As Integer, Optional DefaultValue As String = "") As String
        Return If(oRdr.IsDBNull(i), DefaultValue, CStr(oRdr.GetValue(i)))
    End Function

    Private Shared Function GetInt(i As Integer, Optional DefaultValue As Integer = 0) As Integer
        Dim oVal As Object = If(oRdr.IsDBNull(i), "", oRdr.GetValue(i))
        If IsNumeric(oVal) Then Return CInt(oVal)
        Return DefaultValue
    End Function

    Private Shared Function GetLong(i As Integer, Optional DefaultValue As Long = 0) As Long
        Dim oVal As Object = If(oRdr.IsDBNull(i), "", oRdr.GetValue(i))
        If IsNumeric(oVal) Then Return CLng(oVal)
        Return DefaultValue
    End Function

    Private Shared Function GetDec(i As Integer, Optional DefaultValue As Decimal = 0) As Decimal
        Dim oVal As Object = If(oRdr.IsDBNull(i), "", oRdr.GetValue(i))
        If IsNumeric(oVal) Then Return CDec(oVal)
        Return DefaultValue
    End Function

    Private Shared Function GetDate(i As Integer, Optional DefaultValue As Date = Nothing) As Date
        Dim oVal As Object = If(oRdr.IsDBNull(i), "", oRdr.GetValue(i))
        If IsDate(oVal) Then Return CDate(oVal)
        Return DefaultValue
    End Function

    Public Function ToXml(Optional RemoveCrLf As Boolean = False) As String
        ' serializujeme objekt do stringu
        Try
            Dim oSerializer As New XmlSerializer(Me.GetType)
            Dim oStringWriter As New IO.StringWriter()
            Dim oSettings As New XmlWriterSettings()
            oSettings.Indent = True
            oSettings.OmitXmlDeclaration = True
            oSettings.Encoding = System.Text.Encoding.Default
            oSerializer.Serialize(XmlWriter.Create(oStringWriter, oSettings), Me)
            Dim s As String = oStringWriter.ToString
            ' odstranime definici namespace, pokud neni treba (pokud nejsou v XML pouzity) -
            ' delame to vsak jen u kratkych XML retezcu (u dlouhych by detekce trvala dlouho, 
            '  a navic ziskane zkraceni XML u dlouhych retezcu je nepodstatne)
            If (s IsNot Nothing) AndAlso (s.Length < 50000) Then s = s.Replace(constXMLRedundant1, "").Replace(constXMLRedundant2, "")
            If RemoveCrLf Then s = Replace(Replace(s, vbCr, ""), vbLf, "")
            Return s
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
        Return ""
    End Function

    ''' <summary> deserializace objektu do XML </summary>
    ''' <param name="XMLText"> retezec XML </param>
    ''' <returns> deserializovany objekt </returns>
    Public Shared Function FromXML(XMLText As String, Optional SetDisplayNames As Boolean = False, Optional SortData As Boolean = True) As AData
        Try
            If String.IsNullOrEmpty(XMLText) OrElse XMLText = "<NULL>" Then Return New AData
            Dim oSer As XmlSerializer = New XmlSerializer(GetType(AData))
            Dim oStringReader As New StringReader(XMLText)
            Dim oReader As New XmlTextReader(oStringReader)
            Dim oRes As AData = DirectCast(oSer.Deserialize(oReader), AData)
            If SetDisplayNames Then
                For i As Integer = 0 To oRes.aoFirmyObjPrij.Count - 1
                    oRes.aoFirmyObjPrij(i).SetDisplayName()
                Next
                For i As Integer = 0 To oRes.aoFirmyObjVyd.Count - 1
                    oRes.aoFirmyObjVyd(i).SetDisplayName()
                Next
                For i As Integer = 0 To oRes.aoFirmyNab.Count - 1
                    oRes.aoFirmyNab(i).SetDisplayName()
                Next
                For i As Integer = 0 To oRes.aoFirmyFVyd.Count - 1
                    oRes.aoFirmyFVyd(i).SetDisplayNameF()
                Next
                For i As Integer = 0 To oRes.aoFirmyFPrij.Count - 1
                    oRes.aoFirmyFPrij(i).SetDisplayNameF()
                Next
            End If
            If SortData Then
                oRes.aoFirmyObjPrij.Sort(New AFirma.Sorter)
                For i As Integer = 0 To oRes.aoFirmyObjPrij.Count - 1
                    oRes.aoFirmyObjPrij(i).aoDoc.Sort(New AObjNab.Sorter)
                Next
                oRes.aoFirmyNab.Sort(New AFirma.Sorter)
                For i As Integer = 0 To oRes.aoFirmyNab.Count - 1
                    oRes.aoFirmyNab(i).aoDoc.Sort(New AObjNab.Sorter)
                Next
                oRes.aoFirmyFVyd.Sort(New AFirma.Sorter)
                For i As Integer = 0 To oRes.aoFirmyFVyd.Count - 1
                    oRes.aoFirmyFVyd(i).aoDocF.Sort(New AFakt.Sorter)
                Next
                oRes.aoFirmyFPrij.Sort(New AFirma.Sorter)
                For i As Integer = 0 To oRes.aoFirmyFPrij.Count - 1
                    oRes.aoFirmyFPrij(i).aoDocF.Sort(New AFakt.Sorter)
                Next
            End If
            Return oRes
        Catch ex As System.Exception
        End Try
        Return Nothing
    End Function

End Class
