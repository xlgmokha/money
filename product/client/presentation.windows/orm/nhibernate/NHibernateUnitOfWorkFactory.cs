using momoney.database.transactions;
using momoney.service.infrastructure.transactions;
using ISession = NHibernate.ISession;
using ISessionFactory = NHibernate.ISessionFactory;

namespace presentation.windows.orm.nhibernate
{
    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        readonly ISessionFactory factory;
        readonly IContext context;

        public NHibernateUnitOfWorkFactory(ISessionFactory factory, IContext context)
        {
            this.factory = factory;
            this.context = context;
        }

        public IUnitOfWork create()
        {
            var open_session = factory.OpenSession();
            context.add(new TypedKey<ISession>(), open_session);
            return new NHibernateUnitOfWork(open_session, context);
        }
    }
}