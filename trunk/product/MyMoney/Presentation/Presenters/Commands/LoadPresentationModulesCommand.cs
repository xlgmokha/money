using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Core;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.Commands
{
    public interface ILoadPresentationModulesCommand : ICommand
    {
    }

    public class LoadPresentationModulesCommand : ILoadPresentationModulesCommand
    {
        readonly IRegistry<IPresentationModule> registry;
        readonly ICommandProcessor processor;

        public LoadPresentationModulesCommand(IRegistry<IPresentationModule> registry, ICommandProcessor processor)
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