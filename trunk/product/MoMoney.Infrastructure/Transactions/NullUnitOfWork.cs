using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions
{
    internal class NullUnitOfWork<T> : IUnitOfWork<T> where T : IEntity
    {
        public void register(T entity)
        {
        }

        public void commit()
        {
        }

        public bool is_dirty()
        {
            return false;
        }

        public void Dispose()
        {
        }
    }
}