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
        Dim qledtypeid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT id FROM fixed_param where param_type='quick_ledger_type' and param_name='" & ddlqckledtype.selectedvalue & "'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        qledtypeid = dt.Rows(0).Item(0)

        Dim primaryid As Integer = 0
        Dim da1 As New OdbcDataAdapter("SELECT primary_id FROM primary_details where primary_name='Direct Income'", dbcon.con)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        primaryid = dt1.Rows(0).Item(0)

        Dim gend As String = ""
        If rdblgender.SelectedValue.ToString = "Male" Then
            gend = "M"
        ElseIf rdblgender.SelectedValue.ToString = "Female" Then
            gend = "F"
        End If

        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If

        Dim assledid As Integer = 0
        If txtmainguestcontact.Text <> "" Then
            Dim da2 As New OdbcDataAdapter("SELECT ledger_id FROM ledger where phnno='" & txtmainguestcontact.Text & "' and q_led_type='Guest' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            assledid = dt2.Rows(0).Item(0)
        End If

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO ledger(company_id,company_type_id,q_led_type_id,q_led_type,primary_type_id,primary_type,associate_led_id,ledger_title,ledger_name,phnno,email,dob,gender,relation,per_address,per_pin_code,per_landmark,per_state,per_country,nationality,id_proof_type,id_proof_no,created_date,created_by,status,branch_code,franchisee_code) values(?,?,?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            If ddlqckledtype.SelectedValue = "Companion Guest" Then
                If txtmainguestcontact.Text <> "" And txtguestname.Text <> "" Then
                    cmd.Parameters.AddWithValue("@company_id", Session("comid"))
                    cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
                    cmd.Parameters.AddWithValue("@q_led_type_id", qledtypeid)
                    cmd.Parameters.AddWithValue("@q_led_type", ddlqckledtype.SelectedItem.ToString)
                    cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
                    cmd.Parameters.AddWithValue("@primary_type", "Direct Income")
                    cmd.Parameters.AddWithValue("@associate_led_id", assledid)
                    cmd.Parameters.AddWithValue("@ledger_title", ddltitle.SelectedValue)
                    cmd.Parameters.AddWithValue("@ledger_name", txtledname.Text)
                    cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
                    cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
                    cmd.Parameters.AddWithValue("@dob", DBNull.Value)
                    cmd.Parameters.AddWithValue("@gender", gend)
                    cmd.Parameters.AddWithValue("@relation", txtrelationship.Text)
                    cmd.Parameters.AddWithValue("@per_address", DBNull.Value)
                    cmd.Parameters.AddWithValue("@per_pin_code", DBNull.Value)
                    cmd.Parameters.AddWithValue("@per_landmark", DBNull.Value)
                    cmd.Parameters.AddWithValue("@per_state", DBNull.Value)
                    cmd.Parameters.AddWithValue("@per_country", DBNull.Value)
                    cmd.Parameters.AddWithValue("@nationality", DBNull.Value)
                    cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
                    cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
                    cmd.Parameters.AddWithValue("@created_date", Now.ToString)
                    cmd.Parameters.AddWithValue("@created_by", Session("uname"))
                    cmd.Parameters.AddWithValue("@status", "Active")
                    cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
                    cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
                End If
            Else
                cmd.Parameters.AddWithValue("@company_id", Session("comid"))
                cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
                cmd.Parameters.AddWithValue("@q_led_type_id", qledtypeid)
                cmd.Parameters.AddWithValue("@q_led_type", ddlqckledtype.SelectedItem.ToString)
                cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
                cmd.Parameters.AddWithValue("@primary_type", "Direct Income")
                cmd.Parameters.AddWithValue("@associate_led_id", DBNull.Value)
                cmd.Parameters.AddWithValue("@ledger_title", ddltitle.SelectedValue)
                cmd.Parameters.AddWithValue("@ledger_name", txtledname.Text.ToString)
                cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
                cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
                cmd.Parameters.AddWithValue("@dob", txtdob.Text)
                cmd.Parameters.AddWithValue("@gender", gend)
                cmd.Parameters.AddWithValue("@relation", DBNull.Value)
                cmd.Parameters.AddWithValue("@per_address", txtaddress.Text)
                cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
                cmd.Parameters.AddWithValue("@per_landmark", txtlocality.Text)
                cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToUpper)
                cmd.Parameters.AddWithValue("@per_country", country)
                cmd.Parameters.AddWithValue("@nationality", txtnationality.Text)
                cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
                cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
                cmd.Parameters.AddWithValue("@created_date", Now.ToString)
                cmd.Parameters.AddWithValue("@created_by", Session("uname"))
                cmd.Parameters.AddWithValue("@status", "Active")
                cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
                cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            End If

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
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Guest' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Guest already Exist", "error")
        Else
            ledgerentry()
            txtledname.Text = ""
            txtphnno.Text = ""
            ddltitle.ClearSelection()
            ddlqckledtype.ClearSelection()
            txtmainguestcontact.Text = ""
            txtguestname.Text = ""
            txtmail.Text = ""
            rdblgender.ClearSelection()
            txtdob.Text = ""
            txtrelationship.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlocality.Text = ""
            txtstate.Text = ""
            rblcountry.ClearSelection()
            txtcountry.Text = ""
            txtnationality.Text = ""
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,associate_led_id,ledger_title as title,ledger_name as guest_name,phnno,email,dob,gender,relation,per_address as address,per_pin_code as pincode,per_landmark as lanmark,per_state as state,per_country as country,nationality,id_proof_type,id_proof_no,status FROM ledger where company_id='" & Session("comid") & "' and q_led_type in ('Guest','Companion Guest') and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,associate_led_id,ledger_title as title,ledger_name as guest_name,phnno,email,dob,gender,relation,per_address as address,per_pin_code as pincode,per_landmark as lanmark,per_state as state,per_country as country,nationality,id_proof_type,id_proof_no,status FROM ledger where upper(ledger_name) like upper('%" & txtsearchname.Text & "%') and q_led_type in ('Guest','Companion Guest Guest') and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT q_led_type,associate_led_id,ledger_title,ledger_name,phnno,email,dob,gender,relation,per_address,per_pin_code,per_landmark,per_state,per_country,nationality,id_proof_type,id_proof_no,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type in ('Guest','Companion Guest') and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows(0).Item(0) = "Companion Guest" Then
            If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
                ddlqckledtype.Text = ds.Tables(0).Rows(0).Item(0)
                ddlqckledtype.Attributes("disabled") = "disabled"
            End If
            Using da1 As New OdbcDataAdapter("select phnno,ledger_name from ledger where ledger_id='" & ds.Tables(0).Rows(0).Item(1) & "'", dbcon.con)
                Using dt As New DataTable
                    da1.Fill(dt)
                    txtmainguestcontact.Text = dt.Rows(0).Item(0)
                    txtguestname.Text = dt.Rows(0).Item(1)
                    txtmainguestcontact.Attributes("disabled") = "disabled"
                    txtguestname.Attributes("disabled") = "disabled"
                End Using
            End Using

            If ds.Tables(0).Rows(0).Item(2) IsNot DBNull.Value Then
                ddltitle.Text = ds.Tables(0).Rows(0).Item(2)
            End If
            If ds.Tables(0).Rows(0).Item(3) IsNot DBNull.Value Then
                txtledname.Text = ds.Tables(0).Rows(0).Item(3)
                txtledname.Attributes("disabled") = "disabled"
            End If
            If ds.Tables(0).Rows(0).Item(4) IsNot DBNull.Value Then
                txtphnno.Text = ds.Tables(0).Rows(0).Item(4)
            End If
            If ds.Tables(0).Rows(0).Item(5) IsNot DBNull.Value Then
                txtmail.Text = ds.Tables(0).Rows(0).Item(5)
            End If
            If ds.Tables(0).Rows(0).Item(7) IsNot DBNull.Value Then
                If ds.Tables(0).Rows(0).Item(7) = "M" Then
                    rdblgender.Text = "Male"
                Else
                    rdblgender.Text = "Female"
                End If
            End If
            If ds.Tables(0).Rows(0).Item(8) IsNot DBNull.Value Then
                txtrelationship.Text = ds.Tables(0).Rows(0).Item(8)
            End If
            If ds.Tables(0).Rows(0).Item(15) IsNot DBNull.Value Then
                ddlidproof.Text = ds.Tables(0).Rows(0).Item(15)
            End If
            If ds.Tables(0).Rows(0).Item(16) IsNot DBNull.Value Then
                txtidprfno.Text = ds.Tables(0).Rows(0).Item(16)
            End If
            If ds.Tables(0).Rows(0).Item(17) IsNot DBNull.Value Then
                If ds.Tables(0).Rows(0).Item(17) <> "Inactive" Then
                    ddlstatus.Text = ds.Tables(0).Rows(0).Item(17)
                End If
            End If
        Else
            If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
                ddlqckledtype.Text = ds.Tables(0).Rows(0).Item(0)
                ddlqckledtype.Attributes("disabled") = "disabled"
            End If
            If ds.Tables(0).Rows(0).Item(2) IsNot DBNull.Value Then
                ddltitle.Text = ds.Tables(0).Rows(0).Item(2)
            End If
            If ds.Tables(0).Rows(0).Item(3) IsNot DBNull.Value Then
                txtledname.Text = ds.Tables(0).Rows(0).Item(3)
                txtledname.Attributes("disabled") = "disabled"
            End If
            If ds.Tables(0).Rows(0).Item(4) IsNot DBNull.Value Then
                txtphnno.Text = ds.Tables(0).Rows(0).Item(4)
            End If
            If ds.Tables(0).Rows(0).Item(5) IsNot DBNull.Value Then
                txtmail.Text = ds.Tables(0).Rows(0).Item(5)
            End If
            If ds.Tables(0).Rows(0).Item(6) IsNot DBNull.Value Then
                txtdob.Text = ds.Tables(0).Rows(0).Item(6)
            End If
            If ds.Tables(0).Rows(0).Item(7) IsNot DBNull.Value Then
                If ds.Tables(0).Rows(0).Item(7) = "M" Then
                    rdblgender.Text = "Male"
                Else
                    rdblgender.Text = "Female"
                End If
            End If
            If ds.Tables(0).Rows(0).Item(9) IsNot DBNull.Value Then
                txtaddress.Text = ds.Tables(0).Rows(0).Item(9)
            End If
            If ds.Tables(0).Rows(0).Item(10) IsNot DBNull.Value Then
                txtpin.Text = ds.Tables(0).Rows(0).Item(10)
            End If
            If ds.Tables(0).Rows(0).Item(11) IsNot DBNull.Value Then
                txtlocality.Text = ds.Tables(0).Rows(0).Item(11)
            End If
            If ds.Tables(0).Rows(0).Item(12) IsNot DBNull.Value Then
                txtstate.Text = ds.Tables(0).Rows(0).Item(12)
            End If
            If ds.Tables(0).Rows(0).Item(13) IsNot DBNull.Value Then
                If ds.Tables(0).Rows(0).Item(13) = "India" Then
                    rdblgender.Text = "India"
                Else
                    rdblgender.Text = "Other (*Please Specify)"
                    txtcountry.Text = ds.Tables(0).Rows(0).Item(13)
                End If
            End If
            If ds.Tables(0).Rows(0).Item(14) IsNot DBNull.Value Then
                txtnationality.Text = ds.Tables(0).Rows(0).Item(14)
            End If
            If ds.Tables(0).Rows(0).Item(15) IsNot DBNull.Value Then
                ddlidproof.Text = ds.Tables(0).Rows(0).Item(15)
            End If
            If ds.Tables(0).Rows(0).Item(16) IsNot DBNull.Value Then
                txtidprfno.Text = ds.Tables(0).Rows(0).Item(16)
            End If
            If ds.Tables(0).Rows(0).Item(17) IsNot DBNull.Value Then
                If ds.Tables(0).Rows(0).Item(3) <> "Inactive" Then
                    ddlstatus.Text = ds.Tables(0).Rows(0).Item(17)
                End If
            End If
        End If

        If ddlqckledtype.SelectedValue = "Guest" Then
            divassociate.Visible = False
            divtitle.Visible = True
            divphn.Visible = True
            divmail.Visible = True
            divdob.Visible = True
            divgender.Visible = True
            divreln.Visible = False
            divadrs.Visible = True
            dividproof.Visible = True
        ElseIf ddlqckledtype.SelectedValue = "Companion Guest" Then
            divassociate.Visible = True
            divtitle.Visible = True
            divphn.Visible = True
            divmail.Visible = True
            divdob.Visible = False
            divgender.Visible = True
            divreln.Visible = True
            divadrs.Visible = False
            dividproof.Visible = True
        End If

    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,associate_led_id,ledger_title as title,ledger_name as guest_name,phnno,email,dob,gender,relation,per_address as address,per_pin_code as pincode,per_landmark as lanmark,per_state as state,per_country as country,nationality,id_proof_type,id_proof_no,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type in ('Guest','Companion Guest') and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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

                Else
                    msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Customer ID", "error")
                End If
            Else
                grdvleddetails.DataSource = Nothing
                grdvleddetails.DataBind()
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Customer ID", "error")
            End If
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Private Sub updateinfo()

        Dim gend As String = ""
        If rdblgender.SelectedValue.ToString = "Male" Then
            gend = "M"
        ElseIf rdblgender.SelectedValue.ToString = "Female" Then
            gend = "F"
        End If

        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If

        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        If ddlqckledtype.SelectedValue = "Guest" Then
            cmd.CommandText = "update ledger set ledger_title=?,phnno=?,email=?,dob=?,gender=?,per_address=?,per_pin_code=?,per_landmark=?,per_state=?,per_country=?,nationality=?,id_proof_type=?,id_proof_no=?,modified_date=?,modified_by=?,status=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='Guest' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@ledger_title", ddltitle.SelectedValue)
            cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
            cmd.Parameters.AddWithValue("@dob", txtdob.Text)
            cmd.Parameters.AddWithValue("@gender", gend)
            cmd.Parameters.AddWithValue("@per_address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
            cmd.Parameters.AddWithValue("@per_landmark", txtlocality.Text)
            cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToUpper)
            cmd.Parameters.AddWithValue("@per_country", country)
            cmd.Parameters.AddWithValue("@nationality", txtnationality.Text)
            cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
            cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
            cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
            cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
            cmd.Parameters.AddWithValue("@status", ddlstatus.SelectedValue)
        Else
            cmd.CommandText = "update ledger set ledger_title=?,phnno=?,email=?,gender=?,relation=?,id_proof_type=?,id_proof_no=?,modified_date=?,modified_by=?,status=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='Companion Guest' and company_id='" & Session("comid") & "'"
            cmd.Parameters.AddWithValue("@ledger_title", ddltitle.SelectedValue)
            cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
            cmd.Parameters.AddWithValue("@gender", gend)
            cmd.Parameters.AddWithValue("@relation", txtrelationship.Text)
            cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
            cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
            cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
            cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
            cmd.Parameters.AddWithValue("@status", ddlstatus.SelectedValue)

        End If

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
       
        msgct1.InnerHtml = gcdsgn.alertmsg("Information Updated Successfully", "success")

    End Sub

    Protected Sub btnupdate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.ServerClick
        If txtsearchname.Text <> "" Then
            updateinfo()
            txtledname.Text = ""
            txtphnno.Text = ""
            ddltitle.ClearSelection()
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
            txtledname.Text = ""
            txtphnno.Text = ""
            ddltitle.ClearSelection()
            ddlqckledtype.ClearSelection()
            txtmainguestcontact.Text = ""
            txtguestname.Text = ""
            txtmail.Text = ""
            rdblgender.ClearSelection()
            txtdob.Text = ""
            txtrelationship.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlocality.Text = ""
            txtstate.Text = ""
            rblcountry.ClearSelection()
            txtcountry.Text = ""
            txtnationality.Text = ""
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
            ddlstatus.ClearSelection()
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Ledger ID to Update", "error")
        End If
    End Sub

    Private Sub deleteledger()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set status='Inactive' where ledger_id='" & txtsearchname.Text & "' and q_led_type in ('Guest','Companion Guest') and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Ledger Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            txtledname.Text = ""
            txtphnno.Text = ""
            ddltitle.ClearSelection()
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
            txtledname.Text = ""
            txtphnno.Text = ""
            ddltitle.ClearSelection()
            ddlqckledtype.ClearSelection()
            txtmainguestcontact.Text = ""
            txtguestname.Text = ""
            txtmail.Text = ""
            rdblgender.ClearSelection()
            txtdob.Text = ""
            txtrelationship.Text = ""
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlocality.Text = ""
            txtstate.Text = ""
            rblcountry.ClearSelection()
            txtcountry.Text = ""
            txtnationality.Text = ""
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
            ddlstatus.ClearSelection()
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Ledger ID to Delete", "error")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            Dim da As New OdbcDataAdapter("SELECT param_name FROM fixed_param where param_type='quick_ledger_type' and param_name in ('Companion Guest','Guest') order by param_name asc", dbcon.con)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                ddlqckledtype.DataSource = dt
                ddlqckledtype.DataTextField = "param_name"
                ddlqckledtype.DataValueField = "param_name"
                ddlqckledtype.DataBind()
            End If
        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            valmsg.InnerText = ""
            divval.InnerText = ""
        End If
        grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White

        If rblcountry.SelectedValue.ToString = "India" Then
            txtcountry.ReadOnly = True
        Else
            txtcountry.ReadOnly = False
        End If
    End Sub
    Protected Sub txtledname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtledname.TextChanged
        'Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Guest' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        'Dim ds As New DataSet
        'da.Fill(ds)
        'If ds.Tables(0).Rows.Count > 0 Then
        '    valmsg.InnerHtml = gcdsgn.validmsg("Guest already Exist", "error")
        'Else
        '    valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        'End If
    End Sub

    Protected Sub txtphnno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtphnno.TextChanged
        If txtphnno.Text <> "" Then
            Dim da As New OdbcDataAdapter("select ledger_title,ledger_name from ledger where phnno='" & txtphnno.Text & "' and q_led_type='Guest' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                valmsg.InnerHtml = gcdsgn.validmsg("Guest already Exist", "error")
                If ds.Tables(0).Rows(0).Item(1) IsNot DBNull.Value Then
                    txtledname.Text = ds.Tables(0).Rows(0).Item(1)
                End If
                If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
                    ddltitle.Text = ds.Tables(0).Rows(0).Item(0)
                End If
            Else
                valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
            End If
        End If
    End Sub

    Protected Sub ddlqckledtype_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlqckledtype.Load
        If ddlqckledtype.SelectedValue = "Guest" Then
            divassociate.Visible = False
            divtitle.Visible = True
            divphn.Visible = True
            divmail.Visible = True
            divdob.Visible = True
            divgender.Visible = True
            divreln.Visible = False
            divadrs.Visible = True
            dividproof.Visible = True
        ElseIf ddlqckledtype.SelectedValue = "Companion Guest" Then
            divassociate.Visible = True
            divtitle.Visible = True
            divphn.Visible = True
            divmail.Visible = True
            divdob.Visible = False
            divgender.Visible = True
            divreln.Visible = True
            divadrs.Visible = False
            dividproof.Visible = True
        End If
    End Sub

    Protected Sub ddlqckledtype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlqckledtype.TextChanged
        If ddlqckledtype.SelectedValue = "Guest" Then
            divassociate.Visible = False
            divtitle.Visible = True
            divphn.Visible = True
            divmail.Visible = True
            divdob.Visible = True
            divgender.Visible = True
            divreln.Visible = False
            divadrs.Visible = True
            dividproof.Visible = True
        ElseIf ddlqckledtype.SelectedValue = "Companion Guest" Then
            divassociate.Visible = True
            divtitle.Visible = True
            divphn.Visible = True
            divmail.Visible = True
            divdob.Visible = False
            divgender.Visible = True
            divreln.Visible = True
            divadrs.Visible = False
            dividproof.Visible = True
        End If
    End Sub

    Protected Sub txtmainguestcontact_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmainguestcontact.TextChanged
        If txtmainguestcontact.Text <> "" Then
            Dim da As New OdbcDataAdapter("select ledger_name from ledger where phnno='" & txtmainguestcontact.Text & "' and q_led_type='Guest' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
                    txtguestname.Text = ds.Tables(0).Rows(0).Item(0)
                    divval.InnerHtml = gcdsgn.validmsg("ok", "success")
                End If
            Else
                txtledname.Text = ""
                divval.InnerHtml = gcdsgn.validmsg("Wrong phone number", "error")
            End If
        End If
    End Sub
End Class
