using AuthApp.Data;
using AuthApp.Models;

namespace AuthApp.Repositories.Interfaces
{
    public interface IPasswordResetTokenService
    {
        Task<PasswordResetToken> GetTokenByIdentifierAsync(string identifier);
        Task SaveTokenAsync(string email, string token);
    }
}
