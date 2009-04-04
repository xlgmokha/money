using System.Collections.Generic;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public class IdentityMapProxy<Key, Value> : IIdentityMap<Key, Value> where Value : IEntity
    {
        readonly IIdentityMap<Key, Value> real_map;
        readonly IChangeTracker<Value> change_tracker;

        public IdentityMapProxy(IChangeTracker<Value> change_tracker, IIdentityMap<Key, Value> real_map)
        {
            this.change_tracker = change_tracker;
            this.real_map = real_map;
        }

        public IEnumerable<Value> all()
        {
            return real_map.all();
        }

        public void add(Key key, Value value)
        {
            change_tracker.register(value);
            real_map.add(key, value);
        }

        public void update_the_item_for(Key key, Value new_value)
        {
            real_map.update_the_item_for(key, new_value);
        }

        public bool contains_an_item_for(Key key)
        {
            return real_map.contains_an_item_for(key);
        }

        public Value item_that_belongs_to(Key key)
        {
            return real_map.item_that_belongs_to(key);
        }

        public void remove(Key key)
        {
            real_map.remove(key);
        }
    }
}