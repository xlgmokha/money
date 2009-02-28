using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Container;

namespace MyMoney.Infrastructure.transactions
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork<T> create_for<T>() where T : IEntity;
    }

    public class unit_of_work_factory : IUnitOfWorkFactory
    {
        readonly IRepository repository;
        IDependencyRegistry registry;

        public unit_of_work_factory(IRepository repository, IDependencyRegistry registry)
        {
            this.repository = repository;
            this.registry = registry;
        }

        public IUnitOfWork<T> create_for<T>() where T : IEntity
        {
            return new unit_of_work<T>(repository, registry.get_a<IUnitOfWorkRegistrationFactory<T>>());
        }
    }
}