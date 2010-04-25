using momoney.database.transactions;
using momoney.service.infrastructure.transactions;
using MoMoney.Service.Infrastructure.Transactions;
using ISession = NHibernate.ISession;
using ISessionFactory = NHibernate.ISessionFactory;

namespace presentation.windows.server.orm.nhibernate
{
    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        readonly ISessionFactory factory;
        readonly IContext context;
        TypedKey<ISession> key = new TypedKey<ISession>();

        public NHibernateUnitOfWorkFactory(ISessionFactory factory, IContext context)
        {
            this.factory = factory;
            this.context = context;
        }

        public IUnitOfWork create()
        {
            if (context.contains(key)) return new EmptyUnitOfWork();
            var open_session = factory.OpenSession();
            context.add(key, open_session);
            return new NHibernateUnitOfWork(open_session, context);
        }
    }
}