using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ProcessUserData.Iservices;
using ProcessUserData.Models;

namespace ProcessUserData
{
	public class ReadUserDataAndQueueToServiceBusFunction
	{
		private readonly IUserService _userService;
		private readonly ILogger<ReadUserDataAndQueueToServiceBusFunction> _log;
		private readonly IQueueService _queueService;
		public ReadUserDataAndQueueToServiceBusFunction(IUserService userService, IQueueService queueService, ILogger<ReadUserDataAndQueueToServiceBusFunction> log)
		{
			_userService = userService;
			_queueService = queueService;
			_log = log;
		}

		[FunctionName("ReadUserDataAndQueueToServiceBus")]
		public void Run([TimerTrigger("0 */15 * * * *")] TimerInfo myTimer)
		{
			try
			{
				_log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

				var userDetails = _userService.GetUserDetails();

				_queueService.SendMessageAsync(userDetails);

				_log.LogInformation($"Sent messages to Service Bus Queue.");

			}
			catch (Exception ex)
			{
				_log.LogError($"An Error Occurred : {ex.Message}");
			}

		}
	}
}
