Imports VBUTILS

Public Interface IFileLoader
    Function Load(Path As String) As List(Of String)
End Interface

Public Class FileLoader
    Implements IFileLoader
    Public Function Load(Path As String) As List(Of String) Implements IFileLoader.Load
        Return New List(Of String)
    End Function
End Class
