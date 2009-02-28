using System.Linq;
using Castle.Core;
using MyMoney.Domain.accounting;
using MyMoney.Domain.Core;
using MyMoney.Infrastructure.interceptors;

namespace MyMoney.Tasks.application
{
    public interface ICustomerTasks
    {
        IAccountHolder get_the_current_customer();
    }

    [Interceptor(typeof (IUnitOfWorkInterceptor))]
    public class customer_tasks : ICustomerTasks
    {
        private readonly IRepository repository;

        public customer_tasks(IRepository repository)
        {
            this.repository = repository;
        }

        public IAccountHolder get_the_current_customer()
        {
            var c = repository.all<IAccountHolder>().SingleOrDefault();

            if (null == c) {
                return new account_holder();
            }

            return c;
        }
    }
}