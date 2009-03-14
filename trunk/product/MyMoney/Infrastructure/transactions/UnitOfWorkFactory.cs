using MoMoney.DataAccess.core;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Container;

namespace MoMoney.Infrastructure.transactions
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork<T> create_for<T>() where T : IEntity;
    }

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        readonly IDatabaseGateway repository;
        readonly IDependencyRegistry registry;

        public UnitOfWorkFactory(IDatabaseGateway repository, IDependencyRegistry registry)
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