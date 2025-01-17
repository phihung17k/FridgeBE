﻿using FridgeBE.Api.Authorization;
using FridgeBE.Api.Filters;
using FridgeBE.Api.Middlewares;
using FridgeBE.Core;
using FridgeBE.Core.ValueObjects;
using FridgeBE.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
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
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, (JwtBearerOptions options) =>
                    {
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
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
            services.AddSwaggerGen((SwaggerGenOptions options) =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

            services.AddCors((CorsOptions options) =>
            {
                options.AddDefaultPolicy((CorsPolicyBuilder policy) =>
                {
                    //policy.WithOrigins("http://localhost:9877")
                    //      .AllowAnyHeader()
                    //      .AllowAnyMethod();
                    policy.SetIsOriginAllowed(origin => true/*new Uri(origin).Host == "localhost"*/);
                });
            });
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

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints((IEndpointRouteBuilder endpoints) =>
            {
                endpoints.MapControllers();
                //endpoints.MapIdentityApi<IdentityUser>();
            });

            // init storage
            app.InitCategoryStorage();
        }
    }
}