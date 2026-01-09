namespace _01_Hosting
{
    public class App
    {
        private readonly IGreetingService _greetingService;

        public App(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        public async Task RunAsync()
        {
            await _greetingService.GreetAsync("Emanuel dos Santos");
        }
    }
}
