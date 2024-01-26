using KT_DMAWS.Model;
using Microsoft.EntityFrameworkCore;

namespace KT_DMAWS.DBContext
{
    public class KT_DMAWSDBContext : DbContext
    {
        public KT_DMAWSDBContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(p => p.PriceQuantity)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
