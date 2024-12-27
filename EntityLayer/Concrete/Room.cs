using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public string Photo { get; set; }
        public double PricePerNight { get; set; }
        public double? Rating { get; set; }
        public string Description { get; set; }
        public bool HasWifi { get; set; } = false;
        public bool HasAirConditioning { get; set; } = false;
        public bool HasTV { get; set; } = false;
        public bool HasMinibar { get; set; } = false;

        // Navigation Properties
        public virtual RoomType RoomType { get; set; }
        public virtual List<Booking>? Bookings { get; set; }
    }
}