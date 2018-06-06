﻿using System;

namespace SDG_Site {
	public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
			if (Managers.UserManager.LoginCheck(Request.Form["UserID"], Request.Form["Password"])) {
				Response.Write("Authorized");

				// Authorized
				Response.StatusCode = 200;

				Session["UserID"] = Request.Form["UserID"];
			} else {
				Response.Write("Unauthorized");

				// Unauthorized
				Response.StatusCode = 401;
			}
		}
	}
}