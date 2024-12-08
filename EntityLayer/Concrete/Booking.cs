using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Booking
    {
        [Key]
        public int BookingID { get; private set; } // Primary Key
        public int CustomerID { get; set; } // Foreign Key, Customers table
        public int RoomID { get; set; } // Foreign Key, Rooms table

        public DateTime ReservationDate { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public DateTime BookingDate { get; private set; }

        public bool Status { get; private set; } // Confirmed, Pending, Cancelled
        public int NumberOfGuests { get; private set; }
        public decimal TotalPrice { get; private set; }


        // Navigation Properties
        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}