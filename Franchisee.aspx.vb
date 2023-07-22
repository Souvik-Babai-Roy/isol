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
        Dim da As New OdbcDataAdapter("SELECT primary_id FROM primary_details where company_id='" & Session("comid") & "' and primary_name='Indirect Income'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        primaryid = dt.Rows(0).Item(0)

        Dim qledid As Integer = 0
        Dim da1 As New OdbcDataAdapter("SELECT id FROM fixed_param where param_type='quick_ledger_type' and param_name='Franchisee'", dbcon.con)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        qledid = dt.Rows(0).Item(0)

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO ledger(company_id,company_type_id,q_led_type_id,q_led_type,primary_type_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,tan_no,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,created_date,created_by,status,branch_code,franchisee_code) values(?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@q_led_type_id", qledid)
            cmd.Parameters.AddWithValue("@q_led_type", "Franchisee")
            cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
            cmd.Parameters.AddWithValue("@primary_type", "Indirect Income")
            cmd.Parameters.AddWithValue("@ledger_name", txtfranname.Text.ToString.ToUpper)
            cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
            cmd.Parameters.AddWithValue("@per_address", txtaddress.Text.ToString)
            cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
            cmd.Parameters.AddWithValue("@per_landmark", txtlandmark.Text.ToString)
            cmd.Parameters.AddWithValue("@per_state", txtstate.text.ToString)
            cmd.Parameters.AddWithValue("@comp_name", txtcompname.Text.ToString)
            cmd.Parameters.AddWithValue("@gstno", txtgstno.Text.ToString)
            cmd.Parameters.AddWithValue("@invoice_address", txtinvoice.Text.ToString)
            cmd.Parameters.AddWithValue("@tan_no", txttanno.Text.ToString)
            cmd.Parameters.AddWithValue("@bank_name", txtbank.Text)
            cmd.Parameters.AddWithValue("@ac_no", txtacno.Text)
            cmd.Parameters.AddWithValue("@ac_type", txtactype.Text.ToString)
            cmd.Parameters.AddWithValue("@ifsc_code", txtifsccode.Text.ToString)
            cmd.Parameters.AddWithValue("@branch_name", txtbranch.Text.ToString)
            cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text.ToString)
            cmd.Parameters.AddWithValue("@upi_id", txtupiid.Text.ToString)
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
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name='" & txtfranname.Text & "' and q_led_type='Franchisee' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Franchisee already Exist", "error")
        Else
            ledgerentry()
            txtfranname.Text = ""
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
            txtbank.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtupiid.Text = ""
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,tan_no,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,status FROM ledger where company_id='" & Session("comid") & "' and q_led_type='Franchisee' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,tan_no,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,status FROM ledger where upper(ledger_name) like upper('%" & txtsearchname.Text & "%') and company_id='" & Session("comid") & "' and q_led_type='Franchisee' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT * FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Franchisee' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows(0).Item("ledger_name") IsNot DBNull.Value Then
            txtfranname.Text = ds.Tables(0).Rows(0).Item("ledger_name")
            txtfranname.Attributes("disabled") = "disabled"
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
        If ds.Tables(0).Rows(0).Item("comp_name") IsNot DBNull.Value Then
            txtcompname.Text = ds.Tables(0).Rows(0).Item("comp_name")
        End If
        If ds.Tables(0).Rows(0).Item("gstno") IsNot DBNull.Value Then
            txtgstno.Text = ds.Tables(0).Rows(0).Item("gstno")
        End If
        If ds.Tables(0).Rows(0).Item("invoice_address") IsNot DBNull.Value Then
            txtinvoice.Text = ds.Tables(0).Rows(0).Item("invoice_address")
        End If
        If ds.Tables(0).Rows(0).Item("pan_no") IsNot DBNull.Value Then
            txtpanno.Text = ds.Tables(0).Rows(0).Item("pan_no")
        End If
        If ds.Tables(0).Rows(0).Item("tan_no") IsNot DBNull.Value Then
            txttanno.Text = ds.Tables(0).Rows(0).Item("tan_no")
        End If
        If ds.Tables(0).Rows(0).Item("bank_name") IsNot DBNull.Value Then
            txtbank.Text = ds.Tables(0).Rows(0).Item("bank_name")
        End If
        If ds.Tables(0).Rows(0).Item("ac_no") IsNot DBNull.Value Then
            txtacno.Text = ds.Tables(0).Rows(0).Item("ac_no")
        End If
        If ds.Tables(0).Rows(0).Item("ac_type") IsNot DBNull.Value Then
            txtactype.Text = ds.Tables(0).Rows(0).Item("ac_type")
        End If
        If ds.Tables(0).Rows(0).Item("ifsc_code") IsNot DBNull.Value Then
            txtifsccode.Text = ds.Tables(0).Rows(0).Item("ifsc_code")
        End If
        If ds.Tables(0).Rows(0).Item("branch_name") IsNot DBNull.Value Then
            txtbranch.Text = ds.Tables(0).Rows(0).Item("branch_name")
        End If
        If ds.Tables(0).Rows(0).Item("upi_id") IsNot DBNull.Value Then
            txtupiid.Text = ds.Tables(0).Rows(0).Item("upi_id")
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
                Dim da As New OdbcDataAdapter("SELECT ledger_id,primary_type,ledger_name,phnno,email,per_address,per_pin_code,per_landmark,per_state,comp_name,gstno,invoice_address,tan_no,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and q_led_type='Franchisee' and status<>'Inactive'", dbcon.con)
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
        cmd.CommandText = "update ledger set phnno=?,email=?,per_address=?,per_pin_code=?,per_landmark=?,per_state=?,comp_name=?,gstno=?,invoice_address=?,tan_no=?,bank_name=?,ac_no=?,ac_type=?,ifsc_code=?,branch_name=?,pan_no=?,upi_id=?,modified_date=?,modified_by=?,status=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='Franchisee' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
        cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
        cmd.Parameters.AddWithValue("@per_address", txtaddress.Text.ToString)
        cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
        cmd.Parameters.AddWithValue("@per_landmark", txtlandmark.Text.ToString)
        cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToString)
        cmd.Parameters.AddWithValue("@comp_name", txtcompname.Text.ToString)
        cmd.Parameters.AddWithValue("@gstno", txtgstno.Text.ToString)
        cmd.Parameters.AddWithValue("@invoice_address", txtinvoice.Text.ToString)
        cmd.Parameters.AddWithValue("@tan_no", txttanno.Text.ToString)
        cmd.Parameters.AddWithValue("@bank_name", txtbank.Text)
        cmd.Parameters.AddWithValue("@ac_no", txtacno.Text)
        cmd.Parameters.AddWithValue("@ac_type", txtactype.Text.ToString)
        cmd.Parameters.AddWithValue("@ifsc_code", txtifsccode.Text.ToString)
        cmd.Parameters.AddWithValue("@branch_name", txtbranch.Text.ToString)
        cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text.ToString)
        cmd.Parameters.AddWithValue("@upi_id", txtupiid.Text.ToString)
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
            txtfranname.Text = ""
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
            txtbank.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtupiid.Text = ""
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
        cmd.CommandText = "update ledger set status='Inactive' where ledger_id='" & txtsearchname.Text & "' and q_led_type='Franchisee' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Ledger Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            txtfranname.Text = ""
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
            txtbank.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtupiid.Text = ""
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

    Protected Sub txtfranname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfranname.TextChanged
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtfranname.Text & "') and q_led_type='Franchisee' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Franchisee name already Exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub

End Class
