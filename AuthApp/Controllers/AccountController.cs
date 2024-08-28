using AuthApp.Constants;
using AuthApp.DTOs;
using AuthApp.Extensions;
using AuthApp.Models;
using AuthApp.Repositories.Interfaces;
using AuthApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace AuthApp.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signinManager, IEmailService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signinManager;
            _emailService = emailService;
            _configuration = configuration;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Recherche de l'utilisateur par nom d'utilisateur
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            // Vérification de l'existence de l'utilisateur
            if (user == null)
            {
                return Unauthorized("Invalid username or password!");
            }

            // Vérification de l'e-mail confirmé
           /* if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return Unauthorized("Email not confirmed. Please check your email.");
            }*/

            // Vérification si l'utilisateur est validé par l'administrateur
            if (!user.IsValidated)
            {
                return Unauthorized("Your account has not been validated by the admin yet.");
            }

            // Vérification du mot de passe
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password!");
            }

            // Génération des jetons d'authentification
            var tokenDto = await _tokenService.CreateTokenDto(user, populateExp: true);

            // Réponse avec les jetons et informations utilisateur
            var response = new
            {
                AccessToken = tokenDto.AccessToken,
                RefreshToken = tokenDto.RefreshToken,
                UserId = user.Id,
                UserRole = user.RoleUser
            };

            // Ajout des cookies sécurisés
            HttpContext.Response.Cookies.Append("Access-Token", tokenDto.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Ajout du cookie sécurisé pour HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            HttpContext.Response.Cookies.Append("Username", user.UserName, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            HttpContext.Response.Cookies.Append("Refresh-Token", tokenDto.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = user.RefreshTokenExpires
            });

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrEmpty(registerDto.Email))
                {
                    return BadRequest("Email cannot be null or empty.");
                }

                if (!Enum.IsDefined(typeof(UserRoles), registerDto.RoleUser))
                {
                    return BadRequest("Invalid role specified.");
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    RoleUser = (UserRoles)registerDto.RoleUser,
                    IsValidated = false // Not validated by default
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, registerDto.RoleUser.ToString());
                    if (roleResult.Succeeded)
                    {
                        // Create validation link for admin
                        var validationLink = $"{_configuration["App:BaseUrl"]}/api/admin/confirm-email?userId={appUser.Id}";

                        // Send email to admin
                        await _emailService.SendEmailValidationAsync(validationLink);

                        return Ok(new { message = "Registration successful! Admin will review and validate your account.", userId = appUser.Id });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    await _userManager.DeleteAsync(appUser);
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("check-validation-status/{userId}")]
        public async Task<IActionResult> CheckValidationStatus(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(new { IsValidated = user.IsValidated });
        }


        /*    [HttpGet("ConfirmEmail")]
            public async Task<IActionResult> ConfirmEmail(string userId, string token)
            {
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                {
                    return BadRequest("User ID and token are required.");
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{userId}'.");
                }

                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return Ok("Email confirmed successfully!");
                }
                else
                {
                    return BadRequest("Email confirmation failed.");
                }
            }*/

        /*      [HttpPost("validate-user/{userId}")]
              public async Task<IActionResult> ValidateUser(string userId)
              {
                  var user = await _userManager.FindByIdAsync(userId);
                  if (user == null)
                  {
                      return NotFound("User not found.");
                  }

                  user.IsValidated = true;
                  await _userManager.UpdateAsync(user);

                  return Ok("User validated successfully!");
              }*/

        [HttpGet("userdetails")]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var userDetails = new
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = user.RoleUser
            };

            return Ok(userDetails);
        }

        /*[HttpPost("validate")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Check token validity here if needed

            user.IsValidated = true;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Errors);
            }
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectUser([FromBody] RejectUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Optionally: delete the user or mark them as rejected
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Errors);
            }
        }
*/
        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout() {
            // magic code 
            return Ok();
        }
    }
}
