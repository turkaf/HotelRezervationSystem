using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        public int CustomerId { get; private set; } // Primary Key
        public string UserName { get; private set; } // Unique
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        // Navigation Properties
        public ICollection<Reservation> Reservations { get; set; } // Customer has many Reservations
    }
}