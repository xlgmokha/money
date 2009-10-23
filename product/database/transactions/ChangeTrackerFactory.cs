using System;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public class ChangeTrackerFactory : IChangeTrackerFactory
    {
        readonly DatabaseCommandRegistry statement_registry;
        readonly DependencyRegistry registry;

        public ChangeTrackerFactory(DatabaseCommandRegistry statement_registry, DependencyRegistry registry)
        {
            this.statement_registry = statement_registry;
            this.registry = registry;
        }

        public IChangeTracker<T> create_for<T>() where T : Identifiable<Guid>
        {
            return new ChangeTracker<T>(registry.get_a<ITrackerEntryMapper<T>>(), statement_registry);
        }
    }
}