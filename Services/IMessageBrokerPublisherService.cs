namespace HashApi.Services
{
    public interface IMessageBrokerProducerService
    {
        void PublishMessage<T>(T message);
    }
}