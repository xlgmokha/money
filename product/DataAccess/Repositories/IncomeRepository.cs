using System.Collections.Generic;
using MoMoney.DataAccess.Transactions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;

namespace MoMoney.DataAccess.repositories
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