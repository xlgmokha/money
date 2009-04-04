using System;
using System.Collections.Generic;
using System.Linq;
using MoMoney.Domain.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ISession : IDisposable
    {
        IEntity find<T>(Guid guid) where T : IEntity;
        IEnumerable<T> all<T>() where T : IEntity;
        void save<T>(T entity) where T : IEntity;
        void delete<T>(T entity) where T : IEntity;
        void flush();
    }

    public class Session : ISession
    {
        ITransaction transaction;
        readonly IDatabase database;
        readonly IDictionary<Type, object> identity_maps;

        public Session(ITransaction transaction, IDatabase database)
        {
            this.database = database;
            this.transaction = transaction;
            identity_maps = new Dictionary<Type, object>();
        }

        public IEntity find<T>(Guid id) where T : IEntity
        {
            if (get_identity_map_for<T>().contains_an_item_for(id))
            {
                return get_identity_map_for<T>().item_that_belongs_to(id);
            }

            var entity = database.fetch_all<T>().Single(x => x.Id.Equals(id));
            get_identity_map_for<T>().add(id, entity);
            return entity;
        }

        public IEnumerable<T> all<T>() where T : IEntity
        {
            var uncached_items = database
                .fetch_all<T>()
                .where(x => !get_identity_map_for<T>().contains_an_item_for(x.Id));
            uncached_items.each(x => get_identity_map_for<T>().add(x.Id, x));
            return get_identity_map_for<T>().all();
        }

        public void save<T>(T entity) where T : IEntity
        {
            get_identity_map_for<T>().add(entity.Id, entity);
        }

        public void delete<T>(T entity) where T : IEntity
        {
            get_identity_map_for<T>().evict(entity.Id);
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

        IIdentityMap<Guid, T> get_identity_map_for<T>() where T : IEntity
        {
            return identity_maps.ContainsKey(typeof (T))
                       ? identity_maps[typeof (T)].downcast_to<IIdentityMap<Guid, T>>()
                       : create_map_for<T>();
        }

        IIdentityMap<Guid, T> create_map_for<T>() where T : IEntity
        {
            var identity_map = transaction.create_for<T>();
            identity_maps.Add(typeof (T), identity_map);
            return identity_map;
        }
    }
}