using MySql.Data.MySqlClient;
using SDG_Site.Models;

namespace SDG_Site.Managers {
	public static class PostManager {
		// Table Name
		private const string POSTTABLE = "posts";

		/// <summary>
		/// Post by <c>Post</c> class
		/// </summary>
		/// <param name="post">Post class in Models</param>  
		/// <see cref="Post"/>
		public static int UploadPost(Post post) {
			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// Command Text - Upload new post
				string commandText = "INSERT INTO " + POSTTABLE + "(Title, Contents, Classification, Stage) VALUES ('" + post.Title + "', '" + post.Content + "', '" + post.Classification + "', '" + post.Stage + "')";
				var cmd = new MySqlCommand(commandText, conn);

				int result;
				try {
					// The number of rows affected
					result = cmd.ExecuteNonQuery();
				} catch (MySqlException e) {
					// Returns -1 on exception
					return -1;
				}

				// Connection Close
				conn.Close();

				return result;
			}
		}
	}
}
