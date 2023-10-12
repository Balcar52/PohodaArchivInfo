Module modResourceFiles

    Private pTempDir As String = ""

    ' <summary> nacte z resources data, ulozi je do temp.file a vrati jeho JMENO </summary>
    ' <param name="sName"> jmeno souboru v resources (soubor musi mit property embedded resource!)</param>
    'Public Function GetResourceFileByTemporary(sName As String, Optional TryExeDir As Boolean = True) As String
    '    Try
    '        If TryExeDir Then
    '            Dim sExeLocation As String = IO.Path.Combine(IO.Path.GetDirectoryName(ExePath), sName)
    '            If IO.File.Exists(sExeLocation) Then Return sExeLocation ' vratim odkaz na umisteni v adresari aplikace
    '        End If
    '        Dim executing_assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly()
    '        For Each s As String In executing_assembly.GetManifestResourceNames
    '            If s.ToLower.EndsWith(sName.ToLower) Then
    '                Dim inp_stream As IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(s)
    '                Dim sOutFile As String = IO.Path.Combine(GetTempDir, sName)
    '                If IO.File.Exists(sOutFile) Then IO.File.Delete(sOutFile)
    '                If Not (inp_stream Is Nothing) Then
    '                    Dim out_stream As New IO.FileStream(sOutFile, IO.FileMode.Create)
    '                    inp_stream.CopyTo(out_stream)
    '                    out_stream.Close()
    '                    Return sOutFile
    '                End If
    '            End If
    '        Next
    '    Catch ex As System.Exception
    '        iLog.ErrLog(ex)
    '    End Try
    '    Return Nothing
    'End Function

    ''' <summary> nacte z resources data a vrati je jako jeden dlouhy string. promenne {TEL} a {TELVS} nahradi hodnotami z _gbl_tel </summary>
    ''' <param name="sName"> jmeno souboru v resources (soubor musi mit property embedded resource!)</param>
    ''' <param name="oEncoding"> kodovani. je-li nothing, pouzije se Text.Encoding.Default </param>
    Public Function GetResourceFileContent(sName As String, Optional oEncoding As Text.Encoding = Nothing) As String
        Dim sRet As String = Nothing
        If oEncoding Is Nothing Then oEncoding = Text.Encoding.Default
        Try
            Dim executing_assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly()
            For Each s As String In executing_assembly.GetManifestResourceNames
                If s.ToLower.EndsWith(sName.ToLower) Then
                    Dim inp_stream As IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(s)
                    Dim oRdr As New IO.StreamReader(inp_stream, oEncoding)
                    sRet = oRdr.ReadToEnd
                    oRdr.Close()
                End If
            Next
        Catch ex As System.Exception
            'iLog.ErrLog(ex)
        End Try
        Return sRet
    End Function

    'Public Function GetTempDir() As String
    '    pTempDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & IO.Path.GetFileNameWithoutExtension(ExePath)
    '    If Not IO.Directory.Exists(pTempDir) Then IO.Directory.CreateDirectory(pTempDir)
    '    'Debug.WriteLine("temporary directory: " & pTempDir)
    '    Return pTempDir
    'End Function

    'Public Function GetTempFileName(sFilename As String, Optional OriginalFileName As Boolean = False) As String
    '    pTempDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & IO.Path.GetFileNameWithoutExtension(ExePath)
    '    If Not IO.Directory.Exists(pTempDir) Then IO.Directory.CreateDirectory(pTempDir)
    '    If OriginalFileName Then
    '        pTempDir = IO.Path.Combine(pTempDir, sFilename)
    '    Else
    '        pTempDir = IO.Path.Combine(pTempDir, Now.Ticks.ToString & IO.Path.GetExtension(sFilename))
    '    End If
    '    'Debug.WriteLine("temporary file: " & pTempDir)
    '    Return pTempDir
    'End Function

    Public Function CopyResourceToFile(ResourceName As String, Filename As String, Optional bAsTextFile As Boolean = False, Optional bShowError As Boolean = True) As Boolean
        If IO.File.Exists(Filename) Then
            Try
                IO.File.SetAttributes(Filename, 0)
            Catch : End Try
            Try
                IO.File.Delete(Filename)
            Catch : End Try
        End If
        If bAsTextFile Then
            Dim oTr As IO.TextReader = GetResourceTextFileReader(ResourceName)
            If oTr IsNot Nothing Then
                Try
                    Dim oWr As New IO.BinaryWriter(IO.File.Open(Filename, IO.FileMode.Create))
                    oWr.Write(oTr.ReadToEnd)
                    oWr.Close()
                    oTr.Close()
                    Return True
                Catch : End Try
            End If
        Else
            Dim oBr As IO.BinaryReader = GetResourceBinaryFileReader(ResourceName)
            If oBr IsNot Nothing Then
                Try
                    Dim aoB As Byte() = oBr.ReadBytes(CInt(oBr.BaseStream.Length))
                    Dim oWr As New IO.BinaryWriter(IO.File.Open(Filename, IO.FileMode.Create))
                    oWr.Write(aoB, 0, aoB.Length)
                    oWr.Close()
                    Return True
                Catch : End Try
            End If
        End If
        Return False
    End Function

    Public Function GetResourceTextFileReader(FileName As String, Optional ByRef oEncoding As System.Text.Encoding = Nothing) As IO.StreamReader
        oEncoding = If(oEncoding, System.Text.Encoding.Default)
        For Each sFile As String In System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceNames()
            If sFile.ToLower.EndsWith("." & FileName.ToLower) Then
                Return New IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(sFile), oEncoding)
            End If
        Next
        Return Nothing
    End Function

    Public Function GetResourceBinaryFileReader(FileName As String) As IO.BinaryReader
        For Each sFile As String In System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceNames()
            If sFile.ToLower.EndsWith("." & FileName.ToLower) Then
                Return New IO.BinaryReader(System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(sFile))
            End If
        Next
        Return Nothing
    End Function

End Module
