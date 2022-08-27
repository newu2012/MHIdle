using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace DataContext.Postgresql;

public static class MHIdleContextExtensions
{
    /// <summary>
    ///     Adds MHIdleContext to the specified IServiceCollection. Uses the Postgresql database provider.
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
                var m = Regex.Match(Environment.GetEnvironmentVariable("DATABASE_URL")!,
                    @"postgres://(.*):(.*)@(.*):(.*)/(.*)");
                options.UseNpgsql(
                    $"Server={m.Groups[3]};Port={m.Groups[4]};User Id={m.Groups[1]};Password={m.Groups[2]};Database={m.Groups[5]};sslmode=Prefer;Trust Server Certificate=true",
                    b => b.MigrationsAssembly("Server"));
            }

            options.LogTo(Console.WriteLine, // Console
                new[]
                {
                    RelationalEventId.CommandExecuting
                });
        });

        return services;
    }
}