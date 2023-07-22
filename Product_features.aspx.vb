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
    Dim dt As New DataTable

    Private Sub AddProducts()
        dt.Columns.Add("ID")
        dt.Columns.Add("ProductName")
        dt.Columns.Add("Category")
        dt.Columns.Add("FeatureGroup")
        dt.Columns.Add("FeatureName")
        dt.Columns.Add("Description")
        If tblftr.Rows.Count > 0 Then
            For Each rr As GridViewRow In tblftr.Rows
                dt.Rows.Add(Server.HtmlDecode(rr.Cells(1).Text), Server.HtmlDecode(rr.Cells(2).Text.ToString), Server.HtmlDecode(rr.Cells(3).Text.ToString), Server.HtmlDecode(rr.Cells(4).Text.ToString), Server.HtmlDecode(rr.Cells(5).Text.ToString), Server.HtmlDecode(rr.Cells(6).Text.ToString))
            Next
        End If
        dt.Rows.Add(lblid.InnerText.ToString, ddlproduct.SelectedValue, ddlcategory.SelectedValue, ddlftrgrp.SelectedValue, txtftrname.Text, txtdesc.Text)
        tblftr.DataSource = dt
        tblftr.DataBind()
    End Sub
    Private Sub RemoveAddProducts(ByVal id As Integer)
        dt.Columns.Add("ID")
        dt.Columns.Add("ProductName")
        dt.Columns.Add("Category")
        dt.Columns.Add("FeatureGroup")
        dt.Columns.Add("FeatureName")
        dt.Columns.Add("Description")

        For i As Integer = 0 To tblftr.Rows.Count - 1
            dt.Rows.Add(Server.HtmlDecode(tblftr.Rows(i).Cells(1).Text.ToString), Server.HtmlDecode(tblftr.Rows(i).Cells(2).Text.ToString), Server.HtmlDecode(tblftr.Rows(i).Cells(3).Text.ToString), Server.HtmlDecode(tblftr.Rows(i).Cells(4).Text.ToString), Server.HtmlDecode(tblftr.Rows(i).Cells(5).Text.ToString), Server.HtmlDecode(tblftr.Rows(i).Cells(6).Text.ToString))
        Next

        dt.Rows.RemoveAt(id)
        tblftr.DataSource = dt
        tblftr.DataBind()
    End Sub
    Protected Sub btnadd_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.ServerClick
        AddProducts()
    End Sub

    Protected Sub tblftr_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles tblftr.RowDeleting
        RemoveAddProducts(e.RowIndex)
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            dbcon.productcategory(ddlcategory, Session("comid"))

        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            ''valmsg.InnerText = ""
        End If
        ''grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        ''grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub ddlcategory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcategory.Load
        Dim da As New OdbcDataAdapter("SELECT pdct_name FROM product where cat_name='" & ddlcategory.SelectedValue & "' and company_id='" & Session("comid") & "' and status='Active' order by pdct_name asc", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddlproduct.DataSource = dt
            ddlproduct.DataTextField = "pdct_name"
            ddlproduct.DataValueField = "pdct_name"
            ddlproduct.DataBind()
        Else
            ddlproduct.DataSource = ""
            ddlproduct.DataBind()
        End If
    End Sub

    Protected Sub ddlcategory_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcategory.TextChanged
        Dim da As New OdbcDataAdapter("SELECT pdct_name FROM product where cat_name='" & ddlcategory.SelectedValue & "' and company_id='" & Session("comid") & "' and status='Active' order by pdct_name asc", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddlproduct.DataSource = dt
            ddlproduct.DataTextField = "pdct_name"
            ddlproduct.DataValueField = "pdct_name"
            ddlproduct.DataBind()
        Else
            ddlproduct.DataSource = ""
            ddlproduct.DataBind()
        End If
    End Sub

    Protected Sub ddlproduct_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlproduct.DataBound
        If ddlproduct.Text <> "" Then
            divfeature.Visible = True
        Else
            divfeature.Visible = False
        End If
        Dim da As New OdbcDataAdapter("SELECT pdct_id FROM product where cat_name='" & ddlcategory.SelectedValue & "' and pdct_name='" & ddlproduct.SelectedValue & "' and company_id='" & Session("comid") & "' and status='Active' order by pdct_name asc", dbcon.con)
        Dim dt1 As New DataTable
        da.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            lblid.InnerText = dt1.Rows(0).Item(0)
        Else
            lblid.InnerText = ""
        End If
    End Sub
    Protected Sub ddlproduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlproduct.TextChanged
        If ddlproduct.Text <> "" Then
            divfeature.Visible = True
        Else
            divfeature.Visible = False
        End If
        Dim da As New OdbcDataAdapter("SELECT pdct_id FROM product where cat_name='" & ddlcategory.SelectedValue & "' and pdct_name='" & ddlproduct.SelectedValue & "' and company_id='" & Session("comid") & "' and status='Active' order by pdct_name asc", dbcon.con)
        Dim dt1 As New DataTable
        da.Fill(dt1)
        If dt1.Rows.Count > 0 Then
            lblid.InnerText = dt1.Rows(0).Item(0)
        Else
            lblid.InnerText = ""
        End If
    End Sub
    Public Sub featuresentry()
        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO product_feature(company_id,company_type_id,branch_code,franchisee_code,pdct_id,pdct_name,cat_name,feature_group,feature_name,description,status) values(?,?,?,?,?,?,?,?,?,?,?)"
            For i As Integer = 0 To tblftr.Rows.Count - 1
                cmd.Parameters.AddWithValue("@company_id", Session("comid"))
                cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
                cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
                cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
                cmd.Parameters.AddWithValue("@pdct_id", Server.HtmlDecode(tblftr.Rows(i).Cells(1).Text))
                cmd.Parameters.AddWithValue("@pdct_name", Server.HtmlDecode(tblftr.Rows(i).Cells(2).Text))
                cmd.Parameters.AddWithValue("@cat_name", Server.HtmlDecode(tblftr.Rows(i).Cells(3).Text))
                cmd.Parameters.AddWithValue("@feature_group", Server.HtmlDecode(tblftr.Rows(i).Cells(4).Text))
                cmd.Parameters.AddWithValue("@feature_name", Server.HtmlDecode(tblftr.Rows(i).Cells(5).Text))
                cmd.Parameters.AddWithValue("@description", Server.HtmlDecode(tblftr.Rows(i).Cells(6).Text))
                cmd.Parameters.AddWithValue("@status", "Active")
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                msgct1.InnerHtml = gcdsgn.alertmsg("Features has been Saved", "success")
            Next
        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Protected Sub btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.ServerClick
        If tblftr.Rows.Count = 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Please add at least one Feature to save", "error")
        Else
            featuresentry()
        End If
    End Sub
End Class
