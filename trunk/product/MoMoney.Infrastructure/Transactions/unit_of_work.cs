using System;
using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.DataAccess.core;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions
{
    //public interface IUnitOfWork : IDisposable
    //{
    //    void commit();
    //    bool is_dirty();
    //}

    //public interface IUnitOfWork<T> : IUnitOfWork where T : IEntity
    //{
    //    void register(T entity);
    //}

    //public class unit_of_work<T> : IUnitOfWork<T> where T : IEntity
    //{
    //    readonly IDatabaseGateway gateway;
    //    readonly IUnitOfWorkRegistrationFactory<T> factory;
    //    readonly IList<IUnitOfWorkRegistration<T>> registered_items;

    //    public unit_of_work(IDatabaseGateway repository, IUnitOfWorkRegistrationFactory<T> factory)
    //    {
    //        gateway = repository;
    //        this.factory = factory;
    //        registered_items = new List<IUnitOfWorkRegistration<T>>();
    //    }

    //    public void register(T entity)
    //    {
    //        registered_items.Add(factory.map_from(entity));
    //    }

    //    public void commit()
    //    {
    //        registered_items.each(x => { if (x.contains_changes()) gateway.save(x.current); });
    //    }

    //    public bool is_dirty()
    //    {
    //        return registered_items.Count(x => x.contains_changes()) > 0;
    //    }

    //    public void Dispose()
    //    {
    //        registered_items.Clear();
    //    }
    //}
}