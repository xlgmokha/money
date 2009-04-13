using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.Core;
using MoMoney.Domain.repositories;
using MoMoney.Presentation.Presenters.billing.dto;

namespace MoMoney.Tasks.application
{
    public interface IBillingTasks
    {
        void save_a_new_bill_using(AddNewBillDTO dto);
        IEnumerable<IBill> all_bills();
        IEnumerable<ICompany> all_companys();
    }

    public class BillingTasks : IBillingTasks
    {
        readonly IBillRepository bills;
        readonly ICompanyRepository companys;
        readonly ICustomerTasks tasks;

        public BillingTasks(IBillRepository bills, ICompanyRepository companys, ICustomerTasks tasks)
        {
            this.bills = bills;
            this.companys = companys;
            this.tasks = tasks;
        }

        public void save_a_new_bill_using(AddNewBillDTO dto)
        {
            var company = companys.find_company_named(dto.company_name);
            var customer = tasks.get_the_current_customer();
            company.issue_bill_to(customer, dto.due_date, dto.total.as_money());
        }

        public IEnumerable<IBill> all_bills()
        {
            return bills.all();
        }

        public IEnumerable<ICompany> all_companys()
        {
            return companys.all();
        }
    }
}