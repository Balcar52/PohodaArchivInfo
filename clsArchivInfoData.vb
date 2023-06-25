Imports System.Xml
Imports System.Xml.Serialization
Imports System.ComponentModel
Imports System.Reflection
Imports System.Data.OleDb
Imports System.IO

Public Class AData

    Public Shared CurrentFile As String = ""
    Public Shared CurrentPsw As String = txDefaultPassword

    Public Shared oAdata As AData = Nothing
    Public Shared sError As String = ""

    Friend Shared oRdr As OleDbDataReader = Nothing

    Friend Const constXMLRedundant1 As String = " xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"""
    Friend Const constXMLRedundant2 As String = " xmlns:xsd=""http://www.w3.org/2001/XMLSchema"""
    Friend Const constXMLNS1 As String = "xsi:"
    Friend Const constXMLNS2 As String = "xsd:"

    Friend Const txSQL1 As String = "SELECT firma,ICO,ID,Cislo,Datum,Email from OBJ where reltpobj=1 order by firma, datum desc"
    Friend Const txSQL2 As String = "SELECT RefAg,SText,Pozn,Mnozstvi from OBJpol where RefAg in (SELECT ID from OBJ where reltpobj=1)"
    Friend Const txConnStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password = {1}"
    Friend Const txDefaultPassword As String = "168BF465F0FB19"

    Public Shared Function LoadXMLData() As Boolean
        sError = ""
        Try
            If IO.File.Exists(AData.CurrentFile) Then
                oAdata = AData.FromXML(IO.File.ReadAllText(CurrentFile), True)
                Return True
            End If
        Catch ex As Exception
            sError = ex.Message
        End Try
        oAdata = New AData
        Return False
    End Function

    Public Shared Function LoadXMLDataInfo(sFileName As String) As AData
        sError = ""
        Dim oRet As New AData
        Try
            If IO.File.Exists(sFileName) Then
                oRet = AData.FromXML(IO.File.ReadAllText(sFileName), False)
            End If
        Catch ex As Exception
            sError = ex.Message
        End Try
        Return oRet
    End Function

    Public Shared Function LoadMdbData(sMdbFileName As String, sPassword As String, ByRef sXMLFileName As String) As AData

        sError = ""
        Dim oData As New AData
        If Not IO.File.Exists(sMdbFileName) Then Throw New Exception(String.Format("Databázový soubor {0} nebyl nalezen", sMdbFileName))
        If IO.File.Exists(sXMLFileName) Then
            oData = AData.FromXML(IO.File.ReadAllText(sXMLFileName))
        End If
        Dim iNewID As Integer = oData.GetMaxFileID
        oData.AddMdbFile(sMdbFileName, sPassword, iNewID)

        oConn.ConnectionString = String.Format(txConnStr, sMdbFileName, sPassword)
        Dim oCmd As OleDbCommand = Nothing

        Try
            Dim maoObjList As New Dictionary(Of Integer, AObj)

            oConn.Open()
            oCmd = oConn.CreateCommand()
            oCmd.CommandText = txSQL1
            Debug.WriteLine(oCmd.CommandText)
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                Try
                    Dim sName As String = GetStr(0)
                    Dim oFrm As AFirma = oData.AddFirmaObj(sName, GetDec(1), GetStr(5), iNewID)
                    Dim iRecId As Integer = GetInt(2)
                    Dim iIdx As Integer = -1
                    For i As Integer = 0 To oData.aoFirmy.Count - 1
                        If oData.aoFirmy(i).KeyName = oFrm.KeyName Then
                            iIdx = i
                            Exit For
                        End If
                    Next
                    If iIdx < 0 Then
                        oData.aoFirmy.Add(oFrm)
                        iIdx = oData.aoFirmy.Count - 1
                    End If
                    Dim oObj As New AObj(iRecId, iNewID, sName, GetLong(3), GetDate(4))
                    oData.aoFirmy(iIdx).aoObj.Add(oObj)
                    maoObjList(iRecId) = oObj
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
            End While
            oRdr.Close()

            oCmd.CommandText = txSQL2
            Debug.WriteLine(oCmd.CommandText)
            oRdr = Nothing
            oRdr = oCmd.ExecuteReader
            While oRdr.Read
                Dim oObjP = New AObjPol(GetInt(0), GetStr(1), GetStr(2), GetDec(3))
                If maoObjList.ContainsKey(oObjP.ID) Then
                    Dim oObj As AObj = maoObjList(oObjP.ID)
                    oObj.aoObjPol.Add(oObjP)
                End If
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
                For i As Integer = 0 To oRes.aoFirmy.Count - 1
                    oRes.aoFirmy(i).SetDisplayName()
                Next
            End If
            If SortData Then
                oRes.aoFirmy.Sort(New AFirma.Sorter)
                For i As Integer = 0 To oRes.aoFirmy.Count - 1
                    oRes.aoFirmy(i).aoObj.Sort(New AObj.Sorter)
                Next
            End If
            Return oRes
        Catch ex As System.Exception
            Throw New System.Exception("Chyba při deserializaci vypoctu vodneho")
        End Try
        Return Nothing
    End Function

End Class
