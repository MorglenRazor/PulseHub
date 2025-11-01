using Shared;

namespace AuthService.Models
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAtUtc { get; set; }
        public bool Revoked { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
