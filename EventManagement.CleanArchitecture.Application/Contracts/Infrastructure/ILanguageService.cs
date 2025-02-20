namespace EventManagement.CleanArchitecture.Application.Contracts.Infrastructure
{
    public interface ILanguageService
    {
        Task<string> DetectLanguage(string text);
    }
}
