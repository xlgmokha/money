using momoney.database.transactions;
using momoney.service.infrastructure.transactions;

namespace MoMoney.Service.Infrastructure.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ISession session;
        readonly IContext context;
        readonly IKey<ISession> key;

        public UnitOfWork(ISession session, IContext context, IKey<ISession> key)
        {
            this.session = session;
            this.context = context;
            this.key = key;
        }

        public void commit()
        {
            if (is_dirty()) session.flush();
        }

        public bool is_dirty()
        {
            return session.is_dirty();
        }

        public void Dispose()
        {
            context.remove(key);
            session.Dispose();
        }
    }
}