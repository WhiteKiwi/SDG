using System;

namespace SDG_Site {
	public partial class Logout : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			Session["UserID"] = "";

			Response.Redirect("/Login.aspx");
		}
	}
}