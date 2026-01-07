using Microsoft.Extensions.Hosting;

namespace _01_Hosting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).Build();
            
            await host.StartAsync();
            Console.WriteLine("Hello, World!");
            await host.StopAsync();   
        }
    }
}
