using System;
using System.Collections.Generic;
using Castle.Core;
using MyMoney.Domain.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Infrastructure.transactions
{
    public interface IUnitOfWorkRegistry : IDisposable
    {
        void commit_all();
        IUnitOfWork<T> start_unit_of_work_for<T>() where T : IEntity;
        void clear_all();
    }

    [Singleton]
    public class unit_of_work_registry : IUnitOfWorkRegistry
    {
        private readonly IUnitOfWorkFactory factory;
        private readonly IDictionary<Type, IUnitOfWork> units_of_work;

        public unit_of_work_registry(IUnitOfWorkFactory factory)
        {
            this.factory = factory;
            units_of_work = new Dictionary<Type, IUnitOfWork>();
        }

        public IUnitOfWork<T> start_unit_of_work_for<T>() where T : IEntity
        {
            if (units_of_work.ContainsKey(typeof (T))) {
                return units_of_work[typeof (T)].downcast_to<IUnitOfWork<T>>();
            }

            var new_unit_of_work = factory.create_for<T>();
            units_of_work.Add(typeof (T), new_unit_of_work);
            return new_unit_of_work;
        }

        public void commit_all()
        {
            if (contains_items_to_commit()) {
                units_of_work.Values.each(x => x.commit());
            }
        }

        public void clear_all()
        {
            units_of_work.Clear();
        }

        public bool contains_items_to_commit()
        {
            return units_of_work.Count > 0;
        }

        public void Dispose()
        {
            clear_all();
        }
    }
}