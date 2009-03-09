using jpboodhoo.bdd.contexts;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.Shell
{
    public class GettingStartedPresenterSpecs
    {
        public class behaves_like_the_getting_started_presenter :
            concerns_for<IGettingStartedPresenter, GettingStartedPresenter>
        {
            context c = () =>
                            {
                                view = the_dependency<IGettingStartedView>();
                                broker = the_dependency<IEventAggregator>();
                            };

            protected static IEventAggregator broker;
            protected static IGettingStartedView view;
        }

        public class when_a_new_project_is_opened : behaves_like_the_getting_started_presenter
        {
            it should_display_the_getting_started_screen = () => view.was_told_to(x => x.display());

            because b = () => sut.run();
        }
    }
}