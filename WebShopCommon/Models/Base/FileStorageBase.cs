namespace WebShopCommon.Models.Base
{
    public abstract class FileStorageBase
    {
        public string? PhysicalPath { get; set; }
        public string? DownloadUrl { get; set; }
        public string? FileExtension { get; set; }
        public string? FileName { get; set; }
    }
}
