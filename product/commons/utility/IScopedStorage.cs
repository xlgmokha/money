using System.Collections;

namespace gorilla.commons.utility
{
    public interface IScopedStorage
    {
        IDictionary provide_storage();
    }
}