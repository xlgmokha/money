using System.Collections.Generic;
using momoney.database.transactions;
using MoMoney.Domain.accounting;
using MoMoney.Domain.repositories;

namespace momoney.database.repositories
{
    public class AccountHolderRepository : IAccountHolderRepository
    {
        readonly ISession session;

        public AccountHolderRepository(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<AccountHolder> all()
        {
            return session.all<AccountHolder>();
        }

        public void save(AccountHolder account_holder)
        {
            session.save(account_holder);
        }
    }
}