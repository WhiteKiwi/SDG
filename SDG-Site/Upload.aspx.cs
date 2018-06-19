using System;

namespace SDG_Site {
	public partial class Upload : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty((string)Session["UserID"])) {
				// Upload the post by receiving the POST method
				Managers.PostManager.UploadPost(new Models.Post {
					Title = Request.Form["Title"],
					Content = Request.Form["Content"],
					Classification = Request.Form["Classification"],
					Stage = Request.Form["Stage"]
				});

				Response.Redirect("/");
			} else {
				// Unauthorized
				Response.StatusCode = 401;
			}
		}
	}
}