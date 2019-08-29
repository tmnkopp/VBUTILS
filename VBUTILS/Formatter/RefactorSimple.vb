Namespace Formatter
    Public Class RefactorSimple
        Implements IRefactorStrategy
        Public Function Refactor(content As String) As String Implements IRefactorStrategy.Refactor

            Return $"{content}{vbNewLine}"
        End Function
    End Class
End Namespace