using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.repositories;

namespace MoMoney.Domain.Accounting
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