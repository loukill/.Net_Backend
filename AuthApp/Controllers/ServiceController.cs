using AuthApp.DTOs;
using AuthApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Controllers
{
        [ApiController]
        [Route("api/service")]
        public class ServiceController : ControllerBase
        {
            private readonly IServiceService _serviceService;
            private readonly ILogger<ServiceController> _logger;
            public ServiceController(IServiceService serviceService, ILogger<ServiceController> logger)
            {
                _serviceService = serviceService;
                _logger = logger;
            }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices()
        {
            var services = await _serviceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null) return NotFound();
            return Ok(service);
        }

        [HttpGet("GetServicesByPOS/{posId}")]
        public async Task<IActionResult> GetServicesByPOS(int posId)
        {
            try
            {
                var services = await _serviceService.GetServicesByPOSAsync(posId);
                if (services == null || !services.Any())
                {
                    return NotFound("No services found for the specified POS.");
                }
                return Ok(services);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching services for POS {posId}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<ServiceDto>> CreateService(ServiceDto serviceDto)
        {
            var service = await _serviceService.CreateServiceAsync(serviceDto);
            return CreatedAtAction(nameof(GetService), new { id = service.ServiceId }, service);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, ServiceDto serviceDto)
        {
            if (id != serviceDto.ServiceId) return BadRequest("Service ID mismatch");

            var updatedService = await _serviceService.UpdateServiceAsync(serviceDto);
            if (updatedService == null) return NotFound();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var deleted = await _serviceService.DeleteServiceAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}