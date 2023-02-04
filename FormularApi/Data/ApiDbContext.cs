using FormularApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormularApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}