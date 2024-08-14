using AuthApp.DTOs;

namespace AuthApp.Services.Interfaces
{
    public interface IServiceRepo
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> CreateServiceAsync(CreateServiceDto createServiceDto);
    }
}
