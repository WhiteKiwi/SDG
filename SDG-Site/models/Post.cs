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
		public int Stage { get; set; }
	}
}