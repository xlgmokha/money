using System.Collections;

namespace momoney.database.transactions
{
    public class SingletonScopedStorage : IScopedStorage
    {
        static readonly IDictionary storage = new Hashtable();

        public IDictionary provide_storage()
        {
            return storage;
        }
    }
}