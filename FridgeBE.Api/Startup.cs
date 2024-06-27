using FridgeBE.Infrastructure;
using FridgeBE.Core;
using FridgeBE.Api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using FridgeBE.Infrastructure.Data;

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions => Configuration.Bind("JwtSettings", jwtBearerOptions))
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, cookieAuthenticationOptions => Configuration.Bind("CookieSettings", cookieAuthenticationOptions));

            services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints((IEndpointRouteBuilder endpoints) =>
            {
                endpoints.MapControllers();
                endpoints.MapIdentityApi<IdentityUser>();
            });
        }
    }
}