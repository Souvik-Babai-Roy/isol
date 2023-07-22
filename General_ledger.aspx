<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="General_ledger.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>General Ledger</title>
    <style>
        .rbl input[type="radio"]
        {
            margin-left: 20px !important;
            margin-right: 5px !important;
        }
        .chkbx
        {
            margin-left: 160px !important;
            margin-top: 5px !important;
        }
        
        @media only screen and (max-width: 600px)
        {
            .chkbx
            {
                margin-left: 100px !important;
            }
        
        }
        .input-radius
        {
            border-radius: none !important;
        }
    </style>
    <style type="text/css">
        @media only screen and (max-width: 700px)
        {
            .mobile table, .mobile thead, .mobile tbody, .mobile th, .mobile td, .mobile tr
            {
                display: block;
            }
            .mobile thead .mobile tr
            {
                position: absolute;
                top: -9999px;
                left: -9999px;
            }
            .mobile tr
            {
                border: 1px solid #ccc;
                margin-bottom: .5em;
            }
            .mobile td
            {
                border: none;
                position: relative;
                padding: 1em .5em;
            }
            .mobile td:before
            {
                position: absolute;
                top: 0;
                left: 0;
                padding: 1em .5em;
                white-space: wrap;
            }
            .mobile thead, .mobile th
            {
                display: none;
            }
        
            /* Change these as needed */
            .mobile td
            {
                margin-left: 6.5em;
            }
            .mobile td:before
            {
                margin-left: -6.5em;
            }
            .mobile td:nth-child(1)::before
            {
                content: "company_id: ";
                font-weight: bold;
            }
            .mobile td:nth-child(2)::before
            {
                content: "ledger_id: ";
                font-weight: bold;
            }
            .mobile td:nth-child(3)::before
            {
                content: "led_for: ";
                font-weight: bold;
            }
            .mobile td:nth-child(4)::before
            {
                content: "led_type_id: ";
                font-weight: bold;
            }
            .mobile td:nth-child(5)::before
            {
                content: "led_type: ";
                font-weight: bold;
            }
            .mobile td:nth-child(6)::before
            {
                content: "associate_led_id: ";
                font-weight: bold;
            }
            .mobile td:nth-child(7)::before
            {
                content: "ledger_title: ";
                font-weight: bold;
            }
            .mobile td:nth-child(8)::before
            {
                content: "ledger_name: ";
                font-weight: bold;
            }
            .mobile td:nth-child(9)::before
            {
                content: "phnno: ";
                font-weight: bold;
            }
            .mobile td:nth-child(10)::before
            {
                content: "email: ";
                font-weight: bold;
            }
            .mobile td:nth-child(11)::before
            {
                content: "dob: ";
                font-weight: bold;
            }
            .mobile td:nth-child(12)::before
            {
                content: "gender: ";
                font-weight: bold;
            }
            .mobile td:nth-child(13)::before
            {
                content: "blood_grp: ";
                font-weight: bold;
            }
            .mobile td:nth-child(14)::before
            {
                content: "address: ";
                font-weight: bold;
            }
            .mobile td:nth-child(15)::before
            {
                content: "zip_code: ";
                font-weight: bold;
            }
            .mobile td:nth-child(16)::before
            {
                content: "locality: ";
                font-weight: bold;
            }
            .mobile td:nth-child(17)::before
            {
                content: "city: ";
                font-weight: bold;
            }
            .mobile td:nth-child(18)::before
            {
                content: "state: ";
                font-weight: bold;
            }
            .mobile td:nth-child(19)::before
            {
                content: "country: ";
                font-weight: bold;
            }
            .mobile td:nth-child(20)::before
            {
                content: "nationality: ";
                font-weight: bold;
            }
            .mobile td:nth-child(21)::before
            {
                content: "relation: ";
                font-weight: bold;
            }
            .mobile td:nth-child(22)::before
            {
                content: "id_proof_type: ";
                font-weight: bold;
            }
            .mobile td:nth-child(23)::before
            {
                content: "id_proof_no: ";
                font-weight: bold;
            }
            .mobile td:nth-child(24)::before
            {
                content: "if_married: ";
                font-weight: bold;
            }
            .mobile td:nth-child(25)::before
            {
                content: "emergency contact person: ";
                font-weight: bold;
            }
            .mobile td:nth-child(26)::before
            {
                content: "emergency_contact_number: ";
                font-weight: bold;
            }
            .mobile td:nth-child(27)::before
            {
                content: "gstno: ";
                font-weight: bold;
            }
            .mobile td:nth-child(28)::before
            {
                content: "invoice_address: ";
                font-weight: bold;
            }
            .mobile td:nth-child(29)::before
            {
                content: "room_category: ";
                font-weight: bold;
            }
            .mobile td:nth-child(30)::before
            {
                content: "room_type: ";
                font-weight: bold;
            }
            .mobile td:nth-child(31)::before
            {
                content: "table_type: ";
                font-weight: bold;
            }
            .mobile td:nth-child(32)::before
            {
                content: "table_max_person: ";
                font-weight: bold;
            }
            .mobile td:nth-child(33)::before
            {
                content: "status: ";
                font-weight: bold;
            }
        
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <!-- Default box -->
                    <div class="card card-info" style="box-shadow: 0 0 10px 3px;">
                        <div class="card-header bg-gradient-info">
                            <h3 class="card-title">
                                General Ledger Entry</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label2" class="col-sm-2 col-form-label" runat="server" Text="Ledger Type"
                                                        AssociatedControlID="ddlprimary"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlprimary" runat="server" class="form-control text-blue text-uppercase">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                General Ledger Information</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtledname" class="col-sm-2 col-form-label">
                                                        Ledger Name
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtledname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtledname" runat="server" class="form-control text-blue input-radius text-uppercase"
                                                            placeholder="General Ledger Name" ValidationGroup="entry" AutoPostBack="True"></asp:TextBox>
                                                        <div id="valmsg" runat="server">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divphn" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtphnno" class="col-sm-2 col-form-label">
                                                        Phone Number
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtphnno" ValidationGroup="entry"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtphnno"
                                                            runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true" ValidationGroup="entry"></asp:RegularExpressionValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtphnno" placeholder="10 digit Mobile No."
                                                            runat="server" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divmail" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtmail" class="col-sm-2 col-form-label">
                                                        Email Address
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"
                                                            ControlToValidate="txtmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            SetFocusOnError="true" ValidationGroup="entry"></asp:RegularExpressionValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtmail" runat="server" placeholder="abc@gmail.com"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label3" runat="server" class="col-sm-2 col-form-label" Text="Address"
                                                        AssociatedControlID="txtaddress"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtaddress" placeholder="Address"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div action="#" method="post">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtpin" class="col-sm-2 col-form-label">
                                                            Pincode
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtpin" placeholder="6 digit Pin code"
                                                                runat="server" MaxLength="6"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtlandmark" class="col-sm-2 col-form-label">
                                                            Landmark
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtlandmark" placeholder="Landmark"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label5" class="col-sm-2 col-form-label" runat="server" Text="State"
                                                            AssociatedControlID="txtstate"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtstate" placeholder="State Name"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divgstinv" runat="server">
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h5>
                                                    Tax Information</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label1" runat="server" class="col-sm-2 col-form-label" Text="Company Name"
                                                            AssociatedControlID="txtcompname"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtcompname" runat="server"
                                                                placeholder="Company Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label14" runat="server" class="col-sm-2 col-form-label" Text="GST Number"
                                                            AssociatedControlID="txtgstno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtgstno" runat="server"
                                                                placeholder="Gst No."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label15" runat="server" class="col-sm-2 col-form-label" Text="Invoice Address"
                                                            AssociatedControlID="txtinvoice"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtinvoice" runat="server"
                                                                placeholder="Invoice Address"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label24" runat="server" class="col-sm-2 col-form-label" Text="Pan No."
                                                            AssociatedControlID="txtpanno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtpanno" runat="server"
                                                                placeholder="Pan Card No."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label6" runat="server" class="col-sm-2 col-form-label" Text="Tan No."
                                                            AssociatedControlID="txttanno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txttanno" runat="server"
                                                                placeholder="TAN no."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label4" runat="server" class="col-sm-2 col-form-label" Text="Opening Balance"
                                                            AssociatedControlID="txtopenbal"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtopenbal" runat="server"
                                                                placeholder="Opening Balance"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label8" runat="server" class="col-sm-2 col-form-label" Text="Closing Balance"
                                                            AssociatedControlID="txtclosebal"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtclosebal" runat="server"
                                                                placeholder="Closing Balance"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row" id="divstatus" runat="server" visible="false">
                                                    <asp:Label ID="Label19" runat="server" class="col-sm-2 col-form-label" Text="Status"
                                                        AssociatedControlID="ddlstatus"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlstatus" runat="server" class="form-control text-blue">
                                                            <asp:ListItem>Active</asp:ListItem>
                                                            <asp:ListItem>Deactive</asp:ListItem>
                                                            <asp:ListItem>Incomplete</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="msgct1" runat="server">
                                </div>
                                <div align="center">
                                    <button type="submit" class="btn btn-primary btn-block text-bold" id="btnsave" runat="server"
                                        validationgroup="entry">
                                        <i class="fas fa-plus-square"></i>&nbsp; Add Ledger
                                    </button>
                                    <button type="submit" class="btn btn-secondary btn-block text-bold" id="btnupdate"
                                        runat="server" visible="False">
                                        <i class="fas fa-edit"></i>&nbsp; Update Ledger
                                    </button>
                                    <asp:LinkButton ID="btndelete" runat="server" class="btn btn-warning btn-block text-bold"
                                        Visible="False"><i class="fas fa-trash"></i> &nbsp; Delete Ledger</asp:LinkButton>
                                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btndelete"
                                        ConfirmText="Are you Sure?" OnClientCancel="cancelclick" />
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
                                Ledger Update</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label18" runat="server" class="col-sm-2 col-form-label" Text="Ledger Name/ID"
                                                AssociatedControlID="txtsearchname"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:TextBox ID="txtsearchname" placeholder="Ledger Name (ID for Update)" class="form-control"
                                                    runat="server"></asp:TextBox>
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
                                            <i class="fas fa-search"></i>&nbsp; Search With Ledger Name</button>
                                        <button type="Submit" id="btnupdateinfo" class="btn bg-gradient-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Get Information For Update</button>
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
