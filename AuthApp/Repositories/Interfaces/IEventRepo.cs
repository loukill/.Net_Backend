using AuthApp.Models;

namespace AuthApp.Services.Interfaces
{
    public interface IEventRepo
    {
        Task<List<Events>> GetAllAsync();
        Task<Events> GetByIdAsync(int id);
        Task<IEnumerable<Events>> GetEventsByUserIdAsync(string userId);
        Task AddAsync(Events eventItem);
        Task UpdateAsync(Events eventItem);
        Task DeleteAsync(int id);
        Task SaveAsync();
        Task AcceptEventAsync(int eventId, string prestataireId);
        Task RejectEventAsync(int eventId, string prestataireId);
        Task CompleteEventAsync(int eventId, string prestataireId);
    }
}
