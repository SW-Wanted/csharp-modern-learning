using _02_Logging.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _02_Logging
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<App>();
                    services.AddSingleton<LoggingDemoService>();
                }).Build();

            await host.Services.GetRequiredService<App>().RunAsync();
        }
    }
}
