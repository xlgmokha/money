using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using MoMoney.Presentation;

namespace MoMoney.Modules.Core
{
    public class LoadPresentationModulesCommandSpecs
    {
        [Concern(typeof (LoadPresentationModulesCommand))]
        public class when_loading_the_application_shell :
            concerns_for<ILoadPresentationModulesCommand, LoadPresentationModulesCommand>
        {
            it should_initialize_all_the_presentation_modules = () => module.was_told_to(x => x.run());

            context c = () =>
                        {
                            registry = the_dependency<Registry<IModule>>();
                            module = an<IModule>();
                            when_the(registry).is_told_to(r => r.all()).it_will_return(module);
                        };

            because b = () => sut.run();

            static Registry<IModule> registry;
            static IModule module;
        }
    }
}