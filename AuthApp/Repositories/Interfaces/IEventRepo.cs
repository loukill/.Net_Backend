using AuthApp.Models;

namespace AuthApp.Services.Interfaces
{
    public interface IEventRepo
    {
        Task<IEnumerable<Events>> GetAllAsync();
        Task<Events> GetByIdAsync(int id);
        Task AddAsync(Events eventItem);
        Task UpdateAsync(Events eventItem);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
