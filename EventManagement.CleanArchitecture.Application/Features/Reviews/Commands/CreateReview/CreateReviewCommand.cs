using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<Guid>
    {
        public string Author { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Guid EventId { get; set; }
    }
}
