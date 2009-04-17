using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;

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