using EventManagement.CleanArchitecture.Application.Contracts.Infrastructure;
using EventManagement.CleanArchitecture.Infrastructure.Interfaces;
using Microsoft.SemanticKernel.TextToImage;

namespace EventManagement.CleanArchitecture.Infrastructure.AI.Image
{
    internal class ImageService : IImageService
    {
        private readonly ITextToImageService _textToImageService; 
        private readonly IFileDownloader _fileDownloader; 

        public ImageService(ITextToImageService textToImageService, IFileDownloader fileDownloader)
        {
            _textToImageService = textToImageService;
            _fileDownloader = fileDownloader;
        }

        public async Task<string> GenerateImageFromText(string description)
        {
            string prompt = $@"Create a photo-realistic and visually appealing image
                            for a website that specializes in organizing events.
                            The event to wich I want to generate the image has this description: {description}.";

            var imageUrl = "https://dalleprodsec.blob.core.windows.net/private/images/0f8663d4-78a9-41c0-bc12-56565d7d9825/generated_00.png?se=2025-02-15T19%3A59%3A02Z&sig=1kT%2FEvMAfMEAexgJ5xx7tL950FyWiFIGqe3Sow9d3gY%3D&ske=2025-02-20T14%3A49%3A32Z&skoid=e52d5ed7-0657-4f62-bc12-7e5dbb260a96&sks=b&skt=2025-02-13T14%3A49%3A32Z&sktid=33e01921-4d64-4f8c-a055-5bdaffd5e33d&skv=2020-10-02&sp=r&spr=https&sr=b&sv=2020-10-02";// await _textToImageService.GenerateImageAsync(prompt, 1792, 1024);

            string fileName = $"{Guid.NewGuid()}.png";

            return await _fileDownloader.DownloadFileToFolder(imageUrl, $"{Directory.GetCurrentDirectory()}/images", fileName);
        }


    }
}
