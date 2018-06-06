using SDG_Site.Managers;
using SDG_Site.Models;
using System;
using System.Text.RegularExpressions;

namespace SDG_Site {
	public partial class Register : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (Regex.IsMatch(Request.Form["Email"] == null ? "" : Request.Form["Email"], @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?")) {
				if (Request.Form["Password"] == Request.Form["Password2"]) {
					if (UserManager.Register(new User {
						Name = Request.Form["Name"],
						UserID = Request.Form["UserID"],
						Password = Request.Form["Password"],
						Email = Request.Form["Email"]
					}) == -1) {
						// if ID is already in use
						Response.Write("ID Already in use.");
					}
				} else {
					// If passwords do not match
					Response.Write("Password do not match.");
				}
			} else {
				// If not an email
				Response.Write("This is not an email.");
			}
		}
	}
}