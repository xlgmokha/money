using System;
using System.Collections.Generic;

namespace MoMoney.Infrastructure.reflection
{
    public interface IAssembly
    {
        IEnumerable<Type> all_types();
    }
}