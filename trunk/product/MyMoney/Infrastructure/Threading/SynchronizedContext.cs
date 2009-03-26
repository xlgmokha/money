using System;
using System.Threading;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public class SynchronizedContext : ISynchronizationContext
    {
        readonly SynchronizationContext context;

        public SynchronizedContext(SynchronizationContext context)
        {
            if (context != null) this.context = context;
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void run(ICommand item)
        {
            context.Post(x => item.run(), null);
        }
    }
}