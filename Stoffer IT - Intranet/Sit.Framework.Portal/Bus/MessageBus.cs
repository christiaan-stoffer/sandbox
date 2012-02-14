using System;
using System.Collections.Generic;
using System.Linq;

namespace Sit.Framework.Portal.Bus
{
    public class MessageBus
    {
        private readonly List<object> _subscribers;

        public MessageBus()
        {
            _subscribers = new List<object>();
        }

        public void Subscribe<T>(ISubscriber<T> subscriber)
        {
            _subscribers.Add(new SubscriberWrapper<T>(subscriber.OnMessageReceived));
        }

        public void Subscribe<T>(IChannelSubscriber<T> subscriber)
        {
            _subscribers.Add(new SubscriberWrapper<T>(subscriber.OnMessageReceived){Channel = subscriber.Channel});
        }

        public void Subscribe<T>(Action<T> messageHandler)
        {
            _subscribers.Add(new SubscriberWrapper<T>(messageHandler));
        }

        public void Subscribe<T>(string channel, Action<T> messageHandler)
        {
            _subscribers.Add(new SubscriberWrapper<T>(messageHandler) {Channel = channel});
        }

        public void Publish<T>(T message)
        {
            foreach (var s in _subscribers.OfType<SubscriberWrapper<T>>().Where(wrapper=>string.IsNullOrEmpty(wrapper.Channel)))
            {
                s.Handler(message);
            }
        }

        public void Publish<T>(string channel, T message)
        {
            foreach(var s in _subscribers.OfType<SubscriberWrapper<T>>().Where(wrapper=>string.Compare(channel, wrapper.Channel, StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                s.Handler(message);
            }
        }
    }
}
