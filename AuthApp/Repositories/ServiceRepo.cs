using AuthApp.Data;
using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Services
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly AppDbContext _context;

        public ServiceRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            return await _context.Services
                .Select(service => new ServiceDto
                {
                    ServiceId = service.Id,
                    ServiceName = service.Name,
                    Description = service.Description,
                    Prix = service.Prix,
                    POSId = service.POSId
                })
                .ToListAsync();
        }

        public async Task<ServiceDto> GetServiceByIdAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return null;

            return new ServiceDto
            {
                ServiceId = service.Id,
                ServiceName = service.Name,
                Description = service.Description,
                Prix = service.Prix,
                POSId = service.POSId
            };
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesByPOSAsync(int posId)
        {
            return await _context.Services
                .Where(s => s.POSId == posId)
                .Select(s => new ServiceDto
                {
                    ServiceId = s.Id,
                    ServiceName = s.Name,
                    Description = s.Description,
                    Prix = s.Prix
                })
                .ToListAsync();
        }

        public async Task<ServiceDto> CreateServiceAsync(ServiceDto serviceDto)
        {
            var service = new Service
            {
                Name = serviceDto.ServiceName,
                Description = serviceDto.Description,
                Prix = (float)serviceDto.Prix,
                POSId = serviceDto.POSId // Associate with the specified POS
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            serviceDto.ServiceId = service.Id;
            return serviceDto;
        }

        public async Task<ServiceDto> UpdateServiceAsync(ServiceDto serviceDto)
        {
            var service = await _context.Services.FindAsync(serviceDto.ServiceId);
            if (service == null) return null;

            service.Name = serviceDto.ServiceName;
            service.Description = serviceDto.Description;
            service.Prix = (float)serviceDto.Prix;
            service.POSId = serviceDto.POSId; // Update the associated POS

            _context.Services.Update(service);
            await _context.SaveChangesAsync();

            return serviceDto;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}