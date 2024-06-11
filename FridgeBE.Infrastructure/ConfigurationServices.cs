﻿using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;
using FridgeBE.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FridgeBE.Infrastructure
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(option =>
            //services.AddDbContext<ApplicationDbContext>(option =>
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
            services.AddScoped<IIngredientRepository, IngredientRepository>();


            return services;
        }
    }
}