﻿Imports System.IO
Imports System.Text

Module FileSysIO

    Public Sub Main()
        Dim codeViewer As ICodeParser = New CodeParser()
        Dim profile As CodeParseProfile = New CodeParseProfile()
        profile.Path = $"{Constants.FolderDBArchive}"
        profile.SearchOption = $"*db_update*.sql"

        codeViewer.Load(profile)
        codeViewer.Extract(New SnippetExtractor("fsma_FormMaster"))
        codeViewer.View(New ConsoleViewer("output_db_update_fsma_formmaster.txt"))
        Console.Read()

    End Sub
End Module
