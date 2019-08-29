Imports System.IO
Imports System.Text

Namespace Common
    Module Program
        Public Sub RunTest()

        End Sub

        Public Function RefactorStatements(statements As List(Of String)) As String
            Dim _return As StringBuilder = New StringBuilder
            Dim _stmt As String
            For Each statement In statements
                _stmt = Replace(statement, "~", "!!!!!")
                _return.Append($"{_stmt}{vbNewLine}")
            Next
            Return _return.ToString

        End Function
        Public Function EnumerateStatements() As List(Of String)
            Dim _file As String = $"c:\temp\input.txt"
            Dim _line As String = $""
            Dim _return As List(Of String) = New List(Of String)
            Using textReader As New System.IO.StreamReader($"{_file}")
                Do While textReader.Peek() <> -1
                    _line = textReader.ReadLine().TrimEnd
                    If Not String.IsNullOrEmpty(_line) Then
                        _return.Add($"{_line}")
                    End If
                Loop
            End Using
            Return _return
        End Function
        Public Sub Save(content As String)
            Dim FILE_NAME As String = $"C:\temp\output_1.txt"
            If System.IO.File.Exists(FILE_NAME) = False Then
                Dim fs As FileStream = File.Create(FILE_NAME)
                fs.Close()
            End If
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
            objWriter.Write(content)
            objWriter.Close()

            Dim p As New Process()
            p.StartInfo = New ProcessStartInfo("notepad.exe", FILE_NAME)
            p.Start()
        End Sub
    End Module
End Namespace
