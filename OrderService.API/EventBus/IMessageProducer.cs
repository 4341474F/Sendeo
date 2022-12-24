namespace OrderAPI.EventBus
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
