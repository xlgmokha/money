using System;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.DataAccess.Transactions
{
    public interface IChangeTracker : IDisposable
    {
        bool is_dirty();
        void commit_to(IDatabase database);
    }

    public interface IChangeTracker<T> : IChangeTracker where T : IIdentifiable<Guid>
    {
        void register(T value);
        void delete(T entity);
    }
}