Namespace Common
    Public Class Constants
        Public Shared ReadOnly HR As New String("-"c, 25)
        Public Shared ReadOnly FolderRoot As New String($"D:\dev\CyberScope\CyberScopeBranch\CSwebdev")
        Public Shared ReadOnly FolderCodeArchive As New String($"{Constants.FolderRoot}\code\")
        Public Shared ReadOnly FolderFF2018 As New String($"{Constants.FolderRoot}\code\CyberScope\FismaForms\2018\")
        Public Shared ReadOnly FolderDB As New String($"{Constants.FolderRoot}\database\")
        Public Shared ReadOnly FolderDBArchive As New String($"{Constants.FolderDB}\Archive\")
        Public Shared ReadOnly FolderDBSprocs As New String($"{Constants.FolderDB}\Sprocs\")
        Public Shared ReadOnly FolderDBViews As New String($"{Constants.FolderDB}\Views\")
    End Class
End Namespace
