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
    }
}