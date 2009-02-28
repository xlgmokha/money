using System.Collections.Generic;

namespace MyMoney.Domain.Core
{
    public interface IRegistry<T>
    {
        IEnumerable<T> all();
    }
}