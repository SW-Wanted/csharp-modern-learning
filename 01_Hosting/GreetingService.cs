using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Hosting
{
    public class GreetingService : IGreetingService
    {
        private readonly IOperationId _operationId;
        private readonly ILogger _logger;
        public GreetingService(IOperationId operationId, ILogger<GreetingService> logger)
        {
            _logger = logger;
            _operationId = operationId;
        }
        public async Task GreetAsync(GreetingRequest request)
        {
            _logger.LogInformation("OperationId: {Id} | Saudando: {Name}", _operationId.Id, request.Name);

            await Task.Delay(500);

            _logger.LogInformation("Olá, {Name}", request.Name);
        }
    }
}
