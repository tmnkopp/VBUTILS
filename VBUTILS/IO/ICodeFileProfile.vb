Imports VBUTILS

Public Interface ICodeParseProfile
    Property ID As String
    Property Path As String
    Property SearchOption As String
End Interface

Public Class CodeParseProfile
    Implements ICodeParseProfile

    Private _id As String
    Private _path As String
    Private _searchOption As String
    Private _snippet As String
    Public Sub New()
    End Sub
    Public Sub New(SearchOption As String)
        Me.SearchOption = SearchOption
    End Sub
    Public Property ID As String Implements ICodeParseProfile.ID
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property

    Public Property Path As String Implements ICodeParseProfile.Path
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
        End Set
    End Property
    Public Property SearchOption As String Implements ICodeParseProfile.SearchOption
        Get
            Return _searchOption
        End Get
        Set(value As String)
            _searchOption = value
        End Set
    End Property
    Public Property Snippet As String
        Get
            Return _snippet
        End Get
        Set(value As String)
            _snippet = value
        End Set
    End Property
End Class
