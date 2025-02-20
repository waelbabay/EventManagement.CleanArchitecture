using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.DetectEventReviewLanguage
{
    public class DetectEventReviewLanguageCommand : IRequest<string>
    {
        public string Review { get; set; } = string.Empty;
    }
}
