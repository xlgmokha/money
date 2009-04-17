using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Core;

namespace MoMoney.DataAccess.db40
{
    public class DetachedSession : ISession
    {
        readonly HashSet<object> items;

        public DetachedSession()
        {
            items = new HashSet<object>();
        }

        public IEnumerable<T> query<T>() where T : IEntity
        {
            return items
                .where(x => x.is_an_implementation_of<T>())
                .Select(x => x.downcast_to<T>());
        }

        public void save<T>(T item) where T : IEntity
        {
            items.Add(item);
        }

        public void commit()
        {
            //items.Clear();
        }
    }
}