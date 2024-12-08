using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet'ler
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
