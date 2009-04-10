using System.Collections.Generic;
using System.Linq;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public class Database : IDatabase
    {
        readonly IDatabaseConfiguration configuration;
        readonly IConnectionFactory factory;

        public Database(IDatabaseConfiguration configuration, IConnectionFactory factory)
        {
            this.configuration = configuration;
            this.factory = factory;
        }

        public IEnumerable<T> fetch_all<T>() where T : IEntity
        {
            using (var connection = factory.open_connection_to(configuration.path_to_database()))
            {
                return connection.query<T>().ToList();
            }
        }

        public void apply(IStatement statement)
        {
            using (var connection = factory.open_connection_to(configuration.path_to_database()))
            {
                statement.prepare(connection);
                connection.commit();
            }
        }
    }
}