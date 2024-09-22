using AuthApp.DTOs;

namespace AuthApp.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceByIdAsync(int id);
        Task<ServiceDto> CreateServiceAsync(ServiceDto serviceDto);
        Task<ServiceDto> UpdateServiceAsync(ServiceDto serviceDto);
        Task<bool> DeleteServiceAsync(int id);
        Task<IEnumerable<ServiceDto>> GetServicesByPOSAsync(int posId);
    }
}
