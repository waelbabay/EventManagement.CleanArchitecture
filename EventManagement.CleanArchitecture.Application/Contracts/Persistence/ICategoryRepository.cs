using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includeHistory);
    }
}
