<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Expense.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Expense Quotation</title>
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
                                Expense Sheet</h3>
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
                                                    <label for="txtsupplier" class="col-sm-2 col-form-label">
                                                        Supplier Name
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtsupplier" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Supplier Name" ValidationGroup="entry"></asp:TextBox>
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
                                                    <asp:Label ID="Label1" runat="server" class="col-sm-4 col-form-label" Text="Unit Price"
                                                        AssociatedControlID="txtprice"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtprice" placeholder="Price" runat="server"></asp:TextBox>
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
                                                    <asp:Label ID="Label8" runat="server" class="col-sm-4 col-form-label" Text="Total Amount"
                                                        AssociatedControlID="txtamount"></asp:Label>
                                                    <div class=" col-sm-8">
                                                        <asp:TextBox class="form-control text-blue" ID="txtamount" placeholder="Amount" runat="server"></asp:TextBox>
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
                                                            Taxation info</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxtax" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxtax" id="lblchkbxtax" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divtax" runat="server" visible="false">
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
                                                        <asp:Label ID="Label12" runat="server" class="col-sm-4 col-form-label" Text="Service Tax"
                                                            AssociatedControlID="txtservicetax"></asp:Label>
                                                        <div class=" col-sm-8">
                                                            <asp:TextBox class="form-control text-blue" ID="txtservicetax" placeholder="Service Tax percentage (without %)"
                                                                runat="server"></asp:TextBox>
                                                        </div>
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
                                                        AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
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
                                        <i class="fas fa-plus-square"></i>&nbsp; Save Expense
                                    </button>
                                    <button type="submit" class="btn btn-primary btn-block text-bold bg-gradient-secondary"
                                        id="btntemplate" runat="server" validationgroup="entry">
                                        <i class="fas fa-plus-square"></i>&nbsp; Save This Template
                                    </button>
                                    <button type="submit" class="btn btn-warning btn-block text-bold" id="btnupdate"
                                        runat="server" validationgroup="entry" visible="false">
                                        <i class="fas fa-edit"></i>&nbsp; Edit Expense
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
                                            <i class="fas fa-search"></i>&nbsp; Search With Supllier Name</button>
                                        <button type="Submit" id="btngetinfo" class="btn bg-gradient-info btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Get Information</button>
                                        <button type="Submit" id="btngettemp" class="btn bg-gradient-fuchsia btn-block text-bold"
                                            runat="server" validationgroup="update">
                                            <i class="fas fa-info-circle"></i>&nbsp; Get Template</button>
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
    <script type="text/javascript">
        function autopostback() {
            __doPostBack("<%=UpdatePanel1.UniqueID %>", "");
        }
    </script>
</asp:Content>
