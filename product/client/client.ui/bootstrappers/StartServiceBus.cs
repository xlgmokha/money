using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.threading;
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
                handler.handle(x);
            });
            Resolve.the<CommandProcessor>().add(receiver);
            Resolve.the<ServiceBus>().publish<StartedApplication>(x => x.message = "client");
        }
    }
}