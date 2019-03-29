<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bluediamond - Login</title>
    <link href="css/icheck-bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/Login.css" rel="stylesheet" />
</head>

<body class="bg-login">
    <div class="container">
        <!--row -->
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-4 col-sm-offset-2 col-md-offset-2 col-lg-offset-4 margin-top-login">
                <div class="login-panel panel">
                    <div class="panel-heading text-center">
                        <h3 class="text-info">LOGIN</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form" runat="server">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="E-mail" runat="server" name="email" ID="email" type="email" ToolTip="Enter Email Address" autofocus=""></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Password" runat="server" name="password" ID="password" type="password" Text=""></asp:TextBox>
                                </div>
                                <div class="form-group icheck-info">
                                    <input type="checkbox" data-id="info1" id="remember" runat="server" />
                                    <label for="remember">Remember Me</label>
                                    <%-- <asp:CheckBox id="remember" type="checkbox" runat="server"/>Remember Me           --%>
                                </div>
                                <br />
                                <asp:Button ID="btn_login" runat="server" class="btn btn-info btn-block" OnClick="loginButton_Click" Text="LOGIN"></asp:Button>
                                <br />
                                <asp:Label ID="error" ForeColor="red" runat="server" value="" />
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </div>
        <!-- /.row -->
    </div>
    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

</body>

</html>
