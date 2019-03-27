<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bluediamond - Login</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/datepicker3.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">

    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->

</head>

<body>

    <div class="row">
        <div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
            <div class="login-panel panel panel-default">
                <div class="panel-heading">Log in</div>
                <div class="panel-body">
                    <form role="form" runat="server">
                        <fieldset>
                            <div class="form-group">
                                <asp:TextBox class="form-control" placeholder="E-mail" runat="server" name="email" id="email" type="email" ToolTip="Enter Email Address" autofocus=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox class="form-control" placeholder="Password" runat="server" name="password" id="password" type="password" Text=""></asp:TextBox>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox id="remember" type="checkbox" runat="server"/>Remember Me
                                </label>
                            </div>
                            <asp:Button  ID="btn_login" runat="server" class="btn btn-primary"  OnClick="loginButton_Click" Text="Login"></asp:Button>
                            <br /><asp:Label ID="error" ForeColor="red" runat="server" value=""/>
                        </fieldset>
                    </form>
                </div>
            </div>
        </div><!-- /.col-->
    </div><!-- /.row -->


    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/chart.min.js"></script>
    <script src="js/chart-data.js"></script>
    <script src="js/easypiechart.js"></script>
    <script src="js/easypiechart-data.js"></script>
    <script src="js/bootstrap-datepicker.js"></script>
    <script>
		!function ($) {
			$(document).on("click","ul.nav li.parent > a > span.icon", function(){
				$(this).find('em:first').toggleClass("glyphicon-minus");
			});
			$(".sidebar span.icon").find('em:first').addClass("glyphicon-plus");
		}(window.jQuery);

		$(window).on('resize', function () {
		  if ($(window).width() > 768) $('#sidebar-collapse').collapse('show')
		})
		$(window).on('resize', function () {
		  if ($(window).width() <= 767) $('#sidebar-collapse').collapse('hide')
		})
    </script>

    
</body>

</html>
