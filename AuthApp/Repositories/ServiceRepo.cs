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
                .Select(s => new ServiceDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        public async Task<ServiceDto> CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            var service = new Service
            {
                Name = createServiceDto.Name
            };
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return new ServiceDto
            {
                Id = service.Id,
                Name = service.Name
            };
        }
    }
}
