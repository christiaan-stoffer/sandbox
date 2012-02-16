namespace Sit.Framework.Portal.Bus
{
    public interface ISubscriber<in TMessage>
    {
        void OnMessageReceived(TMessage message);
    }
}