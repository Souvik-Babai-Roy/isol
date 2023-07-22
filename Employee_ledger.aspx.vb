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
        Dim da As New OdbcDataAdapter("SELECT id FROM fixed_param where param_type='quick_ledger_type' and param_name='Employee'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        qledtypeid = dt.Rows(0).Item(0)

        Dim primaryid As Integer = 0
        Dim da1 As New OdbcDataAdapter("SELECT primary_id FROM primary_details where primary_name='Direct Expense'", dbcon.con)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        primaryid = dt1.Rows(0).Item(0)


        Dim gend As String = ""
        If rdblgender.SelectedValue.ToString = "Male" Then
            gend = "M"
        ElseIf rdblgender.SelectedValue.ToString = "Female" Then
            gend = "F"
        End If

        Dim mst As Boolean
        If chkmarried.Checked Then
            mst = True
        Else
            mst = False
        End If

        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If

        Dim rescountry As String = ""
        If rblrescountry.SelectedValue.ToString = "India" Then
            rescountry = "India"
        Else
            rescountry = txtrescountry.Text.ToString
        End If

        Dim ctc As Int64 = 0
        ctc = Val(txtbasesal.Text) + Val(txtda.Text) + Val(txthra.Text) + Val(txtallowamnt.Text)



        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO ledger(company_id,company_type_id,q_led_type_id,q_led_type,primary_type_id,primary_type,ledger_title,ledger_name,phnno,email,dob,gender,blood_grp,if_married,per_address,per_pin_code,per_landmark,per_state,per_country,res_address,res_pin_code,res_landmark,res_state,res_country,nationality,id_proof_type,id_proof_no,emergency_contact_person,emergency_contact_number,emergency_contact_address,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,esic_no,health_ins_com,health_ins_no,health_ins_coverage,health_ins_desc,life_ins_com,life_ins_no,life_ins_coverage,life_ins_desc,joing_date,emp_type,desig,basic_sal,da,hra,pf_amount,pf_no,gratuity,allowance_details,allwance_amount,fringe_benefit,gross_sal,created_date,created_by,status,branch_code,franchisee_code) values(?,?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@q_led_type_id", qledtypeid)
            cmd.Parameters.AddWithValue("@q_led_type", "Employee")
            cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
            cmd.Parameters.AddWithValue("@primary_type", "Direct Expense")
            cmd.Parameters.AddWithValue("@ledger_title", ddltitle.SelectedValue)
            cmd.Parameters.AddWithValue("@ledger_name", txtledname.Text.ToString)
            cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
            cmd.Parameters.AddWithValue("@dob", txtdob.Text)
            cmd.Parameters.AddWithValue("@gender", gend)
            cmd.Parameters.AddWithValue("@blood_grp", ddlbloodgrp.SelectedValue)
            cmd.Parameters.AddWithValue("@if_married", mst)
            cmd.Parameters.AddWithValue("@per_address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
            cmd.Parameters.AddWithValue("@per_landmark", txtlocality.Text)
            cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToUpper)
            cmd.Parameters.AddWithValue("@per_country", country)
            If chkbxresadrs.Checked = False Then
                cmd.Parameters.AddWithValue("@res_address", txtresadrs.Text)
                cmd.Parameters.AddWithValue("@res_pin_code", Val(txtrespin.Text))
                cmd.Parameters.AddWithValue("@res_landmark", txtreslandmark.Text)
                cmd.Parameters.AddWithValue("@res_state", txtresstate.Text.ToUpper)
                cmd.Parameters.AddWithValue("@res_country", rescountry)
            Else
                cmd.Parameters.AddWithValue("@res_address", DBNull.Value)
                cmd.Parameters.AddWithValue("@res_pin_code", DBNull.Value)
                cmd.Parameters.AddWithValue("@res_landmark", DBNull.Value)
                cmd.Parameters.AddWithValue("@res_state", DBNull.Value)
                cmd.Parameters.AddWithValue("@res_country", DBNull.Value)
            End If
            cmd.Parameters.AddWithValue("@nationality", txtnationality.Text)
            cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
            cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
            cmd.Parameters.AddWithValue("@emergency_contact_person", txtemcnname.Text)
            cmd.Parameters.AddWithValue("@emergency_contact_number", Val(txtemcnno.Text))
            cmd.Parameters.AddWithValue("@emergency_contact_address", txtemadrs.Text)
            cmd.Parameters.AddWithValue("@bank_name", txtbankname.Text)
            cmd.Parameters.AddWithValue("@ac_no", txtacno.Text)
            cmd.Parameters.AddWithValue("@ac_type", txtactype.Text)
            cmd.Parameters.AddWithValue("@ifsc_code", txtifsccode.Text)
            cmd.Parameters.AddWithValue("@branch_name", txtbranch.Text)
            cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text)
            cmd.Parameters.AddWithValue("@upi_id", txtupiid.Text)
            cmd.Parameters.AddWithValue("@esic_no", txtesic.Text)
            cmd.Parameters.AddWithValue("@health_ins_com", txthealthcom.Text)
            cmd.Parameters.AddWithValue("@health_ins_no", txthealthinsno.Text)
            cmd.Parameters.AddWithValue("@health_ins_coverage", Val(txthealthcov.Text))
            cmd.Parameters.AddWithValue("@health_ins_desc", txthealthdesc.Text)
            cmd.Parameters.AddWithValue("@life_ins_com", txtlifecom.Text)
            cmd.Parameters.AddWithValue("@life_ins_no", txtlifeinsno.Text)
            cmd.Parameters.AddWithValue("@life_ins_coverage", Val(txtlifecov.Text))
            cmd.Parameters.AddWithValue("@life_ins_desc", txtlifedesc.Text)
            cmd.Parameters.AddWithValue("@joing_date", txtjoiningdate.Text)
            cmd.Parameters.AddWithValue("@emp_type", ddlemptype.SelectedValue)
            cmd.Parameters.AddWithValue("@desig", ddldesig.SelectedValue)
            cmd.Parameters.AddWithValue("@basic_sal", Val(txtbasesal.Text))
            cmd.Parameters.AddWithValue("@da", Val(txtda.Text))
            cmd.Parameters.AddWithValue("@hra", Val(txthra.Text))
            cmd.Parameters.AddWithValue("@pf_amount", Val(txtpfamnt.Text))
            cmd.Parameters.AddWithValue("@pf_no", txtpfno.Text)
            cmd.Parameters.AddWithValue("@gratuity", Val(txtgraamnt.Text))
            cmd.Parameters.AddWithValue("@allowance_details", txtallowdet.Text)
            cmd.Parameters.AddWithValue("@allwance_amount", Val(txtallowamnt.Text))
            cmd.Parameters.AddWithValue("@fringe_benefit", txtfriben.Text)
            cmd.Parameters.AddWithValue("@gross_sal", ctc)
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
        If txtjoiningdate.Text <> "" And txtdob.Text <> "" Then

            Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Employee' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                msgct1.InnerHtml = gcdsgn.alertmsg("Employee already Exist", "error")
            Else
                ledgerentry()
                ddltitle.ClearSelection()
                txtledname.Text = ""
                txtphnno.Text = ""
                txtmail.Text = ""
                txtdob.Text = ""
                rdblgender.ClearSelection()
                ddlbloodgrp.ClearSelection()
                chkmarried.Checked = False
                txtaddress.Text = ""
                txtpin.Text = ""
                txtlocality.Text = ""
                txtstate.Text = ""
                rblcountry.ClearSelection()
                txtcountry.Text = ""
                chkbxresadrs.Checked = "false"
                txtresadrs.Text = ""
                txtrespin.Text = ""
                txtreslandmark.Text = ""
                txtresstate.Text = ""
                rblrescountry.ClearSelection()
                txtrescountry.Text = ""
                txtnationality.Text = ""
                ddlidproof.ClearSelection()
                txtidprfno.Text = ""
                txtemcnname.Text = ""
                txtemcnno.Text = ""
                txtemadrs.Text = ""
                txtbankname.Text = ""
                txtacno.Text = ""
                txtactype.Text = ""
                txtifsccode.Text = ""
                txtbranch.Text = ""
                txtpanno.Text = ""
                txtupiid.Text = ""
                txtesic.Text = ""
                txthealthcom.Text = ""
                txthealthinsno.Text = ""
                txthealthcov.Text = ""
                txthealthdesc.Text = ""
                txtlifecom.Text = ""
                txtlifeinsno.Text = ""
                txtlifecov.Text = ""
                txtlifedesc.Text = ""
                txtjoiningdate.Text = ""
                ddlemptype.ClearSelection()
                ddldesig.ClearSelection()
                txtbasesal.Text = ""
                txtda.Text = ""
                txthra.Text = ""
                txtpfamnt.Text = ""
                txtpfno.Text = ""
                txtgraamnt.Text = ""
                txtallowdet.Text = ""
                txtallowamnt.Text = ""
                txtfriben.Text = ""
                txtctc.Text = ""

            End If
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Joining Date", "error")
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,ledger_title as title,ledger_name as emp_name,phnno,email,dob,gender,blood_grp,if_married,per_address,per_pin_code,per_landmark,per_state,per_country,res_address,res_pin_code,res_landmark,res_state,res_country,nationality,id_proof_type,id_proof_no,emergency_contact_person,emergency_contact_number,emergency_contact_address,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,esic_no,health_ins_com,health_ins_no,health_ins_coverage,health_ins_desc,life_ins_com,life_ins_no,life_ins_coverage,life_ins_desc,joing_date,emp_type,desig,basic_sal,da,hra,pf_amount,pf_no,gratuity,allowance_details,allwance_amount,fringe_benefit,gross_sal,status FROM ledger where company_id='" & Session("comid") & "' and q_led_type='Employee' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,ledger_title as title,ledger_name as emp_name,phnno,email,dob,gender,blood_grp,if_married,per_address,per_pin_code,per_landmark,per_state,per_country,res_address,res_pin_code,res_landmark,res_state,res_country,nationality,id_proof_type,id_proof_no,emergency_contact_person,emergency_contact_number,emergency_contact_address,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,esic_no,health_ins_com,health_ins_no,health_ins_coverage,health_ins_desc,life_ins_com,life_ins_no,life_ins_coverage,life_ins_desc,joing_date,emp_type,desig,basic_sal,da,hra,pf_amount,pf_no,gratuity,allowance_details,allwance_amount,fringe_benefit,gross_sal,status FROM ledger where upper(ledger_name) like upper('%" & txtsearchname.Text & "%') and q_led_type='Employee' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT ledger_title,ledger_name,phnno,email,dob,gender,blood_grp,if_married,per_address,per_pin_code,per_landmark,per_state,per_country,res_address,res_pin_code,res_landmark,res_state,res_country,nationality,id_proof_type,id_proof_no,emergency_contact_person,emergency_contact_number,emergency_contact_address,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,esic_no,health_ins_com,health_ins_no,health_ins_coverage,health_ins_desc,life_ins_com,life_ins_no,life_ins_coverage,life_ins_desc,joing_date,emp_type,desig,basic_sal,da,hra,pf_amount,pf_no,gratuity,allowance_details,allwance_amount,fringe_benefit,gross_sal,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Employee' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
            ddltitle.Text = ds.Tables(0).Rows(0).Item(0)
        End If
        If ds.Tables(0).Rows(0).Item(1) IsNot DBNull.Value Then
            txtledname.Text = ds.Tables(0).Rows(0).Item(1)
            txtledname.Attributes("disabled") = "disabled"
        End If
        If ds.Tables(0).Rows(0).Item(2) IsNot DBNull.Value Then
            txtphnno.Text = ds.Tables(0).Rows(0).Item(2)
        End If
        If ds.Tables(0).Rows(0).Item(3) IsNot DBNull.Value Then
            txtmail.Text = ds.Tables(0).Rows(0).Item(3)
        End If
        If ds.Tables(0).Rows(0).Item(4) IsNot DBNull.Value Then
            txtdob.Text = ds.Tables(0).Rows(0).Item(4)
        End If
        If ds.Tables(0).Rows(0).Item(5) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(5) = "M" Then
                rdblgender.Text = "Male"
            Else
                rdblgender.Text = "Female"
            End If
        End If
        If ds.Tables(0).Rows(0).Item(6) IsNot DBNull.Value Then
            ddlbloodgrp.Text = ds.Tables(0).Rows(0).Item(6)
        End If
        If ds.Tables(0).Rows(0).Item(7) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(7) = "1" Then
                chkmarried.Checked = True
            Else
                chkmarried.Checked = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item(8) IsNot DBNull.Value Then
            txtaddress.Text = ds.Tables(0).Rows(0).Item(8)
        End If
        If ds.Tables(0).Rows(0).Item(9) IsNot DBNull.Value Then
            txtpin.Text = ds.Tables(0).Rows(0).Item(9)
        End If
        If ds.Tables(0).Rows(0).Item(10) IsNot DBNull.Value Then
            txtlocality.Text = ds.Tables(0).Rows(0).Item(10)
        End If
        If ds.Tables(0).Rows(0).Item(11) IsNot DBNull.Value Then
            txtstate.Text = ds.Tables(0).Rows(0).Item(11)
        End If
        If ds.Tables(0).Rows(0).Item(12) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(12) = "India" Then
                rblcountry.Text = "India"
            Else
                rblcountry.Text = "Other (*Please Specify)"
                txtcountry.Text = ds.Tables(0).Rows(0).Item(12)
            End If

        End If
        If ds.Tables(0).Rows(0).Item(13) IsNot DBNull.Value Then
            txtresadrs.Text = ds.Tables(0).Rows(0).Item(13)
        Else
            chkbxresadrs.Checked = True
            divresaddress.Visible = False
        End If
        If ds.Tables(0).Rows(0).Item(14) IsNot DBNull.Value Then
            txtrespin.Text = ds.Tables(0).Rows(0).Item(14)
        End If
        If ds.Tables(0).Rows(0).Item(15) IsNot DBNull.Value Then
            txtreslandmark.Text = ds.Tables(0).Rows(0).Item(15)
        End If
        If ds.Tables(0).Rows(0).Item(16) IsNot DBNull.Value Then
            txtresstate.Text = ds.Tables(0).Rows(0).Item(16)
        End If
        If ds.Tables(0).Rows(0).Item(17) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(17) = "India" Then
                rblrescountry.Text = "India"
            Else
                rblrescountry.Text = "Other (*Please Specify)"
                txtrescountry.Text = ds.Tables(0).Rows(0).Item(17)
            End If
        End If
        If ds.Tables(0).Rows(0).Item(18) IsNot DBNull.Value Then
            txtnationality.Text = ds.Tables(0).Rows(0).Item(18)
        End If
        If ds.Tables(0).Rows(0).Item(19) IsNot DBNull.Value Then
            ddlidproof.Text = ds.Tables(0).Rows(0).Item(19)
        End If
        If ds.Tables(0).Rows(0).Item(20) IsNot DBNull.Value Then
            txtidprfno.Text = ds.Tables(0).Rows(0).Item(20)
        End If
        If ds.Tables(0).Rows(0).Item(21) IsNot DBNull.Value Then
            txtemcnname.Text = ds.Tables(0).Rows(0).Item(21)
        End If
        If ds.Tables(0).Rows(0).Item(22) IsNot DBNull.Value Then
            txtemcnno.Text = ds.Tables(0).Rows(0).Item(22)
        End If
        If ds.Tables(0).Rows(0).Item(23) IsNot DBNull.Value Then
            txtemadrs.Text = ds.Tables(0).Rows(0).Item(23)
        End If
        If ds.Tables(0).Rows(0).Item(24) IsNot DBNull.Value Then
            txtbankname.Text = ds.Tables(0).Rows(0).Item(24)
        End If
        If ds.Tables(0).Rows(0).Item(25) IsNot DBNull.Value Then
            txtacno.Text = ds.Tables(0).Rows(0).Item(25)
        End If
        If ds.Tables(0).Rows(0).Item(26) IsNot DBNull.Value Then
            txtactype.Text = ds.Tables(0).Rows(0).Item(26)
        End If
        If ds.Tables(0).Rows(0).Item(27) IsNot DBNull.Value Then
            txtifsccode.Text = ds.Tables(0).Rows(0).Item(27)
        End If
        If ds.Tables(0).Rows(0).Item(28) IsNot DBNull.Value Then
            txtbranch.Text = ds.Tables(0).Rows(0).Item(28)
        End If
        If ds.Tables(0).Rows(0).Item(29) IsNot DBNull.Value Then
            txtpanno.Text = ds.Tables(0).Rows(0).Item(29)
        End If
        If ds.Tables(0).Rows(0).Item(30) IsNot DBNull.Value Then
            txtupiid.Text = ds.Tables(0).Rows(0).Item(30)
        End If
        If ds.Tables(0).Rows(0).Item(31) IsNot DBNull.Value Then
            txtesic.Text = ds.Tables(0).Rows(0).Item(31)
        End If
        If ds.Tables(0).Rows(0).Item(32) IsNot DBNull.Value Then
            txthealthcom.Text = ds.Tables(0).Rows(0).Item(32)
        End If
        If ds.Tables(0).Rows(0).Item(33) IsNot DBNull.Value Then
            txthealthinsno.Text = ds.Tables(0).Rows(0).Item(33)
        End If
        If ds.Tables(0).Rows(0).Item(34) IsNot DBNull.Value Then
            txthealthcov.Text = ds.Tables(0).Rows(0).Item(34)
        End If
        If ds.Tables(0).Rows(0).Item(35) IsNot DBNull.Value Then
            txthealthdesc.Text = ds.Tables(0).Rows(0).Item(35)
        End If
        If ds.Tables(0).Rows(0).Item(36) IsNot DBNull.Value Then
            txtlifecom.Text = ds.Tables(0).Rows(0).Item(36)
        End If
        If ds.Tables(0).Rows(0).Item(37) IsNot DBNull.Value Then
            txtlifeinsno.Text = ds.Tables(0).Rows(0).Item(37)
        End If
        If ds.Tables(0).Rows(0).Item(38) IsNot DBNull.Value Then
            txtlifecov.Text = ds.Tables(0).Rows(0).Item(38)
        End If
        If ds.Tables(0).Rows(0).Item(39) IsNot DBNull.Value Then
            txtlifedesc.Text = ds.Tables(0).Rows(0).Item(39)
        End If
        If ds.Tables(0).Rows(0).Item(40) IsNot DBNull.Value Then
            txtjoiningdate.Text = ds.Tables(0).Rows(0).Item(40)
        End If
        If ds.Tables(0).Rows(0).Item(41) IsNot DBNull.Value Then
            ddlemptype.Text = ds.Tables(0).Rows(0).Item(41)
        End If
        If ds.Tables(0).Rows(0).Item(42) IsNot DBNull.Value Then
            ddldesig.Text = ds.Tables(0).Rows(0).Item(42)
        End If
        If ds.Tables(0).Rows(0).Item(43) IsNot DBNull.Value Then
            txtbasesal.Text = ds.Tables(0).Rows(0).Item(43)
        End If
        If ds.Tables(0).Rows(0).Item(44) IsNot DBNull.Value Then
            txtda.Text = ds.Tables(0).Rows(0).Item(44)
        End If
        If ds.Tables(0).Rows(0).Item(45) IsNot DBNull.Value Then
            txthra.Text = ds.Tables(0).Rows(0).Item(45)
        End If
        If ds.Tables(0).Rows(0).Item(46) IsNot DBNull.Value Then
            txtpfamnt.Text = ds.Tables(0).Rows(0).Item(46)
        End If
        If ds.Tables(0).Rows(0).Item(47) IsNot DBNull.Value Then
            txtpfno.Text = ds.Tables(0).Rows(0).Item(47)
        End If
        If ds.Tables(0).Rows(0).Item(48) IsNot DBNull.Value Then
            txtgraamnt.Text = ds.Tables(0).Rows(0).Item(48)
        End If
        If ds.Tables(0).Rows(0).Item(49) IsNot DBNull.Value Then
            txtallowdet.Text = ds.Tables(0).Rows(0).Item(49)
        End If
        If ds.Tables(0).Rows(0).Item(50) IsNot DBNull.Value Then
            txtallowamnt.Text = ds.Tables(0).Rows(0).Item(50)
        End If
        If ds.Tables(0).Rows(0).Item(51) IsNot DBNull.Value Then
            txtfriben.Text = ds.Tables(0).Rows(0).Item(51)
        End If
        If ds.Tables(0).Rows(0).Item(52) IsNot DBNull.Value Then
            txtctc.Text = ds.Tables(0).Rows(0).Item(52)
        End If
        If ds.Tables(0).Rows(0).Item(53) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(53) <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item(53)
            End If
        End If
    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,ledger_title as title,ledger_name as emp_name,phnno,email,dob,gender,blood_grp,if_married,per_address,per_pin_code,per_landmark,per_state,per_country,res_address,res_pin_code,res_landmark,res_state,res_country,nationality,id_proof_type,id_proof_no,emergency_contact_person,emergency_contact_number,emergency_contact_address,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,upi_id,esic_no,health_ins_com,health_ins_no,health_ins_coverage,health_ins_desc,life_ins_com,life_ins_no,life_ins_coverage,life_ins_desc,joing_date,emp_type,desig,basic_sal,da,hra,pf_amount,pf_no,gratuity,allowance_details,allwance_amount,fringe_benefit,gross_sal,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Employee' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
                    msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Employee ID", "error")
                End If
            Else
                grdvleddetails.DataSource = Nothing
                grdvleddetails.DataBind()
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Employee ID", "error")
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

        Dim mst As Boolean
        If chkmarried.Checked Then
            mst = True
        Else
            mst = False
        End If

        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If

        Dim rescountry As String = ""
        If rblrescountry.SelectedValue.ToString = "India" Then
            rescountry = "India"
        Else
            rescountry = txtrescountry.Text.ToString
        End If

        Dim ctc As Int64 = 0
        ctc = Val(txtbasesal.Text) + Val(txtda.Text) + Val(txthra.Text) + Val(txtallowamnt.Text)

        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set ledger_title=?,phnno=?,email=?,dob=?,gender=?,blood_grp=?,if_married=?,per_address=?,per_pin_code=?,per_landmark=?,per_state=?,per_country=?,res_address=?,res_pin_code=?,res_landmark=?,res_state=?,res_country=?,nationality=?,id_proof_type=?,id_proof_no=?,emergency_contact_person=?,emergency_contact_number=?,emergency_contact_address=?,bank_name=?,ac_no=?,ac_type=?,ifsc_code=?,branch_name=?,pan_no=?,upi_id=?,esic_no=?,health_ins_com=?,health_ins_no=?,health_ins_coverage=?,health_ins_desc=?,life_ins_com=?,life_ins_no=?,life_ins_coverage=?,life_ins_desc=?,joing_date=?,emp_type=?,desig=?,basic_sal=?,da=?,hra=?,pf_amount=?,pf_no=?,gratuity=?,allowance_details=?,allwance_amount=?,fringe_benefit=?,gross_sal=?,modified_date=?,modified_by=?,status=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='Employee' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@ledger_title", ddltitle.SelectedValue)
        cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
        cmd.Parameters.AddWithValue("@email", txtmail.Text.ToString)
        cmd.Parameters.AddWithValue("@dob", txtdob.Text)
        cmd.Parameters.AddWithValue("@gender", gend)
        cmd.Parameters.AddWithValue("@blood_grp", ddlbloodgrp.SelectedValue)
        cmd.Parameters.AddWithValue("@if_married", mst)
        cmd.Parameters.AddWithValue("@per_address", txtaddress.Text)
        cmd.Parameters.AddWithValue("@per_pin_code", Val(txtpin.Text))
        cmd.Parameters.AddWithValue("@per_landmark", txtlocality.Text)
        cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToUpper)
        cmd.Parameters.AddWithValue("@per_country", country)
        If chkbxresadrs.Checked = False Then
            cmd.Parameters.AddWithValue("@res_address", txtresadrs.Text)
            cmd.Parameters.AddWithValue("@res_pin_code", Val(txtrespin.Text))
            cmd.Parameters.AddWithValue("@res_landmark", txtreslandmark.Text)
            cmd.Parameters.AddWithValue("@res_state", txtresstate.Text.ToUpper)
            cmd.Parameters.AddWithValue("@res_country", rescountry)
        Else
            cmd.Parameters.AddWithValue("@res_address", DBNull.Value)
            cmd.Parameters.AddWithValue("@res_pin_code", DBNull.Value)
            cmd.Parameters.AddWithValue("@res_landmark", DBNull.Value)
            cmd.Parameters.AddWithValue("@res_state", DBNull.Value)
            cmd.Parameters.AddWithValue("@res_country", DBNull.Value)
        End If
        cmd.Parameters.AddWithValue("@nationality", txtnationality.Text)
        cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
        cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
        cmd.Parameters.AddWithValue("@emergency_contact_person", txtemcnname.Text)
        cmd.Parameters.AddWithValue("@emergency_contact_number", Val(txtemcnno.Text))
        cmd.Parameters.AddWithValue("@emergency_contact_address", txtemadrs.Text)
        cmd.Parameters.AddWithValue("@bank_name", txtbankname.Text)
        cmd.Parameters.AddWithValue("@ac_no", txtacno.Text)
        cmd.Parameters.AddWithValue("@ac_type", txtactype.Text)
        cmd.Parameters.AddWithValue("@ifsc_code", txtifsccode.Text)
        cmd.Parameters.AddWithValue("@branch_name", txtbranch.Text)
        cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text)
        cmd.Parameters.AddWithValue("@upi_id", txtupiid.Text)
        cmd.Parameters.AddWithValue("@esic_no", txtesic.Text)
        cmd.Parameters.AddWithValue("@health_ins_com", txthealthcom.Text)
        cmd.Parameters.AddWithValue("@health_ins_no", txthealthinsno.Text)
        cmd.Parameters.AddWithValue("@health_ins_coverage", Val(txthealthcov.Text))
        cmd.Parameters.AddWithValue("@health_ins_desc", txthealthdesc.Text)
        cmd.Parameters.AddWithValue("@life_ins_com", txtlifecom.Text)
        cmd.Parameters.AddWithValue("@life_ins_no", txtlifeinsno.Text)
        cmd.Parameters.AddWithValue("@life_ins_coverage", Val(txtlifecov.Text))
        cmd.Parameters.AddWithValue("@life_ins_desc", txtlifedesc.Text)
        cmd.Parameters.AddWithValue("@joing_date", txtjoiningdate.Text)
        cmd.Parameters.AddWithValue("@emp_type", ddlemptype.SelectedValue)
        cmd.Parameters.AddWithValue("@desig", ddldesig.SelectedValue)
        cmd.Parameters.AddWithValue("@basic_sal", Val(txtbasesal.Text))
        cmd.Parameters.AddWithValue("@da", Val(txtda.Text))
        cmd.Parameters.AddWithValue("@hra", Val(txthra.Text))
        cmd.Parameters.AddWithValue("@pf_amount", Val(txtpfamnt.Text))
        cmd.Parameters.AddWithValue("@pf_no", txtpfno.Text)
        cmd.Parameters.AddWithValue("@gratuity", Val(txtgraamnt.Text))
        cmd.Parameters.AddWithValue("@allowance_details", txtallowdet.Text)
        cmd.Parameters.AddWithValue("@allwance_amount", Val(txtallowamnt.Text))
        cmd.Parameters.AddWithValue("@fringe_benefit", txtfriben.Text)
        cmd.Parameters.AddWithValue("@gross_sal", ctc)
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
            ddltitle.ClearSelection()
            txtledname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtdob.Text = ""
            rdblgender.ClearSelection()
            ddlbloodgrp.ClearSelection()
            chkmarried.Checked = False
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlocality.Text = ""
            txtstate.Text = ""
            rblcountry.ClearSelection()
            txtcountry.Text = ""
            chkbxresadrs.Checked = "false"
            txtresadrs.Text = ""
            txtrespin.Text = ""
            txtreslandmark.Text = ""
            txtresstate.Text = ""
            rblrescountry.ClearSelection()
            txtrescountry.Text = ""
            txtnationality.Text = ""
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
            txtemcnname.Text = ""
            txtemcnno.Text = ""
            txtemadrs.Text = ""
            txtbankname.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtpanno.Text = ""
            txtupiid.Text = ""
            txtesic.Text = ""
            txthealthcom.Text = ""
            txthealthinsno.Text = ""
            txthealthcov.Text = ""
            txthealthdesc.Text = ""
            txtlifecom.Text = ""
            txtlifeinsno.Text = ""
            txtlifecov.Text = ""
            txtlifedesc.Text = ""
            txtjoiningdate.Text = ""
            ddlemptype.ClearSelection()
            ddldesig.ClearSelection()
            txtbasesal.Text = ""
            txtda.Text = ""
            txthra.Text = ""
            txtpfamnt.Text = ""
            txtpfno.Text = ""
            txtgraamnt.Text = ""
            txtallowdet.Text = ""
            txtallowamnt.Text = ""
            txtfriben.Text = ""
            txtctc.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Employee ID to Update", "error")
        End If
    End Sub

    Private Sub deleteledger()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set status='Inactive' where ledger_id='" & txtsearchname.Text & "' and q_led_type='Employee' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Employee Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            ddltitle.ClearSelection()
            txtledname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtdob.Text = ""
            rdblgender.ClearSelection()
            ddlbloodgrp.ClearSelection()
            chkmarried.Checked = False
            txtaddress.Text = ""
            txtpin.Text = ""
            txtlocality.Text = ""
            txtstate.Text = ""
            rblcountry.ClearSelection()
            txtcountry.Text = ""
            chkbxresadrs.Checked = "false"
            txtresadrs.Text = ""
            txtrespin.Text = ""
            txtreslandmark.Text = ""
            txtresstate.Text = ""
            rblrescountry.ClearSelection()
            txtrescountry.Text = ""
            txtnationality.Text = ""
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
            txtemcnname.Text = ""
            txtemcnno.Text = ""
            txtemadrs.Text = ""
            txtbankname.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtpanno.Text = ""
            txtupiid.Text = ""
            txtesic.Text = ""
            txthealthcom.Text = ""
            txthealthinsno.Text = ""
            txthealthcov.Text = ""
            txthealthdesc.Text = ""
            txtlifecom.Text = ""
            txtlifeinsno.Text = ""
            txtlifecov.Text = ""
            txtlifedesc.Text = ""
            txtjoiningdate.Text = ""
            ddlemptype.ClearSelection()
            ddldesig.ClearSelection()
            txtbasesal.Text = ""
            txtda.Text = ""
            txthra.Text = ""
            txtpfamnt.Text = ""
            txtpfno.Text = ""
            txtgraamnt.Text = ""
            txtallowdet.Text = ""
            txtallowamnt.Text = ""
            txtfriben.Text = ""
            txtctc.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Customer ID to Delete", "error")
        End If
    End Sub

    Public Sub lblloads()
        If chkmarried.Checked Then
            lblchkmarried.InnerText = "Married"
        Else
            lblchkmarried.InnerText = "Unmarried"
        End If

        If chkbxresadrs.Checked Then
            divresaddress.Visible = False
        Else
            divresaddress.Visible = True
        End If
        If rblcountry.SelectedValue.ToString = "India" Then
            txtcountry.ReadOnly = True
        Else
            txtcountry.ReadOnly = False
        End If
        If rblrescountry.SelectedValue.ToString = "India" Then
            txtrescountry.ReadOnly = True
        Else
            txtrescountry.ReadOnly = False
        End If
        If chkbxemgc.Checked = True Then
            lblchkbxemgc.InnerText="Yes"
        Else
            lblchkbxemgc.InnerText = "No"
        End If
        If chkbxbank.Checked = True Then
            lblchkbxbank.InnerText = "Yes"
        Else
            lblchkbxbank.InnerText = "No"
        End If
        If chkbxhealth.Checked = True Then
            lblchkbxhealth.InnerText = "Yes"
        Else
            lblchkbxhealth.InnerText = "No"
        End If
        If chkbxlife.Checked = True Then
            lblchkbxlife.InnerText = "Yes"
        Else
            lblchkbxlife.InnerText = "No"
        End If
        If chkbxjob.Checked = True Then
            lblchkbxjob.InnerText = "Yes"
        Else
            lblchkbxjob.InnerText = "No"
        End If
        If chkbxhra.Checked = True Then
            lblchkbxhra.InnerText = "Yes"
        Else
            lblchkbxhra.InnerText = "No"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            dbcon.employeedesignation(ddldesig, Session("comid"))
        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            valmsg.InnerText = ""
        End If
        grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White

        lblloads()

    End Sub


    Protected Sub txtledname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtledname.TextChanged
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Employee' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Customer already Exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub

    Protected Sub txtphnno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtphnno.TextChanged
        If txtphnno.Text <> "" Then
            Dim da As New OdbcDataAdapter("select ledger_title,ledger_name from ledger where phnno='" & txtphnno.Text & "' and company_id='" & Session("comid") & "' and q_led_type='Employee'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item(1) IsNot DBNull.Value Then
                    txtledname.Text = ds.Tables(0).Rows(0).Item(1)
                End If
                If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
                    ddltitle.Text = ds.Tables(0).Rows(0).Item(0)
                End If
            End If
        End If
    End Sub

    Protected Sub chkbxresadrs_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxresadrs.ServerChange
        If chkbxresadrs.Checked Then
            divresaddress.Visible = False
        Else
            divresaddress.Visible = True
        End If
    End Sub


    Protected Sub chkbxresadrs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxresadrs.Load
        If chkbxresadrs.Checked Then
            divresaddress.Visible = False
        Else
            divresaddress.Visible = True
        End If
    End Sub

    Protected Sub txtbasesal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbasesal.TextChanged
        If txtbasesal.Text <> "" Then
            txtctc.Text = Val(txtctc.Text) + Val(txtbasesal.Text)
        End If
        
    End Sub

    Protected Sub txtda_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtda.TextChanged
        If txtda.Text <> "" Then
            txtctc.Text = Val(txtctc.Text) + Val(txtda.Text)
        End If
    End Sub

    Protected Sub txthra_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthra.TextChanged
        If txthra.Text <> "" Then
            txtctc.Text = Val(txtctc.Text) + Val(txthra.Text)
        End If
    End Sub

    Protected Sub txtallowamnt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtallowamnt.TextChanged
        If txtallowamnt.Text <> "" Then
            txtctc.Text = Val(txtctc.Text) + Val(txtallowamnt.Text)
        End If
    End Sub

    Protected Sub rblcountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblcountry.SelectedIndexChanged
        If rblcountry.SelectedValue.ToString = "India" Then
            txtcountry.ReadOnly = True
        Else
            txtcountry.ReadOnly = False
        End If
    End Sub

    Protected Sub rblrescountry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblrescountry.Load
        If rblrescountry.SelectedValue.ToString = "India" Then
            txtrescountry.ReadOnly = True
        Else
            txtrescountry.ReadOnly = False
        End If
    End Sub

    Protected Sub rblrescountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblrescountry.SelectedIndexChanged
        If rblrescountry.SelectedValue.ToString = "India" Then
            txtrescountry.ReadOnly = True
        Else
            txtrescountry.ReadOnly = False
        End If
    End Sub

    Protected Sub chkbxemgc_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxemgc.ServerChange
        If chkbxemgc.Checked = True Then
            divemergency.Visible = True
        Else
            divemergency.Visible = False
        End If
    End Sub

    Protected Sub chkbxbank_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxbank.ServerChange
        If chkbxbank.Checked = True Then
            divbank.Visible = True
        Else
            divbank.Visible = False
        End If
    End Sub

    Protected Sub chkbxhealth_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxhealth.ServerChange
        If chkbxhealth.Checked = True Then
            divhealth.Visible = True
        Else
            divhealth.Visible = False
        End If
    End Sub

    Protected Sub chkbxlife_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxlife.ServerChange
        If chkbxlife.Checked = True Then
            divlife.Visible = True
        Else
            divlife.Visible = False
        End If
    End Sub

    Protected Sub chkbxjob_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxjob.ServerChange
        If chkbxjob.Checked = True Then
            divjobinfo.Visible = True
        Else
            divjobinfo.Visible = False
        End If
    End Sub

    Protected Sub chkbxhra_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxhra.ServerChange
        If chkbxhra.Checked = True Then
            divhra.Visible = True
        Else
            divhra.Visible = False
        End If
    End Sub

    Public Function idformatone() As String
        Dim ss As StringBuilder = New StringBuilder()
        Dim htmltext As String
        Dim p As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")

        Dim da As New OdbcDataAdapter("SELECT * FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Employee' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        Dim da1 As New OdbcDataAdapter("select * from company_details where id='" & Session("comid") & "'", dbcon.con)
        Dim ds1 As New DataSet
        da1.Fill(ds1)

        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")

        ss.Append("<div class='id-card-holder'>")
        ss.Append("<div class='id-card'>")
        ss.Append("<div class='header'><img src='" & p & "img/letterhead.jpg'></div>")
        ss.Append("<div class='photo'><img src='" & p & "img/employee_img.jpg'></div>")
        ss.Append("<h2>" & ds.Tables(0).Rows(0).Item("ledger_name") & "</h2>")
        ss.Append("<p style='font-size: 14px;'>" & ds.Tables(0).Rows(0).Item("phnno") & "</p>")
        ss.Append("<div class='qr-code'><img src='http://www.coreitechconsultancy.com/assets/img/service.svg'></div>")
        ss.Append("<h3>" & ds1.Tables(0).Rows(0).Item("company_name") & "</h3>")
        ss.Append("<hr><p>" & ds1.Tables(0).Rows(0).Item("address") & "</p>")
        ss.Append("<p>Ph: " & ds1.Tables(0).Rows(0).Item("phone_no") & " | E-mail: " & ds1.Tables(0).Rows(0).Item("email_id") & "</p>")
        ss.Append("</div>")
        ss.Append("</div>")
        ss.Append("")
        ss.Append("")
        

        ss.Append("</div>")
        ss.Append("</div>")
        htmltext = ss.ToString
        Return htmltext
    End Function

    Protected Sub btndocument_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndocument.ServerClick
        viewreg.InnerHtml = idformatone.ToString
    End Sub

End Class
