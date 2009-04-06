using System.Collections.Generic;
using Db4objects.Db4o;
using MoMoney.Domain.Core;

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

        public AttachedSession(IObjectContainer connection)
        {
            this.connection = connection;
        }

        public IEnumerable<T> query<T>() where T : IEntity
        {
            return connection.Query<T>();
        }

        public void save<T>(T item) where T : IEntity
        {
            connection.Store(item);
        }

        public void commit()
        {
            connection.Commit();
        }
    }
}