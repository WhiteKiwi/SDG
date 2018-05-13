using SDG_Site.Managers;
using SDG_Site.Models;
using System;

namespace SDG_Site {
	public partial class Login : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void SignUpButton_Click(object sender, EventArgs e) {
			if (Password.Text == Password2.Text) {
				if (UserManager.Register(new User {
					Name = Name.Text,
					UserID = UserID.Text,
					Password = Password.Text,
					Email = Email.Text
				}) == -1) {
					// Notify if ID is already in use
					Response.Write("<script>alert('ID already in use');</script>");
				} else {
					// Return to login page if no exception occurs
					Response.Redirect("/Login.aspx");
				}
			} else {
				// Notify If passwords do not match
				Response.Write("<script>alert('Passwords do not match');</script>");
			}
		}
	}
}