using AutoMapper;
using FluentValidation.Results;
using MediatR;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Application.Exceptions;
using EventManagement.CleanArchitecture.Domain.Entities;
using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.CreateEvent
{
    internal class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IImageService _imageService;

        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IEventRepository eventRepository, IImageService imageService, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _imageService = imageService;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            CreateEventCommandValidator validator = new CreateEventCommandValidator(_eventRepository);
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            Event @event = _mapper.Map<Event>(request);

            @event.ImageUrl = await _imageService.GenerateImageFromText(request.Description);

            @event = await _eventRepository.AddAsync(@event);

            return @event.EventId;
        }
    }
}
