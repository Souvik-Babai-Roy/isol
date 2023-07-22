<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Dashboard.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Dashboard</title>
    <style>
        div.NoBorder div:first-child
        {
            border-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="content">
        <div class="container-fluid">
            <h4 class="mb-2">
                Hotel Informations</h4>
            <div class="row">
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-info">
                        <span class="info-box-icon"><i class="fas fa-user-clock"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Expected Arrivals</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="lblhotelarrivals" runat="server" Text=""></asp:Label></span>
                            <div class="box">
                            </div>
                            <span class="" style="font-style: italic">Today's Reservation Arrivals</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-success">
                        <span class="info-box-icon"><i class="fas fa-person-walking-luggage"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Expected Departures</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="lblhotelcheckin" runat="server" Text=""></asp:Label></span> <span
                                    class="" style="font-style: italic">Today's Scheduled Check Out</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-warning">
                        <span class="info-box-icon"><i class="fas fa-person-circle-check"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Today's Check In</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Today's Total Number of Check-in</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-danger">
                        <span class="info-box-icon"><i class="fas fa-person-circle-xmark"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Today's Checked Out</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="lblhotelcheckout" runat="server" Text=""></asp:Label></span>
                            <span class="" style="font-style: italic">Today's Total Number of Check-out</span>
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
            <h4 class="mb-2">
                Restaurant Informations</h4>
            <div class="row">
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-gradient-purple">
                        <span class="info-box-icon"><i class="fas fa-shop-lock"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Today's Reservations</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Number of Today's Reservations</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-lime">
                        <span class="info-box-icon"><i class="fas fa-mug-hot"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Table Served Today</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Total Number of Completed Orders</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-teal">
                        <span class="info-box-icon"><i class="fas fa-drumstick-bite"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Active Tables</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Number of Currently Active Tables</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-maroon">
                        <span class="info-box-icon"><i class="fas fa-chair"></i></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Available Tables</span>
                            <div class="progress">
                                <div class="progress-bar" style="width: 100%">
                                </div>
                            </div>
                            <span class="info-box-number">
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label></span> <span class=""
                                    style="font-style: italic">Total Number of Available Tables</span>
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
                            <div class="d-flex justify-content-between">
                                <h3 class="card-title">
                                    Visitors</h3>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="d-flex">
                                <p class="d-flex flex-column">
                                    <span class="text-bold text-lg">
                                        <asp:Label ID="lbltotalvisitors" runat="server" Text="#visitors"></asp:Label></span>
                                    <span>Visitors Over Time</span>
                                </p>
                                <p class="ml-auto d-flex flex-column text-right">
                                    <label id="lblcomparevistors" runat="server">
                                        <span class="text-success"><i class="fas fa-arrow-up"></i>12.5% </span>
                                        <br />
                                        <span class="text-muted">Since last week</span>
                                    </label>
                                </p>
                            </div>
                            <!-- /.d-flex -->
                            <div class="position-relative mb-4">
                                <ajaxToolkit:LineChart ID="LineChart1" runat="server" ChartWidth="450" ChartHeight="250"
                                    ChartType="Basic" CategoriesAxis="Sun,Mon,Tue,Wed,Thu,Fri,Sat" ChartTitleColor="#0E426C"
                                    CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB"
                                    BorderStyle="None" class="table table-borderless table-condensed table-responsive NoBorder"
                                    TooltipBorderColor="#B85B3E">
                                    <Series>
                                        <ajaxToolkit:LineChartSeries Name="This Week" LineColor="#6C1E83" Data="180, 119, 105, 95, 107, 127,203" />
                                        <ajaxToolkit:LineChartSeries Name="Last Week" LineColor="#D08AD9" Data="185, 102, 118, 83, 96, 101,192" />
                                    </Series>
                                </ajaxToolkit:LineChart>
                            </div>
                        </div>
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col-md-6 -->
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header border-0">
                            <div class="d-flex justify-content-between">
                                <h3 class="card-title">
                                    Sales</h3>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="d-flex">
                                <p class="d-flex flex-column">
                                    <span class="text-bold text-lg">
                                        <asp:Label ID="Label14" runat="server" Text="#sales"></asp:Label></span> <span>Sales
                                            Over Time</span>
                                </p>
                                <p class="ml-auto d-flex flex-column text-right">
                                    <label id="Label15" runat="server">
                                        <span class="text-success"><i class="fas fa-arrow-up"></i>12.5% </span>
                                        <br />
                                        <span class="text-muted">Since last month</span>
                                    </label>
                                </p>
                            </div>
                            <!-- /.d-flex -->
                            <div class="position-relative mb-4">
                                <ajaxToolkit:BarChart ID="BarChart1" runat="server" ChartHeight="250" ChartWidth="450"
                                    ChartType="Column" ChartTitle="" CategoriesAxis="Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec"
                                    ChartTitleColor="#0E426C" CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9"
                                    BaseLineColor="#A156AB" class="table table-borderless table-condensed table-responsive NoBorder">
                                    <Series>
                                        <ajaxToolkit:BarChartSeries Name="This year" BarColor="#6C1E83" Data="110, 189, 455, 95, 107, 140,110, 189, 255, 95, 107, 140" />
                                        <ajaxToolkit:BarChartSeries Name="Last year" BarColor="#D08AD9" Data="49, 77, 95, 68, 70, 79,49, 77, 95, 68, 70, 79" />
                                    </Series>
                                </ajaxToolkit:BarChart>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.col-md-6 -->
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
            <div class="row">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header" style="background-color: #0000FF; color: White;">
                            <div class="card-title">
                                Browser Usage</div>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                                <button type="button" class="btn btn-tool" data-card-widget="remove">
                                    <i class="fas fa-times"></i>
                                </button>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="chart-responsive">
                                        <img src="img/title_logo.png" style="max-width: 100px; max-height: 100px;" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit.
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer p-0">
                            <ul class="nav nav-pills flex-column">
                                <li class="nav-item"><a href="" class="nav-link">United States of America <span class="float-right text-danger">
                                    <i class="fas fa-arrow-down text-sm"></i>12%</span> </a></li>
                                <li class="nav-item"><a href="" class="nav-link">India <span class="float-right text-success">
                                    <i class="fas fa-arrow-up text-sm"></i>4% </span></a></li>
                                <li class="nav-item"><a href="" class="nav-link">China <span class="float-right text-warning">
                                    <i class="fas fa-arrow-left text-sm"></i>0% </span></a></li>
                            </ul>
                        </div>
                        <!-- /.footer -->
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header" style="background-color: #0000FF; color: White;">
                            <div class="card-title">
                                Browser Usage</div>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                                <button type="button" class="btn btn-tool" data-card-widget="remove">
                                    <i class="fas fa-times"></i>
                                </button>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="chart-responsive">
                                        Content
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    Lorem ipsum
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer p-0">
                            <ul class="nav nav-pills flex-column">
                                <li class="nav-item"><a href="" class="nav-link">United States of America <span class="float-right text-danger">
                                    <i class="fas fa-arrow-down text-sm"></i>...</span> </a></li>
                                <li class="nav-item"><a href="" class="nav-link">India <span class="float-right text-success">
                                    <i class="fas fa-arrow-up text-sm"></i>...</span></a></li>
                                <li class="nav-item"><a href="" class="nav-link">China <span class="float-right text-warning">
                                    <i class="fas fa-arrow-left text-sm"></i>...</span></a></li>
                            </ul>
                        </div>
                        <!-- /.footer -->
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header border-0" style="background-color: indigo; color: White;">
                    <h3 class="card-title">
                        Quick Reports</h3>
                    <div class="card-tools">
                        <span><i class="fas fa-file-alt"></i></span>
                    </div>
                </div>
                <div class="card-body table-responsive p-0">
                    <table class="table table-striped table-valign-middle">
                        <tbody>
                            <tr>
                                <td width="10%" align="center">
                                    <span class="bootstrap-switch-info bg-transparent text-bold"><span class="text-muted">
                                        <i class="fas fa-search"></i></span></span>
                                </td>
                                <td>
                                    Some Product
                                </td>
                            </tr>
                            <tr>
                                <td width="10%" align="center">
                                    <%--<a href="#" class="text-muted"><i class="fas fa-download"></i>
                                                    </a>--%>
                                    <button type="Submit" id="btnupdateinfo" class="btn btn-danger bg-transparent text-bold"
                                        runat="server">
                                        <a class="text-muted"><i class="fas fa-download"></i></a>
                                    </button>
                                </td>
                                <td>
                                    Another Product
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-sm-12">
                    <div class="card card-indigo card-tabs">
                        <div class="card-header p-0 pt-1" style="background-color: blue; color: White;">
                            <ul class="nav nav-tabs" id="custom-tabs-one-tab" role="tablist">
                                <li class="nav-item"><a class="nav-link active" id="custom-tabs-one-home-tab" data-toggle="pill"
                                    href="#custom-tabs-one-home" role="tab" aria-controls="custom-tabs-one-home"
                                    aria-selected="true">Home</a> </li>
                                <li class="nav-item"><a class="nav-link" id="custom-tabs-one-profile-tab" data-toggle="pill"
                                    href="#custom-tabs-one-profile" role="tab" aria-controls="custom-tabs-one-profile"
                                    aria-selected="false">Profile</a> </li>
                                <li class="nav-item"><a class="nav-link" id="custom-tabs-one-messages-tab" data-toggle="pill"
                                    href="#custom-tabs-one-messages" role="tab" aria-controls="custom-tabs-one-messages"
                                    aria-selected="false">Messages</a> </li>
                                <li class="nav-item"><a class="nav-link" id="custom-tabs-one-settings-tab" data-toggle="pill"
                                    href="#custom-tabs-one-setting" role="tab" aria-controls="custom-tabs-one-settings"
                                    aria-selected="false">Settings</a> </li>
                            </ul>
                        </div>
                        <div class="card-body">
                            <div class="tab-content" id="custom-tabs-one-tabContent">
                                <div class="tab-pane fade show active" id="custom-tabs-one-home" role="tabpanel"
                                    aria-labelledby="custom-tabs-one-home-tab">
                                    <asp:Label ID="Label10" runat="server" Text="Content: Tab1"></asp:Label>
                                </div>
                                <div class="tab-pane fade" id="custom-tabs-one-profile" role="tabpanel" aria-labelledby="custom-tabs-one-profile-tab">
                                    <asp:Label ID="Label11" runat="server" Text="Content: Tab2"></asp:Label>
                                </div>
                                <div class="tab-pane fade" id="custom-tabs-one-messages" role="tabpanel" aria-labelledby="custom-tabs-one-messages-tab">
                                    <asp:Label ID="Label12" runat="server" Text="Content: Tab3"></asp:Label>
                                </div>
                                <div class="tab-pane fade" id="custom-tabs-one-setting" role="tabpanel" aria-labelledby="custom-tabs-one-settings-tab">
                                    <asp:Label ID="Label13" runat="server" Text="Content: Tab4"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <!-- /.card -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/myscript/JScript15.js" type="text/javascript"></script>
</asp:Content>
