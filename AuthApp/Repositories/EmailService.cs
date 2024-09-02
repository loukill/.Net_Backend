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
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email), "Email address cannot be null or empty.");

            if (string.IsNullOrEmpty(subject))
                throw new ArgumentNullException(nameof(subject), "Subject cannot be null or empty.");

            if (string.IsNullOrEmpty(htmlMessage))
                throw new ArgumentNullException(nameof(htmlMessage), "Email message cannot be null or empty.");

            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var portString = _configuration["EmailSettings:Port"];
            var username = _configuration["EmailSettings:Username"];
            var password = _configuration["EmailSettings:Password"];
            var enableSslString = _configuration["EmailSettings:EnableSsl"];

            if (string.IsNullOrEmpty(smtpServer))
                throw new ArgumentNullException(nameof(smtpServer), "SMTP server cannot be null or empty.");

            if (string.IsNullOrEmpty(portString))
                throw new ArgumentNullException(nameof(portString), "SMTP port cannot be null or empty.");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username), "SMTP username cannot be null or empty.");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password), "SMTP password cannot be null or empty.");

            if (string.IsNullOrEmpty(enableSslString))
                throw new ArgumentNullException(nameof(enableSslString), "SMTP SSL enable flag cannot be null or empty.");

            if (!int.TryParse(portString, out var port))
                throw new ArgumentException("SMTP port must be a valid integer.", nameof(portString));

            if (!bool.TryParse(enableSslString, out var enableSsl))
                throw new ArgumentException("SMTP SSL enable flag must be a valid boolean.", nameof(enableSslString));

            var mailMessage = new MailMessage
            {
                From = new MailAddress(username),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            using (var smtpClient = new SmtpClient(smtpServer, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = enableSsl
            })
            {
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Email sending failed: {ex.Message}");
                }
            }
        }
    }
}