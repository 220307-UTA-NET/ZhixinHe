using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EF.Shared;

public static class NorthwindContextExtensions
{
    public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Northwind.db");

        services.AddDbContext<NorthwindContext>(FileOptions => FileOptions.UseSqlite($"Data Source={databasePath}"));
        return services;
    }
}