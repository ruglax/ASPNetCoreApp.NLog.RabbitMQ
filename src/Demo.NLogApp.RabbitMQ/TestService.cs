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
 
        public void Run()
        {
            for (int i = 0; i < 100000; i++)
            {
                _logger.LogWarning($"Wow! We are now in the test service. {i}");    
            }
            
        }
    }
}
