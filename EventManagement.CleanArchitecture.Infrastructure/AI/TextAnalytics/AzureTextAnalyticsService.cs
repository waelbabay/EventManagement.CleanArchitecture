using Azure.AI.TextAnalytics;
using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;
using EventManagement.CleanArchitecture.Domain.Enums;

namespace EventManagement.CleanArchitecture.Infrastructure.AI.TextAnalytics
{
    internal class AzureTextAnalyticsService : ITextAnalyticsService
    {
        private readonly TextAnalyticsClient _textAnalyticsClient;

        public AzureTextAnalyticsService(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }

        public async Task<ReviewSentiment> GetSentiment(string text)
        {
            var result = await _textAnalyticsClient.AnalyzeSentimentAsync(text);

            return result.Value.Sentiment switch
            {
                TextSentiment.Positive => ReviewSentiment.Positive,
                TextSentiment.Neutral => ReviewSentiment.Neutral,
                TextSentiment.Negative => ReviewSentiment.Negative,
                _ => throw new InvalidOperationException("Sentiment not recognized")
            };
        }
    }
}
