using System;
using System.Collections.Generic;
using Db4objects.Db4o;
using momoney.database.transactions;

namespace momoney.database.db4o
{
    public class ObjectDatabaseConnection : DatabaseConnection
    {
        readonly IObjectContainer container;

        public ObjectDatabaseConnection(IObjectContainer container)
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