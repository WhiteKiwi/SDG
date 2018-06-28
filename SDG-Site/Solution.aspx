<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solution.aspx.cs" Inherits="SDG_Site.Solution" %>

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
								<a href="index.html" class="logo">Out of Well</a>
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
					>
				</div>
			</section>
			<div class="the-header-text ">
			</div>
		</div>
	</section>
	<%
		SDG_Site.Models.Post post = null;
		try {
			int Id;
			try {
				Id = int.Parse(Request.QueryString["Id"]);
			} catch (Exception e) {
				Id = 1;
			}

			post = SDG_Site.Managers.PostManager.GetPostById(Id);
		} catch (Exception e) {
			Response.Write(e.Message);
		}
	%>
	<section id="solutions-reveal">
		<div class="solutions-reveal">
			<h1><%=post.Title %></h1>
			<img src="assets/img/elephants.jpg" alt="" width="230px">
			<h2>Submitted By <%=post.Writer %></h2>
			<h3>Submitted on <%=post.UploadAt %></h3>
			<p>
				<%=post.Content %>
			</p>
		<br />
		<br />
			<input type="submit" name="AddButton" value="Like: <%=SDG_Site.Managers.LikeManager.LikesCount(post.Id) %>" id="AddButton" class="btn btn-primary" onclick="location.href='/Like.aspx?Id=<%=post.Id%>'">
			</div>
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
