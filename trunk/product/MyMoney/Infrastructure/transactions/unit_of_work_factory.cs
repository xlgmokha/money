using MyMoney.Domain.Core;

namespace MyMoney.Infrastructure.transactions
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork<T> create_for<T>() where T : IEntity;
    }

    public class unit_of_work_factory : IUnitOfWorkFactory
    {
        readonly IRepository repository;

        public unit_of_work_factory(IRepository repository)
        {
            this.repository = repository;
        }

        public IUnitOfWork<T> create_for<T>() where T : IEntity
        {
            return new unit_of_work<T>(repository, null);
        }
    }
}