using Microsoft.ML;
using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;
using EventManagement.CleanArchitecture.Infrastructure.AI.NewFolder;
using static EventManagement_CleanArchitecture_Infrastructure.LanguageDetectorMLModel;

namespace EventManagement.CleanArchitecture.Infrastructure.AI.Language
{
    public class MLLanguageService : ILanguageService
    {
        private readonly AIModelsSettings _aIModelsSettings;
        public MLLanguageService(AIModelsSettings aIModelsSettings)
        {
            _aIModelsSettings = aIModelsSettings;
        }

        public async Task<string> DetectLanguage(string text)
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(_aIModelsSettings.MLLanguageModelPath, out var _);

            var input = new ModelInput()
            {
                Message = text
            };

            var predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
            return await Task.FromResult(predictionEngine.Predict(input).PredictedLabel);
        }
    }
}
