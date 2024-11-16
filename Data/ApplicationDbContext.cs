using API2.Models;
using Microsoft.EntityFrameworkCore;

namespace API2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
        }

        public DbSet<Product> Products { get; set; }
    }
}
