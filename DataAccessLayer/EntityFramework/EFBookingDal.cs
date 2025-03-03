using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public List<Booking> GetListBookingWithCustomerAndRoom()
        {
            using (var c = new Context())
            {
                return c.Bookings
                    .Include(x => x.Customer)
                    .Include(x => x.Room)
                        .ThenInclude(r => r.RoomType)
                    .ToList();
            }
        }
    }
}