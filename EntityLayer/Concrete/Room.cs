using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int CityID { get; set; }
        public int RoomTypeID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Photo { get; set; }
        public double PricePerNight { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public bool HasWifi { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasTV { get; set; }
        public bool HasMinibar { get; set; }

        // Navigation Properties
        public virtual City City { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}