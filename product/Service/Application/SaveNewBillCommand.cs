using MoMoney.Domain.Core;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Service.Application
{
    public class SaveNewBillCommand : ISaveNewBillCommand
    {
        readonly ICompanyRepository companys;
        readonly IGetTheCurrentCustomerQuery tasks;

        public SaveNewBillCommand(ICompanyRepository companys, IGetTheCurrentCustomerQuery tasks)
        {
            this.companys = companys;
            this.tasks = tasks;
        }

        public void run(AddNewBillDTO item)
        {
            companys
                .find_company_by(item.company_id)
                .issue_bill_to(
                tasks.fetch(),
                item.due_date,
                item.total.as_money()
                );
        }
    }
}