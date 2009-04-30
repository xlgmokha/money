using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;

namespace MoMoney.Service.Application
{
    public class GetAllIncomeQuery : IGetAllIncomeQuery
    {
        readonly IIncomeRepository all_income;
        readonly IMapper<IIncome, IncomeInformationDTO> mapper;

        public GetAllIncomeQuery(IIncomeRepository all_income, IMapper<IIncome, IncomeInformationDTO> mapper)
        {
            this.all_income = all_income;
            this.mapper = mapper;
        }

        public IEnumerable<IncomeInformationDTO> fetch()
        {
            return all_income.all().map_all_using(mapper);
        }
    }
}