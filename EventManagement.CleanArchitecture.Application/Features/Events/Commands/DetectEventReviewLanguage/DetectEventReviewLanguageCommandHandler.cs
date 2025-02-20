using MediatR;
using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.DetectEventReviewLanguage
{
    public class DetectEventReviewLanguageCommandHandler : IRequestHandler<DetectEventReviewLanguageCommand, string>
    {
        private readonly ILanguageService _languageDetector;

        public DetectEventReviewLanguageCommandHandler(ILanguageService languageDetector)
        {
            _languageDetector = languageDetector;
        }

        public async Task<string> Handle(DetectEventReviewLanguageCommand request, CancellationToken cancellationToken)
        {
            return await _languageDetector.DetectLanguage(request.Review);
        }
    }
}
