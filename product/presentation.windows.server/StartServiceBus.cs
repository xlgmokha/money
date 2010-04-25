using System;
using Gorilla.Commons.Infrastructure.Container;
using presentation.windows.common;
using presentation.windows.common.messages;

namespace presentation.windows.server
{
    public class StartServiceBus : NeedStartup
    {
        public void run()
        {
            var receiver = Resolve.the<RhinoReceiver>();
            receiver.register(x => Console.Out.WriteLine(x));
            Resolve.the<ServiceBus>().publish<StartedApplication>(x => x.message = "server");
            receiver.run();
        }
    }
}