using AuthApp.Data;
using AuthApp.DTOs;
using AuthApp.Models;
using AuthApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Repositories
{
    public class POSRepo : IPOSRepo
    {
        private readonly AppDbContext _context;
        private readonly ILogger<POSRepo> _logger;

        public POSRepo(AppDbContext context, ILogger<POSRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsAsync()
        {
            var posWithDetails = await _context.POSs
                .Include(pos => pos.Services)
                .Include(pos => pos.Clients)
                .Include(pos => pos.Prestataires)
                .Select(pos => new POSWithDetailsDto
                {
                    POSId = pos.POSId,
                    POSName = pos.POSName,
                    POSLocation = pos.POSLocation,
                    ImageUrl = pos.ImageUrl,
                    Services = pos.Services.Select(s => new ServiceDto
                    {
                        ServiceId = s.Id,
                        ServiceName = s.Name
                    }).ToList(),
                    Clients = pos.Clients.Select(c => new UserDto
                    {
                        UserId = c.Id,
                        UserName = c.UserName,
                        RoleUser = c.RoleUser
                    }).ToList(),
                    Prestataires = pos.Prestataires.Select(p => new UserDto
                    {
                        UserId = p.Id,
                        UserName = p.UserName,
                        RoleUser = p.RoleUser
                    }).ToList()
                })
                .ToListAsync();

            return posWithDetails;
        }
        public async Task<POS> GetPOSByIdAsync(int id)
        {
            return await _context.POSs
                .Include(pos => pos.Services)
                .Include(pos => pos.Clients)
                .Include(pos => pos.Prestataires)
                .FirstOrDefaultAsync(pos => pos.POSId == id);
        }
        public async Task<List<POSWithDetailsDto>> GetAllPOSWithDetailsByAdminIdAsync(string adminId)
        {
            var posWithDetails = await _context.POSs
                .Where(pos => pos.AdminId == adminId)
                .Include(pos => pos.Services)
                .Include(pos => pos.Clients)
                .Include(pos => pos.Prestataires)
                .Select(pos => new POSWithDetailsDto
                {
                    POSId = pos.POSId,
                    POSName = pos.POSName,
                    POSLocation = pos.POSLocation,
                    ImageUrl = pos.ImageUrl,
                    Services = pos.Services.Select(s => new ServiceDto
                    {
                        ServiceId = s.Id,
                        ServiceName = s.Name
                    }).ToList(),
                    Clients = pos.Clients.Select(c => new UserDto
                    {
                        UserId = c.Id,
                        UserName = c.UserName,
                        RoleUser = c.RoleUser
                    }).ToList(),
                    Prestataires = pos.Prestataires.Select(p => new UserDto
                    {
                        UserId = p.Id,
                        UserName = p.UserName,
                        RoleUser = p.RoleUser
                    }).ToList()
                })
                .ToListAsync();

            return posWithDetails;
        }

        public async Task AddPOSAsync(POS pos)
        {
            _context.POSs.Add(pos);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePOSAsync(POS pos)
        {
            _logger.LogInformation("Starting UpdatePOSAsync for POSId: {POSId}", pos.POSId);

            // Fetch the existing POS entity from the database
            var existingPOS = await _context.POSs
                .Include(p => p.Services) // Include related data if needed
                .Include(p => p.Prestataires) // Include related data if needed
                .FirstOrDefaultAsync(p => p.POSId == pos.POSId);

            if (existingPOS == null)
            {
                _logger.LogError("POS with ID {POSId} not found", pos.POSId);
                throw new ArgumentException("POS not found");
            }

            // Update only the properties from the provided POS entity
            existingPOS.POSName = pos.POSName ?? existingPOS.POSName;
            existingPOS.POSLocation = pos.POSLocation ?? existingPOS.POSLocation;
            existingPOS.ImageUrl = pos.ImageUrl ?? existingPOS.ImageUrl;

            // Log the state of the entity before updating
            _logger.LogInformation("Updating POS with ID {POSId}. New values: POSName = {POSName}, POSLocation = {POSLocation}, ImageUrl = {ImageUrl}",
                existingPOS.POSId, existingPOS.POSName, existingPOS.POSLocation, existingPOS.ImageUrl);

            // Mark the entity as modified
            _context.POSs.Update(existingPOS);

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully updated POS with ID {POSId}", existingPOS.POSId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating POS with ID {POSId}", existingPOS.POSId);
                throw;
            }
        }
        public async Task<bool> IsPrestataireInPos(int posId, string prestataireId)
        {
            return await _context.POSPrestataires
                .AnyAsync(pp => pp.POSId == posId && pp.PrestataireId == prestataireId);
        }
        public async Task DeletePOSAsync(int id)
        {
            var pos = await GetPOSByIdAsync(id);
            if (pos != null)
            {
                _context.POSs.Remove(pos);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> IsClientAssociatedWithAdmin(string adminId, string clientId)
        {
            return await _context.POSClients
                .AnyAsync(pc => pc.AdminId == adminId && pc.ClientId == clientId);
        }
        public async Task AddClientToAdminAsync(string adminId, string clientId)
        {
            // Assurez-vous que POSId est correct et que l'objet POS existe
            var pos = await _context.POSs.FirstOrDefaultAsync(p => p.AdminId == adminId);

            if (pos == null)
            {
                throw new InvalidOperationException("No POS found for the given admin.");
            }

            var posClient = new POSClient
            {
                POSId = pos.POSId, // Associe l'ID du POS existant
                ClientId = clientId,
                AdminId = adminId
            };

            _context.POSClients.Add(posClient);
            await _context.SaveChangesAsync();
        }

    }
}