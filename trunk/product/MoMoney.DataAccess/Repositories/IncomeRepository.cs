using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Transactions;
using MoMoney.Domain.accounting.financial_growth;
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