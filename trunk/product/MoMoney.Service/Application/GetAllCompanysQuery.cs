using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;

namespace MoMoney.Service.Application
{
    public class GetAllCompanysQuery : IGetAllCompanysQuery
    {
        readonly ICompanyRepository companys;
        readonly IMapper<ICompany, CompanyDTO> mapper;

        public GetAllCompanysQuery(ICompanyRepository companys, IMapper<ICompany, CompanyDTO> mapper)
        {
            this.companys = companys;
            this.mapper = mapper;
        }

        public IEnumerable<CompanyDTO> fetch()
        {
            return companys.all().map_all_using(mapper);
        }
    }
}