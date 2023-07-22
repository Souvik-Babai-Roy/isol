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
            msgct2.InnerText = ""
        End If

        'tblquot.HeaderStyle.BackColor = Drawing.Color.Blue
        'tblquot.HeaderStyle.ForeColor = Drawing.Color.White
    End Sub

    Protected Sub tblquot_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles tblquot.RowDeleting
        RemoveAddProducts(e.RowIndex)
    End Sub

    'Public Function getquoteid() As Integer
    '    Dim id As Integer

    '    Dim da As New OdbcDataAdapter("select max(quoteid)+1 from estimate where company_id='" & Session("comid") & "'", dbcon.con)
    '    Dim ds As New DataSet
    '    da.Fill(ds)
    '    If ds.Tables(0).Rows(0).Item(0) Is DBNull.Value Then
    '        id = 1
    '    Else
    '        id = ds.Tables(0).Rows(0).Item(0)
    '    End If
    '    Return id
    'End Function
    'Public Function getquoteno() As Integer
    '    Dim id As Integer

    '    Dim da As New OdbcDataAdapter("select max(quoteno)+1 from estimate where company_id='" & Session("comid") & "' and est_type='Quotation'", dbcon.con)
    '    Dim ds As New DataSet
    '    da.Fill(ds)
    '    If ds.Tables(0).Rows(0).Item(0) Is DBNull.Value Then
    '        id = 1
    '    Else
    '        id = ds.Tables(0).Rows(0).Item(0)
    '    End If
    '    Return id
    'End Function

    Public Sub estimateentry()
        Dim ledid As Integer = 0
        Dim da As New OdbcDataAdapter("SELECT ledger_id FROM ledger where ledger_name=upper('" & txtclientname.Text & "') and phnno='" & txtphnno.Text & "' and status='Active'", dbcon.con)
        Dim dt2 As New DataTable
        da.Fill(dt2)
        If dt2.Rows.Count > 0 Then
            ledid = dt2.Rows(0).Item(0)
        End If

        Dim dnow As DateTime = Now.ToString
        Dim qv As DateTime
        qv = dnow.AddDays(txtvaliddays.Text).ToString()
        Dim IDS As String = ""
        Dim ID As Double = 0


        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO estimate_details(quoteid,quoteno,company_id,company_type_id,com_name,branch_code,franchisee_code,client_id,client_name,phn_no,email,address,valid_till,est_type,product_id,product_name,hsn_sac,quant,unit,rate,price,descrptn,sgst,igst,cgst,service_tax,cess,duty,sgst_p,igst_p,cgst_p,service_tax_p,cess_p,duty_p,remarks,status,created_date,ref) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) RETURNING est_id"
            For i As Integer = 0 To tblquot.Rows.Count - 1
                cmd.Parameters.AddWithValue("@quoteid", "0")
                cmd.Parameters.AddWithValue("@quoteno", "0")
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
                cmd.Parameters.AddWithValue("@valid_till", qv)
                cmd.Parameters.AddWithValue("@est_type", ddlestimatetype.SelectedValue)
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
            cmd.CommandText = "INSERT INTO estimate_digest(quoteid,quoteno,company_id,company_type_id,branch_code,franchisee_code,client_id,client_name,phn_no,email,address,valid_till,est_type,sgst,igst,cgst,service_tax,cess,duty,remarks,status,total_amount,total_tax,created_date,created_by) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) returning digest_id"
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


            cmd.Parameters.AddWithValue("@quoteid", 0)
            cmd.Parameters.AddWithValue("@quoteno", 0)
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            cmd.Parameters.AddWithValue("@client_id", ledid)
            cmd.Parameters.AddWithValue("@client_name", txtclientname.Text)
            cmd.Parameters.AddWithValue("@phn_no", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@email", txtmail.Text)
            cmd.Parameters.AddWithValue("@address", txtaddress.Text)
            cmd.Parameters.AddWithValue("@valid_till", qv)
            cmd.Parameters.AddWithValue("@est_type", ddlestimatetype.SelectedValue)
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
            cmd.CommandText = "UPDATE estimate_details SET quoteid=(SELECT max(quoteid)+1 from estimate_details),quoteno=(SELECT max(quoteno)+1 from estimate_details where company_id=" & Val(Session("comid")) & " and est_type='" & ddlestimatetype.SelectedValue & "') WHERE est_id in ( " & IDS & ") and est_type='" & ddlestimatetype.SelectedValue & "'"
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            'Response.Write(IDS)

            cmd.CommandText = "UPDATE estimate_digest SET quoteid=(SELECT quoteid from estimate_details where est_id in(" & IDS & ") limit 1),quoteno=(SELECT quoteno from estimate_details where est_id in(" & IDS & ") limit 1 ) WHERE digest_id=" & digestid
            cmd.ExecuteScalar()
            cmd.Parameters.Clear()

            msgct1.InnerHtml = gcdsgn.alertmsg("Quotation has been Saved", "success")
        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try
        'Response.Redirect("Quotation.aspx", False)

    End Sub

    Protected Sub btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.ServerClick
        If tblquot.Rows.Count = 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Please add at least one product to save", "error")
        Else
            estimateentry()

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
            Dim da As New OdbcDataAdapter("select pdct_id,hsn,sac,rate,description,unit from product where upper(pdct_name)=upper('" & txtpdctname.Text & "') and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
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
                If ds.Tables(0).Rows(0).Item("unit") IsNot DBNull.Value Then
                    txtunit.Text = ds.Tables(0).Rows(0).Item("unit")
                End If
                lblpid.Text = "#" + ds.Tables(0).Rows(0).Item("pdct_id").ToString
            Else
                txthsn.Text = ""
                txtprice.Text = ""
                txtdesc.Text = ""
                lblpid.Text = ""
            End If
            txtquant.Text = 1
        End If
    End Sub
    Public Sub viewdetails()

        Dim da As New OdbcDataAdapter("select product_id,product_name,descrptn,quant,unit,price,hsn_sac,sgst_p,cgst_p,igst_p,duty_p,service_tax_p,cess_p from estimate_details where quoteno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            tblquot.DataSource = ds
            tblquot.DataBind()
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Quotation ID", "error")
        End If


        Dim da1 As New OdbcDataAdapter("select * from estimate_details where quoteno='" & txtsearch.Text & "' and est_type='" & ddlestimatetype.SelectedValue & "' and company_id='" & Session("comid") & "'", dbcon.con)
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
            If ds1.Tables(0).Rows(0).Item("valid_till") IsNot DBNull.Value Then
                txtvaliddays.Text = (Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("valid_till")).Date - Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("created_date")).Date).TotalDays
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
            ddlestimatetype.SelectedValue = ds1.Tables(0).Rows(0).Item("est_type")

        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Wrong quotation no", "error")
        End If
    End Sub


    Protected Sub btngetinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngetinfo.ServerClick
        If txtsearch.Text <> "" Then
            Dim da1 As New OdbcDataAdapter("select * from estimate_details where quoteno='" & txtsearch.Text & "'  and est_type='" & ddlestimatetype.SelectedValue & "' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds1 As New DataSet
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                viewdetails()
                Dim htmltext As String = ""
                Quotationformattwo(htmltext, 2)
                viewgstinvoice.InnerHtml = htmltext.ToString
                btngstprint.Visible = True
            Else
                msgct2.InnerHtml = gcdsgn.alertmsg("Wrong quotation no", "error")
                btngstprint.Visible = False
            End If
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Please enter Quotation No. to fetch", "error")
        End If

    End Sub

    Protected Sub btnviewestimate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnviewestimate.ServerClick
        If txtsearch.Text <> "" Then
            Dim da1 As New OdbcDataAdapter("select * from estimate_details where quoteno='" & txtsearch.Text & "'  and est_type='" & ddlestimatetype.SelectedValue & "' and company_id='" & Session("comid") & "'", dbcon.con)
            Dim ds1 As New DataSet
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Dim htmltext As String = ""
                If ddlformat.SelectedValue = 1 Then
                    QuotationformatOne(htmltext, 2)
                ElseIf ddlformat.SelectedValue = 2 Then
                    Quotationformattwo(htmltext, 2)
                End If

                viewgstinvoice.InnerHtml = htmltext.ToString
                btngstprint.Visible = True
            Else
                msgct2.InnerHtml = gcdsgn.alertmsg("Wrong quotation no", "error")
                btngstprint.Visible = False
            End If
        Else
            msgct2.InnerHtml = gcdsgn.alertmsg("Please enter Quotation No. to View", "error")
        End If
    End Sub

    ' '' ''Private Sub QuotationformatOne(ByRef htmltext As String, ByVal quotationid As Double)
    ' '' ''    Dim ss As StringBuilder = New StringBuilder()
    ' '' ''    Dim currenttime As DateTime = Now
    ' '' ''    Dim p As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")
    ' '' ''    ' new header end here
    ' '' ''    Dim tbl As New DataTable
    ' '' ''    ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
    ' '' ''    ss.Append("<div style='position:relative;border: 2px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")

    ' '' ''    ' header div
    ' '' ''    ss.Append("<div style='border-bottom: 5px solid black; height:110px;width:100%;'>")
    ' '' ''    ss.Append("<div class='float-left' style=' border:0 px solid #000000;'><img src='" & p & "img/letterhead.png'  alt='logo' width='180' height='90' border=0'></div>")
    ' '' ''    ss.Append("<div class='float-right' style='text-align:center;padding: 20px 0;border: 0px solid #000000;height:90px;'><h1>Quotation</h1></div><div></div>")
    ' '' ''    ss.Append("</div>")
    ' '' ''    '' header div end here

    ' '' ''    Dim da As New OdbcDataAdapter("select * from company_details where id='" & Session("comid") & "' and deactive_date>'" & Now.ToString & "'", dbcon.con)
    ' '' ''    Dim ds As New DataSet
    ' '' ''    da.Fill(ds)
    ' '' ''    Dim cmname As String = ds.Tables(0).Rows(0).Item("company_name").ToString
    ' '' ''    Dim adrs As String = ds.Tables(0).Rows(0).Item("address").ToString
    ' '' ''    Dim phn As String = ds.Tables(0).Rows(0).Item("phone_no").ToString
    ' '' ''    Dim mail As String = ds.Tables(0).Rows(0).Item("email_id").ToString
    ' '' ''    Dim gst As String = ds.Tables(0).Rows(0).Item("gst_no").ToString
    ' '' ''    Dim pan As String = ds.Tables(0).Rows(0).Item("pan_no").ToString
    ' '' ''    Dim cntctp As String = ds.Tables(0).Rows(0).Item("contact_person_name").ToString


    ' '' ''    'body starts here
    ' '' ''    ss.Append("<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp " & cmname & "</b></br>")

    ' '' ''    'ss.Append("<div style='border:10px solid #000000;'>")



    ' '' ''    'ss.Append("<div style='text-align:center'>")
    ' '' ''    'ss.Append("<div style='float: left;font-size: 14px;'>")
    ' '' ''    ss.Append("<div style='font-size: 14px; float: left;'>")
    ' '' ''    ss.Append("<table>")
    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td style='vertical-align: text-top'>Address</td> ")
    ' '' ''    ss.Append("<td> : " & adrs & "</td>")
    ' '' ''    ss.Append("</tr>")


    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td>Phone</td> ")
    ' '' ''    ss.Append("<td> : " & phn & "</td>")
    ' '' ''    ss.Append("</tr>")

    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td>e-mail</td> ")
    ' '' ''    ss.Append("<td> : " & mail & "</td>")
    ' '' ''    ss.Append("</tr>")

    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td>GSTIN</td> ")
    ' '' ''    ss.Append("<td> : " & gst & "</td>")
    ' '' ''    ss.Append("</tr>")


    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td>PAN No.</td> ")
    ' '' ''    ss.Append("<td> : " & pan & "</td>")
    ' '' ''    ss.Append("</tr>")
    ' '' ''    ss.Append("</table>")
    ' '' ''    ss.Append("</div>")



    ' '' ''    Dim da1 As New OdbcDataAdapter("select * from estimate_digest where quoteno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
    ' '' ''    Dim ds1 As New DataSet
    ' '' ''    da1.Fill(ds1)
    ' '' ''    Dim qdate As String = Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("created_date")).Date.ToString("dd-MMM-yyyy")
    ' '' ''    Dim cid As String = ""
    ' '' ''    If ds1.Tables(0).Rows(0).Item("client_id") <> 0 Then
    ' '' ''        cid = ds1.Tables(0).Rows(0).Item("client_id").ToString
    ' '' ''    Else
    ' '' ''        cid = ""
    ' '' ''    End If
    ' '' ''    Dim vdate As String = Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("valid_till")).Date.ToString("dd-MMM-yyyy")
    ' '' ''    Dim total As Double = Convert.ToDouble(ds1.Tables(0).Rows(0).Item("total_amount").ToString)
    ' '' ''    total = Math.Round(total, 2)
    ' '' ''    total = Math.Round(Decimal.Parse(total), 2, MidpointRounding.AwayFromZero)
    ' '' ''    Dim tottax As Double = ds1.Tables(0).Rows(0).Item("total_tax").ToString
    ' '' ''    Dim sgstamnt As Double = ds1.Tables(0).Rows(0).Item("sgst").ToString
    ' '' ''    Dim cgstamnt As Double = ds1.Tables(0).Rows(0).Item("cgst").ToString
    ' '' ''    Dim igstamnt As Double = ds1.Tables(0).Rows(0).Item("igst").ToString
    ' '' ''    Dim srvcamnt As Double = ds1.Tables(0).Rows(0).Item("service_tax").ToString
    ' '' ''    Dim dutyamnt As Double = ds1.Tables(0).Rows(0).Item("cess").ToString
    ' '' ''    Dim cessamnt As Double = ds1.Tables(0).Rows(0).Item("duty").ToString


    ' '' ''    Dim da2 As New OdbcDataAdapter("select distinct sgst_p,cgst_p,igst_p,service_tax_p,cess_p,duty_p from estimate_details where quoteno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
    ' '' ''    Dim ds2 As New DataSet
    ' '' ''    da2.Fill(ds2)

    ' '' ''    Dim sgstp As Double = ds2.Tables(0).Rows(0).Item("sgst_p").ToString
    ' '' ''    Dim cgstp As Double = ds2.Tables(0).Rows(0).Item("cgst_p").ToString
    ' '' ''    Dim igstp As Double = ds2.Tables(0).Rows(0).Item("igst_p").ToString
    ' '' ''    Dim srvcp As Double = ds2.Tables(0).Rows(0).Item("service_tax_p").ToString
    ' '' ''    Dim dutyp As Double = ds2.Tables(0).Rows(0).Item("cess_p").ToString
    ' '' ''    Dim cessp As Double = ds2.Tables(0).Rows(0).Item("duty_p").ToString





    ' '' ''    ss.Append("<div style='display:inline-block;margin-bottom: 5em;'></div>")
    ' '' ''    ss.Append("<div style='float: right;font-size: 15px;'>")
    ' '' ''    ss.Append("<table>")

    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td><b>Date of quotation<b></td> ")
    ' '' ''    ss.Append("<td style='font-size: 14px;'> : " & qdate & "</td>")
    ' '' ''    ss.Append("</tr>")

    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td><b>Quotation ID<b></td> ")
    ' '' ''    ss.Append("<td> : #" & txtsearch.Text & "</td>")
    ' '' ''    ss.Append("</tr>")

    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td><b>Customer ID<b></td> ")
    ' '' ''    ss.Append("<td style='font-size: 14px;'> : #" & cid & "</td>")
    ' '' ''    ss.Append("</tr>")


    ' '' ''    ss.Append("<tr style='text-align:left'>")
    ' '' ''    ss.Append("<td ><b>Quotation valid until<b></td> ")
    ' '' ''    ss.Append("<td style='font-size: 14px;'> : " & vdate & "</td>")
    ' '' ''    ss.Append("</tr>")


    ' '' ''    ss.Append("<tr>")
    ' '' ''    ss.Append("<td>&nbsp;</td>")
    ' '' ''    ss.Append("<td>&nbsp;</td>")
    ' '' ''    ss.Append("</tr>")

    ' '' ''    ss.Append("</table>")
    ' '' ''    ss.Append("</div>")




    ' '' ''    ss.Append("<div style='margin-bottom: 2em;'></div>") ' clear div
    ' '' ''    ss.Append("<div>")

    ' '' ''    ss.Append("<div style='display: inline-block;float:left;text-align: left; border: 0px solid black;font-size: 15px;'>Quotation to</br>")
    ' '' ''    ss.Append("<b>OFFICE OF THE PRINCIPAL</b></br>")
    ' '' ''    ss.Append("BIJU PATTANAYAK INTITUTE OF TECHNOLOGY,PURI</br>")
    ' '' ''    ss.Append("Address:At-Moto Po-Chapamanik via-Bramhagir Dist-Puri,PIN-7552011</br>")
    ' '' ''    ss.Append("Phone:06742375811</br>")

    ' '' ''    ss.Append("<b>Comments or Special Instructions:</b> None</br>")
    ' '' ''    'ss.Append("</br>")


    ' '' ''    ss.Append("</div>")
    ' '' ''    ss.Append("<div style='display: inline-block;border: 0px solid black;'></div>")
    ' '' ''    ss.Append("<div style='display: inline-block;float:right;text-align: right; border: 0px solid black;'>Preared By:Mano Kumar sahoo</div>")
    ' '' ''    ss.Append("</div>")
    ' '' ''    ss.Append("</br>")

    ' '' ''    ss.Append("<div style='margin-bottom: 8em;'></div>") ' clear div
    ' '' ''    ss.Append("<center><b>Ref: Providing seamless FTTH broadband internet service of Bharat Sanchar Nigam Limited</b></center>")
    ' '' ''    ss.Append("<div style='margin-bottom: 1em;'></div>") ' clear div


    ' '' ''    ss.Append("<div style='border: 0px solid black;'>") ' new table div

    ' '' ''    ss.Append("<table style='width:100%; border: 2px solid black;border-collapse: collapse;'>")
    ' '' ''    ss.Append("<tr style='border: 2px solid black; text-align:center; font-weight:bold;background-color:#f7f7f7;'>")
    ' '' ''    ss.Append("<td style='width:3px;border: 2px solid black;'>#Sr</td>")
    ' '' ''    ss.Append("<td style='width:180px;border: 2px solid black;'>Description</td>")
    ' '' ''    ss.Append("<td style='width:30px;border: 2px solid black;' >Rate</td>")
    ' '' ''    ss.Append("<td style='width:30px;border: 2px solid black;'>Quantity</td>")
    ' '' ''    ss.Append("<td style='width:60px;border: 2px solid black;'>Amount</td>")
    ' '' ''    ss.Append("</tr>")


    ' '' ''    Dim maxitemcount As Integer = 9
    ' '' ''    Dim itemtbl As New DataTable
    ' '' ''    Dim rmsg As String = ""
    ' '' ''    dbcon.TableReturn("select * from estimate_details where quoteid=" & Val(txtsearch.Text.ToString), rmsg, itemtbl)
    ' '' ''    If rmsg = "ok" Then
    ' '' ''    Else
    ' '' ''        ' code here error meassage
    ' '' ''        Exit Sub
    ' '' ''    End If

    ' '' ''    maxitemcount = itemtbl.Rows.Count - 1

    ' '' ''    For i As Integer = 0 To maxitemcount
    ' '' ''        Dim taxstring As String = ""
    ' '' ''        If Val(itemtbl.Rows(i).Item("sgst_p").ToString()) > 0 Then
    ' '' ''            taxstring += "SGST:" & itemtbl.Rows(i).Item("sgst_p").ToString() & "%,"
    ' '' ''        End If
    ' '' ''        If Val(itemtbl.Rows(i).Item("igst_p").ToString()) > 0 Then
    ' '' ''            taxstring += "IGST:" & itemtbl.Rows(i).Item("igst_p").ToString() & "%,"
    ' '' ''        End If
    ' '' ''        If Val(itemtbl.Rows(i).Item("cgst_p").ToString()) > 0 Then
    ' '' ''            taxstring += "CGST:" & itemtbl.Rows(i).Item("cgst_p").ToString() & "%,"
    ' '' ''        End If
    ' '' ''        If Val(itemtbl.Rows(i).Item("service_tax_p").ToString()) > 0 Then
    ' '' ''            taxstring += "SERVICE TAX:" & itemtbl.Rows(i).Item("service_tax_p").ToString() & "%,"
    ' '' ''        End If
    ' '' ''        If Val(itemtbl.Rows(i).Item("cess_p").ToString()) > 0 Then
    ' '' ''            taxstring += "CESS:" & itemtbl.Rows(i).Item("cess_p").ToString() & "%,"
    ' '' ''        End If
    ' '' ''        If Val(itemtbl.Rows(i).Item("duty_p").ToString()) > 0 Then
    ' '' ''            taxstring += "DUTY:" & itemtbl.Rows(i).Item("duty_p").ToString() & "%,"
    ' '' ''        End If
    ' '' ''        taxstring = taxstring.Substring(0, taxstring.ToString.Length - 1)
    ' '' ''        'If i Mod 2 = 0 Then
    ' '' ''        '    ss.Append("<tr style='border: 0px solid black;background-color:#f7f7f7; '>")
    ' '' ''        'Else
    ' '' ''        '    ss.Append("<tr style='border: 0px solid black;'>")
    ' '' ''        'End If
    ' '' ''        ss.Append("<tr style='border: 0px solid black; font-size:14px;'>")
    ' '' ''        ss.Append("<td style='width:3px;border-left: 1px solid black;text-align:center;'>" & i + 1 & "</td>")
    ' '' ''        ss.Append("<td style='width:180px;border: 0px solid black;'><b>" & itemtbl.Rows(i).Item("product_name").ToString & "</b></br><div style='font-size:12px;'><b>Description:</b>" & itemtbl.Rows(i).Item("descrptn").ToString & "</br><b>Tax:</b>" & taxstring & "</div></td>")
    ' '' ''        ss.Append("<td style='width:30px;border: 0px solid black;text-align:center;' >" & Val(itemtbl.Rows(i).Item("rate").ToString).ToString("#.00") & "</br><b>@per " & itemtbl.Rows(i).Item("unit").ToString & "</b></td>")
    ' '' ''        ss.Append("<td style='width:30px;border: 0px solid black;text-align:center;'>" & itemtbl.Rows(i).Item("quant").ToString & "</br><b>" & itemtbl.Rows(i).Item("unit").ToString & "</b></td>")
    ' '' ''        ss.Append("<td style='width:60px;border-right: 1px solid black;text-align:center;'>" & Val(itemtbl.Rows(i).Item("price").ToString).ToString("#.00") & "</td>")
    ' '' ''        ss.Append("</tr>")
    ' '' ''    Next

    ' '' ''    ' if product not exists
    ' '' ''    For i As Integer = maxitemcount To 8
    ' '' ''        ss.Append("<tr style='border: 0px solid black; font-size:14px;'>")
    ' '' ''        ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></br></br></br></td>")
    ' '' ''        ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
    ' '' ''        ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
    ' '' ''        ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
    ' '' ''        ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
    ' '' ''        ss.Append("</tr>")
    ' '' ''    Next
    ' '' ''    ' end here
    ' '' ''    Dim totalamount As Double = Val(itemtbl.Compute("Sum(price)", "").ToString()) ' Val(itemtbl.Select("sum(price)").ToString)
    ' '' ''    ss.Append("<tr style='border: 2px solid black;background-color:#f7f7f7;'>")
    ' '' ''    ss.Append("<td colspan='4' style='text-align:right;'><b>Total Quotation Amount </b></td>")
    ' '' ''    ss.Append("<td style='text-align:center;'> <b>" & totalamount.ToString("#.00") & "</b></td>")
    ' '' ''    ss.Append("</tr>")


    ' '' ''    ss.Append("</table>")




    ' '' ''    'ss.Append("hi")
    ' '' ''    ss.Append("</div>")

    ' '' ''    ss.Append("<div>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("If you have any questions concerning this quotation, please contact Mr Manoj Kumar Sahoo at 9658792134 or e-mail at starvision.puri@gmail.com")
    ' '' ''    ss.Append("<CENTER><b><p style='border: 0px solid black; font-size:14px;'> TERMS AND CONDITIONS</p></b></CENTER>")

    ' '' ''    ss.Append("<div style='border: 0px solid black; font-size:12px;'>")
    ' '' ''    ss.Append("<b>I.The customer </b> who is entitled for any concessional rate of tax either under GST should furnish the necessary concessional declaration form along with the payment to issue Sales Order and charge GST accordingly in the invoice.</br>")
    ' '' ''    ss.Append("<b>II.The company </b>  shall not pay any interest, damages (including liquidated risk purchase) etc for non delivery of material for the reasons beyond its control.</br>")
    ' '' ''    ss.Append("<b>III.All payments </b>  should be made only in Indian Rupees vide (i) Demand Draft(s) / Pay Order(s) / Cheque(s) favoring STAR VISION payable at the city where STAR VISION’s Offices are located, or (ii) electronic wire transfer into the STAR VISIONS’s designated bank account, accompanied by documentary evidence certified by the DPO’s bank that the payment has been transferred to the STAR VISION’s bank account or (iii) Bill desk platform (iv) any other mode as intimated by STAR VISION.</br>")
    ' '' ''    ss.Append("<b>IV.Product warranty </b>  will be provided by the product manufacturer directy. The seller is not liable for any warranty or damage of  the product.</br>")
    ' '' ''    ss.Append("</div>")


    ' '' ''    ss.Append("</div>")




    ' '' ''    'ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("</br>")
    ' '' ''    ss.Append("<CENTER><b><p> THANK YOU FOR YOUR BUSINESS!!</p></b></CENTER>")











    ' '' ''    'For I As Integer = 0 To 63
    ' '' ''    '    ss.Append("</br>")
    ' '' ''    'Next

    ' '' ''    'For I As Integer = 0 To 20
    ' '' ''    '    ss.Append("</br>")
    ' '' ''    'Next

    ' '' ''    ss.Append("</div>")
    ' '' ''    ss.Append("</div>")

    ' '' ''    htmltext = ss.ToString

    ' '' ''End Sub


    Private Sub QuotationformatOne(ByRef htmltext As String, ByVal quotationid As Double)
        Dim ss As StringBuilder = New StringBuilder()
        Dim currenttime As DateTime = Now
        Dim p As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")
        ' new header end here
        Dim tbl As New DataTable
        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 2px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")

        ' header div
        ss.Append("<div style='border-bottom: 5px solid black; height:110px;width:100%;'>")
        ss.Append("<div class='float-left' style=' border:0 px solid #000000;'><img src='" & p & "img/letterhead1.png'  alt='logo' width='180' height='90' border=0'></div>")
        ss.Append("<div class='float-right' style='text-align:center;padding: 20px 0;border: 0px solid #000000;height:90px;'><h1>" & ddlquotehead.SelectedValue & "</h1></div><div></div>")
        ss.Append("</div>")
        '' header div end here

        Dim da As New OdbcDataAdapter("select * from company_details where id='" & Session("comid") & "' and deactive_date>'" & Now.ToString & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim cmname As String = ds.Tables(0).Rows(0).Item("company_name").ToString
        Dim adrs As String = ds.Tables(0).Rows(0).Item("address").ToString
        Dim phn As String = ds.Tables(0).Rows(0).Item("phone_no").ToString
        Dim mail As String = ds.Tables(0).Rows(0).Item("email_id").ToString
        Dim gst As String = ds.Tables(0).Rows(0).Item("gst_no").ToString
        Dim pan As String = ds.Tables(0).Rows(0).Item("pan_no").ToString
        Dim cntctp As String = ds.Tables(0).Rows(0).Item("contact_person_name").ToString


        'body starts here
        ss.Append("<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp " & cmname & "</b></br>")

        ss.Append("<div style='font-size: 14px; float: left;'>")
        ss.Append("<table>")
        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td style='vertical-align: text-top'>Address</td> ")
        ss.Append("<td> : " & adrs & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>Phone</td> ")
        ss.Append("<td> : " & phn & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>e-mail</td> ")
        ss.Append("<td> : " & mail & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>GSTIN</td> ")
        ss.Append("<td> : " & gst & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>PAN No.</td> ")
        ss.Append("<td> : " & pan & "</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")



        Dim da1 As New OdbcDataAdapter("select * from estimate_digest where quoteno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds1 As New DataSet
        da1.Fill(ds1)
        Dim qdate As String = Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("created_date")).Date.ToString("dd-MMM-yyyy")
        Dim cid As String = ""
        If ds1.Tables(0).Rows(0).Item("client_id") <> 0 Then
            cid = ds1.Tables(0).Rows(0).Item("client_id").ToString
        Else
            cid = ""
        End If
        Dim vdate As String = Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("valid_till")).Date.ToString("dd-MMM-yyyy")
        Dim total As Double = Convert.ToDouble(ds1.Tables(0).Rows(0).Item("total_amount").ToString)
        total = Math.Round(total, 2)
        total = Math.Round(Decimal.Parse(total), 2, MidpointRounding.AwayFromZero)
        Dim tottax As Double = ds1.Tables(0).Rows(0).Item("total_tax").ToString
        Dim sgstamnt As Double = ds1.Tables(0).Rows(0).Item("sgst").ToString
        Dim cgstamnt As Double = ds1.Tables(0).Rows(0).Item("cgst").ToString
        Dim igstamnt As Double = ds1.Tables(0).Rows(0).Item("igst").ToString
        Dim srvcamnt As Double = ds1.Tables(0).Rows(0).Item("service_tax").ToString
        Dim dutyamnt As Double = ds1.Tables(0).Rows(0).Item("cess").ToString
        Dim cessamnt As Double = ds1.Tables(0).Rows(0).Item("duty").ToString


        Dim da2 As New OdbcDataAdapter("select distinct sgst_p,cgst_p,igst_p,service_tax_p,cess_p,duty_p,ref from estimate_details where quoteno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds2 As New DataSet
        da2.Fill(ds2)

        Dim sgstp As Double = ds2.Tables(0).Rows(0).Item("sgst_p").ToString
        Dim cgstp As Double = ds2.Tables(0).Rows(0).Item("cgst_p").ToString
        Dim igstp As Double = ds2.Tables(0).Rows(0).Item("igst_p").ToString
        Dim srvcp As Double = ds2.Tables(0).Rows(0).Item("service_tax_p").ToString
        Dim dutyp As Double = ds2.Tables(0).Rows(0).Item("cess_p").ToString
        Dim cessp As Double = ds2.Tables(0).Rows(0).Item("duty_p").ToString
        Dim ref As String = ds2.Tables(0).Rows(0).Item("ref").ToString

        Dim uid As Integer = 0
        Dim da3 As New OdbcDataAdapter("select * from user_master where user_master_id='" & Session("uid") & "'", dbcon.con)
        Dim ds3 As New DataSet
        da3.Fill(ds3)
        Dim umail As String = ds3.Tables(0).Rows(0).Item("email")
        Dim uphn As String = ds3.Tables(0).Rows(0).Item("phn_no")




        ss.Append("<div style='display:inline-block;margin-bottom: 5em;'></div>")
        ss.Append("<div style='float: right;font-size: 15px;'>")
        ss.Append("<table>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td><b>Date of quotation<b></td> ")
        ss.Append("<td style='font-size: 14px;'> : " & qdate & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td><b>Quotation ID<b></td> ")
        ss.Append("<td> : #" & txtsearch.Text & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td><b>Customer ID<b></td> ")
        ss.Append("<td style='font-size: 14px;'> : #" & cid & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td ><b>Quotation valid until<b></td> ")
        ss.Append("<td style='font-size: 14px;'> : " & vdate & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr>")
        ss.Append("<td>&nbsp;</td>")
        ss.Append("<td>&nbsp;</td>")
        ss.Append("</tr>")

        ss.Append("</table>")
        ss.Append("</div>")




        ss.Append("<div style='margin-bottom: 2em;'></div>") ' clear div
        ss.Append("<div>")

        ss.Append("<div style='display: inline-block;float:left;text-align: left; border: 0px solid black;font-size: 15px;'>Quotation to</br>")
        ss.Append("<b>" & txtclientname.Text & "</b></br>")
        ss.Append("" & txtcompname.Text & "</br>")
        ss.Append("Address: " & txtaddress.Text & "</br>")
        ss.Append("Phone: " & txtphnno.Text & "</br>")

        ss.Append("<b>Comments or Special Instructions:</b> " & txtremarks.Text & "</br>")
        'ss.Append("</br>")


        ss.Append("</div>")
        ss.Append("<div style='display: inline-block;border: 0px solid black;'></div>")
        ss.Append("<div style='display: inline-block;float:right;text-align: right; border: 0px solid black;'>Prepared By: " & Session("uname") & "</div>")
        ss.Append("</div>")
        ss.Append("</br>")

        ss.Append("<div style='margin-bottom: 8em;'></div>") ' clear div
        ss.Append("<center><b>Ref: " & ref & "</b></center>")
        ss.Append("<div style='margin-bottom: 1em;'></div>") ' clear div


        ss.Append("<div style='border: 0px solid black;'>") ' new table div

        ss.Append("<table style='width:100%; border: 2px solid black;border-collapse: collapse;'>")
        ss.Append("<tr style='border: 2px solid black; text-align:center; font-weight:bold;background-color:#f7f7f7;'>")
        ss.Append("<td style='width:3px;border: 2px solid black;'>#Sr</td>")
        ss.Append("<td style='width:180px;border: 2px solid black;'>Description</td>")
        ss.Append("<td style='width:30px;border: 2px solid black;' >HSN/SAC</td>")
        ss.Append("<td style='width:30px;border: 2px solid black;' >Rate</td>")
        ss.Append("<td style='width:30px;border: 2px solid black;'>Quantity</td>")
        ss.Append("<td style='width:60px;border: 2px solid black;'>Amount</td>")
        ss.Append("</tr>")


        Dim maxitemcount As Integer = 9
        Dim itemtbl As New DataTable
        Dim rmsg As String = ""
        dbcon.TableReturn("select * from estimate_details where quoteno=" & Val(txtsearch.Text.ToString) & " and company_id=" & Session("comid"), rmsg, itemtbl)
        If rmsg = "ok" Then
        Else
            ' code here error meassage
            Exit Sub
        End If

        maxitemcount = itemtbl.Rows.Count - 1

        For i As Integer = 0 To maxitemcount
            Dim taxstring As String = ""
            If Val(itemtbl.Rows(i).Item("sgst_p").ToString()) > 0 Then
                taxstring += "SGST:" & itemtbl.Rows(i).Item("sgst_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("igst_p").ToString()) > 0 Then
                taxstring += "IGST:" & itemtbl.Rows(i).Item("igst_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("cgst_p").ToString()) > 0 Then
                taxstring += "CGST:" & itemtbl.Rows(i).Item("cgst_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("service_tax_p").ToString()) > 0 Then
                taxstring += "SERVICE TAX:" & itemtbl.Rows(i).Item("service_tax_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("cess_p").ToString()) > 0 Then
                taxstring += "CESS:" & itemtbl.Rows(i).Item("cess_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("duty_p").ToString()) > 0 Then
                taxstring += "DUTY:" & itemtbl.Rows(i).Item("duty_p").ToString() & "%,"
            End If
            taxstring = taxstring.Substring(0, taxstring.ToString.Length - 1)
            'If i Mod 2 = 0 Then
            '    ss.Append("<tr style='border: 0px solid black;background-color:#f7f7f7; '>")
            'Else
            '    ss.Append("<tr style='border: 0px solid black;'>")
            'End If
            ss.Append("<tr style='border: 0px solid black; font-size:14px;'>")
            ss.Append("<td style='width:3px;border-left: 1px solid black;text-align:center;'>" & i + 1 & "</td>")
            ss.Append("<td style='width:180px;border: 0px solid black;'><b>" & itemtbl.Rows(i).Item("product_name").ToString & "</b></br><div style='font-size:12px;'><b>Description:</b>" & itemtbl.Rows(i).Item("descrptn").ToString & "</br><b>Tax:</b>" & taxstring & "</div></td>")
            ss.Append("<td style='width:30px;border: 0px solid black;text-align:center;'>" & itemtbl.Rows(i).Item("hsn_sac").ToString & "</td>")
            ss.Append("<td style='width:30px;border: 0px solid black;text-align:center;' >" & Val(itemtbl.Rows(i).Item("rate").ToString).ToString("#.00") & "</br><b>@per " & itemtbl.Rows(i).Item("unit").ToString & "</b></td>")
            ss.Append("<td style='width:30px;border: 0px solid black;text-align:center;'>" & itemtbl.Rows(i).Item("quant").ToString & "</br><b>" & itemtbl.Rows(i).Item("unit").ToString & "</b></td>")
            ss.Append("<td style='width:60px;border-right: 1px solid black;text-align:center;'>" & Val(itemtbl.Rows(i).Item("price").ToString).ToString("#.00") & "</td>")
            ss.Append("</tr>")
        Next

        ' if product not exists
        For i As Integer = maxitemcount To 8
            ss.Append("<tr style='border: 0px solid black; font-size:14px;'>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></br></br></br></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("</tr>")
        Next
        ' end here
        Dim totalamount As Double = Val(itemtbl.Compute("Sum(price)", "").ToString()) ' Val(itemtbl.Select("sum(price)").ToString)
        ss.Append("<tr style='border: 2px solid black;background-color:#f7f7f7;'>")
        ss.Append("<td colspan='5' style='text-align:right;'><b>Total Quotation Amount </b></td>")
        ss.Append("<td style='text-align:center;'> <b>" & totalamount.ToString("#.00") & "</b></td>")
        ss.Append("</tr>")


        ss.Append("</table>")




        'ss.Append("hi")
        ss.Append("</div>")

        ss.Append("<div>")
        ss.Append("</br>")
        ss.Append("If you have any questions concerning this quotation, please contact <b>" & Session("uname") & "</b> at <b>" & uphn & "</b> or e-mail at <b>" & umail & "</b>")
        ss.Append("<CENTER><b><p style='border: 0px solid black; font-size:14px;'> TERMS AND CONDITIONS</p></b></CENTER>")

        ss.Append("<div style='border: 0px solid black; font-size:12px;'>")
        ss.Append("<b>I.The customer </b> who is entitled for any concessional rate of tax either under GST should furnish the necessary concessional declaration form along with the payment to issue Sales Order and charge GST accordingly in the invoice.</br>")
        ss.Append("<b>II.The company </b>  shall not pay any interest, damages (including liquidated risk purchase) etc for non delivery of material for the reasons beyond its control.</br>")
        ss.Append("<b>III.All payments </b>  should be made only in Indian Rupees vide (i) Demand Draft(s) / Pay Order(s) / Cheque(s) favoring " & cmname & " payable at the city where " & cmname & "’s Offices are located, or (ii) electronic wire transfer into the " & cmname & "’s designated bank account, accompanied by documentary evidence certified by the DPO’s bank that the payment has been transferred to the " & cmname & "’s bank account or (iii) Bill desk platform (iv) any other mode as intimated by " & cmname & ".</br>")
        ss.Append("<b>IV.Product warranty </b>  will be provided by the product manufacturer directy. The seller is not liable for any warranty or damage of  the product.</br>")
        ss.Append("</div>")


        ss.Append("</div>")




        'ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("<CENTER><b><p> THANK YOU FOR YOUR BUSINESS!!</p></b></CENTER>")











        'For I As Integer = 0 To 63
        '    ss.Append("</br>")
        'Next

        'For I As Integer = 0 To 20
        '    ss.Append("</br>")
        'Next

        ss.Append("</div>")
        ss.Append("</div>")

        htmltext = ss.ToString

    End Sub


    Private Sub Quotationformattwo(ByRef htmltext As String, ByVal quotationid As Double)
        Dim ss As StringBuilder = New StringBuilder()
        Dim currenttime As DateTime = Now
        Dim p As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")
        ' new header end here
        Dim tbl As New DataTable
        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 2px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")

        ' header div
        ss.Append("<div style='border-bottom: 5px solid black; height:110px;width:100%;'>")
        ss.Append("<div class='float-left' style=' border:0 px solid #000000;'><img src='" & p & "img/letterhead1.png'  alt='logo' width='180' height='90' border=0'></div>")
        ss.Append("<div class='float-right' style='text-align:center;padding: 20px 0;border: 0px solid #000000;height:90px;'><h1>" & ddlquotehead.SelectedValue & "</h1></div><div></div>")
        ss.Append("</div>")
        '' header div end here

        Dim da As New OdbcDataAdapter("select * from company_details where id='" & Session("comid") & "' and deactive_date>'" & Now.ToString & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim cmname As String = ds.Tables(0).Rows(0).Item("company_name").ToString
        Dim adrs As String = ds.Tables(0).Rows(0).Item("address").ToString
        Dim phn As String = ds.Tables(0).Rows(0).Item("phone_no").ToString
        Dim mail As String = ds.Tables(0).Rows(0).Item("email_id").ToString
        Dim gst As String = ds.Tables(0).Rows(0).Item("gst_no").ToString
        Dim pan As String = ds.Tables(0).Rows(0).Item("pan_no").ToString
        Dim cntctp As String = ds.Tables(0).Rows(0).Item("contact_person_name").ToString


        'body starts here
        ss.Append("<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp " & cmname & "</b></br>")

        ss.Append("<div style='font-size: 14px; float: left;'>")
        ss.Append("<table>")
        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td style='vertical-align: text-top'>Address</td> ")
        ss.Append("<td> : " & adrs & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>Phone</td> ")
        ss.Append("<td> : " & phn & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>e-mail</td> ")
        ss.Append("<td> : " & mail & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>GSTIN</td> ")
        ss.Append("<td> : " & gst & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td>PAN No.</td> ")
        ss.Append("<td> : " & pan & "</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")



        Dim da1 As New OdbcDataAdapter("select * from estimate_digest where quoteno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds1 As New DataSet
        da1.Fill(ds1)
        Dim qdate As String = Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("created_date")).Date.ToString("dd-MMM-yyyy")
        Dim cid As String = ""
        If ds1.Tables(0).Rows(0).Item("client_id") <> 0 Then
            cid = ds1.Tables(0).Rows(0).Item("client_id").ToString
        Else
            cid = ""
        End If
        Dim vdate As String = Convert.ToDateTime(ds1.Tables(0).Rows(0).Item("valid_till")).Date.ToString("dd-MMM-yyyy")
        Dim total As Double = Convert.ToDouble(ds1.Tables(0).Rows(0).Item("total_amount").ToString)
        total = Math.Round(total, 2)
        total = Math.Round(Decimal.Parse(total), 2, MidpointRounding.AwayFromZero)
        Dim tottax As Double = ds1.Tables(0).Rows(0).Item("total_tax").ToString
        Dim sgstamnt As Double = ds1.Tables(0).Rows(0).Item("sgst").ToString
        Dim cgstamnt As Double = ds1.Tables(0).Rows(0).Item("cgst").ToString
        Dim igstamnt As Double = ds1.Tables(0).Rows(0).Item("igst").ToString
        Dim srvcamnt As Double = ds1.Tables(0).Rows(0).Item("service_tax").ToString
        Dim dutyamnt As Double = ds1.Tables(0).Rows(0).Item("cess").ToString
        Dim cessamnt As Double = ds1.Tables(0).Rows(0).Item("duty").ToString


        Dim da2 As New OdbcDataAdapter("select distinct sgst_p,cgst_p,igst_p,service_tax_p,cess_p,duty_p,ref from estimate_details where quoteno='" & txtsearch.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds2 As New DataSet
        da2.Fill(ds2)

        Dim sgstp As Double = ds2.Tables(0).Rows(0).Item("sgst_p").ToString
        Dim cgstp As Double = ds2.Tables(0).Rows(0).Item("cgst_p").ToString
        Dim igstp As Double = ds2.Tables(0).Rows(0).Item("igst_p").ToString
        Dim srvcp As Double = ds2.Tables(0).Rows(0).Item("service_tax_p").ToString
        Dim dutyp As Double = ds2.Tables(0).Rows(0).Item("cess_p").ToString
        Dim cessp As Double = ds2.Tables(0).Rows(0).Item("duty_p").ToString
        Dim ref As String = ds2.Tables(0).Rows(0).Item("ref").ToString

        Dim uid As Integer = 0
        Dim da3 As New OdbcDataAdapter("select * from user_master where user_master_id='" & Session("uid") & "'", dbcon.con)
        Dim ds3 As New DataSet
        da3.Fill(ds3)
        Dim umail As String = ds3.Tables(0).Rows(0).Item("email")
        Dim uphn As String = ds3.Tables(0).Rows(0).Item("phn_no")




        ss.Append("<div style='display:inline-block;margin-bottom: 5em;'></div>")
        ss.Append("<div style='float: right;font-size: 15px;'>")
        ss.Append("<table>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td><b>Date of quotation<b></td> ")
        ss.Append("<td style='font-size: 14px;'> : " & qdate & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td><b>Quotation ID<b></td> ")
        ss.Append("<td> : #" & txtsearch.Text & "</td>")
        ss.Append("</tr>")

        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td><b>Customer ID<b></td> ")
        ss.Append("<td style='font-size: 14px;'> : #" & cid & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr style='text-align:left'>")
        ss.Append("<td ><b>Quotation valid until<b></td> ")
        ss.Append("<td style='font-size: 14px;'> : " & vdate & "</td>")
        ss.Append("</tr>")


        ss.Append("<tr>")
        ss.Append("<td>&nbsp;</td>")
        ss.Append("<td>&nbsp;</td>")
        ss.Append("</tr>")

        ss.Append("</table>")
        ss.Append("</div>")




        ss.Append("<div style='margin-bottom: 2em;'></div>") ' clear div
        ss.Append("<div>")

        ss.Append("<div style='display: inline-block;float:left;text-align: left; border: 0px solid black;font-size: 15px;'>Quotation to</br>")
        ss.Append("<b>" & txtclientname.Text & "</b></br>")
        ss.Append("" & txtcompname.Text & "</br>")
        ss.Append("Address: " & txtaddress.Text & "</br>")
        ss.Append("Phone: " & txtphnno.Text & "</br>")

        ss.Append("<b>Comments or Special Instructions:</b> " & txtremarks.Text & "</br>")
        'ss.Append("</br>")


        ss.Append("</div>")
        ss.Append("<div style='display: inline-block;border: 0px solid black;'></div>")
        ss.Append("<div style='display: inline-block;float:right;text-align: right; border: 0px solid black;'>Prepared By: " & Session("uname") & "</div>")
        ss.Append("</div>")
        ss.Append("</br>")

        ss.Append("<div style='margin-bottom: 8em;'></div>") ' clear div
        ss.Append("<center><b>Ref: " & ref & "</b></center>")
        ss.Append("<div style='margin-bottom: 1em;'></div>") ' clear div


        ss.Append("<div style='border: 0px solid black;'>") ' new table div

        ss.Append("<table style='width:100%; border: 2px solid black;border-collapse: collapse;'>")
        ss.Append("<tr style='border: 2px solid black; text-align:center; font-weight:bold;background-color:#f7f7f7;'>")
        ss.Append("<td style='width:3px;border: 2px solid black;'>#Sr</td>")
        ss.Append("<td style='width:180px;border: 2px solid black;'>Description</td>")
        ss.Append("<td style='width:30px;border: 2px solid black;' >Rate</td>")
        ss.Append("<td style='width:30px;border: 2px solid black;'>Quantity</td>")
        ss.Append("<td style='width:60px;border: 2px solid black;'>Amount</td>")
        ss.Append("</tr>")


        Dim maxitemcount As Integer = 9
        Dim itemtbl As New DataTable
        Dim rmsg As String = ""
        dbcon.TableReturn("select * from estimate_details where quoteno=" & Val(txtsearch.Text.ToString) & " and company_id=" & Session("comid"), rmsg, itemtbl)
        If rmsg = "ok" Then
        Else
            ' code here error meassage
            Exit Sub
        End If

        maxitemcount = itemtbl.Rows.Count - 1

        For i As Integer = 0 To maxitemcount
            Dim taxstring As String = ""
            If Val(itemtbl.Rows(i).Item("sgst_p").ToString()) > 0 Then
                taxstring += "SGST:" & itemtbl.Rows(i).Item("sgst_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("igst_p").ToString()) > 0 Then
                taxstring += "IGST:" & itemtbl.Rows(i).Item("igst_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("cgst_p").ToString()) > 0 Then
                taxstring += "CGST:" & itemtbl.Rows(i).Item("cgst_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("service_tax_p").ToString()) > 0 Then
                taxstring += "SERVICE TAX:" & itemtbl.Rows(i).Item("service_tax_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("cess_p").ToString()) > 0 Then
                taxstring += "CESS:" & itemtbl.Rows(i).Item("cess_p").ToString() & "%,"
            End If
            If Val(itemtbl.Rows(i).Item("duty_p").ToString()) > 0 Then
                taxstring += "DUTY:" & itemtbl.Rows(i).Item("duty_p").ToString() & "%,"
            End If
            taxstring = taxstring.Substring(0, taxstring.ToString.Length - 1)
            'If i Mod 2 = 0 Then
            '    ss.Append("<tr style='border: 0px solid black;background-color:#f7f7f7; '>")
            'Else
            '    ss.Append("<tr style='border: 0px solid black;'>")
            'End If
            ss.Append("<tr style='border: 0px solid black; font-size:14px;'>")
            ss.Append("<td style='width:3px;border-left: 1px solid black;text-align:center;'>" & i + 1 & "</td>")
            ss.Append("<td style='width:180px;border: 0px solid black;'><b>" & itemtbl.Rows(i).Item("product_name").ToString & "</b></br><div style='font-size:12px;'><b>Description:</b>" & itemtbl.Rows(i).Item("descrptn").ToString & "</br><b>Tax:</b>" & taxstring & "</div></td>")
            ss.Append("<td style='width:30px;border: 0px solid black;text-align:center;' >" & Val(itemtbl.Rows(i).Item("rate").ToString).ToString("#.00") & "</br><b>@per " & itemtbl.Rows(i).Item("unit").ToString & "</b></td>")
            ss.Append("<td style='width:30px;border: 0px solid black;text-align:center;'>" & itemtbl.Rows(i).Item("quant").ToString & "</br><b>" & itemtbl.Rows(i).Item("unit").ToString & "</b></td>")
            ss.Append("<td style='width:60px;border-right: 1px solid black;text-align:center;'>" & Val(itemtbl.Rows(i).Item("price").ToString).ToString("#.00") & "</td>")
            ss.Append("</tr>")
        Next

        ' if product not exists
        For i As Integer = maxitemcount To 8
            ss.Append("<tr style='border: 0px solid black; font-size:14px;'>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></br></br></br></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("<td style='width:3px;heigh:5px;border-left: 0px solid black;text-align:center;'></td>")
            ss.Append("</tr>")
        Next
        ' end here
        Dim totalamount As Double = Val(itemtbl.Compute("Sum(price)", "").ToString()) ' Val(itemtbl.Select("sum(price)").ToString)
        ss.Append("<tr style='border: 2px solid black;background-color:#f7f7f7;'>")
        ss.Append("<td colspan='4' style='text-align:right;'><b>Total Quotation Amount </b></td>")
        ss.Append("<td style='text-align:center;'> <b>" & totalamount.ToString("#.00") & "</b></td>")
        ss.Append("</tr>")


        ss.Append("</table>")




        'ss.Append("hi")
        ss.Append("</div>")

        ss.Append("<div style='float: right;width:100%;'>")
        ss.Append("<table>")

        ss.Append("<tr style='text-align:right'>")
        ss.Append("<td>Total amount without Tax </td> ")
        ss.Append("<td style='font-size: 14px;'>  " & total & "</td>")
        ss.Append("</tr>")


        If ds1.Tables(0).Rows(0).Item("sgst").ToString <> 0 Then
            ss.Append("<tr style='text-align:right'>")
            ss.Append("<td>Total State Goods and Services Tax Rate @" & sgstp & "% </td> ")
            ss.Append("<td style='font-size: 14px;'>  " & sgstamnt & "</td>")
            ss.Append("</tr>")
        End If
        If ds1.Tables(0).Rows(0).Item("cgst").ToString <> 0 Then
            ss.Append("<tr style='text-align:right'>")
            ss.Append("<td>Total Central Goods and Service Tax Rate @" & cgstp & "% </td> ")
            ss.Append("<td style='font-size: 14px;'>  " & cgstamnt & "</td>")
            ss.Append("</tr>")
        End If
        If ds1.Tables(0).Rows(0).Item("igst").ToString <> 0 Then
            ss.Append("<tr style='text-align:right'>")
            ss.Append("<td>Total Integrated Goods and Services Tax Rate @" & igstp & "% </td> ")
            ss.Append("<td style='font-size: 14px;'>  " & igstamnt & "</td>")
            ss.Append("</tr>")
        End If
        If ds1.Tables(0).Rows(0).Item("service_tax").ToString <> 0 Then
            ss.Append("<tr style='text-align:right'>")
            ss.Append("<td>Total Service Tax Rate @" & srvcp & "% </td> ")
            ss.Append("<td style='font-size: 14px;'>  " & srvcamnt & "</td>")
            ss.Append("</tr>")
        End If
        If ds1.Tables(0).Rows(0).Item("cess").ToString <> 0 Then
            ss.Append("<tr style='text-align:right'>")
            ss.Append("<td>Total CESS Tax Rate @" & cessp & "% </td> ")
            ss.Append("<td style='font-size: 14px;'>  " & cessamnt & "</td>")
            ss.Append("</tr>")
        End If
        If ds1.Tables(0).Rows(0).Item("duty").ToString <> 0 Then
            ss.Append("<tr style='text-align:right'>")
            ss.Append("<td>Total Duty Rate @" & dutyp & "% </td> ")
            ss.Append("<td style='font-size: 14px;'>  " & dutyamnt & "</td>")
            ss.Append("</tr>")
        End If


        ss.Append("<tr style='text-align:right'>")
        ss.Append("<td ><b>Quote Total <b></td> ")
        ss.Append("<td style='font-size: 14px;'> : " & total + tottax & "</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")



        ss.Append("<div>")
        ss.Append("</br>")
        ss.Append("If you have any questions concerning this quotation, please contact <b>" & Session("uname") & "</b> at <b>" & uphn & "</b> or e-mail at <b>" & umail & "</b>")
        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("<CENTER><b><p style='border: 0px solid black; font-size:14px;'> TERMS AND CONDITIONS</p></b></CENTER>")

        ss.Append("<div style='border: 0px solid black; font-size:12px;'>")
        ss.Append("<b>I.The customer </b> who is entitled for any concessional rate of tax either under GST should furnish the necessary concessional declaration form along with the payment to issue Sales Order and charge GST accordingly in the invoice.</br>")
        ss.Append("<b>II.The company </b>  shall not pay any interest, damages (including liquidated risk purchase) etc for non delivery of material for the reasons beyond its control.</br>")
        ss.Append("<b>III.All payments </b>  should be made only in Indian Rupees vide (i) Demand Draft(s) / Pay Order(s) / Cheque(s) favoring " & cmname & " payable at the city where " & cmname & "’s Offices are located, or (ii) electronic wire transfer into the " & cmname & "’s designated bank account, accompanied by documentary evidence certified by the DPO’s bank that the payment has been transferred to the " & cmname & "’s bank account or (iii) Bill desk platform (iv) any other mode as intimated by " & cmname & ".</br>")
        ss.Append("<b>IV.Product warranty </b>  will be provided by the product manufacturer directy. The seller is not liable for any warranty or damage of  the product.</br>")
        ss.Append("</div>")


        ss.Append("</div>")




        ss.Append("</br>")
        ss.Append("</br>")
        ss.Append("</br>")
        'ss.Append("</br>")
        'ss.Append("</br>")


        ss.Append("<CENTER><b><p> THANK YOU FOR YOUR BUSINESS!!</p></b></CENTER>")











        'For I As Integer = 0 To 63
        '    ss.Append("</br>")
        'Next

        'For I As Integer = 0 To 20
        '    ss.Append("</br>")
        'Next

        ss.Append("</div>")
        ss.Append("</div>")

        htmltext = ss.ToString

    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearch.Text = "" Then
                Dim da As New OdbcDataAdapter("select distinct quoteno,com_name,client_name,phn_no,created_date::date,valid_till::date from estimate_details where company_id='" & Session("comid") & "' and est_type='" & ddlestimatetype.SelectedValue & "' and status<>'Inactive' order by quoteno desc", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("select distinct quoteno,com_name,client_name,phn_no,created_date::date,valid_till::date from estimate_details where upper(client_name) like upper('%" & txtsearch.Text & "%')  and est_type='" & ddlestimatetype.SelectedValue & "' and company_id='" & Session("comid") & "' and status<>'Inactive' order by quoteno desc", dbcon.con)
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


End Class
