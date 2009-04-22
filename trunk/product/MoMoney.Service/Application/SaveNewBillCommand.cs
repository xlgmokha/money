using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.Core;
using MoMoney.Domain.repositories;
using MoMoney.DTO;

namespace MoMoney.Service.Application
{
    public interface ISaveNewBillCommand : IParameterizedCommand<AddNewBillDTO>
    {
    }

    public class SaveNewBillCommand : ISaveNewBillCommand
    {
        readonly ICompanyRepository companys;
        readonly ICustomerTasks tasks;

        public SaveNewBillCommand(ICompanyRepository companys, ICustomerTasks tasks)
        {
            this.companys = companys;
            this.tasks = tasks;
        }

        public void run(AddNewBillDTO item)
        {
            companys
                .find_company_by(item.company_id)
                .issue_bill_to(
                tasks.get_the_current_customer(),
                item.due_date,
                item.total.as_money()
                );
        }
    }
}