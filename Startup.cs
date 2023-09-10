using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessUserData.Iservices;
using ProcessUserData.Services;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Azure;
using ProcessUserData.Database;

[assembly: FunctionsStartup(typeof(ProcessUserData.Startup))]

namespace ProcessUserData
{
    public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			var configuration = new ConfigurationBuilder()
	            .SetBasePath(Directory.GetCurrentDirectory())
	            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
	            .AddEnvironmentVariables()
	            .Build();

			builder.Services.AddSingleton<IConfiguration>(configuration);

			builder.Services.AddDbContext<MyDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"));
			});

			builder.Services.AddAzureClients(builder =>
			{
				builder.AddServiceBusClient(configuration.GetConnectionString("ServiceBusConnectionString"));
			});

			builder.Services.AddLogging();
			builder.Services.AddTransient<IUserRepository, UserRepository>();
			builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<IQueueService, QueueService>();
		}
	}
}
