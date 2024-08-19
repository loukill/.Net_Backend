using AuthApp.Constants;
using AuthApp.Data;
using AuthApp.Models;
using AuthApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AuthApp.Services
{
    public class EventRepo : IEventRepo
    {
        private readonly AppDbContext _context;

        public EventRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Events>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Events> GetByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task AddAsync(Events eventItem)
        {
            await _context.Events.AddAsync(eventItem);
        }

        public async Task UpdateAsync(Events eventItem)
        {
            _context.Events.Update(eventItem);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem != null)
            {
                _context.Events.Remove(eventItem);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task AcceptEventAsync(int eventId, string prestataireId)
        {
            var eventItem = await _context.Events.FindAsync(eventId);
            if (eventItem != null && eventItem.PrestataireId == prestataireId)
            {
                eventItem.EventStatus = EventStatus.Accepted;
                eventItem.PrestataireResponse = "Accepted";
                await _context.SaveChangesAsync();
            }
        }

        public async Task RejectEventAsync(int eventId, string prestataireId)
        {
            var eventItem = await _context.Events.FindAsync(eventId);
            if (eventItem != null && eventItem.PrestataireId == prestataireId)
            {
                eventItem.EventStatus = EventStatus.Rejected;
                eventItem.PrestataireResponse = "Rejected";
                await _context.SaveChangesAsync();
            }
        }
        public async Task CompleteEventAsync(int eventId, string prestataireId)
        {
            var eventItem = await _context.Events.FindAsync(eventId);
            if (eventItem != null && eventItem.PrestataireId == prestataireId)
            {
                eventItem.EventStatus = EventStatus.Completed;
                eventItem.CompletionDate = DateTime.UtcNow; // Optional: Record the completion date
                await _context.SaveChangesAsync();
            }
        }
    }
}