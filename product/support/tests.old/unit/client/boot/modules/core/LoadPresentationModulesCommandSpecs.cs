using gorilla.commons.utility;
using MoMoney.Modules.Core;
using MoMoney.Presentation;

namespace tests.unit.client.boot.modules.core
{
    public class LoadPresentationModulesCommandSpecs
    {
        [Concern(typeof (LoadPresentationModulesCommand))]
        public class when_loading_the_application_shell : runner<LoadPresentationModulesCommand>
        {
            it should_initialize_all_the_presentation_modules = () => module.was_told_to(x => x.run());

            context c = () =>
            {
                registry = dependency<Registry<IModule>>();
                module = an<IModule>();
                registry.is_told_to(r => r.all()).it_will_return(module);
            };

            because b = () => sut.run();

            static Registry<IModule> registry;
            static IModule module;
        }
    }
}