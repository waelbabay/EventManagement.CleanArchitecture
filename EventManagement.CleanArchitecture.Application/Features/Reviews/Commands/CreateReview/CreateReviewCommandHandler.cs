using AutoMapper;
using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;
using EventManagement.CleanArchitecture.Domain.Entities;
using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Reviews.Commands.CreateReview
{
    internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;
        private readonly ITextAnalyticsService _textAnalyticsService;
        private readonly ILanguageService _languageDetector;

        public CreateReviewCommandHandler(
            IMapper mapper, 
            IReviewRepository reviewRepository, 
            ITextAnalyticsService textAnalyticsService, 
            ILanguageService languageDetector)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _textAnalyticsService = textAnalyticsService;
            _languageDetector = languageDetector;
        }

        public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            Review review = _mapper.Map<Review>(request);

            review.Sentiment = await _textAnalyticsService.GetSentiment(request.Comment);
            review.Language = await _languageDetector.DetectLanguage(request.Comment);

            review = await _reviewRepository.AddAsync(review);

            return review.ReviewId;
        }
    }
}
