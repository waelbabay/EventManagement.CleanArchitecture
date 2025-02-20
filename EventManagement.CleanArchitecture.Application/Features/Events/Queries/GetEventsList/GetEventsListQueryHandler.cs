using AutoMapper;
using MediatR;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList
{
    internal class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public GetEventsListQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var events = (await _eventRepository.ListAllAsync()).OrderBy(e => e.Date);

            return _mapper.Map<List<EventListVm>>(events);
        }
    }
}
