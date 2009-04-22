using System.Linq;
using MoMoney.Domain.accounting;
using MoMoney.Domain.repositories;

namespace MoMoney.Service.Application
{
    public interface ICustomerTasks
    {
        IAccountHolder get_the_current_customer();
    }

    public class CustomerTasks : ICustomerTasks
    {
        readonly IAccountHolderRepository account_holders;

        public CustomerTasks(IAccountHolderRepository account_holders)
        {
            this.account_holders = account_holders;
        }

        public IAccountHolder get_the_current_customer()
        {
            var c = account_holders.all().SingleOrDefault();

            if (null == c)
            {
                var customer = new AccountHolder();
                account_holders.save(customer);
                return customer;
            }

            return c;
        }
    }
}