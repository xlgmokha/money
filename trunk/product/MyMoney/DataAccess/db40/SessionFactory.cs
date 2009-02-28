using Db4objects.Db4o;
using MyMoney.Utility.Core;

namespace MyMoney.DataAccess.db40
{
    public interface ISessionFactory : IFactory<IObjectContainer>
    {
    }

    public class SessionFactory : ISessionFactory
    {
        readonly IDatabaseConfiguration database_configuration;
        readonly IConnectionFactory connection_factory;

        public SessionFactory(IDatabaseConfiguration database_configuration, IConnectionFactory connection_factory)
        {
            this.database_configuration = database_configuration;
            this.connection_factory = connection_factory;
        }

        public IObjectContainer create()
        {
            return connection_factory.open_connection_to(database_configuration.path_to_the_database());
        }
    }
}