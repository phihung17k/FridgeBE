using FridgeBE.Infrastructure;
using FridgeBE.Core;
using FridgeBE.Api.Middleware;

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

            //services.AddProblemDetails();

            services.AddCoreServices(Configuration);
            services.AddInfrastructureServices(Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureExceptionHandler(env.IsDevelopment());
            //app.UseHsts();
            //if (!env.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}