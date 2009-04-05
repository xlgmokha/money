using MoMoney.Infrastructure.Threading;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Modules.Core
{
    public interface ILoadPresentationModulesCommand : ICommand
    {
    }

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