using Db4objects.Db4o;

namespace MoMoney.DataAccess.db40
{
    public interface ISessionProvider
    {
        IObjectContainer get_session();
    }

    public class SessionProvider : ISessionProvider
    {
        readonly IDatabaseConfiguration database_configuration;
        readonly IConnectionFactory connection_factory;

        public SessionProvider(IDatabaseConfiguration database_configuration, IConnectionFactory connection_factory)
        {
            this.database_configuration = database_configuration;
            this.connection_factory = connection_factory;
        }

        public IObjectContainer get_session()
        {
            return connection_factory.open_connection_to(database_configuration.path_to_the_database());
        }
    }
}