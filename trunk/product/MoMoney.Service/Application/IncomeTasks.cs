using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.Accounting.Growth;
using MoMoney.Domain.Core;
using MoMoney.Domain.repositories;
using MoMoney.Presentation.Presenters.income.dto;

namespace MoMoney.Tasks.application
{
    public interface IIncomeTasks
    {
        void add_new(IncomeSubmissionDto income);
        IEnumerable<ICompany> all_companys();
        IEnumerable<IIncome> retrive_all_income();
    }

    public class IncomeTasks : IIncomeTasks
    {
        readonly ICustomerTasks tasks;
        readonly ICompanyRepository companys;
        readonly IIncomeRepository incomes;

        public IncomeTasks(ICustomerTasks tasks, ICompanyRepository companys, IIncomeRepository incomes)
        {
            this.incomes = incomes;
            this.companys = companys;
            this.tasks = tasks;
        }

        public void add_new(IncomeSubmissionDto income)
        {
            var company = companys.find_company_by(income.company_id);
            company.pay(
                tasks.get_the_current_customer(),
                income.amount.as_money(),
                income.recieved_date.as_a_date()
                );
        }

        public IEnumerable<ICompany> all_companys()
        {
            return companys.all();
        }

        public IEnumerable<IIncome> retrive_all_income()
        {
            return incomes.all();
        }
    }
}