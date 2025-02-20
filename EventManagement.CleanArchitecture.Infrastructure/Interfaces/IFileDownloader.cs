namespace EventManagement.CleanArchitecture.Infrastructure.Interfaces
{
    internal interface IFileDownloader
    {
        Task<string> DownloadFileToFolder(string fileUrlSource, string destinationFolderPath, string fileName);
    }
}
