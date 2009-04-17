using System.Collections.Generic;

namespace MoMoney.Utility.Core
{
    public interface IRegistry<T>
    {
        IEnumerable<T> all();
    }
}