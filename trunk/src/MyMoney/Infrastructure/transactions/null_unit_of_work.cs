using MyMoney.Domain.Core;

namespace MyMoney.Infrastructure.transactions
{
    internal class null_unit_of_work<T> : IUnitOfWork<T> where T : IEntity
    {
        public void register(T entity)
        {}

        public void commit()
        {}

        public void Dispose()
        {}
    }
}