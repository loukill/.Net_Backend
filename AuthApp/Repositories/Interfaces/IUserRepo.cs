using AuthApp.DTOs;
using AuthApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthApp.Services.Interfaces
{
    public interface IUserRepo
    {
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IList<string>> GetUserRolesAsync(AppUser user);
        Task<IEnumerable<UserDto>> GetAllPrestAsync();
        Task<IEnumerable<UserDto>> GetAllClientAsync();
        Task<IdentityResult> AddUserAsync(AppUser user, string password, string roleUser);
        Task<IdentityResult> UpdateUserAsync(AppUser user);
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<AppUser> GetByIdAsync(string id);
        Task<bool> IsInRoleAsync(AppUser user, string role);
        Task<AppUser> GetByNameAsync (string name);
    }
}
