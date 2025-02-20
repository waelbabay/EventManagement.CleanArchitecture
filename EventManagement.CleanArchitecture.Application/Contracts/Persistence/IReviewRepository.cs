using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Application.Contracts.Persistence
{
    public interface IReviewRepository : IAsyncRepository<Review>
    {
        Task<IReadOnlyList<Review>> GetReviewsByEventId(Guid eventId);
    }
}
