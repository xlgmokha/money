using System;

namespace momoney.service.infrastructure.transactions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }
}