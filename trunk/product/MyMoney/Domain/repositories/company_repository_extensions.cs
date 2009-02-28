using System.Linq;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Logging;

namespace MyMoney.Domain.repositories
{
    public static class company_repository_extensions
    {
        public static ICompany find_company_named(this IRepository repository, string company_name)
        {
            var company = repository
                .all<ICompany>()
                .SingleOrDefault(x => x.name.Equals(company_name));
            if (null == company)
            {
                Log.For(typeof (company_repository_extensions)).debug("could not find company named:{0}", company_name);
            }
            return company;
        }
    }
}