using Microsoft.Extensions.Logging;
using Demo.NLogApp.RabbitMQ.Logger.Model;
using Newtonsoft.Json;

using System;

namespace Demo.NLogApp.RabbitMQ.Logger
{
    public class Consumer : IConsumer
    {
        private readonly ILogger<Consumer> _logger;

        public Consumer(ILogger<Consumer> logger)
        {
            _logger = logger;
        }

        public void Write(string routingKey, string message)
        {
            LogEntry entry = JsonConvert.DeserializeObject<LogEntry>(message);
            _logger.Log(LogLevel.Warning,
                default,
                new ExtendedLogEvent(entry.Message).AddProp("Application", entry.Source),
                null,
                ExtendedLogEvent.Formatter);
        }
    }
}