
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace HashApi.Services
{
    public class RabbitMQPublisherService : IMessageBrokerProducerService
    {
        public void PublishMessage<T>(T message)
        {
            // TODO: update conn settings
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "myuser",
                Password = "mypassword"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("hashes", exclusive: false);
            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "hashes", body: body);
        }
    }
}