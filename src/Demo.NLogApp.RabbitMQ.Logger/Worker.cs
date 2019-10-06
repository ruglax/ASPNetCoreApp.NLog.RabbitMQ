using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Demo.NLogApp.RabbitMQ.Logger
{

    public class Worker
    {
        private readonly IConsumer _consumer;

        public Worker(IConsumer consumer)
        {
            _consumer = consumer;
        }

        public void Run()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();

            try
            {
                channel.ExchangeDeclare(exchange: "app-logging", type: "topic", durable: true);
                var queueName = channel.QueueDeclare().QueueName;

                channel.QueueBind(queue: queueName,
                    exchange: "app-logging",
                    routingKey: "demo.nlogapp.rabbitmq.*");

                Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    _consumer.Write(routingKey, message);
                    
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            finally
            {
                channel.Close();
                conn.Close();
            }
        }
    }
}