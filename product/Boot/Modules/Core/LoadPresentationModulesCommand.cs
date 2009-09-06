using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Modules.Core
{
    public class LoadPresentationModulesCommand : ILoadPresentationModulesCommand
    {
        readonly IRegistry<IModule> registry;
        readonly ICommandProcessor processor;

        public LoadPresentationModulesCommand(IRegistry<IModule> registry, ICommandProcessor processor)
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