using System.Collections.Generic;

namespace MyMoney.Infrastructure.Container
{
    public interface IDependencyRegistry
    {
        Interface find_an_implementation_of<Interface>();
        IEnumerable<Interface> all_implementations_of<Interface>();
    }
}