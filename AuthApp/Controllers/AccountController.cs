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
using Microsoft.AspNetCore.Identity.UI.Services;


namespace AuthApp.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signinManager, IEmailService emailService, IConfiguration configuration, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signinManager;
            _emailService = emailService;
            _configuration = configuration;
            _logger = logger;
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
                // Validate the model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if the email is provided
                if (string.IsNullOrEmpty(registerDto.Email))
                {
                    return BadRequest("Email cannot be null or empty.");
                }

                // Check if the email already exists in the system
                var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
                if (existingUser != null)
                {
                    return BadRequest("Email is already in use. Please choose a different email.");
                }

                // Validate the user role
                if (!Enum.IsDefined(typeof(UserRoles), registerDto.RoleUser))
                {
                    return BadRequest("Invalid role specified.");
                }

                // Create the user
                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    RoleUser = (UserRoles)registerDto.RoleUser,
                    IsValidated = false // Not validated by default
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                // Check if the user creation was successful
                if (createdUser.Succeeded)
                {
                    // Assign the role to the user
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
                    // Clean up by deleting the user if creation failed
                    await _userManager.DeleteAsync(appUser);
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return a more descriptive error message
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

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutDto logoutDto)
        {
            // Find the user by their ID or other identifier
            var user = await _userManager.FindByIdAsync(logoutDto.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Expire the refresh token by setting the expiration date to the past
            user.RefreshTokenExpires = DateTime.UtcNow.AddDays(-1); // Set the token as expired

            // Optionally, clear the token to make it unusable
            user.RefreshToken = string.Empty; // Or any other non-null value if your column is NOT NULL

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { message = "Logout successful. Token expired." });
            }
            else
            {
                return StatusCode(500, "An error occurred while logging out.");
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request");

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("User not found");

            // Generate the password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Construct a secure reset link
            // This URL should align with your Angular app's routing
            var resetLink = $"{_configuration["AngularAppUrl"]}/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(model.Email)}";

            // Send the email with the reset link
            await _emailService.SendEmailAsync(model.Email, "Reset Password",
                $"Please reset your password by clicking <a href='{resetLink}'>here</a>");

            return Ok("Password reset link has been sent to your email.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(model.Token))
                return BadRequest(new { error = "Token is required" });

            if (string.IsNullOrEmpty(model.Email))
                return BadRequest(new { error = "Email is required" });

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(new { error = "User not found" });

            var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!resetPassResult.Succeeded)
            {
                var errorMessage = string.Join(", ", resetPassResult.Errors.Select(e => e.Description));
                return BadRequest(new { error = errorMessage });
            }

            return Ok(new { message = "Password has been reset successfully." });
        }

    }
}