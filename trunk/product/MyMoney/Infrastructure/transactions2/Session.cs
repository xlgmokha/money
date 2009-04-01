using System;
using System.Collections.Generic;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.caching;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ISession : IDisposable
    {
        IEnumerable<T> all<T>();
        void save<T>(T entity) where T : IEntity;
        void flush();
    }

    public class Session : ISession
    {
        readonly IIdentityMapFactory factory;
        ITransaction transaction;
        readonly IDictionary<Type, object> maps;

        public Session(IIdentityMapFactory factory, ITransaction transaction)
        {
            this.factory = factory;
            this.transaction = transaction;
            maps = new Dictionary<Type, object>();
        }

        public IEnumerable<T> all<T>()
        {
            return get_identity_map_for<T>().all();
        }

        public void save<T>(T entity) where T : IEntity
        {
            create_map_for<T>().add(entity.Id, entity);
            transaction.add_transient(entity);
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
            if (maps.ContainsKey(typeof (T)))
            {
                return (IIdentityMap<Guid, T>) maps[typeof (T)];
            }
            return create_map_for<T>();
        }

        IIdentityMap<Guid, T> create_map_for<T>()
        {
            var map = factory.create_for<T>();
            maps.Add(typeof (T), map);
            return map;
        }

    }
}