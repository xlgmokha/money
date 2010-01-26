using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface ISessionFactory : Factory<ISession> {}

    public class SessionFactory : ISessionFactory
    {
        readonly IDatabase database;
        readonly IChangeTrackerFactory factory;

        public SessionFactory(IDatabase database, IChangeTrackerFactory factory)
        {
            this.database = database;
            this.factory = factory;
        }

        public ISession create()
        {
            return new Session(new Transaction(database, factory), database);
        }
    }
}