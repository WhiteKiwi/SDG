namespace SDG_Site.Models {
	/// <summary>
	/// users table Model
	/// </summary>
	public class User {
		// User's Serial Number
		public int Id { get; set; }

		// User's ID
		public string UserID { get; set; }

		// User's Password
		public string Password {
			get {
				// password Returns a hash value on request
				return Password.GetHashCode().ToString();
			}
			set {
				Password = value;
			}
		}

		// User's Name
		public string Name { get; set; }
		
		// User's Uni
		public int Uni { get; set; }
	}
}