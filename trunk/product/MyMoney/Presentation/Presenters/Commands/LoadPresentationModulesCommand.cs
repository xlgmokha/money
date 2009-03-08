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

        public LoadPresentationModulesCommand(IRegistry<IPresentationModule> registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            registry.all().each(x => x.run());
        }
    }
}