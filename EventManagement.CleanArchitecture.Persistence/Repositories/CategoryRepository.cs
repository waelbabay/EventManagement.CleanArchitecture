using Microsoft.EntityFrameworkCore;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EventManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includeHistory)
        {
            List<Category> categories = await _dbContext.Categories.Include(c => c.Events).ToListAsync();

            if (!includeHistory)
            {
                categories.ForEach(c => c.Events = c.Events?.Where(e => e.Date.Date >= DateTime.Today).ToList());
            }

            return categories;
        }
    }
}
