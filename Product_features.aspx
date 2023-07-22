<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Product_features.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Product Features</title>
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
                                Products Entry</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Product Details</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label23" runat="server" class="col-sm-2 col-form-label" Text="Product Category"
                                                        AssociatedControlID="ddlcategory"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlcategory" runat="server" class="form-control text-blue text-uppercase"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="ddlproduct" class="col-sm-2 col-form-label">
                                                        Product Name
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlproduct" runat="server" class="form-control text-blue text-uppercase"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <label id="lblid" runat="server"></label>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divfeature" runat="server" visible="false">
                                            <br />
                                            <div class="border-bottom mb-2">
                                                <h5>
                                                    Features</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="ddlftrgrp" class="col-sm-2 col-form-label">
                                                            Feature Group
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlftrgrp" runat="server" class="form-control text-blue text-uppercase"
                                                                AutoPostBack="True">
                                                                <asp:ListItem>Highlight Feature</asp:ListItem>
                                                                <asp:ListItem>Additional Information</asp:ListItem>
                                                                <asp:ListItem>Technical Details</asp:ListItem>
                                                                <asp:ListItem>Offer</asp:ListItem>
                                                                <asp:ListItem>Other Feature</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtftrname" class="col-sm-2 col-form-label">
                                                            Feature Name
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtftrname" runat="server" placeholder="Feature Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtdesc" class="col-sm-2 col-form-label">
                                                            Description
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtdesc" runat="server" placeholder="Feature Description"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row" id="divstatus" runat="server" visible="false">
                                                        <asp:Label ID="Label19" runat="server" class="col-sm-2 col-form-label" Text="Status"
                                                            AssociatedControlID="ddlstatus"></asp:Label>
                                                        <div class=" col-sm-10">
                                                            <asp:DropDownList ID="ddlstatus" runat="server" class="form-control text-blue">
                                                                <asp:ListItem>Active</asp:ListItem>
                                                                <asp:ListItem>Deactive</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="center">
                                                <button type="submit" class="btn btn-warning btn-group-sm text-bold" id="btnadd"
                                                    runat="server">
                                                    <i class="fas fa-cart-plus"></i>&nbsp; Add Features
                                                </button>
                                            </div>
                                            <div class="post clearfix">
                                            </div>
                                            <div class="box" align="center">
                                                <div class="row">
                                                    <div class="col-12 table-responsive">
                                                        <asp:GridView ID="tblftr" runat="server" class="table table-striped" GridLines="None"
                                                            AutoGenerateDeleteButton="True">
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="post clearfix">
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="msgct1" runat="server">
                                </div>
                                <div align="center">
                                    <button type="submit" class="btn btn-primary btn-block text-bold" id="btnsave" runat="server"
                                        validationgroup="entry">
                                        <i class="fas fa-plus-square"></i>&nbsp; Save Product Features
                                    </button>
                                    <button type="submit" class="btn btn-secondary btn-block text-bold" id="btnupdate"
                                        runat="server" visible="False">
                                        <i class="fas fa-edit"></i>&nbsp; Update Product
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
                                Product Update</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label18" runat="server" class="col-sm-2 col-form-label" Text="Product Name/ID"
                                                AssociatedControlID="txtsearchname"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:TextBox ID="txtsearchname" placeholder="Product Name (ID for Update)" class="form-control"
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
                                            <i class="fas fa-search"></i>&nbsp; Search With Product Name</button>
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
