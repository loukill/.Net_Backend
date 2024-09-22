using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Repositories.Interfaces;
using AuthApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApp.Services
{
    public class POSService : IPOSService
    {
        private readonly IPOSRepo _posRepo;
        private readonly ILogger<POSService> _logger;

        public POSService(IPOSRepo posRepo, ILogger<POSService> logger)
        {
            _posRepo = posRepo;
            _logger = logger;
        }

        public async Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsAsync()
        {
            return await _posRepo.GetAllPOSWithDetailsAsync();
        }

        public async Task<POS> GetPOSByIdAsync(int id)
        {
            return await _posRepo.GetPOSByIdAsync(id);
        }
        public async Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsByAdminIdAsync(string adminId)
        {
            return await _posRepo.GetAllPOSWithDetailsByAdminIdAsync(adminId);
        }
        public async Task AddPOSAsync(POS pos)
        {
            await _posRepo.AddPOSAsync(pos);
        }

        public async Task UpdatePOSAsync(POS pos)
        {
            _logger.LogInformation("Updating POS with ID: {POSId}", pos.POSId);
            await _posRepo.UpdatePOSAsync(pos);
        }

        public async Task DeletePOSAsync(int id)
        {
            await _posRepo.DeletePOSAsync(id);
        }
    }
}
