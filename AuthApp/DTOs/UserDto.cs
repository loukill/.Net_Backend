using AuthApp.Constants;
using Microsoft.AspNetCore.Identity;

namespace AuthApp.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserRoles RoleUser { get; set; }
        public int POSId {  get; set; }
        public List<string> POSNames { get; set; }
    }
}
