using System.Collections.Generic;
using MoMoney.DataAccess.core;
using MoMoney.Domain.Core;

namespace MoMoney.DataAccess.db40
{
    public class ObjectDatabaseGateway : IDatabaseGateway
    {
        readonly ISessionContext context;

        public ObjectDatabaseGateway(ISessionContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> all<T>() where T : IEntity
        {
            return open_session_with_database().query<T>();
        }

        public void save<T>(T item) where T : IEntity
        {
            var session = open_session_with_database();
            session.save(item);
            //session.commit();
        }

        ISession open_session_with_database()
        {
            return context.current_session();
        }
    }
}