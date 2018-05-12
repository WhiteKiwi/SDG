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
        private string password;
		public string Password {
			get {
				// password Returns a hash value on request
				return (password + "rsEGnGEgJ45r57IhIu6aRKwGMJfHrXVhoaAEpTHgTK7DY9GTwhEFi").GetHashCode().ToString();
			}
			set {
				password = value;
			}
		}

        // User's Name
        public string Name { get; set; }

        // User's Email
        public string Email { get; set; }

        // User's Uni
        public int Uni { get; set; }
	}
}