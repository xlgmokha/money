using gorilla.commons.utility;
using MoMoney.Presentation;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Modules.Core
{
    public class LoadPresentationModulesCommand : ILoadPresentationModulesCommand
    {
        readonly Registry<IModule> registry;
        readonly CommandProcessor processor;

        public LoadPresentationModulesCommand(Registry<IModule> registry, CommandProcessor processor)
        {
            this.registry = registry;
            this.processor = processor;
        }

        public void run()
        {
            registry.all().each(x => processor.add(x));
        }
    }
}