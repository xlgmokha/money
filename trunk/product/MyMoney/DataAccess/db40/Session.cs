using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Db4objects.Db4o;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.DataAccess.db40
{
    public interface ISession
    {
        IEnumerable<T> query<T>() where T : IEntity;
        void save<T>(T item) where T : IEntity;
        void commit();
    }

    public class Session : ISession
    {
        readonly IObjectContainer connection;
        Guid session_id;

        public Session(IObjectContainer connection)
        {
            this.connection = connection;
            session_id = Guid.NewGuid();
        }

        public IEnumerable<T> query<T>() where T : IEntity
        {
            return connection.Query<T>();
        }

        public void save<T>(T item) where T : IEntity
        {
            if (query<T>().Count(x => x.Id.Equals(item.Id)) > 0)
            {
                this.log().debug("already added: {0}, from {1}", item, session_id);
            }
            this.log().debug("adding item: {0}, {1} {2}", item, session_id, Thread.CurrentThread.ManagedThreadId);
            connection.Store(item);
        }

        public void commit()
        {
            connection.Commit();
        }
    }
}