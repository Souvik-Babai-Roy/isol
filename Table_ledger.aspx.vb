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
        Dim da As New OdbcDataAdapter("SELECT id FROM fixed_param where param_type='quick_ledger_type' and param_name='Table'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        qledtypeid = dt.Rows(0).Item(0)

        Dim primaryid As Integer = 0
        Dim da1 As New OdbcDataAdapter("SELECT primary_id FROM primary_details where primary_name='Fixed Asset'", dbcon.con)
        Dim dt1 As New DataTable
        da1.Fill(dt1)
        primaryid = dt1.Rows(0).Item(0)

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO ledger(company_id,company_type_id,q_led_type_id,q_led_type,primary_type_id,primary_type,ledger_name,table_type,table_max_person,created_date,created_by,status,branch_code,franchisee_code,location) values(?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?)"

            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@q_led_type_id", qledtypeid)
            cmd.Parameters.AddWithValue("@q_led_type", "Table")
            cmd.Parameters.AddWithValue("@primary_type_id", primaryid)
            cmd.Parameters.AddWithValue("@primary_type", "Fixed Asset")
            cmd.Parameters.AddWithValue("@ledger_name", txtledname.Text.ToString)
            cmd.Parameters.AddWithValue("@table_type", ddltabletype.SelectedValue)
            cmd.Parameters.AddWithValue("@table_max_person", Val(txtmaxperson.Text))
            cmd.Parameters.AddWithValue("@created_date", Now.ToString)
            cmd.Parameters.AddWithValue("@created_by", Session("uname"))
            cmd.Parameters.AddWithValue("@status", "Active")
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            cmd.Parameters.AddWithValue("@location", txtposition.Text.ToUpper)
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
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Table' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Table already Exist", "error")
        Else
            ledgerentry()
            txtledname.Text = ""
            txtmaxperson.Text = ""
            ddltabletype.ClearSelection()
            txtposition.Text = ""
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,ledger_name as table_no,location,table_type,table_max_person,status FROM ledger where company_id='" & Session("comid") & "' and q_led_type='Table' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,ledger_name as table_no,location,table_type,table_max_person,status FROM ledger where upper(ledger_name) like upper('%" & txtsearchname.Text & "%') and q_led_type='Table' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT ledger_name,table_type,table_max_person,status,location FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Table' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows(0).Item(0) IsNot DBNull.Value Then
            txtledname.Text = ds.Tables(0).Rows(0).Item(0)
            txtledname.Attributes("disabled") = "disabled"
        End If
        If ds.Tables(0).Rows(0).Item(1) IsNot DBNull.Value Then
            ddltabletype.Text = ds.Tables(0).Rows(0).Item(1)
        End If
        If ds.Tables(0).Rows(0).Item(2) IsNot DBNull.Value Then
            txtmaxperson.Text = ds.Tables(0).Rows(0).Item(2)
        End If
        If ds.Tables(0).Rows(0).Item(3) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(3) <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item(3)
            End If
        End If
        If ds.Tables(0).Rows(0).Item("location") IsNot DBNull.Value Then
            txtposition.Text = ds.Tables(0).Rows(0).Item("location")
        End If
    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT ledger_id,q_led_type,primary_type,ledger_name as table_no,location,table_type,table_max_person,status FROM ledger where ledger_id='" & txtsearchname.Text & "' and q_led_type='Table' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Table ID", "error")
            End If
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Private Sub updateinfo()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set table_type=?,table_max_person=?,modified_date=?,modified_by=?,status=?,location=? where ledger_id='" & txtsearchname.Text & "' and q_led_type='Table' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@table_type", ddltabletype.SelectedValue)
        cmd.Parameters.AddWithValue("@table_max_person", Val(txtmaxperson.Text))
        cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
        cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
        cmd.Parameters.AddWithValue("@status", ddlstatus.SelectedValue)
        cmd.Parameters.AddWithValue("@location", txtposition.Text.ToUpper)
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Information Updated Successfully", "success")

    End Sub

    Protected Sub btnupdate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.ServerClick
        If txtsearchname.Text <> "" Then
            updateinfo()
            txtledname.Text = ""
            txtmaxperson.Text = ""
            ddltabletype.ClearSelection()
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Table ID to Update", "error")
        End If
    End Sub

    Private Sub deleteledger()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update ledger set status='Inactive' where ledger_id='" & txtsearchname.Text & "' and q_led_type='Table' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Table Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            txtledname.Text = ""
            txtmaxperson.Text = ""
            ddltabletype.ClearSelection()
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Table ID to Delete", "error")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            dbcon.tabletypepopulate(ddltabletype, Session("comid"))
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
        Dim da As New OdbcDataAdapter("select * from ledger where ledger_name=upper('" & txtledname.Text & "') and q_led_type='Table' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Table no. already Exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub
End Class
