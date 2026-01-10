using System;
using System.Collections.Generic;
using System.Text;

namespace _00_LegacyStyle
{
    public class GreetingService
    {
        public void Greet(string name)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Olá, {name}");
        }
    }
}
