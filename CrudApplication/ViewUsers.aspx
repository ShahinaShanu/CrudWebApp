<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="CrudApplication.ViewUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <nav id="navbar">
        <div id="logo">
            <img src="img/girl-avatar-png.png" alt="myimage" srcset=""/></div>
           <%-- <ul>
             <li class="item"><a href="Protected.aspx">Protected</a></li>
             </ul>--%>
 </nav>
            <asp:Button ID="BtnLogOut" runat="server" Text="LogOut" class="btn" OnClick="BtnLogOut_Click" />
            <br />
            <asp:Label ID="lblUname" Text="" runat="server"></asp:Label>
        </div>
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <contenttemplate>
                            <asp:GridView ID="GridView_UserList" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
                                PageSize="30" GridLines="None" Width="100%" AllowSorting="True" AllowPaging="True" >
                              <AlternatingRowStyle CssClass="alt" />
                                 <Columns>
                                     <asp:TemplateField HeaderText="SNo">
                                         <ItemTemplate>
                                             <asp:Label ID="lblSr" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                             <asp:Label ID="lblFname" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                             <asp:Label ID="lblLname" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                             <asp:Label ID="lblEmailid" runat="server" Text='<%# Bind("EmailId") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Gender">
                                        <ItemTemplate>
                                             <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="City">
                                         <ItemTemplate>
                                             <asp:Label ID="lblcity" runat="server" Text='<%# Bind("CityName") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="State">
                                        
                                         <ItemTemplate>
                                             <asp:Label ID="lblstate" runat="server" Text='<%# Bind("StateName") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Country">
                                        <ItemTemplate>
                                             <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Interest">
                                          <ItemTemplate>
                                             <asp:Label ID="lblinterest" runat="server" Text='<%# Bind("Interest") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Password">
                                          <ItemTemplate>
                                             <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("Pasword") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="Imagepath" runat="server" ImageUrl='<%# Eval("ProfilePicPath") %>' Height="80px" Width="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                         <asp:LinkButton ID="lnkDetails" runat="server" Text="" CommandName="Edit" CommandArgument='<%#Eval("ID")%>'
                                                OnCommand="lnkDetails_Command" Font-Underline="false" >Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                        <PagerStyle CssClass="pgr" />
                            </asp:GridView>
                               </contenttemplate>
                                    </asp:UpdatePanel>
            
        
        </div>
</form>
</body>
</html>
