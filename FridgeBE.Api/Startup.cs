using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

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

            //services.AddDbContextPool<ApplicationDbContext>(option =>
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseMySql(Configuration.GetConnectionString("Fridge"), ServerVersion.Parse("8.4.0"), sqlOptionsBuilder =>
                {
                    //sqlOptionsBuilder.EnableRetryOnFailure(maxRetryCount: 1);
                    //sqlOptionsBuilder.
                    //sqlOptionsBuilder.MigrationsAssembly("FridgeBE.Infrastructure");
                });
                //option.UseLoggerFactory(LoggerFactory.Create(configure => configure.AddConsole()));
                //option.LogTo(Console.WriteLine, LogLevel.Debug, DbContextLoggerOptions.DefaultWithLocalTime);
                //option.EnableSensitiveDataLogging();
                //option.EnableDetailedErrors();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}