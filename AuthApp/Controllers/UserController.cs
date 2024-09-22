using AuthApp.Constants;
using AuthApp.DTOs;
using AuthApp.Extensions;
using AuthApp.Models;
using AuthApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Data;
using System.Security.Claims;
using AuthApp.Repositories.Interfaces;
using AuthApp.Data;

namespace AuthApp.Controllers {
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly IPOSRepo _posRepo;
        private readonly AppDbContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepo userRepo, IPOSRepo posRepo, AppDbContext context, ILogger<UserController> logger)
        {
            _userRepo = userRepo;
            _posRepo = posRepo;
            _context = context;
            _logger = logger;

        }

        [Authorize]
        [HttpGet("user-status")]
        public async Task<IActionResult> GetUserStatus()
        {
            var username = User.GetUsername();
            var appUser = await _userRepo.GetUserByUsernameAsync(username);
            if (appUser != null)
            {
                var roles = await _userRepo.GetUserRolesAsync(appUser);
                var message = $"User {appUser.UserName} is authorized. Roles: {string.Join(", ", roles)}";
                return Ok(message);
            }
            else
            {
                return Ok("User is unauthorized");
            }
        }

        [HttpGet("GetPrestatairesByPOS/{posId}")]
        public async Task<IActionResult> GetPrestatairesByPOS(int posId)
        {
            try
            {
                var prestataires = await _userRepo.GetPrestatairesByPOSAsync(posId);
                if (prestataires == null || !prestataires.Any())
                {
                    return NotFound("No prestataires found for the specified POS.");
                }
                return Ok(prestataires);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching prestataires for POS {posId}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet("prestataires")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetPrestataires([FromQuery] string adminId)
        {
            // Ensure the adminId parameter is valid
            if (string.IsNullOrEmpty(adminId))
            {
                return BadRequest("Admin ID is required.");
            }

            var prestataires = await _userRepo.GetPrestatairesForAdminAsync(adminId);

            // Check if any prestataires were found
            if (prestataires == null || !prestataires.Any())
            {
                return NotFound("No prestataires found for the specified admin.");
            }

            return Ok(prestataires);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("clients/{adminId}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetClients(string adminId)
        {
            // Ensure the adminId parameter is valid
            if (string.IsNullOrEmpty(adminId))
            {
                return BadRequest("Admin ID is required.");
            }

            var clients = await _userRepo.GetClientsForAdminAsync(adminId);

            // Check if any clients were found
            if (clients == null || !clients.Any())
            {
                return NotFound("No clients found for the specified admin.");
            }

            return Ok(clients);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] RegisterDto registerDto)
        {
            _logger.LogInformation($"Attempting to add a new user with Role: {registerDto.RoleUser} to POS: {registerDto.POSId}");
            // Get current admin's ID from the token context
            var currentAdminId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find the selected POS based on POSId in the DTO
            var pos = await _posRepo.GetPOSByIdAsync(registerDto.POSId.Value);

            if (pos == null)
            {
                return BadRequest("Invalid POS selected.");
            }

            // Assign the admin to the POS
            pos.AdminId = currentAdminId;

            var user = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                RoleUser = (UserRoles)registerDto.RoleUser,
                IsValidated = true
            };

            // Add user to the relevant collection based on their role
            switch (user.RoleUser)
            {
                case UserRoles.Admin:
                    pos.Admin = user;
                    break;
                case UserRoles.Client:
                    pos.Clients.Add(user);
                    break;
                case UserRoles.Prestataire:
                    pos.Prestataires.Add(user);
                    break;
                default:
                    return BadRequest("Invalid user role.");
            }

            // Set default password if not provided
            var password = registerDto.Password ?? "DefaultPassword123!";

            var result = await _userRepo.AddUserAsync(user, password, registerDto.RoleUser.ToString());

            if (result.Succeeded)
            {
                _logger.LogInformation($"User {user.UserName} added successfully.");
                await _context.SaveChangesAsync();
                return Ok("User added successfully.");
            }

            _logger.LogError($"Failed to add user {user.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var userDto = new UserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RoleUser = user.RoleUser
            };

            return Ok(userDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            var existingUser = await _userRepo.GetByIdAsync(userDto.UserId);
            if (existingUser == null)
            {
                return NotFound(new { message = "User not found." });
            }

            existingUser.UserName = userDto.UserName ?? existingUser.UserName;
            existingUser.Email = userDto.Email ?? existingUser.Email;

            var result = await _userRepo.UpdateUserAsync(existingUser);

            if (result.Succeeded)
            {
                return Ok(new { message = "User updated successfully." });
            }

            return BadRequest(result.Errors);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userRepo.DeleteUserAsync(id);

            if (result.Succeeded)
            {
                return Ok("User deleted successfully.");
            }

            return BadRequest(result.Errors);
        }
    }
}
