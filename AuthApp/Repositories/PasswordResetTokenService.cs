using AuthApp.Data;
using AuthApp.Models;
using AuthApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Repositories
{
    public class PasswordResetTokenService : IPasswordResetTokenService
    {
        private readonly AppDbContext _context;

        public PasswordResetTokenService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PasswordResetToken> GetTokenByIdentifierAsync(string identifier)
        {
            return await _context.PasswordResetTokens
                .Where(t => t.Token == identifier)
                .FirstOrDefaultAsync();
        }

        public async Task SaveTokenAsync(string email, string token)
        {
            var resetToken = new PasswordResetToken
            {
                Id = Guid.NewGuid(),
                Token = token,
                Email = email,
                CreatedAt = DateTime.UtcNow
            };

            _context.PasswordResetTokens.Add(resetToken);
            await _context.SaveChangesAsync();
        }
    }

}
