using System;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface IChangeTracker : IDisposable
    {
        bool is_dirty();
        void commit_to(IDatabase database);
    }

    public interface IChangeTracker<T> : IChangeTracker where T : Identifiable<Guid>
    {
        void register(T value);
        void delete(T entity);
    }
}