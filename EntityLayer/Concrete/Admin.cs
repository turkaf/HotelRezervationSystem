using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete 
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}