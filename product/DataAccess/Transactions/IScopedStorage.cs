using System.Collections;

namespace MoMoney.DataAccess.Transactions
{
    public interface IScopedStorage
    {
        IDictionary provide_storage();
    }
}