<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CrudApplication.Index" %>

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
            <ul>
              <li class="item"><a href="Index.aspx">Home</a></li>
              <li class="item"><a href="About.aspx">About</a></li>
               <li class="item"><a href="RegForm.aspx">Register</a></li>
               <li class="item"><a href="Login.aspx">Login</a></li>
      <%--          <li class="item"><a href="ViewUsers.aspx">Login</a></li>--%>
             </ul>

    </nav>
        </div>
       <h1>Crud Operation System</h1>
    </form>
</body></html>
