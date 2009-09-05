using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation;

namespace MoMoney.Modules.Core
{
    [Concern(typeof (LoadPresentationModulesCommand))]
    public class when_loading_the_application_shell : concerns_for<ILoadPresentationModulesCommand, LoadPresentationModulesCommand>
    {
        it should_initialize_all_the_presentation_modules = () => processor.was_told_to(x => x.add(module));

        context c = () =>
                        {
                            registry = the_dependency<IRegistry<IModule>>();
                            processor = the_dependency<ICommandProcessor>();
                            module = an<IModule>();
                            when_the(registry).is_told_to(r => r.all()).it_will_return(module);
                        };

        because b = () => sut.run();

        static IRegistry<IModule> registry;
        static IModule module;
        static ICommandProcessor processor;
    }
}