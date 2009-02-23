using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Container;

namespace MyMoney.Infrastructure.transactions
{
    public class UnitOfWork
    {
        public static IUnitOfWork<T> start_for<T>() where T : IEntity
        {
            if (resolve.is_initialized()) {
                return resolve.dependency_for<IUnitOfWorkRegistry>().start_unit_of_work_for<T>();
            }
            return new null_unit_of_work<T>();
        }
    }
}