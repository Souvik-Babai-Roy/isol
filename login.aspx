<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="Login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>isol: Login</title>
     <link rel="icon" href="img/title_logo.ico" type="image/ico" />
    <link href="Styles/login.css" rel="stylesheet" type="text/css" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Lato:100,300,400,700,900&display=swap"
        rel="stylesheet">
    <style>
* {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
    font-weight: 300;
}
body {
    font-family: 'Lato', sans-serif;
    color: #555555;
    font-weight: 300;
    background-color: white;
    /*    height: 100%;
        background: linear-gradient(90deg, #50a3a2 50%, #FFFFFF 50%);*/
}
body ::-webkit-input-placeholder {
    /* WebKit browsers */
    font-family: 'Lato', sans-serif;
    color: #555555;
    font-weight: 300;
}
body :-moz-placeholder {
    /* Mozilla Firefox 4 to 18 */
    font-family: 'Lato', sans-serif;
    color: #555555;
    opacity: 1;
    font-weight: 300;
}
body ::-moz-placeholder {
    /* Mozilla Firefox 19+ */
    font-family: 'Lato', sans-serif;
    color: #555555;
    opacity: 1;
    font-weight: 300;
}
body :-ms-input-placeholder {
    /* Internet Explorer 10+ */
    font-family: 'Lato', sans-serif;
    color: #555555;
    font-weight: 300;
}
.wrapper {
    position: relative;
    z-index: 2;
    width: 100%;
    min-height: 750px;
    display: -webkit-box;
    display: -webkit-flex;
    display: -moz-box;
    display: -ms-flexbox;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    padding: 50px 200px;
}
.container {
    -webkit-box-shadow: 10px 0px 30px 5px rgba(0,0,0,0.27);
    -moz-box-shadow: 10px 0px 30px 5px rgba(0,0,0,0.27);
    box-shadow: 10px 0px 30px 5px rgba(0,0,0,0.27);
    background: #fff;
    overflow: hidden;
    display: -webkit-box;
    display: -webkit-flex;
    display: -moz-box;
    display: -ms-flexbox;
    display: flex;
    flex-wrap: wrap;
    align-items: stretch;
    flex-direction: row-reverse;
    padding: 0px;
    width: 100%;
    height: 500px;
}
.login-left {
    width: 50%;
    background: indigo;
    z-index: 1;
    padding: 100px 40px;
    position: relative;
    color: White;
}
.login-left h2 {
    font-weight: 700;
    font-size:34px;
}
.login-left h3 {
    font-size: 1.2em;
    margin: 1em 0;
    line-height: 28px;
    font-weight: 500;
    text-transform: capitalize;
}
.login-left p {
    font-size: 14px;
    margin: 1em 0;
    line-height: 28px;
    font-weight: 400;
}
.login-left i {
    font-size: 18px;
}
.login-left a {
    color: #555555;
    text-decoration: none;
    padding-right: 5px; 
}
    
