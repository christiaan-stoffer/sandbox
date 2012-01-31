using System;

namespace Sit.Intranet.Model
{
    public static class ItemFactory
    {
        public static Item<TInterface> Create<TInterface>()
        {
            if (!typeof(TInterface).IsInterface)
            {
                throw new ArgumentException("Only interfaces are allowed.");
            }

            return new Item<TInterface>();
        } 
    }
}