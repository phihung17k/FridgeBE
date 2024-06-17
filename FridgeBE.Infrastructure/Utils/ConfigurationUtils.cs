using Microsoft.Extensions.Configuration;

namespace FridgeBE.Infrastructure.Utils
{
    public class ConfigurationUtils
    {
        private static IConfiguration? _configuration;

        public static void Init(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ExternalFileFolder => _configuration?["ExternalFilePath:ExternalFilePath"]!;
        public static string ImagesFolder => _configuration?["ExternalFilePath:ImagesFolder"]!;
    }
}