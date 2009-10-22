using gorilla.commons.utility;
using momoney.service.contracts.infrastructure.transactions;

namespace MoMoney.Service.Contracts.Infrastructure.Transactions
{
    public interface IUnitOfWorkFactory : Factory<IUnitOfWork> {}
}