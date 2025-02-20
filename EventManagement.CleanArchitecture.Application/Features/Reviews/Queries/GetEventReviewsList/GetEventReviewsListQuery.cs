using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Reviews.Queries.GetEventReviewsList
{
    public class GetEventReviewsListQuery : IRequest<List<EventReviewsListVm>>
    {
        public Guid EventId { get; set; }
    }
}
