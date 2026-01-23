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
            // Configuração do Logger global Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // nível mínimo global
                .Enrich.FromLogContext() // permite BeginScope e CorrelationId
                .WriteTo.Console()       // console para desenvolvimento
                .WriteTo.File("logs/log.json", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:O} [{Level}] {Message}{NewLine}{Properties}{Exception}")
                .CreateLogger();

            using IHost host = Host.CreateDefaultBuilder(args)
                .UseSerilog() // substitui logger interno do Host pelo Serilog
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();

                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        logging.AddConsole(options => options.IncludeScopes = true);
                        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    }
                    else
                    {
                        logging.AddJsonConsole(options => options.IncludeScopes = true);
                        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                    }

                    // Filtros por namespace/categoria
                    logging.AddFilter("Microsoft", Microsoft.Extensions.Logging.LogLevel.Warning);
                    logging.AddFilter("System", Microsoft.Extensions.Logging.LogLevel.Warning);
                    logging.AddFilter("LoggingLab.Services", Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<App>();
                    services.AddSingleton<LoggingDemoService>();
                })
                .Build();

            await host.Services.GetRequiredService<App>().RunAsync();
        }
    }
}
