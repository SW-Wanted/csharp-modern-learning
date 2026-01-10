using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Logging.Services
{
    public class LoggingDemoService
    {
        private readonly ILogger<LoggingDemoService> _logger;
        public LoggingDemoService(ILogger<LoggingDemoService> logger)
        {
            _logger = logger;
        }
        public async Task RullAllExamplesAsync()
        {
            _logger.LogTrace("Log TRACE: detalhes extremos");
            _logger.LogDebug("Log DEBUG: diagnóstico");
            _logger.LogInformation("Log INFO: fluxo normal");
            _logger.LogWarning("Log WARNING: algo inesperado");
            _logger.LogError("Log ERROR: falha ocorreu");
            _logger.LogCritical("Log CRITICAL: sistema comprometido");

            await Task.Delay(500);
        }
    }

}
