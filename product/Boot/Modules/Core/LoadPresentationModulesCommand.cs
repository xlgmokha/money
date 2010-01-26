using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using MoMoney.Presentation;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Modules.Core
{
    public class LoadPresentationModulesCommand : ILoadPresentationModulesCommand
    {
        Registry<IModule> registry;
        IEventAggregator broker;

        public LoadPresentationModulesCommand(Registry<IModule> registry, IEventAggregator broker)
        {
            this.registry = registry;
            this.broker = broker;
        }

        public void run()
        {
            registry
                .all()
                .each(x =>
                      {
                          this.log().debug("loading... {0}", x);
                          broker.subscribe(x);
                          x.run();
                      });
        }
    }
}