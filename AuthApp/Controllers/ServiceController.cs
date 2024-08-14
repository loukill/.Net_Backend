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
            private readonly IServiceRepo _serviceRepo;

            public ServiceController(IServiceRepo serviceRepo)
            {
                _serviceRepo = serviceRepo;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAllServices()
            {
                var services = await _serviceRepo.GetAllServicesAsync();
                return Ok(services);
            }

            [Authorize(Roles = "Admin")]
            [HttpPost("CreateService")]
            public async Task<ActionResult<ServiceDto>> CreateService(CreateServiceDto createServiceDto)
            {
                if (string.IsNullOrWhiteSpace(createServiceDto.Name))
                {
                    return BadRequest("Service name cannot be empty");
                }

                var service = await _serviceRepo.CreateServiceAsync(createServiceDto);
                return CreatedAtAction(nameof(GetAllServices), new { id = service.Id }, service);
            }
        }
 }