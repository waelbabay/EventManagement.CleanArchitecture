namespace EventManagement.CleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IImageService
    {
        Task<string> GenerateImageFromText(string text);
    }
}
