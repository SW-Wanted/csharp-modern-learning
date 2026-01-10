using _02_Logging.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Logging
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly LoggingDemoService _demo;
        public App(ILogger<App> logger, LoggingDemoService demo)
        {
            _logger = logger;
            _demo = demo;
        }
        public async Task RunAsync()
        {
            _logger.LogInformation("Logging Lab Starts");

            await _demo.RullAllExamplesAsync();

            _logger.LogInformation("Logging Lab Finalizado");
        }
    }
}
