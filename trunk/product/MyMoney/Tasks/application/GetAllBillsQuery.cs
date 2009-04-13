using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Tasks.application
{
    public interface IGetAllBillsQuery : IQuery<IEnumerable<bill_information_dto>>
    {
    }

    public class GetAllBillsQuery : IGetAllBillsQuery
    {
        readonly IBillingTasks tasks;

        public GetAllBillsQuery(IBillingTasks tasks)
        {
            this.tasks = tasks;
        }

        public IEnumerable<bill_information_dto> fetch()
        {
            return tasks.all_bills().map_all_using(x => map_from(x));
        }

        bill_information_dto map_from(IBill bill)
        {
            return new bill_information_dto
                       {
                           company_name = bill.company_to_pay.name,
                           the_amount_owed = bill.the_amount_owed.ToString(),
                           due_date = bill.due_date.to_date_time(),
                       };
        }
    }
}