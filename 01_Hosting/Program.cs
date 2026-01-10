using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _01_Hosting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<App>();
                    services.AddSingleton<IGreetingService, GreetingService>();
                    services.AddTransient<IOperationId, OperationId>();
                })
                .Build();
            
            await host.StartAsync();
            using var scope = host.Services.CreateScope(); // To use services.addScoped<>(); | Only for non-web apps
            var app = host.Services.GetRequiredService<App>();
            await app.RunAsync();

            await host.StopAsync();
        }
    }
}
