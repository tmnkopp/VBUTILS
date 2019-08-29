
Namespace Formatter
    Public Class RefactorAspxCode
        Implements IRefactorStrategy
        Public Function Refactor(content As String) As String Implements IRefactorStrategy.Refactor
            content = Replace(content, "2018", "2019")
            Return $"{content}{vbNewLine}"
        End Function
    End Class
End Namespace
