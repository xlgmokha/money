using System;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IChangeTrackerFactory
    {
        IChangeTracker<T> create_for<T>() where T : IIdentifiable<Guid>;
    }
}