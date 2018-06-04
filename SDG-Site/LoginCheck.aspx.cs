using System;

namespace SDG_Site {
	public partial class LoginCheck : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (Managers.UserManager.LoginCheck(Request.Form["UserID"], Request.Form["Password"])) {
				Response.Write("Authorized");
				// Authorized
				Response.StatusCode = 200;
			} else {
				Response.Write("Unauthorized");
				// Unauthorized
				Response.StatusCode = 401;
			}
		}
	}
}