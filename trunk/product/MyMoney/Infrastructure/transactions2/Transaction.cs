using System;
using System.Collections.Generic;
using MoMoney.Domain.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ITransaction
    {
        IIdentityMap<Guid, T> create_for<T>();
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
        readonly ICollection<IEntity> transients;
        readonly ICollection<IEntity> dirty;

        public Transaction(IStatementRegistry registry, IDatabase database)
        {
            this.registry = registry;
            this.database = database;
            transients = new HashSet<IEntity>();
            dirty = new HashSet<IEntity>();
        }

        public IIdentityMap<Guid, T> create_for<T>()
        {
            return new IdentityMap<Guid, T>();
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
            throw new NotImplementedException();
        }

        public void commit_changes()
        {
            dirty.each(x => database.apply(registry.prepare_update_statement_for(x)));
            transients.each(x => database.apply(registry.prepare_insert_statement_for(x)));
        }

        public void rollback_changes()
        {
            throw new NotImplementedException();
        }
    }
}