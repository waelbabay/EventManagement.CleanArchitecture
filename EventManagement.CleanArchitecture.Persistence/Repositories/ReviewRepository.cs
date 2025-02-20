using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.CleanArchitecture.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(EventManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Review>> GetReviewsByEventId(Guid eventId)
        {
           return await _dbContext.Reviews.Where(r => r.EventId == eventId).ToListAsync();
        }
    }
}
