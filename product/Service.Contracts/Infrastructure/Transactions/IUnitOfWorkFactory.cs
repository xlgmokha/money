using Gorilla.Commons.Utility.Core;
using MoMoney.Service.Infrastructure.Transactions;

namespace MoMoney.Service.Contracts.Infrastructure.Transactions
{
    public interface IUnitOfWorkFactory : IFactory<IUnitOfWork>
    {
    }
}