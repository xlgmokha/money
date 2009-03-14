using System.Collections.Generic;
using Castle.Core;
using MoMoney.DataAccess.core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Presenters.income.dto;

namespace MoMoney.Tasks.application
{
    public interface IIncomeTasks
    {
        void add_new(income_submission_dto income);
        IEnumerable<ICompany> all_companys();
        IEnumerable<IIncome> retrive_all_income();
    }

    [Interceptor(typeof (IUnitOfWorkInterceptor))]
    public class IncomeTasks : IIncomeTasks
    {
        private readonly IDatabaseGateway repository;
        private readonly ICustomerTasks tasks;

        public IncomeTasks(IDatabaseGateway repository, ICustomerTasks tasks)
        {
            this.repository = repository;
            this.tasks = tasks;
        }

        public void add_new(income_submission_dto income)
        {
            income
                .company.pay(
                tasks.get_the_current_customer(),
                income.amount.as_money(),
                income.recieved_date.as_a_date()
                );
        }

        public IEnumerable<ICompany> all_companys()
        {
            return repository.all<ICompany>();
        }

        public IEnumerable<IIncome> retrive_all_income()
        {
            return repository.all<IIncome>();
        }
    }
}