.login-form {
    width: 50%;
    display: -webkit-box;
    display: -webkit-flex;
    display: -moz-box;
    display: -ms-flexbox;
    display: flex;
    flex-wrap: wrap;
    padding: 50px 50px 50px 50px
}
.form-title {
    font-size: 25px;
    font-weight: 900;
    text-align: center;
    width: 100%;
    display: block;
    padding-bottom: 25px;
}
.remember-link-left {
    display: block;
    width: 50%;
    text-align: left;
    padding-bottom: 25px;
    
}
.forgot-link-right {
    display: block;
    width: 50%;
    text-align: right;
    padding-bottom: 25px;
    
}
.login-form a {
   color: violet;
    text-decoration: none;
    font-weight: 700;
    font-size: 15px;
}
.form-group {
    margin-bottom: 1rem;
}
.form-group {
    width: 100%;
    display: -webkit-box;
    display: -webkit-flex;
    display: -moz-box;
    display: -ms-flexbox;
    display: flex;
    flex-wrap: wrap;
}
button, input, optgroup, select, textarea {
    margin: 0;
    font-family: inherit;
    font-size: inherit;
    line-height: inherit;
}
button, input {
    overflow: visible;
}
[type="button"], [type="reset"], [type="submit"], button {
    -webkit-appearance: button;
}
.btn {
    display: inline-block;
    font-weight: 400;
    color: #212529;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    background-color: transparent;
    border: 1px solid transparent;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: .25rem;
    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
}
.btn-primary {
    color: #ffffff;
    background-color:indigo;
    border-color: #007bff;
}
.btn-group-lg > .btn, .btn-lg {
    padding: .5rem 1rem;
    font-size: 1.25rem;
    line-height: 1.5;
    border-radius: .3rem;
}
.btn-block {
    display: block;
    width: 100%;
}
[type="button"]:not(:disabled), [type="reset"]:not(:disabled), [type="submit"]:not(:disabled), button:not(:disabled) {
    cursor: pointer;
}
input[type="button"].btn-block, input[type="reset"].btn-block, input[type="submit"].btn-block {
    width: 100%;
}
[type="button"]::-moz-focus-inner, [type="reset"]::-moz-focus-inner, [type="submit"]::-moz-focus-inner, button::-moz-focus-inner {
    padding: 0;
    border-style: none;
}
.form-control {
    display: block;
    width: 100%;
    height: calc(1.5em + .75rem + 10px);
    padding: .375rem .75rem;
    font-size: 1rem;
    font-weight: 400;
    line-height: 1.5;
    color: #495057;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    border-radius: .25rem;
    transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
}
.form-control::placeholder {
    color: #0000ff;
    opacity: 0.5;
}
label {
    display: inline-block;
    margin-bottom: .5rem;
    font-weight: 700;
}
.copyright {
    font-size: 15px;
    position: relative;
    z-index: 1;
}
.copyright a{
    color: #34568B;
    font-size: 16px;
    text-decoration: none;
}
.copyright a:hover{
    color: #000;
    text-decoration: underline;
}
.copyright strong {
    font-weight: 700;
}

/*-----Responsive------ */
@media (max-width: 1280px) {
    .login-form {
        padding-left: 100px;
        padding-right: 100px;
    }
    .wrapper {
        padding:50px;
    }
}
@media (max-width: 992px) {
    .login-form {
        width: 50%;
        padding-left: 30px;
        padding-right: 30px;
    }
    .login-left {
        width: 50%;
    }
}
@media (max-width: 767px){
    .login-form {
        width: 100%;
    }
    .login-left {
        background: white;
        width: 100%;
    }
    .wrapper {
        padding:10px;
    }
    .copyright {
        padding-bottom: 30px;
    }
}
   </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper">
        <div class="container">
            <div class="login-form">
                <span class="form-title">Log in</span>
                <div class="form-group">
                    <label>
                        User Name</label>
                    <asp:TextBox ID="txtuser" runat="server" class="form-control" placeholder="User Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>
                        Password</label>
                    <asp:TextBox ID="txtpswd" runat="server" class="form-control" placeholder="Enter Password"
                        TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <span class="remember-link-left">
                        <label>
                            <asp:CheckBox ID="CheckBox1" runat="server" />&nbsp;Remember Me</label></span>
                    <span class="forgot-link-right"><a href="#">forgot password?</a></span>
                </div>
                <div class="form-group">
                    <button class="btn btn-primary btn-lg btn-block" id="btnlogin" runat="server">
                        <i class="fas fa-unlock"></i>&nbsp;<span class="button__text">Log In Now</span>
                    </button>
                </div>
                <p>
                    Don't have an account? <a href="#">Register here</a>.</p>
            </div>
            <div class="login-left">
                <h2>
                    Welcome !</h2>
                <h3>
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry.</h3>
                <p>
                    It is a long established fact that a reader will be distracted by the readable content
                    of a page when looking at its layout. The point of using Lorem Ipsum is that it
                    has a more-or-less normal distribution of letters, as opposed to using 'Content
                    here, content here', making it look like readable English.</p>
            </div>
        </div>
        <div class="copyright">
            &copy; 2022 All rights reserved | Designed by <a href="http://coreitechconsultancy.com" target="_blank"><strong>COREITECH
                CONSULTANCY SERVICES</strong></a>
        </div>
    </div>
    </form>
</body>
</html>
