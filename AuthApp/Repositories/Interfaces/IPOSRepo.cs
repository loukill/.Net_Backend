using AuthApp.DTOs;
using AuthApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthApp.Repositories.Interfaces
{
    public interface IPOSRepo
    {
        Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsAsync();
        Task<POS> GetPOSByIdAsync(int id);
        Task AddPOSAsync(POS pos);
        Task UpdatePOSAsync(POS pos);
        Task DeletePOSAsync(int id);
        Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsByAdminIdAsync(string adminId);
        Task<bool> IsPrestataireInPos(int posId, string prestataireId);
        Task<bool> IsClientAssociatedWithAdmin(string adminId, string clientId);
        Task AddClientToAdminAsync(string adminId, string clientId);
    }
}
