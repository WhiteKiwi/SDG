using MySql.Data.MySqlClient;
using SDG_Site.Models;
using System.Collections.Generic;

namespace SDG_Site.Managers {
	public static class LikeManager {
		// Table Name
		private const string LIKETABLE = "likes";

		/// <summary>
		/// Liking the POST
		/// </summary>
		/// <param name="UserID">Member variable of User class</param>  
		/// <param name="PostID">Member variable of Post class</param>  
		/// <see cref="User.UserID"/>
		/// <see cref="Post.Id"/>
		public static string Liking(string UserID, string PostID) {
			string result = "";

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();


				// Command Text - Exist check
				string sql = "SELECT User_Id FROM " + LIKETABLE + " WHERE User_Id='" + UserID + "' AND Post_ID='" + PostID + "';";
				var cmd = new MySqlCommand(sql, conn);

				string userID = (string)cmd.ExecuteScalar();

				if (string.IsNullOrEmpty(userID)) {
					sql = "INSERT INTO " + LIKETABLE + "(User_Id, Post_Id) VALUES ('" + UserID + "', '" + PostID + "')";
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();

					result = "Successed";

					sql = "SELECT Writer FROM posts WHERE Id='" + PostID + "'";
					cmd.CommandText = sql;
					string writer = (string)cmd.ExecuteScalar();

					UserManager.AddUni(writer, 10);
				} else {
					result = "Already you like this";
				}

				// Connection Close
				conn.Close();
			}

			return result;
		}

		/// <summary>
		/// Count of Likes
		/// </summary>
		/// <param name="PostID">Member variable of Post class</param>  
		/// <see cref="Post.Id"/>
		public static int LikesCount(int PostID) {
			int result = 0;

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();


				// Command Text - Exist check
				string sql = "SELECT COUNT(*) FROM " + LIKETABLE + " WHERE Post_Id='" + PostID + "';";
				var cmd = new MySqlCommand(sql, conn);
				result = System.Convert.ToInt32(cmd.ExecuteScalar());

				// Connection Close
				conn.Close();
			}

			return result;
		}

		// TODO: Select Top 10 liker
	}
}
