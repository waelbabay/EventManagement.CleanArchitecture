using EventManagement.CleanArchitecture.Domain.Enums;

namespace EventManagement.CleanArchitecture.Application.Contracts.Infrastructure
{
    public interface ITextAnalyticsService
    {
        Task<ReviewSentiment> GetSentiment(string text);
    }
}
