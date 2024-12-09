using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
        public double TotalPrice { get; set; }
        // Navigation Properties
        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}