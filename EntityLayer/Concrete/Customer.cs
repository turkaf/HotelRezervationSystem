using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        // Navigation Properties
        public virtual List<Booking> Bookings { get; set; }
    }
}