using HashApi.Data.Repositories.Hashes;
using HashApi.Worker.Consumer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<RabbitMqConsumer>();
        services.AddScoped<IHashRepository, HashRepository>();
    })
    .Build()
    .Run();
