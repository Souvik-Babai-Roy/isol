<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="epg_schedule.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>EPG Schedule</title>
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
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
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
                                                        <asp:DropDownList ID="ddlchname" runat="server" class="form-control text-blue">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label2" runat="server" class="col-sm-2 col-form-label" Text="Schedule Days"
                                                        AssociatedControlID="txtdayno"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtdayno" runat="server" placeholder="No. of days"
                                                             min="1" Text="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <asp:Label ID="Label3" runat="server" class="col-sm-2 col-form-label" Text="Slot Duration"
                                                        AssociatedControlID="ddlchname"></asp:Label>
                                                    <div class=" col-sm-10">
                                                        <asp:DropDownList ID="ddlduration" runat="server" class="form-control text-blue">
                                                            <asp:ListItem Value="30">30 min</asp:ListItem>
                                                            <asp:ListItem Value="60">1 hour</asp:ListItem>
                                                            <asp:ListItem Value="90">1 hour 30 min</asp:ListItem>
                                                            <asp:ListItem Value="120">2 hour</asp:ListItem>
                                                            <asp:ListItem Value="150">2 hour 30 min</asp:ListItem>
                                                            <asp:ListItem Value="180">3 hour</asp:ListItem>
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
                                    <asp:LinkButton ID="btnblankadd" runat="server" class="btn btn-block text-bold bg-gradient-warning"><i class="fas fa-rectangle-list"></i>&nbsp; Add Blank Schedule for Channel</asp:LinkButton>
                                    <asp:LinkButton ID="btnlock" runat="server" class="btn btn-danger btn-block text-bold"><i class="fas fa-edit"></i>&nbsp; Edit Schedule for Channel</asp:LinkButton>
                                    <%--<asp:LinkButton ID="btnunlock" runat="server" class="btn btn-success btn-block text-bold"><i class="fas fa-unlock"></i>&nbsp; Unblock Channel</asp:LinkButton>--%>
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
                    <div class="card card-info" style="box-shadow: 0 0 10px 3px;">
                        <div class="card-header" style="background-color: #5777ba; color: White;">
                            <h3 class="card-title">
                                Channel Selection</h3>
                        </div>
                        <div class="card-body">
                            <div class="forms-sample">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">
                                                        Select Date
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtstartdate" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtstartdate" runat="server" placeholder="yyyy-mm-dd"
                                                            AutoPostBack="True"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtstartdate"
                                                            Format="yyyy-MM-dd" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">
                                                        Start Time
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtstarttime" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox class="form-control text-blue " ID="txtstarttime" runat="server" placeholder="HH:mm"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-sm-2 col-form-label">
                                                        Duration
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                            SetFocusOnError="true" ControlToValidate="txtduration" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                    <div class=" col-sm-10">
                                                        <asp:TextBox ID="txtduration" runat="server" class="form-control text-blue input-radius"
                                                            placeholder="Duration"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div2" runat="server">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-2 col-form-label">
                                                            Program Name
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                                SetFocusOnError="true" ControlToValidate="txtprgname" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue " ID="txtprgname" runat="server" placeholder="Program Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-2 col-form-label">
                                                            Short Description
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                                SetFocusOnError="true" ControlToValidate="txtshtdesc" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue " ID="txtshtdesc" runat="server" placeholder="Program Description"
                                                                TextMode="MultiLine" Rows="2" Style="resize: none;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-sm-2 col-form-label">
                                                            Extended Description
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                                SetFocusOnError="true" ControlToValidate="txtdesc" ValidationGroup="entry"></asp:RequiredFieldValidator></label>
                                                        <div class=" col-sm-10">
                                                            <asp:TextBox class="form-control text-blue " ID="txtdesc" runat="server" placeholder="Program Description"
                                                                TextMode="MultiLine" Rows="2" Style="resize: none;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <br />
                                        <div id="msgct2" runat="server">
                                        </div>
                                        <%-- <div align="center">
                                            <asp:LinkButton ID="btnadd" class="btn btn-warning btn-group-sm text-bold" runat="server"
                                                ValidationGroup="entry"><i class="fas fa-cart-plus"></i>&nbsp; Edit Blank Schedule</asp:LinkButton>
                                        </div>--%>
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
                                                            <asp:CommandField HeaderText="Action" ShowDeleteButton="True" ShowEditButton="True" />
                                                            <asp:TemplateField HeaderText="Time Description">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="tstart" runat="server" Text='<%# Eval("start_time")%>' Width="150px"
                                                                        class="form-control text-blue "></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="tduration" runat="server" Text='<%# Eval("duration")%>' Width="150px"
                                                                        class="form-control text-blue "></asp:TextBox>
                                                                    <br />
                                                                    <asp:Label ID="lend" runat="server" Text='<%# Eval("end_time")%>' Width="150px" class="col-form-label text-blue "></asp:Label>
                                                                </EditItemTemplate>
                                                                <ControlStyle Width="250px" />
                                                                <ItemTemplate>
                                                                    <b>
                                                                        <%# Eval("start_time")%></b>
                                                                    <hr />
                                                                    <%# Eval("duration")%><br />
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
                                                                    <asp:TextBox ID="et2" class="form-control text-blue " runat="server" Text='<%# Eval("event_short_desc")%>'
                                                                        Width="400px" MaxLength="60"></asp:TextBox>
                                                                    <br />
                                                                    <asp:TextBox ID="et3" class="form-control text-blue " runat="server" Text='<%# eval("event_description") %>'
                                                                        TextMode="MultiLine" Rows="2" Width="400px"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ControlStyle Width="500px" />
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <b>
                                                                            <asp:Label ID="lbl1" runat="server" Text=' <%# eval("eventname") %>' Width="400px"></asp:Label></b>
                                                                        <hr />
                                                                        <asp:Label ID="lbl2" runat="server" Text='<%# Eval("event_short_desc")%>' Width="400px"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="lbl3" runat="server" Text='<%# eval("event_description") %>' Width="400px"
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
                                <%--<div align="center">
                                    <button type="submit" class="btn btn-primary btn-block text-bold" id="Button1" runat="server"
                                        validationgroup="entry">
                                        <i class="fas fa-person-shelter"></i>&nbsp; Add Room
                                    </button>
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
</asp:Content>
