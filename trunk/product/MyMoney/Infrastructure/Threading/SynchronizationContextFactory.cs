using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface ISynchronizationContextFactory : IFactory<ISynchronizationContext>
    {
    }

    public class SynchronizationContextFactory : ISynchronizationContextFactory
    {
        readonly ISynchronizationContext context;

        public SynchronizationContextFactory(ISynchronizationContext context)
        {
            this.context = context;
        }

        public ISynchronizationContext create()
        {
            return context;
        }
    }
}