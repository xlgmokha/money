using System.Collections.Generic;

namespace MoMoney.Infrastructure.caching
{
    public interface IIdentityMap<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        void UpdateTheItemFor(TKey key, TValue newValue);
        bool ContainsAnItemFor(TKey key);
        TValue ItemThatBelongsTo(TKey key);
    }

    public class IdentityMap<TKey, TValue> : IIdentityMap<TKey, TValue>
    {
        readonly IDictionary<TKey, TValue> itemsInMap;

        public IdentityMap() : this(new Dictionary<TKey, TValue>())
        {
        }

        public IdentityMap(IDictionary<TKey, TValue> itemsInMap)
        {
            this.itemsInMap = itemsInMap;
        }

        public void Add(TKey key, TValue value)
        {
            itemsInMap.Add(key, value);
        }

        public void UpdateTheItemFor(TKey key, TValue newValue)
        {
            if (ContainsAnItemFor(key))
            {
                itemsInMap[key] = newValue;
            }
            else
            {
                Add(key, newValue);
            }
        }

        public bool ContainsAnItemFor(TKey key)
        {
            return itemsInMap.ContainsKey(key);
        }

        public TValue ItemThatBelongsTo(TKey key)
        {
            return ContainsAnItemFor(key) ? itemsInMap[key] : default(TValue);
        }
    }
}