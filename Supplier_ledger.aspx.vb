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
        Dim da As New OdbcDataAdapter("SELECT id FROM fixed_param where param_type='quick_ledger_type' and param_name='Supplier'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        qledtypeid = dt.Rows(0).Item(0)

        Dim primaryid As Integer = 0
        Dim da1 As New OdbcDataAdapter("SELECT primary_id FROM primary_details where primary_name='Indirect Income'", dbcon.con)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        primaryid = dt1.Rows(0).Item(0)

        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO ledger(company_id,company_type_id,q_led_type_id,q_led_type,primary_type_id,primary_type,ledger_name,phnno,email,website,per_address,per_pin_code,per_landmark,per_state,per_country,id_proof_type,id_proof_no,comp_name,gstno,invoice_address,open_bal,close_bal,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,tan_no,upi_id,created_date,created_by,status,branch_code,franchisee_code) values(?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@q_led_type_id", qledtypeid)
            cmd.Parameters.AddWithValue("@q_led_type", "Supplier")
            cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
            cmd.Parameters.AddWithValue("@primary_type", "Indirect Income")
            cmd.Parameters.AddWithValue("@ledger_name", txtledname.Text.ToString)
            cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text)
            cmd.Parameters.AddWithValue("@website", txtwebsite.text)
            cmd.Parameters.AddWithValue("@per_address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@per_pin_code", Val(txtzip.Text))
            cmd.Parameters.AddWithValue("@per_landmark", txtlocality.Text)
            cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToUpper)
            cmd.Parameters.AddWithValue("@per_country", country)
            cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
            cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
            cmd.Parameters.AddWithValue("@comp_name", txtcompany.Text)
            cmd.Parameters.AddWithValue("@gstno", txtgstno.Text)
            cmd.Parameters.AddWithValue("@invoice_address", txtinvoice.Text)
            cmd.Parameters.AddWithValue("@open_bal", Val(txtopenbal.Text))
            cmd.Parameters.AddWithValue("@close_bal", Val(txtclosebal.Text))
            cmd.Parameters.AddWithValue("@bank_name", txtbank.Text.ToString)
            cmd.Parameters.AddWithValue("@ac_no", txtacno.Text)
            cmd.Parameters.AddWithValue("@ac_type", txtactype.text)
            cmd.Parameters.AddWithValue("@ifsc_code", txtifsccode.Text)
            cmd.Parameters.AddWithValue("@branch_name", txtbranch.Text.ToString)
            cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text)
            cmd.Parameters.AddWithValue("@tan_no", txttanno.text)
            cmd.Parameters.AddWithValue("@upi_id", txtupiid.Text)
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
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Supplier' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Supplier already Exist", "error")
        Else
            ledgerentry()
            txtledname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtwebsite.Text = ""
            txtaddress.Text = ""
            txtzip.Text = ""
            txtcountry.Text = ""
            rblcountry.ClearSelection()
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
            txtcompany.Text = ""
            txtgstno.Text = ""
            txtinvoice.Text = ""
            txtopenbal.Text = ""
            txtclosebal.Text = ""
            txtbank.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtpanno.Text = ""
            txtupiid.Text = ""

        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id as supplier_id,q_led_type,primary_type,ledger_name,phnno,email,website,per_address,per_pin_code,per_landmark,per_state,per_country,id_proof_type,id_proof_no,comp_name,gstno,invoice_address,open_bal,close_bal,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,tan_no,upi_id,status FROM ledger where company_id='" & Session("comid") & "' and q_led_type='Supplier' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT ledger_id as supplier_id,q_led_type,primary_type,ledger_name,phnno,email,website,per_address,per_pin_code,per_landmark,per_state,per_country,id_proof_type,id_proof_no,comp_name,gstno,invoice_address,open_bal,close_bal,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,tan_no,upi_id,status FROM ledger where upper(ledger_name) like upper('%" & txtsearchname.Text & "%') and q_led_type='Supplier' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT ledger_name,phnno,email,website,per_address,per_pin_code,per_landmark,per_state,per_country,id_proof_type,id_proof_no,comp_name,gstno,invoice_address,open_bal,close_bal,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,tan_no,upi_id,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Supplier' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
            txtledname.Text = ds.Tables(0).Rows(0).Item(0)
            txtledname.Attributes("disabled") = "disabled"
        End If
        If ds.Tables(0).Rows(0).Item(1) IsNot DBNull.Value Then
            txtphnno.Text = ds.Tables(0).Rows(0).Item(1)
        End If
        If ds.Tables(0).Rows(0).Item(2) IsNot DBNull.Value Then
            txtmail.Text = ds.Tables(0).Rows(0).Item(2)
        End If
        If ds.Tables(0).Rows(0).Item(3) IsNot DBNull.Value Then
            txtwebsite.Text = ds.Tables(0).Rows(0).Item(3)
        End If
        If ds.Tables(0).Rows(0).Item(4) IsNot DBNull.Value Then
            txtaddress.Text = ds.Tables(0).Rows(0).Item(4)
        End If
        If ds.Tables(0).Rows(0).Item(5) IsNot DBNull.Value Then
            txtzip.Text = ds.Tables(0).Rows(0).Item(5)
        End If
        If ds.Tables(0).Rows(0).Item(6) IsNot DBNull.Value Then
            txtlocality.Text = ds.Tables(0).Rows(0).Item(6)
        End If
        If ds.Tables(0).Rows(0).Item(7) IsNot DBNull.Value Then
            txtstate.Text = ds.Tables(0).Rows(0).Item(7)
        End If
        If ds.Tables(0).Rows(0).Item(8) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(8) = "India" Then
                rblcountry.Text = "India"
            Else
                rblcountry.Text = "Other (*Please Specify)"
                txtcountry.Text = ds.Tables(0).Rows(0).Item(8)
            End If
        End If
        If ds.Tables(0).Rows(0).Item(9) IsNot DBNull.Value Then
            ddlidproof.Text = ds.Tables(0).Rows(0).Item(9)
        End If
        If ds.Tables(0).Rows(0).Item(10) IsNot DBNull.Value Then
            txtidprfno.Text = ds.Tables(0).Rows(0).Item(10)
        End If
        If ds.Tables(0).Rows(0).Item(11) IsNot DBNull.Value Then
            txtcompany.Text = ds.Tables(0).Rows(0).Item(11)
        End If
        If ds.Tables(0).Rows(0).Item(12) IsNot DBNull.Value Then
            txtgstno.Text = ds.Tables(0).Rows(0).Item(12)
        End If
        If ds.Tables(0).Rows(0).Item(13) IsNot DBNull.Value Then
            txtinvoice.Text = ds.Tables(0).Rows(0).Item(13)
        End If
        If ds.Tables(0).Rows(0).Item(14) IsNot DBNull.Value Then
            txtopenbal.Text = ds.Tables(0).Rows(0).Item(14)
        End If
        If ds.Tables(0).Rows(0).Item(15) IsNot DBNull.Value Then
            txtclosebal.Text = ds.Tables(0).Rows(0).Item(15)
        End If
        If ds.Tables(0).Rows(0).Item(16) IsNot DBNull.Value Then
            txtbank.Text = ds.Tables(0).Rows(0).Item(16)
        End If
        If ds.Tables(0).Rows(0).Item(17) IsNot DBNull.Value Then
            txtacno.Text = ds.Tables(0).Rows(0).Item(17)
        End If
        If ds.Tables(0).Rows(0).Item(18) IsNot DBNull.Value Then
            txtactype.Text = ds.Tables(0).Rows(0).Item(18)
        End If
        If ds.Tables(0).Rows(0).Item(19) IsNot DBNull.Value Then
            txtifsccode.Text = ds.Tables(0).Rows(0).Item(19)
        End If
        If ds.Tables(0).Rows(0).Item(20) IsNot DBNull.Value Then
            txtbranch.Text = ds.Tables(0).Rows(0).Item(20)
        End If
        If ds.Tables(0).Rows(0).Item(21) IsNot DBNull.Value Then
            txtpanno.Text = ds.Tables(0).Rows(0).Item(21)
        End If
        If ds.Tables(0).Rows(0).Item(22) IsNot DBNull.Value Then
            txttanno.Text = ds.Tables(0).Rows(0).Item(22)
        End If
        If ds.Tables(0).Rows(0).Item(23) IsNot DBNull.Value Then
            txtupiid.Text = ds.Tables(0).Rows(0).Item(23)
        End If
        If ds.Tables(0).Rows(0).Item(24) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(3) <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item(24)
            End If
        End If
    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id as supplier_id,q_led_type,primary_type,ledger_name,phnno,email,website,per_address,per_pin_code,per_landmark,per_state,per_country,id_proof_type,id_proof_no,comp_name,gstno,invoice_address,open_bal,close_bal,bank_name,ac_no,ac_type,ifsc_code,branch_name,pan_no,tan_no,upi_id,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Supplier' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
                    txtsearchname.ReadOnly = True
                Else
                    msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Supplier ID", "error")
                End If
            Else
                grdvleddetails.DataSource = Nothing
                grdvleddetails.DataBind()
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Supplier ID", "error")
            End If
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Private Sub updateinfo()
        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If

        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set phnno=?,email=?,website=?,per_address=?,per_pin_code=?,per_landmark=?,per_state=?,per_country=?,id_proof_type=?,id_proof_no=?,comp_name=?,gstno=?,invoice_address=?,open_bal=?,close_bal=?,bank_name=?,ac_no=?,ac_type=?,ifsc_code=?,branch_name=?,pan_no=?,tan_no=?,upi_id=?,modified_date=?,modified_by=?,status=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='Supplier' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@phnno", Val(txtphnno.Text))
        cmd.Parameters.AddWithValue("@email", txtmail.Text)
        cmd.Parameters.AddWithValue("@website", txtwebsite.Text)
        cmd.Parameters.AddWithValue("@per_address", txtaddress.Text)
        cmd.Parameters.AddWithValue("@per_pin_code", Val(txtzip.Text))
        cmd.Parameters.AddWithValue("@per_landmark", txtlocality.Text)
        cmd.Parameters.AddWithValue("@per_state", txtstate.Text.ToUpper)
        cmd.Parameters.AddWithValue("@per_country", country)
        cmd.Parameters.AddWithValue("@id_proof_type", ddlidproof.SelectedValue)
        cmd.Parameters.AddWithValue("@id_proof_no", txtidprfno.Text)
        cmd.Parameters.AddWithValue("@comp_name", txtcompany.Text)
        cmd.Parameters.AddWithValue("@gstno", txtgstno.Text)
        cmd.Parameters.AddWithValue("@invoice_address", txtinvoice.Text)
        cmd.Parameters.AddWithValue("@open_bal", Val(txtopenbal.Text))
        cmd.Parameters.AddWithValue("@close_bal", Val(txtclosebal.Text))
        cmd.Parameters.AddWithValue("@bank_name", txtbank.Text.ToString)
        cmd.Parameters.AddWithValue("@ac_no", txtacno.Text)
        cmd.Parameters.AddWithValue("@ac_type", txtactype.Text)
        cmd.Parameters.AddWithValue("@ifsc_code", txtifsccode.Text)
        cmd.Parameters.AddWithValue("@branch_name", txtbranch.Text.ToString)
        cmd.Parameters.AddWithValue("@pan_no", txtpanno.Text)
        cmd.Parameters.AddWithValue("@tan_no", txttanno.Text)
        cmd.Parameters.AddWithValue("@upi_id", txtupiid.Text)
        cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
        cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
        cmd.Parameters.AddWithValue("@status", ddlstatus.SelectedValue.ToString)

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
            txtmail.Text = ""
            txtwebsite.Text = ""
            txtaddress.Text = ""
            txtzip.Text = ""
            txtcountry.Text = ""
            rblcountry.ClearSelection()
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
            txtcompany.Text = ""
            txtgstno.Text = ""
            txtinvoice.Text = ""
            txtopenbal.Text = ""
            txtclosebal.Text = ""
            txtbank.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtpanno.Text = ""
            txtupiid.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Supplier ID to Update", "error")
        End If
    End Sub

    Private Sub deleteledger()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set status='Inactive' where ledger_id='" & txtsearchname.Text & "' and q_led_type='Supplier' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Customer Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            txtledname.Text = ""
            txtphnno.Text = ""
            txtmail.Text = ""
            txtwebsite.Text = ""
            txtaddress.Text = ""
            txtzip.Text = ""
            txtcountry.Text = ""
            rblcountry.ClearSelection()
            ddlidproof.ClearSelection()
            txtidprfno.Text = ""
            txtcompany.Text = ""
            txtgstno.Text = ""
            txtinvoice.Text = ""
            txtopenbal.Text = ""
            txtclosebal.Text = ""
            txtbank.Text = ""
            txtacno.Text = ""
            txtactype.Text = ""
            txtifsccode.Text = ""
            txtbranch.Text = ""
            txtpanno.Text = ""
            txtupiid.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Supplier ID to Delete", "error")
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
    Protected Sub txtledname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtledname.TextChanged
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Supplier' and company_id='" & Session("comid") & "'  and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Supplier already Exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub

    Protected Sub chkbxinvadrs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxinvadrs.CheckedChanged
        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If
        If chkbxinvadrs.Checked Then
            txtinvoice.Text = txtaddress.Text + " " + txtzip.Text + " , " + txtlocality.Text + " , " + txtstate.Text + " , " + country
        Else
            txtinvoice.Text = ""
        End If

    End Sub
End Class
