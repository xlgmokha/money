using System.Collections.Generic;
using MoMoney.Domain.accounting;

namespace MoMoney.Domain.repositories
{
    public interface IAccountHolderRepository
    {
        IEnumerable<AccountHolder> all();
        void save(AccountHolder account_holder);
    }
}