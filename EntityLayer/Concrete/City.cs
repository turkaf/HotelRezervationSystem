using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class City
    {
        [Key]
        public int CityID { get; private set; } // Primary Key
        public string CityName { get; private set; }
        // Navigational Property
        public virtual List<Room> Rooms { get; set; }
    }
}