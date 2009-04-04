using System;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IChangeTracker
    {
        bool is_dirty();
        void commit_to(IDatabase database);
    }

    public interface IChangeTracker<T> : IChangeTracker, IDisposable where T : IEntity
    {
        void register(T value);
        void delete(T entity);
    }
}