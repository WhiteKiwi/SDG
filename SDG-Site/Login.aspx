<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SDG_Site.Login" %>

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
    <asp:TextBox runat="server" ID="UserID"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="PW"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="Name"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="Email"></asp:TextBox><br />

    <br />
    <asp:Button runat="server" ID="signInButton" Text="Sign in" OnClick="SignInButton_Click"/>
</body>
</html>
