using System;

namespace MoMoney.Service.Contracts.Infrastructure.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }
}