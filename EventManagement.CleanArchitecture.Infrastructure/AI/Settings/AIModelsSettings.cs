namespace EventManagement.CleanArchitecture.Infrastructure.AI.NewFolder
{
    public class AIModelsSettings
    {
        public string LanguageServiceKey { get; set; } = string.Empty;
        public string LanguageServiceEndpoint { get; set; } = string.Empty;
        public string MLLanguageModelPath { get; set; } = string.Empty;
        public string OpenAiImageModelName { get; set; } = string.Empty;
        public string OpenAiServiceKey { get; set; } = string.Empty;
        public string AzureOpenAITextToImageDeploymentName { get; set; } = string.Empty;
        public string AzureOpenAITextToImageEndpoint { get; set; } = string.Empty;
        public string AzureOpenAITextToImageKey { get; set; } = string.Empty;

    }
}
