namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class EmptyUnitOfWork : IUnitOfWork
    {
        public void commit()
        {
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