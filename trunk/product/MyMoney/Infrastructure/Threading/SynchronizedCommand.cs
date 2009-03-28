using System;
using System.Threading;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface ISynchronizedCommand : IParameterizedCommand<Action>, IParameterizedCommand<ICommand>
    {
    }

    public class SynchronizedCommand : ISynchronizedCommand
    {
        readonly SynchronizationContext context;

        public SynchronizedCommand(SynchronizationContext context)
        {
            this.context = context;
        }

        public void run(Action item)
        {
            context.Post(x =>
                             {
                                 this.log().debug("posting action");
                                 item();
                             }, new object());
        }

        public void run(ICommand item)
        {
            run(item.run);
        }
    }
}