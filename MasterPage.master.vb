Imports System.Web
Imports System.IO
Imports globalcon
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Odbc
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim dbcon As New globalcon

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogout.Click
        Session.RemoveAll()
        Response.Redirect("login.aspx")
    End Sub

    Public Sub loadoptions(ByVal comtypeid As String)
        Select Case comtypeid
            Case "11"
                HyperLink1.NavigateUrl = "epg_dashboard.aspx"
                HyperLink2.NavigateUrl = "epg_dashboard.aspx"
                lidashboard.Visible = False
                liepgdashboard.Visible = True
                liepgschedule.Visible = True
                liepgscheduleref.Visible = True
                ligenledger.Visible = False
                liguest.Visible = False
                licustomer.Visible = False
                liemployee.Visible = False
                listudent.Visible = False
                liroom.Visible = False
                litable.Visible = False
                lisupplier.Visible = False
                licategory.Visible = False
                liproductentry.Visible = False
                liproductfeature.Visible = False
                libook.Visible = False
                lifranchisee.Visible = False
                libranch.Visible = False
                liwarehouse.Visible = False
                listore.Visible = False
                liquotation.Visible = False
                liinvoice.Visible = False
                liexpense.Visible = False












        End Select

    End Sub

    Public Sub sidebar()
        Dim path As String = (HttpContext.Current.Request.Url.Segments.Last())
        path = path.Replace(".aspx", "")
        If path = "Dashboard" Then
            lidashboard1.Attributes.Add("class", "nav-link active")
        ElseIf path = "epg_dashboard" Then
            liepgdashboard1.Attributes.Add("class", "nav-link active")
        ElseIf path = "General_ledger" Then
            limaster1.Attributes.Add("class", "nav-link active")
            ligenledger1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "epg_schedule" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liepgschedule1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "epg_schedule_referrence" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liepgscheduleref1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Guest_ledger" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liguest1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Customer_ledger" Then
            limaster1.Attributes.Add("class", "nav-link active")
            licustomer1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Employee_ledger" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liemployee1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Student_ledger" Then
            limaster1.Attributes.Add("class", "nav-link active")
            listudent1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Room_ledger" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liroom1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Table_ledger" Then
            limaster1.Attributes.Add("class", "nav-link active")
            litable1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Category_master" Then
            limaster1.Attributes.Add("class", "nav-link active")
            licategory1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Product_entry" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liproductentry1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Product_features" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liproductfeature1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Books_entry" Then
            limaster1.Attributes.Add("class", "nav-link active")
            libook1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Franchisee" Then
            limaster1.Attributes.Add("class", "nav-link active")
            lifranchisee1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Branch" Then
            limaster1.Attributes.Add("class", "nav-link active")
            libranch1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Warehouse" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liwarehouse1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Store" Then
            limaster1.Attributes.Add("class", "nav-link active")
            listore1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Quotation" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liquotation1.Attributes.Add("class", "nav-link nav-indent active")
            'ElseIf path = "Puchase_order" Then
            '    limaster1.Attributes.Add("class", "nav-link active")
            '    lipurchase1.Attributes.Add("class", "nav-link nav-indent active")
            'ElseIf path = "Sales_order" Then
            '    limaster1.Attributes.Add("class", "nav-link active")
            '    lisales1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Invoice" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liinvoice1.Attributes.Add("class", "nav-link nav-indent active")
        ElseIf path = "Expense" Then
            limaster1.Attributes.Add("class", "nav-link active")
            liexpense1.Attributes.Add("class", "nav-link nav-indent active")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbldate.InnerHtml = Now.ToString("dd-MMMM-yyyy (dddd)")
        If Session("comid") Is Nothing Then
            Response.Redirect("login.aspx")
        Else
            lbluname.Text = Session("uname")
            Dim da As New OdbcDataAdapter("select company_name from company_details where id='" & Session("comid") & "' and deactive_date>'" & Now.ToString & "'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                lblcmnpame.Text = ds.Tables(0).Rows(0).Item(0)
            Else
                Session.RemoveAll()
                Response.Redirect("error404.aspx")
            End If
        End If

        sidebar()
        loadoptions(Session("comtypeid"))

        
    End Sub
End Class

