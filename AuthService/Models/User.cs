using Shared;

namespace AuthService.Models
{
    public class User : BaseEntity
    {
        public Guid PublicId { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public List<RefreshToken> RefreshToken { get; set; } = new();
    }
}
