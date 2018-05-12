using System;

namespace SDG_Site {
	public partial class Default : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			// Redirect to the Login page if the session does not exist
			if (String.IsNullOrEmpty((string)Session["UserID"]))
				Response.Redirect("/Login.aspx");
		}
	}
}