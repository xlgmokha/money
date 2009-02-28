using MyMoney.Utility.Core;

namespace MyMoney.Infrastructure.transactions
{
    public interface IUnitOfWorkRegistrationFactory<T> : IMapper<T, IUnitOfWorkRegistration<T>>
    {
    }
}