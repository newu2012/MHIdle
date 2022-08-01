using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataContext.Postgresql;

public static class MHIdleContextExtensions
{
    /// <summary>
    /// Adds MHIdleContext to the specified IServiceCollection. Uses the Postgresql database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">Set to override the default.</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddMHIdleContext(
        this IServiceCollection services,
        string connectionString = "")
    {
        services.AddDbContext<MHIdleContext>(options =>
        {
            if (connectionString == "")
            {
                var connectionVariables = Environment.GetEnvironmentVariables();
                connectionString =
                    $"Host={connectionVariables["POSTGRESQL_HOST"]};" +
                    $"Port={connectionVariables["POSTGRESQL_PORT"]};" +
                    $"Database={connectionVariables["POSTGRESQL_DATABASE"]};" +
                    $"Username={connectionVariables["POSTGRESQL_USERNAME"]};" +
                    $"Password={connectionVariables["POSTGRESQL_PASSWORD"]}";
            }

            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Server"));

            options.LogTo(Console.WriteLine, // Console
                new[]
                {
                    Microsoft.EntityFrameworkCore
                        .Diagnostics.RelationalEventId.CommandExecuting
                });
        });

        return services;
    }
}