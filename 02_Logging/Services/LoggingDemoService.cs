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

        private void SimulateFailure()
        {
            throw new InvalidOperationException("Estádo inválido dectetado", new ArgumentNullException("dependecy"));
        }

        public async Task GreetingAsync(string name)
        {
            using (_logger.BeginScope("User: [{UserName}]", name))
            {
                _logger.LogInformation("Inicio da Saudacao");

                await Task.Delay(500);

                _logger.LogInformation("Fim da Saudacao");

            }

            _logger.LogInformation("Iniciando operação sem nome de usuário no escopo.");
            await Task.Delay(500);
            _logger.LogInformation("Finalizando operação sem nome de usuário no escopo.");

            using (_logger.BeginScope(new { CorrelationId = Guid.NewGuid(), Name = name}))
            {
                _logger.LogInformation("Iniciando operação com múltiplos valores no escopo.");
                await Task.Delay(500);
                _logger.LogInformation("Finalizando operação com múltiplos valores no escopo.");
            }
        }
        public void RunWithException()
        {
            try
            {
                _logger.LogInformation("Iniciando operação perigosa.");

                SimulateFailure();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao executar a operação em {Service}", nameof(LoggingDemoService));
            }
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
