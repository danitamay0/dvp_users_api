using Microsoft.EntityFrameworkCore;
using users_api.Models;

namespace users_api.Data
{
    public class DoubleVPartnersDbContext : DbContext
    {
        public DoubleVPartnersDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }

    }
    
}
