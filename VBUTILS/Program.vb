Imports System.Data.SqlClient
Imports System.Text
Imports System.Configuration
Imports System.Text.RegularExpressions

Module Program
    Public Sub Main()



        'Formatter.Program.RunFormatter()

        Parser.Program.RunParser()

        'Dim clArgs As String = Console.ReadLine()
        '
        'Dim yourArgs() As String = Regex.Split(clArgs, "- ")
        '
        'For Each arg As String In yourArgs
        '    If arg.Contains("-format ") Then
        '        Formatter.Program.RunFormatter()
        '    End If
        'Next
        '
        'Parser.Program.RunParser()
    End Sub
End Module


