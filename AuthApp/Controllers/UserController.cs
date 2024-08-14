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

namespace AuthApp.Controllers {
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
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

        [HttpGet("prestataires")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetPrestataires()
        {
            var prestataires = await _userRepo.GetAllPrestAsync();
            return Ok(prestataires);
        }

        [HttpGet("clients")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetClients()
        {
            var clients = await _userRepo.GetAllClientAsync();
            return Ok(clients);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] RegisterDto registerDto)
        {
            var user = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                RoleUser = registerDto.RoleUser.ToString()
            };

            var password = "DefaultPassword123!";

            var result = await _userRepo.AddUserAsync(user, password, registerDto.RoleUser.ToString());

            if (result.Succeeded)
            {
                return Ok("User added successfully.");
            }

            return BadRequest(result.Errors);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            var user = new AppUser
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Email,
                RoleUser = userDto.RoleUser
            };

            var result = await _userRepo.UpdateUserAsync(user);

            if (result.Succeeded)
            {
                return Ok("User updated successfully.");
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
