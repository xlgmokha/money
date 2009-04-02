using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ITransaction
    {
        void add_transient<T>(T entity) where T : IEntity;
        void add_dirty<T>(T modified) where T : IEntity;
        void commit_changes();
        void rollback_changes();
    }
}