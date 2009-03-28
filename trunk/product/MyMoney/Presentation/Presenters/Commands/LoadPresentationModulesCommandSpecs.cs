using developwithpassion.bdd.contexts;
using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Core;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    [Concern(typeof (LoadPresentationModulesCommand))]
    public class when_loading_the_application_shell : concerns_for<ILoadPresentationModulesCommand, LoadPresentationModulesCommand>
    {
        it should_initialize_all_the_presentation_modules = () => processor.was_told_to(x => x.add(module));

        context c = () =>
                        {
                            registry = the_dependency<IRegistry<IPresentationModule>>();
                            processor = the_dependency<ICommandProcessor>();
                            module = an<IPresentationModule>();
                            when_the(registry).is_told_to(r => r.all()).it_will_return(module);
                        };

        because b = () => sut.run();

        static IRegistry<IPresentationModule> registry;
        static IPresentationModule module;
        static ICommandProcessor processor;
    }
}