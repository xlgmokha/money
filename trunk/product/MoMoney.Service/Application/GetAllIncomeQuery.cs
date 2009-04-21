using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Tasks.application;

namespace MoMoney.Service.Application
{
    public interface IGetAllIncomeQuery : IQuery<IEnumerable<IncomeInformationDTO>>
    {
    }

    public class GetAllIncomeQuery : IGetAllIncomeQuery
    {
        readonly IIncomeTasks tasks;

        public GetAllIncomeQuery(IIncomeTasks tasks)
        {
            this.tasks = tasks;
        }

        public IEnumerable<IncomeInformationDTO> fetch()
        {
            return tasks.retrive_all_income().map_all_using(x => map_from(x));
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