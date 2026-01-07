using Microsoft.Extensions.Hosting;

namespace _01_Hosting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using IHost host = Host.CreateDefaultBuilder(args).Build();
            Console.WriteLine("Hello, World!");
            await host.StartAsync();
            Console.WriteLine("Hello, World!");
            await host.StopAsync();
            Console.WriteLine("Hello, World!");
        }
    }
}
