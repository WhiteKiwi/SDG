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
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sdgDB"].ConnectionString)) {
				conn.Open();

				// Command Text - Insert new user
				string commandText = "INSERT INTO " + USERTABLE + "(User_Id, Password, Name) VALUES (" + user.UserID + ", " + user.Password + ", " + user.Name + ")";
				var cmd = new MySqlCommand(commandText, conn);

				// The number of rows affected
				int result = cmd.ExecuteNonQuery();

				// Connection Close
				conn.Close();

				return result;
			}
		}

	}
}
