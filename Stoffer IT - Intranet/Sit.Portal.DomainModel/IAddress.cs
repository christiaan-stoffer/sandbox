using Sit.Framework.Portal.Content;

namespace Sit.Portal.DomainModel
{
    public interface IAddress : IEntity
    {
        [MaxLength(250)]
        string Street { get; set; }

        [MaxLength(10)]
        string Number { get; set; }

        [MaxLength(10)]
        string PostalCode { get; set; }

        [MaxLength(250)]
        string City { get; set; }

        [MultiLine, Nullable]
        string Description { get; set; }

        int CountryCode { get; set; }
    }
}