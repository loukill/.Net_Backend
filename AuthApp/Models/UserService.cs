namespace AuthApp.Models
{
    public class UserService
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
