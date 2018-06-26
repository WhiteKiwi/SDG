using MySql.Data.MySqlClient;
using SDG_Site.Models;
using System;
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
				string commandText = "INSERT INTO " + POSTTABLE + "(Title, Contents, Classification, Stage, Writer, Upload_At) VALUES ('" + post.Title + "', '" + post.Content + "', '" + post.Classification + "', '" + post.Stage + "', '" + post.Writer + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
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
		/// <param name="stage">Member variable of Post class</param>  
		/// <param name="page">requested page number</param>  
		/// <see cref="Post.Stage"/>
		public static List<Post> GetPostsByPage(int page, int stage = 0) {
			List<Post> result = new List<Post>();

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				// If stage is 0, not where sql
				string whereStage = stage == 0 ? "" : " WHERE Stage='" + stage + "'";

				// Command Text - Select Password
				string sql = "SELECT COUNT(*) FROM " + POSTTABLE + whereStage + ";";
				var cmd = new MySqlCommand(sql, conn);

				int postsCount = (int)cmd.ExecuteScalar();

				// Get Notices
				sql = "SELECT Id, Title, Upload_At FROM " + POSTTABLE + whereStage + " ORDER BY Id DESC LIMIT 10 OFFSET " + ((page - 1) * 10) + ";";
				cmd.CommandText = sql;

				var rdr = cmd.ExecuteReader();
				while (rdr.Read()) {
					result.Add(new Post {
						Id = (int)rdr["Id"],
						Title = (string)rdr["Title"],
						UploadAt = (DateTime)rdr["Upload_At"]
					});
				}

				// Connection Close
				conn.Close();
			}

			return result;
		}

		/// <summary>
		/// Get Post by Id
		/// </summary>
		/// <param name="Id">Member variable of Post class</param>  
		/// <see cref="Post.Id"/>
		public static Post GetPostById(int Id) {
			Post result = new Post();

			// Connect to DB
			using (var conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SDGDB"].ConnectionString)) {
				conn.Open();

				string sql = "SELECT * FROM " + POSTTABLE + " WHERE Id='" + Id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				var rdr = cmd.ExecuteReader();
				rdr.Read();

				// TODO: Check the table
				result = new Post{
					Id = (int)rdr["Id"],
					Title = (string)rdr["Title"],
					Content = (string)rdr["Content"],
					Classification = (string)rdr["Content"],
					Stage = (string)rdr["Stage"],
					Writer = (string)rdr["Writer"],
					UploadAt = (DateTime)rdr["Upload_At"]
				};

				// Connection Close
				conn.Close();
			}

			return result;
		}
	}
}
