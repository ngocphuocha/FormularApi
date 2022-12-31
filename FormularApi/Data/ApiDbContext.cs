using FormularApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormularApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {
        }
    }
}
