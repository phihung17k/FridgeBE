using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;
using FridgeBE.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Entities;

namespace FridgeBE.Infrastructure
{
    public static class ConfigurationServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContextPool<ApplicationDbContext>(option =>
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseMySql(configuration.GetConnectionString("Fridge"), ServerVersion.Parse("8.4.0"), sqlOptionsBuilder =>
                {
                    sqlOptionsBuilder.EnableRetryOnFailure(maxRetryCount: 2);
                    //sqlOptionsBuilder.MigrationsAssembly(nameof(FridgeBE.Infrastructure));
                });

                option.UseLoggerFactory(LoggerFactory.Create(configure => configure.AddConsole()));
                option.LogTo(Console.WriteLine, LogLevel.Debug, DbContextLoggerOptions.DefaultWithLocalTime);
                option.EnableSensitiveDataLogging();
                option.EnableDetailedErrors();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIngredientService, IngredientService>();

            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            services.AddScoped<IPasswordHasher<UserAccount>, PasswordHasher<UserAccount>>();
        }
    }
}