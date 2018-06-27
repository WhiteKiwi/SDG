<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solutions.aspx.cs" Inherits="SDG_Site.Solutions" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<title>Solutions</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<link rel="stylesheet" href="/assets/css/main.css">
	<link rel="shortcut icon" href="/assets/img/logo.png" />
</head>
<body>
	<section id="noheader">
		<div class="container">
			<section id="noheader">
				<div class="container">
					<nav>
						<ul id="mainNavigation" class="main-nav">
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
					<h1>Solutions</h1>
				</div>
			</section>
			<div class="the-header-text ">
			</div>
		</div>
	</section>
	<section id="solutions">

		<table>

			<tr>
				<th>Index</th>
				<th>Writer</th>
				<th>Solution Title</th>
				<th>Stage</th>
				<th>Date Submitted</th>
			</tr>
			<%
				try {
					int page;
					try {
						page = int.Parse(Request.QueryString["page"]);
					} catch (Exception e) {
						page = 1;
					}
					var postList = SDG_Site.Managers.PostManager.GetPostsByPage(page);

					foreach (var post in postList) {
						// Write on Page
						Response.Write("<tr>");
						Response.Write("<td>" + post.Id + "</td>");
						Response.Write("<td>" + post.Writer + "</td>");
						Response.Write("<td><a href=\"/Solution.aspx?Id=" + post.Id + "\">" + post.Title + "</a></td>");
						Response.Write("<td>" + post.Stage + "</td>");
						Response.Write("<td>" + post.UploadAt.ToString("yyyy-MM-dd") + "</td>");
						Response.Write("</tr>");
					}
				} catch (Exception e) {
					Response.Write(e.Message);
				}
				// TODO: Paging
			%>
		</table>
	</section>
	<section id="footer">
		<div class="content-container ">
			<p>COPYRIGHT © 2018. ALL RIGHTS RESERVED. DESIGN BY TEAM NETWORK B</p>
			<br />
		</div>
	</section>
	<script src="/assets/js/app-min.js"></script>
</body>
</html>
