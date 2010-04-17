using momoney.database.transactions;
using momoney.service.infrastructure.transactions;
using ISession = NHibernate.ISession;
using ITransaction = NHibernate.ITransaction;

namespace presentation.windows.server.orm.nhibernate
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        readonly ISession session;
        readonly IContext context;
        ITransaction transaction;

        public NHibernateUnitOfWork(ISession session, IContext context)
        {
            this.session = session;
            this.context = context;
            transaction = session.BeginTransaction();
        }

        public void Dispose()
        {
            if (!transaction.WasCommitted && !transaction.WasRolledBack)
            {
                transaction.Rollback();
            }
            session.Dispose();
            context.remove(new TypedKey<ISession>());
        }

        public void commit()
        {
            if (is_dirty()) transaction.Commit();
        }

        public bool is_dirty()
        {
            return session.IsDirty();
        }
    }
}