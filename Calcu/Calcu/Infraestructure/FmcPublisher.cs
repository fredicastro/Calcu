using Calcu.Models;
using RabbitMQ.Client;
using System.Text;

namespace Calcu.Infraestructure
{
    public class FmcPublisher: ConnectionBuilderBase, IMessageProducer
    {
        public FmcPublisher(IConfiguration configuration) : base(configuration) { }

        public void Produce(string message)
        {
            var factory = GetConnection;

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Rabbit sent message type: {typeof(IntentosCalculo)} - body {message}");
        }

    }
}
