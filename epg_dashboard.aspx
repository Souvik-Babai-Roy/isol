<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="epg_dashboard.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="content">
        <div class="container-fluid">
            <h4 class="mb-2">
                EPG Informations</h4>
            <div class="row">
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-info">
                        <span class="info-box-icon"><i class="fas fa-photo-film"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Total Channels</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number text-xl">
                                <asp:Label ID="lbltotalchannel" runat="server" Text=""></asp:Label></span>
                            <div class="box">
                            </div>
                            <span class="" style="font-style: italic">Total Number of Channels</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-success">
                        <span class="info-box-icon"><i class="fas fa-film"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Channel Genere</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number text-xl">
                                <asp:Label ID="lblgenere" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Total Number of Generes</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-warning">
                        <span class="info-box-icon"><i class="fas fa-list-check"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Today's List Entry</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number text-xl">
                                <asp:Label ID="lblentry" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Total Number of Slots Entered</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-danger">
                        <span class="info-box-icon"><i class="fas fa-list-ul"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Today's Slots Left</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number text-xl">
                                <asp:Label ID="lblslotleft" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Total Number of Slots left</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-indigo">
                        <span class="info-box-icon"><i class="fas fa-people-roof"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Inhouse Rooms</span><div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Number of Active Rooms</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-blue">
                        <span class="info-box-icon"><i class="fas fa-house-flag"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Rooms to Sell</span><div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Number of Available Rooms</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-lightblue">
                        <span class="info-box-icon"><i class="fas fa-house-circle-exclamation"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Reserved Rooms</span><div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Number of Reserved Rooms</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-fuchsia">
                        <span class="info-box-icon"><i class="fas fa-house-lock"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Blocked Rooms</span><div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Number of Blocked Rooms</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header border-0">
                            <h3 class="card-title">
                                Most Demanding Products</h3>
                        </div>
                        <div class="card-body table-responsive p-0">
                            <table class="table table-striped table-valign-middle">
                                <thead>
                                    <tr>
                                        <th>
                                            Product
                                        </th>
                                        <th>
                                            Price
                                        </th>
                                        <th>
                                            Sales
                                        </th>
                                        <th>
                                            Units
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <img src="img/icore.png" alt="" class="img-circle img-size-32 mr-2">
                                            Some Product
                                        </td>
                                        <td>
                                            $13 USD
                                        </td>
                                        <td>
                                            <small class="text-success mr-1"><i class="fas fa-arrow-up"></i>12%
                                        </td>
                                        <td>
                                            <small>123,234 Sold</small>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="img/icore.png" alt="" class="img-circle img-size-32 mr-2">
                                            Another Product
                                        </td>
                                        <td>
                                            $29 USD
                                        </td>
                                        <td>
                                            <span class="text-warning mr-1"><i class="fas fa-arrow-down"></i>0.5% </span>
                                        </td>
                                        <td>
                                            <small>123,234 Sold</small>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="img/icore.png" alt="" class="img-circle img-size-32 mr-2">
                                            Amazing Product
                                        </td>
                                        <td>
                                            $1,230 USD
                                        </td>
                                        <td>
                                            <small class="text-danger mr-1"><i class="fas fa-arrow-down"></i>3% </small>
                                        </td>
                                        <td>
                                            <small>123,234 Sold</small>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="img/icore.png" alt="" class="img-circle img-size-32 mr-2">
                                            Amazing Product
                                        </td>
                                        <td>
                                            $1,230 USD
                                        </td>
                                        <td>
                                            <small class="text-danger mr-1"><i class="fas fa-arrow-down"></i>3% </small>
                                        </td>
                                        <td>
                                            <small>123,234 Sold</small>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col-md-6 -->
                <div class="col-lg-6">
                    <!-- /.card -->
                    <div class="card">
                        <div class="card-header border-0">
                            <h3 class="card-title">
                                Data Analysis</h3>
                        </div>
                        <div class="card-body">
                            <div class="d-flex justify-content-between align-items-center border-bottom mb-2">
                                <p class="text-success">
                                    <i class="fas fa-building-user text-xl"></i>&emsp;<span class="">HOTEL CHECK-IN RATE</span>
                                </p>
                                <p class="d-flex flex-column text-right">
                                    <span class="font-weight-bold"><i class="fas fa-arrow-alt-circle-up text-success"></i>
                                        12% </span><span class="text-muted text-sm">OVER LAST WEEK</span>
                                </p>
                            </div>
                            <!-- /.d-flex -->
                            <div class="d-flex justify-content-between align-items-center border-bottom mb-2">
                                <p class="text-danger">
                                    <i class="fas fa-code-compare text-xl"></i>&emsp;<span class="">TABLE TURNOVER RATE</span>
                                </p>
                                <p class="d-flex flex-column text-right">
                                    <span class="font-weight-bold"><i class="fas fa-arrow-alt-circle-down text-danger"></i>
                                        1% </span><span class="text-muted text-sm">OVER LAST WEEK</span>
                                </p>
                            </div>
                            <!-- /.d-flex -->
                            <div class="d-flex justify-content-between align-items-center mb-1">
                                <p class="text-warning">
                                    <i class="fas fa-shopping-cart text-xl"></i>&emsp;<span class="">OVERALL SALES RATE</span>
                                </p>
                                <p class="d-flex flex-column text-right">
                                    <span class="font-weight-bold"><i class="fas fa-arrow-alt-circle-up text-warning"></i>
                                        0.8% </span><span class="text-muted text-sm">OVER LAST WEEK</span>
                                </p>
                            </div>
                            <!-- /.d-flex -->
                        </div>
                    </div>
                </div>
                <!-- /.col-md-6 -->
            </div>
        </div>
    </div>
</asp:Content>
