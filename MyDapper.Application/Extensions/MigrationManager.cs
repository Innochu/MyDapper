﻿using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDapper.Application.Service.Implementation;
using MyDapper.Application.Service.Interface;
using MyDapper.Persistence.Migrations;
using MyDapper.Persistence.Repository;
using MyDapper.Persistence.Repository.Interface;
using MyDapper.Persistence.Repository.RepositoryManagerFolder;
using System.Reflection;

namespace MyDapper.Application.Extensions
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();


                try
                {
                    databaseService.CreateDatabase("CompanyEmployeeDapper");
                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch (Exception ex)
                {

                  
                    // Handle the exception as needed, without logging
                    throw;
                }

                return app;
            }
        }

        public static void ConfigureFluentMigrator(this IServiceCollection services, IConfiguration configuration)
                                                     => services.AddLogging(c => c.AddFluentMigratorConsole())
                                                        .AddFluentMigratorCore().ConfigureRunner(c => c.AddSqlServer2016()
                                                        .WithGlobalConnectionString(configuration.GetConnectionString("sqlConnection"))
                                                        .ScanIn(typeof(InitialTables_202402010221).Assembly).For.Migrations());




        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
                                                  services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
                                                  services.AddScoped<IServiceManager, ServiceManager>();
    }

   
}
