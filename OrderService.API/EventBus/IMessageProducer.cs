namespace OrderService.API.EventBus
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
