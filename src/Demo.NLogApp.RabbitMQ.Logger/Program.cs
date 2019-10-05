using System;
using RabbitMQ.Client;

namespace Demo.NLogApp.RabbitMQ.Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConnectionFactory factory = new ConnectionFactory { HostName = "amqp://guest:guest@localhost:5672 /" };
            IConnection conn = factory.CreateConnection();

            IModel channel = conn.CreateModel();
            channel.Close();
            conn.Close();
        }
    }
}
