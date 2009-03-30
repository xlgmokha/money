using System.Collections.Generic;

namespace MoMoney.Infrastructure.caching
{
    public interface IIdentityMap<TKey, TValue>
    {
        void add(TKey key, TValue value);
        void update_the_item_for(TKey key, TValue new_value);
        bool contains_an_item_for(TKey key);
        TValue item_that_belongs_to(TKey key);
    }

    public class IdentityMap<TKey, TValue> : IIdentityMap<TKey, TValue>
    {
        readonly IDictionary<TKey, TValue> items_in_map;

        public IdentityMap() : this(new Dictionary<TKey, TValue>())
        {
        }

        public IdentityMap(IDictionary<TKey, TValue> items_in_map)
        {
            this.items_in_map = items_in_map;
        }

        public void add(TKey key, TValue value)
        {
            items_in_map.Add(key, value);
        }

        public void update_the_item_for(TKey key, TValue new_value)
        {
            if (contains_an_item_for(key)) items_in_map[key] = new_value;
            else add(key, new_value);
        }

        public bool contains_an_item_for(TKey key)
        {
            return items_in_map.ContainsKey(key);
        }

        public TValue item_that_belongs_to(TKey key)
        {
            return contains_an_item_for(key) ? items_in_map[key] : default(TValue);
        }
    }
}