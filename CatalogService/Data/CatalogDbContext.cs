using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options){}
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(c=>c.Name).IsUnique();
            modelBuilder.Entity<Supplier>().HasIndex(c=>c.Name).IsUnique();
            modelBuilder.Entity<Product>()
                .HasOne(p=>p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
