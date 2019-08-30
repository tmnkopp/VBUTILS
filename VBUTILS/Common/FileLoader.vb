Imports System.IO
Imports VBUTILS

Interface IFileLoader
    Function Load(dir As String) As String
End Interface
Public Class FileLoader
    Implements IFileLoader
    Public Sub New()

    End Sub

    Public Function Load(dir As String) As String Implements IFileLoader.Load

        Return dir

    End Function
End Class
