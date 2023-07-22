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
        Dim da As New OdbcDataAdapter("SELECT primary_id FROM primary_details where company_id='" & Session("comid") & "' and primary_name='" & ddlprimary.SelectedValue & "'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        primaryid = dt.Rows(0).Item(0)

        Dim qledid As Integer = 0
        Dim da1 As New OdbcDataAdapter("SELECT id FROM fixed_param where param_type='quick_ledger_type' and param_name='General Ledger'", dbcon.con)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        qledid = dt.Rows(0).Item(0)

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO ledger(company_id,company_type_id,q_led_type_id,q_led_type,primary_type_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,pan_no,tan_no,open_bal,close_bal,created_date,created_by,status,branch_code,franchisee_code) values(?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@q_led_type_id", qledid)
            cmd.Parameters.AddWithValue("@q_led_type", "General Ledger")
            cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
            cmd.Parameters.AddWithValue("@primary_type", ddlprimary.SelectedValue)
            cmd.Parameters.AddWithValue("@ledger_name", txtledname.Text.ToString)
            cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
            cmd.Parameters.AddWithValue("@per_address", txtaddress.Text.ToString)
            cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
            cmd.Parameters.AddWithValue("@per_landmark", txtlandmark.Text.ToString)
            cmd.Parameters.AddWithValue("@per_state", txtstate.text.ToString)
            cmd.Parameters.AddWithValue("@comp_name", txtcompname.Text.ToString)
            cmd.Parameters.AddWithValue("@gstno", txtgstno.Text.ToString)
            cmd.Parameters.AddWithValue("@invoice_address", txtinvoice.Text.ToString)
            cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text.ToString)
            cmd.Parameters.AddWithValue("@tan_no", txttanno.Text.ToString)
            cmd.Parameters.AddWithValue("@open_bal", Val(txtopenbal.Text))
            cmd.Parameters.AddWithValue("@close_bal", Val(txtclosebal.Text))
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
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name='" & txtledname.Text & "' and q_led_type='General Ledger' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Ledger already Exist", "error")
        Else
            ledgerentry()
            ddlprimary.ClearSelection()
            txtledname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlandmark.Text = ""
            txtstate.Text = ""
            txtcompname.Text = ""
            txtgstno.Text = ""
            txtinvoice.Text = ""
            txtpanno.Text = ""
            txttanno.Text = ""
            txtopenbal.Text = ""
            txtclosebal.Text = ""
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,pan_no,tan_no,open_bal,close_bal,status FROM ledger where company_id='" & Session("comid") & "' and q_led_type='General Ledger' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,pan_no,tan_no,open_bal,close_bal,status FROM ledger where upper(ledger_name) like upper('%" & txtsearchname.Text & "%') and company_id='" & Session("comid") & "' and q_led_type='General Ledger' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,pan_no,tan_no,open_bal,close_bal,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='General Ledger' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows(0).Item(1) IsNot DBNull.Value Then
            ddlprimary.Text = ds.Tables(0).Rows(0).Item(1)
        End If
        If ds.Tables(0).Rows(0).Item(2) IsNot DBNull.Value Then
            txtledname.Text = ds.Tables(0).Rows(0).Item(2)
            txtledname.Attributes("disabled") = "disabled"
        End If
        If ds.Tables(0).Rows(0).Item(3) IsNot DBNull.Value Then
            txtphnno.Text = ds.Tables(0).Rows(0).Item(3)
        End If
        If ds.Tables(0).Rows(0).Item(4) IsNot DBNull.Value Then
            txtmail.Text = ds.Tables(0).Rows(0).Item(4)
        End If
        If ds.Tables(0).Rows(0).Item(5) IsNot DBNull.Value Then
            txtaddress.Text = ds.Tables(0).Rows(0).Item(5)
        End If
        If ds.Tables(0).Rows(0).Item(6) IsNot DBNull.Value Then
            txtpin.Text = ds.Tables(0).Rows(0).Item(6)
        End If
        If ds.Tables(0).Rows(0).Item(7) IsNot DBNull.Value Then
            txtlandmark.Text = ds.Tables(0).Rows(0).Item(7)
        End If
        If ds.Tables(0).Rows(0).Item(8) IsNot DBNull.Value Then
            txtstate.Text = ds.Tables(0).Rows(0).Item(8)
        End If
        If ds.Tables(0).Rows(0).Item(9) IsNot DBNull.Value Then
            txtcompname.Text = ds.Tables(0).Rows(0).Item(9)
        End If
        If ds.Tables(0).Rows(0).Item(10) IsNot DBNull.Value Then
            txtgstno.Text = ds.Tables(0).Rows(0).Item(10)
        End If
        If ds.Tables(0).Rows(0).Item(11) IsNot DBNull.Value Then
            txtinvoice.Text = ds.Tables(0).Rows(0).Item(11)
        End If
        If ds.Tables(0).Rows(0).Item(12) IsNot DBNull.Value Then
            txtpanno.Text = ds.Tables(0).Rows(0).Item(12)
        End If
        If ds.Tables(0).Rows(0).Item(13) IsNot DBNull.Value Then
            txttanno.Text = ds.Tables(0).Rows(0).Item(13)
        End If
        If ds.Tables(0).Rows(0).Item(14) IsNot DBNull.Value Then
            txtopenbal.Text = ds.Tables(0).Rows(0).Item(14)
        End If
        If ds.Tables(0).Rows(0).Item(15) IsNot DBNull.Value Then
            txtclosebal.Text = ds.Tables(0).Rows(0).Item(15)
        End If
        If ds.Tables(0).Rows(0).Item(16) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(16) <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item(16)
            End If
        End If
    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,pan_no,tan_no,open_bal,close_bal,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and q_led_type='General Ledger' and status<>'Inactive'", dbcon.con)
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
        Dim primaryid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT primary_id FROM primary_details where company_id='" & Session("comid") & "' and primary_name='" & ddlprimary.SelectedValue & "'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        primaryid = dt.Rows(0).Item(0)

        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set primary_type_id=?,primary_type=?,phnno=?,email=?,per_address=?,per_pin_code=?,per_landmark=?,per_state=?,comp_name=?,gstno=?,invoice_address=?,pan_no=?,tan_no=?,open_bal=?,close_bal=?,modified_date=?,modified_by=?,status=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='General Ledger' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
        cmd.Parameters.AddWithValue("@primary_type", ddlprimary.SelectedValue)
        cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
        cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
        cmd.Parameters.AddWithValue("@per_address", txtaddress.Text.ToString)
        cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
        cmd.Parameters.AddWithValue("@per_landmark", txtlandmark.Text.ToString)
        cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToString)
        cmd.Parameters.AddWithValue("@comp_name", txtcompname.Text.ToString)
        cmd.Parameters.AddWithValue("@gstno", txtgstno.Text.ToString)
        cmd.Parameters.AddWithValue("@invoice_address", txtinvoice.Text.ToString)
        cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text.ToString)
        cmd.Parameters.AddWithValue("@tan_no", txttanno.Text.ToString)
        cmd.Parameters.AddWithValue("@open_bal", Val(txtopenbal.Text))
        cmd.Parameters.AddWithValue("@close_bal", Val(txtclosebal.Text))
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
            ddlprimary.ClearSelection()
            txtledname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlandmark.Text = ""
            txtstate.Text = ""
            txtcompname.Text = ""
            txtgstno.Text = ""
            txtinvoice.Text = ""
            txtpanno.Text = ""
            txttanno.Text = ""
            txtopenbal.Text = ""
            txtclosebal.Text = ""
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
        cmd.CommandText = "update ledger set status='Inactive' where ledger_id='" & txtsearchname.Text & "' and q_led_type='General Ledger' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Ledger Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            ddlprimary.ClearSelection()
            txtledname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlandmark.Text = ""
            txtstate.Text = ""
            txtcompname.Text = ""
            txtgstno.Text = ""
            txtinvoice.Text = ""
            txtpanno.Text = ""
            txttanno.Text = ""
            txtopenbal.Text = ""
            txtclosebal.Text = ""
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
            dbcon.primarypopulate(ddlprimary, Session("comid"))
        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            valmsg.InnerText = ""
        End If
        grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub txtledname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtledname.TextChanged
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='General Ledger' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Ledger name already Exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub
End Class
