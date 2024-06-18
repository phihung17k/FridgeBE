using Microsoft.AspNetCore.Http;

namespace FridgeBE.Infrastructure.Utils
{
    public class FileUtils
    {
        private static readonly List<string> _imageExtensions = new List<string>
        {
            ".apng",
            ".avif",
            ".gif",
            ".jpg",
            ".jpeg",
            ".jfif",
            ".pjpeg",
            ".pjp",
            ".png",
            ".svg",
            ".webp",
            ".bmp",
            ".ico",
            ".cur",
            ".tif",
            ".tiff"
        };

        public static List<string> ImageExtensions = _imageExtensions;

        public static bool ValidateFileType(IFormFile file)
        {
            // check supported content type
            if (file.ContentType.Contains("image"))
            {
                // check extension
                string extension = Path.GetExtension(file.FileName);
                return _imageExtensions.Contains(extension);
            }

            return false;
        }
    }
}