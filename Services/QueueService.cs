using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using ProcessUserData.Iservices;
using ProcessUserData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProcessUserData.Services
{
	public class QueueService : IQueueService
	{
		private readonly ServiceBusClient _client;
		private readonly IConfiguration _config;
		public QueueService(ServiceBusClient client, IConfiguration config)
        {
            _client = client;
			_config = config;
        }
        public async Task SendMessageAsync(List<UserData> userDetails)
		{
			try
			{
				var messages = userDetails.Select(data => new MessageData
				{
					UserId = data.UserId,
					UserName = data.UserName,
					UserEmail = data.UserEmail,
					DataValue = data.DataValue,
				})
			    .Select(myMessage => new ServiceBusMessage(JsonSerializer.Serialize(myMessage)))
			    .ToList();

				var sender = _client.CreateSender(_config["ServiceBusQueueName"]);
				await sender.SendMessagesAsync(messages);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
