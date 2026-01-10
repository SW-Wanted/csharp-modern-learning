using System;
using System.Collections.Generic;
using System.Text;

namespace _00_LegacyStyle
{
    public class App
    {
        private GreetingService _greetingService;
        public App()
        {
            _greetingService = new GreetingService();
        }
        public void Run()
        {
            Console.WriteLine("Aplicação iniciada.");

            _greetingService.Greet("Emanuel dos Santos");

            Console.WriteLine("Aplicação finalizada.");
        }
    }
}
