<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Student_ledger.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Student Ledger</title>
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
        
            .mobile thead, .mobile th
            {
                display: none;
            }
        
            /* Change these as needed */
            .mobile td
            {
                margin-left: 0.5em;
            }
            .mobile td:before
            {
                margin-left: -0.5em;
            }
        
        
        }
    </style>
    <style type="text/css">
        @media only screen and (max-width: 700px)
        {
            .mobile1 table, .mobile1 thead, .mobile1 tbody, .mobile1 th, .mobile1 td, .mobile1 tr
            {
                display: block;
            }
            .mobile1 thead .mobile1 tr
            {
                position: absolute;
                top: -9999px;
                left: -9999px;
            }
            .mobile1 tr
            {
                border: 1px solid #ccc;
                margin-bottom: .5em;
            }
            .mobile1 td
            {
                border: none;
                position: relative;
                padding: 1em .5em;
            }
            .mobile1 td:before
            {
                position: absolute;
                top: 0;
                left: 0;
                padding: 1em .5em;
                white-space: wrap;
            }
            .mobile1 thead, .mobile1 th
            {
                display: none;
            }
        
            /* Change these as needed */
            .mobile1 td
            {
                margin-left: 8.5em;
            }
            .mobile1 td:before
            {
                margin-left: -8.5em;
            }
            .mobile1 td:nth-child(1)
            {
                margin-left: 0em;
                text-align: center;
                text-decoration: underline;
            }
            .mobile1 td:nth-child(1)::before
            {
                margin-left: 0em;
                text-align: center;
                text-decoration: underline;
            }
            .mobile1 td:nth-child(2)::before
            {
                content: "Use of Student Photograph ";
                font-weight: bold;
            }
            .mobile1 td:nth-child(3)::before
            {
                content: "Use of Work by Student  ";
                font-weight: bold;
            }
            .mobile1 td:nth-child(4)::before
            {
                content: "Publishing Student Name  ";
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
                        <div class="card-header" style="background-color: #5777ba; color: White;">
                            <h3 class="card-title">
                                Student Entry</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Personal Information</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtstudentname" class="col-sm-2 col-form-label">
                                                        Student Full Name
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtstudentname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtstudentname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Student's full Name" ValidationGroup="entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label27" runat="server" class="col-sm-2 col-form-label" Text="Nicknames (If any)"
                                                        AssociatedControlID="txtnickname"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox type="text" class="form-control text-blue" ID="txtnickname" runat="server"
                                                            placeholder="Student Nicknames"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label28" runat="server" class="col-sm-2 col-form-label" Text="Father's Full Name"
                                                        AssociatedControlID="txtfathername"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox type="text" class="form-control text-blue" ID="txtfathername" runat="server"
                                                            placeholder="Father's Full Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label29" runat="server" class="col-sm-2 col-form-label" Text="Mother's Full Name"
                                                        AssociatedControlID="txtmothername"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox type="text" class="form-control text-blue" ID="txtmothername" runat="server"
                                                            placeholder="Mother's Full Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label" for="txtdob">
                                                        Date of Birth
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtdob" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class="col-sm-10">
                                                        <asp:TextBox ID="txtdob" runat="server" class="form-control text-blue" placeholder="yyyy-mm-dd"
                                                            AutoPostBack="True" ClientIDMode="Static"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdob"
                                                            Format="yyyy-MM-dd" />
                                                        <div id="valmsg" runat="server">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label7" runat="server" class="col-sm-2 col-form-label" Text="Entrance Class"
                                                        AssociatedControlID="ddlclass"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlclass" runat="server" class="form-control text-blue text-uppercase">
                                                            <asp:ListItem>I</asp:ListItem>
                                                            <asp:ListItem>II</asp:ListItem>
                                                            <asp:ListItem>III</asp:ListItem>
                                                            <asp:ListItem>IV</asp:ListItem>
                                                            <asp:ListItem>V</asp:ListItem>
                                                            <asp:ListItem>VI</asp:ListItem>
                                                            <asp:ListItem>VII</asp:ListItem>
                                                            <asp:ListItem>VIII</asp:ListItem>
                                                            <asp:ListItem>IX</asp:ListItem>
                                                            <asp:ListItem>X</asp:ListItem>
                                                            <asp:ListItem>XI</asp:ListItem>
                                                            <asp:ListItem>XII</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label6" runat="server" class="col-sm-2 col-form-label" Text="Gender"
                                                        AssociatedControlID="rdblgender"></asp:Label>
                                                    <asp:RadioButtonList ID="rdblgender" runat="server" class="form-check rbl text-blue"
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
                                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                                        <asp:ListItem Value="Other">Transgender</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label8" runat="server" class="col-sm-2 col-form-label" Text="Blood Group"
                                                        AssociatedControlID="ddlbloodgrp"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlbloodgrp" runat="server" class="form-control text-blue text-uppercase">
                                                            <asp:ListItem>NA</asp:ListItem>
                                                            <asp:ListItem>A Positive</asp:ListItem>
                                                            <asp:ListItem>A Negative</asp:ListItem>
                                                            <asp:ListItem>B Positive</asp:ListItem>
                                                            <asp:ListItem>B Negative</asp:ListItem>
                                                            <asp:ListItem>AB Positive</asp:ListItem>
                                                            <asp:ListItem>AB Negative</asp:ListItem>
                                                            <asp:ListItem>O Positive</asp:ListItem>
                                                            <asp:ListItem>O Negative</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label24" runat="server" class="col-sm-4 col-form-label" Text="Cast/Quota"
                                                        AssociatedControlID="txtcast"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox type="text" class="form-control text-blue" ID="txtcast" runat="server"
                                                            placeholder="Cast"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-6">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label58" runat="server" class="col-sm-4 col-form-label" Text="Religion"
                                                        AssociatedControlID="txtreligion"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox type="text" class="form-control text-blue" ID="txtreligion" runat="server"
                                                            placeholder="Religion"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label26" runat="server" class="col-sm-2 col-form-label" Text="Student Image"
                                                        AssociatedControlID="filestudimg"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:FileUpload ID="filestudimg" runat="server" class="form-control text-blue" accept="image/*" />
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
                                                                placeholder="Residential Address" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
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
                                                            Suburb/town/community
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
                                                        <asp:Label ID="Label46" class="col-sm-2 col-form-label" runat="server" Text="State"
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
                                                                runat="server" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label57" runat="server" class="col-sm-2 col-form-label" Text="Nationality"
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
                                                    Student ID Details</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label9" runat="server" class="col-sm-2 col-form-label" Text="ID Proof"
                                                            AssociatedControlID="ddlstudentidproof"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlstudentidproof" runat="server" class="form-control text-blue text-uppercase">
                                                                <asp:ListItem>Birth Certificate</asp:ListItem>
                                                                <asp:ListItem>Aadhar Card</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label10" runat="server" class="col-sm-2 col-form-label" Text="ID Proof Number"
                                                            AssociatedControlID="txtstudentidprfno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtstudentidprfno" runat="server"
                                                                placeholder="ID proof number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label4" runat="server" class="col-sm-2 col-form-label" Text="ID proof Image"
                                                            AssociatedControlID="filestudentidimg"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:FileUpload ID="filestudentidimg" runat="server" class="form-control text-blue"
                                                                accept="image/*" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <table class="table-borderless">
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle; width: 250px;">
                                                    <asp:Label ID="Label11" runat="server" Text="Are you a secondary student?" AssociatedControlID="chkbxsecondary"></asp:Label>
                                                </td>
                                                <td style="height: 20px; vertical-align: middle;">
                                                    <div class="form-control border-0">
                                                        <div class="custom-control custom-switch text-sm">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxsecondary" runat="server"
                                                                clientidmode="Static" onclick="autopostback()" />
                                                            <label class="custom-control-label text-blue" for="chkbxsecondary" id="lblchkbxsecondary"
                                                                runat="server">
                                                            </label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divsecondarystudent" runat="server" visible="false">
                                            <div class="border-bottom mb-2">
                                                <h5>
                                                    For senior secondary students only</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtphnno" class="col-sm-2 col-form-label">
                                                            Phone Number
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtphnno"
                                                                runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtphnno" placeholder="10 digit Mobile No."
                                                                runat="server" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
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
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label5" runat="server" class="col-sm-2 col-form-label" Text="Car Registration No"
                                                            AssociatedControlID="txtcarregno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtcarregno" runat="server" placeholder="Student’s car registration number: (if applicable)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label30" runat="server" class="col-sm-2 col-form-label" Text="Social Status"
                                                            AssociatedControlID="chksstatus"></asp:Label>
                                                        <div class="col-sm-10">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chksstatus" runat="server"
                                                                        clientidmode="Static" /><label class="custom-control-label text-blue" for="chksstatus">Is
                                                                            the student independent? (living without parents)</label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Guardian Information</h5>
                                        </div>
                                        <div class="form-control border-0">
                                            <div class="custom-control custom-switch">
                                                <input type="checkbox" class="custom-control-input" id="chkbxgrd1" runat="server"
                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                        for="chkbxgrd1">
                                                        <i class="fas fa-square-plus"></i>&nbsp;Add 1<sup>st</sup> Guardian Details</label>
                                            </div>
                                        </div>
                                        <div id="divguardian1" runat="server" visible="False">
                                            <div class="border-bottom mb-2">
                                                <h6 style="font-style: italic">
                                                    Guadian 1</h6>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd1name" class="col-sm-2 col-form-label">
                                                            Guardian Name
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox ID="txtgrd1name" runat="server" class="form-control text-blue input-radius"
                                                                placeholder="Guardian Name" ValidationGroup="entry"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label39" runat="server" class="col-sm-2 col-form-label" Text="Relationship"
                                                            AssociatedControlID="txtgrd1reln"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd1reln" placeholder="Relationship With student"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd1phn" class="col-sm-2 col-form-label">
                                                            Phone Number
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtgrd1phn"
                                                                runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd1phn" placeholder="10 digit Mobile No."
                                                                runat="server" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd1altphn" class="col-sm-2 col-form-label">
                                                            Alternative Phone Number
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtgrd1altphn"
                                                                runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd1altphn" placeholder="10 digit Mobile No."
                                                                runat="server" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd1mail" class="col-sm-2 col-form-label">
                                                            Email Address
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtgrd1mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd1mail" runat="server" placeholder="abc@gmail.com"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label25" runat="server" class="col-sm-2 col-form-label" Text="Address Confirmation"
                                                            AssociatedControlID="chkbxgrd1adrsstud"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxgrd1adrsstud" runat="server"
                                                                        clientidmode="Static" onclick="autopostback()" checked="checked" /><label class="custom-control-label text-blue text-sm"
                                                                            for="chkbxgrd1adrsstud">Is guardian residential and permanent address same as student
                                                                            address?</label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="divgrd1resadrs" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label2" runat="server" class="col-sm-2 col-form-label" Text="Residential Address"
                                                            AssociatedControlID="txtgrd1adrs"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox type="text" class="form-control text-blue" ID="txtgrd1adrs" runat="server"
                                                                placeholder="Full residential Address" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="divgrd1peradrs" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label1" runat="server" class="col-sm-2 col-form-label" Text="Permanent Address"
                                                            AssociatedControlID="txtgrd1peradrs"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox type="text" class="form-control text-blue" ID="txtgrd1peradrs" runat="server"
                                                                placeholder="Full permanent address (if different from above)" TextMode="MultiLine"
                                                                Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <table class="table-borderless">
                                                    <tr>
                                                        <td style="height: 20px; vertical-align: middle; width: 200px;">
                                                            <h6 style="font-style: italic">
                                                                Background Information</h6>
                                                        </td>
                                                        <td style="height: 20px; vertical-align: middle;">
                                                            <div class="form-control border-0 text-sm">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxgrd1bginfo" runat="server"
                                                                        clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue text-sm"
                                                                            for="chkbxgrd1bginfo" id="lblchkbxgrd1bginfo" runat="server"></label>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divgrd1bginfo" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label37" runat="server" class="col-sm-2 col-form-label" Text="Highest Tier of Secondary Education"
                                                                AssociatedControlID="ddlgrd1secondary"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:DropDownList ID="ddlgrd1secondary" runat="server" class="form-control text-blue">
                                                                    <asp:ListItem>Not Applicable</asp:ListItem>
                                                                    <asp:ListItem>Class 8 or lower</asp:ListItem>
                                                                    <asp:ListItem>10th or equivalent</asp:ListItem>
                                                                    <asp:ListItem>12th or equivalent</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label38" runat="server" class="col-sm-2 col-form-label" Text="Highest Qualification"
                                                                AssociatedControlID="ddlgrd1qualification"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:DropDownList ID="ddlgrd1qualification" runat="server" class="form-control text-blue">
                                                                    <asp:ListItem>Not Applicable</asp:ListItem>
                                                                    <asp:ListItem>Bachelor degree or above</asp:ListItem>
                                                                    <asp:ListItem>Advanced diploma/Diploma</asp:ListItem>
                                                                    <asp:ListItem>Trade Certificate</asp:ListItem>
                                                                    <asp:ListItem>No non-school qualification</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label40" runat="server" class="col-sm-2 col-form-label" Text="Occupation"
                                                                AssociatedControlID="txtgrd1occu"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtgrd1occu" runat="server" placeholder="Guardian 1 occupation"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h6 style="font-style: italic">
                                                    Guadian 1 ID Proof</h6>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label22" runat="server" class="col-sm-2 col-form-label" Text="ID Proof"
                                                            AssociatedControlID="ddlgrd1idprf"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlgrd1idprf" runat="server" class="form-control text-blue text-uppercase">
                                                                <asp:ListItem>Aadhar Card</asp:ListItem>
                                                                <asp:ListItem>Voter Card</asp:ListItem>
                                                                <asp:ListItem>Pan Card</asp:ListItem>
                                                                <asp:ListItem>Driving License</asp:ListItem>
                                                                <asp:ListItem>Passport</asp:ListItem>
                                                                <asp:ListItem>Arms license</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label23" runat="server" class="col-sm-2 col-form-label" Text="ID Proof Number"
                                                            AssociatedControlID="txtgrd1idprfno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd1idprfno" runat="server" placeholder="Guardian 1 ID proof number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label44" runat="server" class="col-sm-2 col-form-label" Text="ID proof upload"
                                                            AssociatedControlID="filegrd1idproof"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:FileUpload ID="filegrd1idproof" runat="server" class="form-control text-blue"
                                                                accept="image/*" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label31" runat="server" class="col-sm-4 col-form-label" Text="Responsible for parenting"
                                                            AssociatedControlID="chkbxresponsiblegrd1"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxresponsiblegrd1" runat="server"
                                                                        clientidmode="Static" /><label class="custom-control-label text-blue" for="chkbxresponsiblegrd1"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label32" runat="server" class="col-sm-4 col-form-label" Text="Lives with student"
                                                            AssociatedControlID="chkbxlivewstugrd1"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxlivewstugrd1" runat="server"
                                                                        clientidmode="Static" /><label class="custom-control-label text-blue" for="chkbxlivewstugrd1"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label33" runat="server" class="col-sm-4 col-form-label" Text="Receive reports etc"
                                                            AssociatedControlID="chkbxreportgrd1"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxreportgrd1" runat="server"
                                                                        clientidmode="Static" /><label class="custom-control-label text-blue" for="chkbxreportgrd1"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label34" runat="server" class="col-sm-4 col-form-label" Text="Contact this person in an emergency?"
                                                            AssociatedControlID="chkbxgrd1emccntct"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxgrd1emccntct" runat="server"
                                                                        clientidmode="Static" onclick="autopostback()" checked="checked" /><label class="custom-control-label text-blue"
                                                                            for="chkbxgrd1emccntct"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="emc1" runat="server" visible="false">
                                                <div class="border-bottom mb-2">
                                                    <h6 style="font-style: italic">
                                                        Emergency Contact 1</h6>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label for="txtemgc1name" class="col-sm-2 col-form-label">
                                                                Contact Name
                                                            </label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox ID="txtemgc1name" runat="server" class="form-control text-blue input-radius"
                                                                    placeholder="1st Emergency Contact Name" ValidationGroup="entry"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label55" runat="server" class="col-sm-2 col-form-label" Text="Relationship"
                                                                AssociatedControlID="txtemgc1reln"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtemgc1reln" placeholder="Relationship With student"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label for="txtemgc1phn" class="col-sm-2 col-form-label">
                                                                Phone Number
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtemgc1phn"
                                                                    runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtemgc1phn" placeholder="10 digit Mobile No."
                                                                    runat="server" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label for="txtemgc1altphn" class="col-sm-2 col-form-label">
                                                                Alternative Phone Number
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txtemgc1altphn"
                                                                    runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtemgc1altphn" placeholder="10 digit Mobile No."
                                                                    runat="server" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-control border-0">
                                            <div class="custom-control custom-switch">
                                                <input type="checkbox" class="custom-control-input" id="chkbxgrd2" runat="server"
                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                        for="chkbxgrd2">
                                                        <i class="fas fa-square-plus"></i>&nbsp;Add 2<sup>nd</sup> Guardian Details</label>
                                            </div>
                                        </div>
                                        <div id="divguardian2" runat="server" visible="False">
                                            <div class="border-bottom mb-2">
                                                <h6 style="font-style: italic">
                                                    Guadian 2</h6>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd2name" class="col-sm-2 col-form-label">
                                                            Guardian Name
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox ID="txtgrd2name" runat="server" class="form-control text-blue input-radius"
                                                                placeholder="Guardian Name" ValidationGroup="entry"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label13" runat="server" class="col-sm-2 col-form-label" Text="Relationship"
                                                            AssociatedControlID="txtgrd2reln"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd2reln" placeholder="Relationship With student"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd2phn" class="col-sm-2 col-form-label">
                                                            Phone Number
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtgrd2phn"
                                                                runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd2phn" placeholder="10 digit Mobile No."
                                                                runat="server" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd2altphn" class="col-sm-2 col-form-label">
                                                            Alternative Phone Number
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtgrd2altphn"
                                                                runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd2altphn" placeholder="10 digit Mobile No."
                                                                runat="server" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtgrd2mail" class="col-sm-2 col-form-label">
                                                            Email Address
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="*"
                                                                ControlToValidate="txtgrd2mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd2mail" runat="server" placeholder="abc@gmail.com"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label35" runat="server" class="col-sm-2 col-form-label" Text="Address Confirmation"
                                                            AssociatedControlID="chkbxgrd2adrsstud"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxgrd2adrsstud" runat="server"
                                                                        clientidmode="Static" onclick="autopostback()" checked="checked" /><label class="custom-control-label text-blue text-sm"
                                                                            for="chkbxgrd2adrsstud">Is guardian residential and permanent address same as student
                                                                            address?</label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="divgrd2resadrs" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label21" runat="server" class="col-sm-2 col-form-label" Text="Residential Address"
                                                            AssociatedControlID="txtgrd2adrs"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox type="text" class="form-control text-blue" ID="txtgrd2adrs" runat="server"
                                                                placeholder="Full Residential Address" TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" id="divgrd2peradrs" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label36" runat="server" class="col-sm-2 col-form-label" Text="Permanent Address"
                                                            AssociatedControlID="txtgrd2peradrs"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox type="text" class="form-control text-blue" ID="txtgrd2peradrs" runat="server"
                                                                placeholder="Full permanent address (if different from above)" TextMode="MultiLine"
                                                                Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <table class="table-borderless">
                                                    <tr>
                                                        <td style="height: 20px; vertical-align: middle; width: 200px;">
                                                            <h6 style="font-style: italic">
                                                                Background Information</h6>
                                                        </td>
                                                        <td style="height: 20px; vertical-align: middle;">
                                                            <div class="form-control border-0 text-sm">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxgrd2bginfo" runat="server"
                                                                        clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue text-sm"
                                                                            for="chkbxgrd2bginfo" id="Label56" runat="server"></label>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divgrd2bginfo" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label41" runat="server" class="col-sm-2 col-form-label" Text="Highest Tier of Secondary Education"
                                                                AssociatedControlID="ddlgrd2secondary"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:DropDownList ID="ddlgrd2secondary" runat="server" class="form-control text-blue">
                                                                    <asp:ListItem>Not Applicable</asp:ListItem>
                                                                    <asp:ListItem>Class 8 or lower</asp:ListItem>
                                                                    <asp:ListItem>10th or equivalent</asp:ListItem>
                                                                    <asp:ListItem>12th or equivalent</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label42" runat="server" class="col-sm-2 col-form-label" Text="Highest Qualification"
                                                                AssociatedControlID="ddlgrd2qualification"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:DropDownList ID="ddlgrd2qualification" runat="server" class="form-control text-blue">
                                                                    <asp:ListItem>Not Applicable</asp:ListItem>
                                                                    <asp:ListItem>Bachelor degree or above</asp:ListItem>
                                                                    <asp:ListItem>Advanced diploma/Diploma</asp:ListItem>
                                                                    <asp:ListItem>Trade Certificate</asp:ListItem>
                                                                    <asp:ListItem>No non-school qualification</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label43" runat="server" class="col-sm-2 col-form-label" Text="Occupation"
                                                                AssociatedControlID="txtgrd2occu"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtgrd2occu" runat="server" placeholder="Guardian 2 occupation"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h6 style="font-style: italic">
                                                    Guadian 2 ID Proof</h6>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label45" runat="server" class="col-sm-2 col-form-label" Text="ID Proof"
                                                            AssociatedControlID="ddlgrd2idprf"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlgrd2idprf" runat="server" class="form-control text-blue text-uppercase">
                                                                <asp:ListItem>Aadhar Card</asp:ListItem>
                                                                <asp:ListItem>Voter Card</asp:ListItem>
                                                                <asp:ListItem>Pan Card</asp:ListItem>
                                                                <asp:ListItem>Driving License</asp:ListItem>
                                                                <asp:ListItem>Passport</asp:ListItem>
                                                                <asp:ListItem>Arms license</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label47" runat="server" class="col-sm-2 col-form-label" Text="ID Proof Number"
                                                            AssociatedControlID="txtgrd2idprfno"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtgrd2idprfno" runat="server" placeholder="Guardian 2 ID proof number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label48" runat="server" class="col-sm-2 col-form-label" Text="ID proof upload"
                                                            AssociatedControlID="dilegrd2idprf"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:FileUpload ID="dilegrd2idprf" runat="server" class="form-control text-blue"
                                                                accept="image/*" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label14" runat="server" class="col-sm-4 col-form-label" Text="Responsible for parenting"
                                                            AssociatedControlID="chkbxresponsiblegrd2"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxresponsiblegrd2" runat="server"
                                                                        clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxresponsiblegrd2"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label15" runat="server" class="col-sm-4 col-form-label" Text="Lives with student"
                                                            AssociatedControlID="chkbxlivewstugrd2"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxlivewstugrd2" runat="server"
                                                                        clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxlivewstugrd2"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label16" runat="server" class="col-sm-4 col-form-label" Text="Receive reports etc"
                                                            AssociatedControlID="chkbxreportgrd2"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxreportgrd2" runat="server"
                                                                        clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxreportgrd2"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label20" runat="server" class="col-sm-4 col-form-label" Text="Contact this person in an emergency?"
                                                            AssociatedControlID="chkbxgrd2emccntc"></asp:Label>
                                                        <div class="col-sm-8">
                                                            <div class="form-control border-0">
                                                                <div class="custom-control custom-switch">
                                                                    <input type="checkbox" class="custom-control-input" id="chkbxgrd2emccntc" runat="server"
                                                                        clientidmode="Static" onclick="autopostback()" checked="checked" /><label class="custom-control-label text-blue"
                                                                            for="chkbxgrd2emccntc"></label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="emc2" runat="server" visible="false">
                                                <br />
                                                <div class="border-bottom mb-2">
                                                    <h6 style="font-style: italic">
                                                        Emergency Contact 2</h6>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label for="txtemgc2name" class="col-sm-2 col-form-label">
                                                                Contact Name
                                                            </label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox ID="txtemgc2name" runat="server" class="form-control text-blue input-radius"
                                                                    placeholder="2nd Emergency Contact Name" ValidationGroup="entry"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <asp:Label ID="Label68" runat="server" class="col-sm-2 col-form-label" Text="Relationship"
                                                                AssociatedControlID="txtemgc2reln"></asp:Label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtemgc2reln" placeholder="Relationship With student"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label for="txtemgc2phn" class="col-sm-2 col-form-label">
                                                                Phone Number
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtemgc2phn"
                                                                    runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtemgc2phn" placeholder="10 digit Mobile No."
                                                                    runat="server" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label for="txtemgc2altphn" class="col-sm-2 col-form-label">
                                                                Alternative Phone Number
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ControlToValidate="txtemgc2altphn"
                                                                    runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true"></asp:RegularExpressionValidator></label>
                                                            <div class=" col-sm-10">
                                                                <asp:TextBox class="form-control text-blue" ID="txtemgc2altphn" placeholder="10 digit Mobile No."
                                                                    runat="server" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Sibling Information</h5>
                                        </div>
                                        <table class="table-borderless">
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle; width: 500px;">
                                                    <asp:Label ID="Label49" runat="server" Text="Does the student have any brothers or sisters at this school?"
                                                        AssociatedControlID="chkbxsibling"></asp:Label>
                                                </td>
                                                <td style="height: 20px; vertical-align: middle;">
                                                    <div class="form-control border-0">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxsibling" runat="server"
                                                                clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                    for="chkbxsibling" id="lblchkbxsibling" runat="server"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divsibling" runat="server" visible="False">
                                            <div class="row">
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label50" runat="server" class="col-sm-4 col-form-label" Text="Name"
                                                            AssociatedControlID="txtsibling1name"></asp:Label>
                                                        <div class=" col-sm-8">
                                                            <asp:TextBox class="form-control text-blue" ID="txtsibling1name" placeholder="Sibling Name"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label51" runat="server" class="col-sm-4 col-form-label" Text="D.O.B."
                                                            AssociatedControlID="txtsibling1dob"></asp:Label>
                                                        <div class=" col-sm-8">
                                                            <asp:TextBox class="form-control text-blue" ID="txtsibling1dob" placeholder="DOB"
                                                                runat="server"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtsibling1dob"
                                                                Format="yyyy-MM-dd" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label52" runat="server" class="col-sm-4 col-form-label" Text="Name"
                                                            AssociatedControlID="txtsibling2name"></asp:Label>
                                                        <div class=" col-sm-8">
                                                            <asp:TextBox class="form-control text-blue" ID="txtsibling2name" placeholder="Sibling Name"
                                                                runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-6">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label53" runat="server" class="col-sm-4 col-form-label" Text="DOB"
                                                            AssociatedControlID="txtsibling2dob"></asp:Label>
                                                        <div class=" col-sm-8">
                                                            <asp:TextBox class="form-control text-blue" ID="txtsibling2dob" placeholder="DOB"
                                                                runat="server"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtsibling2dob"
                                                                Format="yyyy-MM-dd" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Medical Details and Consent</h5>
                                        </div>
                                        <table class="table-borderless">
                                            <tr>
                                                <td style="height: 20px; vertical-align: middle; width: 500px;">
                                                    <asp:Label ID="Label12" runat="server" Text="Does student suffer from any medical condition?"
                                                        AssociatedControlID="chkbxmedinfo"></asp:Label>
                                                </td>
                                                <td style="height: 20px; vertical-align: middle;">
                                                    <div class="form-control border-0">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxmedinfo" runat="server"
                                                                clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                    for="chkbxmedinfo" id="lblchkbxmedinfo" runat="server"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="divmedinfo" runat="server" visible="false">
                                            <table class="table table-avatar table-responsive-sm mobile">
                                                <tr>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedallergy" runat="server"
                                                                    clientidmode="Static"><label class="custom-control-label text-blue text-sm" for="chkbxmedallergy">Allergies</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedasthma" runat="server"
                                                                    clientidmode="Static"><label class="custom-control-label text-blue text-sm" for="chkbxmedasthma">Asthma</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmeddiab" runat="server"
                                                                    clientidmode="Static"><label class="custom-control-label text-blue text-sm" for="chkbxmeddiab">Diabetes</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedseidis" runat="server"
                                                                    clientidmode="Static"><label class="custom-control-label text-blue text-sm" for="chkbxmedseidis">Seizure
                                                                        disorder (e.g. epilepsy)</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedhearim" runat="server"
                                                                    clientidmode="Static"><label class="custom-control-label text-blue text-sm" for="chkbxmedhearim">Hearing
                                                                        impairment</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedphydis" runat="server"
                                                                    clientidmode="Static"><label class="custom-control-label text-blue text-sm" for="chkbxmedphydis">Physical
                                                                        disability</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedspch" runat="server"
                                                                    clientidmode="Static" /><label class="custom-control-label text-blue text-sm" for="chkbxmedspch">Speech
                                                                        impairment</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedvisual" runat="server"
                                                                    clientidmode="Static" /><label class="custom-control-label text-blue text-sm" for="chkbxmedvisual">Visual
                                                                        impairment</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedintel" runat="server"
                                                                    clientidmode="Static"><label class="custom-control-label text-blue text-sm" for="chkbxmedintel">Intellectual/learning
                                                                        impairment (e.g. dyslexia)</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedaqbrain" runat="server"
                                                                    clientidmode="Static" /><label class="custom-control-label text-blue text-sm" for="chkbxmedaqbrain">Acquired
                                                                        brain impairment</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td colspan="2">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedbehave" runat="server"
                                                                    clientidmode="Static" /><label class="custom-control-label text-blue text-sm" for="chkbxmedbehave">Mental
                                                                        health or behaviour issue (e.g. depression, ADHD)</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxmedother" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue text-sm"
                                                                        for="chkbxmedother">Other, please specify</label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox class="form-control text-blue" ID="txtmedother" placeholder="Other medical condition"
                                                            runat="server" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <p>
                                                If you have ticked any of the boxes above please provide further information. Also
                                                provide details if the student has any special needs or requires support in school
                                                (including details of previous special needs assessments undertaken by a school
                                                etc).</p>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label54" runat="server" class="col-sm-2 col-form-label" Text="Description"
                                                            AssociatedControlID="txtmeddesc"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtmeddesc" runat="server" placeholder="Meidcal issue related description"
                                                                TextMode="MultiLine" Rows="2" Style="resize: none"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Additional Consents</h5>
                                        </div>
                                        <table class="table table-avatar table-responsive-md mobile1">
                                            <thead>
                                                <th>
                                                </th>
                                                <th>
                                                    Use of Student Photograph
                                                </th>
                                                <th>
                                                    Use of Work by Student
                                                </th>
                                                <th>
                                                    Publishing Student Name
                                                </th>
                                            </thead>
                                            <tr>
                                                <td class="text-bold">
                                                    School/College Newsletter
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxnewsletterphoto" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxnewsletterphoto"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxnewsletterwork" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxnewsletterwork"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxnewslettername" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxnewslettername"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-bold">
                                                    School/College Yearbook
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxyearbookphoto" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxyearbookphoto"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxyearbookwork" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxyearbookwork"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxyearbookname" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxyearbookname"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-bold">
                                                    School/College/Department Website
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxwebsitephoto" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxwebsitephoto"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxwebsitework" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxwebsitework"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="form-control border-0 text-center">
                                                        <div class="custom-control custom-switch">
                                                            <input type="checkbox" class="custom-control-input" id="chkbxwebsitename" runat="server"
                                                                clientidmode="Static"><label class="custom-control-label text-blue" for="chkbxwebsitename"></label>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
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
                                <div id="msgctgr" runat="server">
                                </div>
                                <div align="center">
                                    <button type="submit" class="btn btn-primary btn-block text-bold" id="btnsave" runat="server"
                                        validationgroup="entry">
                                        <i class="fas fa-graduation-cap"></i>&nbsp; Add Student
                                    </button>
                                    <button type="submit" class="btn btn-secondary btn-block text-bold" id="btnupdate"
                                        runat="server" visible="False">
                                        <i class="fas fa-edit"></i>&nbsp; Update Student
                                    </button>
                                    <asp:LinkButton ID="btndelete" runat="server" class="btn btn-warning btn-block text-bold"
                                        Visible="False"><i class="fas fa-trash"></i> &nbsp; Delete Student</asp:LinkButton>
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
                                Student Update</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label18" runat="server" class="col-sm-2 col-form-label" Text="Student Name/ID"
                                                AssociatedControlID="txtsearchname"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:TextBox ID="txtsearchname" placeholder="Student Name (ID for Update)" class="form-control"
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
                                            <i class="fas fa-search"></i>&nbsp; Search With Student Name</button>
                                        <button type="Submit" id="btnupdateinfo" class="btn bg-gradient-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Get Information For Update</button>
                                        <button type="Submit" id="btndocument" class="btn bg-gradient-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Download Form</button>
                                    </div>
                                    <br />
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
    <script src="Scripts/myscript/JScript15.js" type="text/javascript"></script>
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
            printWindow.document.write(' <link href="Styles/fontawesome-free/css/all.css" rel="stylesheet" type="text/css" />');

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
</asp:Content>
