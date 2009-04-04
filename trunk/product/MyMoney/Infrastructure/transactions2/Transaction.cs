using System;
using System.Collections.Generic;
using MoMoney.Domain.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ITransaction
    {
        IIdentityMap<Guid, T> create_for<T>() where T : IEntity;
        //void mark_for_deletion<T>(T entity) where T : IEntity;
        void commit_changes();
        void rollback_changes();
    }

    public class Transaction : ITransaction
    {
        readonly IDatabase database;
        readonly IChangeTrackerFactory factory;
        readonly IDictionary<Type, IChangeTracker> change_trackers;

        public Transaction(IDatabase database, IChangeTrackerFactory factory)
        {
            this.factory = factory;
            this.database = database;
            change_trackers = new Dictionary<Type, IChangeTracker>();
        }

        public IIdentityMap<Guid, T> create_for<T>() where T : IEntity
        {
            return new IdentityMapProxy<Guid, T>(get_change_tracker_for<T>(), new IdentityMap<Guid, T>());
        }

        public void commit_changes()
        {
            change_trackers.Values.where(x => x.is_dirty()).each(x => x.commit_to(database));
        }

        public void rollback_changes()
        {
            throw new NotImplementedException();
        }

        IChangeTracker<T> get_change_tracker_for<T>() where T : IEntity
        {
            if (!change_trackers.ContainsKey(typeof (T))) change_trackers.Add(typeof (T), factory.create_for<T>());
            return change_trackers[typeof (T)].downcast_to<IChangeTracker<T>>();
        }
    }
}