using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Transactions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;

namespace MoMoney.DataAccess.repositories
{
    public class BillRepository : IBillRepository
    {
        readonly ISession session;

        public BillRepository(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<IBill> all()
        {
            return session.all<IBill>();
        }
    }
}