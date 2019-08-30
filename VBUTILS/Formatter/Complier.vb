Imports System.IO
Imports System.Text

Namespace Formatter
    Public Interface ICompiler
        Sub Compile(compileStrat As ICompileStrategy)
        Sub Save(viewer As Common.IViewer)
    End Interface
    Public Interface ICompileStrategy
        Function Execute(content As String)
    End Interface

    Public Class CodeComplier
        Implements ICompiler
        Dim _content As StringBuilder = New StringBuilder
        Private _src As String
        Public Property Src As String
            Get
                Return _src
            End Get
            Set(value As String)
                _src = value
            End Set
        End Property

        Private _dest As String
        Public Property Dest As String
            Get
                Return _dest
            End Get
            Set(value As String)
                _dest = value
            End Set
        End Property
        Public Sub New()
        End Sub
        Public Sub New(src As String, dest As String)
            _src = src
            _dest = dest
        End Sub

        Public Sub Compile(compileStrat As ICompileStrategy) Implements ICompiler.Compile
            Dim _line As String = $""
            Using textReader As New System.IO.StreamReader($"{Src}")
                Do While textReader.Peek() <> -1
                    _line = textReader.ReadLine().TrimEnd
                    If Not String.IsNullOrEmpty(_line) Then
                        _line = compileStrat.Execute(_line)
                        _content.Append($"{_line}{vbCrLf}")
                    End If
                Loop
            End Using
        End Sub
        Public Sub Save(viewer As Common.IViewer) Implements ICompiler.Save
            viewer.Execute(_content.ToString())
        End Sub
    End Class
End Namespace
