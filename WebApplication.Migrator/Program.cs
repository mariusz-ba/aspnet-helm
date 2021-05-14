using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using WebApplication.Infrastructure;

namespace WebApplication.Migrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = GetConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql(configuration.GetConnectionString("Database"));

            await using var context = new ApplicationContext(optionsBuilder.Options);

            var migrations = await context.Database.GetPendingMigrationsAsync();
            if (migrations.Any())
            {
                Console.WriteLine("Applying migrations...");
                
                await context.Database.MigrateAsync();
                
                Console.WriteLine("Migrations applied");
            }
            else
            {
                Console.WriteLine("All migrations already applied");
            }
        }

        private static IConfiguration GetConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configurationBuilder = new ConfigurationBuilder();

            if (env == "Development")
            {
                configurationBuilder
                    .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "migratorSettings.json"));
            }
            else
            {
                configurationBuilder
                    .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                    .AddJsonFile(Path.Combine(AppContext.BaseDirectory, $"appsettings.{env}.json"), true)
                    .AddEnvironmentVariables();
            }

            return configurationBuilder.Build();
        }
    }
}