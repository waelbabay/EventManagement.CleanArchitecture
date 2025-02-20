using EventManagement.CleanArchitecture.Infrastructure.Interfaces;

namespace EventManagement.CleanArchitecture.Infrastructure
{
    internal class FileDownloader : IFileDownloader
    {
        public async Task<string> DownloadFileToFolder(string fileUrlSource, string destinationFolderPath, string fileName)
        {
            string filePath = $"{destinationFolderPath}/{fileName}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(fileUrlSource);
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }

            return filePath;
        }
    }
}
