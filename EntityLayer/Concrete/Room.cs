using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Room
    {
        [Key]
        public int RoomID { get; private set; } // Primary Key
        public int CityID { get; set; } // Foreign Key, Cities table
        public string RoomNumber { get; private set; }
        public string RoomType { get; private set; }
        public int Capacity { get; private set; }
        public decimal PricePerNight { get; private set; }
        public float Rating { get; private set; }
        public string Description { get; private set; }
        public bool Status { get; private set; }

        public bool HasWifi { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasTV { get; set; }
        public bool HasMinibar { get; set; }

        // Navigation Properties
        public virtual City City { get; set; }

        public virtual List<Booking> Reservations { get; set; } // Room has many Reservations
    }
}