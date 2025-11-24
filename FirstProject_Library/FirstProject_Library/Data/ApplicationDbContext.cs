using FirstProject_Library.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstProject_Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Book>Books { get; set; }
        public DbSet<Employee>Employees { get; set; }
    }
}