using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Service.Application
{
    public class GetAllCompanysQuery : IGetAllCompanysQuery
    {
        ICompanyRepository companys;
        Mapper<Company, CompanyDTO> mapper;

        public GetAllCompanysQuery(ICompanyRepository companys, Mapper<Company, CompanyDTO> mapper)
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