using System;

namespace MyMoney.Infrastructure.Container
{
    public static class resolve
    {
        private static IDependencyRegistry underlying_registry;
        private static bool initialized;

        public static void initialize_with(IDependencyRegistry registry)
        {
            underlying_registry = registry;
            initialized = registry != null;
        }

        public static DependencyToResolve dependency_for<DependencyToResolve>()
        {
            try {
                return underlying_registry.get_a<DependencyToResolve>();
            }
            catch (Exception e) {
                throw new dependency_resolution_exception<DependencyToResolve>(e);
            }
        }

        public static bool is_initialized()
        {
            return initialized;
        }
    }
}