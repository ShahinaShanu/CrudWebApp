<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CrudApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/Style.css" rel="stylesheet" />
    <script src="JS/Script.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav id="navbar">
        <div id="logo">
            <img src="img/girl-avatar-png.png" alt="myimage" srcset=""/></div>
            <ul>
              <li class="item"><a href="Index.aspx">Home</a></li>
              <li class="item"><a href="About.aspx">About</a></li>
               <li class="item"><a href="RegForm.aspx">Register</a></li>
               <li class="item"><a href="Login.aspx">Login</a></li>
             </ul>
 </nav>
  <h2>Login Here</h2>
 <table style="width: 70%;">
  <tr>
         <td>UserName<span style="color:red"> *</span> </td>
         <td>
             <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox> </td>
          </tr>
  <tr><td>Password<span style="color:red"> *</span> </td>
          <td><asp:TextBox ID="txtUserpwd" TextMode="Password" runat="server" ></asp:TextBox></td>
              </tr>
     <tr><td colspan="4">
        <asp:Button ID="BtnLogin" runat="server" Text="LogIn" class="btn"  OnClientClick="return userValid();" OnClick="BtnLogin_Click"/>
         <a href="ResetPassword.aspx">Forgot password</a>
      </td></tr>
            </table>
        </div>
    </form>
</body>
</html>
