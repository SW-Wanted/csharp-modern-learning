using _02_Logging.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace _02_Logging
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .Enrich.FromLogContext()
               .WriteTo.Console()
               .WriteTo.File("logs/myapp.log", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            using IHost host = Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<App>();
                    services.AddSingleton<LoggingDemoService>();
                }).Build();

            await host.Services.GetRequiredService<App>().RunAsync();
        }
    }
}
