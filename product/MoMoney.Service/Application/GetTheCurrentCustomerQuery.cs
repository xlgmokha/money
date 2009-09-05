using System.Linq;
using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.accounting;
using MoMoney.Domain.repositories;

namespace MoMoney.Service.Application
{
    public interface IGetTheCurrentCustomerQuery : IQuery<IAccountHolder>
    {
    }

    public class GetTheCurrentCustomerQuery : IGetTheCurrentCustomerQuery
    {
        readonly IAccountHolderRepository account_holders;

        public GetTheCurrentCustomerQuery(IAccountHolderRepository account_holders)
        {
            this.account_holders = account_holders;
        }

        public IAccountHolder fetch()
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