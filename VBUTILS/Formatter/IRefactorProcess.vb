Imports System.IO
Imports System.Text
Imports VBUTILS
Namespace Formatter
    Module Program
        Public Sub RunFormatter()
            Dim Refactor As New RefactorProcess
            Dim result As String
            Dim file As String = $"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\code\CyberScope\FismaForms\2018\2018_A_SAOP_7.aspx"

            result = Refactor.Load(file, New RefactorAspxCode())
            Refactor.Save(result)
        End Sub
    End Module

    Public Interface IRefactorStrategy
        Function Refactor(content As String) As String
    End Interface
    Public Interface IRefactorProcess
        Function Load(file As String, RefactorStrategy As IRefactorStrategy) As String
        Sub Save(file As String)
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

        Public Sub Save(content As String) Implements IRefactorProcess.Save
            Dim FILE_NAME As String = $"C:\temp\refactor_output_1.txt"
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
    End Class


End Namespace
