using Azure;
using Azure.AI.TextAnalytics;
using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;
using EventManagement.CleanArchitecture.Infrastructure.AI.Image;
using EventManagement.CleanArchitecture.Infrastructure.AI.Language;
using EventManagement.CleanArchitecture.Infrastructure.AI.NewFolder;
using EventManagement.CleanArchitecture.Infrastructure.AI.TextAnalytics;
using EventManagement.CleanArchitecture.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;

namespace EventManagement.CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILanguageService, AzureLanguageService>();
            services.AddScoped<ITextAnalyticsService, AzureTextAnalyticsService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IFileDownloader, FileDownloader>();

            services.Configure<AIModelsSettings>(configuration.GetSection("AIModelsSettings"));

            services.AddScoped(provider =>
            {
                return provider.GetRequiredService<IOptions<AIModelsSettings>>().Value;
            });

            services.AddScoped(provider =>
            {
                AIModelsSettings aiModelSettings = provider.GetRequiredService<AIModelsSettings>();
                return new TextAnalyticsClient(new Uri(aiModelSettings.LanguageServiceEndpoint), new AzureKeyCredential(aiModelSettings.LanguageServiceKey));
            });

            AIModelsSettings aiModelSettings = services.BuildServiceProvider().GetRequiredService<AIModelsSettings>();
            services.AddKernel().AddAzureOpenAITextToImage(aiModelSettings.AzureOpenAITextToImageDeploymentName, aiModelSettings.AzureOpenAITextToImageEndpoint, aiModelSettings.AzureOpenAITextToImageKey);

            return services;
        }
    }
}
