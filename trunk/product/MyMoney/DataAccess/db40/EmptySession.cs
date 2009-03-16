using System;
using System.Collections.Generic;
using System.Linq;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Utility.Extensions;

namespace MoMoney.DataAccess.db40
{
    public class EmptySession : ISession
    {
        readonly HashSet<object> items;
        Guid session_id;

        public EmptySession()
        {
            items = new HashSet<object>();
            session_id = Guid.NewGuid();
        }

        public IEnumerable<T> query<T>() where T : IEntity
        {
            var enumerable = items
                .where(x => x.is_an_implementation_of<T>())
                .Select(x => x.downcast_to<T>());
            this.log().debug("items in session: {0}", enumerable.Count());
            enumerable.each(x => this.log().debug("session item {0}", x));
            return enumerable;
        }

        public void save<T>(T item) where T : IEntity
        {
            if (query<T>().Count(x => x.Id.Equals(item.Id)) > 0)
            {
                this.log().debug("already added: {0}, from {1}", item, session_id);
            }
            this.log().debug("adding item: {0}, from {1}", item, session_id);
            items.Add(item);
        }

        public void commit()
        {
            //items.Clear();
        }
    }
}