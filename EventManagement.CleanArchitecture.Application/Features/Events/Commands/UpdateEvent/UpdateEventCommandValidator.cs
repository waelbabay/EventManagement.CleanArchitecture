using FluentValidation;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.UpdateEvent
{
    internal class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(p => p.Speaker)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
        }
    }
}