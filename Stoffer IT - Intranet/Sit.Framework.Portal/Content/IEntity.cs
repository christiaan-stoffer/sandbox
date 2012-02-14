using System;

namespace Sit.Framework.Portal.Content
{
    public interface IEntity<out TKey>
    {
        TKey Key { get; }

        Guid UniqueId { get; set; }
        DateTime Created { get; }
        DateTime Modified { get; }
    }
}