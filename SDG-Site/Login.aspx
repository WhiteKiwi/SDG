﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SDG_Site.Login1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form runat="server">
        <asp:TextBox runat="server" ID="UserID"></asp:TextBox><br />
        <asp:TextBox runat="server" ID="Password"></asp:TextBox><br />
        <br />
        <asp:Button runat="server" ID="SignInButton" Text="Sign in" OnClick="SignInButton_Click"/>
    </form>
</body>
</html>
