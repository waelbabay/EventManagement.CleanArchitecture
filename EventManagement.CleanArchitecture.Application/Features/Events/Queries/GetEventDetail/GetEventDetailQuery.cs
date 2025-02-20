using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public Guid EventId { get; set; }
    }
}
