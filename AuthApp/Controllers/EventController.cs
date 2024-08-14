using AuthApp.Constants;
using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace AuthApp.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepo _eventRepo;
        private readonly IUserRepo _userRepo;

        public EventController(IEventRepo eventRepo, IUserRepo userRepo)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var events = await _eventRepo.GetAllAsync(); // Récupérer tous les événements

            // Appliquer le filtrage en fonction du rôle de l'utilisateur
            if (userRole == "client")
            {
                // Filtrer les événements liés au client
                events = events.Where(e => e.ClientId == userId).ToList();
            }
            else if (userRole == "prestataire")
            {
                // Filtrer les événements liés au prestataire
                events = events.Where(e => e.PrestataireId == userId).ToList();
            }
            // Si l'utilisateur est admin, il voit tous les événements

            var eventDtos = events.Select(e => new EventDto
            {
                Id = e.Id,
                ClientId = e.ClientId,
                Description = e.Description,
                DateRequest = e.DateRequest,
                EventStatus = e.EventStatus.ToString(),
                PrestataireId = e.PrestataireId,
                PrestataireName = e.PrestataireName,
                AdminName = e.AdminName
            }).ToList();

            return Ok(eventDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var eventItem = await _eventRepo.GetByIdAsync(id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            // Vérifiez que l'utilisateur a accès à cet événement
            if ((userRole == "client" && eventItem.ClientId != userId) ||
                (userRole == "prestataire" && eventItem.PrestataireId != userId))
            {
                return Forbid("You do not have access to this event.");
            }

            var eventDto = new EventDto
            {
                Id = eventItem.Id,
                ClientId = eventItem.ClientId,
                Description = eventItem.Description,
                DateRequest = eventItem.DateRequest,
                EventStatus = eventItem.EventStatus.ToString(),
                PrestataireId = eventItem.PrestataireId,
                PrestataireName = eventItem.PrestataireName,
                AdminName = eventItem.AdminName
            };

            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventDto newEventDto)
        {
            if (newEventDto == null)
            {
                return BadRequest("Event is null.");
            }

            var newEvent = new Events
            {
                ClientId = newEventDto.ClientId,
                Description = newEventDto.Description,
                DateRequest = newEventDto.DateRequest,
                EventStatus = Enum.Parse<EventStatus>(newEventDto.EventStatus),
                PrestataireId = newEventDto.PrestataireId
            };

            await _eventRepo.AddAsync(newEvent);
            await _eventRepo.SaveAsync();

            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEventDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDto updatedEventDto)
        {
            if (updatedEventDto == null || id != updatedEventDto.Id)
            {
                return BadRequest("Event data is incorrect.");
            }

            var eventItem = await _eventRepo.GetByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            eventItem.Description = updatedEventDto.Description;
            eventItem.DateRequest = updatedEventDto.DateRequest;
            eventItem.EventStatus = Enum.Parse<EventStatus>(updatedEventDto.EventStatus);
            eventItem.PrestataireId = updatedEventDto.PrestataireId;

            await _eventRepo.UpdateAsync(eventItem);
            await _eventRepo.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await _eventRepo.GetByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            await _eventRepo.DeleteAsync(id);
            await _eventRepo.SaveAsync();

            return NoContent();
        }

        [HttpPost("createrequest")]
        public async Task<IActionResult> CreateServiceRequestAsync(string clientId, string description, string? prestataireName, string? adminName)
        {
            // Vérifiez si le client est valide
            var client = await _userRepo.GetByIdAsync(clientId);
            if (client == null)
                return BadRequest("Invalid client.");

            // Validez l'entrée : soit PrestataireName soit AdminName doit être fourni
            if (string.IsNullOrEmpty(prestataireName) && string.IsNullOrEmpty(adminName))
                return BadRequest("Either PrestataireName or AdminName must be provided.");

            if (!string.IsNullOrEmpty(prestataireName) && !string.IsNullOrEmpty(adminName))
                return BadRequest("You can only assign the event to either a Prestataire or an Admin, not both.");

            // Recherchez l'utilisateur par nom
            string prestataireId = null;
            string adminId = null;

            if (!string.IsNullOrEmpty(prestataireName))
            {
                var prestataire = await _userRepo.GetByNameAsync(prestataireName);
                if (prestataire == null || prestataire.RoleUser != UserRoles.Prestataire.ToString())
                    return BadRequest("Invalid prestataire name.");
                prestataireId = prestataire.Id;
            }
            if (!string.IsNullOrEmpty(adminName))
            {
                var admin = await _userRepo.GetByNameAsync(adminName);
                if (admin == null || admin.RoleUser != UserRoles.Admin.ToString())
                    return BadRequest("Invalid admin name.");
                adminId = admin.Id;
            }

            // Créez l'événement
            var newRequest = new Events
            {
                ClientId = clientId,
                Description = description,
                DateRequest = DateTime.Now,
                EventStatus = EventStatus.Pending,
                PrestataireId = prestataireId,
                AdminId = adminId, 
                PrestataireName = prestataireName,
                AdminName = adminName
            };

            await _eventRepo.AddAsync(newRequest);
            await _eventRepo.SaveAsync();

            // Retournez la réponse avec les détails de l'événement créé
            return CreatedAtAction(nameof(GetEventById), new { id = newRequest.Id }, new EventDto
            {
                Id = newRequest.Id,
                ClientId = newRequest.ClientId,
                Description = newRequest.Description,
                DateRequest = newRequest.DateRequest,
                EventStatus = newRequest.EventStatus.ToString(),
                PrestataireId = newRequest.PrestataireId,
                PrestataireName = newRequest.PrestataireName,
                AdminId = newRequest.AdminId,
                AdminName = newRequest.AdminName
            });
        }

        [HttpPost("assignrequest")]
        public async Task<IActionResult> AssignRequestToPrestataire(int eventId, string prestataireName)
        {
            var eventItem = await _eventRepo.GetByIdAsync(eventId);
            if (eventItem == null)
                return NotFound("Event not found.");

            var prestataire = await _userRepo.GetByNameAsync(prestataireName);
            if (prestataire == null || prestataire.RoleUser != UserRoles.Prestataire.ToString())
                return BadRequest("Invalid prestataire name.");

            eventItem.PrestataireId = prestataire.Id;
            eventItem.EventStatus = EventStatus.Assigned;

            await _eventRepo.UpdateAsync(eventItem);
            await _eventRepo.SaveAsync();

            // Retournez la réponse avec les détails de l'événement mis à jour
            return Ok(new EventDto
            {
                Id = eventItem.Id,
                ClientId = eventItem.ClientId,
                Description = eventItem.Description,
                DateRequest = eventItem.DateRequest,
                EventStatus = eventItem.EventStatus.ToString(),
                PrestataireId = eventItem.PrestataireId,
                PrestataireName = eventItem.PrestataireName
            });
        }
    }
}