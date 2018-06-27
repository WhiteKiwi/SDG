using System;

namespace SDG_Site.Models {
	/// <summary>
	/// posts table Model
	/// </summary>
	public class Post {
		// Post's ID
		public int Id { get; set; }

		// Title
		public string Title { get; set; }

		// Content
		public string Content { get; set; }

		// Classification
		public string Classification { get; set; }

		// Stage
		public string Stage { get; set; }

		// Writer's User_ID
		public string Writer { get; set; }

		// Uploaded Date
		public DateTime UploadAt { get; set; }
	}
}