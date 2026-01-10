using Microsoft.Extensions.Logging;

namespace _01_Hosting
{
    public class App
    {
        private readonly IGreetingService _greetingService;
        private readonly ILogger<App> _logger;

        public App(IGreetingService greetingService, ILogger<App> logger)
        {
            _greetingService = greetingService;
            _logger = logger;
        }
        public async Task RunAsync()
        {
            _logger.LogInformation("Aplicação Iniciada.");

            await _greetingService.GreetAsync("Emanuel dos Santos");
            await _greetingService.GreetAsync("Micaela dos Santos");

            _logger.LogInformation("Aplicação Finalizada.");
        }
    }
}
