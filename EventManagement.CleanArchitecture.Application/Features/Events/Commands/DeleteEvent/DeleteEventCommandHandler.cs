using MediatR;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            Event? eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

            await _eventRepository.DeleteAsync(eventToDelete);
        }
    }
}
