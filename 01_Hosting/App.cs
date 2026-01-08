namespace _01_Hosting
{
    public class App
    {
        public async Task RunAsync()
        {
            Console.WriteLine("App está a executar...");

            await Task.Delay(1000);

            Console.WriteLine("App terminou.");
        }
    }
}
