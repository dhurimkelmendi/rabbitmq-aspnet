using System.Text;
using System.Text.Json;
using HashApi.Data.Entities;
using HashApi.Data.Repositories.Hashes;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HashApi.Worker.Consumer
{
    public class RabbitMqConsumer : IHostedService
    {
        private IHashRepository _hashRepository;
        public RabbitMqConsumer(IHashRepository hashRepository)
        {
            _hashRepository = hashRepository;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                for (int i = 0; i < 4; i++)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(consume));
                }
            }
        }

        private void consume(object obj)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("hashes", exclusive: false);

            //Set Event object which listen message from chanel which is sent by producer
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Hash message received: {message}");

                var hash = JsonSerializer.Deserialize<Hash>(message);

                _hashRepository.Add(hash);
            };
            //read the message
            channel.BasicConsume(queue: "hashes", autoAck: true, consumer: consumer);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
