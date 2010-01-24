using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
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

            static protected IEventAggregator broker;
            static protected IGettingStartedView view;
        }

        public class when_a_new_project_is_opened : behaves_like_the_getting_started_presenter
        {
            it should_display_the_getting_started_screen = () => view.was_told_to(x => x.attach_to(sut));

            because b = () => sut.present();
        }
    }
}