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

namespace AuthApp.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepo _eventRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILogger<EventController> _logger;

        public EventController(IEventRepo eventRepo, IUserRepo userRepo, ILogger<EventController> logger)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var events = await _eventRepo.GetAllAsync(); // Retrieve all events

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

        [Authorize]
        [HttpPost("createrequest")]
        public async Task<IActionResult> CreateServiceRequestAsync([FromBody] EventRequest request)
        {
            if (request == null)
                return BadRequest("Request body cannot be null.");

            if (string.IsNullOrEmpty(request.Description))
                return BadRequest("The description field is required.");

            string? clientId = null;

            // Récupère le GivenName du token
            var givenName = User.FindFirst(ClaimTypes.GivenName)?.Value;

            // Si le GivenName est présent, essayons de récupérer le clientId
            if (!string.IsNullOrEmpty(givenName))
            {
                var client = await _userRepo.GetByNameAsync(givenName);
                if (client != null && client.RoleUser == UserRoles.Client.ToString())
                {
                    clientId = client.Id;
                }
            }

            // Si clientId n'est pas trouvé ou GivenName est absent, utiliser clientName fourni
            if (string.IsNullOrEmpty(clientId))
            {
                if (string.IsNullOrEmpty(request.ClientName))
                    return BadRequest("Client name must be provided if client is not authenticated.");

                var client = await _userRepo.GetByNameAsync(request.ClientName);
                if (client == null || client.RoleUser != UserRoles.Client.ToString())
                    return BadRequest("Invalid client name.");

                clientId = client.Id;
            }

            // Validez l'entrée : soit PrestataireName soit AdminName doit être fourni
            if (string.IsNullOrEmpty(request.PrestataireName) && string.IsNullOrEmpty(request.AdminName))
                return BadRequest("Either PrestataireName or AdminName must be provided.");

            if (!string.IsNullOrEmpty(request.PrestataireName) && !string.IsNullOrEmpty(request.AdminName))
                return BadRequest("You can only assign the event to either a Prestataire or an Admin, not both.");

            // Recherchez l'utilisateur par nom
            string? prestataireId = null;
            string? adminId = null;

            if (!string.IsNullOrEmpty(request.PrestataireName))
            {
                var prestataire = await _userRepo.GetByNameAsync(request.PrestataireName);
                if (prestataire == null || prestataire.RoleUser != UserRoles.Prestataire.ToString())
                    return BadRequest("Invalid prestataire name.");
                prestataireId = prestataire.Id;
            }
            if (!string.IsNullOrEmpty(request.AdminName))
            {
                var admin = await _userRepo.GetByNameAsync(request.AdminName);
                if (admin == null || admin.RoleUser != UserRoles.Admin.ToString())
                    return BadRequest("Invalid admin name.");
                adminId = admin.Id;
            }

            DateTime eventDateTime = request.DateTime ?? DateTime.Now;

            var newRequest = new Events
            {
                ClientId = clientId,
                Description = request.Description,
                DateRequest = eventDateTime,
                EventStatus = EventStatus.Pending,
                PrestataireId = prestataireId,
                AdminId = adminId,
                PrestataireName = request.PrestataireName,
                AdminName = request.AdminName
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
            if (prestataire == null || prestataire.RoleUser != "Prestataire")
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
            if (prestataire == null || prestataire.RoleUser != "Prestataire")
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

            // Désérialiser le token JWT pour récupérer le given_name
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
            if (prestataire == null || prestataire.RoleUser != "Prestataire")
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