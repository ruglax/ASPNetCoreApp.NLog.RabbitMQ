using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Demo.NLogApp.RabbitMQ
{
    class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;

        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        public void Run(int i = 0)
        {
            var level = i % 2 == 0 ? LogLevel.Warning : LogLevel.Information;
            _logger.Log(level, $"We are sending messages over RabbitMQ whohooo!!. {i}");
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("good bye!");
                return;
            }

            Run(++i);
        }
    }
}
