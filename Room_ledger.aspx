<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Room_ledger.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Room Entry</title>
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
                content: "ledger_id: ";
                font-weight: bold;
            }
            .mobile td:nth-child(2)::before
            {
                content: "ledger_type: ";
                font-weight: bold;
            }
            .mobile td:nth-child(3)::before
            {
                content: "primary_type: ";
                font-weight: bold;
            }
            .mobile td:nth-child(4)::before
            {
                content: "room_no: ";
                font-weight: bold;
            }
            .mobile td:nth-child(5)::before
            {
                content: "category: ";
                font-weight: bold;
            }
            .mobile td:nth-child(6)::before
            {
                content: "room_type: ";
                font-weight: bold;
            }
            .mobile td:nth-child(7)::before
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
                        <div class="card-header" style="background-color: #5777ba; color: White;">
                            <h3 class="card-title">
                                Room Entry</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label1" runat="server" class="col-sm-2 col-form-label" Text="Building Name/No."
                                                        AssociatedControlID="txtbuilding"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtbuilding" runat="server" placeholder="Building Name/Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label2" runat="server" class="col-sm-2 col-form-label" Text="Floor No."
                                                        AssociatedControlID="txtfloor"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtfloor" runat="server" placeholder="Floor Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtledname" class="col-sm-2 col-form-label">
                                                        Room No.
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtledname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtledname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Room No." ValidationGroup="entry" AutoPostBack="True"></asp:TextBox>
                                                        <div id="valmsg" runat="server">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divroom" runat="server">
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h5>
                                                    Room Information</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label22" runat="server" class="col-sm-2 col-form-label" Text="Room Category"
                                                            AssociatedControlID="txtroomcategory"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue " ID="txtroomcategory" runat="server"
                                                                placeholder="Room Category / Description"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <asp:Label ID="Label16" runat="server" class="col-sm-2 col-form-label" Text="Room Type"
                                                            AssociatedControlID="ddlroomtype"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlroomtype" runat="server" class="form-control text-blue text-uppercase">
                                                            </asp:DropDownList>
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
                                        <i class="fas fa-person-shelter"></i>&nbsp; Add Room
                                    </button>
                                    <button type="submit" class="btn btn-secondary btn-block text-bold" id="btnupdate"
                                        runat="server" visible="False">
                                        <i class="fas fa-edit"></i>&nbsp; Update Room
                                    </button>
                                    <asp:LinkButton ID="btndelete" runat="server" class="btn btn-warning btn-block text-bold"
                                        Visible="False"><i class="fas fa-trash"></i> &nbsp; Delete Room</asp:LinkButton>
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
                                Room Update</h3>
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
                                            <i class="fas fa-search"></i>&nbsp; Search With Room No.</button>
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
