using FluentValidation;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(DateTime.Now);

            RuleFor(p => p)
                .MustAsync(EventNameAndDateUnique).WithMessage("An event with the same name and date already exists.");
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand request, CancellationToken token)
        {
            return await _eventRepository.IsEventNameAndDateUnique(request.Name, request.Date);
        }
    }
}
