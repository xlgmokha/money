using developwithpassion.bdd.contexts;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.Shell
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

            protected static IEventAggregator broker;
            protected static IRunPresenterCommand command;
        }

        public class when_initializing_the_getting_started_module : behaves_like_the_getting_started_module
        {
            it should_start_listening_for_when_a_new_project_is_started =
                () => broker.was_told_to(x => x.subscribe_to(sut));

            because b = () => sut.run();
        }
    }
}