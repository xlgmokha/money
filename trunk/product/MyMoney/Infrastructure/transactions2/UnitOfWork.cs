using System;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }

    public class UnitOfWork : IUnitOfWork
    {
        readonly ISession session;
        readonly IContext request;
        readonly IKey<ISession> key;

        public UnitOfWork(ISession session, IContext request, IKey<ISession> key)
        {
            this.session = session;
            this.request = request;
            this.key = key;
        }

        public void commit()
        {
            if (is_dirty()) session.flush();
        }

        public bool is_dirty()
        {
            return session.is_dirty();
        }

        public void Dispose()
        {
            request.remove(key);
            session.Dispose();
        }
    }
}