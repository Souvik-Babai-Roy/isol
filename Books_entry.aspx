<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Books_entry.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Books Entry</title>
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
                                Books Entry</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtbookname" class="col-sm-2 col-form-label">
                                                        Book Name
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtbookname" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Book Name" ValidationGroup="entry" AutoPostBack="True"></asp:TextBox>
                                                        <div id="valmsg" runat="server">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtauthor" class="col-sm-2 col-form-label">
                                                        Author
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue text-uppercase" ID="txtauthor" runat="server"
                                                            placeholder="AUthor Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtpublisher" class="col-sm-2 col-form-label">
                                                        Publisher
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue text-uppercase" ID="txtpublisher" runat="server"
                                                            placeholder="Publisher Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtedition" class="col-sm-2 col-form-label">
                                                        Edition No.
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue  text-uppercase" ID="txtedition" runat="server"
                                                            placeholder="Edition Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtprice" class="col-sm-2 col-form-label">
                                                       Purchase Price
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtprice" runat="server" placeholder="Price (Amount Only)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtpurdate" class="col-sm-2 col-form-label">
                                                        Purchase Date
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtpurdate" runat="server" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtpurdate"
                                                            Format="yyyy-MM-dd" />
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
                                                        <asp:TextBox class="form-control text-blue" ID="txtdesc" runat="server" placeholder="Book Description"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtdatepublish" class="col-sm-2 col-form-label">
                                                        Published Date
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtdatepublish" runat="server" placeholder="yyyy-mm-dd"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatepublish"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="ddlbooktype" class="col-sm-2 col-form-label">
                                                        Book Type
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlbooktype" runat="server" class="form-control text-blue text-uppercase">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="ddllang" class="col-sm-2 col-form-label">
                                                        Book Language
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddllang" runat="server" class="form-control text-blue text-uppercase">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtrackno" class="col-sm-2 col-form-label">
                                                        Rack No.
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtrackno" runat="server" placeholder="Rack Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label for="txtroomno" class="col-sm-2 col-form-label">
                                                        Buiding/Room No.
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue" ID="txtroomno" runat="server" placeholder="Buiding/Room No."></asp:TextBox>
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
                                        <i class="fas fa-book"></i>&nbsp; Add Book
                                    </button>
                                    <button type="submit" class="btn btn-secondary btn-block text-bold" id="btnupdate"
                                        runat="server" visible="False">
                                        <i class="fas fa-edit"></i>&nbsp; Update Book
                                    </button>
                                    <asp:LinkButton ID="btndelete" runat="server" class="btn btn-warning btn-block text-bold"
                                        Visible="False"><i class="fas fa-trash"></i> &nbsp; Delete Book</asp:LinkButton>
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
                                Book Update</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label18" runat="server" class="col-sm-2 col-form-label" Text="Book Name/ID"
                                                AssociatedControlID="txtsearchname"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:TextBox ID="txtsearchname" placeholder="Book Name (ID for Update)" class="form-control"
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
                                            <i class="fas fa-search"></i>&nbsp; Search With Book Name</button>
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
