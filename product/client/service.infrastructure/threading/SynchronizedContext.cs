using System.Threading;
using gorilla.commons.utility;

namespace momoney.service.infrastructure.threading
{
    public interface ISynchronizationContext : ArgCommand<Command> {}

    public class SynchronizedContext : ISynchronizationContext
    {
        readonly SynchronizationContext context;

        public SynchronizedContext(SynchronizationContext context)
        {
            this.context = context;
        }

        public void run_against(Command item)
        {
            context.Post(x => item.run(), new object());
            //context.Send(x => item.run(), new object());
        }
    }
}