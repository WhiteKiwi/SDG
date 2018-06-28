using SDG_Site.Managers;
using System;

namespace SDG_Site {
	public partial class Like : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (Request.Cookies["UserID"] == null) {
				// Cookie가 없을 경우 발급
				var rand = new Random(DateTime.Now.Millisecond);
				Response.Cookies["UserID"].Value = rand.Next().ToString() + "/" + rand.Next().ToString();
				Response.Cookies["UserID"].Expires = DateTime.Now.AddYears(5);
			}

			LikeManager.Liking(Request.Cookies["UserID"].Value, Request.QueryString["Id"]);

			Response.Redirect("/Solution.aspx?Id=" + Request.QueryString["Id"]);
		}
	}
}