namespace ProjectJob.Models
{
    public class AddAdminViewModel
    {
      
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


		public string IsRole { get; set; }
	}
}
