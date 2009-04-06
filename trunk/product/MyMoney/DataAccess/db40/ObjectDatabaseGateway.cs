using System.Collections.Generic;
using MoMoney.DataAccess.core;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.transactions2;

namespace MoMoney.DataAccess.db40
{
    public class ObjectDatabaseGateway : IDatabaseGateway
    {
        readonly ISessionContext context;
        readonly ISessionProvider session_provider;

        public ObjectDatabaseGateway(ISessionContext context, ISessionProvider session_provider)
        {
            this.context = context;
            this.session_provider = session_provider;
        }

        public IEnumerable<T> all<T>() where T : IEntity
        {
            return open_session_with_database().all<T>();
        }

        public void save<T>(T item) where T : IEntity
        {
            open_session_with_database().save(item);
        }

        Infrastructure.transactions2.ISession open_session_with_database()
        {
            return session_provider.get_the_current_session();
            //return context.current_session();
        }
    }
}