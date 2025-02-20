using FluentValidation;

namespace EventManagement.CleanArchitecture.Application.Features.Categories.Commands.CreateCategory
{
    internal class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The category name is required !");
        }
    }
}
