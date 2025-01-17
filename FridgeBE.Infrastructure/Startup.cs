using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Interfaces.IUtils;
using FridgeBE.Core.Services;
using FridgeBE.Infrastructure.Data;
using FridgeBE.Infrastructure.Repositories;
using FridgeBE.Infrastructure.Services;
using FridgeBE.Infrastructure.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FridgeBE.Infrastructure
{
    public static class Startup
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContextPool<ApplicationDbContext>(option =>
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseMySql(configuration.GetConnectionString("Fridge"), ServerVersion.Parse("8.0.40"), sqlOptionsBuilder =>
                {
                    //sqlOptionsBuilder.EnableRetryOnFailure(maxRetryCount: 2);
                    //sqlOptionsBuilder.MigrationsAssembly(nameof(FridgeBE.Infrastructure));
                });

                option.UseLoggerFactory(LoggerFactory.Create(configure => configure.AddConsole()));
                option.LogTo(Console.WriteLine, LogLevel.Debug, DbContextLoggerOptions.DefaultWithLocalTime);

                IWebHostEnvironment env = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();
                if (env.IsDevelopment() || env.IsProduction())
                {
                    option.EnableSensitiveDataLogging();
                    option.EnableDetailedErrors();
                }
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<ICategoryRepository, CategoryResponsitory>();

            services.AddScoped<IPasswordHasher<UserAccount>, PasswordHasher<UserAccount>>();

            services.AddTransient<ITokenUtils, TokenUtils>();
        }

        public static void InitCategoryStorage(this IApplicationBuilder _)
        {
            //CategoryStorageService.Initialize(CategoryStorage.GetAllCategories());
            CategoryStorageService.GetCategoryById = CategoryStorage.GetCategoryById;
        }
    }
}