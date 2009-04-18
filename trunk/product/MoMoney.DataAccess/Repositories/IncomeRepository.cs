using System.Collections.Generic;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Domain.repositories;
using MoMoney.Infrastructure.transactions2;

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