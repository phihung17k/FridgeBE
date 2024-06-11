using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Repositories;
using FridgeBE.Infrastructure;

namespace FridgeBE.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddInfrastructureServices(Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}