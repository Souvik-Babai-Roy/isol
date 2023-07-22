<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="epg_schedule_referrence.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>EPG Schedule Referrence</title>
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
                                Channel Selection</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label4" runat="server" class="col-sm-2 col-form-label" Text="Genere"
                                                AssociatedControlID="ddlgenere"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:DropDownList ID="ddlgenere" runat="server" class="form-control text-blue" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="Label1" runat="server" class="col-sm-2 col-form-label" Text="Channel Name"
                                                AssociatedControlID="ddlchname"></asp:Label>
                                            <div class=" col-sm-10">
                                                <asp:DropDownList ID="ddlchname" runat="server" class="form-control text-blue" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="msgct1" runat="server">
                                </div>
                                <%--<div align="center">
                                    <asp:LinkButton ID="btnlock" runat="server" class="btn btn-danger btn-block text-bold"><i class="fas fa-edit"></i>&nbsp; Edit Schedule for Channel</asp:LinkButton>
                                </div>--%>
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
    <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <!-- Default box -->
                    <div class="card card-info" style="box-shadow: 0 0 10px 3px;">
                        <div class="card-header" style="background-color: #5777ba; color: White;">
                            <h3 class="card-title">
                                Referrence Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">
                                                        Referrence EPG Entry Date
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtstartdate" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtepgdate" runat="server" placeholder="yyyy-mm-dd"
                                                            AutoPostBack="True"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtepgdate"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">
                                                        Referrence Start Date
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtstartdate" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtstartdate" runat="server" placeholder="yyyy-mm-dd"
                                                            AutoPostBack="True"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtstartdate"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">
                                                        Migrate To
                                                    </label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtmigdate" runat="server" placeholder="yyyy-mm-dd"
                                                            AutoPostBack="True"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtmigdate"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label2" runat="server" class="col-sm-2 col-form-label" Text="Migration Options"
                                                        AssociatedControlID="ddlgenere"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlmigoption" runat="server" class="form-control text-blue">
                                                            <asp:ListItem Value="0">Single Channel</asp:ListItem>
                                                            <asp:ListItem Value="1">Complete Genere</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div id="msgct2" runat="server">
                                        </div>
                                        <div align="center">
                                            <asp:LinkButton ID="btnadd" class="btn btn-warning btn-group-sm text-bold" runat="server"
                                                ValidationGroup="entry"><i class="fas fa-cart-plus"></i>&nbsp; Go</asp:LinkButton>
                                        </div>
                                        <div class="post clearfix">
                                        </div>
                                        <div class="post clearfix">
                                        </div>
                                        <div class="box" align="center">
                                            <div class="row">
                                                <div class="col-12 table-responsive">
                                                    <asp:GridView ID="tblepg" runat="server" class="table" GridLines="None" AutoGenerateColumns="False"
                                                        DataKeyNames="id">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                                                <ControlStyle Width="50px" />
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkselect" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Time Description">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="tstart" runat="server" class="form-control text-blue " Text='<%# Eval("start_time")%>'
                                                                        Width="150px"></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="tduration" runat="server" class="form-control text-blue " Text='<%# Eval("duration")%>'
                                                                        Width="150px"></asp:TextBox>
                                                                    <br />
                                                                    <asp:Label ID="lend" runat="server" class="col-form-label text-blue " Text='<%# Eval("end_time")%>'
                                                                        Width="150px"></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <b>
                                                                        <%# Eval("start_time")%></b>
                                                                    <hr />
                                                                    <%# Eval("duration")%>
                                                                    <br />
                                                                    <%# Eval("end_time")%>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="250px" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Program Details" HeaderStyle-HorizontalAlign="Center">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="et1" class="form-control text-blue " runat="server" Text='<%# eval("eventname") %>'
                                                                        Width="400px"></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="et2" class="form-control text-blue " runat="server" Text='<%# Eval("short_desc")%>'
                                                                        Width="400px" MaxLength="60"></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="et3" class="form-control text-blue " runat="server" Text='<%# eval("ext_desc") %>'
                                                                        TextMode="MultiLine" Rows="2" Width="400px"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ControlStyle Width="500px" />
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <b>
                                                                            <asp:Label ID="lbl1" runat="server" Text=' <%# eval("eventname") %>' Width="400px"></asp:Label></b>
                                                                        <hr />
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%# Eval("short_desc")%>' Width="400px"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%# eval("ext_desc") %>' Width="400px"
                                                                            class=" text-blue"></asp:Label>
                                                                    </center>
                                                                </ItemTemplate>
                                                                <ControlStyle Width="500px" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
