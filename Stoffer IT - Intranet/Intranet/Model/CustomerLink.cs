using System.Collections.Generic;

namespace Intranet.Model
{
    /// <summary>
    /// Represents a link to a customer.
    /// </summary>
    public class CustomerLink
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    public class ImageCustomerLink : CustomerLink
    {
        public string ImageUrl { get; set; }
    }

    public class CustomerOverview<T> where T : CustomerLink
    {
        public IEnumerable<T> Customers { get; set; }
    }
}