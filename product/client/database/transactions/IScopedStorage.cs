using System.Collections;

namespace momoney.database.transactions
{
    public interface IScopedStorage
    {
        IDictionary provide_storage();
    }
}