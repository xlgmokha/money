using Gorilla.Commons.Infrastructure.Container;
using MoMoney.Service.Infrastructure.Threading;
using momoney.service.infrastructure.transactions;
using presentation.windows.common;

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
                    handler.handle(x);
                    unit_of_work.commit();
                }
            });
            Resolve.the<CommandProcessor>().add(receiver);
        }
    }
}