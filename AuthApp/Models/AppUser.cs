using AuthApp.Constants;
using AuthApp.Services;
using Microsoft.AspNetCore.Identity;

namespace AuthApp.Models {
    public class AppUser : IdentityUser {
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpires { get; set; }
        public string RoleUser { get; set; }
        public ICollection<UserService> UserServices { get; set; }
        public virtual ICollection<Events> CreatedRequests { get; set; } 
        public virtual ICollection<Events> AssignedRequests { get; set; }
    }
}
