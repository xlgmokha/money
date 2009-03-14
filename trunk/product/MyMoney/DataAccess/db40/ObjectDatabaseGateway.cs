using System.Collections.Generic;
using System.Linq;
using MoMoney.DataAccess.core;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Utility.Extensions;

namespace MoMoney.DataAccess.db40
{
    public class ObjectDatabaseGateway : IDatabaseGateway
    {
        readonly ISessionProvider provider;

        public ObjectDatabaseGateway(ISessionProvider provider)
        {
            this.provider = provider;
        }

        public IEnumerable<T> all<T>() where T : IEntity
        {
            using (var container = open_session_with_database())
            {
                container.Query<T>().each(x => this.log().debug("found item: {0}", x));
                return container.Query<T>().ToList();
            }
        }

        public void save<T>(T item) where T : IEntity
        {
            using (var container = open_session_with_database())
            {
                container.Store(item);
                container.Commit();
            }
        }

        ISession open_session_with_database()
        {
            return provider.get_session();
        }
    }
}