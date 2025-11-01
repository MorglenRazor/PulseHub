using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) {}
        public DbSet<User> Users => Set<User>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshToken)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
