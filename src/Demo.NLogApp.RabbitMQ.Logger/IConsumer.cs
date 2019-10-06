namespace Demo.NLogApp.RabbitMQ.Logger
{
    public interface IConsumer
    {
        void Write(string routingKey, string message);
    }
}