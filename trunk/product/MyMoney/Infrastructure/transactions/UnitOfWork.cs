using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Container;

namespace MoMoney.Infrastructure.transactions
{
    static public class UnitOfWork
    {
        static public IUnitOfWork<T> For<T>() where T : IEntity
        {
            if (resolve.is_initialized())
            {
                return resolve.dependency_for<IUnitOfWorkRegistry>().start_unit_of_work_for<T>();
            }
            return new NullUnitOfWork<T>();
        }
    }
}