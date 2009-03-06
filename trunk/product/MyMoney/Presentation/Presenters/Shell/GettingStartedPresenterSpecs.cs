using jpboodhoo.bdd.contexts;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.messages;
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
            //public override IGettingStartedPresenter create_sut()
            //{
            //    return new GettingStartedPresenter(view, broker);
            //}

            context c = () =>
                            {
                                view = the_dependency<IGettingStartedView>();
                                broker = the_dependency<IEventAggregator>();
                            };

            protected static IEventAggregator broker;
            protected static IGettingStartedView view;
        }

        public class when_initializing_the_getting_started_module : behaves_like_the_getting_started_presenter
        {
            it should_start_listening_for_when_a_new_project_is_started =
                () => broker.was_told_to(x => x.subscribe_to(sut));

            because b = () => sut.run();
        }

        public class when_a_new_project_is_opened : behaves_like_the_getting_started_presenter
        {
            it should_display_the_getting_started_screen = () => view.was_told_to(x => x.display());

            because b = () => sut.notify(new new_project_opened(""));
        }
    }
}