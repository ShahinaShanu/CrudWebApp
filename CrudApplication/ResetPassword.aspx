<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CrudApplication.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/Style.css" rel="stylesheet" />
    <script src="JS/Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h2>Reset Password Here</h2>
 <table style="width: 70%;">
  <tr>
         <td>Registered EmailID:<span style="color:red"> *</span> </td>
         <td>
             <asp:TextBox ID="txtresetEmail" runat="server"></asp:TextBox> </td>
          </tr>
     <tr>
  <td colspan="2">
        <asp:Button ID="BtnSendMail" runat="server" Text="Send" class="btn"  OnClientClick="return EmailValid();" OnClick="BtnSendMail_Click"/>
        </td></tr>
            </table>
        </div>
    </form>
</body>
</html>
