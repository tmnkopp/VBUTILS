Imports System.Text
Imports System.Text.RegularExpressions

Namespace Formatter

    Public Class CompileStrategy
        Implements ICompileStrategy
        Public Function Execute(content As String) As Object Implements ICompileStrategy.Execute
            Return Replace(content, "[compile-me]", "compiled!!!")
        End Function
    End Class
    Public Class SQLCompileStrategy
        Implements ICompileStrategy
        Public Function Execute(content As String) As Object Implements ICompileStrategy.Execute
            Return Replace(content, "[date]", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
        End Function
    End Class
    Public Class CompileCNT
        Implements ICompileStrategy
        Public Function Execute(content As String) As Object Implements ICompileStrategy.Execute
            Dim sb As StringBuilder = New StringBuilder()
            Dim _line As String
            For i As Integer = 0 To 45
                _line = Replace(content, "[cnt]", i)
                sb.Append($"{_line}{vbNewLine}")
            Next
            Return sb.ToString()
        End Function
    End Class

    Public Class CompileComponent
        Implements ICompileStrategy
        Public Function Execute(content As String) As Object Implements ICompileStrategy.Execute
            Dim sb As StringBuilder = New StringBuilder()
            Dim _content As String
            Dim _file As String
            Dim _matched As String
            Dim regex As Regex = New Regex($"\[.*\]", RegexOptions.Multiline)
            Dim match As Match = regex.Match(content)
            If match.Success Then
                _matched = match.Value
                _file = Replace(_matched, "[", "")
                _file = Replace(_file, "]", "")
                Using textReader As New System.IO.StreamReader($"{_file}")
                    _content = textReader.ReadToEnd()
                End Using
                content = Replace(content, _matched, _content)
            End If
            Return content

        End Function
    End Class

End Namespace
