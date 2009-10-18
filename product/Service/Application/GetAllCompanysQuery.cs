using System.Collections.Generic;
using System.ComponentModel;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Service.Application
{
    [DisplayName("Loading all companies...")]
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