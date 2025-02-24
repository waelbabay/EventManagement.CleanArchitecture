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

            var imageUrl = await _textToImageService.GenerateImageAsync(prompt, 1792, 1024);

            string fileName = $"{Guid.NewGuid()}.png";

            return await _fileDownloader.DownloadFileToFolder(imageUrl, $"{Directory.GetCurrentDirectory()}/images", fileName);
        }


    }
}
