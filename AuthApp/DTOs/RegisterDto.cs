using AuthApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace AuthApp.DTOs {
    public class RegisterDto {
        public string? UserId { get; set; }
        [Required]
        public string? UserName { get; set; } 
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }

        [Required]
        public UserRoles? RoleUser { get; set; }
        public int? POSId {  get; set; }
        
    }
}
