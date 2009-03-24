using System;
using System.Collections.Generic;
using System.Linq;
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

    public class AttachedSession : ISession
    {
        readonly IObjectContainer connection;
        readonly Guid session_id;

        public AttachedSession(IObjectContainer connection)
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
            this.log().debug("adding item: {0}, {1}", item, session_id);
            connection.Store(item);
        }

        public void commit()
        {
            connection.Commit();
        }
    }
}