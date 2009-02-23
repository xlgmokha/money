using System;
using System.Collections.Generic;
using MyMoney.Domain.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Infrastructure.transactions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
    }

    public interface IUnitOfWork<T> : IUnitOfWork where T : IEntity
    {
        void register(T entity);
    }

    public class unit_of_work<T> : IUnitOfWork<T> where T : IEntity
    {
        private readonly IRepository repository;
        private readonly IList<T> registered_items;

        public unit_of_work(IRepository repository)
        {
            this.repository = repository;
            registered_items = new List<T>();
        }

        public void register(T entity)
        {
            registered_items.Add(entity);
        }

        public void commit()
        {
            registered_items.each(x => repository.save(x));
        }

        public void Dispose()
        {
            registered_items.Clear();
        }
    }
}