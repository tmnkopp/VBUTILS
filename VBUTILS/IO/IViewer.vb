Imports System.IO
Imports VBUTILS

Public Interface IViewer
    Sub Execute(ContentToView As String)
End Interface

Public Class ConsoleViewer
    Implements IViewer
    Private _outputname As String

    Public Sub New()
        _outputname = "output.txt"
    End Sub
    Public Sub New(OutputName As String)
        _outputname = OutputName
    End Sub
    Public Sub Execute(ContentToView As String) Implements IViewer.Execute
        Console.Write($"{_outputname}:{vbNewLine}{ContentToView}")
        Console.SetCursorPosition(0, 0)
    End Sub
End Class

Public Class NotepadViewer
    Implements IViewer
    Private _filename As String

    Public Sub New()
        _filename = "output.txt"
    End Sub
    Public Sub New(Filename As String)
        _filename = Filename
    End Sub

    Public Sub Execute(ContentToView As String) Implements IViewer.Execute
        Dim FILE_NAME As String = $"C:\temp\{_filename}"
        If System.IO.File.Exists(FILE_NAME) = False Then
            Dim fs As FileStream = File.Create(FILE_NAME)
            fs.Close()
        End If
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        objWriter.Write(ContentToView)
        objWriter.Close()

        Dim p As New Process()
        p.StartInfo = New ProcessStartInfo("notepad.exe", FILE_NAME)
        p.Start()

    End Sub
End Class
