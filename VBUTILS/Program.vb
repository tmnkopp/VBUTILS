Imports System.Data.SqlClient
Imports System.Text
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports VBUTILS.Formatter
Imports VBUTILS.Common
Imports VBUTILS.Data

Module Program
    Public Sub Main()
        Dim dbUtils As New DBUtils()
        Dim str As String = dbUtils.dbLookUp("select code from fsma_QuestionTypes WHERE PK_QuestionTypeId = 43 ")
        Dim view As New ConsoleViewer()
        view.Execute(str)


        ''Dim compiler As New CodeComplier()
        ''compiler.Src = $"c:\temp\template\input.txt"
        ''compiler.Dest = $"c:\temp\compiled\output.txt"
        ''compiler.Compile(New CompileStrategy())
        ''compiler.Save(New NotepadViewer(compiler.Dest))

    End Sub
End Module



Interface IInvoker
    Sub Invoke()
    Function ParseArgs(arg As String) As Hashtable
End Interface
Public Class Invoker
    Public Sub New()
    End Sub
    Public Sub Sub1()
        Console.Write("Sub1")
    End Sub
End Class

''''COMMAND: >type -arg1 the first argument -arg2 second -dir c:\asdf\asdf\asdf.txt
''''COMMAND: >format -in c:\asdf\asdf\asdf.txt -out c:\temp\output.txt -fmt ''
''''COMMAND: >type -arg1 the first argument -arg2 second -dir c:\asdf\asdf\asdf.txt
''''Get Type
''''Invoke Init Method w/ arguments
'''' -- Init Args:KeyValue (-dir: -file: -format: )
'''' -- KeyValue Arg Parser: ()


'Dim _assembly As Assembly = Assembly.Load("VBUTILS")
'Dim _type As Type = _assembly.GetType("VBUTILS.Invoker")
'Dim _constructor As ConstructorInfo = _type.GetConstructor(Type.EmptyTypes)
'Dim _object As Object = _constructor.Invoke(Nothing)
'Dim _mainMethod = _type.GetMethod("Sub1", BindingFlags.Public Or BindingFlags.Instance)
'Dim result As String = DirectCast(_mainMethod.Invoke(_object, Nothing), String)

'Formatter.Program.RunFormatter()

'Parser.Program.RunParser()

'Dim cArgs As String = Console.ReadLine()
'
'Dim args() As String = Regex.Split(cArgs, "- ")
'
'For Each arg As String In args
'    If arg.Contains("-format") Then
'        Formatter.Program.RunFormatter()
'    End If
'Next
'
'Parser.Program.RunParser()


