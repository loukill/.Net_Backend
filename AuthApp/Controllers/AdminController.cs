using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Repositories;
using AuthApp.Repositories.Interfaces;
using AuthApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AuthApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AdminController(UserManager<AppUser> userManager, IEmailService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult ConfirmationPage()
        {
            return View("~/Views/Admin/ConfirmationPage.cshtml");
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId)
        {

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Invalid request");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var model = new ConfirmEmailViewModel
            {
                UserId = userId,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.RoleUser.ToString()
            };

            return View("~/Views/Admin/ConfirmEmail.cshtml", model);
        }

        /* [HttpGet("validate-user")]
         public async Task<IActionResult> ValidateUser([FromQuery] string userId)
         {
             if (string.IsNullOrEmpty(userId))
             {
                 return BadRequest("Invalid request");
             }

             var user = await _userManager.FindByIdAsync(userId);
             if (user == null)
             {
                 return NotFound("User not found");
             }

             // Confirm the user's email and validate the user
             // Assuming token validation is handled separately

             user.IsValidated = true;
             var result = await _userManager.UpdateAsync(user);

             if (result.Succeeded)
             {
                 return Ok("User validated successfully");
             }
             else
             {
                 return StatusCode(500, "Validation failed");
             }
         }*/


        [HttpPost("approveuser")]
        public async Task<IActionResult> ApproveUser([FromForm] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            user.IsValidated = true;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Récupérer l'URL de l'application Angular
                var angularAppUrl = _configuration["AngularAppUrl"];
                var loginLink = $"{angularAppUrl}/authentication/login";

                // Envoyer un email à l'utilisateur avec le lien de connexion
                await _emailService.SendApprovalEmail(user.Email, loginLink);

                return View("~/Views/Admin/ConfirmationPage.cshtml");
            }
            else
            {
                return StatusCode(500, result.Errors);
            }
        }



        [HttpPost("rejectuser")]
        public async Task<IActionResult> RejectUser([FromForm] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                // Récupérer l'URL de l'application Angular
                var angularAppUrl = _configuration["AngularAppUrl"];
                var registerLink = $"{angularAppUrl}/authentication/register";

                // Envoyer un email avec le lien de rejet
                await _emailService.SendRejectionEmail(user.Email, registerLink);

                return View("~/Views/Admin/RejectionPage.cshtml");
            }
            else
            {
                return StatusCode(500, result.Errors);
            }
        }
    }

}