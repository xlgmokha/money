using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.application
{
    public interface IGetAllCompanysQuery : IQuery<IEnumerable<ICompany>>
    {
    }

    public class GetAllCompanysQuery : IGetAllCompanysQuery
    {
        readonly ICompanyRepository companys;

        public GetAllCompanysQuery(ICompanyRepository companys)
        {
            this.companys = companys;
        }

        public IEnumerable<ICompany> fetch()
        {
            return companys.all();
        }
    }
}