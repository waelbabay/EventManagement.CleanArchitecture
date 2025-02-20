using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {
    }
}
