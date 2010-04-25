using System.Threading;
using Gorilla.Commons.Infrastructure.Container;
using momoney.service.infrastructure.transactions;
using presentation.windows.common;
using presentation.windows.common.messages;

namespace presentation.windows.server
{
    public class StartServiceBus : NeedStartup
    {
        public void run()
        {
            var receiver = Resolve.the<RhinoReceiver>();
            var handler = new MessageHandler(Resolve.the<DependencyRegistry>());
            receiver.register(x =>
            {
                using (var unit_of_work = Resolve.the<IUnitOfWorkFactory>().create())
                {
                    handler.handler(x);
                    unit_of_work.commit();
                }
            });
            ThreadPool.QueueUserWorkItem(x => receiver.run());
            Resolve.the<ServiceBus>().publish<StartedApplication>(x => x.message = "server");
        }
    }
}