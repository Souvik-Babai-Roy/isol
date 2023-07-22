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


    Public Sub bookentry()
        Dim catid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT cat_id FROM product_category where cat_name='Book' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            catid = dt.Rows(0).Item(0)
        End If


        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO product(company_id,company_type_id,branch_code,franchisee_code,cat_id,cat_name,pdct_name,author,publisher,edition,rate,description,manufctr_date,book_type,language,rack_no,location,open_quant,close_quant,status,purchase_date) values(?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            cmd.Parameters.AddWithValue("@cat_id", catid)
            cmd.Parameters.AddWithValue("@cat_name", "Book")
            cmd.Parameters.AddWithValue("@pdct_name", txtbookname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@author", txtauthor.Text)
            cmd.Parameters.AddWithValue("@publisher", txtpublisher.Text)
            cmd.Parameters.AddWithValue("@edition", txtedition.Text)
            cmd.Parameters.AddWithValue("@rate", txtprice.Text)
            cmd.Parameters.AddWithValue("@description", txtdesc.Text)
            If txtdatepublish.Text <> "" Then
                cmd.Parameters.AddWithValue("@manufctr_date", txtdatepublish.Text)
            Else
                cmd.Parameters.AddWithValue("@manufctr_date", DBNull.Value)
            End If
            cmd.Parameters.AddWithValue("@book_type", ddlbooktype.SelectedValue)
            cmd.Parameters.AddWithValue("@language", ddllang.SelectedValue)
            cmd.Parameters.AddWithValue("@rack_no", txtrackno.Text)
            cmd.Parameters.AddWithValue("@location", txtroomno.Text)
            cmd.Parameters.AddWithValue("@open_quant", Val(txtopenquant.Text))
            cmd.Parameters.AddWithValue("@close_quant", Val(txtclosequant.Text))
            cmd.Parameters.AddWithValue("@status", "Active")
            cmd.Parameters.AddWithValue("@purchase_date", txtpurdate.Text)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            msgct1.InnerHtml = gcdsgn.alertmsg("Book has been entried", "success")
        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try
    End Sub
    Protected Sub btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.ServerClick
        Dim da As New OdbcDataAdapter("select * from product where pdct_name=upper('" & txtbookname.Text & "')and cat_name='Book' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Book already Exist", "error")
        Else
            bookentry()
            txtbookname.Text = ""
            txtpublisher.Text = ""
            txtauthor.Text = ""
            txtedition.Text = ""
            txtprice.Text = ""
            txtopenquant.Text = ""
            txtclosequant.Text = ""
            txtdesc.Text = ""
            txtdatepublish.Text = ""
            ddlbooktype.ClearSelection()
            ddllang.ClearSelection()
            txtrackno.Text = ""
            txtroomno.Text = ""
            txtpurdate.Text = ""
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT pdct_id,cat_name,pdct_name,author,publisher,edition,rate,description,manufctr_date,book_type,language,rack_no,location,open_quant,close_quant,status FROM product where company_id='" & Session("comid") & "' and cat_name='Book' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT pdct_id,cat_name,pdct_name,author,publisher,edition,rate,description,manufctr_date,book_type,language,rack_no,location,open_quant,close_quant,status FROM product where upper(pdct_name) like upper('%" & txtsearchname.Text & "%') and cat_name='Book' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT * FROM product where pdct_id='" & txtsearchname.Text & "' and cat_name='BOOK' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows(0).Item("pdct_name") IsNot DBNull.Value Then
            txtbookname.Text = ds.Tables(0).Rows(0).Item("pdct_name")
        End If
        If ds.Tables(0).Rows(0).Item("author") IsNot DBNull.Value Then
            txtauthor.Text = ds.Tables(0).Rows(0).Item("author")
        End If
        If ds.Tables(0).Rows(0).Item("publisher") IsNot DBNull.Value Then
            txtpublisher.Text = ds.Tables(0).Rows(0).Item("publisher")
        End If
        If ds.Tables(0).Rows(0).Item("edition") IsNot DBNull.Value Then
            txtedition.Text = ds.Tables(0).Rows(0).Item("edition")
        End If
        If ds.Tables(0).Rows(0).Item("book_type") IsNot DBNull.Value Then
            ddlbooktype.Text = ds.Tables(0).Rows(0).Item("book_type")
        End If
        If ds.Tables(0).Rows(0).Item("language") IsNot DBNull.Value Then
            ddllang.Text = ds.Tables(0).Rows(0).Item("language")
        End If
        If ds.Tables(0).Rows(0).Item("rack_no") IsNot DBNull.Value Then
            txtrackno.Text = ds.Tables(0).Rows(0).Item("rack_no")
        End If
        If ds.Tables(0).Rows(0).Item("location") IsNot DBNull.Value Then
            txtroomno.Text = ds.Tables(0).Rows(0).Item("location")
        End If
        If ds.Tables(0).Rows(0).Item("open_quant") IsNot DBNull.Value Then
            txtopenquant.Text = ds.Tables(0).Rows(0).Item("open_quant")
        End If
        If ds.Tables(0).Rows(0).Item("close_quant") IsNot DBNull.Value Then
            txtclosequant.Text = ds.Tables(0).Rows(0).Item("close_quant")
        End If
        If ds.Tables(0).Rows(0).Item("purchase_date") IsNot DBNull.Value Then
            txtpurdate.Text = ds.Tables(0).Rows(0).Item("purchase_date")
        End If
        If ds.Tables(0).Rows(0).Item("status") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("status") <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item("Status")
            End If
        End If
    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT pdct_id,cat_name,pdct_name,author,publisher,edition,rate,description,manufctr_date,book_type,language,rack_no,location,open_quant,close_quant,status FROM product where pdct_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Book ID", "error")
            End If
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Private Sub updateinfo()

        Dim catid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT cat_id FROM product_category where cat_name='BOOK' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        catid = dt.Rows(0).Item(0)


        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update product set pdct_name=?,author=?,publisher=?,edition=?,rate=?,description=?,manufctr_date=?,book_type=?,language=?,rack_no=?,location=?,open_quant=?,close_quant=?,status=?,purchase_date=? where pdct_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and cat_name='BOOK'"
        cmd.Parameters.AddWithValue("@pdct_name", txtbookname.Text.ToUpper)
        cmd.Parameters.AddWithValue("@author", txtauthor.Text)
        cmd.Parameters.AddWithValue("@publisher", txtpublisher.Text)
        cmd.Parameters.AddWithValue("@edition", txtedition.Text)
        cmd.Parameters.AddWithValue("@rate", txtprice.Text)
        cmd.Parameters.AddWithValue("@description", txtdesc.Text)
        If txtdatepublish.Text <> "" Then
            cmd.Parameters.AddWithValue("@manufctr_date", txtdatepublish.Text)
        Else
            cmd.Parameters.AddWithValue("@manufctr_date", DBNull.Value)
        End If
        cmd.Parameters.AddWithValue("@book_type", ddlbooktype.SelectedValue)
        cmd.Parameters.AddWithValue("@language", ddllang.SelectedValue)
        cmd.Parameters.AddWithValue("@rack_no", txtrackno.Text)
        cmd.Parameters.AddWithValue("@location", txtroomno.Text)
        cmd.Parameters.AddWithValue("@open_quant", Val(txtopenquant.Text))
        cmd.Parameters.AddWithValue("@close_quant", Val(txtclosequant.Text))
        cmd.Parameters.AddWithValue("@status", "Active")
        cmd.Parameters.AddWithValue("@purchase_date", txtpurdate.Text)

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Information Updated Successfully", "success")

    End Sub

    Protected Sub btnupdate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.ServerClick
        If txtsearchname.Text <> "" Then
            Dim da As New OdbcDataAdapter("select * from product where pdct_name=upper('" & txtbookname.Text & "') and pdct_id<>'" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                msgct1.InnerHtml = gcdsgn.alertmsg("Product Name Exist", "error")
            Else
                updateinfo()
                txtbookname.Text = ""
                txtpublisher.Text = ""
                txtauthor.Text = ""
                txtedition.Text = ""
                txtprice.Text = ""
                txtopenquant.Text = ""
                txtclosequant.Text = ""
                txtdesc.Text = ""
                txtdatepublish.Text = ""
                ddlbooktype.ClearSelection()
                ddllang.ClearSelection()
                txtrackno.Text = ""
                txtroomno.Text = ""
                ddlstatus.ClearSelection()
                btnsave.Visible = True
                btnupdate.Visible = False
                btndelete.Visible = False
                divstatus.Visible = False
            End If
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Product ID to Update", "error")
        End If
    End Sub

    Private Sub deleteledger()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update product set status='Inactive' where pdct_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Product Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            txtbookname.Text = ""
            txtpublisher.Text = ""
            txtauthor.Text = ""
            txtedition.Text = ""
            txtprice.Text = ""
            txtopenquant.Text = ""
            txtclosequant.Text = ""
            txtdesc.Text = ""
            txtdatepublish.Text = ""
            ddlbooktype.ClearSelection()
            ddllang.ClearSelection()
            txtrackno.Text = ""
            txtroomno.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Book ID to Delete", "error")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            dbcon.booktypepopulate(ddlbooktype, Session("comid"))
            dbcon.booklangpopulate(ddllang, Session("comid"))
        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            valmsg.InnerText = ""
        End If
        grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub txtbookname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbookname.TextChanged
        Dim da As New OdbcDataAdapter("select * from product where pdct_name=upper('" & txtbookname.Text & "') and company_id='" & Session("comid") & "' and cat_name='Book' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Book already exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub



End Class
