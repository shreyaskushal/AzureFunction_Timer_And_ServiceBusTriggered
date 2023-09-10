using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ProcessUserData
{
    public class ProcessServiceBusMessageFunction
    {
        private readonly ILogger _log;
        public ProcessServiceBusMessageFunction(ILogger<ProcessServiceBusMessageFunction> log)
        {
             _log = log;
        }

        [FunctionName("ProcessServiceBusMessage")]
        public void Run([ServiceBusTrigger("%ServiceBusQueueName%", Connection = "ServiceBusConnectionString")]string myQueueItem)
        {
			_log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
	}
}
