Imports System.Data.SqlClient
Imports System.Text
Imports System.Configuration

Namespace Data
    Module Program
        Public Sub Run()
            Dim sConn As String = ConfigurationManager.ConnectionStrings("CBUTILS").ToString()
            Dim sSql As String = "SELECT * From Folders"
            Dim oConn As SqlConnection = New SqlConnection(sConn)

            oConn.Open()

            Using oCmd As SqlCommand = New SqlCommand(sSql, oConn)
                Using oRead As SqlDataReader = oCmd.ExecuteReader()
                    Dim sRetSB As New StringBuilder
                    While oRead.Read
                        sRetSB.Append(oRead.GetValue(0).ToString)
                    End While
                End Using
            End Using

            oConn.Close()
            oConn.Dispose()
        End Sub
    End Module
End Namespace
