using System.Collections.Generic;

namespace Sit.Intranet.Domain
{
    public class CustomerRepository
    {
        public IEnumerable<Company> GetAllCompanies()
        {
            using (var cntx = new IntranetDataContext())
            {
                return cntx.Companies;
            }
        }
    }
}
