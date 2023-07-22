<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Product_entry.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Product Entry</title>
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
                                                        <asp:DropDownList ID="ddlcategory" runat="server" ClientIDMode="Static" class="form-control text-blue text-uppercase">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtledname" class="col-sm-2 col-form-label">
                                                        Product Name
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtpdctname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Product Name" ValidationGroup="entry" AutoPostBack="True"></asp:TextBox>
                                                        <div id="valmsg" runat="server">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtbrand" class="col-sm-2 col-form-label">
                                                        Brand
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue text-uppercase" ID="txtbrand" runat="server"
                                                            placeholder="Brand Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtmanufacturer" class="col-sm-2 col-form-label">
                                                        Manufacturer
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue text-uppercase" ID="txtmanufacturer" runat="server"
                                                            placeholder="Manufacturer Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtmodelno" class="col-sm-2 col-form-label">
                                                        Model No.
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue  text-uppercase" ID="txtmodelno" runat="server"
                                                            placeholder="Model Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtmodelname" class="col-sm-2 col-form-label">
                                                        Model Name
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtmodelname" runat="server" placeholder="Model Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtrate" class="col-sm-2 col-form-label">
                                                        Rate
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtrate" runat="server" placeholder="Rate (Amount Only)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtunit" class="col-sm-2 col-form-label">
                                                        Unit
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtunit" runat="server" placeholder="Unit"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txthsn" class="col-sm-2 col-form-label">
                                                        HSN/SAC Code
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txthsn" runat="server" placeholder="HSN/SAC Code"></asp:TextBox>
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
                                                        <asp:TextBox class="form-control text-blue" ID="txtdesc" runat="server" placeholder="Product Description"></asp:TextBox>
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
                                                            Product Differentiators</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxdiff" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxdiff" id="lblchkbxdiff" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divdiff" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtsize" class="col-sm-2 col-form-label">
                                                            Size Varients
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtsize" runat="server" placeholder="example entry: 28,30,32,34"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtcolour" class="col-sm-2 col-form-label">
                                                            Colour Varients
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtcolour" runat="server" placeholder="example entry: Red, Green, Blue"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtcolour" class="col-sm-2 col-form-label">
                                                            Product Material
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtmaterial" runat="server" placeholder="product material"></asp:TextBox>
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
                                                            Product Features</h5>
                                                    </td>
                                                    <td style="height: 20px; vertical-align: middle;">
                                                        <div class="form-control border-0">
                                                            <div class="custom-control custom-switch text-sm">
                                                                <input type="checkbox" class="custom-control-input" id="chkbxfeature" runat="server"
                                                                    clientidmode="Static" onclick="autopostback()" /><label class="custom-control-label text-blue"
                                                                        for="chkbxfeature" id="lblchkbxfeature" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="divfeature" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txthigh" class="col-sm-2 col-form-label">
                                                            Highlight Features
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txthigh" runat="server" placeholder="ex: Feature 1, Feature 2 etc."
                                                                AutoPostBack="False" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txttech" class="col-sm-2 col-form-label">
                                                            Technical Details
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txttech" runat="server" placeholder="ex: Feature name: Description, Feature name: Description"
                                                                AutoPostBack="False" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtadditional" class="col-sm-2 col-form-label">
                                                            Additional Information
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtadditional" runat="server" placeholder="ex: Feature name: Description, Feature name: Description"
                                                                AutoPostBack="False" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtother" class="col-sm-2 col-form-label">
                                                            Other Feature
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtother" runat="server" placeholder="ex: Feature name: Description, Feature name: Description"
                                                                AutoPostBack="False" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label for="txtsize" class="col-sm-2 col-form-label">
                                                            Offers
                                                        </label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue" ID="txtoffer" runat="server" placeholder="ex: Offer 1, Offer 2 etc"
                                                                AutoPostBack="False" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="border-bottom mb-2">
                                            <h5>
                                                Others Features</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="ddlrating" class="col-sm-2 col-form-label">
                                                        Ratings
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlrating" runat="server" class="form-control text-blue">
                                                            <asp:ListItem Value="1">&#10031; Terrible</asp:ListItem>
                                                            <asp:ListItem Value="2">&#10031;&#10031; Bad</asp:ListItem>
                                                            <asp:ListItem Value="3">&#10031;&#10031;&#10031; Ok</asp:ListItem>
                                                            <asp:ListItem Value="4">&#10031;&#10031;&#10031;&#10031; Good</asp:ListItem>
                                                            <asp:ListItem Value="5">&#10031;&#10031;&#10031;&#10031;&#10031; Excellent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtoffer" class="col-sm-2 col-form-label">
                                                        Offers
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtoffer" runat="server" placeholder="Offers"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="border-bottom mb-2">
                                            <h5>
                                                Other Informations</h5>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtdatemanufct" class="col-sm-2 col-form-label">
                                                        Manufacture Date
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtdatemanufct" runat="server" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatemanufct"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtdateexp" class="col-sm-2 col-form-label">
                                                        Expiry Date
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtdateexp" runat="server" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateexp"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                      <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtopenquant" class="col-sm-2 col-form-label">
                                                        Opening Quantity
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtopenquant" runat="server" placeholder="Opening Quantity"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtclosequant" class="col-sm-2 col-form-label">
                                                        Closing Quantity
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtclosequant" runat="server" placeholder="Closing Quantity"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div id="msgct1" runat="server">
                                </div>
                                <div align="center">
                                    <button type="submit" class="btn btn-primary btn-block text-bold" id="btnsave" runat="server"
                                        validationgroup="entry">
                                        <i class="fas fa-plus-square"></i>&nbsp; Add Product
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
    <script type="text/javascript">
        function autopostback() {
            __doPostBack("<%=UpdatePanel1.UniqueID %>", "");
        }
    </script>
</asp:Content>
