using System;
using Sit.Framework.Portal.Content;

namespace Sit.Portal.DomainModel
{
    public interface IContact : IEntity
    {
        [MaxLength(15)]
        string Name { get; set; }

        [MaxLength(15)]
        string Firstname { get; set; }

        [MaxLength(10)]
        string Initials { get; set; }

        [MaxLength(10)]
        string Prefix { get; set; }

        [MaxLength(10)]
        string Postfix { get; set; }

        [Nullable]
        DateTime DateOfBirth { get; set; }
    }
}