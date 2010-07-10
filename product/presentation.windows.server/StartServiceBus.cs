using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.threading;
using presentation.windows.common;
using presentation.windows.server.orm;

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