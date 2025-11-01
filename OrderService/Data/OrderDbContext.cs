using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) {}
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Order)
                .WithMany(o=>o.Items)
                .HasForeignKey(i=>i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
