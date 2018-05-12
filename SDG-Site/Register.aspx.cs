using SDG_Site.Managers;
using SDG_Site.Models;
using System;

namespace SDG_Site {
	public partial class Login : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void SignUpButton_Click(object sender, EventArgs e) {
            UserManager.Register(new User {
                Name = Name.Text,
                UserID = UserID.Text,
                Password = Password.Text,
                Email = Email.Text
            });

            Response.Redirect("/");
        }
	}
}