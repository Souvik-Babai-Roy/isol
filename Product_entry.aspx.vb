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

    Public Sub productentry()
        Dim catid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT cat_id FROM product_category where cat_name='" & ddlcategory.SelectedValue & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        catid = dt.Rows(0).Item(0)

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO product(company_id,company_type_id,branch_code,franchisee_code,cat_id,cat_name,pdct_name,brand,manufctr,model_no,model_name,rate,unit,hsn,description,status,size,colour,material,highlight_feature,technical_details,additional_feature,other_feature,offers) values(?,?,?,?,?,?,upper(?),?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            cmd.Parameters.AddWithValue("@cat_id", catid)
            cmd.Parameters.AddWithValue("@cat_name", ddlcategory.SelectedValue)
            cmd.Parameters.AddWithValue("@pdct_name", txtpdctname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@brand", txtbrand.Text)
            cmd.Parameters.AddWithValue("@manufctr", txtmanufacturer.Text)
            cmd.Parameters.AddWithValue("@model_no", txtmodelno.Text)
            cmd.Parameters.AddWithValue("@model_name", txtmodelname.Text)
            cmd.Parameters.AddWithValue("@rate", Val(txtrate.Text))
            cmd.Parameters.AddWithValue("@unit", txtunit.Text)
            cmd.Parameters.AddWithValue("@hsn", txthsn.Text)
            cmd.Parameters.AddWithValue("@description", txtdesc.Text)
            cmd.Parameters.AddWithValue("@status", "Active")
            cmd.Parameters.AddWithValue("@size", txtsize.Text.ToString.Replace(" ", [String].Empty))
            cmd.Parameters.AddWithValue("@colour", txtcolour.Text.ToString.Replace(" ", [String].Empty))
            cmd.Parameters.AddWithValue("@material", txtmaterial.Text)
            cmd.Parameters.AddWithValue("@highlight_feature", txthigh.Text)
            cmd.Parameters.AddWithValue("@technical_details", txttech.Text)
            cmd.Parameters.AddWithValue("@additional_feature", txtadditional.Text)
            cmd.Parameters.AddWithValue("@other_feature", txtother.Text)
            cmd.Parameters.AddWithValue("@offers", txtoffer.Text)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            msgct1.InnerHtml = gcdsgn.alertmsg("Product has been Saved", "success")
        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try
    End Sub
    Protected Sub btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.ServerClick
        Dim da As New OdbcDataAdapter("select * from product where pdct_name=upper('" & txtpdctname.Text & "') and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Product already Exist", "error")
        Else
            productentry()
            ddlcategory.ClearSelection()
            txtpdctname.Text = ""
            txtbrand.Text = ""
            txtmanufacturer.Text = ""
            txtmodelno.Text = ""
            txtmodelname.Text = ""
            txtrate.Text = ""
            txtunit.Text = ""
            txthsn.Text = ""
            txtdesc.Text = ""
            txtsize.Text = ""
            txtcolour.Text = ""
            txtmaterial.Text = ""
            txthigh.Text = ""
            txtadditional.Text = ""
            txttech.Text = ""
            txtother.Text = ""
            txtoffer.Text = ""
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT pdct_id,cat_name,pdct_name,brand,manufctr,model_no,model_name,rate,unit,hsn,size,colour,material,status FROM product where company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT pdct_id,cat_name,pdct_name,brand,manufctr,model_no,model_name,rate,unit,hsn,size,colour,material,status FROM product where upper(pdct_name) like upper('%" & txtsearchname.Text & "%') and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
        Dim da As New OdbcDataAdapter("SELECT * FROM product where pdct_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows(0).Item("cat_name") IsNot DBNull.Value Then
            ddlcategory.Text = ds.Tables(0).Rows(0).Item("cat_name")
        End If
        If ds.Tables(0).Rows(0).Item("pdct_name") IsNot DBNull.Value Then
            txtpdctname.Text = ds.Tables(0).Rows(0).Item("pdct_name")
        End If
        If ds.Tables(0).Rows(0).Item("brand") IsNot DBNull.Value Then
            txtbrand.Text = ds.Tables(0).Rows(0).Item("brand")
        End If
        If ds.Tables(0).Rows(0).Item("manufctr") IsNot DBNull.Value Then
            txtmanufacturer.Text = ds.Tables(0).Rows(0).Item("manufctr")
        End If
        If ds.Tables(0).Rows(0).Item("model_no") IsNot DBNull.Value Then
            txtmodelno.Text = ds.Tables(0).Rows(0).Item("model_no")
        End If
        If ds.Tables(0).Rows(0).Item("model_name") IsNot DBNull.Value Then
            txtmodelname.Text = ds.Tables(0).Rows(0).Item("model_name")
        End If
        If ds.Tables(0).Rows(0).Item("rate") IsNot DBNull.Value Then
            txtrate.Text = ds.Tables(0).Rows(0).Item("rate")
        End If
        If ds.Tables(0).Rows(0).Item("unit") IsNot DBNull.Value Then
            txtunit.Text = ds.Tables(0).Rows(0).Item("unit")
        End If
        If ds.Tables(0).Rows(0).Item("hsn") IsNot DBNull.Value Then
            txthsn.Text = ds.Tables(0).Rows(0).Item("hsn")
        End If
       
        If ds.Tables(0).Rows(0).Item("description") IsNot DBNull.Value Then
            txtdesc.Text = ds.Tables(0).Rows(0).Item("description")
        End If
        If ds.Tables(0).Rows(0).Item("size") IsNot DBNull.Value Then
            txtsize.Text = ds.Tables(0).Rows(0).Item("size")
        End If
        If ds.Tables(0).Rows(0).Item("colour") IsNot DBNull.Value Then
            txtcolour.Text = ds.Tables(0).Rows(0).Item("colour")
        End If
        If ds.Tables(0).Rows(0).Item("material") IsNot DBNull.Value Then
            txtmaterial.Text = ds.Tables(0).Rows(0).Item("material")
        End If
        If ds.Tables(0).Rows(0).Item("highlight_feature") IsNot DBNull.Value Then
            txtmaterial.Text = ds.Tables(0).Rows(0).Item("highlight_feature")
        End If
        If ds.Tables(0).Rows(0).Item("technical_details") IsNot DBNull.Value Then
            txtmaterial.Text = ds.Tables(0).Rows(0).Item("technical_details")
        End If
        If ds.Tables(0).Rows(0).Item("additional_feature") IsNot DBNull.Value Then
            txtmaterial.Text = ds.Tables(0).Rows(0).Item("additional_feature")
        End If
        If ds.Tables(0).Rows(0).Item("other_feature") IsNot DBNull.Value Then
            txtmaterial.Text = ds.Tables(0).Rows(0).Item("other_feature")
        End If
        If ds.Tables(0).Rows(0).Item("offers") IsNot DBNull.Value Then
            txtmaterial.Text = ds.Tables(0).Rows(0).Item("offers")
        End If
        If ds.Tables(0).Rows(0).Item(13) IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item(13) <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item("Status")
            End If
        End If
    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT pdct_id,cat_name,pdct_name,brand,manufctr,model_no,model_name,rate,unit,hsn,size,colour,material,status FROM product where pdct_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
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
                End If
            Else
                grdvleddetails.DataSource = Nothing
                grdvleddetails.DataBind()
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Product ID", "error")
            End If
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Private Sub updateinfo()

        Dim catid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT cat_id FROM product_category where cat_name='" & ddlcategory.SelectedValue & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        catid = dt.Rows(0).Item(0)


        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update product set cat_id=?,cat_name=?,pdct_name=?,brand=?,manufctr=?,model_no=?,model_name=?,rate=?,unit=?,hsn=?,description=?,status=?,size=?,colour=?,material=?,highlight_feature=?,technical_details=?,additional_feature=?,other_feature=?,offers=? where pdct_id='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@cat_id", catid)
        cmd.Parameters.AddWithValue("@cat_name", ddlcategory.SelectedValue)
        cmd.Parameters.AddWithValue("@pdct_name", txtpdctname.Text.ToUpper)
        cmd.Parameters.AddWithValue("@brand", txtbrand.Text)
        cmd.Parameters.AddWithValue("@manufctr", txtmanufacturer.Text)
        cmd.Parameters.AddWithValue("@model_no", txtmodelno.Text)
        cmd.Parameters.AddWithValue("@model_name", txtmodelname.Text)
        cmd.Parameters.AddWithValue("@rate", Val(txtrate.Text))
        cmd.Parameters.AddWithValue("@unit", txtunit.Text)
        cmd.Parameters.AddWithValue("@hsn", txthsn.Text)
        cmd.Parameters.AddWithValue("@description", txtdesc.Text)
        cmd.Parameters.AddWithValue("@status", ddlstatus.SelectedValue)
        cmd.Parameters.AddWithValue("@size", txtsize.Text.ToString.Replace(" ", [String].Empty))
        cmd.Parameters.AddWithValue("@colour", txtcolour.Text.ToString.Replace(" ", [String].Empty))
        cmd.Parameters.AddWithValue("@material", txtmaterial.Text)
        cmd.Parameters.AddWithValue("@highlight_feature", txthigh.Text)
        cmd.Parameters.AddWithValue("@technical_details", txttech.Text)
        cmd.Parameters.AddWithValue("@additional_feature", txtadditional.Text)
        cmd.Parameters.AddWithValue("@other_feature", txtother.Text)
        cmd.Parameters.AddWithValue("@offers", txtoffer.Text)
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Information Updated Successfully", "success")

    End Sub

    Protected Sub btnupdate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.ServerClick
        If txtsearchname.Text <> "" Then
            Dim da As New OdbcDataAdapter("select * from product where pdct_name=upper('" & txtpdctname.Text & "') and pdct_id<>'" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                msgct1.InnerHtml = gcdsgn.alertmsg("Product Name Exist", "error")
            Else
                updateinfo()
                ddlcategory.ClearSelection()
                txtpdctname.Text = ""
                txtbrand.Text = ""
                txtmanufacturer.Text = ""
                txtmodelno.Text = ""
                txtmodelname.Text = ""
                txtrate.Text = ""
                txtunit.Text = ""
                txthsn.Text = ""
                txtdesc.Text = ""
                ddlstatus.ClearSelection()
                txtsize.Text = ""
                txtcolour.Text = ""
                txtmaterial.Text = ""
                txthigh.Text = ""
                txtadditional.Text = ""
                txttech.Text = ""
                txtother.Text = ""
                txtoffer.Text = ""
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
            ddlcategory.ClearSelection()
            txtpdctname.Text = ""
            txtbrand.Text = ""
            txtmanufacturer.Text = ""
            txtmodelno.Text = ""
            txtmodelname.Text = ""
            txtrate.Text = ""
            txtunit.Text = ""
            txthsn.Text = ""
            txtdesc.Text = ""
            txtsize.Text = ""
            txtcolour.Text = ""
            txtmaterial.Text = ""
            txthigh.Text = ""
            txtadditional.Text = ""
            txttech.Text = ""
            txtother.Text = ""
            txtoffer.Text = ""
            ddlstatus.ClearSelection()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Product ID to Delete", "error")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            dbcon.productcategory(ddlcategory, Session("comid"))
        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            valmsg.InnerText = ""
        End If
        If chkbxdiff.Checked = True Then
            lblchkbxdiff.InnerText = "Yes"
        Else
            lblchkbxdiff.InnerText = "No"
        End If
        If chkbxfeature.Checked = True Then
            lblchkbxfeature.InnerText = "Yes"
        Else
            lblchkbxfeature.InnerText = "No"
        End If

        grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub txtpdctname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpdctname.TextChanged
        Dim da As New OdbcDataAdapter("select * from product where pdct_name=upper('" & txtpdctname.Text & "') and company_id='" & Session("comid") & "'  and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Product already exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub


    Protected Sub chkbxdiff_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxdiff.ServerChange
        If chkbxdiff.Checked = True Then
            divdiff.Visible = True
        Else
            divdiff.Visible = False
        End If
    End Sub

    Protected Sub chkbxfeature_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxfeature.ServerChange
        If chkbxfeature.Checked = True Then
            divfeature.Visible = True
        Else
            divfeature.Visible = False
        End If
    End Sub
End Class
