using AuthApp.Constants;
using AuthApp.Services;
using Microsoft.AspNetCore.Identity;

namespace AuthApp.Models {
    public class AppUser : IdentityUser {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
        public UserRoles RoleUser { get; set; }
        public Boolean IsValidated { get; set; }
        public Boolean IsApproved { get; set; }
        public ICollection<UserService> UserServices { get; set; }
        public virtual ICollection<Events> CreatedRequests { get; set; } 
        public virtual ICollection<Events> AssignedRequests { get; set; }
    }
}
