using MoMoney.Domain.repositories;
using MoMoney.Utility.Core;

namespace MoMoney.Domain.accounting.billing
{
    public interface ICompanyFactory : IFactory<ICompany>
    {
    }

    public class CompanyFactory : ICompanyFactory
    {
        readonly IComponentFactory<Company> factory;
        readonly ICompanyRepository companys;

        public CompanyFactory(IComponentFactory<Company> factory, ICompanyRepository companys)
        {
            this.factory = factory;
            this.companys = companys;
        }

        public ICompany create()
        {
            var company = factory.create();
            companys.save(company);
            return company;
        }
    }
}