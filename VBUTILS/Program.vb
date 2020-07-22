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
        ''Dim dbUtils As New DBUtils()
        ''Dim str As String = dbUtils.dbLookUp("select code from fsma_QuestionTypes WHERE PK_QuestionTypeId = 43 ")
        ''Dim view As New ConsoleViewer()
        ''view.Execute(str)
        Dim compiler As New CodeComplier()
        compiler.Src = $"c:\temp\template\component-test.txt"
        compiler.Dest = $"c:\temp\compiled\component-compiled.txt"
        compiler.Compile(New CompileComponent())
        compiler.Save(New NotepadViewer(compiler.Dest))

    End Sub
    Public Sub ChangeOMBsubStatus(ByVal sComp As String, ByVal sStat As String)

        Using oCmd As SqlCommand = New SqlCommand("UPDATE fsma_ReportingCycle_Components SET Status_Code = @Status_Code WHERE PK_ReportingCycle_Component = @PK_ReportingCycle_Component", oConn)
            oCmd.Parameters.AddWithValue("@Status_Code", IIf(sStat = "IRC", "SUBO", sStat))
            oCmd.Parameters.AddWithValue("@PK_ReportingCycle_Component", sComp)
            oCmd.ExecuteNonQuery()
        End Using
        Using oCmd As SqlCommand = New SqlCommand("UPDATE fsma_OrgSubmissions SET Status_Code = @Status_Code WHERE FK_ReportingCycle_Component =  @FK_ReportingCycle_Component", oConn)
            oCmd.Parameters.AddWithValue("@FK_ReportingCycle_Component", sComp)
            oCmd.Parameters.AddWithValue("@Status_Code", IIf(sStat = "IRC", "SUBO", sStat))
            oCmd.ExecuteNonQuery()
        End Using

        If sStat = "IRC" Then
            Using oCmd As SqlCommand = New SqlCommand("INSERT INTO fsma_WorkFlowHist SELECT TOP 1 PK_PrimeKey, WFtype, PK_UserID, EventDateTime, Status_Code FROM fsma_WorkFlowHist WHERE WFtype='AGENCY' AND Status_Code = 'SUBO' AND PK_PrimeKey = @PK_PrimeKey ORDER BY PK_WorkFlowHist DESC", oConn)
                oCmd.Parameters.AddWithValue("@PK_PrimeKey", sComp)
                oCmd.ExecuteNonQuery()
            End Using
        Else
            Using oCmd As SqlCommand = New SqlCommand("INSERT INTO fsma_WorkFlowHist (PK_PrimeKey, WFtype, PK_UserID, EventDateTime, Status_Code) VALUES (@PK_PrimeKey, @WFtype, @PK_UserID, GetDate(), @Status_Code )", oConn)
                oCmd.Parameters.AddWithValue("@PK_PrimeKey", sComp)
                oCmd.Parameters.AddWithValue("@WFtype", "AGENCY")
                oCmd.Parameters.AddWithValue("@Status_Code", sStat)
                oCmd.ExecuteNonQuery()
            End Using
        End If
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


