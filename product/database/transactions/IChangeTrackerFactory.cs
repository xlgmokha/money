using System;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface IChangeTrackerFactory
    {
        IChangeTracker<T> create_for<T>() where T : Identifiable<Guid>;
    }
}