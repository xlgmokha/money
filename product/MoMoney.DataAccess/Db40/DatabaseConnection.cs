using System;
using System.Collections.Generic;
using Db4objects.Db4o;
using Gorilla.Commons.Infrastructure.Transactions;

namespace MoMoney.DataAccess.Db40
{
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