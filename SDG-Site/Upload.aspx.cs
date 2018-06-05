using System;

namespace SDG_Site {
	public partial class Upload : System.Web.UI.Page {
		// Upload the post by receiving the POST method
		protected void Page_Load(object sender, EventArgs e) {
			Managers.PostManager.UploadPost(new Models.Post {
				Title = Request.Form["Title"],
				Content = Request.Form["Content"],
				Classification = Request.Form["Classification"],
				Stage = Request.Form["Stage"]
			});
		}
	}
}