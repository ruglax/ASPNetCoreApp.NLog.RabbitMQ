﻿using Microsoft.Extensions.Logging;

namespace Demo.NLogApp.RabbitMQ
{
    public interface ITestService
    {
        void Run(int i = 0);
    }
}
