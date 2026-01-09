using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Hosting
{
    public class GreetingService : IGreetingService
    {
        public async Task GreetAsync(string name)
        {
            Console.WriteLine($"Olá, {name}");
            await Task.Delay(500);
        }
    }
}
