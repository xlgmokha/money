using System;
using System.Collections.Generic;
using System.Linq;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ITransaction
    {
        IIdentityMap<Guid, T> create_for<T>() where T : IEntity;
        void add_transient<T>(T entity) where T : IEntity;
        void add_dirty<T>(T modified) where T : IEntity;
        void mark_for_deletion<T>(T entity) where T : IEntity;
        void commit_changes();
        void rollback_changes();
    }

    public class Transaction : ITransaction
    {
        readonly IStatementRegistry registry;
        readonly IDatabase database;
        readonly IChangeTrackerFactory factory;
        readonly List<IEntity> transients;
        readonly List<IEntity> dirty;
        readonly List<IEntity> to_be_deleted;
        IDictionary<Type, IChangeTracker> change_trackers;

        public Transaction(IStatementRegistry registry, IDatabase database, IChangeTrackerFactory factory)
        {
            this.registry = registry;
            this.factory = factory;
            this.database = database;
            change_trackers = new Dictionary<Type, IChangeTracker>();
            transients = new List<IEntity>();
            dirty = new List<IEntity>();
            to_be_deleted = new List<IEntity>();
        }

        public IIdentityMap<Guid, T> create_for<T>() where T : IEntity
        {
            return new IdentityMapProxy<Guid, T>(get_change_tracker_for<T>(), new IdentityMap<Guid, T>());
        }

        public void add_transient<T>(T entity) where T : IEntity
        {
            transients.Add(entity);
        }

        public void add_dirty<T>(T modified) where T : IEntity
        {
            dirty.Add(modified);
        }

        public void mark_for_deletion<T>(T entity) where T : IEntity
        {
            to_be_deleted.Add(entity);
        }

        public void commit_changes()
        {
            change_trackers.Values
                .where(x => x.is_dirty())
                .each(x => x.commit_to(database));

            transients.each(x => database.apply(registry.prepare_insert_statement_for(x)));
            dirty.each(x => database.apply(registry.prepare_update_statement_for(x)));
            to_be_deleted.each(x => database.apply(registry.prepare_delete_statement_for(x)));
        }

        public void rollback_changes()
        {
            throw new NotImplementedException();
        }

        IChangeTracker<T> get_change_tracker_for<T>() where T : IEntity
        {
            if (!change_trackers.ContainsKey(typeof(T)))
            {
                var tracker = factory.create_for<T>();
                this.log().debug("tracker: {0}", tracker);
                change_trackers.Add(typeof(T), tracker);
            }
            return change_trackers[typeof (T)].downcast_to<IChangeTracker<T>>();
        }
    }
}