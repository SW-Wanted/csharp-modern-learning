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
                })
                .Build();
            
            await host.StartAsync();

            var app = host.Services.GetRequiredService<App>();
            await app.RunAsync();
            
            await host.StopAsync();   
        }
    }
}
