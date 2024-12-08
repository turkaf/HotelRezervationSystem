using System;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int BookingId { get; private set; } // Primary Key
        public int UserId { get; set; } // Foreign Key, Customers table
        public int RoomId { get; set; } // Foreign Key, Rooms table

        public DateTime ReservationDate { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public DateTime BookingDate { get; private set; }

        public string Status { get; private set; } // Confirmed, Pending, Cancelled
        public int NumberOfGuests { get; private set; }
        public decimal TotalPrice { get; private set; }


        // Navigation Properties
        public virtual Customer Reservation { get; set; }
        public virtual Room Room { get; set; }
    }
}