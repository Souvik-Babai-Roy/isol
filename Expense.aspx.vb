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
        dt.Columns.Add("id")
        dt.Columns.Add("Product_Name")
        dt.Columns.Add("Unit_Price")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Amount")


        If tblquot.Rows.Count > 0 Then
            For Each rr As GridViewRow In tblquot.Rows
                dt.Rows.Add(Server.HtmlDecode(rr.Cells(1).Text), Server.HtmlDecode(rr.Cells(2).Text.ToString), Server.HtmlDecode(rr.Cells(3).Text.ToString), Server.HtmlDecode(rr.Cells(4).Text.ToString), Server.HtmlDecode(rr.Cells(5).Text.ToString), Server.HtmlDecode(rr.Cells(6).Text.ToString))
            Next
        End If
        dt.Rows.Add(lblpid.Text.ToString, txtpdctname.Text, txtprice.Text.ToString, txtunit.Text.ToString, txtquant.Text.ToString, txtamount.Text.ToString)
        tblquot.DataSource = dt
        tblquot.DataBind()
    End Sub
    Private Sub RemoveAddProducts(ByVal id As Integer)
        dt.Columns.Add("id")
        dt.Columns.Add("Product_Name")
        dt.Columns.Add("Unit_Price")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Amount")

        For i As Integer = 0 To tblquot.Rows.Count - 1
            dt.Rows.Add(Server.HtmlDecode(tblquot.Rows(i).Cells(1).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(2).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(3).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(4).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(5).Text.ToString))
        Next
        dt.Rows.RemoveAt(id)
        tblquot.DataSource = dt
        tblquot.DataBind()
    End Sub
    Protected Sub btnadd_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.ServerClick
        AddProducts()
    End Sub

   

    Protected Sub tblquot_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles tblquot.RowDeleting
        RemoveAddProducts(e.RowIndex)
    End Sub
    Protected Sub tblquot_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles tblquot.RowEditing
        tblquot.EditIndex = e.NewEditIndex

    End Sub

    Protected Sub tblquot_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles tblquot.RowCancelingEdit
        tblquot.EditIndex = -1
    End Sub
    Protected Sub tblquot_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles tblquot.RowUpdating
        Dim row As GridViewRow = tblquot.Rows(e.RowIndex)
        Dim amt As String = TryCast(row.Cells(5).Controls(0), TextBox).Text
    End Sub

    Protected Sub chkbxtax_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxtax.ServerChange
        If chkbxtax.Checked = True Then
            divtax.Visible = True
        Else
            divtax.Visible = False
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If chkbxtax.Checked = True Then
            lblchkbxtax.InnerText = "Yes"
        Else
            lblchkbxtax.InnerText = "No"
        End If
    End Sub

    Public Sub expenseentry()
        Dim ledid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT ledger_id FROM ledger where ledger_name=upper('" & txtsupplier.Text & "') and q_led_type='Supplier' and status='Active'", dbcon.con)
        Dim dt2 As New DataTable
        da.Fill(dt2)
        If dt2.Rows.Count > 0 Then
            ledid = dt2.Rows(0).Item(0)
        End If

        Dim IDS As String = ""
        Dim ID As Double = 0

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO invoice_details(invoiceid,invoiceno,company_id,company_type_id,branch_code,franchisee_code,client_id,client_name,invoice_type,product_id,product_name,hsn_sac,quant,unit,rate,price,descrptn,sgst,igst,cgst,service_tax,sgst_p,igst_p,cgst_p,service_tax_p,created_date,status) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) RETURNING inv_id"
            For i As Integer = 0 To tblquot.Rows.Count - 1
                cmd.Parameters.AddWithValue("@invoiceid", "0")
                cmd.Parameters.AddWithValue("@invoiceno", "0")
                cmd.Parameters.AddWithValue("@company_id", Session("comid"))
                cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
                cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
                cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
                cmd.Parameters.AddWithValue("@client_id", ledid)
                cmd.Parameters.AddWithValue("@client_name", txtsupplier.Text)
                cmd.Parameters.AddWithValue("@est_type", "Expense")
                cmd.Parameters.AddWithValue("@product_id", Val(tblquot.Rows(i).Cells(1).Text))
                cmd.Parameters.AddWithValue("@product_name", tblquot.Rows(i).Cells(2).Text)



                Dim da1 As New OdbcDataAdapter("SELECT * FROM product where pdct_id='" & tblquot.Rows(i).Cells(1).Text & "' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
                Dim dt3 As New DataTable
                da1.Fill(dt3)
                


                cmd.Parameters.AddWithValue("@hsn_sac", dt3.Rows(0).Item("hsn").ToString)
                cmd.Parameters.AddWithValue("@quant", Val(tblquot.Rows(i).Cells(5).Text))
                cmd.Parameters.AddWithValue("@unit", tblquot.Rows(i).Cells(4).Text)
                cmd.Parameters.AddWithValue("@rate", Val(tblquot.Rows(i).Cells(3).Text))
                cmd.Parameters.AddWithValue("@price", Val(tblquot.Rows(i).Cells(6).Text))
                cmd.Parameters.AddWithValue("@descrptn", dt3.Rows(0).Item("description").ToString)
                cmd.Parameters.AddWithValue("@sgst", (Val(tblquot.Rows(i).Cells(6).Text) * Val(txtsgst.Text)) / 100)
                cmd.Parameters.AddWithValue("@igst", (Val(tblquot.Rows(i).Cells(6).Text) * Val(txtigst.Text)) / 100)
                cmd.Parameters.AddWithValue("@cgst", (Val(tblquot.Rows(i).Cells(6).Text) * Val(txtcgst.Text)) / 100)
                cmd.Parameters.AddWithValue("@service_tax", (Val(tblquot.Rows(i).Cells(6).Text) * Val(txtservicetax.Text)) / 100)
                cmd.Parameters.AddWithValue("@sgst_p", Val(txtsgst.Text))
                cmd.Parameters.AddWithValue("@igst_p", Val(txtigst.Text))
                cmd.Parameters.AddWithValue("@cgst_p", Val(txtcgst.Text))
                cmd.Parameters.AddWithValue("@service_tax_p", Val(txtcgst.Text))
                cmd.Parameters.AddWithValue("@created_date", Now.ToString)
                cmd.Parameters.AddWithValue("@status", "Active")
                'cmd.ExecuteNonQuery()
                ID = cmd.ExecuteScalar
                cmd.Parameters.Clear()
                IDS += ID & ","

            Next
            IDS = IDS.Substring(0, IDS.ToString.Length - 1)

            ' enter digest data here
            Dim sgst As Double = 0
            Dim igst As Double = 0
            Dim cgst As Double = 0
            Dim stax As Double = 0
            Dim tot As Double = 0
            Dim tottax As Double = 0


            Dim digestid As Double = 0

            'Dim cmd1 As New OdbcCommand
            'cmd1.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO invoice_digest(invoiceid,invoiceno,company_id,company_type_id,branch_code,franchisee_code,client_id,client_name,invoice_type,sgst,igst,cgst,service_tax,status,total_amount,total_tax,created_date,created_by) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) returning inv_digest_id"
            For i As Integer = 0 To tblquot.Rows.Count - 1
                sgst = sgst + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(txtsgst.Text)) / 100)
                igst = igst + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(txtigst.Text)) / 100)
                cgst = cgst + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(txtcgst.Text)) / 100)
                stax = stax + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(txtservicetax.Text)) / 100)
              
                tot = tot + Val(tblquot.Rows(i).Cells(5).Text)
            Next

            tottax = tottax + sgst + igst + cgst + stax

            cmd.Parameters.AddWithValue("@invoiceid", 0)
            cmd.Parameters.AddWithValue("@invoiceno", 0)
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            cmd.Parameters.AddWithValue("@client_id", ledid)
            cmd.Parameters.AddWithValue("@client_name", txtsupplier.Text)
            cmd.Parameters.AddWithValue("@invoice_type", "Expense")
            cmd.Parameters.AddWithValue("@sgst", sgst)
            cmd.Parameters.AddWithValue("@igst", igst)
            cmd.Parameters.AddWithValue("@cgst", cgst)
            cmd.Parameters.AddWithValue("@service_tax", stax)
            cmd.Parameters.AddWithValue("@status", "Active")
            cmd.Parameters.AddWithValue("@total_amount", tot)
            cmd.Parameters.AddWithValue("@total_tax", tottax)
            cmd.Parameters.AddWithValue("@created_date", Now.ToString)
            cmd.Parameters.AddWithValue("@created_by", Session("uname"))
            digestid = cmd.ExecuteScalar
            cmd.Parameters.Clear()
            ' digest data end here
            cmd.CommandText = "UPDATE invoice_details SET invoiceid=(SELECT max(invoiceid)+1 from invoice_details),invoiceno=(SELECT max(invoiceno)+1 from invoice_details where company_id=" & Val(Session("comid")) & ") WHERE inv_id in ( " & IDS & ") and invoice_type='Expense'"
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()


            cmd.CommandText = "UPDATE invoice_digest SET invoiceid=(SELECT invoiceid from invoice_details where inv_id in(" & IDS & ") limit 1),invoiceno=(SELECT invoiceno from invoice_details where inv_id in(" & IDS & ") limit 1 ) WHERE inv_digest_id=" & digestid
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()

            msgct1.InnerHtml = gcdsgn.alertmsg("Expense has been Saved", "success")
        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try

    End Sub

    Public Sub templateentry()
        Dim IDS As String = ""
        Dim ID As Double = 0

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO expense_template(tempno,company_id,company_type_id,branch_code,franchisee_code,temp_type,product_id,product_name,hsn_sac,quant,unit,rate,descrptn,sgst_p,igst_p,cgst_p,service_tax_p,status) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) RETURNING temp_id"
            For i As Integer = 0 To tblquot.Rows.Count - 1
                cmd.Parameters.AddWithValue("@tempno", "0")
                cmd.Parameters.AddWithValue("@company_id", Session("comid"))
                cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
                cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
                cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
                cmd.Parameters.AddWithValue("@temp_type", "Expense Template")
                cmd.Parameters.AddWithValue("@product_id", Val(tblquot.Rows(i).Cells(1).Text))
                cmd.Parameters.AddWithValue("@product_name", tblquot.Rows(i).Cells(2).Text)


                Dim da1 As New OdbcDataAdapter("SELECT * FROM product where pdct_id='" & tblquot.Rows(i).Cells(1).Text & "' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
                Dim dt3 As New DataTable
                da1.Fill(dt3)


                cmd.Parameters.AddWithValue("@hsn_sac", dt3.Rows(0).Item("hsn").ToString)
                cmd.Parameters.AddWithValue("@quant", Val(tblquot.Rows(i).Cells(5).Text))
                cmd.Parameters.AddWithValue("@unit", tblquot.Rows(i).Cells(4).Text)
                cmd.Parameters.AddWithValue("@rate", Val(tblquot.Rows(i).Cells(3).Text))
                cmd.Parameters.AddWithValue("@descrptn", dt3.Rows(0).Item("description").ToString)
                cmd.Parameters.AddWithValue("@sgst_p", Val(txtsgst.Text))
                cmd.Parameters.AddWithValue("@igst_p", Val(txtigst.Text))
                cmd.Parameters.AddWithValue("@cgst_p", Val(txtcgst.Text))
                cmd.Parameters.AddWithValue("@service_tax_p", Val(txtcgst.Text))
                cmd.Parameters.AddWithValue("@status", "Active")
                ID = cmd.ExecuteScalar
                cmd.Parameters.Clear()
                IDS += ID & ","
            Next
            IDS = IDS.Substring(0, IDS.ToString.Length - 1)
            cmd.CommandText = "UPDATE expense_template SET tempno=(SELECT max(tempno)+1 from expense_template where company_id=" & Val(Session("comid")) & ") WHERE temp_id in ( " & IDS & ") and temp_type='Expense Template'"
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()

            msgct1.InnerHtml = gcdsgn.alertmsg("Expense Template has been Saved", "success")

        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try
    End Sub

    Protected Sub btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.ServerClick
        If tblquot.Rows.Count = 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Please add at least one product to save", "error")
        Else
            expenseentry()
        End If
    End Sub


    Protected Sub txtpdctname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpdctname.TextChanged
        If txtpdctname.Text <> "" Then
            Dim da As New OdbcDataAdapter("select pdct_id,hsn,sac,rate,description,unit from product where upper(pdct_name)=upper('" & txtpdctname.Text & "') and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
               
                If ds.Tables(0).Rows(0).Item("rate") IsNot DBNull.Value Then
                    txtprice.Text = ds.Tables(0).Rows(0).Item("rate")
                End If

                If ds.Tables(0).Rows(0).Item("unit") IsNot DBNull.Value Then
                    txtunit.Text = ds.Tables(0).Rows(0).Item("unit")
                End If
                lblpid.Text = ds.Tables(0).Rows(0).Item("pdct_id").ToString
            Else

                txtprice.Text = ""
                txtunit.Text = ""
                lblpid.Text = ""
            End If
            txtquant.Text = 1
        End If
    End Sub
   
    Protected Sub txtquant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquant.TextChanged
        If txtprice.Text <> "" And txtquant.Text <> "" Then
            txtamount.Text = Val(txtprice.Text) * Val(txtquant.Text)
        End If
    End Sub

    Protected Sub btntemplate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntemplate.ServerClick
        If tblquot.Rows.Count = 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Please add at least one product to save", "error")
        Else
            templateentry()
        End If
    End Sub

    Public Sub viewdetails()

        Dim da As New OdbcDataAdapter("select product_id,product_name,rate,unit,quant,price from invoice_details where invoiceno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            tblquot.DataSource = ds
            tblquot.DataBind()
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Invoice No.", "error")
        End If


        Dim da1 As New OdbcDataAdapter("select * from invoice_digest where invoiceno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds1 As New DataSet
        da1.Fill(ds1)
        If ds1.Tables(0).Rows.Count > 0 Then

            If ds1.Tables(0).Rows(0).Item("client_name") IsNot DBNull.Value Then
                txtsupplier.Text = ds1.Tables(0).Rows(0).Item("client_name")
            End If

        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Wrong quotation no", "error")
        End If
    End Sub

    Public Sub viewtemp()

        Dim da As New OdbcDataAdapter("select product_id,product_name,rate,unit,quant,price from expense_template where tempno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            tblquot.DataSource = ds
            tblquot.DataBind()
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Template No.", "error")
        End If

    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearch.Text = "" Then
                Dim da As New OdbcDataAdapter("select distinct invoiceno,client_name,created_date::date from invoice_details where company_id='" & Session("comid") & "' and invoice_type='Expense' and status<>'Inactive' order by invoiceno desc", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("select distinct invoiceno,client_name,created_date::date from invoice_details where upper(client_name) like upper('%" & txtsearch.Text & "%') and invoice_type='Expense' and company_id='" & Session("comid") & "' and status<>'Inactive' order by invoiceno desc", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    grdvleddetails.DataSource = dt
                    grdvleddetails.DataBind()
                    grdvleddetails.Visible = True
                Else
                    grdvleddetails.DataSource = ""
                    grdvleddetails.DataBind()
                    grdvleddetails.Visible = False
                End If

            End If

        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try

    End Sub

    Protected Sub btngetinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngetinfo.ServerClick
        If txtsearch.Text <> "" Then
            Dim da1 As New OdbcDataAdapter("select * from invoice_details where invoiceno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds1 As New DataSet
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                viewdetails()
            Else
                msgct2.InnerHtml = gcdsgn.alertmsg("Wrong quotation no", "error")
            End If
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Please enter Quotation No. to fetch", "error")
        End If

    End Sub

    Protected Sub btngettemp_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngettemp.ServerClick
        If txtsearch.Text <> "" Then
            Dim da1 As New OdbcDataAdapter("select * from expense_template where tempno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds1 As New DataSet
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                viewtemp()
            Else
                msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Template no", "error")
            End If
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Please enter Template No. to fetch", "error")
        End If


    End Sub
End Class
