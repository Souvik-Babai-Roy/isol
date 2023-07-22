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
        dt.Columns.Add("Description")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Price")
        dt.Columns.Add("HSN/SAC")
        dt.Columns.Add("SGST")
        dt.Columns.Add("CGST")
        dt.Columns.Add("IGST")
        dt.Columns.Add("Duty")
        dt.Columns.Add("ServiceTax")
        dt.Columns.Add("CESS")
        If tblquot.Rows.Count > 0 Then
            For Each rr As GridViewRow In tblquot.Rows
                dt.Rows.Add(Server.HtmlDecode(rr.Cells(1).Text), Server.HtmlDecode(rr.Cells(2).Text.ToString), Server.HtmlDecode(rr.Cells(3).Text.ToString), Server.HtmlDecode(rr.Cells(4).Text.ToString), Server.HtmlDecode(rr.Cells(5).Text.ToString), Server.HtmlDecode(rr.Cells(6).Text.ToString), Server.HtmlDecode(rr.Cells(7).Text.ToString), Server.HtmlDecode(rr.Cells(8).Text.ToString), Server.HtmlDecode(rr.Cells(9).Text.ToString), Server.HtmlDecode(rr.Cells(10).Text.ToString), Server.HtmlDecode(rr.Cells(11).Text.ToString), Server.HtmlDecode(rr.Cells(12).Text.ToString), Server.HtmlDecode(rr.Cells(13).Text.ToString))

            Next
        End If
        dt.Rows.Add(lblpid.Text.ToString, txtpdctname.Text, txtdesc.Text.ToString, txtquant.Text.ToString, txtunit.Text.ToString, txtprice.Text, txthsn.Text.ToString, txtsgst.Text.ToString, txtcgst.Text.ToString, txtigst.Text.ToString, txtduty.Text.ToString, txtservicetax.Text.ToString, txtcess.Text.ToString)
        tblquot.DataSource = dt
        tblquot.DataBind()
    End Sub
    Private Sub RemoveAddProducts(ByVal id As Integer)
        dt.Columns.Add("ID")
        dt.Columns.Add("ProductName")
        dt.Columns.Add("Description")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Price")
        dt.Columns.Add("HSN/SAC")
        dt.Columns.Add("SGST")
        dt.Columns.Add("CGST")
        dt.Columns.Add("IGST")
        dt.Columns.Add("Duty")
        dt.Columns.Add("ServiceTax")
        dt.Columns.Add("CESS")

        For i As Integer = 0 To tblquot.Rows.Count - 1
            dt.Rows.Add(Server.HtmlDecode(tblquot.Rows(i).Cells(1).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(2).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(3).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(4).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(5).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(6).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(7).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(8).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(9).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(10).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(11).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(12).Text.ToString), Server.HtmlDecode(tblquot.Rows(i).Cells(13).Text.ToString))
        Next

        dt.Rows.RemoveAt(id)
        tblquot.DataSource = dt
        tblquot.DataBind()
    End Sub
    Protected Sub btnadd_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.ServerClick
        AddProducts()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
        End If
        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
        End If
        Try


        Catch ex As Exception

        End Try

        tblquot.HeaderStyle.BackColor = Drawing.Color.Blue
        tblquot.HeaderStyle.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub tblquot_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles tblquot.RowDeleting
        RemoveAddProducts(e.RowIndex)
    End Sub



    Public Sub invoiceentry()
        Dim ledid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT ledger_id FROM ledger where ledger_name=upper('" & txtclientname.Text & "') and phnno='" & txtphnno.Text & "' and status='Active'", dbcon.con)
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
            cmd.CommandText = "INSERT INTO invoice_details(invoiceid,invoiceno,company_id,company_type_id,com_name,branch_code,franchisee_code,client_id,client_name,phn_no,email,address,invoice_type,product_id,product_name,hsn_sac,quant,unit,rate,price,descrptn,sgst,igst,cgst,service_tax,cess,duty,sgst_p,igst_p,cgst_p,service_tax_p,cess_p,duty_p,remarks,status,created_date,ref) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) RETURNING inv_id"
            For i As Integer = 0 To tblquot.Rows.Count - 1
                cmd.Parameters.AddWithValue("@invoiceid", "0")
                cmd.Parameters.AddWithValue("@invoiceno", "0")
                cmd.Parameters.AddWithValue("@company_id", Session("comid"))
                cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
                cmd.Parameters.AddWithValue("@com_name", txtcompname.Text.ToString)
                cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
                cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
                cmd.Parameters.AddWithValue("@client_id", ledid)
                cmd.Parameters.AddWithValue("@client_name", txtclientname.Text)
                cmd.Parameters.AddWithValue("@phn_no", Val(txtphnno.Text))
                cmd.Parameters.AddWithValue("@email", txtmail.Text)
                cmd.Parameters.AddWithValue("@address", txtaddress.Text)
                cmd.Parameters.AddWithValue("@invoice_type", ddlinvoicetype.SelectedValue)
                cmd.Parameters.AddWithValue("@product_id", Val(tblquot.Rows(i).Cells(1).Text))
                cmd.Parameters.AddWithValue("@product_name", tblquot.Rows(i).Cells(2).Text)
                cmd.Parameters.AddWithValue("@hsn_sac", Server.HtmlDecode(tblquot.Rows(i).Cells(7).Text))
                cmd.Parameters.AddWithValue("@quant", Val(tblquot.Rows(i).Cells(4).Text))
                cmd.Parameters.AddWithValue("@unit", tblquot.Rows(i).Cells(5).Text)
                cmd.Parameters.AddWithValue("@rate", Val(tblquot.Rows(i).Cells(6).Text) / Val(tblquot.Rows(i).Cells(4).Text))
                cmd.Parameters.AddWithValue("@price", Val(tblquot.Rows(i).Cells(6).Text))
                cmd.Parameters.AddWithValue("@descrptn", Server.HtmlDecode(tblquot.Rows(i).Cells(3).Text))
                cmd.Parameters.AddWithValue("@sgst", (Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(8).Text)) / 100)
                cmd.Parameters.AddWithValue("@igst", (Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(10).Text)) / 100)
                cmd.Parameters.AddWithValue("@cgst", (Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(9).Text)) / 100)
                cmd.Parameters.AddWithValue("@service_tax", (Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(12).Text)) / 100)
                cmd.Parameters.AddWithValue("@cess", (Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(13).Text)) / 100)
                cmd.Parameters.AddWithValue("@duty", (Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(11).Text)) / 100)
                cmd.Parameters.AddWithValue("@sgst_p", Val(tblquot.Rows(i).Cells(8).Text))
                cmd.Parameters.AddWithValue("@igst_p", Val(tblquot.Rows(i).Cells(10).Text))
                cmd.Parameters.AddWithValue("@cgst_p", Val(tblquot.Rows(i).Cells(9).Text))
                cmd.Parameters.AddWithValue("@service_tax_p", Val(tblquot.Rows(i).Cells(12).Text))
                cmd.Parameters.AddWithValue("@cess_p", Val(tblquot.Rows(i).Cells(13).Text))
                cmd.Parameters.AddWithValue("@duty_p", Val(tblquot.Rows(i).Cells(11).Text))
                cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                cmd.Parameters.AddWithValue("@status", "Active")
                cmd.Parameters.AddWithValue("@created_date", Now.ToString)
                cmd.Parameters.AddWithValue("@ref", txtref.Text)
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
            Dim cess As Double = 0
            Dim duty As Double = 0
            Dim tot As Double = 0
            Dim tottax As Double = 0


            Dim digestid As Double = 0

            'Dim cmd1 As New OdbcCommand
            'cmd1.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO invoice_digest(invoiceid,invoiceno,company_id,company_type_id,branch_code,franchisee_code,client_id,client_name,phn_no,email,address,invoice_type,sgst,igst,cgst,service_tax,cess,duty,remarks,status,total_amount,total_tax,created_date,created_by) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) returning inv_digest_id"
            For i As Integer = 0 To tblquot.Rows.Count - 1
                sgst = sgst + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(8).Text)) / 100)
                igst = igst + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(10).Text)) / 100)
                cgst = cgst + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(9).Text)) / 100)
                stax = stax + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(12).Text)) / 100)
                cess = cess + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(13).Text)) / 100)
                duty = duty + Convert.ToDouble((Val(tblquot.Rows(i).Cells(6).Text) * Val(tblquot.Rows(i).Cells(11).Text)) / 100)
                tot = tot + Val(tblquot.Rows(i).Cells(6).Text)
            Next

            tottax = tottax + sgst + igst + cgst + stax + duty + cess


            cmd.Parameters.AddWithValue("@invoiceid", 0)
            cmd.Parameters.AddWithValue("@invoiceno", 0)
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            cmd.Parameters.AddWithValue("@client_id", ledid)
            cmd.Parameters.AddWithValue("@client_name", txtclientname.Text)
            cmd.Parameters.AddWithValue("@phn_no", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text)
            cmd.Parameters.AddWithValue("@address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@invoice_type", ddlinvoicetype.SelectedValue)
            cmd.Parameters.AddWithValue("@sgst", sgst)
            cmd.Parameters.AddWithValue("@igst", igst)
            cmd.Parameters.AddWithValue("@cgst", cgst)
            cmd.Parameters.AddWithValue("@service_tax", stax)
            cmd.Parameters.AddWithValue("@cess", cess)
            cmd.Parameters.AddWithValue("@duty", duty)
            cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
            cmd.Parameters.AddWithValue("@status", "Active")
            cmd.Parameters.AddWithValue("@total_amount", tot)
            cmd.Parameters.AddWithValue("@total_tax", tottax)
            cmd.Parameters.AddWithValue("@created_date", Now.ToString)
            cmd.Parameters.AddWithValue("@created_by", Session("uname"))
            digestid = cmd.ExecuteScalar
            cmd.Parameters.Clear()
            ' digest data end here
            cmd.CommandText = "UPDATE invoice_details SET invoiceid=(SELECT max(invoiceid)+1 from invoice_details),invoiceno=(SELECT max(invoiceno)+1 from invoice_details where company_id=" & Val(Session("comid")) & " and invoice_type='" & ddlinvoicetype.SelectedValue & "') WHERE inv_id in ( " & IDS & ") and invoice_type='" & ddlinvoicetype.SelectedValue & "'"
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            'Response.Write(IDS)

            cmd.CommandText = "UPDATE invoice_digest SET invoiceid=(SELECT invoiceid from invoice_details where inv_id in(" & IDS & ") limit 1),invoiceno=(SELECT invoiceno from invoice_details where inv_id in(" & IDS & ") limit 1 ) WHERE inv_digest_id=" & digestid
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()


            msgct1.InnerHtml = gcdsgn.alertmsg("Quotation has been Saved", "success")
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
            invoiceentry()

        End If
    End Sub



    Protected Sub txtquant_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtquant.TextChanged
        If txtpdctname.Text <> "" And txtprice.Text <> "" Then
            Dim price As Double = 0.0
            Dim da As New OdbcDataAdapter("select rate from product where upper(pdct_name)=upper('" & txtpdctname.Text & "') and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                price = ds.Tables(0).Rows(0).Item(0)
            Else
                price = txtprice.Text
            End If
            txtprice.Text = price * txtquant.Text

        End If
    End Sub

    Protected Sub txtpdctname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpdctname.TextChanged
        If txtpdctname.Text <> "" Then
            Dim da As New OdbcDataAdapter("select hsn,sac,rate,description from product where upper(pdct_name)=upper('" & txtpdctname.Text & "') and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("hsn") IsNot DBNull.Value Then
                    txthsn.Text = ds.Tables(0).Rows(0).Item("hsn")
                End If
                If ds.Tables(0).Rows(0).Item("rate") IsNot DBNull.Value Then
                    txtprice.Text = ds.Tables(0).Rows(0).Item("rate")
                End If
                If ds.Tables(0).Rows(0).Item("description") IsNot DBNull.Value Then
                    txtdesc.Text = ds.Tables(0).Rows(0).Item("description")
                End If
            End If
            txtquant.Text = 1
        End If
    End Sub

    Public Sub viewdetails()

        Dim da As New OdbcDataAdapter("select product_id,product_name,descrptn,quant,unit,price,hsn_sac,sgst_p,cgst_p,igst_p,duty_p,service_tax_p,cess_p from invoice_details where invoiceno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "' and invoice_type='" & ddlinvoicetype.SelectedValue & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            tblquot.DataSource = ds
            tblquot.DataBind()
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Invoice ID", "error")
        End If


        Dim da1 As New OdbcDataAdapter("select * from invoice_details where invoiceno='" & txtsearch.Text & "' and invoice_type='" & ddlinvoicetype.SelectedValue & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds1 As New DataSet
        da1.Fill(ds1)
        If ds1.Tables(0).Rows.Count > 0 Then

            If ds1.Tables(0).Rows(0).Item("com_name") IsNot DBNull.Value Then
                txtcompname.Text = ds1.Tables(0).Rows(0).Item("com_name")
            End If
            If ds1.Tables(0).Rows(0).Item("client_name") IsNot DBNull.Value Then
                txtclientname.Text = ds1.Tables(0).Rows(0).Item("client_name")
            End If
            If ds1.Tables(0).Rows(0).Item("phn_no") IsNot DBNull.Value Then
                txtphnno.Text = ds1.Tables(0).Rows(0).Item("phn_no")
            End If
            If ds1.Tables(0).Rows(0).Item("email") IsNot DBNull.Value Then
                txtmail.Text = ds1.Tables(0).Rows(0).Item("email")
            End If
            If ds1.Tables(0).Rows(0).Item("address") IsNot DBNull.Value Then
                txtaddress.Text = ds1.Tables(0).Rows(0).Item("address")
            End If
            If ds1.Tables(0).Rows(0).Item("remarks") IsNot DBNull.Value Then
                txtremarks.Text = ds1.Tables(0).Rows(0).Item("remarks")
            End If
            If ds1.Tables(0).Rows(0).Item("ref") IsNot DBNull.Value Then
                txtref.Text = ds1.Tables(0).Rows(0).Item("ref")
            End If
            If ds1.Tables(0).Rows(0).Item("sgst_p") IsNot DBNull.Value Then
                txtsgst.Text = ds1.Tables(0).Rows(0).Item("sgst_p")
            End If
            If ds1.Tables(0).Rows(0).Item("igst_p") IsNot DBNull.Value Then
                txtigst.Text = ds1.Tables(0).Rows(0).Item("igst_p")
            End If
            If ds1.Tables(0).Rows(0).Item("cgst_p") IsNot DBNull.Value Then
                txtcgst.Text = ds1.Tables(0).Rows(0).Item("cgst_p")
            End If
            If ds1.Tables(0).Rows(0).Item("service_tax_p") IsNot DBNull.Value Then
                txtservicetax.Text = ds1.Tables(0).Rows(0).Item("service_tax_p")
            End If
            If ds1.Tables(0).Rows(0).Item("cess_p") IsNot DBNull.Value Then
                txtcess.Text = ds1.Tables(0).Rows(0).Item("cess_p")
            End If
            If ds1.Tables(0).Rows(0).Item("duty_p") IsNot DBNull.Value Then
                txtduty.Text = ds1.Tables(0).Rows(0).Item("duty_p")
            End If
            ddlinvoicetype.SelectedValue = ds1.Tables(0).Rows(0).Item("invoice_type")

        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Wrong quotation no", "error")
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearch.Text = "" Then
                Dim da As New OdbcDataAdapter("select distinct invoiceno,client_name,phn_no,created_date::date,invoice_type from invoice_details where company_id='" & Session("comid") & "' and invoice_type='" & ddlinvoicetype.SelectedValue & "' and status<>'Inactive' order by invoiceno desc", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("select distinct invoiceno,client_name,phn_no,created_date::date,invoice_type from invoice_details where upper(client_name) like upper('%" & txtsearch.Text & "%')  and invoice_type='" & ddlinvoicetype.SelectedValue & "' and company_id='" & Session("comid") & "' and status<>'Inactive' order by invoiceno desc", dbcon.con)
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
            Dim da1 As New OdbcDataAdapter("select * from invoice_details where invoiceno='" & txtsearch.Text & "'  and invoice_type='" & ddlinvoicetype.SelectedValue & "' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds1 As New DataSet
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                viewdetails()
            Else
                msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Invoice no", "error")
            End If
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Please enter Invoice No. to fetch", "error")
        End If

    End Sub

End Class
