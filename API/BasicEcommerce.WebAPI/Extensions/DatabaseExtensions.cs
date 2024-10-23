using BasicEcommerce.Infrastructure.Context;
using BasicEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicEcommerce.WebAPI.Extensions;
public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetRequiredService<BasicEcommerceDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating or initializing the database.");
        }

    }

    private static async Task SeedAsync(BasicEcommerceDbContext context)
    {
        await SeedProductAsync(context);
    }

    private static async Task SeedProductAsync(BasicEcommerceDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }
    }
}
