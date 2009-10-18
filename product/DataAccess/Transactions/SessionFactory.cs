using Gorilla.Commons.Utility.Core;

namespace MoMoney.DataAccess.Transactions
{
    public interface ISessionFactory : IFactory<ISession>
    {
    }

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