Namespace Formatter
    Module Program
        Public Sub RunFormatter()
            Dim Refactor As New RefactorProcess
            Dim result As String
            Dim file As String = $"c:\"

            result = Refactor.Load(file, New RefactorAspxCode())
            Refactor.Save("output.txt", result)
        End Sub
    End Module
End Namespace
