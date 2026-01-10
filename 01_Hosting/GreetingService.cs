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
        public async Task GreetAsync(string name)
        {
            _logger.LogInformation("OperationId: {Id} | Saudando: {Name}", _operationId.Id, name);

            await Task.Delay(300);
        }
    }
}
