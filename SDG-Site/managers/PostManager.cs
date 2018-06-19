using MySql.Data.MySqlClient;
using SDG_Site.Models;
using System.Collections.Generic;

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

		/// <summary>
		/// Get Posts by page
		/// </summary>
		/// <param name="page">Post class in Models</param>  
		/// <see cref="Post"/>
		public static List<Post> GetContents(int page, int stage) {
			var result = new List<Post>();

			#region TotalPage
			// Number of postings
			int totalCount = GetPostsCount(stage);

			// Number of postings to float on one page
			const int listCount = 10;

			// Number of pages
			int totalPage = totalCount / listCount;
			if (totalCount % listCount > 0)
				totalPage++;

			// If the requested page is more than the total page
			if (page > totalPage)
				page = totalPage;
			#endregion

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// If stage is 0, not where sql
				string whereStage = stage == 0 ? "" : " WHERE Stage='" + stage + "'";

				// Command Text - Get Id and Title of Post
				string commandText = "SELECT Id, Title FROM " + POSTTABLE + whereStage + " LIMIT " + (page - 1) + ", " + listCount + ";";
				var cmd = new MySqlCommand(commandText, conn);

				// Return only title and id for paging purposes.
				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					result.Add(new Post {
						Id = (int)rdr["Id"],
						Title = (string)rdr["Id"]
					});
				}

				conn.Close();
			}

			return result;
		}

		/// <summary>
		/// Get Post's Count by Stage
		/// </summary>
		/// <param name="stage">Member variable of Post class</param>  
		/// <see cref="Post.Stage"/>
		public static int GetPostsCount(int stage) {
			int result = 0;

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// If stage is 0, not where sql
				string whereStage = stage == 0 ? "" : " WHERE Stage='" + stage + "'";

				// Command Text - Select Password
				string commandText = "SELECT COUNT(*) FROM " + POSTTABLE + whereStage + ";";
				var cmd = new MySqlCommand(commandText, conn);

				result = (int)cmd.ExecuteScalar();

				// Connection Close
				conn.Close();
			}

			return result;
		}
	}
}
