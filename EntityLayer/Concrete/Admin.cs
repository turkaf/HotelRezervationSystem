namespace EntityLayer.Concrete 
{
    public class Admin
    {
        public int AdminId { get; private set; } // Primary Key
        public string UserName { get; private set; } // Unique
        public string Password { get; private set; }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}