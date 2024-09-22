namespace AuthApp.Models
{
    public class UserService
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
