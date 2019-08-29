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
            profile.SearchOption = $"*SAOP*.aspx"

            codeViewer.Load(profile)
            codeViewer.Extract(New ControlByAttributeExtractor("12496"))
            codeViewer.View(New NotepadViewer("output_parser_saop_controls.txt"))
            Console.Read()

        End Sub
    End Module

End Namespace
