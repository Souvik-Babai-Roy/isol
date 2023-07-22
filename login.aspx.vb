Imports System.Web
Imports System.IO
Imports globalcon
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Odbc
Partial Class Login2
    Inherits System.Web.UI.Page
    Dim dbcon As New globalcon

    Public Sub redirectto(ByVal comptypeid As String)
        Select Case comptypeid
            Case "11"
                Response.Redirect("epg_dashboard.aspx")
            Case Else
                Response.Redirect("Dashboard.aspx")
        End Select
    End Sub


    Protected Sub btnlogin_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogin.ServerClick

        Try
            Dim da As New OdbcDataAdapter("select company_id,company_type_id,uname,usertypeid,branch_code,franchisee_code,user_master_id from user_master where user_id='" & txtuser.Text & "' and user_passwd='" & txtpswd.Text & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                Session("comid") = ds.Tables(0).Rows(0).Item(0)
                Session("comtypeid") = ds.Tables(0).Rows(0).Item(1)
                Session("uname") = ds.Tables(0).Rows(0).Item(2)
                Session("utypeid") = ds.Tables(0).Rows(0).Item(3)
                If ds.Tables(0).Rows(0).Item(4) IsNot DBNull.Value Then
                    Session("brcode") = ds.Tables(0).Rows(0).Item(4)
                Else
                    Session("brcode") = 0
                End If
                If ds.Tables(0).Rows(0).Item(5) IsNot DBNull.Value Then
                    Session("frcode") = ds.Tables(0).Rows(0).Item(5)
                Else
                    Session("frcode") = 0
                End If
                Session("uid") = ds.Tables(0).Rows(0).Item("user_master_id")

                redirectto(Session("comtypeid"))
            Else
                Response.Write("Incorrect Login Credentials")
            End If


        Catch ex As Exception
        End Try



    End Sub
End Class
