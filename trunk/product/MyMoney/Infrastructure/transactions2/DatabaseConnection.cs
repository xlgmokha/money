using System;
using System.Collections.Generic;
using Db4objects.Db4o;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IDatabaseConnection : IDisposable
    {
        IEnumerable<T> query<T>();
        IEnumerable<T> query<T>(Predicate<T> predicate);
        void delete<T>(T entity);
        void commit();
        void store<T>(T entity);
    }

    public class DatabaseConnection : IDatabaseConnection
    {
        readonly IObjectContainer container;

        public DatabaseConnection(IObjectContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
            container.Close();
            container.Dispose();
        }

        public IEnumerable<T> query<T>()
        {
            return container.Query<T>();
        }

        public IEnumerable<T> query<T>(Predicate<T> predicate)
        {
            return container.Query(predicate);
        }

        public void delete<T>(T entity)
        {
            container.Delete(entity);
        }

        public void commit()
        {
            container.Commit();
        }

        public void store<T>(T entity)
        {
            container.Store(entity);
        }
    }
}