using Gorilla.Commons.Infrastructure.Logging;
using momoney.service.contracts.infrastructure.transactions;

namespace MoMoney.Service.Infrastructure.Transactions
{
    public class EmptyUnitOfWork : IUnitOfWork
    {
        public void commit()
        {
            this.log().debug("committed empty unit of work");
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