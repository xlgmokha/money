using System;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Logging;

namespace MoMoney.Infrastructure.transactions
{
    static public class UnitOfWork
    {
        static public IUnitOfWork<T> For<T>() where T : IEntity
        {
            IUnitOfWork<T> unit_of_work = null;
            if (resolve.is_initialized())
            {
                try
                {
                    unit_of_work = resolve.dependency_for<IUnitOfWorkRegistry>().start_unit_of_work_for<T>();
                }
                catch (Exception exception)
                {
                    Log.For(typeof (UnitOfWork)).error(exception);
                }
            }
            return unit_of_work ?? new NullUnitOfWork<T>();
        }
    }
}