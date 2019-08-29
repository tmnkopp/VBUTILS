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
End Namespace
