<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Guest_ledger.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Guest Ledger</title>
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
                                Guest Entry</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label1" class="col-sm-2 col-form-label" runat="server" Text=" Quick Ledger Type"
                                                        AssociatedControlID="ddlqckledtype"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlqckledtype" runat="server" AutoPostBack="True" class="form-control text-blue">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Personal Information</h5>
                                        </div>
                                        <div id="divassociate" runat="server">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtphnno" class="col-sm-2 col-form-label">
                                                            Guest Conatct No.
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtmainguestcontact"
                                                                runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtmainguestcontact" placeholder="10 digit Mobile No."
                                                                runat="server" MaxLength="10" AutoPostBack="True"></asp:TextBox>
                                                        <div id="divval" runat="server">
                                                        </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtledname" class="col-sm-2 col-form-label">
                                                            Guest Name</label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox ID="txtguestname" runat="server" class="form-control text-blue input-radius"
                                                                placeholder="Guest Name" ReadOnly></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divtitle" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label4" class="col-sm-2 col-form-label" runat="server" Text="Title"
                                                        AssociatedControlID="ddltitle"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddltitle" runat="server" class="form-control text-blue">
                                                            <asp:ListItem>Mr.</asp:ListItem>
                                                            <asp:ListItem>Mrs.</asp:ListItem>
                                                            <asp:ListItem>Miss</asp:ListItem>
                                                            <asp:ListItem>Dr.</asp:ListItem>
                                                            <asp:ListItem>Prof.</asp:ListItem>
                                                            <asp:ListItem>Master</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtledname" class="col-sm-2 col-form-label">
                                                        Ledger Name
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtledname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtledname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Guest Name/Companion Guest Name" ValidationGroup="entry" AutoPostBack="True"></asp:TextBox>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divphn" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtphnno" class="col-sm-2 col-form-label">
                                                        Phone Number
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtphnno"
                                                            runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtphnno" placeholder="10 digit Mobile No."
                                                            runat="server" MaxLength="10" AutoPostBack="True"></asp:TextBox>
                                                    <div id="valmsg" runat="server">
                                                        </div>
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
                                                            SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtmail" runat="server" placeholder="abc@gmail.com"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divdob" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label7" runat="server" class="col-sm-2 col-form-label" Text="Date of Birth"
                                                        AssociatedControlID="txtdob"></asp:Label>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtdob" runat="server" class="form-control text-blue" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdob"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divgender" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label6" runat="server" class="col-sm-2 col-form-label" Text="Gender"
                                                        AssociatedControlID="rdblgender"></asp:Label>
                                                    <asp:RadioButtonList ID="rdblgender" runat="server" class="form-check rbl text-blue"
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True">Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divreln" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label21" runat="server" class="col-sm-2 col-form-label" Text="Relationship"
                                                        AssociatedControlID="txtrelationship"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtrelationship" placeholder="Relationship"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divadrs" runat="server">
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h5>
                                                    Correspondence Details</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label3" runat="server" class="col-sm-2 col-form-label" Text="Address"
                                                            AssociatedControlID="txtaddress"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox type="text" class="form-control text-blue" ID="txtaddress" runat="server"
                                                                placeholder="Permanent Address" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtpin" class="col-sm-2 col-form-label">
                                                            Pincode
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtpin" placeholder="6 digit Pin code"
                                                                runat="server" MaxLength="6" ClientIDMode="Static"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtlocality" class="col-sm-2 col-form-label">
                                                            Landmark
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtlocality" placeholder="Area Name"
                                                                runat="server" ClientIDMode="Static"></asp:TextBox>
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
                                                            <asp:TextBox class="form-control text-blue" ID="txtstate" placeholder="State" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label17" runat="server" class="col-sm-2 col-form-label" Text="Country"
                                                            AssociatedControlID="txtcountry"></asp:Label>
                                                        <div class=" col-sm-4 d-flex justify-content-between align-items-center">
                                                            <asp:RadioButtonList ID="rblcountry" runat="server" class="form-check rbl text-blue"
                                                                RepeatDirection="Horizontal" AutoPostBack="True">
                                                                <asp:ListItem Selected="True">India</asp:ListItem>
                                                                <asp:ListItem>Other (*Please Specify)</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                        <div class=" col-sm-6">
                                                            <asp:TextBox class="form-control text-blue" ID="txtcountry" placeholder="Country Name"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label20" runat="server" class="col-sm-2 col-form-label" Text="Nationality"
                                                            AssociatedControlID="txtnationality"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtnationality" placeholder="Nationality"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="dividproof" runat="server">
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h5>
                                                    ID Details</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label9" runat="server" class="col-sm-2 col-form-label" Text="ID Proof"
                                                            AssociatedControlID="ddlidproof"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlidproof" runat="server" class="form-control text-blue text-uppercase">
                                                                <asp:ListItem>Aadhar Card</asp:ListItem>
                                                                <asp:ListItem>Voter Card</asp:ListItem>
                                                                <asp:ListItem>Pan Card</asp:ListItem>
                                                                <asp:ListItem>Driving License</asp:ListItem>
                                                                <asp:ListItem>Passport</asp:ListItem>
                                                                <asp:ListItem>Arms Licence</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label10" runat="server" class="col-sm-2 col-form-label" Text="ID Proof Number"
                                                            AssociatedControlID="txtidprfno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtidprfno" runat="server" placeholder="ID proof number"></asp:TextBox>
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
