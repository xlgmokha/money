using System.Threading;
using Gorilla.Commons.Infrastructure.Container;
using presentation.windows.common;
using presentation.windows.common.messages;

namespace presentation.windows.bootstrappers
{
    public class StartServiceBus : NeedStartup
    {
        public void run()
        {
            var receiver = Resolve.the<RhinoReceiver>();
            var handler = new MessageHandler(Resolve.the<DependencyRegistry>());
            receiver.register(x =>
            {
                // synchronize with ui thread?
                handler.handler(x);
            });
            ThreadPool.QueueUserWorkItem(x =>
            {
                receiver.run();
            });

            Resolve.the<ServiceBus>().publish<StartedApplication>(x => x.message = "client");
        }
    }
}