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

    Public Sub ledgerentry()

        Dim primaryid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT primary_id FROM primary_details where company_id='" & Session("comid") & "' and primary_name='Branch / Division'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        primaryid = dt.Rows(0).Item(0)

        Dim qledid As Integer = 0
        Dim da1 As New OdbcDataAdapter("SELECT id FROM fixed_param where param_type='quick_ledger_type' and param_name='Branch'", dbcon.con)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        qledid = dt.Rows(0).Item(0)

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO ledger(company_id,company_type_id,q_led_type_id,q_led_type,primary_type_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,gstno,emergency_contact_person,created_date,created_by,status,branch_code,franchisee_code) values(?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@q_led_type_id", qledid)
            cmd.Parameters.AddWithValue("@q_led_type", "Branch")
            cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
            cmd.Parameters.AddWithValue("@primary_type", "Branch / Division")
            cmd.Parameters.AddWithValue("@ledger_name", txtbranchname.Text.ToString.ToUpper)
            cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
            cmd.Parameters.AddWithValue("@per_address", txtaddress.Text.ToString)
            cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
            cmd.Parameters.AddWithValue("@per_landmark", txtlandmark.Text.ToString)
            cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToString)
            cmd.Parameters.AddWithValue("@gstno", txtgst.Text.ToString)
            cmd.Parameters.AddWithValue("@emergency_contact_person", txtcntperson.Text.ToString)
            cmd.Parameters.AddWithValue("@created_date", Now.ToString)
            cmd.Parameters.AddWithValue("@created_by", Session("uname"))
            cmd.Parameters.AddWithValue("@status", "Active")
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            msgct1.InnerHtml = gcdsgn.alertmsg("Data has been Saved", "success")
        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try
    End Sub

    Protected Sub btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.ServerClick
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name='" & txtbranchname.Text & "' and q_led_type='Branch' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Branch already Exist", "error")
        Else
            ledgerentry()
            txtbranchname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlandmark.Text = ""
            txtstate.Text = ""
            txtgst.Text = ""
            txtcntperson.Text = ""
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name as branch_name,emergency_contact_person as contact_person,phnno,email,per_address,per_pin_code,per_landmark,per_state,gstno,status FROM ledger where company_id='" & Session("comid") & "' and q_led_type='Branch' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name as branch_name,emergency_contact_person as contact_person,phnno,email,per_address,per_pin_code,per_landmark,per_state,gstno,status FROM ledger where upper(ledger_name) like upper('%" & txtsearchname.Text & "%') and company_id='" & Session("comid") & "' and q_led_type='Branch' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True
            End If

        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try

    End Sub


    Public Sub updatefields()
        Dim da As New OdbcDataAdapter("SELECT * FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Branch' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows(0).Item("ledger_name") IsNot DBNull.Value Then
            txtbranchname.Text = ds.Tables(0).Rows(0).Item("ledger_name")
            txtbranchname.Attributes("disabled") = "disabled"
        End If

        If ds.Tables(0).Rows(0).Item("phnno") IsNot DBNull.Value Then
            txtphnno.Text = ds.Tables(0).Rows(0).Item("phnno")
        End If
        If ds.Tables(0).Rows(0).Item("email") IsNot DBNull.Value Then
            txtmail.Text = ds.Tables(0).Rows(0).Item("email")
        End If
        If ds.Tables(0).Rows(0).Item("per_address") IsNot DBNull.Value Then
            txtaddress.Text = ds.Tables(0).Rows(0).Item("per_address")
        End If
        If ds.Tables(0).Rows(0).Item("per_pin_code") IsNot DBNull.Value Then
            txtpin.Text = ds.Tables(0).Rows(0).Item("per_pin_code")
        End If
        If ds.Tables(0).Rows(0).Item("per_landmark") IsNot DBNull.Value Then
            txtlandmark.Text = ds.Tables(0).Rows(0).Item("per_landmark")
        End If
        If ds.Tables(0).Rows(0).Item("per_state") IsNot DBNull.Value Then
            txtstate.Text = ds.Tables(0).Rows(0).Item("per_state")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact_person") IsNot DBNull.Value Then
            txtcntperson.Text = ds.Tables(0).Rows(0).Item("emergency_contact_person")
        End If
        If ds.Tables(0).Rows(0).Item("gstno") IsNot DBNull.Value Then
            txtgst.Text = ds.Tables(0).Rows(0).Item("gstno")
        End If
        If ds.Tables(0).Rows(0).Item("status") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(16) <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item("status")
            End If
        End If
    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name as branch_name,emergency_contact_person as contact_person,phnno,email,per_address,per_pin_code,per_landmark,per_state,gstno,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and q_led_type='Branch' and status<>'Inactive'", dbcon.con)
                Dim ds As New DataSet
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    grdvleddetails.DataSource = ds
                    grdvleddetails.DataBind()
                    grdvleddetails.Visible = True
                    updatefields()
                    btnsave.Visible = False
                    btnupdate.Visible = True
                    btndelete.Visible = True
                    divstatus.Visible = True
                End If
            Else
                grdvleddetails.DataSource = Nothing
                grdvleddetails.DataBind()
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Ledger ID", "error")
            End If
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Private Sub updateinfo()

        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set phnno=?,email=?,per_address=?,per_pin_code=?,per_landmark=?,per_state=?,gstno=?,emergency_contact_person=?,modified_date=?,modified_by=?,status=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='Branch' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
        cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
        cmd.Parameters.AddWithValue("@per_address", txtaddress.Text.ToString)
        cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
        cmd.Parameters.AddWithValue("@per_landmark", txtlandmark.Text.ToString)
        cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToString)
        cmd.Parameters.AddWithValue("@gstno", txtgst.Text.ToString)
        cmd.Parameters.AddWithValue("@emergency_contact_person", txtcntperson.Text.ToString)
        cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
        cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
        cmd.Parameters.AddWithValue("@status", ddlstatus.SelectedValue)
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Information Updated Successfully", "success")

    End Sub

    Protected Sub btnupdate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.ServerClick
        If txtsearchname.Text <> "" Then
            updateinfo()
           txtbranchname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlandmark.Text = ""
            txtstate.Text = ""
            txtgst.Text = ""
            txtcntperson.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Ledger ID to Update", "error")
        End If

    End Sub

    Private Sub deleteledger()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set status='Inactive' where ledger_id='" & txtsearchname.Text & "' and q_led_type='Branch' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Ledger Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
          txtbranchname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlandmark.Text = ""
            txtstate.Text = ""
            txtgst.Text = ""
            txtcntperson.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Ledger ID to Delete", "error")
        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            valmsg.InnerText = ""
        End If
        grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub txtbranchname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbranchname.TextChanged
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtbranchname.Text & "') and q_led_type='Branch' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Branch name already Exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub
End Class
