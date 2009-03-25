using System.Threading;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface ISynchronizationContext : IParameterizedCommand<ICommand>
    {
    }

    public class SynchronizedContext : ISynchronizationContext
    {
        readonly SynchronizationContext context;

        public SynchronizedContext(SynchronizationContext context)
        {
            this.context = context;
        }

        public void run(ICommand item)
        {
            context.Post(x => item.run(), null);
        }
    }
}