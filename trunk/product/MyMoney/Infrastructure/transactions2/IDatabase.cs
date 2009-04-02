using System.Collections.Generic;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IDatabase
    {
        IEnumerable<T> fetch_all<T>();
    }
}