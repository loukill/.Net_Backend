namespace AuthApp.DTOs
{
    public class PasswordResetTokenDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
