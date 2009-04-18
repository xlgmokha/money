using Gorilla.Commons.Infrastructure.Container;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public class ChangeTrackerFactory : IChangeTrackerFactory
    {
        readonly IStatementRegistry statement_registry;
        readonly IDependencyRegistry registry;

        public ChangeTrackerFactory(IStatementRegistry statement_registry, IDependencyRegistry registry)
        {
            this.statement_registry = statement_registry;
            this.registry = registry;
        }

        public IChangeTracker<T> create_for<T>() where T : IEntity
        {
            return new ChangeTracker<T>(registry.get_a<ITrackerEntryMapper<T>>(), statement_registry);
        }
    }
}