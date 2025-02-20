using AutoMapper;
using MediatR;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Application.Exceptions;
using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event? eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            if(eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId.ToString());
            }

            var validator = new UpdateEventCommandValidator();

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsync(eventToUpdate);
        }
    }
}
