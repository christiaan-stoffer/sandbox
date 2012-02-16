namespace Sit.Framework.Portal.Bus
{
    public interface IChannelSubscriber<in TMessage> : ISubscriber<TMessage>
    {
        string Channel { get; }
    }
}