# Azure Functions Documentation

This repository contains two Azure Functions implemented in C# for various scenarios. Below are details and instructions for each function.

## Getting Started - Setting Up Local Development

To set up your local development environment for this project, you'll need to clone or download this repositor. 

Create a `local.settings.json` file that contains the necessary configuration settings.

![image](https://github.com/shreyaskushal/AzureFunction_Timer_And_ServiceBusTriggered/assets/53855082/a4472b46-cdc9-43ad-a1a7-8a02d8a9075a)


## ProcessServiceBusMessageFunction

### Overview

The `ProcessServiceBusMessageFunction` is a Service Bus Queue Triggered Function designed to process messages from a Service Bus queue. It triggers automatically when a new message is added to the specified queue.

### Configuration

- **Queue Name**: The name of the Service Bus queue to monitor is specified using the `%ServiceBusQueueName%` placeholder setting in the `local.settings.json`. In a production environment, this value should be set as an environment variable.

- **Connection String**: The connection string for the Service Bus is specified using the `"ServiceBusConnectionString"` setting in the `local.settings.json` file for local development. In a production environment, set this value as an environment variable.

### Usage

To use the `ProcessServiceBusMessageFunction`:

1. Clone this repository to your local environment.

2. Configure the Service Bus queue name and connection string in the appropriate configuration files:
   - In `local.settings.json` for local development, set `"ServiceBusConnectionString"` to your Service Bus connection string.
   - In a production environment, set the `ServiceBusQueueName` and `ServiceBusConnectionString` environment variables.

3. Deploy the function to your Azure Functions app in the Azure portal or using your preferred deployment method.

4. Send messages to the specified Service Bus queue, and the function will automatically process them based on the trigger.

## ReadUserDataAndQueueToServiceBusFunction

### Overview

The `ReadUserDataAndQueueToServiceBusFunction` is a Timer Triggered Function designed to read user data from a source, such as a database, and queue it in a Service Bus queue at a specified interval.

### Configuration

- **Schedule**: The function is configured to run on a schedule using a CRON expression in the `[TimerTrigger]` attribute. You can modify the schedule in the code.

### Usage

To use the `ReadUserDataAndQueueToServiceBusFunction`:

1. Configure the function to run according to your desired schedule by modifying the CRON expression in the `[TimerTrigger]` attribute within the `Run` method in the code.

2. Deploy the function to your Azure Functions app in the Azure portal or using your preferred deployment method.

3. The function will automatically run at the specified intervals and perform the following actions:
   - Retrieve user data from SQL server using stored procedure by passing "LastExecutionTime" as the parameter.
   - "LastExecutionTime" is retrieved from the configuration.
   - Queue the user data to a Service Bus queue using the `QueueService`.
   - Log information about the execution.

## Contributing

If you'd like to contribute to this project or report issues, please open a GitHub issue or create a pull request.

