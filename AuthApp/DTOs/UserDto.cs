using AuthApp.Constants;
using Microsoft.AspNetCore.Identity;

namespace AuthApp.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserRoles RoleUser { get; set; }

    }
}
