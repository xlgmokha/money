using System.Collections.Generic;
using momoney.database.transactions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;

namespace momoney.database.repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        readonly ISession session;

        public IncomeRepository(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<IIncome> all()
        {
            return session.all<IIncome>();
        }
    }
}