using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Service.Application
{
    public class GetAllIncomeQuery : IGetAllIncomeQuery
    {
        readonly IIncomeRepository all_income;
        readonly Mapper<Income, IncomeInformationDTO> mapper;

        public GetAllIncomeQuery(IIncomeRepository all_income, Mapper<Income, IncomeInformationDTO> mapper)
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