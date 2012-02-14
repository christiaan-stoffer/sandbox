namespace Sit.Framework.Portal.Bus
{
    public interface ISubscriber<in TMessage>
    {
        void OnMessageReceived(TMessage message);
    }

    public interface IChannelSubscriber<in TMessage> : ISubscriber<TMessage>
    {
        string Channel { get; }
    }
}