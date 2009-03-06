using System.Linq;
using Castle.Core;
using MoMoney.Domain.accounting;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.interceptors;

namespace MoMoney.Tasks.application
{
    public interface ICustomerTasks
    {
        IAccountHolder get_the_current_customer();
    }

    [Interceptor(typeof (IUnitOfWorkInterceptor))]
    public class CustomerTasks : ICustomerTasks
    {
        private readonly IRepository repository;

        public CustomerTasks(IRepository repository)
        {
            this.repository = repository;
        }

        public IAccountHolder get_the_current_customer()
        {
            var c = repository.all<IAccountHolder>().SingleOrDefault();

            if (null == c) {
                return new AccountHolder();
            }

            return c;
        }
    }
}