using System.Collections.Generic;
using Castle.Core;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.Core;
using MyMoney.Domain.repositories;
using MyMoney.Infrastructure.interceptors;
using MyMoney.Presentation.Presenters.billing.dto;

namespace MyMoney.Tasks.application
{
    public interface IBillingTasks
    {
        void save_a_new_bill_using(add_new_bill_dto dto);
        IEnumerable<IBill> all_bills();
        void register_new_company(register_new_company dto);
        IEnumerable<ICompany> all_companys();
    }

    [Interceptor(typeof (IUnitOfWorkInterceptor))]
    public class billing_tasks : IBillingTasks
    {
        private readonly IRepository repository;
        private readonly ICustomerTasks tasks;

        public billing_tasks(IRepository repository, ICustomerTasks tasks)
        {
            this.repository = repository;
            this.tasks = tasks;
        }

        public void save_a_new_bill_using(add_new_bill_dto dto)
        {
            var company = repository.find_company_named(dto.company_name);
            var customer = tasks.get_the_current_customer();
            company.issue_bill_to(customer, dto.due_date, dto.total.as_money());
        }

        public IEnumerable<IBill> all_bills()
        {
            return repository.all<IBill>();
        }

        public void register_new_company(register_new_company dto)
        {
            new Company(dto.company_name);
        }

        public IEnumerable<ICompany> all_companys()
        {
            return repository.all<ICompany>();
        }
    }
}