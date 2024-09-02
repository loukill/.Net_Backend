namespace AuthApp.Models
{
    public class PasswordResetToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
