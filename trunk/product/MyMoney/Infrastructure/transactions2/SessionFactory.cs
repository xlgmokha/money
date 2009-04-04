using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ISessionFactory : IFactory<ISession>
    {
    }

    public class SessionFactory : ISessionFactory
    {
        readonly IDatabase database;
        readonly IStatementRegistry registry;
        readonly IChangeTrackerFactory factory;

        public SessionFactory(IDatabase database, IStatementRegistry registry, IChangeTrackerFactory factory)
        {
            this.database = database;
            this.registry = registry;
            this.factory = factory;
        }

        public ISession create()
        {
            return new Session(new Transaction(database, factory), database);
        }
    }
}