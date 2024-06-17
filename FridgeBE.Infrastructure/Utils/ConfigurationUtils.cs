using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeBE.Infrastructure.Utils
{
    public class ConfigurationUtils
    {
        private readonly IConfiguration _configuration;

        public ConfigurationUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ExternalFileFolder => _configuration["ExternalFilePath:ExternalFilePath"];
        public static string ImagesFolder => _configuration["ExternalFilePath:ImagesFolder"];
    }
}