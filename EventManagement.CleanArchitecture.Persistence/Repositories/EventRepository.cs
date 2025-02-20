using Microsoft.EntityFrameworkCore;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            return !await _dbContext.Events.AnyAsync(e => e.Name == name && e.Date.Date == eventDate.Date);
        }
    }
}
