using AuthApp.Constants;
using AuthApp.Data;
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
        private readonly AppDbContext _context;

        public UserRepo(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<IList<string>> GetUserRolesAsync(AppUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
        public async Task<IEnumerable<UserDto>> GetClientsForAdminAsync(string adminId)
        {
            var clients = await _context.POSs
                .Where(pos => pos.AdminId == adminId)  // Find POSs where the adminId matches
                .SelectMany(pos => pos.Clients)          // Select all Clients associated with these POSs
                .Select(client => new UserDto
                {
                    UserId = client.Id,           // Use ClientId instead of Id
                    UserName = client.UserName,  // Access UserName through the Client navigation property
                    Email = client.Email,        // Access Email through the Client navigation property
                    RoleUser = client.RoleUser,  // Access RoleUser through the Client navigation property
                    POSNames = _context.POSs
                                    .Where(p => p.Clients.Any(c => c.Id == client.Id))
                                    .Select(p => p.POSName)  // Get POS names associated with this client
                                    .ToList()
                })
                .ToListAsync();

            return clients;
        }

        public async Task<IEnumerable<PrestataireDto>> GetPrestatairesByPOSAsync(int posId)
        {
            return await _context.POSPrestataires
                .Where(p => p.POSId == posId)
                .Include(p => p.Prestataire) // Assuming there's a navigation property for Prestataire
                .Select(p => new PrestataireDto
                {
                    PrestataireId = p.PrestataireId,
                    UserName = p.Prestataire.UserName,
                    Email = p.Prestataire.Email
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<UserDto>> GetPrestatairesForAdminAsync(string adminId)
        {
            var prestataires = await _context.POSs
                .Where(pos => pos.AdminId == adminId)  // Find POSs where the adminId matches
                .SelectMany(pos => pos.Prestataires)    // Select all Prestataires associated with these POSs
                .Select(prestataire => new UserDto
                {
                    UserId = prestataire.Id,   // Use PrestataireId instead of Id
                    UserName = prestataire.UserName, // Access UserName through the Prestataire navigation property
                    Email = prestataire.Email,     // Access Email through the Prestataire navigation property
                    RoleUser = prestataire.RoleUser, // Access RoleUser through the Prestataire navigation property
                    POSNames = _context.POSs
                                    .Where(p => p.Prestataires.Any(pr => pr.Id == prestataire.Id))
                                    .Select(p => p.POSName)  // Get POS names associated with this prestataire
                                    .ToList()
                })
                .ToListAsync();

            return prestataires;
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
