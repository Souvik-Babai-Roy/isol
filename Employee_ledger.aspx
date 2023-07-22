<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Employee_ledger.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Employee Entry</title>
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
                                Employee Entry</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Personal Information</h5>
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
                                                        Employee Name
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtledname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtledname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Employee Name" ValidationGroup="entry" AutoPostBack="True"></asp:TextBox>
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
                                        <div class="row" id="divdob" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label id="Label7" runat="server" class="col-sm-2 col-form-label" for="txtdob">
                                                        Date of Birth
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtdob" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
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
                                        <div class="row" id="divblgrp" runat="server">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label8" runat="server" class="col-sm-2 col-form-label" Text="Blood Group"
                                                        AssociatedControlID="ddlbloodgrp"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlbloodgrp" runat="server" class="form-control text-blue text-uppercase">
                                                            <asp:ListItem>A Positive</asp:ListItem>
                                                            <asp:ListItem>A Negative</asp:ListItem>
                                                            <asp:ListItem>B Positive</asp:ListItem>
                                                            <asp:ListItem>B Negative</asp:ListItem>
                                                            <asp:ListItem>AB Positive</asp:ListItem>
                                                            <asp:ListItem>AB Negative</asp:ListItem>
                                                            <asp:ListItem>O Positive</asp:ListItem>
                                                            <asp:ListItem>O Negative</asp:ListItem>
                                                            <asp:ListItem>Unknown</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <table class="table-borderless">
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle; width: 200px;">
                                                    <asp:Label ID="Label49" runat="server" Text="Marital Status" AssociatedControlID="chkmarried"></asp:Label>
                                                </td>
                                                <td style="height: 20px; vertical-align: middle;">
                                                    <div class="form-control border-0">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkmarried" runat="server"
                                                                clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                    for="chkmarried" id="lblchkmarried" runat="server"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divadrs" runat="server">
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h5>
                                                    Correspondence Details</h5>
                                            </div>
                                            <div class="border-bottom mb-2">
                                                <h6 style="font-style: italic">
                                                    Permanent Address</h6>
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
                                            <div action="#" method="post">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label for="txtpin" class="col-sm-2 col-form-label">
                                                                Pincode
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtpin"
                                                                    runat="server" ErrorMessage="*" ValidationExpression="[1-9]{1}[0-9]{2}[0-9]{3}"
                                                                    SetFocusOnError="true"></asp:RegularExpressionValidator></label>
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
                                                                <asp:TextBox class="form-control text-blue" ID="txtlocality" placeholder="Landmark"
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
                                                                <asp:TextBox class="form-control text-blue" ID="txtstate" placeholder="State" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label48" runat="server" class="col-sm-2 col-form-label" Text="Country"
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
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label11" runat="server" class="col-sm-2 col-form-label" Text="" AssociatedControlID="chkbxresadrs"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxresadrs" runat="server"
                                                                        clientidmode="Static" onclick="autopostback()" checked="checked" /><label class="custom-control-label text-blue text-sm"
                                                                            for="chkbxresadrs">Is residential address is same as permanent address?</label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divresaddress" runat="server" visible="false">
                                                <div class="border-bottom mb-3">
                                                    <h6 style="font-style: italic">
                                                        Residential Address</h6>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label45" runat="server" class="col-sm-2 col-form-label" Text="Address"
                                                                AssociatedControlID="txtresadrs"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox type="text" class="form-control text-blue" ID="txtresadrs" runat="server"
                                                                    placeholder="Residential Address" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div action="#" method="post">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group row">
                                                                <label for="txtrespin" class="col-sm-2 col-form-label">
                                                                    Pincode
                                                                </label>
                                                                <div class=" col-sm-10">
                                                                    <asp:TextBox class="form-control text-blue" ID="txtrespin" placeholder="6 digit Pin code"
                                                                        runat="server" MaxLength="6" ClientIDMode="Static"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group row">
                                                                <label for="txtreslandmark" class="col-sm-2 col-form-label">
                                                                    Landmark
                                                                </label>
                                                                <div class=" col-sm-10">
                                                                    <asp:TextBox class="form-control text-blue" ID="txtreslandmark" placeholder="Landmark"
                                                                        runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group row">
                                                                <asp:Label ID="Label46" class="col-sm-2 col-form-label" runat="server" Text="State"
                                                                    AssociatedControlID="txtresstate"></asp:Label>
                                                                <div class=" col-sm-10">
                                                                    <asp:TextBox class="form-control text-blue" ID="txtresstate" placeholder="State"
                                                                        runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label17" runat="server" class="col-sm-2 col-form-label" Text="Country"
                                                                AssociatedControlID="txtrescountry"></asp:Label>
                                                            <div class=" col-sm-4 d-flex justify-content-between align-items-center">
                                                                <asp:RadioButtonList ID="rblrescountry" runat="server" class="form-check rbl text-blue"
                                                                    RepeatDirection="Horizontal" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True">India</asp:ListItem>
                                                                    <asp:ListItem>Other (*Please Specify)</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                            <div class=" col-sm-6">
                                                                <asp:TextBox class="form-control text-blue" ID="txtrescountry" placeholder="Country Name"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
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
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <table class="table-borderless">
                                                <tr>
                                                    <td style="height: 20px; vertical-align: middle; width: 260px;">
                                                        <h5>
                                                            Emergency Information</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxemgc" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxemgc" id="lblchkbxemgc" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divemergency" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtemcnno" class="col-sm-2 col-form-label">
                                                            Emergency Contact Number
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtemcnno"
                                                                runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtemcnno" runat="server"
                                                                placeholder="10 Digit mobile no." MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label13" runat="server" class="col-sm-2 col-form-label" Text="Emergency Contact Person"
                                                            AssociatedControlID="txtemcnname"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtemcnname" runat="server"
                                                                placeholder="Emergency Contact Person Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label1" runat="server" class="col-sm-2 col-form-label" Text="Emergency Address"
                                                            AssociatedControlID="txtemadrs"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox type="text" class="form-control text-blue" ID="txtemadrs" runat="server"
                                                                placeholder="Emergency Address" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <table class="table-borderless">
                                                <tr>
                                                    <td style="height: 20px; vertical-align: middle; width: 260px;">
                                                        <h5>
                                                            Banking Details</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxbank" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxbank" id="lblchkbxbank" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divbank" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label25" runat="server" class="col-sm-2 col-form-label" Text="Bank Name"
                                                            AssociatedControlID="txtbankname"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtbankname" runat="server"
                                                                placeholder="Bank Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label26" runat="server" class="col-sm-2 col-form-label" Text="Account Number"
                                                            AssociatedControlID="txtacno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtacno" runat="server"
                                                                placeholder="Account Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label2" runat="server" class="col-sm-2 col-form-label" Text="Account Type"
                                                            AssociatedControlID="txtactype"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtactype" runat="server"
                                                                placeholder="Account Type"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label27" runat="server" class="col-sm-2 col-form-label" Text="IFSC Code"
                                                            AssociatedControlID="txtpanno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtifsccode" runat="server"
                                                                placeholder="IFSC Code"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label28" runat="server" class="col-sm-2 col-form-label" Text="Branch Name"
                                                            AssociatedControlID="txtbranch"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtbranch" runat="server"
                                                                placeholder="Branch Name"></asp:TextBox>
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
                                                        <asp:Label ID="Label12" runat="server" class="col-sm-2 col-form-label" Text="UPI ID"
                                                            AssociatedControlID="txtupiid"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtupiid" runat="server"
                                                                placeholder="name@BankName or mobile@BankName"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <table class="table-borderless">
                                                <tr>
                                                    <td style="height: 20px; vertical-align: middle; width: 260px;">
                                                        <h5>
                                                            Health Insurance Information</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxhealth" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxhealth" id="lblchkbxhealth" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divhealth" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label30" runat="server" class="col-sm-2 col-form-label" Text="ESIC No."
                                                            AssociatedControlID="txtesic"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtesic" runat="server"
                                                                placeholder="Employee State Insurance Scheme Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label32" runat="server" class="col-sm-2 col-form-label" Text="Health Insurance Company"
                                                            AssociatedControlID="txthealthcom"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txthealthcom" runat="server"
                                                                placeholder="COmpany Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label33" runat="server" class="col-sm-2 col-form-label" Text="Health Insurance No."
                                                            AssociatedControlID="txthealthinsno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txthealthinsno" runat="server"
                                                                placeholder="Insurance Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label35" runat="server" class="col-sm-2 col-form-label" Text="Coverage"
                                                            AssociatedControlID="txthealthcov"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txthealthcov" runat="server"
                                                                placeholder="Insurance Coverage"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label34" runat="server" class="col-sm-2 col-form-label" Text="Description"
                                                            AssociatedControlID="txthealthdesc"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txthealthdesc" runat="server"
                                                                placeholder="Insurance Description"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <table class="table-borderless">
                                                <tr>
                                                    <td style="height: 20px; vertical-align: middle; width: 260px;">
                                                        <h5>
                                                            Life Insurance Information</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxlife" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxlife" id="lblchkbxlife" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divlife" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label16" runat="server" class="col-sm-2 col-form-label" Text="Life Insurance Company"
                                                            AssociatedControlID="txtlifecom"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtlifecom" runat="server"
                                                                placeholder="Company Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label21" runat="server" class="col-sm-2 col-form-label" Text="Life Insurance No."
                                                            AssociatedControlID="txtlifeinsno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtlifeinsno" runat="server"
                                                                placeholder="Insurance Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label22" runat="server" class="col-sm-2 col-form-label" Text="Coverage"
                                                            AssociatedControlID="txtlifecov"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtlifecov" runat="server"
                                                                placeholder="Insurance Coverage"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label23" runat="server" class="col-sm-2 col-form-label" Text="Description"
                                                            AssociatedControlID="txtlifedesc"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtlifedesc" runat="server"
                                                                placeholder="Insurance Description"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <table class="table-borderless">
                                                <tr>
                                                    <td style="height: 20px; vertical-align: middle; width: 260px;">
                                                        <h5>
                                                            Job Information</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxjob" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxjob" id="lblchkbxjob" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divjobinfo" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label id="Label36" runat="server" class="col-sm-2 col-form-label" for="txtjoiningdate">
                                                            Joining Date
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                                SetFocusOnError="true" ControlToValidate="txtjoiningdate" ValidationGroup="entry"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="col-sm-10">
                                                            <asp:TextBox ID="txtjoiningdate" runat="server" class="form-control text-blue" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtjoiningdate"
                                                                Format="yyyy-MM-dd" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label37" runat="server" class="col-sm-2 col-form-label" Text="Employee Type"
                                                            AssociatedControlID="ddlemptype"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlemptype" runat="server" class="form-control text-blue">
                                                                <asp:ListItem>Permanent</asp:ListItem>
                                                                <asp:ListItem>Non-Permanent</asp:ListItem>
                                                                <asp:ListItem>Apprentice</asp:ListItem>
                                                                <asp:ListItem>Casual</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label38" runat="server" class="col-sm-2 col-form-label" Text="Designation"
                                                            AssociatedControlID="ddldesig"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddldesig" runat="server" class="form-control text-blue">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <table class="table-borderless">
                                                <tr>
                                                    <td style="height: 20px; vertical-align: middle; width: 260px;">
                                                        <h5>
                                                            HRA Information</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxhra" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxhra" id="lblchkbxhra" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divhra" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label14" runat="server" class="col-sm-2 col-form-label" Text="Basic Salary"
                                                            AssociatedControlID="txtbasesal"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtbasesal" runat="server"
                                                                placeholder="Basic Salary Amount" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label40" runat="server" class="col-sm-2 col-form-label" Text="DA"
                                                            AssociatedControlID="txtda"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtda" runat="server"
                                                                placeholder="DA Amount" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label41" runat="server" class="col-sm-2 col-form-label" Text="HRA"
                                                            AssociatedControlID="txthra"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txthra" runat="server"
                                                                placeholder="HRA Amount" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label43" runat="server" class="col-sm-2 col-form-label" Text="PF Amount"
                                                            AssociatedControlID="txtpfamnt"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtpfamnt" runat="server"
                                                                placeholder="Provident Fund Amount"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label29" runat="server" class="col-sm-2 col-form-label" Text="PF No."
                                                            AssociatedControlID="txtpfno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtpfno" runat="server"
                                                                placeholder="Provident Fund Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label31" runat="server" class="col-sm-2 col-form-label" Text="Gratuity Amount"
                                                            AssociatedControlID="txtgraamnt"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtgraamnt" runat="server"
                                                                placeholder="Gratuity Amount"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label15" runat="server" class="col-sm-2 col-form-label" Text="Allowance Details"
                                                            AssociatedControlID="txtallowdet"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtallowdet" runat="server"
                                                                placeholder="Allowances Details"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label39" runat="server" class="col-sm-2 col-form-label" Text="Allowance Amount"
                                                            AssociatedControlID="txtallowamnt"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtallowamnt" runat="server"
                                                                placeholder="Allowances Amount" AutoPostBack="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label42" runat="server" class="col-sm-2 col-form-label" Text="Fringe Benefits"
                                                            AssociatedControlID="txtfriben"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtfriben" runat="server"
                                                                placeholder="Fringe Benefits Deatils"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label44" runat="server" class="col-sm-2 col-form-label" Text="Gross Salary/CTC"
                                                            AssociatedControlID="txtctc"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue text-uppercase" ID="txtctc" runat="server"
                                                                placeholder="Gross Salary Amount" AutoPostBack="True"></asp:TextBox>
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
                                        <i class="fas fa-plus-square"></i>&nbsp; Add Employee
                                    </button>
                                    <button type="submit" class="btn btn-secondary btn-block text-bold" id="btnupdate"
                                        runat="server" visible="False">
                                        <i class="fas fa-edit"></i>&nbsp; Update Employee
                                    </button>
                                    <asp:LinkButton ID="btndelete" runat="server" class="btn btn-warning btn-block text-bold"
                                        Visible="False"><i class="fas fa-trash"></i> &nbsp; Delete Employee</asp:LinkButton>
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
                                Employee Update</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label18" runat="server" class="col-sm-2 col-form-label" Text="Employee Name/ID"
                                                AssociatedControlID="txtsearchname"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:TextBox ID="txtsearchname" placeholder="Employee Name (ID for Update)" class="form-control"
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
                                            <i class="fas fa-search"></i>&nbsp; Search With Employee Name</button>
                                        <button type="Submit" id="btnupdateinfo" class="btn bg-gradient-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Get Information For Update</button>
                                            <button type="Submit" id="btndocument" class="btn bg-gradient-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Download Form</button>
                                    </div>
                                    <button id="btngstprint" runat="server" class="btn btn-app bg-gradient-fuchsia text-bold"
                                        onclick="return PrintgstPanel();" visible="true">
                                        <i class="fas fa-print"></i>Print</button>
                                    <div id="viewreg" runat="server">
                                        
                                        
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
    <script type="text/javascript">
        function autopostback() {
            __doPostBack("<%=UpdatePanel1.UniqueID %>", "");
        }
    </script>
     <script type="text/javascript">
         function PrintgstPanel() {
             var panel = document.getElementById("<%=viewreg.ClientID %>");
             var printWindow = window.open('', '', 'height=500,width=850,left=0,top=0,location=1,status=1,scrollbars=1');
             printWindow.document.write('<html><head> <title>Student Registration Form</title>');
             printWindow.document.write('<link href="Styles/adminlte.min.css" rel="stylesheet" type="text/css" />');
             printWindow.document.write('<link href="Styles/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>');
             printWindow.document.write('<link href="Styles/fontawesome-free/css/all.css" rel="stylesheet" type="text/css" />');
             printWindow.document.write('<link rel="stylesheet" type="text/css" href="Styles/emp_idcard.css" />');
             printWindow.document.write('<style type=text/css>@page {size: auto;margin: 0; } table{border-collapse: collapse;}   .sansserif{font-family: Arial, Helvetica, sans-serif;} h1{text-transform: uppercase;font-style: normal; } </style>');


             printWindow.document.write('</head><body>');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');

             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }

     </script>
    <%--<link href="Styles/emp_idcard.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
