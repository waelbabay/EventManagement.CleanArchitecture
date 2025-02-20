using AutoMapper;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Reviews.Queries.GetEventReviewsList
{
    internal class GetEventReviewsListQueryHandler : IRequestHandler<GetEventReviewsListQuery, List<EventReviewsListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public GetEventReviewsListQueryHandler(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<List<EventReviewsListVm>> Handle(GetEventReviewsListQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.GetReviewsByEventId(request.EventId);

            return _mapper.Map<List<EventReviewsListVm>>(reviews);
        }
    }
}
