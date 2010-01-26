using System.Linq;
using gorilla.commons.utility;
using MoMoney.Domain.accounting;
using MoMoney.Domain.repositories;

namespace MoMoney.Service.Application
{
    public interface IGetTheCurrentCustomerQuery : Query<AccountHolder> {}

    public class GetTheCurrentCustomerQuery : IGetTheCurrentCustomerQuery
    {
        readonly IAccountHolderRepository account_holders;

        public GetTheCurrentCustomerQuery(IAccountHolderRepository account_holders)
        {
            this.account_holders = account_holders;
        }

        public AccountHolder fetch()
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