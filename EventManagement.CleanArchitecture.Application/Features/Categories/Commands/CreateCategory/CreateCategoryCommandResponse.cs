using FluentValidation.Results;
using EventManagement.CleanArchitecture.Application.Responses;

namespace EventManagement.CleanArchitecture.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse(bool success, string message) : base(success, message)
        {
        }

        public CreateCategoryCommandResponse(List<ValidationFailure> validationFailures) : base(validationFailures)
        {
        }

        public CreateCategoryCommandResponse(CategoryDto category) : base()
        {
            Category = category;
        }

        public CategoryDto? Category { get; set; }
    }
}