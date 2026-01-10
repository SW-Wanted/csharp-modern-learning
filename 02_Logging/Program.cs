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
                .ConfigureLogging((context, logging)=>
                {
                    logging.ClearProviders();

                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        logging.AddSimpleConsole(options =>
                        {
                            options.IncludeScopes = true;
                            options.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ";
                            options.SingleLine = false;
                        });
                        logging.SetMinimumLevel(LogLevel.Trace);
                    }
                    else
                    {
                        logging.AddSimpleConsole(options => options.IncludeScopes = false);
                        logging.AddJsonConsole(options => options.IncludeScopes = true);
                        logging.SetMinimumLevel(LogLevel.Information);
                    }

                    logging.AddFilter("Microsoft", LogLevel.Warning);
                    logging.AddFilter("System", LogLevel.Warning);
                    logging.AddFilter("Default", LogLevel.Information);
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
