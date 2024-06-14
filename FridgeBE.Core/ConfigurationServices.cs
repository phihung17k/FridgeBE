using FridgeBE.Core.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FridgeBE.Core
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(mapConfig => mapConfig.AddProfile(new AutoMapperProfile()));
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
