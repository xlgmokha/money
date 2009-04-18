using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;
using MoMoney.Infrastructure.transactions2;

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