using System.Linq;
using MoMoney.DataAccess.core;
using MoMoney.Domain.accounting;

namespace MoMoney.Tasks.application
{
    public interface ICustomerTasks
    {
        IAccountHolder get_the_current_customer();
    }

    public class CustomerTasks : ICustomerTasks
    {
        readonly IDatabaseGateway repository;

        public CustomerTasks(IDatabaseGateway repository)
        {
            this.repository = repository;
        }

        public IAccountHolder get_the_current_customer()
        {
            var c = repository.all<IAccountHolder>().SingleOrDefault();

            if (null == c)
            {
                var customer = new AccountHolder();
                repository.save(customer);
                return customer;
            }

            return c;
        }
    }
}