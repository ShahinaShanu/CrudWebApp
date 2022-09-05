<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPwdWindow.aspx.cs" Inherits="CrudApplication.ResetPwdWindow" %>

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
             <h2>Reset Password:</h2>
 <table style="width: 70%;">
  <tr>
         <td>New Password :<span style="color:red"> *</span> </td>
         <td>
             <asp:TextBox ID="txtNewPwd" TextMode="Password" runat="server"></asp:TextBox> </td>
          </tr>
  <tr><td>Confirm Password<span style="color:red"> *</span> </td>
          <td><asp:TextBox ID="txtCnfmpwd" TextMode="Password" runat="server" ></asp:TextBox></td>
              </tr>
     <tr><td colspan="4">
        <asp:Button ID="BtnReset" runat="server" Text="Reset" class="btn"  OnClientClick="return PasswordValid();" OnClick="BtnReset_Click" />
        <asp:Button ID="BtnExit" runat="server"  Text="Exit" class="btn" OnClick="BtnExit_Click" /></td>
      </td></tr>
            </table>
        </div>
    </form>
</body>
</html>
