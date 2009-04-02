using System;
using System.Collections.Generic;
using System.Linq;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.caching;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ISession : IDisposable
    {
        IEntity find<T>(Guid guid) where T : IEntity;
        IEnumerable<T> all<T>() where T : IEntity;
        void save<T>(T entity) where T : IEntity;
        void update<T>(T entity) where T : IEntity;
        void flush();
    }

    public class Session : ISession
    {
        readonly IIdentityMapFactory factory;
        ITransaction transaction;
        readonly IDatabase database;
        readonly IDictionary<Type, object> identity_maps;

        public Session(IIdentityMapFactory factory, ITransaction transaction, IDatabase database)
        {
            this.factory = factory;
            this.database = database;
            this.transaction = transaction;
            identity_maps = new Dictionary<Type, object>();
        }

        public IEntity find<T>(Guid id) where T : IEntity
        {
            var identity_map = get_identity_map_for<T>();
            if (identity_map.contains_an_item_for(id))
            {
                return identity_map.item_that_belongs_to(id);
            }
            var entity = database.fetch_all<T>().Single(x => x.Id.Equals(id));
            identity_map.add(id, entity);
            return entity;
        }

        public IEnumerable<T> all<T>() where T : IEntity
        {
            var identity_map = get_identity_map_for<T>();
            var uncached_items = database
                .fetch_all<T>()
                .where(x => !identity_map.contains_an_item_for(x.Id));
            uncached_items.each(x => identity_map.add(x.Id, x));
            return uncached_items.join_with(identity_map.all());
        }

        public void save<T>(T entity) where T : IEntity
        {
            create_map_for<T>().add(entity.Id, entity);
            transaction.add_transient(entity);
        }

        public void update<T>(T entity) where T : IEntity
        {
            get_identity_map_for<T>().update_the_item_for(entity.Id, entity);
            transaction.add_dirty(entity);
        }

        public void flush()
        {
            transaction.commit_changes();
            transaction = null;
        }

        public void Dispose()
        {
            if (null != transaction) transaction.rollback_changes();
        }

        IIdentityMap<Guid, T> get_identity_map_for<T>()
        {
            var type = typeof (T);
            return identity_maps.ContainsKey(type)
                       ? identity_maps[type].downcast_to<IIdentityMap<Guid, T>>()
                       : create_map_for<T>();
        }

        IIdentityMap<Guid, T> create_map_for<T>()
        {
            var identity_map = factory.create_for<T>();
            identity_maps.Add(typeof (T), identity_map);
            return identity_map;
        }
    }
}