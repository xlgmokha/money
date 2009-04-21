using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.repositories;
using MoMoney.DTO;

namespace MoMoney.Tasks.application
{
    public interface IGetAllCompanysQuery : IQuery<IEnumerable<CompanyDTO>>
    {
    }

    public class GetAllCompanysQuery : IGetAllCompanysQuery
    {
        readonly ICompanyRepository companys;

        public GetAllCompanysQuery(ICompanyRepository companys)
        {
            this.companys = companys;
        }

        public IEnumerable<CompanyDTO> fetch()
        {
            return companys.all().map_all_using(x => new CompanyDTO {id = x.id, name = x.name});
        }
    }
}