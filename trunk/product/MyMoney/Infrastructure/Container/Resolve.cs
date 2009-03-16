using System;

namespace MoMoney.Infrastructure.Container
{
    static public class resolve
    {
        static IDependencyRegistry underlying_registry;
        static bool initialized;

        static public void initialize_with(IDependencyRegistry registry)
        {
            underlying_registry = registry;
            initialized = registry != null;
        }

        static public DependencyToResolve dependency_for<DependencyToResolve>()
        {
            try
            {
                return underlying_registry.get_a<DependencyToResolve>();
            }
            catch (Exception e)
            {
                throw new dependency_resolution_exception<DependencyToResolve>(e);
            }
        }

        static public bool is_initialized()
        {
            return initialized;
        }
    }
}