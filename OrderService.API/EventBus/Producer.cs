using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace OrderService.API.EventBus
{
    public class Producer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("orders", exclusive:false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
            Console.WriteLine($"Sent {message}");
        }
    }
}
