using System;
using System.Linq;
using System.Collections.Generic;
using MoMoney.Domain.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.transactions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }

    public interface IUnitOfWork<T> : IUnitOfWork where T : IEntity
    {
        void register(T entity);
    }

    public class unit_of_work<T> : IUnitOfWork<T> where T : IEntity
    {
        readonly IRepository repository;
        readonly IUnitOfWorkRegistrationFactory<T> factory;
        readonly IList<IUnitOfWorkRegistration<T>> registered_items;

        public unit_of_work(IRepository repository, IUnitOfWorkRegistrationFactory<T> factory)
        {
            this.repository = repository;
            this.factory = factory;
            registered_items = new List<IUnitOfWorkRegistration<T>>();
        }

        public void register(T entity)
        {
            registered_items.Add(factory.map_from(entity));
        }

        public void commit()
        {
            registered_items.each(x => repository.save(x.current));
        }

        public bool is_dirty()
        {
            return registered_items.Count(x => x.contains_changes()) > 0;
        }

        public void Dispose()
        {
            registered_items.Clear();
        }
    }

}