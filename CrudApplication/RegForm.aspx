<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegForm.aspx.cs" Inherits="CrudApplication.RegForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/Style.css" rel="stylesheet" />
    <script src="JS/Script.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <nav id="navbar" runat="server">
        <div id="logo">
            <img src="img/girl-avatar-png.png" alt="myimage" /></div>
            <ul>
              <li class="item"><a href="Index.aspx">Home</a></li>
              <li class="item"><a href="About.aspx">About</a></li>
               <li class="item"><a href="RegForm.aspx">Register</a></li>
               <li class="item"><a href="Login.aspx">Login</a></li>
              
             </ul>
       </nav>
        </div>
         <div class="container">
    <div class="formContent">
        <h2 id="headingReg" runat="server" >Register here</h2>
        <table style="width: 100%;">
            <tr>
                <td>First Name<span style="color: red"> *</span> </td>
                <td colspan="2">
                    <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                </td>
                <td>Last name<span style="color: red"> *</span> </td>
                <td colspan="2">
                    <asp:TextBox ID="txtLname" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Gender<span style="color: red"> *</span> </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="RdBtnListGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Text="Male">Male</asp:ListItem>
                        <asp:ListItem Value="2" Text="Female">Female</asp:ListItem>
                        <asp:ListItem Value="3" Text="Other">Other</asp:ListItem>
                    </asp:RadioButtonList>
 </td>
                <td>Email<span style="color: red"> *</span> </td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hdnid" runat="server" />
                </td>
            </tr>
          
            <tr>
                <td>Zip <span style="color: red">*</span>  </td>
                <td colspan="2">
                    <asp:TextBox ID="txtZip" TextMode="number" runat="server"></asp:TextBox>
                </td>
                <td>Country <span style="color: red">*</span> </td>
                <td colspan="2">
                    <asp:DropDownList ID="DdlCountry" runat="server" AutoPostBack="true" Height="20px" Width="170px" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>State <span style="color: red">*</span> </td>
                <td colspan="2">
                    <%--<asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
                    <asp:DropDownList ID="DdlState" runat="server" AutoPostBack="true" Height="20px" Width="170px" OnSelectedIndexChanged="DdlState_SelectedIndexChanged"></asp:DropDownList>
                    <%--</ContentTemplate>
</asp:UpdatePanel>--%>

                </td>
                <td>City <span style="color: red">*</span> </td>
                <td colspan="2">
                    <%--<asp:UpdatePanel ID="updatePanel2" runat="server" UpdateMode="Conditional">
      <ContentTemplate>--%>
                    <asp:DropDownList ID="DdlCity" AutoPostBack="true" Height="20px" Width="170px" runat="server"></asp:DropDownList>
                    <%-- 
     </ContentTemplate>
</asp:UpdatePanel>   --%> </td>
            </tr>
              <tr>
                <td>Password<span style="color: red"> *</span> </td>
                <td colspan="2">
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="updatePanel" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>Confirm Password<span style="color: red"> *</span> </td>
                <td colspan="2">
                    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Area of Interest</td>
                <td colspan="2">
                     <asp:CheckBoxList ID="cblInterest" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Text="Reading" />
                            <asp:ListItem Value="2" Text="Writing" />
                            <asp:ListItem Value="3" Text="Traveling" />
                            <asp:ListItem Value="4" Text="Playing" />
                        </asp:CheckBoxList>
                </td>
                <td>Profile Picture</td>
                <td colspan="2">
                    <asp:FileUpload ID="FileUploadPic" runat="server" /> <asp:Label ID="lblFileUpload" Text="" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td >
                    <asp:Button ID="BtnRegister" runat="server" Text="Register" class="btn" OnClick="BtnRegister_Click" OnClientClick="return FormValid();" /></td>
                <td>
                    <asp:Button ID="BtnBack" runat="server" visible="false" Text="Back To View" class="btn" OnClick="BtnBack_Click" /></td>
                <td> <asp:Button ID="BtnDel" runat="server" visible="false" Text="Delete" class="btn" OnClick="BtnDel_Click" />
                    <asp:Label ID="lblSuccessMsg" Text="" ForeColor="Green" runat="server"></asp:Label>
               <asp:Label ID="lblErrorMsg" Text="" ForeColor="Red" runat="server"></asp:Label>
                </td>
                
            </tr>
            
        </table>
        </div>
             </div>
 
    </form>
  
</body>
</html>
