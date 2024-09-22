using AuthApp.Constants;
using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Services;
using AuthApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using AuthApp.Repositories.Interfaces;

namespace AuthApp.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepo _eventRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILogger<EventController> _logger;
        private readonly IPOSRepo _posRepo;
        private readonly IServiceRepo _serviceRepo;

        public EventController(IEventRepo eventRepo, IUserRepo userRepo, ILogger<EventController> logger, IPOSRepo posRepo, IServiceRepo serviceRepo)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
            _logger = logger;
            _posRepo = posRepo;
            _serviceRepo = serviceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Retrieve all events with related POS and Admin data
            var events = await _eventRepo.GetAllAsync();

            // Apply filtering based on the user's role
            if (userRole == "Client")
            {
                // Filter events related to the client
                events = events.Where(e => e.ClientId == userId).ToList();
            }
            else if (userRole == "Prestataire")
            {
                // Filter events related to the prestataire
                events = events.Where(e => e.PrestataireId == userId).ToList();
            }
            // Admin sees all events

            // Map the filtered events to the EventDto
            var eventDtos = events.Select(e => new EventDto
            {
                Id = e.Id,
                ClientId = e.ClientId,
                Description = e.Description,
                DateRequest = e.DateRequest,
                EventStatus = e.EventStatus.ToString(),
                PrestataireId = e.PrestataireId,
                PrestataireName = e.PrestataireName,
                AdminId = e.POS?.Admin?.Id,  // Access AdminId through POS
                AdminName = e.POS?.Admin?.UserName,  // Access AdminName through POS
                PosId = e.POS.POSId,
                ServiceId = e.ServiceId
            }).ToList();

            return Ok(eventDtos);
        }

        [HttpGet("pos/{posId}")]
        public async Task<IActionResult> GetAllEventsForPos(int posId)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Récupérer tous les événements
            var events = await _eventRepo.GetAllAsync();

            // Filtrer les événements en fonction du POS ID
            events = events.Where(e => e.PosId == posId).ToList();

            // Filtrer les événements en fonction du rôle de l'utilisateur
            if (userRole == "Client")
            {
                // Filtrer les événements liés au client
                events = events.Where(e => e.ClientId == userId).ToList();
            }
            else if (userRole == "Prestataire")
            {
                // Filtrer les événements liés au prestataire
                events = events.Where(e => e.PrestataireId == userId).ToList();
            }
            // Admin voit tous les événements liés au POS

            var eventDtos = events.Select(e => new EventDto
            {
                Id = e.Id,
                ClientId = e.ClientId,
                Description = e.Description,
                DateRequest = e.DateRequest,
                EventStatus = e.EventStatus.ToString(),
                PrestataireId = e.PrestataireId,
                PrestataireName = e.PrestataireName,
                AdminName = e.AdminName,
                PosId = e.PosId 
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

            // Check if the user has access to this event
            if ((userRole == "Client" && eventItem.ClientId != userId) ||
                (userRole == "Prestataire" && eventItem.PrestataireId != userId))
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
                AdminName = eventItem.AdminName,
                ClientName = eventItem.ClientName,
                PosId = eventItem.PosId,
                ServiceId = eventItem.ServiceId,
            };

            return Ok(eventDto);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Events>>> GetEventsByUserIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var events = await _eventRepo.GetEventsByUserIdAsync(userId);

            if (events == null || !events.Any())
            {
                return NotFound("No events found for the specified user ID.");
            }

            return Ok(events);
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

            if (!string.IsNullOrWhiteSpace(updatedEventDto.Description))
            {
                eventItem.Description = updatedEventDto.Description;
            }

            if (updatedEventDto.DateRequest != null)
            {
                eventItem.DateRequest = updatedEventDto.DateRequest;
            }

            if (!string.IsNullOrWhiteSpace(updatedEventDto.EventStatus))
            {
                eventItem.EventStatus = Enum.Parse<EventStatus>(updatedEventDto.EventStatus);
            }

            if (!string.IsNullOrWhiteSpace(updatedEventDto.PrestataireName))
            {
                eventItem.PrestataireName = updatedEventDto.PrestataireName;
            }

            if (!string.IsNullOrWhiteSpace(updatedEventDto.ClientName))
            {
                eventItem.ClientName = updatedEventDto.ClientName;
            }

            if (!string.IsNullOrWhiteSpace(updatedEventDto.AdminName))
            {
                eventItem.AdminName = updatedEventDto.AdminName;
            }

            // Save changes to the database
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

        [Authorize]
        [HttpPost("createrequest")]
        public async Task<IActionResult> CreateServiceRequestAsync([FromBody] EventRequest request)
        {
            if (request == null)
                return BadRequest("Request body cannot be null.");

            if (string.IsNullOrEmpty(request.Description))
                return BadRequest("The description field is required.");

            if (request.PosId <= 0)
                return BadRequest("A valid POS ID is required.");

            // Retrieve POS information along with the AdminId
            var pos = await _posRepo.GetPOSByIdAsync(request.PosId.Value);
            if (pos == null)
                return BadRequest("Invalid POS ID.");

            // Check if the selected service is available in the selected POS
            var service = await _serviceRepo.GetServiceByIdAsync(request.ServiceId.Value);
            if (service == null || service.POSId != request.PosId.Value)
                return BadRequest("The selected service is not available in the chosen POS.");

            // Get client name from the logged-in user
            var clientName = User.FindFirst(ClaimTypes.GivenName)?.Value;
            if (string.IsNullOrEmpty(clientName))
            {
                return BadRequest("Client is not authenticated.");
            }

            var client = await _userRepo.GetByNameAsync(clientName);
            if (client == null || client.RoleUser != UserRoles.Client)
                return BadRequest("Invalid client.");

            // POS Prestataire check
            if (string.IsNullOrEmpty(request.PrestataireName))
                return BadRequest("A Prestataire must be selected.");

            var prestataire = await _userRepo.GetByNameAsync(request.PrestataireName);
            if (prestataire == null || prestataire.RoleUser != UserRoles.Prestataire)
                return BadRequest("Invalid prestataire.");

            // Check if the prestataire works at the selected POS
            var isPrestataireInPos = await _posRepo.IsPrestataireInPos(request.PosId.Value, prestataire.Id);
            if (!isPrestataireInPos)
                return BadRequest("The selected prestataire does not work at the chosen POS.");

            DateTime eventDateTime = request.DateTime ?? DateTime.Now;

            // Create a new event request with the AdminId from the POS
            var newRequest = new Events
            {
                ClientId = client.Id,
                Description = request.Description,
                DateRequest = eventDateTime,
                EventStatus = EventStatus.Pending, // Always Pending
                PrestataireId = prestataire.Id,
                PrestataireName = prestataire.UserName,
                ClientName = client.UserName,
                PosId = request.PosId.Value,
                ServiceId = request.ServiceId.Value,
                AdminId = pos.AdminId // Include the AdminId from the POS
            };

            // Add the new event request to the database
            await _eventRepo.AddAsync(newRequest);

            // Check if the client is already associated with the admin (via the POS)
            var isClientAssociated = await _posRepo.IsClientAssociatedWithAdmin(pos.AdminId, client.Id);
            if (!isClientAssociated)
            {
                // Associate the client with the admin of the POS
                await _posRepo.AddClientToAdminAsync(pos.AdminId, client.Id);
            }

            await _eventRepo.SaveAsync();

            // Return the created event with the details
            return CreatedAtAction(nameof(GetEventById), new { id = newRequest.Id }, new EventDto
            {
                Id = newRequest.Id,
                ClientId = newRequest.ClientId,
                Description = newRequest.Description,
                DateRequest = newRequest.DateRequest,
                EventStatus = newRequest.EventStatus.ToString(),
                PrestataireId = newRequest.PrestataireId,
                PrestataireName = newRequest.PrestataireName,
                ClientName = newRequest.ClientName,
                PosId = newRequest.PosId,
                ServiceId = newRequest.ServiceId,
                AdminId = newRequest.AdminId
            });
        }

        [Authorize]
        [HttpPost("assignrequest")]
        public async Task<IActionResult> AssignRequestToPrestataire([FromBody] AssignRequestDto request)
        {
            // Vérifier le rôle de l'utilisateur
            var (userRole, givenName) = GetUserRoleAndName();

            if (!IsAuthorizedToAssign(userRole))
                return Unauthorized("Only admins and prestataires can assign events.");

            // Récupérer l'événement et vérifier son existence
            var eventItem = await _eventRepo.GetByIdAsync(request.EventId);
            if (eventItem == null)
                return NotFound("Event not found.");

            // Récupérer et vérifier le prestataire
            var prestataire = await GetValidPrestataire(request.PrestataireName);
            if (prestataire == null)
                return BadRequest("Invalid prestataire name or role.");

            // Règle spéciale pour les prestataires : ils ne peuvent s'assigner qu'à eux-mêmes
            if (userRole == UserRoles.Prestataire.ToString() && givenName != request.PrestataireName)
                return BadRequest("Prestataire can only assign the event to themselves.");

            // Assignation de l'événement
            await AssignEventToPrestataire(eventItem, prestataire);

            // Retourner l'événement mis à jour
            return Ok(MapToEventDto(eventItem));
        }

        private (string userRole, string givenName) GetUserRoleAndName()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var givenName = User.FindFirst(ClaimTypes.GivenName)?.Value;
            return (userRole, givenName);
        }

        private bool IsAuthorizedToAssign(string userRole)
        {
            return !string.IsNullOrEmpty(userRole) &&
                   (userRole == UserRoles.Admin.ToString() || userRole == UserRoles.Prestataire.ToString());
        }

        private async Task<AppUser> GetValidPrestataire(string prestataireName)
        {
            var prestataire = await _userRepo.GetByNameAsync(prestataireName);
            return prestataire?.RoleUser == UserRoles.Prestataire ? prestataire : null;
        }

        private async Task AssignEventToPrestataire(Events eventItem, AppUser prestataire)
        {
            eventItem.PrestataireId = prestataire.Id;
            eventItem.PrestataireName = prestataire.UserName;
            eventItem.EventStatus = EventStatus.Assigned;

            await _eventRepo.UpdateAsync(eventItem);
            await _eventRepo.SaveAsync();
        }

        private EventDto MapToEventDto(Events eventItem)
        {
            return new EventDto
            {
                Id = eventItem.Id,
                ClientId = eventItem.ClientId,
                Description = eventItem.Description,
                DateRequest = eventItem.DateRequest,
                EventStatus = eventItem.EventStatus.ToString(),
                PrestataireId = eventItem.PrestataireId,
                PrestataireName = eventItem.PrestataireName
            };
        }


        [Authorize]
        [HttpPost("accept/{eventId}")]
        public async Task<IActionResult> AcceptEvent(int eventId)
        {
            _logger.LogInformation("AcceptEvent method called with eventId: {EventId}", eventId);

            // Récupérer le token d'accès à partir des en-têtes de la requête
            var accessToken = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(accessToken))
            {
                _logger.LogWarning("Access token not found in the request headers");
                return Forbid();
            }

            // Désérialiser le token JWT en utilisant System.IdentityModel.Tokens.Jwt
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken;

            try
            {
                jwtToken = handler.ReadToken(accessToken) as JwtSecurityToken;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to parse JWT token: {Error}", ex.Message);
                return BadRequest("Invalid token.");
            }

            // Récupérer le given_name de l'utilisateur à partir du payload du token
            var givenName = jwtToken?.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value;

            if (string.IsNullOrEmpty(givenName))
            {
                _logger.LogWarning("Given name not found in the token payload");
                return Forbid();
            }

            // Récupérer l'événement par ID
            var eventItem = await _eventRepo.GetByIdAsync(eventId);
            if (eventItem == null)
            {
                _logger.LogWarning("Event with ID {EventId} not found", eventId);
                return NotFound("Event not found.");
            }

            // Récupérer le prestataire associé à l'événement par son given_name
            var prestataire = await _userRepo.GetByNameAsync(givenName);
            if (prestataire == null || prestataire.RoleUser != UserRoles.Prestataire)
            {
                _logger.LogWarning("User with given name {GivenName} is not a valid Prestataire", givenName);
                return Forbid();
            }

            // Vérifier si l'utilisateur est autorisé à accepter cet événement
            if (eventItem.PrestataireId != prestataire.Id)
            {
                _logger.LogWarning("User {GivenName} is not authorized to accept event {EventId}", givenName, eventId);
                return Forbid();
            }

            // Vérifier si l'événement est assigné ou en attente (Pending)
            if (eventItem.EventStatus != EventStatus.Assigned && eventItem.EventStatus != EventStatus.Pending)
            {
                _logger.LogWarning("Event {EventId} cannot be accepted in its current state: {EventStatus}", eventId, eventItem.EventStatus);
                return BadRequest("Event cannot be accepted in its current state.");
            }

            // Mettre à jour l'état de l'événement pour refléter l'acceptation
            eventItem.EventStatus = EventStatus.Accepted;
            eventItem.PrestataireResponse = "Accepted";

            await _eventRepo.UpdateAsync(eventItem);
            await _eventRepo.SaveAsync();

            return Ok(new EventDto
            {
                Id = eventItem.Id,
                ClientId = eventItem.ClientId,
                Description = eventItem.Description,
                DateRequest = eventItem.DateRequest,
                EventStatus = eventItem.EventStatus.ToString(),
                PrestataireId = eventItem.PrestataireId,
                PrestataireName = prestataire.UserName,
                AdminName = eventItem.AdminName
            });
        }

        [Authorize]
        [HttpPost("reject/{eventId}")]
        public async Task<IActionResult> RejectEvent(int eventId)
        {
            _logger.LogInformation("RejectEvent method called with eventId: {EventId}", eventId);

            // Récupérer le token d'accès à partir des en-têtes de la requête
            var accessToken = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(accessToken))
            {
                _logger.LogWarning("Access token not found in the request headers");
                return Forbid();
            }

            // Désérialiser le token JWT en utilisant System.IdentityModel.Tokens.Jwt
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken;

            try
            {
                jwtToken = handler.ReadToken(accessToken) as JwtSecurityToken;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to parse JWT token: {Error}", ex.Message);
                return BadRequest("Invalid token.");
            }

            // Récupérer le given_name de l'utilisateur à partir du payload du token
            var givenName = jwtToken?.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value;

            if (string.IsNullOrEmpty(givenName))
            {
                _logger.LogWarning("Given name not found in the token payload");
                return Forbid();
            }

            // Récupérer l'événement par ID
            var eventItem = await _eventRepo.GetByIdAsync(eventId);
            if (eventItem == null)
            {
                _logger.LogWarning("Event with ID {EventId} not found", eventId);
                return NotFound("Event not found.");
            }

            // Récupérer le prestataire associé à l'événement par son given_name
            var prestataire = await _userRepo.GetByNameAsync(givenName);
            if (prestataire == null || prestataire.RoleUser != UserRoles.Prestataire)
            {
                _logger.LogWarning("User with given name {GivenName} is not a valid Prestataire", givenName);
                return Forbid();
            }

            // Vérifier si l'utilisateur est autorisé à rejeter cet événement
            if (eventItem.PrestataireId != prestataire.Id)
            {
                _logger.LogWarning("User {GivenName} is not authorized to reject event {EventId}", givenName, eventId);
                return Forbid();
            }

            // Vérifier si l'événement est assigné ou en attente (Pending)
            if (eventItem.EventStatus != EventStatus.Assigned && eventItem.EventStatus != EventStatus.Pending)
            {
                _logger.LogWarning("Event {EventId} cannot be rejected in its current state: {EventStatus}", eventId, eventItem.EventStatus);
                return BadRequest("Event cannot be rejected in its current state.");
            }

            // Mettre à jour l'état de l'événement pour refléter le rejet
            eventItem.EventStatus = EventStatus.Rejected;
            eventItem.PrestataireResponse = "Rejected";

            await _eventRepo.UpdateAsync(eventItem);
            await _eventRepo.SaveAsync();

            // Retourner la réponse avec les détails de l'événement mis à jour
            return Ok(new EventDto
            {
                Id = eventItem.Id,
                ClientId = eventItem.ClientId,
                Description = eventItem.Description,
                DateRequest = eventItem.DateRequest,
                EventStatus = eventItem.EventStatus.ToString(),
                PrestataireId = eventItem.PrestataireId,
                PrestataireName = prestataire.UserName,
                AdminName = eventItem.AdminName
            });
        }

        [Authorize]
        [HttpPost("complete")]
        public async Task<IActionResult> CompleteEvent(int eventId)
        {
            // Récupérer le token d'accès à partir des en-têtes de la requête
            var accessToken = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Access token not found.");
            }

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken;

            try
            {
                jwtToken = handler.ReadToken(accessToken) as JwtSecurityToken;
            }
            catch (Exception)
            {
                return BadRequest("Invalid token.");
            }

            // Récupérer le given_name de l'utilisateur à partir du payload du token
            var givenName = jwtToken?.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value;

            if (string.IsNullOrEmpty(givenName))
            {
                return Unauthorized("Given name not found in the token.");
            }

            // Récupérer l'événement par ID
            var eventItem = await _eventRepo.GetByIdAsync(eventId);
            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            // Récupérer le prestataire en fonction du given_name
            var prestataire = await _userRepo.GetByNameAsync(givenName);
            if (prestataire == null || prestataire.RoleUser != UserRoles.Prestataire)
            {
                return Forbid("You do not have permission to complete this event.");
            }

            // Vérifier si l'utilisateur est le prestataire assigné à cet événement
            if (eventItem.PrestataireId != prestataire.Id)
            {
                return Forbid("You do not have permission to complete this event.");
            }

            // Mettre à jour l'événement comme complété
            eventItem.EventStatus = EventStatus.Completed;

            await _eventRepo.UpdateAsync(eventItem);
            await _eventRepo.SaveAsync();

            return NoContent();
        }
    }
}