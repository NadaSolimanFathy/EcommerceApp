using Core.Context;
using InfraStructure;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Helper
{
    public class ApplySeeding
    {


        public static async Task ApplySeedingAsync(WebApplication app)
        {



            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreDbContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                    logger.LogError(ex.Message);
                }

            }
        }
    }
}
