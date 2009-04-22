using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Accounting.Growth;
using MoMoney.Domain.repositories;
using MoMoney.Presentation.Presenters.income.dto;

namespace MoMoney.Service.Application
{
    public interface IGetAllIncomeQuery : IQuery<IEnumerable<IncomeInformationDTO>>
    {
    }

    public class GetAllIncomeQuery : IGetAllIncomeQuery
    {
        readonly IIncomeRepository all_income;

        public GetAllIncomeQuery(IIncomeRepository all_income)
        {
            this.all_income = all_income;
        }

        public IEnumerable<IncomeInformationDTO> fetch()
        {
            return all_income.all().map_all_using(x => map_from(x));
        }

        static IncomeInformationDTO map_from(IIncome x)
        {
            return new IncomeInformationDTO
                       {
                           amount = x.amount_tendered.to_string(),
                           company = x.company.to_string(),
                           recieved_date = x.date_of_issue.to_string(),
                       };
        }
    }
}