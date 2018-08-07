<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Auth_login" %>

<!DOCTYPE html>

<html lang="en">

<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
  <!-- Meta, title, CSS, favicons, etc. -->
  <meta charset="utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />

  <title>Login</title>

  <!-- Bootstrap core CSS -->

  <link href="css/bootstrap.min.css" rel="stylesheet" />

  <link href="fonts/css/font-awesome.min.css" rel="stylesheet" />
  <link href="css/animate.min.css" rel="stylesheet" />

  <!-- Custom styling plus plugins -->
  <link href="css/custom.css" rel="stylesheet" />
  <link href="css/icheck/flat/green.css" rel="stylesheet" />


  <script type="text/javascript" src="js/jquery.min.js"></script>

  <!--[if lt IE 9]>
        <script src="../assets/js/ie8-responsive-file-warning.js"></script>
        <![endif]-->

  <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
  <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
          <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->

</head>

<body style="background:#F7F7F7;">

  <div class="">
    <a class="hiddenanchor" id="toregister"></a>
    <a class="hiddenanchor" id="tologin"></a>

    <div id="wrapper">
      <div id="login" class="animate form">
        <section class="login_content">
          <form runat="server">
            <h1>Login Form</h1>
              <div>
              <asp:DropDownList ID="ddllist" runat="server" class="form-control">
        <asp:ListItem>Admin</asp:ListItem>
       
        </asp:DropDownList>
            </div>
              <br />
            <div>
           
            <asp:TextBox ID="txtusername" runat="server"  placeholder="UserName" required="" class="form-control"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" placeholder="Password" required="" class="form-control"></asp:TextBox>
   
            </div>
            <div>
              
                <asp:Button ID="btnsubmit" class="btn btn-default submit" runat="server" Text="Log in" OnClick="btnsubmit_Click" />
              
            </div>
            <div class="clearfix"></div>
            <div class="separator">

              <p class="change_link">New to site?
                <a href="#toregister" class="to_register"> Create Account </a>
              </p>
              <div class="clearfix"></div>
              <br />
              <div>
                <h1><i class="fa fa-paw" style="font-size: 26px;"></i> 
                    Official Solutions!</h1>

              </div>
            </div>
          </form>
          <!-- form -->
        </section>
        <!-- content -->
      </div>
      <div id="register" class="animate form">
        <section class="login_content">
          <form>
            <h1>Create Account</h1>
            <div>
              <input type="text" class="form-control" placeholder="Username" required="" runat="server" />
            </div>
            <div>
              <input type="text" class="form-control" placeholder="Email" required="" runat="server" />
            </div>
            <div>
              <input type="password" class="form-control" placeholder="Password" required="" />
            </div>
            <div>
              <a class="btn btn-default submit" href="index.html">Submit</a>
            </div>
            <div class="clearfix"></div>
            <div class="separator">

              <p class="change_link">Already a member ?
                <a href="#tologin" class="to_register"> Log in </a>
              </p>
              <div class="clearfix"></div>
              <br />
              <div>
                <h1><i class="fa fa-paw" style="font-size: 26px;"></i> Gentelella Alela!</h1>

                <p>©2015 All Rights Reserved. Gentelella Alela! is a Bootstrap 3 template. Privacy and Terms</p>
              </div>
            </div>
          </form>
          <!-- form -->
        </section>
        <!-- content -->
      </div>
    </div>
  </div>

</body>

</html>
