Imports System.IO
Imports System.Text
Imports VBUTILS
Namespace Formatter

    Public Interface IRefactorStrategy
        Function Refactor(content As String) As String
    End Interface
    Public Interface IRefactorProcess
        Function Load(file As String, RefactorStrategy As IRefactorStrategy) As String
        Sub Save(filename As String, contents As String)
    End Interface

    Public Class RefactorProcess
        Implements IRefactorProcess
        Public Function Load(file As String, RefactorStrategy As IRefactorStrategy) As String Implements IRefactorProcess.Load
            Dim _line As String = $""
            Dim _return As StringBuilder = New StringBuilder
            Using textReader As New System.IO.StreamReader($"{file}")
                Do While textReader.Peek() <> -1
                    _line = textReader.ReadLine().TrimEnd
                    If Not String.IsNullOrEmpty(_line) Then
                        _line = RefactorStrategy.Refactor(_line)
                        _return.Append($"{_line}")
                    End If
                Loop
            End Using
            Return _return.ToString()
        End Function

        Public Sub Save(filename As String, content As String) Implements IRefactorProcess.Save
            If String.IsNullOrEmpty(filename) Then
                filename = $"C:\temp\{filename}"
            End If
            If System.IO.File.Exists(filename) = False Then
                Dim fs As FileStream = File.Create(filename)
                fs.Close()
            End If
            Dim objWriter As New System.IO.StreamWriter(filename)
            objWriter.Write(content)
            objWriter.Close()

            Dim p As New Process()
            p.StartInfo = New ProcessStartInfo("notepad.exe", filename)
            p.Start()
        End Sub
    End Class



End Namespace
