<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SDG_Site.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Title -->
    <title></title>

    <!-- Icon -->
    <%--<link rel="shortcut icon" href="/assets/img/favicon.png" />--%>
</head>
<body>
    <form runat="server">
        <asp:TextBox runat="server" ID="UserID"></asp:TextBox><br />
        <asp:TextBox runat="server" ID="Password"></asp:TextBox><br />
        <asp:TextBox runat="server" ID="Name"></asp:TextBox><br />
        <asp:TextBox runat="server" ID="Email"></asp:TextBox><br />

        <br />
        <asp:Button runat="server" ID="signInButton" Text="Sign up" OnClick="SignUpButton_Click" />
    </form>
</body>
</html>
