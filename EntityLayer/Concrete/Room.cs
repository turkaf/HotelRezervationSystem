using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Room
    {
        public int RoomId { get; private set; } // Primary Key
        public string RoomNumber { get; private set; }
        public string RoomType { get; private set; }
        public int Capacity { get; private set; }
        public decimal PricePerNight { get; private set; }
        public float Rating { get; private set; }
        public int CityId { get; set; } // Foreign Key, Cities table
        public string Description { get; private set; }
        public bool Status { get; private set; }

        public bool HasWifi { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasTV { get; set; }
        public bool HasMinibar { get; set; }

        // Navigation Properties
        public virtual City City { get; set; }

        public ICollection<Reservation> Reservations { get; set; } // Room has many Reservations
    }
}