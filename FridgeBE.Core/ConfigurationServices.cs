using FridgeBE.Core.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FridgeBE.Core
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(mapConfig => mapConfig.AddProfile(new AutoMapperProfile()));

            return services;
        }
    }
}
