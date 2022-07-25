using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Builder;
using ToyRobot.Domain;

namespace ToyRobot.Simulator
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = builder.Build();

            services.AddLogging();

            services.AddSingleton(configuration);

            var tableTop = configuration.GetSection("Tabletop").Get<Tabletop>();

            if (tableTop == null)
            {
                throw new ArgumentException("Tabletop is not configured");
            }

            services.AddSingleton<IRobot, Robot>(r => new Robot(tableTop));
            services.AddSingleton<EntryPoint>();

            return services;
        }
    }
}
