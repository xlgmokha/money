using System;

namespace momoney.service.contracts.infrastructure.transactions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }
}