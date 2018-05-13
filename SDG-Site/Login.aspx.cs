using SDG_Site.Managers;
using System;

namespace SDG_Site {
    public partial class Login1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void SignInButton_Click(object sender, EventArgs e) {
			// If the login succeeds, save the value to the session and return to the main page
			if (UserManager.LoginCheck(UserID.Text, Password.Text)) {
				Session["UserID"] = UserID.Text;

				Response.Redirect("/");
			} else {
				Response.Write("<script>alert('Please check ID and PW');</script>");
			}
		}
	}
}