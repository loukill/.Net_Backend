using AuthApp.DTOs;
using AuthApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApp.Services.Interfaces
{
    public interface IPOSService
    {
        Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsAsync();
        Task<POS> GetPOSByIdAsync(int id);
        Task AddPOSAsync(POS pos);
        Task UpdatePOSAsync(POS pos);
        Task DeletePOSAsync(int id);
        Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsByAdminIdAsync(string adminId);
    }
}
