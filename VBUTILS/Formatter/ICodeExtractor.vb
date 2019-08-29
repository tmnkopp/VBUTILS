Imports System.Text
Imports System.Text.RegularExpressions
Imports VBUTILS
Namespace Formatter

    Public Interface ICodeExtractor
        Function Extract(ContentToExtract As String) As String
    End Interface

    Public Class DBObjectExtractor
        Implements ICodeExtractor
        Private _objectName As String
        Public Sub New(ObjectName As String)
            _objectName = ObjectName
        End Sub
        Public Function Extract(ContentToExtract As String) As String Implements ICodeExtractor.Extract
            Dim SB As StringBuilder = New StringBuilder
            Dim element As String
            If ContentToExtract.Contains(_objectName) Then
                element = Replace(ContentToExtract.Trim, "runat=""server""", "")
                Return $"{element}{vbNewLine}"
            Else
                Return ""
            End If
        End Function
    End Class


    Public Class ControlExtractor
        Implements ICodeExtractor
        Private _controlName As String
        Public Sub New(ControlName As String)
            _controlName = ControlName
        End Sub
        Public Function Extract(ContentToExtract As String) As String Implements ICodeExtractor.Extract
            Dim SB As StringBuilder = New StringBuilder
            Dim element As String
            If ContentToExtract.Contains(_controlName) Then
                element = Replace(ContentToExtract.Trim, "runat=""server""", "")
                Return $"{element}{vbNewLine}"
            Else
                Return ""
            End If
        End Function
    End Class

    Public Class UserControlExtractor
        Implements ICodeExtractor
        Public Function Extract(ContentToExtract As String) As String Implements ICodeExtractor.Extract
            Dim SB As StringBuilder = New StringBuilder
            Dim element As String
            If ContentToExtract.Contains("<uc") Then
                element = Replace(ContentToExtract.Trim, "runat=""server""", "")
                Return $"{element}{vbNewLine}"
            Else
                Return ""
            End If
        End Function
    End Class

    Public Class QuestionPKExtractor
        Implements ICodeExtractor
        Public Function Extract(ContentToExtract As String) As String Implements ICodeExtractor.Extract
            Dim SB As StringBuilder = New StringBuilder
            Dim element As String
            If ContentToExtract.Contains("PK_Question") Then
                Dim matchCollection As MatchCollection = Regex.Matches(ContentToExtract, "PK_Question=""\d+""")
                Dim match As Match
                For Each match In matchCollection
                    element = Replace(match.ToString, "PK_Question=", "")
                    element = Replace(element, """", "")
                    SB.Append($"{element}")
                Next match
                Return $"{SB.ToString}{vbNewLine}"
            Else
                Return ""
            End If
        End Function
    End Class
    Public Class ASPExtractor
        Implements ICodeExtractor
        Public Function Extract(ContentToExtract As String) As String Implements ICodeExtractor.Extract
            Dim SB As StringBuilder = New StringBuilder
            Dim element As String
            If ContentToExtract.Contains("<asp") Then
                element = Replace(ContentToExtract.Trim, "runat=""server""", "")
                Return $"{element}{vbNewLine}"
            Else
                Return ""
            End If
        End Function
    End Class
    Public Class GenericExtractor
        Implements ICodeExtractor
        Public Function Extract(ContentToExtract As String) As String Implements ICodeExtractor.Extract
            Return $"{ContentToExtract}{vbNewLine}"
        End Function
    End Class

    Public Class SnippetExtractor
        Implements ICodeExtractor
        Private _snippet As String
        Public Sub New(Snippet As String)
            _snippet = Snippet
        End Sub
        Public Function Extract(ContentToExtract As String) As String Implements ICodeExtractor.Extract
            Dim SB As StringBuilder = New StringBuilder
            Dim element As String
            If ContentToExtract.Contains(_snippet) Then
                element = Replace(ContentToExtract.Trim, "runat=""server""", "")
                Return $"{element}{vbNewLine}"
            Else
                Return ""
            End If
        End Function
    End Class
End Namespace