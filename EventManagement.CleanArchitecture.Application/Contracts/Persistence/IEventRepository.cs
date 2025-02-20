using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
