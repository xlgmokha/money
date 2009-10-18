using Gorilla.Commons.Utility.Core;

namespace MoMoney.Service.Contracts.Infrastructure.Transactions
{
    public interface IUnitOfWorkFactory : IFactory<IUnitOfWork>
    {
    }
}