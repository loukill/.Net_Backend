using AuthApp.Constants;
using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepo(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<IList<string>> GetUserRolesAsync(AppUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllPrestAsync()
        {
            var users = await _userManager.Users
                                          .Where(u => u.RoleUser == UserRoles.Prestataire)
                                          .ToListAsync();

            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleUser = user.RoleUser
            });

            return userDtos;
        }
        public async Task<IEnumerable<UserDto>> GetAllClientAsync()
        {
            var users = await _userManager.Users
                                          .Where(u => u.RoleUser == UserRoles.Client)
                                          .ToListAsync();

            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleUser = user.RoleUser
            });

            return userDtos;
        }


        public async Task<IdentityResult> AddUserAsync(AppUser user, string password, string role)
        {
            
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Assignez le rôle à l'utilisateur
                result = await _userManager.AddToRoleAsync(user, role);

                if (!result.Succeeded)
                {
                    // Optionnellement, gérez le cas où l'attribution du rôle échoue
                }
            }
            else
            {
                // Optionnellement, gérez le cas où la création de l'utilisateur échoue
            }

            return result;
        }

        public async Task<IdentityResult> UpdateUserAsync(AppUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;

            var existingRoles = await _userManager.GetRolesAsync(existingUser);
            var newRole = user.RoleUser.ToString();

            if (!existingRoles.Contains(newRole))
            {
                await _userManager.RemoveFromRolesAsync(existingUser, existingRoles);
                await _userManager.AddToRoleAsync(existingUser, newRole);
            }

            return await _userManager.UpdateAsync(existingUser);
        }


        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            return await _userManager.DeleteAsync(user);
        }
        public async Task<bool> IsInRoleAsync(AppUser user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }
        public async Task<AppUser> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
        public async Task<AppUser> GetByNameAsync(string name)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == name);
        }
    }
}
