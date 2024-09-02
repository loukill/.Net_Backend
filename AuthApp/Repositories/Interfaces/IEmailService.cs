namespace AuthApp.Repositories.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailValidationAsync(string validationLink);
        Task SendRejectionEmail(string userEmail, string registerLink);
        Task SendApprovalEmail(string userEmail, string loginLink);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
