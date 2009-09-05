using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Modules
{
    public class GettingStartedModuleSpecs
    {
        public class behaves_like_the_getting_started_module :
            concerns_for<IGettingStartedModule, GettingStartedModule>
        {
            context c = () =>
                            {
                                broker = the_dependency<IEventAggregator>();
                                command = the_dependency<IRunPresenterCommand>();
                            };

            static protected IEventAggregator broker;
            static protected IRunPresenterCommand command;
        }

        public class when_initializing_the_getting_started_module : behaves_like_the_getting_started_module
        {
            it should_start_listening_for_when_a_new_project_is_started = () => broker.was_told_to(x => x.subscribe((GettingStartedModule)sut));

            because b = () => sut.run();
        }
    }
}