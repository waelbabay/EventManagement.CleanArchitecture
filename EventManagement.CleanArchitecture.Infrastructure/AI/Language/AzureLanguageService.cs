using Azure.AI.TextAnalytics;
using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;

namespace EventManagement.CleanArchitecture.Infrastructure.AI.Language
{
    public class AzureLanguageService : ILanguageService
    {
        private readonly TextAnalyticsClient _textAnalyticsClient;

        public AzureLanguageService(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }

        public async Task<string> DetectLanguage(string text)
        {
            DetectedLanguage detectedLanguage = await _textAnalyticsClient.DetectLanguageAsync(text);

            return detectedLanguage.Name;
        }
    }
}
