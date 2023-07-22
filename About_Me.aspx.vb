Imports System.Web
Imports System.IO
Imports globalcon
Imports globaldesign
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Odbc
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim dbcon As New globalcon
    Dim gcdsgn As New globaldesign

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim da As New OdbcDataAdapter("select * from user_master where uname='" & Session("uname") & "' and usertypeid='" & Session("utypeid") & "' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            lblusername.Text = Session("uname")
            lblusertype.Text = ds.Tables(0).Rows(0).Item("usertype")
            lblphn.Text = ds.Tables(0).Rows(0).Item("phn_no")
            lblmail.Text = ds.Tables(0).Rows(0).Item("email")
            lbluid.Text = ds.Tables(0).Rows(0).Item("user_id")

        Catch ex As Exception

        End Try
    End Sub

    Public Sub updateinfo()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        If txtphnno.Text <> "" And txtmail.Text <> "" Then
            cmd.CommandText = "update user_master set phn_no=?,email=?,modifyby=?,modifydate=? where uname='" & Session("uname") & "' and usertypeid='" & Session("utypeid") & "' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@phn_no", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text)
            cmd.Parameters.AddWithValue("@modifyby", Session("uname"))
            cmd.Parameters.AddWithValue("@modifydate", Now.ToString)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

        ElseIf txtphnno.Text <> "" And txtmail.Text = "" Then
            cmd.CommandText = "update user_master set phn_no=?,modifyby=?,modifydate=? where uname='" & Session("uname") & "' and usertypeid='" & Session("utypeid") & "' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@phn_no", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@modifyby", Session("uname"))
            cmd.Parameters.AddWithValue("@modifydate", Now.ToString)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        ElseIf txtphnno.Text = "" And txtmail.Text <> "" Then
            cmd.CommandText = "update user_master set email=?,modifyby=?,modifydate=? where uname='" & Session("uname") & "' and usertypeid='" & Session("utypeid") & "' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@email", txtmail.Text)
            cmd.Parameters.AddWithValue("@modifyby", Session("uname"))
            cmd.Parameters.AddWithValue("@modifydate", Now.ToString)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        End If
        dbcon.con.Close()

    End Sub

    Private Sub updateledger()

        Dim ledid As Integer = 0
        Dim da As New OdbcDataAdapter("select * from user_master where uname='" & Session("uname") & "' and usertypeid='" & Session("utypeid") & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        ledid = ds.Tables(0).Rows(0).Item("ledger_id")

        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        If txtphnno.Text <> "" And txtmail.Text <> "" Then
            cmd.CommandText = "update ledger set phnno=?,email=?,modified_date=?,modified_by=? where ledger_id='" & ledid & "' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@phnno", txtphnno.Text)
            cmd.Parameters.AddWithValue("@email", txtmail.Text)
            cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
            cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        ElseIf txtphnno.Text <> "" And txtmail.Text = "" Then
            cmd.CommandText = "update ledger set phnno=?,modified_date=?,modified_by=? where ledger_id='" & ledid & "' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@phnno", txtphnno.Text)
            cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
            cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        ElseIf txtphnno.Text = "" And txtmail.Text <> "" Then
            cmd.CommandText = "update ledger set email=?,modified_date=?,modified_by=? where ledger_id='" & ledid & "' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@email", txtmail.Text)
            cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
            cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
        End If

        dbcon.con.Close()


    End Sub


    Public Sub updatelogin()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update user_master set user_id=?,user_passwd=?,modifyby=?,modifydate=? where uname='" & Session("uname") & "' and usertypeid='" & Session("utypeid") & "' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@user_passwd", txtuserid.Text)
        cmd.Parameters.AddWithValue("@user_passwd", txtrenewpswd.Text)
        cmd.Parameters.AddWithValue("@modifyby", Session("uname"))
        cmd.Parameters.AddWithValue("@modifydate", Now.ToString)
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct2.InnerHtml = gcdsgn.alertmsg("Login Credentials have been updated", "success")

    End Sub


    Protected Sub btneditmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btneditmail.Click
        txtmail.Text = lblmail.Text
    End Sub

    Protected Sub btnediphn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnediphn.Click
        txtphnno.Text = lblphn.Text
    End Sub

    Protected Sub btnedituid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnedituid.Click
        txtuserid.Text = lbluid.Text
    End Sub

    Protected Sub btnupdatelogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdatelogin.Click
        Dim da As New OdbcDataAdapter("select * from user_master where user_id='" & txtuserid.Text & "' and status<>'Inactive'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 1 Then
            msgct2.InnerHtml = gcdsgn.alertmsg("User ID not available", "error")
        Else
            updatelogin()

        End If
    End Sub


    Protected Sub btnupdateinfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.Click
        updateinfo()
        updateledger()
    End Sub
End Class
