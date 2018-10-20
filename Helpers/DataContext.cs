using Microsoft.EntityFrameworkCore;
using veso_be.Entities;
 
namespace veso_be.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
 
        public DbSet<User> Users { get; set; }
    }
}