using MySql.Data.MySqlClient;
using SDG_Site.Models;

namespace SDG_Site.Managers {
	public static class UserManager {
		// Table Name
		private const string USERTABLE = "users";

		/// <summary>
		/// Register by <c>User</c> class
		/// </summary>
		/// <param name="user">User class in Models</param>  
		/// <see cref="User"/>
		public static int Register(User user) {
			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// Command Text - Insert new user
				string commandText = "INSERT INTO " + USERTABLE + "(User_Id, Password, Name, Email) VALUES ('" + user.UserID + "', '" + user.Password + "', '" + user.Name + "', '" + user.Email + "')";
				var cmd = new MySqlCommand(commandText, conn);

				int result;
				try {
					// The number of rows affected
					result = cmd.ExecuteNonQuery();
				} catch(MySqlException e) {
					// Returns -1 on exception
					return -1;
				}

				// Connection Close
				conn.Close();

				// add 30 uni for writer
				AddUni(user.UserID, 30);

				return result;
			}
		}

		/// <summary>
		/// Change Password by <c>User</c> class and newPassword string
		/// </summary>
		/// <param name="user">User class in Models</param>  
		/// <param name="newPassword">Password to change</param>  
		/// <see cref="User"/>
		public static int ChangePassword(User user, string newPassword)	 {
			// If the password change fails, -1 is returned
			int result = -1;

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// Command Text - Select Password
				string commandText = "SELECT Password FROM " + USERTABLE + " WHERE User_Id='" + user.UserID + "';";
				var cmd = new MySqlCommand(commandText, conn);

				// If the passwords match -> Update Password
				if (user.Password == (string)cmd.ExecuteScalar()) {
					// Change user's password
					user.Password = newPassword;

					// Command Text - Update Password
					commandText = "UPDATE " + USERTABLE + " SET Password='" + user.Password + "' Where User_Id='" + user.UserID + "';";
					cmd.CommandText = commandText;

					// The number of rows affected
					result = cmd.ExecuteNonQuery();
				}
				// Connection Close
				conn.Close();
			}

			return result;
		}

		/// <summary>
		/// Returns the amount of the <c>User</c>'s Uni 
		/// </summary>
		/// <param name="userID">A member variable of the User class</param>  
		/// <see cref="User.UserID"/>
		public static int GetUniByUserID(string userID) {
			// If the Uni read fails, 0 is returned
			int Uni = 0;

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// Command Text - Select Password
				string commandText = "SELECT Uni FROM " + USERTABLE + " WHERE User_Id='" + userID + "';";
				var cmd = new MySqlCommand(commandText, conn);

				// Read User's Uni
				Uni = (int)cmd.ExecuteScalar();

				// Connection Close
				conn.Close();
			}

			return Uni;
		}

		/// <summary>
		/// Check the <c>User</c>'s Id and pw
		/// </summary>
		/// <param name="userID">User's ID</param>  
		/// <param name="password">User's Password</param>  
		/// <see cref="User.UserID"/>
		/// <see cref="User.Password"/>
		public static bool LoginCheck(string userID, string inputPassword) {
			// If ID or Password is null, return false
			if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(userID)) {
				return false;
			}

			// Returns false if the ID and password do not match
			bool result = false;

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// Command Text - Select Password
				string commandText = "SELECT Password FROM " + USERTABLE + " WHERE User_Id='" + userID + "';";
				var cmd = new MySqlCommand(commandText, conn);

				// Check User's Password
				if ((int)cmd.ExecuteScalar() == (inputPassword + "rsEGnGEgJ45r57IhIu6aRKwGMJfHrXVhoaAEpTHgTK7DY9GTwhEFi").GetHashCode())
					result = true;

				// Connection Close
				conn.Close();
			}

			return result;
		}
	}
}
