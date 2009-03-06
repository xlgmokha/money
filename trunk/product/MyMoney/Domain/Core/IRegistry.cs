using System.Collections.Generic;

namespace MoMoney.Domain.Core
{
    public interface IRegistry<T>
    {
        IEnumerable<T> all();
    }
}