<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="About_Me.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <section class="content">
    <div class="container-fluid">
    <div class="row">
        <div class="col-md-3">

        <!-- Profile Image -->
        <div class="card card-primary card-outline">
            <div class="card-body box-profile">
            <div class="text-center">
                <img class="profile-user-img img-fluid img-circle"
                    src="img/user-profile-icon.png"
                    alt="User profile picture">
            </div>
            <h3 class="profile-username text-center"><asp:Label ID="lblusername" runat="server" Text=""></asp:Label></h3>

            <p class="text-muted text-center"><asp:Label ID="lblusertype" runat="server" Text=""></asp:Label></p>
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->

        <!-- About Me Box -->
        <div class="card card-primary">
            <div class="card-header">
            <h3 class="card-title">About Me</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
            <strong><i class="fas fa-phone mr-1"></i> Phone Number &nbsp;<asp:LinkButton ID="btnediphn" runat="server"><i class="far fa-pen-to-square" ></i></asp:LinkButton></strong>
            <p class="text-muted"><asp:Label ID="lblphn" runat="server" Text=""></asp:Label></p>
            <hr />
            <strong><i class="fas fa-envelope mr-1"></i> Email &nbsp; <asp:LinkButton ID="btneditmail" runat="server"><i class="far fa-pen-to-square"></i></asp:LinkButton></strong>
            <p class="text-muted"><asp:Label ID="lblmail" runat="server" Text=""></asp:Label></p>               
            <hr />
            <strong><i class="fas fa-user-secret mr-1"></i> Username &nbsp; <asp:LinkButton ID="btnedituid" runat="server"><i class="far fa-pen-to-square"></i></asp:LinkButton></strong>
            <p class="text-muted"><asp:Label ID="lbluid" runat="server" Text=""></asp:Label></p>
            <hr />
            <%--<strong><i class="fas fa-key mr-1"></i> Password</strong>
            <p class="text-muted"></p>--%>
            <%--<a href="#" class="btn btn-primary btn-block"><b>Edit Login Info</b></a>--%>
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->
        </div>
        <!-- /.col -->
        <div class="col-md-9">
        <div class="card">
            <div class="card-header p-2">
            Update Basic Information
            </div><!-- /.card-header -->
            <div class="card-body">
                <div class="form-horizontal">                      
                    <div class="form-group row">
                    <label for="txtphnno" class="col-sm-2 col-form-label">Phone No. <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtphnno"
                                                        runat="server" ErrorMessage="*" ValidationExpression="[0-9]{10}" SetFocusOnError="true" ValidationGroup="info"></asp:RegularExpressionValidator></label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control text-blue" ID="txtphnno" placeholder="Phone Number"
                                                        runat="server"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <label for="txtmail" class="col-sm-2 col-form-label">Email  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"
                                                        ControlToValidate="txtmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        SetFocusOnError="true" ValidationGroup="info"></asp:RegularExpressionValidator></label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control text-blue" ID="txtmail" placeholder="user@company.com"
                                                        runat="server"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <div id="msgct1" runat="server">
                                </div>
                    <div class="offset-sm-2 col-sm-10 text-center">
                        <asp:Button runat="server" Text="Update Information" id="btnupdateinfo" class="btn btn-danger" ValidationGroup="info"></asp:Button>
                    </div>
                    </div>
                </div>
                </div>               
               
            <!-- /.tab-content -->
            </div><!-- /.card-body -->
           
        <!-- /.card -->
        <div class="card">
            <div class="card-header p-2">
            Update Login Information
            </div><!-- /.card-header -->
            <div class="card-body">            
            <div class="form-horizontal">
                    <div class="form-group row">
                    <label for="txtuserid" class="col-sm-3 col-form-label">Username</label>
                    <div class="col-sm-9">
                        <asp:TextBox class="form-control text-blue" ID="txtuserid" placeholder="login Username"
                                                        runat="server"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <label for="txtoldpswd" class="col-sm-3 col-form-label">Old Password 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtoldpswd" SetFocusOnError="true" ValidationGroup="password"></asp:RequiredFieldValidator>
                    </label>
                    <div class="col-sm-9">
                        <asp:TextBox class="form-control text-blue" ID="txtoldpswd" placeholder="Old Password"
                                                        runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    </div>  
                    <div class="form-group row">
                    <label for="inputSkills" class="col-sm-3 col-form-label">New Password
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtnewpswd" SetFocusOnError="true" ValidationGroup="password"></asp:RequiredFieldValidator>

                    </label>
                    <div class="col-sm-9">
                        <asp:TextBox class="form-control text-blue" ID="txtnewpswd" placeholder="New Password"
                                                        runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    </div>
                    <div class="form-group row">
                    <label for="inputSkills" class="col-sm-3 col-form-label">Retype Password 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtrenewpswd" SetFocusOnError="true" ValidationGroup="password"></asp:RequiredFieldValidator>
                       
                    </label>
                    <div class="col-sm-9">
                        <asp:TextBox class="form-control text-blue" ID="txtrenewpswd" placeholder="Retype New Password"
                                                        runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtrenewpswd" CssClass="ValidationError" ControlToCompare="txtnewpswd" ErrorMessage="No Match" ToolTip="Password must be the same" ValidationGroup="password"/>
                    </div>
                    </div>                     
                    <div class="form-group row ">
                    <div id="msgct2" runat="server">
                                    </div>
                    <div class="offset-sm-2 col-sm-10 text-center">
                        <asp:Button runat="server" Text="Update Password" id="btnupdatelogin" class="btn btn-danger" ValidationGroup="password"></asp:Button>
                          
                    </div>
                    </div>
                </div>                  
            </div><!-- /.card-body -->
        </div>
             
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
    </div><!-- /.container-fluid -->
</section>
    <script src="Scripts/myscript/JScript15.js" type="text/javascript"></script>
</asp:Content>
