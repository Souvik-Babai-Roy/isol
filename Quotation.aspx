<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Quotation.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Quotation</title>

    <script type="text/javascript">
        function PrintgstPanel() {
            var panel = document.getElementById("<%=viewgstinvoice.ClientID %>");
            //         var printWindow = window.open('', '', 'height=400,width=800,left=0,top=0,location=1,status=1,scrollbars=1');
            var printWindow = window.open('', '', 'height=500,width=850,left=0,top=0,location=1,status=1,scrollbars=1');
            printWindow.document.write('<html><head> <title>Quotation</title>');

            //         printWindow.document.write('<style type=text/css>@media print{body{ background-color:#FFFFFF; background-image:none; color:#000000 }#ad{ display:none;}#leftbar{ display:none;}#contentarea{ width:100%;}}</style>');
            ////////        printWindow.document.write('<link href="admcss/style-responsive.css" rel="stylesheet"/>');
            ////////        printWindow.document.write('<link href="Style/dashboardstyle.css" rel="stylesheet" type="text/css" />');
            ////////        printWindow.document.write(' <link href="Style/font-awesome.css" rel="stylesheet" type="text/css" />');
            ////////     

            // printWindow.document.write('<style type=text/css>@page {size: auto;margin: 0; } table{border-collapse: collapse;} h1{text-transform: uppercase;font-style: normal; } </style>');
            printWindow.document.write('<link href="Styles/adminlte.min.css" rel="stylesheet" type="text/css" />');
            printWindow.document.write('<link href="Styles/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>');
            printWindow.document.write(' <link href="Styles/fontawesome-free/css/all.css" rel="stylesheet" type="text/css" />');

            printWindow.document.write('<style type=text/css>@page {size: auto;margin: 0; } table{border-collapse: collapse;}   .sansserif{font-family: Arial, Helvetica, sans-serif;} h1{text-transform: uppercase;font-style: normal; } </style>');


            printWindow.document.write('</head><body>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            //         printWindow.document.body.style.fontFamily = "Impact, Charcoal, sans-serif";


            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <!-- Default box -->
                    <div class="card card-info" style="box-shadow: 0 0 10px 3px;">
                        <div class="card-header" style="background-color: #5777ba; color: White;">
                            <h3 class="card-title">
                                Estimate</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Header Information</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label15" runat="server" class="col-sm-2 col-form-label" Text="Estimate Type"
                                                        AssociatedControlID="ddlestimatetype"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlestimatetype" runat="server" class="form-control text-blue text-uppercase">
                                                        <asp:ListItem>Quotation</asp:ListItem>
                                                        <asp:ListItem>Sales Order</asp:ListItem>
                                                        <asp:ListItem>Purchase Order</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label16" runat="server" class="col-sm-2 col-form-label" Text="Quotation Header"
                                                        AssociatedControlID="ddlquotehead"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlquotehead" runat="server" class="form-control text-blue text-uppercase">
                                                        <asp:ListItem>Quotation</asp:ListItem>
                                                        <asp:ListItem>Estimate</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtcompname" class="col-sm-2 col-form-label">
                                                        Company Name
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtcompname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtcompname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Business Name" ValidationGroup="entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtclientname" class="col-sm-2 col-form-label">
                                                        Person Name
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtclientname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtclientname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Client Name" ValidationGroup="entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="div1" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtphnno" class="col-sm-2 col-form-label">
                                                        Phone Number
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtphnno" ValidationGroup="entry"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtphnno"
                                                            runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtphnno" placeholder="10 digit Mobile No."
                                                            runat="server" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="div2" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtmail" class="col-sm-2 col-form-label">
                                                        Email Address
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtmail" runat="server" placeholder="name@business.com"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label1" runat="server" class="col-sm-2 col-form-label" Text="Address"
                                                        AssociatedControlID="txtaddress"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtaddress" placeholder="Address"
                                                            runat="server" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtremarks" class="col-sm-2 col-form-label">
                                                        Quotation Remarks
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtremarks" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Quotation Remarks" ValidationGroup="entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtvaliddays" class="col-sm-2 col-form-label">
                                                        Quotation Validity (Days)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtvaliddays" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtvaliddays" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Validity in days" ValidationGroup="entry" Text="1" min="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtref" class="col-sm-2 col-form-label">
                                                        Quotation Reference
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtref" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Quotation Reference" ValidationGroup="entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Fetch Products/Services Info</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label6" runat="server" class="col-sm-2 col-form-label" Text="Product/Service Name"
                                                        AssociatedControlID="txtpdctname"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtpdctname" placeholder="Product Name"
                                                            runat="server" AutoPostBack="True"></asp:TextBox>
                                                        <i>
                                                            <asp:Label ID="lblpid" runat="server" Text="" class=" text-bold"></asp:Label></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label2" runat="server" class="col-sm-4 col-form-label" Text="HSN/SAC"
                                                        AssociatedControlID="txthsn"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txthsn" placeholder="HSN Code" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label4" runat="server" class="col-sm-4 col-form-label" Text="Unit"
                                                        AssociatedControlID="txtunit"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtunit" placeholder="Unit" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label7" runat="server" class="col-sm-4 col-form-label" Text="Quantity"
                                                        AssociatedControlID="txtquant"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtquant" placeholder="Quantity"
                                                            runat="server" AutoPostBack="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label8" runat="server" class="col-sm-4 col-form-label" Text="Unit Price"
                                                        AssociatedControlID="txtprice"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtprice" placeholder="Price" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label9" runat="server" class="col-sm-2 col-form-label" Text="Product/Service Description"
                                                        AssociatedControlID="txtdesc"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtdesc" placeholder="Description"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Taxation info</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label10" runat="server" class="col-sm-4 col-form-label" Text="SGST"
                                                        AssociatedControlID="txtsgst"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtsgst" placeholder="SGST percentage (without %)"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label11" runat="server" class="col-sm-4 col-form-label" Text="CGST"
                                                        AssociatedControlID="txtcgst"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtcgst" placeholder="CGST percentage (without %)"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label5" runat="server" class="col-sm-4 col-form-label" Text="IGST"
                                                        AssociatedControlID="txtigst"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtigst" placeholder="IGST percentage (without %)"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label3" runat="server" class="col-sm-4 col-form-label" Text="Duty"
                                                        AssociatedControlID="txtduty"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtduty" placeholder="GST percentage (without %)"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label12" runat="server" class="col-sm-4 col-form-label" Text="Service Tax"
                                                        AssociatedControlID="txtservicetax"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtservicetax" placeholder="Service Tax percentage (without %)"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label13" runat="server" class="col-sm-4 col-form-label" Text="CESS"
                                                        AssociatedControlID="txtcess"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtcess" placeholder="CESS percentage (without %)"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div align="center">
                                            <button type="submit" class="btn btn-warning btn-group-sm text-bold" id="btnadd"
                                                runat="server">
                                                <i class="fas fa-cart-plus"></i>&nbsp; Add Item
                                            </button>
                                        </div>
                                        <div class="post clearfix">
                                        </div>
                                        <div class="post clearfix">
                                        </div>
                                        <div class="box" align="center">
                                            <div class="row">
                                                <div class="col-12 table-responsive">
                                                    <asp:GridView ID="tblquot" runat="server" class="table table-striped" GridLines="None"
                                                        AutoGenerateDeleteButton="True">
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="msgct1" runat="server">
                                </div>
                                <div align="center">
                                    <button type="submit" class="btn btn-primary btn-block text-bold" id="btnsave" runat="server"
                                        validationgroup="entry">
                                        <i class="fas fa-plus-square"></i>&nbsp; Save Quotation
                                    </button>
                                    <button type="submit" class="btn btn-warning btn-block text-bold" id="btnupdate"
                                        runat="server" validationgroup="entry" visible="false">
                                        <i class="fas fa-edit"></i>&nbsp; Edit Quotation
                                    </button>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                        </div>
                        <!-- /.card-footer-->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
        </div>
    </div>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <!-- Default box -->
                    <div class="card" style="box-shadow: 0 0 10px 3px;">
                        <div class="card-header bg-gradient-success">
                            <h3 class="card-title">
                                Quotation Fetch</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label18" runat="server" class="col-sm-2 col-form-label" Text="Quotation ID"
                                                AssociatedControlID="txtsearch"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:TextBox ID="txtsearch" placeholder="Quotation ID" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <br />
                                    <div style="width: 100%; overflow-x: scroll; max-height: 300px; overflow-y: scroll;">
                                        <asp:GridView ID="grdvleddetails" runat="server" Visible="False" ClientIDMode="Static"
                                            class="table table-bordered table-striped mobile" GridLines="None">
                                        </asp:GridView>
                                    </div>
                                    <br />
                                    <div id="msgct2" runat="server">
                                    </div>
                                    <div class="" align="center">
                                        <button type="Submit" id="btnsearch" class="btn btn-info btn-block text-bold" runat="server"
                                            validationgroup="update">
                                            <i class="fas fa-search"></i>&nbsp; Search With Client Name</button>
                                        <button type="Submit" id="btngetinfo" class="btn bg-gradient-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Get Information</button>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <asp:Label ID="Label14" runat="server" class="col-sm-2 col-form-label" Text="Estimate Format"
                                                    AssociatedControlID="ddlformat"></asp:Label>
                                                <div class=" col-sm-10">
                                                    <asp:DropDownList ID="ddlformat" runat="server" class="form-control text-blue">
                                                        <asp:ListItem Value="1">Format I: Without GST</asp:ListItem>
                                                        <asp:ListItem Value="2">Format II: With GST</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div align="center">
                                        <button type="Submit" id="btnviewestimate" class="btn btn-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-file-lines"></i>&nbsp; View Quotation</button>
                                    </div>
                                    <br />
                                    <button id="btngstprint" runat="server" class="btn btn-app bg-gradient-fuchsia text-bold"
                                        onclick="return PrintgstPanel();" visible="false">
                                        <i class="fas fa-print"></i>Print</button>
                                    <div id="viewgstinvoice" runat="server">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                        </div>
                        <!-- /.card-footer-->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
