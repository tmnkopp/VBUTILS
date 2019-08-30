Imports System.Data.SqlClient
Imports System.Text
Imports System.Configuration

Namespace Data
    Public Class DBUtils
        Public Function dbLookUp(sSql As String) As String
            Dim sConn As String = ConfigurationManager.ConnectionStrings("Cyberscope123").ToString()
            Dim oConn As SqlConnection = New SqlConnection(sConn)
            Dim sRetSB As New StringBuilder
            oConn.Open()
            Using oCmd As SqlCommand = New SqlCommand(sSql, oConn)
                Using oRead As SqlDataReader = oCmd.ExecuteReader()
                    While oRead.Read
                        sRetSB.Append(oRead.GetValue(0).ToString)
                    End While
                End Using
            End Using
            oConn.Close()
            oConn.Dispose()
            Return sRetSB.ToString()
        End Function
        Public Function dbLookUpList(sSql As String) As List(Of String)
            Dim sConn As String = ConfigurationManager.ConnectionStrings("Cyberscope123").ToString()
            Dim oConn As SqlConnection = New SqlConnection(sConn)
            Dim sRetList As New List(Of String)
            oConn.Open()
            Using oCmd As SqlCommand = New SqlCommand(sSql, oConn)
                Using oRead As SqlDataReader = oCmd.ExecuteReader()
                    While oRead.Read
                        sRetList.Add(oRead.GetValue(0).ToString)
                    End While
                End Using
            End Using
            oConn.Close()
            oConn.Dispose()
            Return sRetList
        End Function
    End Class
End Namespace
