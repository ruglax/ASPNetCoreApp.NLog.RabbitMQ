using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Microsoft.Extensions.Logging;
using Demo.NLogApp.RabbitMQ.Logger.Model;
using Newtonsoft.Json;

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
            LogEntry logEntry = JsonConvert.DeserializeObject<LogEntry>(message);
            _logger.LogWarning(logEntry.Message);
            // Console.WriteLine(" [x] Received '{0}':'{1}'",
            //                           routingKey,
            //                           message);
        }
    }
}