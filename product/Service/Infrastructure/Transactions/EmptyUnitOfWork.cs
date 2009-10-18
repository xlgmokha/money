using Gorilla.Commons.Infrastructure.Logging;
using MoMoney.Service.Contracts.Infrastructure.Transactions;

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