using AuthApp.DTOs;
using AuthApp.Services.Interfaces;

namespace AuthApp.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepo _serviceRepo;

        public ServiceService(IServiceRepo serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }
        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            return await _serviceRepo.GetAllServicesAsync();
        }

        public async Task<ServiceDto> GetServiceByIdAsync(int id)
        {
            return await _serviceRepo.GetServiceByIdAsync(id);
        }

        public async Task<ServiceDto> CreateServiceAsync(ServiceDto serviceDto)
        {
            return await _serviceRepo.CreateServiceAsync(serviceDto);
        }

        public async Task<ServiceDto> UpdateServiceAsync(ServiceDto serviceDto)
        {
            return await _serviceRepo.UpdateServiceAsync(serviceDto);
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            return await _serviceRepo.DeleteServiceAsync(id);
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesByPOSAsync(int posId)
        {
            return await _serviceRepo.GetServicesByPOSAsync(posId);
        }
    }
}
