using FridgeBE.Api.Authorization;
using FridgeBE.Api.Filters;
using FridgeBE.Api.Middlewares;
using FridgeBE.Core;
using FridgeBE.Core.ValueObjects;
using FridgeBE.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FridgeBE.Api
{
    public class Startup
    {
        private IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ResultFilter));
                options.Filters.Add(typeof(ActionFilter));
            });
            services.AddHttpContextAccessor();

            //services.AddProblemDetails();

            JwtOptions jwtOptions = _configuration.GetSection("JwtOptions").Get<JwtOptions>()!;
            services.AddSingleton(jwtOptions);

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
                    {
                        jwtBearerOptions.SaveToken = true;
                        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtOptions.Issuer,
                            ValidAudience = jwtOptions.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                            RequireExpirationTime = true,
                        };
                        // handle token is revoked
                    });

            services.AddTransient<DefaultAuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddTransient<IAuthorizationHandler, PermissionHandler>();
            services.AddTransient<IAuthorizationMiddlewareResultHandler, PermissionAuthorizationMiddlewareResultHandler>();

            // TryAdd Authorization services in https://github.com/dotnet/aspnetcore/blob/c925f99cddac0df90ed0bc4a07ecda6b054a0b02/src/Security/Authorization/Core/src/AuthorizationServiceCollectionExtensions.cs#L21
            services.AddAuthorization();
            //services.AddAuthorization(a => a.InvokeHandlersAfterFailure = false);

            //services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddCoreServices(_configuration);
            services.AddInfrastructureServices(_configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            //services.AddHttpsRedirection(httpRedirectionOptions =>
            //{
            //    httpRedirectionOptions.HttpsPort = 443;
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.ConfigureExceptionHandler(env.IsDevelopment());

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints((IEndpointRouteBuilder endpoints) =>
            {
                endpoints.MapControllers();
                //endpoints.MapIdentityApi<IdentityUser>();
            });
        }
    }
}