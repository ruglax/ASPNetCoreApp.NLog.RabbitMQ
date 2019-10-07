using Microsoft.Extensions.Logging;
using Demo.NLogApp.RabbitMQ.Logger.Model;
using Newtonsoft.Json;

using System;
using Demo.NLogApp.RabbitMQ.Logger.Utils;

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
            LogEntry entry = JsonConvert.DeserializeObject<LogEntry>(message, new LogLevelConverter());
            _logger.Log(entry.Level,
                default,
                new ExtendedLogEvent(entry.Message).AddProp("Application", entry.Source),
                null,
                ExtendedLogEvent.Formatter);
        }
    }
}