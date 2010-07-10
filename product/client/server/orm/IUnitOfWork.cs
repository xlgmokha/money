using System;

namespace presentation.windows.server.orm
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }
}