using System.Threading;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Service.Infrastructure.Threading
{
    public interface ISynchronizationContextFactory : IFactory<ISynchronizationContext>
    {
    }

    public class SynchronizationContextFactory : ISynchronizationContextFactory
    {
        readonly IDependencyRegistry registry;

        public SynchronizationContextFactory(IDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public ISynchronizationContext create()
        {
            return new SynchronizedContext(registry.get_a<SynchronizationContext>());
        }
    }
}