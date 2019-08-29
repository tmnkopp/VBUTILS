Imports System.IO
Imports System.Text
Imports VBUTILS
Imports VBUTILS.Common

Namespace Parser
    Module Program
        Public Sub RunParser()
            Dim codeViewer As ICodeParser = New CodeParser()
            Dim profile As CodeParseProfile = New CodeParseProfile()
            profile.Path = $"{Constants.FolderFF2018}"
            profile.SearchOption = $"*SAOP*.aspx.vb"

            codeViewer.Load(profile)
            codeViewer.Extract(New GenericExtractor())
            codeViewer.View(New ConsoleViewer("output_parser2.txt"))
            Console.Read()
        End Sub
    End Module

End Namespace
