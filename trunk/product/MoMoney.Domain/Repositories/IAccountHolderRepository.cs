using System.Collections.Generic;
using MoMoney.Domain.accounting;

namespace MoMoney.Domain.repositories
{
    public interface IAccountHolderRepository
    {
        IEnumerable<IAccountHolder> all();
        void save(IAccountHolder account_holder);
    }
}