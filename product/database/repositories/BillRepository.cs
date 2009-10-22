using System.Collections.Generic;
using momoney.database.transactions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;

namespace momoney.database.repositories
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