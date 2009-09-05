using System;

namespace MoMoney.Service.Infrastructure.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }
}