using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete 
{
    public class Admin
    {
        [Key]
        public int AdminID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}