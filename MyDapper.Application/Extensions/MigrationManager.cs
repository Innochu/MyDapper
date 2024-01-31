using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyDapper.Persistence.Repository;


namespace MyDapper.Application.Extensions
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<Database>();

                try
                {
                    databaseService.CreateDatabase("CompanyEmployeeDapper");
                }
                catch (Exception ex)
                {
                    // Handle the exception as needed, without logging
                    throw;
                }

                return app;
            }
        }

}
