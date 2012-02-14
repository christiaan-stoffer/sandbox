using System;

namespace Sit.Framework.Portal.Bus
{
    internal class SubscriberWrapper<T>
    {
        public SubscriberWrapper(Action<T> handler)
        {
            Handler = handler;
        }

        public Action<T> Handler { get; private set; }

        public string Channel { get; set; }
    }
}