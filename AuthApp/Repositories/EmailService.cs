using AuthApp.Repositories.Interfaces;
using System.Net;
using System.Net.Mail;

namespace AuthApp.Repositories
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"],
                                         int.Parse(_configuration["EmailSettings:Port"]));
            _smtpClient.Credentials = new NetworkCredential(_configuration["EmailSettings:Username"],
                                                            _configuration["EmailSettings:Password"]);
            _smtpClient.EnableSsl = true;
        }
        public async Task SendEmailValidationAsync(string validationLink)
        {
            string adminEmail = _configuration["EmailSettings:FromEmail"];

            if (string.IsNullOrEmpty(adminEmail))
            {
                throw new ArgumentNullException(nameof(adminEmail), "Admin email address cannot be null or empty");
            }

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["EmailSettings:FromEmail"]),
                Subject = "New User Registration - Validate User ",
                Body = $"A new user has registered. Review their details and validate their account using this link: <a href=\"{validationLink}\">Click here to validate</a>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(adminEmail));

            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Email sending failed: {ex.Message}");
            }
        }
        public async Task SendApprovalEmail(string userEmail, string loginLink)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["EmailSettings:FromEmail"]),
                Subject = "Your Account Has Been Approved",
                Body = $"Your account has been approved. You can now log in using this link: <a href=\"{loginLink}\">Login</a>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(userEmail));

            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Email sending failed: {ex.Message}");
            }
        }

        public async Task SendRejectionEmail(string userEmail, string registerLink)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                throw new ArgumentNullException(nameof(userEmail), "User email address cannot be null or empty");
            }

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["EmailSettings:FromEmail"]),
                Subject = "Account Rejected",
                Body = $"Unfortunately, your account has been rejected. You can try registering in again here: <a href=\"{registerLink}\">Register</a>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(userEmail));

            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Email sending failed: {ex.Message}");
            }
        }
    }
}