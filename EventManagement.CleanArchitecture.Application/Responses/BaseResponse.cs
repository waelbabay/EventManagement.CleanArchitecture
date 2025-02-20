using FluentValidation.Results;

namespace EventManagement.CleanArchitecture.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(List<ValidationFailure> validationFailures)
        {
            Success = false;
            ValidationErrors.AddRange(validationFailures.Select(f => f.ErrorMessage));
        }

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}
