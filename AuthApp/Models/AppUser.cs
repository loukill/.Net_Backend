using AuthApp.Constants;
using AuthApp.Services;
using Microsoft.AspNetCore.Identity;

namespace AuthApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
        public UserRoles RoleUser { get; set; }
        public bool IsValidated { get; set; }
        public bool IsApproved { get; set; }
        public ICollection<UserService> UserServices { get; set; }
        public virtual ICollection<Events> CreatedRequests { get; set; }
        public virtual ICollection<Events> AssignedRequests { get; set; }
        public virtual ICollection<POS> AdminPOSs { get; set; } // Collection pour les POS liés à l'Admin
        public virtual ICollection<POS> ClientPOSs { get; set; } // Collection pour les POS liés aux Clients
        public virtual ICollection<POS> PrestatairePOSs { get; set; } // Collection pour les POS liés aux Prestataires
        public virtual ICollection<POSClient> POSClients { get; set; } // Collection for POS associated with Clients
        public virtual ICollection<POSPrestataire> POSPrestataires { get; set; } // Collection for POS associated with Prestataires
    }
}
