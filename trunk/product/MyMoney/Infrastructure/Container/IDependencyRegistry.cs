using System.Collections.Generic;

namespace MoMoney.Infrastructure.Container
{
    public interface IDependencyRegistry
    {
        Interface get_a<Interface>();
        IEnumerable<Interface> all_the<Interface>();
    }
}