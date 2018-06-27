<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaderBoard.aspx.cs" Inherits="SDG_Site.LeaderBoard" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Leaderboard</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="/assets/css/main.css">
	<link rel="shortcut icon" href="/assets/img/logo.png" />
</head>
<body>
    <section id="yoheader">
        <div class="container">
            <section id=yoheader>
                <div class="container">
                    <nav>
                        <ul id=mainNavigation class="main-nav">
                            <li>
                                <a href="/" class="logo">Out of Well</a>
                            </li>
                            <div id="responsive-nav" class="responsive-nav">
                                <li>
                                    <a href="/Solutions.aspx" id="begone1" class="other-nav">Solutions</a>
                                </li>
                                <li>
                                    <a href="/LeaderBoard.aspx" id="begone2" class="other-nav">Leaderboard</a>
                                </li>
                            </div>
                            <li>
                                <a href="javascript:void(0);" onclick="showNav()">
                                    <div class="nav-toggle "></div>
                                    <div class="nav-toggle "></div>
                                    <div class="nav-toggle "></div>
                                </a>
                            </li>
                        </ul>
                    </nav>
                </div>
                <div class="text ">
                    <h1> Leaderboard</h1>>
                </div>
            </section>
            <div class="the-header-text ">

            </div>
        </div>
    </section>
    <section id="leaderboard">
        <table>
            <tr>
                <th>#</th>
                <th>Username</th>
                <th>Uni</th>
            </tr>
            <%
				try {
					var userList = SDG_Site.Managers.UserManager.GetTop10Users();
					int i = 0;
					foreach (var user in userList) {
						// Write on Page
						Response.Write("<tr>");
						Response.Write("<td>" + (++i) + "</td>");
						Response.Write("<td>" + user.Name+ "</td>");
						Response.Write("<td>" + user.Uni + "</td>");
						Response.Write("</tr>");
					}
				} catch (Exception e) {
					Response.Write(e.Message);
				}
				// TODO: Paging
				%>
        </table>
    </section>
    <section id=footer>
        <div class="content-container ">
            <p>COPYRIGHT © 2018. ALL RIGHTS RESERVED. DESIGN BY TEAM NETWORK B</p>
			<br />
        </div>
    </section>
    <script src="/assets/js/app-min.js"></script>
</body>

</html>
