using System;
using System.Threading;
using gorilla.commons.utility;

namespace momoney.service.infrastructure.threading
{
    public interface ISynchronizedCommand : ArgCommand<Action>, ArgCommand<Command> {}

    public class SynchronizedCommand : ISynchronizedCommand
    {
        readonly SynchronizationContext context;

        public SynchronizedCommand(SynchronizationContext context)
        {
            this.context = context;
        }

        public void run_against(Action item)
        {
            context.Post(x => item(), new object());
        }

        public void run_against(Command item)
        {
            run_against(item.run);
        }
    }
}