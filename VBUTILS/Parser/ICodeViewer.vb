Imports System.IO
Imports System.Text
Imports VBUTILS
Namespace Parser


    Public Interface ICodeParser
        Sub Load(profile As ICodeParseProfile)
        Sub Extract(extractor As ICodeExtractor)
        Sub View(viewer As IViewer)
    End Interface

    Public Class CodeParser
        Implements ICodeParser
        Private _path As String
        Private _searchOption As String
        Private _profile As ICodeParseProfile
        Private HashOfFiles As Hashtable = New Hashtable()
        Private sbContents As StringBuilder = New StringBuilder()

        Public Property Path As String
            Get
                Return _path
            End Get
            Set(value As String)
                _path = value
            End Set
        End Property
        Public Property SearchOption As String
            Get
                Return _searchOption
            End Get
            Set(value As String)
                _searchOption = value
            End Set
        End Property
        Public Sub New()
        End Sub
        Public Sub New(profile As ICodeParseProfile)
            Me._path = profile.Path
            Me._searchOption = profile.SearchOption
        End Sub

        Public Sub Load(profile As ICodeParseProfile) Implements ICodeParser.Load
            Me._path = profile.Path
            Me._searchOption = profile.SearchOption
        End Sub

        Public Sub Extract(extractor As ICodeExtractor) Implements ICodeParser.Extract
            Dim dir As New DirectoryInfo($"{Me._path}")
            Dim files As FileInfo()
            If String.IsNullOrEmpty(_searchOption) Then
                files = dir.GetFiles()
            Else
                files = dir.GetFiles(_searchOption)
            End If
            Dim line As String
            For Each file As FileInfo In files
                Using textReader As New System.IO.StreamReader($"{_path}{file}")
                    Do While textReader.Peek() <> -1
                        line = extractor.Extract(textReader.ReadLine().TrimEnd)
                        If Not String.IsNullOrEmpty(line) Then
                            sbContents.Append($"{line}")
                        End If
                    Loop
                    HashOfFiles.Add(file, sbContents.ToString())
                    sbContents.Clear()
                End Using
            Next
            'Return HashOfFiles
        End Sub

        Public Sub View(viewer As IViewer) Implements ICodeParser.View
            sbContents.Clear()

            For Each k In HashOfFiles.Keys
                If Not String.IsNullOrEmpty(HashOfFiles(k)) Then
                    sbContents.Append($"{k}{vbNewLine}{Constants.HR} 
                    {vbNewLine}{HashOfFiles(k)}{vbNewLine}")
                End If
            Next

            viewer.Execute(sbContents.ToString)
        End Sub
    End Class
End Namespace