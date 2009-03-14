using System.Collections.Generic;
using System.Linq;

namespace MoMoney.DataAccess.db40
{
    public interface ISessionProvider
    {
        ISession get_session();
    }

    public class SessionProvider : ISessionProvider
    {
        readonly IDatabaseConfiguration database_configuration;
        readonly IConnectionFactory connection_factory;
        readonly IList<ISession> sessions;

        public SessionProvider(IDatabaseConfiguration database_configuration, IConnectionFactory connection_factory)
        {
            this.database_configuration = database_configuration;
            this.connection_factory = connection_factory;
            sessions = new List<ISession>();
        }

        public ISession get_session()
        {
            var session = sessions.SingleOrDefault(x => x.represents(database_configuration.path_to_the_database()));
            if (null == session)
            {
                session = connection_factory.open_connection_to(database_configuration.path_to_the_database());
                sessions.Add(session);
            }
            return session;
        }
    }
}